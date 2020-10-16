Option Strict On
Imports IOOperations.Components

Public Class CurvesForm
    Dim Ds2Crv As DataSerie2D

    Private Sub CmbMarkerSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMarkerSize.SelectedIndexChanged
        SynchonizeGraphics(Ds2Crv, ChartCrv)
    End Sub

    Private Sub CurvesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CmbMarkerSize.Items.Clear()
        For i = 1 To 28
            CmbMarkerSize.Items.Add(i.ToString())
        Next

        If IsNothing(TheReservoir) Then Return

        If IsNothing(TheReservoir.ElevationVolume_Curve) = False Then
            CmbExistanteCurves.Items.Add(TheReservoir.ElevationVolume_Curve.Name)
        End If

        If IsNothing(TheReservoir.ElevationArea_Curve) = False Then
            CmbExistanteCurves.Items.Add(TheReservoir.ElevationArea_Curve.Name)
        End If

    End Sub

    Private Sub DgvData_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvData.CellEndEdit
        If Equals(DgvData.Item(e.ColumnIndex, e.RowIndex), Nothing) = False Then
            SynchonizeData(Ds2Crv, DgvData)
            SynchonizeGraphics(Ds2Crv, ChartCrv)
        End If
    End Sub

    Private Sub SynchonizeData(ByRef dSerie As DataSerie2D, ByRef dgv As DataGridView)
        Try
            Dim rdCount As Integer = (dgv.Rows.Count - 1)
            Dim rsCount As Integer = dSerie.Data.Count
            Dim value As Double = 0R
            Dim isConverted As Boolean = False

            If rdCount > rsCount Then
                For i As Integer = 0 To (rsCount - 1)
                    If IsNothing(dgv.Item(1, i).Value) = False Then

                        isConverted = Double.TryParse(dgv.Item(1, i).Value.ToString(), value)

                        If isConverted Then
                            dSerie.Data(i).X_Value = value
                        Else
                            dSerie.Data(i).X_Value = 0R
                        End If
                    Else
                        dSerie.Data(i).X_Value = 0R
                    End If

                    If IsNothing(dgv.Item(2, i).Value) = False Then
                        isConverted = Double.TryParse(dgv.Item(2, i).Value.ToString(), value)
                        If isConverted Then
                            dSerie.Data(i).Y_Value = value
                        Else
                            dSerie.Data(i).Y_Value = 0R
                        End If
                    Else
                        dSerie.Data(i).Y_Value = 0R
                    End If

                Next

                Dim dsItem As DataItem2D

                For i As Integer = rsCount To (rdCount - 1)
                    dsItem = New DataItem2D()

                    If IsNothing(dgv.Item(1, i).Value) = False Then
                        isConverted = Double.TryParse(dgv.Item(1, i).Value.ToString(), value)
                        If isConverted Then
                            dsItem.X_Value = value
                        Else
                            dsItem.X_Value = 0R
                        End If

                    End If

                    If IsNothing(dgv.Item(2, i).Value) = False Then
                        isConverted = Double.TryParse(dgv.Item(2, i).Value.ToString(), value)
                        If isConverted Then
                            dsItem.Y_Value = value
                        Else
                            dsItem.Y_Value = 0R
                        End If
                    End If

                    dSerie.Add(dsItem)
                Next

            ElseIf rdCount < rsCount Then

                dSerie.Data.RemoveRange((rdCount - 1), (rsCount - rdCount))

            Else

                For i As Integer = 0 To (rsCount - 1)

                    If IsNothing(dgv.Item(1, i).Value) = False Then
                        isConverted = Double.TryParse(dgv.Item(1, i).Value.ToString(), value)
                        If isConverted Then
                            dSerie.Data(i).X_Value = value
                        Else
                            dSerie.Data(i).X_Value = 0R
                        End If

                    End If

                    If IsNothing(dgv.Item(2, i).Value) = False Then
                        isConverted = Double.TryParse(dgv.Item(2, i).Value.ToString(), value)
                        If isConverted Then
                            dSerie.Data(i).Y_Value = value
                        Else
                            dSerie.Data(i).Y_Value = 0R
                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SynchonizeGraphics(ByRef dSerie As DataSerie2D, ByRef chart As DataVisualization.Charting.Chart)
        Try
            If IsNothing(dSerie) Then Return
            If IsNothing(dSerie.Data) Then Return
            If dSerie.Data.Count = 0 Then Return

            Dim rsCount = dSerie.Data.Count
            If rsCount > 0 Then
                Dim serie As New DataVisualization.Charting.Series()
                serie.Name = dSerie.Name

                For i As Integer = 0 To (rsCount - 1)
                    serie.Points.AddXY(dSerie.Data(i).X_Value, dSerie.Data(i).Y_Value)
                Next

                serie.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                serie.MarkerSize = (CmbMarkerSize.SelectedIndex + 1)
                serie.ChartType = DataVisualization.Charting.SeriesChartType.Spline

                chart.Series.Clear()
                chart.Series.Add(serie)

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DisplayData(ByRef dSerie As DataSerie2D, ByRef dgv As DataGridView)
        Try
            If IsNothing(dSerie) Then Return
            If IsNothing(dSerie.Data) Then Return
            If dSerie.Data.Count = 0 Then Return
            Dim rsCount = dSerie.Data.Count

            TxtCurveName.Text = String.Format("{0} / {1}", dSerie.Name, dSerie.Description)

            With dgv
                .Rows.Clear()
                .Rows.Add(rsCount)
                For i = 0 To (rsCount - 1)
                    .Item(0, i).Value = dSerie.Data(i).Title
                    .Item(1, i).Value = dSerie.Data(i).X_Value
                    .Item(2, i).Value = dSerie.Data(i).Y_Value
                Next
            End With

            DgvData.Enabled = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        If CmbCurveType.SelectedIndex < 0 Then
            MsgBox("Select Curve Type Before..", MsgBoxStyle.Exclamation)
        Else
            TxtCurveName.Text = String.Format("New {0}", CmbCurveType.SelectedItem.ToString())
            Ds2Crv = New DataSerie2D(TxtCurveName.Text)
            DgvData.Enabled = True
        End If

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        DgvData.Rows.Clear()
        DgvData.Enabled = False
        ChartCrv.Series.Clear()
        TxtCurveName.Clear()
        Ds2Crv.Data.Clear()
        Ds2Crv = Nothing

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If IsNothing(Ds2Crv) Then Return
        If IsNothing(TheReservoir) Then Return

        Select Case CmbCurveType.SelectedIndex
            Case 0
                TheReservoir.ElevationVolume_Curve = Ds2Crv
            Case 1
                TheReservoir.ElevationArea_Curve = Ds2Crv
            Case 2
                TheReservoir.EvaporationRates = Ds2Crv
            Case 3
                TheReservoir.InfiltrationRates = Ds2Crv
        End Select
        Close()
    End Sub

    Private Sub TxtCurveName_TextChanged(sender As Object, e As EventArgs) Handles TxtCurveName.TextChanged
        If IsNothing(Ds2Crv) = False Then
            Ds2Crv.Name = TxtCurveName.Text
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub CmbExistanteCurves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbExistanteCurves.SelectedIndexChanged
        If CmbExistanteCurves.SelectedIndex < 0 Then Return

        If Equals(TheReservoir, Nothing) = False Then
            If IsNothing(TheReservoir.ElevationVolume_Curve) = False Then
                If TheReservoir.ElevationVolume_Curve.Name = CmbExistanteCurves.SelectedItem.ToString() Then
                    DisplayData(TheReservoir.ElevationVolume_Curve, DgvData)
                    SynchonizeGraphics(TheReservoir.ElevationVolume_Curve, ChartCrv)
                    Return
                End If
            End If

            If IsNothing(TheReservoir.ElevationArea_Curve) = False Then
                If TheReservoir.ElevationArea_Curve.Name = CmbExistanteCurves.SelectedItem.ToString() Then
                    DisplayData(TheReservoir.ElevationArea_Curve, DgvData)
                    SynchonizeGraphics(TheReservoir.ElevationArea_Curve, ChartCrv)
                    Return
                End If

            End If

        End If

    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim result As Boolean = Import_Data(Ds2Crv)
        If result Then
            DisplayData(Ds2Crv, DgvData)
            SynchonizeGraphics(Ds2Crv, ChartCrv)
        End If
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim result As Boolean = Export_Data(Ds2Crv)
        If result Then
            MsgBox("Data have been saved", MsgBoxStyle.Information, "Saving")
        Else
            MsgBox("Data have NOT been saved. Retry please", MsgBoxStyle.Exclamation, "Saving Err")
        End If
    End Sub

    Private DgvColumnsStyle As New DataGridViewCellStyle() With {.BackColor = Color.AliceBlue}

    Private Sub CmbCurveType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCurveType.SelectedIndexChanged

        Select Case CmbCurveType.SelectedIndex
            Case -1
                Return
            Case 0
                With DgvData
                    .Columns(1).HeaderText = "H (m)"
                    .Columns(2).HeaderText = "V (10^6 m3)"
                End With
            Case 1
                With DgvData
                    .Columns(1).HeaderText = "H (m)"
                    .Columns(2).HeaderText = "S (10^4 m2)"
                End With

            Case 2
                With DgvData
                    .Columns(1).HeaderText = "T (Months)"
                    .Columns(2).HeaderText = "Evaporation Rate (m)"
                End With
            Case 3
                With DgvData
                    .Columns(1).HeaderText = "Volume (10^6 m3)"
                    .Columns(2).HeaderText = "Infiltration Rate (10^6 m3)"
                End With

        End Select
    End Sub

End Class