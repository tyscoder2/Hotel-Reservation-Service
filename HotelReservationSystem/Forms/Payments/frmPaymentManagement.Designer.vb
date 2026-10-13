<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaymentManagement))
        lblTitle = New Label()
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnShowAll = New Button()
        btnBack = New Button()
        flpPayments = New FlowLayoutPanel()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(26, 21)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(168, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Payment Management"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(202, 514)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(125, 27)
        txtSearch.TabIndex = 2
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(26, 514)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(155, 29)
        btnSearch.TabIndex = 3
        btnSearch.Text = "Search Reservation ID"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnShowAll
        ' 
        btnShowAll.Location = New Point(419, 514)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(94, 29)
        btnShowAll.TabIndex = 4
        btnShowAll.Text = "Show All"
        btnShowAll.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(532, 514)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 5
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' flpPayments
        ' 
        flpPayments.AutoScroll = True
        flpPayments.FlowDirection = FlowDirection.TopDown
        flpPayments.Location = New Point(26, 57)
        flpPayments.Name = "flpPayments"
        flpPayments.Size = New Size(600, 441)
        flpPayments.TabIndex = 6
        flpPayments.WrapContents = False
        ' 
        ' frmPaymentManagement
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(655, 566)
        Controls.Add(flpPayments)
        Controls.Add(btnBack)
        Controls.Add(btnShowAll)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmPaymentManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Payment Management"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents flpPayments As FlowLayoutPanel
End Class
