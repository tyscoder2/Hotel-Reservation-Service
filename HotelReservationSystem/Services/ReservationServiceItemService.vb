Imports Microsoft.Data.SqlClient

Public Class ReservationServiceItemService
    Private ReadOnly _repository As New ReservationServiceRepository()
    Private ReadOnly _reservationService As New ReservationService()
    Private ReadOnly _serviceService As New ServiceService()

    Public Function GetReservationServices(
    reservationId As Integer
    ) As List(Of ReservationServiceItem)

        Dim reservation As Reservation =
        _reservationService.GetReservation(reservationId)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation could not be found.")
        End If

        Return _repository.GetByReservation(reservationId)

    End Function

    Public Function GetReservationService(
    reservationServiceId As Integer
    ) As ReservationServiceItem

        Dim item As ReservationServiceItem =
        _repository.GetById(reservationServiceId)

        If item Is Nothing Then
            Return Nothing
        End If

        Dim reservation As Reservation =
        _reservationService.GetReservation(item.ReservationID)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation could not be found.")
        End If

        Return item

    End Function

    Public Function AddService(
        reservationId As Integer,
        serviceId As Integer,
        quantity As Integer
    ) As Integer

        If quantity <= 0 Then
            Throw New ArgumentException(
                "Quantity must be greater than zero.")
        End If

        Dim reservation As Reservation =
            _reservationService.GetReservation(reservationId)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
                "The selected reservation could not be found.")
        End If

        If reservation.Status = "Cancelled" OrElse
        reservation.Status = "Checked Out" Then

            Throw New InvalidOperationException(
        "Services cannot be added to a cancelled or checked-out reservation.")
        End If

        Dim service As Service =
            _serviceService.GetService(serviceId)

        If service Is Nothing Then
            Throw New InvalidOperationException(
                "The selected service could not be found.")
        End If

        If Not service.IsActive Then
            Throw New InvalidOperationException(
                "The selected service is no longer active.")
        End If

        Dim item As New ReservationServiceItem With {
            .ReservationID = reservationId,
            .ServiceID = serviceId,
            .Quantity = quantity,
            .UnitPrice = service.Price
        }

        Try
            Return _repository.CreateAndRecalculate(item)
        Catch ex As SqlException
            If ex.Number = 2601 OrElse ex.Number = 2627 Then
                Throw New InvalidOperationException(
                    "This service has already been added to the reservation.")
            End If

            Throw
        End Try

    End Function

    Public Sub UpdateQuantity(
    reservationServiceId As Integer,
    quantity As Integer
)

        If quantity <= 0 Then
            Throw New ArgumentException(
            "Quantity must be greater than zero.")
        End If

        Dim item As ReservationServiceItem =
        _repository.GetById(reservationServiceId)

        If item Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation service could not be found.")
        End If

        Dim reservation As Reservation =
        _reservationService.GetReservation(item.ReservationID)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation could not be found.")
        End If

        If reservation.Status = "Cancelled" OrElse
       reservation.Status = "Checked Out" Then

            Throw New InvalidOperationException(
            "Services cannot be modified for cancelled or checked-out reservations.")
        End If

        _repository.UpdateQuantity(
        reservationServiceId,
        quantity)
    End Sub

    Public Sub RemoveService(
    reservationServiceId As Integer
)

        Dim item As ReservationServiceItem =
        _repository.GetById(reservationServiceId)

        If item Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation service could not be found.")
        End If

        Dim reservation As Reservation =
        _reservationService.GetReservation(item.ReservationID)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
            "The selected reservation could not be found.")
        End If

        If reservation.Status = "Cancelled" OrElse
        reservation.Status = "Checked Out" Then

            Throw New InvalidOperationException(
        "Services cannot be removed from a cancelled or checked-out reservation.")
        End If

        _repository.DeleteAndRecalculate(
        reservationServiceId)

    End Sub

    Public Function GetTotalServiceAmount(
        reservationId As Integer
    ) As Decimal

        Dim items As List(Of ReservationServiceItem) =
            _repository.GetByReservation(reservationId)

        Dim total As Decimal = 0D

        For Each item As ReservationServiceItem In items
            total += item.Subtotal
        Next

        Return total

    End Function
End Class