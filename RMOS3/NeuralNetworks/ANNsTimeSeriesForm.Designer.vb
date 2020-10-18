<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ANNsTimeSeriesForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.DataTabPage = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CmbInputsFileType = New System.Windows.Forms.ComboBox()
        Me.BtnImportInputs = New System.Windows.Forms.Button()
        Me.PrptGrdInput = New System.Windows.Forms.PropertyGrid()
        Me.DataChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPageDataStructure = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtyGrdAnnData = New System.Windows.Forms.PropertyGrid()
        Me.BtnFormateDataSerie = New System.Windows.Forms.Button()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TrainingTestingTabPage = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtyGrdAnnStructure = New System.Windows.Forms.PropertyGrid()
        Me.BtnLuanchTraining = New System.Windows.Forms.Button()
        Me.PrtyGrdNeuralNet = New System.Windows.Forms.PropertyGrid()
        Me.BtnComputeTrainingOuts = New System.Windows.Forms.Button()
        Me.SplitContainer9 = New System.Windows.Forms.SplitContainer()
        Me.ChartTrainingResults = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PrtyGrdTrainingIndexes = New System.Windows.Forms.PropertyGrid()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtyGrdTestinngIndexes = New System.Windows.Forms.PropertyGrid()
        Me.ChartTestingResults = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.MainTabControl.SuspendLayout()
        Me.DataTabPage.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageDataStructure.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TrainingTestingTabPage.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainer9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer9.Panel1.SuspendLayout()
        Me.SplitContainer9.Panel2.SuspendLayout()
        Me.SplitContainer9.SuspendLayout()
        CType(Me.ChartTrainingResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.ChartTestingResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.DataTabPage)
        Me.MainTabControl.Controls.Add(Me.TabPageDataStructure)
        Me.MainTabControl.Controls.Add(Me.TrainingTestingTabPage)
        Me.MainTabControl.Controls.Add(Me.TabPage1)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(998, 499)
        Me.MainTabControl.TabIndex = 0
        '
        'DataTabPage
        '
        Me.DataTabPage.Controls.Add(Me.SplitContainer1)
        Me.DataTabPage.Location = New System.Drawing.Point(4, 22)
        Me.DataTabPage.Name = "DataTabPage"
        Me.DataTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.DataTabPage.Size = New System.Drawing.Size(792, 424)
        Me.DataTabPage.TabIndex = 0
        Me.DataTabPage.Text = "Data"
        Me.DataTabPage.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataChart)
        Me.SplitContainer1.Size = New System.Drawing.Size(786, 418)
        Me.SplitContainer1.SplitterDistance = 262
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(262, 418)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import Training Data :"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CmbInputsFileType, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnImportInputs, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PrptGrdInput, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.58823!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41177!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(256, 401)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CmbInputsFileType
        '
        Me.CmbInputsFileType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbInputsFileType.FormattingEnabled = True
        Me.CmbInputsFileType.Items.AddRange(New Object() {"CSV", "DS1"})
        Me.CmbInputsFileType.Location = New System.Drawing.Point(3, 2)
        Me.CmbInputsFileType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbInputsFileType.Name = "CmbInputsFileType"
        Me.CmbInputsFileType.Size = New System.Drawing.Size(250, 21)
        Me.CmbInputsFileType.TabIndex = 0
        Me.CmbInputsFileType.Text = "Select File Type (Inputs)"
        '
        'BtnImportInputs
        '
        Me.BtnImportInputs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportInputs.Location = New System.Drawing.Point(3, 27)
        Me.BtnImportInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnImportInputs.Name = "BtnImportInputs"
        Me.BtnImportInputs.Size = New System.Drawing.Size(250, 32)
        Me.BtnImportInputs.TabIndex = 1
        Me.BtnImportInputs.Text = "Import Data (Inputs)"
        Me.BtnImportInputs.UseVisualStyleBackColor = True
        '
        'PrptGrdInput
        '
        Me.PrptGrdInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrptGrdInput.HelpVisible = False
        Me.PrptGrdInput.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrptGrdInput.Location = New System.Drawing.Point(3, 63)
        Me.PrptGrdInput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrptGrdInput.Name = "PrptGrdInput"
        Me.PrptGrdInput.Size = New System.Drawing.Size(250, 286)
        Me.PrptGrdInput.TabIndex = 4
        '
        'DataChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.DataChart.ChartAreas.Add(ChartArea1)
        Me.DataChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Name = "Legend1"
        Me.DataChart.Legends.Add(Legend1)
        Me.DataChart.Location = New System.Drawing.Point(0, 0)
        Me.DataChart.Name = "DataChart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.DataChart.Series.Add(Series1)
        Me.DataChart.Size = New System.Drawing.Size(520, 418)
        Me.DataChart.TabIndex = 1
        Me.DataChart.Text = "Chart1"
        '
        'TabPageDataStructure
        '
        Me.TabPageDataStructure.Controls.Add(Me.SplitContainer2)
        Me.TabPageDataStructure.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDataStructure.Name = "TabPageDataStructure"
        Me.TabPageDataStructure.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDataStructure.Size = New System.Drawing.Size(990, 473)
        Me.TabPageDataStructure.TabIndex = 1
        Me.TabPageDataStructure.Text = "ANN-Data Structure"
        Me.TabPageDataStructure.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(984, 467)
        Me.SplitContainer2.SplitterDistance = 328
        Me.SplitContainer2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PrtyGrdAnnData, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnFormateDataSerie, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(328, 467)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'PrtyGrdAnnData
        '
        Me.PrtyGrdAnnData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdAnnData.Location = New System.Drawing.Point(3, 73)
        Me.PrtyGrdAnnData.Name = "PrtyGrdAnnData"
        Me.PrtyGrdAnnData.Size = New System.Drawing.Size(322, 391)
        Me.PrtyGrdAnnData.TabIndex = 7
        '
        'BtnFormateDataSerie
        '
        Me.BtnFormateDataSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFormateDataSerie.Location = New System.Drawing.Point(3, 25)
        Me.BtnFormateDataSerie.Name = "BtnFormateDataSerie"
        Me.BtnFormateDataSerie.Size = New System.Drawing.Size(322, 40)
        Me.BtnFormateDataSerie.TabIndex = 6
        Me.BtnFormateDataSerie.Text = "Formate Data Serie"
        Me.BtnFormateDataSerie.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Chart1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Chart2)
        Me.SplitContainer3.Size = New System.Drawing.Size(652, 467)
        Me.SplitContainer3.SplitterDistance = 233
        Me.SplitContainer3.TabIndex = 8
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(652, 233)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Chart2
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea3)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Fill
        Legend3.Alignment = System.Drawing.StringAlignment.Center
        Legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend3.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend3)
        Me.Chart2.Location = New System.Drawing.Point(0, 0)
        Me.Chart2.Name = "Chart2"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart2.Series.Add(Series3)
        Me.Chart2.Size = New System.Drawing.Size(652, 230)
        Me.Chart2.TabIndex = 1
        Me.Chart2.Text = "Chart2"
        '
        'TrainingTestingTabPage
        '
        Me.TrainingTestingTabPage.Controls.Add(Me.SplitContainer4)
        Me.TrainingTestingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.TrainingTestingTabPage.Name = "TrainingTestingTabPage"
        Me.TrainingTestingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TrainingTestingTabPage.Size = New System.Drawing.Size(990, 473)
        Me.TrainingTestingTabPage.TabIndex = 2
        Me.TrainingTestingTabPage.Text = "Training-Testing"
        Me.TrainingTestingTabPage.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(792, 424)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.TableLayoutPanel3)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer9)
        Me.SplitContainer4.Size = New System.Drawing.Size(984, 467)
        Me.SplitContainer4.SplitterDistance = 328
        Me.SplitContainer4.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.PrtyGrdAnnStructure, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnLuanchTraining, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.PrtyGrdNeuralNet, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnComputeTrainingOuts, 0, 3)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(328, 467)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'PrtyGrdAnnStructure
        '
        Me.PrtyGrdAnnStructure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdAnnStructure.HelpVisible = False
        Me.PrtyGrdAnnStructure.Location = New System.Drawing.Point(3, 13)
        Me.PrtyGrdAnnStructure.Name = "PrtyGrdAnnStructure"
        Me.PrtyGrdAnnStructure.Size = New System.Drawing.Size(322, 125)
        Me.PrtyGrdAnnStructure.TabIndex = 3
        '
        'BtnLuanchTraining
        '
        Me.BtnLuanchTraining.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLuanchTraining.Location = New System.Drawing.Point(3, 145)
        Me.BtnLuanchTraining.Name = "BtnLuanchTraining"
        Me.BtnLuanchTraining.Size = New System.Drawing.Size(322, 32)
        Me.BtnLuanchTraining.TabIndex = 0
        Me.BtnLuanchTraining.Text = "Luanch New Training Operation"
        Me.BtnLuanchTraining.UseVisualStyleBackColor = True
        '
        'PrtyGrdNeuralNet
        '
        Me.PrtyGrdNeuralNet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdNeuralNet.HelpVisible = False
        Me.PrtyGrdNeuralNet.Location = New System.Drawing.Point(3, 224)
        Me.PrtyGrdNeuralNet.Name = "PrtyGrdNeuralNet"
        Me.PrtyGrdNeuralNet.Size = New System.Drawing.Size(322, 240)
        Me.PrtyGrdNeuralNet.TabIndex = 1
        '
        'BtnComputeTrainingOuts
        '
        Me.BtnComputeTrainingOuts.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnComputeTrainingOuts.Location = New System.Drawing.Point(3, 184)
        Me.BtnComputeTrainingOuts.Name = "BtnComputeTrainingOuts"
        Me.BtnComputeTrainingOuts.Size = New System.Drawing.Size(322, 34)
        Me.BtnComputeTrainingOuts.TabIndex = 4
        Me.BtnComputeTrainingOuts.Text = "Compute Training && Testing Outputs"
        Me.BtnComputeTrainingOuts.UseVisualStyleBackColor = True
        '
        'SplitContainer9
        '
        Me.SplitContainer9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer9.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer9.Name = "SplitContainer9"
        Me.SplitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer9.Panel1
        '
        Me.SplitContainer9.Panel1.Controls.Add(Me.TableLayoutPanel4)
        '
        'SplitContainer9.Panel2
        '
        Me.SplitContainer9.Panel2.Controls.Add(Me.TableLayoutPanel5)
        Me.SplitContainer9.Size = New System.Drawing.Size(652, 467)
        Me.SplitContainer9.SplitterDistance = 236
        Me.SplitContainer9.TabIndex = 1
        '
        'ChartTrainingResults
        '
        ChartArea4.Name = "ChartArea1"
        Me.ChartTrainingResults.ChartAreas.Add(ChartArea4)
        Me.ChartTrainingResults.Dock = System.Windows.Forms.DockStyle.Fill
        Legend4.Alignment = System.Drawing.StringAlignment.Center
        Legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend4.Name = "Legend1"
        Me.ChartTrainingResults.Legends.Add(Legend4)
        Me.ChartTrainingResults.Location = New System.Drawing.Point(3, 3)
        Me.ChartTrainingResults.Name = "ChartTrainingResults"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.ChartTrainingResults.Series.Add(Series4)
        Me.ChartTrainingResults.Size = New System.Drawing.Size(427, 230)
        Me.ChartTrainingResults.TabIndex = 0
        Me.ChartTrainingResults.Text = "Chart3"
        '
        'PrtyGrdTrainingIndexes
        '
        Me.PrtyGrdTrainingIndexes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdTrainingIndexes.Location = New System.Drawing.Point(436, 3)
        Me.PrtyGrdTrainingIndexes.Name = "PrtyGrdTrainingIndexes"
        Me.PrtyGrdTrainingIndexes.Size = New System.Drawing.Size(213, 230)
        Me.PrtyGrdTrainingIndexes.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.PrtyGrdTrainingIndexes, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ChartTrainingResults, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(652, 236)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.ChartTestingResults, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.PrtyGrdTestinngIndexes, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(652, 227)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'PrtyGrdTestinngIndexes
        '
        Me.PrtyGrdTestinngIndexes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdTestinngIndexes.Location = New System.Drawing.Point(459, 3)
        Me.PrtyGrdTestinngIndexes.Name = "PrtyGrdTestinngIndexes"
        Me.PrtyGrdTestinngIndexes.Size = New System.Drawing.Size(190, 221)
        Me.PrtyGrdTestinngIndexes.TabIndex = 1
        '
        'ChartTestingResults
        '
        ChartArea5.Name = "ChartArea1"
        Me.ChartTestingResults.ChartAreas.Add(ChartArea5)
        Me.ChartTestingResults.Dock = System.Windows.Forms.DockStyle.Fill
        Legend5.Alignment = System.Drawing.StringAlignment.Center
        Legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend5.Name = "Legend1"
        Me.ChartTestingResults.Legends.Add(Legend5)
        Me.ChartTestingResults.Location = New System.Drawing.Point(3, 3)
        Me.ChartTestingResults.Name = "ChartTestingResults"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        Me.ChartTestingResults.Series.Add(Series5)
        Me.ChartTestingResults.Size = New System.Drawing.Size(450, 221)
        Me.ChartTestingResults.TabIndex = 2
        Me.ChartTestingResults.Text = "ChartTestingResults"
        '
        'ANNsTimeSeriesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 499)
        Me.Controls.Add(Me.MainTabControl)
        Me.Name = "ANNsTimeSeriesForm"
        Me.Text = "ANN  for Time Series"
        Me.MainTabControl.ResumeLayout(False)
        Me.DataTabPage.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageDataStructure.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TrainingTestingTabPage.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.SplitContainer9.Panel1.ResumeLayout(False)
        Me.SplitContainer9.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer9.ResumeLayout(False)
        CType(Me.ChartTrainingResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.ChartTestingResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainTabControl As TabControl
    Friend WithEvents DataTabPage As TabPage
    Friend WithEvents TabPageDataStructure As TabPage
    Friend WithEvents TrainingTestingTabPage As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CmbInputsFileType As ComboBox
    Friend WithEvents BtnImportInputs As Button
    Friend WithEvents PrptGrdInput As PropertyGrid
    Friend WithEvents DataChart As DataVisualization.Charting.Chart
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PrtyGrdAnnData As PropertyGrid
    Friend WithEvents BtnFormateDataSerie As Button
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents PrtyGrdAnnStructure As PropertyGrid
    Friend WithEvents BtnLuanchTraining As Button
    Friend WithEvents PrtyGrdNeuralNet As PropertyGrid
    Friend WithEvents BtnComputeTrainingOuts As Button
    Friend WithEvents SplitContainer9 As SplitContainer
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents PrtyGrdTrainingIndexes As PropertyGrid
    Friend WithEvents ChartTrainingResults As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents PrtyGrdTestinngIndexes As PropertyGrid
    Friend WithEvents ChartTestingResults As DataVisualization.Charting.Chart
End Class
