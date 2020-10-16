<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphicsForm
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.CxtMenuChart1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmiRefreshChart1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmiSaveImage1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiSaveBMPChart1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiSavePNGChart1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiSaveTIFFChart1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.CxtMenuChart2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmiRefreshChart2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.CxtMenuChart3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmiRefreshChart3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chart4 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.CxtMenuChart4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmiRefreshChart4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbBestCharts = New System.Windows.Forms.ComboBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxtMenuChart1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxtMenuChart2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxtMenuChart3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CxtMenuChart4.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.DodgerBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(827, 378)
        Me.SplitContainer1.SplitterDistance = 415
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.DodgerBlue
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(415, 378)
        Me.SplitContainer2.SplitterDistance = 191
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Chart1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 191)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Release [R*], Demands [D] :"
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.ContextMenuStrip = Me.CxtMenuChart1
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 20)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(409, 168)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'CxtMenuChart1
        '
        Me.CxtMenuChart1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMenuChart1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiRefreshChart1, Me.ToolStripSeparator1, Me.TsmiSaveImage1})
        Me.CxtMenuChart1.Name = "CxtMenuChart1"
        Me.CxtMenuChart1.Size = New System.Drawing.Size(176, 58)
        '
        'TsmiRefreshChart1
        '
        Me.TsmiRefreshChart1.Name = "TsmiRefreshChart1"
        Me.TsmiRefreshChart1.Size = New System.Drawing.Size(175, 24)
        Me.TsmiRefreshChart1.Text = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(172, 6)
        '
        'TsmiSaveImage1
        '
        Me.TsmiSaveImage1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiSaveBMPChart1, Me.TsmiSavePNGChart1, Me.TsmiSaveTIFFChart1})
        Me.TsmiSaveImage1.Name = "TsmiSaveImage1"
        Me.TsmiSaveImage1.Size = New System.Drawing.Size(175, 24)
        Me.TsmiSaveImage1.Text = "Save As Image"
        '
        'TsmiSaveBMPChart1
        '
        Me.TsmiSaveBMPChart1.Name = "TsmiSaveBMPChart1"
        Me.TsmiSaveBMPChart1.Size = New System.Drawing.Size(165, 26)
        Me.TsmiSaveBMPChart1.Text = "BMP Format"
        '
        'TsmiSavePNGChart1
        '
        Me.TsmiSavePNGChart1.Name = "TsmiSavePNGChart1"
        Me.TsmiSavePNGChart1.Size = New System.Drawing.Size(165, 26)
        Me.TsmiSavePNGChart1.Text = "PNG Format"
        '
        'TsmiSaveTIFFChart1
        '
        Me.TsmiSaveTIFFChart1.Name = "TsmiSaveTIFFChart1"
        Me.TsmiSaveTIFFChart1.Size = New System.Drawing.Size(165, 26)
        Me.TsmiSaveTIFFChart1.Text = "TIFF Format"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.Chart2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(415, 182)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stotage variation [S] :"
        '
        'Chart2
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Me.Chart2.ContextMenuStrip = Me.CxtMenuChart2
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(3, 20)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(409, 159)
        Me.Chart2.TabIndex = 0
        Me.Chart2.Text = "Chart2"
        '
        'CxtMenuChart2
        '
        Me.CxtMenuChart2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMenuChart2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiRefreshChart2})
        Me.CxtMenuChart2.Name = "CxtMenuChart2"
        Me.CxtMenuChart2.Size = New System.Drawing.Size(128, 28)
        '
        'TsmiRefreshChart2
        '
        Me.TsmiRefreshChart2.Name = "TsmiRefreshChart2"
        Me.TsmiRefreshChart2.Size = New System.Drawing.Size(127, 24)
        Me.TsmiRefreshChart2.Text = "Refresh"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.DodgerBlue
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer3.Size = New System.Drawing.Size(407, 378)
        Me.SplitContainer3.SplitterDistance = 191
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.Chart3)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(407, 191)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Overflow [O] :"
        '
        'Chart3
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea3)
        Me.Chart3.ContextMenuStrip = Me.CxtMenuChart3
        Me.Chart3.Dock = System.Windows.Forms.DockStyle.Fill
        Legend3.Alignment = System.Drawing.StringAlignment.Center
        Legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend3.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend3)
        Me.Chart3.Location = New System.Drawing.Point(3, 20)
        Me.Chart3.Name = "Chart3"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart3.Series.Add(Series3)
        Me.Chart3.Size = New System.Drawing.Size(401, 168)
        Me.Chart3.TabIndex = 0
        Me.Chart3.Text = "Chart3"
        '
        'CxtMenuChart3
        '
        Me.CxtMenuChart3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMenuChart3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiRefreshChart3})
        Me.CxtMenuChart3.Name = "CxtMenuChart3"
        Me.CxtMenuChart3.Size = New System.Drawing.Size(128, 28)
        '
        'TsmiRefreshChart3
        '
        Me.TsmiRefreshChart3.Name = "TsmiRefreshChart3"
        Me.TsmiRefreshChart3.Size = New System.Drawing.Size(127, 24)
        Me.TsmiRefreshChart3.Text = "Refresh"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(407, 182)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GA) Performance :"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chart4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbBestCharts, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(401, 159)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Chart4
        '
        ChartArea4.Name = "ChartArea1"
        Me.Chart4.ChartAreas.Add(ChartArea4)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Chart4, 2)
        Me.Chart4.ContextMenuStrip = Me.CxtMenuChart4
        Me.Chart4.Dock = System.Windows.Forms.DockStyle.Fill
        Legend4.Alignment = System.Drawing.StringAlignment.Center
        Legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend4.Name = "Legend1"
        Me.Chart4.Legends.Add(Legend4)
        Me.Chart4.Location = New System.Drawing.Point(3, 33)
        Me.Chart4.Name = "Chart4"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.Chart4.Series.Add(Series4)
        Me.Chart4.Size = New System.Drawing.Size(395, 123)
        Me.Chart4.TabIndex = 0
        Me.Chart4.Text = "Chart4"
        '
        'CxtMenuChart4
        '
        Me.CxtMenuChart4.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CxtMenuChart4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiRefreshChart4})
        Me.CxtMenuChart4.Name = "CxtMenuChart4"
        Me.CxtMenuChart4.Size = New System.Drawing.Size(128, 28)
        '
        'TsmiRefreshChart4
        '
        Me.TsmiRefreshChart4.Name = "TsmiRefreshChart4"
        Me.TsmiRefreshChart4.Size = New System.Drawing.Size(127, 24)
        Me.TsmiRefreshChart4.Text = "Refresh"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stage :"
        '
        'CmbBestCharts
        '
        Me.CmbBestCharts.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbBestCharts.FormattingEnabled = True
        Me.CmbBestCharts.Location = New System.Drawing.Point(61, 3)
        Me.CmbBestCharts.Name = "CmbBestCharts"
        Me.CmbBestCharts.Size = New System.Drawing.Size(337, 24)
        Me.CmbBestCharts.TabIndex = 1
        '
        'GAGraphicsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 378)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "GAGraphicsForm"
        Me.Text = "Results"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxtMenuChart1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxtMenuChart2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxtMenuChart3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CxtMenuChart4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Chart4 As DataVisualization.Charting.Chart
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbBestCharts As ComboBox
    Friend WithEvents CxtMenuChart1 As ContextMenuStrip
    Friend WithEvents CxtMenuChart2 As ContextMenuStrip
    Friend WithEvents CxtMenuChart3 As ContextMenuStrip
    Friend WithEvents CxtMenuChart4 As ContextMenuStrip
    Friend WithEvents TsmiRefreshChart1 As ToolStripMenuItem
    Friend WithEvents TsmiRefreshChart2 As ToolStripMenuItem
    Friend WithEvents TsmiRefreshChart3 As ToolStripMenuItem
    Friend WithEvents TsmiRefreshChart4 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TsmiSaveImage1 As ToolStripMenuItem
    Friend WithEvents TsmiSaveBMPChart1 As ToolStripMenuItem
    Friend WithEvents TsmiSavePNGChart1 As ToolStripMenuItem
    Friend WithEvents TsmiSaveTIFFChart1 As ToolStripMenuItem
End Class
