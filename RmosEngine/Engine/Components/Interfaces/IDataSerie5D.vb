'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:02
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
	Public Interface IDataSerie5D
        Inherits IDataSerieBase
        Property Data As List(Of IDataItem5D)
        Property A_Title As String
        Property B_Title As String
        Property C_Title As String
        Property D_Title As String
        Property E_Title As String
        Sub Add(ByVal title As String, ByVal aValue As Double, ByVal bValue As Double, ByVal cValue As Double, ByVal dValue As Double, ByVal eValue As Double)
    End Interface
End Namespace


