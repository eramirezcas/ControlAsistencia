<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroExtrasListado_historico_x_periodos666
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroExtrasListado_historico_x_periodos666))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnFiltro = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnExportaexcel = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 66)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(625, 318)
        Me.DataGridView1.TabIndex = 145
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(-1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(637, 32)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = "GENERAR REPORTE DE EXTRAS "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFiltro
        '
        Me.btnFiltro.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnFiltro.Image = CType(resources.GetObject("btnFiltro.Image"), System.Drawing.Image)
        Me.btnFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFiltro.Location = New System.Drawing.Point(6, 37)
        Me.btnFiltro.Name = "btnFiltro"
        Me.btnFiltro.Size = New System.Drawing.Size(64, 23)
        Me.btnFiltro.TabIndex = 144
        Me.btnFiltro.Text = "Cargar"
        Me.btnFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFiltro.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(142, 37)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(68, 23)
        Me.btnLimpiar.TabIndex = 143
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnExportaexcel
        '
        Me.btnExportaexcel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnExportaexcel.Image = CType(resources.GetObject("btnExportaexcel.Image"), System.Drawing.Image)
        Me.btnExportaexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaexcel.Location = New System.Drawing.Point(76, 37)
        Me.btnExportaexcel.Name = "btnExportaexcel"
        Me.btnExportaexcel.Size = New System.Drawing.Size(60, 23)
        Me.btnExportaexcel.TabIndex = 142
        Me.btnExportaexcel.Text = "Excel"
        Me.btnExportaexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportaexcel.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(738, 447)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 25)
        Me.btnCancelar.TabIndex = 140
        Me.btnCancelar.Text = " Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'frmRegistroExtrasListado_historico_x_periodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 484)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnFiltro)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnExportaexcel)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label8)
        Me.Name = "frmRegistroExtrasListado_historico_x_periodos"
        Me.Text = "frmRegistroExtrasListado_historico_x_periodos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnFiltro As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnExportaexcel As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label8 As Label
End Class
