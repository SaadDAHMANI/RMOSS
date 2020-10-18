Option Strict On
Imports IOOperations
Imports IOOperations.Components
Imports ForecastingEngine.NeuralNetworks
Public Class ANNsTimeSeriesForm
    Dim DataSerie As DataSerie1D

    Private AnnDataFormator As New ForecastingEngine.AnnTimeSeriesFomator()
    Private NeuralNetEO As NeuralNetworksEngineEO
    Private NeuralNetStructure As DataSerie1D

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

    Private Sub ANNsTimeSeriesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CmbInputsFileType.Items.Clear()
        For i = 0 To 1
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
        NeuralNetEO.ActivationFunction = ActivationFunctionEnum.SigmoidFunction
        NeuralNetEO.LearningAlgorithm = LearningAlgorithmEnum.LevenbergMarquardtLearning
        PrtyGrdNeuralNet.SelectedObject = NeuralNetEO

        '---------------------------------------------------
        'PrtGrdAnnOptimizer.SelectedObject = AnnOptimizer
        '---------------------------------------------------
        'If Not Equals(SequentialForecaster, Nothing) Then
        'PrtyGrdForecasting.SelectedObject = SequentialForecaster
        'End If

    End Sub

    Private Sub BtnFormateDataSerie_Click(sender As Object, e As EventArgs) Handles BtnFormateDataSerie.Click
        With AnnDataFormator
            .Data = DataSerie
            .Formate()
        End With

        DrawDataGraphic(AnnDataFormator.Training_Outputs, Chart1)
        DrawDataGraphic(AnnDataFormator.Testing_Outputs, Chart2)
    End Sub
End Class