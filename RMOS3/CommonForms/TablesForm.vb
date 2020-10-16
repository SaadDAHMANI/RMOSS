Option Strict On
Imports System.Windows.Forms.DataVisualization.Charting
Imports IOOperations.Components

Public Class TablesForm
    Friend OptimizationEngine As RmosEngine.OptimizationEngineBase
    Private DecimalsData As Integer = 7I
    Private DecimalsPerformance As Integer = 4I

    Private Sub TablesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cursor = Cursors.WaitCursor
        CmbDecimals.SelectedIndex = DecimalsData
        ShowData()
        Cursor = Cursors.Default
    End Sub

    Private Sub CmbFitnessSeies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFitnessSeies.SelectedIndexChanged
        Cursor = Cursors.WaitCursor

        Dim index As Integer = CmbFitnessSeies.SelectedIndex
        If index >= 0 Then
            ShowData(index)
            'ShowDataGraphics(OptimizationEngine.Performance(index), Chart1)
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub ShowDataGraphics(ByRef ds1 As IOOperations.Components.DataSerie1D, ByRef theChart As Chart)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return
        If IsNothing(theChart) Then Return

        Try
            Dim serie As New Series(ds1.Name)
            Dim i As Integer = 0
            If ds1.Data.Count > 0 Then
                For Each ditm1 In ds1.Data
                    serie.Points.AddXY(i, Math.Round(ditm1.X_Value, 2))
                    i += 1
                Next
            End If
            serie.ChartType = SeriesChartType.Line

            theChart.Series.Clear()
            theChart.Series.Add(serie)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub ShowDataGraphics(ByRef ds3 As IOOperations.Components.DataSerie3D, ByRef theChart As Chart)
        If IsNothing(ds3) Then Return
        If IsNothing(ds3.Data) Then Return
        If IsNothing(theChart) Then Return

        Try
            Dim serie1 As New Series(ds3.X_Title)
            Dim serie2 As New Series(ds3.Y_Title)
            Dim serie3 As New Series(ds3.Z_Title)

            Dim i As Integer = 0
            If ds3.Data.Count > 0 Then
                For Each ditm In ds3.Data
                    serie1.Points.AddXY(i, Math.Round(ditm.X_Value, 2))
                    serie2.Points.AddXY(i, Math.Round(ditm.Y_Value, 2))
                    serie3.Points.AddXY(i, Math.Round(ditm.Z_Value, 2))
                    i += 1
                Next
            End If

            serie1.ChartType = SeriesChartType.Line
            serie2.ChartType = SeriesChartType.Line
            serie3.ChartType = SeriesChartType.Line

            With theChart
                .Series.Clear()
                .Series.Add(serie1)
                .Series.Add(serie2)
                .Series.Add(serie3)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub ShowData()
        Try

            Dim iCount As Integer = 0
            Dim monthCounter As Integer = 1
            Dim yearCounter As Integer = 1

            CmbFitnessSeies.Items.Clear()
            If IsNothing(OptimizationEngine) = False Then
                If IsNothing(OptimizationEngine.Best_Charts) = False Then
                    For Each s1 In OptimizationEngine.Best_Charts
                        CmbFitnessSeies.Items.Add(s1.Name)
                        CmbStage.Items.Add(s1.Name)
                    Next
                End If

                If IsNothing(OptimizationEngine.InflowSerie) = False Then
                    iCount = OptimizationEngine.InflowSerie.Count
                    If iCount > 0 Then
                        With DgvResults
                            .Rows.Clear()
                            .Rows.Add(iCount)
                        End With

                        For i = 0 To (iCount - 1)
                            With DgvResults
                                .Item(0, i).Value = (i + 1).ToString()
                                .Item(1, i).Value = String.Format("Y- {0} | {1}", yearCounter, monthCounter)
                                .Item(2, i).Value = Math.Round(OptimizationEngine.InflowSerie.Data(i).X_Value, DecimalsData)
                                .Item(3, i).Value = 0R
                                .Item(4, i).Value = 0R
                                .Item(5, i).Value = 0R
                                .Item(6, i).Value = 0R
                                .Item(7, i).Value = 0R
                                .Item(8, i).Value = 0R
                            End With
                            monthCounter += 1
                            If monthCounter > 12 Then
                                monthCounter = 1
                                yearCounter += 1
                            End If
                        Next

                        If IsNothing(OptimizationEngine.Demands) = False Then
                            iCount = OptimizationEngine.Demands.Count
                            If iCount > 0 Then
                                For i = 0 To (iCount - 1)
                                    DgvResults.Item(3, i).Value = Math.Round(OptimizationEngine.Demands.Data(i).X_Value, DecimalsData)
                                Next
                            End If
                        End If

                        If IsNothing(OptimizationEngine.Release) = False Then
                            iCount = OptimizationEngine.Release.Count
                            If iCount > 0 Then
                                For i = 0 To (iCount - 1)
                                    DgvResults.Item(4, i).Value = Math.Round(OptimizationEngine.Release.Data(i).X_Value, DecimalsData)
                                Next
                            End If
                        End If

                        If IsNothing(OptimizationEngine.Storage) = False Then
                            iCount = OptimizationEngine.Storage.Count
                            If iCount > 0 Then
                                For i = 0 To (iCount - 1)
                                    DgvResults.Item(5, i).Value = Math.Round(OptimizationEngine.Storage.Data(i).X_Value, DecimalsData)
                                Next
                            End If
                        End If

                        If IsNothing(OptimizationEngine.OverFlow) = False Then
                            iCount = OptimizationEngine.OverFlow.Count
                            If iCount > 0 Then
                                For i = 0 To (iCount - 1)
                                    DgvResults.Item(6, i).Value = Math.Round(OptimizationEngine.OverFlow.Data(i).X_Value, DecimalsData)
                                Next
                            End If
                        End If

                        If IsNothing(OptimizationEngine.Evaporation) = False Then
                            iCount = OptimizationEngine.Evaporation.Count
                            If iCount > 0 Then
                                For i = 0 To (iCount - 1)
                                    DgvResults.Item(7, i).Value = Math.Round(OptimizationEngine.Evaporation.Data(i).X_Value, DecimalsData)
                                Next
                            End If
                        End If

                        If IsNothing(OptimizationEngine.Infiltration) = False Then
                            iCount = OptimizationEngine.Infiltration.Count
                            If iCount > 0 Then
                                For i = 0 To (iCount - 1)
                                    DgvResults.Item(8, i).Value = Math.Round(OptimizationEngine.Infiltration.Data(i).X_Value, DecimalsData)
                                Next
                            End If
                        End If
                    Else
                        Return
                    End If
                Else
                    Return
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShowData0(ByVal index As Integer)
        If index < 0 Then Return
        Try
            If IsNothing(OptimizationEngine) = False Then
                If IsNothing(OptimizationEngine.Best_Charts) = False Then
                    With DgvBestFitness
                        .Rows.Clear()
                        .Rows.Add(OptimizationEngine.Best_Charts(index).Data.Count)
                        For i As Integer = 0 To (OptimizationEngine.Best_Charts(index).Data.Count - 1)
                            .Item(0, i).Value = (i + 1).ToString()
                            .Item(1, i).Value = Math.Round(OptimizationEngine.Best_Charts(index).Data(i).X_Value, DecimalsPerformance)
                        Next
                    End With
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShowData(ByVal index As Integer)
        If index < 0 Then Return
        Try
            If IsNothing(OptimizationEngine) = False Then
                If IsNothing(OptimizationEngine.Performance) = False Then
                    With DgvBestFitness
                        .Rows.Clear()
                        .Rows.Add(OptimizationEngine.Performance(index).Data.Count)
                        For i As Integer = 0 To (OptimizationEngine.Performance(index).Data.Count - 1)
                            .Item(0, i).Value = (i + 1).ToString()
                            .Item(1, i).Value = Math.Round(OptimizationEngine.Performance(index).Data(i).X_Value, DecimalsPerformance)
                            .Item(2, i).Value = Math.Round(OptimizationEngine.Performance(index).Data(i).Y_Value, DecimalsPerformance)
                            .Item(3, i).Value = Math.Round(OptimizationEngine.Performance(index).Data(i).Z_Value, DecimalsPerformance)
                        Next
                    End With
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub BtnExportData_Click(sender As Object, e As EventArgs) Handles BtnExportData.Click
        Try

            Dim result As Boolean = False
            Dim iCount As Integer = DgvResults.Rows.Count

            If iCount > 0 Then
                Dim titles As New List(Of String) From {
               "Time (Month)", "Q (Mm3)", "D (Mm3)", "R* (Mm3)",
                "S* (Mm3)", "O (Mm3)", "Evapo. (Mm3)", "Infilt. (Mm3)"
                }
                Dim dItem As DataItemTD
                Dim dSerie As New DataSerieTD() With {.Titles = titles}

                dSerie.Title = String.Format("QRSEI-{0}", OptimizationEngine.Best_Charts(CmbFitnessSeies.SelectedIndex).Title)

                Dim tt As String = ""
                Dim qq, dd, rr, ss, oo, ee, ii As Double

                With DgvResults
                    For i = 0 To (iCount - 1)
                        tt = .Item(1, i).Value.ToString()
                        qq = Double.Parse(.Item(2, i).Value.ToString())
                        dd = Double.Parse(.Item(3, i).Value.ToString())
                        rr = Double.Parse(.Item(4, i).Value.ToString())
                        ss = Double.Parse(.Item(5, i).Value.ToString())
                        oo = Double.Parse(.Item(6, i).Value.ToString())
                        ee = Double.Parse(.Item(7, i).Value.ToString())
                        ii = Double.Parse(.Item(8, i).Value.ToString())

                        dItem = New DataItemTD(tt, qq, dd, rr, ss, oo, ee, ii)
                        dSerie.Data.Add(dItem)
                    Next
                End With

                result = Export_Data(dSerie)

                dItem = Nothing
                dSerie.Data.Clear()
                dSerie.Data = Nothing
                dSerie = Nothing

            End If

            MsgBox(String.Format("Saving data result = {0}", result.ToString()), MsgBoxStyle.Information, "Export Data")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BtnExportFitnessData_Click(sender As Object, e As EventArgs) Handles BtnExportFitnessData.Click
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If

            'Dim fileTitle As String = OptimizationEngine.Best_Charts(CmbFitnessSeies.SelectedIndex).Title                                  ).FileName
            ' Dim fileShortName As String = OptimizationEngine.Best_Charts(CmbFitnessSeies.SelectedIndex).Title
            Dim fileShortName As String = OptimizationEngine.Best_Charts(0).Title
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    .Filter = "CSV files (*.csv)|*.csv"
                    .FileName = String.Format("{0}.csv", fileShortName)
                    .ShowDialog()

                    If IsNothing(.FileName) Then Return
                    If .FileName = String.Empty Then Return

                    fileName = .FileName
                End With
            End Using

            'Saving data to .csv file :

            Dim ioEngine As New IOOperations.CsvFileIO(fileName)
            Dim result As Boolean = False
            With ioEngine
                ' result = .Write(OptimizationEngine.Best_Charts, 0)
                result = .Write(OptimizationEngine.Performance(0))
            End With

            MsgBox(result.ToString(), MsgBoxStyle.Information, "Saving Performance")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CmbDecimals_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDecimals.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        If CmbDecimals.SelectedIndex < 0 Then Return
        DecimalsData = CmbDecimals.SelectedIndex
        ShowData()
        Cursor = Cursors.Default
    End Sub

    Private Sub CmbDecimalsPerformance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDecimalsPerformance.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        If CmbDecimalsPerformance.SelectedIndex < 0 Then Return
        DecimalsPerformance = CmbDecimalsPerformance.SelectedIndex
        ShowData(CmbFitnessSeies.SelectedIndex)
        Cursor = Cursors.Default
    End Sub

    Private Sub TsmiShowSingleGraph_Click(sender As Object, e As EventArgs) Handles TsmiShowSingleGraph.Click
        Try
            Dim graphicsFrm As New SingleGraphicForm With {.GraphicChart = Chart1,
                .MdiParent = MainForm
            }
            graphicsFrm.Text = "Graphics"
            MainForm.Show_Window(CType(graphicsFrm, Form))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class