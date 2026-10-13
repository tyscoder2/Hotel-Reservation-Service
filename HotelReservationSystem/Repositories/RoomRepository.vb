Imports Microsoft.Data.SqlClient

Public Class RoomRepository
    Public Function GetAll() As List(Of Room)

        Const sql As String =
            "SELECT RoomID, RoomType, Rate, Status, IsActive, RoomImagePath " &
            "FROM Rooms " &
            "ORDER BY RoomID;"

        Dim rooms As New List(Of Room)

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()

                    While reader.Read()
                        rooms.Add(MapRoom(reader))
                    End While

                End Using
            End Using
        End Using

        Return rooms
    End Function

    Public Function GetById(roomId As Integer) As Room
        Const sql As String =
            "SELECT RoomID, RoomType, Rate, Status, IsActive, RoomImagePath " &
            "FROM Rooms " &
            "WHERE RoomID = @RoomID;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomId

                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        Return MapRoom(reader)
                    End If

                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function Create(room As Room) As Integer

        Const sql As String =
            "INSERT INTO Rooms " &
            "(RoomType, Rate, Status, IsActive, RoomImagePath) " &
            "VALUES (@RoomType, @Rate, @Status, @IsActive, @RoomImagePath); " &
            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@RoomType", SqlDbType.NVarChar, 20).Value =
                    room.RoomType

                Dim rateParameter =
                    command.Parameters.Add("@Rate", SqlDbType.Decimal)
                rateParameter.Precision = 10
                rateParameter.Scale = 2
                rateParameter.Value = room.Rate

                command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
                    room.Status

                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                    room.IsActive

                command.Parameters.Add(
                    "@RoomImagePath", SqlDbType.NVarChar, 500).Value =
                    If(String.IsNullOrWhiteSpace(room.RoomImagePath),
                       CType(DBNull.Value, Object),
                       room.RoomImagePath)

                connection.Open()

                Return Convert.ToInt32(command.ExecuteScalar())

            End Using
        End Using
    End Function

    Public Function Update(room As Room) As Boolean
        Const sql As String =
            "UPDATE Rooms " &
            "SET RoomType = @RoomType, " &
            "Rate = @Rate, " &
            "Status = @Status, " &
            "IsActive = @IsActive " &
            "WHERE RoomID = @RoomID;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@RoomID", SqlDbType.Int).Value =
                    room.RoomID

                command.Parameters.Add("@RoomType", SqlDbType.NVarChar, 20).Value =
                    room.RoomType

                Dim rateParameter =
                    command.Parameters.Add("@Rate", SqlDbType.Decimal)
                rateParameter.Precision = 10
                rateParameter.Scale = 2
                rateParameter.Value = room.Rate

                command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
                    room.Status

                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                    room.IsActive

                connection.Open()

                Return command.ExecuteNonQuery() > 0

            End Using
        End Using
    End Function

    Public Function UpdateRoomImagePath(
        roomId As Integer,
        imagePath As String
    ) As Boolean

        Const sql As String =
            "UPDATE Rooms " &
            "SET RoomImagePath = @RoomImagePath " &
            "WHERE RoomID = @RoomID;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@RoomID", SqlDbType.Int).Value = roomId

                command.Parameters.Add(
                    "@RoomImagePath", SqlDbType.NVarChar, 500).Value =
                    If(String.IsNullOrWhiteSpace(imagePath),
                       CType(DBNull.Value, Object),
                       imagePath)

                connection.Open()

                Return command.ExecuteNonQuery() = 1

            End Using
        End Using
    End Function

    Public Function Delete(roomId As Integer) As Boolean
        Const sql As String =
            "DELETE FROM Rooms " &
            "WHERE RoomID = @RoomID;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomId

                connection.Open()

                Return command.ExecuteNonQuery() > 0

            End Using
        End Using
    End Function

    Public Function UpdateStatus(
        roomId As Integer,
        status As String
    ) As Boolean

        Const sql As String =
            "UPDATE Rooms " &
            "SET Status = @Status " &
            "WHERE RoomID = @RoomID;"

        Using connection As SqlConnection = DbConnection.CreateConnection()
            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@RoomID", SqlDbType.Int).Value = roomId

                command.Parameters.Add(
                    "@Status", SqlDbType.NVarChar, 20).Value = status

                connection.Open()

                Return command.ExecuteNonQuery() > 0

            End Using
        End Using
    End Function

    Private Function MapRoom(reader As SqlDataReader) As Room
        Return New Room With {
            .RoomID = Convert.ToInt32(reader("RoomID")),
            .RoomType = reader("RoomType").ToString(),
            .Rate = Convert.ToDecimal(reader("Rate")),
            .Status = reader("Status").ToString(),
            .IsActive = Convert.ToBoolean(reader("IsActive")),
            .RoomImagePath = If(
                IsDBNull(reader("RoomImagePath")),
                Nothing,
                reader("RoomImagePath").ToString())
        }

    End Function
End Class