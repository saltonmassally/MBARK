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

Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Drawing
Imports System.Windows.Forms

Imports Mbark
Imports Mbark.UI
Imports Mbark.UI.GlobalUISettings
Imports Mbark.SensorMessages


Namespace Mbark.Sensors

    Public Class AttemptEditor
        Inherits BaseForm
        Implements IAutosizable
        Implements IHasUICulture

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
        Friend WithEvents FooterPanel As System.Windows.Forms.Panel
        Friend WithEvents ButtonFlowLayout As Syncfusion.Windows.Forms.Tools.FlowLayout
        Friend WithEvents OKButton As System.Windows.Forms.Button
        Friend WithEvents CancelationButton As System.Windows.Forms.Button
        Friend WithEvents EditorPanels As Mbark.Sensors.TaskOrAttemptEditor
        Friend WithEvents ConflictControl As Mbark.Sensors.ConflictControl
        Friend WithEvents LinkCurrentAndCaptured As System.Windows.Forms.CheckBox
        Friend WithEvents HeaderGroup As Mbark.UI.AutosizableDropDownGroup
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AttemptEditor))
            Me.FooterPanel = New System.Windows.Forms.Panel
            Me.LinkCurrentAndCaptured = New System.Windows.Forms.CheckBox
            Me.OKButton = New System.Windows.Forms.Button
            Me.CancelationButton = New System.Windows.Forms.Button
            Me.ButtonFlowLayout = New Syncfusion.Windows.Forms.Tools.FlowLayout(Me.components)
            Me.ConflictControl = New Mbark.Sensors.ConflictControl
            Me.EditorPanels = New Mbark.Sensors.TaskOrAttemptEditor
            Me.HeaderGroup = New Mbark.UI.AutosizableDropDownGroup
            Me.FooterPanel.SuspendLayout()
            CType(Me.ButtonFlowLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            Me.FooterPanel.Controls.Add(Me.LinkCurrentAndCaptured)
            Me.FooterPanel.Controls.Add(Me.OKButton)
            Me.FooterPanel.Controls.Add(Me.CancelationButton)
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
            'LinkCurrentAndCaptured
            '
            Me.LinkCurrentAndCaptured.AccessibleDescription = resources.GetString("LinkCurrentAndCaptured.AccessibleDescription")
            Me.LinkCurrentAndCaptured.AccessibleName = resources.GetString("LinkCurrentAndCaptured.AccessibleName")
            Me.LinkCurrentAndCaptured.Anchor = CType(resources.GetObject("LinkCurrentAndCaptured.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.LinkCurrentAndCaptured.Appearance = CType(resources.GetObject("LinkCurrentAndCaptured.Appearance"), System.Windows.Forms.Appearance)
            Me.LinkCurrentAndCaptured.BackgroundImage = CType(resources.GetObject("LinkCurrentAndCaptured.BackgroundImage"), System.Drawing.Image)
            Me.LinkCurrentAndCaptured.CheckAlign = CType(resources.GetObject("LinkCurrentAndCaptured.CheckAlign"), System.Drawing.ContentAlignment)
            Me.ButtonFlowLayout.SetConstraints(Me.LinkCurrentAndCaptured, CType(resources.GetObject("LinkCurrentAndCaptured.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.LinkCurrentAndCaptured.Dock = CType(resources.GetObject("LinkCurrentAndCaptured.Dock"), System.Windows.Forms.DockStyle)
            Me.LinkCurrentAndCaptured.Enabled = CType(resources.GetObject("LinkCurrentAndCaptured.Enabled"), Boolean)
            Me.LinkCurrentAndCaptured.FlatStyle = CType(resources.GetObject("LinkCurrentAndCaptured.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.LinkCurrentAndCaptured.Font = CType(resources.GetObject("LinkCurrentAndCaptured.Font"), System.Drawing.Font)
            Me.LinkCurrentAndCaptured.Image = CType(resources.GetObject("LinkCurrentAndCaptured.Image"), System.Drawing.Image)
            Me.LinkCurrentAndCaptured.ImageAlign = CType(resources.GetObject("LinkCurrentAndCaptured.ImageAlign"), System.Drawing.ContentAlignment)
            Me.LinkCurrentAndCaptured.ImageIndex = CType(resources.GetObject("LinkCurrentAndCaptured.ImageIndex"), Integer)
            Me.LinkCurrentAndCaptured.ImeMode = CType(resources.GetObject("LinkCurrentAndCaptured.ImeMode"), System.Windows.Forms.ImeMode)
            Me.LinkCurrentAndCaptured.Location = CType(resources.GetObject("LinkCurrentAndCaptured.Location"), System.Drawing.Point)
            Me.ButtonFlowLayout.SetMinimumSize(Me.LinkCurrentAndCaptured, CType(resources.GetObject("LinkCurrentAndCaptured.MinimumSize"), System.Drawing.Size))
            Me.LinkCurrentAndCaptured.Name = "LinkCurrentAndCaptured"
            Me.ButtonFlowLayout.SetPreferredSize(Me.LinkCurrentAndCaptured, CType(resources.GetObject("LinkCurrentAndCaptured.PreferredSize"), System.Drawing.Size))
            Me.LinkCurrentAndCaptured.RightToLeft = CType(resources.GetObject("LinkCurrentAndCaptured.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.LinkCurrentAndCaptured.Size = CType(resources.GetObject("LinkCurrentAndCaptured.Size"), System.Drawing.Size)
            Me.LinkCurrentAndCaptured.TabIndex = CType(resources.GetObject("LinkCurrentAndCaptured.TabIndex"), Integer)
            Me.LinkCurrentAndCaptured.Text = resources.GetString("LinkCurrentAndCaptured.Text")
            Me.LinkCurrentAndCaptured.TextAlign = CType(resources.GetObject("LinkCurrentAndCaptured.TextAlign"), System.Drawing.ContentAlignment)
            Me.LinkCurrentAndCaptured.Visible = CType(resources.GetObject("LinkCurrentAndCaptured.Visible"), Boolean)
            '
            'OKButton
            '
            Me.OKButton.AccessibleDescription = resources.GetString("OKButton.AccessibleDescription")
            Me.OKButton.AccessibleName = resources.GetString("OKButton.AccessibleName")
            Me.OKButton.Anchor = CType(resources.GetObject("OKButton.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OKButton.BackgroundImage = CType(resources.GetObject("OKButton.BackgroundImage"), System.Drawing.Image)
            Me.ButtonFlowLayout.SetConstraints(Me.OKButton, CType(resources.GetObject("OKButton.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.OKButton.Dock = CType(resources.GetObject("OKButton.Dock"), System.Windows.Forms.DockStyle)
            Me.OKButton.Enabled = CType(resources.GetObject("OKButton.Enabled"), Boolean)
            Me.OKButton.FlatStyle = CType(resources.GetObject("OKButton.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.OKButton.Font = CType(resources.GetObject("OKButton.Font"), System.Drawing.Font)
            Me.OKButton.Image = CType(resources.GetObject("OKButton.Image"), System.Drawing.Image)
            Me.OKButton.ImageAlign = CType(resources.GetObject("OKButton.ImageAlign"), System.Drawing.ContentAlignment)
            Me.OKButton.ImageIndex = CType(resources.GetObject("OKButton.ImageIndex"), Integer)
            Me.OKButton.ImeMode = CType(resources.GetObject("OKButton.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OKButton.Location = CType(resources.GetObject("OKButton.Location"), System.Drawing.Point)
            Me.ButtonFlowLayout.SetMinimumSize(Me.OKButton, CType(resources.GetObject("OKButton.MinimumSize"), System.Drawing.Size))
            Me.OKButton.Name = "OKButton"
            Me.ButtonFlowLayout.SetPreferredSize(Me.OKButton, CType(resources.GetObject("OKButton.PreferredSize"), System.Drawing.Size))
            Me.OKButton.RightToLeft = CType(resources.GetObject("OKButton.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OKButton.Size = CType(resources.GetObject("OKButton.Size"), System.Drawing.Size)
            Me.OKButton.TabIndex = CType(resources.GetObject("OKButton.TabIndex"), Integer)
            Me.OKButton.Text = resources.GetString("OKButton.Text")
            Me.OKButton.TextAlign = CType(resources.GetObject("OKButton.TextAlign"), System.Drawing.ContentAlignment)
            Me.OKButton.Visible = CType(resources.GetObject("OKButton.Visible"), Boolean)
            '
            'CancelationButton
            '
            Me.CancelationButton.AccessibleDescription = resources.GetString("CancelationButton.AccessibleDescription")
            Me.CancelationButton.AccessibleName = resources.GetString("CancelationButton.AccessibleName")
            Me.CancelationButton.Anchor = CType(resources.GetObject("CancelationButton.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.CancelationButton.BackgroundImage = CType(resources.GetObject("CancelationButton.BackgroundImage"), System.Drawing.Image)
            Me.ButtonFlowLayout.SetConstraints(Me.CancelationButton, CType(resources.GetObject("CancelationButton.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.CancelationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.CancelationButton.Dock = CType(resources.GetObject("CancelationButton.Dock"), System.Windows.Forms.DockStyle)
            Me.CancelationButton.Enabled = CType(resources.GetObject("CancelationButton.Enabled"), Boolean)
            Me.CancelationButton.FlatStyle = CType(resources.GetObject("CancelationButton.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.CancelationButton.Font = CType(resources.GetObject("CancelationButton.Font"), System.Drawing.Font)
            Me.CancelationButton.Image = CType(resources.GetObject("CancelationButton.Image"), System.Drawing.Image)
            Me.CancelationButton.ImageAlign = CType(resources.GetObject("CancelationButton.ImageAlign"), System.Drawing.ContentAlignment)
            Me.CancelationButton.ImageIndex = CType(resources.GetObject("CancelationButton.ImageIndex"), Integer)
            Me.CancelationButton.ImeMode = CType(resources.GetObject("CancelationButton.ImeMode"), System.Windows.Forms.ImeMode)
            Me.CancelationButton.Location = CType(resources.GetObject("CancelationButton.Location"), System.Drawing.Point)
            Me.ButtonFlowLayout.SetMinimumSize(Me.CancelationButton, CType(resources.GetObject("CancelationButton.MinimumSize"), System.Drawing.Size))
            Me.CancelationButton.Name = "CancelationButton"
            Me.ButtonFlowLayout.SetPreferredSize(Me.CancelationButton, CType(resources.GetObject("CancelationButton.PreferredSize"), System.Drawing.Size))
            Me.CancelationButton.RightToLeft = CType(resources.GetObject("CancelationButton.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.CancelationButton.Size = CType(resources.GetObject("CancelationButton.Size"), System.Drawing.Size)
            Me.CancelationButton.TabIndex = CType(resources.GetObject("CancelationButton.TabIndex"), Integer)
            Me.CancelationButton.Text = resources.GetString("CancelationButton.Text")
            Me.CancelationButton.TextAlign = CType(resources.GetObject("CancelationButton.TextAlign"), System.Drawing.ContentAlignment)
            Me.CancelationButton.Visible = CType(resources.GetObject("CancelationButton.Visible"), Boolean)
            '
            'ButtonFlowLayout
            '
            Me.ButtonFlowLayout.Alignment = CType(resources.GetObject("ButtonFlowLayout.Alignment"), Syncfusion.Windows.Forms.Tools.FlowAlignment)
            Me.ButtonFlowLayout.ContainerControl = Me.FooterPanel
            Me.ButtonFlowLayout.CustomLayoutBounds = CType(resources.GetObject("ButtonFlowLayout.CustomLayoutBounds"), System.Drawing.Rectangle)
            Me.ButtonFlowLayout.HGap = CType(resources.GetObject("ButtonFlowLayout.HGap"), Integer)
            Me.ButtonFlowLayout.HorzFarMargin = 5
            Me.ButtonFlowLayout.LayoutMode = CType(resources.GetObject("ButtonFlowLayout.LayoutMode"), Syncfusion.Windows.Forms.Tools.FlowLayoutMode)
            Me.ButtonFlowLayout.ReverseRows = CType(resources.GetObject("ButtonFlowLayout.ReverseRows"), Boolean)
            Me.ButtonFlowLayout.VGap = CType(resources.GetObject("ButtonFlowLayout.VGap"), Integer)
            '
            'ConflictControl
            '
            Me.ConflictControl.AccessibleDescription = resources.GetString("ConflictControl.AccessibleDescription")
            Me.ConflictControl.AccessibleName = resources.GetString("ConflictControl.AccessibleName")
            Me.ConflictControl.Anchor = CType(resources.GetObject("ConflictControl.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.ConflictControl.AutoScroll = CType(resources.GetObject("ConflictControl.AutoScroll"), Boolean)
            Me.ConflictControl.AutoScrollMargin = CType(resources.GetObject("ConflictControl.AutoScrollMargin"), System.Drawing.Size)
            Me.ConflictControl.AutoScrollMinSize = CType(resources.GetObject("ConflictControl.AutoScrollMinSize"), System.Drawing.Size)
            Me.ConflictControl.BackgroundImage = CType(resources.GetObject("ConflictControl.BackgroundImage"), System.Drawing.Image)
            Me.ConflictControl.Dock = CType(resources.GetObject("ConflictControl.Dock"), System.Windows.Forms.DockStyle)
            Me.ConflictControl.DockPadding.All = 4
            Me.ConflictControl.Enabled = CType(resources.GetObject("ConflictControl.Enabled"), Boolean)
            Me.ConflictControl.Font = CType(resources.GetObject("ConflictControl.Font"), System.Drawing.Font)
            Me.ConflictControl.HeaderText = "Conflict"
            Me.ConflictControl.HeaderTextColor = System.Drawing.Color.Empty
            Me.ConflictControl.ImeMode = CType(resources.GetObject("ConflictControl.ImeMode"), System.Windows.Forms.ImeMode)
            Me.ConflictControl.Location = CType(resources.GetObject("ConflictControl.Location"), System.Drawing.Point)
            Me.ConflictControl.Name = "ConflictControl"
            Me.ConflictControl.RadioButtonIndentation = 8
            Me.ConflictControl.RadioButtonSelected = False
            Me.ConflictControl.RadioGroupBoxChecked = False
            Me.ConflictControl.RightToLeft = CType(resources.GetObject("ConflictControl.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.ConflictControl.Size = CType(resources.GetObject("ConflictControl.Size"), System.Drawing.Size)
            Me.ConflictControl.TabIndex = CType(resources.GetObject("ConflictControl.TabIndex"), Integer)
            Me.ConflictControl.Visible = CType(resources.GetObject("ConflictControl.Visible"), Boolean)
            Me.ConflictControl.WithFancyHeader = False
            Me.ConflictControl.WithRadioButton = False
            '
            'EditorPanels
            '
            Me.EditorPanels.AccessibleDescription = resources.GetString("EditorPanels.AccessibleDescription")
            Me.EditorPanels.AccessibleName = resources.GetString("EditorPanels.AccessibleName")
            Me.EditorPanels.Anchor = CType(resources.GetObject("EditorPanels.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.EditorPanels.AutoScroll = CType(resources.GetObject("EditorPanels.AutoScroll"), Boolean)
            Me.EditorPanels.AutoScrollMargin = CType(resources.GetObject("EditorPanels.AutoScrollMargin"), System.Drawing.Size)
            Me.EditorPanels.AutoScrollMinSize = CType(resources.GetObject("EditorPanels.AutoScrollMinSize"), System.Drawing.Size)
            Me.EditorPanels.BackgroundImage = CType(resources.GetObject("EditorPanels.BackgroundImage"), System.Drawing.Image)
            Me.EditorPanels.BorderPadding = 4
            Me.EditorPanels.Dock = CType(resources.GetObject("EditorPanels.Dock"), System.Windows.Forms.DockStyle)
            Me.EditorPanels.Enabled = CType(resources.GetObject("EditorPanels.Enabled"), Boolean)
            Me.EditorPanels.Font = CType(resources.GetObject("EditorPanels.Font"), System.Drawing.Font)
            Me.EditorPanels.ImeMode = CType(resources.GetObject("EditorPanels.ImeMode"), System.Windows.Forms.ImeMode)
            Me.EditorPanels.Location = CType(resources.GetObject("EditorPanels.Location"), System.Drawing.Point)
            Me.EditorPanels.Name = "EditorPanels"
            Me.EditorPanels.RightToLeft = CType(resources.GetObject("EditorPanels.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.EditorPanels.Size = CType(resources.GetObject("EditorPanels.Size"), System.Drawing.Size)
            Me.EditorPanels.StackBodyPartPanels = True
            Me.EditorPanels.StackConditionPanels = True
            Me.EditorPanels.TabIndex = CType(resources.GetObject("EditorPanels.TabIndex"), Integer)
            Me.EditorPanels.Visible = CType(resources.GetObject("EditorPanels.Visible"), Boolean)
            Me.EditorPanels.WithCancellationReasons = False
            Me.EditorPanels.WithCapturedConditions = False
            Me.EditorPanels.WithCapturedInaccessibleParts = False
            Me.EditorPanels.WithCaptureResult = False
            Me.EditorPanels.WithCurrentConditions = False
            Me.EditorPanels.WithCurrentInaccessibleBodyParts = False
            '
            'HeaderGroup
            '
            Me.HeaderGroup.AccessibleDescription = resources.GetString("HeaderGroup.AccessibleDescription")
            Me.HeaderGroup.AccessibleName = resources.GetString("HeaderGroup.AccessibleName")
            Me.HeaderGroup.Anchor = CType(resources.GetObject("HeaderGroup.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.HeaderGroup.AutoScroll = CType(resources.GetObject("HeaderGroup.AutoScroll"), Boolean)
            Me.HeaderGroup.AutoScrollMargin = CType(resources.GetObject("HeaderGroup.AutoScrollMargin"), System.Drawing.Size)
            Me.HeaderGroup.AutoScrollMinSize = CType(resources.GetObject("HeaderGroup.AutoScrollMinSize"), System.Drawing.Size)
            Me.HeaderGroup.BackColor = System.Drawing.SystemColors.Control
            Me.HeaderGroup.BackgroundImage = CType(resources.GetObject("HeaderGroup.BackgroundImage"), System.Drawing.Image)
            Me.HeaderGroup.Dock = CType(resources.GetObject("HeaderGroup.Dock"), System.Windows.Forms.DockStyle)
            Me.HeaderGroup.Enabled = CType(resources.GetObject("HeaderGroup.Enabled"), Boolean)
            Me.HeaderGroup.Font = CType(resources.GetObject("HeaderGroup.Font"), System.Drawing.Font)
            Me.HeaderGroup.HeaderEnabled = False
            Me.HeaderGroup.HeaderText = Nothing
            Me.HeaderGroup.ImeMode = CType(resources.GetObject("HeaderGroup.ImeMode"), System.Windows.Forms.ImeMode)
            Me.HeaderGroup.Location = CType(resources.GetObject("HeaderGroup.Location"), System.Drawing.Point)
            Me.HeaderGroup.LowerPanelVisible = True
            Me.HeaderGroup.Name = "HeaderGroup"
            Me.HeaderGroup.RightToLeft = CType(resources.GetObject("HeaderGroup.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.HeaderGroup.Size = CType(resources.GetObject("HeaderGroup.Size"), System.Drawing.Size)
            Me.HeaderGroup.TabIndex = CType(resources.GetObject("HeaderGroup.TabIndex"), Integer)
            Me.HeaderGroup.Visible = CType(resources.GetObject("HeaderGroup.Visible"), Boolean)
            '
            'AttemptEditor
            '
            Me.AcceptButton = Me.OKButton
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.CancelButton = Me.CancelationButton
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.Controls.Add(Me.EditorPanels)
            Me.Controls.Add(Me.FooterPanel)
            Me.Controls.Add(Me.ConflictControl)
            Me.Controls.Add(Me.HeaderGroup)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "AttemptEditor"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            Me.FooterPanel.ResumeLayout(False)
            CType(Me.ButtonFlowLayout, System.ComponentModel.ISupportInitialize).EndInit()
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


        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return

            HeaderGroup.DockPadding.All = 5

            Dim headerTop As New AutosizableRichTextBox
            Dim headerTopString As String = Rtf.ToRtfBold( _
                Messages.EditAttempt(UICulture) & ": " & mAttemptWire.ParentTask.FriendlyToString(UICulture), _
                Defaults.Fonts.Large.Size)
            headerTop.Text = headerTopString
            headerTop.MinimumWidthInChars = Messages.EditAttempt(UICulture).Length
            headerTop.MinimumHeightInChars = 2
            Dim headerTopLayout As New AutosizableDropDownLayoutArgs(headerTop)
            With headerTopLayout
                .FillWeightX = 1
                .CellSpanX = 1
            End With
            HeaderGroup.LayoutControl(headerTopLayout)

            Dim headerInstruction As New AutosizableRichTextBox
            Dim headerInstructionString As String = _
                Rtf.ToRtfBold(Messages.AnticipatedSpecialConditionsDuringCapture(UICulture)) & _
                InfrastructureMessages.Messages.ColonSpace(UICulture) & _
                mAttemptWire.ParentTask.Conditions.FriendlyToString(UICulture) & Rtf.Newline & _
                Rtf.ToRtfBold(Messages.AnticipatedInjuriesDuringCapture(UICulture)) & _
                InfrastructureMessages.Messages.ColonSpace(UICulture) & _
                mAttemptWire.ParentTask.TargetInaccessibleParts.ToString(UICulture)
            headerInstruction.Text = Rtf.ToRtf(headerInstructionString)
            headerInstruction.MinimumHeightInChars = 3
            headerInstruction.MinimumWidthInChars = 64
            Dim headerInstructionLayout As New AutosizableDropDownLayoutArgs(headerInstruction)
            With headerInstructionLayout
                .FillWeightX = 1
                .GridPosX = 0
                .GridPosY = 1
                .CellSpanX = 1
            End With
            HeaderGroup.LayoutControl(headerInstructionLayout)

            RefreshConflict()
            RefreshButtons()
            RefreshPanels()

            AddHandler EditorPanels.CaptureResultControl.WrongTaskCheckBoxCheckedChanged, AddressOf RefreshButtonsAndPanels
            AddHandler EditorPanels.CaptureResultControl.WrongTaskComboBoxAdvSelectedIndexChanged, AddressOf RefreshButtonsAndPanels

            Me.Text = SensorMessages.Messages.AttemptEditor(UICulture)

            LinkCurrentAndCaptured.Font = UI.GlobalUISettings.Defaults.Fonts.Regular


        End Sub

        Private mAttemptWire As SensorTaskAttempt
        Private mOriginalAttempt As SensorTaskAttempt

        Private mOriginalCurrentConditions As ConditionCollection
        Private mCurrentConditionsWire As ConditionCollection
        Private mOriginalCapturedConditions As ConditionCollection

        Private mOriginalCurrentInaccessibleBodyParts As BodyPartCollection
        Private mCurrentInaccessibleBodyPartsWire As BodyPartCollection
        Private mOriginalCapturedInaccessibleBodyParts As BodyPartCollection

        Public ReadOnly Property OriginalCurrentConditions() As ConditionCollection
            Get
                Return mOriginalCurrentConditions
            End Get
        End Property
        Public ReadOnly Property OriginalCapturedConditions() As ConditionCollection
            Get
                Return mOriginalCapturedConditions
            End Get
        End Property
        Public ReadOnly Property OriginalCurrentInaccessibleBodyParts() As BodyPartCollection
            Get
                Return mOriginalCurrentInaccessibleBodyParts
            End Get
        End Property
        Public ReadOnly Property OriginalCapturedInaccessibleBodyParts() As BodyPartCollection
            Get
                Return mOriginalCapturedInaccessibleBodyParts
            End Get
        End Property

        Private mConflict As New SensorTaskAttemptConflict
        Private mInConflict As Boolean

        Private Sub RefreshConflict()
            mConflict.Clear()
            mInConflict = mAttemptWire.InConflict(mCurrentConditionsWire, mCurrentInaccessibleBodyPartsWire, mConflict, UICulture)
            ConflictControl.RefreshConflict()
        End Sub

        Public ReadOnly Property InConflict() As Boolean
            Get
                Return mInConflict
            End Get
        End Property

        Public ReadOnly Property Attempt() As SensorTaskAttempt
            Get
                Return mAttemptWire
            End Get
        End Property

        Public ReadOnly Property OriginalAttempt() As SensorTaskAttempt
            Get
                Return mOriginalAttempt
            End Get
        End Property
        Public ReadOnly Property HasWrongTask() As Boolean
            Get
                Return EditorPanels.CaptureResultControl.WrongTaskCheckBox.Checked
            End Get
        End Property

        Private mOriginalInConflict As Boolean
        Private mOriginalIgnoreConflict As Boolean
        Private mOriginalInaccessibleBodyParts As BodyPartCollection
        Public Sub WireAttempt(ByVal attempt As SensorTaskAttempt)
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")

            ' BaseSensorController does a deep copy before calling this
            Dim category As SensorTaskCategory = attempt.ParentTask.TargetCategory
            With EditorPanels
                If category = SensorTaskCategory.LeftSlap OrElse category = SensorTaskCategory.ThumbsSlap Then
                    .CapturedInaccessibleBodyPartsControl.WithLeftHand = True
                    .CurrentInaccessibleBodyPartsControl.WithLeftHand = True
                End If
                If category = SensorTaskCategory.RightSlap OrElse category = SensorTaskCategory.ThumbsSlap Then
                    .CapturedInaccessibleBodyPartsControl.WithRightHand = True
                    .CurrentInaccessibleBodyPartsControl.WithRightHand = True
                End If
                If category = SensorTaskCategory.BothIrises OrElse category = SensorTaskCategory.LeftIris OrElse category = SensorTaskCategory.RightIris Then
                    .CapturedInaccessibleBodyPartsControl.WithIrises = True
                    .CurrentInaccessibleBodyPartsControl.WithIrises = True
                End If
            End With


            mAttemptWire = attempt
            mOriginalAttempt = attempt.DeepCopyEditables
            mOriginalInConflict = attempt.InConflict(CurrentConditions, CurrentInaccessibleBodyParts)
            mOriginalIgnoreConflict = attempt.IsConflictIgnored
            mOriginalInaccessibleBodyParts = CurrentInaccessibleBodyParts.DeepCopy

            ConflictControl.WireConflictAndAttempt(mConflict, attempt)

            mOriginalCapturedConditions = attempt.CapturedConditions.DeepCopy
            mOriginalCapturedInaccessibleBodyParts = attempt.InaccessiblePartsOnCapture.DeepCopy

            ConflictControl.OverrideCheckBox.BoolValue = mAttemptWire.IsConflictIgnored

            ' Wire the attempt to the editor panels and make sure we know about changed conditions
            EditorPanels.AttemptToEdit(attempt)
            With EditorPanels
                AddHandler .CapturedConditionsControl.Conditions.ConditionValueChanged, AddressOf CapturedConditionSetChange
                AddHandler .CapturedInaccessibleBodyPartsControl.BodyPartsWire.BodyPartsChanged, AddressOf CapturedBodyPartChange
                AddHandler .CaptureResultControl.CorruptImageCheckBox.CheckedChanged, AddressOf CaptureCheckBoxChange
                AddHandler .CaptureResultControl.RejectCheckBox.CheckedChanged, AddressOf CaptureCheckBoxChange
            End With

            With ConflictControl
                AddHandler .OverrideCheckBox.CheckStateChanged, AddressOf OverrideCheckBoxChange
            End With


            

        End Sub

        Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)

            With EditorPanels
                RemoveHandler .CapturedConditionsControl.Conditions.ConditionValueChanged, AddressOf CapturedConditionSetChange
                RemoveHandler .CapturedInaccessibleBodyPartsControl.BodyPartsWire.BodyPartsChanged, AddressOf CapturedBodyPartChange
                RemoveHandler .CaptureResultControl.CorruptImageCheckBox.CheckedChanged, AddressOf CaptureCheckBoxChange
                RemoveHandler .CaptureResultControl.RejectCheckBox.CheckedChanged, AddressOf CaptureCheckBoxChange
            End With

            With ConflictControl
                RemoveHandler .OverrideCheckBox.CheckStateChanged, AddressOf OverrideCheckBoxChange
            End With
        End Sub

        Public Sub WireCurrentConditions(ByVal conditions As ConditionCollection)
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            mCurrentConditionsWire = conditions.DeepCopy()
            mOriginalCurrentConditions = conditions.DeepCopy()
            EditorPanels.WireCurrentConditions(mCurrentConditionsWire)
            AddHandler mCurrentConditionsWire.ConditionValueChanged, AddressOf CurrentConditionSetChange
        End Sub

        Public Sub WireDeepCopyOfCurrentInaccessibleBodyParts(ByVal parts As BodyPartCollection)
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            mCurrentInaccessibleBodyPartsWire = parts.DeepCopy
            mOriginalCurrentInaccessibleBodyParts = parts.DeepCopy
            EditorPanels.WireCurrentInaccessibleBodyParts(mCurrentInaccessibleBodyPartsWire)
            AddHandler mCurrentInaccessibleBodyPartsWire.BodyPartsChanged, AddressOf CurrentBodyPartChange
        End Sub


        Public ReadOnly Property CapturedConditions() As ConditionCollection
            Get
                Return EditorPanels.CapturedConditionsControl.Conditions
            End Get
        End Property

        Public ReadOnly Property CurrentConditions() As ConditionCollection
            Get
                Return EditorPanels.CurrentConditionsControl.Conditions
            End Get
        End Property

        Public ReadOnly Property CurrentInaccessibleBodyParts() As BodyPartCollection
            Get
                Return EditorPanels.CurrentInaccessibleBodyPartsControl.BodyPartsWire
            End Get
        End Property



        Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
            DialogResult = Windows.Forms.DialogResult.OK

            If EditorPanels.CaptureResultControl.ImageJustMarkedAsCorrupt AndAlso UninitializeSensorsOfCorruptImages Then
                mAttemptWire.ParentTask.Sensor.Uninitialize()
            End If

            Close()
        End Sub


        Private Sub CancelationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelationButton.Click
            Close()
        End Sub

        Private mSyncingConditionChanges As Boolean
        Private Sub CapturedConditionSetChange(ByVal sender As Object, ByVal e As ConditionValueChangedEventArgs)
            RefreshConflict()
            RefreshButtons()
        End Sub


        Private Sub CurrentConditionSetChange(ByVal sender As Object, ByVal e As ConditionValueChangedEventArgs)

            If mSyncingConditionChanges Then Return
            If LinkCurrentAndCaptured.CheckState = CheckState.Checked Then
                With EditorPanels.CapturedConditionsControl
                    .Conditions.AssignSubset(EditorPanels.CurrentConditionsControl.Conditions)
                    .BindFromWireToControls()
                End With
                mSyncingConditionChanges = False
            End If

            EditorPanels.Refresh()
            RefreshConflict()
            RefreshButtons()
        End Sub

        Private mSyncingBodyPartChanges As Boolean
        Private Sub CurrentBodyPartChange(ByVal sender As Object, ByVal e As BodyPartsChangeEventArgs)

            If mSyncingBodyPartChanges Then Return
            If LinkCurrentAndCaptured.CheckState = CheckState.Checked Then
                mSyncingBodyPartChanges = True
                With EditorPanels.CapturedInaccessibleBodyPartsControl
                    .BodyPartsWire.AddRange(e.PartsAdded)
                    .BodyPartsWire.RemoveRange(e.PartsRemoved, False)
                    .BindFromWireToControls()
                End With
                mSyncingBodyPartChanges = False
            End If

            RefreshConflict()
            RefreshButtons()
            RefreshPanels()
            RefreshLinkCurrentAndCaptured()
        End Sub

        Private Sub CapturedBodyPartChange(ByVal sender As Object, ByVal e As BodyPartsChangeEventArgs)
            If mSyncingBodyPartChanges Then Return
            If LinkCurrentAndCaptured.CheckState = CheckState.Checked Then
                mSyncingBodyPartChanges = True
                With EditorPanels.CurrentInaccessibleBodyPartsControl
                    .BodyPartsWire.AddRange(e.PartsAdded)
                    .BodyPartsWire.RemoveRange(e.PartsRemoved, False)
                    .BindFromWireToControls()
                End With
                mSyncingBodyPartChanges = False
            End If

            RefreshConflict()
            RefreshButtons()
            RefreshPanels()
            RefreshLinkCurrentAndCaptured()
        End Sub

        Private Sub CaptureCheckBoxChange(ByVal sender As Object, ByVal e As EventArgs)
            RefreshConflict()
            RefreshButtons()
            RefreshPanels()
            RefreshLinkCurrentAndCaptured()
        End Sub

        Private Sub OverrideCheckBoxChange(ByVal sender As Object, ByVal e As EventArgs)
            ' We don't refresh the conflict since the conflict control will do it itself
            RefreshButtons()
            RefreshPanels()
        End Sub

        Private Sub RefreshPanels()

            With EditorPanels
                If .CaptureResultControl.WrongTaskCheckBox.CheckState = CheckState.Checked Then

                    .CurrentConditionsControl.Enabled = False
                    .CurrentConditionsControl.Refresh()

                    .CurrentInaccessibleBodyPartsControl.Enabled = False
                    .CurrentInaccessibleBodyPartsControl.Refresh()

                    .CapturedConditionsControl.Enabled = False
                    .CapturedConditionsControl.DisabledLabelColor = Color.Pink
                    .CapturedConditionsControl.DisabledLabelText = "Task-specific injury data " & vbNewLine & " will not be saved"
                    .CapturedConditionsControl.Refresh()

                    .CapturedInaccessibleBodyPartsControl.Enabled = False
                    .CapturedInaccessibleBodyPartsControl.DisabledLabelColor = Color.Pink
                    .CapturedInaccessibleBodyPartsControl.DisabledLabelText = "Task-specific injury data " & vbNewLine & " will not be saved"

                    LinkCurrentAndCaptured.Enabled = False

                ElseIf LinkCurrentAndCaptured.CheckState = CheckState.Checked Then

                    .CurrentConditionsControl.Enabled = _
                        .CaptureResultControl.WrongTaskCheckBox.CheckState = CheckState.Unchecked
                    .CurrentConditionsControl.Refresh()

                    .CurrentInaccessibleBodyPartsControl.Enabled = _
                        .CaptureResultControl.WrongTaskCheckBox.CheckState = CheckState.Unchecked
                    .CurrentInaccessibleBodyPartsControl.Refresh()

                    .CapturedConditionsControl.Enabled = False
                    .CapturedConditionsControl.DisabledLabelColor = Color.DarkGray
                    .CapturedConditionsControl.DisabledLabelText = "Current and captured conditions" & vbNewLine & "change together"
                    .CapturedConditionsControl.Refresh()

                    .CapturedInaccessibleBodyPartsControl.Enabled = False
                    .CapturedInaccessibleBodyPartsControl.DisabledLabelColor = Color.DarkGray
                    .CapturedInaccessibleBodyPartsControl.DisabledLabelText = "Current and captured parts" & vbNewLine & "change together"
                    .CapturedInaccessibleBodyPartsControl.Refresh()

                    LinkCurrentAndCaptured.Enabled = True
                Else
                    .CapturedInaccessibleBodyPartsControl.Enabled = True
                    .CapturedConditionsControl.Enabled = True
                    .CurrentConditionsControl.Enabled = True
                    .CurrentInaccessibleBodyPartsControl.Enabled = True
                    LinkCurrentAndCaptured.Enabled = True
                End If
                .Refresh()
            End With

        End Sub

        Private Sub RefreshButtons()


            ' Helper booleans
            Dim factories As SensorTaskFactoryCollection = mAttemptWire.ParentTask.OriginatingFactory.ParentSensorTaskFactories
            Dim hasNoConflict As Boolean = mConflict.IsEmpty
            Dim hasConflict As Boolean = Not mConflict.IsEmpty
            Dim hasUnfixableConflict As Boolean = hasConflict AndAlso Not factories.AttemptIsMigratable(mAttemptWire)


            ' --------------------
            ' Reasons to click OK
            '
            Dim unrejected As Boolean = mOriginalAttempt.IsRejected And Not mAttemptWire.IsRejected
            Dim hasFixableConflict As Boolean = hasConflict AndAlso factories.AttemptIsMigratable(mAttemptWire)
            Dim hasUnfixableIgnoredConflict As Boolean = hasUnfixableConflict AndAlso mAttemptWire.IsConflictIgnored
            Dim conflictResolved As Boolean = mOriginalInConflict AndAlso hasNoConflict
            Dim changedWithNoConflict As Boolean = Not mOriginalAttempt.Equals(mAttemptWire) AndAlso mConflict.IsEmpty


            OKButton.Enabled = unrejected Or hasFixableConflict Or hasUnfixableIgnoredConflict Or conflictResolved Or changedWithNoConflict

            ' ---------------------
            ' Reasons to *forbid* clicking OK (i.e., cancel only)
            '
            Dim unchanged As Boolean = mOriginalAttempt.Equals(mAttemptWire)
            If unchanged Then OKButton.Enabled = False


            OKButton.Refresh()

        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout

            RecursiveSuspendLayout(Me)

            With HeaderGroup
                .RefreshAutomaticLayout(graphics)
                .Width = .MinimumWidth
                .Height = .MinimumHeight
            End With

            mMinimumHeight = 0
            mMinimumWidth = 0
            mMinimumHeight = HeaderGroup.MinimumHeight + EditorPanels.MinimumHeight + FooterPanel.Height + VerticalPadding(Me)
            mMinimumWidth = Math.Max(HeaderGroup.MinimumWidth, EditorPanels.MinimumWidth) + HorizontalPadding(Me)

            Static buttons As Collection(Of Button)
            If buttons Is Nothing Then
                buttons = New Collection(Of Button)
                buttons.Add(OKButton)
                buttons.Add(CancelationButton)
            End If

            OKButton.Font = UI.GlobalUISettings.Defaults.Fonts.Button
            CancelationButton.Font = UI.GlobalUISettings.Defaults.Fonts.Button
            UI.AutoSize.Buttons(graphics, buttons)
            ButtonFlowLayout.LayoutContainer()

            LinkCurrentAndCaptured.Font = UI.GlobalUISettings.Defaults.Fonts.Small
            UI.AutoSize.CheckBox(UICulture, graphics, LinkCurrentAndCaptured)


            RecursiveResumeLayout(Me)
        End Sub


        Private mMinimumHeight As Integer
        Public ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get
                Return mMinimumHeight
            End Get
        End Property

        Private mMinimumWidth As Integer
        Public ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get
                Return mMinimumWidth
            End Get
        End Property

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If InDesignMode(Me) Then Return
            If Not NearestForm Is Nothing Then
                Dim g As Graphics = NearestForm.CreateGraphics()
                RefreshAutomaticLayout(g)
                g.Dispose()
            End If
        End Sub


        Private mUninitializeSensorsOfCorruptImages As Boolean
        Public Property UninitializeSensorsOfCorruptImages() As Boolean
            Get
                Return mUninitializeSensorsOfCorruptImages
            End Get
            Set(ByVal value As Boolean)
                mUninitializeSensorsOfCorruptImages = value
            End Set
        End Property

        Private Sub LinkCurrentAndCaptured_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkCurrentAndCaptured.CheckedChanged

            '' If we've decided to change both the captured and current data together, then go ahead and refresh the captured data
            '' so that it reflects what which has been captured.
            ''
            'If LinkCurrentAndCaptured.CheckState = CheckState.Checked Then

            '    With EditorPanels.CapturedConditionsControl
            '        .Conditions.AssignSubset(EditorPanels.CurrentConditionsControl.Conditions)
            '        .BindFromWireToControls()
            '    End With

            '    With EditorPanels.CapturedInaccessibleBodyPartsControl
            '        .BodyPartsWire.Assign(EditorPanels.CurrentInaccessibleBodyPartsControl.BodyPartsWire)
            '        .BindFromWireToControls()
            '    End With

            'End If
            RefreshConflict()
            RefreshPanels()
            RefreshButtons()
        End Sub

        Private Sub RefreshButtonsAndPanels(ByVal sender As System.Object, ByVal e As System.EventArgs)
            RefreshConflict()
            RefreshPanels()
            RefreshButtons()
            RefreshLinkCurrentAndCaptured()
        End Sub

        Private Sub RefreshLinkCurrentAndCaptured()
            Dim conditionsEqual As Boolean = mCurrentConditionsWire.EqualsSubset(EditorPanels.CapturedConditionsControl.Conditions)
            Dim partsEqual As Boolean = mCurrentInaccessibleBodyPartsWire.Equals(EditorPanels.CapturedInaccessibleBodyPartsControl.BodyPartsWire)
            LinkCurrentAndCaptured.Enabled = conditionsEqual AndAlso partsEqual
        End Sub

        Private Shared Sub Trace(ByVal message As String)
            If Diagnostics.Trace.Listeners("AttemptEditor") IsNot Nothing Then
                Dim now As DateTime = DateTime.Now
                Dim dateNow As String = now.Date.ToShortDateString
                Dim timeNow As String = String.Format("{0,-2:00}:{1,-2:00}:{2,-2:00}.{3,-3:000}", _
                    now.TimeOfDay.Hours, now.TimeOfDay.Minutes, now.TimeOfDay.Seconds, now.TimeOfDay.Milliseconds)

                Diagnostics.Trace.Listeners("AttemptEditor").WriteLine(dateNow & " " & timeNow & ": " & message)
                Diagnostics.Trace.Listeners("AttemptEditor").Flush()
            End If
        End Sub


    End Class

End Namespace
