<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        btnRefresh = New Button()
        btnBack = New Button()
        tabReports = New TabControl()
        tabOverview = New TabPage()
        btnClearFilters = New Button()
        btnFilter = New Button()
        dtpEndDate = New DateTimePicker()
        dtpStartDate = New DateTimePicker()
        chkUseDateRange = New CheckBox()
        cmbStatusFilter = New ComboBox()
        lblStatusFilter = New Label()
        dgvReservations = New DataGridView()
        lblOutstanding = New Label()
        lblTotalCollected = New Label()
        lblTotalRevenue = New Label()
        lblCancelled = New Label()
        lblCheckedOut = New Label()
        lblCheckedIn = New Label()
        lblConfirmed = New Label()
        lblPending = New Label()
        lblTotalReservations = New Label()
        lblTitle = New Label()
        tabSchedule = New TabPage()
        lblTab2 = New Label()
        dgvSchedule = New DataGridView()
        btnLoadSchedule = New Button()
        dtpScheduleDate = New DateTimePicker()
        cmbScheduleType = New ComboBox()
        lblScheduleType = New Label()
        tabRooms = New TabPage()
        lblTab3 = New Label()
        dgvRoomOccupancy = New DataGridView()
        tabPayments = New TabPage()
        lblTab4 = New Label()
        dgvPaymentMethods = New DataGridView()
        tabReports.SuspendLayout()
        tabOverview.SuspendLayout()
        CType(dgvReservations, ComponentModel.ISupportInitialize).BeginInit()
        tabSchedule.SuspendLayout()
        CType(dgvSchedule, ComponentModel.ISupportInitialize).BeginInit()
        tabRooms.SuspendLayout()
        CType(dgvRoomOccupancy, ComponentModel.ISupportInitialize).BeginInit()
        tabPayments.SuspendLayout()
        CType(dgvPaymentMethods, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(36, 740)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(94, 29)
        btnRefresh.TabIndex = 10
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(1058, 740)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 11
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' tabReports
        ' 
        tabReports.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        tabReports.Controls.Add(tabOverview)
        tabReports.Controls.Add(tabSchedule)
        tabReports.Controls.Add(tabRooms)
        tabReports.Controls.Add(tabPayments)
        tabReports.Location = New Point(3, 3)
        tabReports.Name = "tabReports"
        tabReports.SelectedIndex = 0
        tabReports.Size = New Size(1180, 703)
        tabReports.TabIndex = 25
        ' 
        ' tabOverview
        ' 
        tabOverview.BackColor = Color.Transparent
        tabOverview.Controls.Add(btnClearFilters)
        tabOverview.Controls.Add(btnFilter)
        tabOverview.Controls.Add(dtpEndDate)
        tabOverview.Controls.Add(dtpStartDate)
        tabOverview.Controls.Add(chkUseDateRange)
        tabOverview.Controls.Add(cmbStatusFilter)
        tabOverview.Controls.Add(lblStatusFilter)
        tabOverview.Controls.Add(dgvReservations)
        tabOverview.Controls.Add(lblOutstanding)
        tabOverview.Controls.Add(lblTotalCollected)
        tabOverview.Controls.Add(lblTotalRevenue)
        tabOverview.Controls.Add(lblCancelled)
        tabOverview.Controls.Add(lblCheckedOut)
        tabOverview.Controls.Add(lblCheckedIn)
        tabOverview.Controls.Add(lblConfirmed)
        tabOverview.Controls.Add(lblPending)
        tabOverview.Controls.Add(lblTotalReservations)
        tabOverview.Controls.Add(lblTitle)
        tabOverview.Location = New Point(4, 29)
        tabOverview.Name = "tabOverview"
        tabOverview.Padding = New Padding(3)
        tabOverview.Size = New Size(1172, 670)
        tabOverview.TabIndex = 0
        tabOverview.Text = "Overview"
        ' 
        ' btnClearFilters
        ' 
        btnClearFilters.Location = New Point(983, 264)
        btnClearFilters.Name = "btnClearFilters"
        btnClearFilters.Size = New Size(162, 29)
        btnClearFilters.TabIndex = 27
        btnClearFilters.Text = "Clear Filters"
        btnClearFilters.UseVisualStyleBackColor = True
        ' 
        ' btnFilter
        ' 
        btnFilter.Location = New Point(815, 264)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(162, 29)
        btnFilter.TabIndex = 26
        btnFilter.Text = "Apply Filters"
        btnFilter.UseVisualStyleBackColor = True
        ' 
        ' dtpEndDate
        ' 
        dtpEndDate.Location = New Point(462, 266)
        dtpEndDate.Name = "dtpEndDate"
        dtpEndDate.Size = New Size(250, 27)
        dtpEndDate.TabIndex = 25
        ' 
        ' dtpStartDate
        ' 
        dtpStartDate.Location = New Point(195, 266)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(250, 27)
        dtpStartDate.TabIndex = 24
        ' 
        ' chkUseDateRange
        ' 
        chkUseDateRange.AutoSize = True
        chkUseDateRange.Location = New Point(195, 236)
        chkUseDateRange.Name = "chkUseDateRange"
        chkUseDateRange.Size = New Size(195, 24)
        chkUseDateRange.TabIndex = 23
        chkUseDateRange.Text = "Filter by reservation date"
        chkUseDateRange.UseVisualStyleBackColor = True
        ' 
        ' cmbStatusFilter
        ' 
        cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatusFilter.FormattingEnabled = True
        cmbStatusFilter.Location = New Point(24, 265)
        cmbStatusFilter.Name = "cmbStatusFilter"
        cmbStatusFilter.Size = New Size(146, 28)
        cmbStatusFilter.TabIndex = 22
        ' 
        ' lblStatusFilter
        ' 
        lblStatusFilter.AutoSize = True
        lblStatusFilter.Location = New Point(24, 236)
        lblStatusFilter.Name = "lblStatusFilter"
        lblStatusFilter.Size = New Size(49, 20)
        lblStatusFilter.TabIndex = 21
        lblStatusFilter.Text = "Status"
        ' 
        ' dgvReservations
        ' 
        dgvReservations.AllowUserToAddRows = False
        dgvReservations.AllowUserToDeleteRows = False
        dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReservations.Location = New Point(24, 309)
        dgvReservations.Name = "dgvReservations"
        dgvReservations.ReadOnly = True
        dgvReservations.RowHeadersWidth = 51
        dgvReservations.Size = New Size(1121, 355)
        dgvReservations.TabIndex = 20
        ' 
        ' lblOutstanding
        ' 
        lblOutstanding.AutoSize = True
        lblOutstanding.Location = New Point(566, 105)
        lblOutstanding.Name = "lblOutstanding"
        lblOutstanding.Size = New Size(146, 20)
        lblOutstanding.TabIndex = 19
        lblOutstanding.Text = "Outstanding balance"
        ' 
        ' lblTotalCollected
        ' 
        lblTotalCollected.AutoSize = True
        lblTotalCollected.Location = New Point(566, 80)
        lblTotalCollected.Name = "lblTotalCollected"
        lblTotalCollected.Size = New Size(136, 20)
        lblTotalCollected.TabIndex = 18
        lblTotalCollected.Text = "Payments collected"
        ' 
        ' lblTotalRevenue
        ' 
        lblTotalRevenue.AutoSize = True
        lblTotalRevenue.Location = New Point(565, 54)
        lblTotalRevenue.Name = "lblTotalRevenue"
        lblTotalRevenue.Size = New Size(158, 20)
        lblTotalRevenue.TabIndex = 17
        lblTotalRevenue.Text = "Total reservation value"
        ' 
        ' lblCancelled
        ' 
        lblCancelled.AutoSize = True
        lblCancelled.Location = New Point(27, 193)
        lblCancelled.Name = "lblCancelled"
        lblCancelled.Size = New Size(157, 20)
        lblCancelled.TabIndex = 16
        lblCancelled.Text = "Cancelled reservations"
        ' 
        ' lblCheckedOut
        ' 
        lblCheckedOut.AutoSize = True
        lblCheckedOut.Location = New Point(26, 168)
        lblCheckedOut.Name = "lblCheckedOut"
        lblCheckedOut.Size = New Size(176, 20)
        lblCheckedOut.TabIndex = 15
        lblCheckedOut.Text = "Checked-out reservations"
        ' 
        ' lblCheckedIn
        ' 
        lblCheckedIn.AutoSize = True
        lblCheckedIn.Location = New Point(27, 144)
        lblCheckedIn.Name = "lblCheckedIn"
        lblCheckedIn.Size = New Size(166, 20)
        lblCheckedIn.TabIndex = 14
        lblCheckedIn.Text = "Checked-in reservations"
        ' 
        ' lblConfirmed
        ' 
        lblConfirmed.AutoSize = True
        lblConfirmed.Location = New Point(27, 103)
        lblConfirmed.Name = "lblConfirmed"
        lblConfirmed.Size = New Size(162, 20)
        lblConfirmed.TabIndex = 13
        lblConfirmed.Text = "Confirmed reservations"
        ' 
        ' lblPending
        ' 
        lblPending.AutoSize = True
        lblPending.Location = New Point(26, 79)
        lblPending.Name = "lblPending"
        lblPending.Size = New Size(145, 20)
        lblPending.TabIndex = 12
        lblPending.Text = "Pending reservations"
        ' 
        ' lblTotalReservations
        ' 
        lblTotalReservations.AutoSize = True
        lblTotalReservations.Location = New Point(24, 53)
        lblTotalReservations.Name = "lblTotalReservations"
        lblTotalReservations.Size = New Size(125, 20)
        lblTotalReservations.TabIndex = 11
        lblTotalReservations.Text = "Total reservations"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(26, 19)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(144, 20)
        lblTitle.TabIndex = 10
        lblTitle.Text = "Reports Dashboard"
        ' 
        ' tabSchedule
        ' 
        tabSchedule.Controls.Add(lblTab2)
        tabSchedule.Controls.Add(dgvSchedule)
        tabSchedule.Controls.Add(btnLoadSchedule)
        tabSchedule.Controls.Add(dtpScheduleDate)
        tabSchedule.Controls.Add(cmbScheduleType)
        tabSchedule.Controls.Add(lblScheduleType)
        tabSchedule.Location = New Point(4, 29)
        tabSchedule.Name = "tabSchedule"
        tabSchedule.Padding = New Padding(3)
        tabSchedule.Size = New Size(1172, 670)
        tabSchedule.TabIndex = 1
        tabSchedule.Text = "Check-in / Check-out"
        tabSchedule.UseVisualStyleBackColor = True
        ' 
        ' lblTab2
        ' 
        lblTab2.AutoSize = True
        lblTab2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTab2.Location = New Point(29, 20)
        lblTab2.Name = "lblTab2"
        lblTab2.Size = New Size(175, 20)
        lblTab2.TabIndex = 30
        lblTab2.Text = "Arrivals and Departures"
        ' 
        ' dgvSchedule
        ' 
        dgvSchedule.AllowUserToAddRows = False
        dgvSchedule.AllowUserToDeleteRows = False
        dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSchedule.Location = New Point(29, 95)
        dgvSchedule.Name = "dgvSchedule"
        dgvSchedule.ReadOnly = True
        dgvSchedule.RowHeadersWidth = 51
        dgvSchedule.Size = New Size(1116, 551)
        dgvSchedule.TabIndex = 29
        ' 
        ' btnLoadSchedule
        ' 
        btnLoadSchedule.Location = New Point(1011, 54)
        btnLoadSchedule.Name = "btnLoadSchedule"
        btnLoadSchedule.Size = New Size(134, 29)
        btnLoadSchedule.TabIndex = 28
        btnLoadSchedule.Text = "Load Schedule"
        btnLoadSchedule.UseVisualStyleBackColor = True
        ' 
        ' dtpScheduleDate
        ' 
        dtpScheduleDate.Location = New Point(271, 51)
        dtpScheduleDate.Name = "dtpScheduleDate"
        dtpScheduleDate.Size = New Size(250, 27)
        dtpScheduleDate.TabIndex = 27
        ' 
        ' cmbScheduleType
        ' 
        cmbScheduleType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbScheduleType.FormattingEnabled = True
        cmbScheduleType.Location = New Point(102, 51)
        cmbScheduleType.Name = "cmbScheduleType"
        cmbScheduleType.Size = New Size(151, 28)
        cmbScheduleType.TabIndex = 26
        ' 
        ' lblScheduleType
        ' 
        lblScheduleType.AutoSize = True
        lblScheduleType.Location = New Point(27, 54)
        lblScheduleType.Name = "lblScheduleType"
        lblScheduleType.Size = New Size(69, 20)
        lblScheduleType.TabIndex = 25
        lblScheduleType.Text = "Schedule"
        ' 
        ' tabRooms
        ' 
        tabRooms.Controls.Add(lblTab3)
        tabRooms.Controls.Add(dgvRoomOccupancy)
        tabRooms.Location = New Point(4, 29)
        tabRooms.Name = "tabRooms"
        tabRooms.Padding = New Padding(3)
        tabRooms.Size = New Size(1172, 670)
        tabRooms.TabIndex = 2
        tabRooms.Text = "Room Occupancy"
        tabRooms.UseVisualStyleBackColor = True
        ' 
        ' lblTab3
        ' 
        lblTab3.AutoSize = True
        lblTab3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTab3.Location = New Point(29, 26)
        lblTab3.Name = "lblTab3"
        lblTab3.Size = New Size(154, 20)
        lblTab3.TabIndex = 31
        lblTab3.Text = "Occupancy Overview"
        ' 
        ' dgvRoomOccupancy
        ' 
        dgvRoomOccupancy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRoomOccupancy.Location = New Point(29, 66)
        dgvRoomOccupancy.Name = "dgvRoomOccupancy"
        dgvRoomOccupancy.RowHeadersWidth = 51
        dgvRoomOccupancy.Size = New Size(1116, 585)
        dgvRoomOccupancy.TabIndex = 0
        ' 
        ' tabPayments
        ' 
        tabPayments.Controls.Add(lblTab4)
        tabPayments.Controls.Add(dgvPaymentMethods)
        tabPayments.Location = New Point(4, 29)
        tabPayments.Name = "tabPayments"
        tabPayments.Padding = New Padding(3)
        tabPayments.Size = New Size(1172, 670)
        tabPayments.TabIndex = 3
        tabPayments.Text = "Payment Methods"
        tabPayments.UseVisualStyleBackColor = True
        ' 
        ' lblTab4
        ' 
        lblTab4.AutoSize = True
        lblTab4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTab4.Location = New Point(29, 29)
        lblTab4.Name = "lblTab4"
        lblTab4.Size = New Size(148, 20)
        lblTab4.TabIndex = 32
        lblTab4.Text = "Payments Overview"
        ' 
        ' dgvPaymentMethods
        ' 
        dgvPaymentMethods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPaymentMethods.Location = New Point(29, 67)
        dgvPaymentMethods.Name = "dgvPaymentMethods"
        dgvPaymentMethods.RowHeadersWidth = 51
        dgvPaymentMethods.Size = New Size(1116, 586)
        dgvPaymentMethods.TabIndex = 0
        ' 
        ' frmReports
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1188, 803)
        Controls.Add(tabReports)
        Controls.Add(btnBack)
        Controls.Add(btnRefresh)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmReports"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reports Dashboard"
        tabReports.ResumeLayout(False)
        tabOverview.ResumeLayout(False)
        tabOverview.PerformLayout()
        CType(dgvReservations, ComponentModel.ISupportInitialize).EndInit()
        tabSchedule.ResumeLayout(False)
        tabSchedule.PerformLayout()
        CType(dgvSchedule, ComponentModel.ISupportInitialize).EndInit()
        tabRooms.ResumeLayout(False)
        tabRooms.PerformLayout()
        CType(dgvRoomOccupancy, ComponentModel.ISupportInitialize).EndInit()
        tabPayments.ResumeLayout(False)
        tabPayments.PerformLayout()
        CType(dgvPaymentMethods, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents tabReports As TabControl
    Friend WithEvents tabOverview As TabPage
    Friend WithEvents tabSchedule As TabPage
    Friend WithEvents tabRooms As TabPage
    Friend WithEvents tabPayments As TabPage
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents btnFilter As Button
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents chkUseDateRange As CheckBox
    Friend WithEvents cmbStatusFilter As ComboBox
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents dgvReservations As DataGridView
    Friend WithEvents lblOutstanding As Label
    Friend WithEvents lblTotalCollected As Label
    Friend WithEvents lblTotalRevenue As Label
    Friend WithEvents lblCancelled As Label
    Friend WithEvents lblCheckedOut As Label
    Friend WithEvents lblCheckedIn As Label
    Friend WithEvents lblConfirmed As Label
    Friend WithEvents lblPending As Label
    Friend WithEvents lblTotalReservations As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents dgvSchedule As DataGridView
    Friend WithEvents btnLoadSchedule As Button
    Friend WithEvents dtpScheduleDate As DateTimePicker
    Friend WithEvents cmbScheduleType As ComboBox
    Friend WithEvents lblScheduleType As Label
    Friend WithEvents dgvRoomOccupancy As DataGridView
    Friend WithEvents dgvPaymentMethods As DataGridView
    Friend WithEvents lblTab2 As Label
    Friend WithEvents lblTab3 As Label
    Friend WithEvents lblTab4 As Label
End Class
