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

Imports System.Drawing
Imports System.Globalization
Imports System.Xml.Serialization

Imports Mbark.UI.GlobalUISettings
Imports Mbark.SensorMessages


Namespace Mbark.Sensors


    Public Enum SensorTaskStatus
        Unstarted   ' Task has not yet started
        Active      ' Task is underway

        Downloading ' Task result is currently being downloaded
        Pending     ' Task can be downloaded when ready
        Blocked     ' Task can't be downloaded b/c another task is downloading

        Done        ' Task is finished

        Skipped     ' Task was explicitly skipped
        Suspended   ' Task was active, and implicitly skipped 
    End Enum

    Module SensorTaskStatusSupport

        Public Function ToString(ByVal culture As CultureInfo, ByVal status As SensorTaskStatus) As String
            Dim returnValue As String = status.ToString()
            Select Case status
                Case SensorTaskStatus.Active
                    returnValue = Messages.Active(culture)
                Case SensorTaskStatus.Blocked
                    returnValue = Messages.Blocked(culture)
                Case SensorTaskStatus.Done
                    returnValue = Messages.Done(culture)
                Case SensorTaskStatus.Downloading
                    returnValue = Messages.Downloading(culture)
                Case SensorTaskStatus.Pending
                    returnValue = Messages.Pending(culture)
                Case SensorTaskStatus.Skipped
                    returnValue = Messages.Skipped(culture)
                Case SensorTaskStatus.Suspended
                    returnValue = Messages.Suspended(culture)
                Case SensorTaskStatus.Unstarted
                    returnValue = Messages.NotStarted(culture)
            End Select
            Return returnValue
        End Function

    End Module

    <XmlType()> Public Class SensorTask
        Implements IComparable

        Friend mDefinition As New SensorTaskDefinition
        Friend mConditions As New ConditionCollection
        Friend mColors As SensorTaskColors
        Friend mAttempts As New SensorTaskAttemptCollection(Me)
        Friend mOriginatingFactory As SensorTaskFactory
        Friend mSensor As ISensor

        Friend Function CreateDefinition(ByVal strings As LocalizableStringCollection) As SensorTaskDefinition
            Dim newDef As SensorTaskDefinition = mDefinition.DeepCopy

            With newDef
                .TargetConditionsDefinition = mConditions.CreateDefinition()
                .ColorsDefinition = mColors.Definition()
                .AttemptsDefinition = mAttempts.CreateDefinition(Me, strings)
            End With
            Return newDef
        End Function


        Public Property DownloadsPaused() As Boolean
            Get
                Return mDefinition.DownloadsPaused
            End Get
            Set(ByVal value As Boolean)
                mDefinition.DownloadsPaused = value
            End Set
        End Property


        Public Sub Block()
            mDefinition.IsBlocked = True
        End Sub

        Public Sub Unblock()
            mDefinition.IsBlocked = False
        End Sub




        Public ReadOnly Property LatestAttempt() As SensorTaskAttempt
            Get
                If Attempts.Count = 0 Then Return Nothing Else Return mAttempts(mAttempts.Count - 1)
            End Get
        End Property

        Public ReadOnly Property Attempts() As SensorTaskAttemptCollection
            Get
                Return mAttempts
            End Get
        End Property

        Friend ReadOnly Property OriginatingFactory() As SensorTaskFactory
            Get
                Return mOriginatingFactory
            End Get
        End Property

        Friend Sub WireOriginatingFactory(ByVal factory As SensorTaskFactory)
            mOriginatingFactory = factory
        End Sub

        Friend Sub PopulateConditions()
            If mOriginatingFactory Is Nothing Then Throw New MissingWiringException
            mConditions = mOriginatingFactory.ConditionFactories.CreateConditionCollection()
        End Sub

        Public Property Colors() As SensorTaskColors
            Get
                Return mColors
            End Get
            Set(ByVal value As SensorTaskColors)
                mColors = value
            End Set
        End Property

        Public ReadOnly Property IsEffectivelyUnstarted() As Boolean
            Get
                Return Status = SensorTaskStatus.Unstarted OrElse _
                       Status = SensorTaskStatus.Active AndAlso Attempts.Count = 0 OrElse _
                       Status = SensorTaskStatus.Suspended AndAlso mAttempts.Count = 0
            End Get
        End Property

        Public ReadOnly Property HasAttemptsInConflict(ByVal currentConditions As ConditionCollection, ByVal currentParts As BodyPartCollection) _
        As Boolean
            Get
                For i As Integer = 0 To mAttempts.Count - 1
                    If mAttempts(i).IsConflictIgnored Then Return False
                    If mAttempts(i).InConflict(currentConditions, currentParts) Then Return True
                Next
            End Get
        End Property

        Public ReadOnly Property HasUnresolvedConflicts(ByVal currentConditions As ConditionCollection, ByVal currentParts As BodyPartCollection) _
        As Boolean
            Get
                For i As Integer = 0 To mAttempts.Count - 1
                    If mAttempts(i).InConflict(currentConditions, currentParts) AndAlso Not mAttempts(i).IsConflictIgnored Then Return True
                Next
            End Get
        End Property

        Public ReadOnly Property HasOnlyCorrectedConflicts(ByVal currentConditions As ConditionCollection, ByVal currentParts As BodyPartCollection) _
        As Boolean
            Get
                Dim notCorrected As Integer
                Dim corrected As Integer
                For i As Integer = 0 To mAttempts.Count - 1

                    If mAttempts(i).InConflict(currentConditions, currentParts) Then
                        If mAttempts(i).IsConflictIgnored Then
                            corrected += 1
                        Else
                            notCorrected += 1
                        End If
                    End If
                Next
                Return corrected > 0 AndAlso notCorrected = 0
            End Get
        End Property



        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> _
        Public Property TargetCategory() As SensorTaskCategory
            Get
                Return mDefinition.TargetCategory
            End Get
            Set(ByVal value As SensorTaskCategory)
                With mDefinition
                    .TargetCategory = value
                    .TargetParts.Clear()
                    Select Case .TargetCategory
                        Case SensorTaskCategory.Face
                            .TargetParts.AddRange(BodyPartCollection.ForFaceTask)
                        Case SensorTaskCategory.LeftIris
                            .TargetParts.AddRange(BodyPartCollection.ForLeftIrisTask)
                        Case SensorTaskCategory.LeftSlap
                            .TargetParts.AddRange(BodyPartCollection.ForLeftSlapTask)
                        Case SensorTaskCategory.RightIris
                            .TargetParts.AddRange(BodyPartCollection.ForRightIrisTask)
                        Case SensorTaskCategory.RightSlap
                            .TargetParts.AddRange(BodyPartCollection.ForRightSlapTask)
                        Case SensorTaskCategory.ThumbsSlap
                            .TargetParts.AddRange(BodyPartCollection.ForThumbsSlapTask)
                        Case SensorTaskCategory.FlatLeftThumb
                            .TargetParts.AddRange(BodyPartCollection.ForFlatLeftThumb)
                        Case SensorTaskCategory.FlatLeftIndex
                            .TargetParts.AddRange(BodyPartCollection.ForFlatLeftIndex)
                        Case SensorTaskCategory.FlatLeftMiddle
                            .TargetParts.AddRange(BodyPartCollection.ForFlatLeftMiddle)
                        Case SensorTaskCategory.FlatLeftRing
                            .TargetParts.AddRange(BodyPartCollection.ForFlatLeftRing)
                        Case SensorTaskCategory.FlatLeftLittle
                            .TargetParts.AddRange(BodyPartCollection.ForFlatLeftLittle)
                        Case SensorTaskCategory.FlatRightThumb
                            .TargetParts.AddRange(BodyPartCollection.ForFlatRightThumb)
                        Case SensorTaskCategory.FlatRightIndex
                            .TargetParts.AddRange(BodyPartCollection.ForFlatRightIndex)
                        Case SensorTaskCategory.FlatRightMiddle
                            .TargetParts.AddRange(BodyPartCollection.ForFlatRightMiddle)
                        Case SensorTaskCategory.FlatRightRing
                            .TargetParts.AddRange(BodyPartCollection.ForFlatRightRing)
                        Case SensorTaskCategory.FlatRightLittle
                            .TargetParts.AddRange(BodyPartCollection.ForFlatRightLittle)
                        Case SensorTaskCategory.RolledLeftThumb
                            .TargetParts.AddRange(BodyPartCollection.ForRolledLeftThumb)
                        Case SensorTaskCategory.RolledLeftIndex
                            .TargetParts.AddRange(BodyPartCollection.ForRolledLeftIndex)
                        Case SensorTaskCategory.RolledLeftMiddle
                            .TargetParts.AddRange(BodyPartCollection.ForRolledLeftMiddle)
                        Case SensorTaskCategory.RolledLeftRing
                            .TargetParts.AddRange(BodyPartCollection.ForRolledLeftRing)
                        Case SensorTaskCategory.RolledLeftLittle
                            .TargetParts.AddRange(BodyPartCollection.ForRolledLeftLittle)
                        Case SensorTaskCategory.RolledRightThumb
                            .TargetParts.AddRange(BodyPartCollection.ForRolledRightThumb)
                        Case SensorTaskCategory.RolledRightIndex
                            .TargetParts.AddRange(BodyPartCollection.ForRolledRightIndex)
                        Case SensorTaskCategory.RolledRightMiddle
                            .TargetParts.AddRange(BodyPartCollection.ForRolledRightMiddle)
                        Case SensorTaskCategory.RolledRightRing
                            .TargetParts.AddRange(BodyPartCollection.ForRolledRightRing)
                        Case SensorTaskCategory.RolledRightLittle
                            .TargetParts.AddRange(BodyPartCollection.ForRolledRightLittle)
                        Case SensorTaskCategory.LeftPalm
                            .TargetParts.AddRange(BodyPartCollection.ForLeftPalmTask)
                        Case SensorTaskCategory.RightPalm
                            .TargetParts.AddRange(BodyPartCollection.ForRightPalmTask)
                        Case SensorTaskCategory.Voice
                            .TargetParts.AddRange(BodyPartCollection.ForVoiceTask)
                        Case Else
                            Debugging.Break()
                    End Select
                End With
            End Set
        End Property

        'Public Property Enabled() As Boolean
        '    Get
        '        Return mDefinition.Enabled
        '    End Get
        '    Set(ByVal value As Boolean)
        '        mDefinition.Enabled = value
        '    End Set
        'End Property

        Public ReadOnly Property ReachedFailureLimit() As Boolean
            Get
                Return Attempts.Count >= mDefinition.MaximumAttempts
            End Get
        End Property

        Public Sub TallyAttempt( _
            ByVal conditions As ConditionCollection, _
            ByVal targetParts As BodyPartCollection, _
            ByVal inaccessibleParts As BodyPartCollection, _
            ByVal thumbnail As Image, _
            ByVal results As CaptureResultCollection, _
            ByVal captureFailure As SensorTaskFailure, _
            ByVal downloadId As Guid, _
            ByVal withDownloadStage As Boolean, _
            ByVal rejected As Boolean, _
            ByVal corrupt As Boolean)

            'ky
            Dim attempt As New SensorTaskAttempt( _
                     parentTask:=Me, _
                     conditions:=conditions, _
                     targetParts:=targetParts, _
                     inaccessibleParts:=inaccessibleParts, _
                     thumbnail:=thumbnail, _
                     results:=results, _
                     captureFailure:=captureFailure, _
                     downloadId:=downloadId, _
                     withDownloadStage:=withDownloadStage, _
                     rejected:=rejected, _
                     corrupt:=corrupt, _
                     conflictIgnore:=False)

            mAttempts.Add(attempt)

        End Sub


        Public ReadOnly Property Name(ByVal culture As CultureInfo) As String
            Get
                Return SensorTaskCategorySupport.ToString(culture, mDefinition.TargetCategory)
            End Get
        End Property

        Public Property Sensor() As ISensor
            Get
                Return mSensor
            End Get
            Set(ByVal value As ISensor)
                mSensor = value
            End Set
        End Property

        Public Property SensorConfiguration() As SensorConfiguration
            Get
                Return mDefinition.SensorConfiguration
            End Get
            Set(ByVal value As SensorConfiguration)
                mDefinition.SensorConfiguration = value
            End Set
        End Property

        Public ReadOnly Property Conditions() As ConditionCollection
            Get
                Return mConditions
            End Get
        End Property

        Public ReadOnly Property TargetParts() As BodyPartCollection
            Get
                Return mDefinition.TargetParts
            End Get
        End Property
        Public ReadOnly Property TargetInaccessibleParts() As BodyPartCollection
            Get
                Return mDefinition.TargetInaccessibleParts
            End Get
        End Property

        Public Property Repetition() As Integer
            Get
                Return mDefinition.Repetition
            End Get
            Set(ByVal value As Integer)
                mDefinition.Repetition = value
            End Set
        End Property

        'Public ReadOnly Property CapturedParts() As BodyPartCollection
        '    Get
        '        Return mDefinition.CapturedParts
        '    End Get
        'End Property


        Public Function FriendlyToString(ByVal culture As CultureInfo) As String
            Dim index As Integer

            ' We allow the OriginatingFactory to be Nothing so that we can test the UI
            If OriginatingFactory IsNot Nothing Then
                index = OriginatingFactory.ParentSensorTaskFactories.AllTasks.IndexOf(Me) + 1
            End If

            Using writer As New IO.StringWriter(culture)
                With writer
                    .Write(Parenthesize(culture, index.ToString(culture)))
                    .Write(StringConstants.Space)
                    .Write(Name(culture))
                    If Conditions.FriendlyToString(culture) <> InfrastructureMessages.Messages.None(culture) Then
                        .Write(StringConstants.Space)
                        .Write(Parenthesize(culture, Conditions.FriendlyToString(culture)))
                    End If
                End With
                FriendlyToString = writer.ToString
            End Using

        End Function

        Public Overrides Function ToString() As String
            If Me.OriginatingFactory.GeneratedTasks.IndexOf(Me) = -1 Then Debugging.Break()
            Return "Factory """ & _
                """, Task " & _
                Me.OriginatingFactory.GeneratedTasks.IndexOf(Me) & " " & _
                Me.Status.ToString
        End Function

        Public ReadOnly Property IsBusy() As Boolean
            Get
                Return _
                    Status = SensorTaskStatus.Downloading OrElse _
                    Sensor.LatestStatus = SensorStatus.Capturing
                Status = SensorTaskStatus.Blocked
            End Get
        End Property

        Public ReadOnly Property IsExcess() As Boolean
            Get
                Return OriginatingFactory.GeneratedTasks.IndexOf(Me) >= OriginatingFactory.TaskCount
            End Get
        End Property


        Public ReadOnly Property HasSuccessfulCapture() As Boolean
            Get
                Dim count As Integer
                For i As Integer = 0 To mAttempts.Count - 1
                    Dim notRejected As Boolean = Not Attempts(i).IsRejected
                    Dim noCaptureFailure As Boolean = Not Attempts(i).HadCaptureFailure
                    Dim noDownloadFailure As Boolean = Not Attempts(i).HadDownloadFailure
                    Dim captureResultOkay As Boolean = Not Attempts(i).CaptureResults Is Nothing
                    If notRejected AndAlso noCaptureFailure AndAlso noDownloadFailure AndAlso captureResultOkay Then count += 1
                Next

                Return count > 0
            End Get
        End Property

        Public Sub RefreshStatus()

            ' ---
            ' Note that this method gets called after every attempt edit.
            ' ---


            If ReachedFailureLimit Then
                ' If we're reached our failure limit, then we're done
                mDefinition.Status = SensorTaskStatus.Done
                Return
            Else
                ' If we have *not* reached our failure limit, but we are labeled done, 
                ' then we should no longer be labeled done. Make this 'suspended.'
                If mDefinition.Status = SensorTaskStatus.Done Then
                    mDefinition.Status = SensorTaskStatus.Suspended
                End If
            End If





            Dim notBusy As Boolean = Not IsBusy
            Dim successfulCapture As Boolean = HasSuccessfulCapture

            If notBusy AndAlso successfulCapture Then

                If NumberOfDownloadsNeeded = 0 Then
                    ' If we're not busy, have a sucessful capture, and no downloads are needed, then
                    ' we must have everything we need. Consider this task 'done.'
                    '
                    mDefinition.Status = SensorTaskStatus.Done
                ElseIf Not DownloadsPaused Then

                    ' If we're not busy, have a sucessful capture, and downloads have not been paused,
                    ' then we are ready for download --- consider this task 'pending.'
                    '
                    mDefinition.Status = SensorTaskStatus.Pending
                End If
            End If

            If mDefinition.Status = SensorTaskStatus.Pending AndAlso NumberOfDownloadsNeeded = 0 Then

                ' If the task was pending (which means it must have had a successful capture),
                ' and now no longer has pending downloads (this can happen if an accepted
                ' attempt was changed to rejected), then we need to set this task to 'suspended'.
                ' This means that at some point in the future this task could be made active again.
                '
                mDefinition.Status = SensorTaskStatus.Suspended

            End If

            If mDefinition.Status = SensorTaskStatus.Suspended AndAlso NumberOfDownloadsNeeded > 0 Then

                ' Similarly, if the task was suspended (which may have been caused by rejecting a previously
                ' sucessful attempt) and there are now downloads needed, then the task should be labeled
                ' pending, since we want to download this result now.
                mDefinition.Status = SensorTaskStatus.Pending

                ' We don't want to force the user to 'unpause' the download here.
                DownloadsPaused = False

            End If


            If mDefinition.Status = SensorTaskStatus.Active AndAlso NumberOfDownloadsNeeded > 0 Then

                ' If we have a rejected attempt that gets accepted via the editor, then we need
                ' to make the task as 'pending' since we want to now download the result. Notice
                ' that this isn't necessary when we accept the attempt from the 'review' form,
                ' since accepting that review sets the task to pending.
                mDefinition.Status = SensorTaskStatus.Pending
            End If


            '' If we were suspended, see if we need to revert to pending on wakeup
            'If mDefinition.Status = SensorTaskStatus.Suspended AndAlso NumberOfPendingDownloads > 0 Then
            ' mDefinition.Status = SensorTaskStatus.Pending
            ' End If

        End Sub

        Public ReadOnly Property IsSkippable() As Boolean
            Get
                If Status = SensorTaskStatus.Active OrElse Status = SensorTaskStatus.Unstarted Then Return True
                Return False
            End Get
        End Property
        Public ReadOnly Property NumberOfDownloadsNeeded() As Integer
            Get
                For i As Integer = 0 To mAttempts.Count - 1
                    If mAttempts(i).NeedsDownload Then NumberOfDownloadsNeeded += 1
                Next
            End Get
        End Property

        Public Property Status() As SensorTaskStatus
            Get
                ' Notice how we keep the information about 'IsBlocked' separate, so that we can return to the non-blocked state
                If mDefinition.IsBlocked AndAlso Not Me.HasSuccessfulCapture Then Return SensorTaskStatus.Blocked
                Return mDefinition.Status
            End Get
            Set(ByVal value As SensorTaskStatus)



                If value = SensorTaskStatus.Done Then
                    ' Automatically set the captured parts when the status is tagged as done
                    'mDefinition.CapturedParts.AddEachPartIfNotContainedInOtherSet( _
                    '    mDefinition.TargetInaccessibleParts, _
                    '    mDefinition.TargetParts)
                    mDefinition.Status = value

                ElseIf value = SensorTaskStatus.Skipped Then

                    Select Case Status
                        Case SensorTaskStatus.Active, SensorTaskStatus.Suspended, SensorTaskStatus.Unstarted
                            mDefinition.Status = value
                        Case Else
                            ' Leave as is
                    End Select


                Else
                    mDefinition.Status = value
                End If


            End Set
        End Property

        Public ReadOnly Property HasAccessibleParts() As Boolean
            Get
                Return Not TargetParts.Equals(TargetInaccessibleParts)
            End Get
        End Property

        Public ReadOnly Property IsActivatableLessMissingParts() As Boolean
            Get

                ' We can't activate (or keep activated) a done task 
                If Status = SensorTaskStatus.Done Then Return False

                ' Reaching the failure limit means we're not activatable
                If ReachedFailureLimit Then Return False


                ' Sensors are not disabled
                If mSensor.Disabled Then Return False

                ' Downloading tasks certainly aren't activatable
                If Status = SensorTaskStatus.Downloading Then Return False

                ' Sensors not online (and also not defered) are not activatable --- in other
                ' words, a sensor that is either online or deferred is still activatable.
                '
                If mSensor.LatestStatus <> SensorStatus.Online AndAlso Not mSensor.DeferInitialization Then
                    Return False
                End If

                ' Make sure our prerequisite has been met
                If OriginatingFactory.Prerequisite.Evaluate = False Then Return False

                If mDefinition.Status = SensorTaskStatus.Active Then
                    ' Active tasks, by definition, are activatable, by definition
                    Return True
                End If


                If mDefinition.Status = SensorTaskStatus.Suspended AndAlso mDefinition.DownloadsPaused Then
                    ' Tasks that have their downloads suspended are *not* activatable if they've had a success
                    Return Not HasSuccessfulCapture
                End If

                ' Tasks with a download pending are not activatable
                If mDefinition.Status = SensorTaskStatus.Pending Then Return False

                ' If we've made it this far, the task must be unstarted or below the failure limit
                Dim unstarted As Boolean = Status = SensorTaskStatus.Unstarted
                Dim suspended As Boolean = Status = SensorTaskStatus.Suspended
                Dim notAtFailureLimit As Boolean = Not ReachedFailureLimit

                If mDefinition.Status = SensorTaskStatus.Blocked Then
                    Dim sw As New System.IO.StreamWriter("c:\TestingLog2.txt", True)
                    sw.WriteLine(DateTime.Now & " - " & "Task is blocked, but IsActivatable is " & (unstarted Or suspended Or notAtFailureLimit).ToString)
                    sw.Flush()
                    sw.Close()
                End If

                Return unstarted Or suspended Or notAtFailureLimit
            End Get
        End Property

        Public ReadOnly Property IsActivatable() As Boolean
            Get
                ' With no accessible parts, give up
                If Not HasAccessibleParts Then Return False
                Return IsActivatableLessMissingParts
            End Get
        End Property

        Shared smDefaultMaximumAttempts As Integer = 3

        Public Property MaximumAttempts() As Integer
            Get
                Return mDefinition.MaximumAttempts
            End Get
            Set(ByVal value As Integer)
                mDefinition.MaximumAttempts = value
            End Set
        End Property

        Public Sub New()
            mDefinition.MaximumAttempts = smDefaultMaximumAttempts
        End Sub

        Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            Dim f1, f2, t1, t2 As Integer

            Dim other As SensorTask = DirectCast(obj, SensorTask)

            f1 = OriginatingFactory.ParentSensorTaskFactories.IndexOf(Me.OriginatingFactory)
            t1 = OriginatingFactory.GeneratedTasks.IndexOf(Me)

            f2 = other.OriginatingFactory.ParentSensorTaskFactories.IndexOf(other.OriginatingFactory)
            t2 = other.OriginatingFactory.GeneratedTasks.IndexOf(other)

            Dim rv As Integer
            If f1 = f2 Then
                If t1 = t2 Then
                    rv = 0
                ElseIf t1 < t2 Then
                    rv = -1
                Else
                    rv = 1
                End If

            ElseIf f1 < f2 Then
                rv = -1
            Else
                rv = 1
            End If

            Return rv
        End Function

        Public Shared Operator <>(ByVal lhs As SensorTask, ByVal rhs As SensorTask) As Boolean
            If lhs Is Nothing Then Throw New ArgumentNullException("lhs")
            Return lhs.CompareTo(rhs) <> 0
        End Operator

        Public Shared Operator =(ByVal lhs As SensorTask, ByVal rhs As SensorTask) As Boolean
            If lhs Is Nothing Then Throw New ArgumentNullException("lhs")
            Return lhs.CompareTo(rhs) = 0
        End Operator

        Public Shared Operator <(ByVal lhs As SensorTask, ByVal rhs As SensorTask) As Boolean
            If lhs Is Nothing Then Throw New ArgumentNullException("lhs")
            Return lhs.CompareTo(rhs) = -1
        End Operator

        Public Shared Operator >(ByVal lhs As SensorTask, ByVal rhs As SensorTask) As Boolean
            If lhs Is Nothing Then Throw New ArgumentNullException("lhs")
            Return lhs.CompareTo(rhs) = 1
        End Operator




        Public Property SkipDestination() As Boolean
            Get
                Return mDefinition.SkipDestination
            End Get
            Set(ByVal value As Boolean)
                mDefinition.SkipDestination = value
            End Set
        End Property

    End Class

End Namespace
