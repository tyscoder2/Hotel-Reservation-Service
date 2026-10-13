Imports Microsoft.Data.SqlClient

Public Class Form1
    Private Sub TestDatabaseConnection()
        Try
            Using connection As SqlConnection =
                DbConnection.CreateConnection()

                connection.Open()

                MessageBox.Show(
                    "Database connection successful.",
                    "Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            End Using

        Catch ex As Exception
            MessageBox.Show(
                "Database connection failed." &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load
        ' Startup is handled by Form1_Shown.
    End Sub

    Private Sub Form1_Shown(
    sender As Object,
    e As EventArgs
) Handles MyBase.Shown

        Dim splash As New frmSplash()
        splash.Show()

        ' Close the startup form after showing the splash.
        Me.Close()

    End Sub

    Private Sub Form1_FormClosed(
        sender As Object,
        e As FormClosedEventArgs
    ) Handles MyBase.FormClosed

        AppSession.Clear()

    End Sub
End Class

'dette er bare forfaerdelig det burde ikke vaere her lol'