<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservationManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservationManagement))
        lblTitle = New Label()
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnRefresh = New Button()
        dgvReservations = New DataGridView()
        btnConfirm = New Button()
        btnCheckIn = New Button()
        btnCheckOut = New Button()
        btnCancel = New Button()
        btnViewDetails = New Button()
        btnClose = New Button()
        CType(dgvReservations, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(12, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(251, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Search by Reservation ID or Status"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(115, 49)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(125, 27)
        txtSearch.TabIndex = 1
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(12, 47)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(94, 29)
        btnSearch.TabIndex = 3
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(1086, 48)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(94, 29)
        btnRefresh.TabIndex = 4
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' dgvReservations
        ' 
        dgvReservations.AllowUserToAddRows = False
        dgvReservations.AllowUserToDeleteRows = False
        dgvReservations.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReservations.Location = New Point(12, 86)
        dgvReservations.Name = "dgvReservations"
        dgvReservations.ReadOnly = True
        dgvReservations.RowHeadersWidth = 51
        dgvReservations.Size = New Size(1169, 485)
        dgvReservations.TabIndex = 5
        ' 
        ' btnConfirm
        ' 
        btnConfirm.Location = New Point(115, 591)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(94, 29)
        btnConfirm.TabIndex = 6
        btnConfirm.Text = "Confirm"
        btnConfirm.UseVisualStyleBackColor = True
        ' 
        ' btnCheckIn
        ' 
        btnCheckIn.Location = New Point(15, 591)
        btnCheckIn.Name = "btnCheckIn"
        btnCheckIn.Size = New Size(94, 29)
        btnCheckIn.TabIndex = 7
        btnCheckIn.Text = "Check In"
        btnCheckIn.UseVisualStyleBackColor = True
        ' 
        ' btnCheckOut
        ' 
        btnCheckOut.Location = New Point(215, 591)
        btnCheckOut.Name = "btnCheckOut"
        btnCheckOut.Size = New Size(94, 29)
        btnCheckOut.TabIndex = 8
        btnCheckOut.Text = "Check Out"
        btnCheckOut.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(315, 591)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 29)
        btnCancel.TabIndex = 9
        btnCancel.Text = "Cancel Reservation"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnViewDetails
        ' 
        btnViewDetails.Location = New Point(415, 591)
        btnViewDetails.Name = "btnViewDetails"
        btnViewDetails.Size = New Size(94, 29)
        btnViewDetails.TabIndex = 10
        btnViewDetails.Text = "View Details"
        btnViewDetails.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(1087, 591)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(94, 29)
        btnClose.TabIndex = 11
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' frmReservationManagement
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1192, 632)
        Controls.Add(btnClose)
        Controls.Add(btnViewDetails)
        Controls.Add(btnCancel)
        Controls.Add(btnCheckOut)
        Controls.Add(btnCheckIn)
        Controls.Add(btnConfirm)
        Controls.Add(dgvReservations)
        Controls.Add(btnRefresh)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmReservationManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reservation Management"
        CType(dgvReservations, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvReservations As DataGridView
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCheckIn As Button
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents btnClose As Button
End Class
