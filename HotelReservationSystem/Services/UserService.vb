Public Class UserService
    Private ReadOnly _userRepository As UserRepository

    Public Sub New()
        _userRepository = New UserRepository()
    End Sub

    Public Function GetCurrentUserProfile() As User

        If Not AppSession.IsLoggedIn Then
            Throw New UnauthorizedAccessException(
                "You must be logged in to view your profile.")
        End If

        Dim user As User =
            _userRepository.GetById(AppSession.CurrentUser.UserID)

        If user Is Nothing OrElse Not user.IsActive Then
            AppSession.Clear()

            Throw New UnauthorizedAccessException(
                "Your account could not be found or is inactive.")
        End If

        Return user
    End Function

    Public Sub UpdateCurrentUserProfile(
        firstName As String,
        middleName As String,
        surname As String,
        contactNumber As String,
        address As String
    )

        If Not AppSession.IsLoggedIn Then
            Throw New UnauthorizedAccessException(
                "You must be logged in to update your profile.")
        End If

        If String.IsNullOrWhiteSpace(firstName) Then
            Throw New ArgumentException("First name is required.")
        End If

        If String.IsNullOrWhiteSpace(surname) Then
            Throw New ArgumentException("Surname is required.")
        End If

        Dim userId As Integer = AppSession.CurrentUser.UserID

        Dim user As User = _userRepository.GetById(userId)

        If user Is Nothing OrElse Not user.IsActive Then
            AppSession.Clear()

            Throw New UnauthorizedAccessException(
                "Your account could not be found or is inactive.")
        End If

        user.FirstName = firstName.Trim()
        user.MiddleName = If(
            String.IsNullOrWhiteSpace(middleName),
            Nothing,
            middleName.Trim())
        user.Surname = surname.Trim()
        user.ContactNumber = If(
            String.IsNullOrWhiteSpace(contactNumber),
            Nothing,
            contactNumber.Trim())
        user.Address = If(
            String.IsNullOrWhiteSpace(address),
            Nothing,
            address.Trim())

        If Not _userRepository.UpdateProfile(user) Then
            Throw New InvalidOperationException(
                "The profile could not be updated. Please try again.")
        End If

        ' Refresh the logged-in user so the application
        ' immediately uses the latest profile information.
        Dim updatedUser As User =
            _userRepository.GetById(userId)

        If updatedUser Is Nothing OrElse Not updatedUser.IsActive Then
            AppSession.Clear()

            Throw New UnauthorizedAccessException(
                "Your account is no longer available.")
        End If

        AppSession.CurrentUser = updatedUser
    End Sub

    Public Sub UpdateCurrentUserProfileImage(imagePath As String)
        If Not AppSession.IsLoggedIn OrElse
           AppSession.CurrentUser Is Nothing Then

            Throw New UnauthorizedAccessException(
                "You must be logged in to update your profile picture.")
        End If

        If String.IsNullOrWhiteSpace(imagePath) Then
            Throw New ArgumentException(
                "A profile picture path is required.")
        End If

        Dim userId As Integer = AppSession.CurrentUser.UserID

        Dim updated As Boolean =
            _userRepository.UpdateProfileImagePath(userId, imagePath)

        If Not updated Then
            Throw New InvalidOperationException(
                "The profile picture could not be saved.")
        End If

        Dim refreshedUser As User = _userRepository.GetById(userId)

        If refreshedUser Is Nothing OrElse Not refreshedUser.IsActive Then
            AppSession.Clear()

            Throw New UnauthorizedAccessException(
                "Your account is no longer available. Please log in again.")
        End If

        AppSession.CurrentUser = refreshedUser

    End Sub
End Class
