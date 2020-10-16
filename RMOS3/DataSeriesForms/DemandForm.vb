Option Strict On
Imports IOOperations

Public Class DemandForm
    Dim Ds1 As Components.DataSerie1D

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            MainModule.Import_Data(Ds1)
            LoadData(Ds1)
            If (Equals(TheReservoir, Nothing)) Then
                TheReservoir = New RmosEngine.HydComponents.Reservoir()
            End If

            TheReservoir.Downstream = Ds1

        Catch ex As Exception
            Throw ex
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnShowGraphics_Click(sender As Object, e As EventArgs) Handles BtnShowGraphics.Click
        Me.Cursor = Cursors.WaitCursor
        DrawDataGraphic(Ds1)
        Me.Cursor = Cursors.Default
    End Sub

#Region "Subs_Functions"
    Private Sub LoadData(ByRef ds As IOOperations.Components.DataSerie1D)
        Try
            If IsNothing(ds.Data) Then Return
            If ds.Data.Count > 0 Then

                ShowData(ds)
                ''--------------Add data to Global list :--------------------------------
                'If IsNothing(MainModule.List_DemandsSeries) Then
                '    MainModule.List_DemandsSeries = New List(Of Components.DataSerie1D)
                'End If
                'MainModule.List_DemandsSeries.Add(ds)

                '------------------------------------------------------------------------
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShowData(ByRef ds As IOOperations.Components.DataSerie1D)
        If IsNothing(ds) Then Return
        If IsNothing(ds.Data) Then Return
        Try
            With DgvData
                .DataSource = ds.Data
            End With
            ProprtyGrdDataSerie.SelectedObject = ds

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DrawDataGraphic(ByRef ds1 As IOOperations.Components.DataSerie1D)
        If IsNothing(ds1) Then Return
        If IsNothing(ds1.Data) Then Return

        Try
            Dim serie As New System.Windows.Forms.DataVisualization.Charting.Series("Inflows [Qi]")
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

    Private Sub DemandForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(TheReservoir.Downstream) = False Then
            CmbDataSeries.Items.Add(TheReservoir.Downstream.Name)
        Else

            CmbDataSeries.Text = "No Data"
            End If

    End Sub

    Private Function Minimum(ByRef ds1 As Components.DataSerie1D) As Double
        If IsNothing(ds1.Data) Then Return 0
        Dim min As Double = Double.MaxValue
        For Each itm In ds1.Data
            If itm.X_Value < min Then
                min = itm.X_Value
            End If
        Next
        Return Math.Round(min, 3)
    End Function

    Private Function Maximum(ByRef ds1 As Components.DataSerie1D) As Double
        If IsNothing(ds1.Data) Then Return 0
        Dim min As Double = Double.MinValue
        For Each itm In ds1.Data
            If itm.X_Value > min Then
                min = itm.X_Value
            End If
        Next
        Return Math.Round(min, 3)
    End Function

    Private Sub CmbDataSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDataSeries.SelectedIndexChanged
        ShowData(TheReservoir.Downstream)
    End Sub
#End Region
End Class