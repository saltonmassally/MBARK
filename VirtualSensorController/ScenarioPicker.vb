Option Strict On

Imports System.Collections.Specialized


Public Class ScenarioPicker
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GoButton As System.Windows.Forms.Button
    Private WithEvents FaceGroup As System.Windows.Forms.GroupBox
    Private WithEvents FingerprintGroup As System.Windows.Forms.GroupBox
    Private WithEvents IrisGroup As System.Windows.Forms.GroupBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents FaceScenarioList As System.Windows.Forms.ListBox
    Private WithEvents FingerScenarioList As System.Windows.Forms.ListBox
    Private WithEvents mFaceDownloadCheck As System.Windows.Forms.CheckBox
    Private WithEvents mFaceCaptureCheck As System.Windows.Forms.CheckBox
    Private WithEvents mFaceInitializeCheck As System.Windows.Forms.CheckBox
    Private WithEvents mFingerCaptureCheck As System.Windows.Forms.CheckBox
    Private WithEvents mFingerInitializeCheck As System.Windows.Forms.CheckBox
    Private WithEvents mIrisCaptureCheck As System.Windows.Forms.CheckBox
    Private WithEvents mIrisInitializeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Private WithEvents IrisScenarioList As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScenarioPicker))
        Me.GoButton = New System.Windows.Forms.Button
        Me.FaceGroup = New System.Windows.Forms.GroupBox
        Me.FaceScenarioList = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.mFaceDownloadCheck = New System.Windows.Forms.CheckBox
        Me.mFaceCaptureCheck = New System.Windows.Forms.CheckBox
        Me.mFaceInitializeCheck = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.FingerprintGroup = New System.Windows.Forms.GroupBox
        Me.FingerScenarioList = New System.Windows.Forms.ListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.mFingerCaptureCheck = New System.Windows.Forms.CheckBox
        Me.mFingerInitializeCheck = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.IrisGroup = New System.Windows.Forms.GroupBox
        Me.IrisScenarioList = New System.Windows.Forms.ListBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.mIrisCaptureCheck = New System.Windows.Forms.CheckBox
        Me.mIrisInitializeCheck = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ExitButton = New System.Windows.Forms.Button
        Me.FaceGroup.SuspendLayout()
        Me.FingerprintGroup.SuspendLayout()
        Me.IrisGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'GoButton
        '
        Me.GoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GoButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoButton.Location = New System.Drawing.Point(227, 387)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(75, 23)
        Me.GoButton.TabIndex = 3
        Me.GoButton.Text = "Go"
        '
        'FaceGroup
        '
        Me.FaceGroup.Controls.Add(Me.FaceScenarioList)
        Me.FaceGroup.Controls.Add(Me.Label4)
        Me.FaceGroup.Controls.Add(Me.mFaceDownloadCheck)
        Me.FaceGroup.Controls.Add(Me.mFaceCaptureCheck)
        Me.FaceGroup.Controls.Add(Me.mFaceInitializeCheck)
        Me.FaceGroup.Controls.Add(Me.Label6)
        Me.FaceGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FaceGroup.Location = New System.Drawing.Point(12, 12)
        Me.FaceGroup.Name = "FaceGroup"
        Me.FaceGroup.Size = New System.Drawing.Size(290, 116)
        Me.FaceGroup.TabIndex = 12
        Me.FaceGroup.TabStop = False
        Me.FaceGroup.Text = "Face"
        '
        'FaceScenarioList
        '
        Me.FaceScenarioList.Location = New System.Drawing.Point(9, 36)
        Me.FaceScenarioList.Name = "FaceScenarioList"
        Me.FaceScenarioList.Size = New System.Drawing.Size(168, 69)
        Me.FaceScenarioList.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(182, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Pick a Type:"
        '
        'mFaceDownloadCheck
        '
        Me.mFaceDownloadCheck.Enabled = False
        Me.mFaceDownloadCheck.Location = New System.Drawing.Point(185, 80)
        Me.mFaceDownloadCheck.Name = "mFaceDownloadCheck"
        Me.mFaceDownloadCheck.Size = New System.Drawing.Size(88, 16)
        Me.mFaceDownloadCheck.TabIndex = 12
        Me.mFaceDownloadCheck.Text = "Download"
        '
        'mFaceCaptureCheck
        '
        Me.mFaceCaptureCheck.Enabled = False
        Me.mFaceCaptureCheck.Location = New System.Drawing.Point(185, 58)
        Me.mFaceCaptureCheck.Name = "mFaceCaptureCheck"
        Me.mFaceCaptureCheck.Size = New System.Drawing.Size(88, 16)
        Me.mFaceCaptureCheck.TabIndex = 11
        Me.mFaceCaptureCheck.Text = "Capture"
        '
        'mFaceInitializeCheck
        '
        Me.mFaceInitializeCheck.Enabled = False
        Me.mFaceInitializeCheck.Location = New System.Drawing.Point(185, 36)
        Me.mFaceInitializeCheck.Name = "mFaceInitializeCheck"
        Me.mFaceInitializeCheck.Size = New System.Drawing.Size(88, 16)
        Me.mFaceInitializeCheck.TabIndex = 10
        Me.mFaceInitializeCheck.Text = "Initialize"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(192, 23)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Choose a scenario"
        '
        'FingerprintGroup
        '
        Me.FingerprintGroup.Controls.Add(Me.FingerScenarioList)
        Me.FingerprintGroup.Controls.Add(Me.Label5)
        Me.FingerprintGroup.Controls.Add(Me.mFingerCaptureCheck)
        Me.FingerprintGroup.Controls.Add(Me.mFingerInitializeCheck)
        Me.FingerprintGroup.Controls.Add(Me.Label7)
        Me.FingerprintGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FingerprintGroup.Location = New System.Drawing.Point(12, 134)
        Me.FingerprintGroup.Name = "FingerprintGroup"
        Me.FingerprintGroup.Size = New System.Drawing.Size(290, 116)
        Me.FingerprintGroup.TabIndex = 13
        Me.FingerprintGroup.TabStop = False
        Me.FingerprintGroup.Text = "Fingerprint"
        '
        'FingerScenarioList
        '
        Me.FingerScenarioList.Location = New System.Drawing.Point(8, 35)
        Me.FingerScenarioList.Name = "FingerScenarioList"
        Me.FingerScenarioList.Size = New System.Drawing.Size(168, 69)
        Me.FingerScenarioList.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(182, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Pick a Type:"
        '
        'mFingerCaptureCheck
        '
        Me.mFingerCaptureCheck.Enabled = False
        Me.mFingerCaptureCheck.Location = New System.Drawing.Point(185, 57)
        Me.mFingerCaptureCheck.Name = "mFingerCaptureCheck"
        Me.mFingerCaptureCheck.Size = New System.Drawing.Size(88, 16)
        Me.mFingerCaptureCheck.TabIndex = 11
        Me.mFingerCaptureCheck.Text = "Capture"
        '
        'mFingerInitializeCheck
        '
        Me.mFingerInitializeCheck.Enabled = False
        Me.mFingerInitializeCheck.Location = New System.Drawing.Point(185, 35)
        Me.mFingerInitializeCheck.Name = "mFingerInitializeCheck"
        Me.mFingerInitializeCheck.Size = New System.Drawing.Size(88, 16)
        Me.mFingerInitializeCheck.TabIndex = 10
        Me.mFingerInitializeCheck.Text = "Initialize"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 23)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Choose a scenario"
        '
        'IrisGroup
        '
        Me.IrisGroup.Controls.Add(Me.IrisScenarioList)
        Me.IrisGroup.Controls.Add(Me.Label8)
        Me.IrisGroup.Controls.Add(Me.mIrisCaptureCheck)
        Me.IrisGroup.Controls.Add(Me.mIrisInitializeCheck)
        Me.IrisGroup.Controls.Add(Me.Label9)
        Me.IrisGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IrisGroup.Location = New System.Drawing.Point(12, 256)
        Me.IrisGroup.Name = "IrisGroup"
        Me.IrisGroup.Size = New System.Drawing.Size(290, 127)
        Me.IrisGroup.TabIndex = 14
        Me.IrisGroup.TabStop = False
        Me.IrisGroup.Text = "Iris"
        '
        'IrisScenarioList
        '
        Me.IrisScenarioList.Location = New System.Drawing.Point(9, 37)
        Me.IrisScenarioList.Name = "IrisScenarioList"
        Me.IrisScenarioList.Size = New System.Drawing.Size(170, 69)
        Me.IrisScenarioList.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(182, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Pick a Type:"
        '
        'mIrisCaptureCheck
        '
        Me.mIrisCaptureCheck.Enabled = False
        Me.mIrisCaptureCheck.Location = New System.Drawing.Point(185, 59)
        Me.mIrisCaptureCheck.Name = "mIrisCaptureCheck"
        Me.mIrisCaptureCheck.Size = New System.Drawing.Size(88, 16)
        Me.mIrisCaptureCheck.TabIndex = 11
        Me.mIrisCaptureCheck.Text = "Capture"
        '
        'mIrisInitializeCheck
        '
        Me.mIrisInitializeCheck.Enabled = False
        Me.mIrisInitializeCheck.Location = New System.Drawing.Point(185, 37)
        Me.mIrisInitializeCheck.Name = "mIrisInitializeCheck"
        Me.mIrisInitializeCheck.Size = New System.Drawing.Size(88, 16)
        Me.mIrisInitializeCheck.TabIndex = 10
        Me.mIrisInitializeCheck.Text = "Initialize"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(173, 23)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Choose a scenario"
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(12, 389)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(75, 23)
        Me.ExitButton.TabIndex = 15
        Me.ExitButton.Text = "Exit"
        '
        'ScenarioPicker
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(310, 422)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.IrisGroup)
        Me.Controls.Add(Me.FingerprintGroup)
        Me.Controls.Add(Me.FaceGroup)
        Me.Controls.Add(Me.GoButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ScenarioPicker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scenario Picker"
        Me.FaceGroup.ResumeLayout(False)
        Me.FingerprintGroup.ResumeLayout(False)
        Me.IrisGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Enum Scenarios
        AllOkay
        AlwaysHaveFailure
        AlwaysHaveTimeout
        HaveRandomFailure
        HaveRandomTimeout
        HaveHighFailureRate
        HaveHighTimeoutRate
        NumberOfScenariors
    End Enum

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        FaceScenario = New ArrayList(2)
        FingerScenario = New ArrayList(2)
        IrisScenario = New ArrayList(2)

        MyBase.OnLoad(e)
        For i As Integer = 0 To Scenarios.NumberOfScenariors - 1
            Dim scenario As Scenarios = CType(i, Scenarios)
            FaceScenarioList.Items.Add(scenario.ToString)
            FingerScenarioList.Items.Add(scenario.ToString)
            IrisScenarioList.Items.Add(scenario.ToString)
        Next
        FaceScenarioList.SelectedIndex = 0
        FingerScenarioList.SelectedIndex = 0
        IrisScenarioList.SelectedIndex = 0

        Me.Refresh()

    End Sub

    Private Sub ScenarioPicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FaceScenarioList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FaceScenarioList.SelectedIndexChanged
        Dim SelectedScenario As Scenarios = CType(FaceScenarioList.SelectedIndex, Scenarios)
        If FaceScenario.Count = 0 Then FaceScenario.Insert(0, SelectedScenario)
        FaceScenario(0) = SelectedScenario
        EnableCheckBox(SensorType.Face, SelectedScenario)
        Refresh()
    End Sub

    Private Sub FingerScenarioList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FingerScenarioList.SelectedIndexChanged
        Dim SelectedScenario As Scenarios = CType(FingerScenarioList.SelectedIndex, Scenarios)
        If FingerScenario.Count = 0 Then FingerScenario.Insert(0, SelectedScenario)
        FingerScenario(0) = SelectedScenario
        EnableCheckBox(SensorType.Fingerprint, SelectedScenario)
        Refresh()
    End Sub

    Private Sub IrisScenarioList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IrisScenarioList.SelectedIndexChanged
        Dim SelectedScenario As Scenarios = CType(IrisScenarioList.SelectedIndex, Scenarios)
        If IrisScenario.Count = 0 Then IrisScenario.Insert(0, SelectedScenario)
        IrisScenario(0) = SelectedScenario
        EnableCheckBox(SensorType.Iris, SelectedScenario)
        Refresh()
    End Sub

    Private Function ScenariosSelections(ByVal sType As SensorType, ByVal selectedScenario As Scenarios) As Decimal
        Select Case selectedScenario
            Case Scenarios.AllOkay
            Case Scenarios.AlwaysHaveFailure, Scenarios.AlwaysHaveTimeout
                Return 1D
            Case Scenarios.HaveHighFailureRate, Scenarios.HaveHighTimeoutRate
                Return 0.8D
            Case Scenarios.HaveRandomFailure, Scenarios.HaveRandomTimeout
                Return 0.25D
        End Select
    End Function

    Private Sub EnableCheckBox(ByVal sType As SensorType, ByVal selectedScenario As Scenarios)
        Dim enable As Boolean
        If selectedScenario <> Scenarios.AllOkay Then
            enable = True
        Else
            enable = False
        End If
        Select Case sType
            Case SensorType.Face
                If selectedScenario <> Scenarios.AlwaysHaveTimeout AndAlso _
                   selectedScenario <> Scenarios.HaveHighTimeoutRate AndAlso _
                   selectedScenario <> Scenarios.HaveRandomTimeout Then
                    mFaceCaptureCheck.Enabled = enable
                Else
                    mFaceCaptureCheck.Enabled = Not enable
                End If
                mFaceInitializeCheck.Enabled = enable
                mFaceDownloadCheck.Enabled = enable
                FaceCheckBoxEnabled = enable
            Case SensorType.Fingerprint
                mFingerCaptureCheck.Enabled = enable
                mFingerInitializeCheck.Enabled = enable
                FingerCheckBoxEnabled = enable
            Case SensorType.Iris
                mIrisCaptureCheck.Enabled = enable
                mIrisInitializeCheck.Enabled = enable
                IrisCheckBoxEnabled = enable
        End Select
        Refresh()
    End Sub

    Public Overrides Sub Refresh()
        MyBase.Refresh()
        If (FaceCheckBoxEnabled AndAlso Not mFaceCaptureCheck.Checked AndAlso _
                                     Not mFaceInitializeCheck.Checked AndAlso Not mFaceDownloadCheck.Checked) Or _
           (FingerCheckBoxEnabled AndAlso Not mFingerCaptureCheck.Checked AndAlso Not mFingerInitializeCheck.Checked) Or _
           (IrisCheckBoxEnabled AndAlso Not mIrisCaptureCheck.Checked AndAlso Not mIrisInitializeCheck.Checked) Then
            GoButton.Enabled = False
        Else
            'if all the check boxes are disable, therefore user have selected AlwaysOkay Scenario
            'Clear all the check mark for all the boxes.
            If Not FaceCheckBoxEnabled Then
                mFaceCaptureCheck.CheckState = CheckState.Unchecked
                mFaceInitializeCheck.CheckState = CheckState.Unchecked
                mFaceDownloadCheck.CheckState = CheckState.Unchecked
            Else
                If Not mFaceCaptureCheck.Enabled Then mFaceCaptureCheck.CheckState = CheckState.Unchecked
            End If
            If Not FingerCheckBoxEnabled Then
                mFingerCaptureCheck.CheckState = CheckState.Unchecked
                mFingerInitializeCheck.CheckState = CheckState.Unchecked
            End If
            If Not IrisCheckBoxEnabled Then
                mIrisCaptureCheck.CheckState = CheckState.Unchecked
                mIrisCaptureCheck.CheckState = CheckState.Unchecked
            End If
            GoButton.Enabled = True
        End If
    End Sub
    Private Sub mFaceInitializeCheckBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mFaceInitializeCheck.CheckedChanged
        If mFaceInitializeCheck.Checked Then
            mFaceCaptureCheck.Checked = False
            mFaceDownloadCheck.Checked = False
        End If
        If FaceScenario.Count = 1 Then FaceScenario.Insert(1, FailureType.Initialize)
        FaceScenario(1) = FailureType.Initialize
        Refresh()
    End Sub

    Private Sub mFaceCaptureCheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mFaceCaptureCheck.CheckedChanged
        If mFaceCaptureCheck.Checked Then
            mFaceInitializeCheck.Checked = False
            mFaceDownloadCheck.Checked = False
        End If
        If FaceScenario.Count = 1 Then FaceScenario.Insert(1, FailureType.Capture)
        FaceScenario(1) = FailureType.Capture
        Refresh()
    End Sub
    Private Sub mFaceDownloadCheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mFaceDownloadCheck.CheckedChanged
        If mFaceDownloadCheck.Checked Then
            mFaceInitializeCheck.Checked = False
            mFaceCaptureCheck.Checked = False
        End If
        If FaceScenario.Count = 1 Then FaceScenario.Insert(1, FailureType.Download)
        FaceScenario(1) = FailureType.Download
        Refresh()
    End Sub

    Private Sub mFingerInitializeCheckBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mFingerInitializeCheck.CheckedChanged
        If mFingerInitializeCheck.Checked Then mFingerCaptureCheck.Checked = False
        If FingerScenario.Count = 1 Then FingerScenario.Insert(1, FailureType.Initialize)
        FingerScenario(1) = FailureType.Initialize
        Refresh()
    End Sub

    Private Sub mFingerCaptureCheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mFingerCaptureCheck.CheckedChanged
        If mFingerCaptureCheck.Checked Then mFingerInitializeCheck.Checked = False
        If FingerScenario.Count = 1 Then FingerScenario.Insert(1, FailureType.Capture)
        FingerScenario(1) = FailureType.Capture
        Refresh()
    End Sub

    Private Sub mIrisInitializeCheckBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mIrisInitializeCheck.CheckedChanged
        If mIrisCaptureCheck.Checked Then mIrisInitializeCheck.Checked = False
        If IrisScenario.Count = 1 Then IrisScenario.Insert(1, FailureType.Initialize)
        IrisScenario(1) = FailureType.Initialize
        Refresh()
    End Sub

    Private Sub mCaptureCheckBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mIrisCaptureCheck.CheckedChanged
        If mIrisInitializeCheck.Checked Then mIrisCaptureCheck.Checked = False
        If IrisScenario.Count = 1 Then IrisScenario.Insert(1, FailureType.Capture)
        IrisScenario(1) = FailureType.Capture
        Refresh()
    End Sub

    Private Enum SensorType
        Face
        Fingerprint
        Iris
    End Enum
    Public Enum ProbabilityType
        Okay
        CaptureTimeout
        CaptureFailure
        InitTimeout
        InitFailure
        DownloadTimeout
        DownloadFailure
    End Enum
    Public Enum FailureType
        Initialize
        Capture
        Download
    End Enum
    Private FaceCheckBoxEnabled As Boolean
    Private FingerCheckBoxEnabled As Boolean
    Private IrisCheckBoxEnabled As Boolean

    Public FaceScenario As ArrayList
    Public FingerScenario As ArrayList
    Public IrisScenario As ArrayList

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class