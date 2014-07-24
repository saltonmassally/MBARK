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

Imports System.Collections.ObjectModel
Imports System.Windows.Forms

Imports Mbark.Threading

Imports SensorControlModeSet = System.Collections.ObjectModel.Collection(Of Mbark.Sensors.SensorControlMode)

Namespace Mbark.Sensors

    Public Enum SensorControlMode
        StartingForm

        StartingSensorCheck

        StartingSensorInitialization
        AwaitingSensorInitializationCompletion
        HandlingSensorInitializationCompletion

        RecoveringFromSensorFailures
        AwaitingRecoveryResult
        HandlingRecoveryResult

        AwaitingStartOfNewTaskSet
        StartingNewTaskSet
        AwaitingTaskSetCompletion
        CheckingOutstandingConflicts
        EditingConflict
        CompletingTaskSet

        ActivatingTask

        JustifyingTaskSkip
        HandlingTaskSkipResponse

        AwaitingCaptureSignal
        AwaitingCaptureResult
        HandlingCaptureResult

        EditingAttempt
        HandlingAttemptEdit

        ReviewingCaptureResult
        HandlingCaptureReviewResponse

        CancellingOrResumingDownload

        ConfiguringSensor
        AwaitingConfigurationResult
        HandlingConfigurationResult

        FinalizingSensorResult
        GeneratingTemplate
        OperatorExplainingTimeout
        TallyingFailedAttempt

        NoTasksToPerform


    End Enum


    ' Defines a property common to multiple control modes
    Public NotInheritable Class SensorControlModeSets


        Private Sub New()
            ' Forbid construction
        End Sub

        Private Shared mTaskSelectionPermitted As SensorControlModeSet = InitializeTaskSelectionPermitted()
        Public Shared ReadOnly Property TaskSelectionPermitted() As SensorControlModeSet
            Get
                Return mTaskSelectionPermitted
            End Get
        End Property
        Private Shared Function InitializeTaskSelectionPermitted() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.AwaitingTaskSetCompletion)
            End With
            Return modes
        End Function

        Private Shared mInaccessibleBodyPartsChangeable As SensorControlModeSet = InitializeInaccessibleBodyPartsChangeable()
        Public Shared ReadOnly Property InaccessibleBodyPartsChangeable() As SensorControlModeSet
            Get
                Return mInaccessibleBodyPartsChangeable
            End Get
        End Property
        Private Shared Function InitializeInaccessibleBodyPartsChangeable() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingStartOfNewTaskSet)
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.AwaitingTaskSetCompletion)
                .Add(SensorControlMode.NoTasksToPerform)
            End With
            Return modes
        End Function


        Private Shared smDisableSensorPermitted As SensorControlModeSet = InitializeDisableSensorPermitted()
        Public Shared ReadOnly Property DisableSensorPermitted() As SensorControlModeSet
            Get
                Return smDisableSensorPermitted
            End Get
        End Property
        Private Shared Function InitializeDisableSensorPermitted() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingStartOfNewTaskSet)
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.NoTasksToPerform)
            End With
            Return modes
        End Function


        Private Shared smLoadSessionPermitted As SensorControlModeSet = InitializeLoadSessionPermitted()
        Public Shared ReadOnly Property LoadSessionPermitted() As SensorControlModeSet
            Get
                Return smLoadSessionPermitted
            End Get
        End Property
        Private Shared Function InitializeLoadSessionPermitted() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingStartOfNewTaskSet)
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.AwaitingTaskSetCompletion)
                .Add(SensorControlMode.NoTasksToPerform)
            End With
            Return modes
        End Function


        Private Shared smSaveSessionPermitted As SensorControlModeSet = InitializeSaveSessionPermitted()
        Public Shared ReadOnly Property SaveSessionPermitted() As SensorControlModeSet
            Get
                Return smSaveSessionPermitted
            End Get
        End Property
        Private Shared Function InitializeSaveSessionPermitted() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingStartOfNewTaskSet)
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.AwaitingTaskSetCompletion)
                .Add(SensorControlMode.NoTasksToPerform)
            End With
            Return modes
        End Function


        Private Shared ReadOnly smConditionChangePermitted As SensorControlModeSet = InitializeConditionChangePermitted()
        Public Shared ReadOnly Property ConditionChangePermitted() As SensorControlModeSet
            Get
                Return smConditionChangePermitted
            End Get
        End Property
        Private Shared Function InitializeConditionChangePermitted() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingStartOfNewTaskSet)
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.AwaitingTaskSetCompletion)
                .Add(SensorControlMode.NoTasksToPerform)
            End With
            Return modes
        End Function

        Private Shared ReadOnly smExitPermitted As SensorControlModeSet = InitializeExitPermitted()
        Public Shared ReadOnly Property ExitPermitted() As SensorControlModeSet
            Get
                Return smExitPermitted
            End Get
        End Property
        Private Shared Function InitializeExitPermitted() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.ActivatingTask)
                .Add(SensorControlMode.NoTasksToPerform)
                .Add(SensorControlMode.AwaitingTaskSetCompletion)
            End With
            Return modes
        End Function


        Private Shared smAttemptEditPermitted As SensorControlModeSet = InitializeAttemptEditPermitted()
        Public Shared ReadOnly Property AttemptEditPermitted() As SensorControlModeSet
            Get
                Return smAttemptEditPermitted
            End Get
        End Property
        Private Shared Function InitializeAttemptEditPermitted() As SensorControlModeSet
            Dim modes As New SensorControlModeSet
            With modes
                .Add(SensorControlMode.AwaitingStartOfNewTaskSet)
                .Add(SensorControlMode.AwaitingCaptureSignal)
                .Add(SensorControlMode.AwaitingTaskSetCompletion)
                .Add(SensorControlMode.NoTasksToPerform)
            End With
            Return modes
        End Function

    End Class


    Public Interface ISensorControlModeChangeProducer
        Event SensorControlModeChange As EventHandler(Of SensorControlModeChangeEventArgs)
    End Interface

    Public Interface ISensorControlModeProvider
        Inherits ISensorControlModeChangeProducer
        ReadOnly Property CurrentSensorControlMode() As SensorControlMode
        ReadOnly Property PreviousSensorControlMode() As SensorControlMode
    End Interface

    Public Interface ISensorControlModeChangeConsumer
        ReadOnly Property SensorControlModeProvider() As ISensorControlModeProvider
        Sub HandleSensorControlModeChange(ByVal sender As Object, ByVal e As SensorControlModeChangeEventArgs)
    End Interface

    Public Enum SensorModeChangeTrigger
        EventActivated
        CommandCompleted
        ExplicitTransition
    End Enum

    Public Class SensorControlModeChangeEventArgs
        Inherits EventArgs
        Private mOldMode As SensorControlMode
        Private mNewMode As SensorControlMode

        ' Useful for tracking state changes triggered by commands being finished
        Private mCommand As AsyncCommand

        Public ReadOnly Property OldMode() As SensorControlMode
            Get
                Return mOldMode
            End Get
        End Property
        Public ReadOnly Property NewMode() As SensorControlMode
            Get
                Return mNewMode
            End Get
        End Property
        Public Sub New( _
            ByVal oldMode As SensorControlMode, _
            ByVal newMode As SensorControlMode, _
            ByVal command As AsyncCommand, _
            ByVal trigger As SensorModeChangeTrigger, _
            ByVal reason As String)
            mOldMode = oldMode
            mNewMode = newMode
            mTrigger = trigger
            mCommand = command
            mReason = reason
        End Sub

        Private mReason As String
        Public ReadOnly Property Reason() As String
            Get
                Return mReason
            End Get
        End Property

        Private mTrigger As SensorModeChangeTrigger
        Public ReadOnly Property Trigger() As SensorModeChangeTrigger
            Get
                Return mTrigger
            End Get
        End Property


        Public ReadOnly Property Command() As AsyncCommand
            Get
                Return mCommand
            End Get
        End Property




    End Class

    Module SharedImplementation

        Friend Sub SubscribeToParentSensorControlModeChangeEvents(ByVal child As Control, ByVal bind As Boolean)

            If child Is Nothing Then Return

            ' Using GetInterface avoids an unnecessary cast as detected by FxCop
            If child.GetType.GetInterface("ISensorControlModeChangeConsumer") Is Nothing Then Return
            Dim childAsConsumer As ISensorControlModeChangeConsumer = _
                DirectCast(child, ISensorControlModeChangeConsumer)

            Dim parentControl As Control = FindNearestSensorControlModeProviderParent(child)
            If parentControl Is Nothing Then Return

            Dim parentProducer As ISensorControlModeChangeProducer = _
                DirectCast(parentControl, ISensorControlModeChangeProducer)

            If bind Then
                AddHandler parentProducer.SensorControlModeChange, _
                AddressOf childAsConsumer.HandleSensorControlModeChange
            Else
                RemoveHandler parentProducer.SensorControlModeChange, _
                AddressOf childAsConsumer.HandleSensorControlModeChange
            End If

        End Sub

        Friend Function FindNearestSensorControlModeProviderParent(ByVal control As Windows.Forms.Control) As Control
            Return FindNearestParentOfInterface(control, GetType(ISensorControlModeProvider))
        End Function

    End Module


End Namespace