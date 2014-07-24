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
Imports System.Windows.Forms

Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Class ResultPopup
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
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
        Friend WithEvents MainPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Friend WithEvents CaptionLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        Friend WithEvents MainLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        Private WithEvents FadeTimer As System.Windows.Forms.Timer
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ResultPopup))
            Me.MainPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.MainLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.CaptionLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.FadeTimer = New System.Windows.Forms.Timer(Me.components)
            CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MainPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'MainPanel
            '
            Me.MainPanel.AccessibleDescription = resources.GetString("MainPanel.AccessibleDescription")
            Me.MainPanel.AccessibleName = resources.GetString("MainPanel.AccessibleName")
            Me.MainPanel.Anchor = CType(resources.GetObject("MainPanel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.MainPanel.AutoScroll = CType(resources.GetObject("MainPanel.AutoScroll"), Boolean)
            Me.MainPanel.AutoScrollMargin = CType(resources.GetObject("MainPanel.AutoScrollMargin"), System.Drawing.Size)
            Me.MainPanel.AutoScrollMinSize = CType(resources.GetObject("MainPanel.AutoScrollMinSize"), System.Drawing.Size)
            Me.MainPanel.BackColor = System.Drawing.SystemColors.Control
            Me.MainPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.MainPanel.BackgroundImage = CType(resources.GetObject("MainPanel.BackgroundImage"), System.Drawing.Image)
            Me.MainPanel.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
            Me.MainPanel.BorderColor = System.Drawing.Color.Black
            Me.MainPanel.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None
            Me.MainPanel.Controls.Add(Me.MainLabel)
            Me.MainPanel.Controls.Add(Me.CaptionLabel)
            Me.MainPanel.Dock = CType(resources.GetObject("MainPanel.Dock"), System.Windows.Forms.DockStyle)
            Me.MainPanel.Enabled = CType(resources.GetObject("MainPanel.Enabled"), Boolean)
            Me.MainPanel.Font = CType(resources.GetObject("MainPanel.Font"), System.Drawing.Font)
            Me.MainPanel.ImeMode = CType(resources.GetObject("MainPanel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.MainPanel.Location = CType(resources.GetObject("MainPanel.Location"), System.Drawing.Point)
            Me.MainPanel.Name = "MainPanel"
            Me.MainPanel.RightToLeft = CType(resources.GetObject("MainPanel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.MainPanel.Size = CType(resources.GetObject("MainPanel.Size"), System.Drawing.Size)
            Me.MainPanel.TabIndex = CType(resources.GetObject("MainPanel.TabIndex"), Integer)
            Me.MainPanel.Text = resources.GetString("MainPanel.Text")
            Me.MainPanel.Visible = CType(resources.GetObject("MainPanel.Visible"), Boolean)
            '
            'MainLabel
            '
            Me.MainLabel.AccessibleDescription = resources.GetString("MainLabel.AccessibleDescription")
            Me.MainLabel.AccessibleName = resources.GetString("MainLabel.AccessibleName")
            Me.MainLabel.Anchor = CType(resources.GetObject("MainLabel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.MainLabel.AutoSize = CType(resources.GetObject("MainLabel.AutoSize"), Boolean)
            Me.MainLabel.BackColor = System.Drawing.SystemColors.Control
            Me.MainLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LightGreen)
            Me.MainLabel.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.MainLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
            Me.MainLabel.Dock = CType(resources.GetObject("MainLabel.Dock"), System.Windows.Forms.DockStyle)
            Me.MainLabel.Enabled = CType(resources.GetObject("MainLabel.Enabled"), Boolean)
            Me.MainLabel.Font = CType(resources.GetObject("MainLabel.Font"), System.Drawing.Font)
            Me.MainLabel.Image = CType(resources.GetObject("MainLabel.Image"), System.Drawing.Image)
            Me.MainLabel.ImageAlign = CType(resources.GetObject("MainLabel.ImageAlign"), System.Drawing.ContentAlignment)
            Me.MainLabel.ImageIndex = CType(resources.GetObject("MainLabel.ImageIndex"), Integer)
            Me.MainLabel.ImeMode = CType(resources.GetObject("MainLabel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.MainLabel.Location = CType(resources.GetObject("MainLabel.Location"), System.Drawing.Point)
            Me.MainLabel.Name = "MainLabel"
            Me.MainLabel.RightToLeft = CType(resources.GetObject("MainLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.MainLabel.Size = CType(resources.GetObject("MainLabel.Size"), System.Drawing.Size)
            Me.MainLabel.TabIndex = CType(resources.GetObject("MainLabel.TabIndex"), Integer)
            Me.MainLabel.Text = resources.GetString("MainLabel.Text")
            Me.MainLabel.TextAlign = CType(resources.GetObject("MainLabel.TextAlign"), System.Drawing.ContentAlignment)
            Me.MainLabel.Visible = CType(resources.GetObject("MainLabel.Visible"), Boolean)
            '
            'CaptionLabel
            '
            Me.CaptionLabel.AccessibleDescription = resources.GetString("CaptionLabel.AccessibleDescription")
            Me.CaptionLabel.AccessibleName = resources.GetString("CaptionLabel.AccessibleName")
            Me.CaptionLabel.Anchor = CType(resources.GetObject("CaptionLabel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.CaptionLabel.AutoSize = CType(resources.GetObject("CaptionLabel.AutoSize"), Boolean)
            Me.CaptionLabel.BackColor = System.Drawing.Color.LightGreen
            Me.CaptionLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo
            Me.CaptionLabel.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.CaptionLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
            Me.CaptionLabel.Dock = CType(resources.GetObject("CaptionLabel.Dock"), System.Windows.Forms.DockStyle)
            Me.CaptionLabel.Enabled = CType(resources.GetObject("CaptionLabel.Enabled"), Boolean)
            Me.CaptionLabel.Font = CType(resources.GetObject("CaptionLabel.Font"), System.Drawing.Font)
            Me.CaptionLabel.Image = CType(resources.GetObject("CaptionLabel.Image"), System.Drawing.Image)
            Me.CaptionLabel.ImageAlign = CType(resources.GetObject("CaptionLabel.ImageAlign"), System.Drawing.ContentAlignment)
            Me.CaptionLabel.ImageIndex = CType(resources.GetObject("CaptionLabel.ImageIndex"), Integer)
            Me.CaptionLabel.ImeMode = CType(resources.GetObject("CaptionLabel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.CaptionLabel.Location = CType(resources.GetObject("CaptionLabel.Location"), System.Drawing.Point)
            Me.CaptionLabel.Name = "CaptionLabel"
            Me.CaptionLabel.RightToLeft = CType(resources.GetObject("CaptionLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.CaptionLabel.Size = CType(resources.GetObject("CaptionLabel.Size"), System.Drawing.Size)
            Me.CaptionLabel.TabIndex = CType(resources.GetObject("CaptionLabel.TabIndex"), Integer)
            Me.CaptionLabel.Text = resources.GetString("CaptionLabel.Text")
            Me.CaptionLabel.TextAlign = CType(resources.GetObject("CaptionLabel.TextAlign"), System.Drawing.ContentAlignment)
            Me.CaptionLabel.Visible = CType(resources.GetObject("CaptionLabel.Visible"), Boolean)
            '
            'FadeTimer
            '
            '
            'ResultPopup
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.Controls.Add(Me.MainPanel)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "ResultPopup"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.ShowInTaskbar = False
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MainPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mUICulture As CultureInfo = CultureInfo.CurrentUICulture
        Public Property UICulture() As CultureInfo
            Get
                Return mUICulture
            End Get
            Set(ByVal Value As CultureInfo)
                mUICulture = Value
            End Set
        End Property

        Private mStyle As ResultPopupStyle
        Private Shared WithEvents smPopup As ResultPopup
        Public Property Style() As ResultPopupStyle
            Get
                Return mStyle
            End Get
            Set(ByVal value As ResultPopupStyle)
                mStyle = value
                Refresh()
            End Set
        End Property

        Private mMainLabelPointSize As Integer = 72
        Public Overrides Sub Refresh()
            MyBase.Refresh()

            Dim wingdingsFont As New Font(Mbark.UI.GlobalUISettings.StringConstants.WingdingsFontName, mMainLabelPointSize)
            Select Case mStyle
                Case ResultPopupStyle.Accept

                    MainLabel.Font = wingdingsFont
                    MainLabel.Text = Mbark.UI.GlobalUISettings.StringConstants.WingdingsCheck
                    MainLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.PaleGreen)
                    MainLabel.Refresh()
                    CaptionLabel.Text = Messages.Accepted(UICulture)
                    CaptionLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.LargeBold
                    CaptionLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.PaleGreen)
                    CaptionLabel.Refresh()

                Case ResultPopupStyle.Success

                    MainLabel.Font = wingdingsFont
                    MainLabel.Text = Mbark.UI.GlobalUISettings.StringConstants.WingdingsCheck
                    MainLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.PaleGreen)
                    MainLabel.Refresh()
                    CaptionLabel.Text = Messages.Success(UICulture)
                    CaptionLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.LargeBold
                    CaptionLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.PaleGreen)
                    CaptionLabel.Refresh()

                Case ResultPopupStyle.Failure

                    MainPanel.BackColor = Color.Pink
                    MainLabel.Font = wingdingsFont
                    MainLabel.Text = Mbark.UI.GlobalUISettings.StringConstants.WingdingsX
                    MainLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Pink)
                    MainLabel.Refresh()
                    CaptionLabel.Text = Messages.Failure(UICulture)
                    CaptionLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.LargeBold
                    CaptionLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Pink)
                    CaptionLabel.Refresh()


                Case ResultPopupStyle.Reject

                    MainPanel.BackColor = Color.Pink
                    MainLabel.Font = wingdingsFont
                    MainLabel.Text = Mbark.UI.GlobalUISettings.StringConstants.WingdingsThumbsDown
                    MainLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Pink)
                    MainLabel.Refresh()
                    CaptionLabel.Text = Messages.Rejected(UICulture)
                    CaptionLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.LargeBold
                    CaptionLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Pink)
                    CaptionLabel.Refresh()


                Case ResultPopupStyle.Timeout

                    MainPanel.BackColor = Color.Pink
                    MainLabel.Font = wingdingsFont
                    MainLabel.Text = Mbark.UI.GlobalUISettings.StringConstants.WingdingsClock
                    MainLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Pink)
                    MainLabel.Refresh()
                    CaptionLabel.Text = Messages.Timeout(UICulture)
                    CaptionLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.LargeBold
                    CaptionLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Pink)
                    CaptionLabel.Refresh()


            End Select
            wingdingsFont.Dispose()
        End Sub

        Private mFadeTime As Integer = 3000
        Public Property FadeTime() As Integer
            Get
                Return mFadeTime
            End Get
            Set(ByVal value As Integer)
                mFadeTime = value
            End Set
        End Property

        Private mFadeSteps As Integer = 100
        Public Property FadeSteps() As Integer
            Get
                Return mFadeSteps
            End Get
            Set(ByVal value As Integer)
                mFadeSteps = value
            End Set
        End Property

        Private mFadeStart As Long
        Private Sub Start()
            Me.Show()
            FadeTimer.Interval = CInt(mFadeTime * 1.0 / mFadeSteps)
            mFadeStart = DateTime.Now.Ticks
            FadeTimer.Start()
            Application.DoEvents()
        End Sub

        Public Overloads Shared Sub Show(ByVal parent As Form, ByVal style As ResultPopupStyle)

            If parent Is Nothing Then Throw New ArgumentNullException("parent")

            smPopup = New ResultPopup

            smPopup.StartPosition = FormStartPosition.Manual
            Dim x As Integer = CInt(parent.Location.X + (parent.ClientSize.Width - smPopup.Width) / 2)
            Dim y As Integer = CInt(parent.Location.Y + (parent.ClientSize.Height - smPopup.Height) / 2)
            smPopup.Location = New Point(x, y)
            smPopup.Style = style
            smPopup.Start()
        End Sub

        Public Sub Fade()

            Dim ticksElapsed As Long = DateTime.Now.Ticks - mFadeStart
            Dim msElapsed As Integer = CInt(ticksElapsed / TimeSpan.TicksPerMillisecond)
            Opacity = (mFadeTime - msElapsed) * 1.0! / mFadeTime * 1.0!
            Refresh()
            If Opacity <= 0 Then
                FadeTimer.Stop()
                Me.Close()
            End If
        End Sub

        Private Sub FadeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FadeTimer.Tick
            Fade()
        End Sub
    End Class

    Public Enum ResultPopupStyle
        Accept
        Reject
        Success
        Failure
        Timeout
    End Enum

End Namespace