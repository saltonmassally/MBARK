Option Strict On

Imports System.Collections.Generic
Imports System.Delegate
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Threading

Imports Mbark.Threading
Imports Mbark.UI
Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Class BaseVirtualSensor
        Inherits BaseSensor

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
        End Sub

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Friend WithEvents PositionTimer As System.Windows.Forms.Timer
        'Friend WithEvents IrisImageBox As System.Windows.Forms.PictureBox
        Friend WithEvents mMessageCtrl As Syncfusion.Windows.Forms.Tools.GradientLabel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.mMessageCtrl = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.PositionTimer = New System.Windows.Forms.Timer(Me.components)
            Me.MainPanel.SuspendLayout()
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.OuterPanel.SuspendLayout()
            Me.InnerPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'CancelSensorButton
            '
            '
            'TimeoutIndicator
            '
            Me.TimeoutIndicator.Size = New System.Drawing.Size(310, 16)
            '
            'MainPanel
            '
            Me.MainPanel.Controls.Add(Me.mMessageCtrl)
            Me.MainPanel.Size = New System.Drawing.Size(312, 168)
            '
            'OuterPanel
            '
            Me.OuterPanel.Size = New System.Drawing.Size(312, 256)
            '
            'InnerPanel
            '
            Me.InnerPanel.Size = New System.Drawing.Size(310, 174)
            '
            'mMessageCtrl
            '
            Me.mMessageCtrl.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(247, Byte), Integer)), System.Drawing.SystemColors.ActiveCaptionText)
            Me.mMessageCtrl.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.mMessageCtrl.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
            Me.mMessageCtrl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.mMessageCtrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.mMessageCtrl.Location = New System.Drawing.Point(0, 0)
            Me.mMessageCtrl.Name = "mMessageCtrl"
            Me.mMessageCtrl.Size = New System.Drawing.Size(312, 168)
            Me.mMessageCtrl.TabIndex = 7
            Me.mMessageCtrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'BaseVirtualSensor
            '
            Me.Name = "BaseVirtualSensor"
            Me.Size = New System.Drawing.Size(316, 256)
            Me.MainPanel.ResumeLayout(False)
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.OuterPanel.ResumeLayout(False)
            Me.InnerPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


#Region " Properties "
        Protected Delegate Function ProcessDelegate(ByVal waitObj As Object) As Object
        Protected Delegate Function CaptureDelegate(ByVal CmdGuid As Guid) As Object

        Public Sub New(ByVal VirtualModality As SensorModality, Optional ByVal DeferInit As Boolean = False)
        End Sub

        Protected mCapturesImmediately As Boolean
        Public Overrides ReadOnly Property CapturesImmediately() As Boolean
            Get
                Return mCapturesImmediately
            End Get
        End Property
        Protected mModality As SensorModality
        Public Overrides ReadOnly Property Modality() As SensorModality
            Get
                Return mModality
            End Get
        End Property

        Public Overrides ReadOnly Property FriendlyName() As String
            Get
                Return Messages.Virtual(UICulture) & " " & SensorModalitySupport.ToString(UICulture, mModality)
            End Get
        End Property



        Private mThumbnail As Bitmap
        Protected Shared smRandom As New Random
#End Region

#Region "       Initialization         "
        Public Overrides ReadOnly Property InitializationCommandTemplate() As Threading.AsyncCommandTemplate
            Get
                Static init As AsyncCommandTemplate
                If init Is Nothing Then
                    init = New AsyncCommandTemplate
                    With init
                        .TargetMethod = CreateDelegate(GetType(ProcessDelegate), Me, "SimulateInitialize")
                        .ExpirationTime = 10000 '10 seconds
                        .IgnoreUnderlyingHandleOfTargetControl = True
                    End With
                End If
                Return init
            End Get
        End Property

        Private Function SimulateInitialize(ByVal waitObj As Object) As Object
            mInitializeOperationBehavior = DirectCast(waitObj, VirtualSensorOperationBehavior)

            Dim elapsed As Integer
            Try
                With mInitializeOperationBehavior
                    Dim percent As Single
                    elapsed = PerformWait(.Wait, .InvocationStyle, percent)
                    If smRandom.NextDouble < .ProbabilityOfFailure Then
                        '        ReportError(Me, "Initialization failure")
                        MyBase.MarkAsOffline()
                        MyBase.RequiresRecovery = True
                        Throw New InitializationFailureException
                    ElseIf smRandom.NextDouble < .ProbabilityOfTimeout Then
                        MyBase.MarkAsOffline()
                        MyBase.RequiresRecovery = True
                        Throw New InitializationTimeoutException
                    Else
                        MyBase.MarkAsOnline()
                        '        MainLabel.Text = "Ready"
                    End If
                End With

            Catch ex As ThreadInterruptedException
                '    ReportError(Me, "Initialization timeout")
                MyBase.MarkAsOffline()
                MyBase.RequiresRecovery = True
                Throw New InitializationTimeoutException
            End Try
            SensorProperties()
            ''Console.WriteLine(DateTime.Now.Ticks & " " & FriendlyName & " init completed.")
            Return Me
            'Return elapsed
        End Function
        Private mSensorProperties As New SensorProperties
        Private Sub SensorProperties()
            mSensorProperties.Modality = mModality
            mSensorProperties.ModelName = FriendlyName()
        End Sub
#End Region

#Region "         Configuration         "

        Private mCaptureOperationBehavior As New VirtualSensorOperationBehavior
        Private mDownloadOperationBehavior As New VirtualSensorOperationBehavior
        Private mInitializeOperationBehavior As New VirtualSensorOperationBehavior
        Protected Delegate Sub ConfigurationDelegate(ByVal config As SensorConfiguration)
        Public Overrides ReadOnly Property ConfigurationCommandTemplate() As Threading.AsyncCommandTemplate
            Get
                Static config As AsyncCommandTemplate
                If config Is Nothing Then
                    config = New AsyncCommandTemplate
                    With config
                        .TargetMethod = CreateDelegate(GetType(ConfigurationDelegate), Me, "Configuration")
                        .ExpirationTime = 10000
                        .IgnoreUnderlyingHandleOfTargetControl = True
                    End With
                End If
                Return config
            End Get
        End Property

        Public Sub Configuration(ByVal ConfigurationObj As SensorConfiguration)
            Dim ConfigObj As VirtualSensorsConfiguration = CType(ConfigurationObj, VirtualSensorsConfiguration)

            mCaptureOperationBehavior = ConfigObj.CaptureOperationBehavior
            mDownloadOperationBehavior = ConfigObj.DownloadOperationBehavior

            MyBase.MarkAsOnline()
        End Sub
#End Region

#Region "       Uninitialization        "
        Public Overrides Sub Uninitialize()
            MyBase.Uninitialize()
        End Sub
#End Region

#Region "       Capture         "

        Protected Delegate Function CDelegate() As Object
        Public Overrides ReadOnly Property CaptureCommandTemplate() As Threading.AsyncCommandTemplate
            Get
                Static Capture As AsyncCommandTemplate
                If Capture Is Nothing Then
                    Capture = New AsyncCommandTemplate
                    With Capture
                        .TargetMethod = CreateDelegate(GetType(CDelegate), Me, "SimulateCapture")
                        .ExpirationTime = 15000
                        .IgnoreUnderlyingHandleOfTargetControl = True
                    End With
                End If
                Return Capture
            End Get
        End Property



        Private Function SimulateCapture() As Object
            ' Clear the thumbnail
            WritableLatestThumbnail = Nothing

            Dim picture As Bitmap

            Dim percentCaptured As Single

            Dim CaptureResultList As New CaptureResultCollection
            ' Simulate errors first; it's faster. :)
            If smRandom.NextDouble <= mCaptureOperationBehavior.ProbabilityOfFailure Then
                MyBase.MarkAsOnline()
                Throw New CaptureFailureException
                Return Nothing
            End If

            Try

                If Modality = SensorModality.Face Then
                    DisplayInstruction = Messages.CapturingBiometricDataDotDotDot & vbNewLine
                    ' Next, we simulate a review download delay
                    With mCaptureOperationBehavior
                        PerformWait(.Wait, .InvocationStyle, percentCaptured)
                    End With
                    picture = GeneratePicture()

                    CaptureResultList = Nothing
                Else

                    Mbark.UI.SafeInvokeNoArgSub(Me, AddressOf Refresh)

                    DisplayInstruction = Messages.Polling & vbNewLine
                    Dim elapsed As Integer
                    With mCaptureOperationBehavior
                        Do
                            elapsed += PerformWait(.Wait, .InvocationStyle, percentCaptured)
                            'Dim db As Double = smRandom.NextDouble
                            'Console.WriteLine(db & " > " & .ProbabilityOfTimeout)
                            If smRandom.NextDouble > .ProbabilityOfTimeout Then 'Exit Do
                                'Console.WriteLine(elapsed & " > " & .Wait.ProcessTime)
                                If elapsed > .Wait.ProcessTime Then Exit Do
                            End If
                            If PollingWasCanceled Then Exit Do
                        Loop While elapsed < .Timeout 'Or Not mPollingIsCancelled

                        If PollingWasCanceled Then
                            Dim pce As New PollingCanceledException
                            pce.Sensor = Me
                            pce.MachineNotes = "Polling cancelled"
                            Throw pce
                        End If
                        If elapsed > .Timeout Then
                            Dim cte As New CaptureTimeoutException
                            cte.Sensor = Me
                            cte.MachineNotes = "Capture timeout"
                            Throw cte
                        End If
                    End With
                    picture = GeneratePicture()

                    Dim result As New CaptureResult
                    result.ImageProperties.Image = picture
                    result.ImageProperties.Timestamp = DateTime.Now
                    result.SensorProperties = mSensorProperties
                    CaptureResultList.Add(result)
                End If

                WritableLatestThumbnail = picture
            Catch ex As ThreadInterruptedException
                Me.MarkAsOffline()
                DisplayInstruction = String.Empty
                Dim cte As New CaptureTimeoutException
                cte.Sensor = Me
                cte.MachineNotes = "Capture timeout"
                Throw cte
            Finally
                Me.MarkAsOnline()
                DisplayInstruction = String.Empty
            End Try
            Return CaptureResultList
        End Function


#Region " Display Instruction "

        Public Property DisplayInstruction() As String
            Get
                Return SafeInvokeNoArgFunction(Of String)(Me, AddressOf GetDisplayInstructionImplementation)
            End Get

            Protected Set(ByVal value As String)
                SafeInvoke1ArgSub(Of String)(Me, AddressOf SetDisplayInstructionImplementation, value)
            End Set

        End Property

        Private Function GetDisplayInstructionImplementation() As String
            Return mMessageCtrl.Text
        End Function

        Private Sub SetDisplayInstructionImplementation(ByVal value As String)
            mMessageCtrl.Text = value
        End Sub
#End Region

        Protected Function GeneratePicture() As Bitmap
            Dim fp As Bitmap
            If Modality = SensorModality.Fingerprint Then
                fp = New Bitmap(Me.GetType, "fingerprint.gif")
            ElseIf Modality = SensorModality.Face Then
                fp = New Bitmap(Me.GetType(), "face.gif")
            Else
                fp = New Bitmap(Me.GetType(), "iris.jpg")
            End If

            Dim w As Integer = fp.Width
            Dim h As Integer = fp.Height

            Dim picture As New Drawing.Bitmap(w, h, Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Drawing.Graphics.FromImage(picture)

            g.PageUnit = GraphicsUnit.Pixel
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
            g.FillRectangle(New SolidBrush(Color.White), 0, 0, CInt(w), CInt(h))

            g.DrawImage(fp, CInt(w / 2 - fp.Width / 2), CInt(h / 2 - fp.Height / 2))
            OverlayTextOnPicture(picture, Color.Black, Color.White)

            Return picture
        End Function
        Private Sub OverlayTextOnPicture(ByVal picture As Bitmap, ByVal fgTextColor As Color, ByVal bgTextColor As Color)
            Dim g As Graphics = Drawing.Graphics.FromImage(picture)
            Dim builder As New System.Text.StringBuilder

            Static InvocationStyles As Dictionary(Of VirtualSensorInvocationStyle, String)
            If InvocationStyles Is Nothing Then
                InvocationStyles = New Dictionary(Of VirtualSensorInvocationStyle, String)
                InvocationStyles(VirtualSensorInvocationStyle.Synchronous) = "Sync"
                InvocationStyles(VirtualSensorInvocationStyle.SynchronouslyWrappedAsynchronous) = "Async"
            End If

            With builder
                .Append(DateTime.Now.ToString).Append(vbNewLine)
                .Append("Active = ").Append(Me.mCapturesImmediately).Append(vbNewLine)
                .Append("Init = ").Append(InvocationStyles(mInitializeOperationBehavior.InvocationStyle)).Append(vbNewLine)
                .Append("Capture = ").Append(InvocationStyles(mCaptureOperationBehavior.InvocationStyle)).Append(vbNewLine)
                .Append("Download = ").Append(InvocationStyles(mDownloadOperationBehavior.InvocationStyle)).Append(vbNewLine)
                .Append("Target parts = ").Append(TargetParts.ToString).Append(vbNewLine)
                .Append("Missing parts = ").Append(InaccessibleParts.ToString).Append(vbNewLine)
            End With
            g.DrawString(builder.ToString, New Font("Arial", 8, FontStyle.Bold), New SolidBrush(bgTextColor), 1, 1)
            g.DrawString(builder.ToString, New Font("Arial", 8, FontStyle.Bold), New SolidBrush(fgTextColor), 0, 0)
        End Sub
#End Region

#Region "       Download      "
        Protected Overrides Function CreateDownloadCommand(ByVal id As Guid) As AsyncCommand
            Dim DownloadCommand As New AsyncCommand(DownloadCommandTemplate)
            DownloadCommand.TargetMethodArg(0) = id
            Return DownloadCommand
        End Function

        Public Overrides ReadOnly Property DownloadCommandTemplate() As Threading.AsyncCommandTemplate
            Get
                Static download As AsyncCommandTemplate
                If download Is Nothing Then
                    download = New AsyncCommandTemplate
                    With download
                        .TargetMethod = CreateDelegate(GetType(DownloadDelegate), Me, "DownloadImage")
                        Dim args As Object() = {Guid.Empty}
                        .TargetMethodArgs(args)
                        .ExpirationTime = 5500 ' 3mins
                        .IgnoreUnderlyingHandleOfTargetControl = True
                    End With
                End If
                Return download
            End Get
        End Property
        Private Delegate Function DownloadDelegate(ByVal id As Guid) As Object
        Private Function DownloadImage(ByVal id As Guid) As Object

            WritableLatestDownloadWasSuccessful = False
            WritableLatestDownloadWasCanceled = False
            WritablePercentDownloaded = 0

            'If smRandom.NextDouble < mDownloadOperationBehavior.ProbabilityOfFailure Then
            '    MarkAsOffLine()
            '    Throw New DownloadFailureException
            'End If

            Dim elapsed As Integer
            Try
                With mDownloadOperationBehavior

                    Do
                        elapsed += PerformWait(.Wait, .InvocationStyle, PercentDownloaded)
                        Dim db As Double = smRandom.NextDouble
                        Console.WriteLine(db & " " & .ProbabilityOfTimeout)
                        If db > .ProbabilityOfTimeout Then 'Exit Do
                            Console.WriteLine(elapsed & " " & .Wait.ProcessTime)
                            If elapsed > .Wait.ProcessTime Then
                                WritableLatestDownloadWasSuccessful = True
                                Exit Do
                            End If
                        End If


                        WritablePercentDownloaded = PercentDownloaded + (1.0! / CSng(.Wait.ProcessTime / .Wait.ShortTime))
                    Loop While (elapsed < .Timeout)

                    If smRandom.NextDouble <= .ProbabilityOfFailure Then
                        MarkAsOffline()
                        Dim dfe As New DownloadFailureException
                        dfe.Sensor = Me
                        dfe.MachineNotes = "Download Failure Exception"
                        Throw dfe
                    End If

                    If LatestDownloadWasSuccessful Or LatestDownloadWasCanceled Then
                        MarkAsOnline()
                        If LatestDownloadWasCanceled Then WritableLatestDownloadWasSuccessful = False
                    End If

                End With
            Catch tiex As ThreadInterruptedException
                WritableLatestDownloadWasSuccessful = False
                Dim dte As New DownloadTimeoutException
                dte.Sensor = Me
                dte.MachineNotes = "DownloadImage timeout"
                Throw dte
            Finally
                'MyBase.MarkAsOnline()
                WritablePercentDownloaded = 0
            End Try

            Dim picture As Bitmap = GeneratePicture()

            Dim result As New CaptureResult
            result.ImageProperties.Image = picture
            result.ImageProperties.Timestamp = DateTime.Now
            result.SensorProperties = mSensorProperties
            Dim CaptureResultList As New CaptureResultCollection
            CaptureResultList.Add(result)
            Return CaptureResultList
        End Function

        Public Overrides Function CancelDownload() As Boolean
            WritableLatestDownloadWasSuccessful = False
            WritableLatestDownloadWasCanceled = True
            System.Threading.Thread.Sleep(1000)
            WritablePercentDownloaded = 0
        End Function
#End Region

        Private Sub CancelSensorButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelSensorButton.Click
            WritablePollingWasCanceled = True
        End Sub

#Region "   Virtual Functions   "
        Protected Friend Function PerformWait(ByVal waiter As VirtualBimodalWait, ByVal InvocationStyle As VirtualSensorInvocationStyle, _
                                                ByRef percentComplete As Single) As Integer
            Dim elapsed As Integer

            If InvocationStyle = VirtualSensorInvocationStyle.Synchronous Then
                elapsed = SynchronousWait(waiter)
            ElseIf InvocationStyle = VirtualSensorInvocationStyle.SynchronouslyWrappedAsynchronous Then
                elapsed = SynchronizedAsynchronousWait(waiter, percentComplete)
            End If

            Return elapsed

        End Function

        Private Function SynchronousWait(ByVal waiter As VirtualBimodalWait) As Integer
            Return waiter.Wait(25)
        End Function

        Private WithEvents mAsyncTimer As Timers.Timer
        Protected Friend mAsyncWaitIsDone As Boolean
        Private Function SynchronizedAsynchronousWait(ByVal waiter As VirtualBimodalWait, ByRef percentComplete As Single) As Integer
            mAsyncWaitIsDone = False

            If waiter Is mCaptureOperationBehavior.Wait Then
                WritablePollingWasCanceled = False
            ElseIf waiter Is mDownloadOperationBehavior.Wait Then
                WritableLatestDownloadWasCanceled = False
            End If

            Dim waitTime As Integer = waiter.WaitTime
            mAsyncTimer = New Timers.Timer(waitTime)

            Dim ticksToWait As Long = waitTime * TimeSpan.TicksPerMillisecond
            Dim startTicks As Long = DateTime.Now.Ticks
            Dim elapsedTicks As Long

            Dim isCancelled As Boolean

            mAsyncTimer.Start()
            While Not mAsyncWaitIsDone AndAlso Not isCancelled AndAlso percentComplete <= 1.0 ' CHECK: Why is this percentComplete necessary?
                WaitWithDoEvents(150, 10)
                elapsedTicks = DateTime.Now.Ticks - startTicks
                percentComplete = CType(elapsedTicks / ticksToWait, Single)

                If waiter Is mCaptureOperationBehavior.Wait Then
                    isCancelled = PollingWasCanceled
                End If

                If waiter Is mDownloadOperationBehavior.Wait Then
                    isCancelled = LatestDownloadWasCanceled
                End If

            End While

            If isCancelled And waiter Is mCaptureOperationBehavior.Wait Then Throw New PollingCanceledException

            Dim now As Long = DateTime.Now.Ticks
            Dim elapsed As Long = now - startTicks
            Dim msElapsed As Integer = CInt(elapsed * 1.0 / TimeSpan.TicksPerMillisecond)

            Return msElapsed
        End Function
#End Region

    End Class

    <Serializable()> Public Class VirtualSensorsConfiguration
        Inherits SensorConfiguration
        Public CaptureOperationBehavior As New VirtualSensorOperationBehavior
        Public DownloadOperationBehavior As New VirtualSensorOperationBehavior

        Public Overrides Function Clone() As Object
            Dim newConfiguration As New VirtualSensorsConfiguration
            newConfiguration.CaptureOperationBehavior = CaptureOperationBehavior
            newConfiguration.DownloadOperationBehavior = DownloadOperationBehavior
            Return newConfiguration
        End Function
    End Class

    Public Enum VirtualSensorInvocationStyle
        Synchronous
        SynchronouslyWrappedAsynchronous
    End Enum

    <Serializable()> Public Class VirtualSensorOperationBehavior
        Private mWait As New VirtualBimodalWait
        Private mInvocationStyle As VirtualSensorInvocationStyle
        Private mProbabilityOfFailure As Decimal
        Private mProbabilityOfTimeout As Decimal
        Private mTimeout As Integer

        Public Property Wait() As VirtualBimodalWait
            Get
                Return mWait
            End Get
            Set(ByVal value As VirtualBimodalWait)
                mWait = value
            End Set
        End Property
        Public Property InvocationStyle() As VirtualSensorInvocationStyle
            Get
                Return mInvocationStyle
            End Get
            Set(ByVal value As VirtualSensorInvocationStyle)
                mInvocationStyle = value
            End Set
        End Property
        Public Property ProbabilityOfFailure() As Decimal
            Get
                Return mProbabilityOfFailure
            End Get
            Set(ByVal value As Decimal)
                mProbabilityOfFailure = value
            End Set
        End Property
        Public Property ProbabilityOfTimeout() As Decimal
            Get
                Return mProbabilityOfTimeout
            End Get
            Set(ByVal value As Decimal)
                mProbabilityOfTimeout = value
            End Set
        End Property
        Public Property Timeout() As Integer
            Get
                Return mTimeout
            End Get
            Set(ByVal value As Integer)
                mTimeout = value
            End Set
        End Property

    End Class

    Public Class VirtualFingerprint
        Inherits BaseVirtualSensor
        Public Sub New()
            mModality = SensorModality.Fingerprint
            mCapturesImmediately = False

            MyBase.TimeoutIndicator.CriticalTime = 3 * 1000
            MyBase.WritableRequiresConfiguration = True
            MyBase.WritableHasConfigurationClass = True
            MyBase.WritableConfigurationClassName = "Mbark.Sensors.VirtualSensorsConfiguration"


        End Sub
    End Class

    Public Class VirtualFace
        Inherits BaseVirtualSensor
        Public Sub New()
            mModality = SensorModality.Face
            mCapturesImmediately = True

            MyBase.TimeoutIndicator.CriticalTime = 3 * 1000

            MyBase.WritableRequiresConfiguration = True
            MyBase.WritableHasConfigurationClass = True
            MyBase.WritableConfigurationClassName = "Mbark.Sensors.VirtualSensorsConfiguration"

            MyBase.WritableRequiresReview = True
            MyBase.WritableRequiresDownload = True
            MyBase.WritableHasLivePreview = False
            MyBase.WritableDownloadIsCancellable = True
            MyBase.WritablePercentDownloadedIsMeaningful = True

        End Sub
    End Class

    Public Class VirtualIris
        Inherits BaseVirtualSensor
        Public Sub New()
            mModality = SensorModality.Iris
            WritableDeferInitialization = False
            mCapturesImmediately = False

            MyBase.TimeoutIndicator.CriticalTime = 3 * 1000

            MyBase.WritableRequiresConfiguration = True
            MyBase.WritableHasConfigurationClass = True
            MyBase.WritableConfigurationClassName = "Mbark.Sensors.VirtualSensorsConfiguration"

        End Sub

    End Class


End Namespace