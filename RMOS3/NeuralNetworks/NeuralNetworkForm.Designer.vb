<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NeuralNetworkForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NeuralNetworkForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TpgTrainingData = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnImportTrainOutputs = New System.Windows.Forms.Button()
        Me.CmbTrainInputsFileType = New System.Windows.Forms.ComboBox()
        Me.BtnImportTrainInputs = New System.Windows.Forms.Button()
        Me.CmbTrainOutputsFileType = New System.Windows.Forms.ComboBox()
        Me.PrptGrdTrainingInput = New System.Windows.Forms.PropertyGrid()
        Me.PrptGrdTrainingOutput = New System.Windows.Forms.PropertyGrid()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DgvTrainingInputs = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DgvTrainingOutputs = New System.Windows.Forms.DataGridView()
        Me.TpgTestingData = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnImportTestingOutputs = New System.Windows.Forms.Button()
        Me.CmbTestInputsFileType = New System.Windows.Forms.ComboBox()
        Me.BtnImportTestingInputs = New System.Windows.Forms.Button()
        Me.CmbTestOutputsFileType = New System.Windows.Forms.ComboBox()
        Me.PrptGrdTestingInput = New System.Windows.Forms.PropertyGrid()
        Me.PrptGrdTestingOutput = New System.Windows.Forms.PropertyGrid()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DgvTestingInputs = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.DgvTestingOutputs = New System.Windows.Forms.DataGridView()
        Me.TpgNeuralNetworkParams = New System.Windows.Forms.TabPage()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrptyGrdNeuralNet = New System.Windows.Forms.PropertyGrid()
        Me.BtnLuanchTraining = New System.Windows.Forms.Button()
        Me.PrptyGrdNeuralNetStruct = New System.Windows.Forms.PropertyGrid()
        Me.SplitContainer14 = New System.Windows.Forms.SplitContainer()
        Me.ChartTraining = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.CxmChartANNResults = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CxmiLoadNeuralNet = New System.Windows.Forms.ToolStripMenuItem()
        Me.CxmiSaveNeuralNetwork = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CxmiSaveTrainingResults = New System.Windows.Forms.ToolStripMenuItem()
        Me.CxmiSaveTestingResults = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtGrdTrainingIndexes = New System.Windows.Forms.PropertyGrid()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.TpgValidationResults = New System.Windows.Forms.TabPage()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer11 = New System.Windows.Forms.SplitContainer()
        Me.BtnLuanchTesting = New System.Windows.Forms.Button()
        Me.DgvValidationResults = New System.Windows.Forms.DataGridView()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer15 = New System.Windows.Forms.SplitContainer()
        Me.PrtyGrdPerformCriteria = New System.Windows.Forms.PropertyGrid()
        Me.PropertyGrid2 = New System.Windows.Forms.PropertyGrid()
        Me.BtnComputeIndexes = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.ChartValidationResults = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TpgForecasting = New System.Windows.Forms.TabPage()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnLuanchForecasting = New System.Windows.Forms.Button()
        Me.PrtyGrdForecasting = New System.Windows.Forms.PropertyGrid()
        Me.BtnExportForecastingResults = New System.Windows.Forms.Button()
        Me.SplitContainer8 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.DgvForecastingResults = New System.Windows.Forms.DataGridView()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.ChartForecasting = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer9 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnImportDataSerie = New System.Windows.Forms.Button()
        Me.CmbfileFormat = New System.Windows.Forms.ComboBox()
        Me.CmbAggregationCount = New System.Windows.Forms.ComboBox()
        Me.BtnAggregateData = New System.Windows.Forms.Button()
        Me.BtnExportDataSerie = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SplitContainer10 = New System.Windows.Forms.SplitContainer()
        Me.DgvInputData = New System.Windows.Forms.DataGridView()
        Me.DgvOutputData = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer12 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer13 = New System.Windows.Forms.SplitContainer()
        Me.BtnLuanchOptimization = New System.Windows.Forms.Button()
        Me.PrtGrdAnnOptimizer = New System.Windows.Forms.PropertyGrid()
        Me.LbxSolutionsHistory = New System.Windows.Forms.ListBox()
        Me.BestFitnessChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabControl1.SuspendLayout()
        Me.TpgTrainingData.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvTrainingInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgvTrainingOutputs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpgTestingData.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DgvTestingInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DgvTestingOutputs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpgNeuralNetworkParams.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainer14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer14.Panel1.SuspendLayout()
        Me.SplitContainer14.Panel2.SuspendLayout()
        Me.SplitContainer14.SuspendLayout()
        CType(Me.ChartTraining, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxmChartANNResults.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TpgValidationResults.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.SplitContainer11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer11.Panel1.SuspendLayout()
        Me.SplitContainer11.Panel2.SuspendLayout()
        Me.SplitContainer11.SuspendLayout()
        CType(Me.DgvValidationResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        CType(Me.SplitContainer15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer15.Panel1.SuspendLayout()
        Me.SplitContainer15.Panel2.SuspendLayout()
        Me.SplitContainer15.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.ChartValidationResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpgForecasting.SuspendLayout()
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer8.Panel1.SuspendLayout()
        Me.SplitContainer8.Panel2.SuspendLayout()
        Me.SplitContainer8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.DgvForecastingResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.ChartForecasting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer9.Panel1.SuspendLayout()
        Me.SplitContainer9.Panel2.SuspendLayout()
        Me.SplitContainer9.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.SplitContainer10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer10.Panel1.SuspendLayout()
        Me.SplitContainer10.Panel2.SuspendLayout()
        Me.SplitContainer10.SuspendLayout()
        CType(Me.DgvInputData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvOutputData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer12.Panel1.SuspendLayout()
        Me.SplitContainer12.Panel2.SuspendLayout()
        Me.SplitContainer12.SuspendLayout()
        CType(Me.SplitContainer13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer13.Panel1.SuspendLayout()
        Me.SplitContainer13.Panel2.SuspendLayout()
        Me.SplitContainer13.SuspendLayout()
        CType(Me.BestFitnessChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TpgTrainingData)
        Me.TabControl1.Controls.Add(Me.TpgTestingData)
        Me.TabControl1.Controls.Add(Me.TpgNeuralNetworkParams)
        Me.TabControl1.Controls.Add(Me.TpgValidationResults)
        Me.TabControl1.Controls.Add(Me.TpgForecasting)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1196, 455)
        Me.TabControl1.TabIndex = 0
        '
        'TpgTrainingData
        '
        Me.TpgTrainingData.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TpgTrainingData.Controls.Add(Me.SplitContainer1)
        Me.TpgTrainingData.Location = New System.Drawing.Point(4, 22)
        Me.TpgTrainingData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgTrainingData.Name = "TpgTrainingData"
        Me.TpgTrainingData.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgTrainingData.Size = New System.Drawing.Size(1188, 429)
        Me.TpgTrainingData.TabIndex = 0
        Me.TpgTrainingData.Text = "Training Data "
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 2)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1182, 425)
        Me.SplitContainer1.SplitterDistance = 323
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
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
        Me.GroupBox1.Size = New System.Drawing.Size(323, 425)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import Training Data :"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnImportTrainOutputs, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbTrainInputsFileType, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnImportTrainInputs, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbTrainOutputsFileType, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.PrptGrdTrainingInput, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PrptGrdTrainingOutput, 0, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(317, 408)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'BtnImportTrainOutputs
        '
        Me.BtnImportTrainOutputs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportTrainOutputs.Location = New System.Drawing.Point(3, 231)
        Me.BtnImportTrainOutputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnImportTrainOutputs.Name = "BtnImportTrainOutputs"
        Me.BtnImportTrainOutputs.Size = New System.Drawing.Size(311, 32)
        Me.BtnImportTrainOutputs.TabIndex = 3
        Me.BtnImportTrainOutputs.Text = "Import Data (Outputs)"
        Me.BtnImportTrainOutputs.UseVisualStyleBackColor = True
        '
        'CmbTrainInputsFileType
        '
        Me.CmbTrainInputsFileType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbTrainInputsFileType.FormattingEnabled = True
        Me.CmbTrainInputsFileType.Location = New System.Drawing.Point(3, 2)
        Me.CmbTrainInputsFileType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbTrainInputsFileType.Name = "CmbTrainInputsFileType"
        Me.CmbTrainInputsFileType.Size = New System.Drawing.Size(311, 21)
        Me.CmbTrainInputsFileType.TabIndex = 0
        Me.CmbTrainInputsFileType.Text = "Select File Type (Inputs)"
        '
        'BtnImportTrainInputs
        '
        Me.BtnImportTrainInputs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportTrainInputs.Location = New System.Drawing.Point(3, 27)
        Me.BtnImportTrainInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnImportTrainInputs.Name = "BtnImportTrainInputs"
        Me.BtnImportTrainInputs.Size = New System.Drawing.Size(311, 32)
        Me.BtnImportTrainInputs.TabIndex = 1
        Me.BtnImportTrainInputs.Text = "Import Data (Inputs)"
        Me.BtnImportTrainInputs.UseVisualStyleBackColor = True
        '
        'CmbTrainOutputsFileType
        '
        Me.CmbTrainOutputsFileType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbTrainOutputsFileType.FormattingEnabled = True
        Me.CmbTrainOutputsFileType.Location = New System.Drawing.Point(3, 206)
        Me.CmbTrainOutputsFileType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbTrainOutputsFileType.Name = "CmbTrainOutputsFileType"
        Me.CmbTrainOutputsFileType.Size = New System.Drawing.Size(311, 21)
        Me.CmbTrainOutputsFileType.TabIndex = 2
        Me.CmbTrainOutputsFileType.Text = "Select File Type (Outputs)"
        '
        'PrptGrdTrainingInput
        '
        Me.PrptGrdTrainingInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrptGrdTrainingInput.HelpVisible = False
        Me.PrptGrdTrainingInput.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrptGrdTrainingInput.Location = New System.Drawing.Point(3, 63)
        Me.PrptGrdTrainingInput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrptGrdTrainingInput.Name = "PrptGrdTrainingInput"
        Me.PrptGrdTrainingInput.Size = New System.Drawing.Size(311, 139)
        Me.PrptGrdTrainingInput.TabIndex = 4
        '
        'PrptGrdTrainingOutput
        '
        Me.PrptGrdTrainingOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrptGrdTrainingOutput.HelpVisible = False
        Me.PrptGrdTrainingOutput.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrptGrdTrainingOutput.Location = New System.Drawing.Point(3, 267)
        Me.PrptGrdTrainingOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrptGrdTrainingOutput.Name = "PrptGrdTrainingOutput"
        Me.PrptGrdTrainingOutput.Size = New System.Drawing.Size(311, 139)
        Me.PrptGrdTrainingOutput.TabIndex = 5
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer2.Size = New System.Drawing.Size(856, 425)
        Me.SplitContainer2.SplitterDistance = 518
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.DgvTrainingInputs)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(518, 425)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Training Inputs :"
        '
        'DgvTrainingInputs
        '
        Me.DgvTrainingInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrainingInputs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrainingInputs.Location = New System.Drawing.Point(3, 15)
        Me.DgvTrainingInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvTrainingInputs.Name = "DgvTrainingInputs"
        Me.DgvTrainingInputs.RowTemplate.Height = 26
        Me.DgvTrainingInputs.Size = New System.Drawing.Size(512, 408)
        Me.DgvTrainingInputs.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.DgvTrainingOutputs)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(335, 425)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Training Outputs :"
        '
        'DgvTrainingOutputs
        '
        Me.DgvTrainingOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrainingOutputs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrainingOutputs.Location = New System.Drawing.Point(3, 15)
        Me.DgvTrainingOutputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvTrainingOutputs.Name = "DgvTrainingOutputs"
        Me.DgvTrainingOutputs.RowTemplate.Height = 26
        Me.DgvTrainingOutputs.Size = New System.Drawing.Size(329, 408)
        Me.DgvTrainingOutputs.TabIndex = 1
        '
        'TpgTestingData
        '
        Me.TpgTestingData.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TpgTestingData.Controls.Add(Me.SplitContainer3)
        Me.TpgTestingData.Location = New System.Drawing.Point(4, 22)
        Me.TpgTestingData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgTestingData.Name = "TpgTestingData"
        Me.TpgTestingData.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgTestingData.Size = New System.Drawing.Size(1188, 429)
        Me.TpgTestingData.TabIndex = 1
        Me.TpgTestingData.Text = "Validation Data"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 2)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox4)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(1182, 425)
        Me.SplitContainer3.SplitterDistance = 453
        Me.SplitContainer3.SplitterWidth = 3
        Me.SplitContainer3.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(453, 425)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Import Validation (Testing) Data :"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnImportTestingOutputs, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbTestInputsFileType, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnImportTestingInputs, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbTestOutputsFileType, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.PrptGrdTestingInput, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.PrptGrdTestingOutput, 0, 5)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(447, 408)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'BtnImportTestingOutputs
        '
        Me.BtnImportTestingOutputs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportTestingOutputs.Location = New System.Drawing.Point(3, 231)
        Me.BtnImportTestingOutputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnImportTestingOutputs.Name = "BtnImportTestingOutputs"
        Me.BtnImportTestingOutputs.Size = New System.Drawing.Size(441, 32)
        Me.BtnImportTestingOutputs.TabIndex = 3
        Me.BtnImportTestingOutputs.Text = "Import Data (Outputs)"
        Me.BtnImportTestingOutputs.UseVisualStyleBackColor = True
        '
        'CmbTestInputsFileType
        '
        Me.CmbTestInputsFileType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbTestInputsFileType.FormattingEnabled = True
        Me.CmbTestInputsFileType.Location = New System.Drawing.Point(3, 2)
        Me.CmbTestInputsFileType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbTestInputsFileType.Name = "CmbTestInputsFileType"
        Me.CmbTestInputsFileType.Size = New System.Drawing.Size(441, 21)
        Me.CmbTestInputsFileType.TabIndex = 0
        Me.CmbTestInputsFileType.Text = "Select File Type (Inputs)"
        '
        'BtnImportTestingInputs
        '
        Me.BtnImportTestingInputs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportTestingInputs.Location = New System.Drawing.Point(3, 27)
        Me.BtnImportTestingInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnImportTestingInputs.Name = "BtnImportTestingInputs"
        Me.BtnImportTestingInputs.Size = New System.Drawing.Size(441, 32)
        Me.BtnImportTestingInputs.TabIndex = 1
        Me.BtnImportTestingInputs.Text = "Import Data (Inputs)"
        Me.BtnImportTestingInputs.UseVisualStyleBackColor = True
        '
        'CmbTestOutputsFileType
        '
        Me.CmbTestOutputsFileType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbTestOutputsFileType.FormattingEnabled = True
        Me.CmbTestOutputsFileType.Location = New System.Drawing.Point(3, 206)
        Me.CmbTestOutputsFileType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbTestOutputsFileType.Name = "CmbTestOutputsFileType"
        Me.CmbTestOutputsFileType.Size = New System.Drawing.Size(441, 21)
        Me.CmbTestOutputsFileType.TabIndex = 2
        Me.CmbTestOutputsFileType.Text = "Select File Type (Outputs)"
        '
        'PrptGrdTestingInput
        '
        Me.PrptGrdTestingInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrptGrdTestingInput.HelpVisible = False
        Me.PrptGrdTestingInput.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrptGrdTestingInput.Location = New System.Drawing.Point(3, 63)
        Me.PrptGrdTestingInput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrptGrdTestingInput.Name = "PrptGrdTestingInput"
        Me.PrptGrdTestingInput.Size = New System.Drawing.Size(441, 139)
        Me.PrptGrdTestingInput.TabIndex = 4
        '
        'PrptGrdTestingOutput
        '
        Me.PrptGrdTestingOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrptGrdTestingOutput.HelpVisible = False
        Me.PrptGrdTestingOutput.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrptGrdTestingOutput.Location = New System.Drawing.Point(3, 267)
        Me.PrptGrdTestingOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrptGrdTestingOutput.Name = "PrptGrdTestingOutput"
        Me.PrptGrdTestingOutput.Size = New System.Drawing.Size(441, 139)
        Me.PrptGrdTestingOutput.TabIndex = 5
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.GroupBox5)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.GroupBox6)
        Me.SplitContainer4.Size = New System.Drawing.Size(726, 425)
        Me.SplitContainer4.SplitterDistance = 439
        Me.SplitContainer4.SplitterWidth = 3
        Me.SplitContainer4.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.DgvTestingInputs)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Size = New System.Drawing.Size(439, 425)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Testing Inputs :"
        '
        'DgvTestingInputs
        '
        Me.DgvTestingInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTestingInputs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTestingInputs.Location = New System.Drawing.Point(3, 15)
        Me.DgvTestingInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvTestingInputs.Name = "DgvTestingInputs"
        Me.DgvTestingInputs.RowTemplate.Height = 26
        Me.DgvTestingInputs.Size = New System.Drawing.Size(433, 408)
        Me.DgvTestingInputs.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox6.Controls.Add(Me.DgvTestingOutputs)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox6.Size = New System.Drawing.Size(284, 425)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Testing Outputs :"
        '
        'DgvTestingOutputs
        '
        Me.DgvTestingOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTestingOutputs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTestingOutputs.Location = New System.Drawing.Point(3, 15)
        Me.DgvTestingOutputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvTestingOutputs.Name = "DgvTestingOutputs"
        Me.DgvTestingOutputs.RowTemplate.Height = 26
        Me.DgvTestingOutputs.Size = New System.Drawing.Size(278, 408)
        Me.DgvTestingOutputs.TabIndex = 1
        '
        'TpgNeuralNetworkParams
        '
        Me.TpgNeuralNetworkParams.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TpgNeuralNetworkParams.Controls.Add(Me.SplitContainer5)
        Me.TpgNeuralNetworkParams.Location = New System.Drawing.Point(4, 22)
        Me.TpgNeuralNetworkParams.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgNeuralNetworkParams.Name = "TpgNeuralNetworkParams"
        Me.TpgNeuralNetworkParams.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgNeuralNetworkParams.Size = New System.Drawing.Size(1188, 429)
        Me.TpgNeuralNetworkParams.TabIndex = 2
        Me.TpgNeuralNetworkParams.Text = "Neural Network Parameters"
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(3, 2)
        Me.SplitContainer5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.TableLayoutPanel3)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.SplitContainer14)
        Me.SplitContainer5.Size = New System.Drawing.Size(1182, 425)
        Me.SplitContainer5.SplitterDistance = 391
        Me.SplitContainer5.SplitterWidth = 3
        Me.SplitContainer5.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.PrptyGrdNeuralNet, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnLuanchTraining, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.PrptyGrdNeuralNetStruct, 0, 3)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(391, 425)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'PrptyGrdNeuralNet
        '
        Me.PrptyGrdNeuralNet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrptyGrdNeuralNet.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrptyGrdNeuralNet.Location = New System.Drawing.Point(3, 157)
        Me.PrptyGrdNeuralNet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrptyGrdNeuralNet.Name = "PrptyGrdNeuralNet"
        Me.PrptyGrdNeuralNet.Size = New System.Drawing.Size(385, 266)
        Me.PrptyGrdNeuralNet.TabIndex = 1
        '
        'BtnLuanchTraining
        '
        Me.BtnLuanchTraining.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLuanchTraining.Location = New System.Drawing.Point(3, 6)
        Me.BtnLuanchTraining.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnLuanchTraining.Name = "BtnLuanchTraining"
        Me.BtnLuanchTraining.Size = New System.Drawing.Size(385, 32)
        Me.BtnLuanchTraining.TabIndex = 0
        Me.BtnLuanchTraining.Text = "Training (Teaching) "
        Me.BtnLuanchTraining.UseVisualStyleBackColor = True
        '
        'PrptyGrdNeuralNetStruct
        '
        Me.PrptyGrdNeuralNetStruct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrptyGrdNeuralNetStruct.HelpVisible = False
        Me.PrptyGrdNeuralNetStruct.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrptyGrdNeuralNetStruct.Location = New System.Drawing.Point(3, 42)
        Me.PrptyGrdNeuralNetStruct.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrptyGrdNeuralNetStruct.Name = "PrptyGrdNeuralNetStruct"
        Me.PrptyGrdNeuralNetStruct.Size = New System.Drawing.Size(385, 111)
        Me.PrptyGrdNeuralNetStruct.TabIndex = 3
        '
        'SplitContainer14
        '
        Me.SplitContainer14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer14.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer14.Name = "SplitContainer14"
        '
        'SplitContainer14.Panel1
        '
        Me.SplitContainer14.Panel1.Controls.Add(Me.ChartTraining)
        '
        'SplitContainer14.Panel2
        '
        Me.SplitContainer14.Panel2.Controls.Add(Me.TableLayoutPanel6)
        Me.SplitContainer14.Size = New System.Drawing.Size(788, 425)
        Me.SplitContainer14.SplitterDistance = 567
        Me.SplitContainer14.TabIndex = 1
        '
        'ChartTraining
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartTraining.ChartAreas.Add(ChartArea1)
        Me.ChartTraining.ContextMenuStrip = Me.CxmChartANNResults
        Me.ChartTraining.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Name = "Legend1"
        Me.ChartTraining.Legends.Add(Legend1)
        Me.ChartTraining.Location = New System.Drawing.Point(0, 0)
        Me.ChartTraining.Name = "ChartTraining"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartTraining.Series.Add(Series1)
        Me.ChartTraining.Size = New System.Drawing.Size(567, 425)
        Me.ChartTraining.TabIndex = 0
        Me.ChartTraining.Text = "Chart1"
        '
        'CxmChartANNResults
        '
        Me.CxmChartANNResults.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CxmiLoadNeuralNet, Me.CxmiSaveNeuralNetwork, Me.ToolStripSeparator1, Me.CxmiSaveTrainingResults, Me.CxmiSaveTestingResults})
        Me.CxmChartANNResults.Name = "CxmChartTraining"
        Me.CxmChartANNResults.Size = New System.Drawing.Size(232, 120)
        '
        'CxmiLoadNeuralNet
        '
        Me.CxmiLoadNeuralNet.Image = Global.RMOS3.My.Resources.Resources.open_load
        Me.CxmiLoadNeuralNet.Name = "CxmiLoadNeuralNet"
        Me.CxmiLoadNeuralNet.Size = New System.Drawing.Size(231, 22)
        Me.CxmiLoadNeuralNet.Text = "Load Neural Network"
        '
        'CxmiSaveNeuralNetwork
        '
        Me.CxmiSaveNeuralNetwork.Image = Global.RMOS3.My.Resources.Resources.document_save_5
        Me.CxmiSaveNeuralNetwork.Name = "CxmiSaveNeuralNetwork"
        Me.CxmiSaveNeuralNetwork.Size = New System.Drawing.Size(231, 22)
        Me.CxmiSaveNeuralNetwork.Text = "Save Artificial Neural Network"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(228, 6)
        '
        'CxmiSaveTrainingResults
        '
        Me.CxmiSaveTrainingResults.Image = Global.RMOS3.My.Resources.Resources.document_save_5
        Me.CxmiSaveTrainingResults.Name = "CxmiSaveTrainingResults"
        Me.CxmiSaveTrainingResults.Size = New System.Drawing.Size(231, 22)
        Me.CxmiSaveTrainingResults.Text = "Training results - Save As ..."
        '
        'CxmiSaveTestingResults
        '
        Me.CxmiSaveTestingResults.Image = Global.RMOS3.My.Resources.Resources.document_save_5
        Me.CxmiSaveTestingResults.Name = "CxmiSaveTestingResults"
        Me.CxmiSaveTestingResults.Size = New System.Drawing.Size(231, 22)
        Me.CxmiSaveTestingResults.Text = "Testing Results - Save As ..."
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.PrtGrdTrainingIndexes, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.PropertyGrid1, 0, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(217, 425)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'PrtGrdTrainingIndexes
        '
        Me.PrtGrdTrainingIndexes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtGrdTrainingIndexes.HelpVisible = False
        Me.PrtGrdTrainingIndexes.Location = New System.Drawing.Point(3, 3)
        Me.PrtGrdTrainingIndexes.Name = "PrtGrdTrainingIndexes"
        Me.PrtGrdTrainingIndexes.Size = New System.Drawing.Size(211, 210)
        Me.PrtGrdTrainingIndexes.TabIndex = 0
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.HelpVisible = False
        Me.PropertyGrid1.Location = New System.Drawing.Point(3, 219)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(211, 203)
        Me.PropertyGrid1.TabIndex = 1
        '
        'TpgValidationResults
        '
        Me.TpgValidationResults.Controls.Add(Me.SplitContainer6)
        Me.TpgValidationResults.Location = New System.Drawing.Point(4, 22)
        Me.TpgValidationResults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgValidationResults.Name = "TpgValidationResults"
        Me.TpgValidationResults.Size = New System.Drawing.Size(1188, 429)
        Me.TpgValidationResults.TabIndex = 3
        Me.TpgValidationResults.Text = "Validation Results"
        Me.TpgValidationResults.UseVisualStyleBackColor = True
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer6.Name = "SplitContainer6"
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.GroupBox7)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.GroupBox8)
        Me.SplitContainer6.Size = New System.Drawing.Size(1188, 429)
        Me.SplitContainer6.SplitterDistance = 384
        Me.SplitContainer6.SplitterWidth = 3
        Me.SplitContainer6.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.SplitContainer11)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox7.Size = New System.Drawing.Size(384, 429)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Testing Results :"
        '
        'SplitContainer11
        '
        Me.SplitContainer11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer11.Location = New System.Drawing.Point(3, 15)
        Me.SplitContainer11.Name = "SplitContainer11"
        Me.SplitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer11.Panel1
        '
        Me.SplitContainer11.Panel1.Controls.Add(Me.BtnLuanchTesting)
        Me.SplitContainer11.Panel1.Controls.Add(Me.DgvValidationResults)
        '
        'SplitContainer11.Panel2
        '
        Me.SplitContainer11.Panel2.Controls.Add(Me.GroupBox11)
        Me.SplitContainer11.Size = New System.Drawing.Size(378, 412)
        Me.SplitContainer11.SplitterDistance = 160
        Me.SplitContainer11.TabIndex = 1
        '
        'BtnLuanchTesting
        '
        Me.BtnLuanchTesting.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLuanchTesting.Location = New System.Drawing.Point(12, 8)
        Me.BtnLuanchTesting.Name = "BtnLuanchTesting"
        Me.BtnLuanchTesting.Size = New System.Drawing.Size(352, 33)
        Me.BtnLuanchTesting.TabIndex = 1
        Me.BtnLuanchTesting.Text = "Testing (Validation)"
        Me.BtnLuanchTesting.UseVisualStyleBackColor = True
        '
        'DgvValidationResults
        '
        Me.DgvValidationResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvValidationResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvValidationResults.Location = New System.Drawing.Point(3, 46)
        Me.DgvValidationResults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvValidationResults.Name = "DgvValidationResults"
        Me.DgvValidationResults.RowTemplate.Height = 26
        Me.DgvValidationResults.Size = New System.Drawing.Size(371, 112)
        Me.DgvValidationResults.TabIndex = 0
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.SplitContainer15)
        Me.GroupBox11.Controls.Add(Me.BtnComputeIndexes)
        Me.GroupBox11.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(370, 239)
        Me.GroupBox11.TabIndex = 0
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Performance Criteria :"
        '
        'SplitContainer15
        '
        Me.SplitContainer15.Location = New System.Drawing.Point(6, 59)
        Me.SplitContainer15.Name = "SplitContainer15"
        '
        'SplitContainer15.Panel1
        '
        Me.SplitContainer15.Panel1.Controls.Add(Me.PrtyGrdPerformCriteria)
        '
        'SplitContainer15.Panel2
        '
        Me.SplitContainer15.Panel2.Controls.Add(Me.PropertyGrid2)
        Me.SplitContainer15.Size = New System.Drawing.Size(358, 180)
        Me.SplitContainer15.SplitterDistance = 182
        Me.SplitContainer15.TabIndex = 3
        '
        'PrtyGrdPerformCriteria
        '
        Me.PrtyGrdPerformCriteria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdPerformCriteria.HelpVisible = False
        Me.PrtyGrdPerformCriteria.Location = New System.Drawing.Point(0, 0)
        Me.PrtyGrdPerformCriteria.Name = "PrtyGrdPerformCriteria"
        Me.PrtyGrdPerformCriteria.Size = New System.Drawing.Size(182, 180)
        Me.PrtyGrdPerformCriteria.TabIndex = 1
        '
        'PropertyGrid2
        '
        Me.PropertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid2.HelpVisible = False
        Me.PropertyGrid2.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid2.Name = "PropertyGrid2"
        Me.PropertyGrid2.Size = New System.Drawing.Size(172, 180)
        Me.PropertyGrid2.TabIndex = 3
        '
        'BtnComputeIndexes
        '
        Me.BtnComputeIndexes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnComputeIndexes.Location = New System.Drawing.Point(20, 19)
        Me.BtnComputeIndexes.Name = "BtnComputeIndexes"
        Me.BtnComputeIndexes.Size = New System.Drawing.Size(329, 34)
        Me.BtnComputeIndexes.TabIndex = 2
        Me.BtnComputeIndexes.Text = "Compute Indexes"
        Me.BtnComputeIndexes.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.ChartValidationResults)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox8.Size = New System.Drawing.Size(801, 429)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Graphics :"
        '
        'ChartValidationResults
        '
        ChartArea2.Name = "ChartArea1"
        Me.ChartValidationResults.ChartAreas.Add(ChartArea2)
        Me.ChartValidationResults.ContextMenuStrip = Me.CxmChartANNResults
        Me.ChartValidationResults.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend2.Name = "Legend1"
        Me.ChartValidationResults.Legends.Add(Legend2)
        Me.ChartValidationResults.Location = New System.Drawing.Point(3, 15)
        Me.ChartValidationResults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartValidationResults.Name = "ChartValidationResults"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.ChartValidationResults.Series.Add(Series2)
        Me.ChartValidationResults.Size = New System.Drawing.Size(795, 412)
        Me.ChartValidationResults.TabIndex = 0
        Me.ChartValidationResults.Text = "Chart1"
        '
        'TpgForecasting
        '
        Me.TpgForecasting.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TpgForecasting.Controls.Add(Me.SplitContainer7)
        Me.TpgForecasting.Location = New System.Drawing.Point(4, 22)
        Me.TpgForecasting.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TpgForecasting.Name = "TpgForecasting"
        Me.TpgForecasting.Size = New System.Drawing.Size(1188, 429)
        Me.TpgForecasting.TabIndex = 4
        Me.TpgForecasting.Text = "Forecasting"
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer7.Name = "SplitContainer7"
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.Controls.Add(Me.TableLayoutPanel4)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.Controls.Add(Me.SplitContainer8)
        Me.SplitContainer7.Size = New System.Drawing.Size(1188, 429)
        Me.SplitContainer7.SplitterDistance = 350
        Me.SplitContainer7.SplitterWidth = 3
        Me.SplitContainer7.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.BtnLuanchForecasting, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.PrtyGrdForecasting, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.BtnExportForecastingResults, 0, 2)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 5
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(350, 429)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'BtnLuanchForecasting
        '
        Me.BtnLuanchForecasting.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLuanchForecasting.Location = New System.Drawing.Point(3, 18)
        Me.BtnLuanchForecasting.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnLuanchForecasting.Name = "BtnLuanchForecasting"
        Me.BtnLuanchForecasting.Size = New System.Drawing.Size(344, 33)
        Me.BtnLuanchForecasting.TabIndex = 0
        Me.BtnLuanchForecasting.Text = "Forecasting"
        Me.BtnLuanchForecasting.UseVisualStyleBackColor = True
        '
        'PrtyGrdForecasting
        '
        Me.PrtyGrdForecasting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdForecasting.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrtyGrdForecasting.Location = New System.Drawing.Point(3, 92)
        Me.PrtyGrdForecasting.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PrtyGrdForecasting.Name = "PrtyGrdForecasting"
        Me.TableLayoutPanel4.SetRowSpan(Me.PrtyGrdForecasting, 2)
        Me.PrtyGrdForecasting.Size = New System.Drawing.Size(344, 335)
        Me.PrtyGrdForecasting.TabIndex = 1
        '
        'BtnExportForecastingResults
        '
        Me.BtnExportForecastingResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportForecastingResults.Location = New System.Drawing.Point(3, 55)
        Me.BtnExportForecastingResults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnExportForecastingResults.Name = "BtnExportForecastingResults"
        Me.BtnExportForecastingResults.Size = New System.Drawing.Size(344, 33)
        Me.BtnExportForecastingResults.TabIndex = 2
        Me.BtnExportForecastingResults.Text = "Export"
        Me.BtnExportForecastingResults.UseVisualStyleBackColor = True
        '
        'SplitContainer8
        '
        Me.SplitContainer8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer8.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer8.Name = "SplitContainer8"
        '
        'SplitContainer8.Panel1
        '
        Me.SplitContainer8.Panel1.Controls.Add(Me.GroupBox9)
        '
        'SplitContainer8.Panel2
        '
        Me.SplitContainer8.Panel2.Controls.Add(Me.GroupBox10)
        Me.SplitContainer8.Size = New System.Drawing.Size(835, 429)
        Me.SplitContainer8.SplitterDistance = 284
        Me.SplitContainer8.SplitterWidth = 3
        Me.SplitContainer8.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox9.Controls.Add(Me.DgvForecastingResults)
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox9.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox9.Size = New System.Drawing.Size(284, 429)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Forecasting Results :"
        '
        'DgvForecastingResults
        '
        Me.DgvForecastingResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvForecastingResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvForecastingResults.Location = New System.Drawing.Point(3, 15)
        Me.DgvForecastingResults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvForecastingResults.Name = "DgvForecastingResults"
        Me.DgvForecastingResults.RowTemplate.Height = 26
        Me.DgvForecastingResults.Size = New System.Drawing.Size(278, 412)
        Me.DgvForecastingResults.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox10.Controls.Add(Me.ChartForecasting)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox10.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox10.Size = New System.Drawing.Size(548, 429)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Forecasting Results :"
        '
        'ChartForecasting
        '
        ChartArea3.Name = "ChartArea1"
        Me.ChartForecasting.ChartAreas.Add(ChartArea3)
        Me.ChartForecasting.Dock = System.Windows.Forms.DockStyle.Fill
        Legend3.Alignment = System.Drawing.StringAlignment.Center
        Legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend3.Name = "Legend1"
        Me.ChartForecasting.Legends.Add(Legend3)
        Me.ChartForecasting.Location = New System.Drawing.Point(3, 15)
        Me.ChartForecasting.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartForecasting.Name = "ChartForecasting"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "Legend1"
        Series3.MarkerBorderWidth = 3
        Series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series3.Name = "Series1"
        Me.ChartForecasting.Series.Add(Series3)
        Me.ChartForecasting.Size = New System.Drawing.Size(542, 412)
        Me.ChartForecasting.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer9)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1188, 429)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "Conversion "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer9
        '
        Me.SplitContainer9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer9.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer9.Name = "SplitContainer9"
        '
        'SplitContainer9.Panel1
        '
        Me.SplitContainer9.Panel1.Controls.Add(Me.TableLayoutPanel5)
        '
        'SplitContainer9.Panel2
        '
        Me.SplitContainer9.Panel2.Controls.Add(Me.SplitContainer10)
        Me.SplitContainer9.Size = New System.Drawing.Size(1188, 429)
        Me.SplitContainer9.SplitterDistance = 395
        Me.SplitContainer9.SplitterWidth = 3
        Me.SplitContainer9.TabIndex = 5
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.BtnImportDataSerie, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.CmbfileFormat, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.CmbAggregationCount, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.BtnAggregateData, 0, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.BtnExportDataSerie, 0, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.ComboBox1, 0, 6)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 9
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(395, 429)
        Me.TableLayoutPanel5.TabIndex = 4
        '
        'BtnImportDataSerie
        '
        Me.BtnImportDataSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportDataSerie.Location = New System.Drawing.Point(3, 27)
        Me.BtnImportDataSerie.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnImportDataSerie.Name = "BtnImportDataSerie"
        Me.BtnImportDataSerie.Size = New System.Drawing.Size(389, 28)
        Me.BtnImportDataSerie.TabIndex = 2
        Me.BtnImportDataSerie.Text = "Import Data"
        Me.BtnImportDataSerie.UseVisualStyleBackColor = True
        '
        'CmbfileFormat
        '
        Me.CmbfileFormat.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbfileFormat.FormattingEnabled = True
        Me.CmbfileFormat.Location = New System.Drawing.Point(3, 2)
        Me.CmbfileFormat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbfileFormat.Name = "CmbfileFormat"
        Me.CmbfileFormat.Size = New System.Drawing.Size(389, 21)
        Me.CmbfileFormat.TabIndex = 4
        Me.CmbfileFormat.Text = "Select File Format "
        '
        'CmbAggregationCount
        '
        Me.CmbAggregationCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAggregationCount.FormattingEnabled = True
        Me.CmbAggregationCount.Location = New System.Drawing.Point(3, 59)
        Me.CmbAggregationCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbAggregationCount.Name = "CmbAggregationCount"
        Me.CmbAggregationCount.Size = New System.Drawing.Size(389, 21)
        Me.CmbAggregationCount.TabIndex = 5
        Me.CmbAggregationCount.Text = "Select Aggegation Counter"
        '
        'BtnAggregateData
        '
        Me.BtnAggregateData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAggregateData.Location = New System.Drawing.Point(3, 84)
        Me.BtnAggregateData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnAggregateData.Name = "BtnAggregateData"
        Me.BtnAggregateData.Size = New System.Drawing.Size(389, 28)
        Me.BtnAggregateData.TabIndex = 3
        Me.BtnAggregateData.Text = "Aggregate Data"
        Me.BtnAggregateData.UseVisualStyleBackColor = True
        '
        'BtnExportDataSerie
        '
        Me.BtnExportDataSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportDataSerie.Location = New System.Drawing.Point(3, 141)
        Me.BtnExportDataSerie.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnExportDataSerie.Name = "BtnExportDataSerie"
        Me.BtnExportDataSerie.Size = New System.Drawing.Size(389, 28)
        Me.BtnExportDataSerie.TabIndex = 6
        Me.BtnExportDataSerie.Text = "Export Data"
        Me.BtnExportDataSerie.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 116)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(389, 21)
        Me.ComboBox1.TabIndex = 7
        Me.ComboBox1.Text = "Select File Format"
        '
        'SplitContainer10
        '
        Me.SplitContainer10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer10.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer10.Name = "SplitContainer10"
        '
        'SplitContainer10.Panel1
        '
        Me.SplitContainer10.Panel1.Controls.Add(Me.DgvInputData)
        '
        'SplitContainer10.Panel2
        '
        Me.SplitContainer10.Panel2.Controls.Add(Me.DgvOutputData)
        Me.SplitContainer10.Size = New System.Drawing.Size(790, 429)
        Me.SplitContainer10.SplitterDistance = 425
        Me.SplitContainer10.SplitterWidth = 3
        Me.SplitContainer10.TabIndex = 0
        '
        'DgvInputData
        '
        Me.DgvInputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvInputData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvInputData.Location = New System.Drawing.Point(0, 0)
        Me.DgvInputData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvInputData.Name = "DgvInputData"
        Me.DgvInputData.RowTemplate.Height = 26
        Me.DgvInputData.Size = New System.Drawing.Size(425, 429)
        Me.DgvInputData.TabIndex = 0
        '
        'DgvOutputData
        '
        Me.DgvOutputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOutputData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvOutputData.Location = New System.Drawing.Point(0, 0)
        Me.DgvOutputData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvOutputData.Name = "DgvOutputData"
        Me.DgvOutputData.RowTemplate.Height = 26
        Me.DgvOutputData.Size = New System.Drawing.Size(362, 429)
        Me.DgvOutputData.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer12)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1188, 429)
        Me.TabPage2.TabIndex = 6
        Me.TabPage2.Text = "Optimization ANN Tuning"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer12
        '
        Me.SplitContainer12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer12.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer12.Name = "SplitContainer12"
        '
        'SplitContainer12.Panel1
        '
        Me.SplitContainer12.Panel1.Controls.Add(Me.SplitContainer13)
        '
        'SplitContainer12.Panel2
        '
        Me.SplitContainer12.Panel2.Controls.Add(Me.BestFitnessChart)
        Me.SplitContainer12.Size = New System.Drawing.Size(1182, 423)
        Me.SplitContainer12.SplitterDistance = 393
        Me.SplitContainer12.TabIndex = 0
        '
        'SplitContainer13
        '
        Me.SplitContainer13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer13.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer13.Name = "SplitContainer13"
        Me.SplitContainer13.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer13.Panel1
        '
        Me.SplitContainer13.Panel1.Controls.Add(Me.BtnLuanchOptimization)
        Me.SplitContainer13.Panel1.Controls.Add(Me.PrtGrdAnnOptimizer)
        '
        'SplitContainer13.Panel2
        '
        Me.SplitContainer13.Panel2.Controls.Add(Me.LbxSolutionsHistory)
        Me.SplitContainer13.Size = New System.Drawing.Size(393, 423)
        Me.SplitContainer13.SplitterDistance = 285
        Me.SplitContainer13.TabIndex = 0
        '
        'BtnLuanchOptimization
        '
        Me.BtnLuanchOptimization.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLuanchOptimization.Location = New System.Drawing.Point(82, 9)
        Me.BtnLuanchOptimization.Name = "BtnLuanchOptimization"
        Me.BtnLuanchOptimization.Size = New System.Drawing.Size(235, 31)
        Me.BtnLuanchOptimization.TabIndex = 1
        Me.BtnLuanchOptimization.Text = ">> Luanch >>"
        Me.BtnLuanchOptimization.UseVisualStyleBackColor = True
        '
        'PrtGrdAnnOptimizer
        '
        Me.PrtGrdAnnOptimizer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrtGrdAnnOptimizer.Location = New System.Drawing.Point(9, 53)
        Me.PrtGrdAnnOptimizer.Name = "PrtGrdAnnOptimizer"
        Me.PrtGrdAnnOptimizer.Size = New System.Drawing.Size(375, 224)
        Me.PrtGrdAnnOptimizer.TabIndex = 0
        '
        'LbxSolutionsHistory
        '
        Me.LbxSolutionsHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LbxSolutionsHistory.FormattingEnabled = True
        Me.LbxSolutionsHistory.HorizontalScrollbar = True
        Me.LbxSolutionsHistory.Location = New System.Drawing.Point(0, 0)
        Me.LbxSolutionsHistory.Name = "LbxSolutionsHistory"
        Me.LbxSolutionsHistory.ScrollAlwaysVisible = True
        Me.LbxSolutionsHistory.Size = New System.Drawing.Size(393, 134)
        Me.LbxSolutionsHistory.TabIndex = 0
        '
        'BestFitnessChart
        '
        ChartArea4.Name = "ChartArea1"
        Me.BestFitnessChart.ChartAreas.Add(ChartArea4)
        Me.BestFitnessChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend4.Name = "Legend1"
        Me.BestFitnessChart.Legends.Add(Legend4)
        Me.BestFitnessChart.Location = New System.Drawing.Point(0, 0)
        Me.BestFitnessChart.Name = "BestFitnessChart"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.BestFitnessChart.Series.Add(Series4)
        Me.BestFitnessChart.Size = New System.Drawing.Size(785, 423)
        Me.BestFitnessChart.TabIndex = 0
        Me.BestFitnessChart.Text = "OptimizedANN"
        '
        'NeuralNetworkForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 455)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "NeuralNetworkForm"
        Me.Text = "Forecasting - Artificial Neural Networks (ANNs)"
        Me.TabControl1.ResumeLayout(False)
        Me.TpgTrainingData.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvTrainingInputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DgvTrainingOutputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpgTestingData.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DgvTestingInputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.DgvTestingOutputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpgNeuralNetworkParams.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.SplitContainer14.Panel1.ResumeLayout(False)
        Me.SplitContainer14.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer14.ResumeLayout(False)
        CType(Me.ChartTraining, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxmChartANNResults.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TpgValidationResults.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.SplitContainer11.Panel1.ResumeLayout(False)
        Me.SplitContainer11.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer11.ResumeLayout(False)
        CType(Me.DgvValidationResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.SplitContainer15.Panel1.ResumeLayout(False)
        Me.SplitContainer15.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer15.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.ChartValidationResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpgForecasting.ResumeLayout(False)
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer7.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.SplitContainer8.Panel1.ResumeLayout(False)
        Me.SplitContainer8.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        CType(Me.DgvForecastingResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.ChartForecasting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer9.Panel1.ResumeLayout(False)
        Me.SplitContainer9.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer9.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.SplitContainer10.Panel1.ResumeLayout(False)
        Me.SplitContainer10.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer10.ResumeLayout(False)
        CType(Me.DgvInputData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvOutputData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer12.Panel1.ResumeLayout(False)
        Me.SplitContainer12.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer12.ResumeLayout(False)
        Me.SplitContainer13.Panel1.ResumeLayout(False)
        Me.SplitContainer13.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer13.ResumeLayout(False)
        CType(Me.BestFitnessChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TpgTrainingData As TabPage
    Friend WithEvents TpgTestingData As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DgvTrainingInputs As DataGridView
    Friend WithEvents DgvTrainingOutputs As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CmbTrainInputsFileType As ComboBox
    Friend WithEvents BtnImportTrainInputs As Button
    Friend WithEvents BtnImportTrainOutputs As Button
    Friend WithEvents CmbTrainOutputsFileType As ComboBox
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents BtnImportTestingOutputs As Button
    Friend WithEvents CmbTestInputsFileType As ComboBox
    Friend WithEvents BtnImportTestingInputs As Button
    Friend WithEvents CmbTestOutputsFileType As ComboBox
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents DgvTestingInputs As DataGridView
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents DgvTestingOutputs As DataGridView
    Friend WithEvents TpgNeuralNetworkParams As TabPage
    Friend WithEvents TpgValidationResults As TabPage
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents PrptyGrdNeuralNet As PropertyGrid
    Friend WithEvents BtnLuanchTraining As Button
    Friend WithEvents SplitContainer6 As SplitContainer
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents DgvValidationResults As DataGridView
    Friend WithEvents ChartValidationResults As DataVisualization.Charting.Chart
    Friend WithEvents TpgForecasting As TabPage
    Friend WithEvents SplitContainer7 As SplitContainer
    Friend WithEvents SplitContainer8 As SplitContainer
    Friend WithEvents ChartForecasting As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents DgvForecastingResults As DataGridView
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents BtnLuanchForecasting As Button
    Friend WithEvents PrtyGrdForecasting As PropertyGrid
    Friend WithEvents BtnExportForecastingResults As Button
    Friend WithEvents PrptyGrdNeuralNetStruct As PropertyGrid
    Friend WithEvents PrptGrdTrainingInput As PropertyGrid
    Friend WithEvents PrptGrdTrainingOutput As PropertyGrid
    Friend WithEvents PrptGrdTestingInput As PropertyGrid
    Friend WithEvents PrptGrdTestingOutput As PropertyGrid
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents BtnAggregateData As Button
    Friend WithEvents BtnImportDataSerie As Button
    Friend WithEvents DgvOutputData As DataGridView
    Friend WithEvents DgvInputData As DataGridView
    Friend WithEvents SplitContainer9 As SplitContainer
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents CmbfileFormat As ComboBox
    Friend WithEvents CmbAggregationCount As ComboBox
    Friend WithEvents BtnExportDataSerie As Button
    Friend WithEvents SplitContainer10 As SplitContainer
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents SplitContainer11 As SplitContainer
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents PrtyGrdPerformCriteria As PropertyGrid
    Friend WithEvents BtnComputeIndexes As Button
    Friend WithEvents BtnLuanchTesting As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents SplitContainer12 As SplitContainer
    Friend WithEvents SplitContainer13 As SplitContainer
    Friend WithEvents PrtGrdAnnOptimizer As PropertyGrid
    Friend WithEvents LbxSolutionsHistory As ListBox
    Friend WithEvents BestFitnessChart As DataVisualization.Charting.Chart
    Friend WithEvents BtnLuanchOptimization As Button
    Friend WithEvents CxmChartANNResults As ContextMenuStrip
    Friend WithEvents ChartTraining As DataVisualization.Charting.Chart
    Friend WithEvents CxmiSaveTrainingResults As ToolStripMenuItem
    Friend WithEvents SplitContainer14 As SplitContainer
    Friend WithEvents PrtGrdTrainingIndexes As PropertyGrid
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents SplitContainer15 As SplitContainer
    Friend WithEvents PropertyGrid2 As PropertyGrid
    Friend WithEvents CxmiSaveNeuralNetwork As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CxmiSaveTestingResults As ToolStripMenuItem
    Friend WithEvents CxmiLoadNeuralNet As ToolStripMenuItem
End Class
