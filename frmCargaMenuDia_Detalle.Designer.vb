<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaMenuDia_Detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaMenuDia_Detalle))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkActiva = New System.Windows.Forms.CheckBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.txtnom_archivo = New System.Windows.Forms.TextBox()
        Me.txtImagen = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.imgPrevia = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(408, 32)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "CARGAR IMAGEN PARA MENÚ DEL DÍA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(329, 38)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(69, 27)
        Me.txtId.TabIndex = 128
        Me.txtId.Text = "0000000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(301, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 22)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "ID:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Location = New System.Drawing.Point(0, 471)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 43)
        Me.Panel1.TabIndex = 127
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(328, 7)
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
        Me.btnAceptar.Location = New System.Drawing.Point(249, 7)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(74, 25)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Guardar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkActiva)
        Me.GroupBox1.Controls.Add(Me.btnExaminar)
        Me.GroupBox1.Controls.Add(Me.txtnom_archivo)
        Me.GroupBox1.Controls.Add(Me.txtImagen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 157)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos imagen"
        '
        'txtFecha
        '
        Me.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFecha.Enabled = False
        Me.txtFecha.Location = New System.Drawing.Point(91, 101)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(210, 20)
        Me.txtFecha.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Creado:"
        '
        'chkActiva
        '
        Me.chkActiva.AutoSize = True
        Me.chkActiva.Location = New System.Drawing.Point(91, 127)
        Me.chkActiva.Name = "chkActiva"
        Me.chkActiva.Size = New System.Drawing.Size(56, 17)
        Me.chkActiva.TabIndex = 5
        Me.chkActiva.Text = "Activa"
        Me.chkActiva.UseVisualStyleBackColor = True
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = CType(resources.GetObject("btnExaminar.Image"), System.Drawing.Image)
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(303, 22)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(74, 23)
        Me.btnExaminar.TabIndex = 1
        Me.btnExaminar.Text = " Examinar"
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtnom_archivo
        '
        Me.txtnom_archivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnom_archivo.Enabled = False
        Me.txtnom_archivo.Location = New System.Drawing.Point(91, 53)
        Me.txtnom_archivo.Multiline = True
        Me.txtnom_archivo.Name = "txtnom_archivo"
        Me.txtnom_archivo.Size = New System.Drawing.Size(286, 42)
        Me.txtnom_archivo.TabIndex = 2
        '
        'txtImagen
        '
        Me.txtImagen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImagen.Enabled = False
        Me.txtImagen.Location = New System.Drawing.Point(91, 24)
        Me.txtImagen.Name = "txtImagen"
        Me.txtImagen.Size = New System.Drawing.Size(210, 20)
        Me.txtImagen.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Archivo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Imagen:"
        '
        'imgPrevia
        '
        Me.imgPrevia.Location = New System.Drawing.Point(8, 259)
        Me.imgPrevia.Name = "imgPrevia"
        Me.imgPrevia.Size = New System.Drawing.Size(392, 203)
        Me.imgPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgPrevia.TabIndex = 131
        Me.imgPrevia.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Vista Previa"
        '
        'frmCargaMenuDia_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(408, 509)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.imgPrevia)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCargaMenuDia_Detalle"
        Me.Text = "CARGAR IMAGEN PARA MENÚ DEL DÍA"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents txtnom_archivo As System.Windows.Forms.TextBox
    Friend WithEvents txtImagen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkActiva As System.Windows.Forms.CheckBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents imgPrevia As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
