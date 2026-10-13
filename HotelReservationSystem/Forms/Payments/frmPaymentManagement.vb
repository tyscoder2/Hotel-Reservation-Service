Public Class frmPaymentManagement

    Private ReadOnly _paymentService As New PaymentService()

    Private Sub frmPaymentManagement_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            MessageBox.Show(
                "You do not have permission to manage payments.",
                "Payment Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        LoadPayments()

    End Sub

    Private Sub LoadPayments(
        Optional reservationId As Integer? = Nothing
    )

        flpPayments.Controls.Clear()

        Try

            Dim payments As New List(Of Payment)()

            If reservationId.HasValue Then

                payments =
                    _paymentService.GetPayments(
                        reservationId.Value)

            Else

                ' Load payment records for all reservations.
                ' Implemented through the payment service below.

                payments =
                    _paymentService.GetAllPayments()

            End If

            If payments.Count = 0 Then

                Dim lblNone As New Label()

                lblNone.AutoSize = True
                lblNone.Margin = New Padding(10)
                lblNone.Text = "No payments found."

                flpPayments.Controls.Add(lblNone)

                Return

            End If

            For Each payment As Payment In payments
                AddPaymentCard(payment)
            Next

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load payments: " & ex.Message,
                "Payment Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub AddPaymentCard(
        payment As Payment
    )

        Dim panel As New Panel With {
            .Width = 480,
            .Height = 105,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(5)
        }

        Dim lblPaymentID As New Label With {
            .AutoSize = True,
            .Location = New Point(10, 10),
            .Text = "Payment ID: " & payment.PaymentID
        }

        Dim lblReservationID As New Label With {
            .AutoSize = True,
            .Location = New Point(180, 10),
            .Text = "Reservation ID: " & payment.ReservationID
        }

        Dim lblAmount As New Label With {
            .AutoSize = True,
            .Location = New Point(10, 40),
            .Text = "Amount: " & payment.Amount.ToString("C2")
        }

        Dim lblMethod As New Label With {
            .AutoSize = True,
            .Location = New Point(180, 40),
            .Text = "Method: " & payment.PaymentMethod
        }

        Dim lblDate As New Label With {
            .AutoSize = True,
            .Location = New Point(10, 70),
            .Text = "Date: " &
                    payment.PaymentDate.ToString("MMM dd, yyyy hh:mm tt")
        }

        panel.Controls.Add(lblPaymentID)
        panel.Controls.Add(lblReservationID)
        panel.Controls.Add(lblAmount)
        panel.Controls.Add(lblMethod)
        panel.Controls.Add(lblDate)

        If Not String.IsNullOrWhiteSpace(
            payment.ReferenceNumber) Then

            Dim lblReference As New Label With {
                .AutoSize = True,
                .Location = New Point(250, 70),
                .Text = "Reference: " & payment.ReferenceNumber
            }

            panel.Controls.Add(lblReference)

        End If

        flpPayments.Controls.Add(panel)

    End Sub

    Private Sub btnSearch_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearch.Click

        Dim reservationId As Integer

        If Not Integer.TryParse(
            txtSearch.Text.Trim(),
            reservationId) OrElse reservationId <= 0 Then

            MessageBox.Show(
                "Enter a valid positive Reservation ID.",
                "Payment Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtSearch.Focus()
            Return

        End If

        LoadPayments(reservationId)

    End Sub

    Private Sub btnShowAll_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnShowAll.Click

        txtSearch.Clear()
        LoadPayments()

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class