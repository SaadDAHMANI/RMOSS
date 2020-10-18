Option Strict On
Imports IOOperations.Components

Public Class ANNsTimeSeriesForm
    Dim DataSerie As DataSerie1D

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

End Class