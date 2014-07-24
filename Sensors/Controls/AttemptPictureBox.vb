'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
'       Ross J. Micheals (rossm@nist.gov)
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

Imports Mbark.UI

Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections.ObjectModel

Imports Mbark.SensorMessages
Imports Mbark.UI.GlobalUISettings


Namespace Mbark.Sensors

    Public Class AttemptPictureBox
        Inherits UserControl
        Implements IAutosizable
        Implements IHasUICulture

        Private Const EditButtonIdentation As Integer = 4

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
        Friend WithEvents OuterPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Friend WithEvents SmoothPictureBox As Mbark.UI.SmoothPictureBox
        Friend WithEvents CaptionLabel As System.Windows.Forms.Label
        Friend WithEvents EditButton As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttemptPictureBox))
            Me.OuterPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.EditButton = New System.Windows.Forms.Button
            Me.SmoothPictureBox = New Mbark.UI.SmoothPictureBox
            Me.CaptionLabel = New System.Windows.Forms.Label
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.OuterPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'OuterPanel
            '
            Me.OuterPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.OuterPanel.BorderColor = System.Drawing.Color.Blue
            Me.OuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.OuterPanel.Controls.Add(Me.EditButton)
            Me.OuterPanel.Controls.Add(Me.SmoothPictureBox)
            Me.OuterPanel.Controls.Add(Me.CaptionLabel)
            resources.ApplyResources(Me.OuterPanel, "OuterPanel")
            Me.OuterPanel.Name = "OuterPanel"
            '
            'EditButton
            '
            resources.ApplyResources(Me.EditButton, "EditButton")
            Me.EditButton.Name = "EditButton"
            '
            'SmoothPictureBox
            '
            Me.SmoothPictureBox.Alignment = Mbark.UI.SmoothPictureBoxAlignment.Center
            Me.SmoothPictureBox.BackColor = System.Drawing.SystemColors.Control
            Me.SmoothPictureBox.Backwards = False
            Me.SmoothPictureBox.BorderColor = System.Drawing.Color.Black
            Me.SmoothPictureBox.BorderThickness = 1
            Me.SmoothPictureBox.DisabledImage = Nothing
            Me.SmoothPictureBox.EnabledImage = Nothing
            resources.ApplyResources(Me.SmoothPictureBox, "SmoothPictureBox")
            Me.SmoothPictureBox.Name = "SmoothPictureBox"
            Me.SmoothPictureBox.OverlayColor = System.Drawing.Color.Black
            Me.SmoothPictureBox.OverlayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SmoothPictureBox.OverlayText = Nothing
            Me.SmoothPictureBox.WithBorder = False
            '
            'CaptionLabel
            '
            resources.ApplyResources(Me.CaptionLabel, "CaptionLabel")
            Me.CaptionLabel.Name = "CaptionLabel"
            '
            'AttemptPictureBox
            '
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.Controls.Add(Me.OuterPanel)
            Me.Name = "AttemptPictureBox"
            resources.ApplyResources(Me, "$this")
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.OuterPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mUICulture As CultureInfo = CultureInfo.CurrentUICulture
        Public Property UICulture() As CultureInfo Implements IHasUICulture.UICulture
            Get
                Return mUICulture
            End Get
            Set(ByVal Value As CultureInfo)
                mUICulture = Value
            End Set
        End Property

        Private Sub UserNew()
            'SetStyle(Mbark.UI.DoubleBufferStyle, True)
            SmoothPictureBox.WithBorder = True
        End Sub

        Private mAttemptWire As SensorTaskAttempt
        Public Sub WireAttempt(ByVal attempt As SensorTaskAttempt)
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")
            mAttemptWire = attempt
            SmoothPictureBox.EnabledImage = New Bitmap(attempt.ThumbnailImage)
        End Sub

        Public Sub RefreshLabel(ByVal conditions As ConditionCollection, ByVal parts As BodyPartCollection)


            If mAttemptWire.InConflict(conditions, parts) Then

                CaptionLabel.Text = Messages.Conflict(UICulture) & vbNewLine
                CaptionLabel.Font = Defaults.Fonts.Bold

            ElseIf mAttemptWire.HadCaptureFailure Then

                CaptionLabel.Text = Messages.CaptureFailure(UICulture)
                CaptionLabel.Font = Defaults.Fonts.Regular

            ElseIf mAttemptWire.HasCorruptImage Then

                CaptionLabel.Text = Messages.Corrupt(UICulture)
                CaptionLabel.Font = Defaults.Fonts.Regular

            ElseIf mAttemptWire.HadDownloadFailure Then

                CaptionLabel.Text = Messages.DownloadFailure(UICulture)
                CaptionLabel.Font = Defaults.Fonts.Regular

            ElseIf mAttemptWire.IsRejected Then

                CaptionLabel.Text = Messages.Rejected(UICulture)
                CaptionLabel.Font = Defaults.Fonts.Regular

            ElseIf mAttemptWire.HasDownloadStage Then

                If mAttemptWire.DownloadSuccessful Then
                    CaptionLabel.Text = Messages.DownloadComplete(UICulture)
                ElseIf mAttemptWire.HadDownloadFailure Then
                    CaptionLabel.Text = Messages.DownloadFailed(UICulture)
                ElseIf mAttemptWire.NeedsDownload Then
                    CaptionLabel.Text = Messages.AwaitingDownload(UICulture)
                End If
                CaptionLabel.Font = Defaults.Fonts.Regular

            Else

                CaptionLabel.Text = Messages.Success(UICulture)
                CaptionLabel.Font = Defaults.Fonts.Regular

            End If

            CaptionLabel.Refresh()

        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            SmoothPictureBox.Refresh()

            If mAttemptWire Is Nothing Then Return

            RecursiveSuspendLayout(Me)
            ' Don't allow attempt of busy sensors to be edited
            Dim busy As Boolean
            If mAttemptWire.ParentTask.Sensor.LatestStatus = SensorStatus.Capturing OrElse _
                mAttemptWire.ParentTask.Sensor.LatestStatus = SensorStatus.Initializing OrElse _
                mAttemptWire.ParentTask.Sensor.LatestStatus = SensorStatus.Downloading Then
                busy = True
            End If
            EditButton.Visible = Not busy
            EditButton.Enabled = Not busy
            EditButton.Refresh()
            RecursiveResumeLayout(Me)

        End Sub


        Public Sub ClearPicture()
            SmoothPictureBox.EnabledImage = Nothing
        End Sub


        Public Property WithEditButton() As Boolean
            Get
                Return EditButton.Visible
            End Get
            Set(ByVal value As Boolean)
                EditButton.Visible = value
            End Set
        End Property

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
            RaiseEvent EditRequested(Me, New EditRequestedEventArgs(mAttemptWire))
        End Sub

        Public Event EditRequested As EventHandler(Of EditRequestedEventArgs)

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout

            If SmoothPictureBox.EnabledImage Is Nothing Then Return

            ' We compute the height of the caption, since the height of the SmoothPictureBox depends on it.
            ' Notice that we explicitly use the bold version of the font since this is a smidge taller, and
            ' should therefore not cause any visual misaligments should any of the labels be displayed in bold.
            ' We base the label font size on the bold version of the font since this is a smidge taller
            '
            Dim labelHeight As Integer = StringHeightInPixels(graphics, Defaults.Fonts.Bold, CaptionLabel.Text)


            ' Next, we place the SmoothPictureBox -- we leave room for the label underneath.
            '
            SmoothPictureBox.Location = New Point(0, 0)
            SmoothPictureBox.Width = Width - DockPadding.Left - DockPadding.Right
            SmoothPictureBox.Height = Height - DockPadding.Top - DockPadding.Bottom - labelHeight


            ' We place the caption label manually, because if we dock it underneath the SmoothPictureBox, then there
            ' could be large gap between the top of the label and the bottom of the image.
            '
            CaptionLabel.Width = SmoothPictureBox.Width
            CaptionLabel.Height = labelHeight
            CaptionLabel.Location = LowerLeft(SmoothPictureBox)
            CaptionLabel.BringToFront()


            ' Finally, add the edit button. We place it with a small indentation. We assume that this indent 
            ' is not large enough to throw off the mininum height and width computations.
            '
            EditButton.Font = Defaults.Fonts.Small
            UI.AutoSize.ToText(graphics, EditButton, 1.75, 1.2)
            Dim imageUpperRight As Point = SmoothPictureBox.RemapImagePoint(New Point(0, 0))
            EditButton.Location = New Point(imageUpperRight.X + EditButtonIdentation, imageUpperRight.Y + EditButtonIdentation)


            EditButton.BringToFront()
            EditButton.BackColor = Color.Transparent

            ' Ensure the label is accomodated or that the button doesn't extend past 1/3 of the width of the control
            Dim labelMinWidth As Integer = StringWidthInPixels(graphics, CaptionLabel) + UndocumentedPaddingConstants.PreventLabelWordWrap
            Dim buttonMinWidth As Integer = 3 * EditButton.Width + DockPadding.Left + DockPadding.Right
            mMinimumWidth = Math.Max(labelMinWidth, buttonMinWidth)

            ' Make that the button doesn't extend past 1/3 of the image
            mMinimumHeight = 3 * EditButton.Height + CaptionLabel.Height + DockPadding.Top + DockPadding.Bottom

            Refresh()

        End Sub

        Private mMinimumHeight As Integer
        Public ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get
                If SmoothPictureBox.EnabledImage Is Nothing Then mMinimumHeight = 0
                Return mMinimumHeight
            End Get
        End Property

        Private mMinimumWidth As Integer
        Public ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get
                If SmoothPictureBox.EnabledImage Is Nothing Then mMinimumWidth = 0
                Return mMinimumWidth
            End Get
        End Property

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property

        Public ReadOnly Property GetEditButton() As Control
            Get
                Return EditButton
            End Get
        End Property

        Private Sub CaptionLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
    End Class

    Public Class EditRequestedEventArgs
        Inherits EventArgs
        Private mAttempt As SensorTaskAttempt
        Public ReadOnly Property Attempt() As SensorTaskAttempt
            Get
                Return mAttempt
            End Get
        End Property
        Public Sub New(ByVal attempt As SensorTaskAttempt)
            mAttempt = attempt
        End Sub
    End Class

End Namespace