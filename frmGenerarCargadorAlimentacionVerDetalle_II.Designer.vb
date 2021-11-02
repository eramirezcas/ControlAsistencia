<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarCargadorAlimentacionVerDetalle_II
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerarCargadorAlimentacionVerDetalle_II))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnExportaexcel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(7, 131)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(625, 251)
        Me.DataGridView1.TabIndex = 141
        '
        'btnExportaexcel
        '
        Me.btnExportaexcel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnExportaexcel.Image = CType(resources.GetObject("btnExportaexcel.Image"), System.Drawing.Image)
        Me.btnExportaexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaexcel.Location = New System.Drawing.Point(341, 21)
        Me.btnExportaexcel.Name = "btnExportaexcel"
        Me.btnExportaexcel.Size = New System.Drawing.Size(60, 23)
        Me.btnExportaexcel.TabIndex = 140
        Me.btnExportaexcel.Text = "Excel"
        Me.btnExportaexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportaexcel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(637, 32)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = " DETALLE DE COMPRA DE SERVICIOS DE ALIMENTACIÓN"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(0, 391)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(638, 37)
        Me.Panel1.TabIndex = 138
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(558, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = " Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.btnExportaexcel)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 84)
        Me.GroupBox1.TabIndex = 142
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos personales"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(274, 21)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(66, 23)
        Me.btnLimpiar.TabIndex = 141
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(205, 21)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = " Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(88, 49)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(313, 20)
        Me.txtNombre.TabIndex = 2
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(88, 22)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(111, 20)
        Me.txtCodigo.TabIndex = 0
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
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Código:"
        '
        'frmGenerarCargadorAlimentacionVerDetalle_II
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(639, 429)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerarCargadorAlimentacionVerDetalle_II"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " DETALLE DE COMPRA DE SERVICIOS DE ALIMENTACIÓN"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnExportaexcel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
End Class
