<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        btnAbout = New Button()
        btnReserve = New Button()
        btnServices = New Button()
        btnProfile = New Button()
        btnReservations = New Button()
        btnRoomManagement = New Button()
        btnServiceManagement = New Button()
        btnPaymentManagement = New Button()
        btnReports = New Button()
        btnLogout = New Button()
        btnGuestManagement = New Button()
        btnReservationManagement = New Button()
        btnTitle = New Label()
        SuspendLayout()
        ' 
        ' btnAbout
        ' 
        btnAbout.Location = New Point(13, 70)
        btnAbout.Name = "btnAbout"
        btnAbout.Size = New Size(128, 56)
        btnAbout.TabIndex = 0
        btnAbout.Text = "About Us"
        btnAbout.UseVisualStyleBackColor = True
        ' 
        ' btnReserve
        ' 
        btnReserve.Location = New Point(147, 70)
        btnReserve.Name = "btnReserve"
        btnReserve.Size = New Size(128, 56)
        btnReserve.TabIndex = 1
        btnReserve.Text = "Reserve a Room"
        btnReserve.UseVisualStyleBackColor = True
        ' 
        ' btnServices
        ' 
        btnServices.Location = New Point(281, 70)
        btnServices.Name = "btnServices"
        btnServices.Size = New Size(128, 56)
        btnServices.TabIndex = 2
        btnServices.Text = "Our Services"
        btnServices.UseVisualStyleBackColor = True
        ' 
        ' btnProfile
        ' 
        btnProfile.Location = New Point(695, 70)
        btnProfile.Name = "btnProfile"
        btnProfile.Size = New Size(94, 29)
        btnProfile.TabIndex = 3
        btnProfile.Text = "Edit Profile"
        btnProfile.UseVisualStyleBackColor = True
        ' 
        ' btnReservations
        ' 
        btnReservations.Location = New Point(415, 70)
        btnReservations.Name = "btnReservations"
        btnReservations.Size = New Size(128, 56)
        btnReservations.TabIndex = 4
        btnReservations.Text = "Reservations"
        btnReservations.UseVisualStyleBackColor = True
        ' 
        ' btnRoomManagement
        ' 
        btnRoomManagement.Location = New Point(147, 128)
        btnRoomManagement.Name = "btnRoomManagement"
        btnRoomManagement.Size = New Size(128, 56)
        btnRoomManagement.TabIndex = 5
        btnRoomManagement.Text = "Room Management"
        btnRoomManagement.UseVisualStyleBackColor = True
        ' 
        ' btnServiceManagement
        ' 
        btnServiceManagement.Location = New Point(281, 128)
        btnServiceManagement.Name = "btnServiceManagement"
        btnServiceManagement.Size = New Size(128, 56)
        btnServiceManagement.TabIndex = 6
        btnServiceManagement.Text = "Service Management"
        btnServiceManagement.UseVisualStyleBackColor = True
        ' 
        ' btnPaymentManagement
        ' 
        btnPaymentManagement.Location = New Point(549, 128)
        btnPaymentManagement.Name = "btnPaymentManagement"
        btnPaymentManagement.Size = New Size(128, 56)
        btnPaymentManagement.TabIndex = 7
        btnPaymentManagement.Text = "Payment Management"
        btnPaymentManagement.UseVisualStyleBackColor = True
        ' 
        ' btnReports
        ' 
        btnReports.Location = New Point(549, 70)
        btnReports.Name = "btnReports"
        btnReports.Size = New Size(128, 56)
        btnReports.TabIndex = 8
        btnReports.Text = "Reports"
        btnReports.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(695, 105)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(94, 29)
        btnLogout.TabIndex = 9
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnGuestManagement
        ' 
        btnGuestManagement.Location = New Point(13, 128)
        btnGuestManagement.Name = "btnGuestManagement"
        btnGuestManagement.Size = New Size(128, 56)
        btnGuestManagement.TabIndex = 10
        btnGuestManagement.Text = "Guest Management"
        btnGuestManagement.UseVisualStyleBackColor = True
        ' 
        ' btnReservationManagement
        ' 
        btnReservationManagement.Location = New Point(415, 128)
        btnReservationManagement.Name = "btnReservationManagement"
        btnReservationManagement.Size = New Size(128, 56)
        btnReservationManagement.TabIndex = 11
        btnReservationManagement.Text = "Reservation Management"
        btnReservationManagement.UseVisualStyleBackColor = True
        ' 
        ' btnTitle
        ' 
        btnTitle.AutoSize = True
        btnTitle.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTitle.Location = New Point(241, 19)
        btnTitle.Name = "btnTitle"
        btnTitle.Size = New Size(330, 31)
        btnTitle.TabIndex = 12
        btnTitle.Text = "WELCOME TO HOTEL GASAN!"
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(800, 506)
        Controls.Add(btnTitle)
        Controls.Add(btnReservationManagement)
        Controls.Add(btnGuestManagement)
        Controls.Add(btnLogout)
        Controls.Add(btnReports)
        Controls.Add(btnPaymentManagement)
        Controls.Add(btnServiceManagement)
        Controls.Add(btnRoomManagement)
        Controls.Add(btnReservations)
        Controls.Add(btnProfile)
        Controls.Add(btnServices)
        Controls.Add(btnReserve)
        Controls.Add(btnAbout)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Hotel Gasan Services"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAbout As Button
    Friend WithEvents btnReserve As Button
    Friend WithEvents btnServices As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents btnReservations As Button
    Friend WithEvents btnRoomManagement As Button
    Friend WithEvents btnServiceManagement As Button
    Friend WithEvents btnPaymentManagement As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnGuestManagement As Button
    Friend WithEvents btnReservationManagement As Button
    Friend WithEvents btnTitle As Label
End Class
