Imports System.Security.Cryptography
Imports Microsoft.Data.SqlClient

Public Class AuthenticationService
    Private ReadOnly _userRepository As UserRepository

    Public Sub New()
        _userRepository = New UserRepository()
    End Sub

    Public Function Register(
        username As String,
        password As String,
        firstName As String,
        surname As String,
        middleName As String,
        contactNumber As String,
        address As String
    ) As Integer

        If String.IsNullOrWhiteSpace(username) Then
            Throw New ArgumentException("Username is required.")
        End If

        If String.IsNullOrEmpty(password) Then
            Throw New ArgumentException("Password is required.")
        End If

        username = username.Trim()

        If username.Length > 50 Then
            Throw New ArgumentException(
                "Username cannot exceed 50 characters.")
        End If

        If String.IsNullOrWhiteSpace(firstName) Then
            Throw New ArgumentException("First name is required.")
        End If

        If String.IsNullOrWhiteSpace(surname) Then
            Throw New ArgumentException("Surname is required.")
        End If

        If _userRepository.UsernameExists(username) Then
            Throw New ArgumentException(
                "Username already exists. Please choose another username.")
        End If

        Dim user As New User With {
            .Username = username,
            .PasswordHash = HashPassword(password),
            .FirstName = firstName.Trim(),
            .Surname = surname.Trim(),
            .MiddleName = If(
                String.IsNullOrWhiteSpace(middleName),
                Nothing,
                middleName.Trim()),
            .ContactNumber = If(
                String.IsNullOrWhiteSpace(contactNumber),
                Nothing,
                contactNumber.Trim()),
            .Address = If(
                String.IsNullOrWhiteSpace(address),
                Nothing,
                address.Trim()),
            .IsAdmin = False,
            .IsActive = True
        }

        Try
            Return _userRepository.Create(user)

        Catch ex As SqlException When ex.Number = 2601 OrElse ex.Number = 2627

            Throw New ArgumentException(
                "Username already exists. Please choose another username.")
        End Try

    End Function

    Public Function Login(
        username As String,
        password As String
    ) As User

        If String.IsNullOrWhiteSpace(username) Then
            Return Nothing
        End If

        If String.IsNullOrEmpty(password) Then
            Return Nothing
        End If

        Dim user As User =
            _userRepository.GetByUsername(username.Trim())

        If user Is Nothing Then
            Return Nothing
        End If

        If Not user.IsActive Then
            Return Nothing
        End If

        If Not VerifyPassword(password, user.PasswordHash) Then
            Return Nothing
        End If

        Return user
    End Function

    Private Function HashPassword(password As String) As String
        Const saltSize As Integer = 16
        Const hashSize As Integer = 32
        Const iterations As Integer = 100000

        Dim salt(saltSize - 1) As Byte

        Using rng As RandomNumberGenerator =
            RandomNumberGenerator.Create()

            rng.GetBytes(salt)
        End Using

        Using pbkdf2 As New Rfc2898DeriveBytes(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256)

            Dim hash As Byte() = pbkdf2.GetBytes(hashSize)

            Return String.Join(
                ".",
                iterations.ToString(),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash))
        End Using
    End Function

    Private Function VerifyPassword(
        password As String,
        storedHash As String
    ) As Boolean

        If String.IsNullOrEmpty(storedHash) Then
            Return False
        End If

        Try
            Dim parts As String() = storedHash.Split("."c)

            If parts.Length <> 3 Then
                Return False
            End If

            Dim iterations As Integer

            If Not Integer.TryParse(parts(0), iterations) Then
                Return False
            End If

            If iterations < 100000 OrElse iterations > 1000000 Then
                Return False
            End If

            Dim salt As Byte() =
                Convert.FromBase64String(parts(1))

            Dim expectedHash As Byte() =
                Convert.FromBase64String(parts(2))

            If salt.Length <> 16 OrElse expectedHash.Length <> 32 Then
                Return False
            End If

            Using pbkdf2 As New Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256)

                Dim actualHash As Byte() =
                    pbkdf2.GetBytes(expectedHash.Length)

                Return CryptographicOperations.FixedTimeEquals(
                    actualHash,
                    expectedHash)
            End Using

        Catch
            Return False
        End Try

    End Function
End Class