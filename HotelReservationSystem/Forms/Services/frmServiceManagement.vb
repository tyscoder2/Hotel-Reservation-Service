Imports Microsoft.Data.SqlClient

Public Class frmServiceManagement

    Private ReadOnly _serviceService As New ServiceService()

    Private _selectedServiceId As Integer = 0

    Private Sub frmServiceManagement_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            MessageBox.Show(
                "You do not have permission to manage hotel services.",
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return
        End If

        chkActive.Checked = True

        LoadServices()

    End Sub

    Private Sub LoadServices()

        flpServices.Controls.Clear()

        Dim services As List(Of Service) =
            _serviceService.GetServices()

        If services.Count = 0 Then

            Dim emptyLabel As New Label With {
                .AutoSize = True,
                .Text = "No services found.",
                .Margin = New Padding(10)
            }

            flpServices.Controls.Add(emptyLabel)

            Return

        End If

        For Each service As Service In services
            AddServiceCard(service)
        Next

    End Sub

    Private Sub AddServiceCard(
        service As Service
    )

        Dim servicePanel As New Panel With {
            .Width = 320,
            .Height = 160,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(10)
        }

        Dim serviceLabel As New Label With {
            .AutoSize = False,
            .Left = 10,
            .Top = 10,
            .Width = 300,
            .Height = 100
        }

        Dim statusText As String

        If service.IsActive Then
            statusText = "Active"
        Else
            statusText = "Inactive"
        End If

        serviceLabel.Text =
            "Service ID: " &
            service.ServiceID &
            Environment.NewLine &
            "Description: " &
            service.Description &
            Environment.NewLine &
            "Price: " &
            service.Price.ToString("C2") &
            Environment.NewLine &
            "Status: " &
            statusText

        servicePanel.Controls.Add(serviceLabel)

        Dim selectButton As New Button With {
            .Text = "Select",
            .Width = 100,
            .Height = 30,
            .Left = 10,
            .Top = 115,
            .Tag = service.ServiceID
        }

        AddHandler selectButton.Click,
            Sub(sender, e)

                Dim serviceId As Integer =
                    CInt(
                        DirectCast(
                            sender,
                            Button
                        ).Tag
                    )

                SelectService(serviceId)

            End Sub

        servicePanel.Controls.Add(selectButton)

        flpServices.Controls.Add(servicePanel)

    End Sub

    Private Sub SelectService(
        serviceId As Integer
    )

        Dim service As Service =
            _serviceService.GetService(serviceId)

        If service Is Nothing Then

            MessageBox.Show(
                "The selected service could not be found.",
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            LoadServices()
            Return

        End If

        _selectedServiceId = service.ServiceID

        txtDescription.Text = service.Description
        txtPrice.Text = service.Price.ToString("0.00")
        chkActive.Checked = service.IsActive

    End Sub

    Private Sub btnAdd_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAdd.Click

        Dim description As String =
            txtDescription.Text.Trim()

        Dim price As Decimal

        If Not Decimal.TryParse(
            txtPrice.Text.Trim(),
            price) Then

            MessageBox.Show(
                "Please enter a valid service price.",
                "Invalid Price",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtPrice.Focus()
            Return

        End If

        Try

            Dim serviceId As Integer =
                _serviceService.CreateService(
                    description,
                    price)

            MessageBox.Show(
                "Service added successfully." &
                Environment.NewLine &
                "Service ID: " & serviceId,
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            ClearForm()
            LoadServices()

        Catch ex As ArgumentException

            MessageBox.Show(
                ex.Message,
                "Invalid Service",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As Exception

            MessageBox.Show(
                "An unexpected error occurred while adding the service." &
                Environment.NewLine &
                ex.Message,
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnUpdate_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnUpdate.Click

        If _selectedServiceId = 0 Then

            MessageBox.Show(
                "Please select a service to update.",
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return

        End If

        Dim description As String =
            txtDescription.Text.Trim()

        Dim price As Decimal

        If Not Decimal.TryParse(
            txtPrice.Text.Trim(),
            price) Then

            MessageBox.Show(
                "Please enter a valid service price.",
                "Invalid Price",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtPrice.Focus()
            Return

        End If

        Try

            _serviceService.UpdateService(
                _selectedServiceId,
                description,
                price,
                chkActive.Checked)

            MessageBox.Show(
                "Service updated successfully.",
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            ClearForm()
            LoadServices()

        Catch ex As ArgumentException

            MessageBox.Show(
                ex.Message,
                "Invalid Service",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As InvalidOperationException

            MessageBox.Show(
                ex.Message,
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As Exception

            MessageBox.Show(
                "An unexpected error occurred while updating the service." &
                Environment.NewLine &
                ex.Message,
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnDelete_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDelete.Click

        If _selectedServiceId = 0 Then

            MessageBox.Show(
                "Please select a service to delete.",
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return

        End If

        Dim result As DialogResult =
            MessageBox.Show(
                "Are you sure you want to delete this service?",
                "Delete Service",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            Return
        End If

        Try

            _serviceService.DeleteService(
                _selectedServiceId)

            MessageBox.Show(
                "Service deleted successfully.",
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            ClearForm()
            LoadServices()

        Catch ex As SqlException

            MessageBox.Show(
                "This service cannot be deleted because it is already associated with a reservation.",
                "Delete Service",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As InvalidOperationException

            MessageBox.Show(
                ex.Message,
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As Exception

            MessageBox.Show(
                "An unexpected error occurred while deleting the service." &
                Environment.NewLine &
                ex.Message,
                "Service Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnClear_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClear.Click

        ClearForm()

    End Sub

    Private Sub ClearForm()

        _selectedServiceId = 0

        txtDescription.Clear()
        txtPrice.Clear()

        chkActive.Checked = True

        txtDescription.Focus()

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

End Class