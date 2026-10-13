Public Class frmLogin
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.UseSystemPasswordChar = True

    End Sub

    Private ReadOnly _authenticationService As New AuthenticationService()

    Private Sub btnLogin_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLogin.Click

        Try

            Dim user As User =
                _authenticationService.Login(
                    txtUsername.Text,
                    txtPassword.Text)

            If user Is Nothing Then

                ShowOops("Invalid username or password.")
                Return

            End If

            AppSession.CurrentUser = user

            Dim mainForm As New frmMain()
            mainForm.Show()

            Me.Close()

        Catch ex As Exception

            ShowOops("Unable to log in: " & ex.Message)

        End Try

    End Sub

    Private Sub btnRegister_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegister.Click

        Dim registerForm As New frmRegister()
        registerForm.Show()

        Me.Close()

    End Sub

    Private Sub ShowOops(message As String)

        Dim oopsForm As New frmOops(message)
        oopsForm.Show()

        Me.Close()

    End Sub

End Class