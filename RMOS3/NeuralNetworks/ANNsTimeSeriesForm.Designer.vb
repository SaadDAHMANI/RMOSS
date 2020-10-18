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
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea9 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend9 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea10 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend10 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.DataTabPage = New System.Windows.Forms.TabPage()
        Me.TabPageDataStructure = New System.Windows.Forms.TabPage()
        Me.TrainingTestingTabPage = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CmbInputsFileType = New System.Windows.Forms.ComboBox()
        Me.BtnImportInputs = New System.Windows.Forms.Button()
        Me.PrptGrdInput = New System.Windows.Forms.PropertyGrid()
        Me.DataChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PrtyGrdAnnData = New System.Windows.Forms.PropertyGrid()
        Me.BtnFormateDataSerie = New System.Windows.Forms.Button()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.MainTabControl.SuspendLayout()
        Me.DataTabPage.SuspendLayout()
        Me.TabPageDataStructure.SuspendLayout()
        Me.TrainingTestingTabPage.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataChart, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.DataTabPage)
        Me.MainTabControl.Controls.Add(Me.TabPageDataStructure)
        Me.MainTabControl.Controls.Add(Me.TrainingTestingTabPage)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(800, 450)
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
        'TabPageDataStructure
        '
        Me.TabPageDataStructure.Controls.Add(Me.SplitContainer2)
        Me.TabPageDataStructure.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDataStructure.Name = "TabPageDataStructure"
        Me.TabPageDataStructure.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDataStructure.Size = New System.Drawing.Size(792, 424)
        Me.TabPageDataStructure.TabIndex = 1
        Me.TabPageDataStructure.Text = "ANN-Data Structure"
        Me.TabPageDataStructure.UseVisualStyleBackColor = True
        '
        'TrainingTestingTabPage
        '
        Me.TrainingTestingTabPage.Controls.Add(Me.SplitContainer4)
        Me.TrainingTestingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.TrainingTestingTabPage.Name = "TrainingTestingTabPage"
        Me.TrainingTestingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TrainingTestingTabPage.Size = New System.Drawing.Size(792, 424)
        Me.TrainingTestingTabPage.TabIndex = 2
        Me.TrainingTestingTabPage.Text = "Training-Testing"
        Me.TrainingTestingTabPage.UseVisualStyleBackColor = True
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
        ChartArea8.Name = "ChartArea1"
        Me.DataChart.ChartAreas.Add(ChartArea8)
        Me.DataChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend8.Alignment = System.Drawing.StringAlignment.Center
        Legend8.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend8.Name = "Legend1"
        Me.DataChart.Legends.Add(Legend8)
        Me.DataChart.Location = New System.Drawing.Point(0, 0)
        Me.DataChart.Name = "DataChart"
        Series8.ChartArea = "ChartArea1"
        Series8.Legend = "Legend1"
        Series8.Name = "Series1"
        Me.DataChart.Series.Add(Series8)
        Me.DataChart.Size = New System.Drawing.Size(520, 418)
        Me.DataChart.TabIndex = 1
        Me.DataChart.Text = "Chart1"
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
        Me.SplitContainer2.Size = New System.Drawing.Size(786, 418)
        Me.SplitContainer2.SplitterDistance = 262
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
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(262, 418)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'PrtyGrdAnnData
        '
        Me.PrtyGrdAnnData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrtyGrdAnnData.Location = New System.Drawing.Point(3, 61)
        Me.PrtyGrdAnnData.Name = "PrtyGrdAnnData"
        Me.PrtyGrdAnnData.Size = New System.Drawing.Size(256, 354)
        Me.PrtyGrdAnnData.TabIndex = 7
        '
        'BtnFormateDataSerie
        '
        Me.BtnFormateDataSerie.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFormateDataSerie.Location = New System.Drawing.Point(3, 15)
        Me.BtnFormateDataSerie.Name = "BtnFormateDataSerie"
        Me.BtnFormateDataSerie.Size = New System.Drawing.Size(256, 40)
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
        Me.SplitContainer3.Size = New System.Drawing.Size(520, 418)
        Me.SplitContainer3.SplitterDistance = 209
        Me.SplitContainer3.TabIndex = 8
        '
        'Chart1
        '
        ChartArea9.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea9)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend9.Alignment = System.Drawing.StringAlignment.Center
        Legend9.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend9.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend9)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series9.ChartArea = "ChartArea1"
        Series9.Legend = "Legend1"
        Series9.Name = "Series1"
        Me.Chart1.Series.Add(Series9)
        Me.Chart1.Size = New System.Drawing.Size(520, 209)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Chart2
        '
        ChartArea10.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea10)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Fill
        Legend10.Alignment = System.Drawing.StringAlignment.Center
        Legend10.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend10.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend10)
        Me.Chart2.Location = New System.Drawing.Point(0, 0)
        Me.Chart2.Name = "Chart2"
        Series10.ChartArea = "ChartArea1"
        Series10.Legend = "Legend1"
        Series10.Name = "Series1"
        Me.Chart2.Series.Add(Series10)
        Me.Chart2.Size = New System.Drawing.Size(520, 205)
        Me.Chart2.TabIndex = 1
        Me.Chart2.Text = "Chart2"
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.SplitContainer6)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer5)
        Me.SplitContainer4.Size = New System.Drawing.Size(786, 418)
        Me.SplitContainer4.SplitterDistance = 274
        Me.SplitContainer4.TabIndex = 0
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainer5.Size = New System.Drawing.Size(508, 418)
        Me.SplitContainer5.SplitterDistance = 169
        Me.SplitContainer5.TabIndex = 0
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainer6.Size = New System.Drawing.Size(274, 418)
        Me.SplitContainer6.SplitterDistance = 185
        Me.SplitContainer6.TabIndex = 0
        '
        'ANNsTimeSeriesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MainTabControl)
        Me.Name = "ANNsTimeSeriesForm"
        Me.Text = "ANNsTimeSeriesForm"
        Me.MainTabControl.ResumeLayout(False)
        Me.DataTabPage.ResumeLayout(False)
        Me.TabPageDataStructure.ResumeLayout(False)
        Me.TrainingTestingTabPage.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataChart, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
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
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents SplitContainer6 As SplitContainer
    Friend WithEvents SplitContainer5 As SplitContainer
End Class
