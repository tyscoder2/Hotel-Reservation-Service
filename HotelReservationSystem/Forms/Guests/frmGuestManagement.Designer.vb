<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuestManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuestManagement))
        lblTitle = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnShowAll = New Button()
        btnBack = New Button()
        flpGuests = New FlowLayoutPanel()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(24, 22)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(105, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "List of Guests"
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(24, 63)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(0, 20)
        lblSearch.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(169, 554)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(125, 27)
        txtSearch.TabIndex = 2
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(26, 552)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(128, 29)
        btnSearch.TabIndex = 3
        btnSearch.Text = "Search Guest ID"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnShowAll
        ' 
        btnShowAll.Location = New Point(404, 552)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(94, 29)
        btnShowAll.TabIndex = 4
        btnShowAll.Text = "Show All"
        btnShowAll.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(524, 552)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 5
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' flpGuests
        ' 
        flpGuests.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        flpGuests.AutoScroll = True
        flpGuests.FlowDirection = FlowDirection.TopDown
        flpGuests.Location = New Point(26, 63)
        flpGuests.Name = "flpGuests"
        flpGuests.Size = New Size(593, 471)
        flpGuests.TabIndex = 6
        flpGuests.WrapContents = False
        ' 
        ' frmGuestManagement
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(650, 603)
        Controls.Add(flpGuests)
        Controls.Add(btnBack)
        Controls.Add(btnShowAll)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(lblSearch)
        Controls.Add(lblTitle)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmGuestManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Guest Management"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents flpGuests As FlowLayoutPanel
End Class
