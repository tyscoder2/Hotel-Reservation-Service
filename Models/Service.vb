Public Class Service
    Public Property ServiceID As Integer
    Public Property Description As String
    Public Property Price As Decimal
    Public Property IsActive As Boolean
    Public Overrides Function ToString() As String
        Return Description & " - " & Price.ToString("C2")
    End Function
End Class
