<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        btnTitle = New Label()
        btnBody = New Label()
        picAbout = New PictureBox()
        CType(picAbout, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnTitle
        ' 
        btnTitle.AutoSize = True
        btnTitle.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTitle.Location = New Point(30, 31)
        btnTitle.Name = "btnTitle"
        btnTitle.Size = New Size(468, 31)
        btnTitle.TabIndex = 0
        btnTitle.Text = "HOTEL GASAN - SERVING YOU SINCE 2026"
        ' 
        ' btnBody
        ' 
        btnBody.Location = New Point(30, 420)
        btnBody.Name = "btnBody"
        btnBody.Size = New Size(498, 78)
        btnBody.TabIndex = 1
        btnBody.Text = "Welcome to Hotel Gasan! Located in Bahi, we strive to provide a nice place for visitors to enjoy the sights."
        ' 
        ' picAbout
        ' 
        picAbout.Image = CType(resources.GetObject("picAbout.Image"), Image)
        picAbout.Location = New Point(30, 65)
        picAbout.Name = "picAbout"
        picAbout.Size = New Size(498, 325)
        picAbout.SizeMode = PictureBoxSizeMode.Zoom
        picAbout.TabIndex = 2
        picAbout.TabStop = False
        ' 
        ' frmAbout
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(564, 526)
        Controls.Add(picAbout)
        Controls.Add(btnBody)
        Controls.Add(btnTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmAbout"
        StartPosition = FormStartPosition.CenterScreen
        Text = "About Us"
        CType(picAbout, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTitle As Label
    Friend WithEvents btnBody As Label
    Friend WithEvents picAbout As PictureBox
End Class
