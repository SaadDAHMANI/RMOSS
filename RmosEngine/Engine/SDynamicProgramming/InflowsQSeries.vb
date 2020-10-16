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
Imports RmosEngine.MarkovChains


Namespace SDynamicProgramming
    Public Class InflowsQSeries

        ''' <summary>
        ''' The full file path (path+name).
        ''' </summary>
        ''' <remarks></remarks>
        Public FileName As String

        Public ReferenceSerieFileName As String

        Public Property Description As String
        	Dim mQSereies As List(Of InflowQSerie) = Nothing

        Public Property QSereies As List(Of InflowQSerie)
            Get
                Return mQSereies
            End Get
            Set(ByVal value As List(Of InflowQSerie))
                mQSereies = value
                If IsNothing(TpMatrixs) = False Then
                    TpMatrixs.Clear()
                    TpMatrixs = Nothing
                End If
            End Set
        End Property

        Dim mReferenceSerie As DataSerie3D = Nothing
        Public Property ReferenceSerie As DataSerie3D
            Get
                Return mReferenceSerie
            End Get
            Set(ByVal value As DataSerie3D)
                mReferenceSerie = value
                If IsNothing(TpMatrixs) = False Then
                    TpMatrixs.Clear()
                    TpMatrixs = Nothing
                End If
            End Set
        End Property

        Dim TpMatrixs As List(Of TPMatrix) = Nothing
        Public ReadOnly Property TranstionProbMatrixs As List(Of TPMatrix)
            Get
                If IsNothing(TpMatrixs) OrElse TpMatrixs.Count = 0 Then
                    If IsNothing(mReferenceSerie) Then Return Nothing
                    If IsNothing(mReferenceSerie.Data) Then Return Nothing
                    If mReferenceSerie.Data.Count < 1 Then Return Nothing
                    If IsNothing(mQSereies) Then Return Nothing
                    If mQSereies.Count < 1 Then Return Nothing

                    Dim markovAnalyser As New TPMatrixAnalyser(Me.mReferenceSerie)
                    With markovAnalyser
                        .Series = mQSereies
                        .Analyse()
                        TpMatrixs = .Matrixs
                    End With
                End If
                Return TpMatrixs
            End Get
        End Property

        Public Sub Add(ByVal inQSerie As InflowQSerie)
            If IsNothing(mQSereies) Then
                mQSereies = New List(Of InflowQSerie)
                mQSereies.Add(inQSerie)
            Else
                mQSereies.Add(inQSerie)
            End If
        End Sub
        Public Sub Clear()
            If IsNothing(mQSereies) = False Then
                mQSereies.Clear()
            End If
        End Sub

        Public Shared Function ConvertFrom(ByRef ds1List As List(Of DataSerie1D)) As InflowsQSeries
            Dim result As InflowsQSeries = Nothing
            Try
                If IsNothing(ds1List) = False Then
                    If ds1List.Count > 0 Then
                        result = New InflowsQSeries()
                        Dim qSerie As InflowQSerie

                        For Each ds1 In ds1List
                            qSerie = New InflowQSerie()
                            With qSerie
                                .Title = ds1.Name
                                .Q_Title = "Qi"
                                .Qc_Title = "Qci"
                            End With

                            For Each itm In ds1.Data
                                qSerie.Add(itm.X_value, 0)
                            Next
                            result.mQSereies.Add(qSerie)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Public Shared Function ConvertFrom(ByRef ds1List As List(Of IOOperations.Components.DataSerie1D)) As InflowsQSeries
            Dim result As InflowsQSeries = Nothing
            Try
                If IsNothing(ds1List) = False Then
                    result = New InflowsQSeries()
                    If ds1List.Count > 0 Then
                        result.mQSereies = New List(Of InflowQSerie)

                        Dim qSerie As InflowQSerie

                        For Each ds1 In ds1List
                            qSerie = New InflowQSerie()
                            With qSerie
                                .Title = ds1.Name
                                .Description = ds1.Description
                                .Q_Title = "Qi"
                                .Qc_Title = "Qci"
                            End With

                            For Each itm In ds1.Data
                                qSerie.Add(itm.X_Value, 0)
                            Next

                            result.mQSereies.Add(qSerie)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Public Shared Function ConvertTo(ByRef ds1List As InflowsQSeries) As List(Of IOOperations.Components.DataSerie1D)
            Dim result As List(Of IOOperations.Components.DataSerie1D) = Nothing
            Try
                If IsNothing(ds1List) Then Return Nothing
                If IsNothing(ds1List.mQSereies) Then Return Nothing
                If ds1List.mQSereies.Count < 1 Then Return Nothing
                result = New List(Of IOOperations.Components.DataSerie1D)

                For Each ds In ds1List.QSereies
                    If IsNothing(ds.QSerie) = False Then
                        result.Add(InflowQSerie.ConvertToDs1Io(ds))
                    End If
                Next

            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0}", Me.FileName)
        End Function
    End Class
End Namespace


