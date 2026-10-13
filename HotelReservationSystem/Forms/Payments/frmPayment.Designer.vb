<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayment))
        lblTitle = New Label()
        lblReservationID = New Label()
        lblTotal = New Label()
        lblPaid = New Label()
        lblBalance = New Label()
        lblPaymentMethod = New Label()
        cmbPaymentMethod = New ComboBox()
        lblAmount = New Label()
        txtAmount = New TextBox()
        lblReferenceNumber = New Label()
        txtReferenceNumber = New TextBox()
        btnPay = New Button()
        btnBack = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(41, 38)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(71, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Payment"
        ' 
        ' lblReservationID
        ' 
        lblReservationID.AutoSize = True
        lblReservationID.Location = New Point(41, 67)
        lblReservationID.Name = "lblReservationID"
        lblReservationID.Size = New Size(108, 20)
        lblReservationID.TabIndex = 1
        lblReservationID.Text = "Reservation ID:"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(41, 100)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(45, 20)
        lblTotal.TabIndex = 2
        lblTotal.Text = "Total:"
        ' 
        ' lblPaid
        ' 
        lblPaid.AutoSize = True
        lblPaid.Location = New Point(41, 131)
        lblPaid.Name = "lblPaid"
        lblPaid.Size = New Size(40, 20)
        lblPaid.TabIndex = 3
        lblPaid.Text = "Paid:"
        ' 
        ' lblBalance
        ' 
        lblBalance.AutoSize = True
        lblBalance.Location = New Point(41, 160)
        lblBalance.Name = "lblBalance"
        lblBalance.Size = New Size(64, 20)
        lblBalance.TabIndex = 4
        lblBalance.Text = "Balance:"
        ' 
        ' lblPaymentMethod
        ' 
        lblPaymentMethod.AutoSize = True
        lblPaymentMethod.Location = New Point(42, 197)
        lblPaymentMethod.Name = "lblPaymentMethod"
        lblPaymentMethod.Size = New Size(121, 20)
        lblPaymentMethod.TabIndex = 5
        lblPaymentMethod.Text = "Payment Method"
        ' 
        ' cmbPaymentMethod
        ' 
        cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPaymentMethod.FormattingEnabled = True
        cmbPaymentMethod.Location = New Point(194, 192)
        cmbPaymentMethod.Name = "cmbPaymentMethod"
        cmbPaymentMethod.Size = New Size(151, 28)
        cmbPaymentMethod.TabIndex = 6
        ' 
        ' lblAmount
        ' 
        lblAmount.AutoSize = True
        lblAmount.Location = New Point(42, 230)
        lblAmount.Name = "lblAmount"
        lblAmount.Size = New Size(62, 20)
        lblAmount.TabIndex = 7
        lblAmount.Text = "Amount"
        ' 
        ' txtAmount
        ' 
        txtAmount.Location = New Point(194, 226)
        txtAmount.MaxLength = 13
        txtAmount.Name = "txtAmount"
        txtAmount.Size = New Size(151, 27)
        txtAmount.TabIndex = 8
        ' 
        ' lblReferenceNumber
        ' 
        lblReferenceNumber.AutoSize = True
        lblReferenceNumber.Location = New Point(43, 263)
        lblReferenceNumber.Name = "lblReferenceNumber"
        lblReferenceNumber.Size = New Size(133, 20)
        lblReferenceNumber.TabIndex = 9
        lblReferenceNumber.Text = "Reference Number"
        ' 
        ' txtReferenceNumber
        ' 
        txtReferenceNumber.Location = New Point(194, 259)
        txtReferenceNumber.Name = "txtReferenceNumber"
        txtReferenceNumber.Size = New Size(151, 27)
        txtReferenceNumber.TabIndex = 10
        ' 
        ' btnPay
        ' 
        btnPay.Location = New Point(41, 332)
        btnPay.Name = "btnPay"
        btnPay.Size = New Size(94, 29)
        btnPay.TabIndex = 11
        btnPay.Text = "Pay"
        btnPay.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(251, 332)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 12
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' frmPayment
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSeaGreen
        ClientSize = New Size(395, 397)
        Controls.Add(btnBack)
        Controls.Add(btnPay)
        Controls.Add(txtReferenceNumber)
        Controls.Add(lblReferenceNumber)
        Controls.Add(txtAmount)
        Controls.Add(lblAmount)
        Controls.Add(cmbPaymentMethod)
        Controls.Add(lblPaymentMethod)
        Controls.Add(lblBalance)
        Controls.Add(lblPaid)
        Controls.Add(lblTotal)
        Controls.Add(lblReservationID)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmPayment"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Payment"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblReservationID As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblPaid As Label
    Friend WithEvents lblBalance As Label
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents cmbPaymentMethod As ComboBox
    Friend WithEvents lblAmount As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents lblReferenceNumber As Label
    Friend WithEvents txtReferenceNumber As TextBox
    Friend WithEvents btnPay As Button
    Friend WithEvents btnBack As Button
End Class
