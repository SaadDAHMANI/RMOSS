Imports RMOS3

Public Interface Interface1
    Property X As Integer
End Interface

Public Interface Interface2
    Property X As Integer

End Interface

Public Class Test
    Implements Interface1
    Implements Interface2

    Public Property X As Integer Implements Interface1.X
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Private Property Interface2_X As Integer Implements Interface2.X
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property
End Class