<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowseServices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowseServices))
        lblTitle = New Label()
        txtSearch = New TextBox()
        flpServices = New FlowLayoutPanel()
        btnRefresh = New Button()
        btnClose = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(34, 26)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(176, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Available Hotel Services"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(146, 593)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(125, 27)
        txtSearch.TabIndex = 1
        ' 
        ' flpServices
        ' 
        flpServices.AutoScroll = True
        flpServices.FlowDirection = FlowDirection.TopDown
        flpServices.Location = New Point(34, 60)
        flpServices.Name = "flpServices"
        flpServices.Size = New Size(485, 518)
        flpServices.TabIndex = 2
        flpServices.WrapContents = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(34, 593)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(94, 29)
        btnRefresh.TabIndex = 3
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(425, 593)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(94, 29)
        btnClose.TabIndex = 4
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' frmBrowseServices
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(556, 659)
        Controls.Add(btnClose)
        Controls.Add(btnRefresh)
        Controls.Add(flpServices)
        Controls.Add(txtSearch)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmBrowseServices"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Browse Services"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents flpServices As FlowLayoutPanel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnClose As Button
End Class
