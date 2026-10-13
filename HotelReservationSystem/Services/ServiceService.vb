Public Class ServiceService
    Private ReadOnly _serviceRepository As New ServiceRepository()

    Public Function GetServices() As List(Of Service)
        Return _serviceRepository.GetAll()
    End Function

    Public Function GetActiveServices() As List(Of Service)
        Return _serviceRepository.GetActive()
    End Function

    Public Function GetService(
        serviceId As Integer
    ) As Service

        Return _serviceRepository.GetById(serviceId)

    End Function

    Public Function CreateService(
        description As String,
        price As Decimal
    ) As Integer

        EnsureAdmin()
        ValidateService(description, price)

        Dim service As New Service With {
            .Description = description.Trim(),
            .Price = Decimal.Round(price, 2),
            .IsActive = True
        }

        Return _serviceRepository.Create(service)

    End Function

    Public Sub UpdateService(
        serviceId As Integer,
        description As String,
        price As Decimal,
        isActive As Boolean
    )

        EnsureAdmin()
        ValidateService(description, price)

        Dim service As Service =
            _serviceRepository.GetById(serviceId)

        If service Is Nothing Then
            Throw New InvalidOperationException(
                "The selected service could not be found.")
        End If

        service.Description = description.Trim()
        service.Price = Decimal.Round(price, 2)
        service.IsActive = isActive

        _serviceRepository.Update(service)

    End Sub

    Public Sub DeleteService(
        serviceId As Integer
    )

        EnsureAdmin()

        Dim service As Service =
            _serviceRepository.GetById(serviceId)

        If service Is Nothing Then
            Throw New InvalidOperationException(
                "The selected service could not be found.")
        End If

        If _serviceRepository.IsUsedInReservations(serviceId) Then
            Throw New InvalidOperationException(
                "This service has reservation history and cannot be deleted. " &
                "Deactivate it instead.")
        End If

        Try
            _serviceRepository.Delete(serviceId)

        Catch ex As Microsoft.Data.SqlClient.SqlException When ex.Number = 547

            Throw New InvalidOperationException(
                "This service is referenced by another record and cannot be deleted. " &
                "Deactivate it instead.")
        End Try

    End Sub

    Private Sub EnsureAdmin()

        If Not AppSession.IsLoggedIn OrElse Not AppSession.IsAdmin Then
            Throw New UnauthorizedAccessException(
                "Only administrators can manage services.")
        End If

    End Sub

    Private Sub ValidateService(
        description As String,
        price As Decimal
    )

        If String.IsNullOrWhiteSpace(description) Then
            Throw New ArgumentException(
                "Service description is required.")
        End If

        If description.Trim().Length > 255 Then
            Throw New ArgumentException(
                "Service description cannot exceed 255 characters.")
        End If

        If price < 0D Then
            Throw New ArgumentException(
                "Service price cannot be negative.")
        End If

        If price > 99999999.99D Then
            Throw New ArgumentException(
                "Service price exceeds the maximum supported amount.")
        End If

        If price <> Decimal.Round(price, 2) Then
            Throw New ArgumentException(
                "Service price cannot have more than two decimal places.")
        End If

    End Sub
End Class