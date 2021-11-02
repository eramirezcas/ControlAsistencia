<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportePlanillaMensual_filtros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportePlanillaMensual_filtros))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAcepar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAgregarFechas = New System.Windows.Forms.Button()
        Me.gridFechas = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.cboAnio = New System.Windows.Forms.ComboBox()
        Me.btnAgregarTipoNomina = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnEliminarTipoNomina = New System.Windows.Forms.Button()
        Me.gridTipoNomina = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnEliminarConcepto = New System.Windows.Forms.Button()
        Me.btnAgregarConcepto = New System.Windows.Forms.Button()
        Me.gridListaConceptos = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.gridTipoNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.gridListaConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.btnAcepar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(-1, 561)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(651, 44)
        Me.Panel1.TabIndex = 43
        '
        'btnAcepar
        '
        Me.btnAcepar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAcepar.Image = CType(resources.GetObject("btnAcepar.Image"), System.Drawing.Image)
        Me.btnAcepar.Location = New System.Drawing.Point(435, 9)
        Me.btnAcepar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAcepar.Name = "btnAcepar"
        Me.btnAcepar.Size = New System.Drawing.Size(100, 28)
        Me.btnAcepar.TabIndex = 7
        Me.btnAcepar.Text = "Aceptar"
        Me.btnAcepar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAcepar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(543, 9)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 28)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 42
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 213)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 17)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Tipos de nómina:"
        '
        'btnAgregarFechas
        '
        Me.btnAgregarFechas.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarFechas.Location = New System.Drawing.Point(519, 59)
        Me.btnAgregarFechas.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarFechas.Name = "btnAgregarFechas"
        Me.btnAgregarFechas.Size = New System.Drawing.Size(92, 28)
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
        Me.gridFechas.Location = New System.Drawing.Point(17, 59)
        Me.gridFechas.Margin = New System.Windows.Forms.Padding(4)
        Me.gridFechas.MultiSelect = False
        Me.gridFechas.Name = "gridFechas"
        Me.gridFechas.ReadOnly = True
        Me.gridFechas.RowHeadersVisible = False
        Me.gridFechas.RowHeadersWidth = 51
        Me.gridFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridFechas.Size = New System.Drawing.Size(485, 64)
        Me.gridFechas.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Año:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(215, 26)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Mes:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cboMes)
        Me.Panel3.Controls.Add(Me.cboAnio)
        Me.Panel3.Controls.Add(Me.btnAgregarFechas)
        Me.Panel3.Controls.Add(Me.gridFechas)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(11, 59)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(626, 140)
        Me.Panel3.TabIndex = 45
        '
        'cboMes
        '
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Location = New System.Drawing.Point(251, 23)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(168, 24)
        Me.cboMes.TabIndex = 32
        '
        'cboAnio
        '
        Me.cboAnio.FormattingEnabled = True
        Me.cboAnio.Location = New System.Drawing.Point(59, 23)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(121, 24)
        Me.cboAnio.TabIndex = 31
        '
        'btnAgregarTipoNomina
        '
        Me.btnAgregarTipoNomina.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarTipoNomina.Location = New System.Drawing.Point(519, 48)
        Me.btnAgregarTipoNomina.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarTipoNomina.Name = "btnAgregarTipoNomina"
        Me.btnAgregarTipoNomina.Size = New System.Drawing.Size(92, 28)
        Me.btnAgregarTipoNomina.TabIndex = 26
        Me.btnAgregarTipoNomina.Text = "Agregar"
        Me.btnAgregarTipoNomina.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnEliminarTipoNomina)
        Me.Panel4.Controls.Add(Me.btnAgregarTipoNomina)
        Me.Panel4.Controls.Add(Me.gridTipoNomina)
        Me.Panel4.Location = New System.Drawing.Point(11, 223)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(626, 132)
        Me.Panel4.TabIndex = 46
        '
        'btnEliminarTipoNomina
        '
        Me.btnEliminarTipoNomina.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarTipoNomina.Location = New System.Drawing.Point(519, 84)
        Me.btnEliminarTipoNomina.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarTipoNomina.Name = "btnEliminarTipoNomina"
        Me.btnEliminarTipoNomina.Size = New System.Drawing.Size(92, 28)
        Me.btnEliminarTipoNomina.TabIndex = 27
        Me.btnEliminarTipoNomina.Text = "Eliminar"
        Me.btnEliminarTipoNomina.UseVisualStyleBackColor = False
        '
        'gridTipoNomina
        '
        Me.gridTipoNomina.AllowUserToAddRows = False
        Me.gridTipoNomina.AllowUserToDeleteRows = False
        Me.gridTipoNomina.AllowUserToResizeColumns = False
        Me.gridTipoNomina.AllowUserToResizeRows = False
        Me.gridTipoNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTipoNomina.Location = New System.Drawing.Point(17, 22)
        Me.gridTipoNomina.Margin = New System.Windows.Forms.Padding(4)
        Me.gridTipoNomina.MultiSelect = False
        Me.gridTipoNomina.Name = "gridTipoNomina"
        Me.gridTipoNomina.ReadOnly = True
        Me.gridTipoNomina.RowHeadersVisible = False
        Me.gridTipoNomina.RowHeadersWidth = 51
        Me.gridTipoNomina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridTipoNomina.Size = New System.Drawing.Size(485, 97)
        Me.gridTipoNomina.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Fechas:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-1, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(651, 39)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "     Definición de filtro"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 368)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Lista conceptos"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnEliminarConcepto)
        Me.Panel2.Controls.Add(Me.btnAgregarConcepto)
        Me.Panel2.Controls.Add(Me.gridListaConceptos)
        Me.Panel2.Location = New System.Drawing.Point(11, 378)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(626, 172)
        Me.Panel2.TabIndex = 49
        '
        'btnEliminarConcepto
        '
        Me.btnEliminarConcepto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarConcepto.Location = New System.Drawing.Point(519, 84)
        Me.btnEliminarConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarConcepto.Name = "btnEliminarConcepto"
        Me.btnEliminarConcepto.Size = New System.Drawing.Size(92, 28)
        Me.btnEliminarConcepto.TabIndex = 27
        Me.btnEliminarConcepto.Text = "Eliminar"
        Me.btnEliminarConcepto.UseVisualStyleBackColor = False
        '
        'btnAgregarConcepto
        '
        Me.btnAgregarConcepto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAgregarConcepto.Location = New System.Drawing.Point(519, 48)
        Me.btnAgregarConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarConcepto.Name = "btnAgregarConcepto"
        Me.btnAgregarConcepto.Size = New System.Drawing.Size(92, 28)
        Me.btnAgregarConcepto.TabIndex = 26
        Me.btnAgregarConcepto.Text = "Agregar"
        Me.btnAgregarConcepto.UseVisualStyleBackColor = False
        '
        'gridListaConceptos
        '
        Me.gridListaConceptos.AllowUserToAddRows = False
        Me.gridListaConceptos.AllowUserToDeleteRows = False
        Me.gridListaConceptos.AllowUserToResizeColumns = False
        Me.gridListaConceptos.AllowUserToResizeRows = False
        Me.gridListaConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListaConceptos.Location = New System.Drawing.Point(17, 22)
        Me.gridListaConceptos.Margin = New System.Windows.Forms.Padding(4)
        Me.gridListaConceptos.MultiSelect = False
        Me.gridListaConceptos.Name = "gridListaConceptos"
        Me.gridListaConceptos.ReadOnly = True
        Me.gridListaConceptos.RowHeadersVisible = False
        Me.gridListaConceptos.RowHeadersWidth = 51
        Me.gridListaConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridListaConceptos.Size = New System.Drawing.Size(485, 138)
        Me.gridListaConceptos.TabIndex = 25
        '
        'FrmReportePlanillaMensual_filtros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(649, 606)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReportePlanillaMensual_filtros"
        Me.Text = "  Definición de filtro"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.gridTipoNomina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.gridListaConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAcepar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAgregarFechas As Button
    Friend WithEvents gridFechas As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnAgregarTipoNomina As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnEliminarTipoNomina As Button
    Friend WithEvents gridTipoNomina As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboMes As ComboBox
    Friend WithEvents cboAnio As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnEliminarConcepto As Button
    Friend WithEvents btnAgregarConcepto As Button
    Friend WithEvents gridListaConceptos As DataGridView
End Class
