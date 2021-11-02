Public Class frmCargaMenuDia_Detalle
    Public frmOrigen As Form
    Public dt As DataTable
    Public pos As Integer, nuevo As Boolean
    Dim sourceDir As String
    Dim defadir As String = CType(cnx.SQLEXECESCALAR("select ruta_imagenes_menu as dir from tbl_control_alimentacion_parametros"), String)
    Dim fname As String
    Dim cancelado As Boolean

    Private Function valida_datos() As Boolean
        If txtImagen.Text = "" Then
            Return False
        ElseIf txtnom_archivo.Text = "" Then
            Return False
        ElseIf txtFecha.Text = "" Then
            Return False
        ElseIf chkActiva.Checked = False Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub frmCargaMenuDia_Detalle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If nuevo And cancelado And pos >= 0 Then
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        ElseIf nuevo And Not cancelado And pos >= 0 Then
            BindingContext(dt).Position = dt.Rows.Count - 1
        ElseIf Not nuevo And Not cancelado And pos >= 0 Then
            BindingContext(dt).Position = pos
        End If
        frmOrigen.Enabled = True
    End Sub

    Private Sub frmCargaMenuDia_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If nuevo Then
                dt.Rows.Add()
                pos = dt.Rows.Count - 1
                txtFecha.Text = Format(Now, "dd/MM/yyyy h:mm tt")
                imgPrevia.Image = Nothing
                chkActiva.Checked = True
            Else
                imgPrevia.Image = Image.FromFile(dt.Rows(pos).Item("imagen"))
            End If

            BindingContext(dt).Position = pos
            txtId.DataBindings.Add("Text", dt, "id_linea", True, DataSourceUpdateMode.Never, 0)
            txtImagen.DataBindings.Add("Text", dt, "nom_archivo", True, DataSourceUpdateMode.Never, 0)
            txtnom_archivo.DataBindings.Add("Text", dt, "imagen", True, DataSourceUpdateMode.Never, 0)
            txtFecha.DataBindings.Add("Text", dt, "fecha", True, DataSourceUpdateMode.Never, 0)
            chkActiva.DataBindings.Add("checked", dt, "activa", True, DataSourceUpdateMode.Never, False)

            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Try
            Dim oFD As New OpenFileDialog()

            oFD.InitialDirectory = "%USERPROFILE%"
            oFD.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            oFD.FilterIndex = 2
            oFD.RestoreDirectory = True

            If oFD.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtImagen.Text = oFD.SafeFileName
            txtnom_archivo.Text = defadir & oFD.SafeFileName
            imgPrevia.Image = Image.FromFile(oFD.FileName)
            sourceDir = System.IO.Path.GetDirectoryName(oFD.FileName)

            fname = "IMG_" & Now.Year.ToString.Trim & _
                    IIf(Now.Month.ToString.Length = 1, "0", "") & Now.Month.ToString.Trim & _
                    IIf(Now.Day.ToString.Length = 1, "0", "") & Now.Day.ToString.Trim & _
                    IIf(Now.Hour.ToString.Length = 1, "0", "") & Now.Hour.ToString.Trim & _
                    IIf(Now.Minute.ToString.Length = 1, "0", "") & Now.Minute.ToString.Trim & _
                    "." & txtImagen.Text.Substring(txtImagen.Text.Length - 3, 3)

            Me.Text = fname

            'System.IO.File.Copy( _
            '                 System.IO.Path.Combine(sourceDir, txtImagen.Text) _
            '                , System.IO.Path.Combine(defadir, oFD.SafeFileName) _
            ')

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            IO.File.Copy(sourceDir & "\" & txtImagen.Text.ToUpper.Trim(), defadir.ToUpper.Trim & fname.ToUpper.Trim, True)

            Dim strSQL As String = _
                "BEGIN TRY" & vbNewLine & _
                "BEGIN TRANSACTION" & vbNewLine & _
                "	SET NOCOUNT ON;" & vbNewLine & _
                "" & vbNewLine & _
                "	UPDATE tbl_control_alimentacion_imagenes SET activa = 0" & vbNewLine & _
                "	INSERT INTO tbl_control_alimentacion_imagenes(imagen,nom_archivo,activa,fecha)" & vbNewLine & _
                "	VALUES" & vbNewLine & _
                "	(" & vbNewLine & _
                "		 '" & defadir.ToUpper.Trim & fname.ToUpper.Trim() & "'" & vbNewLine & _
                "		,'" & fname.ToUpper.Trim() & "'" & vbNewLine & _
                "		,1" & vbNewLine & _
                "		,GETDATE()" & vbNewLine & _
                "	)" & vbNewLine & _
                "" & vbNewLine & _
                "END TRY" & vbNewLine & _
                "BEGIN CATCH" & vbNewLine & _
                "	IF @@TRANCOUNT > 0" & vbNewLine & _
                "		ROLLBACK TRANSACTION;" & vbNewLine & _
                "		DECLARE @ErrorMessage NVARCHAR(4000);" & vbNewLine & _
                "		DECLARE @ErrorSeverity INT;" & vbNewLine & _
                "		DECLARE @ErrorState INT;" & vbNewLine & _
                "" & vbNewLine & _
                "		SET @ErrorMessage = ERROR_MESSAGE()" & vbNewLine & _
                "		SET @ErrorSeverity = ERROR_SEVERITY()" & vbNewLine & _
                "		SET @ErrorState = ERROR_STATE();" & vbNewLine & _
                "" & vbNewLine & _
                "	    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);" & vbNewLine & _
                "END CATCH;" & vbNewLine & _
                "IF @@TRANCOUNT > 0" & vbNewLine & _
                "	COMMIT TRANSACTION;"
            cnx.SQLEXEC(strSQL)

            dt.Rows.Clear()
            strSQL = "SELECT id_linea,imagen,nom_archivo,activa,fecha" & vbNewLine & _
                     "FROM tbl_control_alimentacion_imagenes"
            cnx.SQLEXEC(dt, strSQL)
            dt.TableName = "tbl_control_alimentacion_caps"

            MessageBox.Show("Proceso realizado con éxito", "GUARDAR DATOS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cancelado = True
        Me.Close()
    End Sub
End Class