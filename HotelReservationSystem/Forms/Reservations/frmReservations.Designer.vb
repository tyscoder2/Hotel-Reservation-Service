<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservations))
        lblTitle = New Label()
        flpReservations = New FlowLayoutPanel()
        btnBack = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(29, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(57, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Details"
        ' 
        ' flpReservations
        ' 
        flpReservations.AutoScroll = True
        flpReservations.FlowDirection = FlowDirection.TopDown
        flpReservations.Location = New Point(29, 58)
        flpReservations.Name = "flpReservations"
        flpReservations.Size = New Size(630, 371)
        flpReservations.TabIndex = 1
        flpReservations.WrapContents = False
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(294, 457)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 2
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' frmReservations
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(698, 515)
        Controls.Add(btnBack)
        Controls.Add(flpReservations)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmReservations"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reservations"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents flpReservations As FlowLayoutPanel
    Friend WithEvents btnBack As Button
End Class
