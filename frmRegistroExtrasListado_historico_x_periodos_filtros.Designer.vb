<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroExtrasListado_historico_x_periodos_filtros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroExtrasListado_historico_x_periodos_filtros))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAcepar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnLimNi = New System.Windows.Forms.Button()
        Me.btnCargarNominas = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFfinal = New System.Windows.Forms.DateTimePicker()
        Me.dtFinicio = New System.Windows.Forms.DateTimePicker()
        Me.gridNominasInv = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnAgregaConcepto = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gridConceptos = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnEliminarTipoNomi = New System.Windows.Forms.Button()
        Me.btnAgregarTipoNomi = New System.Windows.Forms.Button()
        Me.gridTipoNomina = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gridNominasInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.gridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.gridTipoNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "     Definición de filtro"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.btnAcepar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(0, 511)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 36)
        Me.Panel1.TabIndex = 5
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tipos de nómina:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 339)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Nóminas involucradas:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnLimNi)
        Me.Panel2.Controls.Add(Me.btnCargarNominas)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dtFfinal)
        Me.Panel2.Controls.Add(Me.dtFinicio)
        Me.Panel2.Controls.Add(Me.gridNominasInv)
        Me.Panel2.Location = New System.Drawing.Point(9, 347)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(470, 155)
        Me.Panel2.TabIndex = 8
        '
        'btnLimNi
        '
        Me.btnLimNi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnLimNi.Location = New System.Drawing.Point(389, 13)
        Me.btnLimNi.Name = "btnLimNi"
        Me.btnLimNi.Size = New System.Drawing.Size(69, 23)
        Me.btnLimNi.TabIndex = 22
        Me.btnLimNi.Text = "Limpiar"
        Me.btnLimNi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimNi.UseVisualStyleBackColor = False
        '
        'btnCargarNominas
        '
        Me.btnCargarNominas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCargarNominas.Location = New System.Drawing.Point(316, 12)
        Me.btnCargarNominas.Name = "btnCargarNominas"
        Me.btnCargarNominas.Size = New System.Drawing.Size(69, 23)
        Me.btnCargarNominas.TabIndex = 21
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
        Me.dtFfinal.TabIndex = 18
        '
        'dtFinicio
        '
        Me.dtFinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinicio.Location = New System.Drawing.Point(54, 12)
        Me.dtFinicio.Name = "dtFinicio"
        Me.dtFinicio.Size = New System.Drawing.Size(95, 20)
        Me.dtFinicio.TabIndex = 17
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
        Me.gridNominasInv.Size = New System.Drawing.Size(445, 104)
        Me.gridNominasInv.TabIndex = 16
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnAgregaConcepto)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.gridConceptos)
        Me.Panel3.Location = New System.Drawing.Point(9, 190)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 135)
        Me.Panel3.TabIndex = 22
        '
        'btnAgregaConcepto
        '
        Me.btnAgregaConcepto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregaConcepto.Location = New System.Drawing.Point(389, 68)
        Me.btnAgregaConcepto.Name = "btnAgregaConcepto"
        Me.btnAgregaConcepto.Size = New System.Drawing.Size(69, 23)
        Me.btnAgregaConcepto.TabIndex = 27
        Me.btnAgregaConcepto.Text = "Eliminar"
        Me.btnAgregaConcepto.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Location = New System.Drawing.Point(389, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'gridConceptos
        '
        Me.gridConceptos.AllowUserToAddRows = False
        Me.gridConceptos.AllowUserToDeleteRows = False
        Me.gridConceptos.AllowUserToResizeColumns = False
        Me.gridConceptos.AllowUserToResizeRows = False
        Me.gridConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridConceptos.Location = New System.Drawing.Point(13, 16)
        Me.gridConceptos.MultiSelect = False
        Me.gridConceptos.Name = "gridConceptos"
        Me.gridConceptos.ReadOnly = True
        Me.gridConceptos.RowHeadersVisible = False
        Me.gridConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridConceptos.Size = New System.Drawing.Size(364, 106)
        Me.gridConceptos.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Conceptos:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnEliminarTipoNomi)
        Me.Panel4.Controls.Add(Me.btnAgregarTipoNomi)
        Me.Panel4.Controls.Add(Me.gridTipoNomina)
        Me.Panel4.Location = New System.Drawing.Point(9, 58)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(470, 108)
        Me.Panel4.TabIndex = 28
        '
        'btnEliminarTipoNomi
        '
        Me.btnEliminarTipoNomi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarTipoNomi.Location = New System.Drawing.Point(389, 68)
        Me.btnEliminarTipoNomi.Name = "btnEliminarTipoNomi"
        Me.btnEliminarTipoNomi.Size = New System.Drawing.Size(69, 23)
        Me.btnEliminarTipoNomi.TabIndex = 27
        Me.btnEliminarTipoNomi.Text = "Eliminar"
        Me.btnEliminarTipoNomi.UseVisualStyleBackColor = False
        '
        'btnAgregarTipoNomi
        '
        Me.btnAgregarTipoNomi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarTipoNomi.Location = New System.Drawing.Point(389, 39)
        Me.btnAgregarTipoNomi.Name = "btnAgregarTipoNomi"
        Me.btnAgregarTipoNomi.Size = New System.Drawing.Size(69, 23)
        Me.btnAgregarTipoNomi.TabIndex = 26
        Me.btnAgregarTipoNomi.Text = "Agregar"
        Me.btnAgregarTipoNomi.UseVisualStyleBackColor = False
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
        Me.gridTipoNomina.Size = New System.Drawing.Size(364, 79)
        Me.gridTipoNomina.TabIndex = 25
        '
        'frmRegistroExtrasListado_historico_x_periodos_filtros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 546)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistroExtrasListado_historico_x_periodos_filtros"
        Me.Text = "  Definición de filtro"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gridNominasInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.gridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.gridTipoNomina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAcepar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCargarNominas As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtFfinal As DateTimePicker
    Friend WithEvents dtFinicio As DateTimePicker
    Friend WithEvents gridNominasInv As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents gridConceptos As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnAgregarTipoNomi As Button
    Friend WithEvents gridTipoNomina As DataGridView
    Friend WithEvents btnLimNi As Button
    Friend WithEvents btnAgregaConcepto As Button
    Friend WithEvents btnEliminarTipoNomi As Button
End Class
