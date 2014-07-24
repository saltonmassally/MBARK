'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
'       Ross J. Micheals (rossm@nist.gov)
'       Kayee Kwong (kayee@nist.gov)
'
' •—————————————————————————————————————————————————————————————————————————————————————————————————————•
' | LICENSE & DISCLAIMER                                                                                |
' |                                                                                                     |
' | This software was developed at the National Institute of Standards and Technology (NIST) by         |
' | employees of the Federal Government in the course of their official duties. Pursuant to title 17    |
' | Section 105 of the United States Code. This software is not subject to copyright protection and     |
' | is in the public domain. NIST assumes no responsibility whatsoever for use by other parties of      |
' | its source code or open source server, and makes no guarantees, expressed or implied, about its     |
' | quality, reliability, or any other characteristic.                                                  |
' |                                                                                                     |
' | Specific hardware and software products identified in this open source project were used in order   |
' | to perform technology transfer and collaboration. In no case does such identification imply         |
' | recommendation or endorsement by the National Institute of Standards and Technology, nor            |
' | does it imply that the products and equipment identified are necessarily the best available for the |
' | purpose.                                                                                            |
' •—————————————————————————————————————————————————————————————————————————————————————————————————————•

Option Strict On

Imports System.Xml.Serialization

Imports Mbark
Imports Mbark.Sensors

Public Class VirtualSensorController
    Inherits BaseSensorController

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        Me.AutomaticallyStartNewTaskSet = False
        Loader = New BiCCLLoader
        MyBase.OnLoad(e)
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
    End Sub

    Public WithEvents mScenarioPicker As ScenarioPicker
    Protected Overrides Sub OnAwaitingStartOfNewTaskSet()

        GetVirtualSensorControllerSettings()

        If mVirtualSensorSettings.ShowScenarioPicker Then
            mScenarioPicker = New ScenarioPicker
            AddHandler mScenarioPicker.GoButton.Click, AddressOf ScenarioPickerGoButton_Click
            AddHandler mScenarioPicker.ExitButton.Click, AddressOf ScenarioPickerExitButton_Click
            Me.Enabled = False

            With mScenarioPicker
                .Visible = False
                .Show(Me)
                .BringToFront()
                .DesktopLocation = UI.LocationForCenteringChildForm(Me, mScenarioPicker)
                .Visible = True
            End With
        Else
            SetFaceProbabilities()
            SetFingerProbabilities()
            SetIrisProbabilities()

            SetScenarioProperties()

            Me.Enabled = True
            StartNewTaskSet()
        End If


    End Sub

    Private mVirtualSensorControllerSettingsFile As String = "VirtualSensorController-Settings.xml"
    Private mVirtualSensorSettings As VirtualSensorControllerSettings
    Private Shared smSettingsSerializer As New XmlSerializer(GetType(VirtualSensorControllerSettings))

    Private Sub GetVirtualSensorControllerSettings()
        ' By default, use the initial settings file
        Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
        Dim finalFilename As String = IO.Path.Combine(baseDir, mVirtualSensorControllerSettingsFile)

        ' However, if a local settings file exists, use that one instead.
        Dim localSettingsPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Dim localSettingsFileName As String = IO.Path.Combine(localSettingsPath, mVirtualSensorControllerSettingsFile)
        If IO.File.Exists(localSettingsFileName) Then
            finalFilename = localSettingsFileName
        End If

        Dim settingsfile As New IO.FileStream(finalFilename, IO.FileMode.Open)
        mVirtualSensorSettings = DirectCast(smSettingsSerializer.Deserialize(settingsfile), VirtualSensorControllerSettings)
        settingsfile.Close()
    End Sub

    Private FaceInitTimeout As Decimal ' = 0.25D
    Private FaceCaptureFailure As Decimal '= 1
    Private FaceDownloadTimeout As Decimal '= 1
    Private FaceDownloadFailure As Decimal
    Private FaceInitFailure As Decimal

    Private FingerprintInitTimeout As Decimal '= 0.25D
    Private FingerprintInitFailure As Decimal '= 0.8D
    Private FingerprintCaptureFailure As Decimal '= 0.8D
    Private FingerprintCaptureTimeout As Decimal

    Private IrisInitTimeout As Decimal '= 0.25D
    Private IrisInitFailure As Decimal '= 0.8D
    Private IrisCaptureFailure As Decimal
    Private IrisCaptureTimeout As Decimal

    Private Sub ScenarioPickerExitButton_Click(ByVal sender As Object, ByVal events As EventArgs)
        Me.Close()
    End Sub

    Private Sub ScenarioPickerGoButton_Click(ByVal sender As Object, ByVal events As EventArgs)


        SetFaceProbabilities(mScenarioPicker.FaceScenario)
        SetFingerProbabilities(mScenarioPicker.FingerScenario)
        SetIrisProbabilities(mScenarioPicker.IrisScenario)

        'For m As Integer = 0 To Sensors.Count - 1
        '    Dim vSensor As BaseVirtualSensor = DirectCast(Sensors(m), BaseVirtualSensor)
        '    Dim mNewConfiguration As VirtualSensorsConfiguration = New VirtualSensorsConfiguration
        '    Dim InitOperationBehavior As New VirtualSensorOperationBehavior

        '    Select Case vSensor.Modality
        '        Case SensorModality.Face
        '            mNewConfiguration.CaptureOperationBehavior.ProbabilityOfFailure = FaceCaptureFailure
        '            With mNewConfiguration.DownloadOperationBehavior
        '                .ProbabilityOfTimeout = FaceDownloadTimeout
        '                .ProbabilityOfFailure = FaceDownloadFailure
        '                .Timeout = vSensor.DownloadCommandTemplate.ExpirationTime

        '            End With


        '            With InitOperationBehavior

        '                .Wait.ShortTime = 2000
        '                .Wait.LongTime = 5000
        '                .Wait.ProbOfLongWait = 0
        '                .InvocationStyle = VirtualSensorInvocationStyle.Synchronous
        '                .Timeout = InitOperationBehavior.Wait.BetweenShortAndLongTime(0.5)
        '                .ProbabilityOfFailure = FaceInitFailure
        '                .ProbabilityOfTimeout = FaceInitTimeout
        '            End With

        '        Case SensorModality.Fingerprint
        '            With mNewConfiguration.CaptureOperationBehavior
        '                .ProbabilityOfFailure = FingerprintCaptureFailure
        '                .Timeout = vSensor.CaptureCommandTemplate.ExpirationTime
        '                .ProbabilityOfTimeout = FingerprintCaptureTimeout
        '            End With


        '            With InitOperationBehavior
        '                .Wait.ShortTime = 200
        '                .Wait.LongTime = 12000
        '                .Wait.ProbOfLongWait = 0
        '                .InvocationStyle = VirtualSensorInvocationStyle.Synchronous
        '                .Timeout = InitOperationBehavior.Wait.BetweenShortAndLongTime(1.0)
        '                .ProbabilityOfFailure = FingerprintInitFailure
        '                .ProbabilityOfTimeout = FingerprintInitTimeout
        '            End With

        '        Case SensorModality.Iris
        '            With mNewConfiguration.CaptureOperationBehavior
        '                .ProbabilityOfFailure = IrisCaptureFailure
        '                .Timeout = vSensor.CaptureCommandTemplate.ExpirationTime
        '                .ProbabilityOfTimeout = IrisCaptureTimeout
        '            End With

        '            With InitOperationBehavior
        '                .Wait.ShortTime = 300
        '                .Wait.LongTime = 13000
        '                .Wait.ProbOfLongWait = 0
        '                .InvocationStyle = VirtualSensorInvocationStyle.Synchronous
        '                .Timeout = InitOperationBehavior.Wait.BetweenShortAndLongTime(1.0)
        '                .ProbabilityOfFailure = IrisInitFailure
        '                .ProbabilityOfTimeout = IrisInitTimeout
        '            End With

        '    End Select

        '    For x As Integer = 0 To Me.TaskFactories.Count - 1
        '        If TaskFactories(x).Sensor.FriendlyName = vSensor.FriendlyName Then
        '            Dim vConfiguration As VirtualSensorsConfiguration = CType(TaskFactories(x).SensorConfiguration, VirtualSensorsConfiguration)
        '            mNewConfiguration.CaptureOperationBehavior.Wait = vConfiguration.CaptureOperationBehavior.Wait
        '            mNewConfiguration.DownloadOperationBehavior.Wait = vConfiguration.DownloadOperationBehavior.Wait
        '            TaskFactories(x).SensorConfiguration = mNewConfiguration
        '        End If
        '    Next

        '    Dim InitObj() As Object = {InitOperationBehavior}
        '    vSensor.InitializationCommandTemplate.TargetMethodArgs(InitObj)
        'Next

        SetScenarioProperties()

        mScenarioPicker.Close()
        mScenarioPicker.Dispose()
        mScenarioPicker = Nothing
        Me.Enabled = True
        StartNewTaskSet()
    End Sub

    Private Sub SetScenarioProperties()
        For m As Integer = 0 To Sensors.Count - 1
            Dim vSensor As BaseVirtualSensor = DirectCast(Sensors(m), BaseVirtualSensor)
            Dim mNewConfiguration As VirtualSensorsConfiguration = New VirtualSensorsConfiguration
            Dim InitOperationBehavior As New VirtualSensorOperationBehavior

            Select Case vSensor.Modality
                Case SensorModality.Face
                    mNewConfiguration.CaptureOperationBehavior.ProbabilityOfFailure = FaceCaptureFailure
                    With mNewConfiguration.DownloadOperationBehavior
                        .ProbabilityOfTimeout = FaceDownloadTimeout
                        .ProbabilityOfFailure = FaceDownloadFailure
                        .Timeout = vSensor.DownloadCommandTemplate.ExpirationTime

                    End With


                    With InitOperationBehavior

                        .Wait.ShortTime = 2000
                        .Wait.LongTime = 5000
                        .Wait.ProbOfLongWait = 0
                        .InvocationStyle = VirtualSensorInvocationStyle.Synchronous
                        .Timeout = InitOperationBehavior.Wait.BetweenShortAndLongTime(0.5)
                        .ProbabilityOfFailure = FaceInitFailure
                        .ProbabilityOfTimeout = FaceInitTimeout
                    End With

                Case SensorModality.Fingerprint
                    With mNewConfiguration.CaptureOperationBehavior
                        .ProbabilityOfFailure = FingerprintCaptureFailure
                        .Timeout = vSensor.CaptureCommandTemplate.ExpirationTime
                        .ProbabilityOfTimeout = FingerprintCaptureTimeout
                    End With


                    With InitOperationBehavior
                        .Wait.ShortTime = 200
                        .Wait.LongTime = 12000
                        .Wait.ProbOfLongWait = 0
                        .InvocationStyle = VirtualSensorInvocationStyle.Synchronous
                        .Timeout = InitOperationBehavior.Wait.BetweenShortAndLongTime(1.0)
                        .ProbabilityOfFailure = FingerprintInitFailure
                        .ProbabilityOfTimeout = FingerprintInitTimeout
                    End With

                Case SensorModality.Iris
                    With mNewConfiguration.CaptureOperationBehavior
                        .ProbabilityOfFailure = IrisCaptureFailure
                        .Timeout = vSensor.CaptureCommandTemplate.ExpirationTime
                        .ProbabilityOfTimeout = IrisCaptureTimeout
                    End With

                    With InitOperationBehavior
                        .Wait.ShortTime = 300
                        .Wait.LongTime = 13000
                        .Wait.ProbOfLongWait = 0
                        .InvocationStyle = VirtualSensorInvocationStyle.Synchronous
                        .Timeout = InitOperationBehavior.Wait.BetweenShortAndLongTime(1.0)
                        .ProbabilityOfFailure = IrisInitFailure
                        .ProbabilityOfTimeout = IrisInitTimeout
                    End With

            End Select

            For x As Integer = 0 To Me.TaskFactories.Count - 1
                If TaskFactories(x).Sensor.FriendlyName = vSensor.FriendlyName Then
                    Dim vConfiguration As VirtualSensorsConfiguration = CType(TaskFactories(x).SensorConfiguration, VirtualSensorsConfiguration)
                    mNewConfiguration.CaptureOperationBehavior.Wait = vConfiguration.CaptureOperationBehavior.Wait
                    mNewConfiguration.DownloadOperationBehavior.Wait = vConfiguration.DownloadOperationBehavior.Wait
                    TaskFactories(x).SensorConfiguration = mNewConfiguration
                End If
            Next

            Dim InitObj() As Object = {InitOperationBehavior}
            vSensor.InitializationCommandTemplate.TargetMethodArgs(InitObj)
        Next
    End Sub

    Protected Overrides Sub OnActivated(ByVal e As EventArgs)
        MyBase.OnActivated(e)
        If Not mScenarioPicker Is Nothing Then mScenarioPicker.BringToFront()
    End Sub

    Private Sub SetFaceProbabilities()
        Dim SelectedScenario As ScenarioPicker.Scenarios = CType(mVirtualSensorSettings.FaceScenario, ScenarioPicker.Scenarios)
        Dim FailureType As ScenarioPicker.FailureType
        If SelectedScenario <> ScenarioPicker.Scenarios.AllOkay Then
            FailureType = CType(mVirtualSensorSettings.FaceFailureType, ScenarioPicker.FailureType)
        End If

        ImplementationSetFaceProbabilities(SelectedScenario, FailureType)
    End Sub

    Private Sub SetFaceProbabilities(ByVal FaceScenario As ArrayList)
        Dim SelectedScenario As ScenarioPicker.Scenarios = CType(FaceScenario(0), ScenarioPicker.Scenarios)
        Dim FailureType As ScenarioPicker.FailureType
        If FaceScenario.Count > 1 Then FailureType = CType(FaceScenario(1), ScenarioPicker.FailureType)

        ImplementationSetFaceProbabilities(SelectedScenario, FailureType)
    End Sub

    Private Sub ImplementationSetFaceProbabilities(ByVal SelectedScenario As ScenarioPicker.Scenarios, ByVal FailureType As ScenarioPicker.FailureType)
        Select Case SelectedScenario
            Case ScenarioPicker.Scenarios.AllOkay
                FaceInitTimeout = 0
                FaceInitFailure = 0
                FaceCaptureFailure = 0
                FaceDownloadTimeout = 0
                FaceDownloadFailure = 0

            Case ScenarioPicker.Scenarios.AlwaysHaveFailure
                If FailureType = ScenarioPicker.FailureType.Capture Then FaceCaptureFailure = 1D
                If FailureType = ScenarioPicker.FailureType.Download Then FaceDownloadFailure = 1D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FaceInitFailure = 1D

            Case ScenarioPicker.Scenarios.AlwaysHaveTimeout
                If FailureType = ScenarioPicker.FailureType.Download Then FaceDownloadTimeout = 1

            Case ScenarioPicker.Scenarios.HaveHighFailureRate
                If FailureType = ScenarioPicker.FailureType.Capture Then FaceCaptureFailure = 0.8D
                If FailureType = ScenarioPicker.FailureType.Download Then FaceDownloadFailure = 0.8D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FaceInitFailure = 0.8D

            Case ScenarioPicker.Scenarios.HaveHighTimeoutRate
                If FailureType = ScenarioPicker.FailureType.Download Then FaceDownloadTimeout = 0.8D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FaceInitTimeout = 0.8D

            Case ScenarioPicker.Scenarios.HaveRandomFailure
                If FailureType = ScenarioPicker.FailureType.Capture Then FaceCaptureFailure = 0.25D
                If FailureType = ScenarioPicker.FailureType.Download Then FaceDownloadFailure = 0.25D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FaceInitFailure = 0.25D

            Case ScenarioPicker.Scenarios.HaveRandomTimeout
                If FailureType = ScenarioPicker.FailureType.Download Then FaceDownloadTimeout = 0.25D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FaceInitTimeout = 0.25D
        End Select
    End Sub

    Private Sub SetFingerProbabilities()
        Dim SelectedScenario As ScenarioPicker.Scenarios = CType(mVirtualSensorSettings.FingerprintScenario, ScenarioPicker.Scenarios)
        Dim FailureType As ScenarioPicker.FailureType
        If SelectedScenario <> ScenarioPicker.Scenarios.AllOkay Then
            FailureType = CType(mVirtualSensorSettings.FingerprintFailureType, ScenarioPicker.FailureType)
        End If

        ImplementationSetFingerProbabilities(SelectedScenario, FailureType)
    End Sub

    Private Sub SetFingerProbabilities(ByVal FingerScenario As ArrayList)
        Dim SelectedScenario As ScenarioPicker.Scenarios = CType(FingerScenario(0), ScenarioPicker.Scenarios)
        Dim FailureType As ScenarioPicker.FailureType
        If FingerScenario.Count > 1 Then FailureType = CType(FingerScenario(1), ScenarioPicker.FailureType)

        ImplementationSetFingerProbabilities(SelectedScenario, FailureType)
    End Sub

    Private Sub ImplementationSetFingerProbabilities(ByVal SelectedScenario As ScenarioPicker.Scenarios, ByVal FailureType As ScenarioPicker.FailureType)
        Select Case SelectedScenario
            Case ScenarioPicker.Scenarios.AllOkay
                FingerprintInitTimeout = 0
                FingerprintInitFailure = 0
                FingerprintCaptureFailure = 0
                FingerprintCaptureTimeout = 0

            Case ScenarioPicker.Scenarios.AlwaysHaveFailure
                If FailureType = ScenarioPicker.FailureType.Capture Then FingerprintCaptureFailure = 1D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FingerprintInitFailure = 1D

            Case ScenarioPicker.Scenarios.AlwaysHaveTimeout
                If FailureType = ScenarioPicker.FailureType.Capture Then FingerprintCaptureTimeout = 1D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FingerprintInitTimeout = 1D

            Case ScenarioPicker.Scenarios.HaveHighFailureRate
                If FailureType = ScenarioPicker.FailureType.Capture Then FingerprintCaptureFailure = 0.8D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FingerprintInitFailure = 0.8D

            Case ScenarioPicker.Scenarios.HaveHighTimeoutRate
                If FailureType = ScenarioPicker.FailureType.Capture Then FingerprintCaptureTimeout = 0.8D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FingerprintInitTimeout = 0.8D

            Case ScenarioPicker.Scenarios.HaveRandomFailure
                If FailureType = ScenarioPicker.FailureType.Capture Then FingerprintCaptureFailure = 0.25D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FingerprintInitFailure = 0.25D

            Case ScenarioPicker.Scenarios.HaveRandomTimeout
                If FailureType = ScenarioPicker.FailureType.Capture Then FingerprintCaptureTimeout = 0.25D
                If FailureType = ScenarioPicker.FailureType.Initialize Then FingerprintInitTimeout = 0.25D
        End Select
    End Sub

    Private Sub SetIrisProbabilities()
        Dim SelectedScenario As ScenarioPicker.Scenarios = CType(mVirtualSensorSettings.IrisScenario, ScenarioPicker.Scenarios)
        Dim FailureType As ScenarioPicker.FailureType
        If SelectedScenario <> ScenarioPicker.Scenarios.AllOkay Then
            FailureType = CType(mVirtualSensorSettings.IrisFailureType, ScenarioPicker.FailureType)
        End If
        ImplementationSetIrisProbilities(SelectedScenario, FailureType)
    End Sub

    Private Sub SetIrisProbabilities(ByVal IrisScenario As ArrayList)
        Dim SelectedScenario As ScenarioPicker.Scenarios = CType(IrisScenario(0), ScenarioPicker.Scenarios)
        Dim FailureType As ScenarioPicker.FailureType
        If IrisScenario.Count > 1 Then FailureType = CType(IrisScenario(1), ScenarioPicker.FailureType)

        ImplementationSetIrisProbilities(SelectedScenario, FailureType)
    End Sub

    Private Sub ImplementationSetIrisProbilities(ByVal SelectedScenario As ScenarioPicker.Scenarios, ByVal FailureType As ScenarioPicker.FailureType)
        Select Case SelectedScenario
            Case ScenarioPicker.Scenarios.AllOkay
                IrisInitTimeout = 0
                IrisInitFailure = 0
                IrisCaptureFailure = 0
                IrisCaptureTimeout = 0

            Case ScenarioPicker.Scenarios.AlwaysHaveFailure
                If FailureType = ScenarioPicker.FailureType.Capture Then IrisCaptureFailure = 1D
                If FailureType = ScenarioPicker.FailureType.Initialize Then IrisInitFailure = 1D

            Case ScenarioPicker.Scenarios.AlwaysHaveTimeout
                If FailureType = ScenarioPicker.FailureType.Capture Then IrisCaptureTimeout = 1D
                If FailureType = ScenarioPicker.FailureType.Initialize Then IrisInitTimeout = 1D

            Case ScenarioPicker.Scenarios.HaveHighFailureRate
                If FailureType = ScenarioPicker.FailureType.Capture Then IrisCaptureFailure = 0.8D
                If FailureType = ScenarioPicker.FailureType.Initialize Then IrisInitFailure = 0.8D

            Case ScenarioPicker.Scenarios.HaveHighTimeoutRate
                If FailureType = ScenarioPicker.FailureType.Capture Then IrisCaptureTimeout = 0.8D
                If FailureType = ScenarioPicker.FailureType.Initialize Then IrisInitTimeout = 0.8D

            Case ScenarioPicker.Scenarios.HaveRandomFailure
                If FailureType = ScenarioPicker.FailureType.Capture Then IrisCaptureFailure = 0.25D
                If FailureType = ScenarioPicker.FailureType.Initialize Then IrisInitFailure = 0.25D

            Case ScenarioPicker.Scenarios.HaveRandomTimeout
                If FailureType = ScenarioPicker.FailureType.Capture Then IrisCaptureTimeout = 0.25D
                If FailureType = ScenarioPicker.FailureType.Initialize Then IrisInitTimeout = 0.25D
        End Select
    End Sub






    Private Sub InitializeComponent()
        CType(Me.SensorPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VirtualSensorController
        '
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Name = "VirtualSensorController"
        Me.Text = "MBARK - Virtual Sensor Demo"
        CType(Me.SensorPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

    End Sub
End Class

<Serializable()> Public Class VirtualSensorControllerSettings

    Private mShowScenarioPicker As Boolean = True
    Public Property ShowScenarioPicker() As Boolean
        Get
            Return mShowScenarioPicker
        End Get
        Set(ByVal value As Boolean)
            mShowScenarioPicker = value
        End Set
    End Property



    Private mFaceScenario As ScenarioPicker.Scenarios
    Public Property FaceScenario() As ScenarioPicker.Scenarios
        Get
            Return mFaceScenario
        End Get
        Set(ByVal value As ScenarioPicker.Scenarios)
            mFaceScenario = value
        End Set
    End Property

    Private mFaceFailureType As ScenarioPicker.FailureType
    Public Property FaceFailureType() As ScenarioPicker.FailureType
        Get
            Return mFaceFailureType
        End Get
        Set(ByVal value As ScenarioPicker.FailureType)
            mFaceFailureType = value
        End Set
    End Property

    Private mFingerprintScenario As ScenarioPicker.Scenarios
    Public Property FingerprintScenario() As ScenarioPicker.Scenarios
        Get
            Return mFingerprintScenario
        End Get
        Set(ByVal value As ScenarioPicker.Scenarios)
            mFingerprintScenario = value
        End Set
    End Property

    Private mFingerprintFailureType As ScenarioPicker.FailureType
    Public Property FingerprintFailureType() As ScenarioPicker.FailureType
        Get
            Return mFingerprintFailureType
        End Get
        Set(ByVal value As ScenarioPicker.FailureType)
            mFingerprintFailureType = value
        End Set
    End Property

    Private mIrisScenario As ScenarioPicker.Scenarios
    Public Property IrisScenario() As ScenarioPicker.Scenarios
        Get
            Return mIrisScenario
        End Get
        Set(ByVal value As ScenarioPicker.Scenarios)
            mIrisScenario = value
        End Set
    End Property

    Private mIrisFailureType As ScenarioPicker.FailureType
    Public Property IrisFailureType() As ScenarioPicker.FailureType
        Get
            Return mIrisFailureType
        End Get
        Set(ByVal value As ScenarioPicker.FailureType)
            mIrisFailureType = value
        End Set
    End Property
End Class