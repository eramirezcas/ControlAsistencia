<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteRotacion_filtros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteRotacion_filtros))
        Me.btnEliminarTipoNomi = New System.Windows.Forms.Button()
        Me.gridTipoNomina = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAgregarTipoNomi = New System.Windows.Forms.Button()
        Me.btnEliminarTipoAccion = New System.Windows.Forms.Button()
        Me.btnAgregarTipoAccion = New System.Windows.Forms.Button()
        Me.gridTipoAccion = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chAccionIng = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarNominas = New System.Windows.Forms.Button()
        Me.btnCargarNominas = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFfinal = New System.Windows.Forms.DateTimePicker()
        Me.dtFinicio = New System.Windows.Forms.DateTimePicker()
        Me.gridNominasInv = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAcepar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnEliminarColaborador = New System.Windows.Forms.Button()
        Me.btnAgregarColaborador = New System.Windows.Forms.Button()
        Me.gridTipoCol = New System.Windows.Forms.DataGridView()
        CType(Me.gridTipoNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.gridTipoAccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.gridNominasInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.gridTipoCol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEliminarTipoNomi
        '
        Me.btnEliminarTipoNomi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarTipoNomi.Location = New System.Drawing.Point(389, 40)
        Me.btnEliminarTipoNomi.Name = "btnEliminarTipoNomi"
        Me.btnEliminarTipoNomi.Size = New System.Drawing.Size(69, 23)
        Me.btnEliminarTipoNomi.TabIndex = 1
        Me.btnEliminarTipoNomi.Text = "Eliminar"
        Me.btnEliminarTipoNomi.UseVisualStyleBackColor = False
        '
        'gridTipoNomina
        '
        Me.gridTipoNomina.AllowUserToAddRows = False
        Me.gridTipoNomina.AllowUserToDeleteRows = False
        Me.gridTipoNomina.AllowUserToResizeColumns = False
        Me.gridTipoNomina.AllowUserToResizeRows = False
        Me.gridTipoNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTipoNomina.Location = New System.Drawing.Point(13, 18)
        Me.gridTipoNomina.MultiSelect = False
        Me.gridTipoNomina.Name = "gridTipoNomina"
        Me.gridTipoNomina.ReadOnly = True
        Me.gridTipoNomina.RowHeadersVisible = False
        Me.gridTipoNomina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridTipoNomina.Size = New System.Drawing.Size(364, 44)
        Me.gridTipoNomina.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Tipos de acción:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnEliminarTipoNomi)
        Me.Panel4.Controls.Add(Me.btnAgregarTipoNomi)
        Me.Panel4.Controls.Add(Me.gridTipoNomina)
        Me.Panel4.Location = New System.Drawing.Point(9, 138)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(470, 73)
        Me.Panel4.TabIndex = 1
        '
        'btnAgregarTipoNomi
        '
        Me.btnAgregarTipoNomi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarTipoNomi.Location = New System.Drawing.Point(389, 11)
        Me.btnAgregarTipoNomi.Name = "btnAgregarTipoNomi"
        Me.btnAgregarTipoNomi.Size = New System.Drawing.Size(69, 23)
        Me.btnAgregarTipoNomi.TabIndex = 0
        Me.btnAgregarTipoNomi.Text = "Agregar"
        Me.btnAgregarTipoNomi.UseVisualStyleBackColor = False
        '
        'btnEliminarTipoAccion
        '
        Me.btnEliminarTipoAccion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarTipoAccion.Location = New System.Drawing.Point(389, 58)
        Me.btnEliminarTipoAccion.Name = "btnEliminarTipoAccion"
        Me.btnEliminarTipoAccion.Size = New System.Drawing.Size(69, 23)
        Me.btnEliminarTipoAccion.TabIndex = 2
        Me.btnEliminarTipoAccion.Text = "Eliminar"
        Me.btnEliminarTipoAccion.UseVisualStyleBackColor = False
        '
        'btnAgregarTipoAccion
        '
        Me.btnAgregarTipoAccion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarTipoAccion.Location = New System.Drawing.Point(389, 29)
        Me.btnAgregarTipoAccion.Name = "btnAgregarTipoAccion"
        Me.btnAgregarTipoAccion.Size = New System.Drawing.Size(69, 23)
        Me.btnAgregarTipoAccion.TabIndex = 1
        Me.btnAgregarTipoAccion.Text = "Agregar"
        Me.btnAgregarTipoAccion.UseVisualStyleBackColor = False
        '
        'gridTipoAccion
        '
        Me.gridTipoAccion.AllowUserToAddRows = False
        Me.gridTipoAccion.AllowUserToDeleteRows = False
        Me.gridTipoAccion.AllowUserToResizeColumns = False
        Me.gridTipoAccion.AllowUserToResizeRows = False
        Me.gridTipoAccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTipoAccion.Location = New System.Drawing.Point(13, 30)
        Me.gridTipoAccion.MultiSelect = False
        Me.gridTipoAccion.Name = "gridTipoAccion"
        Me.gridTipoAccion.ReadOnly = True
        Me.gridTipoAccion.RowHeadersVisible = False
        Me.gridTipoAccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridTipoAccion.Size = New System.Drawing.Size(364, 84)
        Me.gridTipoAccion.TabIndex = 25
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chAccionIng)
        Me.Panel3.Controls.Add(Me.btnEliminarTipoAccion)
        Me.Panel3.Controls.Add(Me.btnAgregarTipoAccion)
        Me.Panel3.Controls.Add(Me.gridTipoAccion)
        Me.Panel3.Location = New System.Drawing.Point(9, 228)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 124)
        Me.Panel3.TabIndex = 2
        '
        'chAccionIng
        '
        Me.chAccionIng.AutoSize = True
        Me.chAccionIng.Location = New System.Drawing.Point(13, 11)
        Me.chAccionIng.Name = "chAccionIng"
        Me.chAccionIng.Size = New System.Drawing.Size(134, 17)
        Me.chAccionIng.TabIndex = 0
        Me.chAccionIng.Text = "Es acción de ingreso ?"
        Me.chAccionIng.UseVisualStyleBackColor = True
        '
        'btnLimpiarNominas
        '
        Me.btnLimpiarNominas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnLimpiarNominas.Location = New System.Drawing.Point(389, 13)
        Me.btnLimpiarNominas.Name = "btnLimpiarNominas"
        Me.btnLimpiarNominas.Size = New System.Drawing.Size(69, 23)
        Me.btnLimpiarNominas.TabIndex = 3
        Me.btnLimpiarNominas.Text = "Limpiar"
        Me.btnLimpiarNominas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarNominas.UseVisualStyleBackColor = False
        '
        'btnCargarNominas
        '
        Me.btnCargarNominas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCargarNominas.Location = New System.Drawing.Point(316, 12)
        Me.btnCargarNominas.Name = "btnCargarNominas"
        Me.btnCargarNominas.Size = New System.Drawing.Size(69, 23)
        Me.btnCargarNominas.TabIndex = 2
        Me.btnCargarNominas.Text = "Cargar"
        Me.btnCargarNominas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCargarNominas.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(161, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Final:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Inicio:"
        '
        'dtFfinal
        '
        Me.dtFfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFfinal.Location = New System.Drawing.Point(199, 12)
        Me.dtFfinal.Name = "dtFfinal"
        Me.dtFfinal.Size = New System.Drawing.Size(95, 20)
        Me.dtFfinal.TabIndex = 1
        '
        'dtFinicio
        '
        Me.dtFinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinicio.Location = New System.Drawing.Point(54, 12)
        Me.dtFinicio.Name = "dtFinicio"
        Me.dtFinicio.Size = New System.Drawing.Size(95, 20)
        Me.dtFinicio.TabIndex = 0
        '
        'gridNominasInv
        '
        Me.gridNominasInv.AllowUserToAddRows = False
        Me.gridNominasInv.AllowUserToDeleteRows = False
        Me.gridNominasInv.AllowUserToResizeColumns = False
        Me.gridNominasInv.AllowUserToResizeRows = False
        Me.gridNominasInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridNominasInv.Location = New System.Drawing.Point(13, 41)
        Me.gridNominasInv.Name = "gridNominasInv"
        Me.gridNominasInv.ReadOnly = True
        Me.gridNominasInv.RowHeadersVisible = False
        Me.gridNominasInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridNominasInv.Size = New System.Drawing.Size(445, 98)
        Me.gridNominasInv.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 360)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Nóminas involucradas:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Tipos de nómina:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnLimpiarNominas)
        Me.Panel2.Controls.Add(Me.btnCargarNominas)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dtFfinal)
        Me.Panel2.Controls.Add(Me.dtFinicio)
        Me.Panel2.Controls.Add(Me.gridNominasInv)
        Me.Panel2.Location = New System.Drawing.Point(9, 368)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(470, 148)
        Me.Panel2.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.btnAcepar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(0, 527)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 36)
        Me.Panel1.TabIndex = 4
        '
        'btnAcepar
        '
        Me.btnAcepar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAcepar.Image = CType(resources.GetObject("btnAcepar.Image"), System.Drawing.Image)
        Me.btnAcepar.Location = New System.Drawing.Point(326, 7)
        Me.btnAcepar.Name = "btnAcepar"
        Me.btnAcepar.Size = New System.Drawing.Size(75, 23)
        Me.btnAcepar.TabIndex = 0
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
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 32)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "     Definición de filtro"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Tipos de colaborador:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnEliminarColaborador)
        Me.Panel5.Controls.Add(Me.btnAgregarColaborador)
        Me.Panel5.Controls.Add(Me.gridTipoCol)
        Me.Panel5.Location = New System.Drawing.Point(9, 49)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(470, 73)
        Me.Panel5.TabIndex = 0
        '
        'btnEliminarColaborador
        '
        Me.btnEliminarColaborador.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarColaborador.Location = New System.Drawing.Point(389, 40)
        Me.btnEliminarColaborador.Name = "btnEliminarColaborador"
        Me.btnEliminarColaborador.Size = New System.Drawing.Size(69, 23)
        Me.btnEliminarColaborador.TabIndex = 1
        Me.btnEliminarColaborador.Text = "Eliminar"
        Me.btnEliminarColaborador.UseVisualStyleBackColor = False
        '
        'btnAgregarColaborador
        '
        Me.btnAgregarColaborador.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarColaborador.Location = New System.Drawing.Point(389, 11)
        Me.btnAgregarColaborador.Name = "btnAgregarColaborador"
        Me.btnAgregarColaborador.Size = New System.Drawing.Size(69, 23)
        Me.btnAgregarColaborador.TabIndex = 0
        Me.btnAgregarColaborador.Text = "Agregar"
        Me.btnAgregarColaborador.UseVisualStyleBackColor = False
        '
        'gridTipoCol
        '
        Me.gridTipoCol.AllowUserToAddRows = False
        Me.gridTipoCol.AllowUserToDeleteRows = False
        Me.gridTipoCol.AllowUserToResizeColumns = False
        Me.gridTipoCol.AllowUserToResizeRows = False
        Me.gridTipoCol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTipoCol.Location = New System.Drawing.Point(13, 18)
        Me.gridTipoCol.MultiSelect = False
        Me.gridTipoCol.Name = "gridTipoCol"
        Me.gridTipoCol.ReadOnly = True
        Me.gridTipoCol.RowHeadersVisible = False
        Me.gridTipoCol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridTipoCol.Size = New System.Drawing.Size(364, 44)
        Me.gridTipoCol.TabIndex = 25
        '
        'frmReporteRotacion_filtros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 564)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReporteRotacion_filtros"
        Me.Text = "Definición de filtro"
        CType(Me.gridTipoNomina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.gridTipoAccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.gridNominasInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.gridTipoCol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEliminarTipoNomi As Button
    Friend WithEvents gridTipoNomina As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnAgregarTipoNomi As Button
    Friend WithEvents btnEliminarTipoAccion As Button
    Friend WithEvents btnAgregarTipoAccion As Button
    Friend WithEvents gridTipoAccion As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnLimpiarNominas As Button
    Friend WithEvents btnCargarNominas As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtFfinal As DateTimePicker
    Friend WithEvents dtFinicio As DateTimePicker
    Friend WithEvents gridNominasInv As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAcepar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnEliminarColaborador As Button
    Friend WithEvents btnAgregarColaborador As Button
    Friend WithEvents gridTipoCol As DataGridView
    Friend WithEvents chAccionIng As CheckBox
End Class
