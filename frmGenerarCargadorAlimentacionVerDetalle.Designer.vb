<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarCargadorAlimentacionVerDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerarCargadorAlimentacionVerDetalle))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnExportaexcel = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 63)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(625, 318)
        Me.DataGridView1.TabIndex = 137
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, -1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(637, 32)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = " DETALLE DE COMPRA DE SERVICIOS DE ALIMENTACIÓN"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(-1, 390)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(638, 37)
        Me.Panel1.TabIndex = 134
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
        'btnExportaexcel
        '
        Me.btnExportaexcel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnExportaexcel.Image = CType(resources.GetObject("btnExportaexcel.Image"), System.Drawing.Image)
        Me.btnExportaexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaexcel.Location = New System.Drawing.Point(6, 34)
        Me.btnExportaexcel.Name = "btnExportaexcel"
        Me.btnExportaexcel.Size = New System.Drawing.Size(60, 23)
        Me.btnExportaexcel.TabIndex = 136
        Me.btnExportaexcel.Text = "Excel"
        Me.btnExportaexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportaexcel.UseVisualStyleBackColor = False
        '
        'frmGenerarCargadorAlimentacionVerDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(637, 427)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnExportaexcel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerarCargadorAlimentacionVerDetalle"
        Me.Text = " DETALLE DE COMPRA DE SERVICIOS DE ALIMENTACIÓN"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnExportaexcel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
