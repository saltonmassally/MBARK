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

Imports System.Collections.Generic
Imports System.Diagnostics.CodeAnalysis
Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms

Namespace Mbark.Threading

#Region " Command Classes "

    Public Delegate Sub ResultMethod(ByVal command As AsyncCommand)

    ''' <summary>
    '''     Indicates a particular delegate the
    '''     <see cref="AsyncCommandManager">AsyncCommandManager Class</see> should execute,
    '''     along with its arguments and other control parameters (such as timeouts).
    ''' </summary>
    Public Class AsyncCommand
        Inherits AsyncCommandTemplate

        ''' <summary>Gets a unique identifier for the purposes of referencing the command.</summary>
        Public ReadOnly Property CommandId() As Guid
            Get
                Return mCommandId
            End Get
        End Property
        Private mCommandId As Guid = Guid.NewGuid

        ' Points back to the command manager that is executing or will execute this command
        '  Friend ParentManager As AsyncCommandManager

        <SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification:="Exception information is propogated into TargetException")> _
        Private Sub InvokeTargetDelegate()

            If TargetMethod Is Nothing Then Return
            mTimeInvoked = DateTime.UtcNow

            Dim c As Control = Nothing
            If TargetMethod.Target.GetType.IsSubclassOf(GetType(Control)) Then
                If ExpirationTime > -1 AndAlso Not IgnoreUnderlyingHandleOfTargetControl Then
                    Throw New NotFormInvokableException
                End If

                c = DirectCast(TargetMethod.Target, Control)
                If IgnoreUnderlyingHandleOfTargetControl Or Not c.InvokeRequired Then c = Nothing
            End If

            Try
                If c Is Nothing OrElse c.IsDisposed Then
                    mIsCancellable = True
                    mReturnValue = TargetMethod.DynamicInvoke(TargetMethodArgs())
                Else
                    mIsCancellable = False
                    mReturnValue = c.Invoke(TargetMethod, TargetMethodArgs())
                End If
            Catch tarInvEx As TargetInvocationException

                If tarInvEx.InnerException.GetType Is GetType(ThreadInterruptedException) Then

                    ' If we break here, this means that the target delegate could not gracefully handle a timeout. 
                    ' To handle this, add a 'Catch ex As ThreadInterupptedException' block.
                    '
                    mTargetException = New MissingThreadInterruptedHandlerException
                Else

                    ' Otherwise, the exception was not a timeout exception
                    mTargetException = tarInvEx.InnerException
                End If
                ' Catch thIntEx As ThreadInterruptedException
                ' This means the target delegate itself was interrupted
                'Debugger.Break()
            Catch ex As Exception
                mTargetException = ex ' CHECK: Is this okay?
            End Try

        End Sub



        Private mActiveInvocations As New List(Of Guid)
        Friend Sub Invoke()


            ' Make sure we're not invoking the same command twice
            If mActiveInvocations.Contains(mCommandId) Then Return

            mActiveInvocations.Add(mCommandId)

            ' The target delegate is executed on it's own thread. The result delegate
            ' is executed by the command consumer thread. Notice that the command consumer
            ' could be interrupted by stopping the queue.
            '
            Dim thread As New thread(AddressOf InvokeTargetDelegate)
            Dim threadName As String = "TargetDelegate " & mCommandId.ToString
            thread.Name = threadName
            thread.IsBackground = True

            Dim beforeStart As Long = DateTime.Now.Ticks
            thread.Start()

            Try
                If ExpirationTime = -1 Then
                    thread.Join()
                Else
                    thread.Join(ExpirationTime)
                End If
            Catch ex As ThreadInterruptedException
                ' Ignore this excpetion
            End Try

            Dim afterJoin As Long = DateTime.Now.Ticks

            Dim timeToJoin As Integer = CInt((afterJoin - beforeStart) / TimeSpan.TicksPerMillisecond + 1)

            If timeToJoin >= ExpirationTime Then
                mIsTimeExpired = True
                If CancelDelegateOnTimeout AndAlso mIsCancellable Then
                    thread.Interrupt()
                    thread.Join()
                End If
            End If



            ActivateCommandCompleteEvent(New CommandCompleteEventArgs(Me))

            mTimeCompleted = DateTime.UtcNow

            mActiveInvocations.Remove(mCommandId)

        End Sub


        ''' <summary>Gets the time at which the command enters the event queue.</summary>
        Public ReadOnly Property TimeEnqueued() As DateTime
            Get
                Return mTimeEnqueued
            End Get
        End Property
        ''' <summary>Gets the time at which the target delegate was invoked.</summary>
        ''' <value>
        ''' A <strong>DateTime</strong> whose value is the time that the command was invoked,
        ''' or, if the command was not yet invoked, an uninitialized
        ''' <strong>DateTime</strong>.
        ''' </value>
        Public ReadOnly Property TimeInvoked() As DateTime
            Get
                Return mTimeInvoked
            End Get
        End Property
        ''' <summary>Records the time at which the command invokation finished.</summary>
        Public ReadOnly Property TimeCompleted() As DateTime
            Get
                Return mTimeCompleted
            End Get
        End Property
        ''' <summary>
        ''' Records if the time it took to execute the command exceeded the expiration
        ''' time.
        ''' </summary>
        Public ReadOnly Property IsTimeExpired() As Boolean
            Get
                Return mIsTimeExpired
            End Get
        End Property

        Private mTargetException As Exception
        ''' <summary>Records any exception thrown during the execution of the command.</summary>
        Public ReadOnly Property TargetException() As Exception
            Get
                Return mTargetException
            End Get
        End Property

        ''' <summary>Records the value returned by the command (if any).</summary>
        Public ReadOnly Property TargetReturnValue() As Object
            Get
                Return mReturnValue
            End Get
        End Property

        Protected Friend Property WritableTimeEnqueued() As DateTime
            Get
                Return mTimeEnqueued
            End Get
            Set(ByVal value As DateTime)
                mTimeEnqueued = value
            End Set
        End Property

        Private mReturnValue As Object
        Private mTimeEnqueued As DateTime
        Private mTimeInvoked As DateTime
        Private mTimeCompleted As DateTime
        Private mIsTimeExpired As Boolean
        Private mIsCancellable As Boolean

        Public Sub New(ByVal template As AsyncCommandTemplate)

            With template
                Me.TargetMethod = .TargetMethod
                Me.TargetMethodArgs(.TargetMethodArgs())
                Me.ExpirationTime = .ExpirationTime

                Me.InvokeResultDelegateAsynchronously = .InvokeResultDelegateAsynchronously
                Me.CancelDelegateOnTimeout = .CancelDelegateOnTimeout
                For i As Integer = 0 To template.CommandCompleteHandlerCount - 1
                    AddHandler Me.CommandComplete, template.CommandCompleteHandler(i)
                Next

                Me.IgnoreUnderlyingHandleOfTargetControl = .IgnoreUnderlyingHandleOfTargetControl

            End With
        End Sub

        Public Sub New()

        End Sub


    End Class

    ''' <summary>
    '''     A factory class that generates an <see cref="AsyncCommand">AsyncCommand 
    ''' Class</see>
    '''     based on its internal state. An AsyncCommandTemplate is useful for automating the
    '''     generation of often instantiated <see cref="AsyncCommand">AsyncCommand
    '''     Class</see>es.
    ''' </summary>
    Public Class AsyncCommandTemplate

        ''' <summary>Determines how long the command is permitted to run until it is cancelled.</summary>
        Public Property ExpirationTime() As Integer
            Get
                Return mExpirationTime
            End Get
            Set(ByVal value As Integer)
                mExpirationTime = value
            End Set
        End Property

        Public Property TargetMethod() As System.Delegate
            Get
                Return mTargetMethod
            End Get
            Set(ByVal value As System.Delegate)
                mTargetMethod = value
            End Set
        End Property

        Public Sub TargetMethodArgs(ByVal value As Object())
            mTargetMethodArgs = value
        End Sub

        Public Function TargetMethodArgs() As Object()
            Return mTargetMethodArgs
        End Function

        Public Property TargetMethodArg(ByVal index As Integer) As Object
            Get
                Return mTargetMethodArgs(index)
            End Get
            Set(ByVal value As Object)
                mTargetMethodArgs(index) = value
            End Set
        End Property

        Public Event CommandComplete As EventHandler(Of CommandCompleteEventArgs)

        Public Sub ActivateCommandCompleteEvent(ByVal e As CommandCompleteEventArgs)
            ' Raising events is not thread-safe
            SyncLock Me
                RaiseEvent CommandComplete(Me, e)
            End SyncLock
        End Sub

        Private mCommandCompleteHandlers As New List(Of EventHandler(Of CommandCompleteEventArgs))
        Public ReadOnly Property CommandCompleteHandler(ByVal index As Integer) As EventHandler(Of CommandCompleteEventArgs)
            Get
                Return mCommandCompleteHandlers(index)
            End Get
        End Property
        Public Sub AddCommandCompleteHandler(ByVal handler As EventHandler(Of CommandCompleteEventArgs))
            mCommandCompleteHandlers.Add(handler)
        End Sub

        Public Sub RemoveCommandCompleteHandler(ByVal handler As EventHandler(Of CommandCompleteEventArgs))
            mCommandCompleteHandlers.Remove(handler)
        End Sub

        Public Sub InsertCommandCompleteHandler(ByVal index As Integer, ByVal handler As EventHandler(Of CommandCompleteEventArgs))
            mCommandCompleteHandlers.Insert(index, handler)
        End Sub
        Public ReadOnly Property CommandCompleteHandlerCount() As Integer
            Get
                Return mCommandCompleteHandlers.Count
            End Get
        End Property


        ' Control parameters

        Public Property InvokeResultDelegateAsynchronously() As Boolean
            Get
                Return mInvokeResultDelegateAsynchronously
            End Get
            Set(ByVal value As Boolean)
                mInvokeResultDelegateAsynchronously = value
            End Set
        End Property
        ''' <summary>
        '''	<para>Determines if the command queue should ignore or respect the underlying
        '''    handle of the target object should that object be of type Control. If true, then
        '''    the delegate is executed in a separate thread. If false, then the command queue
        '''    will invoke the delegate via the Control.Invoke mechanism built-in to .NET.</para>
        ''' </summary>
        ''' <remarks>
        '''    <para>This property only has an effect on the execution of the target delegate if
        '''    the delegate's object is of type Control.</para>
        '''    <para>If the delegate's target property is of type Control, and this property is
        '''    set to <strong>false</strong>, then the command cannot be set to expire.</para>
        ''' </remarks>
        ''' <value>This property is <strong>false</strong> by default.</value>

        Public Property IgnoreUnderlyingHandleOfTargetControl() As Boolean
            Get
                Return mIgnoreUnderlyingHandleOfTargetControl
            End Get
            Set(ByVal value As Boolean)
                mIgnoreUnderlyingHandleOfTargetControl = value
            End Set
        End Property

        Public Property CancelDelegateOnTimeout() As Boolean
            Get
                Return mCancelDelegateOnTimeout
            End Get
            Set(ByVal value As Boolean)
                mCancelDelegateOnTimeout = value
            End Set
        End Property

        Private Shared mDefaultInvokationExpirationTime As Integer = 30000
        ''' <summary>Determines the default value</summary>
        Public Shared Property DefaultInvokationExpirationTime() As Integer
            Get
                Return mDefaultInvokationExpirationTime
            End Get
            Set(ByVal value As Integer)
                mDefaultInvokationExpirationTime = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            mExpirationTime = DefaultInvokationExpirationTime
        End Sub

        Private mTargetMethod As System.Delegate
        Private mTargetMethodArgs As Object()
        Private mInvokeResultDelegateAsynchronously As Boolean
        Private mCancelDelegateOnTimeout As Boolean = True
        Private mIgnoreUnderlyingHandleOfTargetControl As Boolean
        Private mExpirationTime As Integer







    End Class

#End Region

    ''' <summary>
    ''' Provides a producer-consumer command queue for the asynchronous, but sequential,
    ''' execution of otherwise synchronous delegates. The <strong>AsyncCommandManager</strong>
    ''' differs from the typical "fire and forget" functionality built into .NET by proving a
    ''' <em>single</em> command thread that waits for a client to enqueue commands, which in
    ''' turn, are sequentially executed. Upon completing each command, the command thread
    ''' invokes a result delegate (along with a rich set of arguments so that the client can
    ''' evaluate the status of that command.
    ''' </summary>
    ''' <remarks>
    '''     For each command in the queue, the AsyncCommandManager first invokes the command's
    '''     <see cref="AsyncCommandTemplate.TargetMethod">target delegate</see>
    ''' </remarks>
    Public Class AsyncCommandManager

        Private Shared DefaultCreationTimeout As Integer = 1000
        Private Shared DefaultCancellationTimeout As Integer = 5000

        Friend CurrentlyHandlingCommandCompleteEvents As Boolean

        ''' <summary>Creates a new command queue</summary>
        Public Sub New()

            Try
                EnterMonitor()
                mSyncCommands = New List(Of AsyncCommand)
                mCommandThread = New ThreadParameters
            Finally
                ExitMonitor()
            End Try

        End Sub

        Private mStartCalled As Boolean
        Public Sub Start(ByVal creationTimeout As Integer, ByVal cancellationTimeout As Integer)

            If mStartCalled Then Return
            mStartCalled = True

            With mCommandThread
                .CreationTimeout = creationTimeout
                .CancellationTimeout = cancellationTimeout
                .Name = "Command Consumer " & Guid.NewGuid.ToString
                .StartThread(Me, New ThreadStart(AddressOf CommandThread))
            End With

        End Sub

        Public Sub Start()
            Start(DefaultCreationTimeout, DefaultCancellationTimeout)
        End Sub


        Public Sub [Stop](ByVal blocking As Boolean)
            If Not mStartCalled Then Return
            mStartCalled = False
            mCommandThread.StopThread(Me, blocking)
        End Sub

        Private Sub CommandThread()

            Dim done As Boolean

            ' If we have no pending stop request, then signal that we are running.
            EnterMonitor()
            If mCommandThread.HasStopRequest Then
                ExitMonitor()
                Return
            Else
                mCommandThread.IsRunning = True
                Monitor.PulseAll(Me)
                ExitMonitor()
            End If


            While Not done

                ' We wait only both the queue is empty and there is no request to quit
                EnterMonitor()

                While _
                    Not CurrentlyHandlingCommandCompleteEvents _
                    AndAlso mSyncCommands.Count() = 0 _
                    AndAlso Not mCommandThread.HasStopRequest

                    If mWaitWakeupFrequency > -1 Then
                        Monitor.Wait(Me, mWaitWakeupFrequency)
                    Else
                        Monitor.Wait(Me)
                    End If

                End While

                Dim command As AsyncCommand

                If mCommandThread.HasStopRequest Then
                    done = True
                    ExitMonitor()
                    Exit While
                Else
                    ' Peek at the most recent command
                    command = mSyncCommands(mSyncCommands.Count - 1)
                    ExitMonitor()
                End If



                ' Invoke the target, use the same creation and cancellation timeouts as the command thread itself
                command.Invoke()

                ' Remove the command from the queue and notify anything that might
                ' be waiting for its removal

                EnterMonitor()
                mSyncCommands.Remove(command)
                Monitor.PulseAll(Me)
                ExitMonitor()

            End While


        End Sub




        ''' <summary>
        ''' Adds a command to the CommandQueue. If the command is blocking, then the calling
        ''' thread blocks indefinitely until the queue is empty.
        ''' </summary>
        ''' <param name="command">The command to be queued.</param>
        Public Sub Enqueue(ByVal command As AsyncCommand)

            If command Is Nothing Then Throw New ArgumentNullException("command")

            ' Enqueue the command and notify waiting threads
            Try
                EnterMonitor()
                If command.ExpirationTime <> -1 AndAlso Not command.IgnoreUnderlyingHandleOfTargetControl Then

                End If
                command.WritableTimeEnqueued = DateTime.UtcNow
                mSyncCommands.Add(command)
                Monitor.PulseAll(Me)
            Finally
                ExitMonitor()
            End Try

        End Sub


        Public Sub Clear()
            Try
                EnterMonitor()
                mSyncCommands.Clear()
                Monitor.PulseAll(Me)
            Finally
                ExitMonitor()
            End Try

        End Sub

        
        Public Sub BlockUntilEmpty()
            Try
                EnterMonitor()
                While mSyncCommands.Count() > 0
                    If mWaitWakeupFrequency > -1 Then
                        Monitor.Wait(Me, mWaitWakeupFrequency)
                    Else
                        Monitor.Wait(Me)
                    End If
                End While
            Finally
                ExitMonitor()
            End Try
        End Sub

        Private mCommandThread As ThreadParameters
        Private mSyncCommands As List(Of AsyncCommand)

        ' How frequently we should attempt to suspend/resume the watchdog thread before timing out
        Private mWaitWakeupFrequency As Integer = -1


        Public Sub DisableIndefiniteWaiting(ByVal wakeupFrequency As Integer)
            EnterMonitor()
            mWaitWakeupFrequency = wakeupFrequency
            ExitMonitor()
        End Sub

        Private Sub EnterMonitor()
            Monitor.Enter(Me)
        End Sub

        Private Sub ExitMonitor()
            Monitor.Exit(Me)
        End Sub


    End Class

    Friend Class ThreadParameters
        Public Thread As Thread
        Public Name As String

        Public CreationTimeout As Integer
        Public CreationExitContext As Boolean

        Public CancellationTimeout As Integer
        Public CancellationWakeupOnWaitFrequency As Integer

        Public IsRunning As Boolean
        Public HasStopRequest As Boolean


        Friend Sub StartThread(ByVal monitoredObject As Object, ByVal threadStart As ThreadStart)

            Try
                Monitor.Enter(monitoredObject)
                Thread = New Thread(threadStart)
                Thread.Name = Name
                Thread.IsBackground = True

                ' Clear any deactivation request
                HasStopRequest = False

                ' Only if we're not alive should we start the thread
                If Not Thread.IsAlive Then

                    ' Start the thread, and then block until it is fully activated
                    ' Note that this *requires* that the created thread set the 
                    ' appropriate IsRunning flag.

                    Thread.Start()
                    While Not IsRunning
                        Monitor.Wait(monitoredObject, CreationTimeout, CreationExitContext)
                    End While

                End If
            Finally
                Monitor.PulseAll(monitoredObject)
                Monitor.Exit(monitoredObject)
            End Try

        End Sub

        Friend Sub StopThread(ByVal monitoredObject As Object, ByVal blocking As Boolean)


            ' First, we indiate that we're no longer running and send the stop request
            Monitor.Enter(monitoredObject)
            If IsRunning Then HasStopRequest = True
            Monitor.PulseAll(monitoredObject)
            Monitor.Exit(monitoredObject)

            If Not blocking Then Return
            If Thread Is Nothing Then Return

            Dim startTime As Long = DateTime.Now.Ticks
            Dim timedOut As Boolean = False

            Dim threadTerminated As Boolean

            While (Not threadTerminated And Not timedOut)
                If CancellationWakeupOnWaitFrequency > -1 Then
                    threadTerminated = Thread.Join(CancellationWakeupOnWaitFrequency)
                Else
                    threadTerminated = Thread.Join(CancellationTimeout)
                End If
                Dim elapsed As Long = DateTime.Now.Ticks - startTime
                timedOut = elapsed > CancellationTimeout * 1000
            End While

            ' If the thread is not terminated, take more drastic action.
            If Not threadTerminated Then
                Thread.Interrupt()
                Thread.Join(0)
            End If

            IsRunning = False
            Thread = Nothing

        End Sub

    End Class

    Public Class CommandCompleteEventArgs
        Inherits EventArgs
        Private mCommand As AsyncCommand
        Friend Sub New(ByVal command As AsyncCommand)
            mCommand = command
        End Sub
        Public ReadOnly Property Command() As AsyncCommand
            Get
                Return mCommand
            End Get
        End Property
    End Class

End Namespace
