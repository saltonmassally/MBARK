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

Imports System.Globalization
Imports System.Windows.Forms

Imports Mbark
Imports Mbark.UI
Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Class OperatorReviewForm
        Inherits System.Windows.Forms.Form
        Implements IAutosizable
        Implements IHasUICulture

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            UserNew()
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
        Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
        Friend WithEvents FooterPanel As System.Windows.Forms.Panel
        Friend WithEvents MainPanel As System.Windows.Forms.Panel
        Friend WithEvents MainPictureBox As Mbark.UI.SmoothPictureBox
        Friend WithEvents FlowLayout1 As Syncfusion.Windows.Forms.Tools.FlowLayout
        Public WithEvents RejectImageButton As System.Windows.Forms.Button
        Public WithEvents AcceptImageButton As System.Windows.Forms.Button
        Friend WithEvents CorruptCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents HeaderRTFBox As Mbark.UI.AutosizableRichTextBox
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OperatorReviewForm))
            Me.HeaderPanel = New System.Windows.Forms.Panel
            Me.HeaderRTFBox = New Mbark.UI.AutosizableRichTextBox
            Me.FooterPanel = New System.Windows.Forms.Panel
            Me.CorruptCheckBox = New System.Windows.Forms.CheckBox
            Me.AcceptImageButton = New System.Windows.Forms.Button
            Me.RejectImageButton = New System.Windows.Forms.Button
            Me.MainPanel = New System.Windows.Forms.Panel
            Me.MainPictureBox = New Mbark.UI.SmoothPictureBox
            Me.FlowLayout1 = New Syncfusion.Windows.Forms.Tools.FlowLayout(Me.components)
            Me.HeaderPanel.SuspendLayout()
            Me.FooterPanel.SuspendLayout()
            Me.MainPanel.SuspendLayout()
            CType(Me.FlowLayout1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'HeaderPanel
            '
            Me.HeaderPanel.AccessibleDescription = resources.GetString("HeaderPanel.AccessibleDescription")
            Me.HeaderPanel.AccessibleName = resources.GetString("HeaderPanel.AccessibleName")
            Me.HeaderPanel.Anchor = CType(resources.GetObject("HeaderPanel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.HeaderPanel.AutoScroll = CType(resources.GetObject("HeaderPanel.AutoScroll"), Boolean)
            Me.HeaderPanel.AutoScrollMargin = CType(resources.GetObject("HeaderPanel.AutoScrollMargin"), System.Drawing.Size)
            Me.HeaderPanel.AutoScrollMinSize = CType(resources.GetObject("HeaderPanel.AutoScrollMinSize"), System.Drawing.Size)
            Me.HeaderPanel.BackgroundImage = CType(resources.GetObject("HeaderPanel.BackgroundImage"), System.Drawing.Image)
            Me.HeaderPanel.Controls.Add(Me.HeaderRTFBox)
            Me.HeaderPanel.Dock = CType(resources.GetObject("HeaderPanel.Dock"), System.Windows.Forms.DockStyle)
            Me.HeaderPanel.Enabled = CType(resources.GetObject("HeaderPanel.Enabled"), Boolean)
            Me.HeaderPanel.Font = CType(resources.GetObject("HeaderPanel.Font"), System.Drawing.Font)
            Me.HeaderPanel.ImeMode = CType(resources.GetObject("HeaderPanel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.HeaderPanel.Location = CType(resources.GetObject("HeaderPanel.Location"), System.Drawing.Point)
            Me.HeaderPanel.Name = "HeaderPanel"
            Me.HeaderPanel.RightToLeft = CType(resources.GetObject("HeaderPanel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.HeaderPanel.Size = CType(resources.GetObject("HeaderPanel.Size"), System.Drawing.Size)
            Me.HeaderPanel.TabIndex = CType(resources.GetObject("HeaderPanel.TabIndex"), Integer)
            Me.HeaderPanel.Text = resources.GetString("HeaderPanel.Text")
            Me.HeaderPanel.Visible = CType(resources.GetObject("HeaderPanel.Visible"), Boolean)
            '
            'HeaderRTFBox
            '
            Me.HeaderRTFBox.AccessibleDescription = resources.GetString("HeaderRTFBox.AccessibleDescription")
            Me.HeaderRTFBox.AccessibleName = resources.GetString("HeaderRTFBox.AccessibleName")
            Me.HeaderRTFBox.Anchor = CType(resources.GetObject("HeaderRTFBox.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.HeaderRTFBox.AutoScroll = CType(resources.GetObject("HeaderRTFBox.AutoScroll"), Boolean)
            Me.HeaderRTFBox.AutoScrollMargin = CType(resources.GetObject("HeaderRTFBox.AutoScrollMargin"), System.Drawing.Size)
            Me.HeaderRTFBox.AutoScrollMinSize = CType(resources.GetObject("HeaderRTFBox.AutoScrollMinSize"), System.Drawing.Size)
            Me.HeaderRTFBox.BackgroundImage = CType(resources.GetObject("HeaderRTFBox.BackgroundImage"), System.Drawing.Image)
            Me.HeaderRTFBox.Dock = CType(resources.GetObject("HeaderRTFBox.Dock"), System.Windows.Forms.DockStyle)
            Me.HeaderRTFBox.DockPadding.Left = 10
            Me.HeaderRTFBox.DockPadding.Top = 15
            Me.HeaderRTFBox.Enabled = CType(resources.GetObject("HeaderRTFBox.Enabled"), Boolean)
            Me.HeaderRTFBox.Font = CType(resources.GetObject("HeaderRTFBox.Font"), System.Drawing.Font)
            Me.HeaderRTFBox.ImeMode = CType(resources.GetObject("HeaderRTFBox.ImeMode"), System.Windows.Forms.ImeMode)
            Me.HeaderRTFBox.Location = CType(resources.GetObject("HeaderRTFBox.Location"), System.Drawing.Point)
            Me.HeaderRTFBox.MinimumHeightInChars = 1
            Me.HeaderRTFBox.MinimumWidthInChars = 0
            Me.HeaderRTFBox.Name = "HeaderRTFBox"
            Me.HeaderRTFBox.RightToLeft = CType(resources.GetObject("HeaderRTFBox.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.HeaderRTFBox.Size = CType(resources.GetObject("HeaderRTFBox.Size"), System.Drawing.Size)
            Me.HeaderRTFBox.TabIndex = CType(resources.GetObject("HeaderRTFBox.TabIndex"), Integer)
            Me.HeaderRTFBox.Visible = CType(resources.GetObject("HeaderRTFBox.Visible"), Boolean)
            '
            'FooterPanel
            '
            Me.FooterPanel.AccessibleDescription = resources.GetString("FooterPanel.AccessibleDescription")
            Me.FooterPanel.AccessibleName = resources.GetString("FooterPanel.AccessibleName")
            Me.FooterPanel.Anchor = CType(resources.GetObject("FooterPanel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.FooterPanel.AutoScroll = CType(resources.GetObject("FooterPanel.AutoScroll"), Boolean)
            Me.FooterPanel.AutoScrollMargin = CType(resources.GetObject("FooterPanel.AutoScrollMargin"), System.Drawing.Size)
            Me.FooterPanel.AutoScrollMinSize = CType(resources.GetObject("FooterPanel.AutoScrollMinSize"), System.Drawing.Size)
            Me.FooterPanel.BackgroundImage = CType(resources.GetObject("FooterPanel.BackgroundImage"), System.Drawing.Image)
            Me.FooterPanel.Controls.Add(Me.CorruptCheckBox)
            Me.FooterPanel.Controls.Add(Me.AcceptImageButton)
            Me.FooterPanel.Controls.Add(Me.RejectImageButton)
            Me.FooterPanel.Dock = CType(resources.GetObject("FooterPanel.Dock"), System.Windows.Forms.DockStyle)
            Me.FooterPanel.Enabled = CType(resources.GetObject("FooterPanel.Enabled"), Boolean)
            Me.FooterPanel.Font = CType(resources.GetObject("FooterPanel.Font"), System.Drawing.Font)
            Me.FooterPanel.ImeMode = CType(resources.GetObject("FooterPanel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.FooterPanel.Location = CType(resources.GetObject("FooterPanel.Location"), System.Drawing.Point)
            Me.FooterPanel.Name = "FooterPanel"
            Me.FooterPanel.RightToLeft = CType(resources.GetObject("FooterPanel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.FooterPanel.Size = CType(resources.GetObject("FooterPanel.Size"), System.Drawing.Size)
            Me.FooterPanel.TabIndex = CType(resources.GetObject("FooterPanel.TabIndex"), Integer)
            Me.FooterPanel.Text = resources.GetString("FooterPanel.Text")
            Me.FooterPanel.Visible = CType(resources.GetObject("FooterPanel.Visible"), Boolean)
            '
            'CorruptCheckBox
            '
            Me.CorruptCheckBox.AccessibleDescription = resources.GetString("CorruptCheckBox.AccessibleDescription")
            Me.CorruptCheckBox.AccessibleName = resources.GetString("CorruptCheckBox.AccessibleName")
            Me.CorruptCheckBox.Anchor = CType(resources.GetObject("CorruptCheckBox.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.CorruptCheckBox.Appearance = CType(resources.GetObject("CorruptCheckBox.Appearance"), System.Windows.Forms.Appearance)
            Me.CorruptCheckBox.BackgroundImage = CType(resources.GetObject("CorruptCheckBox.BackgroundImage"), System.Drawing.Image)
            Me.CorruptCheckBox.CheckAlign = CType(resources.GetObject("CorruptCheckBox.CheckAlign"), System.Drawing.ContentAlignment)
            Me.FlowLayout1.SetConstraints(Me.CorruptCheckBox, CType(resources.GetObject("CorruptCheckBox.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.CorruptCheckBox.Dock = CType(resources.GetObject("CorruptCheckBox.Dock"), System.Windows.Forms.DockStyle)
            Me.CorruptCheckBox.Enabled = CType(resources.GetObject("CorruptCheckBox.Enabled"), Boolean)
            Me.CorruptCheckBox.FlatStyle = CType(resources.GetObject("CorruptCheckBox.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.CorruptCheckBox.Font = CType(resources.GetObject("CorruptCheckBox.Font"), System.Drawing.Font)
            Me.CorruptCheckBox.Image = CType(resources.GetObject("CorruptCheckBox.Image"), System.Drawing.Image)
            Me.CorruptCheckBox.ImageAlign = CType(resources.GetObject("CorruptCheckBox.ImageAlign"), System.Drawing.ContentAlignment)
            Me.CorruptCheckBox.ImageIndex = CType(resources.GetObject("CorruptCheckBox.ImageIndex"), Integer)
            Me.CorruptCheckBox.ImeMode = CType(resources.GetObject("CorruptCheckBox.ImeMode"), System.Windows.Forms.ImeMode)
            Me.CorruptCheckBox.Location = CType(resources.GetObject("CorruptCheckBox.Location"), System.Drawing.Point)
            Me.FlowLayout1.SetMinimumSize(Me.CorruptCheckBox, CType(resources.GetObject("CorruptCheckBox.MinimumSize"), System.Drawing.Size))
            Me.CorruptCheckBox.Name = "CorruptCheckBox"
            Me.FlowLayout1.SetPreferredSize(Me.CorruptCheckBox, CType(resources.GetObject("CorruptCheckBox.PreferredSize"), System.Drawing.Size))
            Me.CorruptCheckBox.RightToLeft = CType(resources.GetObject("CorruptCheckBox.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.CorruptCheckBox.Size = CType(resources.GetObject("CorruptCheckBox.Size"), System.Drawing.Size)
            Me.CorruptCheckBox.TabIndex = CType(resources.GetObject("CorruptCheckBox.TabIndex"), Integer)
            Me.CorruptCheckBox.Text = resources.GetString("CorruptCheckBox.Text")
            Me.CorruptCheckBox.TextAlign = CType(resources.GetObject("CorruptCheckBox.TextAlign"), System.Drawing.ContentAlignment)
            Me.CorruptCheckBox.Visible = CType(resources.GetObject("CorruptCheckBox.Visible"), Boolean)
            '
            'AcceptImageButton
            '
            Me.AcceptImageButton.AccessibleDescription = resources.GetString("AcceptImageButton.AccessibleDescription")
            Me.AcceptImageButton.AccessibleName = resources.GetString("AcceptImageButton.AccessibleName")
            Me.AcceptImageButton.Anchor = CType(resources.GetObject("AcceptImageButton.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.AcceptImageButton.BackgroundImage = CType(resources.GetObject("AcceptImageButton.BackgroundImage"), System.Drawing.Image)
            Me.FlowLayout1.SetConstraints(Me.AcceptImageButton, CType(resources.GetObject("AcceptImageButton.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.AcceptImageButton.Dock = CType(resources.GetObject("AcceptImageButton.Dock"), System.Windows.Forms.DockStyle)
            Me.AcceptImageButton.Enabled = CType(resources.GetObject("AcceptImageButton.Enabled"), Boolean)
            Me.AcceptImageButton.FlatStyle = CType(resources.GetObject("AcceptImageButton.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.AcceptImageButton.Font = CType(resources.GetObject("AcceptImageButton.Font"), System.Drawing.Font)
            Me.AcceptImageButton.Image = CType(resources.GetObject("AcceptImageButton.Image"), System.Drawing.Image)
            Me.AcceptImageButton.ImageAlign = CType(resources.GetObject("AcceptImageButton.ImageAlign"), System.Drawing.ContentAlignment)
            Me.AcceptImageButton.ImageIndex = CType(resources.GetObject("AcceptImageButton.ImageIndex"), Integer)
            Me.AcceptImageButton.ImeMode = CType(resources.GetObject("AcceptImageButton.ImeMode"), System.Windows.Forms.ImeMode)
            Me.AcceptImageButton.Location = CType(resources.GetObject("AcceptImageButton.Location"), System.Drawing.Point)
            Me.FlowLayout1.SetMinimumSize(Me.AcceptImageButton, CType(resources.GetObject("AcceptImageButton.MinimumSize"), System.Drawing.Size))
            Me.AcceptImageButton.Name = "AcceptImageButton"
            Me.FlowLayout1.SetPreferredSize(Me.AcceptImageButton, CType(resources.GetObject("AcceptImageButton.PreferredSize"), System.Drawing.Size))
            Me.AcceptImageButton.RightToLeft = CType(resources.GetObject("AcceptImageButton.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.AcceptImageButton.Size = CType(resources.GetObject("AcceptImageButton.Size"), System.Drawing.Size)
            Me.AcceptImageButton.TabIndex = CType(resources.GetObject("AcceptImageButton.TabIndex"), Integer)
            Me.AcceptImageButton.Text = resources.GetString("AcceptImageButton.Text")
            Me.AcceptImageButton.TextAlign = CType(resources.GetObject("AcceptImageButton.TextAlign"), System.Drawing.ContentAlignment)
            Me.AcceptImageButton.Visible = CType(resources.GetObject("AcceptImageButton.Visible"), Boolean)
            '
            'RejectImageButton
            '
            Me.RejectImageButton.AccessibleDescription = resources.GetString("RejectImageButton.AccessibleDescription")
            Me.RejectImageButton.AccessibleName = resources.GetString("RejectImageButton.AccessibleName")
            Me.RejectImageButton.Anchor = CType(resources.GetObject("RejectImageButton.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.RejectImageButton.BackgroundImage = CType(resources.GetObject("RejectImageButton.BackgroundImage"), System.Drawing.Image)
            Me.FlowLayout1.SetConstraints(Me.RejectImageButton, CType(resources.GetObject("RejectImageButton.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.RejectImageButton.Dock = CType(resources.GetObject("RejectImageButton.Dock"), System.Windows.Forms.DockStyle)
            Me.RejectImageButton.Enabled = CType(resources.GetObject("RejectImageButton.Enabled"), Boolean)
            Me.RejectImageButton.FlatStyle = CType(resources.GetObject("RejectImageButton.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.RejectImageButton.Font = CType(resources.GetObject("RejectImageButton.Font"), System.Drawing.Font)
            Me.RejectImageButton.Image = CType(resources.GetObject("RejectImageButton.Image"), System.Drawing.Image)
            Me.RejectImageButton.ImageAlign = CType(resources.GetObject("RejectImageButton.ImageAlign"), System.Drawing.ContentAlignment)
            Me.RejectImageButton.ImageIndex = CType(resources.GetObject("RejectImageButton.ImageIndex"), Integer)
            Me.RejectImageButton.ImeMode = CType(resources.GetObject("RejectImageButton.ImeMode"), System.Windows.Forms.ImeMode)
            Me.RejectImageButton.Location = CType(resources.GetObject("RejectImageButton.Location"), System.Drawing.Point)
            Me.FlowLayout1.SetMinimumSize(Me.RejectImageButton, CType(resources.GetObject("RejectImageButton.MinimumSize"), System.Drawing.Size))
            Me.RejectImageButton.Name = "RejectImageButton"
            Me.FlowLayout1.SetPreferredSize(Me.RejectImageButton, CType(resources.GetObject("RejectImageButton.PreferredSize"), System.Drawing.Size))
            Me.RejectImageButton.RightToLeft = CType(resources.GetObject("RejectImageButton.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.RejectImageButton.Size = CType(resources.GetObject("RejectImageButton.Size"), System.Drawing.Size)
            Me.RejectImageButton.TabIndex = CType(resources.GetObject("RejectImageButton.TabIndex"), Integer)
            Me.RejectImageButton.Text = resources.GetString("RejectImageButton.Text")
            Me.RejectImageButton.TextAlign = CType(resources.GetObject("RejectImageButton.TextAlign"), System.Drawing.ContentAlignment)
            Me.RejectImageButton.Visible = CType(resources.GetObject("RejectImageButton.Visible"), Boolean)
            '
            'MainPanel
            '
            Me.MainPanel.AccessibleDescription = resources.GetString("MainPanel.AccessibleDescription")
            Me.MainPanel.AccessibleName = resources.GetString("MainPanel.AccessibleName")
            Me.MainPanel.Anchor = CType(resources.GetObject("MainPanel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.MainPanel.AutoScroll = CType(resources.GetObject("MainPanel.AutoScroll"), Boolean)
            Me.MainPanel.AutoScrollMargin = CType(resources.GetObject("MainPanel.AutoScrollMargin"), System.Drawing.Size)
            Me.MainPanel.AutoScrollMinSize = CType(resources.GetObject("MainPanel.AutoScrollMinSize"), System.Drawing.Size)
            Me.MainPanel.BackgroundImage = CType(resources.GetObject("MainPanel.BackgroundImage"), System.Drawing.Image)
            Me.MainPanel.Controls.Add(Me.MainPictureBox)
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
            'FlowLayout1
            '
            Me.FlowLayout1.Alignment = CType(resources.GetObject("FlowLayout1.Alignment"), Syncfusion.Windows.Forms.Tools.FlowAlignment)
            Me.FlowLayout1.BottomMargin = 4
            Me.FlowLayout1.ContainerControl = Me.FooterPanel
            Me.FlowLayout1.CustomLayoutBounds = CType(resources.GetObject("FlowLayout1.CustomLayoutBounds"), System.Drawing.Rectangle)
            Me.FlowLayout1.HGap = CType(resources.GetObject("FlowLayout1.HGap"), Integer)
            Me.FlowLayout1.HorzFarMargin = 4
            Me.FlowLayout1.LayoutMode = CType(resources.GetObject("FlowLayout1.LayoutMode"), Syncfusion.Windows.Forms.Tools.FlowLayoutMode)
            Me.FlowLayout1.ReverseRows = CType(resources.GetObject("FlowLayout1.ReverseRows"), Boolean)
            Me.FlowLayout1.VGap = CType(resources.GetObject("FlowLayout1.VGap"), Integer)
            '
            'OperatorReviewForm
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
            Me.Controls.Add(Me.FooterPanel)
            Me.Controls.Add(Me.HeaderPanel)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "OperatorReviewForm"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            Me.HeaderPanel.ResumeLayout(False)
            Me.FooterPanel.ResumeLayout(False)
            Me.MainPanel.ResumeLayout(False)
            CType(Me.FlowLayout1, System.ComponentModel.ISupportInitialize).EndInit()
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
            AddHandler AcceptImageButton.Click, AddressOf Me.AcceptImageButton_Click
            AddHandler RejectImageButton.Click, AddressOf Me.RejectImageButton_Click
        End Sub

        Private mCorrupt As Boolean
        Public ReadOnly Property Corrupt() As Boolean
            Get
                Return mCorrupt
            End Get
        End Property

        Private mRejected As Boolean = True
        Public Property Rejected() As Boolean
            Get
                Return mRejected
            End Get
            Set(ByVal value As Boolean)
                mRejected = value
            End Set
        End Property

        Private Sub AcceptImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            mRejected = False
            Close()
        End Sub

        Private Sub RejectImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            mRejected = True
            If mImageJustMarkedAsCorrupt AndAlso UninitializeSensorsOfCorruptImages Then
                mCurrentTask.Sensor.Uninitialize()
            End If
            Close()
        End Sub

        Private Sub OperatorReviewForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            RefreshAutomaticLayout(NearestForm.CreateGraphics)
            HeaderRTFBox.Text = Rtf.ToRtf(SensorMessages.Messages.PleaseAcceptRejectThisDataRtf(UICulture))
        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout
            FooterPanel.SuspendLayout()
            CorruptCheckBox.Width = Me.FooterPanel.Width - GlobalUISettings.UndocumentedPaddingConstants.PreventFlowLayoutWrap
            FooterPanel.ResumeLayout()
        End Sub

        Public ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get

            End Get
        End Property

        Public ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get

            End Get
        End Property

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return Me
            End Get
        End Property

        Private Sub RefreshButtons()
            If CorruptCheckBox.CheckState = CheckState.Checked Then
                AcceptImageButton.Enabled = False
            Else
                AcceptImageButton.Enabled = True
            End If
        End Sub

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            RefreshAutomaticLayout(CreateGraphics)
        End Sub

        Private Sub CorruptCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorruptCheckBox.CheckedChanged
            RefreshButtons()
            If CorruptCheckBox.CheckState = CheckState.Checked Then
                mImageJustMarkedAsCorrupt = True
            Else
                mImageJustMarkedAsCorrupt = False
            End If
            mCorrupt = CorruptCheckBox.CheckState = CheckState.Checked
        End Sub

        Private mImageJustMarkedAsCorrupt As Boolean
        Private mUninitializeSensorsOfCorruptImages As Boolean
        Public Property UninitializeSensorsOfCorruptImages() As Boolean
            Get
                Return mUninitializeSensorsOfCorruptImages
            End Get
            Set(ByVal value As Boolean)
                mUninitializeSensorsOfCorruptImages = value
            End Set
        End Property

        Private mCurrentTask As SensorTask
        Public Property CurrentTask() As SensorTask
            Get
                Return mCurrentTask
            End Get
            Set(ByVal value As SensorTask)
                mCurrentTask = value
            End Set
        End Property

    End Class

End Namespace
