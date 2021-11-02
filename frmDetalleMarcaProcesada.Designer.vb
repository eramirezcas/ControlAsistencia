<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleMarcaProcesada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleMarcaProcesada))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbGuardar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtMarcaEntrada = New System.Windows.Forms.TextBox()
        Me.txtHoraEntra = New System.Windows.Forms.TextBox()
        Me.txtHorasRebajar = New System.Windows.Forms.TextBox()
        Me.txtSalida = New System.Windows.Forms.TextBox()
        Me.txtFechaCal = New System.Windows.Forms.TextBox()
        Me.pcbFoto = New System.Windows.Forms.PictureBox()
        Me.txtDetalle1 = New System.Windows.Forms.TextBox()
        Me.txtDetalle2 = New System.Windows.Forms.TextBox()
        Me.txtJustificacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkAplicado = New System.Windows.Forms.CheckBox()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir, Me.tsbGuardar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(456, 25)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSalir
        '
        Me.tsbSalir.AutoSize = False
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsbSalir.Size = New System.Drawing.Size(65, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbGuardar
        '
        Me.tsbGuardar.Image = CType(resources.GetObject("tsbGuardar.Image"), System.Drawing.Image)
        Me.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGuardar.Name = "tsbGuardar"
        Me.tsbGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsbGuardar.Size = New System.Drawing.Size(66, 22)
        Me.tsbGuardar.Text = "&Guardar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Marca Entrada:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Hora entra:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(121, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nombre:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Salida:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Horas rebajar:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Fecha calendario:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(63, 74)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(52, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(174, 74)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(262, 20)
        Me.txtNombre.TabIndex = 1
        '
        'txtMarcaEntrada
        '
        Me.txtMarcaEntrada.Enabled = False
        Me.txtMarcaEntrada.Location = New System.Drawing.Point(112, 109)
        Me.txtMarcaEntrada.Name = "txtMarcaEntrada"
        Me.txtMarcaEntrada.Size = New System.Drawing.Size(140, 20)
        Me.txtMarcaEntrada.TabIndex = 2
        Me.txtMarcaEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHoraEntra
        '
        Me.txtHoraEntra.Enabled = False
        Me.txtHoraEntra.Location = New System.Drawing.Point(112, 135)
        Me.txtHoraEntra.Name = "txtHoraEntra"
        Me.txtHoraEntra.Size = New System.Drawing.Size(140, 20)
        Me.txtHoraEntra.TabIndex = 4
        Me.txtHoraEntra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHorasRebajar
        '
        Me.txtHorasRebajar.Enabled = False
        Me.txtHorasRebajar.Location = New System.Drawing.Point(112, 161)
        Me.txtHorasRebajar.Name = "txtHorasRebajar"
        Me.txtHorasRebajar.Size = New System.Drawing.Size(140, 20)
        Me.txtHorasRebajar.TabIndex = 5
        Me.txtHorasRebajar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalida
        '
        Me.txtSalida.Enabled = False
        Me.txtSalida.Location = New System.Drawing.Point(112, 187)
        Me.txtSalida.Name = "txtSalida"
        Me.txtSalida.Size = New System.Drawing.Size(140, 20)
        Me.txtSalida.TabIndex = 7
        Me.txtSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaCal
        '
        Me.txtFechaCal.Enabled = False
        Me.txtFechaCal.Location = New System.Drawing.Point(112, 213)
        Me.txtFechaCal.Name = "txtFechaCal"
        Me.txtFechaCal.Size = New System.Drawing.Size(140, 20)
        Me.txtFechaCal.TabIndex = 9
        Me.txtFechaCal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pcbFoto
        '
        Me.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pcbFoto.Location = New System.Drawing.Point(376, 213)
        Me.pcbFoto.Name = "pcbFoto"
        Me.pcbFoto.Size = New System.Drawing.Size(60, 72)
        Me.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbFoto.TabIndex = 20
        Me.pcbFoto.TabStop = False
        '
        'txtDetalle1
        '
        Me.txtDetalle1.Enabled = False
        Me.txtDetalle1.Location = New System.Drawing.Point(256, 109)
        Me.txtDetalle1.Name = "txtDetalle1"
        Me.txtDetalle1.Size = New System.Drawing.Size(180, 20)
        Me.txtDetalle1.TabIndex = 3
        '
        'txtDetalle2
        '
        Me.txtDetalle2.Enabled = False
        Me.txtDetalle2.Location = New System.Drawing.Point(256, 187)
        Me.txtDetalle2.Name = "txtDetalle2"
        Me.txtDetalle2.Size = New System.Drawing.Size(180, 20)
        Me.txtDetalle2.TabIndex = 8
        '
        'txtJustificacion
        '
        Me.txtJustificacion.Enabled = False
        Me.txtJustificacion.Location = New System.Drawing.Point(112, 239)
        Me.txtJustificacion.Multiline = True
        Me.txtJustificacion.Name = "txtJustificacion"
        Me.txtJustificacion.Size = New System.Drawing.Size(252, 46)
        Me.txtJustificacion.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Justificación:"
        '
        'chkAplicado
        '
        Me.chkAplicado.AutoSize = True
        Me.chkAplicado.Enabled = False
        Me.chkAplicado.Location = New System.Drawing.Point(256, 163)
        Me.chkAplicado.Name = "chkAplicado"
        Me.chkAplicado.Size = New System.Drawing.Size(103, 17)
        Me.chkAplicado.TabIndex = 6
        Me.chkAplicado.Text = "Rebajo aplicado"
        Me.chkAplicado.UseVisualStyleBackColor = True
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "DETALLE DE MARCAS PROCESADAS"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(457, 34)
        Me._titulo1.TabIndex = 2
        '
        'frmDetalleMarcaProcesada
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(456, 296)
        Me.Controls.Add(Me.chkAplicado)
        Me.Controls.Add(Me.txtJustificacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDetalle2)
        Me.Controls.Add(Me.txtDetalle1)
        Me.Controls.Add(Me.pcbFoto)
        Me.Controls.Add(Me.txtFechaCal)
        Me.Controls.Add(Me.txtSalida)
        Me.Controls.Add(Me.txtHorasRebajar)
        Me.Controls.Add(Me.txtHoraEntra)
        Me.Controls.Add(Me.txtMarcaEntrada)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetalleMarcaProcesada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLE DE MARCAS PROCESADAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtMarcaEntrada As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraEntra As System.Windows.Forms.TextBox
    Friend WithEvents txtHorasRebajar As System.Windows.Forms.TextBox
    Friend WithEvents txtSalida As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaCal As System.Windows.Forms.TextBox
    Friend WithEvents pcbFoto As System.Windows.Forms.PictureBox
    Friend WithEvents txtDetalle1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDetalle2 As System.Windows.Forms.TextBox
    Friend WithEvents txtJustificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAplicado As System.Windows.Forms.CheckBox
    Friend WithEvents tsbGuardar As System.Windows.Forms.ToolStripButton
End Class
