<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GWOAlgoForm
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
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GWOAlgoForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chart_RD = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.CxtMenuCharts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Chart_S = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ColInfiltration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvResults = New System.Windows.Forms.DataGridView()
        Me.ColN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDemands = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRelease = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColInflow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStorage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOverflow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEvaporation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CxtMenuDGV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PropertyGrd = New System.Windows.Forms.PropertyGrid()
        Me.CmbInflowSeries = New System.Windows.Forms.ComboBox()
        Me.CmbDemands = New System.Windows.Forms.ComboBox()
        Me.CmbEvaporation = New System.Windows.Forms.ComboBox()
        Me.CmbInfiltration = New System.Windows.Forms.ComboBox()
        Me.BtnObjectiveFunction = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BtnLuanchOptimization = New System.Windows.Forms.Button()
        Me.BtnShowGraphics = New System.Windows.Forms.Button()
        Me.BtnShowReport = New System.Windows.Forms.Button()
        Me.TsmiShowTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiShowGraphics = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart_RD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxtMenuCharts.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Chart_S, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxtMenuDGV.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(316, 442)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Chart_RD)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(310, 217)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Release [R*]  - Demands [D] :"
        '
        'Chart_RD
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart_RD.ChartAreas.Add(ChartArea1)
        Me.Chart_RD.ContextMenuStrip = Me.CxtMenuCharts
        Me.Chart_RD.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Name = "Legend1"
        Me.Chart_RD.Legends.Add(Legend1)
        Me.Chart_RD.Location = New System.Drawing.Point(3, 15)
        Me.Chart_RD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chart_RD.Name = "Chart_RD"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart_RD.Series.Add(Series1)
        Me.Chart_RD.Size = New System.Drawing.Size(304, 200)
        Me.Chart_RD.TabIndex = 0
        Me.Chart_RD.Text = "Chart1"
        '
        'CxtMenuCharts
        '
        Me.CxtMenuCharts.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMenuCharts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiShowGraphics})
        Me.CxtMenuCharts.Name = "CxtMenuCharts"
        Me.CxtMenuCharts.Size = New System.Drawing.Size(199, 30)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Chart_S)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 223)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(310, 217)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Storage [S] :"
        '
        'Chart_S
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart_S.ChartAreas.Add(ChartArea2)
        Me.Chart_S.ContextMenuStrip = Me.CxtMenuCharts
        Me.Chart_S.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend2.Name = "Legend1"
        Me.Chart_S.Legends.Add(Legend2)
        Me.Chart_S.Location = New System.Drawing.Point(3, 15)
        Me.Chart_S.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chart_S.Name = "Chart_S"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart_S.Series.Add(Series2)
        Me.Chart_S.Size = New System.Drawing.Size(304, 200)
        Me.Chart_S.TabIndex = 1
        Me.Chart_S.Text = "Chart2"
        '
        'ColInfiltration
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ColInfiltration.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColInfiltration.HeaderText = "[Ii]"
        Me.ColInfiltration.Name = "ColInfiltration"
        '
        'DgvResults
        '
        Me.DgvResults.AllowUserToDeleteRows = False
        Me.DgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColN, Me.ColTime, Me.ColDemands, Me.ColRelease, Me.ColInflow, Me.ColStorage, Me.ColOverflow, Me.ColEvaporation, Me.ColInfiltration})
        Me.DgvResults.ContextMenuStrip = Me.CxtMenuDGV
        Me.DgvResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvResults.Location = New System.Drawing.Point(3, 15)
        Me.DgvResults.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvResults.Name = "DgvResults"
        Me.DgvResults.RowTemplate.Height = 26
        Me.DgvResults.Size = New System.Drawing.Size(207, 425)
        Me.DgvResults.TabIndex = 0
        '
        'ColN
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ColN.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColN.HeaderText = "N°"
        Me.ColN.Name = "ColN"
        Me.ColN.Width = 60
        '
        'ColTime
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ColTime.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColTime.HeaderText = "Time"
        Me.ColTime.Name = "ColTime"
        Me.ColTime.Width = 80
        '
        'ColDemands
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Orange
        Me.ColDemands.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColDemands.HeaderText = "[Di]"
        Me.ColDemands.Name = "ColDemands"
        '
        'ColRelease
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan
        Me.ColRelease.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColRelease.HeaderText = "[Ri*]"
        Me.ColRelease.Name = "ColRelease"
        '
        'ColInflow
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColInflow.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColInflow.HeaderText = "[Qi]"
        Me.ColInflow.Name = "ColInflow"
        '
        'ColStorage
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Azure
        Me.ColStorage.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColStorage.HeaderText = "[Si]"
        Me.ColStorage.Name = "ColStorage"
        '
        'ColOverflow
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightBlue
        Me.ColOverflow.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColOverflow.HeaderText = "[Oi]"
        Me.ColOverflow.Name = "ColOverflow"
        '
        'ColEvaporation
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ColEvaporation.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColEvaporation.HeaderText = "[Evi]"
        Me.ColEvaporation.Name = "ColEvaporation"
        '
        'CxtMenuDGV
        '
        Me.CxtMenuDGV.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMenuDGV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiShowTables})
        Me.CxtMenuDGV.Name = "CxtMenuDGV"
        Me.CxtMenuDGV.Size = New System.Drawing.Size(186, 30)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DgvResults)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(213, 442)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Results :"
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer2.Size = New System.Drawing.Size(501, 442)
        Me.SplitContainer2.SplitterDistance = 284
        Me.SplitContainer2.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnLuanchOptimization, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox3, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbInflowSeries, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbDemands, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbEvaporation, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbInfiltration, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnShowGraphics, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnShowReport, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnObjectiveFunction, 1, 4)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(284, 442)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inflows :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Location = New System.Drawing.Point(3, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Demands :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label3, 2)
        Me.Label3.Location = New System.Drawing.Point(3, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Evaporation :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label4, 2)
        Me.Label4.Location = New System.Drawing.Point(3, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Infiltration :"
        '
        'GroupBox3
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox3, 4)
        Me.GroupBox3.Controls.Add(Me.PropertyGrd)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 234)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(278, 206)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Optimization Options [GSA] :"
        '
        'PropertyGrd
        '
        Me.PropertyGrd.AccessibleDescription = ""
        Me.PropertyGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrd.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PropertyGrd.Location = New System.Drawing.Point(3, 15)
        Me.PropertyGrd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PropertyGrd.Name = "PropertyGrd"
        Me.PropertyGrd.Size = New System.Drawing.Size(272, 189)
        Me.PropertyGrd.TabIndex = 0
        '
        'CmbInflowSeries
        '
        Me.CmbInflowSeries.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.CmbInflowSeries, 2)
        Me.CmbInflowSeries.FormattingEnabled = True
        Me.CmbInflowSeries.Location = New System.Drawing.Point(86, 2)
        Me.CmbInflowSeries.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbInflowSeries.Name = "CmbInflowSeries"
        Me.CmbInflowSeries.Size = New System.Drawing.Size(195, 21)
        Me.CmbInflowSeries.TabIndex = 11
        '
        'CmbDemands
        '
        Me.CmbDemands.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.CmbDemands, 2)
        Me.CmbDemands.FormattingEnabled = True
        Me.CmbDemands.Location = New System.Drawing.Point(86, 27)
        Me.CmbDemands.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbDemands.Name = "CmbDemands"
        Me.CmbDemands.Size = New System.Drawing.Size(195, 21)
        Me.CmbDemands.TabIndex = 12
        '
        'CmbEvaporation
        '
        Me.CmbEvaporation.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.CmbEvaporation, 2)
        Me.CmbEvaporation.FormattingEnabled = True
        Me.CmbEvaporation.Location = New System.Drawing.Point(86, 52)
        Me.CmbEvaporation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbEvaporation.Name = "CmbEvaporation"
        Me.CmbEvaporation.Size = New System.Drawing.Size(195, 21)
        Me.CmbEvaporation.TabIndex = 13
        '
        'CmbInfiltration
        '
        Me.CmbInfiltration.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.CmbInfiltration, 2)
        Me.CmbInfiltration.FormattingEnabled = True
        Me.CmbInfiltration.Location = New System.Drawing.Point(86, 77)
        Me.CmbInfiltration.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CmbInfiltration.Name = "CmbInfiltration"
        Me.CmbInfiltration.Size = New System.Drawing.Size(195, 21)
        Me.CmbInfiltration.TabIndex = 14
        '
        'BtnObjectiveFunction
        '
        Me.BtnObjectiveFunction.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.BtnObjectiveFunction, 2)
        Me.BtnObjectiveFunction.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnObjectiveFunction.Image = Global.RMOS3.My.Resources.Resources.Formula
        Me.BtnObjectiveFunction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnObjectiveFunction.Location = New System.Drawing.Point(20, 102)
        Me.BtnObjectiveFunction.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnObjectiveFunction.Name = "BtnObjectiveFunction"
        Me.BtnObjectiveFunction.Size = New System.Drawing.Size(195, 40)
        Me.BtnObjectiveFunction.TabIndex = 17
        Me.BtnObjectiveFunction.Text = "Objective Function"
        Me.BtnObjectiveFunction.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Silver
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(821, 442)
        Me.SplitContainer1.SplitterDistance = 501
        Me.SplitContainer1.TabIndex = 2
        '
        'BtnLuanchOptimization
        '
        Me.BtnLuanchOptimization.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnLuanchOptimization.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLuanchOptimization.Image = Global.RMOS3.My.Resources.Resources.Hydro_electric_40
        Me.BtnLuanchOptimization.Location = New System.Drawing.Point(221, 102)
        Me.BtnLuanchOptimization.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnLuanchOptimization.Name = "BtnLuanchOptimization"
        Me.TableLayoutPanel2.SetRowSpan(Me.BtnLuanchOptimization, 3)
        Me.BtnLuanchOptimization.Size = New System.Drawing.Size(60, 128)
        Me.BtnLuanchOptimization.TabIndex = 8
        Me.BtnLuanchOptimization.UseVisualStyleBackColor = True
        '
        'BtnShowGraphics
        '
        Me.BtnShowGraphics.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.BtnShowGraphics, 2)
        Me.BtnShowGraphics.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShowGraphics.Image = Global.RMOS3.My.Resources.Resources.Chart1
        Me.BtnShowGraphics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnShowGraphics.Location = New System.Drawing.Point(20, 190)
        Me.BtnShowGraphics.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnShowGraphics.Name = "BtnShowGraphics"
        Me.BtnShowGraphics.Size = New System.Drawing.Size(195, 40)
        Me.BtnShowGraphics.TabIndex = 15
        Me.BtnShowGraphics.Text = "Show Graphics"
        Me.BtnShowGraphics.UseVisualStyleBackColor = True
        '
        'BtnShowReport
        '
        Me.BtnShowReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.BtnShowReport, 2)
        Me.BtnShowReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShowReport.Image = Global.RMOS3.My.Resources.Resources.Table
        Me.BtnShowReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnShowReport.Location = New System.Drawing.Point(20, 146)
        Me.BtnShowReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnShowReport.Name = "BtnShowReport"
        Me.BtnShowReport.Size = New System.Drawing.Size(195, 40)
        Me.BtnShowReport.TabIndex = 16
        Me.BtnShowReport.Text = "Show Report"
        Me.BtnShowReport.UseVisualStyleBackColor = True
        '
        'TsmiShowTables
        '
        Me.TsmiShowTables.Image = Global.RMOS3.My.Resources.Resources.Table
        Me.TsmiShowTables.Name = "TsmiShowTables"
        Me.TsmiShowTables.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.TsmiShowTables.Size = New System.Drawing.Size(185, 26)
        Me.TsmiShowTables.Text = "Show Tables"
        '
        'TsmiShowGraphics
        '
        Me.TsmiShowGraphics.Image = Global.RMOS3.My.Resources.Resources.Chart1
        Me.TsmiShowGraphics.Name = "TsmiShowGraphics"
        Me.TsmiShowGraphics.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.TsmiShowGraphics.Size = New System.Drawing.Size(198, 26)
        Me.TsmiShowGraphics.Text = "Show Graphics"
        '
        'GWOAlgoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 442)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "GWOAlgoForm"
        Me.Text = "Grey Wolf Optimization Algorithm (GWO)"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Chart_RD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxtMenuCharts.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Chart_S, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxtMenuDGV.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Chart_RD As DataVisualization.Charting.Chart
    Friend WithEvents CxtMenuCharts As ContextMenuStrip
    Friend WithEvents TsmiShowGraphics As ToolStripMenuItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Chart_S As DataVisualization.Charting.Chart
    Friend WithEvents ColInfiltration As DataGridViewTextBoxColumn
    Friend WithEvents DgvResults As DataGridView
    Friend WithEvents ColN As DataGridViewTextBoxColumn
    Friend WithEvents ColTime As DataGridViewTextBoxColumn
    Friend WithEvents ColDemands As DataGridViewTextBoxColumn
    Friend WithEvents ColRelease As DataGridViewTextBoxColumn
    Friend WithEvents ColInflow As DataGridViewTextBoxColumn
    Friend WithEvents ColStorage As DataGridViewTextBoxColumn
    Friend WithEvents ColOverflow As DataGridViewTextBoxColumn
    Friend WithEvents ColEvaporation As DataGridViewTextBoxColumn
    Friend WithEvents CxtMenuDGV As ContextMenuStrip
    Friend WithEvents TsmiShowTables As ToolStripMenuItem
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnLuanchOptimization As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents PropertyGrd As PropertyGrid
    Friend WithEvents CmbInflowSeries As ComboBox
    Friend WithEvents CmbDemands As ComboBox
    Friend WithEvents CmbEvaporation As ComboBox
    Friend WithEvents CmbInfiltration As ComboBox
    Friend WithEvents BtnShowGraphics As Button
    Friend WithEvents BtnShowReport As Button
    Friend WithEvents BtnObjectiveFunction As Button
End Class
