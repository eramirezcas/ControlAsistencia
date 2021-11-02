<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMarcasDia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMarcasDia))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pbProceso = New System.Windows.Forms.ProgressBar()
        Me.pctLocalizar = New System.Windows.Forms.Button()
        Me.lblMensage = New System.Windows.Forms.Label()
        Me.tsVCR = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrimero = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.tsbUltimo = New System.Windows.Forms.ToolStripButton()
        Me.lblRecActual = New System.Windows.Forms.Label()
        Me.lblLocalizar = New System.Windows.Forms.Label()
        Me.txtLocalizar = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.cbSeccion = New System.Windows.Forms.ComboBox()
        Me.cbDepartamento = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tsVCR.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.btnImprimir, Me.btnExcel, Me.ToolStripSeparator2, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(855, 25)
        Me.ToolStrip1.TabIndex = 35
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AutoSize = False
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 22)
        Me.btnLimpiar.Text = "&Limpiar"
        '
        'btnImprimir
        '
        Me.btnImprimir.AutoSize = False
        Me.btnImprimir.Enabled = False
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.pbProceso)
        Me.GroupBox1.Controls.Add(Me.pctLocalizar)
        Me.GroupBox1.Controls.Add(Me.lblMensage)
        Me.GroupBox1.Controls.Add(Me.tsVCR)
        Me.GroupBox1.Controls.Add(Me.lblRecActual)
        Me.GroupBox1.Controls.Add(Me.lblLocalizar)
        Me.GroupBox1.Controls.Add(Me.txtLocalizar)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 483)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(848, 40)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'pbProceso
        '
        Me.pbProceso.Location = New System.Drawing.Point(278, 11)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.Size = New System.Drawing.Size(361, 23)
        Me.pbProceso.TabIndex = 27
        '
        'pctLocalizar
        '
        Me.pctLocalizar.AllowDrop = True
        Me.pctLocalizar.Image = CType(resources.GetObject("pctLocalizar.Image"), System.Drawing.Image)
        Me.pctLocalizar.Location = New System.Drawing.Point(241, 11)
        Me.pctLocalizar.Name = "pctLocalizar"
        Me.pctLocalizar.Size = New System.Drawing.Size(31, 22)
        Me.pctLocalizar.TabIndex = 26
        Me.pctLocalizar.UseVisualStyleBackColor = True
        '
        'lblMensage
        '
        Me.lblMensage.BackColor = System.Drawing.Color.Transparent
        Me.lblMensage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMensage.Location = New System.Drawing.Point(278, 14)
        Me.lblMensage.Name = "lblMensage"
        Me.lblMensage.Size = New System.Drawing.Size(361, 19)
        Me.lblMensage.TabIndex = 20
        '
        'tsVCR
        '
        Me.tsVCR.BackColor = System.Drawing.Color.Transparent
        Me.tsVCR.Dock = System.Windows.Forms.DockStyle.None
        Me.tsVCR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator7, Me.tsbPrimero, Me.tsbAnterior, Me.ToolStripSeparator8, Me.tsbSiguiente, Me.tsbUltimo})
        Me.tsVCR.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsVCR.Location = New System.Drawing.Point(642, 11)
        Me.tsVCR.Name = "tsVCR"
        Me.tsVCR.Size = New System.Drawing.Size(105, 23)
        Me.tsVCR.TabIndex = 7
        Me.tsVCR.Text = "ToolStrip2"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
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
        Me.lblRecActual.Location = New System.Drawing.Point(736, 16)
        Me.lblRecActual.Name = "lblRecActual"
        Me.lblRecActual.Size = New System.Drawing.Size(112, 13)
        Me.lblRecActual.TabIndex = 5
        Me.lblRecActual.Text = "Registro #000/999"
        Me.lblRecActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLocalizar
        '
        Me.lblLocalizar.AutoSize = True
        Me.lblLocalizar.Location = New System.Drawing.Point(3, 16)
        Me.lblLocalizar.Name = "lblLocalizar"
        Me.lblLocalizar.Size = New System.Drawing.Size(52, 13)
        Me.lblLocalizar.TabIndex = 3
        Me.lblLocalizar.Text = "Localizar:"
        '
        'txtLocalizar
        '
        Me.txtLocalizar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocalizar.Location = New System.Drawing.Point(58, 12)
        Me.txtLocalizar.Name = "txtLocalizar"
        Me.txtLocalizar.Size = New System.Drawing.Size(177, 20)
        Me.txtLocalizar.TabIndex = 4
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
        Me.DataGridView1.Location = New System.Drawing.Point(2, 176)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(851, 305)
        Me.DataGridView1.TabIndex = 37
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(379, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 22)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Filtrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cbEstado)
        Me.TabPage1.Controls.Add(Me.cbSeccion)
        Me.TabPage1.Controls.Add(Me.cbDepartamento)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(843, 86)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "FILTROS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(11, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Sección:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(11, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Departamento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(11, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Estado:"
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Items.AddRange(New Object() {"", "AUSENTE", "LIBRE", "PRESENTE"})
        Me.cbEstado.Location = New System.Drawing.Point(100, 8)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(268, 21)
        Me.cbEstado.TabIndex = 45
        '
        'cbSeccion
        '
        Me.cbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSeccion.FormattingEnabled = True
        Me.cbSeccion.Location = New System.Drawing.Point(100, 58)
        Me.cbSeccion.Name = "cbSeccion"
        Me.cbSeccion.Size = New System.Drawing.Size(268, 21)
        Me.cbSeccion.TabIndex = 44
        '
        'cbDepartamento
        '
        Me.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartamento.FormattingEnabled = True
        Me.cbDepartamento.Location = New System.Drawing.Point(100, 33)
        Me.cbDepartamento.Name = "cbDepartamento"
        Me.cbDepartamento.Size = New System.Drawing.Size(268, 21)
        Me.cbDepartamento.TabIndex = 43
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(2, 59)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(851, 112)
        Me.TabControl1.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(219, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(17, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Desde:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(385, 32)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(73, 22)
        Me.btnGenerar.TabIndex = 52
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'dtpFinal
        '
        Me.dtpFinal.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFinal.Location = New System.Drawing.Point(263, 34)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(111, 20)
        Me.dtpFinal.TabIndex = 54
        '
        'dtpInicio
        '
        Me.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(79, 34)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(111, 20)
        Me.dtpInicio.TabIndex = 53
        '
        'frmConsultaMarcasDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(855, 529)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaMarcasDia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSULTA DE MARCAS DEL DÍA"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsVCR.ResumeLayout(False)
        Me.tsVCR.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pctLocalizar As System.Windows.Forms.Button
    Friend WithEvents lblMensage As System.Windows.Forms.Label
    Friend WithEvents tsVCR As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblRecActual As System.Windows.Forms.Label
    Friend WithEvents lblLocalizar As System.Windows.Forms.Label
    Friend WithEvents txtLocalizar As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents pbProceso As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents cbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
End Class
