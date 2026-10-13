
Imports System.Linq

Public Class frmReservationManagement

    Private ReadOnly _reservationService As New ReservationService()
    Private _allReservations As New List(Of Reservation)()

    Public Sub New()

        InitializeComponent()

        AddHandler Me.Load, AddressOf frmReservationManagement_Load
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler btnRefresh.Click, AddressOf btnRefresh_Click
        AddHandler btnConfirm.Click, AddressOf btnConfirm_Click
        AddHandler btnCheckIn.Click, AddressOf btnCheckIn_Click
        AddHandler btnCheckOut.Click, AddressOf btnCheckOut_Click
        AddHandler btnCancel.Click, AddressOf btnCancel_Click
        AddHandler btnViewDetails.Click, AddressOf btnViewDetails_Click
        AddHandler btnClose.Click, AddressOf btnClose_Click
        AddHandler dgvReservations.SelectionChanged,
            AddressOf dgvReservations_SelectionChanged

    End Sub

    Private Sub frmReservationManagement_Load(
        sender As Object,
        e As EventArgs
    )

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            MessageBox.Show(
                "Only administrators can access Reservation Management.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        ConfigureGrid()
        LoadReservations()

    End Sub

    Private Sub ConfigureGrid()

        With dgvReservations

            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False

        End With

    End Sub

    Private Sub LoadReservations()

        Try

            _allReservations =
                _reservationService.GetAllReservations()

            ApplySearch()

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load reservations." &
                Environment.NewLine &
                ex.Message,
                "Reservation Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub ApplySearch()

        Dim searchText As String =
            txtSearch.Text.Trim()

        Dim filteredReservations As List(Of Reservation)

        If String.IsNullOrWhiteSpace(searchText) Then

            filteredReservations = _allReservations.ToList()

        Else

            filteredReservations =
                _allReservations.
                Where(
                    Function(r)
                        Return r.ReservationID.ToString().
                                   Contains(searchText) OrElse
                               r.Status.IndexOf(
                                   searchText,
                                   StringComparison.OrdinalIgnoreCase) >= 0
                    End Function).
                ToList()

        End If

        dgvReservations.DataSource = Nothing
        dgvReservations.DataSource = filteredReservations

        FormatGridColumns()
        UpdateActionButtons()

    End Sub

    Private Sub FormatGridColumns()

        If dgvReservations.Columns.Count = 0 Then
            Return
        End If

        If dgvReservations.Columns.Contains("ReservationID") Then
            dgvReservations.Columns("ReservationID").HeaderText =
                "Reservation ID"
        End If

        If dgvReservations.Columns.Contains("GuestID") Then
            dgvReservations.Columns("GuestID").HeaderText =
                "Guest ID"
        End If

        If dgvReservations.Columns.Contains("RoomID") Then
            dgvReservations.Columns("RoomID").HeaderText =
                "Room ID"
        End If

        If dgvReservations.Columns.Contains("ReservationDate") Then
            dgvReservations.Columns("ReservationDate").HeaderText =
                "Booked On"
        End If

        If dgvReservations.Columns.Contains("CheckInDate") Then
            dgvReservations.Columns("CheckInDate").HeaderText =
                "Check-In Date"
        End If

        If dgvReservations.Columns.Contains("CheckOutDate") Then
            dgvReservations.Columns("CheckOutDate").HeaderText =
                "Check-Out Date"
        End If

        If dgvReservations.Columns.Contains("RoomRate") Then
            dgvReservations.Columns("RoomRate").HeaderText =
                "Room Rate"
        End If

        If dgvReservations.Columns.Contains("TotalAmount") Then
            dgvReservations.Columns("TotalAmount").HeaderText =
                "Total"
        End If

        If dgvReservations.Columns.Contains("PaidAmount") Then
            dgvReservations.Columns("PaidAmount").HeaderText =
                "Paid"
        End If

        If dgvReservations.Columns.Contains("Balance") Then
            dgvReservations.Columns("Balance").HeaderText =
                "Balance"
        End If

        If dgvReservations.Columns.Contains("CreatedAt") Then
            dgvReservations.Columns("CreatedAt").Visible = False
        End If

        If dgvReservations.Columns.Contains("UpdatedAt") Then
            dgvReservations.Columns("UpdatedAt").Visible = False
        End If

        'Note: some dupes here, pls fix later
        If dgvReservations.Columns.Contains("GuestName") Then
            dgvReservations.Columns("GuestName").HeaderText =
        "Guest Name"
            dgvReservations.Columns("GuestName").DisplayIndex = 1
        End If

        If dgvReservations.Columns.Contains("RoomType") Then
            dgvReservations.Columns("RoomType").HeaderText =
        "Room Type"
            dgvReservations.Columns("RoomType").DisplayIndex = 2
        End If

        If dgvReservations.Columns.Contains("GuestID") Then
            dgvReservations.Columns("GuestID").Visible = False
        End If

        If dgvReservations.Columns.Contains("RoomID") Then
            dgvReservations.Columns("RoomID").Visible = False
        End If


        For Each column As DataGridViewColumn In
            dgvReservations.Columns

            If column.Name = "RoomRate" OrElse
               column.Name = "TotalAmount" OrElse
               column.Name = "PaidAmount" OrElse
               column.Name = "Balance" Then

                column.DefaultCellStyle.Format = "C2"

            End If

        Next

    End Sub

    Private Function GetSelectedReservation() As Reservation

        If dgvReservations.CurrentRow Is Nothing Then
            Return Nothing
        End If

        Return TryCast(
            dgvReservations.CurrentRow.DataBoundItem,
            Reservation)

    End Function

    Private Sub UpdateActionButtons()

        Dim reservation As Reservation =
            GetSelectedReservation()

        btnConfirm.Enabled = False
        btnCheckIn.Enabled = False
        btnCheckOut.Enabled = False
        btnCancel.Enabled = False
        btnViewDetails.Enabled = reservation IsNot Nothing

        If reservation Is Nothing Then
            Return
        End If

        Select Case reservation.Status

            Case "Pending"

                btnConfirm.Enabled = True
                btnCancel.Enabled = True

            Case "Confirmed"

                btnCheckIn.Enabled = True
                btnCancel.Enabled = True

            Case "Checked In"

                btnCheckOut.Enabled = True

        End Select

    End Sub

    Private Sub ChangeReservationStatus(
    newStatus As String,
    confirmationMessage As String,
    Optional assignedAttendant As String = Nothing
)

        Dim reservation As Reservation =
            GetSelectedReservation()

        If reservation Is Nothing Then

            MessageBox.Show(
                "Please select a reservation first.",
                "Reservation Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If

        Dim result As DialogResult =
            MessageBox.Show(
                confirmationMessage,
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            Return
        End If

        Try

            _reservationService.UpdateReservationStatus(
                reservation.ReservationID,
                newStatus,
                assignedAttendant)

            MessageBox.Show(
                "Reservation #" &
                reservation.ReservationID.ToString() &
                " was updated to " &
                newStatus & ".",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            LoadReservations()

        Catch ex As Exception

            MessageBox.Show(
                "The reservation could not be updated." &
                Environment.NewLine &
                ex.Message,
                "Reservation Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            LoadReservations()

        End Try

    End Sub

    Private Sub txtSearch_TextChanged(
        sender As Object,
        e As EventArgs
    )

        ApplySearch()

    End Sub

    Private Sub btnRefresh_Click(
        sender As Object,
        e As EventArgs
    )

        LoadReservations()

    End Sub

    Private Sub btnConfirm_Click(
    sender As Object,
    e As EventArgs
)

        Dim reservation As Reservation =
        GetSelectedReservation()

        If reservation Is Nothing Then
            MessageBox.Show(
            "Please select a reservation first.",
            "Reservation Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
            Return
        End If

        If reservation.Status <> "Pending" Then
            MessageBox.Show(
            "Only pending reservations can be confirmed.",
            "Reservation Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Dim attendant As String = SelectAttendant()

        If attendant Is Nothing Then
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
        "Confirm reservation #" & reservation.ReservationID &
        " and assign " & attendant & " as the attendant?",
        "Confirm Reservation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            Return
        End If

        ChangeReservationStatus(
        "Confirmed",
        "Confirm the selected reservation?",
        attendant)

    End Sub

    Private Sub btnCheckIn_Click(
        sender As Object,
        e As EventArgs
    )

        ChangeReservationStatus(
            "Checked In",
            "Check in the guest for this reservation?")

    End Sub

    Private Sub btnCheckOut_Click(
        sender As Object,
        e As EventArgs
    )

        ChangeReservationStatus(
            "Checked Out",
            "Check out the guest for this reservation?")

    End Sub

    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    )

        ChangeReservationStatus(
            "Cancelled",
            "Cancel this reservation? The reservation record will be preserved.")

    End Sub

    Private Sub btnViewDetails_Click(
        sender As Object,
        e As EventArgs
    )

        Dim reservation As Reservation =
            GetSelectedReservation()

        If reservation Is Nothing Then
            Return
        End If

        Dim details As String =
            "Reservation ID: " & reservation.ReservationID &
            Environment.NewLine &
            "Guest ID: " & reservation.GuestID &
            Environment.NewLine &
            "Room ID: " & reservation.RoomID &
            Environment.NewLine &
            "Status: " & reservation.Status &
            Environment.NewLine &
            "Reservation Date: " &
                reservation.ReservationDate.ToShortDateString() &
            Environment.NewLine &
            "Check-In: " &
                reservation.CheckInDate.ToShortDateString() &
            Environment.NewLine &
            "Check-Out: " &
                reservation.CheckOutDate.ToShortDateString() &
            Environment.NewLine &
            "Room Rate: " & reservation.RoomRate.ToString("C2") &
            Environment.NewLine &
            "Total Amount: " & reservation.TotalAmount.ToString("C2") &
            Environment.NewLine &
            "Paid Amount: " & reservation.PaidAmount.ToString("C2") &
            Environment.NewLine &
            "Balance: " & reservation.Balance.ToString("C2")

        MessageBox.Show(
            details,
            "Reservation Details",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    Private Sub dgvReservations_SelectionChanged(
        sender As Object,
        e As EventArgs
    )

        UpdateActionButtons()

    End Sub

    Private Sub btnClose_Click(
        sender As Object,
        e As EventArgs
    )

        Me.Close()

    End Sub

    Private Function SelectAttendant() As String

        Using dialog As New Form()

            dialog.Text = "Assign Attendant"
            dialog.StartPosition = FormStartPosition.CenterParent
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog
            dialog.MinimizeBox = False
            dialog.MaximizeBox = False
            dialog.ShowInTaskbar = False
            dialog.ClientSize = New Size(300, 130)

            Dim lblAttendant As New Label With {
            .Text = "Select an attendant:",
            .Left = 15,
            .Top = 15,
            .AutoSize = True
        }

            Dim cboAttendant As New ComboBox With {
            .Left = 15,
            .Top = 40,
            .Width = 270,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }

            cboAttendant.Items.AddRange(
            New Object() {"Jay", "Andrew", "Amy", "Nathan", "Lazaro"})

            cboAttendant.SelectedIndex = -1

            Dim btnOK As New Button With {
            .Text = "Confirm",
            .Left = 105,
            .Top = 80,
            .Width = 85,
            .DialogResult = DialogResult.OK
        }

            Dim btnCancel As New Button With {
            .Text = "Cancel",
            .Left = 195,
            .Top = 80,
            .Width = 85,
            .DialogResult = DialogResult.Cancel
        }

            AddHandler btnOK.Click,
            Sub(sender, e)
                If cboAttendant.SelectedIndex = -1 Then
                    MessageBox.Show(
                        dialog,
                        "Please select an attendant.",
                        "Attendant Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                    dialog.DialogResult = DialogResult.None
                End If
            End Sub

            dialog.Controls.Add(lblAttendant)
            dialog.Controls.Add(cboAttendant)
            dialog.Controls.Add(btnOK)
            dialog.Controls.Add(btnCancel)

            dialog.AcceptButton = btnOK
            dialog.CancelButton = btnCancel

            If dialog.ShowDialog(Me) = DialogResult.OK Then
                Return cboAttendant.SelectedItem.ToString()
            End If

        End Using

        Return Nothing

    End Function
End Class
