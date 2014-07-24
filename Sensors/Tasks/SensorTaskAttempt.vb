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

Imports Mbark.SensorMessages

Namespace Mbark.Sensors


    <XmlType("RuntimeSensorTaskAttempt")> Public Class SensorTaskAttempt

        Friend mParentTask As SensorTask
        Friend mCapturedConditions As ConditionCollection

        Friend mThumbnail As Image
        Friend mCaptureResults As CaptureResultCollection
        Friend mDefinition As New SensorTaskAttemptDefinition

        Friend Function CreateDefinition(ByVal parentTask As SensorTask, ByVal strings As LocalizableStringCollection) As SensorTaskAttemptDefinition

            mParentTask = parentTask

            Dim newDef As SensorTaskAttemptDefinition = mDefinition.DeepCopy

            With newDef
                .CapturedConditionsDefinition = mCapturedConditions.CreateDefinition()

                Dim thumbnailProperties As New ImageProperties
                thumbnailProperties.Image = mThumbnail
                .ThumbnailDefinition = thumbnailProperties.Definition

                If Not mCaptureResults Is Nothing Then
                    .CaptureResultsDefinition = mCaptureResults.Definition
                End If

            End With
            Return newDef
        End Function

        Public ReadOnly Property CapturedConditions() As ConditionCollection
            Get
                Return mCapturedConditions
            End Get
        End Property

        Public ReadOnly Property TargetPartsOnCapture() As BodyPartCollection
            Get
                Return mDefinition.TargetPartsOnCapture
            End Get
        End Property

        Public ReadOnly Property InaccessiblePartsOnCapture() As BodyPartCollection
            Get
                Return mDefinition.InaccessiblePartsOnCapture
            End Get
        End Property

        Public ReadOnly Property ThumbnailImage() As Image
            Get
                Return mThumbnail
            End Get
        End Property

        Public ReadOnly Property HadCaptureFailure() As Boolean
            Get
                Return Not mDefinition.CaptureFailure Is Nothing
            End Get
        End Property

        Public ReadOnly Property HasDownloadStage() As Boolean
            Get
                Return mDefinition.HasDownloadStage
            End Get
        End Property

        Public ReadOnly Property HadDownloadFailure() As Boolean
            Get
                Return mDefinition.HasDownloadStage AndAlso Not mDefinition.DownloadFailure Is Nothing
            End Get
        End Property

        Public ReadOnly Property HasCaptureResults() As Boolean
            Get
                Return Not mCaptureResults Is Nothing
            End Get
        End Property

        Public ReadOnly Property CaptureResults() As CaptureResultCollection
            Get
                Return mCaptureResults
            End Get
        End Property

        Public ReadOnly Property NeedsDownload() As Boolean
            Get
                Return _
                    Me.mParentTask.Status <> SensorTaskStatus.Skipped AndAlso _
                    mDefinition.HasDownloadStage AndAlso _
                    mDefinition.CaptureFailure Is Nothing AndAlso _
                    Not mDefinition.DownloadComplete AndAlso _
                    Not mDefinition.IsRejected AndAlso _
                    Not mThumbnail Is Nothing
            End Get
        End Property

        Public ReadOnly Property DownloadSuccessful() As Boolean
            Get
                Return _
                    mDefinition.HasDownloadStage AndAlso _
                    mDefinition.DownloadComplete AndAlso _
                    mDefinition.DownloadFailure Is Nothing AndAlso _
                    Not mCaptureResults Is Nothing
            End Get
        End Property

        Public ReadOnly Property HasSuccessfulCapture() As Boolean
            Get
                If HadCaptureFailure Then Return False
                If IsRejected Then Return False
                If HasCorruptImage Then Return False

                ' A download failure automatically trumps any succesful capture
                If HasDownloadStage And HadDownloadFailure Then Return False

                Return True
            End Get
        End Property

        Public ReadOnly Property IsSuccessful() As Boolean
            Get
                If Not HasSuccessfulCapture Then Return False
                If Not HasCaptureResults Then Return False
                If HasDownloadStage AndAlso Not DownloadSuccessful Then Return False

                Return True
            End Get
        End Property

        Friend ReadOnly Property Timestamp() As DateTime
            Get
                Return mDefinition.Timestamp
            End Get
        End Property


#Region " Editable Properties "

        Public Property IsRejected() As Boolean
            Get
                Return mDefinition.IsRejected
            End Get
            Set(ByVal value As Boolean)
                mDefinition.IsRejected = value
            End Set
        End Property

        Public Property HasCorruptImage() As Boolean
            Get
                Return Not mThumbnail Is Nothing AndAlso mDefinition.HasCorruptImage
            End Get
            Set(ByVal value As Boolean)
                mDefinition.HasCorruptImage = value
            End Set
        End Property

        Public Property AcceptedAsIs() As Boolean
            Get
                Debug.Assert(Not mThumbnail Is Nothing)
                Return mDefinition.AcceptedAsIs
            End Get
            Set(ByVal value As Boolean)
                mDefinition.AcceptedAsIs = value
            End Set
        End Property

        Public Property TimeoutReason() As TimeoutDetailForm.TimeoutReason
            Get
                Return mDefinition.TimeoutReason
            End Get
            Set(ByVal value As TimeoutDetailForm.TimeoutReason)
                mDefinition.TimeoutReason = value
            End Set
        End Property

        Public Property OtherTimeoutReason() As String
            Get
                Return mDefinition.OtherTimeoutReason
            End Get
            Set(ByVal value As String)
                ' FIXME: Throw an exception here if need be
                If mDefinition.TimeoutReason = TimeoutDetailForm.TimeoutReason.OtherReason Then
                    mDefinition.OtherTimeoutReason = value
                End If
            End Set
        End Property

        Public Property CapturedCategory() As SensorTaskCategory
            Get
                Return mDefinition.CapturedCategory
            End Get
            Set(ByVal value As SensorTaskCategory)
                mDefinition.CapturedCategory = value
            End Set
        End Property
        Public Property IsConflictIgnored() As Boolean
            Get
                Return mDefinition.IsConflictIgnored
            End Get
            Set(ByVal value As Boolean)
                mDefinition.IsConflictIgnored = value
            End Set
        End Property
#End Region

#Region " Corrective Properties "

        Public Sub MarkAsHavingDownloadFailure(ByVal failure As SensorTaskFailure)
            With mDefinition
                Debug.Assert(.HasDownloadStage)
                .DownloadComplete = True
                .DownloadFailure = failure
            End With
        End Sub

        Public Sub MarkAsDownloadedSuccessfully(ByVal results As CaptureResultCollection)
            Debug.Assert(mDefinition.HasDownloadStage)
            mDefinition.DownloadComplete = True
            mCaptureResults = results
        End Sub

#End Region


        Public Function InConflict( _
            ByVal currentConditions As ConditionCollection, _
            ByVal currentInaccessibleParts As BodyPartCollection) As Boolean

            Return InConflict(currentConditions, currentInaccessibleParts, Nothing, CultureInfo.CurrentUICulture)

        End Function

        Private Function AttemptBelongsToDisabledFactory(ByVal conflict As SensorTaskAttemptConflict) As Boolean
            Dim result As Boolean = ParentTask.OriginatingFactory.Prerequisite.Evaluate = False
            If result AndAlso conflict IsNot Nothing Then
                conflict.UnmetPrerequisite = New UnmetPrerequisiteConflict(ParentTask.OriginatingFactory.Prerequisite)
            Else
                Return result
            End If
        End Function

        Private Function CurrentAndCapturedConditionsConflict( _
            ByVal currentConditions As ConditionCollection, _
            ByVal conflict As SensorTaskAttemptConflict, _
            ByVal culture As CultureInfo) As Boolean

            Dim result As Boolean = Not currentConditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.StaticsOnly)
            If result AndAlso conflict IsNot Nothing Then

                Dim conditionsConflict As New ConditionsConflict
                conditionsConflict.SupersetLabel = Messages.CurrentConditions(culture)
                conditionsConflict.SubsetLabel = Messages.ConditionsOnCapture(culture)
                currentConditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.StaticsOnly, conditionsConflict, False)

                If Not conditionsConflict.IsEmpty Then
                    conflict.CurrentConditions = conditionsConflict
                End If

            Else
                Return result
            End If

        End Function

        Private Function AnticipatedAndCapturedConditionsConflict( _
            ByVal currentConditions As ConditionCollection, _
            ByVal conflict As SensorTaskAttemptConflict, _
            ByVal culture As CultureInfo) As Boolean

            Dim result As Boolean = Not ParentTask.Conditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.All)
            If result AndAlso conflict IsNot Nothing Then

                Dim conditionsConflict As New ConditionsConflict
                conditionsConflict.SupersetLabel = Messages.AnticipatedConditions(culture)
                conditionsConflict.SubsetLabel = Messages.ConditionsOnCapture(culture)
                ParentTask.Conditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.All, conditionsConflict, False)
                If Not conditionsConflict.IsEmpty Then
                    conflict.TargetConditions = conditionsConflict
                End If
            Else
                Return result
            End If

        End Function

        Private Function CapturedPartsNowMissing( _
            ByVal currentInaccessibleParts As BodyPartCollection, _
            ByVal conflict As SensorTaskAttemptConflict) As Boolean

            Dim result As Boolean = False

            ' See if any currently inaccessible parts that are in the target parts set are *not* 
            ' in the target captured parts

            For i As Integer = 0 To currentInaccessibleParts.Count - 1
                Dim part As BodyPart = currentInaccessibleParts(i)
                If TargetPartsOnCapture.Contains(part) AndAlso Not InaccessiblePartsOnCapture.Contains(part) Then
                    result = True

                    If conflict Is Nothing Then
                        ' If we don't track the conflict details, then we can exit
                        Return True
                    End If

                    If conflict.BodyPartCollection Is Nothing Then
                        conflict.BodyPartCollection = New BodyPartsConflict(New BodyPartCollection, New BodyPartCollection)
                    End If
                    conflict.BodyPartCollection.CapturedPartsGoneMissing.Add(part)
                End If
            Next

            Return result

        End Function

        Private Function MissingPartsRecovered( _
            ByVal currentInaccessibleParts As BodyPartCollection, _
            ByVal conflict As SensorTaskAttemptConflict) As Boolean

            Dim result As Boolean = False

            For i As Integer = 0 To InaccessiblePartsOnCapture.Count - 1
                Dim part As BodyPart = InaccessiblePartsOnCapture(i)

                If Not currentInaccessibleParts.Contains(part) Then
                    result = True
                    If conflict Is Nothing Then
                        ' If we don't track the conflict details, then we can exit
                        Return True
                    End If

                    If conflict.BodyPartCollection Is Nothing Then
                        conflict.BodyPartCollection = New BodyPartsConflict(New BodyPartCollection, New BodyPartCollection)
                    End If
                    conflict.BodyPartCollection.MissingPartsRecovered.Add(part)
                End If

            Next

            Return result
        End Function

        Private Function ParentTaskAlreadyHasSuccess(ByVal conflict As SensorTaskAttemptConflict) As Boolean
            If Not HasSuccessfulCapture Then Return False

            Dim result As Boolean

            Dim startIndex As Integer = ParentTask.Attempts.IndexOf(Me)

            If startIndex = -1 Then
                ' If the start index is -1 then we're dealing with a deep copy. We must
                ' use the timestamp instead of .Equals because we may be making changes!
                For i As Integer = 0 To ParentTask.Attempts.Count - 1
                    If ParentTask.Attempts(i).Timestamp.Equals(Me.Timestamp) Then startIndex = i
                Next

            End If

            For i As Integer = startIndex + 1 To ParentTask.Attempts.Count - 1
                If ParentTask.Attempts(i).HasSuccessfulCapture Then
                    result = True
                    If conflict Is Nothing Then Return True
                    conflict.ExistingSuccess = New ExistingSuccessConflict(Me, ParentTask.Attempts(i))
                End If
            Next

            Return result

        End Function

        Private Function CategoryChanged(ByVal conflict As SensorTaskAttemptConflict) As Boolean

            Dim result As Boolean = ParentTask.TargetCategory <> CapturedCategory
            If result AndAlso conflict IsNot Nothing Then
                conflict.Category = New CategoryConflict(ParentTask.TargetCategory, CapturedCategory)
            Else
                Return result
            End If

        End Function



        Private Function ExcessiveTasks(ByVal conflict As SensorTaskAttemptConflict) As Boolean

            Dim result As Boolean = ParentTask.IsExcess AndAlso HasCaptureResults
            If result Then
                For i As Integer = 0 To ParentTask.OriginatingFactory.GeneratedTasks.Count - 1

                    Dim task As SensorTask = ParentTask.OriginatingFactory.GeneratedTasks(i)

                    If Not task.IsExcess AndAlso Satisfies(task, ConditionsMatchStyle.All) Then
                        result = True
                        If conflict Is Nothing Then Return True
                        conflict.ExcessiveTask = New ExcessiveTaskConflict(Me)
                    End If

                Next

            Else
                Return result
            End If

        End Function


        Private Function OldInConflict( _
            ByVal currentConditions As ConditionCollection, _
            ByVal currentInaccessibleParts As BodyPartCollection, _
            ByVal conflict As SensorTaskAttemptConflict, _
            ByVal culture As CultureInfo) As Boolean


            ' Attempts of disabled tasks are in conflict
            If ParentTask.OriginatingFactory.Prerequisite.Evaluate = False Then
                If conflict Is Nothing Then
                    Return True
                End If
                conflict.UnmetPrerequisite = New UnmetPrerequisiteConflict(ParentTask.OriginatingFactory.Prerequisite)
            End If

            ' Check for conflict between *current* (static) conditions, and conditions *on capture*. 
            If conflict Is Nothing Then
                If Not currentConditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.StaticsOnly) Then
                    Return True
                End If
            Else

                Dim conditionsConflict As New ConditionsConflict
                conditionsConflict.SupersetLabel = Messages.CurrentConditions(culture)
                conditionsConflict.SubsetLabel = Messages.ConditionsOnCapture(culture)
                currentConditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.StaticsOnly, conditionsConflict, False)

                If Not conditionsConflict.IsEmpty Then
                    ' If there was a conditions conflict, then we need to attach it to the conflict class; otherwise it stays as Nothing
                    conflict.CurrentConditions = conditionsConflict
                End If
            End If




            ' Check for conflicts between *anticipated* conditions (all) and conditions *on capture*
            If conflict Is Nothing Then
                If Not ParentTask.Conditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.All) Then
                    Return True
                End If
            Else
                Dim conditionsConflict As New ConditionsConflict
                conditionsConflict.SupersetLabel = Messages.AnticipatedConditions(culture)
                conditionsConflict.SubsetLabel = Messages.ConditionsOnCapture(culture)
                ParentTask.Conditions.EqualsSubset(CapturedConditions, ConditionsMatchStyle.All, conditionsConflict, False)
                If Not conditionsConflict.IsEmpty Then
                    conflict.TargetConditions = conditionsConflict
                End If
            End If


            ' Flush any previous parts
            If Not conflict Is Nothing AndAlso Not conflict.BodyPartCollection Is Nothing Then
                conflict.BodyPartCollection = Nothing
            End If

            ' See if any currently inaccessible parts that are in the target parts set are *not* 
            ' in the target captured parts

            For i As Integer = 0 To currentInaccessibleParts.Count - 1
                Dim part As BodyPart = currentInaccessibleParts(i)
                If TargetPartsOnCapture.Contains(part) AndAlso Not InaccessiblePartsOnCapture.Contains(part) Then

                    If conflict Is Nothing Then
                        ' If we don't track the conflict details, then we can exit
                        Return True
                    End If

                    If conflict.BodyPartCollection Is Nothing Then
                        conflict.BodyPartCollection = New BodyPartsConflict(New BodyPartCollection, New BodyPartCollection)
                    End If
                    conflict.BodyPartCollection.CapturedPartsGoneMissing.Add(part)
                End If
            Next

            ' Also check to see if any inaccessible parts on capture are now no longer considered missing
            For i As Integer = 0 To InaccessiblePartsOnCapture.Count - 1
                Dim part As BodyPart = InaccessiblePartsOnCapture(i)

                If Not currentInaccessibleParts.Contains(part) Then

                    If conflict Is Nothing Then
                        ' If we don't track the conflict details, then we can exit
                        Return True
                    End If

                    If conflict.BodyPartCollection Is Nothing Then
                        conflict.BodyPartCollection = New BodyPartsConflict(New BodyPartCollection, New BodyPartCollection)
                    End If
                    conflict.BodyPartCollection.MissingPartsRecovered.Add(part)
                End If

            Next

            '
            ' ExistingSuccess
            '
            If HasSuccessfulCapture Then

                Dim startIndex As Integer = ParentTask.Attempts.IndexOf(Me)

                If startIndex = -1 Then
                    ' If the start index is -1 then we're dealing with a deep copy. We must
                    ' use the timestamp instead of .Equals because we may be making changes!
                    For i As Integer = 0 To ParentTask.Attempts.Count - 1
                        If ParentTask.Attempts(i).Timestamp.Equals(Me.Timestamp) Then startIndex = i
                    Next

                End If

                For i As Integer = startIndex + 1 To ParentTask.Attempts.Count - 1
                    If ParentTask.Attempts(i).HasSuccessfulCapture Then
                        If conflict Is Nothing Then Return True
                        conflict.ExistingSuccess = New ExistingSuccessConflict(Me, ParentTask.Attempts(i))
                    End If
                Next

            End If

            '
            ' Category
            '
            If ParentTask.TargetCategory <> CapturedCategory Then
                If conflict Is Nothing Then
                    Return True
                End If
                conflict.Category = New CategoryConflict(ParentTask.TargetCategory, CapturedCategory)
            End If


            '
            ' Excessive tasks
            '
            If ParentTask.IsExcess AndAlso Me.HasCaptureResults Then

                ' Only check to see if the task is excessive if it is an excess task
                For i As Integer = 0 To ParentTask.OriginatingFactory.GeneratedTasks.Count - 1

                    Dim task As SensorTask = ParentTask.OriginatingFactory.GeneratedTasks(i)

                    If Not task.IsExcess AndAlso Satisfies(task, ConditionsMatchStyle.All) Then
                        If conflict Is Nothing Then Return True
                        conflict.ExcessiveTask = New ExcessiveTaskConflict(Me)
                    End If

                Next

            End If


            If conflict Is Nothing Then Return False
            Return Not conflict.IsEmpty

        End Function



        Friend Function InConflict( _
            ByVal currentConditions As ConditionCollection, _
            ByVal currentInaccessibleParts As BodyPartCollection, _
            ByVal conflict As SensorTaskAttemptConflict, _
            ByVal culture As CultureInfo) As Boolean

            Dim quiet As Boolean = conflict Is Nothing

            If AttemptBelongsToDisabledFactory(conflict) AndAlso quiet Then Return True
            If CurrentAndCapturedConditionsConflict(currentConditions, conflict, culture) AndAlso quiet Then Return True
            If AnticipatedAndCapturedConditionsConflict(currentConditions, conflict, culture) AndAlso quiet Then Return True

            ' Flush any previous parts
            If Not conflict Is Nothing AndAlso Not conflict.BodyPartCollection Is Nothing Then conflict.BodyPartCollection = Nothing

            If CapturedPartsNowMissing(currentInaccessibleParts, conflict) AndAlso quiet Then Return True
            If MissingPartsRecovered(currentInaccessibleParts, conflict) AndAlso quiet Then Return True

            If ParentTaskAlreadyHasSuccess(conflict) AndAlso quiet Then Return True
            If CategoryChanged(conflict) AndAlso quiet Then Return True
            If ExcessiveTasks(conflict) AndAlso quiet Then Return True

            If conflict Is Nothing Then
                Return False
            Else
                Return conflict.IsEmpty
            End If

        End Function

        Public ReadOnly Property Satisfies(ByVal task As SensorTask, ByVal style As ConditionsMatchStyle) As Boolean
            Get
                If task Is Nothing Then Throw New ArgumentNullException("task")

                If task.Status = SensorTaskStatus.Done Then Return False

                Dim activatable As Boolean = task.IsActivatable
                Dim attemptCountOK As Boolean = task.Attempts.Count < task.MaximumAttempts
                Dim prereqOK As Boolean = task.OriginatingFactory.Prerequisite.Evaluate
                Dim conditionsOK As Boolean = task.Conditions.EqualsSubset(CapturedConditions, style)
                Dim targetPartsOK As Boolean = task.TargetParts.Equals(TargetPartsOnCapture)
                Dim inaccessiblePartsOK As Boolean = task.TargetInaccessibleParts.Equals(InaccessiblePartsOnCapture)
                Dim categoryOK As Boolean = CapturedCategory.Equals(task.TargetCategory)

                Return _
                    activatable AndAlso _
                    attemptCountOK AndAlso _
                    prereqOK AndAlso _
                    conditionsOK AndAlso _
                    targetPartsOK AndAlso _
                    categoryOK AndAlso _
                    inaccessiblePartsOK

            End Get
        End Property

        Public ReadOnly Property Satisfies(ByVal factory As SensorTaskFactory) As Boolean
            Get
                If factory Is Nothing Then Throw New ArgumentNullException("factory")
                Dim sensorOK As Boolean = factory.Sensor Is ParentTask.Sensor
                Dim prereqOK As Boolean = factory.Prerequisite.Evaluate
                Dim categoryOK As Boolean = factory.Category = CapturedCategory

                ' All of the conditions during capture must be satisfied by the factory (not the other way around, since
                ' a factory might not contain all of the relevant conditions).
                Dim conditionsOK As Boolean = factory.ConditionFactories.CreateConditionCollection().EqualsSubset(CapturedConditions)

                Return prereqOK AndAlso conditionsOK AndAlso categoryOK AndAlso sensorOK

            End Get
        End Property

        Public ReadOnly Property ParentTask() As SensorTask
            Get
                Return mParentTask
            End Get
        End Property

        Public ReadOnly Property DownloadCommandId() As Guid
            Get
                Return mDefinition.DownloadId
            End Get
        End Property

        Friend Sub WireParentTask(ByVal parentTask As SensorTask)
            mParentTask = parentTask
        End Sub


        Public Overloads Function ToString() As String
            Return ToString(CultureInfo.CurrentUICulture)
        End Function

        Public Overloads Function ToString(ByVal formatter As IFormatProvider) As String
            Using writer As New IO.StringWriter(formatter)
                Dim factory As SensorTaskFactory = ParentTask.OriginatingFactory
                writer.Write(factory.ParentSensorTaskFactories.IndexOf(factory))
                writer.Write(UI.GlobalUISettings.StringConstants.Space)
                writer.Write(factory.GeneratedTasks.IndexOf(ParentTask))
                writer.Write(UI.GlobalUISettings.StringConstants.Space)
                writer.Write(ParentTask.Attempts.IndexOf(Me))
                ToString = writer.ToString
            End Using
        End Function

        Public Sub New()
            ' Required for serialization
        End Sub


        Public Sub New( _
            ByVal parentTask As SensorTask, _
            ByVal conditions As ConditionCollection, _
            ByVal targetParts As BodyPartCollection, _
            ByVal inaccessibleParts As BodyPartCollection, _
            ByVal thumbnail As Image, _
            ByVal results As CaptureResultCollection, _
            ByVal captureFailure As SensorTaskFailure, _
            ByVal downloadId As Guid, _
            ByVal withDownloadStage As Boolean, _
            ByVal rejected As Boolean, _
            ByVal corrupt As Boolean, _
            ByVal conflictIgnore As Boolean)

            If parentTask Is Nothing Then Throw New ArgumentNullException("parentTask")

            mDefinition.Timestamp = DateTime.UtcNow

            mParentTask = parentTask
            mDefinition.CapturedCategory = parentTask.TargetCategory
            mCapturedConditions = conditions
            mDefinition.TargetPartsOnCapture.Assign(targetParts)
            mDefinition.InaccessiblePartsOnCapture = inaccessibleParts
            mThumbnail = thumbnail
            mCaptureResults = results
            mDefinition.CaptureFailure = captureFailure
            mDefinition.DownloadId = downloadId
            mDefinition.HasDownloadStage = withDownloadStage
            mDefinition.IsRejected = rejected
            mDefinition.HasCorruptImage = corrupt
            mDefinition.IsConflictIgnored = conflictIgnore


        End Sub



        Public Function DeepCopyEditables() As SensorTaskAttempt


            Dim attempt As New SensorTaskAttempt( _
                ParentTask:=mParentTask, _
                conditions:=mCapturedConditions.DeepCopy, _
                targetParts:=mDefinition.TargetPartsOnCapture.DeepCopy, _
                inaccessibleParts:=mDefinition.InaccessiblePartsOnCapture.DeepCopy, _
                thumbnail:=mThumbnail, _
                results:=mCaptureResults, _
                captureFailure:=mDefinition.CaptureFailure, _
                downloadId:=mDefinition.DownloadId, _
                withDownloadStage:=mDefinition.HasDownloadStage, _
                rejected:=mDefinition.IsRejected, _
                corrupt:=mDefinition.HasCorruptImage, _
                ConflictIgnore:=mDefinition.IsConflictIgnored)


            With attempt.mDefinition
                .ManuallyCorrected = mDefinition.ManuallyCorrected
                .DownloadFailure = mDefinition.DownloadFailure
                .DownloadComplete = mDefinition.DownloadComplete
                .AcceptedAsIs = mDefinition.AcceptedAsIs
                .Timestamp = mDefinition.Timestamp
            End With

            Return attempt
        End Function


        Public Overloads Function Equals(ByVal attempt As SensorTaskAttempt) As Boolean
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")

            Dim result As Boolean = True

            With attempt
                result = result AndAlso .mThumbnail Is ThumbnailImage
                result = result AndAlso .mCaptureResults Is CaptureResults
                result = result AndAlso .mCapturedConditions IsNot Nothing AndAlso .mCapturedConditions.EqualsSubset(mCapturedConditions, ConditionsMatchStyle.AllWithoutEquivalenceClasses)
            End With

            With attempt.mDefinition
                result = result AndAlso .TargetPartsOnCapture.Equals(mDefinition.TargetPartsOnCapture)
                result = result AndAlso .CapturedCategory = mDefinition.CapturedCategory
                result = result AndAlso .InaccessiblePartsOnCapture.Equals(mDefinition.InaccessiblePartsOnCapture)
                result = result AndAlso .TimeoutReason = mDefinition.TimeoutReason
                result = result AndAlso .OtherTimeoutReason = mDefinition.OtherTimeoutReason
                result = result AndAlso .DownloadId.Equals(mDefinition.DownloadId)
                result = result AndAlso .CaptureFailure IsNot Nothing AndAlso .CaptureFailure.Equals(mDefinition.CaptureFailure)
                result = result AndAlso .DownloadFailure IsNot Nothing AndAlso .DownloadFailure.Equals(mDefinition.DownloadFailure)
                result = result AndAlso .HasCorruptImage = mDefinition.HasDownloadStage
                result = result AndAlso .IsRejected = mDefinition.IsRejected
                result = result AndAlso .HasCorruptImage = mDefinition.HasCorruptImage
                result = result AndAlso .ManuallyCorrected = mDefinition.ManuallyCorrected
                result = result AndAlso .DownloadComplete = mDefinition.DownloadComplete
                result = result AndAlso .AcceptedAsIs = mDefinition.AcceptedAsIs
                result = result AndAlso .Timestamp = mDefinition.Timestamp
            End With

            Return result

        End Function

    End Class

    <XmlType("Attempt"), Serializable()> _
    Public Class SensorTaskAttemptDefinition
        Implements ICloneable

#Region "Private"

        Private mAcceptedAsIs As Boolean
        Private mCapturedCategory As SensorTaskCategory
        Private mCapturedConditionsDefinition As ConditionCollectionDefinition

        Private mCaptureFailure As SensorTaskFailure
        Private mCaptureResultsDefinition As CaptureResultCollectionDefinition


        Private mDownloadComplete As Boolean
        Private mDownloadFailure As SensorTaskFailure
        Private mDownloadId As Guid = Guid.Empty

        Private mHasCorruptImage As Boolean
        Private mHasDownloadStage As Boolean
        Private mInaccessiblePartsOnCapture As New BodyPartCollection

        Private mIsConflictIgnored As Boolean

        Private mIsRejected As Boolean

        Private mManuallyCorrected As Boolean
        Private mOtherTimeoutReason As String
        Private mTargetPartsOnCapture As New BodyPartCollection

        Private mThumbnailDefinition As ImagePropertiesDefinition

        Private mTimeoutReason As TimeoutDetailForm.TimeoutReason
        Private mTimestamp As DateTime
#End Region

#Region "Properties"

        Public Property AcceptedAsIs() As Boolean
            Get
                Return mAcceptedAsIs
            End Get
            Set(ByVal Value As Boolean)
                mAcceptedAsIs = Value
            End Set
        End Property
        Public Property DownloadComplete() As Boolean
            Get
                Return mDownloadComplete
            End Get
            Set(ByVal Value As Boolean)
                mDownloadComplete = Value
            End Set
        End Property
        Public Property IsConflictIgnored() As Boolean
            Get
                Return mIsConflictIgnored
            End Get
            Set(ByVal Value As Boolean)
                mIsConflictIgnored = Value
            End Set
        End Property
        Public Property ManuallyCorrected() As Boolean
            Get
                Return mManuallyCorrected
            End Get
            Set(ByVal Value As Boolean)
                mManuallyCorrected = Value
            End Set
        End Property
        Public Property CapturedCategory() As SensorTaskCategory
            Get
                Return mCapturedCategory
            End Get
            Set(ByVal value As SensorTaskCategory)
                mCapturedCategory = value
            End Set
        End Property
        <XmlElement("CapturedConditions")> Public Property CapturedConditionsDefinition() As ConditionCollectionDefinition
            Get
                Return mCapturedConditionsDefinition
            End Get
            Set(ByVal value As ConditionCollectionDefinition)
                mCapturedConditionsDefinition = value
            End Set
        End Property
        Public ReadOnly Property TargetPartsOnCapture() As BodyPartCollection
            Get
                Return mTargetPartsOnCapture
            End Get
        End Property
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")> _
        Public Property InaccessiblePartsOnCapture() As BodyPartCollection
            Get
                Return mInaccessiblePartsOnCapture
            End Get
            Set(ByVal value As BodyPartCollection)
                mInaccessiblePartsOnCapture = value
            End Set
        End Property
        <XmlElement("Thumbnail")> Public Property ThumbnailDefinition() As ImagePropertiesDefinition
            Get
                Return mThumbnailDefinition
            End Get
            Set(ByVal value As ImagePropertiesDefinition)
                mThumbnailDefinition = value
            End Set
        End Property
        <XmlElement("CaptureResults")> Public Property CaptureResultsDefinition() As CaptureResultCollectionDefinition
            Get
                Return mCaptureResultsDefinition
            End Get
            Set(ByVal value As CaptureResultCollectionDefinition)
                mCaptureResultsDefinition = value
            End Set
        End Property
        Public Property TimeoutReason() As TimeoutDetailForm.TimeoutReason
            Get
                Return mTimeoutReason
            End Get
            Set(ByVal value As TimeoutDetailForm.TimeoutReason)
                mTimeoutReason = value
            End Set
        End Property
        Public Property OtherTimeoutReason() As String
            Get
                Return mOtherTimeoutReason
            End Get
            Set(ByVal value As String)
                mOtherTimeoutReason = value
            End Set
        End Property
        Public Property DownloadId() As Guid
            Get
                Return mDownloadId
            End Get
            Set(ByVal value As Guid)
                mDownloadId = value
            End Set
        End Property
        Public Property CaptureFailure() As SensorTaskFailure
            Get
                Return mCaptureFailure
            End Get
            Set(ByVal Value As SensorTaskFailure)
                mCaptureFailure = Value
            End Set
        End Property
        Public Property DownloadFailure() As SensorTaskFailure
            Get
                Return mDownloadFailure
            End Get
            Set(ByVal Value As SensorTaskFailure)
                mDownloadFailure = Value
            End Set
        End Property
        Public Property HasDownloadStage() As Boolean
            Get
                Return mHasDownloadStage
            End Get
            Set(ByVal Value As Boolean)
                mHasDownloadStage = Value
            End Set
        End Property
        Public Property IsRejected() As Boolean
            Get
                Return mIsRejected
            End Get
            Set(ByVal Value As Boolean)
                mIsRejected = Value
            End Set
        End Property
        Public Property HasCorruptImage() As Boolean
            Get
                Return mHasCorruptImage
            End Get
            Set(ByVal Value As Boolean)
                mHasCorruptImage = Value
            End Set
        End Property
        Public Property Timestamp() As DateTime
            Get
                Return mTimestamp
            End Get
            Set(ByVal Value As DateTime)
                mTimestamp = Value
            End Set
        End Property
#End Region

#Region " Clone and Deep Copy"

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New SensorTaskAttemptDefinition
            With newDef

                .CapturedCategory = CapturedCategory

                If CapturedConditionsDefinition IsNot Nothing Then
                    .CapturedConditionsDefinition = CapturedConditionsDefinition.DeepCopy
                End If

                If TargetPartsOnCapture IsNot Nothing Then
                    .TargetPartsOnCapture.Assign(TargetPartsOnCapture.DeepCopy)
                End If

                If InaccessiblePartsOnCapture IsNot Nothing Then
                    .InaccessiblePartsOnCapture = InaccessiblePartsOnCapture.DeepCopy
                End If

                If ThumbnailDefinition IsNot Nothing Then
                    .ThumbnailDefinition = ThumbnailDefinition.DeepCopy
                End If

                If Not CaptureResultsDefinition Is Nothing Then
                    .CaptureResultsDefinition = CaptureResultsDefinition.DeepCopy
                End If

                .TimeoutReason = TimeoutReason
                .OtherTimeoutReason = OtherTimeoutReason

                .DownloadId = DownloadId
                .CaptureFailure = CaptureFailure
                .DownloadFailure = DownloadFailure

                .HasDownloadStage = HasDownloadStage

                .IsRejected = IsRejected
                .HasCorruptImage = HasCorruptImage

                .ManuallyCorrected = ManuallyCorrected
                .DownloadComplete = DownloadComplete
                .AcceptedAsIs = AcceptedAsIs

                .Timestamp = Timestamp

            End With
            Return newDef

        End Function

        Public Function DeepCopy() As SensorTaskAttemptDefinition
            Return DirectCast(Clone(), SensorTaskAttemptDefinition)
        End Function
#End Region

        Public Function CreateTaskAttempt( _
            ByVal parentTask As SensorTask, _
            ByVal strings As LocalizableStringCollection, _
            ByVal conditionFactories As ConditionFactoryCollection) As SensorTaskAttempt

            Dim attempt As New SensorTaskAttempt

            attempt.mParentTask = parentTask
            attempt.mCapturedConditions = CapturedConditionsDefinition.CreateConditionCollection(strings, conditionFactories)

            attempt.mThumbnail = Me.ThumbnailDefinition.CreateImageProperties.Image
            If Not CaptureResultsDefinition Is Nothing Then
                attempt.mCaptureResults = Me.CaptureResultsDefinition.CreateCaptureResultCollection
            End If
            attempt.mDefinition = Me.DeepCopy

            If attempt.HasDownloadStage AndAlso attempt.NeedsDownload Then
                Dim failure As New SensorTaskFailure(New DownloadFailureException("Download never completed."))
                attempt.MarkAsHavingDownloadFailure(failure)
            End If

            Return attempt

        End Function

        Public Sub New()
            ' Required for serialization
        End Sub


    End Class

End Namespace
