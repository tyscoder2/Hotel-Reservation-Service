Public Class frmReservations

    Private ReadOnly _reservationService As New ReservationService()

    Private Sub frmReservations_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn Then

            MessageBox.Show(
                "You must be logged in to view reservations.",
                "Reservations",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        If AppSession.IsAdmin Then
            lblTitle.Text = "All Reservations"
        Else
            lblTitle.Text = "My Reservations"
        End If

        LoadReservations()

    End Sub

    Private Sub LoadReservations()

        flpReservations.Controls.Clear()

        Dim reservations As List(Of Reservation)

        If AppSession.IsAdmin Then
            reservations =
                _reservationService.GetAllReservations()
        Else
            reservations =
                _reservationService.GetMyReservations()
        End If

        If reservations.Count = 0 Then

            Dim emptyLabel As New Label With {
                .AutoSize = True,
                .Text = "No reservations found.",
                .Margin = New Padding(10)
            }

            flpReservations.Controls.Add(emptyLabel)

            Return

        End If

        For Each reservation As Reservation In reservations

            AddReservationCard(reservation)

        Next

    End Sub

    Private Sub AddReservationCard(
        reservation As Reservation
    )

        Dim reservationPanel As New Panel With {
            .Width = 420,
            .Height = 210,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(10)
        }

        Dim reservationLabel As New Label With {
            .AutoSize = False,
            .Left = 10,
            .Top = 10,
            .Width = 390,
            .Height = 150
        }

        reservationLabel.Text =
            "Reservation ID: " &
            reservation.ReservationID &
            Environment.NewLine &
            "Room ID: " &
            reservation.RoomID &
            Environment.NewLine &
            "Check-in: " &
            reservation.CheckInDate.ToString("MMM dd, yyyy") &
            Environment.NewLine &
            "Check-out: " &
            reservation.CheckOutDate.ToString("MMM dd, yyyy") &
            Environment.NewLine &
            "Status: " &
            reservation.Status &
            Environment.NewLine &
            "Room Rate: " &
            reservation.RoomRate.ToString("C2") &
            Environment.NewLine &
            "Total: " &
            reservation.TotalAmount.ToString("C2") &
            Environment.NewLine &
            "Paid: " &
            reservation.PaidAmount.ToString("C2") &
            Environment.NewLine &
            "Balance: " &
            reservation.Balance.ToString("C2")

        reservationPanel.Controls.Add(reservationLabel)

        Dim viewButton As New Button With {
            .Text = "View",
            .Width = 100,
            .Height = 30,
            .Left = 10,
            .Top = 170,
            .Tag = reservation.ReservationID
        }

        AddHandler viewButton.Click,
            Sub(sender, e)

                Dim reservationId As Integer =
                    CInt(
                        DirectCast(sender, Button).Tag)

                OpenReservation(reservationId)

            End Sub

        reservationPanel.Controls.Add(viewButton)

        flpReservations.Controls.Add(
            reservationPanel)

    End Sub

    Private Sub OpenReservation(
    reservationId As Integer
)
        Dim form As New frmReservationDetails(reservationId)
        form.ShowDialog()
    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

End Class