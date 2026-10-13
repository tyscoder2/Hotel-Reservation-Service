Public Class GuestService
    Private ReadOnly _guestRepository As New GuestRepository()

    Public Function GetGuest(guestId As Integer) As Guest
        If Not AppSession.IsLoggedIn Then
            Throw New UnauthorizedAccessException(
            "You must be logged in to access guest records.")
        End If

        Dim guest As Guest = _guestRepository.GetById(guestId)

        If guest Is Nothing Then Return Nothing

        If Not AppSession.IsAdmin Then
            Dim ownGuest As Guest =
            _guestRepository.GetByUserId(AppSession.CurrentUser.UserID)

            If ownGuest Is Nothing OrElse ownGuest.GuestID <> guest.GuestID Then
                Throw New UnauthorizedAccessException(
                "You do not have permission to access this guest record.")
            End If
        End If

        Return guest
    End Function

    Public Function GetGuestByUserId(userId As Integer) As Guest
        If Not AppSession.IsLoggedIn Then
            Throw New UnauthorizedAccessException(
            "You must be logged in to access guest records.")
        End If

        If Not AppSession.IsAdmin AndAlso
       userId <> AppSession.CurrentUser.UserID Then
            Throw New UnauthorizedAccessException(
            "You do not have permission to access this guest record.")
        End If

        Return _guestRepository.GetByUserId(userId)
    End Function
    Public Function CreateGuest(
        userId As Integer,
        Optional assignedAttendant As String = Nothing
    ) As Integer


        If Not AppSession.IsLoggedIn Then
            Throw New UnauthorizedAccessException(
        "You must be logged in to create a guest record.")
        End If

        If Not AppSession.IsAdmin AndAlso
   userId <> AppSession.CurrentUser.UserID Then
            Throw New UnauthorizedAccessException(
        "You can only create a guest record for your own account.")
        End If


        Dim guest As New Guest With {
            .UserID = userId,
            .AssignedAttendant = assignedAttendant
        }

        Return _guestRepository.Create(guest)

    End Function

    Public Function GetAllGuests() As List(Of Guest)

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            Throw New UnauthorizedAccessException(
                "Only administrators can view all guests.")

        End If

        Return _guestRepository.GetAll()

    End Function

    Public Function GetAllGuestDetails() As DataTable

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            Throw New UnauthorizedAccessException(
                "Only administrators can view all guest details.")

        End If

        Return _guestRepository.GetAllGuestDetails()

    End Function

    Public Function GetGuestDetails(
        guestId As Integer
    ) As DataTable

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            Throw New UnauthorizedAccessException(
                "Only administrators can view guest details.")

        End If

        Return _guestRepository.GetGuestDetails(guestId)

    End Function
End Class