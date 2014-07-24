Option Strict On

Namespace Mbark.Sensors

    <Serializable()> Public Class SensorWorkflowSettings

        Private mTaskDefinitionFileName As String = "Configurations\Empty.xml"
        Private mCheckOutstandingConflictOnComplete As Boolean
        Private mPassiveSensorsStartAutomatically As Boolean
        Private mIncludeSensorsOfDisabledTasks As Boolean
        Private mSkippingEffectsMultipleTasks As Boolean
        Private mDeleteInternalImagesOnSetCompletion As Boolean = True
        Private mSensorPromptForDetailOnTimeout As Boolean
        Private mSensorTimeoutsAreAlwaysFailures As Boolean = True
        Private mSensorCancellationAreAlwaysFailures As Boolean
        Private mUninitializeSensorsOfCorruptImages As Boolean
        Private mTaskSetsStartAutomatically As Boolean

        Public Property CheckOutstandingConflictOnComplete() As Boolean
            Get
                Return mCheckOutstandingConflictOnComplete
            End Get
            Set(ByVal value As Boolean)
                mCheckOutstandingConflictOnComplete = value
            End Set
        End Property
        Public Property TaskDefinitionFileName() As String
            Get
                Return mTaskDefinitionFileName
            End Get
            Set(ByVal value As String)
                mTaskDefinitionFileName = value
            End Set
        End Property
        Public Property PassiveSensorsStartAutomatically() As Boolean
            Get
                Return mPassiveSensorsStartAutomatically
            End Get
            Set(ByVal value As Boolean)
                mPassiveSensorsStartAutomatically = value
            End Set
        End Property
        Public Property IncludeSensorsOfDisabledTasks() As Boolean
            Get
                Return mIncludeSensorsOfDisabledTasks
            End Get
            Set(ByVal value As Boolean)
                mIncludeSensorsOfDisabledTasks = value
            End Set
        End Property
        Public Property SkippingEffectsMultipleTasks() As Boolean
            Get
                Return mSkippingEffectsMultipleTasks
            End Get
            Set(ByVal value As Boolean)
                mSkippingEffectsMultipleTasks = value
            End Set
        End Property
        Public Property DeleteInternalImagesOnSetCompletion() As Boolean
            Get
                Return mDeleteInternalImagesOnSetCompletion
            End Get
            Set(ByVal value As Boolean)
                mDeleteInternalImagesOnSetCompletion = value
            End Set
        End Property
        Public Property SensorPromptForDetailOnTimeout() As Boolean
            Get
                Return mSensorPromptForDetailOnTimeout
            End Get
            Set(ByVal value As Boolean)
                mSensorPromptForDetailOnTimeout = value
            End Set
        End Property
        Public Property SensorTimeoutsAreAlwaysFailures() As Boolean
            Get
                Return mSensorTimeoutsAreAlwaysFailures
            End Get
            Set(ByVal value As Boolean)
                mSensorTimeoutsAreAlwaysFailures = value
            End Set
        End Property
        Public Property SensorCancellationAreAlwaysFailures() As Boolean
            Get
                Return mSensorCancellationAreAlwaysFailures
            End Get
            Set(ByVal value As Boolean)
                mSensorCancellationAreAlwaysFailures = value
            End Set
        End Property
        Public Property UninitializeSensorsOfCorruptImages() As Boolean
            Get
                Return mUninitializeSensorsOfCorruptImages
            End Get
            Set(ByVal value As Boolean)
                mUninitializeSensorsOfCorruptImages = value
            End Set
        End Property

        Public Property TaskSetsStartAutomatically() As Boolean
            Get
                Return mTaskSetsStartAutomatically
            End Get
            Set(ByVal value As Boolean)
                mTaskSetsStartAutomatically = value
            End Set
        End Property


    End Class

End Namespace