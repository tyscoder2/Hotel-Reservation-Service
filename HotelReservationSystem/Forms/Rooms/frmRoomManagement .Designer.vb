<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoomManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRoomManagement))
        lblRoomType = New Label()
        lblRate = New Label()
        lblStatus = New Label()
        lblActive = New Label()
        cmbRoomType = New ComboBox()
        txtRate = New TextBox()
        cmbStatus = New ComboBox()
        chkActive = New CheckBox()
        flpRooms = New FlowLayoutPanel()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        btnBack = New Button()
        picRoomPreview = New PictureBox()
        btnChangePicture = New Button()
        lblTitle = New Label()
        CType(picRoomPreview, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblRoomType
        ' 
        lblRoomType.AutoSize = True
        lblRoomType.Location = New Point(210, 382)
        lblRoomType.Name = "lblRoomType"
        lblRoomType.Size = New Size(84, 20)
        lblRoomType.TabIndex = 0
        lblRoomType.Text = "Room Type"
        ' 
        ' lblRate
        ' 
        lblRate.AutoSize = True
        lblRate.Location = New Point(26, 427)
        lblRate.Name = "lblRate"
        lblRate.Size = New Size(39, 20)
        lblRate.TabIndex = 1
        lblRate.Text = "Rate"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(210, 427)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(49, 20)
        lblStatus.TabIndex = 2
        lblStatus.Text = "Status"
        ' 
        ' lblActive
        ' 
        lblActive.AutoSize = True
        lblActive.Location = New Point(26, 466)
        lblActive.Name = "lblActive"
        lblActive.Size = New Size(50, 20)
        lblActive.TabIndex = 3
        lblActive.Text = "Active"
        ' 
        ' cmbRoomType
        ' 
        cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRoomType.FormattingEnabled = True
        cmbRoomType.Items.AddRange(New Object() {"Small", "Medium", "VIP"})
        cmbRoomType.Location = New Point(300, 379)
        cmbRoomType.Name = "cmbRoomType"
        cmbRoomType.Size = New Size(151, 28)
        cmbRoomType.TabIndex = 4
        ' 
        ' txtRate
        ' 
        txtRate.Location = New Point(71, 424)
        txtRate.Name = "txtRate"
        txtRate.Size = New Size(98, 27)
        txtRate.TabIndex = 5
        ' 
        ' cmbStatus
        ' 
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.FormattingEnabled = True
        cmbStatus.Items.AddRange(New Object() {"Available", "Occupied", "Maintenance"})
        cmbStatus.Location = New Point(300, 424)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(151, 28)
        cmbStatus.TabIndex = 6
        ' 
        ' chkActive
        ' 
        chkActive.AutoSize = True
        chkActive.Location = New Point(82, 465)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(72, 24)
        chkActive.TabIndex = 7
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        ' 
        ' flpRooms
        ' 
        flpRooms.AutoScroll = True
        flpRooms.FlowDirection = FlowDirection.TopDown
        flpRooms.Location = New Point(514, 56)
        flpRooms.Name = "flpRooms"
        flpRooms.Size = New Size(368, 471)
        flpRooms.TabIndex = 8
        flpRooms.WrapContents = False
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(26, 546)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(94, 29)
        btnAdd.TabIndex = 9
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(135, 546)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(94, 29)
        btnUpdate.TabIndex = 10
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(246, 546)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(94, 29)
        btnDelete.TabIndex = 11
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(357, 546)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(94, 29)
        btnClear.TabIndex = 12
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(788, 546)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 13
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' picRoomPreview
        ' 
        picRoomPreview.BorderStyle = BorderStyle.FixedSingle
        picRoomPreview.Location = New Point(26, 56)
        picRoomPreview.Name = "picRoomPreview"
        picRoomPreview.Size = New Size(425, 304)
        picRoomPreview.SizeMode = PictureBoxSizeMode.Zoom
        picRoomPreview.TabIndex = 14
        picRoomPreview.TabStop = False
        ' 
        ' btnChangePicture
        ' 
        btnChangePicture.Location = New Point(26, 378)
        btnChangePicture.Name = "btnChangePicture"
        btnChangePicture.Size = New Size(143, 29)
        btnChangePicture.TabIndex = 15
        btnChangePicture.Text = "Change Picture"
        btnChangePicture.UseVisualStyleBackColor = True
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(26, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(118, 20)
        lblTitle.TabIndex = 16
        lblTitle.Text = "Manage Rooms"
        ' 
        ' frmRoomManagement
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(915, 599)
        Controls.Add(lblTitle)
        Controls.Add(btnChangePicture)
        Controls.Add(picRoomPreview)
        Controls.Add(btnBack)
        Controls.Add(btnClear)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(flpRooms)
        Controls.Add(chkActive)
        Controls.Add(cmbStatus)
        Controls.Add(txtRate)
        Controls.Add(cmbRoomType)
        Controls.Add(lblActive)
        Controls.Add(lblStatus)
        Controls.Add(lblRate)
        Controls.Add(lblRoomType)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmRoomManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Room Management"
        CType(picRoomPreview, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblRoomType As Label
    Friend WithEvents lblRate As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblActive As Label
    Friend WithEvents cmbRoomType As ComboBox
    Friend WithEvents txtRate As TextBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents flpRooms As FlowLayoutPanel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents picRoomPreview As PictureBox
    Friend WithEvents btnChangePicture As Button
    Friend WithEvents lblTitle As Label
End Class
