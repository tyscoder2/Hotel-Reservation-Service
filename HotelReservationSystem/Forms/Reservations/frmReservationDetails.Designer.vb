<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservationDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservationDetails))
        lblTitle = New Label()
        lblReservationID = New Label()
        lblRoomID = New Label()
        lblStatus = New Label()
        lblCheckOut = New Label()
        lblCheckIn = New Label()
        lblPaid = New Label()
        lblTotal = New Label()
        lblRoomRate = New Label()
        Label10 = New Label()
        lblReservationDate = New Label()
        lblBalance = New Label()
        btnBack = New Button()
        btnServices = New Button()
        lblServiceCharges = New Label()
        btnPay = New Button()
        lblPaymentHistory = New Label()
        flpPayments = New FlowLayoutPanel()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(35, 22)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(157, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Breakdown of details"
        ' 
        ' lblReservationID
        ' 
        lblReservationID.AutoSize = True
        lblReservationID.Location = New Point(35, 53)
        lblReservationID.Name = "lblReservationID"
        lblReservationID.Size = New Size(105, 20)
        lblReservationID.TabIndex = 1
        lblReservationID.Text = "Reservation ID"
        ' 
        ' lblRoomID
        ' 
        lblRoomID.AutoSize = True
        lblRoomID.Location = New Point(35, 78)
        lblRoomID.Name = "lblRoomID"
        lblRoomID.Size = New Size(68, 20)
        lblRoomID.TabIndex = 2
        lblRoomID.Text = "Room ID"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(37, 203)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(49, 20)
        lblStatus.TabIndex = 5
        lblStatus.Text = "Status"
        ' 
        ' lblCheckOut
        ' 
        lblCheckOut.AutoSize = True
        lblCheckOut.Location = New Point(35, 166)
        lblCheckOut.Name = "lblCheckOut"
        lblCheckOut.Size = New Size(78, 20)
        lblCheckOut.TabIndex = 4
        lblCheckOut.Text = "Check-Out"
        ' 
        ' lblCheckIn
        ' 
        lblCheckIn.AutoSize = True
        lblCheckIn.Location = New Point(35, 142)
        lblCheckIn.Name = "lblCheckIn"
        lblCheckIn.Size = New Size(66, 20)
        lblCheckIn.TabIndex = 3
        lblCheckIn.Text = "Check-In"
        ' 
        ' lblPaid
        ' 
        lblPaid.AutoSize = True
        lblPaid.Location = New Point(342, 148)
        lblPaid.Name = "lblPaid"
        lblPaid.Size = New Size(37, 20)
        lblPaid.TabIndex = 8
        lblPaid.Text = "Paid"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(342, 125)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 20)
        lblTotal.TabIndex = 7
        lblTotal.Text = "Total"
        ' 
        ' lblRoomRate
        ' 
        lblRoomRate.AutoSize = True
        lblRoomRate.Location = New Point(342, 62)
        lblRoomRate.Name = "lblRoomRate"
        lblRoomRate.Size = New Size(83, 20)
        lblRoomRate.TabIndex = 6
        lblRoomRate.Text = "Room Rate"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(80, 351)
        Label10.Name = "Label10"
        Label10.Size = New Size(0, 20)
        Label10.TabIndex = 11
        ' 
        ' lblReservationDate
        ' 
        lblReservationDate.AutoSize = True
        lblReservationDate.Location = New Point(35, 120)
        lblReservationDate.Name = "lblReservationDate"
        lblReservationDate.Size = New Size(122, 20)
        lblReservationDate.TabIndex = 10
        lblReservationDate.Text = "Reservation Date"
        ' 
        ' lblBalance
        ' 
        lblBalance.AutoSize = True
        lblBalance.Location = New Point(342, 172)
        lblBalance.Name = "lblBalance"
        lblBalance.Size = New Size(61, 20)
        lblBalance.TabIndex = 9
        lblBalance.Text = "Balance"
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(484, 592)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(94, 29)
        btnBack.TabIndex = 12
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' btnServices
        ' 
        btnServices.Location = New Point(32, 594)
        btnServices.Name = "btnServices"
        btnServices.Size = New Size(94, 29)
        btnServices.TabIndex = 13
        btnServices.Text = "Services"
        btnServices.UseVisualStyleBackColor = True
        ' 
        ' lblServiceCharges
        ' 
        lblServiceCharges.AutoSize = True
        lblServiceCharges.Location = New Point(342, 87)
        lblServiceCharges.Name = "lblServiceCharges"
        lblServiceCharges.Size = New Size(156, 20)
        lblServiceCharges.TabIndex = 14
        lblServiceCharges.Text = "Service Charges: ₱0.00"
        ' 
        ' btnPay
        ' 
        btnPay.Location = New Point(167, 594)
        btnPay.Name = "btnPay"
        btnPay.Size = New Size(94, 29)
        btnPay.TabIndex = 15
        btnPay.Text = "Pay"
        btnPay.UseVisualStyleBackColor = True
        ' 
        ' lblPaymentHistory
        ' 
        lblPaymentHistory.AutoSize = True
        lblPaymentHistory.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPaymentHistory.Location = New Point(35, 262)
        lblPaymentHistory.Name = "lblPaymentHistory"
        lblPaymentHistory.Size = New Size(127, 20)
        lblPaymentHistory.TabIndex = 16
        lblPaymentHistory.Text = "Payment History"
        ' 
        ' flpPayments
        ' 
        flpPayments.AutoScroll = True
        flpPayments.FlowDirection = FlowDirection.TopDown
        flpPayments.Location = New Point(35, 285)
        flpPayments.Name = "flpPayments"
        flpPayments.Size = New Size(543, 281)
        flpPayments.TabIndex = 17
        flpPayments.WrapContents = False
        ' 
        ' frmReservationDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(615, 650)
        Controls.Add(flpPayments)
        Controls.Add(lblPaymentHistory)
        Controls.Add(btnPay)
        Controls.Add(lblServiceCharges)
        Controls.Add(btnServices)
        Controls.Add(btnBack)
        Controls.Add(Label10)
        Controls.Add(lblReservationDate)
        Controls.Add(lblBalance)
        Controls.Add(lblPaid)
        Controls.Add(lblTotal)
        Controls.Add(lblRoomRate)
        Controls.Add(lblStatus)
        Controls.Add(lblCheckOut)
        Controls.Add(lblCheckIn)
        Controls.Add(lblRoomID)
        Controls.Add(lblReservationID)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmReservationDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reservation Details"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblReservationID As Label
    Friend WithEvents lblRoomID As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCheckOut As Label
    Friend WithEvents lblCheckIn As Label
    Friend WithEvents lblPaid As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblRoomRate As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblReservationDate As Label
    Friend WithEvents lblBalance As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnServices As Button
    Friend WithEvents lblServiceCharges As Label
    Friend WithEvents btnPay As Button
    Friend WithEvents lblPaymentHistory As Label
    Friend WithEvents flpPayments As FlowLayoutPanel
End Class
