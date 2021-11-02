<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaseCapturaHuellaDigital
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClaseCapturaHuellaDigital))
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pbHuella = New System.Windows.Forms.PictureBox()
        Me.txtSucesos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.AutoSize = False
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSalir.Size = New System.Drawing.Size(75, 22)
        Me.btnSalir.Text = "&Salir"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(386, 25)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pbHuella)
        Me.GroupBox2.Controls.Add(Me.txtSucesos)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(373, 127)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'pbHuella
        '
        Me.pbHuella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbHuella.Location = New System.Drawing.Point(283, 27)
        Me.pbHuella.Name = "pbHuella"
        Me.pbHuella.Size = New System.Drawing.Size(82, 93)
        Me.pbHuella.TabIndex = 3
        Me.pbHuella.TabStop = False
        '
        'txtSucesos
        '
        Me.txtSucesos.Location = New System.Drawing.Point(9, 27)
        Me.txtSucesos.Multiline = True
        Me.txtSucesos.Name = "txtSucesos"
        Me.txtSucesos.ReadOnly = True
        Me.txtSucesos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSucesos.Size = New System.Drawing.Size(268, 93)
        Me.txtSucesos.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(306, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Huella"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Sucesos"
        '
        'frmCapturaHuellaDigital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(386, 159)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaHuellaDigital"
        Me.Text = "DATOS DE REGISTRO DE HUELLA DIGITAL"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents pbHuella As System.Windows.Forms.PictureBox
    Friend WithEvents txtSucesos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
