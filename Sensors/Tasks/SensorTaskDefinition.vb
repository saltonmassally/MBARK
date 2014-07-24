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

Namespace Mbark.Sensors


    <XmlType("SensorTask"), Serializable()> _
    Public Class SensorTaskDefinition
        Implements ICloneable

        ' •—————————————————————————————————————————————————————————————————————————————————•
        ' | This class describes the auto-serializable components of SensorTask             |
        ' •—————————————————————————————————————————————————————————————————————————————————•

#Region "Private"


        Private mAttemptsDefinition As SensorTaskAttemptCollectionDefinition
        Private mColorsDefinition As SensorTaskColorsDefinition
        Private mDownloadsPaused As Boolean
        Private mIsBlocked As Boolean
        Private mMaximumAttempts As Integer
        Private mName As String
        Private mRepetition As Integer
        Private mSensorConfiguration As SensorConfiguration
        Private mSkipDestination As Boolean
        Private mStatus As SensorTaskStatus
        Private mTargetCategory As SensorTaskCategory
        Private mTargetConditionsDefinition As ConditionCollectionDefinition
        Private mTargetInaccessibleParts As New BodyPartCollection
        Private mTargetParts As New BodyPartCollection
#End Region

#Region "Properties"

        <XmlElement("Attempts")> Public Property AttemptsDefinition() As SensorTaskAttemptCollectionDefinition
            Get
                Return mAttemptsDefinition
            End Get
            Set(ByVal Value As SensorTaskAttemptCollectionDefinition)
                mAttemptsDefinition = Value
            End Set
        End Property
        
        <XmlElement("Colors")> Public Property ColorsDefinition() As SensorTaskColorsDefinition
            Get
                Return mColorsDefinition
            End Get
            Set(ByVal Value As SensorTaskColorsDefinition)
                mColorsDefinition = Value
            End Set
        End Property
        Public Property DownloadsPaused() As Boolean
            Get
                Return mDownloadsPaused
            End Get
            Set(ByVal Value As Boolean)
                mDownloadsPaused = Value
            End Set
        End Property
     
        Public Property IsBlocked() As Boolean
            Get
                Return mIsBlocked
            End Get
            Set(ByVal Value As Boolean)
                mIsBlocked = Value
            End Set
        End Property
        Public Property MaximumAttempts() As Integer
            Get
                Return mMaximumAttempts
            End Get
            Set(ByVal Value As Integer)
                mMaximumAttempts = Value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal Value As String)
                mName = Value
            End Set
        End Property
        Public Property Repetition() As Integer
            Get
                Return mRepetition
            End Get
            Set(ByVal Value As Integer)
                mRepetition = Value
            End Set
        End Property
        Public Property SensorConfiguration() As SensorConfiguration
            Get
                Return mSensorConfiguration
            End Get
            Set(ByVal Value As SensorConfiguration)
                mSensorConfiguration = Value
            End Set
        End Property
        Public Property SkipDestination() As Boolean
            Get
                Return mSkipDestination
            End Get
            Set(ByVal Value As Boolean)
                mSkipDestination = Value
            End Set
        End Property
        Public Property Status() As SensorTaskStatus
            Get
                Return mStatus
            End Get
            Set(ByVal Value As SensorTaskStatus)
                mStatus = Value
            End Set
        End Property
        Public Property TargetCategory() As SensorTaskCategory
            Get
                Return mTargetCategory
            End Get
            Set(ByVal Value As SensorTaskCategory)
                mTargetCategory = Value
            End Set
        End Property
        <XmlElement("TargetConditions")> Public Property TargetConditionsDefinition() As ConditionCollectionDefinition
            Get
                Return mTargetConditionsDefinition
            End Get
            Set(ByVal Value As ConditionCollectionDefinition)
                mTargetConditionsDefinition = Value
            End Set
        End Property
        Public ReadOnly Property TargetInaccessibleParts() As BodyPartCollection
            Get
                Return mTargetInaccessibleParts
            End Get
        End Property
        Public ReadOnly Property TargetParts() As BodyPartCollection
            Get
                Return mTargetParts
            End Get
        End Property
#End Region

#Region "Clone and DeepCopy"


        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New SensorTaskDefinition

            With newDef

                .Name = Name
                .TargetCategory = TargetCategory

                .TargetParts.AddRange(TargetParts.DeepCopy)
                .TargetInaccessibleParts.Assign(TargetInaccessibleParts)

                If Me.TargetConditionsDefinition IsNot Nothing Then
                    .TargetConditionsDefinition = TargetConditionsDefinition.DeepCopy
                End If


                If Me.SensorConfiguration IsNot Nothing Then
                    .SensorConfiguration = Me.SensorConfiguration.DeepCopy
                End If

                .MaximumAttempts = MaximumAttempts
                .Repetition = Repetition

                '.Enabled = Enabled
                .Status = Status
                .IsBlocked = IsBlocked
                .SkipDestination = SkipDestination
                .DownloadsPaused = DownloadsPaused

                If Me.ColorsDefinition IsNot Nothing Then
                    .ColorsDefinition = ColorsDefinition.DeepCopy
                End If

                If Me.AttemptsDefinition IsNot Nothing Then
                    .AttemptsDefinition = AttemptsDefinition.DeepCopy
                End If
                
            End With

            Return newDef
        End Function

        Public Function DeepCopy() As SensorTaskDefinition
            Return DirectCast(Clone(), SensorTaskDefinition)
        End Function
#End Region

#Region "Reconstitution"

        Public Function CreateSensorTask( _
            ByVal originatingFactory As SensorTaskFactory, _
            ByVal strings As LocalizableStringCollection, _
            ByVal conditionFactories As ConditionFactoryCollection) As SensorTask

            If originatingFactory Is Nothing Then Throw New ArgumentNullException("originatingFactory")

            Dim task As New SensorTask

            With task
                .mDefinition = Me.DeepCopy
                .mConditions = TargetConditionsDefinition.CreateConditionCollection(strings, conditionFactories)
                .mColors = ColorsDefinition.CreateSensorTaskColors
                .mAttempts = AttemptsDefinition.CreateSensorTaskAttemptCollection(task, strings, conditionFactories)
                .mOriginatingFactory = originatingFactory
                .mSensor = originatingFactory.Sensor

                If .mDefinition.Status = SensorTaskStatus.Done AndAlso _
                    Not .ReachedFailureLimit AndAlso _
                    Not .HasSuccessfulCapture Then
                    '
                    ' A 'done' task without a successful capture shouldn't happen. This handles it, but how did we
                    ' get into this state?
                    '
                    .mDefinition.Status = SensorTaskStatus.Suspended
                End If

                If .mDefinition.Status = SensorTaskStatus.Downloading Then
                    ' Tasks saved in mid-download should not be reconstituted as such
                    .mDefinition.Status = SensorTaskStatus.Suspended
                End If

            End With

            Return task
        End Function
#End Region

    End Class

End Namespace
