<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJustificacionMarcas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJustificacionMarcas))
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblEntra = New System.Windows.Forms.Label()
        Me.lblTarde = New System.Windows.Forms.Label()
        Me.lblJustificacion = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtEntra = New System.Windows.Forms.TextBox()
        Me.txtTarde = New System.Windows.Forms.TextBox()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnDescartar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.txtJustificacion = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(3, 41)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(43, 13)
        Me.lblMarca.TabIndex = 0
        Me.lblMarca.Text = "Marca :"
        '
        'lblEntra
        '
        Me.lblEntra.AutoSize = True
        Me.lblEntra.Location = New System.Drawing.Point(3, 15)
        Me.lblEntra.Name = "lblEntra"
        Me.lblEntra.Size = New System.Drawing.Size(79, 13)
        Me.lblEntra.TabIndex = 1
        Me.lblEntra.Text = "Hora de Entra :"
        '
        'lblTarde
        '
        Me.lblTarde.AutoSize = True
        Me.lblTarde.Location = New System.Drawing.Point(3, 67)
        Me.lblTarde.Name = "lblTarde"
        Me.lblTarde.Size = New System.Drawing.Size(41, 13)
        Me.lblTarde.TabIndex = 2
        Me.lblTarde.Text = "Tarde :"
        '
        'lblJustificacion
        '
        Me.lblJustificacion.AutoSize = True
        Me.lblJustificacion.Location = New System.Drawing.Point(3, 93)
        Me.lblJustificacion.Name = "lblJustificacion"
        Me.lblJustificacion.Size = New System.Drawing.Size(71, 13)
        Me.lblJustificacion.TabIndex = 3
        Me.lblJustificacion.Text = "Justificacion :"
        '
        'txtMarca
        '
        Me.txtMarca.Enabled = False
        Me.txtMarca.Location = New System.Drawing.Point(88, 12)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(144, 20)
        Me.txtMarca.TabIndex = 4
        '
        'txtEntra
        '
        Me.txtEntra.Enabled = False
        Me.txtEntra.Location = New System.Drawing.Point(88, 38)
        Me.txtEntra.Name = "txtEntra"
        Me.txtEntra.Size = New System.Drawing.Size(144, 20)
        Me.txtEntra.TabIndex = 5
        '
        'txtTarde
        '
        Me.txtTarde.Enabled = False
        Me.txtTarde.Location = New System.Drawing.Point(88, 64)
        Me.txtTarde.Name = "txtTarde"
        Me.txtTarde.Size = New System.Drawing.Size(144, 20)
        Me.txtTarde.TabIndex = 6
        '
        'tsMenu
        '
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDescartar, Me.btnGuardar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsMenu.Size = New System.Drawing.Size(333, 25)
        Me.tsMenu.TabIndex = 26
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
        Me.btnGuardar.Text = "&Aceptar"
        '
        'txtJustificacion
        '
        Me.txtJustificacion.Location = New System.Drawing.Point(88, 90)
        Me.txtJustificacion.Multiline = True
        Me.txtJustificacion.Name = "txtJustificacion"
        Me.txtJustificacion.Size = New System.Drawing.Size(228, 55)
        Me.txtJustificacion.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMarca)
        Me.GroupBox1.Controls.Add(Me.txtJustificacion)
        Me.GroupBox1.Controls.Add(Me.lblMarca)
        Me.GroupBox1.Controls.Add(Me.txtEntra)
        Me.GroupBox1.Controls.Add(Me.lblJustificacion)
        Me.GroupBox1.Controls.Add(Me.txtTarde)
        Me.GroupBox1.Controls.Add(Me.lblEntra)
        Me.GroupBox1.Controls.Add(Me.lblTarde)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 154)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "JUSTIFICACIÓN DE MARCA"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(334, 34)
        Me._titulo1.TabIndex = 29
        '
        'frmJustificacionMarcas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(333, 226)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me._titulo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJustificacionMarcas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JUSTIFICACIÓN DE MARCA"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblEntra As System.Windows.Forms.Label
    Friend WithEvents lblTarde As System.Windows.Forms.Label
    Friend WithEvents lblJustificacion As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtEntra As System.Windows.Forms.TextBox
    Friend WithEvents txtTarde As System.Windows.Forms.TextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDescartar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtJustificacion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
End Class
