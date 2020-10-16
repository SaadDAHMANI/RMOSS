Public Class MainForm
#Region "Public forms"
    Friend ReservoirFrm As ReservoirForm
    Friend InflowFrm As InflowForm
    Friend DemandFrm As DemandForm
    '----------------------------------------------------------
    Friend GeneticAlgoFrm As GeneticAlgoForm
    Friend GSAlgoFrm As GSAlgoForm
    Friend GWOAlgoFrm As GWOAlgoForm
    Friend HPSOGWOAlgoFrm As HybridPSOGWOForm
    Friend OptimizationFrm As OptimizationForm

    '----------------------------------------------------------
    Friend GaGraphicsFrm As GraphicsForm
    Friend GsaGraphicsFrm As GSAGraphicsForm
    Friend GwoGraphicsFrm As GWOGraphicsForm

    '----------------------------------------------------------
    Friend TablesFrm As TablesForm
    '----------------------------------------------------------
    'Friend NeuralNetwokFrm As NeuralNetworksForm
    Friend NeuralNetwoksFrm As NeuralNetworkForm
    Friend AnnTestFrm As ANNTestForm
    Friend AnnEoaFrm As AnnEoForm

#End Region

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            MainTreeView.ExpandAll()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TsmExit_Click(sender As Object, e As EventArgs) Handles TsmExit.Click
        End
    End Sub

#Region "Subs_Functions"
    Friend Sub Show_Window(ByRef window As Form)
        Try
            If IsNothing(window) Then Return
            window.MdiParent = Me
            MainSplitContainer.Panel1.Controls.Add(window)
            window.Show()
            window.Activate()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShowInTree(ByRef dam As RmosEngine.HydComponents.Reservoir)
        Me.MainTreeView.Nodes.Clear()
        If (Equals(dam, Nothing)) Then Return

        Dim reservoirNode As New TreeNode(String.Format("Reservoir [{0}]", dam.Name))
        reservoirNode.Nodes.Add("Reservoir Config.")

        If (Not Equals(dam.ElevationArea_Curve, Nothing)) Then
            reservoirNode.Nodes.Add(String.Format("H-S Curve [0]", dam.ElevationArea_Curve.Name))
        End If

        If (Not Equals(dam.ElevationVolume_Curve, Nothing)) Then
            reservoirNode.Nodes.Add(String.Format("H-V Curve [0]", dam.ElevationVolume_Curve.Name))
        End If

        If (Not Equals(dam.EvaporationRates, Nothing)) Then
            reservoirNode.Nodes.Add(String.Format("Evaporation Rates [0]", dam.EvaporationRates.Name))
        End If

        If (Not Equals(dam.InfiltrationRates, Nothing)) Then
            reservoirNode.Nodes.Add(String.Format("Infiltration Rates [0]", dam.InfiltrationRates))
        End If
        '--------------------------------------------------
        Dim dataseriesNode As New TreeNode("Data Series")

        If (Not Equals(dam.Inflow, Nothing)) Then
            dataseriesNode.Nodes.Add(String.Format("Inflow [{0}]", dam.Inflow.Name))
        End If

        If (Not Equals(dam.Downstream, Nothing)) Then
            dataseriesNode.Nodes.Add(String.Format("Downstream [{0}]", dam.Downstream.Name))
        End If

        MainTreeView.Nodes.Add(reservoirNode)
        MainTreeView.Nodes.Add(dataseriesNode)

        MainTreeView.ExpandAll()
    End Sub

#End Region

    Private Sub MainTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles MainTreeView.AfterSelect
        Try

            Select Case e.Node.Name
                Case "NdReservoirConfig"
                    ReservoirFrm = New ReservoirForm()
                    Show_Window(CType(ReservoirFrm, Form))

                Case "NdEvaporationSeries"

                Case "NdInfiltrationSeries"

                Case "NdInflows"
                    InflowFrm = New InflowForm()
                    Show_Window(CType(InflowFrm, Form))

                Case "NdDemands"
                    DemandFrm = New DemandForm()
                    Show_Window(CType(DemandFrm, Form))

                Case "NdGeneticAlgo"

                Case "NdGSAlog"

                Case "NdGWOAlgo"

            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TsmiGeneticAlgoOptimzation_Click(sender As Object, e As EventArgs) Handles TsmiGeneticAlgoOptimzation.Click
        GeneticAlgoFrm = New GeneticAlgoForm()
        Show_Window(CType(GeneticAlgoFrm, Form))
    End Sub

    Private Sub TsmiGSAOptimization_Click(sender As Object, e As EventArgs) Handles TsmiGSAOptimization.Click
        GSAlgoFrm = New GSAlgoForm()
        Show_Window(CType(GSAlgoFrm, Form))
    End Sub

    Private Sub TsmiGWOPtimization_Click(sender As Object, e As EventArgs) Handles TsmiGWOPtimization.Click
        GWOAlgoFrm = New GWOAlgoForm()
        Show_Window(CType(GWOAlgoFrm, Form))
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        GaGraphicsFrm = New GraphicsForm()
        GaGraphicsFrm.OptimizationEngine = GA_Engine
        Show_Window(CType(GaGraphicsFrm, Form))
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        'GsaGraphicsFrm = New GSAGraphicsForm()
        'Show_Window(CType(GsaGraphicsFrm, Form))
        GaGraphicsFrm = New GraphicsForm()
        GaGraphicsFrm.OptimizationEngine = GSA_Engine
        Show_Window(CType(GaGraphicsFrm, Form))
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click

        GaGraphicsFrm = New GraphicsForm()
        GaGraphicsFrm.OptimizationEngine = GWO_Engine
        Show_Window(CType(GaGraphicsFrm, Form))

    End Sub

    Private Sub TsmiGaTables_Click(sender As Object, e As EventArgs) Handles TsmiGaTables.Click
        TablesFrm = New TablesForm()
        TablesFrm.OptimizationEngine = GA_Engine
        TablesFrm.Text = "Results (GA)"
        Show_Window(CType(TablesFrm, Form))

    End Sub

    Private Sub TsmiHorizontal_Click(sender As Object, e As EventArgs) Handles TsmiHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TsmiVertical_Click(sender As Object, e As EventArgs) Handles TsmiVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TsmiCascade_Click(sender As Object, e As EventArgs) Handles TsmiCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TsmiMosaic_Click(sender As Object, e As EventArgs) Handles TsmiMosaic.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub TsmiInflows_Click(sender As Object, e As EventArgs) Handles TsmiInflows.Click
        InflowFrm = New InflowForm()
        Show_Window(CType(InflowFrm, Form))

    End Sub

    Private Sub TsmiExploitation_Click(sender As Object, e As EventArgs) Handles TsmiExploitation.Click
        DemandFrm = New DemandForm()
        Show_Window(CType(DemandFrm, Form))

    End Sub

    Private Sub TsmiGsaTables_Click(sender As Object, e As EventArgs) Handles TsmiGsaTables.Click
        TablesFrm = New TablesForm()
        TablesFrm.OptimizationEngine = GSA_Engine
        TablesFrm.Text = "Results (GSA)"
        Show_Window(CType(TablesFrm, Form))
    End Sub

    Private Sub TsmiGwoTables_Click(sender As Object, e As EventArgs) Handles TsmiGwoTables.Click
        TablesFrm = New TablesForm()
        TablesFrm.OptimizationEngine = GWO_Engine
        TablesFrm.Text = "Results (GWO)"
        Show_Window(CType(TablesFrm, Form))
    End Sub

    Private Sub TsmiNeuralNetworks_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub TsmiNeuralNetwork_Click(sender As Object, e As EventArgs) Handles TsmiNeuralNetwork.Click
        NeuralNetwoksFrm = New NeuralNetworkForm()
        Show_Window(CType(NeuralNetwoksFrm, Form))
    End Sub

    Private Sub TssbReservoir_ButtonClick(sender As Object, e As EventArgs) Handles TssbReservoir.ButtonClick
        If IsNothing(ReservoirFrm) Then Return

        If ReservoirFrm.WindowState = FormWindowState.Normal OrElse ReservoirFrm.WindowState = FormWindowState.Maximized Then
            ReservoirFrm.WindowState = FormWindowState.Minimized
        Else
            ReservoirFrm.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub TssbInflows_ButtonClick(sender As Object, e As EventArgs) Handles TssbInflows.ButtonClick

        If IsNothing(InflowFrm) Then Return

        If InflowFrm.WindowState = FormWindowState.Normal OrElse InflowFrm.WindowState = FormWindowState.Maximized Then
            InflowFrm.WindowState = FormWindowState.Minimized
        Else
            InflowFrm.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub TssbDemands_ButtonClick(sender As Object, e As EventArgs) Handles TssbDemands.ButtonClick
        If IsNothing(DemandFrm) Then Return
        If DemandFrm.WindowState = FormWindowState.Normal OrElse DemandFrm.WindowState = FormWindowState.Maximized Then
            DemandFrm.WindowState = FormWindowState.Minimized
        Else
            DemandFrm.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub TssbGAEngine_ButtonClick(sender As Object, e As EventArgs) Handles TssbGAEngine.ButtonClick
        If IsNothing(GeneticAlgoFrm) Then Return
        If GeneticAlgoFrm.WindowState = FormWindowState.Normal OrElse GeneticAlgoFrm.WindowState = FormWindowState.Maximized Then
            GeneticAlgoFrm.WindowState = FormWindowState.Minimized
        Else
            GeneticAlgoFrm.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub TssbGSAEngine_ButtonClick(sender As Object, e As EventArgs) Handles TssbGSAEngine.ButtonClick
        If IsNothing(GSAlgoFrm) Then Return
        If GSAlgoFrm.WindowState = FormWindowState.Normal OrElse GSAlgoFrm.WindowState = FormWindowState.Maximized Then
            GSAlgoFrm.WindowState = FormWindowState.Minimized
        Else
            GSAlgoFrm.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub TssbGWOEngine_ButtonClick(sender As Object, e As EventArgs) Handles TssbGWOEngine.ButtonClick
        If IsNothing(GWOAlgoFrm) Then Return
        If GWOAlgoFrm.WindowState = FormWindowState.Normal OrElse GWOAlgoFrm.WindowState = FormWindowState.Maximized Then
            GWOAlgoFrm.WindowState = FormWindowState.Minimized
        Else
            GWOAlgoFrm.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub TssbResultsTables_ButtonClick(sender As Object, e As EventArgs) Handles TssbResultsTables.ButtonClick
        If IsNothing(TablesFrm) Then Return
        If TablesFrm.WindowState = FormWindowState.Normal OrElse TablesFrm.WindowState = FormWindowState.Maximized Then
            TablesFrm.WindowState = FormWindowState.Minimized
        Else
            TablesFrm.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub TssbResultsGrpahics_ButtonClick(sender As Object, e As EventArgs) Handles TssbResultsGrpahics.ButtonClick
        If IsNothing(GaGraphicsFrm) Then Return
        If GaGraphicsFrm.WindowState = FormWindowState.Normal OrElse GaGraphicsFrm.WindowState = FormWindowState.Maximized Then
            GaGraphicsFrm.WindowState = FormWindowState.Minimized
        Else
            GaGraphicsFrm.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub TsmiReservoir_Click(sender As Object, e As EventArgs) Handles TsmiReservoir.Click
        ReservoirFrm = New ReservoirForm()
        Show_Window(CType(ReservoirFrm, Form))
    End Sub

    Private Sub TsmiOpenProject_Click(sender As Object, e As EventArgs) Handles TsmiOpenProject.Click, TsbOpenProject.Click

        Dim result As Boolean = False
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
            Me.Cursor = Cursors.WaitCursor
            If IsNothing(fileName) OrElse fileName = String.Empty Then
                MsgBox("File not found")
            Else
                Dim extention As String = IO.Path.GetExtension(fileName)
                If extention.ToLower() = ".xml" Then

                    Dim IoPrj As New IOOperations.IOProject()
                    IoPrj.ReadXML(fileName)
                    TheReservoir = RmosEngine.HydComponents.Reservoir.ConvertFrom(IoPrj.Reservoir)
                    TheReservoir.FilePath = fileName
                    result = True
                    Me.Text = String.Format("RMOS-3 (Beta) | [Project = {0}]", IoPrj.FileName)
                    ShowInTree(TheReservoir)
                    ReservoirFrm = New ReservoirForm()
                    Show_Window(CType(ReservoirFrm, Form))

                End If
            End If
            TssSavedLable.Text = String.Format("Loaded = [{0}]", result.ToString())
        Catch ex As Exception
            Throw ex
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub List_InflowQSeries_Changed(sender As Object, e As EventArgs) Handles Me.List_InflowQSeriesChanged
        For Each nd As TreeNode In MainTreeView.Nodes
            If nd.Name = "NdInflows" Then
                nd.Nodes.Clear()
                nd.Nodes.Add(TheReservoir.Inflow.Name)
            End If
        Next
    End Sub

#Region "Events"
    Public Event List_InflowQSeriesChanged(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub TsmiHPSOGWOptimization_Click(sender As Object, e As EventArgs) Handles TsmiHPSOGWOptimization.Click
        HPSOGWOAlgoFrm = New HybridPSOGWOForm()
        Show_Window(CType(HPSOGWOAlgoFrm, Form))
    End Sub

    Private Sub TsmiTsmiHPSOGWOTables_Click(sender As Object, e As EventArgs) Handles TsmiTsmiHPSOGWOTables.Click
        TablesFrm = New TablesForm()
        TablesFrm.OptimizationEngine = HPSOGWO_Engine
        TablesFrm.Text = "Results (Hybrid PSO-GWO)"
        Show_Window(CType(TablesFrm, Form))
    End Sub

    Private Sub TsmiHPSOGWOGraphics_Click(sender As Object, e As EventArgs) Handles TsmiHPSOGWOGraphics.Click
        GaGraphicsFrm = New GraphicsForm()
        GaGraphicsFrm.OptimizationEngine = HPSOGWO_Engine
        Show_Window(CType(GaGraphicsFrm, Form))
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim reportFrm As New ReportForm()
        Show_Window(CType(reportFrm, Form))
    End Sub

    Private Sub TsmiAsynchronOptimFrm_Click(sender As Object, e As EventArgs) Handles TsmiAsynchronOptimFrm.Click
        Dim OptimizationFrm As New OptimizationForm()
        Show_Window(CType(OptimizationFrm, Form))
    End Sub

    Private Sub TsmiSave_Click(sender As Object, e As EventArgs) Handles TsmiSave.Click, TsbSave.Click
        Try
            If (Equals(TheReservoir, Nothing)) Then Return
            If (Equals(TheReservoir.FilePath, Nothing) OrElse TheReservoir.FilePath = "") Then

                Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
                If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                    fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                End If
                Using saveFileDlg As New SaveFileDialog
                    With saveFileDlg
                        .InitialDirectory = fileName
                        '.Filter = "Data Files (*.DS2, *.CSV)|*.DS2;*.CSV"
                        .Filter = "XML|*.XML|xml|*.xml"
                        .ShowDialog()
                        TheReservoir.FilePath = .FileName
                    End With
                End Using
            End If

            Dim result As Boolean = False
            Dim IoPrj As New IOOperations.IOProject()
            IoPrj.Reservoir = TheReservoir.ConvertToIOReservoir()
            result = IoPrj.Save(TheReservoir.FilePath, IOOperations.IOFileFormatEnum.XML)
            TssSavedLable.Text = String.Format("Saved = [{0}]", result.ToString())
            IoPrj = Nothing
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TsmiSaveAs_Click(sender As Object, e As EventArgs) Handles TsmiSaveAs.Click, TsbSaveAs.Click

        If IsNothing(TheReservoir) Then Return

        Dim result As Boolean = False
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If

            Me.Cursor = Cursors.WaitCursor
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    .Filter = "Data Files (*.xml, *.XML)|*.xml;*.XML|xml|*.xml|XML|*.XML"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using
            Me.Cursor = Cursors.Default

            MsgBox(fileName, MsgBoxStyle.Information)

            Dim extention As String = IO.Path.GetExtension(fileName)
            If extention.ToLower() = ".xml" Then
                Dim IoPrj As New IOOperations.IOProject()
                IoPrj.Reservoir = TheReservoir.ConvertToIOReservoir()
                result = IoPrj.Save(fileName, IOOperations.IOFileFormatEnum.XML)
                If result Then
                    TheReservoir.FilePath = fileName
                End If
                IoPrj = Nothing
            End If

            TssSavedLable.Text = String.Format("Saved = [{0}]", result.ToString())

        Catch ex As Exception
            Throw ex
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TsmiANNTest_Click(sender As Object, e As EventArgs)
        ''AnnTestFrm = New ANNTestForm()
        ''Show_Window(CType(AnnTestFrm, Form))
    End Sub

    Private Sub TsmiNeuralNetEOA_Click(sender As Object, e As EventArgs) Handles TsmiNeuralNetEOA.Click
        AnnEoaFrm = New AnnEoForm()
        Show_Window(CType(AnnEoaFrm, Form))
    End Sub

    Private Sub TsmiPerformance_Click(sender As Object, e As EventArgs) Handles TsmiPerformance.Click

    End Sub

    Private Sub TsmiNewProject_Click(sender As Object, e As EventArgs) Handles TsmiNewProject.Click, TsbNewProject.Click
        If (Equals(TheReservoir, Nothing) = False) Then
            Dim msgResult = MsgBox("There is existed project, would you create a new ?", (MsgBoxStyle.Question Or MsgBoxStyle.YesNo), "New Project")
            If msgResult = MsgBoxResult.Yes Then
                TheReservoir = New RmosEngine.HydComponents.Reservoir()
            End If
        Else
            TheReservoir = New RmosEngine.HydComponents.Reservoir()
        End If

    End Sub

    Private Sub TsmPerformance_Click(sender As Object, e As EventArgs) Handles TsmPerformance.Click

    End Sub

#End Region


End Class
