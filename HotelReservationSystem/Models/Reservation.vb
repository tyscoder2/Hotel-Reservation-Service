Public Class Reservation
    Public Property ReservationID As Integer
    Public Property GuestID As Integer
    Public Property RoomID As Integer
    Public Property ReservationDate As Date
    Public Property CheckInDate As Date
    Public Property CheckOutDate As Date
    Public Property Status As String
    Public Property RoomRate As Decimal
    Public Property TotalAmount As Decimal
    Public Property PaidAmount As Decimal
    Public Property Balance As Decimal
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime?
    Public Property GuestName As String
    Public Property RoomType As String
End Class
