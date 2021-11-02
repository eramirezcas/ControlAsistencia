<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMarcasBreacks
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMarcasBreacks))
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.TB1TableAdapter1 = New WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter()
        Me._titulo1 = New WindowsApplication1._titulo()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(81, 70)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(298, 20)
        Me.txtNombre.TabIndex = 63
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(557, 70)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(89, 20)
        Me.dtpFinal.TabIndex = 62
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(426, 70)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(87, 20)
        Me.dtpInicio.TabIndex = 61
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(519, 74)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(32, 13)
        Me.lblFin.TabIndex = 60
        Me.lblFin.Text = "Final:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(385, 74)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblInicio.TabIndex = 59
        Me.lblInicio.Text = "Inicio:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(2, 97)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(735, 304)
        Me.DataGridView1.TabIndex = 56
        '
        'tsMenu
        '
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimir, Me.btnExcel, Me.ToolStripSeparator2, Me.btnSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(739, 25)
        Me.tsMenu.TabIndex = 57
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
        Me.btnImprimir.Visible = False
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
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(2, 69)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(73, 23)
        Me.btnBuscar.TabIndex = 64
        Me.btnBuscar.Text = "Nombre:"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(652, 69)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(55, 22)
        Me.btnCargar.TabIndex = 65
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.UseVisualStyleBackColor = False
        '
        'TB1TableAdapter1
        '
        Me.TB1TableAdapter1.ClearBeforeFill = True
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "CONSULTA DE MARCAS DE CAFÉ Y ALMUERZO"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-4, 28)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(743, 34)
        Me._titulo1.TabIndex = 58
        '
        'frmConsultaMarcasBreacks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(739, 404)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.lblFin)
        Me.Controls.Add(Me.lblInicio)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaMarcasBreacks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSULTA DE MARCAS DE CAFÉ Y ALMUERZO"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents TB1TableAdapter1 As WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter
End Class
