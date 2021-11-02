<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambioCalve
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambioCalve))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnDescartar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtConfirmaClaveNueva = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClaveNueva = New System.Windows.Forms.TextBox()
        Me.txtClaveAnterior = New System.Windows.Forms.TextBox()
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.lblEmpleado = New System.Windows.Forms.Label()
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
        Me.tsMenu.Size = New System.Drawing.Size(387, 25)
        Me.tsMenu.TabIndex = 21
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtConfirmaClaveNueva)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtClaveNueva)
        Me.GroupBox1.Controls.Add(Me.txtClaveAnterior)
        Me.GroupBox1.Controls.Add(Me.lblHorario)
        Me.GroupBox1.Controls.Add(Me.lblEmpleado)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 107)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'txtConfirmaClaveNueva
        '
        Me.txtConfirmaClaveNueva.Location = New System.Drawing.Point(141, 76)
        Me.txtConfirmaClaveNueva.Name = "txtConfirmaClaveNueva"
        Me.txtConfirmaClaveNueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmaClaveNueva.Size = New System.Drawing.Size(226, 20)
        Me.txtConfirmaClaveNueva.TabIndex = 17
        Me.txtConfirmaClaveNueva.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Confirmar Nueva Clave :"
        '
        'txtClaveNueva
        '
        Me.txtClaveNueva.Location = New System.Drawing.Point(141, 46)
        Me.txtClaveNueva.Name = "txtClaveNueva"
        Me.txtClaveNueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClaveNueva.Size = New System.Drawing.Size(226, 20)
        Me.txtClaveNueva.TabIndex = 15
        Me.txtClaveNueva.UseSystemPasswordChar = True
        '
        'txtClaveAnterior
        '
        Me.txtClaveAnterior.Location = New System.Drawing.Point(141, 17)
        Me.txtClaveAnterior.Name = "txtClaveAnterior"
        Me.txtClaveAnterior.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClaveAnterior.ReadOnly = True
        Me.txtClaveAnterior.Size = New System.Drawing.Size(226, 20)
        Me.txtClaveAnterior.TabIndex = 14
        Me.txtClaveAnterior.UseSystemPasswordChar = True
        '
        'lblHorario
        '
        Me.lblHorario.AutoSize = True
        Me.lblHorario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorario.ForeColor = System.Drawing.Color.Black
        Me.lblHorario.Location = New System.Drawing.Point(12, 50)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(75, 13)
        Me.lblHorario.TabIndex = 13
        Me.lblHorario.Text = "Nueva Clave :"
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblEmpleado.Location = New System.Drawing.Point(12, 21)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(79, 13)
        Me.lblEmpleado.TabIndex = 12
        Me.lblEmpleado.Text = "Clave Anterior :"
        '
        'FrmCambioCalve
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(387, 135)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCambioCalve"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAMBIO DE CLAVE"
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtConfirmaClaveNueva As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClaveNueva As System.Windows.Forms.TextBox
    Friend WithEvents txtClaveAnterior As System.Windows.Forms.TextBox
    Friend WithEvents lblHorario As System.Windows.Forms.Label
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
End Class
