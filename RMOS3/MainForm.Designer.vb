<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reservoir Configuration")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Evaporation")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Infiltration")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reservoir", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inflows")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Demand Model")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Data Series", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Genetic Algorithm ")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gravitational Search Algorithm")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Grey Wolf Optimizer")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Optimization", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Performance")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comparaison")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Performance Analysis", New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13})
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiNewProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiOpenProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmData = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiReservoir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmiInflows = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmiExploitation = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmOptimization = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmGeneticAlgo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiGeneticAlgoOptimzation = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiGaTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmGSAlgo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiGSAOptimization = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiGsaTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmGWOAlgo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiGWOPtimization = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiGwoTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmHPSOGWOAlgo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiHPSOGWOptimization = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiTsmiHPSOGWOTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiHPSOGWOGraphics = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmiAsynchronOptimFrm = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmPerformance = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiPerformance = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmComparaison = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmForecasting = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiNeuralNetwork = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmiNeuralNetEOA = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiMosaic = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsbNewProject = New System.Windows.Forms.ToolStripButton()
        Me.TsbOpenProject = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbSave = New System.Windows.Forms.ToolStripButton()
        Me.TsbSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TssSavedLable = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TssbReservoir = New System.Windows.Forms.ToolStripSplitButton()
        Me.TssbInflows = New System.Windows.Forms.ToolStripSplitButton()
        Me.TssbDemands = New System.Windows.Forms.ToolStripSplitButton()
        Me.TssbGAEngine = New System.Windows.Forms.ToolStripSplitButton()
        Me.TssbGSAEngine = New System.Windows.Forms.ToolStripSplitButton()
        Me.TssbGWOEngine = New System.Windows.Forms.ToolStripSplitButton()
        Me.TssbResultsTables = New System.Windows.Forms.ToolStripSplitButton()
        Me.TssbResultsGrpahics = New System.Windows.Forms.ToolStripSplitButton()
        Me.MainSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.MainTreeView = New System.Windows.Forms.TreeView()
        Me.CxtMnuTreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CxtTsmiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.CxtMnuNewInflowSerie = New System.Windows.Forms.ToolStripMenuItem()
        Me.CxtMnuNewDemand = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainSplitContainer.Panel2.SuspendLayout()
        Me.MainSplitContainer.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.CxtMnuTreeView.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFile, Me.TsmData, Me.TsmOptimization, Me.TsmPerformance, Me.TsmForecasting, Me.TsmWindows, Me.TsmHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(949, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuFile
        '
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiNewProject, Me.TsmiOpenProject, Me.ToolStripSeparator2, Me.TsmiSave, Me.TsmiSaveAs, Me.ToolStripSeparator1, Me.TsmExit})
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(37, 20)
        Me.MnuFile.Text = "File"
        '
        'TsmiNewProject
        '
        Me.TsmiNewProject.Image = Global.RMOS3.My.Resources.Resources.AddNewIcon
        Me.TsmiNewProject.Name = "TsmiNewProject"
        Me.TsmiNewProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.TsmiNewProject.Size = New System.Drawing.Size(150, 26)
        Me.TsmiNewProject.Text = "New"
        '
        'TsmiOpenProject
        '
        Me.TsmiOpenProject.Image = Global.RMOS3.My.Resources.Resources.folder_yellow
        Me.TsmiOpenProject.Name = "TsmiOpenProject"
        Me.TsmiOpenProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.TsmiOpenProject.Size = New System.Drawing.Size(150, 26)
        Me.TsmiOpenProject.Text = "Open"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(147, 6)
        '
        'TsmiSave
        '
        Me.TsmiSave.Image = Global.RMOS3.My.Resources.Resources.document_save_51
        Me.TsmiSave.Name = "TsmiSave"
        Me.TsmiSave.Size = New System.Drawing.Size(150, 26)
        Me.TsmiSave.Text = "Save"
        '
        'TsmiSaveAs
        '
        Me.TsmiSaveAs.Image = Global.RMOS3.My.Resources.Resources.document_save_as_5
        Me.TsmiSaveAs.Name = "TsmiSaveAs"
        Me.TsmiSaveAs.Size = New System.Drawing.Size(150, 26)
        Me.TsmiSaveAs.Text = "Save As"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'TsmExit
        '
        Me.TsmExit.Image = Global.RMOS3.My.Resources.Resources.application_exit_5
        Me.TsmExit.Name = "TsmExit"
        Me.TsmExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.TsmExit.Size = New System.Drawing.Size(150, 26)
        Me.TsmExit.Text = "E&xit"
        '
        'TsmData
        '
        Me.TsmData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiReservoir, Me.ToolStripSeparator5, Me.TsmiInflows, Me.ToolStripSeparator6, Me.TsmiExploitation})
        Me.TsmData.Name = "TsmData"
        Me.TsmData.Size = New System.Drawing.Size(43, 20)
        Me.TsmData.Text = "&Data"
        '
        'TsmiReservoir
        '
        Me.TsmiReservoir.Name = "TsmiReservoir"
        Me.TsmiReservoir.Size = New System.Drawing.Size(197, 22)
        Me.TsmiReservoir.Text = "Reservoir Config."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(194, 6)
        '
        'TsmiInflows
        '
        Me.TsmiInflows.Name = "TsmiInflows"
        Me.TsmiInflows.Size = New System.Drawing.Size(197, 22)
        Me.TsmiInflows.Text = "Inflows"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(194, 6)
        '
        'TsmiExploitation
        '
        Me.TsmiExploitation.Name = "TsmiExploitation"
        Me.TsmiExploitation.Size = New System.Drawing.Size(197, 22)
        Me.TsmiExploitation.Text = "Exploitation (Demands)"
        '
        'TsmOptimization
        '
        Me.TsmOptimization.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmGeneticAlgo, Me.ToolStripSeparator3, Me.TsmGSAlgo, Me.ToolStripSeparator4, Me.TsmGWOAlgo, Me.ToolStripSeparator8, Me.TsmHPSOGWOAlgo, Me.ToolStripSeparator10, Me.TsmiAsynchronOptimFrm})
        Me.TsmOptimization.Name = "TsmOptimization"
        Me.TsmOptimization.Size = New System.Drawing.Size(88, 20)
        Me.TsmOptimization.Text = "Op&timization"
        '
        'TsmGeneticAlgo
        '
        Me.TsmGeneticAlgo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiGeneticAlgoOptimzation, Me.TsmiGaTables, Me.ToolStripMenuItem7})
        Me.TsmGeneticAlgo.Image = Global.RMOS3.My.Resources.Resources.GAIcone
        Me.TsmGeneticAlgo.Name = "TsmGeneticAlgo"
        Me.TsmGeneticAlgo.Size = New System.Drawing.Size(207, 26)
        Me.TsmGeneticAlgo.Text = "&Genetic Algorithm"
        '
        'TsmiGeneticAlgoOptimzation
        '
        Me.TsmiGeneticAlgoOptimzation.Image = Global.RMOS3.My.Resources.Resources.GAIcone
        Me.TsmiGeneticAlgoOptimzation.Name = "TsmiGeneticAlgoOptimzation"
        Me.TsmiGeneticAlgoOptimzation.Size = New System.Drawing.Size(194, 26)
        Me.TsmiGeneticAlgoOptimzation.Text = "[GA] Opti&mzation"
        '
        'TsmiGaTables
        '
        Me.TsmiGaTables.Image = Global.RMOS3.My.Resources.Resources.Table
        Me.TsmiGaTables.Name = "TsmiGaTables"
        Me.TsmiGaTables.Size = New System.Drawing.Size(194, 26)
        Me.TsmiGaTables.Text = "[GA] Results. Tables"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = Global.RMOS3.My.Resources.Resources.Chart1
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(194, 26)
        Me.ToolStripMenuItem7.Text = "[GA] Results. Graphics"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(204, 6)
        '
        'TsmGSAlgo
        '
        Me.TsmGSAlgo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiGSAOptimization, Me.TsmiGsaTables, Me.ToolStripMenuItem9})
        Me.TsmGSAlgo.Image = Global.RMOS3.My.Resources.Resources.GSAIcone
        Me.TsmGSAlgo.Name = "TsmGSAlgo"
        Me.TsmGSAlgo.Size = New System.Drawing.Size(207, 26)
        Me.TsmGSAlgo.Text = "Gra&vit. Search Algorithm"
        '
        'TsmiGSAOptimization
        '
        Me.TsmiGSAOptimization.Image = Global.RMOS3.My.Resources.Resources.GSAIcone
        Me.TsmiGSAOptimization.Name = "TsmiGSAOptimization"
        Me.TsmiGSAOptimization.Size = New System.Drawing.Size(200, 26)
        Me.TsmiGSAOptimization.Text = "[GSA] Opti&mization"
        '
        'TsmiGsaTables
        '
        Me.TsmiGsaTables.Image = Global.RMOS3.My.Resources.Resources.Table
        Me.TsmiGsaTables.Name = "TsmiGsaTables"
        Me.TsmiGsaTables.Size = New System.Drawing.Size(200, 26)
        Me.TsmiGsaTables.Text = "[GSA] Results. Tables"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(200, 26)
        Me.ToolStripMenuItem9.Text = "[GSA] Results. Graphics"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(204, 6)
        '
        'TsmGWOAlgo
        '
        Me.TsmGWOAlgo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiGWOPtimization, Me.TsmiGwoTables, Me.ToolStripMenuItem11})
        Me.TsmGWOAlgo.Image = Global.RMOS3.My.Resources.Resources.wolf
        Me.TsmGWOAlgo.Name = "TsmGWOAlgo"
        Me.TsmGWOAlgo.Size = New System.Drawing.Size(207, 26)
        Me.TsmGWOAlgo.Text = "Grey &Wolfs Algorithm"
        '
        'TsmiGWOPtimization
        '
        Me.TsmiGWOPtimization.Image = Global.RMOS3.My.Resources.Resources.wolf
        Me.TsmiGWOPtimization.Name = "TsmiGWOPtimization"
        Me.TsmiGWOPtimization.Size = New System.Drawing.Size(206, 26)
        Me.TsmiGWOPtimization.Text = "[GWO] Opti&mization"
        '
        'TsmiGwoTables
        '
        Me.TsmiGwoTables.Image = Global.RMOS3.My.Resources.Resources.Table
        Me.TsmiGwoTables.Name = "TsmiGwoTables"
        Me.TsmiGwoTables.Size = New System.Drawing.Size(206, 26)
        Me.TsmiGwoTables.Text = "[GWO] Results. Tables"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Image = Global.RMOS3.My.Resources.Resources.Chart1
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(206, 26)
        Me.ToolStripMenuItem11.Text = "[GWO] Results. Graphics"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(204, 6)
        '
        'TsmHPSOGWOAlgo
        '
        Me.TsmHPSOGWOAlgo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiHPSOGWOptimization, Me.TsmiTsmiHPSOGWOTables, Me.TsmiHPSOGWOGraphics})
        Me.TsmHPSOGWOAlgo.Image = Global.RMOS3.My.Resources.Resources.HPGIcone
        Me.TsmHPSOGWOAlgo.Name = "TsmHPSOGWOAlgo"
        Me.TsmHPSOGWOAlgo.Size = New System.Drawing.Size(207, 26)
        Me.TsmHPSOGWOAlgo.Text = "Hybrid PSO-GWO Algo."
        '
        'TsmiHPSOGWOptimization
        '
        Me.TsmiHPSOGWOptimization.Image = Global.RMOS3.My.Resources.Resources.HPGIcone
        Me.TsmiHPSOGWOptimization.Name = "TsmiHPSOGWOptimization"
        Me.TsmiHPSOGWOptimization.Size = New System.Drawing.Size(237, 26)
        Me.TsmiHPSOGWOptimization.Text = "[HPSOGWO] Optimization"
        '
        'TsmiTsmiHPSOGWOTables
        '
        Me.TsmiTsmiHPSOGWOTables.Image = Global.RMOS3.My.Resources.Resources.Table
        Me.TsmiTsmiHPSOGWOTables.Name = "TsmiTsmiHPSOGWOTables"
        Me.TsmiTsmiHPSOGWOTables.Size = New System.Drawing.Size(237, 26)
        Me.TsmiTsmiHPSOGWOTables.Text = "[HPSOGWO] Results. Tables"
        '
        'TsmiHPSOGWOGraphics
        '
        Me.TsmiHPSOGWOGraphics.Image = Global.RMOS3.My.Resources.Resources.Chart1
        Me.TsmiHPSOGWOGraphics.Name = "TsmiHPSOGWOGraphics"
        Me.TsmiHPSOGWOGraphics.Size = New System.Drawing.Size(237, 26)
        Me.TsmiHPSOGWOGraphics.Text = "[HPSOGWO] Results. Graphics"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(204, 6)
        '
        'TsmiAsynchronOptimFrm
        '
        Me.TsmiAsynchronOptimFrm.Name = "TsmiAsynchronOptimFrm"
        Me.TsmiAsynchronOptimFrm.Size = New System.Drawing.Size(207, 26)
        Me.TsmiAsynchronOptimFrm.Text = "Asynch. Optimization"
        '
        'TsmPerformance
        '
        Me.TsmPerformance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiPerformance, Me.TsmComparaison, Me.ToolStripSeparator9, Me.ToolStripMenuItem1})
        Me.TsmPerformance.Name = "TsmPerformance"
        Me.TsmPerformance.Size = New System.Drawing.Size(87, 20)
        Me.TsmPerformance.Text = "Performance"
        '
        'TsmiPerformance
        '
        Me.TsmiPerformance.Name = "TsmiPerformance"
        Me.TsmiPerformance.Size = New System.Drawing.Size(188, 22)
        Me.TsmiPerformance.Text = "Performance Analysis"
        '
        'TsmComparaison
        '
        Me.TsmComparaison.Name = "TsmComparaison"
        Me.TsmComparaison.Size = New System.Drawing.Size(188, 22)
        Me.TsmComparaison.Text = "Comparaison"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(185, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripMenuItem1.Text = "Report "
        '
        'TsmForecasting
        '
        Me.TsmForecasting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiNeuralNetwork, Me.ToolStripSeparator11, Me.TsmiNeuralNetEOA})
        Me.TsmForecasting.Name = "TsmForecasting"
        Me.TsmForecasting.ShowShortcutKeys = False
        Me.TsmForecasting.Size = New System.Drawing.Size(80, 20)
        Me.TsmForecasting.Text = "&Forecasting"
        '
        'TsmiNeuralNetwork
        '
        Me.TsmiNeuralNetwork.Image = Global.RMOS3.My.Resources.Resources.ANNIcone
        Me.TsmiNeuralNetwork.Name = "TsmiNeuralNetwork"
        Me.TsmiNeuralNetwork.Size = New System.Drawing.Size(203, 26)
        Me.TsmiNeuralNetwork.Text = "Neural Networks (ANN)"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(200, 6)
        '
        'TsmiNeuralNetEOA
        '
        Me.TsmiNeuralNetEOA.Image = Global.RMOS3.My.Resources.Resources.EANNIcone
        Me.TsmiNeuralNetEOA.Name = "TsmiNeuralNetEOA"
        Me.TsmiNeuralNetEOA.Size = New System.Drawing.Size(203, 26)
        Me.TsmiNeuralNetEOA.Text = "Neural Net - EOAs "
        '
        'TsmWindows
        '
        Me.TsmWindows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiHorizontal, Me.TsmiVertical, Me.TsmiCascade, Me.TsmiMosaic})
        Me.TsmWindows.Name = "TsmWindows"
        Me.TsmWindows.Size = New System.Drawing.Size(68, 20)
        Me.TsmWindows.Text = "Windows"
        '
        'TsmiHorizontal
        '
        Me.TsmiHorizontal.Name = "TsmiHorizontal"
        Me.TsmiHorizontal.Size = New System.Drawing.Size(129, 22)
        Me.TsmiHorizontal.Text = "Horizontal"
        '
        'TsmiVertical
        '
        Me.TsmiVertical.Name = "TsmiVertical"
        Me.TsmiVertical.Size = New System.Drawing.Size(129, 22)
        Me.TsmiVertical.Text = "Vertical"
        '
        'TsmiCascade
        '
        Me.TsmiCascade.Name = "TsmiCascade"
        Me.TsmiCascade.Size = New System.Drawing.Size(129, 22)
        Me.TsmiCascade.Text = "Cascade"
        '
        'TsmiMosaic
        '
        Me.TsmiMosaic.Name = "TsmiMosaic"
        Me.TsmiMosaic.Size = New System.Drawing.Size(129, 22)
        Me.TsmiMosaic.Text = "Arrange"
        '
        'TsmHelp
        '
        Me.TsmHelp.Name = "TsmHelp"
        Me.TsmHelp.Size = New System.Drawing.Size(44, 20)
        Me.TsmHelp.Text = "&Help"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbNewProject, Me.TsbOpenProject, Me.ToolStripSeparator12, Me.TsbSave, Me.TsbSaveAs, Me.ToolStripSeparator13})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(949, 27)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TsbNewProject
        '
        Me.TsbNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbNewProject.Image = Global.RMOS3.My.Resources.Resources.AddNewIcon
        Me.TsbNewProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbNewProject.Name = "TsbNewProject"
        Me.TsbNewProject.Size = New System.Drawing.Size(24, 24)
        Me.TsbNewProject.Text = "ToolStripButton1"
        '
        'TsbOpenProject
        '
        Me.TsbOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbOpenProject.Image = Global.RMOS3.My.Resources.Resources.folder_yellow
        Me.TsbOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbOpenProject.Name = "TsbOpenProject"
        Me.TsbOpenProject.Size = New System.Drawing.Size(24, 24)
        Me.TsbOpenProject.Text = "ToolStripButton2"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 27)
        '
        'TsbSave
        '
        Me.TsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbSave.Image = Global.RMOS3.My.Resources.Resources.document_save_51
        Me.TsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbSave.Name = "TsbSave"
        Me.TsbSave.Size = New System.Drawing.Size(24, 24)
        Me.TsbSave.Text = "ToolStripButton3"
        '
        'TsbSaveAs
        '
        Me.TsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbSaveAs.Image = Global.RMOS3.My.Resources.Resources.document_save_as_5
        Me.TsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbSaveAs.Name = "TsbSaveAs"
        Me.TsbSaveAs.Size = New System.Drawing.Size(24, 24)
        Me.TsbSaveAs.Text = "ToolStripButton4"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 27)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TssSavedLable, Me.TssbReservoir, Me.TssbInflows, Me.TssbDemands, Me.TssbGAEngine, Me.TssbGSAEngine, Me.TssbGWOEngine, Me.TssbResultsTables, Me.TssbResultsGrpahics})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 419)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(949, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TssSavedLable
        '
        Me.TssSavedLable.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TssSavedLable.Name = "TssSavedLable"
        Me.TssSavedLable.Size = New System.Drawing.Size(90, 17)
        Me.TssSavedLable.Text = "Saved = [False]"
        '
        'TssbReservoir
        '
        Me.TssbReservoir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbReservoir.Image = CType(resources.GetObject("TssbReservoir.Image"), System.Drawing.Image)
        Me.TssbReservoir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbReservoir.Name = "TssbReservoir"
        Me.TssbReservoir.Size = New System.Drawing.Size(71, 20)
        Me.TssbReservoir.Text = "Reservoir"
        '
        'TssbInflows
        '
        Me.TssbInflows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbInflows.Image = CType(resources.GetObject("TssbInflows.Image"), System.Drawing.Image)
        Me.TssbInflows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbInflows.Name = "TssbInflows"
        Me.TssbInflows.Size = New System.Drawing.Size(61, 20)
        Me.TssbInflows.Text = "Inflows"
        '
        'TssbDemands
        '
        Me.TssbDemands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbDemands.Image = CType(resources.GetObject("TssbDemands.Image"), System.Drawing.Image)
        Me.TssbDemands.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbDemands.Name = "TssbDemands"
        Me.TssbDemands.Size = New System.Drawing.Size(73, 20)
        Me.TssbDemands.Text = "Demands"
        '
        'TssbGAEngine
        '
        Me.TssbGAEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbGAEngine.Image = CType(resources.GetObject("TssbGAEngine.Image"), System.Drawing.Image)
        Me.TssbGAEngine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbGAEngine.Name = "TssbGAEngine"
        Me.TssbGAEngine.Size = New System.Drawing.Size(39, 20)
        Me.TssbGAEngine.Text = "GA"
        '
        'TssbGSAEngine
        '
        Me.TssbGSAEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbGSAEngine.Image = CType(resources.GetObject("TssbGSAEngine.Image"), System.Drawing.Image)
        Me.TssbGSAEngine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbGSAEngine.Name = "TssbGSAEngine"
        Me.TssbGSAEngine.Size = New System.Drawing.Size(45, 20)
        Me.TssbGSAEngine.Text = "GSA"
        '
        'TssbGWOEngine
        '
        Me.TssbGWOEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbGWOEngine.Image = CType(resources.GetObject("TssbGWOEngine.Image"), System.Drawing.Image)
        Me.TssbGWOEngine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbGWOEngine.Name = "TssbGWOEngine"
        Me.TssbGWOEngine.Size = New System.Drawing.Size(51, 20)
        Me.TssbGWOEngine.Text = "GWO"
        '
        'TssbResultsTables
        '
        Me.TssbResultsTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbResultsTables.Image = CType(resources.GetObject("TssbResultsTables.Image"), System.Drawing.Image)
        Me.TssbResultsTables.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbResultsTables.Name = "TssbResultsTables"
        Me.TssbResultsTables.Size = New System.Drawing.Size(67, 20)
        Me.TssbResultsTables.Text = "R.Tables"
        '
        'TssbResultsGrpahics
        '
        Me.TssbResultsGrpahics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TssbResultsGrpahics.Image = CType(resources.GetObject("TssbResultsGrpahics.Image"), System.Drawing.Image)
        Me.TssbResultsGrpahics.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TssbResultsGrpahics.Name = "TssbResultsGrpahics"
        Me.TssbResultsGrpahics.Size = New System.Drawing.Size(79, 20)
        Me.TssbResultsGrpahics.Text = "R.Graphics"
        '
        'MainSplitContainer
        '
        Me.MainSplitContainer.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSplitContainer.Location = New System.Drawing.Point(0, 51)
        Me.MainSplitContainer.Name = "MainSplitContainer"
        '
        'MainSplitContainer.Panel2
        '
        Me.MainSplitContainer.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.MainSplitContainer.Size = New System.Drawing.Size(949, 368)
        Me.MainSplitContainer.SplitterDistance = 798
        Me.MainSplitContainer.SplitterWidth = 6
        Me.MainSplitContainer.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainer2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(145, 368)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(139, 22)
        Me.ComboBox1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 31)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.MainTreeView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBox1)
        Me.SplitContainer2.Size = New System.Drawing.Size(139, 334)
        Me.SplitContainer2.SplitterDistance = 288
        Me.SplitContainer2.TabIndex = 1
        '
        'MainTreeView
        '
        Me.MainTreeView.ContextMenuStrip = Me.CxtMnuTreeView
        Me.MainTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTreeView.Location = New System.Drawing.Point(0, 0)
        Me.MainTreeView.Name = "MainTreeView"
        TreeNode1.Name = "NdReservoirConfig"
        TreeNode1.Text = "Reservoir Configuration"
        TreeNode2.Name = "NdEvaporationSeries"
        TreeNode2.Text = "Evaporation"
        TreeNode3.Name = "NdInfiltrationSeries"
        TreeNode3.Text = "Infiltration"
        TreeNode4.Name = "NdReservoir"
        TreeNode4.Text = "Reservoir"
        TreeNode5.Name = "NdInflows"
        TreeNode5.Text = "Inflows"
        TreeNode6.Name = "NdDemands"
        TreeNode6.Text = "Demand Model"
        TreeNode7.Name = "NdDataSeries"
        TreeNode7.Text = "Data Series"
        TreeNode8.Name = "NdGeneticAlgo"
        TreeNode8.Text = "Genetic Algorithm "
        TreeNode9.Name = "NdGSAlog"
        TreeNode9.Text = "Gravitational Search Algorithm"
        TreeNode10.Name = "NdGWOAlgo"
        TreeNode10.Text = "Grey Wolf Optimizer"
        TreeNode11.Name = "NdOptimization"
        TreeNode11.Text = "Optimization"
        TreeNode12.Name = "NdPerformanceIndxs"
        TreeNode12.Text = "Performance"
        TreeNode13.Name = "NdComparaison"
        TreeNode13.Text = "Comparaison"
        TreeNode14.Name = "NdPerformanceAnalysis"
        TreeNode14.Text = "Performance Analysis"
        Me.MainTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode7, TreeNode11, TreeNode14})
        Me.MainTreeView.Size = New System.Drawing.Size(139, 288)
        Me.MainTreeView.TabIndex = 1
        '
        'CxtMnuTreeView
        '
        Me.CxtMnuTreeView.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMnuTreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CxtTsmiNew})
        Me.CxtMnuTreeView.Name = "CxtMnuTreeView"
        Me.CxtMnuTreeView.Size = New System.Drawing.Size(99, 26)
        '
        'CxtTsmiNew
        '
        Me.CxtTsmiNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CxtMnuNewInflowSerie, Me.CxtMnuNewDemand})
        Me.CxtTsmiNew.Name = "CxtTsmiNew"
        Me.CxtTsmiNew.Size = New System.Drawing.Size(98, 22)
        Me.CxtTsmiNew.Text = "New"
        '
        'CxtMnuNewInflowSerie
        '
        Me.CxtMnuNewInflowSerie.Name = "CxtMnuNewInflowSerie"
        Me.CxtMnuNewInflowSerie.Size = New System.Drawing.Size(152, 22)
        Me.CxtMnuNewInflowSerie.Text = "Inflows Serie"
        '
        'CxtMnuNewDemand
        '
        Me.CxtMnuNewDemand.Name = "CxtMnuNewDemand"
        Me.CxtMnuNewDemand.Size = New System.Drawing.Size(152, 22)
        Me.CxtMnuNewDemand.Text = "Demands Serie"
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(139, 42)
        Me.TextBox1.TabIndex = 2
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 441)
        Me.Controls.Add(Me.MainSplitContainer)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "RMOSS (Beta)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MainSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainSplitContainer.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.CxtMnuTreeView.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MainSplitContainer As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents MainTreeView As TreeView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents MnuFile As ToolStripMenuItem
    Friend WithEvents TsmiNewProject As ToolStripMenuItem
    Friend WithEvents TsmiOpenProject As ToolStripMenuItem
    Friend WithEvents TsmiSave As ToolStripMenuItem
    Friend WithEvents TsmiSaveAs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TsmExit As ToolStripMenuItem
    Friend WithEvents CxtMnuTreeView As ContextMenuStrip
    Friend WithEvents CxtTsmiNew As ToolStripMenuItem
    Friend WithEvents CxtMnuNewInflowSerie As ToolStripMenuItem
    Friend WithEvents CxtMnuNewDemand As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TsmData As ToolStripMenuItem
    Friend WithEvents TsmOptimization As ToolStripMenuItem
    Friend WithEvents TsmHelp As ToolStripMenuItem
    Friend WithEvents TsmGeneticAlgo As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents TsmGSAlgo As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents TsmGWOAlgo As ToolStripMenuItem
    Friend WithEvents TsmiReservoir As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents TsmiInflows As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents TsmiExploitation As ToolStripMenuItem
    Friend WithEvents TsmiGeneticAlgoOptimzation As ToolStripMenuItem
    Friend WithEvents TsmiGaTables As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripMenuItem
    Friend WithEvents TsmiGSAOptimization As ToolStripMenuItem
    Friend WithEvents TsmiGsaTables As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripMenuItem
    Friend WithEvents TsmiGWOPtimization As ToolStripMenuItem
    Friend WithEvents TsmiGwoTables As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripMenuItem
    Friend WithEvents TsmPerformance As ToolStripMenuItem
    Friend WithEvents TsmiPerformance As ToolStripMenuItem
    Friend WithEvents TsmComparaison As ToolStripMenuItem
    Friend WithEvents TsmWindows As ToolStripMenuItem
    Friend WithEvents TsmiHorizontal As ToolStripMenuItem
    Friend WithEvents TsmiVertical As ToolStripMenuItem
    Friend WithEvents TsmiCascade As ToolStripMenuItem
    Friend WithEvents TsmiMosaic As ToolStripMenuItem
    Friend WithEvents TsmForecasting As ToolStripMenuItem
    Friend WithEvents TsmiNeuralNetwork As ToolStripMenuItem
    Friend WithEvents TssbReservoir As ToolStripSplitButton
    Friend WithEvents TssbInflows As ToolStripSplitButton
    Friend WithEvents TssbDemands As ToolStripSplitButton
    Friend WithEvents TssbGAEngine As ToolStripSplitButton
    Friend WithEvents TssbGSAEngine As ToolStripSplitButton
    Friend WithEvents TssbGWOEngine As ToolStripSplitButton
    Friend WithEvents TssbResultsTables As ToolStripSplitButton
    Friend WithEvents TssbResultsGrpahics As ToolStripSplitButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents TsmHPSOGWOAlgo As ToolStripMenuItem
    Friend WithEvents TsmiHPSOGWOptimization As ToolStripMenuItem
    Friend WithEvents TsmiTsmiHPSOGWOTables As ToolStripMenuItem
    Friend WithEvents TsmiHPSOGWOGraphics As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents TsmiAsynchronOptimFrm As ToolStripMenuItem
    Friend WithEvents TsbNewProject As ToolStripButton
    Friend WithEvents TsbOpenProject As ToolStripButton
    Friend WithEvents TsbSave As ToolStripButton
    Friend WithEvents TsbSaveAs As ToolStripButton
    Friend WithEvents TssSavedLable As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents TsmiNeuralNetEOA As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
End Class
