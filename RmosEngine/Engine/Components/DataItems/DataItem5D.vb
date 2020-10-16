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
    Public Class DataItem5D
        Implements Components.IDataItem5D

        Public Sub New()

        End Sub
        Public Sub New(ByVal title As String, ByVal K As Double, ByVal I As Double, ByVal L As Double, ByVal R As Double, ByVal B As Double)
            mTitle = title
            mK_Value = K
            mI_Value = I
            mL_Value = L
            mR_Value = R
            mB_Value = B
        End Sub

        Public Sub New(ByVal K As Double, ByVal I As Double, ByVal L As Double, ByVal R As Double, ByVal B As Double)
            mK_Value = K
            mI_Value = I
            mL_Value = L
            mR_Value = R
            mB_Value = B
        End Sub

        Public Overrides Function ToString() As String
            Return String.Format("k= {0} ; I= {1} ; L= {2} ; R= {3} ; B= {4}.", K_Value, I_Value, L_Value, R_Value, mB_Value)
        End Function

        Dim mK_Value As Double
        ''' <summary>
        ''' Indicate class interval of storage at the beginning of period (t). 
        ''' </summary>
        ''' <remarks></remarks>
        Public Property K_Value As Double Implements IDataItem5D.K_Value
            Get
                Return mK_Value
            End Get
            Set(ByVal value As Double)
                mK_Value = value
            End Set
        End Property

        Dim mI_Value As Double
        ''' <summary>
        ''' Indicate class interval of inflow Q during the period (t).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property I_Value As Double Implements IDataItem5D.I_Value
            Get
                Return mI_Value
            End Get
            Set(ByVal value As Double)
                mI_Value = value
            End Set
        End Property

        Dim mL_Value As Double
        ''' <summary>
        ''' Indicate class interval of storage at the beginning of period (t+1). 
        ''' </summary>
        ''' <remarks></remarks>
        Public Property L_Value As Double Implements IDataItem5D.L_Value
            Get
                Return mL_Value
            End Get
            Set(ByVal value As Double)
                mL_Value = value
            End Set
        End Property

        Dim mR_Value As Double
        ''' <summary>
        ''' Indicate the realease value R. 
        ''' </summary>
        ''' <remarks></remarks>
        Public Property R_Value As Double Implements IDataItem5D.R_Value
            Get
                Return mR_Value
            End Get
            Set(ByVal value As Double)
                mR_Value = value
            End Set
        End Property

        Dim mB_Value As Double
        ''' <summary>
        ''' Indicate the benefice value B.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property B_Value As Double Implements IDataItem5D.B_Value
            Get
                Return mB_Value
            End Get
            Set(ByVal value As Double)
                mB_Value = value
            End Set
        End Property

        Dim mTitle As String = "/"
        Public Property Title As String Implements IDataItem5D.Title
            Get
                Return mTitle
            End Get
            Set(ByVal value As String)
                mTitle = value
            End Set
        End Property
    End Class
End Namespace
