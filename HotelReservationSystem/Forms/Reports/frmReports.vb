Imports System.Linq

Public Class frmReports

    Private ReadOnly _reportService As New ReportService()

    Private Sub frmReports_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            MessageBox.Show(
                "Only administrators can access reports.",
                "Reports",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        ConfigureReservationGrid()

        cmbStatusFilter.Items.Clear()
        cmbStatusFilter.Items.AddRange(
    New Object() {
        "All",
        "Pending",
        "Confirmed",
        "Checked In",
        "Checked Out",
        "Cancelled"
    })

        cmbStatusFilter.SelectedIndex = 0

        dtpStartDate.Value = Date.Today.AddMonths(-1)
        dtpEndDate.Value = Date.Today

        dtpStartDate.Enabled = False
        dtpEndDate.Enabled = False

        cmbScheduleType.Items.Clear()
        cmbScheduleType.Items.AddRange(
    New Object() {"Arrivals", "Departures"})

        cmbScheduleType.SelectedIndex = 0
        dtpScheduleDate.Value = Date.Today

        With dgvSchedule
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode =
        DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
        End With

        ConfigureSummaryGrid(dgvRoomOccupancy)
        ConfigureSummaryGrid(dgvPaymentMethods)

        LoadRoomOccupancy()
        LoadPaymentMethodBreakdown()

        'LoadSchedule()

        LoadReports()

    End Sub

    Private Sub ConfigureReservationGrid()

        With dgvReservations
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
        End With

    End Sub

    Private Sub LoadReports()

        Try

            Dim reservations As List(Of Reservation) =
            _reportService.GetReservationReport()

            Dim payments As List(Of Payment) =
            _reportService.GetPaymentReport()

            ' Apply the status filter.
            If cmbStatusFilter.SelectedItem IsNot Nothing Then

                Dim selectedStatus As String =
                cmbStatusFilter.SelectedItem.ToString()

                If selectedStatus <> "All" Then
                    reservations = reservations.
                    Where(Function(r) r.Status = selectedStatus).
                    ToList()
                End If

            End If

            ' Apply the optional reservation-date filter.
            If chkUseDateRange.Checked Then

                Dim startDate As Date = dtpStartDate.Value.Date
                Dim endDate As Date = dtpEndDate.Value.Date

                If startDate > endDate Then
                    MessageBox.Show(
                    "The start date must not be later than the end date.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
                    Return
                End If

                reservations = reservations.
                Where(
                    Function(r)
                        Return r.ReservationDate.Date >= startDate AndAlso
                               r.ReservationDate.Date <= endDate
                    End Function).
                ToList()

            End If

            ' Reservation statistics reflect the active filters.
            lblTotalReservations.Text =
            "Total Reservations: " & reservations.Count

            lblPending.Text =
            "Pending: " &
            System.Linq.Enumerable.Count(
                reservations,
                Function(r) r.Status = "Pending")

            lblConfirmed.Text =
            "Confirmed: " &
            System.Linq.Enumerable.Count(
                reservations,
                Function(r) r.Status = "Confirmed")

            lblCheckedIn.Text =
            "Checked In: " &
            System.Linq.Enumerable.Count(
                reservations,
                Function(r) r.Status = "Checked In")

            lblCheckedOut.Text =
            "Checked Out: " &
            System.Linq.Enumerable.Count(
                reservations,
                Function(r) r.Status = "Checked Out")

            lblCancelled.Text =
            "Cancelled: " &
            System.Linq.Enumerable.Count(
                reservations,
                Function(r) r.Status = "Cancelled")

            Dim activeReservations As List(Of Reservation) =
            reservations.
                Where(Function(r) r.Status <> "Cancelled").
                ToList()

            Dim totalRevenue As Decimal =
            activeReservations.Sum(Function(r) r.TotalAmount)

            Dim outstandingBalance As Decimal =
            activeReservations.Sum(Function(r) r.Balance)

            Dim totalCollected As Decimal =
            payments.Sum(Function(p) p.Amount)

            lblTotalRevenue.Text =
            "Reservation Value: " & totalRevenue.ToString("C2")

            lblTotalCollected.Text =
            "All-time Payments Collected: " &
            totalCollected.ToString("C2")

            lblOutstanding.Text =
            "Outstanding Balance: " &
            outstandingBalance.ToString("C2")

            LoadReservationGrid(reservations)

        Catch ex As UnauthorizedAccessException

            MessageBox.Show(
            ex.Message,
            "Access Denied",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Me.Close()

        Catch ex As Exception

            MessageBox.Show(
            "Unable to load reports: " & ex.Message,
            "Reports",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub LoadReservationGrid(
        reservations As List(Of Reservation)
    )

        dgvReservations.DataSource = Nothing

        Dim reportRows = reservations.
            OrderByDescending(Function(r) r.ReservationDate).
            Select(
                Function(r) New With {
                    .ReservationID = r.ReservationID,
                    .GuestID = r.GuestID,
                    .RoomID = r.RoomID,
                    .ReservationDate = r.ReservationDate,
                    .CheckInDate = r.CheckInDate,
                    .CheckOutDate = r.CheckOutDate,
                    .Status = r.Status,
                    .RoomRate = r.RoomRate,
                    .TotalAmount = r.TotalAmount,
                    .PaidAmount = r.PaidAmount,
                    .Balance = r.Balance
                }).
            ToList()

        dgvReservations.DataSource = reportRows

        If dgvReservations.Columns.Contains("RoomRate") Then
            dgvReservations.Columns("RoomRate").
                DefaultCellStyle.Format = "C2"
        End If

        If dgvReservations.Columns.Contains("TotalAmount") Then
            dgvReservations.Columns("TotalAmount").
                DefaultCellStyle.Format = "C2"
        End If

        If dgvReservations.Columns.Contains("PaidAmount") Then
            dgvReservations.Columns("PaidAmount").
                DefaultCellStyle.Format = "C2"
        End If

        If dgvReservations.Columns.Contains("Balance") Then
            dgvReservations.Columns("Balance").
                DefaultCellStyle.Format = "C2"
        End If

    End Sub

    Private Sub btnRefresh_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRefresh.Click

        LoadReports()

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

    Private Sub chkUseDateRange_CheckedChanged(
    sender As Object,
    e As EventArgs
) Handles chkUseDateRange.CheckedChanged

        dtpStartDate.Enabled = chkUseDateRange.Checked
        dtpEndDate.Enabled = chkUseDateRange.Checked

    End Sub

    Private Sub btnFilter_Click(
    sender As Object,
    e As EventArgs
) Handles btnFilter.Click

        LoadReports()

    End Sub

    Private Sub btnClearFilters_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClearFilters.Click

        cmbStatusFilter.SelectedIndex = 0
        chkUseDateRange.Checked = False

        LoadReports()

    End Sub

    Private Sub LoadSchedule()

        Try

            Dim reservations As List(Of Reservation) =
                _reportService.GetReservationReport()

            Dim selectedDate As Date =
                dtpScheduleDate.Value.Date

            Dim scheduleType As String =
                Convert.ToString(cmbScheduleType.SelectedItem)

            If scheduleType = "Arrivals" Then

                ' Expected arrivals that have not been cancelled.
                reservations = reservations.
                    Where(
                        Function(r)
                            Return r.CheckInDate.Date = selectedDate AndAlso
                                   (r.Status = "Pending" OrElse
                                    r.Status = "Confirmed")
                        End Function).
                    ToList()

            ElseIf scheduleType = "Departures" Then

                ' Guests currently checked in and scheduled to depart.
                reservations = reservations.
                    Where(
                        Function(r)
                            Return r.CheckOutDate.Date = selectedDate AndAlso
                                   r.Status = "Checked In"
                        End Function).
                    ToList()

            Else

                dgvSchedule.DataSource = Nothing
                Return

            End If

            Dim scheduleRows = reservations.
                OrderBy(
                    Function(r)
                        If scheduleType = "Arrivals" Then
                            Return r.CheckInDate
                        Else
                            Return r.CheckOutDate
                        End If
                    End Function).
                Select(
                    Function(r) New With {
                        .ReservationID = r.ReservationID,
                        .GuestID = r.GuestID,
                        .RoomID = r.RoomID,
                        .CheckInDate = r.CheckInDate,
                        .CheckOutDate = r.CheckOutDate,
                        .Status = r.Status,
                        .Balance = r.Balance
                    }).
                ToList()

            dgvSchedule.DataSource = scheduleRows

            If dgvSchedule.Columns.Contains("Balance") Then
                dgvSchedule.Columns("Balance").
                    DefaultCellStyle.Format = "C2"
            End If

            If scheduleRows.Count = 0 Then
                MessageBox.Show(
                    "No " & scheduleType.ToLower() &
                    " were found for " &
                    selectedDate.ToString("MMMM dd, yyyy") & ".",
                    "Schedule",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If

        Catch ex As UnauthorizedAccessException

            MessageBox.Show(
                ex.Message,
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load the schedule: " & ex.Message,
                "Schedule",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnLoadSchedule_Click(
    sender As Object,
    e As EventArgs
) Handles btnLoadSchedule.Click

        LoadSchedule()

    End Sub

    Private Sub ConfigureSummaryGrid(grid As DataGridView)

        With grid
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
        End With

    End Sub

    Private Sub LoadRoomOccupancy()

        Try

            Dim rooms As List(Of Room) =
                _reportService.GetRoomReport()

            Dim summary = rooms.
                GroupBy(Function(r) New With {
                    Key .RoomType = r.RoomType,
                    Key .Status = r.Status
                }).
                OrderBy(Function(g) g.Key.RoomType).
                ThenBy(Function(g) g.Key.Status).
                Select(Function(g) New With {
                    .RoomType = g.Key.RoomType,
                    .Status = g.Key.Status,
                    .RoomCount = g.Count()
                }).
                ToList()

            dgvRoomOccupancy.DataSource = Nothing
            dgvRoomOccupancy.DataSource = summary

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load room occupancy: " & ex.Message,
                "Room Occupancy",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub LoadPaymentMethodBreakdown()

        Try

            Dim payments As List(Of Payment) =
                _reportService.GetPaymentReport()

            Dim summary = payments.
                GroupBy(Function(p) p.PaymentMethod).
                OrderBy(Function(g) g.Key).
                Select(Function(g) New With {
                    .PaymentMethod = g.Key,
                    .PaymentCount = g.Count(),
                    .TotalCollected = g.Sum(Function(p) p.Amount)
                }).
                ToList()

            dgvPaymentMethods.DataSource = Nothing
            dgvPaymentMethods.DataSource = summary

            If dgvPaymentMethods.Columns.Contains(
                "TotalCollected") Then

                dgvPaymentMethods.Columns("TotalCollected").
                    DefaultCellStyle.Format = "C2"

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load payment breakdown: " & ex.Message,
                "Payment Breakdown",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub
End Class