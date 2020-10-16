Option Strict On
Imports System.Windows.Forms.DataVisualization.Charting
Imports RmosEngine

Public Class OptimizationForm
    Dim ProgressionValue As Integer = 0I
    Dim Progression As Integer = 0I

    Private OptimizationEngine As OptimizationEngineBase

    Private Sub BtnLuanch_Click(sender As Object, e As EventArgs) Handles BtnLuanch.Click
        Progression = 0
        ProgressionValue = 0
        ProgresBar.Value = 0
        RunOptimisation(CmbSyncMode.SelectedIndex)
    End Sub

    Sub RunOptimisation(optimMode As Integer)

        AddHandler OptimizationEngine.ProcessFinished, AddressOf ComputationFinished
        AddHandler OptimizationEngine.ProgressionChanged, AddressOf ComputationProgress

        With OptimizationEngine
            .TotalTimePeriod = 36
            .Initial_Storage = 117.543
            .Reservoir = TheReservoir
            .InflowSerie = TheReservoir.Inflow
            .Demands = TheReservoir.Downstream
        End With

        If optimMode = 0 Then
            OptimizationEngine.Luanch_Optimisation(OptimizationSyncModeEnum.Synchronous)
        Else
            OptimizationEngine.Luanch_Optimisation(OptimizationSyncModeEnum.Asynchronous)
        End If

    End Sub

    Private Sub ComputationFinished(sender As Object, e As RmosEngine.AsyncOptimEventArgs)
        MsgBox("Computation finished.", MsgBoxStyle.Information, "Computation progression")
        ShowData(OptimizationEngine)
    End Sub

    Private Sub ComputationProgress(sender As Object, e As RmosEngine.AsyncOptimEventArgs)
        Progression += 1
        'ProgressionValue = CInt((Progression * 100) / OptimizationEngine.Max_Iteration)

        'If ProgressionValue >= 100 Then
        '    ProgresBar.Value = 100
        '    ProgressionValue = 100
        'Else
        '    ProgresBar.Value = ProgressionValue
        'End If

        'LabelProgression.Text = String.Format("{0}%", ProgressionValue)
        LabelIterations.Text = String.Format("Iteration : {0} / {1}.", e.ProgressPercentage, OptimizationEngine.Max_Iteration)
    End Sub

    Private Sub OptimizationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbOptimEngine.SelectedIndex = 0
        CmbSyncMode.SelectedIndex = 1
        '----------------------------------------------------
        CmbReservoir.Items.Clear()
        If IsNothing(TheReservoir) = False Then
            CmbReservoir.Items.Add(TheReservoir.Name)
        End If
    End Sub

#Region "Subs/Functions"
    Private Sub ShowData(OptimizationEngine As RmosEngine.OptimizationEngineBase)
        Try
            If IsNothing(OptimizationEngine) = False Then

                ShowDataGraphics(OptimizationEngine.Release, OptimizationEngine.Demands, Chart1)
                ShowDataGraphics(OptimizationEngine.Storage, OptimizationEngine.Min_Storage, OptimizationEngine.Max_Storage, Chart2)

                'If IsNothing(OptimizationEngine.Best_Charts) = False Then
                '    CmbBestCharts.Items.Clear()
                '    For Each serie In OptimizationEngine.Best_Charts
                '        CmbBestCharts.Items.Add(serie.Name)
                '    Next
                'End If

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

    Private Sub ShowDataGraphics(ByRef ds1 As IOOperations.Components.DataSerie1D, minS As Double, maxS As Double, ByRef theChart As Chart)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return
        If IsNothing(theChart) Then Return

        Try
            Dim serie As New Series(ds1.Name)
            Dim serieMin As New Series("Min")
            Dim serieMax As New Series("Max")

            Dim i As Integer = 0
            If ds1.Data.Count > 0 Then
                For Each ditm1 In ds1.Data
                    serie.Points.AddXY(i, ditm1.X_Value)

                    serieMin.Points.AddXY(i, minS)
                    serieMax.Points.AddXY(i, maxS)

                    i += 1
                Next
            End If
            serie.ChartType = SeriesChartType.Line
            serieMin.ChartType = SeriesChartType.Line
            serieMax.ChartType = SeriesChartType.Line

            With theChart
                .Series.Clear()
                .Series.Add(serie)
                .Series.Add(serieMin)
                .Series.Add(serieMax)
            End With


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

    Private Sub CmbOptimEngine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbOptimEngine.SelectedIndexChanged
        Select Case CmbOptimEngine.SelectedIndex
            Case 0
                If IsNothing(GA_Engine) Then GA_Engine = New GeneticAlgorithm.GAEngine()
                OptimizationEngine = GA_Engine
            Case 1
                If IsNothing(GSA_Engine) Then GSA_Engine = New GravitationalSearchAlgorithm.GSAEngine()
                OptimizationEngine = GSA_Engine
            Case 2
                If IsNothing(GWO_Engine) Then GWO_Engine = New GreyWolfOptimizer.GWOEngine()
                OptimizationEngine = GWO_Engine
            Case 3
                If IsNothing(HPSOGWO_Engine) Then HPSOGWO_Engine = New GreyWolfOptimizer.HybridPSOGWOEngine()
                OptimizationEngine = HPSOGWO_Engine
            Case Else
                MsgBox("Select optimization engine please...")
        End Select
        If IsNothing(OptimizationEngine) = False Then
            Me.Text = String.Format("Optimization Engine = [{0}]", OptimizationEngine.Name)
            PropertyGrid1.SelectedObject = OptimizationEngine
        End If
    End Sub

End Class
