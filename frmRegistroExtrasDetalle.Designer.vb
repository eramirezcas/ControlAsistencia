<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroExtrasDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroExtrasDetalle))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnDescartar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNDocumento = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.lblEstadoMarca = New System.Windows.Forms.Label()
        Me.txtDifEntra = New System.Windows.Forms.TextBox()
        Me.txtDifSale = New System.Windows.Forms.TextBox()
        Me.txtHorEntra = New System.Windows.Forms.TextBox()
        Me.txtHorSale = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMontoHoras = New System.Windows.Forms.TextBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtMontoPendiente = New System.Windows.Forms.TextBox()
        Me.txtMontoPresupuesto = New System.Windows.Forms.TextBox()
        Me.txtMontoCuentaCosto = New System.Windows.Forms.TextBox()
        Me.txtCuentaPresupuesto = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCuentaCosto = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtJustificacionAutomatica = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEstatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtHorasFeriado = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtHorasDobles = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtEmpid = New System.Windows.Forms.TextBox()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.txtHorasTiempoyMedio = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtSalarioHora = New System.Windows.Forms.TextBox()
        Me.txtHorasSencillas = New System.Windows.Forms.TextBox()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtSeccion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtMarcaEntrada = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMarcaSalida = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRechGere = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRechRRHH = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRechPlani = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDescartar, Me.btnGuardar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsMenu.Size = New System.Drawing.Size(518, 25)
        Me.tsMenu.TabIndex = 18
        Me.tsMenu.Text = "ToolStrip1"
        '
        'btnDescartar
        '
        Me.btnDescartar.AutoSize = False
        Me.btnDescartar.Image = CType(resources.GetObject("btnDescartar.Image"), System.Drawing.Image)
        Me.btnDescartar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDescartar.Size = New System.Drawing.Size(75, 22)
        Me.btnDescartar.Text = "&Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.AutoSize = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnGuardar.Size = New System.Drawing.Size(75, 22)
        Me.btnGuardar.Text = "&Guardar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(287, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Documento #:"
        '
        'txtNDocumento
        '
        Me.txtNDocumento.Enabled = False
        Me.txtNDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNDocumento.ForeColor = System.Drawing.Color.Brown
        Me.txtNDocumento.Location = New System.Drawing.Point(372, 6)
        Me.txtNDocumento.Name = "txtNDocumento"
        Me.txtNDocumento.Size = New System.Drawing.Size(137, 21)
        Me.txtNDocumento.TabIndex = 3
        Me.txtNDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(-3, 28)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(525, 480)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.lblHistoria)
        Me.TabPage1.Controls.Add(Me.lblEstadoMarca)
        Me.TabPage1.Controls.Add(Me.txtDifEntra)
        Me.TabPage1.Controls.Add(Me.txtDifSale)
        Me.TabPage1.Controls.Add(Me.txtHorEntra)
        Me.TabPage1.Controls.Add(Me.txtHorSale)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtMontoHoras)
        Me.TabPage1.Controls.Add(Me.dtFecha)
        Me.TabPage1.Controls.Add(Me.txtNDocumento)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.txtTotal)
        Me.TabPage1.Controls.Add(Me.txtMontoPendiente)
        Me.TabPage1.Controls.Add(Me.txtMontoPresupuesto)
        Me.TabPage1.Controls.Add(Me.txtMontoCuentaCosto)
        Me.TabPage1.Controls.Add(Me.txtCuentaPresupuesto)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.txtCuentaCosto)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.txtJustificacionAutomatica)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtEstatus)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtHorasFeriado)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtHorasDobles)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.txtEmpid)
        Me.TabPage1.Controls.Add(Me.txtMotivo)
        Me.TabPage1.Controls.Add(Me.txtHorasTiempoyMedio)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.txtNombre)
        Me.TabPage1.Controls.Add(Me.txtSalarioHora)
        Me.TabPage1.Controls.Add(Me.txtHorasSencillas)
        Me.TabPage1.Controls.Add(Me.txtDepartamento)
        Me.TabPage1.Controls.Add(Me.txtSeccion)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.btnCargar)
        Me.TabPage1.Controls.Add(Me.txtMarcaEntrada)
        Me.TabPage1.Controls.Add(Me.btnBuscar)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtMarcaSalida)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(517, 454)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DATOS DE REGISTRO DE HORAS EXTRA"
        '
        'lblHistoria
        '
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.ForeColor = System.Drawing.Color.Blue
        Me.lblHistoria.Image = CType(resources.GetObject("lblHistoria.Image"), System.Drawing.Image)
        Me.lblHistoria.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblHistoria.Location = New System.Drawing.Point(428, 397)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(81, 48)
        Me.lblHistoria.TabIndex = 95
        Me.lblHistoria.Text = "Ver Historia del Documento"
        Me.lblHistoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblEstadoMarca
        '
        Me.lblEstadoMarca.AutoSize = True
        Me.lblEstadoMarca.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.lblEstadoMarca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEstadoMarca.ForeColor = System.Drawing.Color.Red
        Me.lblEstadoMarca.Location = New System.Drawing.Point(219, 101)
        Me.lblEstadoMarca.Name = "lblEstadoMarca"
        Me.lblEstadoMarca.Size = New System.Drawing.Size(47, 15)
        Me.lblEstadoMarca.TabIndex = 85
        Me.lblEstadoMarca.Text = "Label11"
        Me.lblEstadoMarca.Visible = False
        '
        'txtDifEntra
        '
        Me.txtDifEntra.Enabled = False
        Me.txtDifEntra.Location = New System.Drawing.Point(361, 129)
        Me.txtDifEntra.Name = "txtDifEntra"
        Me.txtDifEntra.Size = New System.Drawing.Size(63, 20)
        Me.txtDifEntra.TabIndex = 83
        '
        'txtDifSale
        '
        Me.txtDifSale.Enabled = False
        Me.txtDifSale.Location = New System.Drawing.Point(361, 158)
        Me.txtDifSale.Name = "txtDifSale"
        Me.txtDifSale.Size = New System.Drawing.Size(63, 20)
        Me.txtDifSale.TabIndex = 84
        '
        'txtHorEntra
        '
        Me.txtHorEntra.Enabled = False
        Me.txtHorEntra.Location = New System.Drawing.Point(226, 129)
        Me.txtHorEntra.Name = "txtHorEntra"
        Me.txtHorEntra.Size = New System.Drawing.Size(133, 20)
        Me.txtHorEntra.TabIndex = 81
        '
        'txtHorSale
        '
        Me.txtHorSale.Enabled = False
        Me.txtHorSale.Location = New System.Drawing.Point(226, 158)
        Me.txtHorSale.Name = "txtHorSale"
        Me.txtHorSale.Size = New System.Drawing.Size(133, 20)
        Me.txtHorSale.TabIndex = 82
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(454, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Monto:"
        '
        'txtMontoHoras
        '
        Me.txtMontoHoras.Enabled = False
        Me.txtMontoHoras.Location = New System.Drawing.Point(439, 205)
        Me.txtMontoHoras.Name = "txtMontoHoras"
        Me.txtMontoHoras.Size = New System.Drawing.Size(70, 20)
        Me.txtMontoHoras.TabIndex = 79
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(90, 97)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(87, 20)
        Me.dtFecha.TabIndex = 78
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Blue
        Me.Label27.Location = New System.Drawing.Point(372, 339)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(12, 15)
        Me.Label27.TabIndex = 75
        Me.Label27.Text = "-"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Blue
        Me.Label29.Location = New System.Drawing.Point(372, 397)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(12, 15)
        Me.Label29.TabIndex = 77
        Me.Label29.Text = "-"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(369, 368)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(15, 15)
        Me.Label28.TabIndex = 76
        Me.Label28.Text = "+"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(293, 322)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 13)
        Me.Label23.TabIndex = 74
        Me.Label23.Text = "Montos"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(8, 428)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 13)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "TOTAL:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(8, 399)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(139, 13)
        Me.Label21.TabIndex = 72
        Me.Label21.Text = "Monto pendiente de aplicar:"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(273, 425)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(93, 20)
        Me.txtTotal.TabIndex = 71
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoPendiente
        '
        Me.txtMontoPendiente.Enabled = False
        Me.txtMontoPendiente.Location = New System.Drawing.Point(273, 396)
        Me.txtMontoPendiente.Name = "txtMontoPendiente"
        Me.txtMontoPendiente.Size = New System.Drawing.Size(93, 20)
        Me.txtMontoPendiente.TabIndex = 70
        Me.txtMontoPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoPresupuesto
        '
        Me.txtMontoPresupuesto.Enabled = False
        Me.txtMontoPresupuesto.Location = New System.Drawing.Point(273, 367)
        Me.txtMontoPresupuesto.Name = "txtMontoPresupuesto"
        Me.txtMontoPresupuesto.Size = New System.Drawing.Size(93, 20)
        Me.txtMontoPresupuesto.TabIndex = 69
        '
        'txtMontoCuentaCosto
        '
        Me.txtMontoCuentaCosto.Enabled = False
        Me.txtMontoCuentaCosto.Location = New System.Drawing.Point(273, 338)
        Me.txtMontoCuentaCosto.Name = "txtMontoCuentaCosto"
        Me.txtMontoCuentaCosto.Size = New System.Drawing.Size(93, 20)
        Me.txtMontoCuentaCosto.TabIndex = 65
        '
        'txtCuentaPresupuesto
        '
        Me.txtCuentaPresupuesto.Enabled = False
        Me.txtCuentaPresupuesto.Location = New System.Drawing.Point(89, 367)
        Me.txtCuentaPresupuesto.MaxLength = 15
        Me.txtCuentaPresupuesto.Name = "txtCuentaPresupuesto"
        Me.txtCuentaPresupuesto.Size = New System.Drawing.Size(178, 20)
        Me.txtCuentaPresupuesto.TabIndex = 66
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(8, 370)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 68
        Me.Label20.Text = "Cuenta presup:"
        '
        'txtCuentaCosto
        '
        Me.txtCuentaCosto.Enabled = False
        Me.txtCuentaCosto.Location = New System.Drawing.Point(89, 338)
        Me.txtCuentaCosto.MaxLength = 15
        Me.txtCuentaCosto.Name = "txtCuentaCosto"
        Me.txtCuentaCosto.Size = New System.Drawing.Size(178, 20)
        Me.txtCuentaCosto.TabIndex = 64
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(8, 341)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 67
        Me.Label19.Text = "Cuenta costo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(8, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Horas:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(8, 237)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(123, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Justificación automática:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(8, 161)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 13)
        Me.Label26.TabIndex = 44
        Me.Label26.Text = "Marca Salida:"
        '
        'txtJustificacionAutomatica
        '
        Me.txtJustificacionAutomatica.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.txtJustificacionAutomatica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJustificacionAutomatica.ForeColor = System.Drawing.Color.Red
        Me.txtJustificacionAutomatica.Location = New System.Drawing.Point(131, 234)
        Me.txtJustificacionAutomatica.Multiline = True
        Me.txtJustificacionAutomatica.Name = "txtJustificacionAutomatica"
        Me.txtJustificacionAutomatica.ReadOnly = True
        Me.txtJustificacionAutomatica.Size = New System.Drawing.Size(378, 20)
        Me.txtJustificacionAutomatica.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(367, 188)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Feriado:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(194, 188)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Extras"
        '
        'txtEstatus
        '
        Me.txtEstatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstatus.Enabled = False
        Me.txtEstatus.Location = New System.Drawing.Point(89, 292)
        Me.txtEstatus.Name = "txtEstatus"
        Me.txtEstatus.Size = New System.Drawing.Size(295, 20)
        Me.txtEstatus.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(98, 188)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Sencillas:"
        '
        'txtHorasFeriado
        '
        Me.txtHorasFeriado.Location = New System.Drawing.Point(354, 205)
        Me.txtHorasFeriado.Name = "txtHorasFeriado"
        Me.txtHorasFeriado.Size = New System.Drawing.Size(70, 20)
        Me.txtHorasFeriado.TabIndex = 13
        Me.txtHorasFeriado.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(280, 188)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Dobles:"
        '
        'txtHorasDobles
        '
        Me.txtHorasDobles.Location = New System.Drawing.Point(266, 205)
        Me.txtHorasDobles.Name = "txtHorasDobles"
        Me.txtHorasDobles.Size = New System.Drawing.Size(70, 20)
        Me.txtHorasDobles.TabIndex = 12
        Me.txtHorasDobles.Text = "0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(8, 295)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(45, 13)
        Me.Label25.TabIndex = 39
        Me.Label25.Text = "Estatus:"
        '
        'txtEmpid
        '
        Me.txtEmpid.Enabled = False
        Me.txtEmpid.Location = New System.Drawing.Point(90, 36)
        Me.txtEmpid.Name = "txtEmpid"
        Me.txtEmpid.Size = New System.Drawing.Size(57, 20)
        Me.txtEmpid.TabIndex = 1
        '
        'txtMotivo
        '
        Me.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotivo.Location = New System.Drawing.Point(89, 263)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(295, 20)
        Me.txtMotivo.TabIndex = 14
        '
        'txtHorasTiempoyMedio
        '
        Me.txtHorasTiempoyMedio.Location = New System.Drawing.Point(177, 205)
        Me.txtHorasTiempoyMedio.Name = "txtHorasTiempoyMedio"
        Me.txtHorasTiempoyMedio.Size = New System.Drawing.Size(70, 20)
        Me.txtHorasTiempoyMedio.TabIndex = 11
        Me.txtHorasTiempoyMedio.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(8, 266)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(42, 13)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = "Motivo:"
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(279, 36)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(230, 20)
        Me.txtNombre.TabIndex = 2
        '
        'txtSalarioHora
        '
        Me.txtSalarioHora.Enabled = False
        Me.txtSalarioHora.Location = New System.Drawing.Point(439, 98)
        Me.txtSalarioHora.Name = "txtSalarioHora"
        Me.txtSalarioHora.Size = New System.Drawing.Size(70, 20)
        Me.txtSalarioHora.TabIndex = 5
        '
        'txtHorasSencillas
        '
        Me.txtHorasSencillas.Location = New System.Drawing.Point(89, 205)
        Me.txtHorasSencillas.Name = "txtHorasSencillas"
        Me.txtHorasSencillas.Size = New System.Drawing.Size(70, 20)
        Me.txtHorasSencillas.TabIndex = 10
        Me.txtHorasSencillas.Text = "0"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Location = New System.Drawing.Point(90, 66)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(121, 20)
        Me.txtDepartamento.TabIndex = 3
        '
        'txtSeccion
        '
        Me.txtSeccion.Enabled = False
        Me.txtSeccion.Location = New System.Drawing.Point(278, 66)
        Me.txtSeccion.Name = "txtSeccion"
        Me.txtSeccion.Size = New System.Drawing.Size(231, 20)
        Me.txtSeccion.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(8, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Marca Entrada:"
        '
        'btnCargar
        '
        Me.btnCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.Location = New System.Drawing.Point(183, 96)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(30, 23)
        Me.btnCargar.TabIndex = 7
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtMarcaEntrada
        '
        Me.txtMarcaEntrada.Enabled = False
        Me.txtMarcaEntrada.Location = New System.Drawing.Point(90, 129)
        Me.txtMarcaEntrada.Name = "txtMarcaEntrada"
        Me.txtMarcaEntrada.Size = New System.Drawing.Size(133, 20)
        Me.txtMarcaEntrada.TabIndex = 8
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(153, 33)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 23)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "&Busc."
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(8, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(8, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Fecha:"
        '
        'txtMarcaSalida
        '
        Me.txtMarcaSalida.Enabled = False
        Me.txtMarcaSalida.Location = New System.Drawing.Point(90, 158)
        Me.txtMarcaSalida.Name = "txtMarcaSalida"
        Me.txtMarcaSalida.Size = New System.Drawing.Size(133, 20)
        Me.txtMarcaSalida.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(372, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Salario Hora:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(223, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Sección:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(226, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(8, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Departamento:"
        '
        'txtRechGere
        '
        Me.txtRechGere.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRechGere.Enabled = False
        Me.txtRechGere.Location = New System.Drawing.Point(132, 516)
        Me.txtRechGere.Name = "txtRechGere"
        Me.txtRechGere.Size = New System.Drawing.Size(378, 20)
        Me.txtRechGere.TabIndex = 38
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(9, 519)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Motivo rechazo gerencia:"
        '
        'txtRechRRHH
        '
        Me.txtRechRRHH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRechRRHH.Enabled = False
        Me.txtRechRRHH.Location = New System.Drawing.Point(132, 542)
        Me.txtRechRRHH.Name = "txtRechRRHH"
        Me.txtRechRRHH.Size = New System.Drawing.Size(378, 20)
        Me.txtRechRRHH.TabIndex = 40
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(9, 545)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Motivo rechazo RRHH:"
        '
        'txtRechPlani
        '
        Me.txtRechPlani.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRechPlani.Enabled = False
        Me.txtRechPlani.Location = New System.Drawing.Point(132, 568)
        Me.txtRechPlani.Name = "txtRechPlani"
        Me.txtRechPlani.Size = New System.Drawing.Size(378, 20)
        Me.txtRechPlani.TabIndex = 42
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(9, 571)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 13)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Motivo rechazo plainlla:"
        '
        'frmRegistroExtrasDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(518, 592)
        Me.Controls.Add(Me.txtRechPlani)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtRechRRHH)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtRechGere)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistroExtrasDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATOS DE REGISTRO DE HORAS EXTRA"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDescartar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNDocumento As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtJustificacionAutomatica As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEstatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtHorasFeriado As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtHorasDobles As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtEmpid As System.Windows.Forms.TextBox
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents txtHorasTiempoyMedio As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtSalarioHora As System.Windows.Forms.TextBox
    Friend WithEvents txtHorasSencillas As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtSeccion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents txtMarcaEntrada As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMarcaSalida As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoPendiente As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoCuentaCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMontoHoras As System.Windows.Forms.TextBox
    Friend WithEvents txtDifEntra As System.Windows.Forms.TextBox
    Friend WithEvents txtDifSale As System.Windows.Forms.TextBox
    Friend WithEvents txtHorEntra As System.Windows.Forms.TextBox
    Friend WithEvents txtHorSale As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoMarca As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents txtRechGere As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRechRRHH As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRechPlani As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
