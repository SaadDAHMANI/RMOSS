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
    Public Class DataItem3D
        Implements IDataItem3D

        Public Sub New()
        End Sub
        Public Sub New(ByVal x As Double, ByVal y As Double, ByVal z As Double)
            mXvalue = x
            mYvalue = y
            mZvalue = z
        End Sub

        Public Sub New(ByVal title As String, ByVal x As Double, ByVal y As Double, ByVal z As Double)
            mTitle = title
            mXvalue = x
            mYvalue = y
            mZvalue = z
        End Sub

        Dim mXvalue As Double = 0.0R
        Public Property X_value As Double Implements IDataItem3D.X_value
            Get
                Return mXvalue
            End Get
            Set(ByVal value As Double)
                mXvalue = value
            End Set
        End Property

        Dim mYvalue As Double = 0.0R
        Public Property Y_value As Double Implements IDataItem3D.Y_value
            Get
                Return mYvalue
            End Get
            Set(ByVal value As Double)
                mYvalue = value
            End Set
        End Property

        Dim mZvalue As Double = 0.0R
        Public Property Z_value As Double Implements IDataItem3D.Z_value
            Get
                Return mZvalue
            End Get
            Set(ByVal value As Double)
                mZvalue = value
            End Set
        End Property

        Dim mTitle As String = "/"
        Public Property Title As String Implements Components.IDataItem3D.Title
            Get
                Return mTitle
            End Get
            Set(ByVal value As String)
                mTitle = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0}: x= {1}, y= {2}, z= {3}.", Me.mTitle, Me.mXvalue, Me.mYvalue, Me.mZvalue)
        End Function

    End Class

End Namespace
