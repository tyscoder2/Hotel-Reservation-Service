<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuccess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSuccess))
        lblMessage = New Label()
        btnProceed = New Button()
        SuspendLayout()
        ' 
        ' lblMessage
        ' 
        lblMessage.Dock = DockStyle.Fill
        lblMessage.Location = New Point(0, 0)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(481, 250)
        lblMessage.TabIndex = 0
        lblMessage.Text = "Action was done successfully!"
        lblMessage.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnProceed
        ' 
        btnProceed.Location = New Point(198, 169)
        btnProceed.Name = "btnProceed"
        btnProceed.Size = New Size(94, 29)
        btnProceed.TabIndex = 1
        btnProceed.Text = "Continue"
        btnProceed.UseVisualStyleBackColor = True
        ' 
        ' frmSuccess
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(481, 250)
        Controls.Add(btnProceed)
        Controls.Add(lblMessage)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmSuccess"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Whoohoo!"
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblMessage As Label
    Friend WithEvents btnProceed As Button
End Class
