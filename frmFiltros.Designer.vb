<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltros))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cboCampo = New System.Windows.Forms.ComboBox()
        Me.cboOperador = New System.Windows.Forms.ComboBox()
        Me.cboAndOr = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboBoolean = New System.Windows.Forms.ComboBox()
        Me.txtTextBox = New System.Windows.Forms.TextBox()
        Me.dtDateTime = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 75)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(486, 130)
        Me.DataGridView1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(486, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSalir.Size = New System.Drawing.Size(69, 22)
        Me.btnSalir.Text = "&Cancelar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripButton1.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripButton1.Text = "&Aceptar"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 210)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(486, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 62
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(440, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(422, 48)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(58, 23)
        Me.btnAdd.TabIndex = 63
        Me.btnAdd.Text = "Agreg"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'cboCampo
        '
        Me.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCampo.FormattingEnabled = True
        Me.cboCampo.Location = New System.Drawing.Point(6, 50)
        Me.cboCampo.Name = "cboCampo"
        Me.cboCampo.Size = New System.Drawing.Size(131, 21)
        Me.cboCampo.TabIndex = 64
        '
        'cboOperador
        '
        Me.cboOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperador.FormattingEnabled = True
        Me.cboOperador.Items.AddRange(New Object() {"", "<", ">", "=", "<>"})
        Me.cboOperador.Location = New System.Drawing.Point(141, 50)
        Me.cboOperador.Name = "cboOperador"
        Me.cboOperador.Size = New System.Drawing.Size(46, 21)
        Me.cboOperador.TabIndex = 65
        '
        'cboAndOr
        '
        Me.cboAndOr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAndOr.FormattingEnabled = True
        Me.cboAndOr.Items.AddRange(New Object() {"", "AND", "OR"})
        Me.cboAndOr.Location = New System.Drawing.Point(359, 50)
        Me.cboAndOr.Name = "cboAndOr"
        Me.cboAndOr.Size = New System.Drawing.Size(58, 21)
        Me.cboAndOr.TabIndex = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "CAMPO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(138, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "OPERAD"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(191, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "DATO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(363, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "AND/OR"
        '
        'cboBoolean
        '
        Me.cboBoolean.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBoolean.FormattingEnabled = True
        Me.cboBoolean.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboBoolean.Location = New System.Drawing.Point(194, 50)
        Me.cboBoolean.Name = "cboBoolean"
        Me.cboBoolean.Size = New System.Drawing.Size(159, 21)
        Me.cboBoolean.TabIndex = 72
        '
        'txtTextBox
        '
        Me.txtTextBox.Location = New System.Drawing.Point(193, 50)
        Me.txtTextBox.Name = "txtTextBox"
        Me.txtTextBox.Size = New System.Drawing.Size(160, 20)
        Me.txtTextBox.TabIndex = 73
        '
        'dtDateTime
        '
        Me.dtDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDateTime.Location = New System.Drawing.Point(194, 51)
        Me.dtDateTime.Name = "dtDateTime"
        Me.dtDateTime.Size = New System.Drawing.Size(159, 20)
        Me.dtDateTime.TabIndex = 74
        Me.dtDateTime.Visible = False
        '
        'frmFiltros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(486, 232)
        Me.Controls.Add(Me.dtDateTime)
        Me.Controls.Add(Me.txtTextBox)
        Me.Controls.Add(Me.cboBoolean)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboAndOr)
        Me.Controls.Add(Me.cboOperador)
        Me.Controls.Add(Me.cboCampo)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CREAR FILTROS"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cboCampo As System.Windows.Forms.ComboBox
    Friend WithEvents cboOperador As System.Windows.Forms.ComboBox
    Friend WithEvents cboAndOr As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBoolean As System.Windows.Forms.ComboBox
    Friend WithEvents txtTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dtDateTime As System.Windows.Forms.DateTimePicker
End Class
