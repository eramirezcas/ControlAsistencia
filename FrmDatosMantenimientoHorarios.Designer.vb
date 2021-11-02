<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatosMantenimientoHorarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDatosMantenimientoHorarios))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdHorario = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFeriado2 = New System.Windows.Forms.ComboBox()
        Me.cboFeriado1 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDomingoOut = New System.Windows.Forms.MaskedTextBox()
        Me.txtDomingoIn = New System.Windows.Forms.MaskedTextBox()
        Me.txtSabadoOut = New System.Windows.Forms.MaskedTextBox()
        Me.txtSabadoIn = New System.Windows.Forms.MaskedTextBox()
        Me.txtViernesOut = New System.Windows.Forms.MaskedTextBox()
        Me.txtViernesIn = New System.Windows.Forms.MaskedTextBox()
        Me.txtJuevesOut = New System.Windows.Forms.MaskedTextBox()
        Me.txtJuevesIn = New System.Windows.Forms.MaskedTextBox()
        Me.txtMiercolesOut = New System.Windows.Forms.MaskedTextBox()
        Me.txtMiercolesIn = New System.Windows.Forms.MaskedTextBox()
        Me.txtMartesOut = New System.Windows.Forms.MaskedTextBox()
        Me.txtMartesIn = New System.Windows.Forms.MaskedTextBox()
        Me.txtLunesOut = New System.Windows.Forms.MaskedTextBox()
        Me.txtLunesIn = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id Horario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción:"
        '
        'txtIdHorario
        '
        Me.txtIdHorario.Location = New System.Drawing.Point(80, 74)
        Me.txtIdHorario.Name = "txtIdHorario"
        Me.txtIdHorario.ReadOnly = True
        Me.txtIdHorario.Size = New System.Drawing.Size(43, 20)
        Me.txtIdHorario.TabIndex = 24
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDeshacer, Me.btnGuardar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(351, 25)
        Me.ToolStrip1.TabIndex = 65
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnDeshacer
        '
        Me.btnDeshacer.AutoSize = False
        Me.btnDeshacer.Image = CType(resources.GetObject("btnDeshacer.Image"), System.Drawing.Image)
        Me.btnDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeshacer.Size = New System.Drawing.Size(75, 22)
        Me.btnDeshacer.Text = "&Deshacer"
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
        'txtDepartamento
        '
        Me.txtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartamento.Location = New System.Drawing.Point(80, 99)
        Me.txtDepartamento.MaxLength = 30
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(266, 20)
        Me.txtDepartamento.TabIndex = 66
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Location = New System.Drawing.Point(130, 76)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 67
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "DATOS DE HORARIO"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 25)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(352, 34)
        Me._titulo1.TabIndex = 68
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFeriado2)
        Me.GroupBox1.Controls.Add(Me.cboFeriado1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtDomingoOut)
        Me.GroupBox1.Controls.Add(Me.txtDomingoIn)
        Me.GroupBox1.Controls.Add(Me.txtSabadoOut)
        Me.GroupBox1.Controls.Add(Me.txtSabadoIn)
        Me.GroupBox1.Controls.Add(Me.txtViernesOut)
        Me.GroupBox1.Controls.Add(Me.txtViernesIn)
        Me.GroupBox1.Controls.Add(Me.txtJuevesOut)
        Me.GroupBox1.Controls.Add(Me.txtJuevesIn)
        Me.GroupBox1.Controls.Add(Me.txtMiercolesOut)
        Me.GroupBox1.Controls.Add(Me.txtMiercolesIn)
        Me.GroupBox1.Controls.Add(Me.txtMartesOut)
        Me.GroupBox1.Controls.Add(Me.txtMartesIn)
        Me.GroupBox1.Controls.Add(Me.txtLunesOut)
        Me.GroupBox1.Controls.Add(Me.txtLunesIn)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 119)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 275)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        '
        'cboFeriado2
        '
        Me.cboFeriado2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeriado2.FormattingEnabled = True
        Me.cboFeriado2.Items.AddRange(New Object() {"NULO", "LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.cboFeriado2.Location = New System.Drawing.Point(217, 246)
        Me.cboFeriado2.Name = "cboFeriado2"
        Me.cboFeriado2.Size = New System.Drawing.Size(99, 21)
        Me.cboFeriado2.TabIndex = 82
        '
        'cboFeriado1
        '
        Me.cboFeriado1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeriado1.FormattingEnabled = True
        Me.cboFeriado1.Items.AddRange(New Object() {"NULO", "LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.cboFeriado1.Location = New System.Drawing.Point(113, 246)
        Me.cboFeriado1.Name = "cboFeriado1"
        Me.cboFeriado1.Size = New System.Drawing.Size(99, 21)
        Me.cboFeriado1.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(241, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "Feriado 2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(137, 226)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "Feriado 1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(26, 250)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "Feriado(s)"
        '
        'txtDomingoOut
        '
        Me.txtDomingoOut.Location = New System.Drawing.Point(243, 189)
        Me.txtDomingoOut.Mask = "00:00"
        Me.txtDomingoOut.Name = "txtDomingoOut"
        Me.txtDomingoOut.Size = New System.Drawing.Size(47, 20)
        Me.txtDomingoOut.TabIndex = 80
        Me.txtDomingoOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDomingoOut.ValidatingType = GetType(Date)
        '
        'txtDomingoIn
        '
        Me.txtDomingoIn.Location = New System.Drawing.Point(139, 189)
        Me.txtDomingoIn.Mask = "00:00"
        Me.txtDomingoIn.Name = "txtDomingoIn"
        Me.txtDomingoIn.Size = New System.Drawing.Size(47, 20)
        Me.txtDomingoIn.TabIndex = 79
        Me.txtDomingoIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDomingoIn.ValidatingType = GetType(Date)
        '
        'txtSabadoOut
        '
        Me.txtSabadoOut.Location = New System.Drawing.Point(243, 163)
        Me.txtSabadoOut.Mask = "00:00"
        Me.txtSabadoOut.Name = "txtSabadoOut"
        Me.txtSabadoOut.Size = New System.Drawing.Size(47, 20)
        Me.txtSabadoOut.TabIndex = 78
        Me.txtSabadoOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSabadoOut.ValidatingType = GetType(Date)
        '
        'txtSabadoIn
        '
        Me.txtSabadoIn.Location = New System.Drawing.Point(139, 163)
        Me.txtSabadoIn.Mask = "00:00"
        Me.txtSabadoIn.Name = "txtSabadoIn"
        Me.txtSabadoIn.Size = New System.Drawing.Size(47, 20)
        Me.txtSabadoIn.TabIndex = 77
        Me.txtSabadoIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSabadoIn.ValidatingType = GetType(Date)
        '
        'txtViernesOut
        '
        Me.txtViernesOut.Location = New System.Drawing.Point(243, 137)
        Me.txtViernesOut.Mask = "00:00"
        Me.txtViernesOut.Name = "txtViernesOut"
        Me.txtViernesOut.Size = New System.Drawing.Size(47, 20)
        Me.txtViernesOut.TabIndex = 76
        Me.txtViernesOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtViernesOut.ValidatingType = GetType(Date)
        '
        'txtViernesIn
        '
        Me.txtViernesIn.Location = New System.Drawing.Point(139, 137)
        Me.txtViernesIn.Mask = "00:00"
        Me.txtViernesIn.Name = "txtViernesIn"
        Me.txtViernesIn.Size = New System.Drawing.Size(47, 20)
        Me.txtViernesIn.TabIndex = 75
        Me.txtViernesIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtViernesIn.ValidatingType = GetType(Date)
        '
        'txtJuevesOut
        '
        Me.txtJuevesOut.Location = New System.Drawing.Point(243, 111)
        Me.txtJuevesOut.Mask = "00:00"
        Me.txtJuevesOut.Name = "txtJuevesOut"
        Me.txtJuevesOut.Size = New System.Drawing.Size(47, 20)
        Me.txtJuevesOut.TabIndex = 74
        Me.txtJuevesOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJuevesOut.ValidatingType = GetType(Date)
        '
        'txtJuevesIn
        '
        Me.txtJuevesIn.Location = New System.Drawing.Point(139, 111)
        Me.txtJuevesIn.Mask = "00:00"
        Me.txtJuevesIn.Name = "txtJuevesIn"
        Me.txtJuevesIn.Size = New System.Drawing.Size(47, 20)
        Me.txtJuevesIn.TabIndex = 73
        Me.txtJuevesIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJuevesIn.ValidatingType = GetType(Date)
        '
        'txtMiercolesOut
        '
        Me.txtMiercolesOut.Location = New System.Drawing.Point(243, 85)
        Me.txtMiercolesOut.Mask = "00:00"
        Me.txtMiercolesOut.Name = "txtMiercolesOut"
        Me.txtMiercolesOut.Size = New System.Drawing.Size(47, 20)
        Me.txtMiercolesOut.TabIndex = 72
        Me.txtMiercolesOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMiercolesOut.ValidatingType = GetType(Date)
        '
        'txtMiercolesIn
        '
        Me.txtMiercolesIn.Location = New System.Drawing.Point(139, 85)
        Me.txtMiercolesIn.Mask = "00:00"
        Me.txtMiercolesIn.Name = "txtMiercolesIn"
        Me.txtMiercolesIn.Size = New System.Drawing.Size(47, 20)
        Me.txtMiercolesIn.TabIndex = 71
        Me.txtMiercolesIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMiercolesIn.ValidatingType = GetType(Date)
        '
        'txtMartesOut
        '
        Me.txtMartesOut.Location = New System.Drawing.Point(243, 59)
        Me.txtMartesOut.Mask = "00:00"
        Me.txtMartesOut.Name = "txtMartesOut"
        Me.txtMartesOut.Size = New System.Drawing.Size(47, 20)
        Me.txtMartesOut.TabIndex = 70
        Me.txtMartesOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMartesOut.ValidatingType = GetType(Date)
        '
        'txtMartesIn
        '
        Me.txtMartesIn.Location = New System.Drawing.Point(139, 59)
        Me.txtMartesIn.Mask = "00:00"
        Me.txtMartesIn.Name = "txtMartesIn"
        Me.txtMartesIn.Size = New System.Drawing.Size(47, 20)
        Me.txtMartesIn.TabIndex = 69
        Me.txtMartesIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMartesIn.ValidatingType = GetType(Date)
        '
        'txtLunesOut
        '
        Me.txtLunesOut.Location = New System.Drawing.Point(243, 33)
        Me.txtLunesOut.Mask = "00:00"
        Me.txtLunesOut.Name = "txtLunesOut"
        Me.txtLunesOut.Size = New System.Drawing.Size(47, 20)
        Me.txtLunesOut.TabIndex = 68
        Me.txtLunesOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLunesOut.ValidatingType = GetType(Date)
        '
        'txtLunesIn
        '
        Me.txtLunesIn.Location = New System.Drawing.Point(139, 33)
        Me.txtLunesIn.Mask = "00:00"
        Me.txtLunesIn.Name = "txtLunesIn"
        Me.txtLunesIn.Size = New System.Drawing.Size(47, 20)
        Me.txtLunesIn.TabIndex = 67
        Me.txtLunesIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLunesIn.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(248, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "Salida"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(140, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Entrada"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(26, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "Domingo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Sabado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Viernes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Jueves"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Miercoles"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Martes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Lunes"
        '
        'FrmDatosMantenimientoHorarios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(351, 398)
        Me.Controls.Add(Me.ChkActivo)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtIdHorario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDatosMantenimientoHorarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATOS DE HORARIO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdHorario As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFeriado2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFeriado1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDomingoOut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDomingoIn As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSabadoOut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSabadoIn As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtViernesOut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtViernesIn As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtJuevesOut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtJuevesIn As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtMiercolesOut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtMiercolesIn As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtMartesOut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtMartesIn As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLunesOut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLunesIn As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
