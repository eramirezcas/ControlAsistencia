<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaEmpHorario
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaEmpHorario))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnDescartar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtHorario = New System.Windows.Forms.TextBox()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.chkHorFijo = New System.Windows.Forms.CheckBox()
        Me.TB1TableAdapter1 = New WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter()
        Me.tsMenu.SuspendLayout()
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
        Me.tsMenu.Size = New System.Drawing.Size(415, 25)
        Me.tsMenu.TabIndex = 19
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
        Me.btnDescartar.ToolTipText = "Descarte las busquedas realizadas"
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
        Me.btnGuardar.ToolTipText = "Guarde las busquedas realizadas"
        '
        'txtHorario
        '
        Me.txtHorario.Location = New System.Drawing.Point(76, 102)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.ReadOnly = True
        Me.txtHorario.Size = New System.Drawing.Size(212, 20)
        Me.txtHorario.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.txtHorario, "Horario buscado")
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Location = New System.Drawing.Point(76, 73)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.ReadOnly = True
        Me.txtEmpleado.Size = New System.Drawing.Size(327, 20)
        Me.txtEmpleado.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.txtEmpleado, "Empleado buscado")
        '
        'lblHorario
        '
        Me.lblHorario.AutoSize = True
        Me.lblHorario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorario.ForeColor = System.Drawing.Color.Blue
        Me.lblHorario.Location = New System.Drawing.Point(11, 106)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(47, 13)
        Me.lblHorario.TabIndex = 11
        Me.lblHorario.Text = "Horario :"
        Me.ToolTip1.SetToolTip(Me.lblHorario, "De un click para buscar el horario que usted dese")
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpleado.Location = New System.Drawing.Point(11, 77)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(60, 13)
        Me.lblEmpleado.TabIndex = 10
        Me.lblEmpleado.Text = "Empleado :"
        Me.ToolTip1.SetToolTip(Me.lblEmpleado, "De un click para buscar en la lista de empleados")
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.Image = Global.WindowsApplication1.My.Resources.Resources.findf
        Me.btnVerDetalle.Location = New System.Drawing.Point(372, 101)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(31, 23)
        Me.btnVerDetalle.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnVerDetalle, "Ver detalle de horario")
        Me.btnVerDetalle.UseVisualStyleBackColor = True
        Me.btnVerDetalle.Visible = False
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "ASIGNAR HORARIO"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(416, 34)
        Me._titulo1.TabIndex = 21
        '
        'chkHorFijo
        '
        Me.chkHorFijo.AutoSize = True
        Me.chkHorFijo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkHorFijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHorFijo.ForeColor = System.Drawing.Color.Blue
        Me.chkHorFijo.Location = New System.Drawing.Point(294, 104)
        Me.chkHorFijo.Name = "chkHorFijo"
        Me.chkHorFijo.Size = New System.Drawing.Size(79, 17)
        Me.chkHorFijo.TabIndex = 15
        Me.chkHorFijo.Text = "Horario Fijo"
        Me.chkHorFijo.UseVisualStyleBackColor = True
        '
        'TB1TableAdapter1
        '
        Me.TB1TableAdapter1.ClearBeforeFill = True
        '
        'FrmBuscaEmpHorario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(415, 132)
        Me.Controls.Add(Me.chkHorFijo)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.btnVerDetalle)
        Me.Controls.Add(Me.txtHorario)
        Me.Controls.Add(Me.txtEmpleado)
        Me.Controls.Add(Me.lblHorario)
        Me.Controls.Add(Me.lblEmpleado)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBuscaEmpHorario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNAR HORARIO"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDescartar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtHorario As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents lblHorario As System.Windows.Forms.Label
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents btnVerDetalle As System.Windows.Forms.Button
    Friend WithEvents chkHorFijo As System.Windows.Forms.CheckBox
    Friend WithEvents TB1TableAdapter1 As WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter
End Class
