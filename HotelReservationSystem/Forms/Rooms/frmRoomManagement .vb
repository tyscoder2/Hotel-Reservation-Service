Imports System.IO
Imports System.Drawing

Public Class frmRoomManagement
    Private ReadOnly _roomService As New RoomService()

    Private _selectedRoomId As Integer = 0

    Private _selectedRoomImagePath As String = Nothing

    Private ReadOnly _defaultRoomImagePath As String =
    Path.Combine(
        Application.StartupPath,
        "Resources",
        "Images",
        "default-room.png")

    Private Sub frmRoomManagement_Load(
       sender As Object,
       e As EventArgs
   ) Handles MyBase.Load

        If Not AppSession.IsAdmin Then

            MessageBox.Show(
                "Administrator access is required.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        cmbRoomType.Items.Clear()
        cmbRoomType.Items.Add("Small")
        cmbRoomType.Items.Add("Medium")
        cmbRoomType.Items.Add("VIP")

        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Available")
        cmbStatus.Items.Add("Occupied")
        cmbStatus.Items.Add("Maintenance")

        chkActive.Checked = True

        LoadRooms()
        DisplayRoomImage(Nothing)

    End Sub

    Private Sub LoadRooms()

        flpRooms.Controls.Clear()

        Dim rooms As List(Of Room) =
        _roomService.GetRooms()

        For Each room As Room In rooms

            Dim panel As New Panel With {
            .Width = 250,
            .Height = 170,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(8)
        }

            Dim label As New Label With {
            .AutoSize = False,
            .Dock = DockStyle.Top,
            .Height = 110,
            .Padding = New Padding(10),
            .Text =
                "Room ID: " & room.RoomID &
                Environment.NewLine &
                "Type: " & room.RoomType &
                Environment.NewLine &
                "Rate: " & room.Rate.ToString("C2") &
                Environment.NewLine &
                "Status: " & room.Status &
                Environment.NewLine &
                "Active: " & If(room.IsActive, "Yes", "No")
        }

            panel.Controls.Add(label)

            Dim editButton As New Button With {
            .Text = "Edit",
            .Width = 90,
            .Height = 30,
            .Left = 20,
            .Top = 120,
            .Tag = room.RoomID
        }

            AddHandler editButton.Click,
            Sub(sender, e)

                Dim roomId As Integer =
                    CInt(DirectCast(sender, Button).Tag)

                LoadRoom(roomId)

            End Sub

            panel.Controls.Add(editButton)

            flpRooms.Controls.Add(panel)

        Next

    End Sub

    Private Sub LoadRoom(roomId As Integer)

        Dim room As Room =
        _roomService.GetRoom(roomId)

        If room Is Nothing Then
            MessageBox.Show("Room not found.")
            Return
        End If

        _selectedRoomId = room.RoomID

        cmbRoomType.SelectedItem = room.RoomType
        txtRate.Text = room.Rate.ToString("0.00")
        cmbStatus.SelectedItem = room.Status
        chkActive.Checked = room.IsActive

        _selectedRoomImagePath = room.RoomImagePath
        DisplayRoomImage(_selectedRoomImagePath)

    End Sub

    Private Sub btnAdd_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAdd.Click

        Try

            Dim rate As Decimal

            If Not Decimal.TryParse(txtRate.Text, rate) Then
                MessageBox.Show("Enter a valid room rate.")
                Return
            End If

            Dim roomId As Integer =
                _roomService.CreateRoom(
                    cmbRoomType.Text,
                    rate)

            MessageBox.Show(
                "Room " & roomId & " created successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            ClearFields()
            LoadRooms()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnUpdate_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnUpdate.Click

        If _selectedRoomId = 0 Then
            MessageBox.Show("Select a room to update.")
            Return
        End If

        Try

            Dim rate As Decimal

            If Not Decimal.TryParse(txtRate.Text, rate) Then
                MessageBox.Show("Enter a valid room rate.")
                Return
            End If

            Dim room As New Room With {
                .RoomID = _selectedRoomId,
                .RoomType = cmbRoomType.Text,
                .Rate = rate,
                .Status = cmbStatus.Text,
                .IsActive = chkActive.Checked
            }

            If _roomService.UpdateRoom(room) Then

                MessageBox.Show(
                    "Room updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                ClearFields()
                LoadRooms()

            End If

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnDelete_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDelete.Click

        If _selectedRoomId = 0 Then
            MessageBox.Show("Select a room first.")
            Return
        End If

        Dim result As DialogResult =
            MessageBox.Show(
                "Delete this room?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

        If result <> DialogResult.Yes Then
            Return
        End If

        Try

            If _roomService.DeleteRoom(_selectedRoomId) Then

                MessageBox.Show(
                    "Room deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                ClearFields()
                LoadRooms()

            End If

        Catch ex As Exception

            MessageBox.Show(
                "The room could not be deleted. " &
                "It may already be associated with a reservation." &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Delete Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnClear_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClear.Click

        ClearFields()

    End Sub

    Private Sub ClearFields()

        _selectedRoomId = 0

        cmbRoomType.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1
        txtRate.Clear()
        chkActive.Checked = True

        _selectedRoomImagePath = Nothing
        DisplayRoomImage(Nothing)

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

    Private Sub chkActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkActive.CheckedChanged

    End Sub

    Private Sub DisplayRoomImage(savedPath As String)

        Dim imagePath As String = Nothing

        If Not String.IsNullOrWhiteSpace(savedPath) AndAlso
           File.Exists(savedPath) Then

            imagePath = savedPath

        ElseIf File.Exists(_defaultRoomImagePath) Then

            imagePath = _defaultRoomImagePath

        End If

        Dim newImage As Image = Nothing

        If Not String.IsNullOrWhiteSpace(imagePath) Then
            Try
                Using sourceImage As Image = Image.FromFile(imagePath)
                    newImage = New Bitmap(sourceImage)
                End Using
            Catch
                newImage = Nothing
            End Try
        End If

        Dim oldImage As Image = picRoomPreview.Image
        picRoomPreview.Image = newImage

        If oldImage IsNot Nothing Then
            oldImage.Dispose()
        End If

    End Sub


    Private Sub btnChangePicture_Click(
    sender As Object,
    e As EventArgs
) Handles btnChangePicture.Click

        If Not AppSession.IsAdmin Then
            MessageBox.Show(
                "Administrator access is required.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        If _selectedRoomId <= 0 Then
            MessageBox.Show(
                "Select a room before changing its picture.",
                "No Room Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Using dialog As New OpenFileDialog()

            dialog.Title = "Choose a Room Picture"
            dialog.Filter =
                "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif"
            dialog.CheckFileExists = True
            dialog.Multiselect = False

            If dialog.ShowDialog() <> DialogResult.OK Then
                Return
            End If

            Dim destinationPath As String = Nothing
            Dim databaseUpdated As Boolean = False

            Try
                Dim extension As String =
                    Path.GetExtension(dialog.FileName).ToLowerInvariant()

                Select Case extension
                    Case ".png", ".jpg", ".jpeg", ".bmp", ".gif"
                        ' Supported extension.
                    Case Else
                        Throw New ArgumentException(
                            "Choose a PNG, JPG, JPEG, BMP, or GIF image.")
                End Select

                ' Validate that the selected file is a readable image.
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
                        "Rooms")

                Directory.CreateDirectory(imageFolder)

                destinationPath = Path.Combine(
                    imageFolder,
                    "room_" &
                    _selectedRoomId.ToString() &
                    "_" &
                    Guid.NewGuid().ToString("N") &
                    extension)

                File.Copy(dialog.FileName, destinationPath, False)

                If Not _roomService.UpdateRoomImage(
                    _selectedRoomId,
                    destinationPath) Then

                    Throw New InvalidOperationException(
                        "The room picture could not be saved.")
                End If

                databaseUpdated = True
                _selectedRoomImagePath = destinationPath

                DisplayRoomImage(_selectedRoomImagePath)

                MessageBox.Show(
                    "The room picture has been updated successfully.",
                    "Picture Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                LoadRooms()

            Catch ex As UnauthorizedAccessException
                If Not databaseUpdated Then
                    DeleteCopiedImage(destinationPath)
                End If

                MessageBox.Show(
                    ex.Message,
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            Catch ex As ArgumentException
                If Not databaseUpdated Then
                    DeleteCopiedImage(destinationPath)
                End If

                MessageBox.Show(
                    ex.Message,
                    "Invalid Image",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            Catch ex As Exception
                If Not databaseUpdated Then
                    DeleteCopiedImage(destinationPath)
                End If

                MessageBox.Show(
                    "Unable to update the room picture. " & ex.Message,
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

    Private Sub frmRoomManagement_FormClosed(
    sender As Object,
    e As FormClosedEventArgs
) Handles MyBase.FormClosed

        If picRoomPreview.Image IsNot Nothing Then
            Dim oldImage As Image = picRoomPreview.Image
            picRoomPreview.Image = Nothing
            oldImage.Dispose()
        End If

    End Sub

    Private Sub lblActive_Click(sender As Object, e As EventArgs) Handles lblActive.Click

    End Sub
End Class