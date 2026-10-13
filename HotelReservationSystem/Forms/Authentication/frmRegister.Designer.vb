<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegister))
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        txtFirstName = New TextBox()
        txtSurname = New TextBox()
        txtMiddleName = New TextBox()
        txtContactNumber = New TextBox()
        txtAddress = New TextBox()
        btnRegister = New Button()
        lblUsername = New Label()
        lblPassword = New Label()
        lblFirstName = New Label()
        lblSurname = New Label()
        lblMiddleName = New Label()
        lblNumber = New Label()
        lblAddress = New Label()
        btnBack = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(190, 73)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(125, 27)
        txtUsername.TabIndex = 0
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(190, 112)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(125, 27)
        txtPassword.TabIndex = 1
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(190, 167)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(125, 27)
        txtFirstName.TabIndex = 2
        ' 
        ' txtSurname
        ' 
        txtSurname.Location = New Point(190, 205)
        txtSurname.Name = "txtSurname"
        txtSurname.Size = New Size(125, 27)
        txtSurname.TabIndex = 3
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Location = New Point(190, 241)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(125, 27)
        txtMiddleName.TabIndex = 4
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(190, 297)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(125, 27)
        txtContactNumber.TabIndex = 5
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(190, 333)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(125, 27)
        txtAddress.TabIndex = 6
        ' 
        ' btnRegister
        ' 
        btnRegister.Location = New Point(78, 390)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(94, 29)
        btnRegister.TabIndex = 7
        btnRegister.Text = "Register"
        btnRegister.UseVisualStyleBackColor = True
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(79, 77)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(78, 20)
        lblUsername.TabIndex = 8
        lblUsername.Text = "Username:"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(79, 114)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(73, 20)
        lblPassword.TabIndex = 9
        lblPassword.Text = "Password:"
        ' 
        ' lblFirstName
        ' 
        lblFirstName.AutoSize = True
        lblFirstName.Location = New Point(79, 170)
        lblFirstName.Name = "lblFirstName"
        lblFirstName.Size = New Size(83, 20)
        lblFirstName.TabIndex = 10
        lblFirstName.Text = "First Name:"
        ' 
        ' lblSurname
        ' 
        lblSurname.AutoSize = True
        lblSurname.Location = New Point(79, 205)
        lblSurname.Name = "lblSurname"
        lblSurname.Size = New Size(70, 20)
        lblSurname.TabIndex = 11
        lblSurname.Text = "Surname:"
        ' 
        ' lblMiddleName
        ' 
        lblMiddleName.AutoSize = True
        lblMiddleName.Location = New Point(79, 242)
        lblMiddleName.Name = "lblMiddleName"
        lblMiddleName.Size = New Size(103, 20)
        lblMiddleName.TabIndex = 12
        lblMiddleName.Text = "Middle Name:"
        ' 
        ' lblNumber
        ' 
        lblNumber.AutoSize = True
        lblNumber.Location = New Point(78, 300)
        lblNumber.Name = "lblNumber"
        lblNumber.Size = New Size(66, 20)
        lblNumber.TabIndex = 13
        lblNumber.Text = "Number:"
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Location = New Point(79, 334)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(65, 20)
        lblAddress.TabIndex = 14
        lblAddress.Text = "Address:"
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(221, 390)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 15
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(78, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(134, 20)
        Label1.TabIndex = 16
        Label1.Text = "Enter Your Details"
        ' 
        ' frmRegister
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSeaGreen
        ClientSize = New Size(419, 450)
        Controls.Add(Label1)
        Controls.Add(btnBack)
        Controls.Add(lblAddress)
        Controls.Add(lblNumber)
        Controls.Add(lblMiddleName)
        Controls.Add(lblSurname)
        Controls.Add(lblFirstName)
        Controls.Add(lblPassword)
        Controls.Add(lblUsername)
        Controls.Add(btnRegister)
        Controls.Add(txtAddress)
        Controls.Add(txtContactNumber)
        Controls.Add(txtMiddleName)
        Controls.Add(txtSurname)
        Controls.Add(txtFirstName)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmRegister"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Register"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblSurname As Label
    Friend WithEvents lblMiddleName As Label
    Friend WithEvents lblNumber As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Label1 As Label
End Class
