Imports System.Data
Imports System.Linq
Public Class frmGuestManagement

    Private ReadOnly _guestService As New GuestService()

    Private Sub frmGuestManagement_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Not AppSession.IsLoggedIn OrElse
           Not AppSession.IsAdmin Then

            MessageBox.Show(
                "You do not have permission to manage guests.",
                "Guest Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Return

        End If

        LoadGuests()

    End Sub

    Private Sub LoadGuests(
        Optional guestId As Integer? = Nothing
    )

        flpGuests.Controls.Clear()

        Try

            Dim guests As DataTable

            If guestId.HasValue Then

                guests =
                    _guestService.GetGuestDetails(
                        guestId.Value)

            Else

                guests =
                    _guestService.GetAllGuestDetails()

            End If

            If guests.Rows.Count = 0 Then

                Dim lblNone As New Label With {
                    .AutoSize = True,
                    .Margin = New Padding(10),
                    .Text = "No guests found."
                }

                flpGuests.Controls.Add(lblNone)
                Return

            End If

            For Each guest As DataRow In guests.Rows
                AddGuestCard(guest)
            Next

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load guests: " & ex.Message,
                "Guest Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub AddGuestCard(
        guest As DataRow
    )

        Dim guestId As Integer =
            Convert.ToInt32(guest("GuestID"))

        Dim panel As New Panel With {
            .Width = 480,
            .Height = 130,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(5)
        }

        Dim lblGuestID As New Label With {
            .AutoSize = True,
            .Location = New Point(10, 10),
            .Text = "Guest ID: " & guestId
        }

        Dim userIdText As String =
            If(
                guest.IsNull("UserID"),
                "Not linked",
                Convert.ToString(guest("UserID")))

        Dim lblUserID As New Label With {
            .AutoSize = True,
            .Location = New Point(180, 10),
            .Text = "User ID: " & userIdText
        }

        Dim firstName As String =
            If(guest.IsNull("FirstName"),
               "",
               Convert.ToString(guest("FirstName")))

        Dim middleName As String =
            If(guest.IsNull("MiddleName"),
               "",
               Convert.ToString(guest("MiddleName")))

        Dim surname As String =
            If(guest.IsNull("Surname"),
               "",
               Convert.ToString(guest("Surname")))

        Dim fullName As String =
            String.Join(
                " ",
                New String() {
                    firstName,
                    middleName,
                    surname
                }.Where(
                    Function(part)
                        Return Not String.IsNullOrWhiteSpace(part)
                    End Function))

        If String.IsNullOrWhiteSpace(fullName) Then
            fullName = "Name unavailable"
        End If

        Dim lblName As New Label With {
            .AutoSize = True,
            .Location = New Point(10, 40),
            .Text = "Name: " & fullName
        }

        Dim username As String =
            If(guest.IsNull("Username"),
               "Not linked",
               Convert.ToString(guest("Username")))

        Dim lblUsername As New Label With {
            .AutoSize = True,
            .Location = New Point(10, 65),
            .Text = "Username: " & username
        }

        Dim attendant As String =
            If(
                guest.IsNull("AssignedAttendant") OrElse
                String.IsNullOrWhiteSpace(
                    Convert.ToString(guest("AssignedAttendant"))),
                "Unassigned",
                Convert.ToString(guest("AssignedAttendant")))

        Dim lblAttendant As New Label With {
            .AutoSize = True,
            .Location = New Point(10, 90),
            .Text = "Assigned Attendant: " & attendant
        }

        panel.Controls.Add(lblGuestID)
        panel.Controls.Add(lblUserID)
        panel.Controls.Add(lblName)
        panel.Controls.Add(lblUsername)
        panel.Controls.Add(lblAttendant)

        flpGuests.Controls.Add(panel)

    End Sub

    Private Sub btnSearch_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearch.Click

        Dim guestId As Integer

        If Not Integer.TryParse(
            txtSearch.Text.Trim(),
            guestId) OrElse guestId <= 0 Then

            MessageBox.Show(
                "Enter a valid positive Guest ID.",
                "Guest Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtSearch.Focus()
            Return

        End If

        LoadGuests(guestId)

    End Sub

    Private Sub btnShowAll_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnShowAll.Click

        txtSearch.Clear()
        LoadGuests()

    End Sub

    Private Sub btnBack_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBack.Click

        Me.Close()

    End Sub

End Class