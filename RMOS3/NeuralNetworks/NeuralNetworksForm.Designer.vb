<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NeuralNetworksForm
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPgData = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtyGrdTrainInputData = New System.Windows.Forms.PropertyGrid()
        Me.BtnBrowseInputs = New System.Windows.Forms.Button()
        Me.BtnShowTrainGraphics = New System.Windows.Forms.Button()
        Me.BtnBrowseOutData = New System.Windows.Forms.Button()
        Me.PrtyGrdTrainOutData = New System.Windows.Forms.PropertyGrid()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DgvTrainInputsData = New System.Windows.Forms.DataGridView()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DgvTrainOutData = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChartData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPgTesting = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtyGrdTestData = New System.Windows.Forms.PropertyGrid()
        Me.BtnBrowseTestingData = New System.Windows.Forms.Button()
        Me.BtnShowTestingGraphics = New System.Windows.Forms.Button()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.DgvTestingData = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ChartTestingData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPgANNParams = New System.Windows.Forms.TabPage()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnLuanchLearning = New System.Windows.Forms.Button()
        Me.TabPgValidation = New System.Windows.Forms.TabPage()
        Me.CxtMenuCmbDataSeries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CmiRefreshDataSeres = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPgData.SuspendLayout()
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
        CType(Me.DgvTrainInputsData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvTrainOutData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ChartData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPgTesting.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.DgvTestingData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.ChartTestingData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPgANNParams.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxtMenuCmbDataSeries.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPgData)
        Me.TabControl1.Controls.Add(Me.TabPgTesting)
        Me.TabControl1.Controls.Add(Me.TabPgANNParams)
        Me.TabControl1.Controls.Add(Me.TabPgValidation)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(949, 349)
        Me.TabControl1.TabIndex = 1
        '
        'TabPgData
        '
        Me.TabPgData.Controls.Add(Me.SplitContainer1)
        Me.TabPgData.Location = New System.Drawing.Point(4, 25)
        Me.TabPgData.Name = "TabPgData"
        Me.TabPgData.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPgData.Size = New System.Drawing.Size(941, 320)
        Me.TabPgData.TabIndex = 0
        Me.TabPgData.Text = "Training Data Series"
        Me.TabPgData.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(935, 314)
        Me.SplitContainer1.SplitterDistance = 243
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(243, 314)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Serie :"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PrtyGrdTrainInputData, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnBrowseInputs, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnShowTrainGraphics, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnBrowseOutData, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PrtyGrdTrainOutData, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(237, 291)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PrtyGrdTrainInputData
        '
        Me.PrtyGrdTrainInputData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdTrainInputData.HelpVisible = False
        Me.PrtyGrdTrainInputData.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrtyGrdTrainInputData.Location = New System.Drawing.Point(8, 109)
        Me.PrtyGrdTrainInputData.Name = "PrtyGrdTrainInputData"
        Me.PrtyGrdTrainInputData.Size = New System.Drawing.Size(226, 86)
        Me.PrtyGrdTrainInputData.TabIndex = 0
        '
        'BtnBrowseInputs
        '
        Me.BtnBrowseInputs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowseInputs.Location = New System.Drawing.Point(8, 3)
        Me.BtnBrowseInputs.Name = "BtnBrowseInputs"
        Me.BtnBrowseInputs.Size = New System.Drawing.Size(226, 29)
        Me.BtnBrowseInputs.TabIndex = 1
        Me.BtnBrowseInputs.Text = "Import - Train. Data (Inputs) "
        Me.BtnBrowseInputs.UseVisualStyleBackColor = True
        '
        'BtnShowTrainGraphics
        '
        Me.BtnShowTrainGraphics.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnShowTrainGraphics.Location = New System.Drawing.Point(8, 74)
        Me.BtnShowTrainGraphics.Name = "BtnShowTrainGraphics"
        Me.BtnShowTrainGraphics.Size = New System.Drawing.Size(226, 29)
        Me.BtnShowTrainGraphics.TabIndex = 2
        Me.BtnShowTrainGraphics.Text = "Show Graphics"
        Me.BtnShowTrainGraphics.UseVisualStyleBackColor = True
        '
        'BtnBrowseOutData
        '
        Me.BtnBrowseOutData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowseOutData.Location = New System.Drawing.Point(8, 38)
        Me.BtnBrowseOutData.Name = "BtnBrowseOutData"
        Me.BtnBrowseOutData.Size = New System.Drawing.Size(226, 30)
        Me.BtnBrowseOutData.TabIndex = 4
        Me.BtnBrowseOutData.Text = "Import - Train. Data (Outputs)"
        Me.BtnBrowseOutData.UseVisualStyleBackColor = True
        '
        'PrtyGrdTrainOutData
        '
        Me.PrtyGrdTrainOutData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdTrainOutData.HelpVisible = False
        Me.PrtyGrdTrainOutData.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrtyGrdTrainOutData.Location = New System.Drawing.Point(8, 201)
        Me.PrtyGrdTrainOutData.Name = "PrtyGrdTrainOutData"
        Me.PrtyGrdTrainOutData.Size = New System.Drawing.Size(226, 87)
        Me.PrtyGrdTrainOutData.TabIndex = 5
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(687, 314)
        Me.SplitContainer2.SplitterDistance = 223
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvTrainInputsData)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(223, 314)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Training Data (Inputs) :"
        '
        'DgvTrainInputsData
        '
        Me.DgvTrainInputsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrainInputsData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrainInputsData.Location = New System.Drawing.Point(3, 20)
        Me.DgvTrainInputsData.Name = "DgvTrainInputsData"
        Me.DgvTrainInputsData.RowTemplate.Height = 26
        Me.DgvTrainInputsData.Size = New System.Drawing.Size(217, 291)
        Me.DgvTrainInputsData.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox4)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer3.Size = New System.Drawing.Size(459, 314)
        Me.SplitContainer3.SplitterDistance = 156
        Me.SplitContainer3.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DgvTrainOutData)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(156, 314)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Training Data (Outputs)"
        '
        'DgvTrainOutData
        '
        Me.DgvTrainOutData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrainOutData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrainOutData.Location = New System.Drawing.Point(3, 20)
        Me.DgvTrainOutData.Name = "DgvTrainOutData"
        Me.DgvTrainOutData.RowTemplate.Height = 26
        Me.DgvTrainOutData.Size = New System.Drawing.Size(150, 291)
        Me.DgvTrainOutData.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChartData)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(299, 314)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Chart :"
        '
        'ChartData
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartData.ChartAreas.Add(ChartArea1)
        Me.ChartData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartData.Location = New System.Drawing.Point(3, 20)
        Me.ChartData.Name = "ChartData"
        Series1.ChartArea = "ChartArea1"
        Series1.Name = "Series1"
        Me.ChartData.Series.Add(Series1)
        Me.ChartData.Size = New System.Drawing.Size(293, 291)
        Me.ChartData.TabIndex = 0
        Me.ChartData.Text = "Chart1"
        '
        'TabPgTesting
        '
        Me.TabPgTesting.Controls.Add(Me.SplitContainer4)
        Me.TabPgTesting.Location = New System.Drawing.Point(4, 25)
        Me.TabPgTesting.Name = "TabPgTesting"
        Me.TabPgTesting.Size = New System.Drawing.Size(941, 320)
        Me.TabPgTesting.TabIndex = 2
        Me.TabPgTesting.Text = "Testing Data"
        Me.TabPgTesting.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.GroupBox6)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer5)
        Me.SplitContainer4.Size = New System.Drawing.Size(941, 320)
        Me.SplitContainer4.SplitterDistance = 224
        Me.SplitContainer4.SplitterWidth = 5
        Me.SplitContainer4.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(224, 320)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Data Serie :"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PrtyGrdTestData, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnBrowseTestingData, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnShowTestingGraphics, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(218, 297)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'PrtyGrdTestData
        '
        Me.PrtyGrdTestData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdTestData.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrtyGrdTestData.Location = New System.Drawing.Point(8, 73)
        Me.PrtyGrdTestData.Name = "PrtyGrdTestData"
        Me.PrtyGrdTestData.Size = New System.Drawing.Size(207, 221)
        Me.PrtyGrdTestData.TabIndex = 0
        '
        'BtnBrowseTestingData
        '
        Me.BtnBrowseTestingData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowseTestingData.Location = New System.Drawing.Point(8, 3)
        Me.BtnBrowseTestingData.Name = "BtnBrowseTestingData"
        Me.BtnBrowseTestingData.Size = New System.Drawing.Size(207, 29)
        Me.BtnBrowseTestingData.TabIndex = 1
        Me.BtnBrowseTestingData.Text = "Browse..."
        Me.BtnBrowseTestingData.UseVisualStyleBackColor = True
        '
        'BtnShowTestingGraphics
        '
        Me.BtnShowTestingGraphics.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnShowTestingGraphics.Location = New System.Drawing.Point(8, 38)
        Me.BtnShowTestingGraphics.Name = "BtnShowTestingGraphics"
        Me.BtnShowTestingGraphics.Size = New System.Drawing.Size(207, 29)
        Me.BtnShowTestingGraphics.TabIndex = 2
        Me.BtnShowTestingGraphics.Text = "Show Graphics"
        Me.BtnShowTestingGraphics.UseVisualStyleBackColor = True
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.GroupBox7)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.GroupBox5)
        Me.SplitContainer5.Size = New System.Drawing.Size(712, 320)
        Me.SplitContainer5.SplitterDistance = 236
        Me.SplitContainer5.SplitterWidth = 5
        Me.SplitContainer5.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.DgvTestingData)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(236, 320)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Data :"
        '
        'DgvTestingData
        '
        Me.DgvTestingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTestingData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTestingData.Location = New System.Drawing.Point(3, 20)
        Me.DgvTestingData.Name = "DgvTestingData"
        Me.DgvTestingData.RowTemplate.Height = 26
        Me.DgvTestingData.Size = New System.Drawing.Size(230, 297)
        Me.DgvTestingData.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ChartTestingData)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(471, 320)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Chart :"
        '
        'ChartTestingData
        '
        ChartArea2.Name = "ChartArea1"
        Me.ChartTestingData.ChartAreas.Add(ChartArea2)
        Me.ChartTestingData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartTestingData.Location = New System.Drawing.Point(3, 20)
        Me.ChartTestingData.Name = "ChartTestingData"
        Series2.ChartArea = "ChartArea1"
        Series2.Name = "Series1"
        Me.ChartTestingData.Series.Add(Series2)
        Me.ChartTestingData.Size = New System.Drawing.Size(465, 297)
        Me.ChartTestingData.TabIndex = 0
        Me.ChartTestingData.Text = "Chart1"
        '
        'TabPgANNParams
        '
        Me.TabPgANNParams.Controls.Add(Me.PropertyGrid1)
        Me.TabPgANNParams.Controls.Add(Me.Button2)
        Me.TabPgANNParams.Controls.Add(Me.Chart1)
        Me.TabPgANNParams.Controls.Add(Me.TextBox2)
        Me.TabPgANNParams.Controls.Add(Me.TextBox1)
        Me.TabPgANNParams.Controls.Add(Me.BtnLuanchLearning)
        Me.TabPgANNParams.Location = New System.Drawing.Point(4, 25)
        Me.TabPgANNParams.Name = "TabPgANNParams"
        Me.TabPgANNParams.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPgANNParams.Size = New System.Drawing.Size(941, 320)
        Me.TabPgANNParams.TabIndex = 1
        Me.TabPgANNParams.Text = "Arti.Nueral Net."
        Me.TabPgANNParams.UseVisualStyleBackColor = True
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrid1.HelpVisible = False
        Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PropertyGrid1.Location = New System.Drawing.Point(21, 165)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(217, 147)
        Me.PropertyGrid1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(21, 117)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(217, 42)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Test"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag
        Me.Chart1.BorderSkin.BorderColor = System.Drawing.Color.Bisque
        Me.Chart1.BorderSkin.PageColor = System.Drawing.SystemColors.ActiveCaptionText
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(331, 12)
        Me.Chart1.Name = "Chart1"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "Legend1"
        Series3.MarkerSize = 20
        Series3.Name = "Series1"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(602, 300)
        Me.Chart1.TabIndex = 3
        Me.Chart1.Text = "Chart1"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(21, 87)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(217, 24)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(21, 57)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(217, 24)
        Me.TextBox1.TabIndex = 1
        '
        'BtnLuanchLearning
        '
        Me.BtnLuanchLearning.Location = New System.Drawing.Point(21, 13)
        Me.BtnLuanchLearning.Name = "BtnLuanchLearning"
        Me.BtnLuanchLearning.Size = New System.Drawing.Size(217, 38)
        Me.BtnLuanchLearning.TabIndex = 0
        Me.BtnLuanchLearning.Text = "Luanch Learning"
        Me.BtnLuanchLearning.UseVisualStyleBackColor = True
        '
        'TabPgValidation
        '
        Me.TabPgValidation.Location = New System.Drawing.Point(4, 25)
        Me.TabPgValidation.Name = "TabPgValidation"
        Me.TabPgValidation.Size = New System.Drawing.Size(941, 320)
        Me.TabPgValidation.TabIndex = 3
        Me.TabPgValidation.Text = "Validation Results"
        Me.TabPgValidation.UseVisualStyleBackColor = True
        '
        'CxtMenuCmbDataSeries
        '
        Me.CxtMenuCmbDataSeries.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMenuCmbDataSeries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmiRefreshDataSeres})
        Me.CxtMenuCmbDataSeries.Name = "CxtMenuCmbDataSeries"
        Me.CxtMenuCmbDataSeries.Size = New System.Drawing.Size(128, 28)
        '
        'CmiRefreshDataSeres
        '
        Me.CmiRefreshDataSeres.Name = "CmiRefreshDataSeres"
        Me.CmiRefreshDataSeres.Size = New System.Drawing.Size(127, 24)
        Me.CmiRefreshDataSeres.Text = "Refresh"
        '
        'NeuralNetworksForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 349)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "NeuralNetworksForm"
        Me.Text = "Forecasting : Neural Networks"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPgData.ResumeLayout(False)
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
        CType(Me.DgvTrainInputsData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DgvTrainOutData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ChartData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPgTesting.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.DgvTestingData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.ChartTestingData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPgANNParams.ResumeLayout(False)
        Me.TabPgANNParams.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxtMenuCmbDataSeries.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPgData As TabPage
    Friend WithEvents TabPgANNParams As TabPage
    Friend WithEvents TabPgTesting As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PrtyGrdTrainInputData As PropertyGrid
    Friend WithEvents BtnBrowseInputs As Button
    Friend WithEvents BtnShowTrainGraphics As Button
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DgvTrainInputsData As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ChartData As DataVisualization.Charting.Chart
    Friend WithEvents CxtMenuCmbDataSeries As ContextMenuStrip
    Friend WithEvents CmiRefreshDataSeres As ToolStripMenuItem
    Friend WithEvents BtnLuanchLearning As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Button2 As Button
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents DgvTrainOutData As DataGridView
    Friend WithEvents BtnBrowseOutData As Button
    Friend WithEvents PrtyGrdTrainOutData As PropertyGrid
    Friend WithEvents TabPgValidation As TabPage
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PrtyGrdTestData As PropertyGrid
    Friend WithEvents BtnBrowseTestingData As Button
    Friend WithEvents BtnShowTestingGraphics As Button
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents DgvTestingData As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ChartTestingData As DataVisualization.Charting.Chart
End Class
