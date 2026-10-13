Imports System.IO
Imports System.Drawing

Public Class frmProfile

    Private ReadOnly _userService As UserService

    Private ReadOnly _defaultProfileImagePath As String =
        Path.Combine(
            Application.StartupPath,
            "Resources",
            "Images",
            "default-profile.png")

    Public Sub New()
        InitializeComponent()
        _userService = New UserService()
    End Sub

    Private Sub frmProfile_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        LoadProfile()

    End Sub

    Private Sub LoadProfile()

        Try
            Dim user As User =
                _userService.GetCurrentUserProfile()

            txtUsername.Text = user.Username
            txtFirstName.Text = user.FirstName
            txtMiddleName.Text = If(user.MiddleName, String.Empty)
            txtSurname.Text = user.Surname
            txtContactNumber.Text =
                If(user.ContactNumber, String.Empty)
            txtAddress.Text = If(user.Address, String.Empty)

            DisplayProfileImage(user.ProfileImagePath)

        Catch ex As UnauthorizedAccessException
            MessageBox.Show(
                ex.Message,
                "Profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(
                "Unable to load your profile. " & ex.Message,
                "Profile Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            Me.Close()
        End Try

    End Sub

    Private Sub DisplayProfileImage(savedPath As String)

        Dim imagePath As String = Nothing

        If Not String.IsNullOrWhiteSpace(savedPath) AndAlso
           File.Exists(savedPath) Then

            imagePath = savedPath

        ElseIf File.Exists(_defaultProfileImagePath) Then

            imagePath = _defaultProfileImagePath

        End If

        Dim newImage As Image = Nothing

        If Not String.IsNullOrWhiteSpace(imagePath) Then
            Try
                Using sourceImage As Image =
                    Image.FromFile(imagePath)

                    newImage = New Bitmap(sourceImage)
                End Using

            Catch ex As Exception
                newImage = Nothing
            End Try
        End If

        Dim oldImage As Image = picProfile.Image
        picProfile.Image = newImage

        If oldImage IsNot Nothing Then
            oldImage.Dispose()
        End If

    End Sub

    Private Sub btnChangePicture_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnChangePicture.Click

        Using dialog As New OpenFileDialog()

            dialog.Title = "Choose a Profile Picture"
            dialog.Filter =
                "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif|" &
                "All Files|*.*"

            dialog.CheckFileExists = True
            dialog.Multiselect = False

            If dialog.ShowDialog() <> DialogResult.OK Then
                Return
            End If

            Dim destinationPath As String = Nothing

            Try
                ' Verify that the selected file is a readable image.
                Using selectedImage As Image =
                    Image.FromFile(dialog.FileName)

                    If selectedImage.Width <= 0 OrElse
                       selectedImage.Height <= 0 Then

                        Throw New ArgumentException(
                            "The selected image is invalid.")
                    End If
                End Using

                Dim imageFolder As String =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "HotelReservationSystem",
                        "Images",
                        "Profiles")

                Directory.CreateDirectory(imageFolder)

                Dim extension As String =
                    Path.GetExtension(dialog.FileName).ToLowerInvariant()

                Dim allowedExtensions As String() = {
                    ".png", ".jpg", ".jpeg", ".bmp", ".gif"
                }

                If Not allowedExtensions.Contains(extension) Then
                    MessageBox.Show(
                        "Please choose a PNG, JPG, JPEG, BMP, or GIF image.",
                        "Unsupported Image",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                    Return
                End If

                destinationPath = Path.Combine(
                    imageFolder,
                    "user_" &
                    _userService.GetCurrentUserProfile().UserID.ToString() &
                    "_" &
                    Guid.NewGuid().ToString("N") &
                    extension)

                ' Copy the image so the original file can be moved or deleted.
                File.Copy(dialog.FileName, destinationPath, False)

                ' Save the managed image path to the database.
                _userService.UpdateCurrentUserProfileImage(
                    destinationPath)

                ' Refresh the displayed picture.
                DisplayProfileImage(destinationPath)

                MessageBox.Show(
                    "Your profile picture has been updated successfully.",
                    "Picture Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            Catch ex As ArgumentException
                DeleteCopiedImage(destinationPath)

                MessageBox.Show(
                    ex.Message,
                    "Invalid Image",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            Catch ex As UnauthorizedAccessException
                DeleteCopiedImage(destinationPath)

                MessageBox.Show(
                    ex.Message,
                    "Profile Access",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            Catch ex As Exception
                DeleteCopiedImage(destinationPath)

                MessageBox.Show(
                    "Unable to update your profile picture. " &
                    ex.Message,
                    "Picture Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End Try

        End Using

    End Sub

    Private Sub DeleteCopiedImage(imagePath As String)

        If String.IsNullOrWhiteSpace(imagePath) Then
            Return
        End If

        Try
            If File.Exists(imagePath) Then
                File.Delete(imagePath)
            End If
        Catch
            ' Ignore cleanup errors.
        End Try

    End Sub

    Private Sub btnSave_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSave.Click

        Try
            _userService.UpdateCurrentUserProfile(
                txtFirstName.Text,
                txtMiddleName.Text,
                txtSurname.Text,
                txtContactNumber.Text,
                txtAddress.Text)

            MessageBox.Show(
                "Your profile has been updated successfully.",
                "Profile Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As ArgumentException
            MessageBox.Show(
                ex.Message,
                "Invalid Profile Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As UnauthorizedAccessException
            MessageBox.Show(
                ex.Message,
                "Profile Access",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(
                "Unable to update your profile. " & ex.Message,
                "Profile Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub frmProfile_FormClosed(
        sender As Object,
        e As FormClosedEventArgs
    ) Handles MyBase.FormClosed

        If picProfile.Image IsNot Nothing Then
            Dim oldImage As Image = picProfile.Image
            picProfile.Image = Nothing
            oldImage.Dispose()
        End If

    End Sub

End Class