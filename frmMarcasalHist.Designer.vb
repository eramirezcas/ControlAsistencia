<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcasalHist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcasalHist))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnDescartar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFinal = New System.Windows.Forms.TextBox()
        Me.txtFechaInicial = New System.Windows.Forms.TextBox()
        Me.txtNumpago = New System.Windows.Forms.TextBox()
        Me.txtRegistros = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tsMenu.Size = New System.Drawing.Size(376, 25)
        Me.tsMenu.TabIndex = 23
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
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnGuardar.Size = New System.Drawing.Size(75, 22)
        Me.btnGuardar.Text = "&Cierre"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicial)
        Me.GroupBox1.Controls.Add(Me.txtNumpago)
        Me.GroupBox1.Controls.Add(Me.txtRegistros)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(5, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 119)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de cierre"
        Me.GroupBox1.Visible = False
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.Location = New System.Drawing.Point(267, 61)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.ReadOnly = True
        Me.txtFechaFinal.Size = New System.Drawing.Size(90, 20)
        Me.txtFechaFinal.TabIndex = 7
        Me.txtFechaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.Location = New System.Drawing.Point(267, 36)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.ReadOnly = True
        Me.txtFechaInicial.Size = New System.Drawing.Size(90, 20)
        Me.txtFechaInicial.TabIndex = 6
        Me.txtFechaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumpago
        '
        Me.txtNumpago.Location = New System.Drawing.Point(97, 61)
        Me.txtNumpago.Name = "txtNumpago"
        Me.txtNumpago.ReadOnly = True
        Me.txtNumpago.Size = New System.Drawing.Size(90, 20)
        Me.txtNumpago.TabIndex = 5
        Me.txtNumpago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRegistros
        '
        Me.txtRegistros.Location = New System.Drawing.Point(97, 36)
        Me.txtRegistros.Name = "txtRegistros"
        Me.txtRegistros.ReadOnly = True
        Me.txtRegistros.Size = New System.Drawing.Size(90, 20)
        Me.txtRegistros.TabIndex = 4
        Me.txtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(196, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha final:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(196, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha inicial:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(7, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Número de pago:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(7, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Registros:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 119)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de cierre"
        Me.GroupBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.agt_update_critial
        Me.PictureBox1.Location = New System.Drawing.Point(143, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(81, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(19, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(328, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "No se han procesado marcas aun !!!"
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "ENVIAR MARCAS AL HISTÓRICO"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(377, 34)
        Me._titulo1.TabIndex = 24
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(366, 119)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de cierre"
        Me.GroupBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.WindowsApplication1.My.Resources.Resources.button_ok
        Me.PictureBox2.Location = New System.Drawing.Point(150, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(66, 80)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(56, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(255, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cierre realizado con éxtio !!!"
        '
        'frmMarcasalHist
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(376, 191)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMarcasalHist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ENVIAR MARCAS AL HISTÓRICO"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDescartar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtNumpago As System.Windows.Forms.TextBox
    Friend WithEvents txtRegistros As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
