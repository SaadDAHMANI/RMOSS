'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:25
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.Text
Imports System.ComponentModel

Namespace MarkovChains
    Public Class TPMatrix
        Public Sub New(ByVal dimensionN As Integer)
            If dimensionN > 0 Then
                mDimension = dimensionN - 1
                Dim theMatrix(mDimension, mDimension) As Double
                mMatrix = theMatrix
            End If
        End Sub

        Public Property Name As String
        Public Property From_Serie As String
        Public Property To_Serie As String
        Public Index As Integer = 0I

        Dim mMatrix(,) As Double = Nothing
        Public Property Matrix As Double(,)
            Get
                Return mMatrix
            End Get
            Set(ByVal value As Double(,))
                mMatrix = value
            End Set
        End Property

        Dim mDimension As Integer = 0I
        Public ReadOnly Property Dimension As Integer
            Get
                Return mDimension
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim strb As New StringBuilder
            With strb
                .AppendLine(Me.Name)
                .Append(Me.From_Serie).Append(" To ").AppendLine(Me.To_Serie)
                .Append("Index = ").AppendLine(Index.ToString())
                .AppendLine(" ")
                For i As Integer = 0 To Me.mDimension
                    For j As Integer = 0 To Me.mDimension
                        .Append(mMatrix(i, j)).Append("  ")
                    Next
                    .AppendLine(" ")
                Next
            End With
            Return strb.ToString()
        End Function
    End Class
End Namespace


