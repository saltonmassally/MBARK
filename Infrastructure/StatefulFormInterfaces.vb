Option Strict On

Imports Mbark.Threading

Namespace Mbark.UI

    Public Enum FormStateChangeTrigger
        Explicit
        EventActivated
        CommandCompleted
    End Enum

    Public Class FormStateChangeEventArgs
        Inherits EventArgs

        Private mOldState As Integer
        Private mNewState As Integer
        Private mTrigger As FormStateChangeTrigger
        Private mReason As String
        Private mCommand As AsyncCommand

        Public ReadOnly Property OldState() As Integer
            Get
                Return mOldState
            End Get
        End Property

        Public ReadOnly Property NewState() As Integer
            Get
                Return mNewState
            End Get
        End Property

        Public ReadOnly Property Trigger() As FormStateChangeTrigger
            Get
                Return mTrigger
            End Get
        End Property

        Public ReadOnly Property Reason() As String
            Get
                Return mReason
            End Get
        End Property

        Public ReadOnly Property Command() As AsyncCommand
            Get
                Return mCommand
            End Get
        End Property

        Public Sub New( _
            ByVal oldState As Integer, _
            ByVal newState As Integer, _
            ByVal trigger As FormStateChangeTrigger, _
            ByVal reason As String, _
            ByVal command As AsyncCommand)

            mOldState = oldState
            mNewState = newState
            mTrigger = trigger
            mReason = reason
            mCommand = command

        End Sub

    End Class


    Public Interface IFormStateChangeEventProducer
        Event FormStateChange As EventHandler(Of FormStateChangeEventArgs)
    End Interface

    Public Interface IFormStateProvider
        Inherits IFormStateChangeEventProducer
        ReadOnly Property CurrentFormState() As Integer
        ReadOnly Property PreviousFormState() As Integer
    End Interface

    Public Interface IFormStateChangeEventConsumer
        Sub HandleFormStateChange(ByVal sender As Object, ByVal e As FormStateChangeEventArgs)
    End Interface

End Namespace