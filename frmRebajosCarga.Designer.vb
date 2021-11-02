<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRebajosCarga
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRebajosCarga))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRebajos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.TB1TableAdapter1 = New WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter()
        Me.TB1TableAdapter2 = New WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter()
        Me.TB1TableAdapter3 = New WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimir, Me.btnExcel, Me.ToolStripSeparator3, Me.btnRebajos, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(988, 25)
        Me.ToolStrip1.TabIndex = 67
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(65, 22)
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnExcel
        '
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(52, 22)
        Me.btnExcel.Text = "Excel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnRebajos
        '
        Me.btnRebajos.Image = CType(resources.GetObject("btnRebajos.Image"), System.Drawing.Image)
        Me.btnRebajos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRebajos.Name = "btnRebajos"
        Me.btnRebajos.Size = New System.Drawing.Size(108, 22)
        Me.btnRebajos.Text = "Generar Rebajos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(47, 22)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Salir de la pantalla actual"
        '
        'btnCargar
        '
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(286, 72)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(64, 23)
        Me.btnCargar.TabIndex = 66
        Me.btnCargar.Text = "Car&gar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Progress, Me.lblProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 465)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(988, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 65
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Progress
        '
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(202, 16)
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = False
        Me.lblProgress.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblProgress.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(780, 17)
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(182, 73)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtpFinal.TabIndex = 64
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(44, 73)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(95, 20)
        Me.dtpInicio.TabIndex = 63
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(147, 77)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(32, 13)
        Me.lblFin.TabIndex = 62
        Me.lblFin.Text = "Final:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(5, 77)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblInicio.TabIndex = 61
        Me.lblInicio.Text = "Inicio:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 99)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(988, 365)
        Me.DataGridView1.TabIndex = 68
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "GENERACIÓN DE REBAJOS PARA CARGA"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(989, 34)
        Me._titulo1.TabIndex = 60
        '
        'TB1TableAdapter1
        '
        Me.TB1TableAdapter1.ClearBeforeFill = True
        '
        'TB1TableAdapter2
        '
        Me.TB1TableAdapter2.ClearBeforeFill = True
        '
        'TB1TableAdapter3
        '
        Me.TB1TableAdapter3.ClearBeforeFill = True
        '
        'frmRebajosCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(988, 487)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.lblFin)
        Me.Controls.Add(Me.lblInicio)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRebajosCarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GENERACIÓN DE REBAJOS PARA CARGA"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Progress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRebajos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB1TableAdapter1 As WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter
    Friend WithEvents TB1TableAdapter2 As WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter
    Friend WithEvents TB1TableAdapter3 As WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter
End Class
