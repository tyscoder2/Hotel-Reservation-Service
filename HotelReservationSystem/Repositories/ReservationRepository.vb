Imports Microsoft.Data.SqlClient

Public Class ReservationRepository
    Public Function Create(reservation As Reservation) As Integer

        If reservation.CheckOutDate.Date <= reservation.CheckInDate.Date Then
            Throw New ArgumentException(
            "Check-out date must be after check-in date.")
        End If

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            connection.Open()

            Using transaction As SqlTransaction =
            connection.BeginTransaction()

                Try
                    ' Lock the room row so concurrent reservation creation
                    ' for this room must wait until this transaction finishes.
                    Const roomSql As String =
                    "SELECT Status, IsActive " &
                    "FROM Rooms WITH (UPDLOCK, HOLDLOCK) " &
                    "WHERE RoomID = @RoomID;"

                    Using command As New SqlCommand(
                    roomSql, connection, transaction)

                        command.Parameters.Add(
                        "@RoomID", SqlDbType.Int).Value =
                        reservation.RoomID

                        Using reader As SqlDataReader =
                        command.ExecuteReader()

                            If Not reader.Read() Then
                                Throw New InvalidOperationException(
                                "The selected room could not be found.")
                            End If

                            Dim roomStatus As String =
                            reader("Status").ToString()

                            Dim isActive As Boolean =
                            Convert.ToBoolean(reader("IsActive"))

                            If Not isActive Then
                                Throw New InvalidOperationException(
                                "The selected room is no longer active.")
                            End If

                            If roomStatus <> "Available" AndAlso
                           roomStatus <> "Occupied" Then

                                Throw New InvalidOperationException(
                                "The selected room is not available for reservations.")
                            End If

                        End Using
                    End Using

                    ' Recheck date conflicts inside the transaction.
                    Const overlapSql As String =
                    "SELECT COUNT(*) " &
                    "FROM Reservations WITH (UPDLOCK, HOLDLOCK) " &
                    "WHERE RoomID = @RoomID " &
                    "AND Status IN ('Pending', 'Confirmed', 'Checked In') " &
                    "AND CheckInDate < @CheckOutDate " &
                    "AND CheckOutDate > @CheckInDate;"

                    Using command As New SqlCommand(
                    overlapSql, connection, transaction)

                        command.Parameters.Add(
                        "@RoomID", SqlDbType.Int).Value =
                        reservation.RoomID

                        command.Parameters.Add(
                        "@CheckInDate", SqlDbType.Date).Value =
                        reservation.CheckInDate.Date

                        command.Parameters.Add(
                        "@CheckOutDate", SqlDbType.Date).Value =
                        reservation.CheckOutDate.Date

                        If Convert.ToInt32(command.ExecuteScalar()) > 0 Then
                            Throw New InvalidOperationException(
                            "The selected room is already reserved for part of those dates.")
                        End If

                    End Using

                    ' Insert only after the transactional checks succeed.
                    Const insertSql As String =
                    "INSERT INTO Reservations " &
                    "(GuestID, RoomID, ReservationDate, CheckInDate, " &
                    "CheckOutDate, Status, RoomRate, TotalAmount, " &
                    "PaidAmount, Balance) " &
                    "VALUES " &
                    "(@GuestID, @RoomID, @ReservationDate, @CheckInDate, " &
                    "@CheckOutDate, @Status, @RoomRate, @TotalAmount, " &
                    "@PaidAmount, @Balance); " &
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);"

                    Dim reservationId As Integer

                    Using command As New SqlCommand(
                    insertSql, connection, transaction)

                        command.Parameters.Add(
                        "@GuestID", SqlDbType.Int).Value =
                        reservation.GuestID

                        command.Parameters.Add(
                        "@RoomID", SqlDbType.Int).Value =
                        reservation.RoomID

                        command.Parameters.Add(
                        "@ReservationDate", SqlDbType.Date).Value =
                        reservation.ReservationDate.Date

                        command.Parameters.Add(
                        "@CheckInDate", SqlDbType.Date).Value =
                        reservation.CheckInDate.Date

                        command.Parameters.Add(
                        "@CheckOutDate", SqlDbType.Date).Value =
                        reservation.CheckOutDate.Date

                        command.Parameters.Add(
                        "@Status", SqlDbType.NVarChar, 20).Value =
                        reservation.Status

                        Dim roomRateParameter =
                        command.Parameters.Add(
                            "@RoomRate", SqlDbType.Decimal)
                        roomRateParameter.Precision = 10
                        roomRateParameter.Scale = 2
                        roomRateParameter.Value = reservation.RoomRate

                        Dim totalParameter =
                        command.Parameters.Add(
                            "@TotalAmount", SqlDbType.Decimal)
                        totalParameter.Precision = 10
                        totalParameter.Scale = 2
                        totalParameter.Value = reservation.TotalAmount

                        Dim paidParameter =
                        command.Parameters.Add(
                            "@PaidAmount", SqlDbType.Decimal)
                        paidParameter.Precision = 10
                        paidParameter.Scale = 2
                        paidParameter.Value = reservation.PaidAmount

                        Dim balanceParameter =
                        command.Parameters.Add(
                            "@Balance", SqlDbType.Decimal)
                        balanceParameter.Precision = 10
                        balanceParameter.Scale = 2
                        balanceParameter.Value = reservation.Balance

                        reservationId =
                        Convert.ToInt32(command.ExecuteScalar())

                    End Using

                    transaction.Commit()
                    Return reservationId

                Catch
                    Try
                        transaction.Rollback()
                    Catch
                        ' The transaction may already have been rolled back.
                    End Try

                    Throw
                End Try

            End Using
        End Using
    End Function

    Public Function GetById(
        reservationId As Integer
    ) As Reservation

        Const sql As String =
            "SELECT ReservationID, GuestID, RoomID, " &
            "ReservationDate, CheckInDate, CheckOutDate, " &
            "Status, RoomRate, TotalAmount, PaidAmount, " &
            "Balance, CreatedAt, UpdatedAt " &
            "FROM Reservations " &
            "WHERE ReservationID = @ReservationID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@ReservationID", SqlDbType.Int).Value =
                    reservationId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    If reader.Read() Then
                        Return MapReservation(reader)
                    End If

                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function GetByGuest(
        guestId As Integer
    ) As List(Of Reservation)

        Const sql As String =
            "SELECT ReservationID, GuestID, RoomID, " &
            "ReservationDate, CheckInDate, CheckOutDate, " &
            "Status, RoomRate, TotalAmount, PaidAmount, " &
            "Balance, CreatedAt, UpdatedAt " &
            "FROM Reservations " &
            "WHERE GuestID = @GuestID " &
            "ORDER BY ReservationDate DESC;"

        Dim reservations As New List(Of Reservation)

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@GuestID", SqlDbType.Int).Value =
                    guestId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    While reader.Read()
                        reservations.Add(MapReservation(reader))
                    End While

                End Using
            End Using
        End Using

        Return reservations
    End Function


    Public Function GetAll() As List(Of Reservation)
        Const sql As String =
        "SELECT r.ReservationID, r.GuestID, r.RoomID, " &
        "r.ReservationDate, r.CheckInDate, r.CheckOutDate, " &
        "r.Status, r.RoomRate, r.TotalAmount, r.PaidAmount, " &
        "r.Balance, r.CreatedAt, r.UpdatedAt, " &
        "COALESCE(" &
        "NULLIF(LTRIM(RTRIM(CONCAT(" &
        "u.FirstName, ' ', u.MiddleName, ' ', u.Surname))), ''), " &
        "NULLIF(u.Username, ''), " &
        "CONCAT('Guest #', g.GuestID)) AS GuestName, " &
        "rm.RoomType " &
        "FROM Reservations r " &
        "INNER JOIN Guests g ON r.GuestID = g.GuestID " &
        "LEFT JOIN Users u ON g.UserID = u.UserID " &
        "INNER JOIN Rooms rm ON r.RoomID = rm.RoomID " &
        "ORDER BY r.ReservationDate DESC;"

        Dim reservations As New List(Of Reservation)

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                connection.Open()

                Using reader As SqlDataReader =
                command.ExecuteReader()

                    While reader.Read()
                        reservations.Add(MapReservation(reader))
                    End While

                End Using
            End Using
        End Using

        Return reservations
    End Function

    Public Function HasOverlappingReservation(
    roomId As Integer,
    checkInDate As Date,
    checkOutDate As Date
    ) As Boolean

        Const sql As String =
        "SELECT COUNT(*) " &
        "FROM Reservations " &
        "WHERE RoomID = @RoomID " &
        "AND Status IN ('Pending', 'Confirmed', 'Checked In') " &
        "AND CheckInDate < @CheckOutDate " &
        "AND CheckOutDate > @CheckInDate;"

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@RoomID", SqlDbType.Int).Value =
                roomId

                command.Parameters.Add("@CheckInDate", SqlDbType.Date).Value =
                checkInDate

                command.Parameters.Add("@CheckOutDate", SqlDbType.Date).Value =
                checkOutDate

                connection.Open()

                Return Convert.ToInt32(
                command.ExecuteScalar()) > 0

            End Using
        End Using
    End Function

    Private Function MapReservation(
        reader As SqlDataReader
    ) As Reservation

        Return New Reservation With {
            .ReservationID =
                Convert.ToInt32(reader("ReservationID")),
            .GuestID =
                Convert.ToInt32(reader("GuestID")),
            .RoomID =
                Convert.ToInt32(reader("RoomID")),
            .ReservationDate =
                Convert.ToDateTime(reader("ReservationDate")),
            .CheckInDate =
                Convert.ToDateTime(reader("CheckInDate")),
            .CheckOutDate =
                Convert.ToDateTime(reader("CheckOutDate")),
            .Status =
                reader("Status").ToString(),
            .RoomRate =
                Convert.ToDecimal(reader("RoomRate")),
            .TotalAmount =
                Convert.ToDecimal(reader("TotalAmount")),
            .PaidAmount =
                Convert.ToDecimal(reader("PaidAmount")),
            .Balance =
                Convert.ToDecimal(reader("Balance")),
            .CreatedAt =
                Convert.ToDateTime(reader("CreatedAt")),
            .UpdatedAt =
                If(
                    IsDBNull(reader("UpdatedAt")),
                    Nothing,
                    Convert.ToDateTime(reader("UpdatedAt"))),
            .GuestName =
                If(
                    HasColumn(reader, "GuestName") AndAlso
                    Not IsDBNull(reader("GuestName")),
                    reader("GuestName").ToString(),
                    Nothing),
            .RoomType =
                If(
                    HasColumn(reader, "RoomType") AndAlso
                    Not IsDBNull(reader("RoomType")),
                    reader("RoomType").ToString(),
                    Nothing)
                }
    End Function

    Private Function HasColumn(
    reader As SqlDataReader,
    columnName As String
    ) As Boolean

        For index As Integer = 0 To reader.FieldCount - 1

            If String.Equals(
            reader.GetName(index),
            columnName,
            StringComparison.OrdinalIgnoreCase) Then

                Return True

            End If

        Next

        Return False
    End Function

    Public Function UpdateStatusAndRoomStatus(
    reservationId As Integer,
    expectedStatus As String,
    newStatus As String,
    Optional assignedAttendant As String = Nothing
    ) As Boolean

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            connection.Open()

            Using transaction As SqlTransaction =
            connection.BeginTransaction()

                Try
                    Dim roomId As Integer
                    Dim checkInDate As Date
                    Dim checkOutDate As Date
                    Dim guestId As Integer

                    Const getReservationSql As String =
                    "SELECT RoomID, GuestID, CheckInDate, CheckOutDate " &
                    "FROM Reservations WITH (UPDLOCK, HOLDLOCK) " &
                    "WHERE ReservationID = @ReservationID " &
                    "AND Status = @ExpectedStatus;"

                    Using command As New SqlCommand(
                    getReservationSql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationID", SqlDbType.Int).Value =
                        reservationId

                        command.Parameters.Add(
                        "@ExpectedStatus", SqlDbType.NVarChar, 20).Value =
                        expectedStatus

                        Using reader As SqlDataReader = command.ExecuteReader()

                            If Not reader.Read() Then
                                transaction.Rollback()
                                Return False
                            End If

                            roomId = Convert.ToInt32(reader("RoomID"))
                            checkInDate = Convert.ToDateTime(reader("CheckInDate"))
                            checkOutDate = Convert.ToDateTime(reader("CheckOutDate"))
                            guestId = Convert.ToInt32(reader("GuestID"))

                        End Using
                    End Using

                    If newStatus = "Checked In" Then

                        Const overlapSql As String =
                        "SELECT COUNT(*) " &
                        "FROM Reservations WITH (UPDLOCK, HOLDLOCK) " &
                        "WHERE RoomID = @RoomID " &
                        "AND ReservationID <> @ReservationID " &
                        "AND Status IN ('Pending', 'Confirmed', 'Checked In') " &
                        "AND CheckInDate < @CheckOutDate " &
                        "AND CheckOutDate > @CheckInDate;"

                        Using command As New SqlCommand(
                        overlapSql, connection, transaction)

                            command.Parameters.Add(
                            "@RoomID", SqlDbType.Int).Value = roomId

                            command.Parameters.Add(
                            "@ReservationID", SqlDbType.Int).Value =
                            reservationId

                            command.Parameters.Add(
                            "@CheckInDate", SqlDbType.Date).Value =
                            checkInDate

                            command.Parameters.Add(
                            "@CheckOutDate", SqlDbType.Date).Value =
                            checkOutDate

                            If Convert.ToInt32(command.ExecuteScalar()) > 0 Then
                                Throw New InvalidOperationException(
                                "Another active reservation overlaps these dates.")
                            End If

                        End Using

                        Const occupyRoomSql As String =
                        "UPDATE Rooms " &
                        "SET Status = 'Occupied' " &
                        "WHERE RoomID = @RoomID " &
                        "AND Status = 'Available' " &
                        "AND IsActive = 1;"

                        Using command As New SqlCommand(
                        occupyRoomSql, connection, transaction)

                            command.Parameters.Add(
                            "@RoomID", SqlDbType.Int).Value = roomId

                            If command.ExecuteNonQuery() = 0 Then
                                Throw New InvalidOperationException(
                                "The room is no longer available for check-in.")
                            End If

                        End Using

                    End If

                    If newStatus = "Cancelled" Then

                        Const paymentSql As String =
        "SELECT COUNT(1) " &
        "FROM Payments " &
        "WHERE ReservationID = @ReservationID;"

                        Using paymentCommand As New SqlCommand(
        paymentSql, connection, transaction)

                            paymentCommand.Parameters.Add(
            "@ReservationID", SqlDbType.Int).Value = reservationId

                            Dim paymentCount As Integer =
            Convert.ToInt32(paymentCommand.ExecuteScalar())

                            If paymentCount > 0 Then
                                Throw New InvalidOperationException(
                "This reservation has recorded payments. " &
                "Resolve the payment or refund before cancelling.")
                            End If
                        End Using

                    End If

                    If newStatus = "Confirmed" Then

                        If String.IsNullOrWhiteSpace(assignedAttendant) Then
                            Throw New ArgumentException(
            "An attendant must be assigned when confirming a reservation.")
                        End If

                        Const attendantSql As String =
        "UPDATE Guests " &
        "SET AssignedAttendant = @AssignedAttendant " &
        "WHERE GuestID = @GuestID;"

                        Using command As New SqlCommand(
        attendantSql, connection, transaction)

                            command.Parameters.Add(
            "@AssignedAttendant", SqlDbType.NVarChar, 100).Value =
            assignedAttendant.Trim()

                            command.Parameters.Add(
            "@GuestID", SqlDbType.Int).Value = guestId

                            If command.ExecuteNonQuery() = 0 Then
                                Throw New InvalidOperationException(
                "The guest record could not be updated.")
                            End If

                        End Using

                    End If

                    Const updateReservationSql As String =
                    "UPDATE Reservations " &
                    "SET Status = @NewStatus, UpdatedAt = GETDATE() " &
                    "WHERE ReservationID = @ReservationID " &
                    "AND Status = @ExpectedStatus;"

                    Using command As New SqlCommand(
                    updateReservationSql, connection, transaction)

                        command.Parameters.Add(
                        "@NewStatus", SqlDbType.NVarChar, 20).Value =
                        newStatus

                        command.Parameters.Add(
                        "@ReservationID", SqlDbType.Int).Value =
                        reservationId

                        command.Parameters.Add(
                        "@ExpectedStatus", SqlDbType.NVarChar, 20).Value =
                        expectedStatus

                        If command.ExecuteNonQuery() = 0 Then
                            transaction.Rollback()
                            Return False
                        End If

                    End Using

                    If newStatus = "Checked Out" Then

                        Const releaseRoomSql As String =
                        "UPDATE Rooms " &
                        "SET Status = 'Available' " &
                        "WHERE RoomID = @RoomID " &
                        "AND Status = 'Occupied';"

                        Using command As New SqlCommand(
                        releaseRoomSql, connection, transaction)

                            command.Parameters.Add(
                            "@RoomID", SqlDbType.Int).Value = roomId


                            Dim affectedRows As Integer = command.ExecuteNonQuery()

                            If affectedRows = 0 Then
                                Throw New InvalidOperationException(
                                    "The room could not be released. " &
                                    "Its status may have changed unexpectedly.")
                            End If

                        End Using

                    End If

                    transaction.Commit()
                    Return True

                Catch
                    Try
                        transaction.Rollback()
                    Catch
                        ' The transaction may already have been rolled back.
                    End Try

                    Throw
                End Try

            End Using
        End Using
    End Function
End Class
