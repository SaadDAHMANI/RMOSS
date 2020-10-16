'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:05
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.ComponentModel
Namespace Components
    Public Class DataItem1D
        Implements Components.IDataItem1D

        Public Sub New()
        End Sub
        Public Sub New(ByVal x As Double)
            mX_value = x
        End Sub

        Public Sub New(ByVal title As String, ByVal x As Double)
            title = mTitle
            mX_value = x

        End Sub

        Dim mTitle As String = "/"
        Public Property Title As String Implements IDataItem1D.Title
            Get
                Return mTitle
            End Get
            Set(ByVal value As String)
                mTitle = value
            End Set
        End Property

        Dim mX_value As Double
        Public Property X_value As Double Implements IDataItem1D.X_value
            Get
                Return mX_value
            End Get
            Set(ByVal value As Double)
                mX_value = value
            End Set
        End Property
    End Class
End Namespace

