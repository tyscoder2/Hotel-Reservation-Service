Imports Microsoft.Data.SqlClient

Public Class UserRepository

    Public Function GetByUsername(username As String) As User
        Const sql As String =
            "SELECT UserID, Username, PasswordHash, FirstName, " &
            "Surname, MiddleName, ContactNumber, Address, " &
            "IsAdmin, IsActive, ProfileImagePath " &
            "FROM Users " &
            "WHERE Username COLLATE Latin1_General_100_CS_AS =
      @Username COLLATE Latin1_General_100_CS_AS;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.AddWithValue("@Username", username)

                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        Return MapUser(reader)
                    End If

                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function GetById(userId As Integer) As User

        Const sql As String =
            "SELECT UserID, Username, PasswordHash, FirstName, " &
            "Surname, MiddleName, ContactNumber, Address, " &
            "IsAdmin, IsActive, ProfileImagePath " &
            "FROM Users " &
            "WHERE UserID = @UserID;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.AddWithValue("@UserID", userId)

                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        Return MapUser(reader)
                    End If

                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function UsernameExists(username As String) As Boolean

        Const sql As String =
            "SELECT COUNT(1) FROM Users " &
            "WHERE Username COLLATE Latin1_General_100_CS_AS = " &
            "@Username COLLATE Latin1_General_100_CS_AS;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.AddWithValue("@Username", username)

                connection.Open()

                Return Convert.ToInt32(command.ExecuteScalar()) > 0

            End Using
        End Using
    End Function

    Public Function Create(user As User) As Integer
        Const sql As String =
            "INSERT INTO Users " &
            "(Username, PasswordHash, FirstName, Surname, MiddleName, " &
            "ContactNumber, Address, IsAdmin, IsActive) " &
            "VALUES " &
            "(@Username, @PasswordHash, @FirstName, @Surname, @MiddleName, " &
            "@ContactNumber, @Address, @IsAdmin, @IsActive); " &
            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.AddWithValue("@Username", user.Username)
                command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash)
                command.Parameters.AddWithValue("@FirstName", user.FirstName)
                command.Parameters.AddWithValue("@Surname", user.Surname)

                command.Parameters.AddWithValue(
                    "@MiddleName",
                    If(String.IsNullOrWhiteSpace(user.MiddleName),
                       CType(DBNull.Value, Object),
                       user.MiddleName))

                command.Parameters.AddWithValue(
                    "@ContactNumber",
                    If(String.IsNullOrWhiteSpace(user.ContactNumber),
                       CType(DBNull.Value, Object),
                       user.ContactNumber))

                command.Parameters.AddWithValue(
                    "@Address",
                    If(String.IsNullOrWhiteSpace(user.Address),
                       CType(DBNull.Value, Object),
                       user.Address))

                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin)
                command.Parameters.AddWithValue("@IsActive", user.IsActive)

                connection.Open()

                Return Convert.ToInt32(command.ExecuteScalar())

            End Using
        End Using
    End Function

    Public Function UpdateProfile(user As User) As Boolean

        Const sql As String =
            "UPDATE Users " &
            "SET FirstName = @FirstName, " &
            "    MiddleName = @MiddleName, " &
            "    Surname = @Surname, " &
            "    ContactNumber = @ContactNumber, " &
            "    Address = @Address " &
            "WHERE UserID = @UserID AND IsActive = 1;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.AddWithValue("@UserID", user.UserID)
                command.Parameters.AddWithValue("@FirstName", user.FirstName)
                command.Parameters.AddWithValue("@Surname", user.Surname)

                command.Parameters.AddWithValue(
                    "@MiddleName",
                    If(String.IsNullOrWhiteSpace(user.MiddleName),
                       CType(DBNull.Value, Object),
                       user.MiddleName))

                command.Parameters.AddWithValue(
                    "@ContactNumber",
                    If(String.IsNullOrWhiteSpace(user.ContactNumber),
                       CType(DBNull.Value, Object),
                       user.ContactNumber))

                command.Parameters.AddWithValue(
                    "@Address",
                    If(String.IsNullOrWhiteSpace(user.Address),
                       CType(DBNull.Value, Object),
                       user.Address))

                connection.Open()

                Return command.ExecuteNonQuery() = 1

            End Using
        End Using
    End Function

    Public Function UpdateProfileImagePath(
        userId As Integer,
        imagePath As String
    ) As Boolean

        Const sql As String =
            "UPDATE Users " &
            "SET ProfileImagePath = @ProfileImagePath " &
            "WHERE UserID = @UserID AND IsActive = 1;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@UserID", SqlDbType.Int).Value = userId

                command.Parameters.Add(
                    "@ProfileImagePath", SqlDbType.NVarChar, 500).Value =
                    If(String.IsNullOrWhiteSpace(imagePath),
                       CType(DBNull.Value, Object),
                       imagePath)

                connection.Open()

                Return command.ExecuteNonQuery() = 1

            End Using
        End Using
    End Function

    Private Function MapUser(reader As SqlDataReader) As User
        Return New User With {
            .UserID = Convert.ToInt32(reader("UserID")),
            .Username = reader("Username").ToString(),
            .PasswordHash = reader("PasswordHash").ToString(),
            .FirstName = reader("FirstName").ToString(),
            .Surname = reader("Surname").ToString(),
            .MiddleName = If(
                IsDBNull(reader("MiddleName")),
                Nothing,
                reader("MiddleName").ToString()),
            .ContactNumber = If(
                IsDBNull(reader("ContactNumber")),
                Nothing,
                reader("ContactNumber").ToString()),
            .Address = If(
                IsDBNull(reader("Address")),
                Nothing,
                reader("Address").ToString()),
            .IsAdmin = Convert.ToBoolean(reader("IsAdmin")),
            .IsActive = Convert.ToBoolean(reader("IsActive")),
            .ProfileImagePath = If(
                IsDBNull(reader("ProfileImagePath")),
                Nothing,
                reader("ProfileImagePath").ToString())
        }

    End Function
End Class