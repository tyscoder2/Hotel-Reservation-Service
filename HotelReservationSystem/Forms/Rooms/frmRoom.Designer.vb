<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRoom))
        lblRoomID = New Label()
        lblRoomType = New Label()
        lblRate = New Label()
        lblStatus = New Label()
        btnReserve = New Button()
        btnBack = New Button()
        picRoom = New PictureBox()
        CType(picRoom, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblRoomID
        ' 
        lblRoomID.AutoSize = True
        lblRoomID.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRoomID.Location = New Point(36, 28)
        lblRoomID.Name = "lblRoomID"
        lblRoomID.Size = New Size(107, 31)
        lblRoomID.TabIndex = 0
        lblRoomID.Text = "Room ID"
        ' 
        ' lblRoomType
        ' 
        lblRoomType.AutoSize = True
        lblRoomType.Location = New Point(30, 459)
        lblRoomType.Name = "lblRoomType"
        lblRoomType.Size = New Size(84, 20)
        lblRoomType.TabIndex = 1
        lblRoomType.Text = "Room Type"
        ' 
        ' lblRate
        ' 
        lblRate.AutoSize = True
        lblRate.Location = New Point(321, 459)
        lblRate.Name = "lblRate"
        lblRate.Size = New Size(39, 20)
        lblRate.TabIndex = 2
        lblRate.Text = "Rate"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(571, 459)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(49, 20)
        lblStatus.TabIndex = 3
        lblStatus.Text = "Status"
        ' 
        ' btnReserve
        ' 
        btnReserve.Location = New Point(30, 513)
        btnReserve.Name = "btnReserve"
        btnReserve.Size = New Size(94, 29)
        btnReserve.TabIndex = 4
        btnReserve.Text = "Reserve"
        btnReserve.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(584, 513)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 5
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' picRoom
        ' 
        picRoom.BorderStyle = BorderStyle.FixedSingle
        picRoom.Location = New Point(36, 79)
        picRoom.Name = "picRoom"
        picRoom.Size = New Size(642, 352)
        picRoom.SizeMode = PictureBoxSizeMode.Zoom
        picRoom.TabIndex = 6
        picRoom.TabStop = False
        ' 
        ' frmRoom
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSeaGreen
        ClientSize = New Size(727, 574)
        Controls.Add(picRoom)
        Controls.Add(btnBack)
        Controls.Add(btnReserve)
        Controls.Add(lblStatus)
        Controls.Add(lblRate)
        Controls.Add(lblRoomType)
        Controls.Add(lblRoomID)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmRoom"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Room Detail"
        CType(picRoom, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblRoomID As Label
    Friend WithEvents lblRoomType As Label
    Friend WithEvents lblRate As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnReserve As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents picRoom As PictureBox
End Class
