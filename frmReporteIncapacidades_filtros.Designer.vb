<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteIncapacidades_filtros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteIncapacidades_filtros))
        Me.btnEliminarTipoAccion = New System.Windows.Forms.Button()
        Me.gridTipoAccion = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAgregarTipoAccion = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnEliminarFechas = New System.Windows.Forms.Button()
        Me.btnAgregarFechas = New System.Windows.Forms.Button()
        Me.gridFechas = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFinicio = New System.Windows.Forms.DateTimePicker()
        Me.dtFfinal = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAcepar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.gridTipoAccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gridFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEliminarTipoAccion
        '
        Me.btnEliminarTipoAccion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarTipoAccion.Location = New System.Drawing.Point(389, 68)
        Me.btnEliminarTipoAccion.Name = "btnEliminarTipoAccion"
        Me.btnEliminarTipoAccion.Size = New System.Drawing.Size(69, 23)
        Me.btnEliminarTipoAccion.TabIndex = 27
        Me.btnEliminarTipoAccion.Text = "Eliminar"
        Me.btnEliminarTipoAccion.UseVisualStyleBackColor = False
        '
        'gridTipoAccion
        '
        Me.gridTipoAccion.AllowUserToAddRows = False
        Me.gridTipoAccion.AllowUserToDeleteRows = False
        Me.gridTipoAccion.AllowUserToResizeColumns = False
        Me.gridTipoAccion.AllowUserToResizeRows = False
        Me.gridTipoAccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTipoAccion.Location = New System.Drawing.Point(13, 18)
        Me.gridTipoAccion.MultiSelect = False
        Me.gridTipoAccion.Name = "gridTipoAccion"
        Me.gridTipoAccion.ReadOnly = True
        Me.gridTipoAccion.RowHeadersVisible = False
        Me.gridTipoAccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridTipoAccion.Size = New System.Drawing.Size(364, 79)
        Me.gridTipoAccion.TabIndex = 25
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnEliminarTipoAccion)
        Me.Panel4.Controls.Add(Me.btnAgregarTipoAccion)
        Me.Panel4.Controls.Add(Me.gridTipoAccion)
        Me.Panel4.Location = New System.Drawing.Point(9, 226)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(470, 108)
        Me.Panel4.TabIndex = 37
        '
        'btnAgregarTipoAccion
        '
        Me.btnAgregarTipoAccion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarTipoAccion.Location = New System.Drawing.Point(389, 39)
        Me.btnAgregarTipoAccion.Name = "btnAgregarTipoAccion"
        Me.btnAgregarTipoAccion.Size = New System.Drawing.Size(69, 23)
        Me.btnAgregarTipoAccion.TabIndex = 26
        Me.btnAgregarTipoAccion.Text = "Agregar"
        Me.btnAgregarTipoAccion.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnEliminarFechas)
        Me.Panel3.Controls.Add(Me.btnAgregarFechas)
        Me.Panel3.Controls.Add(Me.gridFechas)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.dtFinicio)
        Me.Panel3.Controls.Add(Me.dtFfinal)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(9, 49)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 158)
        Me.Panel3.TabIndex = 35
        '
        'btnEliminarFechas
        '
        Me.btnEliminarFechas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarFechas.Location = New System.Drawing.Point(388, 116)
        Me.btnEliminarFechas.Name = "btnEliminarFechas"
        Me.btnEliminarFechas.Size = New System.Drawing.Size(69, 23)
        Me.btnEliminarFechas.TabIndex = 30
        Me.btnEliminarFechas.Text = "Eliminar"
        Me.btnEliminarFechas.UseVisualStyleBackColor = False
        '
        'btnAgregarFechas
        '
        Me.btnAgregarFechas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarFechas.Location = New System.Drawing.Point(388, 87)
        Me.btnAgregarFechas.Name = "btnAgregarFechas"
        Me.btnAgregarFechas.Size = New System.Drawing.Size(69, 23)
        Me.btnAgregarFechas.TabIndex = 29
        Me.btnAgregarFechas.Text = "Agregar"
        Me.btnAgregarFechas.UseVisualStyleBackColor = False
        '
        'gridFechas
        '
        Me.gridFechas.AllowUserToAddRows = False
        Me.gridFechas.AllowUserToDeleteRows = False
        Me.gridFechas.AllowUserToResizeColumns = False
        Me.gridFechas.AllowUserToResizeRows = False
        Me.gridFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFechas.Location = New System.Drawing.Point(13, 68)
        Me.gridFechas.MultiSelect = False
        Me.gridFechas.Name = "gridFechas"
        Me.gridFechas.ReadOnly = True
        Me.gridFechas.RowHeadersVisible = False
        Me.gridFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridFechas.Size = New System.Drawing.Size(364, 79)
        Me.gridFechas.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Inicio:"
        '
        'dtFinicio
        '
        Me.dtFinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinicio.Location = New System.Drawing.Point(54, 18)
        Me.dtFinicio.Name = "dtFinicio"
        Me.dtFinicio.Size = New System.Drawing.Size(95, 20)
        Me.dtFinicio.TabIndex = 17
        '
        'dtFfinal
        '
        Me.dtFfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFfinal.Location = New System.Drawing.Point(199, 18)
        Me.dtFfinal.Name = "dtFfinal"
        Me.dtFfinal.Size = New System.Drawing.Size(95, 20)
        Me.dtFfinal.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(161, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Final:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Tipos de acción:"
        '
        'btnAcepar
        '
        Me.btnAcepar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAcepar.Image = CType(resources.GetObject("btnAcepar.Image"), System.Drawing.Image)
        Me.btnAcepar.Location = New System.Drawing.Point(326, 7)
        Me.btnAcepar.Name = "btnAcepar"
        Me.btnAcepar.Size = New System.Drawing.Size(75, 23)
        Me.btnAcepar.TabIndex = 7
        Me.btnAcepar.Text = "Aceptar"
        Me.btnAcepar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAcepar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(407, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.btnAcepar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(0, 343)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 36)
        Me.Panel1.TabIndex = 31
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 32)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "     Definición de filtro"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Fechas:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(28, 95)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(336, 17)
        Me.CheckBox1.TabIndex = 40
        Me.CheckBox1.Text = "Separar resultados cuando las acciones abarcan mas de 30 días."
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmReporteIncapacidades_filtros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 378)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteIncapacidades_filtros"
        Me.Text = "  Definición de filtro"
        CType(Me.gridTipoAccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.gridFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEliminarTipoAccion As Button
    Friend WithEvents gridTipoAccion As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnAgregarTipoAccion As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtFfinal As DateTimePicker
    Friend WithEvents dtFinicio As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAcepar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEliminarFechas As Button
    Friend WithEvents btnAgregarFechas As Button
    Friend WithEvents gridFechas As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox1 As CheckBox
End Class
