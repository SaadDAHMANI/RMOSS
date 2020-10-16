'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:21
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
    Public Class InflowQItem
        Implements IDataItem2D

        Public Sub New()
        End Sub
        Public Sub New(ByRef title As String, ByVal inflowQ As Double, ByVal qClass As Double)
            Me.mTitle = title
            Me.mInflow_Q = inflowQ
            Me.mQ_Class = qClass
        End Sub

        Dim mTitle As String = "Inflow Q"
        Public Property Title As String Implements IDataItem2D.Title
            Get
                Return mTitle
            End Get
            Set(ByVal value As String)
                mTitle = value
            End Set
        End Property

        Dim mInflow_Q As Double = 0.0R
        Public Property Inflow_Q As Double Implements IDataItem2D.X_Value
            Get
                Return mInflow_Q
            End Get
            Set(ByVal value As Double)
                If value >= 0 Then
                    mInflow_Q = value
                Else
                    mInflow_Q = 0.0R
                End If
            End Set
        End Property

        Dim mQ_Class As Double = 0.0R
        Public Property Q_Class As Double Implements IDataItem2D.Y_Value
            Get
                Return mQ_Class
            End Get
            Set(ByVal value As Double)
                mQ_Class = value
            End Set
        End Property
    End Class
End Namespace

