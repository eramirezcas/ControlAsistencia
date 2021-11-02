<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarCargadorAlimentacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerarCargadorAlimentacion))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblMensage = New System.Windows.Forms.Label()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnExportaexcel = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRecActual = New System.Windows.Forms.Label()
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
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tsVCR.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(-1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(637, 32)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = " GENERAR CARGOS POR SERVICO DE ALIMENTACIÓN"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.lblMensage)
        Me.Panel1.Location = New System.Drawing.Point(0, 431)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(636, 37)
        Me.Panel1.TabIndex = 127
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(556, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = " Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'lblMensage
        '
        Me.lblMensage.BackColor = System.Drawing.Color.Transparent
        Me.lblMensage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMensage.Location = New System.Drawing.Point(6, 8)
        Me.lblMensage.Name = "lblMensage"
        Me.lblMensage.Size = New System.Drawing.Size(544, 19)
        Me.lblMensage.TabIndex = 137
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(69, 37)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(66, 23)
        Me.btnImportar.TabIndex = 1
        Me.btnImportar.Text = " Importar"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'btnExportaexcel
        '
        Me.btnExportaexcel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnExportaexcel.Image = CType(resources.GetObject("btnExportaexcel.Image"), System.Drawing.Image)
        Me.btnExportaexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaexcel.Location = New System.Drawing.Point(137, 37)
        Me.btnExportaexcel.Name = "btnExportaexcel"
        Me.btnExportaexcel.Size = New System.Drawing.Size(55, 23)
        Me.btnExportaexcel.TabIndex = 130
        Me.btnExportaexcel.Text = "Excel"
        Me.btnExportaexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportaexcel.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(317, 37)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(66, 23)
        Me.btnLimpiar.TabIndex = 131
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnCargar
        '
        Me.btnCargar.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(6, 37)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(61, 23)
        Me.btnCargar.TabIndex = 132
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargar.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 66)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(625, 318)
        Me.DataGridView1.TabIndex = 133
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(389, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 23)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Nómina no inicializada"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(251, 37)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(63, 23)
        Me.btnRefresh.TabIndex = 135
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRecActual)
        Me.GroupBox1.Controls.Add(Me.btnLocalizar)
        Me.GroupBox1.Controls.Add(Me.tsVCR)
        Me.GroupBox1.Controls.Add(Me.lblLocalizar)
        Me.GroupBox1.Controls.Add(Me.txtLocalizar)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 390)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(625, 37)
        Me.GroupBox1.TabIndex = 138
        Me.GroupBox1.TabStop = False
        '
        'lblRecActual
        '
        Me.lblRecActual.Location = New System.Drawing.Point(501, 14)
        Me.lblRecActual.Name = "lblRecActual"
        Me.lblRecActual.Size = New System.Drawing.Size(117, 13)
        Me.lblRecActual.TabIndex = 137
        Me.lblRecActual.Text = "Registro #000/999"
        Me.lblRecActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLocalizar
        '
        Me.btnLocalizar.Image = CType(resources.GetObject("btnLocalizar.Image"), System.Drawing.Image)
        Me.btnLocalizar.Location = New System.Drawing.Point(370, 9)
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
        Me.tsVCR.Location = New System.Drawing.Point(404, 9)
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
        Me.lblLocalizar.Location = New System.Drawing.Point(6, 14)
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
        Me.txtLocalizar.Size = New System.Drawing.Size(306, 20)
        Me.txtLocalizar.TabIndex = 4
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnVerDetalle.Image = CType(resources.GetObject("btnVerDetalle.Image"), System.Drawing.Image)
        Me.btnVerDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerDetalle.Location = New System.Drawing.Point(194, 37)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(55, 23)
        Me.btnVerDetalle.TabIndex = 139
        Me.btnVerDetalle.Text = " Detal."
        Me.btnVerDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerDetalle.UseVisualStyleBackColor = False
        '
        'frmGenerarCargadorAlimentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(636, 467)
        Me.Controls.Add(Me.btnVerDetalle)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnExportaexcel)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerarCargadorAlimentacion"
        Me.Text = "GENERAR ARCHIVO DE CARGA "
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsVCR.ResumeLayout(False)
        Me.tsVCR.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnExportaexcel As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
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
    Friend WithEvents lblRecActual As System.Windows.Forms.Label
    Friend WithEvents btnVerDetalle As System.Windows.Forms.Button
End Class
