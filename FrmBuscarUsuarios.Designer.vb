<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscarUsuarios))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnDescartar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.txtempid = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkVerTodos = New System.Windows.Forms.CheckBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtJefe = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblEmpleado = New System.Windows.Forms.Label()
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
        Me.tsMenu.Size = New System.Drawing.Size(386, 25)
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
        Me.txtempid.Location = New System.Drawing.Point(22, 35)
        Me.txtempid.Name = "txtempid"
        Me.txtempid.ReadOnly = True
        Me.txtempid.Size = New System.Drawing.Size(40, 20)
        Me.txtempid.TabIndex = 14
        Me.txtempid.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkVerTodos)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.txtContraseña)
        Me.GroupBox1.Controls.Add(Me.lblContraseña)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.txtJefe)
        Me.GroupBox1.Controls.Add(Me.lblUsuario)
        Me.GroupBox1.Controls.Add(Me.lblEmpleado)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 133)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(79, 85)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(286, 20)
        Me.txtEmail.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Email:"
        '
        'chkVerTodos
        '
        Me.chkVerTodos.AutoSize = True
        Me.chkVerTodos.Location = New System.Drawing.Point(79, 110)
        Me.chkVerTodos.Name = "chkVerTodos"
        Me.chkVerTodos.Size = New System.Drawing.Size(141, 17)
        Me.chkVerTodos.TabIndex = 21
        Me.chkVerTodos.Text = "Ver todos los empleados"
        Me.chkVerTodos.UseVisualStyleBackColor = True
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(309, 38)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 20
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(79, 61)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtContraseña.Size = New System.Drawing.Size(224, 20)
        Me.txtContraseña.TabIndex = 19
        '
        'lblContraseña
        '
        Me.lblContraseña.AutoSize = True
        Me.lblContraseña.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContraseña.ForeColor = System.Drawing.Color.Black
        Me.lblContraseña.Location = New System.Drawing.Point(9, 65)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(64, 13)
        Me.lblContraseña.TabIndex = 18
        Me.lblContraseña.Text = "Contraseña:"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Location = New System.Drawing.Point(79, 36)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(224, 20)
        Me.txtUsuario.TabIndex = 17
        '
        'txtJefe
        '
        Me.txtJefe.Location = New System.Drawing.Point(79, 12)
        Me.txtJefe.Name = "txtJefe"
        Me.txtJefe.ReadOnly = True
        Me.txtJefe.Size = New System.Drawing.Size(286, 20)
        Me.txtJefe.TabIndex = 16
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.Black
        Me.lblUsuario.Location = New System.Drawing.Point(9, 40)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(46, 13)
        Me.lblUsuario.TabIndex = 15
        Me.lblUsuario.Text = "Usuario:"
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpleado.Location = New System.Drawing.Point(9, 16)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(57, 13)
        Me.lblEmpleado.TabIndex = 14
        Me.lblEmpleado.Text = "Empleado:"
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "DATOS USUARIO"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(387, 34)
        Me._titulo1.TabIndex = 23
        '
        'FrmBuscarUsuarios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(386, 208)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.txtempid)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBuscarUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATOS USUARIO"
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtJefe As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents chkVerTodos As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
