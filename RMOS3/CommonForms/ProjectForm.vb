Imports IOOperations.Components

Public Class ProjectForm
    Private HVCurve As IOOperations.Components.DataSerie2D = Nothing
    Private HSCurve As IOOperations.Components.DataSerie2D = Nothing
    Private EvapoCurve As IOOperations.Components.DataSerie2D = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click

        Dim result As Boolean = False
        Dim bttn = CType(sender, Button)
        Select Case bttn.Name
            Case "Button1"
                Try
                    Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
                    If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                        fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    End If
                    Using openFileDlg As New OpenFileDialog
                        With openFileDlg
                            .InitialDirectory = fileName
                            .Filter = "Data Files (*.xml, *.XML)|*.xml;*.XML|xml|*.xml|XML|*.XML"
                            .ShowDialog()
                            fileName = .FileName
                        End With
                    End Using

                    If IsNothing(fileName) OrElse fileName = String.Empty Then
                        CmbProjectFile.Text = "File not found"
                        CmbProjectFile.BackColor = Color.Crimson
                        Exit Select
                    Else
                        Dim extention As String = IO.Path.GetExtension(fileName)
                        If extention.ToLower() = ".xml" Then
                            CmbProjectFile.Text = fileName
                            Me.Cursor = Cursors.WaitCursor
                            TheProject = Load_Project(fileName)
                            Show_Project(TheProject)
                            Me.Cursor = Cursors.Default

                        End If
                    End If

                Catch ex As Exception
                    Throw ex
                End Try

            Case "Button2"

            Case "Button3"

            Case "Button4"
                HVCurve = New DataSerie2D()
                result = MainModule.Import_Data(HVCurve)
                CmbCurveHVFile.Text = HVCurve.FileName

            Case "Button5"
                HSCurve = New DataSerie2D()
                result = MainModule.Import_Data(HSCurve)
                CmbCurveHSFile.Text = HSCurve.FileName

            Case "Button6"
                EvapoCurve = New DataSerie2D()
                result = MainModule.Import_Data(EvapoCurve)
                CmbEvaporationFile.Text = EvapoCurve.FileName

            Case "Button7"

        End Select

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True

                CmbInflowFile.Enabled = True
                CmbDemandsFile.Enabled = True
                CmbCurveHVFile.Enabled = True
                CmbCurveHSFile.Enabled = True
                CmbEvaporationFile.Enabled = True
            Case 1
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button5.Enabled = False
                Button6.Enabled = False
                Button7.Enabled = False

                CmbInflowFile.Enabled = False
                CmbDemandsFile.Enabled = False
                CmbCurveHVFile.Enabled = False
                CmbCurveHSFile.Enabled = False
                CmbEvaporationFile.Enabled = False

            Case 2
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True

                CmbInflowFile.Enabled = True
                CmbDemandsFile.Enabled = True
                CmbCurveHVFile.Enabled = True
                CmbCurveHSFile.Enabled = True
                CmbEvaporationFile.Enabled = True
        End Select
    End Sub


    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

        If Object.Equals(TheReservoir, Nothing) Then
            TheReservoir = New RmosEngine.HydComponents.Reservoir()
        End If

        Dim qSeries As DataSerie1D = Nothing
        Dim dSeries As DataSerie1D = Nothing








        Me.Close()
    End Sub

#Region "Subs and functions"
    Private Function Load_Project(ByVal fileName As String) As RmosProject
        Dim prj As RmosProject = Nothing
        Try
            If IO.File.Exists(fileName) Then
                Dim reader As New IOOperations.FileManager(fileName)
                prj = reader.ReadXml()
                prj.ProjectFileName = fileName
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return prj
    End Function

    Private Sub Show_Project(ByRef prj As RmosProject)
        If IsNothing(prj) Then
            CmbInflowFile.BackColor = Color.Crimson
            CmbDemandsFile.BackColor = Color.Crimson
            CmbCurveHVFile.BackColor = Color.Crimson
            CmbCurveHSFile.BackColor = Color.Crimson
            CmbEvaporationFile.BackColor = Color.Crimson
        Else
            With prj
                CmbInflowFile.Text = .InflowSeriesFileName
                CmbDemandsFile.Text = .DemandSeriesFileName
                CmbCurveHVFile.Text = .HVCurveFileName
                CmbCurveHSFile.Text = .HSCurveFileName
                CmbEvaporationFile.Text = .EvaporationCurveFileName
            End With

        End If
    End Sub

#End Region

End Class