Public Class frmReservationDetails

    Private ReadOnly _reservationService As New ReservationService()
    Private ReadOnly _reservationServiceItemService As New ReservationServiceItemService()
    Private ReadOnly _reservationId As Integer
    Private ReadOnly _paymentService As New PaymentService()
    Public Sub New(reservationId As Integer)
        InitializeComponent()
        _reservationId = reservationId
    End Sub

    Private Sub frmReservationDetails_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn Then
            MessageBox.Show(
                "You must be logged in to view reservation details.",
                "Reservation Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return
        End If

        LoadReservation()
    End Sub

    Private Sub LoadReservation()

        Dim reservation As Reservation =
            _reservationService.GetReservation(_reservationId)

        If reservation Is Nothing Then
            MessageBox.Show(
                "Reservation not found.",
                "Reservation Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            Me.Close()
            Return
        End If

        lblTitle.Text = "Reservation Details"

        lblReservationID.Text =
            "Reservation ID: " & reservation.ReservationID

        lblRoomID.Text =
            "Room ID: " & reservation.RoomID

        lblReservationDate.Text =
            "Reservation Date: " &
            reservation.ReservationDate.ToString("MMM dd, yyyy")

        lblCheckIn.Text =
            "Check-in: " &
            reservation.CheckInDate.ToString("MMM dd, yyyy")

        lblCheckOut.Text =
            "Check-out: " &
            reservation.CheckOutDate.ToString("MMM dd, yyyy")

        lblStatus.Text =
            "Status: " & reservation.Status

        lblRoomRate.Text =
            "Room Rate: " &
            reservation.RoomRate.ToString("C2")

        lblTotal.Text =
            "Total: " &
            reservation.TotalAmount.ToString("C2")

        Dim serviceCharges As Decimal =
            _reservationServiceItemService.GetTotalServiceAmount(
                reservation.ReservationID)

        lblServiceCharges.Text =
            "Service Charges: " &
            serviceCharges.ToString("C2")

        lblPaid.Text =
            "Paid: " &
            reservation.PaidAmount.ToString("C2")

        lblBalance.Text =
            "Balance: " &
            reservation.Balance.ToString("C2")

        btnPay.Enabled = reservation.Balance > 0D

        LoadPayments()
    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Close()

    End Sub

    Private Sub btnServices_Click(
    sender As Object,
    e As EventArgs
) Handles btnServices.Click

        Using form As New frmReservationServices(_reservationId)

            form.ShowDialog()

        End Using

        LoadReservation()

    End Sub

    Private Sub btnPay_Click(
    sender As Object,
    e As EventArgs
) Handles btnPay.Click

        Dim form As New frmPayment(_reservationId)

        Dim result As DialogResult =
            form.ShowDialog()

        If result = DialogResult.OK Then
            LoadReservation()
        End If

    End Sub

    Private Sub LoadPayments()

        flpPayments.Controls.Clear()

        Dim payments As List(Of Payment) =
            _paymentService.GetPayments(_reservationId)

        If payments.Count = 0 Then

            Dim lblNone As New Label()

            lblNone.AutoSize = True
            lblNone.Text = "No payments have been recorded."
            lblNone.Margin = New Padding(5)

            flpPayments.Controls.Add(lblNone)

            Return

        End If

        For Each payment As Payment In payments

            AddPaymentCard(payment)

        Next

    End Sub

    Private Sub AddPaymentCard(
    payment As Payment
)

        Dim panel As New Panel()

        panel.Width = 450
        panel.Height = 90
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Margin = New Padding(5)

        Dim lblPaymentID As New Label()

        lblPaymentID.AutoSize = True
        lblPaymentID.Location = New Point(10, 10)

        lblPaymentID.Text =
            "Payment ID: " &
            payment.PaymentID

        Dim lblMethod As New Label()

        lblMethod.AutoSize = True
        lblMethod.Location = New Point(150, 10)

        lblMethod.Text =
            "Method: " &
            payment.PaymentMethod

        Dim lblAmount As New Label()

        lblAmount.AutoSize = True
        lblAmount.Location = New Point(10, 40)

        lblAmount.Text =
            "Amount: " &
            payment.Amount.ToString("C2")

        Dim lblDate As New Label()

        lblDate.AutoSize = True
        lblDate.Location = New Point(150, 40)

        lblDate.Text =
            "Date: " &
            payment.PaymentDate.ToString("MMM dd, yyyy hh:mm tt")

        panel.Controls.Add(lblPaymentID)
        panel.Controls.Add(lblMethod)
        panel.Controls.Add(lblAmount)
        panel.Controls.Add(lblDate)

        If Not String.IsNullOrWhiteSpace(
            payment.ReferenceNumber) Then

            Dim lblReference As New Label()

            lblReference.AutoSize = True
            lblReference.Location = New Point(10, 65)

            lblReference.Text =
                "Reference: " &
                payment.ReferenceNumber

            panel.Controls.Add(lblReference)

        End If

        flpPayments.Controls.Add(panel)

    End Sub
End Class