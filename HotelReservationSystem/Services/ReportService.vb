Public Class ReportService
    Private ReadOnly _reservationService As New ReservationService()
    Private ReadOnly _paymentService As New PaymentService()
    Private ReadOnly _roomService As New RoomService()

    Private Sub EnsureAdminAccess()
        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            Throw New UnauthorizedAccessException(
                "Only administrators can access reports.")
        End If
    End Sub

    Public Function GetReservationReport() As List(Of Reservation)
        EnsureAdminAccess()
        Return _reservationService.GetAllReservations()
    End Function

    Public Function GetPaymentReport() As List(Of Payment)
        EnsureAdminAccess()
        Return _paymentService.GetAllPayments()
    End Function

    Public Function GetRoomReport() As List(Of Room)

        EnsureAdminAccess()

        Return _roomService.GetRooms()

    End Function
End Class