Imports Microsoft.Data.SqlClient

Public Class ServiceRepository
    Public Function GetAll() As List(Of Service)

        Const sql As String =
            "SELECT ServiceID, Description, Price, IsActive " &
            "FROM Services " &
            "ORDER BY Description;"

        Dim services As New List(Of Service)

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    While reader.Read()
                        services.Add(MapService(reader))
                    End While

                End Using

            End Using

        End Using

        Return services
    End Function

    Public Function GetActive() As List(Of Service)
        Const sql As String =
            "SELECT ServiceID, Description, Price, IsActive " &
            "FROM Services " &
            "WHERE IsActive = 1 " &
            "ORDER BY Description;"

        Dim services As New List(Of Service)

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    While reader.Read()
                        services.Add(MapService(reader))
                    End While

                End Using

            End Using

        End Using

        Return services
    End Function

    Public Function GetById(serviceId As Integer) As Service
        Const sql As String =
            "SELECT ServiceID, Description, Price, IsActive " &
            "FROM Services " &
            "WHERE ServiceID = @ServiceID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ServiceID",
                    SqlDbType.Int
                ).Value = serviceId

                connection.Open()

                Using reader As SqlDataReader =
                    command.ExecuteReader()

                    If reader.Read() Then
                        Return MapService(reader)
                    End If

                End Using

            End Using

        End Using

        Return Nothing
    End Function

    Public Function Create(service As Service) As Integer
        Const sql As String =
            "INSERT INTO Services " &
            "(Description, Price, IsActive) " &
            "VALUES " &
            "(@Description, @Price, @IsActive); " &
            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@Description",
                    SqlDbType.NVarChar,
                    255
                ).Value = service.Description

                Dim priceParameter =
                    command.Parameters.Add(
                        "@Price",
                        SqlDbType.Decimal
                    )

                priceParameter.Precision = 10
                priceParameter.Scale = 2
                priceParameter.Value = service.Price

                command.Parameters.Add(
                    "@IsActive",
                    SqlDbType.Bit
                ).Value = service.IsActive

                connection.Open()

                Return Convert.ToInt32(
                    command.ExecuteScalar()
                )

            End Using

        End Using
    End Function

    Public Sub Update(service As Service)
        Const sql As String =
            "UPDATE Services " &
            "SET Description = @Description, " &
            "Price = @Price, " &
            "IsActive = @IsActive " &
            "WHERE ServiceID = @ServiceID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ServiceID",
                    SqlDbType.Int
                ).Value = service.ServiceID

                command.Parameters.Add(
                    "@Description",
                    SqlDbType.NVarChar,
                    255
                ).Value = service.Description

                Dim priceParameter =
                    command.Parameters.Add(
                        "@Price",
                        SqlDbType.Decimal
                    )

                priceParameter.Precision = 10
                priceParameter.Scale = 2
                priceParameter.Value = service.Price

                command.Parameters.Add(
                    "@IsActive",
                    SqlDbType.Bit
                ).Value = service.IsActive

                connection.Open()
                command.ExecuteNonQuery()

            End Using

        End Using
    End Sub

    Public Sub Delete(serviceId As Integer)
        Const sql As String =
            "DELETE FROM Services " &
            "WHERE ServiceID = @ServiceID;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ServiceID",
                    SqlDbType.Int
                ).Value = serviceId

                connection.Open()
                command.ExecuteNonQuery()

            End Using

        End Using
    End Sub

    Public Function IsUsedInReservations(
        serviceId As Integer
    ) As Boolean

        Const sql As String =
            "SELECT CASE WHEN EXISTS (" &
            "SELECT 1 FROM ReservationServices " &
            "WHERE ServiceID = @ServiceID" &
            ") THEN 1 ELSE 0 END;"

        Using connection As SqlConnection =
            DbConnection.CreateConnection()

            Using command As New SqlCommand(sql, connection)

                command.Parameters.Add(
                    "@ServiceID",
                    SqlDbType.Int
                ).Value = serviceId

                connection.Open()

                Return Convert.ToBoolean(command.ExecuteScalar())

            End Using

        End Using
    End Function

    Private Function MapService(
        reader As SqlDataReader
    ) As Service

        Return New Service With {
            .ServiceID =
                Convert.ToInt32(reader("ServiceID")),
            .Description =
                reader("Description").ToString(),
            .Price =
                Convert.ToDecimal(reader("Price")),
            .IsActive =
                Convert.ToBoolean(reader("IsActive"))
        }

    End Function
End Class