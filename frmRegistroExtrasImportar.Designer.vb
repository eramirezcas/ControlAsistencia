<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroExtrasImportar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroExtrasImportar))
        Me.gbProgreso = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.pctConReg = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._titulo1 = New WindowsApplication1._titulo()
        Me.pctSinReg = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pctConReg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctSinReg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbProgreso
        '
        Me.gbProgreso.Location = New System.Drawing.Point(7, 8)
        Me.gbProgreso.Name = "gbProgreso"
        Me.gbProgreso.Size = New System.Drawing.Size(227, 28)
        Me.gbProgreso.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnImportar)
        Me.Panel1.Controls.Add(Me.gbProgreso)
        Me.Panel1.Location = New System.Drawing.Point(0, 123)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 44)
        Me.Panel1.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(321, 11)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.Color.White
        Me.btnImportar.Location = New System.Drawing.Point(240, 11)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 2
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'pctConReg
        '
        Me.pctConReg.Image = CType(resources.GetObject("pctConReg.Image"), System.Drawing.Image)
        Me.pctConReg.Location = New System.Drawing.Point(12, 40)
        Me.pctConReg.Name = "pctConReg"
        Me.pctConReg.Size = New System.Drawing.Size(72, 74)
        Me.pctConReg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctConReg.TabIndex = 5
        Me.pctConReg.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 44)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Se van a importar ### registros de horas extra."
        '
        '_titulo1
        '
        Me._titulo1._foreColor = System.Drawing.Color.White
        Me._titulo1._text = "IMPORTAR REGISTROS APROBADOS"
        Me._titulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._titulo1.BackColor = System.Drawing.Color.Transparent
        Me._titulo1.Location = New System.Drawing.Point(-1, 0)
        Me._titulo1.Name = "_titulo1"
        Me._titulo1.Size = New System.Drawing.Size(409, 34)
        Me._titulo1.TabIndex = 4
        '
        'pctSinReg
        '
        Me.pctSinReg.Image = CType(resources.GetObject("pctSinReg.Image"), System.Drawing.Image)
        Me.pctSinReg.Location = New System.Drawing.Point(12, 40)
        Me.pctSinReg.Name = "pctSinReg"
        Me.pctSinReg.Size = New System.Drawing.Size(72, 74)
        Me.pctSinReg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctSinReg.TabIndex = 7
        Me.pctSinReg.TabStop = False
        '
        'frmRegistroExtrasImportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(408, 168)
        Me.Controls.Add(Me.pctSinReg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pctConReg)
        Me.Controls.Add(Me._titulo1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRegistroExtrasImportar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPORTAR REGISTROS APROBADOS POR RRHH"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pctConReg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctSinReg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents _titulo1 As WindowsApplication1._titulo
    Friend WithEvents pctConReg As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pctSinReg As System.Windows.Forms.PictureBox
End Class
