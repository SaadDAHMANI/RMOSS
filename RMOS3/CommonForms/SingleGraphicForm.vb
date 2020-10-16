Public Class SingleGraphicForm
    Friend GraphicChart As DataVisualization.Charting.Chart
    Private Sub SingleGraphicForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(GraphicChart) = False Then
            With Chart1
                .Series.Clear()
                For Each sr In GraphicChart.Series
                    .Series.Add(sr)
                Next
            End With
        End If

    End Sub
End Class