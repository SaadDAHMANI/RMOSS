Option Strict On
Imports IOOperations
Imports IOOperations.Components
Imports ForecastingEngine.NeuralNetworks

Public Class AnnEoForm
    'All data
    Dim DataSerie As DataSerie1D
    'Private Observed_TrainingInputs As DataSerieTD
    'Private Observed_TrainingOutputs As DataSerie1D
    'Private Computed_TrainingOutputs As DataSerie1D

    'Private Observed_TestingInputs As DataSerieTD
    'Private Observed_TestingOutputs As DataSerie1D
    'Private Computed_TestingOutputs As DataSerie1D

    Private AnnDataFormator As New ForecastingEngine.AnnTimeSeriesFomator()
    Private NeuralNetEO As NeuralNetworksEngineEO
    Private NeuralNetStructure As DataSerie1D

    Private AnnOptimizer As New OptimizedNeuralNetwok()

    Private SequentialForecaster As New ForecastingEngine.SequentialForecasterEO(NeuralNetEO)
    Private ForecastingInputs As DataSerieTD
    Private ForecastingOutputs As DataSerie1D
    '****************************************************************************************

    Private Sub BtnImportInputs_Click(sender As Object, e As EventArgs) Handles BtnImportInputs.Click
        Try
            Dim fileFormat As Integer = CmbInputsFileType.SelectedIndex
            If (fileFormat < 0) OrElse (fileFormat > 6) Then
                MsgBox("Select format of file please..", MsgBoxStyle.Exclamation)
                Return
            End If

            Dim result As Boolean = ImportData(CType(fileFormat, FileFormatEnum), DataSerie)

            If result Then
                DrawDataGraphic(DataSerie, DataChart)
                PrptGrdInput.SelectedObject = DataSerie
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Sub/Function"
    Private Sub ShowData(ByRef ds As DataSerie1D, ByRef dgView As DataGridView)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        Try
            With dgView
                .DataSource = ds.Data
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub ShowData(ByRef ds As DataSerie2D, ByRef dgView As DataGridView)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        Try
            With dgView
                .DataSource = ds.Data
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub ShowData(ByRef ds As DataSerieTD, ByRef dgView As DataGridView)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        Try
            'Dim iCount = ds.Count - 1
            'Dim jCount = ds.Data(0).List.Count() - 1
            'With dgView
            '    If IsNothing(.Columns) = False Then
            '        .Columns.Clear()
            '    End If
            '    For j As Integer = 0 To jCount
            '        .Columns.Add(New DataGridViewTextBoxColumn())
            '    Next
            '    .Rows.Add(iCount)
            'End With
            'For i As Integer = 0 To iCount
            '    For j As Integer = 0 To jCount
            '        dgView.Item(j, i).Value = Math.Round(ds.Data(i).List(j), 4).ToString()
            '    Next
            'Next
            With dgView
                .DataSource = ds.Data
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub ShowData(ByRef ds As DataSerie1D, ByRef ds1 As DataSerie1D, ByRef dgView As DataGridView)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return
        If (ds1.Data.Count = 0) Then Return

        Dim ds3 As New DataSerie3D()

        For i As Integer = 0 To (ds.Count - 1)
            ds3.Add(i.ToString(), ds.Data(i).X_Value, ds1.Data(i).X_Value, (Math.Abs(ds.Data(i).X_Value - ds1.Data(i).X_Value)))
        Next

        Try
            With dgView
                .DataSource = ds3.Data
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DrawDataGraphic(ByRef ds As DataSerie1D, ByRef chart As DataVisualization.Charting.Chart)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        Try
            Dim serie As New DataVisualization.Charting.Series(ds.Name)
            Dim i As Integer = 0
            If ds.Data.Count > 0 Then
                For Each ditm1 In ds.Data
                    serie.Points.AddXY(i, ditm1.X_Value)
                    i += 1
                Next
            End If

            With serie
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                ' .MarkerSize = 7
                .Color = Color.Navy
            End With

            With chart.Series
                .Clear()
                .Add(serie)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DrawDataGraphic(ByRef ds As DataSerie1D, ByRef ds2 As DataSerie1D, ByRef chart As DataVisualization.Charting.Chart)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        If IsNothing(ds2) Then Return
        If IsNothing(ds2.Data) Then Return
        If (ds2.Data.Count = 0) Then Return

        Try
            Dim serie As New DataVisualization.Charting.Series(ds.Name)
            Dim serie2 As New DataVisualization.Charting.Series(ds2.Name)
            Dim i As Integer = 0
            If ds.Data.Count > 0 Then
                For Each ditm1 In ds.Data
                    serie.Points.AddXY(i, ditm1.X_Value)
                    i += 1
                Next
            End If
            i = 0
            If ds2.Data.Count > 0 Then
                For Each ditm1 In ds2.Data
                    serie2.Points.AddXY(i, ditm1.X_Value)
                    i += 1
                Next
            End If

            With serie2
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                .MarkerSize = 0
                .Color = Color.Red
            End With

            With serie
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                .MarkerSize = 0
                .Color = Color.Navy
            End With
            With chart.Series
                .Clear()
                .Add(serie)
                .Add(serie2)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub DrawDataGraphic(ByRef ds As DataSerie2D, ByRef chart As DataVisualization.Charting.Chart)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        Try
            Dim serie As New DataVisualization.Charting.Series(ds.X_Title)
            Dim serie1 As New DataVisualization.Charting.Series(ds.Y_Title)
            Dim i As Integer = 0
            If ds.Data.Count > 0 Then
                For Each ditm1 In ds.Data
                    serie.Points.AddXY(i, ditm1.X_Value)
                    serie1.Points.AddXY(i, ditm1.Y_Value)
                    i += 1
                Next
            End If

            With serie
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                .MarkerSize = 1
                .Color = Color.Navy
            End With

            With serie1
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Cross
                .MarkerSize = 1
                .Color = Color.Crimson
            End With

            With chart.Series
                .Clear()
                .Add(serie)
                .Add(serie1)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub DrawDataGraphic(ByRef ds As DataSerieTD, ByRef chart As DataVisualization.Charting.Chart)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        If (ds.Data.Count = 0) Then Return

        MsgBox("No Yet", MsgBoxStyle.Information)

    End Sub

    Private Sub AnnEoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CmbInputsFileType.Items.Clear()
        For i = 0 To 6
            CmbInputsFileType.Items.Add(CType(i, FileFormatEnum).ToString())
        Next

        If IsNothing(AnnDataFormator) = False Then
            PrtyGrdAnnData.SelectedObject = AnnDataFormator
        End If

        '-------------------------------------------------------------------------------------
        If IsNothing(NeuralNetStructure) Then
            NeuralNetStructure = New DataSerie1D() With {.Name = "Neural Net Structure", .Title = "Layer Name", .X_Title = "Neurone count"}
            With NeuralNetStructure
                .Add("L1", 3)
                .Add("L2", 2)
            End With
        End If
        PrtyGrdAnnStructure.SelectedObject = NeuralNetStructure
        '------------------------------------------------------------------------------------
        If IsNothing(NeuralNetEO) Then
            NeuralNetEO = New NeuralNetworksEngineEO()
        End If
        NeuralNetEO.LayersStruct = NeuralNetworksEngine.GetLayersStruct(NeuralNetStructure, NeuralNetEO.InputsCount, NeuralNetEO.OuputsCount)
        NeuralNetEO.MaxIterationCount = 100
        PrtyGrdNeuralNet.SelectedObject = NeuralNetEO

        '---------------------------------------------------
        PrtGrdAnnOptimizer.SelectedObject = AnnOptimizer
        '---------------------------------------------------
        If Not Equals(SequentialForecaster, Nothing) Then
            PrtyGrdForecasting.SelectedObject = SequentialForecaster
        End If

    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnFormateDataSerie.Click

        With AnnDataFormator
            .Data = DataSerie
            .Formate() 'Simple format.
            '.Formate(True, 9) 'Formating including time in month

        End With
        DrawDataGraphic(AnnDataFormator.Training_Outputs, Chart1)
        DrawDataGraphic(AnnDataFormator.Testing_Outputs, Chart2)
    End Sub

    Private Sub BtnLuanchTraining_Click(sender As Object, e As EventArgs) Handles BtnLuanchTraining.Click
        Me.Cursor = Cursors.WaitCursor
        If IsNothing(NeuralNetEO) Then
            NeuralNetEO = New NeuralNetworksEngineEO()
        End If

        Dim computed_TrainingOutputs As DataSerie1D

        AnnDataFormator.Formate(True, 9)

        With NeuralNetEO
            .Training_Inputs = AnnDataFormator.Training_In
            .Training_Outputs = AnnDataFormator.Training_Out
            .LayersStruct = NeuralNetworksEngine.GetLayersStruct(NeuralNetStructure, .InputsCount, .OuputsCount)

            .LuanchLearning()
            '-----------------------------------------------------------------------------------------------------
            computed_TrainingOutputs = DataSerie1D.Convert(.Compute(AnnDataFormator.Training_In))
            'computed_TestingOutputs = DataSerie1D.Convert(.Compute(AnnDataFormator.Testing_In))
        End With

        AnnDataFormator.Training_Outputs.Name = "Observed Training Outputs"
        Computed_TrainingOutputs.Name = "Computed Training Outputs"

        'AnnDataFormator.Testing_Outputs.Name = "Observed Testing data"
        'computed_TestingOutputs.Name = "Computed Testing Outputs"

        DrawDataGraphic(Computed_TrainingOutputs, AnnDataFormator.Training_Outputs, ChartTrainingResults)
        'DrawDataGraphic(computed_TestingOutputs, AnnDataFormator.Testing_Outputs, ChartTestingResults)

        PrtyGrdNeuralNet.Refresh()

        Me.Cursor = Cursors.Default
        MsgBox(String.Format("End of Training with Err ={0}", NeuralNetEO.FinalTeachingError.ToString()), MsgBoxStyle.Information)

    End Sub

    Private Sub BtnComputeIndexes_Click(sender As Object, e As EventArgs) Handles BtnComputeIndexes.Click
        Dim performanceCalc As New ForecastingEngine.PerformanceMesure()
        Dim obsTestOut As New DataSerie1D With {.Name = "Observed Testing outputs"}
        Dim comptTestOut As New DataSerie1D With {.Name = "Computed Testing outputs"}

        For Each itm In AnnDataFormator.Testing_Outputs.Data
            obsTestOut.Add(itm.Title, (itm.X_Value * 105.18))
        Next

        Dim computed_TestingOutputs = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Testing_In))

        For Each itm In computed_TestingOutputs.Data
            comptTestOut.Add(itm.Title, (itm.X_Value * 105.18))
        Next

        With performanceCalc
            .ObservedSerie = obsTestOut
            .PredictedSerie = comptTestOut
            .Refresh()
        End With

        DrawDataGraphic(obsTestOut, comptTestOut, ChartTestingResults)
        PrtyGrdTestinngIndexes.SelectedObject = performanceCalc

        Dim msgResult = MsgBox("Do you want to save data series", (MsgBoxStyle.Question Or MsgBoxStyle.YesNo))
        If (msgResult = MsgBoxResult.Yes) Then
            Dim result = Export_Data(performanceCalc.ObservedSerie, performanceCalc.PredictedSerie)
            MsgBox(result.ToString())
        End If

    End Sub

    Private Sub BtnLuanchOptimization_Click(sender As Object, e As EventArgs) Handles BtnLuanchOptimization.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Me.Text = "Training... "

            With AnnOptimizer
                '.Learning_Algorithm = LearningAlgorithmEnum.BackPropagationLearning
                .Obs_TrainingInputs = AnnDataFormator.Training_Inputs
                .Obs_TrainingOutputs = AnnDataFormator.Training_Outputs
                .Obs_TestingInputs = AnnDataFormator.Testing_Inputs

                '-------Computation----------------
                .Compute()
                NeuralNetEO = .Best_NeuralNetwork
                '----------------------------------
            End With

            MsgBox("Optimization Completed", MsgBoxStyle.Information)

            '************************************************************************
            PrtyGrdOptimizedNeuralNetEO.SelectedObject = NeuralNetEO

            '************************************************************************
            DrawDataGraphic(AnnOptimizer.Best_Chart, BestFitnessChart)

            Dim trainPerformanceCalc As New ForecastingEngine.PerformanceMesure()

            With trainPerformanceCalc
                .ObservedSerie = AnnOptimizer.Obs_TrainingOutputs
                .PredictedSerie = AnnOptimizer.Computed_TrainingOutputs
                .Refresh()
            End With
            PrtGrdTrainingIndexes.SelectedObject = trainPerformanceCalc

            Dim testPerformanceCalc As New ForecastingEngine.PerformanceMesure()

            With testPerformanceCalc
                .ObservedSerie = AnnDataFormator.Testing_Outputs
                .PredictedSerie = AnnOptimizer.ComputedTestingOutputs
            End With
            PrtGrdTestingIndexes.SelectedObject = testPerformanceCalc

            DrawDataGraphic(AnnOptimizer.Obs_TrainingOutputs, AnnOptimizer.Computed_TrainingOutputs, ChartCompareTraining)
            DrawDataGraphic(AnnDataFormator.Testing_Outputs, AnnOptimizer.ComputedTestingOutputs, ChartCompareTesting)

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CxmSaveDataSeries_Click(sender As Object, e As EventArgs) Handles CxmSaveDataSeries.Click
        Try
            If Equals(AnnDataFormator, Nothing) Then Return
            If Equals(AnnDataFormator.Testing_Outputs, Nothing) Then Return
            If Equals(AnnDataFormator.Testing_Outputs.Data, Nothing) Then Return

            'If Equals(NeuralNetEO, Nothing) Then Return
            'If Equals(NeuralNetEO, Nothing) Then Return
            'If Equals(NeuralNetEO.Training_Outputs, Nothing) Then Return

            'Dim results = Export_Data(DataSerie1D.Convert(NeuralNetEO.Training_Outputs), AnnDataFormator.Training_Outputs)

            'MsgBox(results.ToString())

            If Equals(AnnOptimizer, Nothing) Then Return
            If Equals(AnnOptimizer.ComputedTestingOutputs, Nothing) Then Return
            If Equals(AnnOptimizer.ComputedTestingOutputs.Data, Nothing) Then Return

            Export_Data(AnnDataFormator.Testing_Outputs, AnnOptimizer.ComputedTestingOutputs)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CxmSaveTrainingOutSeries_Click(sender As Object, e As EventArgs) Handles CxmSaveTrainingOutSeries.Click
        Try
            If Equals(AnnDataFormator, Nothing) Then Return
            If Equals(AnnDataFormator.Training_Outputs, Nothing) Then Return
            If Equals(AnnDataFormator.Training_Outputs.Data, Nothing) Then Return

            'If Equals(NeuralNetEO, Nothing) Then Return
            'If Equals(NeuralNetEO.Training_Outputs, Nothing) Then Return
            'If Equals(NeuralNetEO.Training_Outputs, Nothing) Then Return

            'Dim results = Export_Data(DataSerie1D.Convert(NeuralNetEO.Training_Outputs), AnnDataFormator.Training_Outputs)

            'MsgBox(results.ToString())

            If Equals(AnnOptimizer, Nothing) Then Return
            If Equals(AnnOptimizer.Computed_TrainingOutputs, Nothing) Then Return
            If Equals(AnnOptimizer.Computed_TrainingOutputs.Data, Nothing) Then Return

            Export_Data(AnnDataFormator.Training_Outputs, AnnOptimizer.Computed_TrainingOutputs)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BtnComputeTrainIndexes_Click(sender As Object, e As EventArgs) Handles BtnComputeTrainIndexes.Click
        Dim performanceCalc As New ForecastingEngine.PerformanceMesure()
        Dim obsTrainOut As New DataSerie1D With {.Name = "Observed Training outputs"}
        Dim comptTrainOut As New DataSerie1D With {.Name = "Computed Training outputs"}

        If IsNothing(AnnDataFormator.Training_Outputs) Then Return
        If IsNothing(AnnDataFormator.Training_Outputs.Data) Then Return

        If IsNothing(NeuralNetEO) Then Return

        For Each itm In AnnDataFormator.Training_Outputs.Data
            obsTrainOut.Add(itm.Title, (itm.X_Value * 105.18))
        Next

        Dim computed_TrainingOutputs = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Training_In))

        For Each itm In Computed_TrainingOutputs.Data
            comptTrainOut.Add(itm.Title, (itm.X_Value * 105.18))
        Next

        With performanceCalc
            .ObservedSerie = obsTrainOut
            .PredictedSerie = comptTrainOut
            .Refresh()
        End With

        PrtyGrdTrainingIndexes.SelectedObject = performanceCalc

        Dim msgResult = MsgBox("Do you want to save data series", (MsgBoxStyle.Question Or MsgBoxStyle.YesNo))
        If (msgResult = MsgBoxResult.Yes) Then
            Dim result = Export_Data(performanceCalc.ObservedSerie, performanceCalc.PredictedSerie)
            MsgBox(result.ToString())
        End If

        'Clipboard.SetData(DataFormats.Html, performanceCalc.Indexes)
        'Me.Text = "Copied"
    End Sub

    Private Sub BtnLuanchAll_Click(sender As Object, e As EventArgs) Handles BtnLuanchAll.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If IsNothing(NeuralNetEO) Then
                NeuralNetEO = New NeuralNetworksEngineEO()
            End If

            TabPage8.Show()

            TXTResults.Text = " "

            AnnDataFormator.Formate(True, 9)

            Dim observed_TrainingOutputs = New DataSerie1D With {.Name = "Observed Training Outputs", .Title = "Month", .X_Title = "Q"}

            For Each itm In AnnDataFormator.Training_Outputs.Data
                observed_TrainingOutputs.Add(itm.Title, (105.18 * itm.X_Value))
            Next

            Dim observed_TestingOutputs = New DataSerie1D With {.Name = " Observed Testing Outputs", .Title = "Month", .X_Title = "Q"}

            For Each itm In AnnDataFormator.Testing_Outputs.Data

                observed_TestingOutputs.Add(itm.Title, (105.18 * itm.X_Value))
            Next

            With NeuralNetEO
                .ActivationFunction = ActivationFunctionEnum.BipolarSigmoidFunction
                .ActiveFunction_Alpha = 2

                .LearningAlgorithm = LearningAlgorithmEnum.HPSOGWO_Learning
                .MaxIterationCount = 1000

                .EOA_PopulationSize = 40
                .HPSOGWO_C1 = 0.5
                .HPSOGWO_C2 = 0.5
                .HPSOGWO_C3 = 0.5

                .Training_Inputs = AnnDataFormator.Training_In
                .Training_Outputs = AnnDataFormator.Training_Out
            End With

            'Dim ds1 As New DataSerie1D With {.Name = "RNA 1D-Structures"}
            'With ds1
            '    .Add(String.Format("ANN-HPG-{0} (1)", (NeuralNetEO.InputsCount - 1)), 1)
            '    .Add(String.Format("ANN-HPG-{0} (2)", (NeuralNetEO.InputsCount - 1)), 2)
            '    .Add(String.Format("ANN-HPG-{0} (3)", (NeuralNetEO.InputsCount - 1)), 3)
            '    .Add(String.Format("ANN-HPG-{0} (4)", (NeuralNetEO.InputsCount - 1)), 4)
            '    .Add(String.Format("ANN-HPG-{0} (5)", (NeuralNetEO.InputsCount - 1)), 5)
            '    .Add(String.Format("ANN-HPG-{0} (6)", (NeuralNetEO.InputsCount - 1)), 6)
            '    .Add(String.Format("ANN-HPG-{0} (7)", (NeuralNetEO.InputsCount - 1)), 7)
            '    .Add(String.Format("ANN-HPG-{0} (8)", (NeuralNetEO.InputsCount - 1)), 8)
            '    .Add(String.Format("ANN-HPG-{0} (9)", (NeuralNetEO.InputsCount - 1)), 9)
            '    .Add(String.Format("ANN-HPG-{0} (10)", (NeuralNetEO.InputsCount - 1)), 10)
            '    .Add(String.Format("ANN-HPG-{0} (11)", (NeuralNetEO.InputsCount - 1)), 11)
            '    .Add(String.Format("ANN-HPG-{0} (12)", (NeuralNetEO.InputsCount - 1)), 12)
            '    .Add(String.Format("ANN-HPG-{0} (13)", (NeuralNetEO.InputsCount - 1)), 13)
            '    .Add(String.Format("ANN-HPG-{0} (14)", (NeuralNetEO.InputsCount - 1)), 14)
            '    .Add(String.Format("ANN-HPG-{0} (15)", (NeuralNetEO.InputsCount - 1)), 15)
            'End With

            'Dim annStruct(1) As Integer
            'For Each itm In ds1.Data
            '    annStruct(0) = CInt(itm.X_Value)
            '    annStruct(1) = 1

            '    NeuralNetEO.LayersStruct = annStruct
            '    NeuralNetEO.LuanchLearning()

            '    Dim compTrainOuts = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Training_Inputs.GetArray()))
            '    Dim compTestOuts = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Testing_Inputs.GetArray()))

            '    For Each ditem In compTrainOuts.Data
            '        ditem.X_Value *= 105.18
            '    Next

            '    For Each ditem In compTestOuts.Data
            '        ditem.X_Value *= 105.18
            '    Next

            '    Dim performanceCalc1 As New ForecastingEngine.PerformanceMesure()
            '    Dim performanceCalc2 As New ForecastingEngine.PerformanceMesure()

            '    performanceCalc1.ObservedSerie = observed_TrainingOutputs
            '    performanceCalc1.PredictedSerie = compTrainOuts
            '    performanceCalc1.Refresh()

            '    performanceCalc2.ObservedSerie = observed_TestingOutputs
            '    performanceCalc2.PredictedSerie = compTestOuts
            '    performanceCalc2.Refresh()

            '    'Savin results :
            '    TXTResults.Text += String.Format("{0}; {1}; ; {2}", itm.Title, performanceCalc1.Indexes, performanceCalc2.Indexes) + vbNewLine

            'Next

            'MsgBox("End computation ...", MsgBoxStyle.Information)
            'Return
            Dim chronos As New Stopwatch()
            chronos.Start()

            Dim annStruct2(2) As Integer

            For i = 1 To 15
                For j = 1 To 15
                    annStruct2(0) = i
                    annStruct2(1) = j
                    annStruct2(2) = 1

                    NeuralNetEO.LayersStruct = annStruct2

                    NeuralNetEO.LuanchLearning()

                    Dim compTrainOuts = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Training_Inputs.GetArray()))
                    Dim compTestOuts = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Testing_Inputs.GetArray()))

                    For Each ditem In compTrainOuts.Data
                        ditem.X_Value *= 105.18
                    Next

                    For Each ditem In compTestOuts.Data
                        ditem.X_Value *= 105.18
                    Next

                    Dim performanceCalc1 As New ForecastingEngine.PerformanceMesure()
                    Dim performanceCalc2 As New ForecastingEngine.PerformanceMesure()

                    performanceCalc1.ObservedSerie = observed_TrainingOutputs
                    performanceCalc1.PredictedSerie = compTrainOuts
                    performanceCalc1.Refresh()

                    performanceCalc2.ObservedSerie = observed_TestingOutputs
                    performanceCalc2.PredictedSerie = compTestOuts
                    performanceCalc2.Refresh()

                    'Savin results :
                    TXTResults.Text += String.Format("ANN-HPG-{0} ({1}, {2}); {3}; ; {4}", (NeuralNetEO.InputsCount - 1), i, j, performanceCalc1.Indexes, performanceCalc2.Indexes) + vbNewLine

                Next
            Next

            chronos.Stop()
            Me.Text = String.Format("End computation ... In : {0} Ms", chronos.ElapsedMilliseconds)

            MsgBox(String.Format("End computation ... In : {0} Ms", chronos.ElapsedMilliseconds), MsgBoxStyle.Information)
            chronos = Nothing

        Catch ex As Exception
            Throw ex
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CxmLoadNeuralNetwok_Click(sender As Object, e As EventArgs) Handles CxmLoadNeuralNetwok.Click
        Dim result As Boolean = ImportNework()
        MsgBox(String.Format("Importing Neural Network = [{0}]", result), MsgBoxStyle.Information)
        PrtyGrdNeuralNet.SelectedObject = NeuralNetEO
        PrtyGrdNeuralNet.Refresh()
    End Sub

    Private Sub CxmSaveNeuralNetwork_Click(sender As Object, e As EventArgs) Handles CxmSaveNeuralNetwork.Click

        Dim result As Boolean = ExportNetwork(NeuralNetEO)

        MsgBox(String.Format("Saving Neural Network = [{0}]", result), MsgBoxStyle.Information)

    End Sub

    Friend Function ImportNework() As Boolean
        Dim result As Boolean = False
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = "ANN files (*.ANN)|*.ANN"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            NeuralNetEO = NeuralNetworksEngineEO.Load(fileName)

            result = True
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Friend Function ExportNetwork(ByRef neuralNet As NeuralNetworksEngineEO) As Boolean

        Dim result As Boolean = False

        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    .Filter = "ANN files (*.ANN)|*.ANN"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse (fileName = String.Empty) Then Return False
            With neuralNet
                result = .Save(fileName)
            End With

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Private Sub BtnComputeTrainingOuts_Click(sender As Object, e As EventArgs) Handles BtnComputeTrainingOuts.Click
        Try

            Dim computed_TrainingOutputs = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Training_Inputs.GetArray()))
            Dim computed_TestingOutputs = DataSerie1D.Convert(NeuralNetEO.Compute(AnnDataFormator.Testing_Inputs.GetArray()))
            computed_TrainingOutputs.Name = "Computed Training Outputs"
            computed_TestingOutputs.Name = "Computed Testing Outputs"

            AnnDataFormator.Training_Outputs.Name = "Observed Training Outputs"
            AnnDataFormator.Testing_Outputs.Name = "Observed Testing data"

            DrawDataGraphic(computed_TrainingOutputs, AnnDataFormator.Training_Outputs, ChartTrainingResults)

            PrtyGrdNeuralNet.Refresh()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CmiSaveBestAnnEo_Click(sender As Object, e As EventArgs) Handles CmiSaveBestAnnEo.Click
        Dim result As Boolean = False
        If IsNothing(AnnOptimizer) = False Then
            If IsNothing(AnnOptimizer.Best_NeuralNetwork) = False Then
                result = ExportNetwork(AnnOptimizer.Best_NeuralNetwork)
            Else
                result = False
            End If
        Else
            result = False
        End If
        MsgBox(String.Format("Saving the best (Optimized) Neural Net = [{0}].", result), MsgBoxStyle.Information)
    End Sub

    Private Sub BtnLuanchForecasting_Click(sender As Object, e As EventArgs) Handles BtnLuanchForecasting.Click
        'Dim ds As New DataSerie1D
        'For i = 0 To 100
        '    ds.Add(Observed_TestingOutputs.Data(i).Title, Observed_TestingOutputs.Data(i).X_Value)
        'Next

        Dim monthIndex As Integer = 12 - (NeuralNetEO.InputsCount - 2)

        With SequentialForecaster
            .NeuralNetsEngine = NeuralNetEO
            ForecastingOutputs = .Forecast(AnnDataFormator.Testing_Outputs, True, monthIndex)
            'ForecastingOutputs = .Forecast(ds, True, 10)
        End With

        ShowData(ForecastingOutputs, DgvForecastingResults)
        DrawDataGraphic(ForecastingOutputs, ChartForecasting)
    End Sub

    Private Sub BtnExportForecastingResults_Click(sender As Object, e As EventArgs) Handles BtnExportForecastingResults.Click, CsmiExportForecastingResults.Click
        Try
            Dim result = Export_Data(ForecastingOutputs)

            MsgBox(String.Format("Saving Training Data = {0}", result), MsgBoxStyle.Information)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CmiSaveBestChart_Click(sender As Object, e As EventArgs) Handles CmiSaveBestChart.Click
        Try
            If Equals(AnnOptimizer, Nothing) Then Return
            If Equals(AnnOptimizer.Best_Chart) Then Return
            If Equals(AnnOptimizer.Best_Chart) Then Return
            Dim result = ExportData(FileFormatEnum.CSV, AnnOptimizer.Best_Chart)
            MsgBox(String.Format("Export Best Fitness Chart = [{0}]", result), MsgBoxStyle.Information)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CmiSaveObservedComputedTrainingSeries_Click(sender As Object, e As EventArgs) Handles CmiSaveObservedComputedTrainingSeries.Click
        Try
            If Equals(AnnOptimizer, Nothing) Then Return
            If Equals(AnnOptimizer.Obs_TrainingOutputs, Nothing) Then Return
            If Equals(AnnOptimizer.Computed_TrainingOutputs, Nothing) Then Return

            'Saving Training data after optimization:
            Dim result As Boolean = Export_Data(AnnOptimizer.Obs_TrainingOutputs, AnnOptimizer.Computed_TrainingOutputs)
            MsgBox(String.Format("Saving Training Data = {0}", result), MsgBoxStyle.Information)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CmiSaveObservedComputedTestingSeries_Click(sender As Object, e As EventArgs) Handles CmiSaveObservedComputedTestingSeries.Click
        Try
            If Equals(AnnOptimizer, Nothing) Then Return
            If Equals(AnnOptimizer.ComputedTestingOutputs, Nothing) Then Return

            If Equals(AnnDataFormator, Nothing) Then Return
            If Equals(AnnDataFormator.Testing_Outputs, Nothing) Then Return

            'Saving testing data after optimization:
            Dim result As Boolean = Export_Data(AnnDataFormator.Testing_Outputs, AnnOptimizer.ComputedTestingOutputs)
            MsgBox(String.Format("Saving Testing Data = {0}", result), MsgBoxStyle.Information)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim mcDs As New ForecastingEngine.MarkovChain()

        Dim markovChain = mcDs.GetClassifiedSerie(DataSerie)

        DataGridView1.DataSource = markovChain.Data

        PropertyGrid1.SelectedObject = mcDs

    End Sub


End Class