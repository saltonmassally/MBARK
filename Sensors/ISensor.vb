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
Imports System.IO
Imports System.Globalization

Imports Mbark.SensorMessages
Imports System.Runtime.InteropServices


Namespace Mbark.Sensors

    Public Enum SensorTaskFailureCategory
        InitializationError
        CaptureError
        ConfigurationError
        UnspecifiedCaptureTimeout
        SubjectRefuses
        SubjectLeftSession
        DownloadError
        OtherUnspecifiedError
    End Enum

    <Serializable()> Public Class SensorTaskFailure
        Implements ICloneable

        Private mCategory As SensorTaskFailureCategory
        Private mExceptionMessages As String
        Private mOperatorNotes As String
        Private mMachineNotes As String
        Private mTimestamp As DateTime
        Private mCategoryToDisplay As String

        Public Property Category() As SensorTaskFailureCategory
            Get
                Return mCategory
            End Get
            Set(ByVal value As SensorTaskFailureCategory)
                mCategory = value
            End Set
        End Property
        Public Property ExceptionMessages() As String
            Get
                Return mExceptionMessages
            End Get
            Set(ByVal value As String)
                mExceptionMessages = value
            End Set
        End Property
        Public Property OperatorNotes() As String
            Get
                Return mOperatorNotes
            End Get
            Set(ByVal value As String)
                mOperatorNotes = value
            End Set
        End Property
        Public Property MachineNotes() As String
            Get
                Return mMachineNotes
            End Get
            Set(ByVal value As String)
                mMachineNotes = value
            End Set
        End Property
        Public Property Timestamp() As DateTime
            Get
                Return mTimestamp
            End Get
            Set(ByVal value As DateTime)
                mTimestamp = value
            End Set
        End Property

        Public Sub New()
            mTimestamp = DateTime.UtcNow
        End Sub

        Public Sub New(ByVal ex As Exception)
            mTimestamp = DateTime.UtcNow

            If Not ex Is Nothing Then

                ExceptionMessages = StringUtilities.UnwindAllMessages(ex)
                Category = SensorTaskFailureCategory.OtherUnspecifiedError

                Dim pollCancelEx As PollingCanceledException = TryCast(ex, PollingCanceledException)
                If pollCancelEx IsNot Nothing Then
                    PollingCancelledNew(pollCancelEx)
                End If

                Dim initFailEx As InitializationFailureException = TryCast(ex, InitializationFailureException)
                If initFailEx IsNot Nothing Then
                    InitializationFailureNew(initFailEx)
                End If

                Dim initTimeoutEx As InitializationTimeoutException = TryCast(ex, InitializationTimeoutException)
                If initTimeoutEx IsNot Nothing Then
                    InitializationTimeoutNew(initTimeoutEx)
                End If

                Dim capFailEx As CaptureFailureException = TryCast(ex, CaptureFailureException)
                If capFailEx IsNot Nothing Then
                    CaptureFailureNew(capFailEx)
                End If

                Dim capTimeoutEx As CaptureTimeoutException = TryCast(ex, CaptureTimeoutException)
                If capTimeoutEx IsNot Nothing Then
                    CaptureTimeoutNew(capTimeoutEx)
                End If

                Dim confFailEx As ConfigurationFailureException = TryCast(ex, ConfigurationFailureException)
                If confFailEx IsNot Nothing Then
                    ConfigurationFailureNew(confFailEx)
                End If

                Dim confTimeoutEx As ConfigurationTimeoutException = TryCast(ex, ConfigurationTimeoutException)
                If confTimeoutEx IsNot Nothing Then
                    ConfigurationTimeoutNew(confTimeoutEx)
                End If

                Dim dlFailureEx As DownloadFailureException = TryCast(ex, DownloadFailureException)
                If dlFailureEx IsNot Nothing Then
                    DownloadFailureNew(dlFailureEx)
                End If

                Dim dlTimeoutEx As DownloadTimeoutException = TryCast(ex, DownloadTimeoutException)
                If dlTimeoutEx IsNot Nothing Then
                    DownloadTimeoutNew(dlTimeoutEx)
                End If

                ' rjm asks - Does trycast succeeed on base types?
                Dim sensorEx As SensorException = TryCast(ex, SensorException)
                If sensorEx IsNot Nothing Then
                    Dim sensorName As String = "Unknown sensor"
                    If Not sensorEx.Sensor Is Nothing Then sensorName = sensorEx.Sensor.FriendlyName()
                    mMachineNotes = sensorName & " / " & mCategoryToDisplay & " / " & sensorEx.MachineNotes
                End If

            End If


        End Sub

        Private Sub SensorExceptionNew(ByVal ex As SensorException)
            mTimestamp = ex.Timestamp
        End Sub

        Private Sub InitializationFailureNew(ByVal ife As InitializationFailureException)
            SensorExceptionNew(ife)
            mCategory = SensorTaskFailureCategory.InitializationError
            mCategoryToDisplay = "Initialization failure" 'i18n
        End Sub

        Private Sub InitializationTimeoutNew(ByVal ite As InitializationTimeoutException)
            SensorExceptionNew(ite)
            mCategory = SensorTaskFailureCategory.InitializationError
            mCategoryToDisplay = "Initialization timeout" 'i18n
        End Sub

        Private Sub CaptureFailureNew(ByVal cfe As CaptureFailureException)
            SensorExceptionNew(cfe)
            mCategory = SensorTaskFailureCategory.CaptureError
            mCategoryToDisplay = "Capture failure" 'i18n
        End Sub

        Private Sub CaptureTimeoutNew(ByVal cte As CaptureTimeoutException)
            SensorExceptionNew(cte)
            mCategory = SensorTaskFailureCategory.UnspecifiedCaptureTimeout
            mCategoryToDisplay = "Capture timeout" 'i18n
        End Sub

        Private Sub PollingCancelledNew(ByVal pce As PollingCanceledException)
            SensorExceptionNew(pce)
            mCategory = SensorTaskFailureCategory.CaptureError
            mCategoryToDisplay = "Capture failure" 'i18n
        End Sub

        Private Sub ConfigurationTimeoutNew(ByVal cte As ConfigurationTimeoutException)
            SensorExceptionNew(cte)
            mCategory = SensorTaskFailureCategory.ConfigurationError
            mCategoryToDisplay = "Configuration timeout"
        End Sub

        Private Sub ConfigurationFailureNew(ByVal cfe As ConfigurationFailureException)
            SensorExceptionNew(cfe)
            mCategory = SensorTaskFailureCategory.ConfigurationError
            mCategoryToDisplay = "Configuration failure"
        End Sub

        Private Sub DownloadFailureNew(ByVal dfe As DownloadFailureException)
            SensorExceptionNew(dfe)
            mCategory = SensorTaskFailureCategory.DownloadError
            mCategoryToDisplay = "Download failure"
        End Sub

        Private Sub DownloadTimeoutNew(ByVal dte As DownloadTimeoutException)
            SensorExceptionNew(dte)
            mCategory = SensorTaskFailureCategory.DownloadError
            mCategoryToDisplay = "Download timeout"
        End Sub


        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim failure As New SensorTaskFailure

            failure.mCategory = Me.Category
            failure.mExceptionMessages = Me.ExceptionMessages
            failure.mOperatorNotes = Me.OperatorNotes
            failure.mMachineNotes = Me.MachineNotes
            failure.mTimestamp = Me.Timestamp

            Return failure
        End Function

        Public Function DeepCopy() As SensorTaskFailure
            Return DirectCast(Clone(), SensorTaskFailure)
        End Function

        Public Overloads Function Equals(ByVal failure As SensorTaskFailure) As Boolean
            If failure Is Nothing Then Throw New ArgumentNullException("failure")
            Return _
                failure.mCategory = Me.mCategory AndAlso _
                failure.mExceptionMessages = Me.mExceptionMessages AndAlso _
                failure.mOperatorNotes = Me.mOperatorNotes AndAlso _
                failure.mMachineNotes = Me.mMachineNotes AndAlso _
                failure.mTimestamp = Me.mTimestamp
        End Function

    End Class

    Public Enum SensorModality
        Face
        Fingerprint
        Iris
        Voice
        HandGeometry
        Face3D
        Gait
        Ear
    End Enum

    Public Module SensorModalitySupport

        Public Function ToString(ByVal culture As CultureInfo, ByVal modality As SensorModality) As String
            Select Case modality
                Case SensorModality.Face : Return Messages.Face(culture)
                Case SensorModality.Face3D : Return Messages.Face3D(culture)
                Case SensorModality.Fingerprint : Return Messages.Fingerprint(culture)
                Case SensorModality.Gait : Return Messages.Gait(culture)
                Case SensorModality.HandGeometry : Return Messages.HandGeometry(culture)
                Case SensorModality.Iris : Return Messages.Iris(culture)
                Case SensorModality.Voice : Return Messages.Voice(culture)
                Case Else : Return Mbark.InfrastructureMessages.Messages.Unknown(culture)

            End Select
        End Function

    End Module

    Public Enum SensorStatus
        Uninitialized
        Offline
        Initializing
        Capturing
        Configuring
        Downloading
        Online
    End Enum


    Public Class CaptureActivatedEventArgs
        Inherits EventArgs
        Private mOriginatingSensor As ISensor
        Public ReadOnly Property OriginatingSensor() As ISensor
            Get
                Return mOriginatingSensor
            End Get
        End Property
        Public Sub New(ByVal originatingSensor As ISensor)
            mOriginatingSensor = originatingSensor
        End Sub
    End Class

    Public Class BadStatusEventArgs
        Inherits EventArgs

        Private mOriginatingSensor As ISensor
        Private mException As Exception

        Public ReadOnly Property OriginatingSensor() As ISensor
            Get
                Return mOriginatingSensor
            End Get
        End Property

        Public ReadOnly Property Exception() As Exception
            Get
                Return mException
            End Get
        End Property

        Public Sub New(ByVal originatingSensor As ISensor, ByVal exception As Exception)
            mOriginatingSensor = originatingSensor
            mException = exception
        End Sub

    End Class

    Public Interface ISensor
        Inherits IHasUICulture, IHasTabList

        ReadOnly Property TypeName() As String

        ReadOnly Property FriendlyName() As String
        ReadOnly Property Modality() As SensorModality
        ReadOnly Property CapturesImmediately() As Boolean

        Property Disabled() As Boolean

        ReadOnly Property HasLivePreview() As Boolean
        Sub StartLivePreview()
        Sub StopLivePreview()

        ReadOnly Property LatestStatus() As SensorStatus

        ReadOnly Property InitializationCommandTemplate() As Threading.AsyncCommandTemplate
        ReadOnly Property DeferInitialization() As Boolean
        Function StartInitialize() As Guid
        ReadOnly Property IsOfflineOrUninitialized() As Boolean

        Sub Uninitialize()

        ReadOnly Property ConfigurationCommandTemplate() As Threading.AsyncCommandTemplate
        ReadOnly Property HasConfigurationClass() As Boolean
        ReadOnly Property ConfigurationClassName() As String
        ReadOnly Property RequiresConfiguration() As Boolean
        ReadOnly Property RequiresConfiguration(ByVal NewConfiguration As SensorConfiguration) As Boolean
        Function StartConfiguration(ByVal configuration As SensorConfiguration) As Guid

        ReadOnly Property CaptureCommandTemplate() As Threading.AsyncCommandTemplate
        Sub CancelCapture()
        ReadOnly Property TargetParts() As BodyPartCollection
        Property TargetCategory() As SensorTaskCategory
        ReadOnly Property InaccessibleParts() As BodyPartCollection
        ReadOnly Property CaptureIsCancelable() As Boolean
        ReadOnly Property PollingWasCanceled() As Boolean
        Sub ActivateSensorNow()

        Event CaptureActivated As EventHandler(Of CaptureActivatedEventArgs)
        Event BadStatus As EventHandler(Of BadStatusEventArgs)

        Property LatestReviewImageConsideredAcceptable() As Boolean

        ReadOnly Property LatestThumbnail() As Image

        ReadOnly Property RequiresReview() As Boolean

        ReadOnly Property RequiresDownload() As Boolean

        Property RequiresRecovery() As Boolean

        'ReadOnly Property LatestCaptureSuccessful() As Boolean

        ReadOnly Property AsControl() As System.Windows.Forms.Control
        ReadOnly Property SensorId() As Guid

        ReadOnly Property DownloadCommandTemplate() As Threading.AsyncCommandTemplate
        Function StartDownload(ByVal guid As Guid) As Guid
        ReadOnly Property DownloadIsCancelable() As Boolean
        Function CancelDownload() As Boolean
        ReadOnly Property LatestDownloadWasSuccessful() As Boolean
        ReadOnly Property LatestDownloadWasCanceled() As Boolean
        ReadOnly Property PercentDownloadedIsMeaningful() As Boolean
        ReadOnly Property PercentDownloaded() As Single
        Sub DeleteInternalImages()

        Property ActivateSensorButtonEnabled() As Boolean
        Property CancelCaptureButtonEnabled() As Boolean
        Property ConditionsLabelText() As String

        Sub RefreshControls()

        
    End Interface


    Public Class ImageProperties

        Private mDefinition As New ImagePropertiesDefinition
        Private mImage As Image
        Private mRawData As Object

        Public Property Image() As Image
            Get
                Return mImage
            End Get
            Set(ByVal value As Image)
                mImage = value
            End Set
        End Property

        Public Property RawData() As Object
            Get
                Return mRawData
            End Get
            Set(ByVal value As Object)
                mRawData = value
            End Set
        End Property
        Public Property Timestamp() As DateTime
            Get
                Return mDefinition.Timestamp
            End Get
            Set(ByVal value As DateTime)
                mDefinition.Timestamp = value
            End Set
        End Property

        Public Function Definition() As ImagePropertiesDefinition


            Dim newDef As New ImagePropertiesDefinition
            newDef.Timestamp = Timestamp
            If Not Image Is Nothing Then
                Dim memStream As New MemoryStream
                Image.Save(memStream, Imaging.ImageFormat.Png)
                memStream.Close()
                ' Notice the use of MemoryStream.ToArray() instead of the (larger) MemoryStream.GetBuffer()
                newDef.ImageAsBase64String = Convert.ToBase64String(memStream.ToArray())
            Else
                newDef.ImageAsBase64String = String.Empty
            End If

            Return newDef

        End Function

    End Class

    <Serializable()> Public Class ImagePropertiesDefinition
        Implements ICloneable

        Private mImageAsBase64String As String
        Private mTimestamp As DateTime

        Public Property ImageAsBase64String() As String
            Get
                Return mImageAsBase64String
            End Get
            Set(ByVal value As String)
                mImageAsBase64String = value
            End Set
        End Property
        Public Property Timestamp() As DateTime
            Get
                Return mTimestamp
            End Get
            Set(ByVal value As DateTime)
                mTimestamp = value
            End Set
        End Property

        Public Function CreateImageProperties() As ImageProperties

            Dim newProp As New ImageProperties

            If ImageAsBase64String <> String.Empty Then
                Dim imageAsBytes() As Byte = Convert.FromBase64String(ImageAsBase64String)
                Dim memStream As New MemoryStream(imageAsBytes)
                ' Notice we don't close the memory stream as noted in KB 814675
                Dim newImage As Image = Image.FromStream(memStream)
                newProp.Image = newImage
            End If

            Return newProp
        End Function

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New ImagePropertiesDefinition
            newDef.ImageAsBase64String = ImageAsBase64String
            newDef.Timestamp = Timestamp
            Return newDef
        End Function

        Public Function DeepCopy() As ImagePropertiesDefinition
            Return DirectCast(Clone(), ImagePropertiesDefinition)
        End Function
    End Class

    <Serializable()> Public Class SensorConfiguration
        Implements ICloneable

        Private mCaptureCriticalTime As Integer
        Public Property CaptureCriticalTime() As Integer
            Get
                Return mCaptureCriticalTime
            End Get
            Set(ByVal value As Integer)
                mCaptureCriticalTime = value
            End Set
        End Property

        Private mCaptureExpirationTime As Integer
        Public Property CaptureExpirationTime() As Integer
            Get
                Return mCaptureExpirationTime
            End Get
            Set(ByVal value As Integer)
                mCaptureExpirationTime = value
            End Set
        End Property

        Private mDownloadExpirationTime As Integer
        Public Property DownloadExpirationTime() As Integer
            Get
                Return mDownloadExpirationTime
            End Get
            Set(ByVal value As Integer)
                mDownloadExpirationTime = value
            End Set
        End Property


        Public Overridable Function Clone() As Object Implements ICloneable.Clone
            Throw New MissingSpecializationException("Clone()")
        End Function

        Public Function DeepCopy() As SensorConfiguration
            Return DirectCast(Clone(), SensorConfiguration)
        End Function

        Public Overridable Overloads Function Equals(ByVal configuration As SensorConfiguration) As Boolean
            If Me.DownloadExpirationTime <> configuration.DownloadExpirationTime Then Return False
            If Me.CaptureExpirationTime <> configuration.CaptureExpirationTime Then Return False
            If Me.CaptureCriticalTime <> configuration.CaptureCriticalTime Then Return False

            Return True
        End Function
    End Class


End Namespace
