Option Strict On
Imports ForecastingEngine.NeuralNetworks
Imports IOOperations.Components

Public Class ANNTestForm
    Private AnnOptimizer As New OptimizedNeuralNetwok()

    Private AnnTester As New ANNTest()

    Private Alpha As Double = 1

    Private Sub CmbActivationFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbActivationFunction.SelectedIndexChanged
        Alpha = Double.Parse(TxtBxAlpha.Text)
        DrawActivationfunction(CmbActivationFunction.SelectedIndex)

    End Sub

    Private Sub DrawActivationfunction(ByRef index As Integer)
        If index < 0 Then Return
        Dim serie As New DataVisualization.Charting.Series()
        Dim i As Integer = 0
        Dim x, y As Double

        Select Case (index)
            Case 0
                serie.Name = "Sigmoid"
                For i = 0 To 100
                    x = (i / 10) - 5
                    y = 1 / (1 + ((Math.E) ^ (-1 * Alpha * x)))
                    serie.Points.AddXY(x, y)
                Next

            Case 1
                serie.Name = "Bipolar Sigmoid"
                For i = 0 To 100
                    x = (i / 10) - 5
                    y = (2 / (1 + ((Math.E) ^ (-1 * Alpha * x)))) - 1
                    serie.Points.AddXY(x, y)
                Next

            Case 2
                serie.Name = "Linear"

                For i = 0 To 100
                    x = (i / 10) - 5
                    y = (Alpha * x)
                    If y < -1 Then y = -1
                    If y > 1 Then y = 1
                    serie.Points.AddXY(x, y)
                Next

        End Select

        Try

            With serie
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                '.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                '.MarkerSize = 7
                '.Color = Color.Navy
            End With

            With Chart1.Series
                .Clear()
                .Add(serie)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TxtBxAlpha_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBxAlpha.KeyDown
        If (e.KeyCode = Keys.Return) Then
            Alpha = Double.Parse(TxtBxAlpha.Text)
            DrawActivationfunction(CmbActivationFunction.SelectedIndex)
        End If
    End Sub

    Private Sub BtnCompute_Click(sender As Object, e As EventArgs) Handles BtnCompute.Click



        BtnCompute.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        '--------------------------------------------------------------

        If IsNothing(AnnTester) = False Then
            AnnTester.Compute()
        End If
        '--------------------------------------------------------------
        BtnCompute.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ANNTestForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        PropertyGrid1.SelectedObject = AnnTester
        OptimPropertyGrid.SelectedObject = AnnOptimizer

    End Sub

    Private Sub BtnOptimizeANN_Click(sender As Object, e As EventArgs) Handles BtnOptimizeANN.Click
        Me.Cursor = Cursors.WaitCursor

        Dim S3input As New IOOperations.Components.DataSerieTD()
        Dim S1Output As New IOOperations.Components.DataSerie1D()
        With S3input
            .Add("1", 0, 0)
            .Add("2", 0, 1)
            .Add("3", 1, 0)
            .Add("4", 1, 1)
            '----------------
            .Add("5", 1, 0)
            .Add("6", 1, 0)
            .Add("7", 0, 0)
        End With

        With S1Output
            .Add("1", 0)
            .Add("2", 1)
            .Add("3", 1)
            .Add("4", 0)
            '--------------
            .Add("5", 1)
            .Add("6", 1)
            .Add("7", 0)
        End With

        With AnnOptimizer
            .Obs_TrainingInputs = S3input
            .Obs_TrainingOutputs = S1Output

        End With

        AnnOptimizer.Compute()

        LbxSolutionsHistory.Items.Clear()
        If IsNothing(AnnOptimizer.Couple_Solution_Fitness) = False Then

            For Each sf In AnnOptimizer.Couple_Solution_Fitness
                LbxSolutionsHistory.Items.Add(String.Format("Solution: {0} || Fitness = {1}.", sf.Key, sf.Value))
            Next

        Else
            LbxSolutionsHistory.Items.Add(String.Format("{0} || Best Fitness : {1}", AnnOptimizer.Best_Solution.Data2String("int"), AnnOptimizer.Best_Chart.Min))
        End If

        DrawDataGraphic(AnnOptimizer.Best_Chart, Chart2)

        MsgBox("Computation completed", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

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
                .MarkerSize = 2
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim monthIndex As Integer
        Dim m As Integer
        monthIndex = Math.DivRem(13, 12, m)
        MsgBox(m.ToString(), MsgBoxStyle.Information)

    End Sub
End Class