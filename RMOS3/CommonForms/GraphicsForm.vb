Imports System.Windows.Forms.DataVisualization.Charting

Public Class GraphicsForm
    Friend OptimizationEngine As RmosEngine.OptimizationEngineBase

    Private Sub GAGraphicsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cursor = Cursors.WaitCursor
        Try
            If Equals(OptimizationEngine, Nothing) = False Then
                Me.Text = String.Format("Results : {0}", OptimizationEngine.Name)
            End If
            ShowData()

        Catch ex As Exception
            Throw ex
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#Region "Subs/Functions"
    Private Sub ShowData()
        Try
            If IsNothing(OptimizationEngine) = False Then

                ShowDataGraphics(OptimizationEngine.Release, OptimizationEngine.Demands, Chart1)
                ShowDataGraphics(OptimizationEngine.Storage, Chart2)
                ShowDataGraphics(OptimizationEngine.OverFlow, Chart3)

                If IsNothing(OptimizationEngine.Best_Charts) = False Then
                    CmbBestCharts.Items.Clear()
                    For Each serie In OptimizationEngine.Best_Charts
                        CmbBestCharts.Items.Add(serie.Name)
                    Next

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShowDataGraphics(ByRef ds1 As IOOperations.Components.DataSerie1D, ByRef ds2 As IOOperations.Components.DataSerie1D, ByRef chart As Chart)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return

        If IsNothing(ds2) Then Return
        If IsNothing(ds2.Data) Then Return

        If IsNothing(chart) Then Return

        Try
            Dim serie1 As New Series(ds1.Name)
            Dim serie2 As New Series(ds2.Name)

            Dim i As Integer = 0
            If ds1.Data.Count > 0 Then
                For Each ditm1 In ds1.Data
                    serie1.Points.AddXY(i, ditm1.X_Value)
                    serie2.Points.AddXY(i, ds2.Data(i).X_Value)
                    i += 1
                Next
            End If
            serie1.ChartType = SeriesChartType.Line
            serie2.ChartType = SeriesChartType.Line

            serie2.Color = Color.Crimson

            With chart
                .Series.Clear()
                .Series.Add(serie1)
                .Series.Add(serie2)
            End With

        Catch ex As Exception
            Throw ex
        End Try

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
                    serie.Points.AddXY(i, ditm1.X_Value)
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

    Private Sub SaveChartAsImage(ByRef theChart As Chart, ByRef imgFormat As ChartImageFormat)
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    .Filter = String.Format("Image file (*.{0})|*.{0}", imgFormat.ToString())
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            theChart.SaveImage(fileName, imgFormat)

        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub CmbBestCharts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBestCharts.SelectedIndexChanged
        Dim index As Integer = CmbBestCharts.SelectedIndex
        If index >= 0 Then
            'ShowDataGraphics(OptimizationEngine.Best_Charts(index), Chart4)
            ShowDataGraphics(OptimizationEngine.Performance(index), Chart4)
        End If
    End Sub

    Private Sub TsmiRefreshChart1_Click(sender As Object, e As EventArgs) Handles TsmiRefreshChart1.Click

        Try
            If IsNothing(OptimizationEngine) Then Return
            If IsNothing(OptimizationEngine.Release) Then Return
            If IsNothing(OptimizationEngine.Demands) Then Return

            ShowDataGraphics(OptimizationEngine.Release, OptimizationEngine.Demands, Chart1)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TsmiSaveTIFFChart1_Click(sender As Object, e As EventArgs) Handles TsmiSaveTIFFChart1.Click
        SaveChartAsImage(Chart1, ChartImageFormat.Tiff)
    End Sub

    Private Sub TsmiSavePNGChart1_Click(sender As Object, e As EventArgs) Handles TsmiSavePNGChart1.Click
        SaveChartAsImage(Chart1, ChartImageFormat.Png)
    End Sub

    Private Sub TsmiSaveBMPChart1_Click(sender As Object, e As EventArgs) Handles TsmiSaveBMPChart1.Click
        SaveChartAsImage(Chart1, ChartImageFormat.Bmp)
    End Sub
End Class