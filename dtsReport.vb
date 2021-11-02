Partial Class dtsReport
    Partial Class tblEmpleadosSinHorarioDataTable

        Private Sub tblEmpleadosSinHorarioDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.SECCIONColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace dtsReportTableAdapters
    
    Partial Public Class JustifHistTableAdapter
    End Class
End Namespace
