<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMensage))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pbIcono = New System.Windows.Forms.PictureBox()
        Me.lblMensage = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pbIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(609, 55)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(510, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "No"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(411, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Si"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pbIcono
        '
        Me.pbIcono.Image = CType(resources.GetObject("pbIcono.Image"), System.Drawing.Image)
        Me.pbIcono.Location = New System.Drawing.Point(12, 12)
        Me.pbIcono.Name = "pbIcono"
        Me.pbIcono.Size = New System.Drawing.Size(80, 80)
        Me.pbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIcono.TabIndex = 1
        Me.pbIcono.TabStop = False
        '
        'lblMensage
        '
        Me.lblMensage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensage.Location = New System.Drawing.Point(103, 9)
        Me.lblMensage.Name = "lblMensage"
        Me.lblMensage.Size = New System.Drawing.Size(497, 105)
        Me.lblMensage.TabIndex = 2
        Me.lblMensage.Text = "Label1"
        '
        'frmMensage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(607, 173)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMensage)
        Me.Controls.Add(Me.pbIcono)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmMensage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMensage"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbIcono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pbIcono As System.Windows.Forms.PictureBox
    Friend WithEvents lblMensage As System.Windows.Forms.Label
End Class
