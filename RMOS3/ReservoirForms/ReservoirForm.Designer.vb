<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReservoirForm
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
        Dim ChartArea9 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend9 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea10 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend10 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea11 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend11 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea12 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend12 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series12 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnCurveHV = New System.Windows.Forms.Button()
        Me.DgvCurveHV = New System.Windows.Forms.DataGridView()
        Me.ColH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChartCrveHV = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnCurveHS = New System.Windows.Forms.Button()
        Me.DgvCurveHS = New System.Windows.Forms.DataGridView()
        Me.ColHs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChartCrveHS = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnEvaporationCrve = New System.Windows.Forms.Button()
        Me.DgvCurveEvaporation = New System.Windows.Forms.DataGridView()
        Me.ColMonths = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEvapoRates = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChartCrveEvaporation = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnInfiltrationCrve = New System.Windows.Forms.Button()
        Me.DgvCurveInfiltration = New System.Windows.Forms.DataGridView()
        Me.ColVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColInfiltration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChartCrveInfiltration = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtyGrdReservoir = New System.Windows.Forms.PropertyGrid()
        Me.BtnReservoirsCurves = New System.Windows.Forms.Button()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtBxReservoirName = New System.Windows.Forms.TextBox()
        Me.TxtBxInflowSeries = New System.Windows.Forms.TextBox()
        Me.TxtBxDownstream = New System.Windows.Forms.TextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.DgvInflow = New System.Windows.Forms.DataGridView()
        Me.DgvDownstream = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.ColID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtBxInflowDsName = New System.Windows.Forms.TextBox()
        Me.TxtBxInflowDsDescription = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.DgvCurveHV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartCrveHV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DgvCurveHS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartCrveHS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.DgvCurveEvaporation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartCrveEvaporation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.DgvCurveInfiltration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartCrveInfiltration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        CType(Me.DgvInflow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvDownstream, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(645, 327)
        Me.SplitContainer1.SplitterDistance = 407
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(407, 327)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(399, 301)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Reservoir"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Size = New System.Drawing.Size(399, 301)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Curve (H-V)"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 2)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ChartCrveHV)
        Me.SplitContainer2.Size = New System.Drawing.Size(393, 297)
        Me.SplitContainer2.SplitterDistance = 131
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnCurveHV, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.DgvCurveHV, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(131, 297)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'BtnCurveHV
        '
        Me.BtnCurveHV.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCurveHV.Location = New System.Drawing.Point(3, 10)
        Me.BtnCurveHV.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnCurveHV.Name = "BtnCurveHV"
        Me.BtnCurveHV.Size = New System.Drawing.Size(125, 28)
        Me.BtnCurveHV.TabIndex = 0
        Me.BtnCurveHV.Text = "Curve Modification"
        Me.BtnCurveHV.UseVisualStyleBackColor = True
        '
        'DgvCurveHV
        '
        Me.DgvCurveHV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCurveHV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColH, Me.ColV})
        Me.DgvCurveHV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCurveHV.Location = New System.Drawing.Point(3, 42)
        Me.DgvCurveHV.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvCurveHV.Name = "DgvCurveHV"
        Me.DgvCurveHV.RowTemplate.Height = 26
        Me.DgvCurveHV.Size = New System.Drawing.Size(125, 253)
        Me.DgvCurveHV.TabIndex = 1
        '
        'ColH
        '
        Me.ColH.HeaderText = "Elevation H (m)"
        Me.ColH.Name = "ColH"
        '
        'ColV
        '
        Me.ColV.HeaderText = "Volume V (Mm3)"
        Me.ColV.Name = "ColV"
        '
        'ChartCrveHV
        '
        ChartArea9.Name = "ChartArea1"
        Me.ChartCrveHV.ChartAreas.Add(ChartArea9)
        Me.ChartCrveHV.Dock = System.Windows.Forms.DockStyle.Fill
        Legend9.Alignment = System.Drawing.StringAlignment.Center
        Legend9.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend9.Name = "Legend1"
        Me.ChartCrveHV.Legends.Add(Legend9)
        Me.ChartCrveHV.Location = New System.Drawing.Point(0, 0)
        Me.ChartCrveHV.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartCrveHV.Name = "ChartCrveHV"
        Series9.ChartArea = "ChartArea1"
        Series9.Legend = "Legend1"
        Series9.Name = "Series1"
        Me.ChartCrveHV.Series.Add(Series9)
        Me.ChartCrveHV.Size = New System.Drawing.Size(259, 297)
        Me.ChartCrveHV.TabIndex = 0
        Me.ChartCrveHV.Text = "H-V"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(399, 301)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Curve (H-S)"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.TableLayoutPanel3)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.ChartCrveHS)
        Me.SplitContainer3.Size = New System.Drawing.Size(399, 301)
        Me.SplitContainer3.SplitterDistance = 133
        Me.SplitContainer3.SplitterWidth = 3
        Me.SplitContainer3.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.BtnCurveHS, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.DgvCurveHS, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(133, 301)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'BtnCurveHS
        '
        Me.BtnCurveHS.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCurveHS.Location = New System.Drawing.Point(3, 10)
        Me.BtnCurveHS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnCurveHS.Name = "BtnCurveHS"
        Me.BtnCurveHS.Size = New System.Drawing.Size(127, 28)
        Me.BtnCurveHS.TabIndex = 0
        Me.BtnCurveHS.Text = "Curve Modification"
        Me.BtnCurveHS.UseVisualStyleBackColor = True
        '
        'DgvCurveHS
        '
        Me.DgvCurveHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCurveHS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColHs, Me.ColS})
        Me.DgvCurveHS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCurveHS.Location = New System.Drawing.Point(3, 42)
        Me.DgvCurveHS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvCurveHS.Name = "DgvCurveHS"
        Me.DgvCurveHS.RowTemplate.Height = 26
        Me.DgvCurveHS.Size = New System.Drawing.Size(127, 257)
        Me.DgvCurveHS.TabIndex = 1
        '
        'ColHs
        '
        Me.ColHs.HeaderText = "Elevation H(m)"
        Me.ColHs.Name = "ColHs"
        '
        'ColS
        '
        Me.ColS.HeaderText = "Surface A (Ha)"
        Me.ColS.Name = "ColS"
        '
        'ChartCrveHS
        '
        ChartArea10.Name = "ChartArea1"
        Me.ChartCrveHS.ChartAreas.Add(ChartArea10)
        Me.ChartCrveHS.Dock = System.Windows.Forms.DockStyle.Fill
        Legend10.Alignment = System.Drawing.StringAlignment.Center
        Legend10.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend10.Name = "Legend1"
        Me.ChartCrveHS.Legends.Add(Legend10)
        Me.ChartCrveHS.Location = New System.Drawing.Point(0, 0)
        Me.ChartCrveHS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartCrveHS.Name = "ChartCrveHS"
        Series10.ChartArea = "ChartArea1"
        Series10.Legend = "Legend1"
        Series10.Name = "Series1"
        Me.ChartCrveHS.Series.Add(Series10)
        Me.ChartCrveHS.Size = New System.Drawing.Size(263, 301)
        Me.ChartCrveHS.TabIndex = 0
        Me.ChartCrveHS.Text = "H-V"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SplitContainer4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(399, 301)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Evaporation"
        Me.TabPage4.UseVisualStyleBackColor = True
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
        Me.SplitContainer4.Panel1.Controls.Add(Me.TableLayoutPanel4)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.ChartCrveEvaporation)
        Me.SplitContainer4.Size = New System.Drawing.Size(399, 301)
        Me.SplitContainer4.SplitterDistance = 133
        Me.SplitContainer4.SplitterWidth = 3
        Me.SplitContainer4.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.BtnEvaporationCrve, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.DgvCurveEvaporation, 0, 2)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(133, 301)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'BtnEvaporationCrve
        '
        Me.BtnEvaporationCrve.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEvaporationCrve.Location = New System.Drawing.Point(3, 10)
        Me.BtnEvaporationCrve.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnEvaporationCrve.Name = "BtnEvaporationCrve"
        Me.BtnEvaporationCrve.Size = New System.Drawing.Size(127, 28)
        Me.BtnEvaporationCrve.TabIndex = 0
        Me.BtnEvaporationCrve.Text = "Curve Modification"
        Me.BtnEvaporationCrve.UseVisualStyleBackColor = True
        '
        'DgvCurveEvaporation
        '
        Me.DgvCurveEvaporation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCurveEvaporation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMonths, Me.ColEvapoRates})
        Me.DgvCurveEvaporation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCurveEvaporation.Location = New System.Drawing.Point(3, 42)
        Me.DgvCurveEvaporation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvCurveEvaporation.Name = "DgvCurveEvaporation"
        Me.DgvCurveEvaporation.RowTemplate.Height = 26
        Me.DgvCurveEvaporation.Size = New System.Drawing.Size(127, 257)
        Me.DgvCurveEvaporation.TabIndex = 1
        '
        'ColMonths
        '
        Me.ColMonths.HeaderText = "Time (Months)"
        Me.ColMonths.Name = "ColMonths"
        '
        'ColEvapoRates
        '
        Me.ColEvapoRates.HeaderText = "Rate (mm)"
        Me.ColEvapoRates.Name = "ColEvapoRates"
        '
        'ChartCrveEvaporation
        '
        ChartArea11.Name = "ChartArea1"
        Me.ChartCrveEvaporation.ChartAreas.Add(ChartArea11)
        Me.ChartCrveEvaporation.Dock = System.Windows.Forms.DockStyle.Fill
        Legend11.Alignment = System.Drawing.StringAlignment.Center
        Legend11.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend11.Name = "Legend1"
        Me.ChartCrveEvaporation.Legends.Add(Legend11)
        Me.ChartCrveEvaporation.Location = New System.Drawing.Point(0, 0)
        Me.ChartCrveEvaporation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartCrveEvaporation.Name = "ChartCrveEvaporation"
        Series11.ChartArea = "ChartArea1"
        Series11.Legend = "Legend1"
        Series11.Name = "Series1"
        Me.ChartCrveEvaporation.Series.Add(Series11)
        Me.ChartCrveEvaporation.Size = New System.Drawing.Size(263, 301)
        Me.ChartCrveEvaporation.TabIndex = 0
        Me.ChartCrveEvaporation.Text = "H-V"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.SplitContainer5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(399, 301)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Infiltration"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.TableLayoutPanel5)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.ChartCrveInfiltration)
        Me.SplitContainer5.Size = New System.Drawing.Size(399, 301)
        Me.SplitContainer5.SplitterDistance = 133
        Me.SplitContainer5.SplitterWidth = 3
        Me.SplitContainer5.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.BtnInfiltrationCrve, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.DgvCurveInfiltration, 0, 2)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(133, 301)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'BtnInfiltrationCrve
        '
        Me.BtnInfiltrationCrve.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnInfiltrationCrve.Location = New System.Drawing.Point(3, 10)
        Me.BtnInfiltrationCrve.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnInfiltrationCrve.Name = "BtnInfiltrationCrve"
        Me.BtnInfiltrationCrve.Size = New System.Drawing.Size(127, 28)
        Me.BtnInfiltrationCrve.TabIndex = 0
        Me.BtnInfiltrationCrve.Text = "Curve Modification"
        Me.BtnInfiltrationCrve.UseVisualStyleBackColor = True
        '
        'DgvCurveInfiltration
        '
        Me.DgvCurveInfiltration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCurveInfiltration.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColVolume, Me.ColInfiltration})
        Me.DgvCurveInfiltration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCurveInfiltration.Location = New System.Drawing.Point(3, 42)
        Me.DgvCurveInfiltration.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvCurveInfiltration.Name = "DgvCurveInfiltration"
        Me.DgvCurveInfiltration.RowTemplate.Height = 26
        Me.DgvCurveInfiltration.Size = New System.Drawing.Size(127, 257)
        Me.DgvCurveInfiltration.TabIndex = 1
        '
        'ColVolume
        '
        Me.ColVolume.HeaderText = "Volume (Mm3)"
        Me.ColVolume.Name = "ColVolume"
        '
        'ColInfiltration
        '
        Me.ColInfiltration.HeaderText = "Infiltration Rate"
        Me.ColInfiltration.Name = "ColInfiltration"
        '
        'ChartCrveInfiltration
        '
        ChartArea12.Name = "ChartArea1"
        Me.ChartCrveInfiltration.ChartAreas.Add(ChartArea12)
        Me.ChartCrveInfiltration.Dock = System.Windows.Forms.DockStyle.Fill
        Legend12.Alignment = System.Drawing.StringAlignment.Center
        Legend12.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend12.Name = "Legend1"
        Me.ChartCrveInfiltration.Legends.Add(Legend12)
        Me.ChartCrveInfiltration.Location = New System.Drawing.Point(0, 0)
        Me.ChartCrveInfiltration.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartCrveInfiltration.Name = "ChartCrveInfiltration"
        Series12.ChartArea = "ChartArea1"
        Series12.Legend = "Legend1"
        Series12.Name = "Series1"
        Me.ChartCrveInfiltration.Series.Add(Series12)
        Me.ChartCrveInfiltration.Size = New System.Drawing.Size(263, 301)
        Me.ChartCrveInfiltration.TabIndex = 0
        Me.ChartCrveInfiltration.Text = "H-V"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PrtyGrdReservoir, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnReservoirsCurves, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(235, 327)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PrtyGrdReservoir
        '
        Me.PrtyGrdReservoir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdReservoir.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PrtyGrdReservoir.Location = New System.Drawing.Point(4, 4)
        Me.PrtyGrdReservoir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PrtyGrdReservoir.Name = "PrtyGrdReservoir"
        Me.PrtyGrdReservoir.Size = New System.Drawing.Size(227, 271)
        Me.PrtyGrdReservoir.TabIndex = 0
        '
        'BtnReservoirsCurves
        '
        Me.BtnReservoirsCurves.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReservoirsCurves.Location = New System.Drawing.Point(4, 283)
        Me.BtnReservoirsCurves.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnReservoirsCurves.Name = "BtnReservoirsCurves"
        Me.BtnReservoirsCurves.Size = New System.Drawing.Size(227, 32)
        Me.BtnReservoirsCurves.TabIndex = 1
        Me.BtnReservoirsCurves.Text = "Curves (H-V) / (H-S) /Evapo. Rates"
        Me.BtnReservoirsCurves.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.TxtBxReservoirName, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.TxtBxInflowSeries, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.TxtBxDownstream, 1, 3)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 2)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 5
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(393, 297)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reservoir :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Inflow data :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Downstream demand :"
        '
        'TxtBxReservoirName
        '
        Me.TxtBxReservoirName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBxReservoirName.Location = New System.Drawing.Point(124, 17)
        Me.TxtBxReservoirName.Name = "TxtBxReservoirName"
        Me.TxtBxReservoirName.ReadOnly = True
        Me.TxtBxReservoirName.Size = New System.Drawing.Size(266, 20)
        Me.TxtBxReservoirName.TabIndex = 3
        '
        'TxtBxInflowSeries
        '
        Me.TxtBxInflowSeries.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBxInflowSeries.Location = New System.Drawing.Point(124, 52)
        Me.TxtBxInflowSeries.Name = "TxtBxInflowSeries"
        Me.TxtBxInflowSeries.ReadOnly = True
        Me.TxtBxInflowSeries.Size = New System.Drawing.Size(266, 20)
        Me.TxtBxInflowSeries.TabIndex = 4
        '
        'TxtBxDownstream
        '
        Me.TxtBxDownstream.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBxDownstream.Location = New System.Drawing.Point(124, 89)
        Me.TxtBxDownstream.Name = "TxtBxDownstream"
        Me.TxtBxDownstream.ReadOnly = True
        Me.TxtBxDownstream.Size = New System.Drawing.Size(266, 20)
        Me.TxtBxDownstream.TabIndex = 5
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.TableLayoutPanel7)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(399, 301)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Inflow"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.TableLayoutPanel8)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(399, 301)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Downstream"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'DgvInflow
        '
        Me.DgvInflow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvInflow.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColID, Me.ColValue})
        Me.DgvInflow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvInflow.Location = New System.Drawing.Point(3, 63)
        Me.DgvInflow.Name = "DgvInflow"
        Me.DgvInflow.ReadOnly = True
        Me.DgvInflow.Size = New System.Drawing.Size(111, 229)
        Me.DgvInflow.TabIndex = 0
        '
        'DgvDownstream
        '
        Me.DgvDownstream.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDownstream.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DgvDownstream.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDownstream.Location = New System.Drawing.Point(3, 3)
        Me.DgvDownstream.Name = "DgvDownstream"
        Me.DgvDownstream.ReadOnly = True
        Me.DgvDownstream.Size = New System.Drawing.Size(111, 289)
        Me.DgvDownstream.TabIndex = 0
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.DgvInflow, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.TxtBxInflowDsName, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Chart1, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.TxtBxInflowDsDescription, 0, 1)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 3
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(393, 295)
        Me.TableLayoutPanel7.TabIndex = 1
        '
        'Chart1
        '
        ChartArea7.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea7)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend7.Alignment = System.Drawing.StringAlignment.Center
        Legend7.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend7.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend7)
        Me.Chart1.Location = New System.Drawing.Point(120, 3)
        Me.Chart1.Name = "Chart1"
        Me.TableLayoutPanel7.SetRowSpan(Me.Chart1, 3)
        Series7.ChartArea = "ChartArea1"
        Series7.Legend = "Legend1"
        Series7.Name = "Series1"
        Me.Chart1.Series.Add(Series7)
        Me.Chart1.Size = New System.Drawing.Size(270, 289)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        '
        'Chart2
        '
        ChartArea8.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea8)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Fill
        Legend8.Alignment = System.Drawing.StringAlignment.Center
        Legend8.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend8.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend8)
        Me.Chart2.Location = New System.Drawing.Point(120, 3)
        Me.Chart2.Name = "Chart2"
        Series8.ChartArea = "ChartArea1"
        Series8.Legend = "Legend1"
        Series8.Name = "Series1"
        Me.Chart2.Series.Add(Series8)
        Me.Chart2.Size = New System.Drawing.Size(270, 289)
        Me.Chart2.TabIndex = 1
        Me.Chart2.Text = "Chart2"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.DgvDownstream, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Chart2, 1, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(393, 295)
        Me.TableLayoutPanel8.TabIndex = 2
        '
        'ColID
        '
        Me.ColID.HeaderText = "ID"
        Me.ColID.Name = "ColID"
        '
        'ColValue
        '
        Me.ColValue.HeaderText = "Value"
        Me.ColValue.Name = "ColValue"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'TxtBxInflowDsName
        '
        Me.TxtBxInflowDsName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBxInflowDsName.Location = New System.Drawing.Point(3, 5)
        Me.TxtBxInflowDsName.Name = "TxtBxInflowDsName"
        Me.TxtBxInflowDsName.ReadOnly = True
        Me.TxtBxInflowDsName.Size = New System.Drawing.Size(111, 20)
        Me.TxtBxInflowDsName.TabIndex = 2
        '
        'TxtBxInflowDsDescription
        '
        Me.TxtBxInflowDsDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBxInflowDsDescription.Location = New System.Drawing.Point(3, 35)
        Me.TxtBxInflowDsDescription.Name = "TxtBxInflowDsDescription"
        Me.TxtBxInflowDsDescription.ReadOnly = True
        Me.TxtBxInflowDsDescription.Size = New System.Drawing.Size(111, 20)
        Me.TxtBxInflowDsDescription.TabIndex = 3
        '
        'ReservoirForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 327)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ReservoirForm"
        Me.Text = "Reservoir"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.DgvCurveHV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartCrveHV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.DgvCurveHS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartCrveHS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.DgvCurveEvaporation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartCrveEvaporation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.DgvCurveInfiltration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartCrveInfiltration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        CType(Me.DgvInflow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvDownstream, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PrtyGrdReservoir As PropertyGrid
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents BtnReservoirsCurves As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents BtnCurveHV As Button
    Friend WithEvents DgvCurveHV As DataGridView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ChartCrveHV As DataVisualization.Charting.Chart
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents ChartCrveEvaporation As DataVisualization.Charting.Chart
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents ChartCrveHS As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents BtnCurveHS As Button
    Friend WithEvents DgvCurveHS As DataGridView
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents BtnEvaporationCrve As Button
    Friend WithEvents DgvCurveEvaporation As DataGridView
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents BtnInfiltrationCrve As Button
    Friend WithEvents DgvCurveInfiltration As DataGridView
    Friend WithEvents ChartCrveInfiltration As DataVisualization.Charting.Chart
    Friend WithEvents ColH As DataGridViewTextBoxColumn
    Friend WithEvents ColV As DataGridViewTextBoxColumn
    Friend WithEvents ColHs As DataGridViewTextBoxColumn
    Friend WithEvents ColS As DataGridViewTextBoxColumn
    Friend WithEvents ColMonths As DataGridViewTextBoxColumn
    Friend WithEvents ColEvapoRates As DataGridViewTextBoxColumn
    Friend WithEvents ColVolume As DataGridViewTextBoxColumn
    Friend WithEvents ColInfiltration As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtBxReservoirName As TextBox
    Friend WithEvents TxtBxInflowSeries As TextBox
    Friend WithEvents TxtBxDownstream As TextBox
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents DgvInflow As DataGridView
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents DgvDownstream As DataGridView
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents ColID As DataGridViewTextBoxColumn
    Friend WithEvents ColValue As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents TxtBxInflowDsName As TextBox
    Friend WithEvents TxtBxInflowDsDescription As TextBox
End Class
