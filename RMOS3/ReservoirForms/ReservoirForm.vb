Imports RmosEngine.HydComponents
Imports IOOperations.Components

Public Class ReservoirForm
    Private Sub ReservoirForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Equals(TheReservoir, Nothing) Then TheReservoir = New RmosEngine.HydComponents.Reservoir
        Me.Text = String.Format("Reservoir : [{0}]", TheReservoir.Name)
        PrtyGrdReservoir.SelectedObject = TheReservoir

    End Sub

    Private Sub BtnReservoirsCurves_Click(sender As Object, e As EventArgs) Handles BtnReservoirsCurves.Click
        Dim curvesFrm As New CurvesForm
        curvesFrm.MdiParent = MainForm
        MainForm.MainSplitContainer.Panel1.Controls.Add(curvesFrm)
        curvesFrm.Show()
        curvesFrm.Focus()
    End Sub


#Region "Subs_Functions"
    Private Sub SynchonizeData(ByRef dSerie As DataSerie2D, ByRef dgv As DataGridView, ByRef chart As DataVisualization.Charting.Chart)
        Try
            If IsNothing(dgv) Then Return
            If IsNothing(dSerie) Then Return
            If IsNothing(dSerie.Data) Then Return
            If dSerie.Data.Count = 0 Then Return

            Dim rsCount As Integer = dSerie.Data.Count
            Dim chartSerie As New DataVisualization.Charting.Series(dSerie.Name)
            chartSerie.ChartType = DataVisualization.Charting.SeriesChartType.Line

            With dgv
                .Rows.Clear()
                .Rows.Add(rsCount)
                For i = 0 To (rsCount - 1)
                    .Item(0, i).Value = dSerie.Data(i).X_Value
                    .Item(1, i).Value = dSerie.Data(i).Y_Value
                Next
            End With

            For i = 0 To (rsCount - 1)
                chartSerie.Points.AddXY(dSerie.Data(i).X_Value, dSerie.Data(i).Y_Value)
            Next
            chart.Series.Clear()
            chart.Series.Add(chartSerie)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SynchonizeData(ByRef dSerie As DataSerie1D, ByRef dgv As DataGridView, ByRef chart As DataVisualization.Charting.Chart)
        Try
            If IsNothing(dgv) Then Return
            If IsNothing(dSerie) Then Return
            If IsNothing(dSerie.Data) Then Return
            If dSerie.Data.Count = 0 Then Return

            Dim rsCount As Integer = dSerie.Data.Count
            Dim chartSerie As New DataVisualization.Charting.Series(dSerie.Name)
            chartSerie.ChartType = DataVisualization.Charting.SeriesChartType.Line

            With dgv
                .Rows.Clear()
                .Rows.Add(rsCount)
                For i = 0 To (rsCount - 1)
                    .Item(0, i).Value = dSerie.Data(i).Title
                    .Item(1, i).Value = dSerie.Data(i).X_Value
                Next
            End With

            For i = 0 To (rsCount - 1)
                chartSerie.Points.AddXY(i, dSerie.Data(i).X_Value)
            Next
            chart.Series.Clear()
            chart.Series.Add(chartSerie)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex

            Case 1
                SynchonizeData(TheReservoir.ElevationVolume_Curve, DgvCurveHV, ChartCrveHV)
            Case 2
                SynchonizeData(TheReservoir.ElevationArea_Curve, DgvCurveHS, ChartCrveHS)
            Case 3
                SynchonizeData(TheReservoir.EvaporationRates, DgvCurveEvaporation, ChartCrveEvaporation)
            Case 4
                SynchonizeData(TheReservoir.InfiltrationRates, DgvCurveInfiltration, ChartCrveInfiltration)
            Case 5
                SynchonizeData(TheReservoir.Inflow, DgvInflow, Chart1)
                If (Not Equals(TheReservoir.Inflow, Nothing)) Then
                    TxtBxInflowDsName.Text = TheReservoir.Inflow.Name
                    TxtBxInflowDsDescription.Text = TheReservoir.Inflow.Description
                End If
            Case 6
                SynchonizeData(TheReservoir.Downstream, DgvDownstream, Chart2)
            Case Else
                Exit Select
        End Select
    End Sub

    Private Sub ReservoirForm_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        Try
            If (Equals(MainModule.TheReservoir, Nothing)) Then
                TxtBxReservoirName.Text = "no reservoir defined"
                TxtBxInflowSeries.Text = "n/a"
                TxtBxDownstream.Text = "n/a"
            Else
                TxtBxReservoirName.Text = TheReservoir.Name
                If (Equals(TheReservoir.Inflow, Nothing)) Then
                    TxtBxInflowSeries.Text = "n/a"
                Else
                    TxtBxInflowSeries.Text = TheReservoir.Inflow.Name
                End If
                If (Equals(TheReservoir.Downstream, Nothing)) Then
                    TxtBxDownstream.Text = "n/a"
                Else
                    TxtBxDownstream.Text = TheReservoir.Downstream.Name
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class