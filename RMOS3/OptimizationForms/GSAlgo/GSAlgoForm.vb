Option Strict On
Imports System.ComponentModel
Imports RmosEngine.GravitationalSearchAlgorithm

Public Class GSAlgoForm
    Dim Index_InflowSerie As Integer = 0I
    Dim Index_DemandsSerie As Integer = 0I

    Dim Storage_Result As IOOperations.Components.DataSerie1D = Nothing
    Dim Release_Result As IOOperations.Components.DataSerie1D = Nothing

    Private Sub GSAlgoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try

            If IsNothing(GSA_Engine) Then
                GSA_Engine = New GSAEngine() With {.OptimizationType = RmosEngine.OptimizationTypeEnum.Minimization}
            End If
            With GSA_Engine
                GSA_Engine.Agents_N = 10
                .TotalTimePeriod = 36
                .G0_Value = 20
                .Alpha = 10
                .Max_Iteration = 300
                GSA_Engine.Initial_Storage = 117.543
                GSA_Engine.Min_Storage = 23
            End With

            PropertyGrd.SelectedObject = GSA_Engine

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
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnLuanchOptimization_Click(sender As Object, e As EventArgs) Handles BtnLuanchOptimization.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            With GSA_Engine
                '.Reset()
                .Reservoir = TheReservoir
                .InflowSerie = TheReservoir.Inflow
                .Demands = TheReservoir.Downstream
                '--------------------------------------------------
                .Luanch_Optimization()
                '--------------------------------------------------
            End With

            MsgBox(String.Format("End of computation... Duration = {0} Ms.", GSA_Engine.ComputationTime), MsgBoxStyle.Information)

            If IsNothing(GSA_Engine.Release) = False Then
                If IsNothing(GSA_Engine.Release.Data) = False Then
                    If IsNothing(GSA_Engine.Storage) = False Then
                        If IsNothing(GSA_Engine.Storage.Data) = False Then

                            Storage_Result = GSA_Engine.Storage
                            Release_Result = GSA_Engine.Release
                            ShowData()
                            ShowDataGraphics(Release_Result, GSA_Engine.Demands, Chart_RD)
                            ShowDataGraphics(Storage_Result, Chart_S)

                            BtnShowGraphics.Focus()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Debug.Print(ex.StackTrace)
            Debug.Print("----------------------------------------###")
            Debug.Print(ex.InnerException.StackTrace)
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
            serie1.MarkerSize = 10
            serie2.ChartType = DataVisualization.Charting.SeriesChartType.Line
            serie2.Color = System.Drawing.Color.Crimson
            serie2.MarkerSize = 10

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
            serie.MarkerSize = 10

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

        With GSA_Engine
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

                .Item(7, i).Value = GSA_Engine.Evaporation.Data(i).X_Value
                .Item(8, i).Value = GSA_Engine.Infiltration.Data(i).X_Value

                i += 1
            Next

        End With
    End Sub

#End Region

    Private Sub BtnShowGraphics_Click(sender As Object, e As EventArgs) Handles BtnShowGraphics.Click
        Try
            ShowDataGraphics(Release_Result, GSA_Engine.Demands, Chart_RD)
            ShowDataGraphics(Storage_Result, Chart_S)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CmbInflowSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbInflowSeries.SelectedIndexChanged
        If CmbInflowSeries.SelectedIndex >= 0 Then
            Index_InflowSerie = CmbInflowSeries.SelectedIndex
        End If
    End Sub

    Private Sub CmbDemands_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDemands.SelectedIndexChanged
        If CmbDemands.SelectedIndex >= 0 Then
            Index_DemandsSerie = CmbDemands.SelectedIndex
        End If
    End Sub

    Private Sub TsmiShowTables_Click(sender As Object, e As EventArgs) Handles TsmiShowTables.Click
        Try
            Dim tablesFrm As New TablesForm With {
                .OptimizationEngine = GSA_Engine,
                .MdiParent = MainForm
            }
            tablesFrm.Text = "Results (GSA)"
            MainForm.Show_Window(CType(tablesFrm, Form))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TsmiShowGraphics_Click(sender As Object, e As EventArgs) Handles TsmiShowGraphics.Click
        Try
            Dim graphicsFrm As New GraphicsForm With {
                .OptimizationEngine = GSA_Engine,
                .MdiParent = MainForm
            }
            graphicsFrm.Text = "Results (GSA)"
            MainForm.Show_Window(CType(graphicsFrm, Form))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSAlgoForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim msgResult = MsgBox("Do you want to Save [GSA] Optimization Engine for next operation", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "GSA")
        If msgResult = MsgBoxResult.No Then
            MainModule.GSA_Engine = Nothing
            e.Cancel = False
        ElseIf msgResult = MsgBoxResult.Cancel Then
            e.Cancel = True
        End If
    End Sub
End Class