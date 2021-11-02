<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsignaPermisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsignaPermisos))
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.BtnFiltar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(68, 88)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(404, 20)
        Me.txtNombre.TabIndex = 54
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Blue
        Me.lblNombre.Location = New System.Drawing.Point(12, 92)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(50, 13)
        Me.lblNombre.TabIndex = 53
        Me.lblNombre.Text = "Nombre :"
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConsultar, Me.btnLimpiar, Me.btnImprimir, Me.ToolStripSeparator1, Me.btnExcel, Me.BtnFiltar, Me.ToolStripSeparator2, Me.btnSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(484, 25)
        Me.tsMenu.TabIndex = 55
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
        Me._titulo1._foreColor = System.Drawing.Color.Empty
        Me._titulo1._picture = "\\tempisque\sistemas\Poas\Iconos\kedit.ico"
        Me._titulo1._text = "Consulta de Extras"
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(0, 28)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(484, 61)
        Me._titulo1.TabIndex = 56
        '
        'FrmAsignaPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 262)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblNombre)
        Me.Name = "FrmAsignaPermisos"
        Me.Text = "FrmAsignaPermisos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnFiltar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
End Class
