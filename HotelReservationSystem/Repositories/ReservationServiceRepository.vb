Imports Microsoft.Data.SqlClient

Public Class ReservationServiceRepository
    Public Function GetByReservation(
        reservationId As Integer
    ) As List(Of ReservationServiceItem)

        Const sql As String =
            "SELECT ReservationServiceID, ReservationID, " &
            "ServiceID, Quantity, UnitPrice, Subtotal " &
            "FROM ReservationServices " &
            "WHERE ReservationID = @ReservationID " &
            "ORDER BY ReservationServiceID;"

        Dim items As New List(Of ReservationServiceItem)

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ReservationID",
                    SqlDbType.Int
                ).Value = reservationId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    While reader.Read()
                        items.Add(MapReservationService(reader))
                    End While

                End Using

            End Using

        End Using

        Return items
    End Function

    Public Function GetById(
        reservationServiceId As Integer
    ) As ReservationServiceItem

        Const sql As String =
            "SELECT ReservationServiceID, ReservationID, " &
            "ServiceID, Quantity, UnitPrice, Subtotal " &
            "FROM ReservationServices " &
            "WHERE ReservationServiceID = @ReservationServiceID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ReservationServiceID",
                    SqlDbType.Int
                ).Value = reservationServiceId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    If reader.Read() Then
                        Return MapReservationService(reader)
                    End If

                End Using

            End Using

        End Using

        Return Nothing
    End Function


    Public Function CreateAndRecalculate(
    item As ReservationServiceItem
    ) As Integer

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            connection.Open()

            Using transaction As SqlTransaction =
            connection.BeginTransaction()

                Try
                    LockReservation(
                    connection,
                    transaction,
                    item.ReservationID)

                    Const insertSql As String =
                    "INSERT INTO ReservationServices " &
                    "(ReservationID, ServiceID, Quantity, UnitPrice) " &
                    "VALUES " &
                    "(@ReservationID, @ServiceID, @Quantity, @UnitPrice); " &
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);"

                    Dim serviceItemId As Integer

                    Using command As New SqlCommand(
                    insertSql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationID",
                        SqlDbType.Int).Value = item.ReservationID

                        command.Parameters.Add(
                        "@ServiceID",
                        SqlDbType.Int).Value = item.ServiceID

                        command.Parameters.Add(
                        "@Quantity",
                        SqlDbType.Int).Value = item.Quantity

                        Dim priceParameter =
                        command.Parameters.Add(
                            "@UnitPrice",
                            SqlDbType.Decimal)

                        priceParameter.Precision = 10
                        priceParameter.Scale = 2
                        priceParameter.Value = item.UnitPrice

                        serviceItemId =
                        Convert.ToInt32(command.ExecuteScalar())

                    End Using

                    RecalculateSummary(
                    connection,
                    transaction,
                    item.ReservationID)

                    transaction.Commit()

                    Return serviceItemId

                Catch
                    Try
                        transaction.Rollback()
                    Catch
                        ' Preserve the original exception.
                    End Try

                    Throw
                End Try

            End Using

        End Using
    End Function

    Public Sub DeleteAndRecalculate(
    reservationServiceId As Integer
)

        ' Find which reservation owns this service item.
        Dim item As ReservationServiceItem =
        GetById(reservationServiceId)

        If item Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation service could not be found.")
        End If

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            connection.Open()

            Using transaction As SqlTransaction =
            connection.BeginTransaction()

                Try
                    ' Lock the reservation before changing its services.
                    LockReservation(
                    connection,
                    transaction,
                    item.ReservationID)

                    Const verifySql As String =
                    "SELECT ReservationID " &
                    "FROM ReservationServices WITH (UPDLOCK, HOLDLOCK) " &
                    "WHERE ReservationServiceID = @ReservationServiceID;"

                    Using command As New SqlCommand(
                        verifySql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationServiceID",
                        SqlDbType.Int).Value = reservationServiceId

                        Dim result As Object = command.ExecuteScalar()

                        If result Is Nothing OrElse result Is DBNull.Value Then
                            Throw New InvalidOperationException(
                            "The reservation service no longer exists.")
                        End If

                        If Convert.ToInt32(result) <> item.ReservationID Then
                            Throw New InvalidOperationException(
                            "The reservation service has changed. Please refresh and try again.")
                        End If
                    End Using

                    Const deleteSql As String =
                    "DELETE FROM ReservationServices " &
                    "WHERE ReservationServiceID = " &
                    "@ReservationServiceID;"

                    Using command As New SqlCommand(
                    deleteSql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationServiceID",
                        SqlDbType.Int).Value =
                        reservationServiceId

                        If command.ExecuteNonQuery() = 0 Then
                            Throw New InvalidOperationException(
                            "The reservation service no longer exists.")
                        End If

                    End Using

                    RecalculateSummary(
                    connection,
                    transaction,
                    item.ReservationID)

                    transaction.Commit()

                Catch
                    Try
                        transaction.Rollback()
                    Catch
                        ' Preserve the original exception.
                    End Try

                    Throw
                End Try

            End Using

        End Using
    End Sub

    Private Sub LockReservation(
    connection As SqlConnection,
    transaction As SqlTransaction,
    reservationId As Integer
    )

        Const sql As String =
        "SELECT Status " &
        "FROM Reservations WITH (UPDLOCK, HOLDLOCK) " &
        "WHERE ReservationID = @ReservationID;"

        Using command As New SqlCommand(
        sql, connection, transaction)

            command.Parameters.Add(
            "@ReservationID",
            SqlDbType.Int).Value = reservationId

            Dim result As Object = command.ExecuteScalar()

            If result Is Nothing OrElse result Is DBNull.Value Then
                Throw New InvalidOperationException(
                "The reservation could not be found.")
            End If

            Dim status As String = result.ToString()

            If status = "Cancelled" OrElse
           status = "Checked Out" Then

                Throw New InvalidOperationException(
                "Services cannot be modified for cancelled or checked-out reservations.")
            End If

        End Using
    End Sub

    Private Sub RecalculateSummary(
    connection As SqlConnection,
    transaction As SqlTransaction,
    reservationId As Integer
)

        Const selectSql As String =
        "SELECT RoomRate, CheckInDate, CheckOutDate, " &
        "ISNULL((SELECT SUM(Subtotal) " &
        "FROM ReservationServices " &
        "WHERE ReservationID = r.ReservationID), 0) AS ServiceTotal, " &
        "ISNULL((SELECT SUM(Amount) " &
        "FROM Payments " &
        "WHERE ReservationID = r.ReservationID), 0) AS PaidAmount " &
        "FROM Reservations r " &
        "WHERE ReservationID = @ReservationID;"

        Dim roomRate As Decimal
        Dim checkIn As DateTime
        Dim checkOut As DateTime
        Dim serviceTotal As Decimal
        Dim paidAmount As Decimal

        Using command As New SqlCommand(
        selectSql, connection, transaction)

            command.Parameters.Add(
            "@ReservationID",
            SqlDbType.Int).Value = reservationId

            Using reader As SqlDataReader = command.ExecuteReader()

                If Not reader.Read() Then
                    Throw New InvalidOperationException(
                    "The reservation could not be found.")
                End If

                roomRate = Convert.ToDecimal(reader("RoomRate"))
                checkIn = Convert.ToDateTime(reader("CheckInDate"))
                checkOut = Convert.ToDateTime(reader("CheckOutDate"))
                serviceTotal = Convert.ToDecimal(reader("ServiceTotal"))
                paidAmount = Convert.ToDecimal(reader("PaidAmount"))

            End Using

        End Using

        Dim nights As Integer =
        CInt((checkOut - checkIn).TotalDays)

        If nights <= 0 Then
            Throw New InvalidOperationException(
            "The reservation dates are invalid.")
        End If


        Dim totalAmount As Decimal =
    (roomRate * nights) + serviceTotal

        If totalAmount < paidAmount Then
            Throw New InvalidOperationException(
        "This change would reduce the reservation total below the amount already paid. " &
        "Resolve the excess payment before changing the services.")
        End If

        Dim balance As Decimal =
    totalAmount - paidAmount


        Const updateSql As String =
        "UPDATE Reservations " &
        "SET TotalAmount = @TotalAmount, " &
        "PaidAmount = @PaidAmount, " &
        "Balance = @Balance, " &
        "UpdatedAt = GETDATE() " &
        "WHERE ReservationID = @ReservationID;"

        Using command As New SqlCommand(
        updateSql, connection, transaction)

            command.Parameters.Add(
            "@ReservationID",
            SqlDbType.Int).Value = reservationId

            Dim totalParameter =
            command.Parameters.Add(
                "@TotalAmount",
                SqlDbType.Decimal)

            totalParameter.Precision = 10
            totalParameter.Scale = 2
            totalParameter.Value = totalAmount

            Dim paidParameter =
            command.Parameters.Add(
                "@PaidAmount",
                SqlDbType.Decimal)

            paidParameter.Precision = 10
            paidParameter.Scale = 2
            paidParameter.Value = paidAmount

            Dim balanceParameter =
            command.Parameters.Add(
                "@Balance",
                SqlDbType.Decimal)

            balanceParameter.Precision = 10
            balanceParameter.Scale = 2
            balanceParameter.Value = balance

            If command.ExecuteNonQuery() = 0 Then
                Throw New InvalidOperationException(
                "The reservation summary could not be updated.")
            End If

        End Using
    End Sub

    Public Sub UpdateQuantity(
    reservationServiceId As Integer,
    quantity As Integer
)

        ' Find the reservation before beginning the transaction.
        Dim item As ReservationServiceItem =
        GetById(reservationServiceId)

        If item Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation service could not be found.")
        End If

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            connection.Open()

            Using transaction As SqlTransaction =
            connection.BeginTransaction()

                Try
                    ' Lock the reservation before changing its services.
                    LockReservation(
                    connection,
                    transaction,
                    item.ReservationID)


                    Const verifySql As String =
                    "SELECT ReservationID " &
                    "FROM ReservationServices WITH (UPDLOCK, HOLDLOCK) " &
                    "WHERE ReservationServiceID = @ReservationServiceID;"

                    Using command As New SqlCommand(
                    verifySql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationServiceID",
                        SqlDbType.Int).Value = reservationServiceId

                        Dim result As Object = command.ExecuteScalar()

                        If result Is Nothing OrElse result Is DBNull.Value Then
                            Throw New InvalidOperationException(
                            "The reservation service no longer exists.")
                        End If

                        If Convert.ToInt32(result) <> item.ReservationID Then
                            Throw New InvalidOperationException(
                            "The reservation service has changed. Please refresh and try again.")
                        End If
                    End Using


                    Const sql As String =
                    "UPDATE ReservationServices " &
                    "SET Quantity = @Quantity " &
                    "WHERE ReservationServiceID = " &
                    "@ReservationServiceID;"

                    Using command As New SqlCommand(
                    sql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationServiceID",
                        SqlDbType.Int).Value =
                        reservationServiceId

                        command.Parameters.Add(
                        "@Quantity",
                        SqlDbType.Int).Value = quantity

                        If command.ExecuteNonQuery() = 0 Then
                            Throw New InvalidOperationException(
                            "The reservation service no longer exists.")
                        End If

                    End Using

                    ' Recalculate within the same transaction.
                    RecalculateSummary(
                    connection,
                    transaction,
                    item.ReservationID)

                    transaction.Commit()

                Catch
                    Try
                        transaction.Rollback()
                    Catch
                        ' Preserve the original exception.
                    End Try

                    Throw
                End Try

            End Using

        End Using
    End Sub

    Private Function MapReservationService(
        reader As SqlDataReader
    ) As ReservationServiceItem

        Return New ReservationServiceItem With {
            .ReservationServiceID =
                Convert.ToInt32(reader("ReservationServiceID")),
            .ReservationID =
                Convert.ToInt32(reader("ReservationID")),
            .ServiceID =
                Convert.ToInt32(reader("ServiceID")),
            .Quantity =
                Convert.ToInt32(reader("Quantity")),
            .UnitPrice =
                Convert.ToDecimal(reader("UnitPrice")),
            .Subtotal =
                Convert.ToDecimal(reader("Subtotal"))
        }

    End Function
End Class