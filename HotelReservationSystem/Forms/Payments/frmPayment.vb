Public Class frmPayment

    Private ReadOnly _paymentService As New PaymentService()
    Private ReadOnly _reservationService As New ReservationService()

    Private ReadOnly _reservationId As Integer

    Public Sub New(reservationId As Integer)

        InitializeComponent()

        _reservationId = reservationId

    End Sub

    Private Sub frmPayment_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn Then

            MessageBox.Show(
                "You must be logged in to make a payment.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        LoadPaymentMethods()
        LoadReservation()

    End Sub

    Private Sub LoadPaymentMethods()

        cmbPaymentMethod.Items.Clear()

        cmbPaymentMethod.Items.Add("Cash")
        cmbPaymentMethod.Items.Add("Credit Card")
        cmbPaymentMethod.Items.Add("Bank Transfer")
        cmbPaymentMethod.Items.Add("E-Wallet")

        If cmbPaymentMethod.Items.Count > 0 Then
            cmbPaymentMethod.SelectedIndex = 0
        End If

    End Sub

    Private Sub LoadReservation()

        Dim reservation As Reservation =
            _reservationService.GetReservation(
                _reservationId)

        If reservation Is Nothing Then

            MessageBox.Show(
                "Reservation not found.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            Me.Close()
            Return

        End If

        lblTitle.Text = "Make Payment"

        lblReservationID.Text =
            "Reservation ID: " &
            reservation.ReservationID

        lblTotal.Text =
            "Total: " &
            reservation.TotalAmount.ToString("C2")

        Dim currentPaid As Decimal =
            _paymentService.GetTotalPaid(
                reservation.ReservationID)

        Dim balance As Decimal =
            reservation.TotalAmount - currentPaid

        If balance < 0D Then
            balance = 0D
        End If

        lblPaid.Text =
            "Paid: " &
            currentPaid.ToString("C2")

        lblBalance.Text =
            "Balance: " &
            balance.ToString("C2")

        txtAmount.Text =
            balance.ToString("0.00")

        txtAmount.SelectAll()

        If balance <= 0D Then

            btnPay.Enabled = False

            MessageBox.Show(
                "This reservation has already been fully paid.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub btnPay_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnPay.Click

        Dim amount As Decimal

        If Not Decimal.TryParse(
            txtAmount.Text.Trim(),
            amount) Then

            MessageBox.Show(
                "Please enter a valid payment amount.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtAmount.Focus()
            Return

        End If

        If cmbPaymentMethod.SelectedItem Is Nothing Then

            MessageBox.Show(
                "Please select a payment method.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            cmbPaymentMethod.Focus()
            Return

        End If

        Dim paymentMethod As String =
            cmbPaymentMethod.SelectedItem.ToString()

        Try

            Dim paymentId As Integer =
                _paymentService.CreatePayment(
                    _reservationId,
                    paymentMethod,
                    amount,
                    txtReferenceNumber.Text)

            MessageBox.Show(
                "Payment recorded successfully." &
                Environment.NewLine &
                "Payment ID: " & paymentId,
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

End Class