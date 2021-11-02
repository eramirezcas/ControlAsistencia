<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJustificacionesAnte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJustificacionesAnte))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tsVCR = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrimero = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.tsbUltimo = New System.Windows.Forms.ToolStripButton()
        Me.lblRecActual = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cboNumPago = New System.Windows.Forms.ComboBox()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFInicial = New System.Windows.Forms.DateTimePicker()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tsVCR.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimir, Me.btnExcel, Me.ToolStripSeparator2, Me.btnSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(877, 25)
        Me.tsMenu.TabIndex = 41
        Me.tsMenu.Text = "ToolStrip1"
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
        Me.GroupBox1.Controls.Add(Me.tsVCR)
        Me.GroupBox1.Controls.Add(Me.lblRecActual)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 476)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(870, 36)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'tsVCR
        '
        Me.tsVCR.BackColor = System.Drawing.Color.Transparent
        Me.tsVCR.Dock = System.Windows.Forms.DockStyle.None
        Me.tsVCR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.tsbPrimero, Me.tsbAnterior, Me.ToolStripSeparator3, Me.tsbSiguiente, Me.tsbUltimo})
        Me.tsVCR.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsVCR.Location = New System.Drawing.Point(664, 8)
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
        Me.lblRecActual.Location = New System.Drawing.Point(749, 14)
        Me.lblRecActual.Name = "lblRecActual"
        Me.lblRecActual.Size = New System.Drawing.Size(117, 13)
        Me.lblRecActual.TabIndex = 5
        Me.lblRecActual.Text = "Registro #0/0"
        Me.lblRecActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblNombre)
        Me.GroupBox2.Controls.Add(Me.cboNumPago)
        Me.GroupBox2.Controls.Add(Me.chkTodos)
        Me.GroupBox2.Controls.Add(Me.txtNombre)
        Me.GroupBox2.Controls.Add(Me.dtpFFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFInicial)
        Me.GroupBox2.Controls.Add(Me.btnConsulta)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(386, 96)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Numero pago:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Periodo(Inicial/Final):"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Blue
        Me.lblNombre.Location = New System.Drawing.Point(8, 18)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 6
        Me.lblNombre.Text = "Nombre:"
        '
        'cboNumPago
        '
        Me.cboNumPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNumPago.FormattingEnabled = True
        Me.cboNumPago.Location = New System.Drawing.Point(115, 40)
        Me.cboNumPago.Name = "cboNumPago"
        Me.cboNumPago.Size = New System.Drawing.Size(204, 21)
        Me.cboNumPago.TabIndex = 5
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(325, 16)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(56, 17)
        Me.chkTodos.TabIndex = 4
        Me.chkTodos.Text = "Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(115, 14)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(204, 20)
        Me.txtNombre.TabIndex = 3
        '
        'dtpFFinal
        '
        Me.dtpFFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFinal.Location = New System.Drawing.Point(220, 67)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.Size = New System.Drawing.Size(99, 20)
        Me.dtpFFinal.TabIndex = 2
        '
        'dtpFInicial
        '
        Me.dtpFInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFInicial.Location = New System.Drawing.Point(115, 67)
        Me.dtpFInicial.Name = "dtpFInicial"
        Me.dtpFInicial.Size = New System.Drawing.Size(99, 20)
        Me.dtpFInicial.TabIndex = 1
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(325, 39)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(55, 23)
        Me.btnConsulta.TabIndex = 0
        Me.btnConsulta.Text = "Consultar"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 170)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(877, 305)
        Me.DataGridView1.TabIndex = 44
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "JUSTIFICACIONES HISTORICAS"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(878, 34)
        Me._titulo1.TabIndex = 40
        '
        'frmJustificacionesAnte
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(877, 517)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJustificacionesAnte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JUSTIFICACIONES HISTORICAS"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsVCR.ResumeLayout(False)
        Me.tsVCR.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tsVCR As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblRecActual As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents cboNumPago As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
End Class
