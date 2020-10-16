'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:01
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports System.ComponentModel
Namespace Components
    Public Interface IDataSerie1D

        Inherits IDataSerieBase
        Property Data As List(Of IDataItem1D)
        Property X_Title As String
        Sub Add(ByVal title As String, ByVal x As Double)

    End Interface

End Namespace
