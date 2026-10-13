<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRooms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRooms))
        flpRooms = New FlowLayoutPanel()
        btnBack = New Button()
        lblTitle = New Label()
        SuspendLayout()
        ' 
        ' flpRooms
        ' 
        flpRooms.AutoScroll = True
        flpRooms.Location = New Point(31, 53)
        flpRooms.Name = "flpRooms"
        flpRooms.Size = New Size(714, 496)
        flpRooms.TabIndex = 0
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(336, 574)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 1
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(31, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(126, 20)
        lblTitle.TabIndex = 2
        lblTitle.Text = "Available Rooms"
        ' 
        ' frmRooms
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(783, 628)
        Controls.Add(lblTitle)
        Controls.Add(btnBack)
        Controls.Add(flpRooms)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmRooms"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Rooms"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents flpRooms As FlowLayoutPanel
    Friend WithEvents btnBack As Button
    Friend WithEvents lblTitle As Label
End Class
