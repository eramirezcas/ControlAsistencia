Public Class frmRHCCapturaHuellaDigitalDetalle
    '**********************************************************************************************************************
    '**********************************************************************************************************************
    Inherits frmClaseCapturaHuellaDigital

    Public Event OnTemplate(ByVal template)

    Private Enroller As DPFP.Processing.Enrollment

    Protected Overrides Sub Init()
        MyBase.Init()
        MyBase.Text = "CAPTURA DE HUELLA DIGITAL"
        Enroller = New DPFP.Processing.Enrollment()     ' Create an enrollment.
        UpdateStatus()
    End Sub

    Protected Overrides Sub Process(ByVal Sample As DPFP.Sample)
        MyBase.Process(Sample)

        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)

        ' Check quality of the sample and add to enroller if it's good
        If (Not features Is Nothing) Then
            Try
                MakeReport("Plantilla para huella creada.")
                Enroller.AddFeatures(features)        ' Add feature set to template.
            Finally
                UpdateStatus()

                ' Check if template has been created.
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready    ' Report success and stop capturing
                        RaiseEvent OnTemplate(Enroller.Template)
                        SetPrompt("Huella lista para verificacion.")
                        StopCapture()

                    Case DPFP.Processing.Enrollment.Status.Failed   ' Report failure and restart capturing
                        Enroller.Clear()
                        StopCapture()
                        RaiseEvent OnTemplate(Nothing)
                        StartCapture()

                End Select
            End Try
        End If
    End Sub

    Protected Sub UpdateStatus()
        ' Show number of samples needed.
        SetStatus(String.Format("Cantidad de huellas requeridas: {0}", Enroller.FeaturesNeeded))
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs)
        Close()
    End Sub

End Class