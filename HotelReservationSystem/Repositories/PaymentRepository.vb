Imports Microsoft.Data.SqlClient

Public Class PaymentRepository
    Public Function CreateAndUpdateSummary(
    payment As Payment
) As Integer

        Using connection As SqlConnection =
        DbConnection.CreateConnection()

            connection.Open()

            Using transaction As SqlTransaction =
            connection.BeginTransaction()

                Try
                    Dim totalAmount As Decimal
                    Dim reservationStatus As String

                    ' Lock the reservation so concurrent payments
                    ' for the same reservation are processed in order.
                    Const reservationSql As String =
                    "SELECT TotalAmount, Status " &
                    "FROM Reservations WITH (UPDLOCK, HOLDLOCK) " &
                    "WHERE ReservationID = @ReservationID;"

                    Using command As New SqlCommand(
                    reservationSql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationID",
                        SqlDbType.Int).Value = payment.ReservationID

                        Using reader As SqlDataReader =
                        command.ExecuteReader()

                            If Not reader.Read() Then
                                Throw New InvalidOperationException(
                                "The selected reservation could not be found.")
                            End If

                            totalAmount =
                            Convert.ToDecimal(reader("TotalAmount"))

                            reservationStatus =
                            Convert.ToString(reader("Status"))
                        End Using
                    End Using

                    If reservationStatus = "Cancelled" Then
                        Throw New InvalidOperationException(
                        "A payment cannot be recorded for a cancelled reservation.")
                    End If

                    If reservationStatus = "Checked Out" Then
                        Throw New InvalidOperationException(
                        "A payment cannot be recorded for a checked-out reservation.")
                    End If

                    If payment.Amount <= 0D Then
                        Throw New ArgumentException(
                        "Payment amount must be greater than zero.")
                    End If

                    If payment.Amount <> Decimal.Round(payment.Amount, 2) Then
                        Throw New ArgumentException(
                        "Payment amount cannot have more than two decimal places.")
                    End If

                    If payment.Amount > 99999999.99D Then
                        Throw New ArgumentException(
                        "Payment amount exceeds the maximum supported value.")
                    End If

                    ' Calculate the current paid amount inside the transaction.
                    Const totalPaidSql As String =
                    "SELECT ISNULL(SUM(Amount), 0) " &
                    "FROM Payments " &
                    "WHERE ReservationID = @ReservationID;"

                    Dim currentPaid As Decimal

                    Using command As New SqlCommand(
                    totalPaidSql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationID",
                        SqlDbType.Int).Value = payment.ReservationID

                        currentPaid =
                        Convert.ToDecimal(command.ExecuteScalar())
                    End Using

                    Dim currentBalance As Decimal =
                    totalAmount - currentPaid

                    If currentBalance <= 0D Then
                        Throw New InvalidOperationException(
                        "This reservation has already been fully paid.")
                    End If

                    If payment.Amount > currentBalance Then
                        Throw New ArgumentException(
                        "Payment amount cannot exceed the remaining balance.")
                    End If

                    ' Insert the payment within the same transaction.
                    Const insertSql As String =
                    "INSERT INTO Payments " &
                    "(ReservationID, PaymentMethod, Amount, " &
                    "PaymentDate, ReferenceNumber) " &
                    "VALUES " &
                    "(@ReservationID, @PaymentMethod, @Amount, " &
                    "@PaymentDate, @ReferenceNumber); " &
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);"

                    Dim paymentId As Integer

                    Using command As New SqlCommand(
                    insertSql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationID",
                        SqlDbType.Int).Value = payment.ReservationID

                        command.Parameters.Add(
                        "@PaymentMethod",
                        SqlDbType.NVarChar, 30).Value =
                        payment.PaymentMethod

                        Dim amountParameter =
                        command.Parameters.Add(
                            "@Amount", SqlDbType.Decimal)

                        amountParameter.Precision = 10
                        amountParameter.Scale = 2
                        amountParameter.Value = payment.Amount

                        command.Parameters.Add(
                        "@PaymentDate",
                        SqlDbType.DateTime2).Value = payment.PaymentDate

                        command.Parameters.Add(
                        "@ReferenceNumber",
                        SqlDbType.NVarChar, 100).Value =
                        If(
                            String.IsNullOrWhiteSpace(payment.ReferenceNumber),
                            CType(DBNull.Value, Object),
                            payment.ReferenceNumber.Trim())

                        paymentId =
                        Convert.ToInt32(command.ExecuteScalar())
                    End Using

                    ' Update the reservation summary in the same transaction.
                    Dim newPaidAmount As Decimal =
                    currentPaid + payment.Amount

                    Dim newBalance As Decimal =
                    totalAmount - newPaidAmount

                    Const updateSql As String =
                    "UPDATE Reservations " &
                    "SET PaidAmount = @PaidAmount, " &
                    "Balance = @Balance, " &
                    "UpdatedAt = GETDATE() " &
                    "WHERE ReservationID = @ReservationID;"

                    Using command As New SqlCommand(
                    updateSql, connection, transaction)

                        command.Parameters.Add(
                        "@ReservationID",
                        SqlDbType.Int).Value = payment.ReservationID

                        Dim paidParameter =
                        command.Parameters.Add(
                            "@PaidAmount", SqlDbType.Decimal)

                        paidParameter.Precision = 10
                        paidParameter.Scale = 2
                        paidParameter.Value = newPaidAmount

                        Dim balanceParameter =
                        command.Parameters.Add(
                            "@Balance", SqlDbType.Decimal)

                        balanceParameter.Precision = 10
                        balanceParameter.Scale = 2
                        balanceParameter.Value = newBalance

                        If command.ExecuteNonQuery() <> 1 Then
                            Throw New InvalidOperationException(
                            "The reservation payment summary could not be updated.")
                        End If
                    End Using

                    transaction.Commit()
                    Return paymentId

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
        paymentId As Integer
    ) As Payment

        Const sql As String =
            "SELECT " &
            "PaymentID, ReservationID, PaymentMethod, Amount, " &
            "PaymentDate, ReferenceNumber " &
            "FROM Payments " &
            "WHERE PaymentID = @PaymentID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@PaymentID",
                    SqlDbType.Int).Value =
                    paymentId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    If reader.Read() Then
                        Return MapPayment(reader)
                    End If

                End Using

            End Using

        End Using

        Return Nothing
    End Function

    Public Function GetByReservation(
        reservationId As Integer
    ) As List(Of Payment)

        Dim payments As New List(Of Payment)()

        Const sql As String =
            "SELECT " &
            "PaymentID, ReservationID, PaymentMethod, Amount, " &
            "PaymentDate, ReferenceNumber " &
            "FROM Payments " &
            "WHERE ReservationID = @ReservationID " &
            "ORDER BY PaymentDate DESC, PaymentID DESC;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ReservationID",
                    SqlDbType.Int).Value =
                    reservationId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    While reader.Read()

                        payments.Add(
                            MapPayment(reader))

                    End While

                End Using

            End Using

        End Using

        Return payments
    End Function

    Public Function GetTotalPaid(
        reservationId As Integer
    ) As Decimal

        Const sql As String =
            "SELECT ISNULL(SUM(Amount), 0) " &
            "FROM Payments " &
            "WHERE ReservationID = @ReservationID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ReservationID",
                    SqlDbType.Int).Value =
                    reservationId

                connection.Open()

                Return Convert.ToDecimal(
                    command.ExecuteScalar())

            End Using

        End Using
    End Function

    Private Function MapPayment(
        reader As SqlDataReader
    ) As Payment

        Return New Payment With {
            .PaymentID =
                Convert.ToInt32(reader("PaymentID")),
            .ReservationID =
                Convert.ToInt32(reader("ReservationID")),
            .PaymentMethod =
                Convert.ToString(reader("PaymentMethod")),
            .Amount =
                Convert.ToDecimal(reader("Amount")),
            .PaymentDate =
                Convert.ToDateTime(reader("PaymentDate")),
            .ReferenceNumber =
                If(
                    reader("ReferenceNumber") Is DBNull.Value,
                    Nothing,
                    Convert.ToString(reader("ReferenceNumber")))
        }
    End Function

    Public Function GetAll() As List(Of Payment)

        Dim payments As New List(Of Payment)()

        Const sql As String =
            "SELECT PaymentID, ReservationID, PaymentMethod, Amount, " &
            "PaymentDate, ReferenceNumber " &
            "FROM Payments " &
            "ORDER BY PaymentDate DESC, PaymentID DESC;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    While reader.Read()
                        payments.Add(MapPayment(reader))
                    End While

                End Using

            End Using

        End Using

        Return payments
    End Function
End Class