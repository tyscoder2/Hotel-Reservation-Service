Imports System.IO
Imports System.Drawing

Public Class frmRoom

    Private ReadOnly _roomService As New RoomService()
    Private ReadOnly _roomId As Integer

    Private ReadOnly _defaultRoomImagePath As String =
        Path.Combine(
            Application.StartupPath,
            "Resources",
            "Images",
            "default-room.png")

    Public Sub New(roomId As Integer)

        InitializeComponent()
        _roomId = roomId

    End Sub


    Private Sub frmRoom_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        LoadRoom()

    End Sub


    Private Sub LoadRoom()

        Try
            Dim room As Room =
                _roomService.GetRoom(_roomId)

            If room Is Nothing Then
                MessageBox.Show(
                    "Room not found.",
                    "Room",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                Me.Close()
                Return
            End If

            lblRoomID.Text = "Room ID: " & room.RoomID
            lblRoomType.Text = "Type: " & room.RoomType
            lblRate.Text = "Rate: " & room.Rate.ToString("C2")
            lblStatus.Text = "Status: " & room.Status

            btnReserve.Enabled =
                room.Status = "Available"

            DisplayRoomImage(room.RoomImagePath)

        Catch ex As Exception
            MessageBox.Show(
                "Unable to load room details. " & ex.Message,
                "Room Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            Me.Close()
        End Try

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
                Using sourceImage As Image =
                    Image.FromFile(imagePath)

                    newImage = New Bitmap(sourceImage)
                End Using
            Catch
                newImage = Nothing
            End Try
        End If

        Dim oldImage As Image = picRoom.Image
        picRoom.Image = newImage

        If oldImage IsNot Nothing Then
            oldImage.Dispose()
        End If

    End Sub



    Private Sub btnReserve_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnReserve.Click

        If Not AppSession.IsLoggedIn Then

            MessageBox.Show(
                "You must be logged in to make a reservation.",
                "Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return

        End If

        Dim form As New frmReservation(_roomId)

        If form.ShowDialog() = DialogResult.OK Then
            Me.Close()
        End If

    End Sub


    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub


    Private Sub frmRoom_FormClosed(
        sender As Object,
        e As FormClosedEventArgs
    ) Handles MyBase.FormClosed

        If picRoom.Image IsNot Nothing Then
            Dim oldImage As Image = picRoom.Image
            picRoom.Image = Nothing
            oldImage.Dispose()
        End If

    End Sub

End Class