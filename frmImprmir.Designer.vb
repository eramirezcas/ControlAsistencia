<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImprmir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImprmir))
        Me.crControl = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crControl
        '
        Me.crControl.ActiveViewIndex = -1
        Me.crControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.crControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crControl.Location = New System.Drawing.Point(0, 0)
        Me.crControl.Name = "crControl"
        Me.crControl.Size = New System.Drawing.Size(998, 529)
        Me.crControl.TabIndex = 0
        '
        'frmImprmir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(998, 529)
        Me.Controls.Add(Me.crControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmImprmir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VISTA DE IMPRESÓN"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crControl As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
