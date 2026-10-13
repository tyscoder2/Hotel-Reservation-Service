Public Class frmOops

    Private ReadOnly _message As String

    Public Sub New(message As String)

        InitializeComponent()

        _message = message

    End Sub

    Private Sub frmOops_Load(
    sender As Object,
    e As EventArgs
) Handles MyBase.Load

        lblMessage.Text =
        "Something went wrong: " &
        _message &
        Environment.NewLine &
        "Please try again."

    End Sub

    Private Sub btnProceed_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnProceed.Click

        Dim loginForm As New frmLogin()
        loginForm.Show()

        Me.Close()

    End Sub

End Class