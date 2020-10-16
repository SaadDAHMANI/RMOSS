Imports System.ComponentModel

Public Class Intervalle
    Public Sub New()
    End Sub

    Public Sub New(min As Double, max As Double)
        Min_Value = min
        Max_Value = max
    End Sub

    Public Sub New(name As String, min As Double, max As Double)
        Me.Name = name
        Min_Value = min
        Max_Value = max

    End Sub

    Public Min_Value As Double
    Public Max_Value As Double

    Public Property Name As String = "Intervalle"
End Class

Public Class AsyncOptimEventArgs
    Inherits EventArgs

    Public Sub New()
    End Sub

    Public Sub New(ByVal progresPercentage As Integer)
        Me.ProgressPercentage = progresPercentage
    End Sub

    Public Sub New(progresPercentage As Integer, currentState() As Double)
        Me.ProgressPercentage = progresPercentage
    End Sub

    Public ProgressPercentage As Int32
    Public CurrentSate() As Double

End Class

