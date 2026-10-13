Imports System.Linq

Public Class RoomService
    Private ReadOnly _repository As RoomRepository
    Private ReadOnly _reservationRepository As ReservationRepository

    Public Sub New()
        _repository = New RoomRepository()
        _reservationRepository = New ReservationRepository()
    End Sub

    Public Function GetRooms() As List(Of Room)
        Return _repository.GetAll().
            Where(Function(room) room.IsActive).
            ToList()
    End Function

    Public Function GetAvailableRooms() As List(Of Room)
        Return GetRooms().
            Where(Function(room) room.Status = "Available").
            ToList()
    End Function

    Public Function GetRoom(roomId As Integer) As Room
        Return _repository.GetById(roomId)
    End Function

    Public Function CreateRoom(
        roomType As String,
        rate As Decimal
    ) As Integer

        EnsureAdmin()

        ValidateRoom(roomType, rate)

        Dim room As New Room With {
            .RoomType = roomType.Trim(),
            .Rate = rate,
            .Status = "Available",
            .IsActive = True
        }

        Return _repository.Create(room)
    End Function

    Public Function UpdateRoom(room As Room) As Boolean

        EnsureAdmin()

        If room Is Nothing Then
            Throw New ArgumentNullException(NameOf(room))
        End If

        ValidateRoom(room.RoomType, room.Rate)

        Dim existingRoom As Room = _repository.GetById(room.RoomID)

        If existingRoom Is Nothing Then
            Throw New InvalidOperationException(
                "The room could not be found.")
        End If

        ValidateRoomStatusChange(
            room.RoomID,
            room.Status,
            room.IsActive)

        Return _repository.Update(room)
    End Function


    Public Function DeleteRoom(roomId As Integer) As Boolean
        EnsureAdmin()

        Dim existingRoom As Room = _repository.GetById(roomId)

        If existingRoom Is Nothing Then
            Throw New InvalidOperationException(
            "The room could not be found.")
        End If

        Dim reservations As List(Of Reservation) =
        _reservationRepository.GetAll().
        Where(Function(r) r.RoomID = roomId).
        ToList()

        If reservations.Count > 0 Then
            Throw New InvalidOperationException(
            "This room has reservation history and cannot be deleted. " &
            "Deactivate it instead.")
        End If

        ValidateRoomStatusChange(roomId, existingRoom.Status, False)

        Return _repository.Delete(roomId)
    End Function

    Public Function UpdateRoomStatus(
        roomId As Integer,
        status As String
    ) As Boolean

        EnsureAdmin()

        If status <> "Available" AndAlso
           status <> "Occupied" AndAlso
           status <> "Maintenance" Then

            Throw New ArgumentException(
                "The specified room status is invalid.")
        End If

        Dim room As Room = _repository.GetById(roomId)

        If room Is Nothing Then
            Throw New InvalidOperationException(
                "The room could not be found.")
        End If

        ValidateRoomStatusChange(
            roomId,
            status,
            room.IsActive)

        Return _repository.UpdateStatus(roomId, status)
    End Function

    Public Function UpdateRoomImage(
        roomId As Integer,
        imagePath As String
    ) As Boolean

        If Not AppSession.IsLoggedIn OrElse
           AppSession.CurrentUser Is Nothing Then

            Throw New UnauthorizedAccessException(
                "You must be logged in to change room pictures.")
        End If

        If Not AppSession.CurrentUser.IsAdmin Then
            Throw New UnauthorizedAccessException(
                "Only administrators can change room pictures.")
        End If

        If roomId <= 0 Then
            Throw New ArgumentException(
                "A valid room must be selected.")
        End If

        If String.IsNullOrWhiteSpace(imagePath) Then
            Throw New ArgumentException(
                "A room picture path is required.")
        End If

        Dim room As Room = _repository.GetById(roomId)

        If room Is Nothing Then
            Throw New InvalidOperationException(
                "The room could not be found.")
        End If

        Return _repository.UpdateRoomImagePath(roomId, imagePath)
    End Function

    Private Sub ValidateRoomStatusChange(
        roomId As Integer,
        requestedStatus As String,
        requestedActive As Boolean
    )

        Dim reservations As List(Of Reservation) =
            _reservationRepository.GetAll().
            Where(Function(r) r.RoomID = roomId).
            ToList()

        Dim hasCheckedInGuest As Boolean =
            reservations.Any(
                Function(r) r.Status = "Checked In")

        Dim hasUpcomingReservation As Boolean =
            reservations.Any(
                Function(r)
                    Return r.Status = "Pending" OrElse
                           r.Status = "Confirmed"
                End Function)

        If hasCheckedInGuest AndAlso
           (Not requestedActive OrElse
            requestedStatus <> "Occupied") Then

            Throw New InvalidOperationException(
                "This room has a checked-in guest. " &
                "It cannot be deactivated or changed from Occupied.")
        End If

        If requestedStatus = "Maintenance" AndAlso
           (hasCheckedInGuest OrElse hasUpcomingReservation) Then

            Throw New InvalidOperationException(
                "This room has active reservations. " &
                "Resolve those reservations before setting the room to Maintenance.")
        End If

        If Not requestedActive AndAlso
           (hasCheckedInGuest OrElse hasUpcomingReservation) Then

            Throw New InvalidOperationException(
                "This room has active reservations. " &
                "Resolve those reservations before deactivating or deleting it.")
        End If
    End Sub

    Private Sub EnsureAdmin()
        If Not AppSession.IsLoggedIn OrElse Not AppSession.IsAdmin Then
            Throw New UnauthorizedAccessException(
            "Only administrators can manage rooms.")
        End If
    End Sub

    Private Sub ValidateRoom(
        roomType As String,
        rate As Decimal
    )

        If String.IsNullOrWhiteSpace(roomType) Then
            Throw New ArgumentException("Room type is required.")
        End If

        If rate < 0D Then
            Throw New ArgumentException(
                "Room rate cannot be negative.")
        End If

    End Sub
End Class
