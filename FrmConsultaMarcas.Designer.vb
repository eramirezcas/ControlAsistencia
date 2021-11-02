<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultaMarcas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaMarcas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblMensage = New System.Windows.Forms.Label()
        Me.tsVCR = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrimero = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.tsbUltimo = New System.Windows.Forms.ToolStripButton()
        Me.lblRecActual = New System.Windows.Forms.Label()
        Me.lblLocalizar = New System.Windows.Forms.Label()
        Me.pctLocalizar = New System.Windows.Forms.PictureBox()
        Me.txtLocalizar = New System.Windows.Forms.TextBox()
        Me.dgvHorarios = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblUltimaJustificacion = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.btnJustificar = New System.Windows.Forms.ToolStripButton()
        Me.btnAplicar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.BtnFiltar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtEpmID = New System.Windows.Forms.TextBox()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.tsVCR.SuspendLayout()
        CType(Me.pctLocalizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblMensage)
        Me.GroupBox1.Controls.Add(Me.tsVCR)
        Me.GroupBox1.Controls.Add(Me.lblRecActual)
        Me.GroupBox1.Controls.Add(Me.lblLocalizar)
        Me.GroupBox1.Controls.Add(Me.pctLocalizar)
        Me.GroupBox1.Controls.Add(Me.txtLocalizar)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 476)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(870, 38)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'lblMensage
        '
        Me.lblMensage.BackColor = System.Drawing.Color.Transparent
        Me.lblMensage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMensage.Location = New System.Drawing.Point(300, 13)
        Me.lblMensage.Name = "lblMensage"
        Me.lblMensage.Size = New System.Drawing.Size(359, 18)
        Me.lblMensage.TabIndex = 39
        '
        'tsVCR
        '
        Me.tsVCR.BackColor = System.Drawing.Color.Transparent
        Me.tsVCR.Dock = System.Windows.Forms.DockStyle.None
        Me.tsVCR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.tsbPrimero, Me.tsbAnterior, Me.ToolStripSeparator3, Me.tsbSiguiente, Me.tsbUltimo})
        Me.tsVCR.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsVCR.Location = New System.Drawing.Point(664, 11)
        Me.tsVCR.Name = "tsVCR"
        Me.tsVCR.Size = New System.Drawing.Size(105, 23)
        Me.tsVCR.TabIndex = 7
        Me.tsVCR.Text = "ToolStrip2"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'tsbPrimero
        '
        Me.tsbPrimero.Image = CType(resources.GetObject("tsbPrimero.Image"), System.Drawing.Image)
        Me.tsbPrimero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrimero.Name = "tsbPrimero"
        Me.tsbPrimero.Size = New System.Drawing.Size(23, 20)
        Me.tsbPrimero.Tag = "1"
        Me.tsbPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbPrimero.ToolTipText = "Ir al primero"
        '
        'tsbAnterior
        '
        Me.tsbAnterior.Image = CType(resources.GetObject("tsbAnterior.Image"), System.Drawing.Image)
        Me.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnterior.Name = "tsbAnterior"
        Me.tsbAnterior.Size = New System.Drawing.Size(23, 20)
        Me.tsbAnterior.Tag = "2"
        Me.tsbAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbAnterior.ToolTipText = "Ir al anterior"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'tsbSiguiente
        '
        Me.tsbSiguiente.Image = CType(resources.GetObject("tsbSiguiente.Image"), System.Drawing.Image)
        Me.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSiguiente.Name = "tsbSiguiente"
        Me.tsbSiguiente.Size = New System.Drawing.Size(23, 20)
        Me.tsbSiguiente.Tag = "3"
        Me.tsbSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbSiguiente.ToolTipText = "Ir al siguiente"
        '
        'tsbUltimo
        '
        Me.tsbUltimo.Image = CType(resources.GetObject("tsbUltimo.Image"), System.Drawing.Image)
        Me.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbUltimo.Name = "tsbUltimo"
        Me.tsbUltimo.Size = New System.Drawing.Size(23, 20)
        Me.tsbUltimo.Tag = "4"
        Me.tsbUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbUltimo.ToolTipText = "Ir al último"
        '
        'lblRecActual
        '
        Me.lblRecActual.Location = New System.Drawing.Point(749, 16)
        Me.lblRecActual.Name = "lblRecActual"
        Me.lblRecActual.Size = New System.Drawing.Size(117, 13)
        Me.lblRecActual.TabIndex = 5
        Me.lblRecActual.Text = "Registro #0/0"
        Me.lblRecActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLocalizar
        '
        Me.lblLocalizar.AutoSize = True
        Me.lblLocalizar.Location = New System.Drawing.Point(2, 16)
        Me.lblLocalizar.Name = "lblLocalizar"
        Me.lblLocalizar.Size = New System.Drawing.Size(52, 13)
        Me.lblLocalizar.TabIndex = 3
        Me.lblLocalizar.Text = "Localizar:"
        '
        'pctLocalizar
        '
        Me.pctLocalizar.BackColor = System.Drawing.Color.Transparent
        Me.pctLocalizar.Image = CType(resources.GetObject("pctLocalizar.Image"), System.Drawing.Image)
        Me.pctLocalizar.Location = New System.Drawing.Point(276, 12)
        Me.pctLocalizar.Name = "pctLocalizar"
        Me.pctLocalizar.Size = New System.Drawing.Size(18, 20)
        Me.pctLocalizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLocalizar.TabIndex = 3
        Me.pctLocalizar.TabStop = False
        '
        'txtLocalizar
        '
        Me.txtLocalizar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocalizar.Location = New System.Drawing.Point(57, 12)
        Me.txtLocalizar.Name = "txtLocalizar"
        Me.txtLocalizar.Size = New System.Drawing.Size(216, 20)
        Me.txtLocalizar.TabIndex = 4
        '
        'dgvHorarios
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHorarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHorarios.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvHorarios.Location = New System.Drawing.Point(0, 118)
        Me.dgvHorarios.Name = "dgvHorarios"
        Me.dgvHorarios.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHorarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvHorarios.Size = New System.Drawing.Size(878, 359)
        Me.dgvHorarios.TabIndex = 35
        '
        'lblUltimaJustificacion
        '
        Me.lblUltimaJustificacion.AutoSize = True
        Me.lblUltimaJustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaJustificacion.Location = New System.Drawing.Point(98, 98)
        Me.lblUltimaJustificacion.Name = "lblUltimaJustificacion"
        Me.lblUltimaJustificacion.Size = New System.Drawing.Size(148, 13)
        Me.lblUltimaJustificacion.TabIndex = 49
        Me.lblUltimaJustificacion.Text = "Fecha últma justificación"
        Me.ToolTip1.SetToolTip(Me.lblUltimaJustificacion, "Click para ver última jutificación")
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Blue
        Me.lblNombre.Location = New System.Drawing.Point(2, 75)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(50, 13)
        Me.lblNombre.TabIndex = 40
        Me.lblNombre.Text = "Nombre :"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(517, 75)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblInicio.TabIndex = 41
        Me.lblInicio.Text = "Inicio:"
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(666, 75)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(32, 13)
        Me.lblFin.TabIndex = 42
        Me.lblFin.Text = "Final:"
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(555, 71)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(95, 20)
        Me.dtpInicio.TabIndex = 43
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(700, 71)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtpFinal.TabIndex = 44
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(55, 71)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(448, 20)
        Me.txtNombre.TabIndex = 45
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConsultar, Me.btnLimpiar, Me.btnJustificar, Me.btnAplicar, Me.ToolStripSeparator5, Me.btnImprimir, Me.btnExcel, Me.BtnFiltar, Me.ToolStripSeparator2, Me.btnSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(878, 25)
        Me.tsMenu.TabIndex = 36
        Me.tsMenu.Text = "ToolStrip1"
        '
        'btnConsultar
        '
        Me.btnConsultar.AutoSize = False
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 22)
        Me.btnConsultar.Text = "Consultar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AutoSize = False
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 22)
        Me.btnLimpiar.Text = "Limpiar"
        '
        'btnJustificar
        '
        Me.btnJustificar.Image = CType(resources.GetObject("btnJustificar.Image"), System.Drawing.Image)
        Me.btnJustificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnJustificar.Name = "btnJustificar"
        Me.btnJustificar.Size = New System.Drawing.Size(70, 22)
        Me.btnJustificar.Text = "Justificar"
        '
        'btnAplicar
        '
        Me.btnAplicar.AutoSize = False
        Me.btnAplicar.Image = CType(resources.GetObject("btnAplicar.Image"), System.Drawing.Image)
        Me.btnAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(72, 22)
        Me.btnAplicar.Text = "&Aplicar"
        Me.btnAplicar.ToolTipText = "Aplicar "
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnImprimir
        '
        Me.btnImprimir.AutoSize = False
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 22)
        Me.btnImprimir.Text = "&Imprimir"
        '
        'btnExcel
        '
        Me.btnExcel.AutoSize = False
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(75, 22)
        Me.btnExcel.Text = "E&xcel"
        '
        'BtnFiltar
        '
        Me.BtnFiltar.AutoSize = False
        Me.BtnFiltar.Image = CType(resources.GetObject("BtnFiltar.Image"), System.Drawing.Image)
        Me.BtnFiltar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFiltar.Name = "BtnFiltar"
        Me.BtnFiltar.Size = New System.Drawing.Size(75, 22)
        Me.BtnFiltar.Text = "&Filtrar"
        '
        'btnSalir
        '
        Me.btnSalir.AutoSize = False
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 22)
        Me.btnSalir.Text = "&Salir"
        '
        'txtEpmID
        '
        Me.txtEpmID.Enabled = False
        Me.txtEpmID.Location = New System.Drawing.Point(67, 71)
        Me.txtEpmID.Name = "txtEpmID"
        Me.txtEpmID.ReadOnly = True
        Me.txtEpmID.Size = New System.Drawing.Size(0, 20)
        Me.txtEpmID.TabIndex = 47
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "JUSTIFICACIÓN DE MARCAS"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(879, 34)
        Me._titulo1.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Última justificación:"
        '
        'FrmConsultaMarcas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(878, 517)
        Me.Controls.Add(Me.lblUltimaJustificacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.lblFin)
        Me.Controls.Add(Me.lblInicio)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.dgvHorarios)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.txtEpmID)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsultaMarcas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JUSTIFICACIÓN DE MARCAS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsVCR.ResumeLayout(False)
        Me.tsVCR.PerformLayout()
        CType(Me.pctLocalizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHorarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tsVCR As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblRecActual As System.Windows.Forms.Label
    Friend WithEvents lblLocalizar As System.Windows.Forms.Label
    Friend WithEvents pctLocalizar As System.Windows.Forms.PictureBox
    Friend WithEvents txtLocalizar As System.Windows.Forms.TextBox
    Friend WithEvents dgvHorarios As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnFiltar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnJustificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtEpmID As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblMensage As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUltimaJustificacion As System.Windows.Forms.Label
End Class
