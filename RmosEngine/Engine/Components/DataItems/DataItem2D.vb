'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:06
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
    Public Class DataItem2D
        Implements IDataItem2D

        Public Sub New()
        End Sub
        Public Sub New(ByVal x As Double, ByVal y As Double)
            mXvalue = x
            mYvalue = y
        End Sub

        Public Sub New(ByVal title As String, ByVal x As Double, ByVal y As Double)
            title = mTitle
            mXvalue = x
            mYvalue = y
        End Sub

        Dim mXvalue As Double = 0.0R
        Public Property X_value As Double Implements IDataItem2D.X_value
            Get
                Return mXvalue
            End Get
            Set(ByVal value As Double)
                mXvalue = value
            End Set
        End Property

        Dim mYvalue As Double = 0.0R
        Public Property Y_value As Double Implements IDataItem2D.Y_value
            Get
                Return mYvalue
            End Get
            Set(ByVal value As Double)
                mYvalue = value
            End Set
        End Property

        Dim mTitle As String = "/"
        Public Property Title As String Implements Components.IDataItem2D.Title
            Get
                Return mTitle
            End Get
            Set(ByVal value As String)
                mTitle = value
            End Set
        End Property
    End Class

End Namespace


