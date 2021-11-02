<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMarcas_cuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMarcas_cuenta))
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrealizado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnIngDia = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnIngMesArea = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(185, 41)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtpFinal.TabIndex = 62
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(49, 41)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(95, 20)
        Me.dtpInicio.TabIndex = 61
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(151, 45)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(32, 13)
        Me.lblFin.TabIndex = 60
        Me.lblFin.Text = "Final:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(11, 45)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblInicio.TabIndex = 59
        Me.lblInicio.Text = "Inicio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(443, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Ingresos al:"
        '
        'txtrealizado
        '
        Me.txtrealizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrealizado.Location = New System.Drawing.Point(517, 11)
        Me.txtrealizado.Name = "txtrealizado"
        Me.txtrealizado.ReadOnly = True
        Me.txtrealizado.Size = New System.Drawing.Size(185, 26)
        Me.txtrealizado.TabIndex = 67
        Me.txtrealizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(721, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(779, 11)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(72, 26)
        Me.txtCantidad.TabIndex = 69
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, -1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(859, 35)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = " Marcas del dia (listado - cantidad)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Location = New System.Drawing.Point(-1, 427)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(861, 35)
        Me.Panel1.TabIndex = 71
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(780, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 73
        Me.Button2.Text = "Salir"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnIngDia
        '
        Me.btnIngDia.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnIngDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngDia.Location = New System.Drawing.Point(12, 69)
        Me.btnIngDia.Name = "btnIngDia"
        Me.btnIngDia.Size = New System.Drawing.Size(80, 23)
        Me.btnIngDia.TabIndex = 72
        Me.btnIngDia.Text = "Ingresos x dia"
        Me.btnIngDia.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 99)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(859, 283)
        Me.DataGridView1.TabIndex = 73
        '
        'btnIngMesArea
        '
        Me.btnIngMesArea.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnIngMesArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngMesArea.Location = New System.Drawing.Point(96, 69)
        Me.btnIngMesArea.Name = "btnIngMesArea"
        Me.btnIngMesArea.Size = New System.Drawing.Size(80, 23)
        Me.btnIngMesArea.TabIndex = 74
        Me.btnIngMesArea.Text = "Ing. x area"
        Me.btnIngMesArea.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(180, 69)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 23)
        Me.Button3.TabIndex = 75
        Me.Button3.Text = "Dias periodo"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.txtCantidad)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtrealizado)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(0, 382)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(861, 45)
        Me.Panel2.TabIndex = 74
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(264, 69)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "Ing. x mes"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(350, 69)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 23)
        Me.Button4.TabIndex = 77
        Me.Button4.Text = "Exporta Excel"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'frmConsultaMarcas_cuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(859, 460)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnIngMesArea)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnIngDia)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.lblFin)
        Me.Controls.Add(Me.lblInicio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaMarcas_cuenta"
        Me.Text = "Marcas del dia (listado - cantidad)"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFinal As DateTimePicker
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents lblFin As Label
    Friend WithEvents lblInicio As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtrealizado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents btnIngDia As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnIngMesArea As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
End Class
