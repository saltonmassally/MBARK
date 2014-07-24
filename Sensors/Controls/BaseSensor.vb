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

Imports Mbark
Imports Mbark.UI
Imports Mbark.Threading

Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms


Namespace Mbark.Sensors

    Public Class BaseSensor
        Inherits System.Windows.Forms.UserControl
        Implements ISensor
        Implements IAutosizable

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            UserNew()
        End Sub

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If Me.mCommandThreadLifetime = CommandThreadLifetime.PerConstruction Then
                mCommandManager.Stop(True)
            End If
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
        Friend WithEvents HeaderLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        Protected Friend WithEvents ActivateSensorButton As System.Windows.Forms.Button
        Protected Friend WithEvents CancelSensorButton As System.Windows.Forms.Button
        Friend WithEvents FooterPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Protected Friend WithEvents TimeoutIndicator As TimeoutIndicator
        Friend WithEvents ButtonPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Protected Friend WithEvents MainPanel As System.Windows.Forms.Panel
        Friend WithEvents ConditionsLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        Protected Friend WithEvents OuterPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Protected Friend WithEvents InnerPanel As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseSensor))
            Me.OuterPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.InnerPanel = New System.Windows.Forms.Panel
            Me.MainPanel = New System.Windows.Forms.Panel
            Me.FooterPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.ButtonPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.ActivateSensorButton = New System.Windows.Forms.Button
            Me.CancelSensorButton = New System.Windows.Forms.Button
            Me.ConditionsLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.HeaderLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.TimeoutIndicator = New Mbark.UI.TimeoutIndicator
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.OuterPanel.SuspendLayout()
            Me.InnerPanel.SuspendLayout()
            CType(Me.FooterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.FooterPanel.SuspendLayout()
            CType(Me.ButtonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ButtonPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'OuterPanel
            '
            Me.OuterPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.OuterPanel.BorderColor = System.Drawing.SystemColors.Highlight
            Me.OuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.OuterPanel.Controls.Add(Me.InnerPanel)
            Me.OuterPanel.Controls.Add(Me.FooterPanel)
            Me.OuterPanel.Controls.Add(Me.ConditionsLabel)
            Me.OuterPanel.Controls.Add(Me.HeaderLabel)
            resources.ApplyResources(Me.OuterPanel, "OuterPanel")
            Me.OuterPanel.Name = "OuterPanel"
            '
            'InnerPanel
            '
            Me.InnerPanel.Controls.Add(Me.MainPanel)
            resources.ApplyResources(Me.InnerPanel, "InnerPanel")
            Me.InnerPanel.Name = "InnerPanel"
            '
            'MainPanel
            '
            resources.ApplyResources(Me.MainPanel, "MainPanel")
            Me.MainPanel.Name = "MainPanel"
            '
            'FooterPanel
            '
            Me.FooterPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.FooterPanel.BorderColor = System.Drawing.Color.Black
            Me.FooterPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.FooterPanel.Controls.Add(Me.ButtonPanel)
            Me.FooterPanel.Controls.Add(Me.TimeoutIndicator)
            resources.ApplyResources(Me.FooterPanel, "FooterPanel")
            Me.FooterPanel.Name = "FooterPanel"
            '
            'ButtonPanel
            '
            Me.ButtonPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.ButtonPanel.BorderColor = System.Drawing.Color.Black
            Me.ButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.ButtonPanel.Controls.Add(Me.ActivateSensorButton)
            Me.ButtonPanel.Controls.Add(Me.CancelSensorButton)
            resources.ApplyResources(Me.ButtonPanel, "ButtonPanel")
            Me.ButtonPanel.Name = "ButtonPanel"
            '
            'ActivateSensorButton
            '
            resources.ApplyResources(Me.ActivateSensorButton, "ActivateSensorButton")
            Me.ActivateSensorButton.Name = "ActivateSensorButton"
            '
            'CancelSensorButton
            '
            resources.ApplyResources(Me.CancelSensorButton, "CancelSensorButton")
            Me.CancelSensorButton.Name = "CancelSensorButton"
            '
            'ConditionsLabel
            '
            Me.ConditionsLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.ConditionsLabel.BorderSides = System.Windows.Forms.Border3DSide.Top
            Me.ConditionsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
            resources.ApplyResources(Me.ConditionsLabel, "ConditionsLabel")
            Me.ConditionsLabel.Name = "ConditionsLabel"
            '
            'HeaderLabel
            '
            Me.HeaderLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, System.Drawing.SystemColors.ActiveCaption, System.Drawing.SystemColors.InactiveCaption)
            Me.HeaderLabel.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.HeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
            resources.ApplyResources(Me.HeaderLabel, "HeaderLabel")
            Me.HeaderLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.HeaderLabel.Name = "HeaderLabel"
            '
            'TimeoutIndicator
            '
            Me.TimeoutIndicator.CriticalColor = System.Drawing.Color.Red
            Me.TimeoutIndicator.CriticalTime = 0
            resources.ApplyResources(Me.TimeoutIndicator, "TimeoutIndicator")
            Me.TimeoutIndicator.Name = "TimeoutIndicator"
            Me.TimeoutIndicator.UpdateFrequency = 100
            '
            'BaseSensor
            '
            Me.Controls.Add(Me.OuterPanel)
            Me.Name = "BaseSensor"
            resources.ApplyResources(Me, "$this")
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.OuterPanel.ResumeLayout(False)
            Me.InnerPanel.ResumeLayout(False)
            CType(Me.FooterPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.FooterPanel.ResumeLayout(False)
            CType(Me.ButtonPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ButtonPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Private (Properties)"

        Private mDisabled As Boolean

        Private mDownloadIsCancellable As Boolean
        Private mLatestThumbnail As Image
        Private mRequiresRecovery As Boolean

        Private mStatus As SensorStatus = SensorStatus.Offline
#End Region
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private mUICulture As CultureInfo = CultureInfo.CurrentUICulture
        Public Property UICulture() As CultureInfo Implements ISensor.UICulture
            Get
                Return mUICulture
            End Get
            Set(ByVal Value As CultureInfo)
                mUICulture = Value
            End Set
        End Property

        Private Const MaximumThumbnailWidthOrHeight As Integer = 500

        Private Sub UserNew()
            'SetStyle(Mbark.UI.DoubleBufferStyle, True)

            mStatus = SensorStatus.Uninitialized
            mSensorId = Guid.NewGuid

            If Me.mCommandThreadLifetime = CommandThreadLifetime.PerConstruction Then
                mCommandManager.Start()
            End If

            AddHandler ActivateSensorButton.Click, AddressOf HandleSensorButtonClick

        End Sub

#Region " Command Manager "

        Private mCommandManager As New AsyncCommandManager
        Protected ReadOnly Property CommandManager() As AsyncCommandManager
            Get
                Return mCommandManager
            End Get
        End Property

#End Region

#Region " Static Sensor Properties "
        ''' <summary>Define sensor modality: finger, face or iris.</summary>
        ''' <value>
        '''	<para>SensorModality.Finger</para>
        '''	<para>SensorModality.Face</para>
        '''	<para>SensorModality.Iris</para>
        ''' </value>
        ''' <remarks>
        ''' <strong>This propery must be override in the derive class.</strong> Must define
        ''' the modality of the sensor. If sensor modality is define in the code, the property must
        ''' include in the configuration file.
        ''' </remarks>
        Public Overridable ReadOnly Property Modality() As SensorModality _
    Implements ISensor.Modality
            Get
                If InDesignMode(Me) Then Return SensorModality.Face
                Throw New MissingSpecializationException(GetType(BaseSensor), "Modality")
            End Get
        End Property
        ''' <summary>Gets or sets the name of the control.</summary>
        ''' <returns>String</returns>
        ''' <remarks>
        ''' <strong>This property must be override in the derive class.</strong> The
        ''' <b>FriendlyName</b> property can be used to identify the sensors in the sensor
        ''' controller application.
        ''' </remarks>
        ''' <value>The name of sensor name in <strong>string</strong> value.</value>
        Public Overridable ReadOnly Property FriendlyName() As String Implements ISensor.FriendlyName
            Get
                If InDesignMode(Me) Then Return String.Empty
                Throw New MissingSpecializationException(GetType(BaseSensor), "FriendlyName")
            End Get
        End Property
        ''' <summary>
        ''' Get a boolean value indicating whehter capture image immediately after capture
        ''' button is pressed.
        ''' </summary>
        ''' <remarks>
        '''	<strong>This propery must be override in the derive class.</strong> The
        ''' <strong>CapturesImmediately</strong> property can determine the capture mode of the
        ''' sensor. If <strong>true</strong> capture process immediately to collect the image. If
        ''' <strong>false</strong>, capture doesn't collect data immediately, instead data can be
        ''' presented and collected during the allowed capture time.
        ''' </remarks>
        ''' <value>
        ''' <strong>true</strong> if the sensor capture image immediately after capture
        ''' button is clicked, otherwise <strong>false</strong>. The default is
        ''' <strong>false</strong>
        ''' </value>
        ''' <seealso cref="IsTimeout" cat="Other Property">IsTimeout Property</seealso>
        Public Overridable ReadOnly Property CapturesImmediately() As Boolean _
     Implements ISensor.CapturesImmediately
            Get
                If InDesignMode(Me) Then Return False
                Throw New MissingSpecializationException(GetType(BaseSensor), "IsActive")
            End Get
        End Property
        ''' <summary>
        ''' Get sensor as form control.
        ''' </summary>
        ''' <value>Forms.Control</value>
        ''' <returns>Forms.Control</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property AsControl() As System.Windows.Forms.Control _
        Implements ISensor.AsControl
            Get
                Return Me
            End Get
        End Property

        Private mSensorId As Guid
        ''' <summary>
        ''' Get globally unique identifier of the sensor.
        ''' </summary>
        ''' <value>GUI</value>
        Public ReadOnly Property SensorId() As Guid Implements ISensor.SensorId
            Get
                Return mSensorId
            End Get
        End Property

        Private mRequiresReview As Boolean
        ''' <summary>
        ''' Get a boolean value indicating whether the sensor require to preview captured image.
        ''' </summary>
        ''' <value>
        ''' <strong>true</strong> if the sensor require to preview the captured image,
        ''' otherwise <strong>false</strong>. The default is <strong>false</strong>
        ''' </value>
        ''' <remarks>
        ''' This property can be used to determine whether the sensor is require to preview
        ''' image after capture. If <strong>true</strong>, a preview box appear after a successful
        ''' capture, and user must choose whether to accept the image. Otherwise is
        ''' <strong>false</strong>, if capture successfully, the captured image automically get
        ''' accepted.
        ''' </remarks>
        Public ReadOnly Property RequiresReview() As Boolean _
        Implements ISensor.RequiresReview
            Get
                Return mRequiresReview
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether the sensor require to preview captured image.
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableRequiresReview() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mRequiresReview
            End Get
            Set(ByVal value As Boolean)
                mRequiresReview = value
            End Set
        End Property

        Private mRequiresDownload As Boolean
        ''' <summary>
        ''' Get a boolean value indicating whether the sensor require to preview captured image.
        ''' </summary>
        ''' <value>
        ''' <strong>true</strong> if the sensor require to preview the captured image,
        ''' otherwise <strong>false</strong>. The default is <strong>false</strong>
        ''' </value>
        ''' <remarks>
        ''' This property can be used to determine whether the sensor is require to preview
        ''' image after capture. If <strong>true</strong>, a preview box appear after a successful
        ''' capture, and user must choose whether to accept the image. Otherwise is
        ''' <strong>false</strong>, if capture successfully, the captured image automically get
        ''' accepted.
        ''' </remarks>
        Public ReadOnly Property RequiresDownload() As Boolean _
        Implements ISensor.RequiresDownload
            Get
                Return mRequiresDownload
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether the sensor require to preview captured image.
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableRequiresDownload() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mRequiresDownload
            End Get
            Set(ByVal value As Boolean)
                mRequiresDownload = value
            End Set
        End Property

        Private mCaptureIsCancelable As Boolean = True
        ''' <summary>
        ''' Get a boolean value indicating whether sensor allow to cancel capture .
        ''' </summary>
        ''' <value>
        '''	<strong>true</strong> if cancel is allow during capture, otherwise
        ''' <strong>false</strong>. The default is <strong>true</strong>.
        ''' </value>
        ''' <remarks>
        '''	<strong>CaptureIsCancelable</strong> is true only when
        ''' <strong>CapturesImmediately</strong> is to true.
        ''' </remarks>
        ''' <seealso cref="CapturesImmediately" cat="Other Property">CapturesImmediately Property</seealso>
        Public ReadOnly Property CaptureIsCancelable() As Boolean Implements ISensor.CaptureIsCancelable
            Get
                Return mCaptureIsCancelable
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether sensor allow to cancel capture .
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableCaptureIsCancelable() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mCaptureIsCancelable
            End Get
            Set(ByVal value As Boolean)
                mCaptureIsCancelable = value
            End Set
        End Property

        Private mHasLivePreview As Boolean
        ''' <summary>
        ''' Get a boolean value indicating whether sensor has live preview prior capture.
        ''' </summary>
        ''' <value>
        ''' <strong>true</strong> if the sensor provides live preview before capture,
        ''' otherwise <strong>false</strong>. The default is <strong>false</strong>.
        ''' </value>
        Public Overridable ReadOnly Property HasLivePreview() As Boolean Implements ISensor.HasLivePreview
            Get
                Return mHasLivePreview
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether sensor has live preview prior capture.
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overridable Property WritableHasLivePreview() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mHasLivePreview
            End Get
            Set(ByVal value As Boolean)
                mHasLivePreview = value
            End Set
        End Property

        Private mPercentDownloadedIsMeaningful As Boolean
        ''' <summary>
        ''' Get a boolean value indicating whether to display the download process bar while downloading or not.
        ''' </summary>
        ''' <value><strong>true</strong> if</value>
        Public ReadOnly Property PercentDownloadedIsMeaningful() As Boolean _
        Implements ISensor.PercentDownloadedIsMeaningful
            Get
                Return mPercentDownloadedIsMeaningful
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether to display the download process bar while downloading or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WritablePercentDownloadedIsMeaningful() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mPercentDownloadedIsMeaningful
            End Get
            Set(ByVal value As Boolean)
                mPercentDownloadedIsMeaningful = value
            End Set
        End Property

        Public Enum CommandThreadLifetime
            PerConstruction
            PerInitialization
        End Enum

        Private mCommandThreadLifetime As CommandThreadLifetime = CommandThreadLifetime.PerInitialization
        Public Property AsyncCommandManagerLifetime() As CommandThreadLifetime
            Get
                Return mCommandThreadLifetime
            End Get
            Set(ByVal value As CommandThreadLifetime)
                mCommandThreadLifetime = value
            End Set
        End Property

        Private mHasConfigurationClass As Boolean
        ''' <summary>
        ''' Get a boolean value indicating whether the sensor has a configuration class
        ''' </summary>
        ''' <value>
        ''' <strong>true</strong> if the sensor has a configuration class, otherwise
        ''' <strong>false</strong>. The default is <strong>false</strong>.
        ''' </value>
        ''' <returns>Boolean</returns>
        Public ReadOnly Property HasConfigurationClass() As Boolean _
        Implements ISensor.HasConfigurationClass
            Get
                Return mHasConfigurationClass
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether the sensor has a configuration class.
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableHasConfigurationClass() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mHasConfigurationClass
            End Get
            Set(ByVal value As Boolean)
                mHasConfigurationClass = value
            End Set
        End Property

        Private mConfigurationClassName As String
        ''' <summary>
        ''' Get the name of the sensor configuration class.
        ''' </summary>
        ''' <value>The name of the sensor configuration class.</value>
        Public ReadOnly Property ConfigurationClassName() As String _
        Implements ISensor.ConfigurationClassName
            Get
                Return mConfigurationClassName
            End Get
        End Property
        ''' <summary>
        ''' Set the name of the sensor configuration class.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableConfigurationClassName() As String
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mConfigurationClassName
            End Get
            Set(ByVal value As String)
                mConfigurationClassName = value
            End Set
        End Property
        ''' <summary>
        ''' Get the Type of the current instance.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TypeName() As String Implements ISensor.TypeName
            Get
                Return Me.GetType.FullName
            End Get
        End Property


#End Region

#Region " Dynamic Sensor Properties "
        ''' <summary>
        ''' Get the lastes sensor status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property LatestStatus() As SensorStatus _
        Implements ISensor.LatestStatus
            Get
                Return mStatus
            End Get
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Property Disabled() As Boolean Implements ISensor.Disabled
            Get
                Return mDisabled
            End Get
            Set(ByVal Value As Boolean)
                mDisabled = Value
            End Set
        End Property

        Private mTargetParts As BodyPartCollection = New BodyPartCollection
        ''' <summary>
        ''' Body part collection contains set of body part that will require for next capture.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TargetParts() As BodyPartCollection Implements ISensor.TargetParts
            Get
                Return mTargetParts
            End Get
        End Property

        Private mInaccessibleParts As BodyPartCollection = New BodyPartCollection
        ''' <summary>
        ''' Body part collection contains set of body part that will not available for next capture.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property InaccessibleParts() As BodyPartCollection Implements ISensor.InaccessibleParts
            Get
                Return mInaccessibleParts
            End Get
        End Property

        Private mTargetCategory As SensorTaskCategory
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TargetCategory() As SensorTaskCategory Implements ISensor.TargetCategory
            Get
                Return mTargetCategory
            End Get
            Set(ByVal Value As SensorTaskCategory)
                mTargetCategory = Value
            End Set
        End Property

#Region "PercentDownloaded Property"
        Private mPercentDownloaded As Single
        ''' <summary>
        ''' Get the current percentage of completed download.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property PercentDownloaded() As Single Implements ISensor.PercentDownloaded
            Get
                Return mPercentDownloaded
            End Get
        End Property
        ''' <summary>
        ''' Set the percentage of how much download has completed.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritablePercentDownloaded() As Single
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mPercentDownloaded
            End Get
            Set(ByVal value As Single)
                mPercentDownloaded = value
            End Set
        End Property
#End Region

#Region "LatestThumbnail Property"
        ''' <summary>
        ''' Get the Thumbnail image of the latest capture.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LatestThumbnail() As System.Drawing.Image Implements ISensor.LatestThumbnail
            Get
                If mLatestThumbnail Is Nothing Then Return Nothing
                If mLatestThumbnail.Width = 0 OrElse mLatestThumbnail.Height = 0 Then Return Nothing


                Dim tooWide As Boolean = mLatestThumbnail.Width > MaximumThumbnailWidthOrHeight
                Dim tooTall As Boolean = mLatestThumbnail.Height > MaximumThumbnailWidthOrHeight
                Dim isMoreWideThanTall As Boolean = mLatestThumbnail.Width > mLatestThumbnail.Height

                If tooWide Or tooTall AndAlso isMoreWideThanTall AndAlso mLatestThumbnail.Width <> 0 Then
                    mLatestThumbnail = UI.ResizeImage(mLatestThumbnail, MaximumThumbnailWidthOrHeight * 1.0! / mLatestThumbnail.Width)
                ElseIf tooWide Or tooTall AndAlso mLatestThumbnail.Height <> 0 Then
                    mLatestThumbnail = UI.ResizeImage(mLatestThumbnail, MaximumThumbnailWidthOrHeight * 1.0! / mLatestThumbnail.Height)
                End If
                Return mLatestThumbnail
            End Get
        End Property
        ''' <summary>
        ''' Set the Thumbnail image from the latest capture.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableLatestThumbnail() As System.Drawing.Image
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mLatestThumbnail
            End Get
            Set(ByVal value As System.Drawing.Image)
                mLatestThumbnail = value
            End Set
        End Property
#End Region

#Region "LastReviewImageAcceptable Property"
        ''' <summary>
        ''' Get or Set a boolean value indicating whether the capture result is acceptable after a successful capture.
        ''' </summary>
        ''' <remarks></remarks>
        Private mLastReviewImageAcceptable As Boolean
        Public Property LastReviewImageAcceptable() As Boolean _
        Implements ISensor.LatestReviewImageConsideredAcceptable
            Get
                Return mLastReviewImageAcceptable
            End Get
            Set(ByVal Value As Boolean)
                mLastReviewImageAcceptable = Value
            End Set
        End Property

#End Region

#Region "LastCaptureSuccessful Property"
        'Private mLastCaptureSuccessful As Boolean
        '''' <summary>
        '''' 
        '''' </summary>
        '''' <value></value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        '''' ky - Purpose??? don't see it being use except setting it to true/false
        'Public ReadOnly Property LastCaptureSuccessful() As Boolean _
        'Implements ISensor.LatestCaptureSuccessful
        '    Get
        '        Return mLastCaptureSuccessful
        '    End Get
        'End Property
        '''' <summary>
        '''' 
        '''' </summary>
        '''' <value></value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        '''' ky - Purpose??? don't see it being use except setting it to true/false
        'Protected Property WritableLastCaptureSuccessful() As Boolean
        '    <Obsolete(ForbiddenGetterMessage)> Get
        '        Return mLastCaptureSuccessful
        '    End Get
        '    Set(ByVal value As Boolean)
        '        mLastCaptureSuccessful = value
        '    End Set
        'End Property
#End Region

        ' ky - two of the same property below, can we eliminate one???

        ''' <summary>
        ''' Check if the status of sensor is offline or uninitialized
        ''' True if it is offline or uninitialized, else False.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsOfflineOrUninitialized() As Boolean _
        Implements ISensor.IsOfflineOrUninitialized
            Get
                Return mStatus = SensorStatus.Offline Or mStatus = SensorStatus.Uninitialized
            End Get
        End Property
        '''' <summary>
        '''' Check if the status of sensor is offline or uninitialized
        '''' True if it is offline or uninitialized, else False.
        '''' </summary>
        '''' <value></value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public ReadOnly Property OfflineOrUninitialized() As Boolean
        '    Get
        '        Return mStatus = SensorStatus.Offline Or mStatus = SensorStatus.Uninitialized
        '    End Get
        'End Property

#End Region

#Region " Refresh "
        ' RefreshControls gets call after configuration is done.
        ''' <summary>
        ''' Forces the sensor control to redraw itself and child controls.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RefreshControls() Implements ISensor.RefreshControls
            SafeInvokeNoArgSub(Me, AddressOf RefreshBaseSensorImplementation)
        End Sub

        Private Sub RefreshBaseSensorImplementation()
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
            RefreshButtons()
        End Sub
#End Region

#Region "  GUI  "

        Private mButtonsEnabled As Boolean
        Private mMainPanelAspectRatio As Single = 4.0! / 3.0!
        Private mMinimumHeight As Integer
        Private mMinimumWidth As Integer


        Public Property ButtonsEnabled() As Boolean
            Get
                Return mButtonsEnabled
            End Get
            Set(ByVal value As Boolean)
                SafeInvoke1ArgSub(Of Boolean)(Me, AddressOf ButtonsEnabledSetter, value)
            End Set
        End Property


        Private Sub ButtonsEnabledSetter(ByVal value As Boolean)
            mButtonsEnabled = value
            ActivateSensorButtonEnabled = value
            'ActivateSensorButton.Enabled = value
            CancelCaptureButtonEnabled = value
            'CancelSensorButton.Enabled = value
            ActivateSensorButton.Refresh()
            CancelSensorButton.Refresh()
        End Sub

        Private Sub RefreshButtons()

            If CapturesImmediately Then
                CancelSensorButton.Visible = False
            Else
                CancelSensorButton.Visible = True
            End If

            If LatestStatus = SensorStatus.Online Then
                With ActivateSensorButton
                    .Enabled = True
                    .Visible = True
                    .Refresh()
                End With
            End If

        End Sub

        Public Property MainPanelAspectRatio() As Single
            Get
                Return mMainPanelAspectRatio
            End Get
            Set(ByVal value As Single)
                mMainPanelAspectRatio = value
            End Set
        End Property

#Region "ConditionsLabelText"
        Public Property ConditionsLabelText() As String Implements ISensor.ConditionsLabelText
            Get
                Return SafeInvokeNoArgFunction(Of String)(Me, AddressOf GetConditionslabelText)
            End Get
            Set(ByVal Value As String)
                SafeInvoke1ArgSub(Me, AddressOf SetConditionsLabelText, Value)
            End Set
        End Property
        Private Sub SetConditionsLabelText(ByVal text As String)

            ConditionsLabel.Text = text
            If ConditionsLabel.Text = String.Empty OrElse _
               Modality = SensorModality.Fingerprint Then
                ConditionsLabel.Height = 0
            Else
                ConditionsLabel.Height = HeaderLabel.Height
            End If

        End Sub
        Private Function GetConditionslabelText() As String
            Return ConditionsLabel.Text
        End Function

#End Region

#Region "ActivateSensorButtonEnabled"
        Public Property ActivateSensorButtonEnabled() As Boolean Implements ISensor.ActivateSensorButtonEnabled
            Get
                Return SafeGetControlEnabled(ActivateSensorButton)
            End Get
            Set(ByVal Value As Boolean)
                SafeSetControlEnabled(ActivateSensorButton, Value)
            End Set
        End Property


#End Region

#Region "CancelCaptureButtonEnabled"
        Public Property CancelCaptureButtonEnabled() As Boolean Implements ISensor.CancelCaptureButtonEnabled
            Get
                Return SafeGetControlEnabled(CancelSensorButton)
            End Get
            Set(ByVal Value As Boolean)
                SafeSetControlEnabled(CancelSensorButton, Value)
            End Set
        End Property

#End Region



#Region "  Autosize  "
        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout

            RecursiveSuspendLayout(Me)

            ' Font and size the headerLabel
            AutoFont.FancyLabel(HeaderLabel)
            UI.AutoHeight.FancyLabel(graphics, HeaderLabel)

            ConditionsLabel.Font = GlobalUISettings.Defaults.Fonts.LargeBold
            ConditionsLabel.Height = HeaderLabel.Height  ' We don't use AutoHeight.Label() because the string could be empty
            '
            ' ConditionsLabel only should not display when ConditionLabel.text is empty and 
            ' the modality of the sensor is Fingerprint or other that don't need
            If ConditionsLabel.Text = String.Empty OrElse _
               Modality = SensorModality.Fingerprint Then
                ConditionsLabel.Height = 0
            End If


            Dim innerPanelAR As Single = (1.0! * InnerPanel.Width) / (1.0! * InnerPanel.Height)
            Dim ipw As Integer = InnerPanel.Width - InnerPanel.DockPadding.Left - InnerPanel.DockPadding.Right
            Dim iph As Integer = InnerPanel.Height - InnerPanel.DockPadding.Top - InnerPanel.DockPadding.Bottom

            If innerPanelAR < mMainPanelAspectRatio Then
                MainPanel.Height = CInt(ipw * 1.0 / mMainPanelAspectRatio)
                MainPanel.Location = New Point(InnerPanel.DockPadding.Left, CInt(0.5 * (iph - MainPanel.Height)))
                MainPanel.Width = InnerPanel.Width - InnerPanel.DockPadding.Left - InnerPanel.DockPadding.Right
            Else
                MainPanel.Height = InnerPanel.Height - InnerPanel.DockPadding.Top - InnerPanel.DockPadding.Bottom
                MainPanel.Width = CInt(iph * mMainPanelAspectRatio)
                MainPanel.Location = New Point(CInt(0.5 * (ipw - MainPanel.Width)), InnerPanel.DockPadding.Top)

            End If

            If CapturesImmediately Then
                TimeoutIndicator.Height = 0
            Else
                TimeoutIndicator.Height = CInt(GlobalUISettings.Defaults.Fonts.Regular.Size * 2)
            End If

            ' Autofont and size the buttons
            Static buttons As New Collection(Of Button)
            If buttons IsNot Nothing Then
                buttons = New Collection(Of Button)
                buttons.Add(ActivateSensorButton)
                buttons.Add(CancelSensorButton)
            End If
            ActivateSensorButton.Font = GlobalUISettings.Defaults.Fonts.Button
            CancelSensorButton.Font = GlobalUISettings.Defaults.Fonts.Button
            UI.AutoSize.Buttons(graphics, buttons)

            ActivateSensorButton.Refresh()
            CancelSensorButton.Refresh()


            ' Adjust the footer panel height (the ButtonPanel.Dock = Full, so we can't adjust that height)`
            FooterPanel.Height = _
                FooterPanel.DockPadding.Top + FooterPanel.DockPadding.Bottom + ActivateSensorButton.Height + TimeoutIndicator.Height + _
            ButtonPanel.DockPadding.Top + ButtonPanel.DockPadding.Bottom

            ActivateSensorButton.Location = New Point(ButtonPanel.DockPadding.Left, ButtonPanel.DockPadding.Top)
            CancelSensorButton.Location = New Point(ButtonPanel.Width - CancelSensorButton.Width - ButtonPanel.DockPadding.Left, ButtonPanel.DockPadding.Top)

            mMinimumWidth = _
                FooterPanel.DockPadding.Left + FooterPanel.DockPadding.Right + _
                ActivateSensorButton.Width + CancelSensorButton.Height



            mMinimumHeight = _
                HeaderLabel.Height + FooterPanel.Height + ConditionsLabel.Height

            RecursiveResumeLayout(Me)
        End Sub

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Public ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get
                Return mMinimumHeight
            End Get
        End Property

        Public ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get
                Return mMinimumWidth
            End Get
        End Property

        ''' <summary>
        ''' </summary>
        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property
#End Region

        Private mTabList As New Collection(Of Control)
        Public ReadOnly Property TabList() As Collection(Of Control) Implements IHasTabList.TabList
            Get
                mTabList.Clear()

                If ActivateSensorButton.Enabled Then
                    mTabList.Add(ActivateSensorButton)
                End If

                If CancelSensorButton.Enabled Then
                    mTabList.Add(CancelSensorButton)
                End If

                Return mTabList
            End Get
        End Property

#End Region

#Region " Loading & Startup "


        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)

            SuspendLayout()

            Dim allPadding As Integer = 4

            If InDesignMode(Me) Then Return

            If CapturesImmediately Then
                ActivateSensorButton.Visible = True
                CancelSensorButton.Visible = False
                TimeoutIndicator.Visible = False
            Else
                ActivateSensorButton.Visible = True
                CancelSensorButton.Visible = True
                CancelCaptureButtonEnabled = False
                'CancelSensorButton.Enabled = False
                TimeoutIndicator.Visible = True
            End If

            InnerPanel.DockPadding.All = allPadding
            FooterPanel.DockPadding.Left = allPadding
            FooterPanel.DockPadding.Right = allPadding
            FooterPanel.DockPadding.Bottom = allPadding

            ' Ensures this class intercepts the completion of capture first. (When a command
            ' is instantiated, the handlers are also bound in the order they appear in the the CommandCompleteHandler
            ' array.) Sneaky, eh?
            '
            CaptureCommandTemplate.InsertCommandCompleteHandler(0, AddressOf HandleCaptureCompleted)
            InitializationCommandTemplate.InsertCommandCompleteHandler(0, AddressOf HandleInitializationCompleted)

            If Not ConfigurationCommandTemplate Is Nothing Then
                ConfigurationCommandTemplate.InsertCommandCompleteHandler(0, AddressOf HandleConfigurationCompleted)
            End If

            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)


            ResumeLayout()

            'GenerateTabList()
        End Sub
#End Region

#Region " Capture Activation and Default Result Wrapper "

        Public Event CaptureActivated As EventHandler(Of CaptureActivatedEventArgs) Implements ISensor.CaptureActivated
        ''' <remarks><strong>This property must be override in the derive class.</strong></remarks>
        ''' <example>
        '''    The following code example show the implementation of
        '''    <strong>CaptureCommandTemplate</strong> in the derive class. The example declares a
        '''    Protected Delegate and a Private AsyncCommandTemplate member for the capture
        '''    function. Call the AsyncCommandTemplate constructor to create a new template
        '''    command, next... and provide the command a <strong>ExpirationTime.</strong>
        '''    <code lang="VB">
        ''' Private mCaptureCommandTemplate As AsyncCommandTemplate
        ''' Protected Delegate Function CaptureMethod() As CaptureResultCollection
        ''' Public Overrides Readonly Property CaptureCommandTemplate() As Threading.AsyncCommandTemplate
        ''' Get
        '''     If mCaptureCommandTemplate Is Nothing Then
        '''         mCaptureCommandTemplate = New AsyncCommandTemplate
        '''         With mCaptureCommandTemplate
        '''             .TargetMethod = CreateDelegate(GetType(CaptureMethod), Me, "CaptureImage")
        '''             .ExpirationTime = CaptureCommandExpirationTime
        '''             .IgnoreUnderlyingHandleOfTargetControl = True
        '''         End With
        '''     End If
        '''     Return mCaptureCommandTemplate
        ''' End Get
        ''' End Property
        ''' 
        ''' Private Function CaptureImage() As CaptureResultCollection
        ''' ...
        ''' End Sub
        '''    </code>
        ''' </example>
        Public Overridable ReadOnly Property CaptureCommandTemplate() As Threading.AsyncCommandTemplate _
            Implements ISensor.CaptureCommandTemplate
            Get
                If InDesignMode(Me) Then Return Nothing
                Throw New MissingSpecializationException(Me.GetType, "CaptureCommand")
            End Get
        End Property

        Private mDownloadTemplate As Threading.AsyncCommandTemplate
        Public Overridable ReadOnly Property DownloadCommandTemplate() As Threading.AsyncCommandTemplate _
        Implements ISensor.DownloadCommandTemplate
            Get
                Return mDownloadTemplate
            End Get
        End Property

        Private mPollingWasCanceled As Boolean
        ''' <summary>
        ''' Get a boolean value indicating that capture has canceled.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property PollingWasCanceled() As Boolean Implements ISensor.PollingWasCanceled
            Get
                Return mPollingWasCanceled
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating that capture is cancel.
        ''' True is cancel, else False
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritablePollingWasCanceled() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mPollingWasCanceled
            End Get
            Set(ByVal value As Boolean)
                mPollingWasCanceled = value
            End Set
        End Property


        Protected Overridable Sub OnCaptureActivated(ByVal captureActivated As CaptureActivatedEventArgs)

            mPollingWasCanceled = False
            'mLastCaptureSuccessful = False

            If Not CapturesImmediately Then
                With TimeoutIndicator
                    .Visible = True
                    .StartCountdown(CaptureCommandTemplate.ExpirationTime)
                End With
                CancelCaptureButtonEnabled = CaptureIsCancelable
            End If

            Dim captureCommand As New AsyncCommand(CaptureCommandTemplate)
            mStatus = SensorStatus.Capturing
            CommandManager.Enqueue(captureCommand)
        End Sub

        Protected Sub StopCountdownTimerNow()
            TimeoutIndicator.StopCountdown()
            TimeoutIndicatorRefresh()
        End Sub

        Private Sub TimeoutIndicatorRefresh()
            SafeInvokeNoArgSub(Me, AddressOf TimeoutIndicatorRefreshImplementation)
        End Sub
        Private Sub TimeoutIndicatorRefreshImplementation()
            TimeoutIndicator.Refresh()
        End Sub

        Private Sub OutputtoLog(ByVal msg As String)
            If Not IO.Directory.Exists("c:\CrossmatchLog") Then
                IO.Directory.CreateDirectory("c:\CrossmatchLog")
            End If
            Dim sw As New System.IO.StreamWriter("c:\CrossmatchLog\GuardianTestingLog.txt", True)
            sw.WriteLine(DateTime.Now & " - " & msg)
            sw.Flush()
            sw.Close()
        End Sub
        Private Sub HandleCaptureCompleted(ByVal sender As Object, ByVal e As CommandCompleteEventArgs)
            OutputtoLog("In HandleCaptureCompleted")
            ' Stop the timeout indicator (if it's not already)
            If Not CapturesImmediately Then
                With TimeoutIndicator
                    .StopCountdown()
                End With
                SafeSetControlEnabled(CancelSensorButton, False)
            End If

            If Me.mStatus = SensorStatus.Capturing Then
                'Console.WriteLine("[HandleCaptureCompleted] " & Me.Name & " still in capturing mode.")

                OutputtoLog("[HandleCaptureCompleted] " & Me.Name & " still in capturing mode.")
                'OutputtoLog(e.Command.TargetException.ToString)
                MarkAsOffline()
            End If

        End Sub

        Private Sub HandleInitializationCompleted(ByVal sender As Object, ByVal e As CommandCompleteEventArgs)
            mOldConfiguration = Nothing
            OnInitializationCompleted(e)
        End Sub

        Protected Overridable Sub OnCaptureCompleted(ByVal e As CommandCompleteEventArgs)
            ' Meant to be overridden
        End Sub

        Protected Overridable Sub OnInitializationCompleted(ByVal e As CommandCompleteEventArgs)

        End Sub

        Private Sub HandleSensorButtonClick(ByVal sender As System.Object, ByVal e As EventArgs)
            RequiresParts()
            ActivateSensorButtonEnabled = False
            'ActivateSensorButton.Enabled = False
            Dim args As New CaptureActivatedEventArgs(Me)
            OnCaptureActivated(args)
            RaiseEvent CaptureActivated(Me, args)
        End Sub

        Public Overridable Function StartDownload(ByVal guid As Guid) As Guid Implements ISensor.StartDownload
            ForbidInvokeRequired(Me)
            mLatestDownloadWasSuccessful = False
            mStatus = SensorStatus.Downloading
            Dim downloadcommand As AsyncCommand = CreateDownloadCommand(guid)
            CommandManager.Enqueue(downloadcommand)
            HeaderLabel.Text = FriendlyName()
            Return downloadcommand.CommandId
        End Function

        Protected Overridable Function CreateDownloadCommand(ByVal guid As Guid) As AsyncCommand
            Throw New Mbark.MissingSpecializationException("CreateDownloadCommand")
        End Function

        Public Overridable Sub CancelCapture() Implements ISensor.CancelCapture
            If mStatus = SensorStatus.Capturing AndAlso CaptureIsCancelable Then
                CancelSensorButton.PerformClick()
            End If
        End Sub

        Public Sub ActivateCaptureNow() Implements ISensor.ActivateSensorNow
            'OutputLog("     [Capture button is " & ActivateSensorButtonEnabled.ToString & "]")
            If ActivateSensorButton.Enabled Then
                ActivateSensorButton.PerformClick()
            End If

        End Sub

#End Region

#Region "  Initialization & Uninitialization  "

        ''' <example>
        '''    <code lang="VB">
        ''' Protected Delegate Sub InitializationMethod()
        ''' Public Overrides Readonly Property InitializationCommandTemplate() As Threading.AsyncCommandTemplate
        '''      Get
        '''          Static init As AsyncCommandTemplate
        '''          If init Is Nothing Then
        '''              init = New AsyncCommandTemplate
        '''              With init
        '''                  .TargetMethod = CreateDelegate(GetType(InitializationMethod), Me, "Initialization")
        '''                  .ExpirationTime = 30000 'millisecond
        '''                  .IgnoreUnderlyingHandleOfTargetControl = True
        '''              End With
        '''          End If
        '''          Return init
        '''      End Get
        ''' End Property
        ''' Private Sub Initialization()
        '''   ...
        ''' End Sub
        '''    </code>
        ''' </example>
        Public Overridable ReadOnly Property InitializationCommandTemplate() As Threading.AsyncCommandTemplate _
                Implements ISensor.InitializationCommandTemplate
            Get
                If InDesignMode(Me) Then Return Nothing
                Throw New MissingSpecializationException(Me.GetType, "InitializationCommandTemplate")
            End Get
        End Property

        Public Overridable Function StartInitialize() As Guid Implements ISensor.StartInitialize
            ForbidInvokeRequired(Me)

            If mStatus = SensorStatus.Online Then Return Guid.Empty
            mStatus = SensorStatus.Initializing

            Dim initCommand As New AsyncCommand(InitializationCommandTemplate)

            If mCommandThreadLifetime = CommandThreadLifetime.PerInitialization Then
                CommandManager.Start()
            End If

            CommandManager.Enqueue(initCommand)

            HeaderLabel.Text = FriendlyName()

            Return initCommand.CommandId
        End Function

        Public Overridable Sub Uninitialize() Implements ISensor.Uninitialize
            ForbidInvokeRequired(Me)
            If mCommandThreadLifetime = CommandThreadLifetime.PerInitialization Then
                CommandManager.Stop(True)
            End If
            mStatus = SensorStatus.Uninitialized
        End Sub

#End Region

#Region "  Configuration  "

        ''' <example>
        '''    <code lang="VB">
        ''' Protected Delegate Sub ConfigurationMethod(ByVal config As SensorConfiguration)
        ''' Public Overrides Readonly Property ConfigurationCommandTemplate() As Threading.AsyncCommandTemplate
        '''       Get
        '''           Static config As AsyncCommandTemplate
        '''           If config Is Nothing Then
        '''               config = New AsyncCommandTemplate
        '''               With config
        '''                   .TargetMethod = CreateDelegate(GetType(ConfigurationMethod), Me, "Configuration")
        '''                   .ExpirationTime = 30000
        '''                   .IgnoreUnderlyingHandleOfTargetControl = True
        '''               End With
        '''           End If
        '''           Return config
        '''       End Get
        ''' End Property
        ''' Private Sub Configuration()
        '''    ...
        ''' End Sub
        '''    </code>
        ''' </example>
        Public Overridable ReadOnly Property ConfigurationCommandTemplate() As Threading.AsyncCommandTemplate _
            Implements ISensor.ConfigurationCommandTemplate
            Get
                If InDesignMode(Me) Then Return Nothing
                Throw New MissingSpecializationException(Me.GetType, "ConfigurationCommandTemplate")
            End Get
        End Property

        Public Overridable Function StartConfiguration(ByVal configuration As SensorConfiguration) As Guid _
            Implements ISensor.StartConfiguration

            ' The sensor must neither be offline nor uninitialized
            If IsOfflineOrUninitialized Then Throw New BadSensorStatusException("Configuration", LatestStatus)

            mStatus = SensorStatus.Configuring
            Dim configCommand As New AsyncCommand(ConfigurationCommandTemplate)

            configCommand.TargetMethodArgs(New Object() {configuration})

            CommandManager.Enqueue(configCommand)
            Return configCommand.CommandId

        End Function

#Region " Requires Configuration"

        Private mRequiresConfiguration As Boolean
        Private mOldConfiguration As SensorConfiguration
        ''' <summary>
        ''' Get a boolean value indicating whether the sensor require configuration process.
        ''' If the new configuration object is different than the exist configuration object, then this property return True, else False.
        ''' </summary>
        ''' <param name="NewConfiguration">Current configuration setting of the sensor</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property RequiresConfiguration(ByVal NewConfiguration As SensorConfiguration) As Boolean _
                                                            Implements ISensor.RequiresConfiguration
            Get
                Dim required As Boolean = True
                If Not mRequiresConfiguration AndAlso Not mOldConfiguration Is Nothing Then
                    ' If we don't already require configuration, and we have an old configuration to compare the new one to,
                    ' then we require information if the new configuration is not the same as the old one
                    '
                    required = Not (mOldConfiguration.Equals(NewConfiguration))
                End If
                mOldConfiguration = NewConfiguration
                mRequiresConfiguration = required
                Return required
            End Get
        End Property
        ''' <summary>
        ''' Get a boolean value indicating whether the sensor require configuration process.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property RequiresConfiguration() As Boolean _
        Implements ISensor.RequiresConfiguration
            Get
                Return mRequiresConfiguration
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether the sensor require configuration process.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableRequiresConfiguration() As Boolean
            <Obsolete("Use this property only to write values.")> Get
                Return mRequiresConfiguration
            End Get
            Set(ByVal value As Boolean)
                mRequiresConfiguration = value
            End Set
        End Property

#End Region

        Private Sub HandleConfigurationCompleted(ByVal sender As Object, ByVal e As CommandCompleteEventArgs)
            OnConfigurationCompleted(e)
        End Sub

        Protected Overridable Sub OnConfigurationCompleted(ByVal e As CommandCompleteEventArgs)
            ' Meant to be overridden
        End Sub



#End Region

#Region "IsTimeout Property"
        Private mIsTimeout As Boolean
        ''' <summary>
        ''' Set a boolean value indicating whether the current capture attempt is timeout.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableIsTimeout() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mIsTimeout
            End Get
            Set(ByVal value As Boolean)
                mIsTimeout = value
            End Set
        End Property
        ''' <summary>
        ''' Get a boolean value indicating whether the current capture attempt has timeout.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsTimeout() As Boolean
            Get
                Return mIsTimeout
            End Get
        End Property

#End Region

        Private Sub RequiresParts()
            Debug.Assert(Not mTargetParts Is Nothing)
            Debug.Assert(Not mInaccessibleParts Is Nothing)
        End Sub


        Public Overridable Sub StartLivePreview() Implements ISensor.StartLivePreview

        End Sub

        Public Overridable Sub StopLivePreview() Implements ISensor.StopLivePreview

        End Sub



        Public Overridable Function ConvertBytesAsObjectToBitmap(ByVal rawData As Object, ByVal width As Integer, ByVal height As Integer) As Bitmap
            Dim ByteArray() As Byte = CType(rawData, Byte())
            Dim bitmap As New Drawing.Bitmap(width, height, Imaging.PixelFormat.Format8bppIndexed)
            bitmap.Palette = EmptyPalette
            Dim bmd As Imaging.BitmapData = _
                            bitmap.LockBits(New Rectangle(0, 0, width, height), Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat)

            System.Runtime.InteropServices.Marshal.Copy(ByteArray, 0, bmd.Scan0, width * height)
            bitmap.UnlockBits(bmd)

            Return bitmap
        End Function

        Private mEmptyPalette As Drawing.Imaging.ColorPalette
        Public Sub InitEmptyPalette()
            Dim bitmap As New Drawing.Bitmap(Width, Height, Imaging.PixelFormat.Format8bppIndexed)
            mEmptyPalette = bitmap.Palette
            For i As Integer = 0 To 255
                EmptyPalette.Entries(i) = Color.FromArgb(i, i, i)
            Next
        End Sub

        Public ReadOnly Property EmptyPalette() As Drawing.Imaging.ColorPalette
            Get
                Return mEmptyPalette
            End Get
        End Property
        ''' <summary>
        ''' Set the sensor status to offline.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub MarkAsOffline()
            mStatus = SensorStatus.Offline
        End Sub
        ''' <summary>
        ''' Set the sensor status to online.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub MarkAsOnline()
            mStatus = SensorStatus.Online
        End Sub

#Region "LatestDownloadWasSuccessful Property"
        Private mLatestDownloadWasSuccessful As Boolean
        ''' <summary>
        ''' Get a boolean value indicating whether the download process has successfully completed.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LatestDownloadWasSuccessful() As Boolean Implements ISensor.LatestDownloadWasSuccessful
            Get
                Return mLatestDownloadWasSuccessful
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether the download process is finish.
        ''' True if successfully finish, else False.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property WritableLatestDownloadWasSuccessful() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mLatestDownloadWasSuccessful
            End Get
            Set(ByVal value As Boolean)
                mLatestDownloadWasSuccessful = value
            End Set
        End Property
#End Region
        ''' <summary>
        ''' Cancel download process.
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Must implement this function if sensor require download and allow download to cancel.</remarks>
        Public Overridable Function CancelDownload() As Boolean Implements ISensor.CancelDownload
            Throw New MissingSpecializationException("CancelDownload")
        End Function
        ''' <summary>
        ''' Get a boolean value indicating whether download process can be cancel.
        ''' </summary>
        ''' <value></value>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DownloadIsCancellable() As Boolean Implements ISensor.DownloadIsCancelable
            Get
                Return mDownloadIsCancellable
            End Get
        End Property
        ''' <summary>
        ''' Get or set a boolean value indicatin whether download process can be cancel.
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Property WritableDownloadIsCancellable() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mDownloadIsCancellable
            End Get
            Set(ByVal value As Boolean)
                mDownloadIsCancellable = value
            End Set
        End Property

#Region "LatestDownloadWasCanceled Property"
        Private mLatestDownloadWasCanceled As Boolean
        Public ReadOnly Property LatestDownloadWasCanceled() As Boolean Implements ISensor.LatestDownloadWasCanceled
            Get
                Return mLatestDownloadWasCanceled
            End Get
        End Property
        Protected Property WritableLatestDownloadWasCanceled() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mLatestDownloadWasCanceled
            End Get
            Set(ByVal value As Boolean)
                mLatestDownloadWasCanceled = value
            End Set
        End Property

#End Region
        Public Overridable Sub DeleteInternalImages() Implements ISensor.DeleteInternalImages
            ' Meant to be overridden
        End Sub

#Region "DeferInitialization Property"
        Private mDeferInitialization As Boolean
        ''' <summary>
        ''' Get a boolean value indicating whether initialization process occur when a
        ''' session begin.
        ''' </summary>
        ''' <value>
        ''' <strong>true</strong> if only initialize the sensor when performing a task,
        ''' otherwise <strong>false</strong>. The default is <strong>false</strong>.
        ''' </value>
        Public ReadOnly Property DeferInitialization() As Boolean Implements ISensor.DeferInitialization
            Get
                Return mDeferInitialization
            End Get
        End Property
        ''' <summary>
        ''' Set a boolean value indicating whether initialization process occur when a
        ''' session begin.
        ''' </summary>
        Protected Property WritableDeferInitialization() As Boolean
            <Obsolete(ForbiddenGetterMessage)> Get
                Return mDeferInitialization
            End Get
            Set(ByVal value As Boolean)
                mDeferInitialization = value
            End Set
        End Property
#End Region

#Region "RequiresRecovery Property"
        ''' <summary>
        ''' Get or set a boolean value indicating whether the sensor will automatically re-initialize.
        ''' </summary>
        ''' <value>
        ''' <strong>true</strong> if sensor can automatically initialize if failed, otherwise
        ''' <strong>false</strong>. The default is <strong>false</strong>.
        ''' </value>
        ''' <returns>Boolean</returns>
        ''' <example>
        '''    <code lang="VB">
        ''' Private Sub Initialize()
        '''            RequiresRecovery = False
        '''            Try
        '''                ...
        '''                If noError Then
        '''                    MarkAsOnline()
        '''                Else
        '''                    RequiresRecovery = True
        '''                    MarkAsOffline()
        '''                    Dim ife As New InitializationFailureException
        '''                    ife.MachineNotes = ErrorCodeToString(errorCode)
        '''                    ife.Sensor = Me
        '''                    Throw ife
        '''                End If
        ''' 
        '''            Catch ex As Exception
        '''                RequiresRecovery = True
        '''                MarkAsOffline()
        '''                Dim ife As New InitializationFailureException
        '''                ife.MachineNotes = ex.message
        '''                ife.Sensor = Me
        '''                Throw ife
        '''            End Try
        ''' 
        '''        End Sub
        '''    </code>
        ''' </example>
        Public Property RequiresRecovery() As Boolean Implements ISensor.RequiresRecovery
            Get
                Return mRequiresRecovery
            End Get
            Protected Set(ByVal Value As Boolean)
                mRequiresRecovery = Value
            End Set
        End Property
#End Region

#Region " Log4Net "
        'Private mIsLoggerMode As Boolean = True
        'Private mLog As New Logger(GetType(BaseSensorController))
#End Region

#Region " Sensor Setting Control "
        'Public Overridable ReadOnly Property GetSensorSettingControl() As SensorSettingControl Implements ISensor.GetSensorSettingControl
        '    Get
        '        Return Nothing
        '    End Get
        'End Property
        'Public Overridable Sub SaveSensorSettingControl(ByVal SettingControl As SensorSettingControl) Implements ISensor.SaveSensorSettingControl
        'End Sub

#End Region

        Public Sub RaiseBadStatusEvent(ByVal sender As Object, ByVal e As BadStatusEventArgs)
            RaiseEvent BadStatus(sender, e)
        End Sub

        Public Event BadStatus(ByVal sender As Object, ByVal e As BadStatusEventArgs) Implements ISensor.BadStatus

#Region "       Handle Initialization Exceptions       "
        Protected Sub HandleInitializationFailureException(ByVal machineException As Exception)
            MarkAsOffline()
            RequiresRecovery = True
            Dim ife As New InitializationFailureException
            ife.Sensor = Me
            ife.MachineNotes = machineException.Message
            ife.MachineException = machineException
            Throw ife
        End Sub
        Protected Sub HandleInitializationFailureException(ByVal machineNotes As String)
            MarkAsOffline()
            RequiresRecovery = True
            Dim ife As New InitializationFailureException
            ife.Sensor = Me
            ife.MachineNotes = machineNotes
            Throw ife
        End Sub
        Protected Sub HandleInitializationTimeoutException(ByVal machineNotes As String)
            MarkAsOffline()
            RequiresRecovery = True
            Dim ite As New InitializationTimeoutException
            ite.Sensor = Me
            ite.MachineNotes = machineNotes
            Throw ite
        End Sub
#End Region

#Region "       Handle Configuration Exceptions       "
        Protected Sub HandleConfigurationFailureException(ByVal machineException As Exception)
            Dim cfe As ConfigurationFailureException = CreateConfigurationFailureException()
            cfe.MachineException = machineException
            Throw cfe
        End Sub

        Protected Sub HandleConfigurationFailureException(ByVal machineNotes As String)
            Dim cfe As ConfigurationFailureException = CreateConfigurationFailureException()
            cfe.MachineNotes = machineNotes
            Throw cfe
        End Sub

        Private Function CreateConfigurationFailureException() As ConfigurationFailureException
            WritableRequiresConfiguration = True
            RequiresRecovery = True
            MarkAsOffline()
            Dim cfe As New ConfigurationFailureException
            cfe.Sensor = Me
            Return cfe
        End Function

        Protected Sub HandleConfigurationTimeoutException(ByVal machineNotes As String)
            WritableRequiresConfiguration = True
            MarkAsOffline()
            Dim cfe As New ConfigurationTimeoutException
            cfe.Sensor = Me
            cfe.MachineNotes = machineNotes
            Throw cfe
        End Sub
#End Region

#Region "       Handle Capture Exceptions       "
        Protected Sub HandleCaptureFailureException(ByVal machineNote As String, ByVal toMarkOffline As Boolean)
            If toMarkOffline Then
                MarkAsOffline()
            Else
                MarkAsOnline()
            End If
            Dim cfe As New CaptureFailureException
            cfe.Sensor = Me
            cfe.MachineNotes = machineNote.ToString
            Throw cfe
        End Sub
        Protected Sub HandleCaptureFailureException(ByVal machineException As Exception, ByVal toMarkOffline As Boolean)
            If toMarkOffline Then
                MarkAsOffline()
            Else
                MarkAsOnline()
            End If
            Dim cfe As New CaptureFailureException
            cfe.Sensor = Me
            cfe.MachineNotes = machineException.Message
            cfe.MachineException = machineException
            Throw cfe
        End Sub
        Protected Sub HandleCaptureTimeoutException(ByVal machineNote As String)
            MarkAsOnline()
            OutputtoLog("BaseSensor HandleCaptureTimeoutException call MarkAsOnline() - my Lastest status = " & Me.LatestStatus.ToString)
            Dim cte As New CaptureTimeoutException
            cte.Sensor = Me
            cte.MachineNotes = machineNote
            Throw cte
        End Sub
        Protected Sub HandlePollingCancelException(ByVal machineNote As String)
            MarkAsOnline()
            Dim pwc As New PollingCanceledException
            pwc.Sensor = Me
            pwc.MachineNotes = machineNote
            Throw pwc
        End Sub
#End Region

#Region "       Handle Download Exceptions      "
        Protected Sub HandleDownloadFailureException(ByVal machineNothing As String)
            MarkAsOnline()
            Dim dfe As New DownloadFailureException
            dfe.Sensor = Me
            dfe.MachineNotes = machineNothing
            Throw New DownloadFailureException
        End Sub

        Protected Sub HandleDownloadFailureException(ByVal machineNote As Exception)
            MarkAsOnline()
            Dim dfe As New DownloadFailureException
            dfe.Sensor = Me
            dfe.MachineNotes = machineNote.Message
            dfe.MachineException = machineNote
            Throw New DownloadFailureException
        End Sub
#End Region

#Region "       Trace Listeners     "

        Protected Overridable Sub Trace(ByVal message As String)
        End Sub
        Protected Overridable Sub Trace(ByVal message As String, ByVal ex As Exception)
        End Sub

        Protected Sub Trace(ByVal sensorName As String, ByVal message As String)
            If Diagnostics.Trace.Listeners(sensorName) IsNot Nothing Then
                Dim now As DateTime = DateTime.Now
                Dim dateNow As String = now.Date.ToShortDateString
                Dim timeNow As String = String.Format("{0,-2:00}:{1,-2:00}:{2,-2:00}.{3,-3:000}", _
                    now.TimeOfDay.Hours, now.TimeOfDay.Minutes, now.TimeOfDay.Seconds, now.TimeOfDay.Milliseconds)

                Diagnostics.Trace.Listeners(sensorName).WriteLine(dateNow & " " & timeNow & ": " & message)
                Diagnostics.Trace.Listeners(sensorName).Flush()
            End If
        End Sub

        Protected Sub Trace(ByVal sensorName As String, ByVal message As String, ByVal ex As Exception)
            If Diagnostics.Trace.Listeners(sensorName) IsNot Nothing Then
                Dim now As DateTime = DateTime.Now
                With Diagnostics.Trace.Listeners(sensorName)
                    .WriteLine(now.ToString & "." & now.Millisecond & ": " & message)
                    .WriteLine(ex.GetType.ToString)
                    .WriteLine(UnwindAllMessages(ex))
                    .Flush()
                End With
            End If
        End Sub

#End Region
    End Class

End Namespace
