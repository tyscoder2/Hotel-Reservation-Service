Public Class frmRegister

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.UseSystemPasswordChar = True

    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged

    End Sub

    Private Sub txtSurname_TextChanged(sender As Object, e As EventArgs) Handles txtSurname.TextChanged

    End Sub

    Private Sub txtMiddleName_TextChanged(sender As Object, e As EventArgs) Handles txtMiddleName.TextChanged

    End Sub

    Private Sub txtContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtContactNumber.TextChanged

    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged

    End Sub

    Private ReadOnly _authenticationService As New AuthenticationService()

    Private Sub btnRegister_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegister.Click

        If Not ValidateFields() Then
            Return
        End If

        Try

            Dim userId As Integer =
                _authenticationService.Register(
                    txtUsername.Text,
                    txtPassword.Text,
                    txtFirstName.Text,
                    txtSurname.Text,
                    txtMiddleName.Text,
                    txtContactNumber.Text,
                    txtAddress.Text)

            Dim successForm As New frmSuccess(
                "Registration successful. " &
                "Your User ID is " & userId & "." &
                Environment.NewLine &
                "Please log in.")

            successForm.Show()
            Me.Close()

        Catch ex As ArgumentException

            ShowOops(ex.Message)

        Catch ex As Exception

            ShowOops(
                "Registration failed: " &
                ex.Message)

        End Try

    End Sub

    Private Function ValidateFields() As Boolean

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ShowOops("Username is required.")
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            ShowOops("Password is required.")
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            ShowOops("First name is required.")
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSurname.Text) Then
            ShowOops("Surname is required.")
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtContactNumber.Text) Then
            ShowOops("Contact number is required.")
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            ShowOops("Address is required.")
            Return False
        End If

        Return True

    End Function

    Private Sub ShowOops(message As String)

        Dim oopsForm As New frmOops(message)
        oopsForm.Show()

        Me.Close()

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmLogin.Show()

        Me.Close()
    End Sub
End Class