<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CurvesForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DgvData = New System.Windows.Forms.DataGridView()
        Me.ColNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColElevation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCurveName = New System.Windows.Forms.TextBox()
        Me.CmbCurveType = New System.Windows.Forms.ComboBox()
        Me.CmbMarkerSize = New System.Windows.Forms.ComboBox()
        Me.CmbExistanteCurves = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChartCrv = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.ChartCrv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvData)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(909, 413)
        Me.SplitContainer1.SplitterDistance = 346
        Me.SplitContainer1.TabIndex = 0
        '
        'DgvData
        '
        Me.DgvData.AllowUserToDeleteRows = False
        Me.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNumber, Me.ColElevation, Me.ColVolume})
        Me.DgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvData.Enabled = False
        Me.DgvData.Location = New System.Drawing.Point(0, 0)
        Me.DgvData.Margin = New System.Windows.Forms.Padding(5)
        Me.DgvData.Name = "DgvData"
        Me.DgvData.RowTemplate.Height = 26
        Me.DgvData.Size = New System.Drawing.Size(346, 413)
        Me.DgvData.TabIndex = 0
        '
        'ColNumber
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ColNumber.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColNumber.HeaderText = "N°"
        Me.ColNumber.Name = "ColNumber"
        Me.ColNumber.ReadOnly = True
        Me.ColNumber.Width = 50
        '
        'ColElevation
        '
        Me.ColElevation.HeaderText = "Elevation H (m)"
        Me.ColElevation.Name = "ColElevation"
        '
        'ColVolume
        '
        Me.ColVolume.HeaderText = "Volume V (m3)"
        Me.ColVolume.Name = "ColVolume"
        Me.ColVolume.Width = 150
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnImport, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnExport, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnOK, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnCancel, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ChartCrv, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(559, 413)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(5, 373)
        Me.BtnImport.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(90, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Import"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'BtnExport
        '
        Me.BtnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExport.Location = New System.Drawing.Point(105, 373)
        Me.BtnExport.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(90, 30)
        Me.BtnExport.TabIndex = 1
        Me.BtnExport.Text = "Export"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(364, 373)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 30)
        Me.BtnOK.TabIndex = 2
        Me.BtnOK.Text = "Ok"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(464, 373)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 5)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 221)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(553, 144)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnClear, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnNew, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtCurveName, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbCurveType, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbMarkerSize, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CmbExistanteCurves, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(547, 121)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.Location = New System.Drawing.Point(452, 84)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(90, 30)
        Me.BtnClear.TabIndex = 0
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.Location = New System.Drawing.Point(352, 83)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(5, 3, 3, 5)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(92, 30)
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Curve Type :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Curve Name :"
        '
        'TxtCurveName
        '
        Me.TxtCurveName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.TxtCurveName, 2)
        Me.TxtCurveName.Location = New System.Drawing.Point(122, 46)
        Me.TxtCurveName.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TxtCurveName.Name = "TxtCurveName"
        Me.TxtCurveName.Size = New System.Drawing.Size(320, 24)
        Me.TxtCurveName.TabIndex = 4
        '
        'CmbCurveType
        '
        Me.CmbCurveType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbCurveType.FormattingEnabled = True
        Me.CmbCurveType.Items.AddRange(New Object() {"Elevation - Volume (H-V)", "Elevation - Surface (H-S)", "Evaporation Rates (Monthly)", "Infiltration Rates"})
        Me.CmbCurveType.Location = New System.Drawing.Point(122, 87)
        Me.CmbCurveType.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.CmbCurveType.Name = "CmbCurveType"
        Me.CmbCurveType.Size = New System.Drawing.Size(220, 24)
        Me.CmbCurveType.TabIndex = 5
        Me.CmbCurveType.Text = "Select Curve Type"
        '
        'CmbMarkerSize
        '
        Me.CmbMarkerSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbMarkerSize.FormattingEnabled = True
        Me.CmbMarkerSize.Location = New System.Drawing.Point(452, 46)
        Me.CmbMarkerSize.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.CmbMarkerSize.Name = "CmbMarkerSize"
        Me.CmbMarkerSize.Size = New System.Drawing.Size(90, 24)
        Me.CmbMarkerSize.TabIndex = 6
        '
        'CmbExistanteCurves
        '
        Me.CmbExistanteCurves.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.CmbExistanteCurves, 3)
        Me.CmbExistanteCurves.FormattingEnabled = True
        Me.CmbExistanteCurves.Location = New System.Drawing.Point(122, 7)
        Me.CmbExistanteCurves.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.CmbExistanteCurves.Name = "CmbExistanteCurves"
        Me.CmbExistanteCurves.Size = New System.Drawing.Size(420, 24)
        Me.CmbExistanteCurves.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Existing Curves :"
        '
        'ChartCrv
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartCrv.ChartAreas.Add(ChartArea1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.ChartCrv, 5)
        Me.ChartCrv.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Name = "Legend1"
        Me.ChartCrv.Legends.Add(Legend1)
        Me.ChartCrv.Location = New System.Drawing.Point(5, 5)
        Me.ChartCrv.Margin = New System.Windows.Forms.Padding(5)
        Me.ChartCrv.Name = "ChartCrv"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.MarkerBorderWidth = 5
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Series1"
        Me.ChartCrv.Series.Add(Series1)
        Me.ChartCrv.Size = New System.Drawing.Size(549, 208)
        Me.ChartCrv.TabIndex = 5
        Me.ChartCrv.Text = "Chart1"
        '
        'CurvesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 413)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "CurvesForm"
        Me.Text = "Curves"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.ChartCrv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DgvData As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents BtnImport As Button
    Friend WithEvents BtnExport As Button
    Friend WithEvents BtnOK As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ChartCrv As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnNew As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCurveName As TextBox
    Friend WithEvents CmbCurveType As ComboBox
    Friend WithEvents CmbMarkerSize As ComboBox
    Friend WithEvents CmbExistanteCurves As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ColNumber As DataGridViewTextBoxColumn
    Friend WithEvents ColElevation As DataGridViewTextBoxColumn
    Friend WithEvents ColVolume As DataGridViewTextBoxColumn
End Class
