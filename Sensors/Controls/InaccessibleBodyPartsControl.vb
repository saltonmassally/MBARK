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

Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports SF = Syncfusion.Windows.Forms.Tools

Imports Mbark.UI
Imports Mbark.SensorMessages
Imports Mbark.UI.GlobalUISettings


Namespace Mbark.Sensors

    Public Class InaccessibleBodyPartsControl
        Inherits RadioGroupBox
        Implements ISensorControlModeChangeConsumer

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            usernew()
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
        Friend WithEvents InstructionLabel As System.Windows.Forms.Label
        Friend WithEvents MainPanel As System.Windows.Forms.Panel
        Friend WithEvents MainGridLayout As Syncfusion.Windows.Forms.Tools.GridLayout
        Private WithEvents LeftHand As Mbark.Sensors.FingerPickerControl
        Private WithEvents RightHand As Mbark.Sensors.FingerPickerControl
        Private WithEvents Irises As Mbark.Sensors.IrisPickerControl
        Friend WithEvents DisabledLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InaccessibleBodyPartsControl))
            Me.MainPanel = New System.Windows.Forms.Panel
            Me.Irises = New Mbark.Sensors.IrisPickerControl
            Me.LeftHand = New Mbark.Sensors.FingerpickerControl
            Me.RightHand = New Mbark.Sensors.FingerpickerControl
            Me.MainGridLayout = New Syncfusion.Windows.Forms.Tools.GridLayout(Me.components)
            Me.InstructionLabel = New System.Windows.Forms.Label
            Me.DisabledLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.InnerPanel.SuspendLayout()
            Me.MainPanel.SuspendLayout()
            CType(Me.MainGridLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupRadioButton
            '
            Me.GroupRadioButton.Name = "GroupRadioButton"
            Me.GroupRadioButton.TabIndex = CType(resources.GetObject("GroupRadioButton.TabIndex"), Integer)
            '
            'InnerPanel
            '
            Me.InnerPanel.BackColor = System.Drawing.SystemColors.Control
            Me.InnerPanel.Controls.Add(Me.MainPanel)
            Me.InnerPanel.Controls.Add(Me.InstructionLabel)
            Me.InnerPanel.Name = "InnerPanel"
            Me.InnerPanel.Size = CType(resources.GetObject("InnerPanel.Size"), System.Drawing.Size)
            Me.InnerPanel.TabIndex = CType(resources.GetObject("InnerPanel.TabIndex"), Integer)
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
            Me.MainPanel.BackgroundImage = CType(resources.GetObject("MainPanel.BackgroundImage"), System.Drawing.Image)
            Me.MainPanel.Controls.Add(Me.Irises)
            Me.MainPanel.Controls.Add(Me.LeftHand)
            Me.MainPanel.Controls.Add(Me.RightHand)
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
            'Irises
            '
            Me.Irises.AccessibleDescription = resources.GetString("Irises.AccessibleDescription")
            Me.Irises.AccessibleName = resources.GetString("Irises.AccessibleName")
            Me.Irises.Anchor = CType(resources.GetObject("Irises.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Irises.AutoScroll = CType(resources.GetObject("Irises.AutoScroll"), Boolean)
            Me.Irises.AutoScrollMargin = CType(resources.GetObject("Irises.AutoScrollMargin"), System.Drawing.Size)
            Me.Irises.AutoScrollMinSize = CType(resources.GetObject("Irises.AutoScrollMinSize"), System.Drawing.Size)
            Me.Irises.BackColor = System.Drawing.SystemColors.Control
            Me.Irises.BackgroundImage = CType(resources.GetObject("Irises.BackgroundImage"), System.Drawing.Image)
            Me.Irises.Dock = CType(resources.GetObject("Irises.Dock"), System.Windows.Forms.DockStyle)
            Me.Irises.Enabled = CType(resources.GetObject("Irises.Enabled"), Boolean)
            Me.Irises.Font = CType(resources.GetObject("Irises.Font"), System.Drawing.Font)
            Me.Irises.ImeMode = CType(resources.GetObject("Irises.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Irises.LeftEyeOnly = False
            Me.Irises.Location = CType(resources.GetObject("Irises.Location"), System.Drawing.Point)
            Me.MainGridLayout.SetMinimumSize(Me.Irises, CType(resources.GetObject("Irises.MinimumSize"), System.Drawing.Size))
            Me.Irises.Name = "Irises"
            Me.MainGridLayout.SetParticipateInLayout(Me.Irises, CType(resources.GetObject("Irises.ParticipateInLayout"), Boolean))
            Me.MainGridLayout.SetPreferredSize(Me.Irises, CType(resources.GetObject("Irises.PreferredSize"), System.Drawing.Size))
            Me.Irises.RightEyeOnly = False
            Me.Irises.RightToLeft = CType(resources.GetObject("Irises.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Irises.Size = CType(resources.GetObject("Irises.Size"), System.Drawing.Size)
            Me.Irises.TabIndex = CType(resources.GetObject("Irises.TabIndex"), Integer)
            Me.Irises.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.Irises.Visible = CType(resources.GetObject("Irises.Visible"), Boolean)
            '
            'LeftHand
            '
            Me.LeftHand.AccessibleDescription = resources.GetString("LeftHand.AccessibleDescription")
            Me.LeftHand.AccessibleName = resources.GetString("LeftHand.AccessibleName")
            Me.LeftHand.Anchor = CType(resources.GetObject("LeftHand.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.LeftHand.AutoScroll = CType(resources.GetObject("LeftHand.AutoScroll"), Boolean)
            Me.LeftHand.AutoScrollMargin = CType(resources.GetObject("LeftHand.AutoScrollMargin"), System.Drawing.Size)
            Me.LeftHand.AutoScrollMinSize = CType(resources.GetObject("LeftHand.AutoScrollMinSize"), System.Drawing.Size)
            Me.LeftHand.BackColor = System.Drawing.SystemColors.Control
            Me.LeftHand.BackgroundImage = CType(resources.GetObject("LeftHand.BackgroundImage"), System.Drawing.Image)
            Me.LeftHand.CausesValidation = False
            Me.LeftHand.Dock = CType(resources.GetObject("LeftHand.Dock"), System.Windows.Forms.DockStyle)
            Me.LeftHand.DockPadding.Top = 11
            Me.LeftHand.Enabled = CType(resources.GetObject("LeftHand.Enabled"), Boolean)
            Me.LeftHand.Font = CType(resources.GetObject("LeftHand.Font"), System.Drawing.Font)
            Me.LeftHand.ImeMode = CType(resources.GetObject("LeftHand.ImeMode"), System.Windows.Forms.ImeMode)
            Me.LeftHand.IsLeft = True
            Me.LeftHand.Location = CType(resources.GetObject("LeftHand.Location"), System.Drawing.Point)
            Me.MainGridLayout.SetMinimumSize(Me.LeftHand, CType(resources.GetObject("LeftHand.MinimumSize"), System.Drawing.Size))
            Me.LeftHand.Name = "LeftHand"
            Me.MainGridLayout.SetParticipateInLayout(Me.LeftHand, CType(resources.GetObject("LeftHand.ParticipateInLayout"), Boolean))
            Me.MainGridLayout.SetPreferredSize(Me.LeftHand, CType(resources.GetObject("LeftHand.PreferredSize"), System.Drawing.Size))
            Me.LeftHand.RightToLeft = CType(resources.GetObject("LeftHand.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.LeftHand.Size = CType(resources.GetObject("LeftHand.Size"), System.Drawing.Size)
            Me.LeftHand.TabIndex = CType(resources.GetObject("LeftHand.TabIndex"), Integer)
            Me.LeftHand.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.LeftHand.Visible = CType(resources.GetObject("LeftHand.Visible"), Boolean)
            '
            'RightHand
            '
            Me.RightHand.AccessibleDescription = resources.GetString("RightHand.AccessibleDescription")
            Me.RightHand.AccessibleName = resources.GetString("RightHand.AccessibleName")
            Me.RightHand.Anchor = CType(resources.GetObject("RightHand.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.RightHand.AutoScroll = CType(resources.GetObject("RightHand.AutoScroll"), Boolean)
            Me.RightHand.AutoScrollMargin = CType(resources.GetObject("RightHand.AutoScrollMargin"), System.Drawing.Size)
            Me.RightHand.AutoScrollMinSize = CType(resources.GetObject("RightHand.AutoScrollMinSize"), System.Drawing.Size)
            Me.RightHand.BackColor = System.Drawing.SystemColors.Control
            Me.RightHand.BackgroundImage = CType(resources.GetObject("RightHand.BackgroundImage"), System.Drawing.Image)
            Me.RightHand.CausesValidation = False
            Me.RightHand.Dock = CType(resources.GetObject("RightHand.Dock"), System.Windows.Forms.DockStyle)
            Me.RightHand.DockPadding.Top = 11
            Me.RightHand.Enabled = CType(resources.GetObject("RightHand.Enabled"), Boolean)
            Me.RightHand.Font = CType(resources.GetObject("RightHand.Font"), System.Drawing.Font)
            Me.RightHand.ImeMode = CType(resources.GetObject("RightHand.ImeMode"), System.Windows.Forms.ImeMode)
            Me.RightHand.IsLeft = True
            Me.RightHand.Location = CType(resources.GetObject("RightHand.Location"), System.Drawing.Point)
            Me.MainGridLayout.SetMinimumSize(Me.RightHand, CType(resources.GetObject("RightHand.MinimumSize"), System.Drawing.Size))
            Me.RightHand.Name = "RightHand"
            Me.MainGridLayout.SetParticipateInLayout(Me.RightHand, CType(resources.GetObject("RightHand.ParticipateInLayout"), Boolean))
            Me.MainGridLayout.SetPreferredSize(Me.RightHand, CType(resources.GetObject("RightHand.PreferredSize"), System.Drawing.Size))
            Me.RightHand.RightToLeft = CType(resources.GetObject("RightHand.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.RightHand.Size = CType(resources.GetObject("RightHand.Size"), System.Drawing.Size)
            Me.RightHand.TabIndex = CType(resources.GetObject("RightHand.TabIndex"), Integer)
            Me.RightHand.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.RightHand.Visible = CType(resources.GetObject("RightHand.Visible"), Boolean)
            '
            'MainGridLayout
            '
            Me.MainGridLayout.Columns = 3
            Me.MainGridLayout.ContainerControl = Me.MainPanel
            Me.MainGridLayout.CustomLayoutBounds = CType(resources.GetObject("MainGridLayout.CustomLayoutBounds"), System.Drawing.Rectangle)
            Me.MainGridLayout.HGap = 16
            Me.MainGridLayout.Rows = 1
            '
            'InstructionLabel
            '
            Me.InstructionLabel.AccessibleDescription = resources.GetString("InstructionLabel.AccessibleDescription")
            Me.InstructionLabel.AccessibleName = resources.GetString("InstructionLabel.AccessibleName")
            Me.InstructionLabel.Anchor = CType(resources.GetObject("InstructionLabel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.InstructionLabel.AutoSize = CType(resources.GetObject("InstructionLabel.AutoSize"), Boolean)
            Me.InstructionLabel.BackColor = System.Drawing.SystemColors.Control
            Me.InstructionLabel.Dock = CType(resources.GetObject("InstructionLabel.Dock"), System.Windows.Forms.DockStyle)
            Me.InstructionLabel.Enabled = CType(resources.GetObject("InstructionLabel.Enabled"), Boolean)
            Me.InstructionLabel.Font = CType(resources.GetObject("InstructionLabel.Font"), System.Drawing.Font)
            Me.InstructionLabel.Image = CType(resources.GetObject("InstructionLabel.Image"), System.Drawing.Image)
            Me.InstructionLabel.ImageAlign = CType(resources.GetObject("InstructionLabel.ImageAlign"), System.Drawing.ContentAlignment)
            Me.InstructionLabel.ImageIndex = CType(resources.GetObject("InstructionLabel.ImageIndex"), Integer)
            Me.InstructionLabel.ImeMode = CType(resources.GetObject("InstructionLabel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.InstructionLabel.Location = CType(resources.GetObject("InstructionLabel.Location"), System.Drawing.Point)
            Me.InstructionLabel.Name = "InstructionLabel"
            Me.InstructionLabel.RightToLeft = CType(resources.GetObject("InstructionLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.InstructionLabel.Size = CType(resources.GetObject("InstructionLabel.Size"), System.Drawing.Size)
            Me.InstructionLabel.TabIndex = CType(resources.GetObject("InstructionLabel.TabIndex"), Integer)
            Me.InstructionLabel.Text = resources.GetString("InstructionLabel.Text")
            Me.InstructionLabel.TextAlign = CType(resources.GetObject("InstructionLabel.TextAlign"), System.Drawing.ContentAlignment)
            Me.InstructionLabel.Visible = CType(resources.GetObject("InstructionLabel.Visible"), Boolean)
            '
            'DisabledLabel
            '
            Me.DisabledLabel.AccessibleDescription = resources.GetString("DisabledLabel.AccessibleDescription")
            Me.DisabledLabel.AccessibleName = resources.GetString("DisabledLabel.AccessibleName")
            Me.DisabledLabel.Anchor = CType(resources.GetObject("DisabledLabel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.DisabledLabel.AutoSize = CType(resources.GetObject("DisabledLabel.AutoSize"), Boolean)
            Me.DisabledLabel.BackColor = System.Drawing.Color.Black
            Me.DisabledLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.BackwardDiagonal, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlLight)
            Me.DisabledLabel.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.DisabledLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
            Me.DisabledLabel.Dock = CType(resources.GetObject("DisabledLabel.Dock"), System.Windows.Forms.DockStyle)
            Me.DisabledLabel.Enabled = CType(resources.GetObject("DisabledLabel.Enabled"), Boolean)
            Me.DisabledLabel.Font = CType(resources.GetObject("DisabledLabel.Font"), System.Drawing.Font)
            Me.DisabledLabel.Image = CType(resources.GetObject("DisabledLabel.Image"), System.Drawing.Image)
            Me.DisabledLabel.ImageAlign = CType(resources.GetObject("DisabledLabel.ImageAlign"), System.Drawing.ContentAlignment)
            Me.DisabledLabel.ImageIndex = CType(resources.GetObject("DisabledLabel.ImageIndex"), Integer)
            Me.DisabledLabel.ImeMode = CType(resources.GetObject("DisabledLabel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.DisabledLabel.Location = CType(resources.GetObject("DisabledLabel.Location"), System.Drawing.Point)
            Me.DisabledLabel.Name = "DisabledLabel"
            Me.DisabledLabel.RightToLeft = CType(resources.GetObject("DisabledLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.DisabledLabel.Size = CType(resources.GetObject("DisabledLabel.Size"), System.Drawing.Size)
            Me.DisabledLabel.TabIndex = CType(resources.GetObject("DisabledLabel.TabIndex"), Integer)
            Me.DisabledLabel.Text = resources.GetString("DisabledLabel.Text")
            Me.DisabledLabel.TextAlign = CType(resources.GetObject("DisabledLabel.TextAlign"), System.Drawing.ContentAlignment)
            Me.DisabledLabel.Visible = CType(resources.GetObject("DisabledLabel.Visible"), Boolean)
            '
            'InaccessibleBodyPartsControl
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.Controls.Add(Me.DisabledLabel)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.Name = "InaccessibleBodyPartsControl"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
            Me.Controls.SetChildIndex(Me.DisabledLabel, 0)
            Me.InnerPanel.ResumeLayout(False)
            Me.MainPanel.ResumeLayout(False)
            CType(Me.MainGridLayout, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub UserNew()
            AddHandler GroupRadioButton.CheckedChanged, AddressOf HandleRadioButtonChecked
            RightHand.IsLeft = False

            mTabList.Clear()
            Irises.PopulateTabList(mTabList)
            LeftHand.PopulateTabList(mTabList)
            RightHand.PopulateTabList(mTabList)
        End Sub

        Private mBodyPartswire As BodyPartCollection
        Public Sub WireBodyPartsList(ByVal parts As BodyPartCollection)
            mBodyPartswire = parts
            LeftHand.WireBodyPartList(parts)
            RightHand.WireBodyPartList(parts)
            Irises.WireBodyPartList(parts)
        End Sub

        Public ReadOnly Property BodyPartsWire() As BodyPartCollection
            Get
                Return mBodyPartswire
            End Get

        End Property


        Private mWithLeftHand As Boolean
        Public Property WithLeftHand() As Boolean
            Get
                Return mWithLeftHand
            End Get
            Set(ByVal value As Boolean)
                mWithLeftHand = value
                Refresh()
            End Set
        End Property

        Private mWithRightHand As Boolean
        Public Property WithRightHand() As Boolean
            Get
                Return mWithRightHand
            End Get
            Set(ByVal value As Boolean)
                mWithRightHand = value
                Refresh()
            End Set
        End Property

        Private mWithIrises As Boolean
        Public Property WithIrises() As Boolean
            Get
                Return mWithIrises
            End Get
            Set(ByVal value As Boolean)
                mWithIrises = value
                Refresh()
            End Set
        End Property

        Public Sub BindFromWireToControls()
            LeftHand.BindFromWireToControl()
            RightHand.BindFromWireToControl()
            Irises.BindFromWireToControl()
        End Sub


        Private Const UndocumentedPaddingNeededToPreventWordWrapPadding As Integer = 8
        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics)
            MyBase.RefreshAutomaticLayout(graphics)


            InstructionLabel.Font = Defaults.Fonts.InstructionLabel
            DisabledLabel.Font = Defaults.Fonts.Small
            AutoHeight.Label(graphics, InstructionLabel)

            Dim columns As Integer

            ' Compute the minimum height & width
            mMinimumHeight = 0
            mMinimumWidth = 0

            RightHand.RefreshAutomaticLayout(graphics)
            LeftHand.RefreshAutomaticLayout(graphics)
            Irises.RefreshAutomaticLayout(graphics)


            Dim leftMinHeight, leftMinWidth As Integer
            If WithLeftHand Then
                leftMinHeight = LeftHand.MinimumHeight
                leftMinWidth = LeftHand.MinimumWidth
                columns += 1
            End If
            MainGridLayout.SetParticipateInLayout(LeftHand, WithLeftHand)
            LeftHand.Visible = WithLeftHand


            Dim rightMinHeight, rightMinWidth As Integer
            If WithRightHand Then
                rightMinHeight = RightHand.MinimumHeight
                rightMinWidth = RightHand.MinimumWidth
                columns += 1
            End If
            MainGridLayout.SetParticipateInLayout(RightHand, WithRightHand)
            RightHand.Visible = WithRightHand

            Dim irisesMinHeight, irisesMinWidth As Integer
            If WithIrises Then
                irisesMinHeight = Irises.MinimumHeight
                irisesMinWidth = Irises.MinimumWidth
                columns += 1
            End If
            MainGridLayout.SetParticipateInLayout(Irises, WithIrises)
            Irises.Visible = WithIrises


            Dim instructionLabelWidth As Integer = _
                StringWidthInPixels(graphics, InstructionLabel.Font, InstructionLabel.Text) + _
                UndocumentedPaddingConstants.PreventLabelWordWrap

            If MyBase.WithFancyHeader Then InnerPanel.DockPadding.Top = 2

            Dim maxPanelWidth As Integer = Math.Max(leftMinWidth, rightMinWidth)
            maxPanelWidth = Math.Max(maxPanelWidth, irisesMinWidth)

            mMinimumWidth = Math.Max(mMinimumWidth, MyBase.MinimumWidth)
            mMinimumWidth = Math.Max(mMinimumWidth, 3 * maxPanelWidth)
            mMinimumWidth = Math.Max(mMinimumWidth, instructionLabelWidth)
            mMinimumWidth += TotalLeftPadding + TotalRightPadding + MainGridLayout.HGap * columns

            MainGridLayout.Columns = columns

            mMinimumHeight = Math.Max(mMinimumHeight, leftMinHeight)
            mMinimumHeight = Math.Max(mMinimumHeight, rightMinHeight)
            mMinimumHeight = Math.Max(mMinimumHeight, irisesMinHeight)
            mMinimumHeight += TotalTopPadding + TotalBottomPadding + InstructionLabel.Height

            UI.AutoSize.Label(graphics, DisabledLabel)
            DisabledLabel.Width = CInt(DisabledLabel.Width * 1.2!)
            DisabledLabel.Height = CInt(DisabledLabel.Height * 1.0!)

            Dim disabledLabelX As Integer = CInt(Me.Width / 2.0! - DisabledLabel.Width / 2.0!)
            Dim disabledlabely As Integer = CInt(Me.Height / 2.0! - DisabledLabel.Height / 2.0!)
            DisabledLabel.Location = New Point(disabledLabelX, disabledlabely)

            RefreshPanels()




        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            If WithRadioButton Then
                LeftHand.Enabled = GroupRadioButton.Checked
                RightHand.Enabled = GroupRadioButton.Checked
                Irises.Enabled = GroupRadioButton.Checked
            End If
            LeftHand.Refresh()
            RightHand.Refresh()
            Irises.Refresh()
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Private Sub HandleRadioButtonChecked(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Refresh()
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return

            SubscribeToParentSensorControlModeChangeEvents(Me, True)

            ' If there's a control mode provider, then disable the controls; they'll be enabled when appropriate
            If SensorControlModeProvider Is Nothing Then
                LeftHand.Enabled = False
                RightHand.Enabled = False
                Irises.Enabled = False
            Else
                LeftHand.Enabled = True
                RightHand.Enabled = True
                Irises.Enabled = True
            End If

            DisabledLabel.Font = UI.GlobalUISettings.Defaults.Fonts.Small

            HeaderText = Messages.Injuries(UICulture)

            InstructionLabel.Text = Messages.XsIndicateInjuries(UICulture)

            RefreshAutomaticLayout(NearestForm.CreateGraphics)
            Refresh()
        End Sub

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Private mMinimumHeight As Integer
        Public Overrides ReadOnly Property MinimumHeight() As Integer
            Get
                Return mMinimumHeight
            End Get
        End Property

        Private mMinimumWidth As Integer
        Public Overrides ReadOnly Property MinimumWidth() As Integer
            Get
                Return mMinimumWidth
            End Get
        End Property

        Public Sub ReflectTask(ByVal task As SensorTask)
            If task Is Nothing Then Throw New ArgumentNullException("task")

            Dim parts As BodyPartCollection = BodyPartCollection.ForTask(task.TargetCategory)

            WithLeftHand = False
            WithRightHand = False
            WithIrises = False

            ' Iterate over all of the body parts, adding the appropriate parts as we go
            For i As Integer = 0 To parts.Count - 1
                If BodyPartCollection.OnLeftHand(parts(i)) Then WithLeftHand = True
                If BodyPartCollection.OnRightHand(parts(i)) Then WithRightHand = True
                If parts(i) = BodyPart.LeftIris Or parts(i) = BodyPart.RightIris Then WithIrises = True
            Next i

            If task.TargetCategory = SensorTaskCategory.LeftIris Then Irises.LeftEyeOnly = True
            If task.TargetCategory = SensorTaskCategory.RightIris Then Irises.RightEyeOnly = True

            LeftHand.ReflectTask(task.TargetCategory)
            RightHand.ReflectTask(task.TargetCategory)

        End Sub



        Public Sub HandleSensorControlModeChange(ByVal sender As Object, ByVal e As SensorControlModeChangeEventArgs) _
        Implements ISensorControlModeChangeConsumer.HandleSensorControlModeChange

            If e Is Nothing Then Throw New ArgumentNullException("e")
            RefreshPanels()

        End Sub

        Private mSensorControlModeProvider As ISensorControlModeProvider
        Public ReadOnly Property SensorControlModeProvider() As ISensorControlModeProvider _
        Implements ISensorControlModeChangeConsumer.SensorControlModeProvider
            Get
                If mSensorControlModeProvider Is Nothing Then
                    mSensorControlModeProvider = DirectCast(FindNearestSensorControlModeProviderParent(Me), ISensorControlModeProvider)
                End If
                Return mSensorControlModeProvider
            End Get
        End Property

        'reset all picker control when starting new session
        Public Sub ResetControl()
            RightHand.ResetFingerpickerControl()
            LeftHand.ResetFingerpickerControl()
            Irises.DeselectAllIrises()
        End Sub

        Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
            MyBase.OnEnabledChanged(e)
            RefreshPanels()
        End Sub


        Private Sub RefreshPanels()
            
            LeftHand.Enabled = MyBase.Enabled AndAlso mFingerPickerEnable
            RightHand.Enabled = MyBase.Enabled AndAlso mFingerPickerEnable
            Irises.Enabled = MyBase.Enabled AndAlso mIrisPickerEnable

            If DisabledLabel.Text = String.Empty Then
                DisabledLabel.Visible = False
            Else
                DisabledLabel.Visible = Not MyBase.Enabled
                DisabledLabel.Enabled = Not MyBase.Enabled
                DisabledLabel.Refresh()
            End If
        End Sub

        Public Property DisabledLabelText() As String
            Get
                Return DisabledLabel.Text
            End Get
            Set(ByVal value As String)
                If value <> DisabledLabel.Text Then
                    If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
                    DisabledLabel.Text = value
                End If
            End Set
        End Property

        Public Property DisabledLabelColor() As Color
            Get
                Return DisabledLabel.BackColor
            End Get
            Set(ByVal value As Color)
                DisabledLabel.BackColor = value
            End Set
        End Property

        Private mTabList As New Collection(Of Control)
        Public ReadOnly Property TabList() As Collection(Of Control)
            Get
                Return mTabList
            End Get
        End Property

        Private mIrisPickerEnable As Boolean = True
        Public Property IrisPickerEnable() As Boolean
            Get
                Return mIrisPickerEnable
            End Get
            Set(ByVal value As Boolean)
                mIrisPickerEnable = value
            End Set
        End Property

        Private mFingerPickerEnable As Boolean = True
        Public Property FingerPickerEnable() As Boolean
            Get
                Return mFingerPickerEnable
            End Get
            Set(ByVal value As Boolean)
                mFingerPickerEnable = value
            End Set
        End Property

   

    
    End Class

End Namespace