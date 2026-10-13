
Public Class frmBrowseServices

    Private ReadOnly _serviceService As New ServiceService()

    Private _services As New List(Of Service)

    Private Sub frmBrowseServices_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        lblTitle.Text = "Available Hotel Services"
        LoadServices()

    End Sub

    Private Sub LoadServices()

        Try
            _services = _serviceService.GetActiveServices()
            DisplayServices(_services)

        Catch ex As Exception
            MessageBox.Show(
                "Unable to load hotel services." &
                Environment.NewLine & ex.Message,
                "Services",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DisplayServices(
        services As List(Of Service)
    )

        flpServices.Controls.Clear()

        If services.Count = 0 Then

            Dim emptyLabel As New Label With {
                .Text = "No active services are available.",
                .AutoSize = True,
                .Padding = New Padding(10)
            }

            flpServices.Controls.Add(emptyLabel)
            Return

        End If

        For Each hotelService As Service In services

            Dim serviceCard As New Panel With {
                .Width = 300,
                .Height = 105,
                .BorderStyle = BorderStyle.FixedSingle,
                .Margin = New Padding(8),
                .Padding = New Padding(10)
            }

            Dim descriptionLabel As New Label With {
                .Text = hotelService.Description,
                .AutoSize = False,
                .Left = 10,
                .Top = 10,
                .Width = 270,
                .Height = 40,
                .Font = New Font(
                    "Segoe UI", 10, FontStyle.Bold)
            }

            Dim priceLabel As New Label With {
                .Text = "Price: " &
                    hotelService.Price.ToString("C2"),
                .AutoSize = True,
                .Left = 10,
                .Top = 60
            }

            serviceCard.Controls.Add(descriptionLabel)
            serviceCard.Controls.Add(priceLabel)

            flpServices.Controls.Add(serviceCard)

        Next

    End Sub

    Private Sub txtSearch_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearch.TextChanged

        Dim searchText As String = txtSearch.Text.Trim()

        Dim filteredServices As List(Of Service) =
            _services.Where(
                Function(s) s.Description.IndexOf(
                    searchText,
                    StringComparison.OrdinalIgnoreCase
                ) >= 0
            ).ToList()

        DisplayServices(filteredServices)

    End Sub

    Private Sub btnRefresh_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRefresh.Click

        LoadServices()

    End Sub

    Private Sub btnClose_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClose.Click

        Me.Close()

    End Sub

End Class
