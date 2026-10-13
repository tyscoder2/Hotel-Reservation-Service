Imports Microsoft.Data.SqlClient

Public Class DbConnection

    Private Shared ReadOnly ConnectionString As String =
        "Server=(localdb)\MSSQLLocalDB;" &
        "Database=HotelReservation;" &
        "Integrated Security=True;" &
        "TrustServerCertificate=True;"

    Public Shared Function CreateConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
End Class
