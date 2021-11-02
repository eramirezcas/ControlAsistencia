<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoCapsDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoCapsDetalle))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCaptura = New System.Windows.Forms.Button()
        Me.btnVerifica = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtId_Cap = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscaPersona = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtIdentificacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRRHH = New System.Windows.Forms.CheckBox()
        Me.chkRSE = New System.Windows.Forms.CheckBox()
        Me.dtpVence = New System.Windows.Forms.DateTimePicker()
        Me.txtCantDias = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkDBTUR = New System.Windows.Forms.CheckBox()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.btnCaptura)
        Me.GroupBox3.Controls.Add(Me.btnVerifica)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(457, 51)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Huella"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Huella registrada"
        '
        'btnCaptura
        '
        Me.btnCaptura.Image = CType(resources.GetObject("btnCaptura.Image"), System.Drawing.Image)
        Me.btnCaptura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCaptura.Location = New System.Drawing.Point(305, 18)
        Me.btnCaptura.Name = "btnCaptura"
        Me.btnCaptura.Size = New System.Drawing.Size(68, 23)
        Me.btnCaptura.TabIndex = 0
        Me.btnCaptura.Text = "Captura"
        Me.btnCaptura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCaptura.UseVisualStyleBackColor = True
        '
        'btnVerifica
        '
        Me.btnVerifica.Image = CType(resources.GetObject("btnVerifica.Image"), System.Drawing.Image)
        Me.btnVerifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerifica.Location = New System.Drawing.Point(379, 18)
        Me.btnVerifica.Name = "btnVerifica"
        Me.btnVerifica.Size = New System.Drawing.Size(68, 23)
        Me.btnVerifica.TabIndex = 1
        Me.btnVerifica.Text = "Verifica"
        Me.btnVerifica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerifica.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(466, 32)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "DATOS DE SERVICIO DE ALIMENTACIÓN TEMPORAL"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtId_Cap
        '
        Me.txtId_Cap.Enabled = False
        Me.txtId_Cap.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId_Cap.Location = New System.Drawing.Point(392, 38)
        Me.txtId_Cap.Name = "txtId_Cap"
        Me.txtId_Cap.Size = New System.Drawing.Size(69, 27)
        Me.txtId_Cap.TabIndex = 107
        Me.txtId_Cap.Text = "0000000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(309, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 22)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Servicio #"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBox1.Controls.Add(Me.btnBuscaPersona)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.txtIdentificacion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(457, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos personales"
        '
        'btnBuscaPersona
        '
        Me.btnBuscaPersona.Image = CType(resources.GetObject("btnBuscaPersona.Image"), System.Drawing.Image)
        Me.btnBuscaPersona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscaPersona.Location = New System.Drawing.Point(379, 21)
        Me.btnBuscaPersona.Name = "btnBuscaPersona"
        Me.btnBuscaPersona.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscaPersona.TabIndex = 1
        Me.btnBuscaPersona.Text = " Buscar"
        Me.btnBuscaPersona.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscaPersona.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(134, 49)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(313, 20)
        Me.txtNombre.TabIndex = 2
        '
        'txtIdentificacion
        '
        Me.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdentificacion.Location = New System.Drawing.Point(134, 22)
        Me.txtIdentificacion.Name = "txtIdentificacion"
        Me.txtIdentificacion.Size = New System.Drawing.Size(239, 20)
        Me.txtIdentificacion.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Identificación:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBox2.Controls.Add(Me.txtMotivo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.chkDBTUR)
        Me.GroupBox2.Controls.Add(Me.chkRRHH)
        Me.GroupBox2.Controls.Add(Me.chkRSE)
        Me.GroupBox2.Controls.Add(Me.dtpVence)
        Me.GroupBox2.Controls.Add(Me.txtCantDias)
        Me.GroupBox2.Controls.Add(Me.txtFecha)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 218)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(457, 176)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos servicio"
        '
        'chkRRHH
        '
        Me.chkRRHH.AutoSize = True
        Me.chkRRHH.Location = New System.Drawing.Point(134, 122)
        Me.chkRRHH.Name = "chkRRHH"
        Me.chkRRHH.Size = New System.Drawing.Size(114, 17)
        Me.chkRRHH.TabIndex = 5
        Me.chkRRHH.Text = "Servicio de RRHH"
        Me.chkRRHH.UseVisualStyleBackColor = True
        '
        'chkRSE
        '
        Me.chkRSE.AutoSize = True
        Me.chkRSE.Location = New System.Drawing.Point(134, 99)
        Me.chkRSE.Name = "chkRSE"
        Me.chkRSE.Size = New System.Drawing.Size(104, 17)
        Me.chkRSE.TabIndex = 4
        Me.chkRSE.Text = "Servicio de RSE"
        Me.chkRSE.UseVisualStyleBackColor = True
        '
        'dtpVence
        '
        Me.dtpVence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVence.Location = New System.Drawing.Point(298, 47)
        Me.dtpVence.Name = "dtpVence"
        Me.dtpVence.Size = New System.Drawing.Size(96, 20)
        Me.dtpVence.TabIndex = 2
        '
        'txtCantDias
        '
        Me.txtCantDias.Location = New System.Drawing.Point(134, 73)
        Me.txtCantDias.Name = "txtCantDias"
        Me.txtCantDias.Size = New System.Drawing.Size(100, 20)
        Me.txtCantDias.TabIndex = 3
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Location = New System.Drawing.Point(134, 47)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Dias:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(251, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Vence:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha:"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(388, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 25)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = " Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.White
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(309, 7)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(74, 25)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Guardar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Location = New System.Drawing.Point(-2, 401)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 43)
        Me.Panel1.TabIndex = 4
        '
        'chkDBTUR
        '
        Me.chkDBTUR.AutoSize = True
        Me.chkDBTUR.Location = New System.Drawing.Point(134, 145)
        Me.chkDBTUR.Name = "chkDBTUR"
        Me.chkDBTUR.Size = New System.Drawing.Size(116, 17)
        Me.chkDBTUR.TabIndex = 6
        Me.chkDBTUR.Text = "Dobla turno RRHH"
        Me.chkDBTUR.UseVisualStyleBackColor = True
        '
        'txtMotivo
        '
        Me.txtMotivo.Enabled = False
        Me.txtMotivo.Location = New System.Drawing.Point(134, 21)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(260, 20)
        Me.txtMotivo.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Motivo:"
        '
        'frmMantenimientoCapsDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(465, 439)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtId_Cap)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMantenimientoCapsDetalle"
        Me.Text = "DETALLE DE SERVICIO DE ALIMENTACIÓN TEMPORAL"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCaptura As System.Windows.Forms.Button
    Friend WithEvents btnVerifica As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtId_Cap As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscaPersona As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRRHH As System.Windows.Forms.CheckBox
    Friend WithEvents chkRSE As System.Windows.Forms.CheckBox
    Friend WithEvents dtpVence As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCantDias As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkDBTUR As System.Windows.Forms.CheckBox
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
