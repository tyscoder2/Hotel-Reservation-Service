<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservationServices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservationServices))
        lblTitle = New Label()
        cmbService = New ComboBox()
        nudQuantity = New NumericUpDown()
        btnAdd = New Button()
        flpReservationServices = New FlowLayoutPanel()
        lblService = New Label()
        lblQuantity = New Label()
        btnRemove = New Button()
        btnClear = New Button()
        btnBack = New Button()
        lblTotal = New Label()
        CType(nudQuantity, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(29, 22)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(121, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Choose Services"
        ' 
        ' cmbService
        ' 
        cmbService.FormattingEnabled = True
        cmbService.Location = New Point(74, 49)
        cmbService.Name = "cmbService"
        cmbService.Size = New Size(164, 28)
        cmbService.TabIndex = 1
        ' 
        ' nudQuantity
        ' 
        nudQuantity.Location = New Point(338, 49)
        nudQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudQuantity.Name = "nudQuantity"
        nudQuantity.Size = New Size(77, 27)
        nudQuantity.TabIndex = 2
        nudQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(29, 534)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(94, 29)
        btnAdd.TabIndex = 3
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' flpReservationServices
        ' 
        flpReservationServices.AutoScroll = True
        flpReservationServices.FlowDirection = FlowDirection.TopDown
        flpReservationServices.Location = New Point(29, 83)
        flpReservationServices.Name = "flpReservationServices"
        flpReservationServices.Size = New Size(553, 435)
        flpReservationServices.TabIndex = 4
        flpReservationServices.WrapContents = False
        ' 
        ' lblService
        ' 
        lblService.AutoSize = True
        lblService.Location = New Point(29, 52)
        lblService.Name = "lblService"
        lblService.Size = New Size(39, 20)
        lblService.TabIndex = 5
        lblService.Text = "Item"
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Location = New Point(267, 52)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(65, 20)
        lblQuantity.TabIndex = 6
        lblQuantity.Text = "Quantity"
        ' 
        ' btnRemove
        ' 
        btnRemove.Location = New Point(129, 534)
        btnRemove.Name = "btnRemove"
        btnRemove.Size = New Size(94, 29)
        btnRemove.TabIndex = 7
        btnRemove.Text = "Remove"
        btnRemove.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(229, 534)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(94, 29)
        btnClear.TabIndex = 8
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(488, 534)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 9
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(457, 52)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 20)
        lblTotal.TabIndex = 10
        lblTotal.Text = "Total"
        ' 
        ' frmReservationServices
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSeaGreen
        ClientSize = New Size(612, 585)
        Controls.Add(lblTotal)
        Controls.Add(btnBack)
        Controls.Add(btnClear)
        Controls.Add(btnRemove)
        Controls.Add(lblQuantity)
        Controls.Add(lblService)
        Controls.Add(flpReservationServices)
        Controls.Add(btnAdd)
        Controls.Add(nudQuantity)
        Controls.Add(cmbService)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmReservationServices"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reservation Services"
        CType(nudQuantity, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents cmbService As ComboBox
    Friend WithEvents nudQuantity As NumericUpDown
    Friend WithEvents btnAdd As Button
    Friend WithEvents flpReservationServices As FlowLayoutPanel
    Friend WithEvents lblService As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblTotal As Label
End Class
