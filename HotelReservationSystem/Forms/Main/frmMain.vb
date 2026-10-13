Public Class frmMain

    Private Sub frmMain_Load(
    sender As Object,
    e As EventArgs
) Handles MyBase.Load

        ConfigureRole()

    End Sub

    Private Sub ConfigureRole()

        If AppSession.CurrentUser Is Nothing Then
            Return
        End If

        If AppSession.IsAdmin Then

            btnReservations.Text = "Reservations"
            btnRoomManagement.Visible = True
            btnServiceManagement.Visible = True
            btnPaymentManagement.Visible = True
            btnReports.Visible = True
            btnGuestManagement.Visible = True
            btnReservationManagement.Visible = True

            'note: can use AppSession.IsAdmin as bool to simplify

        Else

            btnReservations.Text = "My Reservations"
            btnRoomManagement.Visible = False
            btnServiceManagement.Visible = False
            btnPaymentManagement.Visible = False
            btnReports.Visible = False
            btnGuestManagement.Visible = False
            btnReservationManagement.Visible = False

        End If

    End Sub

    Private Sub btnAbout_Click(
    sender As Object,
    e As EventArgs
) Handles btnAbout.Click

        Dim form As New frmAbout()
        form.ShowDialog()

    End Sub


    Private Sub btnReserve_Click(
    sender As Object,
    e As EventArgs
) Handles btnReserve.Click

        Dim form As New frmRooms()
        form.ShowDialog()

    End Sub



    Private Sub btnServices_Click(
    sender As Object,
    e As EventArgs
) Handles btnServices.Click

        If Not AppSession.IsLoggedIn Then
            MessageBox.Show(
            "Please log in to view available services.",
            "Login Required",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Using form As New frmBrowseServices()
            form.ShowDialog(Me)
        End Using

    End Sub




    Private Sub btnProfile_Click(
    sender As Object,
    e As EventArgs
) Handles btnProfile.Click

        If Not AppSession.IsLoggedIn Then
            MessageBox.Show(
            "Please log in to view your profile.",
            "Login Required",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Using form As New frmProfile()
            form.ShowDialog(Me)
        End Using

    End Sub



    Private Sub btnReservations_Click(
    sender As Object,
    e As EventArgs
) Handles btnReservations.Click

        If Not AppSession.IsLoggedIn Then

            MessageBox.Show(
            "You must be logged in to view reservations.",
            "Reservations",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return

        End If

        Dim form As New frmReservations()

        form.ShowDialog()

    End Sub


    Private Sub btnRoomManagement_Click(
    sender As Object,
    e As EventArgs
) Handles btnRoomManagement.Click

        If Not AppSession.IsAdmin Then
            Return
        End If

        Dim form As New frmRoomManagement()
        form.ShowDialog()

    End Sub


    Private Sub btnServiceManagement_Click(
    sender As Object,
    e As EventArgs
) Handles btnServiceManagement.Click

        If Not AppSession.IsLoggedIn OrElse
       Not AppSession.IsAdmin Then

            MessageBox.Show(
            "You do not have permission to manage hotel services.",
            "Service Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return
        End If

        Dim form As New frmServiceManagement()
        form.ShowDialog()

    End Sub


    Private Sub btnPaymentManagement_Click(
    sender As Object,
    e As EventArgs
) Handles btnPaymentManagement.Click

        If Not AppSession.IsLoggedIn OrElse
       Not AppSession.IsAdmin Then

            MessageBox.Show(
            "You do not have permission to manage payments.",
            "Payment Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return

        End If

        Using form As New frmPaymentManagement()
            form.ShowDialog()
        End Using

    End Sub


    Private Sub btnReports_Click(
    sender As Object,
    e As EventArgs
) Handles btnReports.Click

        If Not AppSession.IsLoggedIn OrElse
       Not AppSession.IsAdmin Then

            MessageBox.Show(
            "You do not have permission to view reports.",
            "Reports",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return

        End If

        Using form As New frmReports()
            form.ShowDialog()
        End Using

    End Sub


    Private Sub btnLogout_Click(
    sender As Object,
    e As EventArgs
) Handles btnLogout.Click

        AppSession.Clear()

        Dim loginForm As New frmLogin()
        loginForm.Show()

        Me.Close()

    End Sub

    Private Sub btnGuestManagement_Click(
    sender As Object,
    e As EventArgs
) Handles btnGuestManagement.Click

        If Not AppSession.IsLoggedIn OrElse
       Not AppSession.IsAdmin Then

            MessageBox.Show(
            "You do not have permission to manage guests.",
            "Guest Management",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return

        End If

        Using form As New frmGuestManagement
            form.ShowDialog()
        End Using

    End Sub


    Private Sub btnReservationManagement_Click(
    sender As Object,
    e As EventArgs
) Handles btnReservationManagement.Click

        If Not AppSession.IsLoggedIn OrElse
       Not AppSession.IsAdmin Then

            MessageBox.Show(
            "Only administrators can access Reservation Management.",
            "Access Denied",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return

        End If

        Using form As New frmReservationManagement()
            form.ShowDialog(Me)
        End Using

    End Sub

End Class