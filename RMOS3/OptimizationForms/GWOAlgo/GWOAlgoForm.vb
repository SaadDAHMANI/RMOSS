Option Strict On
Imports System.ComponentModel
Imports RmosEngine.GreyWolfOptimizer

Public Class GWOAlgoForm
    Dim Index_InflowSerie As Integer = 0I
    Dim Index_DemandsSerie As Integer = 0I

    Dim Storage_Result As IOOperations.Components.DataSerie1D = Nothing
    Dim Release_Result As IOOperations.Components.DataSerie1D = Nothing

    Private Sub GWOForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            'If IsNothing(GWO_Engine) Then
            GWO_Engine = New GWOEngine() With {.TotalTimePeriod = 36, .Agents_N = 10, .Max_Iteration = 100, .OptimizationType = RmosEngine.OptimizationTypeEnum.Minimization}
            'End If

            PropertyGrd.SelectedObject = GWO_Engine

            If IsNothing(TheReservoir) = False Then
                If IsNothing(TheReservoir.Inflow) = False Then
                    CmbInflowSeries.Items.Add(TheReservoir.Inflow.Name)
                    CmbInflowSeries.SelectedIndex = 0
                End If
            End If

            If IsNothing(TheReservoir.Downstream) = False Then
                CmbDemands.Items.Add(TheReservoir.Downstream.Name)
                CmbDemands.SelectedIndex = 0
            End If


        Catch ex As Exception
            Throw ex
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnLuanchOptimization_Click(sender As Object, e As EventArgs) Handles BtnLuanchOptimization.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            BtnLuanchOptimization.Enabled = False

            With GWO_Engine
                .Reservoir = TheReservoir
                .InflowSerie = TheReservoir.Inflow
                .Demands = TheReservoir.Downstream
                '--------------------------------------------------
                .Luanch_Optimization()
                '--------------------------------------------------
            End With

            MsgBox(String.Format("End of computation... Duration = {0} Ms.", GWO_Engine.ComputationTime), MsgBoxStyle.Information)

            BtnLuanchOptimization.Enabled = True

            If IsNothing(GWO_Engine.Release) = False Then
                If IsNothing(GWO_Engine.Release.Data) = False Then
                    If IsNothing(GWO_Engine.Storage) = False Then
                        If IsNothing(GWO_Engine.Storage.Data) = False Then

                            Storage_Result = GWO_Engine.Storage
                            Release_Result = GWO_Engine.Release

                            ShowData()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#Region "Subs_functions"

    Private Sub ShowDataGraphics(ByRef ds1 As IOOperations.Components.DataSerie1D, ByRef ds2 As IOOperations.Components.DataSerie1D, ByRef chart As DataVisualization.Charting.Chart)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return

        If IsNothing(ds2) Then Return
        If IsNothing(ds2.Data) Then Return

        If IsNothing(chart) Then Return

        Try
            Dim serie1 As New DataVisualization.Charting.Series(ds1.Name)
            Dim serie2 As New DataVisualization.Charting.Series(ds2.Name)

            Dim i As Integer = 0
            If ds1.Data.Count > 0 Then
                For Each ditm1 In ds1.Data
                    serie1.Points.AddXY(i, ditm1.X_Value)
                    serie2.Points.AddXY(i, ds2.Data(i).X_Value)
                    i += 1
                Next
            End If
            serie1.ChartType = DataVisualization.Charting.SeriesChartType.Line
            serie2.ChartType = DataVisualization.Charting.SeriesChartType.Line
            serie2.Color = System.Drawing.Color.Crimson

            chart.Series.Clear()
            chart.Series.Add(serie1)
            chart.Series.Add(serie2)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ShowDataGraphics(ByRef ds1 As IOOperations.Components.DataSerie1D, ByRef chart As DataVisualization.Charting.Chart)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return
        If IsNothing(chart) Then Return

        Try
            Dim serie As New DataVisualization.Charting.Series(ds1.Name)
            Dim i As Integer = 0
            If ds1.Data.Count > 0 Then
                For Each ditm1 In ds1.Data
                    serie.Points.AddXY(i, ditm1.X_Value)
                    i += 1
                Next
            End If
            serie.ChartType = DataVisualization.Charting.SeriesChartType.Line

            If IsNothing(chart) Then Return
            chart.Series.Clear()
            chart.Series.Add(serie)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ShowData()

        Dim resultRS As IOOperations.Components.DataSerie5D

        resultRS = New IOOperations.Components.DataSerie5D()

        Dim monthCounter As Integer = 1
        Dim yearCounter As Integer = 1

        Dim i As Integer = 0

        With GWO_Engine
            For Each rItm In .Release.Data
                resultRS.Add(String.Format("Y- {0} | {1}", yearCounter, monthCounter), .Demands.Data(i).X_Value, rItm.X_Value, .InflowSerie.Data(i).X_Value, .Storage.Data(i).X_Value, .OverFlow.Data(i).X_Value) '(rItm.Title, rItm.X_Value, GsaEngine.Storage.Data(i).X_Value)
                i += 1
                monthCounter += 1
                If monthCounter > 12 Then
                    monthCounter = 1
                    yearCounter += 1
                End If
            Next
        End With

        '---------------------------------------------------------------
        If resultRS.Data.Count < 1 Then
            MsgBox("No results", MsgBoxStyle.Information)
            Return
        End If

        i = 0I
        With DgvResults
            .Rows.Clear()
            .Rows.Add((resultRS.Data.Count + 1))

            For Each itm In resultRS.Data
                .Item(0, i).Value = i.ToString()
                .Item(1, i).Value = itm.Title
                .Item(2, i).Value = itm.A_Value
                .Item(3, i).Value = itm.B_Value
                .Item(4, i).Value = itm.C_Value
                .Item(5, i).Value = itm.D_Value
                .Item(6, i).Value = itm.E_Value

                .Item(7, i).Value = GWO_Engine.Evaporation.Data(i).X_Value
                .Item(8, i).Value = GWO_Engine.Infiltration.Data(i).X_Value
                i += 1
            Next
        End With
        BtnShowGraphics_Click(Me, New EventArgs)
        'MsgBox("End of showing data..", MsgBoxStyle.Information, "ShowData()")
    End Sub
#End Region

    Private Sub BtnShowGraphics_Click(sender As Object, e As EventArgs) Handles BtnShowGraphics.Click
        Try
            ShowDataGraphics(Release_Result, GWO_Engine.Demands, Chart_RD)
            ShowDataGraphics(Storage_Result, Chart_S)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CmbDemands_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDemands.SelectedIndexChanged
        If CmbDemands.SelectedIndex >= 0 Then
            Index_DemandsSerie = CmbDemands.SelectedIndex
        End If
    End Sub

    Private Sub CmbInflowSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbInflowSeries.SelectedIndexChanged
        If CmbInflowSeries.SelectedIndex >= 0 Then
            Index_InflowSerie = CmbInflowSeries.SelectedIndex
        End If
    End Sub

    Private Sub GWOForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim msgResult = MsgBox("Do you want to Save [GWO] Optimization Engine for next operation", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "GWO")
        If msgResult = MsgBoxResult.No Then
            MainModule.GWO_Engine = Nothing
            e.Cancel = False
        ElseIf msgResult = MsgBoxResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TsmiShowGraphics_Click(sender As Object, e As EventArgs) Handles TsmiShowGraphics.Click
        Dim graphicsFrm = New GraphicsForm()
        graphicsFrm.OptimizationEngine = GWO_Engine
        MainForm.Show_Window(CType(graphicsFrm, Form))
    End Sub


End Class