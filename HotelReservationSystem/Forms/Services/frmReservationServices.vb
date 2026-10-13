Public Class frmReservationServices

    Private ReadOnly _reservationServiceItemService As New ReservationServiceItemService()
    Private ReadOnly _serviceService As New ServiceService()

    Private ReadOnly _reservationId As Integer

    Private _selectedReservationServiceId As Integer = 0

    Public Sub New(reservationId As Integer)

        InitializeComponent()

        _reservationId = reservationId

    End Sub

    Private Sub frmReservationServices_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn Then

            MessageBox.Show(
                "You must be logged in to manage reservation services.",
                "Reservation Services",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        LoadServices()
        LoadReservationServices()

    End Sub

    Private Sub LoadServices()

        cmbService.Items.Clear()

        Dim services As List(Of Service) =
            _serviceService.GetActiveServices()

        For Each service As Service In services

            cmbService.Items.Add(service)

        Next

        If cmbService.Items.Count > 0 Then
            cmbService.SelectedIndex = 0
        End If

    End Sub

    Private Sub LoadReservationServices()

        flpReservationServices.Controls.Clear()

        Dim items As List(Of ReservationServiceItem) =
            _reservationServiceItemService.GetReservationServices(_reservationId)

        Dim total As Decimal = 0D

        For Each item As ReservationServiceItem In items

            AddServiceCard(item)

            total += item.Subtotal

        Next

        lblTotal.Text =
            "Total Service Charges: " &
            total.ToString("C2")

    End Sub


    Private Sub AddServiceCard(
    item As ReservationServiceItem
)

        Dim panel As New Panel()

        panel.Width = 420
        panel.Height = 100
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Margin = New Padding(5)

        Dim lblServiceName As New Label()

        lblServiceName.AutoSize = True
        lblServiceName.Location = New Point(10, 10)
        Dim service As Service =
    _serviceService.GetService(item.ServiceID)

        If service IsNot Nothing Then
            lblServiceName.Text =
        service.Description
        Else
            lblServiceName.Text =
        "Service #" & item.ServiceID
        End If

        Dim lblPrice As New Label()

        lblPrice.AutoSize = True
        lblPrice.Location = New Point(130, 10)
        lblPrice.Text =
        "Unit Price: " & item.UnitPrice.ToString("C2")

        Dim lblSubtotal As New Label()

        lblSubtotal.AutoSize = True
        lblSubtotal.Location = New Point(260, 10)
        lblSubtotal.Text =
        "Subtotal: " & item.Subtotal.ToString("C2")

        Dim lblQuantity As New Label()

        lblQuantity.AutoSize = True
        lblQuantity.Location = New Point(10, 45)
        lblQuantity.Text = "Quantity:"

        Dim nudItemQuantity As New NumericUpDown()

        nudItemQuantity.Location = New Point(80, 42)
        nudItemQuantity.Width = 65
        nudItemQuantity.Minimum = 1
        nudItemQuantity.Maximum = 1000
        nudItemQuantity.Value = item.Quantity

        Dim btnUpdateItem As New Button()

        btnUpdateItem.Text = "Update"
        btnUpdateItem.Width = 75
        btnUpdateItem.Height = 25
        btnUpdateItem.Location = New Point(160, 40)
        btnUpdateItem.Tag = item.ReservationServiceID

        AddHandler btnUpdateItem.Click,
        Sub(sender As Object, e As EventArgs)

            Dim button As Button =
                DirectCast(sender, Button)

            UpdateReservationServiceQuantity(
                CInt(button.Tag),
                CInt(nudItemQuantity.Value))

        End Sub

        Dim btnRemoveItem As New Button()

        btnRemoveItem.Text = "Remove"
        btnRemoveItem.Width = 75
        btnRemoveItem.Height = 25
        btnRemoveItem.Location = New Point(245, 40)
        btnRemoveItem.Tag = item.ReservationServiceID

        AddHandler btnRemoveItem.Click,
        Sub(sender As Object, e As EventArgs)

            RemoveReservationService(
                CInt(DirectCast(sender, Button).Tag))

        End Sub

        panel.Controls.Add(lblServiceName)
        panel.Controls.Add(lblPrice)
        panel.Controls.Add(lblSubtotal)
        panel.Controls.Add(lblQuantity)
        panel.Controls.Add(nudItemQuantity)
        panel.Controls.Add(btnUpdateItem)
        panel.Controls.Add(btnRemoveItem)

        flpReservationServices.Controls.Add(panel)

    End Sub



    Private Sub UpdateReservationServiceQuantity(
    reservationServiceId As Integer,
    quantity As Integer
)

        Try

            _reservationServiceItemService.UpdateQuantity(
            reservationServiceId,
            quantity)

            MessageBox.Show(
            "Service quantity updated successfully.",
            "Reservation Services",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

            LoadReservationServices()

        Catch ex As Exception

            MessageBox.Show(
            ex.Message,
            "Reservation Services",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub



    Private Sub btnAdd_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAdd.Click

        If cmbService.SelectedItem Is Nothing Then

            MessageBox.Show(
                "Please select a service.",
                "Reservation Services",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return

        End If

        Dim service As Service =
            DirectCast(cmbService.SelectedItem, Service)

        Dim quantity As Integer =
            CInt(nudQuantity.Value)

        Try

            _reservationServiceItemService.AddService(
                _reservationId,
                service.ServiceID,
                quantity)

            MessageBox.Show(
                "Service added to the reservation.",
                "Reservation Services",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            ClearSelection()
            LoadReservationServices()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Reservation Services",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub RemoveReservationService(
        reservationServiceId As Integer
    )

        Dim result As DialogResult =
            MessageBox.Show(
                "Are you sure you want to remove this service?",
                "Remove Service",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            Return
        End If

        Try

            _reservationServiceItemService.RemoveService(
                reservationServiceId)

            LoadReservationServices()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Reservation Services",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnClear_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClear.Click

        ClearSelection()

    End Sub

    Private Sub ClearSelection()

        _selectedReservationServiceId = 0

        If cmbService.Items.Count > 0 Then
            cmbService.SelectedIndex = 0
        Else
            cmbService.SelectedIndex = -1
        End If

        nudQuantity.Value = 1

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

End Class