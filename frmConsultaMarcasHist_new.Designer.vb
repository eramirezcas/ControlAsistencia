<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMarcasHist_new
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMarcasHist_new))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.dtFInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtFFinal = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNombre = New System.Windows.Forms.Button()
        Me.ckTodos = New System.Windows.Forms.CheckBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.TB1TableAdapter1 = New WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnImprimir, Me.ToolStripSeparator5, Me.tsbExcel, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(988, 25)
        Me.ToolStrip1.TabIndex = 26
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(65, 22)
        Me.btnImprimir.Text = "&Imprimir"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExcel
        '
        Me.tsbExcel.AutoSize = False
        Me.tsbExcel.Image = CType(resources.GetObject("tsbExcel.Image"), System.Drawing.Image)
        Me.tsbExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExcel.Name = "tsbExcel"
        Me.tsbExcel.Size = New System.Drawing.Size(65, 22)
        Me.tsbExcel.Text = "&Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSalir
        '
        Me.tsbSalir.AutoSize = False
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(0, 100)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(988, 348)
        Me.DataGridView1.TabIndex = 27
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Progress, Me.lblProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 450)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(988, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 61
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
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(66, 75)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(342, 20)
        Me.txtNombre.TabIndex = 76
        '
        'dtFInicial
        '
        Me.dtFInicial.Enabled = False
        Me.dtFInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFInicial.Location = New System.Drawing.Point(462, 75)
        Me.dtFInicial.Name = "dtFInicial"
        Me.dtFInicial.Size = New System.Drawing.Size(85, 20)
        Me.dtFInicial.TabIndex = 75
        '
        'dtFFinal
        '
        Me.dtFFinal.Enabled = False
        Me.dtFFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFFinal.Location = New System.Drawing.Point(553, 75)
        Me.dtFFinal.Name = "dtFFinal"
        Me.dtFFinal.Size = New System.Drawing.Size(85, 20)
        Me.dtFFinal.TabIndex = 73
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.WindowsApplication1.My.Resources.Resources.refresh
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(701, 74)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(69, 23)
        Me.btnGenerar.TabIndex = 71
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(414, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Fechas:"
        '
        'btnNombre
        '
        Me.btnNombre.Enabled = False
        Me.btnNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNombre.ForeColor = System.Drawing.Color.Blue
        Me.btnNombre.Location = New System.Drawing.Point(5, 74)
        Me.btnNombre.Name = "btnNombre"
        Me.btnNombre.Size = New System.Drawing.Size(55, 22)
        Me.btnNombre.TabIndex = 77
        Me.btnNombre.Text = "Nombre:"
        Me.btnNombre.UseVisualStyleBackColor = True
        '
        'ckTodos
        '
        Me.ckTodos.AutoSize = True
        Me.ckTodos.Checked = True
        Me.ckTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckTodos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ckTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTodos.ForeColor = System.Drawing.Color.Blue
        Me.ckTodos.Location = New System.Drawing.Point(644, 77)
        Me.ckTodos.Name = "ckTodos"
        Me.ckTodos.Size = New System.Drawing.Size(51, 17)
        Me.ckTodos.TabIndex = 78
        Me.ckTodos.Text = "Todo"
        Me.ckTodos.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(703, 74)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(67, 23)
        Me.btnLimpiar.TabIndex = 79
        Me.btnLimpiar.Text = "&Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'TB1TableAdapter1
        '
        Me.TB1TableAdapter1.ClearBeforeFill = True
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "CONSULTA DE MARCAS HISTORICAS"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(989, 34)
        Me._titulo1.TabIndex = 25
        '
        'frmConsultaMarcasHist_new
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(988, 472)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.ckTodos)
        Me.Controls.Add(Me.btnNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.dtFInicial)
        Me.Controls.Add(Me.dtFFinal)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaMarcasHist_new"
        Me.Text = "CONSULTA DE MARCAS HISTORICAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Progress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents dtFInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNombre As System.Windows.Forms.Button
    Friend WithEvents ckTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents TB1TableAdapter1 As WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter
End Class
