<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfile))
        lblTitle = New Label()
        lblUsername = New Label()
        lblFirstName = New Label()
        lblMiddleName = New Label()
        lblSurname = New Label()
        lblContactNumber = New Label()
        lblAddress = New Label()
        txtUsername = New TextBox()
        txtFirstName = New TextBox()
        txtMiddleName = New TextBox()
        txtSurname = New TextBox()
        txtContactNumber = New TextBox()
        txtAddress = New TextBox()
        btnSave = New Button()
        btnCancel = New Button()
        picProfile = New PictureBox()
        btnChangePicture = New Button()
        CType(picProfile, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(42, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(81, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "My Profile"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(42, 265)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(78, 20)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username:"
        ' 
        ' lblFirstName
        ' 
        lblFirstName.AutoSize = True
        lblFirstName.Location = New Point(42, 309)
        lblFirstName.Name = "lblFirstName"
        lblFirstName.Size = New Size(83, 20)
        lblFirstName.TabIndex = 2
        lblFirstName.Text = "First Name:"
        ' 
        ' lblMiddleName
        ' 
        lblMiddleName.AutoSize = True
        lblMiddleName.Location = New Point(42, 343)
        lblMiddleName.Name = "lblMiddleName"
        lblMiddleName.Size = New Size(103, 20)
        lblMiddleName.TabIndex = 3
        lblMiddleName.Text = "Middle Name:"
        ' 
        ' lblSurname
        ' 
        lblSurname.AutoSize = True
        lblSurname.Location = New Point(42, 375)
        lblSurname.Name = "lblSurname"
        lblSurname.Size = New Size(70, 20)
        lblSurname.TabIndex = 4
        lblSurname.Text = "Surname:"
        ' 
        ' lblContactNumber
        ' 
        lblContactNumber.AutoSize = True
        lblContactNumber.Location = New Point(42, 426)
        lblContactNumber.Name = "lblContactNumber"
        lblContactNumber.Size = New Size(121, 20)
        lblContactNumber.TabIndex = 5
        lblContactNumber.Text = "Contact Number:"
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Location = New Point(42, 459)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(65, 20)
        lblAddress.TabIndex = 6
        lblAddress.Text = "Address:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(282, 265)
        txtUsername.Name = "txtUsername"
        txtUsername.ReadOnly = True
        txtUsername.Size = New Size(125, 27)
        txtUsername.TabIndex = 7
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(282, 308)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(125, 27)
        txtFirstName.TabIndex = 8
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Location = New Point(282, 343)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(125, 27)
        txtMiddleName.TabIndex = 9
        ' 
        ' txtSurname
        ' 
        txtSurname.Location = New Point(282, 378)
        txtSurname.Name = "txtSurname"
        txtSurname.Size = New Size(125, 27)
        txtSurname.TabIndex = 10
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(282, 423)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(125, 27)
        txtContactNumber.TabIndex = 11
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(282, 456)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(125, 27)
        txtAddress.TabIndex = 12
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(42, 508)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(94, 29)
        btnSave.TabIndex = 13
        btnSave.Text = "Save Changes"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(311, 508)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 29)
        btnCancel.TabIndex = 14
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' picProfile
        ' 
        picProfile.BorderStyle = BorderStyle.FixedSingle
        picProfile.Location = New Point(150, 44)
        picProfile.Name = "picProfile"
        picProfile.Size = New Size(149, 159)
        picProfile.SizeMode = PictureBoxSizeMode.Zoom
        picProfile.TabIndex = 15
        picProfile.TabStop = False
        ' 
        ' btnChangePicture
        ' 
        btnChangePicture.Location = New Point(176, 209)
        btnChangePicture.Name = "btnChangePicture"
        btnChangePicture.Size = New Size(94, 29)
        btnChangePicture.TabIndex = 16
        btnChangePicture.Text = "Change"
        btnChangePicture.UseVisualStyleBackColor = True
        ' 
        ' frmProfile
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSeaGreen
        ClientSize = New Size(452, 573)
        Controls.Add(btnChangePicture)
        Controls.Add(picProfile)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtAddress)
        Controls.Add(txtContactNumber)
        Controls.Add(txtSurname)
        Controls.Add(txtMiddleName)
        Controls.Add(txtFirstName)
        Controls.Add(txtUsername)
        Controls.Add(lblAddress)
        Controls.Add(lblContactNumber)
        Controls.Add(lblSurname)
        Controls.Add(lblMiddleName)
        Controls.Add(lblFirstName)
        Controls.Add(lblUsername)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmProfile"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Profile"
        CType(picProfile, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblMiddleName As Label
    Friend WithEvents lblSurname As Label
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents picProfile As PictureBox
    Friend WithEvents btnChangePicture As Button
End Class
