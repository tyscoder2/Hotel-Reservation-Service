Public Class AppSession
    Public Shared Property CurrentUser As User

    Public Shared ReadOnly Property IsLoggedIn As Boolean
        Get
            Return CurrentUser IsNot Nothing
        End Get
    End Property

    Public Shared ReadOnly Property IsAdmin As Boolean
        Get
            Return CurrentUser IsNot Nothing AndAlso
                   CurrentUser.IsAdmin
        End Get
    End Property

    Public Shared Sub Clear()
        CurrentUser = Nothing
    End Sub
End Class
