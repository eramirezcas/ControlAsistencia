<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRabajos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRabajos))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLocalizar = New System.Windows.Forms.Button()
        Me.lblMensage = New System.Windows.Forms.Label()
        Me.tsVCR = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrimero = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.tsbUltimo = New System.Windows.Forms.ToolStripButton()
        Me.lblRecActual = New System.Windows.Forms.Label()
        Me.txtLocalizar = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.GroupBox2.SuspendLayout()
        Me.tsVCR.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLocalizar)
        Me.GroupBox2.Controls.Add(Me.lblMensage)
        Me.GroupBox2.Controls.Add(Me.tsVCR)
        Me.GroupBox2.Controls.Add(Me.lblRecActual)
        Me.GroupBox2.Controls.Add(Me.txtLocalizar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 439)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(684, 38)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'btnLocalizar
        '
        Me.btnLocalizar.Image = Global.WindowsApplication1.My.Resources.Resources.print_preview_icon
        Me.btnLocalizar.Location = New System.Drawing.Point(216, 10)
        Me.btnLocalizar.Name = "btnLocalizar"
        Me.btnLocalizar.Size = New System.Drawing.Size(31, 22)
        Me.btnLocalizar.TabIndex = 24
        Me.btnLocalizar.UseVisualStyleBackColor = True
        '
        'lblMensage
        '
        Me.lblMensage.Location = New System.Drawing.Point(251, 15)
        Me.lblMensage.Name = "lblMensage"
        Me.lblMensage.Size = New System.Drawing.Size(188, 13)
        Me.lblMensage.TabIndex = 23
        Me.lblMensage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tsVCR
        '
        Me.tsVCR.BackColor = System.Drawing.Color.Transparent
        Me.tsVCR.Dock = System.Windows.Forms.DockStyle.None
        Me.tsVCR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.tsbPrimero, Me.tsbAnterior, Me.ToolStripSeparator3, Me.tsbSiguiente, Me.tsbUltimo})
        Me.tsVCR.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsVCR.Location = New System.Drawing.Point(447, 10)
        Me.tsVCR.Name = "tsVCR"
        Me.tsVCR.Size = New System.Drawing.Size(105, 23)
        Me.tsVCR.TabIndex = 22
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
        Me.lblRecActual.BackColor = System.Drawing.Color.Transparent
        Me.lblRecActual.Location = New System.Drawing.Point(562, 15)
        Me.lblRecActual.Name = "lblRecActual"
        Me.lblRecActual.Size = New System.Drawing.Size(117, 13)
        Me.lblRecActual.TabIndex = 21
        Me.lblRecActual.Text = "Registro #000/999"
        Me.lblRecActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLocalizar
        '
        Me.txtLocalizar.Location = New System.Drawing.Point(61, 12)
        Me.txtLocalizar.Name = "txtLocalizar"
        Me.txtLocalizar.Size = New System.Drawing.Size(151, 20)
        Me.txtLocalizar.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Localizar:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbExcel, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(688, 25)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton1.Text = "C&orreo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(69, 22)
        Me.tsbSalir.Text = "&Cancelar"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 73)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(688, 364)
        Me.DataGridView1.TabIndex = 24
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "GENERAR REBAJO DE HORAS"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(689, 34)
        Me._titulo1.TabIndex = 21
        '
        'frmRabajos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 479)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRabajos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GENERAR REBAJO DE HORAS"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tsVCR.ResumeLayout(False)
        Me.tsVCR.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLocalizar As System.Windows.Forms.Button
    Friend WithEvents lblMensage As System.Windows.Forms.Label
    Friend WithEvents tsVCR As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblRecActual As System.Windows.Forms.Label
    Friend WithEvents txtLocalizar As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
