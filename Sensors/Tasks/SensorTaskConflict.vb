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

Imports System.IO
Imports System.Globalization
Imports System.Windows.Forms

Imports Mbark.UI.GlobalUISettings
Imports Mbark.SensorMessages

' A task is InConflict if:
'   - The captured conditions and/or body parts do not match the target conditions, OR
'   - the task is NotPossible, yet the task is Done
'   - or, if the task is active and the current conditions and/or body parts do not match the target

Namespace Mbark.Sensors


    Public MustInherit Class BaseSensorTaskAttemptConflict
        Public MustOverride Function ToRtf(ByVal culture As CultureInfo, ByVal standalone As Boolean) As String
        Protected Sub New()
            ' Forbid construction
        End Sub
    End Class

    Public Class UnmetPrerequisiteConflict
        Inherits BaseSensorTaskAttemptConflict

        Protected Sub New()
            ' Forbid construction of abstract class
        End Sub

        Private mPrerequisite As Predicate
        Public ReadOnly Property Prerequisite() As Predicate
            Get
                Return mPrerequisite
            End Get
        End Property
        Public Sub New(ByVal unmetPrerequisite As Predicate)
            MyBase.new()
            mPrerequisite = unmetPrerequisite
        End Sub
        Public Overrides Function ToString() As String
            Return mPrerequisite.UnmetPrerequisiteMessage.Message(CultureInfo.CurrentUICulture.Name)
        End Function

        Public Overrides Function ToRtf(ByVal culture As CultureInfo, ByVal standalone As Boolean) As String
            Dim toRtfResult As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            If standalone Then writer.Write(Rtf.Header())
            writer.Write(Rtf.ToRtf(mPrerequisite.ToString))
            If standalone Then writer.Write(Rtf.Footer)
            toRtfResult = writer.ToString
            writer.Dispose()
            Return toRtfResult
        End Function
    End Class

    Public Class ExistingSuccessConflict
        Inherits BaseSensorTaskAttemptConflict

        Private mExistingSuccess As SensorTaskAttempt
        Private mNewSuccess As SensorTaskAttempt
        Public ReadOnly Property ExistingSuccess() As SensorTaskAttempt
            Get
                Return mExistingSuccess
            End Get
        End Property
        Public ReadOnly Property NewSuccess() As SensorTaskAttempt
            Get
                Return mNewSuccess
            End Get
        End Property
        Public Sub New(ByVal newSuccess As SensorTaskAttempt, ByVal existingSuccess As SensorTaskAttempt)
            mNewSuccess = newSuccess
            mExistingSuccess = existingSuccess
        End Sub

        Public Overrides Function ToRtf(ByVal culture As CultureInfo, ByVal standalone As Boolean) As String
            Using writer As New StringWriter(CultureInfo.InvariantCulture)
                If standalone Then writer.Write(Rtf.Header())
                writer.Write(Rtf.ToRtf(Messages.TaskAlreadyCompletedSuccessfully(culture)))
                If standalone Then writer.Write(Rtf.Footer)
                ToRtf = writer.ToString
            End Using
        End Function

    End Class

    Public Class BodyPartsConflict
        Inherits BaseSensorTaskAttemptConflict

        Private mMissingPartsRecovered As New BodyPartCollection
        Private mCapturedPartsGoneMissing As New BodyPartCollection

        Public ReadOnly Property MissingPartsRecovered() As BodyPartCollection
            Get
                Return mMissingPartsRecovered
            End Get
        End Property
        Public ReadOnly Property CapturedPartsGoneMissing() As BodyPartCollection
            Get
                Return mCapturedPartsGoneMissing
            End Get
        End Property

        Public Sub New(ByVal missingPartsRecovered As BodyPartCollection, ByVal capturedPartsGoneMissing As BodyPartCollection)
            mMissingPartsRecovered = missingPartsRecovered
            mCapturedPartsGoneMissing = capturedPartsGoneMissing
        End Sub

        Public Overrides Function ToRtf(ByVal culture As CultureInfo, ByVal standalone As Boolean) As String
            Dim toRtfResult As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            If standalone Then writer.Write(Rtf.Header())

            If mMissingPartsRecovered.Count > 0 Then
                writer.Write(Rtf.BoldOn)
                writer.Write(Messages.MissingPartsRecovered(culture))
                writer.Write(Rtf.BoldOff)
                writer.Write(InfrastructureMessages.Messages.ColonSpace(culture))
                writer.Write(mMissingPartsRecovered.ToString(culture))
            End If

            If mCapturedPartsGoneMissing.Count > 0 Then
                If mMissingPartsRecovered.Count > 0 Then writer.Write(Rtf.Newline)
                writer.Write(Rtf.BoldOn)
                writer.Write(Messages.CapturedPartsNowMissing(culture))
                writer.Write(InfrastructureMessages.Messages.ColonSpace(culture))
                writer.Write(Rtf.BoldOff)
                writer.Write(mCapturedPartsGoneMissing.ToString(culture))
            End If

            If standalone Then writer.Write(Rtf.Footer)
            toRtfResult = writer.ToString
            writer.Dispose()
            Return toRtfResult
        End Function

    End Class

    Public Class CategoryConflict
        Inherits BaseSensorTaskAttemptConflict

        Private mTargetCategory As SensorTaskCategory
        Private mCapturedCategory As SensorTaskCategory
        Public ReadOnly Property TargetCategory() As SensorTaskCategory
            Get
                Return mTargetCategory
            End Get
        End Property
        Public ReadOnly Property CapturedCategory() As SensorTaskCategory
            Get
                Return mCapturedCategory
            End Get
        End Property
        Public Sub New(ByVal targetCategory As SensorTaskCategory, ByVal capturedCategory As SensorTaskCategory)
            mTargetCategory = targetCategory
            mCapturedCategory = capturedCategory
        End Sub

        Public Overrides Function ToRtf(ByVal culture As CultureInfo, ByVal standalone As Boolean) As String
            Dim toRtfResult As String
            Dim writer As New StringWriter(culture)
            If standalone Then writer.Write(Rtf.Header())
            Dim fromTask As String = SensorTaskCategorySupport.ToString(mTargetCategory)
            Dim toTask As String = SensorTaskCategorySupport.ToString(mCapturedCategory)
            writer.Write(Messages.RtfTaskChangedFromT1ToT2(fromTask, toTask))
            If standalone Then writer.Write(Rtf.Footer)
            toRtfResult = writer.ToString
            writer.Dispose()
            Return toRtfResult
        End Function



    End Class

    Public Class ExcessiveTaskConflict
        Inherits BaseSensorTaskAttemptConflict

        Private mAttemptToBlame As SensorTaskAttempt
        Public ReadOnly Property AttemptToBlame() As SensorTaskAttempt
            Get
                Return mAttemptToBlame
            End Get
        End Property

        Public Sub New(ByVal attemptToBlame As SensorTaskAttempt)
            mAttemptToBlame = attemptToBlame
        End Sub

        Public Overrides Function ToRtf(ByVal culture As CultureInfo, ByVal standalone As Boolean) As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            If standalone Then writer.Write(Rtf.Header())
            writer.Write(Messages.UnnecessaryExtraTask(culture))
            If standalone Then writer.Write(Rtf.Footer)
            ToRtf = writer.ToString
            writer.Dispose()
        End Function


    End Class

    Public Class SensorTaskAttemptConflict

        Public Property UnmetPrerequisite() As UnmetPrerequisiteConflict
            Get
                Return mUnmetPrerequisite
            End Get
            Set(ByVal value As UnmetPrerequisiteConflict)
                mUnmetPrerequisite = value
            End Set
        End Property

        Public Property BodyPartCollection() As BodyPartsConflict
            Get
                Return mBodyParts
            End Get
            Set(ByVal value As BodyPartsConflict)
                mBodyParts = value
            End Set
        End Property

        Public Property TargetConditions() As ConditionsConflict
            Get
                Return mTargetConditions
            End Get
            Set(ByVal value As ConditionsConflict)
                mTargetConditions = value
            End Set
        End Property

        Public Property CurrentConditions() As ConditionsConflict
            Get
                Return mCurrentConditions
            End Get
            Set(ByVal value As ConditionsConflict)
                mCurrentConditions = value
            End Set
        End Property

        Public Property Category() As CategoryConflict
            Get
                Return mCategoryConflict
            End Get
            Set(ByVal value As CategoryConflict)
                mCategoryConflict = value
            End Set
        End Property

        Public Property ExistingSuccess() As ExistingSuccessConflict
            Get
                Return mExistingSuccess
            End Get
            Set(ByVal value As ExistingSuccessConflict)
                mExistingSuccess = value
            End Set
        End Property

        Public Property ExcessiveTask() As ExcessiveTaskConflict
            Get
                Return mExcessiveTask
            End Get
            Set(ByVal value As ExcessiveTaskConflict)
                mExcessiveTask = value
            End Set
        End Property

        Private mCategoryConflict As CategoryConflict
        Private mUnmetPrerequisite As UnmetPrerequisiteConflict
        Private mCurrentConditions As ConditionsConflict
        Private mTargetConditions As ConditionsConflict
        Private mBodyParts As BodyPartsConflict
        Private mExistingSuccess As ExistingSuccessConflict
        Private mExcessiveTask As ExcessiveTaskConflict

        Public Overloads Function ToString(ByVal formatProvider As IFormatProvider) As String
            Using writer As New System.IO.StringWriter(formatProvider)

                Dim conflictCount As Integer = 0

                If Not mUnmetPrerequisite Is Nothing Then
                    writer.Write(mUnmetPrerequisite.Prerequisite.ToString)
                    conflictCount += 1
                End If

                If Not mTargetConditions Is Nothing Then
                    If conflictCount > 0 Then writer.Write(vbNewLine)
                    writer.Write(mTargetConditions.ToString)
                    conflictCount += 1
                End If

                If Not mCurrentConditions Is Nothing Then
                    If conflictCount > 0 Then writer.Write(vbNewLine)
                    writer.Write(mCurrentConditions.ToString)
                    conflictCount += 1
                End If

                ToString = writer.ToString
            End Using

        End Function

        Public Overridable Function ToRtf(ByVal standalone As Boolean, ByVal culture As CultureInfo) As String
            Using writer As New System.IO.StringWriter(culture)

                If standalone Then writer.Write(Rtf.Header())

                Dim conflictCount As Integer = 0

                If Not mUnmetPrerequisite Is Nothing Then
                    If conflictCount > 0 Then writer.Write(Rtf.Newline)
                    writer.Write(mUnmetPrerequisite.ToRtf(culture, False))
                    conflictCount += 1
                End If


                If Not mCategoryConflict Is Nothing Then
                    If conflictCount > 0 Then writer.Write(Rtf.Newline)
                    writer.Write(mCategoryConflict.ToRtf(culture, False))
                    conflictCount += 1
                End If

                If Not mTargetConditions Is Nothing Then
                    If conflictCount > 0 Then writer.Write(Rtf.Newline)
                    writer.Write(mTargetConditions.ToRtf(culture, False))
                    conflictCount += 1
                End If

                If Not mCurrentConditions Is Nothing Then
                    If conflictCount > 0 Then writer.Write(Rtf.Newline)
                    writer.Write(mCurrentConditions.ToRtf(culture, False))
                    conflictCount += 1
                End If

                If Not mBodyParts Is Nothing Then
                    If conflictCount > 0 Then writer.Write(Rtf.Newline)
                    writer.Write(mBodyParts.ToRtf(culture, False))
                    conflictCount += 1
                End If

                If Not mExistingSuccess Is Nothing Then
                    If conflictCount > 0 Then writer.Write(Rtf.Newline)
                    writer.Write(mExistingSuccess.ToRtf(culture, False))
                    conflictCount += 1
                End If

                If Not mExcessiveTask Is Nothing Then
                    If conflictCount > 0 Then writer.Write(Rtf.Newline)
                    writer.Write(mExcessiveTask.ToRtf(culture, False))
                    conflictCount += 1
                End If



                If standalone Then writer.Write(Rtf.Footer)
                ToRtf = writer.ToString
            End Using

        End Function



        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return _
                    mUnmetPrerequisite Is Nothing AndAlso _
                    mBodyParts Is Nothing AndAlso _
                    mTargetConditions Is Nothing AndAlso _
                    mCurrentConditions Is Nothing AndAlso _
                    mExistingSuccess Is Nothing AndAlso _
                    mCategoryConflict Is Nothing AndAlso _
                    mExcessiveTask Is Nothing
            End Get
        End Property

        Friend ReadOnly Property IsOnlyCategoryConflict() As Boolean
            Get
                Return _
                    mUnmetPrerequisite Is Nothing AndAlso _
                    mBodyParts Is Nothing AndAlso _
                    mTargetConditions Is Nothing AndAlso _
                    mCurrentConditions Is Nothing AndAlso _
                    mExistingSuccess Is Nothing AndAlso _
                    Not mCategoryConflict Is Nothing AndAlso _
                    mExcessiveTask Is Nothing
            End Get
        End Property

        Public ReadOnly Property IsOnlyExistingSuccessConflict() As Boolean
            Get
                Return _
                   mUnmetPrerequisite Is Nothing AndAlso _
                   mBodyParts Is Nothing AndAlso _
                   mTargetConditions Is Nothing AndAlso _
                   mCurrentConditions Is Nothing AndAlso _
                   Not mExistingSuccess Is Nothing AndAlso _
                   mCategoryConflict Is Nothing AndAlso _
                   mExcessiveTask Is Nothing
            End Get
        End Property


        Public Sub Clear()
            mCategoryConflict = Nothing
            mUnmetPrerequisite = Nothing
            mCurrentConditions = Nothing
            mTargetConditions = Nothing
            mCategoryConflict = Nothing
            mExistingSuccess = Nothing
            mExcessiveTask = Nothing
        End Sub



    End Class

End Namespace