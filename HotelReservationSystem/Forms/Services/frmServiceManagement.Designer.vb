<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiceManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServiceManagement))
        lblDescription = New Label()
        txtDescription = New TextBox()
        lblPrice = New Label()
        txtPrice = New TextBox()
        lblStatus = New Label()
        chkActive = New CheckBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        btnBack = New Button()
        flpServices = New FlowLayoutPanel()
        lblTitle = New Label()
        SuspendLayout()
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.Location = New Point(30, 47)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(85, 20)
        lblDescription.TabIndex = 0
        lblDescription.Text = "Description"
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(121, 44)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(125, 27)
        txtDescription.TabIndex = 1
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.Location = New Point(277, 47)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(41, 20)
        lblPrice.TabIndex = 2
        lblPrice.Text = "Price"
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(324, 44)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(94, 27)
        txtPrice.TabIndex = 3
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(458, 47)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(49, 20)
        lblStatus.TabIndex = 4
        lblStatus.Text = "Status"
        ' 
        ' chkActive
        ' 
        chkActive.AutoSize = True
        chkActive.Location = New Point(513, 47)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(72, 24)
        chkActive.TabIndex = 5
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(35, 566)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(94, 29)
        btnAdd.TabIndex = 6
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(135, 566)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(94, 29)
        btnUpdate.TabIndex = 7
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(235, 566)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(94, 29)
        btnDelete.TabIndex = 8
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(335, 566)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(94, 29)
        btnClear.TabIndex = 9
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(490, 566)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 10
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' flpServices
        ' 
        flpServices.AutoScroll = True
        flpServices.FlowDirection = FlowDirection.TopDown
        flpServices.Location = New Point(35, 77)
        flpServices.Name = "flpServices"
        flpServices.Size = New Size(550, 471)
        flpServices.TabIndex = 11
        flpServices.WrapContents = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(30, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(126, 20)
        lblTitle.TabIndex = 12
        lblTitle.Text = "Manage Services"
        ' 
        ' frmServiceManagement
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(623, 614)
        Controls.Add(lblTitle)
        Controls.Add(flpServices)
        Controls.Add(btnBack)
        Controls.Add(btnClear)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(chkActive)
        Controls.Add(lblStatus)
        Controls.Add(txtPrice)
        Controls.Add(lblPrice)
        Controls.Add(txtDescription)
        Controls.Add(lblDescription)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmServiceManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Service Management"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents flpServices As FlowLayoutPanel
    Friend WithEvents lblTitle As Label
End Class
