<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservation))
        lblRoomID = New Label()
        lblRoomType = New Label()
        lblRate = New Label()
        lblCheckIn = New Label()
        lblCheckOut = New Label()
        lblNights = New Label()
        lblTotal = New Label()
        dtpCheckIn = New DateTimePicker()
        dtpCheckOut = New DateTimePicker()
        btnReserve = New Button()
        btnBack = New Button()
        SuspendLayout()
        ' 
        ' lblRoomID
        ' 
        lblRoomID.AutoSize = True
        lblRoomID.Location = New Point(41, 21)
        lblRoomID.Name = "lblRoomID"
        lblRoomID.Size = New Size(68, 20)
        lblRoomID.TabIndex = 0
        lblRoomID.Text = "Room ID"
        ' 
        ' lblRoomType
        ' 
        lblRoomType.AutoSize = True
        lblRoomType.Location = New Point(41, 69)
        lblRoomType.Name = "lblRoomType"
        lblRoomType.Size = New Size(84, 20)
        lblRoomType.TabIndex = 1
        lblRoomType.Text = "Room Type"
        ' 
        ' lblRate
        ' 
        lblRate.AutoSize = True
        lblRate.Location = New Point(41, 103)
        lblRate.Name = "lblRate"
        lblRate.Size = New Size(39, 20)
        lblRate.TabIndex = 2
        lblRate.Text = "Rate"
        ' 
        ' lblCheckIn
        ' 
        lblCheckIn.AutoSize = True
        lblCheckIn.Location = New Point(41, 138)
        lblCheckIn.Name = "lblCheckIn"
        lblCheckIn.Size = New Size(66, 20)
        lblCheckIn.TabIndex = 3
        lblCheckIn.Text = "Check-In"
        ' 
        ' lblCheckOut
        ' 
        lblCheckOut.AutoSize = True
        lblCheckOut.Location = New Point(41, 182)
        lblCheckOut.Name = "lblCheckOut"
        lblCheckOut.Size = New Size(78, 20)
        lblCheckOut.TabIndex = 4
        lblCheckOut.Text = "Check-Out"
        ' 
        ' lblNights
        ' 
        lblNights.AutoSize = True
        lblNights.Location = New Point(41, 226)
        lblNights.Name = "lblNights"
        lblNights.Size = New Size(128, 20)
        lblNights.TabIndex = 5
        lblNights.Text = "Number of Nights"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(41, 280)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 20)
        lblTotal.TabIndex = 6
        lblTotal.Text = "Total"
        ' 
        ' dtpCheckIn
        ' 
        dtpCheckIn.Location = New Point(145, 138)
        dtpCheckIn.Name = "dtpCheckIn"
        dtpCheckIn.Size = New Size(250, 27)
        dtpCheckIn.TabIndex = 7
        ' 
        ' dtpCheckOut
        ' 
        dtpCheckOut.Location = New Point(145, 182)
        dtpCheckOut.Name = "dtpCheckOut"
        dtpCheckOut.Size = New Size(250, 27)
        dtpCheckOut.TabIndex = 8
        ' 
        ' btnReserve
        ' 
        btnReserve.Location = New Point(41, 356)
        btnReserve.Name = "btnReserve"
        btnReserve.Size = New Size(94, 29)
        btnReserve.TabIndex = 9
        btnReserve.Text = "Reserve"
        btnReserve.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(301, 356)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 10
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' frmReservation
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSeaGreen
        ClientSize = New Size(438, 450)
        Controls.Add(btnBack)
        Controls.Add(btnReserve)
        Controls.Add(dtpCheckOut)
        Controls.Add(dtpCheckIn)
        Controls.Add(lblTotal)
        Controls.Add(lblNights)
        Controls.Add(lblCheckOut)
        Controls.Add(lblCheckIn)
        Controls.Add(lblRate)
        Controls.Add(lblRoomType)
        Controls.Add(lblRoomID)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmReservation"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Make a Reservation"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblRoomID As Label
    Friend WithEvents lblRoomType As Label
    Friend WithEvents lblRate As Label
    Friend WithEvents lblCheckIn As Label
    Friend WithEvents lblCheckOut As Label
    Friend WithEvents lblNights As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents dtpCheckIn As DateTimePicker
    Friend WithEvents dtpCheckOut As DateTimePicker
    Friend WithEvents btnReserve As Button
    Friend WithEvents btnBack As Button
End Class
