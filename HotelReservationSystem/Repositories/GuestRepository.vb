Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class GuestRepository
    Public Function GetById(
        guestId As Integer
    ) As Guest

        Const sql As String =
            "SELECT GuestID, UserID, AssignedAttendant " &
            "FROM Guests " &
            "WHERE GuestID = @GuestID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@GuestID", SqlDbType.Int).Value =
                    guestId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    If reader.Read() Then
                        Return MapGuest(reader)
                    End If

                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function GetByUserId(
        userId As Integer
    ) As Guest

        Const sql As String =
            "SELECT GuestID, UserID, AssignedAttendant " &
            "FROM Guests " &
            "WHERE UserID = @UserID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@UserID", SqlDbType.Int).Value =
                    userId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    If reader.Read() Then
                        Return MapGuest(reader)
                    End If

                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function Create(
        guest As Guest
    ) As Integer

        Const sql As String =
            "INSERT INTO Guests " &
            "(UserID, AssignedAttendant) " &
            "VALUES (@UserID, @AssignedAttendant); " &
            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                If guest.UserID.HasValue Then
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value =
                        guest.UserID.Value
                Else
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value =
                        DBNull.Value
                End If

                If String.IsNullOrWhiteSpace(guest.AssignedAttendant) Then
                    command.Parameters.Add(
                        "@AssignedAttendant",
                        SqlDbType.NVarChar,
                        100).Value = DBNull.Value
                Else
                    command.Parameters.Add(
                        "@AssignedAttendant",
                        SqlDbType.NVarChar,
                        100).Value =
                        guest.AssignedAttendant.Trim()
                End If

                connection.Open()

                Return Convert.ToInt32(
                    command.ExecuteScalar())

            End Using
        End Using
    End Function

    Private Function MapGuest(
        reader As SqlDataReader
    ) As Guest

        Return New Guest With {
            .GuestID =
                Convert.ToInt32(reader("GuestID")),
            .UserID =
                If(
                    IsDBNull(reader("UserID")),
                    CType(Nothing, Integer?),
                    Convert.ToInt32(reader("UserID"))),
            .AssignedAttendant =
                If(
                    IsDBNull(reader("AssignedAttendant")),
                    Nothing,
                    reader("AssignedAttendant").ToString())
        }
    End Function

    Public Function GetAll() As List(Of Guest)

        Dim guests As New List(Of Guest)()

        Const sql As String =
            "SELECT GuestID, UserID, AssignedAttendant " &
            "FROM Guests " &
            "ORDER BY GuestID DESC;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    While reader.Read()
                        guests.Add(MapGuest(reader))
                    End While

                End Using

            End Using

        End Using

        Return guests
    End Function

    Public Function GetGuestDetails(
    guestId As Integer
    ) As DataTable

        Dim table As New DataTable()

        Const sql As String =
            "SELECT " &
            "g.GuestID, g.UserID, g.AssignedAttendant, " &
            "u.Username, u.FirstName, u.MiddleName, u.Surname " &
            "FROM Guests g " &
            "LEFT JOIN Users u ON g.UserID = u.UserID " &
            "WHERE g.GuestID = @GuestID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@GuestID",
                    SqlDbType.Int).Value = guestId

                Using adapter As New SqlDataAdapter(command)
                    adapter.Fill(table)
                End Using

            End Using

        End Using

        Return table

    End Function

    Public Function GetAllGuestDetails() As DataTable

        Dim table As New DataTable()

        Const sql As String =
            "SELECT " &
            "g.GuestID, g.UserID, g.AssignedAttendant, " &
            "u.Username, u.FirstName, u.MiddleName, u.Surname " &
            "FROM Guests g " &
            "LEFT JOIN Users u ON g.UserID = u.UserID " &
            "ORDER BY g.GuestID DESC;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                Using adapter As New SqlDataAdapter(command)
                    adapter.Fill(table)
                End Using

            End Using

        End Using

        Return table

    End Function
End Class