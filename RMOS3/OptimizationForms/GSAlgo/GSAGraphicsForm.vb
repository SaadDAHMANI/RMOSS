Imports System.Windows.Forms.DataVisualization.Charting
Public Class GSAGraphicsForm

    Private Sub GSAGraphicsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cursor = Cursors.WaitCursor
        Try
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
            If IsNothing(MainModule.GSA_Engine) = False Then

                ShowDataGraphics(GSA_Engine.Release, GSA_Engine.Demands, Chart1)
                ShowDataGraphics(GSA_Engine.Storage, Chart2)
                ShowDataGraphics(GSA_Engine.OverFlow, Chart3)

                If IsNothing(GSA_Engine.Best_Charts) = False Then
                    CmbBestCharts.Items.Clear()
                    For Each serie In GSA_Engine.Best_Charts
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
            ShowDataGraphics(GSA_Engine.Best_Charts(index), Chart4)
        End If
    End Sub

    Private Sub TsmiSavePNGChart1_Click(sender As Object, e As EventArgs) Handles TsmiSavePNGChart1.Click
        SaveChartAsImage(Chart1, ChartImageFormat.Png)
    End Sub

    Private Sub TsmiSaveBMPChart1_Click(sender As Object, e As EventArgs) Handles TsmiSaveBMPChart1.Click
        SaveChartAsImage(Chart1, ChartImageFormat.Bmp)
    End Sub

    Private Sub TsmiSaveTIFFChart1_Click(sender As Object, e As EventArgs) Handles TsmiSaveTIFFChart1.Click
        SaveChartAsImage(Chart1, ChartImageFormat.Tiff)
    End Sub

End Class