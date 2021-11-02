<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscar))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnDescartar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.txtempid = New System.Windows.Forms.TextBox()
        Me.txtdepid = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtJefe = New System.Windows.Forms.TextBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblJefe = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.tsMenu.Size = New System.Drawing.Size(350, 25)
        Me.tsMenu.TabIndex = 17
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
        'txtempid
        '
        Me.txtempid.Location = New System.Drawing.Point(94, 14)
        Me.txtempid.Name = "txtempid"
        Me.txtempid.ReadOnly = True
        Me.txtempid.Size = New System.Drawing.Size(16, 20)
        Me.txtempid.TabIndex = 10
        Me.txtempid.Visible = False
        '
        'txtdepid
        '
        Me.txtdepid.Location = New System.Drawing.Point(94, 40)
        Me.txtdepid.Name = "txtdepid"
        Me.txtdepid.ReadOnly = True
        Me.txtdepid.Size = New System.Drawing.Size(17, 20)
        Me.txtdepid.TabIndex = 10
        Me.txtdepid.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtempid)
        Me.GroupBox1.Controls.Add(Me.txtJefe)
        Me.GroupBox1.Controls.Add(Me.txtdepid)
        Me.GroupBox1.Controls.Add(Me.lblDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblJefe)
        Me.GroupBox1.Controls.Add(Me.txtDepartamento)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 68)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'txtJefe
        '
        Me.txtJefe.Location = New System.Drawing.Point(94, 14)
        Me.txtJefe.Name = "txtJefe"
        Me.txtJefe.ReadOnly = True
        Me.txtJefe.Size = New System.Drawing.Size(240, 20)
        Me.txtJefe.TabIndex = 12
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.ForeColor = System.Drawing.Color.Blue
        Me.lblDepartamento.Location = New System.Drawing.Point(8, 44)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(80, 13)
        Me.lblDepartamento.TabIndex = 11
        Me.lblDepartamento.Text = "Departamento :"
        '
        'lblJefe
        '
        Me.lblJefe.AutoSize = True
        Me.lblJefe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblJefe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJefe.ForeColor = System.Drawing.Color.Blue
        Me.lblJefe.Location = New System.Drawing.Point(8, 18)
        Me.lblJefe.Name = "lblJefe"
        Me.lblJefe.Size = New System.Drawing.Size(33, 13)
        Me.lblJefe.TabIndex = 10
        Me.lblJefe.Text = "Jefe :"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Location = New System.Drawing.Point(94, 40)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(240, 20)
        Me.txtDepartamento.TabIndex = 13
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "ASIGNAR DEPARTAMENTO"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(351, 34)
        Me._titulo1.TabIndex = 22
        '
        'FrmBuscar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(350, 139)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBuscar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNAR DEPARTAMENTO"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDescartar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtempid As System.Windows.Forms.TextBox
    Friend WithEvents txtdepid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtJefe As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblJefe As System.Windows.Forms.Label
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
End Class
