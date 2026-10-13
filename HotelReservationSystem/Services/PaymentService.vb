Public Class PaymentService
    Private ReadOnly _paymentRepository As New PaymentRepository()
    Private ReadOnly _reservationRepository As New ReservationRepository()
    Private ReadOnly _reservationService As New ReservationService()

    Public Function GetPayment(
    paymentId As Integer
    ) As Payment

        If Not AppSession.IsLoggedIn Then
            Throw New UnauthorizedAccessException(
            "You must be logged in to access payments.")
        End If

        Dim payment As Payment =
        _paymentRepository.GetById(paymentId)

        If payment Is Nothing Then
            Return Nothing
        End If

        ' This also verifies reservation ownership.
        Dim reservation As Reservation =
        _reservationService.GetReservation(
            payment.ReservationID)

        If reservation Is Nothing Then
            Return Nothing
        End If

        Return payment
    End Function

    Public Function GetPayments(
    reservationId As Integer
    ) As List(Of Payment)

        Dim reservation As Reservation =
        _reservationService.GetReservation(
            reservationId)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation could not be found.")
        End If

        Return _paymentRepository.GetByReservation(
        reservationId)
    End Function

    Public Function GetTotalPaid(
    reservationId As Integer
    ) As Decimal

        Dim reservation As Reservation =
        _reservationService.GetReservation(
            reservationId)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation could not be found.")
        End If

        Return _paymentRepository.GetTotalPaid(
        reservationId)
    End Function

    Public Function GetBalance(
        reservationId As Integer
    ) As Decimal

        Dim reservation As Reservation =
            _reservationService.GetReservation(
                reservationId)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
                "The selected reservation could not be found.")
        End If

        Dim totalPaid As Decimal =
            _paymentRepository.GetTotalPaid(
                reservationId)

        Dim balance As Decimal =
            reservation.TotalAmount - totalPaid

        If balance < 0D Then
            balance = 0D
        End If

        Return balance
    End Function

    Public Function CreatePayment(
        reservationId As Integer,
        paymentMethod As String,
        amount As Decimal,
        referenceNumber As String
    ) As Integer

        If Not AppSession.IsLoggedIn Then
            Throw New InvalidOperationException(
                "You must be logged in to record a payment.")
        End If

        If String.IsNullOrWhiteSpace(paymentMethod) Then
            Throw New ArgumentException(
                "Payment method is required.")
        End If

        If paymentMethod.Trim().Length > 30 Then
            Throw New ArgumentException(
                "Payment method cannot exceed 30 characters.")
        End If

        If amount <= 0D Then
            Throw New ArgumentException(
        "Payment amount must be greater than zero.")
        End If

        If amount <> Decimal.Round(amount, 2) Then
            Throw New ArgumentException(
        "Payment amount cannot have more than two decimal places.")
        End If

        If amount > 99999999.99D Then
            Throw New ArgumentException(
        "Payment amount exceeds the maximum supported value.")
        End If

        If Not String.IsNullOrWhiteSpace(referenceNumber) AndAlso
           referenceNumber.Trim().Length > 100 Then

            Throw New ArgumentException(
                "Reference number cannot exceed 100 characters.")

        End If

        Dim reservation As Reservation =
            _reservationService.GetReservation(
                reservationId)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
                "The selected reservation could not be found.")
        End If

        If reservation.Status = "Cancelled" Then
            Throw New InvalidOperationException(
                "A payment cannot be recorded for a cancelled reservation.")
        End If

        If reservation.Status = "Checked Out" Then
            Throw New InvalidOperationException(
                "A payment cannot be recorded for a checked-out reservation.")
        End If

        Dim currentPaid As Decimal =
            _paymentRepository.GetTotalPaid(
                reservationId)

        Dim currentBalance As Decimal =
            reservation.TotalAmount - currentPaid

        If currentBalance <= 0D Then
            Throw New InvalidOperationException(
                "This reservation has already been fully paid.")
        End If

        If amount > currentBalance Then
            Throw New ArgumentException(
                "Payment amount cannot exceed the remaining balance.")
        End If

        Dim payment As New Payment With {
            .ReservationID = reservationId,
            .PaymentMethod = paymentMethod.Trim(),
            .Amount = amount,
            .PaymentDate = DateTime.Now,
            .ReferenceNumber =
                If(
                    String.IsNullOrWhiteSpace(referenceNumber),
                    Nothing,
                    referenceNumber.Trim())
        }

        Return _paymentRepository.CreateAndUpdateSummary(payment)
    End Function

    Public Function GetAllPayments() As List(Of Payment)

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            Throw New UnauthorizedAccessException(
                "Only administrators can view all payments.")

        End If

        Return _paymentRepository.GetAll()

    End Function
End Class