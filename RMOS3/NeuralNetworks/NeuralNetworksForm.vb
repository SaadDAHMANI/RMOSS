Imports IOOperations
Imports IOOperations.Components
Imports ForecastingEngine.NeuralNetworks

Public Class NeuralNetworksForm
    Private ANNet As New NeuralNetworksEngine()

    Private TrainingInput As DataSerieTD
    Private TrainingOutputDS1 As DataSerie1D

    Private TestingInput As DataSerieTD
    Private TestingOutput As DataSerie1D

    REM--------------------------------------------------------------------------------------------------

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowseInputs.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = "CSV files (*.csv)|*.csv"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return

            LoadData(fileName, TrainingInput, PrtyGrdTrainInputData)

            ShowData(TrainingInput, DgvTrainInputsData)

        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnShowGraphics_Click(sender As Object, e As EventArgs) Handles BtnShowTrainGraphics.Click
        Me.Cursor = Cursors.WaitCursor
        DrawDataGraphic(TrainingOutputDS1, TrainingInput)
        Me.Cursor = Cursors.Default
    End Sub

#Region "Subs_Functions"

    Private Sub LoadData(ByRef fileName As String, ByRef ds As DataSerie1D, ByRef prptyGrd As PropertyGrid)
        Try
            If FileIO.FileSystem.FileExists(fileName) Then
                Dim reader As New CsvFileIO(fileName)
                ds = reader.Read_DS1()

                If IsNothing(ds.Data) Then Return

                If ds.Data.Count > 0 Then

                    prptyGrd.SelectedObject = ds
                    '------------------------------------------------------------------------
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadData(ByRef fileName As String, ByRef ds As DataSerie2D, ByRef prptyGrd As PropertyGrid)
        Try
            If FileIO.FileSystem.FileExists(fileName) Then
                Dim reader As New CsvFileIO(fileName)

                ds = reader.Read_DS2()

                If IsNothing(ds.Data) Then Return

                If ds.Data.Count > 0 Then

                    prptyGrd.SelectedObject = ds
                    '------------------------------------------------------------------------
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadData(ByRef fileName As String, ByRef ds As DataSerieTD, ByRef prptyGrd As PropertyGrid)
        Try
            If FileIO.FileSystem.FileExists(fileName) Then
                Dim reader As New CsvFileIO(fileName)

                ds = reader.Read_DST()

                If IsNothing(ds.Data) Then Return

                If ds.Data.Count > 0 Then

                    prptyGrd.SelectedObject = ds
                    '------------------------------------------------------------------------
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShowData(ByRef ds1 As Components.DataSerie1D)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return
        Try
            With DgvTrainInputsData
                .DataSource = ds1.Data
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ShowData(ByRef ds As DataSerie1D, ByRef dgView As DataGridView)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
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
        Dim iCount As Integer = ds.Data.Count()
        Dim jCount As Integer = ds.Data(0).List.Count()

        'If iCount > 0 Then
        '    With dgView
        '        '     .Columns.Clear()
        '        For j As Integer = 0 To jCount
        '            .Columns.Add(New DataGridViewColumn())
        '        Next
        '        .Rows.Add(iCount)
        '        For i As Integer = 0 To (iCount - 1)
        '            .Item(0, i).Value = ds.Data(i).Title
        '        Next
        '    End With
        'End If

        Try
            With dgView
                .DataSource = ds.Data
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DrawDataGraphic(ByRef ds1 As IOOperations.Components.DataSerie1D)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return

        Try
            Dim serie As New DataVisualization.Charting.Series("Inflows [Qi]")
            Dim i As Integer = 0
            If ds1.Data.Count > 0 Then
                For Each ditm1 In ds1.Data
                    serie.Points.AddXY(i, ditm1.X_Value)
                    i += 1
                Next
            End If
            serie.ChartType = DataVisualization.Charting.SeriesChartType.Line

            With ChartData.Series
                .Clear()
                .Add(serie)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DrawDataGraphic(ByRef ds2 As IOOperations.Components.DataSerie2D)
        If IsNothing(ds2) Then Return
        If IsNothing(ds2.Data) Then Return

        Try
            Dim serie As New DataVisualization.Charting.Series(ds2.X_Title)
            Dim serie1 As New DataVisualization.Charting.Series(ds2.Y_Title)
            Dim i As Integer = 0
            If ds2.Data.Count > 0 Then
                For Each ditm1 In ds2.Data
                    serie.Points.AddXY(i, ditm1.X_Value)
                    serie1.Points.AddXY(i, ditm1.Y_Value)
                    i += 1
                Next
            End If
            serie.ChartType = DataVisualization.Charting.SeriesChartType.Line

            With ChartData.Series
                .Clear()
                .Add(serie)
                .Add(serie1)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DrawDataGraphic(ByRef ds_1 As DataSerie1D, ByRef ds_2 As DataSerieTD)

        'If IsNothing(ds_2) Then Return
        'If IsNothing(ds_2.Data) Then Return

        'Try

        '    Dim serie As New DataVisualization.Charting.Series(ds_2.X_Title)
        '    Dim serie1 As New DataVisualization.Charting.Series(ds_2.Y_Title)
        '    Dim serie3 As New DataVisualization.Charting.Series(ds_1.X_Title)

        '    Dim i As Integer = 0
        '    If ds_2.Data.Count > 0 Then
        '        For Each ditm1 In ds_2.Data
        '            serie.Points.AddXY(i, ditm1.X_Value)
        '            serie1.Points.AddXY(i, ditm1.Y_Value)
        '            serie3.Points.AddXY(i, ds_1.Data(i).X_Value)
        '            i += 1
        '        Next
        '    End If
        '    serie.ChartType = DataVisualization.Charting.SeriesChartType.Line

        '    With ChartData.Series
        '        .Clear()
        '        .Add(serie)
        '        .Add(serie1)
        '        .Add(serie3)

        '    End With

        'Catch ex As Exception
        '    Throw ex
        'End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnLuanchLearning.Click
        Cursor = Cursors.WaitCursor

        Dim netStruct As New DataSerie1D()
        With netStruct
            .Add("Layer 1", 4)
            .Add("Layer 2", 3)
            .Add("Layer 3", 1)
        End With

        With ANNet

            .TeachingError = 0.01
            .TrainingInputs = TrainingInput
            .TrainingOutputs_DS1 = TrainingOutputDS1

            .LayersStruct = netStruct

            .ActivationFunction = ActivationFunctionEnum.SigmoidFunction
            .LuanchLearning()
            TextBox2.Text = .Iterations.ToString()
        End With

        PropertyGrid1.SelectedObject = ANNet


        'Dim test() As Double = {0.3, 0.4}

        'Dim result = ANNet.Compute(test)

        'Dim itm As String = ""

        'For Each elmt In result
        '    itm += elmt.ToString() + "  "
        'Next

        'TextBox1.Text = itm

        Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim count As Int32 = 12

        Dim rand As New Random()
        Dim data As New List(Of Double())
        Dim result As New List(Of Double)

        For i As Integer = 0 To count
            Dim tmp(1) As Double
            tmp(0) = rand.NextDouble()
            tmp(1) = rand.NextDouble()
            data.Add(tmp)
            'Debug.Print(tmp(0).ToString() + " , " + tmp(1).ToString())
            result.Add(tmp(1))
        Next

        Dim resultAnn As New List(Of Double)
        Dim value As Double = 0
        For i As Integer = 0 To count
            Dim restmp = ANNet.Compute(data(i))
            value = restmp(0)
            resultAnn.Add(value)
        Next

        Dim seri1 As New DataVisualization.Charting.Series("Real") With {.ChartType = DataVisualization.Charting.SeriesChartType.Line}
        Dim seri2 As New DataVisualization.Charting.Series("ANN") With {.ChartType = DataVisualization.Charting.SeriesChartType.Line}


        With seri1
            .Color = Color.Crimson
            .MarkerSize = 10
        End With

        With seri2
            .Color = Color.Blue
            .MarkerSize = 10
        End With

        For i As Integer = 0 To count
            seri1.Points.AddXY(i, result(i))
            seri2.Points.AddXY(i, resultAnn(i))
        Next

        Chart1.Series.Clear()

        Chart1.Series.Add(seri1)
        Chart1.Series.Add(seri2)

    End Sub

    Private Sub BtnBrowseOutData_Click(sender As Object, e As EventArgs) Handles BtnBrowseOutData.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = "CSV files (*.csv)|*.csv"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return

            LoadData(fileName, TrainingOutputDS1, PrtyGrdTrainOutData)

            ShowData(TrainingOutputDS1, DgvTrainOutData)

        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub NeuralNetworksForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#End Region

End Class