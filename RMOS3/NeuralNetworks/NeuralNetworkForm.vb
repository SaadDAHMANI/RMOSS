Option Strict On
Imports IOOperations
Imports IOOperations.Components
Imports ForecastingEngine.NeuralNetworks

Public Class NeuralNetworkForm
    Private NeuralNetEngine As New NeuralNetworksEngine()
    Private NeuralNetStructure As New DataSerie1D() With {.Name = "Neural Net Structure", .Title = "Layer Name", .X_Title = "Neurone count"}
    Private SequentialForecaster As New ForecastingEngine.SequentialForecaster(NeuralNetEngine)
    '------------------------------------------------------------------------------
    Private TrainingInputs As DataSerieTD
    Private TrainingOutputs As DataSerie1D

    Private TestingInputs As DataSerieTD
    Private TestingOutputs As DataSerie1D

    Private ComputedTrainingOutputs As DataSerie1D
    Private ComputedTestingOutputs As DataSerie1D

    Private ForecastingInputs As DataSerieTD
    Private ForecastingOutputs As DataSerie1D

    Private InputDataSerie As DataSerie1D
    Private OutputDataSerie As DataSerie1D

    Private AnnOptimizer As New OptimizedNeuralNetwok()
    REM----------------------------------------------------------------------------

#Region "Subs and Functions"

    'Private Function ImportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerieTD) As Boolean
    '    Dim result As Boolean = False
    '    Try
    '        Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
    '        If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
    '            fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '        End If
    '        Using openFileDlg As New OpenFileDialog
    '            With openFileDlg
    '                .InitialDirectory = fileName
    '                .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
    '                .ShowDialog()
    '                fileName = .FileName
    '            End With
    '        End Using

    '        If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
    '        Dim reader As New CsvFileIO(fileName)
    '        dataserie = reader.Read_DST()
    '        result = True

    '        If IsNothing(dataserie.Data) Then Return False

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return result
    'End Function
    'Private Function ImportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerie1D) As Boolean
    '    Dim result As Boolean = False
    '    Try
    '        Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
    '        If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
    '            fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '        End If
    '        Using openFileDlg As New OpenFileDialog
    '            With openFileDlg
    '                .InitialDirectory = fileName
    '                .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
    '                .ShowDialog()
    '                fileName = .FileName
    '            End With
    '        End Using

    '        If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
    '        Dim reader As New CsvFileIO(fileName)
    '        dataserie = reader.Read_DS1()
    '        result = True

    '        If IsNothing(dataserie.Data) Then Return False

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return result
    'End Function
    'Private Function ImportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerie2D) As Boolean
    '    Dim result As Boolean = False
    '    Try
    '        Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
    '        If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
    '            fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '        End If
    '        Using openFileDlg As New OpenFileDialog
    '            With openFileDlg
    '                .InitialDirectory = fileName
    '                .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
    '                .ShowDialog()
    '                fileName = .FileName
    '            End With
    '        End Using

    '        If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
    '        Dim reader As New CsvFileIO(fileName)
    '        dataserie = reader.Read_DS2()
    '        result = True

    '        If IsNothing(dataserie.Data) Then Return False

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return result
    'End Function

    'Private Function ExportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerie1D) As Boolean
    '    Dim result As Boolean = False
    '    If IsNothing(dataserie) Then Return result

    '    Try
    '        Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
    '        If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
    '            fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '        End If
    '        Using saveFileDlg As New SaveFileDialog
    '            With saveFileDlg
    '                .InitialDirectory = fileName
    '                .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
    '                .ShowDialog()
    '                fileName = .FileName
    '            End With
    '        End Using

    '        If IsNothing(fileName) OrElse fileName = String.Empty Then Return False

    '        Dim dataWriter As New CsvFileIO(fileName)

    '        result = dataWriter.Write(dataserie)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return result
    'End Function

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
                .MarkerSize = 7
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

    Private Sub DrawDataGraphic(ByRef ds As DataSerie1D, ByRef ds1 As DataSerie1D, ByRef chart As DataVisualization.Charting.Chart)
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
            Dim serie As New DataVisualization.Charting.Series(ds3.X_Title)
            Dim serie1 As New DataVisualization.Charting.Series(ds3.Y_Title)
            Dim i As Integer = 0
            If ds3.Data.Count > 0 Then
                For Each ditm In ds3.Data
                    serie.Points.AddXY(i, ditm.X_Value)
                    serie1.Points.AddXY(i, ditm.Y_Value)
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

    REM -------------------------------------------------------------------------------------------------

    Private Sub BtnImportTrainInputs_Click(sender As Object, e As EventArgs) Handles BtnImportTrainInputs.Click
        Dim fileFormat As Integer = CmbTrainInputsFileType.SelectedIndex
        If (fileFormat < 0) OrElse (fileFormat > 6) Then
            MsgBox("Select format of file please..", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim result As Boolean = ImportData(CType(fileFormat, FileFormatEnum), TrainingInputs)
        If result Then
            ShowData(TrainingInputs, DgvTrainingInputs)

            PrptGrdTrainingInput.SelectedObject = TrainingInputs

        End If
    End Sub

    Private Sub BtnImportTrainOutputs_Click(sender As Object, e As EventArgs) Handles BtnImportTrainOutputs.Click
        Dim fileFormat As Integer = CmbTrainOutputsFileType.SelectedIndex
        If (fileFormat < 0) OrElse (fileFormat > 6) Then
            MsgBox("Select format of file please..", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim result As Boolean = ImportData(CType(fileFormat, FileFormatEnum), TrainingOutputs)
        If result Then
            ShowData(TrainingOutputs, DgvTrainingOutputs)
            PrptGrdTrainingOutput.SelectedObject = TrainingOutputs

        End If
    End Sub

    Private Sub BtnImportTestingInputs_Click(sender As Object, e As EventArgs) Handles BtnImportTestingInputs.Click
        Dim fileFormat As Integer = CmbTestInputsFileType.SelectedIndex
        If (fileFormat < 0) OrElse (fileFormat > 6) Then
            MsgBox("Select format of file please..", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim result As Boolean = ImportData(CType(fileFormat, FileFormatEnum), TestingInputs)
        If result Then
            ShowData(TestingInputs, DgvTestingInputs)
            PrptGrdTestingInput.SelectedObject = TestingInputs

        End If
    End Sub

    Private Sub BtnImportTestingOutputs_Click(sender As Object, e As EventArgs) Handles BtnImportTestingOutputs.Click
        Dim fileFormat As Integer = CmbTestOutputsFileType.SelectedIndex
        If (fileFormat < 0) OrElse (fileFormat > 6) Then
            MsgBox("Select format of file please..", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim result As Boolean = ImportData(CType(fileFormat, FileFormatEnum), TestingOutputs)
        If result Then
            ShowData(TestingOutputs, DgvTestingOutputs)
            PrptGrdTestingOutput.SelectedObject = TestingOutputs

        End If
    End Sub

    Private Sub BtnLuanchTraining_Click(sender As Object, e As EventArgs) Handles BtnLuanchTraining.Click
        Cursor = Cursors.WaitCursor
        BtnLuanchTraining.Enabled = False
        Try
            With NeuralNetEngine
                .TrainingInputs = TrainingInputs
                .TrainingOutputs_DS1 = TrainingOutputs
                .LayersStruct = NeuralNetStructure
                .LuanchLearning()
                ComputedTrainingOutputs = .Compute(TrainingInputs)

            End With

            '------------------------------------------------
            If (IsNothing(ComputedTrainingOutputs) = False) Then
                ComputedTrainingOutputs.Name = "Computed Training Outputs"
                DrawDataGraphic(TrainingOutputs, ComputedTrainingOutputs, ChartTraining)
            End If

            '------------------------------------------------
            MsgBox(String.Format("End of Training with Err ={0}", NeuralNetEngine.FinalTeachingError.ToString()), MsgBoxStyle.Information)

            PrptyGrdNeuralNet.Refresh()
            '----------------------------------
            Dim performanceCalc As New ForecastingEngine.PerformanceMesure()
            With performanceCalc
                .ObservedSerie = TrainingOutputs
                .PredictedSerie = ComputedTrainingOutputs
                .Refresh()
            End With

            PrtGrdTrainingIndexes.SelectedObject = performanceCalc
            '----------------------------------------------
            Dim ds1In As New DataSerie1D With {.Name = "ObservedSerie"}
            Dim ds1Out As New DataSerie1D With {.Name = "Computed"}
            ds1In.Data.Clear()
            ds1Out.Data.Clear()

            For Each itm In TrainingOutputs.Data
                ds1In.Add(itm.Title, (itm.X_Value * 102.6))
            Next

            For Each itm In ComputedTrainingOutputs.Data
                ds1Out.Add(itm.Title, (itm.X_Value * 102.6))
            Next

            Dim performCalc As New ForecastingEngine.PerformanceMesure()
            With performCalc
                .ObservedSerie = ds1In
                .PredictedSerie = ds1Out
                .Refresh()
            End With
            PropertyGrid1.SelectedObject = performCalc

        Catch ex As Exception
            Throw ex
        Finally
            Cursor = Cursors.Default
        End Try

        BtnLuanchTraining.Enabled = True

    End Sub

    Private Sub NeuralNetworkForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            '-------------------------------------------------------------------------------------
            For i = 0 To 6
                CmbTestInputsFileType.Items.Add(CType(i, FileFormatEnum).ToString())
                CmbTestOutputsFileType.Items.Add(CType(i, FileFormatEnum).ToString())
                CmbTrainInputsFileType.Items.Add(CType(i, FileFormatEnum).ToString())
                CmbTrainOutputsFileType.Items.Add(CType(i, FileFormatEnum).ToString())
                CmbfileFormat.Items.Add(CType(i, FileFormatEnum).ToString())

            Next
            '-------------------------------------------------------------------------------------
            If IsNothing(NeuralNetEngine) = False Then
                PrptyGrdNeuralNet.SelectedObject = NeuralNetEngine
            End If

            '------------------------------------------------------------------------------------
            With NeuralNetStructure
                .Add("L1", 2)
                .Add("L2", 3)
            End With
            PrptyGrdNeuralNetStruct.SelectedObject = NeuralNetStructure

            '------------------------------------------------------------------------------------
            PrtyGrdForecasting.SelectedObject = SequentialForecaster

            '------------------------------------------------------------------------------------
            For i As Integer = 0 To 12
                CmbAggregationCount.Items.Add(i.ToString())
            Next

            '---------------------------------------------------
            PrtGrdAnnOptimizer.SelectedObject = AnnOptimizer

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BtnLuanchTesting_Click(sender As Object, e As EventArgs) Handles BtnLuanchTesting.Click
        If IsNothing(TestingInputs) = False Then
            If IsNothing(TestingInputs.Data) = False Then
                ComputedTestingOutputs = NeuralNetEngine.Compute(TestingInputs)
                If Equals(ComputedTestingOutputs, Nothing) = False Then

                    StandrizeData(TestingOutputs, NeuralNetEngine.ActivationFunction)

                    ShowData(TestingOutputs, ComputedTestingOutputs, DgvValidationResults)

                    DrawDataGraphic(TestingOutputs, ComputedTestingOutputs, ChartValidationResults)
                End If
            End If
        End If
    End Sub

    Private Sub StandrizeData(ByRef ds1 As DataSerie1D, ByVal activefunction As ActivationFunctionEnum)
        For i As Integer = 0 To (ds1.Count - 1)
            ds1.Data(i).X_Value = (ds1.Data(i).X_Value - ds1.Min) / (ds1.Max - ds1.Min)
        Next
    End Sub

    Private Sub BtnLuanchForecasting_Click(sender As Object, e As EventArgs) Handles BtnLuanchForecasting.Click

        Dim ds As New DataSerie1D()

        Dim rand As New Random()

        With ds
            .Add("2013-1", 0.48)
            .Add("2013-2", 0.36)
            .Add("2013-3", 0.23)
            .Add("2013-4", 0.15)
            .Add("2013-5", 0.29)
            .Add("2013-6", 0)
            .Add("2013-7", 0)
            .Add("2013-8", 0.06)
            .Add("2013-9", 0.04)
            .Add("2013-10", 0)
            .Add("2013-11", 0.26)
            .Add("2013-12", 0.66)

            .Add("2014-1", 0.48)
            .Add("2014-2", 0.14)
            .Add("2014-3", 0.22)
            .Add("2014-4", 0.09)
            .Add("2014-5", 0.12)
            .Add("2014-6", 0.09)
            .Add("2014-7", 0)
            .Add("2014-8", 0)
            .Add("2014-9", 0.22)
            .Add("2014-10", 0.07)
            .Add("2014-11", 0.36)
            .Add("2014-12", 0.6)

            .Add("2015-1", 0.31)
            .Add("2015-2", 0.26)
            .Add("2015-3", 0.12)
            .Add("2015-4", 0.09)
            .Add("2015-5", 0.25)
            .Add("2015-6", 0.01)
            .Add("2015-7", 0)
            .Add("2015-8", 0)
            .Add("2015-9", 0.22)
            .Add("2015-10", 0.16)
            .Add("2015-11", 0.03)
            .Add("2015-12", 0.00)

            .Add("2016-1", 0.08)
            .Add("2016-2", 0.26)
            .Add("2016-3", 0.26)
            .Add("2016-4", 0.13)
            .Add("2016-5", 0.32)
            .Add("2016-6", 0.06)
            .Add("2016-7", 0)
            .Add("2016-8", 0)
            .Add("2016-9", 0.11)
            .Add("2016-10", 0.15)
            .Add("2016-11", 0.27)
            .Add("2016-12", 0.3)

        End With

        With SequentialForecaster
            .FutureHorizon = ds.Count
            ForecastingOutputs = .Forecast2(ds)
        End With

        ShowData(ForecastingOutputs, DgvForecastingResults)
        DrawDataGraphic(ForecastingOutputs, ChartForecasting)
    End Sub

    Private Sub BtnExportForecastingResults_Click(sender As Object, e As EventArgs) Handles BtnExportForecastingResults.Click
        Try

            Dim result = ExportData(FileFormatEnum.CSV, ForecastingOutputs)

            If result Then
                MsgBox("Data have been saved.", MsgBoxStyle.Information)
            Else
                MsgBox("Data have NOT been saved. Try Again Please.", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub BtnImportDataSerie_Click(sender As Object, e As EventArgs) Handles BtnImportDataSerie.Click
        Dim fileFormat As Integer = CmbfileFormat.SelectedIndex
        If (fileFormat < 0) OrElse (fileFormat > 6) Then
            MsgBox("Select format of file please..", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim result As Boolean = ImportData(CType(fileFormat, FileFormatEnum), InputDataSerie)

        If result Then
            ShowData(InputDataSerie, DgvInputData)

        End If
    End Sub

    Private Sub BtnExportDataSerie_Click(sender As Object, e As EventArgs) Handles BtnExportDataSerie.Click
        Try

            Dim result = ExportData(FileFormatEnum.CSV, OutputDataSerie)

            If result Then
                MsgBox("Data have been saved.", MsgBoxStyle.Information)
            Else
                MsgBox("Data have NOT been saved. Try Again Please.", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub BtnAggregateData_Click(sender As Object, e As EventArgs) Handles BtnAggregateData.Click
        Dim count As Integer = CmbAggregationCount.SelectedIndex
        If count < 2 Then Return

        OutputDataSerie = InputDataSerie.Aggregate(count)
        ShowData(OutputDataSerie, DgvOutputData)

    End Sub

    Private Sub BtnComputeIndexes_Click(sender As Object, e As EventArgs) Handles BtnComputeIndexes.Click
        Dim performanceCalc As New ForecastingEngine.PerformanceMesure()
        With performanceCalc
            .ObservedSerie = TestingOutputs
            .PredictedSerie = ComputedTestingOutputs
            .Refresh()
        End With
        PrtyGrdPerformCriteria.SelectedObject = performanceCalc

        '----------------------------------------------------------------------------------
        Dim dsIn As New DataSerie1D
        Dim dsOut As New DataSerie1D

        dsIn.Data.Clear()
        dsOut.Data.Clear()

        For Each itm In dsIn.Data
            dsIn.Add(itm.Title, (itm.X_Value * 102.6))
        Next

        For Each itm In dsOut.Data
            dsOut.Add(itm.Title, (itm.X_Value * 102.6))
        Next

        Dim performCal As New ForecastingEngine.PerformanceMesure()
        With performCal
            .ObservedSerie = dsIn
            .PredictedSerie = dsOut
            .Refresh()
        End With
        PropertyGrid2.SelectedObject = performCal
    End Sub

    Private Sub BtnLuanchOptimization_Click(sender As Object, e As EventArgs) Handles BtnLuanchOptimization.Click
        Me.Cursor = Cursors.WaitCursor

        Try

            With AnnOptimizer
                .Obs_TrainingInputs = TrainingInputs
                .Obs_TrainingOutputs = TrainingOutputs
                '.Learning_Algorithm = LearningAlgorithmEnum.BackPropagationLearning
            End With

            AnnOptimizer.Compute()

            LbxSolutionsHistory.Items.Clear()
            If IsNothing(AnnOptimizer.Couple_Solution_Fitness) = False Then

                For Each sf In AnnOptimizer.Couple_Solution_Fitness
                    LbxSolutionsHistory.Items.Add(String.Format("Solution: {0} || Fitness = {1}.", sf.Key, sf.Value))
                Next

            End If

            For Each itm In AnnOptimizer.Best_Solution.Data
                LbxSolutionsHistory.Items.Add(String.Format("{0} : {1}", itm.Title, itm.X_Value))
            Next

            LbxSolutionsHistory.Items.Add(String.Format("Best Fitness : {0}", AnnOptimizer.Best_Chart.Data.Last.X_Value.ToString()))
                LbxSolutionsHistory.Items.Add(String.Format("{0} || Best Fitness : {1}", AnnOptimizer.Best_Solution.Data2String("int"), AnnOptimizer.Best_Chart.Min))


                DrawDataGraphic(AnnOptimizer.Best_Chart, BestFitnessChart)

            MsgBox("Computation completed", MsgBoxStyle.Information)

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CxmiSaveTrainingResults_Click(sender As Object, e As EventArgs) Handles CxmiSaveTrainingResults.Click
        Try
            If IsNothing(TrainingOutputs) = False Then
                With TrainingOutputs
                    .Name = "Observed Training Outputs"
                    .X_Title = "Observed-Training"
                    .Title = "Index"
                End With
            End If

            If IsNothing(ComputedTrainingOutputs) = False Then
                With ComputedTrainingOutputs
                    .Name = "Computed Training Outputs"
                    .X_Title = "Computed-Training"
                    .Title = "Index"
                End With
            End If


            Dim result = Export_Data(TrainingOutputs, ComputedTrainingOutputs)
            MsgBox(String.Format("Saving = [{0}]", result), MsgBoxStyle.Information)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CxmiSaveTestingResults_Click(sender As Object, e As EventArgs) Handles CxmiSaveTestingResults.Click

        Try
            If IsNothing(TestingOutputs) = False Then
                With TestingOutputs
                    .Name = "Observed Testing Outputs"
                    .Title = "Index"
                    .X_Title = "Observed-Testing"
                End With
            End If

            If IsNothing(ComputedTestingOutputs) = False Then
                With ComputedTestingOutputs
                    .Name = "Computed Testing Outputs"
                    .Title = "Index"
                    .X_Title = "Computed-Testing"

                End With
            End If

            Dim result = Export_Data(TestingOutputs, ComputedTestingOutputs)
            MsgBox(String.Format("Saving = [{0}]", result), MsgBoxStyle.Information)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region

    Friend Function ExportNetwork(ByRef neuralNet As NeuralNetworksEngine) As Boolean

        Dim result As Boolean = False

        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    .Filter = "ANN1 files (*.ANN1)|*.ANN1"
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

    Private Sub CxmiSaveNeuralNetwork_Click(sender As Object, e As EventArgs) Handles CxmiSaveNeuralNetwork.Click
        Dim result As Boolean = ExportNetwork(NeuralNetEngine)

        MsgBox(String.Format("Saving Neural Network = [{0}]", result), MsgBoxStyle.Information)
    End Sub

    Private Sub CxmiLoadNeuralNet_Click(sender As Object, e As EventArgs) Handles CxmiLoadNeuralNet.Click
        Dim result As Boolean = ImportNework()
        MsgBox(String.Format("Importing Neural Network = [{0}]", result), MsgBoxStyle.Information)
        PrptyGrdNeuralNet.SelectedObject = NeuralNetEngine
        PrptyGrdNeuralNet.Refresh()
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
                    .Filter = "ANN1 files (*.ANN1)|*.ANN1"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            NeuralNetEngine = NeuralNetworksEngine.Load(fileName)

            result = True
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function


End Class