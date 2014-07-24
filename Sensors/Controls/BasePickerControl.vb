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

Imports SF = Syncfusion.Windows.Forms.Tools

Imports Mbark.UI

Namespace Mbark.Sensors

    Public Class BasePickerControl
        Inherits System.Windows.Forms.UserControl
        Implements IAutosizable
        Implements IHasUICulture

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
        Friend WithEvents FooterLabel As System.Windows.Forms.Label
        Friend WithEvents MainPictureBox As Mbark.UI.SmoothPictureBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BasePickerControl))
            Me.FooterLabel = New System.Windows.Forms.Label
            Me.MainPictureBox = New Mbark.UI.SmoothPictureBox
            Me.SuspendLayout()
            '
            'FooterLabel
            '
            Me.FooterLabel.AccessibleDescription = resources.GetString("FooterLabel.AccessibleDescription")
            Me.FooterLabel.AccessibleName = resources.GetString("FooterLabel.AccessibleName")
            Me.FooterLabel.Anchor = CType(resources.GetObject("FooterLabel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.FooterLabel.AutoSize = CType(resources.GetObject("FooterLabel.AutoSize"), Boolean)
            Me.FooterLabel.Dock = CType(resources.GetObject("FooterLabel.Dock"), System.Windows.Forms.DockStyle)
            Me.FooterLabel.Enabled = CType(resources.GetObject("FooterLabel.Enabled"), Boolean)
            Me.FooterLabel.Font = CType(resources.GetObject("FooterLabel.Font"), System.Drawing.Font)
            Me.FooterLabel.Image = CType(resources.GetObject("FooterLabel.Image"), System.Drawing.Image)
            Me.FooterLabel.ImageAlign = CType(resources.GetObject("FooterLabel.ImageAlign"), System.Drawing.ContentAlignment)
            Me.FooterLabel.ImageIndex = CType(resources.GetObject("FooterLabel.ImageIndex"), Integer)
            Me.FooterLabel.ImeMode = CType(resources.GetObject("FooterLabel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.FooterLabel.Location = CType(resources.GetObject("FooterLabel.Location"), System.Drawing.Point)
            Me.FooterLabel.Name = "FooterLabel"
            Me.FooterLabel.RightToLeft = CType(resources.GetObject("FooterLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.FooterLabel.Size = CType(resources.GetObject("FooterLabel.Size"), System.Drawing.Size)
            Me.FooterLabel.TabIndex = CType(resources.GetObject("FooterLabel.TabIndex"), Integer)
            Me.FooterLabel.Text = resources.GetString("FooterLabel.Text")
            Me.FooterLabel.TextAlign = CType(resources.GetObject("FooterLabel.TextAlign"), System.Drawing.ContentAlignment)
            Me.FooterLabel.Visible = CType(resources.GetObject("FooterLabel.Visible"), Boolean)
            '
            'MainPictureBox
            '
            Me.MainPictureBox.AccessibleDescription = resources.GetString("MainPictureBox.AccessibleDescription")
            Me.MainPictureBox.AccessibleName = resources.GetString("MainPictureBox.AccessibleName")
            Me.MainPictureBox.Alignment = Mbark.UI.SmoothPictureBoxAlignment.Center
            Me.MainPictureBox.Anchor = CType(resources.GetObject("MainPictureBox.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.MainPictureBox.AutoScroll = CType(resources.GetObject("MainPictureBox.AutoScroll"), Boolean)
            Me.MainPictureBox.AutoScrollMargin = CType(resources.GetObject("MainPictureBox.AutoScrollMargin"), System.Drawing.Size)
            Me.MainPictureBox.AutoScrollMinSize = CType(resources.GetObject("MainPictureBox.AutoScrollMinSize"), System.Drawing.Size)
            Me.MainPictureBox.BackgroundImage = CType(resources.GetObject("MainPictureBox.BackgroundImage"), System.Drawing.Image)
            Me.MainPictureBox.Backwards = False
            Me.MainPictureBox.BorderColor = System.Drawing.Color.Black
            Me.MainPictureBox.BorderThickness = 1
            Me.MainPictureBox.DisabledImage = Nothing
            Me.MainPictureBox.Dock = CType(resources.GetObject("MainPictureBox.Dock"), System.Windows.Forms.DockStyle)
            Me.MainPictureBox.Enabled = CType(resources.GetObject("MainPictureBox.Enabled"), Boolean)
            Me.MainPictureBox.EnabledImage = Nothing
            Me.MainPictureBox.Font = CType(resources.GetObject("MainPictureBox.Font"), System.Drawing.Font)
            Me.MainPictureBox.ImeMode = CType(resources.GetObject("MainPictureBox.ImeMode"), System.Windows.Forms.ImeMode)
            Me.MainPictureBox.Location = CType(resources.GetObject("MainPictureBox.Location"), System.Drawing.Point)
            Me.MainPictureBox.Name = "MainPictureBox"
            Me.MainPictureBox.OverlayColor = System.Drawing.Color.Black
            Me.MainPictureBox.OverlayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MainPictureBox.OverlayText = Nothing
            Me.MainPictureBox.RightToLeft = CType(resources.GetObject("MainPictureBox.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.MainPictureBox.Size = CType(resources.GetObject("MainPictureBox.Size"), System.Drawing.Size)
            Me.MainPictureBox.TabIndex = CType(resources.GetObject("MainPictureBox.TabIndex"), Integer)
            Me.MainPictureBox.Visible = CType(resources.GetObject("MainPictureBox.Visible"), Boolean)
            Me.MainPictureBox.WithBorder = False
            '
            'BasePickerControl
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.Controls.Add(Me.MainPictureBox)
            Me.Controls.Add(Me.FooterLabel)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.Name = "BasePickerControl"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mUICulture As CultureInfo = CultureInfo.CurrentUICulture
        Public Property UICulture() As CultureInfo Implements IHasUICulture.UICulture
            Get
                Return mUICulture
            End Get
            Set(ByVal Value As CultureInfo)
                mUICulture = value
            End Set
        End Property

        Private mEnabledImage As Bitmap
        Private mDisabledImage As Bitmap

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return

            MainPictureBox.EnabledImage = mEnabledImage
            MainPictureBox.DisabledImage = mDisabledImage
            MainPictureBox.Refresh()

            LayoutCheckBoxes()
            BindFromWireToControl()


        End Sub

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
            LayoutCheckBoxes()
        End Sub

        Protected Sub PopulatePartImages(ByVal enabledImage As Bitmap, ByVal disabledImage As Bitmap)
            mEnabledImage = enabledImage
            mDisabledImage = disabledImage
        End Sub

        Protected Friend Overridable Sub BindFromWireToControl()
            Throw New Mbark.MissingSpecializationException("BindFromWireToControl")
        End Sub

        Protected Overridable Sub LayoutCheckBoxes()
            If Not InDesignMode(Me) Then Throw New Mbark.MissingSpecializationException("LayoutCheckBoxes")
        End Sub

        Protected Overridable Sub RefreshCheckBoxes()
            If Not InDesignMode(Me) Then Throw New Mbark.MissingSpecializationException("RefreshCheckBoxes")
        End Sub

        Private mBodyPartsWire As BodyPartCollection ' Contains a list of parts that are *SELECTED*
        Public Sub WireBodyPartList(ByVal parts As BodyPartCollection)
            mBodyPartsWire = parts
            BindFromWireToControl()
        End Sub
        Protected ReadOnly Property BodyPartsWire() As BodyPartCollection
            Get
                Return mBodyPartsWire
            End Get
        End Property

        Public Overridable Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout
            SuspendLayout()

            FooterLabel.Font = Mbark.UI.GlobalUISettings.Defaults.Fonts.SmallBold

            MainPictureBox.Refresh()
            RefreshCheckBoxes()
            Mbark.UI.AutoHeight.Label(graphics, FooterLabel)

            mMinimumHeight = ComputeMinimumHeight()
            mMinimumWidth = ComputeMinimumWidth()

            ResumeLayout()
        End Sub

        Protected Overridable Function ComputeMinimumHeight() As Integer
            Dim minimumPictureHeight As Integer
            If MainPictureBox.ImageAspectRatio > 0 Then
                minimumPictureHeight = CInt(MinimumWidth / MainPictureBox.ImageAspectRatio + FooterLabel.Height)
            End If

            Dim verticalDockPadding As Integer = DockPadding.Top + DockPadding.Bottom

            Return minimumPictureHeight + FooterLabel.Height + verticalDockPadding

        End Function

        Private Const MinimumImageWidthPerFontSize As Integer = 8
        Protected Overridable Function ComputeMinimumWidth() As Integer

            Dim horizontalPadding As Integer = DockPadding.Left + DockPadding.Right

            Dim minimumPictureWidth As Integer = CInt(GlobalUISettings.Defaults.Fonts.Size * MinimumImageWidthPerFontSize) + horizontalPadding
            Dim minimumLabelWidth As Integer = StringWidthInPixels(NearestForm.CreateGraphics, FooterLabel) + horizontalPadding

            Return Math.Max(minimumPictureWidth, minimumLabelWidth)

        End Function



        Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
            MyBase.OnEnabledChanged(e)
            MainPictureBox.Enabled = MyBase.Enabled
            MainPictureBox.Refresh()
        End Sub


        Private mMinimumHeight As Integer

        Public Overridable ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get
                Return mMinimumHeight
            End Get
        End Property

        Private mMinimumWidth As Integer
        Public Overridable ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get
                Return mMinimumWidth
            End Get
        End Property

        Private Const MinimumImageWidthMultiplier As Integer = 10

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property

    End Class

End Namespace