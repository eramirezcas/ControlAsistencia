<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoCaps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoCaps))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.btnAnular = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblRecActual = New System.Windows.Forms.Label()
        Me.lblMensage = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLocalizar = New System.Windows.Forms.Button()
        Me.tsVCR = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrimero = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.tsbUltimo = New System.Windows.Forms.ToolStripButton()
        Me.lblLocalizar = New System.Windows.Forms.Label()
        Me.txtLocalizar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tsVCR.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnEditar, Me.btnAnular, Me.btnImprimir, Me.ToolStripSeparator1, Me.btnExcel, Me.ToolStripSeparator2, Me.btnSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(627, 25)
        Me.tsMenu.TabIndex = 48
        Me.tsMenu.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.AutoSize = False
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 22)
        Me.btnNuevo.Text = "&Nuevo"
        '
        'btnEditar
        '
        Me.btnEditar.AutoSize = False
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 22)
        Me.btnEditar.Text = "&Editar"
        '
        'btnAnular
        '
        Me.btnAnular.AutoSize = False
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(75, 22)
        Me.btnAnular.Text = "&Anular"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnExcel
        '
        Me.btnExcel.AutoSize = False
        Me.btnExcel.Enabled = False
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
        'lblRecActual
        '
        Me.lblRecActual.Location = New System.Drawing.Point(471, 375)
        Me.lblRecActual.Name = "lblRecActual"
        Me.lblRecActual.Size = New System.Drawing.Size(117, 13)
        Me.lblRecActual.TabIndex = 46
        Me.lblRecActual.Text = "Registro #000/999"
        Me.lblRecActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMensage
        '
        Me.lblMensage.BackColor = System.Drawing.Color.Transparent
        Me.lblMensage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMensage.Location = New System.Drawing.Point(1, 369)
        Me.lblMensage.Name = "lblMensage"
        Me.lblMensage.Size = New System.Drawing.Size(485, 19)
        Me.lblMensage.TabIndex = 47
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnLocalizar)
        Me.GroupBox1.Controls.Add(Me.tsVCR)
        Me.GroupBox1.Controls.Add(Me.lblLocalizar)
        Me.GroupBox1.Controls.Add(Me.txtLocalizar)
        Me.GroupBox1.Location = New System.Drawing.Point(-4, 335)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 37)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        '
        'btnLocalizar
        '
        Me.btnLocalizar.Image = CType(resources.GetObject("btnLocalizar.Image"), System.Drawing.Image)
        Me.btnLocalizar.Location = New System.Drawing.Point(377, 9)
        Me.btnLocalizar.Name = "btnLocalizar"
        Me.btnLocalizar.Size = New System.Drawing.Size(31, 22)
        Me.btnLocalizar.TabIndex = 25
        Me.btnLocalizar.UseVisualStyleBackColor = True
        '
        'tsVCR
        '
        Me.tsVCR.BackColor = System.Drawing.Color.Transparent
        Me.tsVCR.Dock = System.Windows.Forms.DockStyle.None
        Me.tsVCR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.tsbPrimero, Me.tsbAnterior, Me.ToolStripSeparator3, Me.tsbSiguiente, Me.tsbUltimo})
        Me.tsVCR.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsVCR.Location = New System.Drawing.Point(487, 9)
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
        'lblLocalizar
        '
        Me.lblLocalizar.AutoSize = True
        Me.lblLocalizar.Location = New System.Drawing.Point(3, 14)
        Me.lblLocalizar.Name = "lblLocalizar"
        Me.lblLocalizar.Size = New System.Drawing.Size(52, 13)
        Me.lblLocalizar.TabIndex = 3
        Me.lblLocalizar.Text = "Localizar:"
        '
        'txtLocalizar
        '
        Me.txtLocalizar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocalizar.Location = New System.Drawing.Point(58, 10)
        Me.txtLocalizar.Name = "txtLocalizar"
        Me.txtLocalizar.Size = New System.Drawing.Size(313, 20)
        Me.txtLocalizar.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(627, 32)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = " MATENIMIENTO DE SERVICIO DE ALIMETACIÓN TEMPORAL"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(6, 66)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(616, 269)
        Me.DataGridView1.TabIndex = 50
        '
        'frmMantenimientoCaps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(627, 390)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.lblRecActual)
        Me.Controls.Add(Me.lblMensage)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMantenimientoCaps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MATENIMIENTO DE SERVICIO DE ALIMETACIÓN TEMPORAL"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsVCR.ResumeLayout(False)
        Me.tsVCR.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblRecActual As System.Windows.Forms.Label
    Friend WithEvents lblMensage As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLocalizar As System.Windows.Forms.Button
    Friend WithEvents tsVCR As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblLocalizar As System.Windows.Forms.Label
    Friend WithEvents txtLocalizar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
