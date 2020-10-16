<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportForm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnLuanch = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnGA = New System.Windows.Forms.Button()
        Me.BtnRunGSA = New System.Windows.Forms.Button()
        Me.BtnHPSOGWO = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnLuanch, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBox1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnCancel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnClose, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(813, 378)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(3, 296)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(135, 35)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnLuanch
        '
        Me.BtnLuanch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLuanch.Location = New System.Drawing.Point(169, 296)
        Me.BtnLuanch.Name = "BtnLuanch"
        Me.BtnLuanch.Size = New System.Drawing.Size(641, 35)
        Me.BtnLuanch.TabIndex = 2
        Me.BtnLuanch.Text = "Luanch >>"
        Me.BtnLuanch.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(169, 3)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(641, 287)
        Me.ListBox1.TabIndex = 3
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(3, 342)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(125, 33)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(169, 346)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(641, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Operation :  ... of ..."
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnHPSOGWO)
        Me.GroupBox1.Controls.Add(Me.BtnRunGSA)
        Me.GroupBox1.Controls.Add(Me.BtnGA)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(155, 287)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'BtnGA
        '
        Me.BtnGA.Location = New System.Drawing.Point(6, 41)
        Me.BtnGA.Name = "BtnGA"
        Me.BtnGA.Size = New System.Drawing.Size(143, 32)
        Me.BtnGA.TabIndex = 0
        Me.BtnGA.Text = "Run GA >>"
        Me.BtnGA.UseVisualStyleBackColor = True
        '
        'BtnRunGSA
        '
        Me.BtnRunGSA.Location = New System.Drawing.Point(6, 81)
        Me.BtnRunGSA.Name = "BtnRunGSA"
        Me.BtnRunGSA.Size = New System.Drawing.Size(143, 32)
        Me.BtnRunGSA.TabIndex = 1
        Me.BtnRunGSA.Text = "Run GSA >>"
        Me.BtnRunGSA.UseVisualStyleBackColor = True
        '
        'BtnHPSOGWO
        '
        Me.BtnHPSOGWO.Location = New System.Drawing.Point(6, 120)
        Me.BtnHPSOGWO.Name = "BtnHPSOGWO"
        Me.BtnHPSOGWO.Size = New System.Drawing.Size(143, 32)
        Me.BtnHPSOGWO.TabIndex = 2
        Me.BtnHPSOGWO.Text = "Run HPSOGWO >>"
        Me.BtnHPSOGWO.UseVisualStyleBackColor = True
        '
        'ReportForm
        '
        Me.AcceptButton = Me.BtnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 378)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ReportForm"
        Me.Text = "Report"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnLuanch As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnHPSOGWO As Button
    Friend WithEvents BtnRunGSA As Button
    Friend WithEvents BtnGA As Button
End Class
