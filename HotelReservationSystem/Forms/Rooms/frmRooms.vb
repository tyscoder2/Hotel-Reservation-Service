Imports System.IO
Imports System.Drawing

Public Class frmRooms

    Private ReadOnly _roomService As New RoomService()

    Private ReadOnly _defaultRoomImagePath As String =
        Path.Combine(
            Application.StartupPath,
            "Resources",
            "Images",
            "default-room.png")

    Private Sub frmRooms_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        LoadRooms()

    End Sub

    Private Sub LoadRooms()

        ' Dispose the previous cards and their images.
        For Each control As Control In flpRooms.Controls
            DisposeRoomCardImages(control)
            control.Dispose()
        Next

        flpRooms.Controls.Clear()

        Dim rooms As List(Of Room) = _roomService.GetRooms()

        For Each room As Room In rooms

            Dim roomPanel As New Panel With {
                .Width = 270,
                .Height = 270,
                .BorderStyle = BorderStyle.FixedSingle,
                .Margin = New Padding(10)
            }

            ' Room picture.
            Dim roomPicture As New PictureBox With {
                .Left = 10,
                .Top = 10,
                .Width = 248,
                .Height = 115,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .BorderStyle = BorderStyle.FixedSingle
            }

            roomPicture.Image = LoadRoomImage(room.RoomImagePath)

            roomPanel.Controls.Add(roomPicture)

            ' Room information.
            Dim roomLabel As New Label With {
                .AutoSize = False,
                .Left = 10,
                .Top = 132,
                .Width = 248,
                .Height = 75,
                .Text =
                    "Room " & room.RoomID &
                    Environment.NewLine &
                    "Type: " & room.RoomType &
                    Environment.NewLine &
                    "Rate: " & room.Rate.ToString("C2") &
                    Environment.NewLine &
                    "Status: " & room.Status
            }

            roomPanel.Controls.Add(roomLabel)

            ' View button.
            Dim viewButton As New Button With {
                .Text = "View",
                .Width = 105,
                .Height = 35,
                .Left = 15,
                .Top = 215,
                .Tag = room.RoomID
            }

            AddHandler viewButton.Click,
                Sub(sender, e)

                    Dim roomId As Integer =
                        CInt(DirectCast(sender, Button).Tag)

                    OpenRoom(roomId)

                End Sub

            roomPanel.Controls.Add(viewButton)

            ' Reserve button.
            If room.IsActive AndAlso
                (room.Status = "Available" OrElse
                 room.Status = "Occupied") Then

                Dim reserveButton As New Button With {
                    .Text = "Reserve Now!",
                    .Width = 125,
                    .Height = 35,
                    .Left = 130,
                    .Top = 215,
                    .Tag = room.RoomID
                }

                AddHandler reserveButton.Click,
                    Sub(sender, e)

                        Dim roomId As Integer =
                            CInt(DirectCast(sender, Button).Tag)

                        OpenRoomReservation(roomId)

                    End Sub

                roomPanel.Controls.Add(reserveButton)

            End If

            flpRooms.Controls.Add(roomPanel)

        Next

    End Sub

    Private Function LoadRoomImage(savedPath As String) As Image

        Dim imagePath As String = _defaultRoomImagePath

        If Not String.IsNullOrWhiteSpace(savedPath) AndAlso
            File.Exists(savedPath) Then

            imagePath = savedPath

        End If

        If Not File.Exists(imagePath) Then
            Return Nothing
        End If

        ' Clone the image so the source file is not locked.
        Using sourceImage As Image = Image.FromFile(imagePath)
            Return New Bitmap(sourceImage)
        End Using

    End Function

    Private Sub DisposeRoomCardImages(control As Control)

        If TypeOf control Is PictureBox Then

            Dim picture As PictureBox = DirectCast(control, PictureBox)

            If picture.Image IsNot Nothing Then
                picture.Image.Dispose()
                picture.Image = Nothing
            End If

        End If

        For Each child As Control In control.Controls
            DisposeRoomCardImages(child)
        Next

    End Sub

    Private Sub OpenRoom(roomId As Integer)

        Using form As New frmRoom(roomId)
            form.ShowDialog()
        End Using

        LoadRooms()

    End Sub

    Private Sub OpenRoomReservation(roomId As Integer)

        If Not AppSession.IsLoggedIn Then

            MessageBox.Show(
                "You must be logged in to make a reservation.",
                "Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return

        End If

        Using form As New frmReservation(roomId)
            form.ShowDialog()
        End Using

        LoadRooms()

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

End Class