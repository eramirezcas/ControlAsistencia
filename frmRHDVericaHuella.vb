Public Class frmRHDVericaHuella
    Inherits frmClaseCapturaHuellaDigital
    Private Template As DPFP.Template
    Private Verificator As DPFP.Verification.Verification

    Public Sub Verify(ByVal template As DPFP.Template)
        Me.Template = template
        ShowDialog()
    End Sub

    Protected Overrides Sub Init()
        MyBase.Init()
        MyBase.Text = "VERIFICACIÓN DE HUELLA DIGITAL"
        Verificator = New DPFP.Verification.Verification
        UpdateStatus(0)
    End Sub

    Protected Overrides Sub Process(ByVal Sample As DPFP.Sample)
        MyBase.Process(Sample)

        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification)

        ' Check quality of the sample and start verification if it's good
        If Not features Is Nothing Then
            ' Compare the feature set with our template
            Dim result As DPFP.Verification.Verification.Result = New DPFP.Verification.Verification.Result()
            Verificator.Verify(features, Template, result)
            UpdateStatus(result.FARAchieved)
            If result.Verified Then
                MakeReport("Huella verificada con éxito.")
            Else
                MakeReport("Fallo la verificación de huella.")
            End If
        End If
    End Sub

    Protected Sub UpdateStatus(ByVal FAR As Integer)
        ' Show "False accept rate" value
        SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR))
    End Sub

End Class