<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMarcas_new
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMarcas_new))
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.btnNombre = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblUltimaJustificacion = New System.Windows.Forms.Label()
        Me._titulo1 = New WindowsApplication1._titulo()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(419, 73)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblInicio.TabIndex = 49
        Me.lblInicio.Text = "Inicio:"
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(561, 73)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(32, 13)
        Me.lblFin.TabIndex = 50
        Me.lblFin.Text = "Final:"
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(458, 69)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(95, 20)
        Me.dtpInicio.TabIndex = 51
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(596, 69)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtpFinal.TabIndex = 52
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(61, 69)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(350, 20)
        Me.txtNombre.TabIndex = 53
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
        Me.DataGridView1.Location = New System.Drawing.Point(0, 109)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(988, 348)
        Me.DataGridView1.TabIndex = 54
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Progress, Me.lblProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 460)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(988, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 55
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
        'btnCargar
        '
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(700, 68)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(64, 23)
        Me.btnCargar.TabIndex = 56
        Me.btnCargar.Text = "Car&gar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'btnNombre
        '
        Me.btnNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNombre.ForeColor = System.Drawing.Color.Blue
        Me.btnNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNombre.Location = New System.Drawing.Point(2, 69)
        Me.btnNombre.Name = "btnNombre"
        Me.btnNombre.Size = New System.Drawing.Size(55, 21)
        Me.btnNombre.TabIndex = 57
        Me.btnNombre.Text = "&Nombre:"
        Me.btnNombre.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimir, Me.btnExcel, Me.ToolStripSeparator3, Me.btnGuardar, Me.ToolStripSeparator4, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(988, 25)
        Me.ToolStrip1.TabIndex = 58
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
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(66, 22)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.ToolTipText = "Guardar datos cargados"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'lblUltimaJustificacion
        '
        Me.lblUltimaJustificacion.AutoSize = True
        Me.lblUltimaJustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaJustificacion.Location = New System.Drawing.Point(32, 92)
        Me.lblUltimaJustificacion.Name = "lblUltimaJustificacion"
        Me.lblUltimaJustificacion.Size = New System.Drawing.Size(167, 13)
        Me.lblUltimaJustificacion.TabIndex = 59
        Me.lblUltimaJustificacion.Text = ">>> Última Justificación <<<"
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "JUSTIFICACIÓN DE MARCAS"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 24)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(989, 34)
        Me._titulo1.TabIndex = 47
        '
        'frmConsultaMarcas_new
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(988, 482)
        Me.Controls.Add(Me.lblUltimaJustificacion)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnNombre)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.lblFin)
        Me.Controls.Add(Me.lblInicio)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaMarcas_new"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JUSTIFICACIÓN DE MARCAS"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnNombre As System.Windows.Forms.Button
    Friend WithEvents Progress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUltimaJustificacion As System.Windows.Forms.Label
End Class
