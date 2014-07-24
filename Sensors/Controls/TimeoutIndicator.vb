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

Imports System.Delegate

Imports SF = Syncfusion.Windows.Forms

Namespace Mbark.UI

    Public Class TimeoutIndicator
        Inherits System.Windows.Forms.UserControl

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
        Friend WithEvents ProgressBar As Syncfusion.Windows.Forms.Tools.ProgressBarAdv
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TimeoutIndicator))
            Me.ProgressBar = New Syncfusion.Windows.Forms.Tools.ProgressBarAdv
            CType(Me.ProgressBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ProgressBar
            '
            Me.ProgressBar.AccessibleDescription = resources.GetString("ProgressBar.AccessibleDescription")
            Me.ProgressBar.AccessibleName = resources.GetString("ProgressBar.AccessibleName")
            Me.ProgressBar.Anchor = CType(resources.GetObject("ProgressBar.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.ProgressBar.BackGradientEndColor = System.Drawing.Color.White
            Me.ProgressBar.BackGradientStartColor = System.Drawing.Color.LightGray
            Me.ProgressBar.BackgroundImage = CType(resources.GetObject("ProgressBar.BackgroundImage"), System.Drawing.Image)
            Me.ProgressBar.BackMultipleColors = New System.Drawing.Color() {System.Drawing.Color.Empty}
            Me.ProgressBar.BackSegments = False
            Me.ProgressBar.BackTubeEndColor = System.Drawing.Color.White
            Me.ProgressBar.BackTubeStartColor = System.Drawing.Color.LightGray
            Me.ProgressBar.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
            Me.ProgressBar.BorderColor = System.Drawing.Color.Black
            Me.ProgressBar.CustomWaitingRender = False
            Me.ProgressBar.Dock = CType(resources.GetObject("ProgressBar.Dock"), System.Windows.Forms.DockStyle)
            Me.ProgressBar.Enabled = CType(resources.GetObject("ProgressBar.Enabled"), Boolean)
            Me.ProgressBar.Font = CType(resources.GetObject("ProgressBar.Font"), System.Drawing.Font)
            Me.ProgressBar.FontColor = System.Drawing.Color.White
            Me.ProgressBar.ForegroundImage = Nothing
            Me.ProgressBar.ForeSegments = False
            Me.ProgressBar.GradientEndColor = System.Drawing.SystemColors.ActiveCaption
            Me.ProgressBar.GradientStartColor = System.Drawing.SystemColors.InactiveCaption
            Me.ProgressBar.ImeMode = CType(resources.GetObject("ProgressBar.ImeMode"), System.Windows.Forms.ImeMode)
            Me.ProgressBar.Location = CType(resources.GetObject("ProgressBar.Location"), System.Drawing.Point)
            Me.ProgressBar.MultipleColors = New System.Drawing.Color() {System.Drawing.Color.Empty}
            Me.ProgressBar.Name = "ProgressBar"
            Me.ProgressBar.ProgressFallbackStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Tube
            Me.ProgressBar.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Gradient
            Me.ProgressBar.RightToLeft = CType(resources.GetObject("ProgressBar.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.ProgressBar.SegmentWidth = 8
            Me.ProgressBar.Size = CType(resources.GetObject("ProgressBar.Size"), System.Drawing.Size)
            Me.ProgressBar.TabIndex = CType(resources.GetObject("ProgressBar.TabIndex"), Integer)
            Me.ProgressBar.Text = resources.GetString("ProgressBar.Text")
            Me.ProgressBar.TextVisible = False
            Me.ProgressBar.ThemesEnabled = True
            Me.ProgressBar.TubeEndColor = System.Drawing.Color.Black
            Me.ProgressBar.TubeStartColor = System.Drawing.Color.Red
            Me.ProgressBar.Visible = CType(resources.GetObject("ProgressBar.Visible"), Boolean)
            Me.ProgressBar.WaitingGradientWidth = 400
            '
            'TimeoutIndicator
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.Controls.Add(Me.ProgressBar)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.Name = "TimeoutIndicator"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
            CType(Me.ProgressBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        WithEvents mTimer As New System.Windows.Forms.Timer

        Private mStartMilliseconds As Long
        Private mTimeoutInterval As Integer
        Private mElapsed As Integer

        Public Property UpdateFrequency() As Integer
            Get
                Return mTimer.Interval
            End Get
            Set(ByVal value As Integer)
                mTimer.Interval = value
            End Set
        End Property

        Public Sub StartCountdown(ByVal milliseconds As Integer)

            ProgressBar.GradientStartColor = Drawing.SystemColors.InactiveCaption
            ProgressBar.GradientEndColor = Drawing.SystemColors.ActiveCaption

            mTimeoutInterval = milliseconds
            ProgressBar.Maximum = milliseconds
            ProgressBar.Minimum = 0
            ProgressBar.Value = milliseconds
            mStartMilliseconds = MillisecondsNow()
            mTimer.Start()
        End Sub

        Private mCriticalTime As Integer
        Public Property CriticalTime() As Integer
            Get
                Return mCriticalTime
            End Get
            Set(ByVal value As Integer)
                mCriticalTime = value
            End Set
        End Property

        Private mCriticalColor As Drawing.Color = Drawing.Color.Red
        Public Property CriticalColor() As Drawing.Color
            Get
                Return mCriticalColor
            End Get
            Set(ByVal value As Drawing.Color)
                mCriticalColor = value
            End Set
        End Property

        Public Sub StopCountdown()
            mTimer.Stop()
            SafeSetProgressBarAdvValue(ProgressBar, 0)
        End Sub

        Private Sub UpdateProgressBar()
            Dim now As Long = MillisecondsNow()
            mElapsed = CType(now - mStartMilliseconds, Integer)
            Dim newValue As Integer = Math.Max(mTimeoutInterval - mElapsed, 0)
            ProgressBar.Value = newValue

            If ProgressBar.Value < mCriticalTime OrElse Not mTimer.Enabled Then
                ProgressBar.GradientStartColor = CriticalColor
                ProgressBar.GradientEndColor = CriticalColor
            Else
                ProgressBar.GradientStartColor = Drawing.SystemColors.InactiveCaption
                ProgressBar.GradientEndColor = Drawing.SystemColors.ActiveCaption
            End If

            If ProgressBar.Value = 0 Then
                mTimer.Stop()
                RaiseEvent OutOfTimeEvent(Me, Nothing)
            End If
        End Sub

        Private Sub mTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles mTimer.Tick
            SafeInvokeNoArgSub(Me, AddressOf UpdateProgressBar)
        End Sub

        Private Shared Function MillisecondsNow() As Long
            Return CType(DateTime.Now.Ticks * 1.0 / TimeSpan.TicksPerMillisecond, Long)
        End Function

        Private Sub UserNew()
            ProgressBar.Value = ProgressBar.Minimum
        End Sub

        Public Event OutOfTimeEvent As EventHandler(Of EventArgs)

    End Class

End Namespace