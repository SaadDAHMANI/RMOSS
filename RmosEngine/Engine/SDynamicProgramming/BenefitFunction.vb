'
' Created by SharpDevelop.
' User: Saad
' Date: 01/11/2015
' Time: 14:28
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Option Strict On
Imports RmosEngine.Components

Namespace SDynamicProgramming
    Public Class BenefitFunction
        Inherits Components.DataSerie2D

        ''' <summary>
        ''' The full file path (path+name).
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Property FileName As String

#Region "Shared fucnctions"

        Public Overloads Shared Function ConvertFrom(ByRef ds2Io As IOOperations.Components.DataSerie2D) As BenefitFunction

            Dim ds2 As BenefitFunction = Nothing
            Try
                If IsNothing(ds2Io) Then Return Nothing
                ds2 = New BenefitFunction()
                With ds2
                    .Name = ds2Io.Name
                    .Description = ds2Io.Description
                    .Title = ds2Io.Title
                    .X_Title = ds2Io.X_Title
                    .Y_Title = ds2Io.Y_Title
                End With
                If IsNothing(ds2Io.Data) = False Then
                    If ds2Io.Data.Count > 0 Then
                        ds2.Data = New List(Of IDataItem2D)
                        For Each itm As IOOperations.Components.DataItem2D In ds2Io.Data
                            ds2.Data.Add(New DataItem2D(itm.Title, itm.X_Value, itm.Y_Value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds2
        End Function
        
        Public Overloads Shared Function ConvertToDs2Io(ByRef ds2 As BenefitFunction) As IOOperations.Components.DataSerie2D
            Dim ds2Io As IOOperations.Components.DataSerie2D = Nothing
            Try
                If IsNothing(ds2) Then Return Nothing
                ds2Io = New IOOperations.Components.DataSerie2D()
                With ds2Io
                    .Name = ds2.Name
                    .Description = ds2.Description
                    .Title = ds2.Title
                    .X_Title = ds2.X_Title
                    .Y_Title = ds2.Y_Title
                End With
                If IsNothing(ds2.Data) = False Then
                    If ds2.Data.Count > 0 Then
                        ds2Io.Data = New List(Of IOOperations.Components.DataItem2D)
                        For Each itm As IDataItem2D In ds2.Data
                            ds2Io.Data.Add(New IOOperations.Components.DataItem2D(itm.Title, itm.X_value, itm.Y_value))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ds2Io
        End Function
        
#End Region
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function

    End Class

End Namespace


