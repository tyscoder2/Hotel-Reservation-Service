Imports System.Linq
Public Class ReservationService
    Private ReadOnly _reservationRepository As New ReservationRepository()
    Private ReadOnly _roomService As New RoomService()
    Private ReadOnly _guestService As New GuestService()
    Private ReadOnly _paymentRepository As New PaymentRepository()

    Public Function IsRoomAvailable(
        roomId As Integer,
        checkInDate As Date,
        checkOutDate As Date
    ) As Boolean

        If checkOutDate <= checkInDate Then
            Return False
        End If

        Dim room As Room =
            _roomService.GetRoom(roomId)

        If room Is Nothing Then
            Return False
        End If

        If Not room.IsActive Then
            Return False
        End If

        If room.Status <> "Available" AndAlso
        room.Status <> "Occupied" Then

            Return False

        End If

        Return Not _reservationRepository.HasOverlappingReservation(
            roomId,
            checkInDate,
            checkOutDate)

    End Function
    Public Function CreateReservation(
        roomId As Integer,
        checkInDate As Date,
        checkOutDate As Date
    ) As Integer

        If Not AppSession.IsLoggedIn Then
            Throw New InvalidOperationException(
                "You must be logged in to make a reservation.")
        End If

        If checkOutDate <= checkInDate Then
            Throw New ArgumentException(
                "Check-out date must be after check-in date.")
        End If

        Dim room As Room =
            _roomService.GetRoom(roomId)

        If room Is Nothing Then
            Throw New InvalidOperationException(
                "The selected room could not be found.")
        End If

        If Not room.IsActive Then
            Throw New InvalidOperationException(
                "The selected room is no longer active.")
        End If

        If room.Status <> "Available" AndAlso
        room.Status <> "Occupied" Then

            Throw New InvalidOperationException(
        "The selected room is not available for reservations.")

        End If

        If _reservationRepository.HasOverlappingReservation(
            roomId,
            checkInDate,
            checkOutDate) Then

            Throw New InvalidOperationException(
                "The selected room is already reserved for part of those dates.")

        End If

        Dim guest As Guest =
            _guestService.GetGuestByUserId(
                AppSession.CurrentUser.UserID)

        Dim guestId As Integer

        If guest Is Nothing Then

            guestId =
                _guestService.CreateGuest(
                    AppSession.CurrentUser.UserID)

        Else

            guestId = guest.GuestID

        End If

        Dim nights As Integer =
            CInt((checkOutDate - checkInDate).TotalDays)

        If room.Rate <> Decimal.Round(room.Rate, 2) OrElse
        room.Rate > 99999999.99D Then

            Throw New InvalidOperationException(
        "The room rate is outside the supported amount range.")
        End If

        Dim totalAmount As Decimal = room.Rate * nights

        If totalAmount > 99999999.99D Then
            Throw New InvalidOperationException(
        "The reservation total exceeds the maximum supported amount.")
        End If

        totalAmount = Decimal.Round(totalAmount, 2)

        Dim reservation As New Reservation With {
            .GuestID = guestId,
            .RoomID = room.RoomID,
            .ReservationDate = Date.Today,
            .CheckInDate = checkInDate.Date,
            .CheckOutDate = checkOutDate.Date,
            .Status = "Pending",
            .RoomRate = room.Rate,
            .TotalAmount = totalAmount,
            .PaidAmount = 0D,
            .Balance = totalAmount
        }

        Return _reservationRepository.Create(
            reservation)
    End Function

    Public Function GetReservation(
    reservationId As Integer
    ) As Reservation

        If Not AppSession.IsLoggedIn Then
            Throw New UnauthorizedAccessException(
            "You must be logged in to access reservations.")
        End If

        Dim reservation As Reservation =
        _reservationRepository.GetById(reservationId)

        If reservation Is Nothing Then
            Return Nothing
        End If

        ' Administrators may access any reservation.
        If AppSession.IsAdmin Then
            Return reservation
        End If

        ' Regular users may access only their own reservations.
        Dim guest As Guest =
        _guestService.GetGuestByUserId(
            AppSession.CurrentUser.UserID)

        If guest Is Nothing OrElse
       reservation.GuestID <> guest.GuestID Then

            Throw New UnauthorizedAccessException(
            "You do not have permission to access this reservation.")
        End If

        Return reservation
    End Function
    Public Function GetMyReservations() As List(Of Reservation)

        If Not AppSession.IsLoggedIn Then
            Return New List(Of Reservation)
        End If

        Dim guest As Guest =
            _guestService.GetGuestByUserId(
                AppSession.CurrentUser.UserID)

        If guest Is Nothing Then
            Return New List(Of Reservation)
        End If

        Return _reservationRepository.GetByGuest(
            guest.GuestID)
    End Function

    Public Function GetAllReservations() As List(Of Reservation)

        If Not AppSession.IsLoggedIn OrElse
       Not AppSession.IsAdmin Then

            Throw New UnauthorizedAccessException(
            "Only administrators can view all reservations.")
        End If

        Return _reservationRepository.GetAll()

    End Function

    Public Sub UpdateReservationStatus(
    reservationId As Integer,
    newStatus As String,
    Optional assignedAttendant As String = Nothing
    )

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            Throw New UnauthorizedAccessException(
                "Only administrators can change reservation statuses.")
        End If

        Dim reservation As Reservation =
            _reservationRepository.GetById(reservationId)

        If reservation Is Nothing Then
            Throw New InvalidOperationException(
                "The reservation could not be found.")
        End If

        Select Case newStatus

            Case "Confirmed"

                If reservation.Status <> "Pending" Then
                    Throw New InvalidOperationException(
                        "Only pending reservations can be confirmed.")
                End If

                If String.IsNullOrWhiteSpace(assignedAttendant) Then
                    Throw New ArgumentException(
                        "Please select an attendant before confirming the reservation.")
                End If

                Dim allowedAttendants As String() = {
                    "Jay", "Andrew", "Amy", "Nathan", "Lazaro"
                }

                If Not allowedAttendants.Contains(assignedAttendant) Then
                    Throw New ArgumentException(
                        "Please select a valid attendant.")
                End If

            Case "Checked In"

                If reservation.Status <> "Confirmed" Then
                    Throw New InvalidOperationException(
                        "Only confirmed reservations can be checked in.")
                End If

                If reservation.CheckInDate.Date > Date.Today Then
                    Throw New InvalidOperationException(
                        "The guest cannot check in before the reservation date.")
                End If

                If reservation.CheckOutDate.Date <= Date.Today Then
                    Throw New InvalidOperationException(
                        "This reservation's checkout date has already arrived or passed.")
                End If

            Case "Checked Out"

                If reservation.Status <> "Checked In" Then
                    Throw New InvalidOperationException(
            "Only checked-in reservations can be checked out.")
                End If

                Dim totalPaid As Decimal =
        _paymentRepository.GetTotalPaid(reservationId)

                If totalPaid < reservation.TotalAmount Then
                    Throw New InvalidOperationException(
            "The reservation has an outstanding balance. " &
            "Please complete payment before checking out.")
                End If

            Case "Cancelled"

                If reservation.Status <> "Pending" AndAlso
                   reservation.Status <> "Confirmed" Then

                    Throw New InvalidOperationException(
                        "Only pending or confirmed reservations can be cancelled.")
                End If

            Case Else

                Throw New ArgumentException(
                    "The requested reservation status is invalid.")

        End Select

        If Not _reservationRepository.UpdateStatusAndRoomStatus(
    reservationId,
    reservation.Status,
    newStatus,
    If(newStatus = "Confirmed", assignedAttendant, Nothing)) Then

            Throw New InvalidOperationException(
        "The reservation status could not be updated. " &
        "It may have changed by another operation since you opened it. Refresh and try again.")

        End If

    End Sub
End Class