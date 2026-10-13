Public Class frmSplash
    Private Sub btnLogin_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLogin.Click

        Dim loginForm As New frmLogin()
        loginForm.Show()

        Me.Close()

    End Sub

    Private Sub btnRegister_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegister.Click

        Dim registerForm As New frmRegister()
        registerForm.Show()

        Me.Close()

    End Sub

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class