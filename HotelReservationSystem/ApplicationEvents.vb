
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(
            sender As Object,
            e As EventArgs
        ) Handles Me.Shutdown

            AppSession.Clear()

        End Sub

        Private Sub MyApplication_Startup(
    sender As Object,
    e As StartupEventArgs
    ) Handles Me.Startup

            Me.ShutdownStyle = ShutdownMode.AfterAllFormsClose

        End Sub

    End Class
End Namespace