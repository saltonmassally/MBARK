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

Imports System.Globalization
Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Class SensorRecoveryForm
        Inherits System.Windows.Forms.Form
        Implements IHasUICulture

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
        Friend WithEvents TimeoutIndicator1 As Mbark.UI.TimeoutIndicator
        Friend WithEvents TryToRecoverButton As System.Windows.Forms.Button
        Friend WithEvents SensorLabel As System.Windows.Forms.Label
        Friend WithEvents InstructionLabel As System.Windows.Forms.Label
        Friend WithEvents GiveUpButton As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SensorRecoveryForm))
            Me.TryToRecoverButton = New System.Windows.Forms.Button
            Me.GiveUpButton = New System.Windows.Forms.Button
            Me.SensorLabel = New System.Windows.Forms.Label
            Me.InstructionLabel = New System.Windows.Forms.Label
            Me.TimeoutIndicator1 = New Mbark.UI.TimeoutIndicator
            Me.SuspendLayout()
            '
            'TryToRecoverButton
            '
            resources.ApplyResources(Me.TryToRecoverButton, "TryToRecoverButton")
            Me.TryToRecoverButton.Name = "TryToRecoverButton"
            '
            'GiveUpButton
            '
            resources.ApplyResources(Me.GiveUpButton, "GiveUpButton")
            Me.GiveUpButton.Name = "GiveUpButton"
            '
            'SensorLabel
            '
            resources.ApplyResources(Me.SensorLabel, "SensorLabel")
            Me.SensorLabel.Name = "SensorLabel"
            '
            'InstructionLabel
            '
            resources.ApplyResources(Me.InstructionLabel, "InstructionLabel")
            Me.InstructionLabel.Name = "InstructionLabel"
            '
            'TimeoutIndicator1
            '
            Me.TimeoutIndicator1.CriticalColor = System.Drawing.Color.Red
            Me.TimeoutIndicator1.CriticalTime = 0
            resources.ApplyResources(Me.TimeoutIndicator1, "TimeoutIndicator1")
            Me.TimeoutIndicator1.Name = "TimeoutIndicator1"
            Me.TimeoutIndicator1.UpdateFrequency = 100
            '
            'SensorRecoveryForm
            '
            resources.ApplyResources(Me, "$this")
            Me.ControlBox = False
            Me.Controls.Add(Me.InstructionLabel)
            Me.Controls.Add(Me.SensorLabel)
            Me.Controls.Add(Me.TimeoutIndicator1)
            Me.Controls.Add(Me.GiveUpButton)
            Me.Controls.Add(Me.TryToRecoverButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "SensorRecoveryForm"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mUICulture As CultureInfo = CultureInfo.CurrentUICulture
        Public Property UICulture() As CultureInfo Implements IHasUICulture.UICulture
            Get
                Return mUICulture
            End Get
            Set(ByVal Value As CultureInfo)
                mUICulture = Value
            End Set
        End Property


        Public Enum RecoveryAction
            Reinitialize
            GiveUp
        End Enum


        Private mFailingSensor As ISensor
        Public Property FailingSensor() As ISensor
            Get
                Return mFailingSensor
            End Get
            Set(ByVal value As ISensor)
                mFailingSensor = value
            End Set
        End Property

        Private mDesiredRecoveryAction As RecoveryAction
        Public Property DesiredRecoveryAction() As RecoveryAction
            Get
                Return mDesiredRecoveryAction
            End Get
            Set(ByVal value As RecoveryAction)
                mDesiredRecoveryAction = value
            End Set
        End Property


        Private Sub TryToRecoverButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TryToRecoverButton.Click
            mDesiredRecoveryAction = RecoveryAction.Reinitialize
            Me.Close()
        End Sub

        Private Sub GiveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GiveUpButton.Click
            mDesiredRecoveryAction = RecoveryAction.GiveUp
            Me.Close()
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            PopulateMessages()

            SensorLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.LargeBold
            InstructionLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.Regular
            TryToRecoverButton.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.Button
            GiveUpButton.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.Button
            TimeoutIndicator1.StartCountdown(30000)
        End Sub

        Private Sub PopulateMessages()

            Me.SensorLabel.Text = FailingSensor.FriendlyName
            Me.Text = Messages.SensorRecoveryFormTitle(UICulture)
            InstructionLabel.Text = Messages.SensorRecoveryInstructions(UICulture)
        End Sub

        Private Sub OutOfTime(ByVal sendere As Object, ByVal e As EventArgs) Handles TimeoutIndicator1.OutOfTimeEvent
            mDesiredRecoveryAction = RecoveryAction.Reinitialize
            Me.Close()
        End Sub

#Region "        Automation Use      "
        Public Sub TryToRecoverButtonPerformClick()
            TryToRecoverButton.PerformClick()
        End Sub

        Public Sub GiveUpButtonPerformClick()
            GiveUpButton.PerformClick()
        End Sub
#End Region

    End Class

End Namespace