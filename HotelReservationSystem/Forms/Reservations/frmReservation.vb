Public Class frmReservation

    Private ReadOnly _reservationService As New ReservationService()
    Private ReadOnly _roomService As New RoomService()
    Private ReadOnly _roomId As Integer

    Public Sub New(roomId As Integer)

        InitializeComponent()

        _roomId = roomId

    End Sub

    Private Sub frmReservation_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn Then

            MessageBox.Show(
                "You must be logged in to make a reservation.",
                "Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        LoadRoom()

        dtpCheckIn.MinDate = Date.Today
        dtpCheckIn.Value = Date.Today

        dtpCheckOut.MinDate = Date.Today.AddDays(1)
        dtpCheckOut.Value = Date.Today.AddDays(1)

        UpdateSummary()

    End Sub

    Private Sub LoadRoom()

        Dim room As Room =
            _roomService.GetRoom(_roomId)

        If room Is Nothing Then

            MessageBox.Show(
                "Room not found.",
                "Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            Me.Close()
            Return

        End If

        If Not room.IsActive Then

            MessageBox.Show(
                "This room is no longer active.",
                "Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        If room.Status <> "Available" AndAlso
   room.Status <> "Occupied" Then

            MessageBox.Show(
        "This room is not available for reservations.",
        "Reservation",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        lblRoomID.Text =
            "Room ID: " & room.RoomID

        lblRoomType.Text =
            "Type: " & room.RoomType

        lblRate.Text =
            "Rate: " & room.Rate.ToString("C2")

    End Sub

    Private Sub dtpCheckIn_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles dtpCheckIn.ValueChanged

        Dim minimumCheckOut As Date =
            dtpCheckIn.Value.Date.AddDays(1)

        If dtpCheckOut.MinDate <> minimumCheckOut Then
            dtpCheckOut.MinDate = minimumCheckOut
        End If

        If dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date Then
            dtpCheckOut.Value = minimumCheckOut
        End If

        UpdateSummary()

    End Sub

    Private Sub dtpCheckOut_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles dtpCheckOut.ValueChanged

        UpdateSummary()

    End Sub

    Private Sub UpdateSummary()

        If dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date Then

            lblNights.Text = "Nights: 0"
            lblTotal.Text = "Total: ₱0.00"

            Return

        End If

        Dim room As Room =
            _roomService.GetRoom(_roomId)

        If room Is Nothing Then
            Return
        End If

        Dim nights As Integer =
            CInt(
                (dtpCheckOut.Value.Date -
                 dtpCheckIn.Value.Date).TotalDays)

        Dim total As Decimal =
            room.Rate * nights

        lblNights.Text =
            "Nights: " & nights

        lblTotal.Text =
            "Total: " & total.ToString("C2")

    End Sub

    Private Sub btnReserve_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnReserve.Click

        Dim checkInDate As Date =
            dtpCheckIn.Value.Date

        Dim checkOutDate As Date =
            dtpCheckOut.Value.Date

        If checkOutDate <= checkInDate Then

            MessageBox.Show(
                "Check-out date must be after check-in date.",
                "Invalid Dates",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return

        End If

        Try

            Dim reservationId As Integer =
                _reservationService.CreateReservation(
                    _roomId,
                    checkInDate,
                    checkOutDate)

            MessageBox.Show(
                "Reservation created successfully." &
                Environment.NewLine &
                "Reservation ID: " & reservationId,
                "Reservation Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As InvalidOperationException

            MessageBox.Show(
                ex.Message,
                "Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As ArgumentException

            MessageBox.Show(
                ex.Message,
                "Invalid Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As Exception

            MessageBox.Show(
                "An unexpected error occurred while creating the reservation." &
                Environment.NewLine &
                ex.Message,
                "Reservation Error",
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