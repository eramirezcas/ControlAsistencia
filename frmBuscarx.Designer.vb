<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarx))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cboCriterios = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDato = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblRegistro = New System.Windows.Forms.Label()
        Me.chkAutoAjust = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAcepar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 74)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(501, 277)
        Me.DataGridView1.TabIndex = 4
        '
        'cboCriterios
        '
        Me.cboCriterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCriterios.FormattingEnabled = True
        Me.cboCriterios.Location = New System.Drawing.Point(65, 46)
        Me.cboCriterios.Name = "cboCriterios"
        Me.cboCriterios.Size = New System.Drawing.Size(124, 21)
        Me.cboCriterios.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Buscar por:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(192, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Dato a buscar:"
        '
        'txtDato
        '
        Me.txtDato.Location = New System.Drawing.Point(271, 46)
        Me.txtDato.Name = "txtDato"
        Me.txtDato.Size = New System.Drawing.Size(158, 20)
        Me.txtDato.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.WindowsApplication1.My.Resources.Resources._127_EDIT_FIND
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(435, 45)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 23)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblRegistro
        '
        Me.lblRegistro.Location = New System.Drawing.Point(381, 356)
        Me.lblRegistro.Name = "lblRegistro"
        Me.lblRegistro.Size = New System.Drawing.Size(119, 13)
        Me.lblRegistro.TabIndex = 10
        Me.lblRegistro.Text = "Registro #000/000"
        Me.lblRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkAutoAjust
        '
        Me.chkAutoAjust.AutoSize = True
        Me.chkAutoAjust.Location = New System.Drawing.Point(2, 354)
        Me.chkAutoAjust.Name = "chkAutoAjust"
        Me.chkAutoAjust.Size = New System.Drawing.Size(83, 17)
        Me.chkAutoAjust.TabIndex = 11
        Me.chkAutoAjust.Text = "Auto A&justar"
        Me.chkAutoAjust.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(501, 39)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "BUSCAR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.btnAcepar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(0, 378)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(501, 36)
        Me.Panel1.TabIndex = 13
        '
        'btnAcepar
        '
        Me.btnAcepar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAcepar.Image = CType(resources.GetObject("btnAcepar.Image"), System.Drawing.Image)
        Me.btnAcepar.Location = New System.Drawing.Point(338, 6)
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
        Me.btnCancelar.Location = New System.Drawing.Point(419, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'frmBuscarx
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(501, 413)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkAutoAjust)
        Me.Controls.Add(Me.lblRegistro)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtDato)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCriterios)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCAR"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cboCriterios As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDato As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblRegistro As System.Windows.Forms.Label
    Friend WithEvents chkAutoAjust As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAcepar As Button
    Friend WithEvents btnCancelar As Button
End Class
