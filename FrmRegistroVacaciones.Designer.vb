<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroVacaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroVacaciones))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnAplicar = New System.Windows.Forms.ToolStripButton()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.BtnFiltar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAplicar, Me.btnLimpiar, Me.ToolStripSeparator5, Me.btnImprimir, Me.btnExcel, Me.BtnFiltar, Me.ToolStripSeparator2, Me.btnSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(664, 25)
        Me.tsMenu.TabIndex = 48
        Me.tsMenu.Text = "ToolStrip1"
        '
        'btnAplicar
        '
        Me.btnAplicar.AutoSize = False
        Me.btnAplicar.Image = CType(resources.GetObject("btnAplicar.Image"), System.Drawing.Image)
        Me.btnAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(75, 22)
        Me.btnAplicar.Text = "Consultar"
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
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._picture = "P:\Iconos\kedit.ico"
        Me._titulo1._text = "REGISTRO DE VACACIONES"
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(0, 28)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(669, 55)
        Me._titulo1.TabIndex = 49
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Blue
        Me.lblNombre.Location = New System.Drawing.Point(12, 86)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(50, 13)
        Me.lblNombre.TabIndex = 56
        Me.lblNombre.Text = "Nombre :"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(65, 82)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(293, 20)
        Me.txtNombre.TabIndex = 55
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(557, 82)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtpFinal.TabIndex = 60
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(412, 82)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(95, 20)
        Me.dtpInicio.TabIndex = 59
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(523, 86)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(32, 13)
        Me.lblFin.TabIndex = 58
        Me.lblFin.Text = "Final:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(374, 86)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblInicio.TabIndex = 57
        Me.lblInicio.Text = "Inicio:"
        '
        'FrmRegistroVacaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 122)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.lblFin)
        Me.Controls.Add(Me.lblInicio)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "FrmRegistroVacaciones"
        Me.Text = "FrmRegistroVacaciones"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnFiltar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
End Class
