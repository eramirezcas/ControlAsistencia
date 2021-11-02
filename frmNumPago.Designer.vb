<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNumPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNumPago))
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnCargar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHoy = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNominaNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaFinal = New System.Windows.Forms.TextBox()
        Me.txtFechaInicio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB1TableAdapter1 = New WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "ENCABEZADO DE NÓMINA"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(400, 34)
        Me._titulo1.TabIndex = 12
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnCargar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(399, 25)
        Me.ToolStrip1.TabIndex = 33
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSalir.Size = New System.Drawing.Size(69, 22)
        Me.btnSalir.Text = "&Cancelar"
        '
        'btnCargar
        '
        Me.btnCargar.AutoSize = False
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCargar.Size = New System.Drawing.Size(65, 22)
        Me.btnCargar.Text = "Car&gar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHoy)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNominaNumero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(388, 99)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de encabezado de nómina:"
        '
        'txtHoy
        '
        Me.txtHoy.Enabled = False
        Me.txtHoy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoy.Location = New System.Drawing.Point(56, 62)
        Me.txtHoy.Name = "txtHoy"
        Me.txtHoy.Size = New System.Drawing.Size(75, 20)
        Me.txtHoy.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Hoy:"
        '
        'txtNominaNumero
        '
        Me.txtNominaNumero.Enabled = False
        Me.txtNominaNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNominaNumero.Location = New System.Drawing.Point(327, 31)
        Me.txtNominaNumero.Name = "txtNominaNumero"
        Me.txtNominaNumero.Size = New System.Drawing.Size(43, 20)
        Me.txtNominaNumero.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(274, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Número:"
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.Enabled = False
        Me.txtFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinal.Location = New System.Drawing.Point(184, 31)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(77, 20)
        Me.txtFechaFinal.TabIndex = 3
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Enabled = False
        Me.txtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.Location = New System.Drawing.Point(56, 31)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(75, 20)
        Me.txtFechaInicio.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(146, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Final:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inicio:"
        '
        'TB1TableAdapter1
        '
        Me.TB1TableAdapter1.ClearBeforeFill = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'frmNumPago
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(399, 175)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNumPago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TB1TableAdapter1 As WindowsApplication1.dtsReportTableAdapters.TB1TableAdapter
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents txtFechaFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHoy As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNominaNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
