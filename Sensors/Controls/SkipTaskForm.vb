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
Imports Mbark.SensorMessages
Imports Mbark.UI
Imports Mbark.UI.GlobalUISettings

Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports SF = Syncfusion.Windows.Forms.Tools

Namespace Mbark.Sensors

    Public Class SkipTaskForm
        Inherits BaseForm
        Implements IAutosizable
        Implements IHasUICulture

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            'UserNew()
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
        Friend WithEvents mEditorPanels As Mbark.Sensors.TaskOrAttemptEditor
        Friend WithEvents FooterPanelFlowLayout As Syncfusion.Windows.Forms.Tools.FlowLayout
        Friend WithEvents OKButton As System.Windows.Forms.Button
        Friend WithEvents CancelationButton As System.Windows.Forms.Button
        Friend WithEvents FooterLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        Friend WithEvents HeaderGroup As Mbark.UI.AutosizableDropDownGroup
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SkipTaskForm))
            Me.FooterPanel = New System.Windows.Forms.Panel
            Me.FooterLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.OKButton = New System.Windows.Forms.Button
            Me.CancelationButton = New System.Windows.Forms.Button
            Me.mEditorPanels = New Mbark.Sensors.TaskOrAttemptEditor
            Me.FooterPanelFlowLayout = New Syncfusion.Windows.Forms.Tools.FlowLayout(Me.components)
            Me.HeaderGroup = New Mbark.UI.AutosizableDropDownGroup
            Me.FooterPanel.SuspendLayout()
            CType(Me.FooterPanelFlowLayout, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.FooterPanel.Controls.Add(Me.FooterLabel)
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
            'FooterLabel
            '
            Me.FooterLabel.AccessibleDescription = resources.GetString("FooterLabel.AccessibleDescription")
            Me.FooterLabel.AccessibleName = resources.GetString("FooterLabel.AccessibleName")
            Me.FooterLabel.Anchor = CType(resources.GetObject("FooterLabel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.FooterLabel.AutoSize = CType(resources.GetObject("FooterLabel.AutoSize"), Boolean)
            Me.FooterLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.FooterLabel.BorderSides = System.Windows.Forms.Border3DSide.All
            Me.FooterLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
            Me.FooterPanelFlowLayout.SetConstraints(Me.FooterLabel, CType(resources.GetObject("FooterLabel.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.FooterLabel.Dock = CType(resources.GetObject("FooterLabel.Dock"), System.Windows.Forms.DockStyle)
            Me.FooterLabel.Enabled = CType(resources.GetObject("FooterLabel.Enabled"), Boolean)
            Me.FooterLabel.Font = CType(resources.GetObject("FooterLabel.Font"), System.Drawing.Font)
            Me.FooterLabel.Image = CType(resources.GetObject("FooterLabel.Image"), System.Drawing.Image)
            Me.FooterLabel.ImageAlign = CType(resources.GetObject("FooterLabel.ImageAlign"), System.Drawing.ContentAlignment)
            Me.FooterLabel.ImageIndex = CType(resources.GetObject("FooterLabel.ImageIndex"), Integer)
            Me.FooterLabel.ImeMode = CType(resources.GetObject("FooterLabel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.FooterLabel.Location = CType(resources.GetObject("FooterLabel.Location"), System.Drawing.Point)
            Me.FooterPanelFlowLayout.SetMinimumSize(Me.FooterLabel, CType(resources.GetObject("FooterLabel.MinimumSize"), System.Drawing.Size))
            Me.FooterLabel.Name = "FooterLabel"
            Me.FooterPanelFlowLayout.SetPreferredSize(Me.FooterLabel, CType(resources.GetObject("FooterLabel.PreferredSize"), System.Drawing.Size))
            Me.FooterLabel.RightToLeft = CType(resources.GetObject("FooterLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.FooterLabel.Size = CType(resources.GetObject("FooterLabel.Size"), System.Drawing.Size)
            Me.FooterLabel.TabIndex = CType(resources.GetObject("FooterLabel.TabIndex"), Integer)
            Me.FooterLabel.Text = resources.GetString("FooterLabel.Text")
            Me.FooterLabel.TextAlign = CType(resources.GetObject("FooterLabel.TextAlign"), System.Drawing.ContentAlignment)
            Me.FooterLabel.Visible = CType(resources.GetObject("FooterLabel.Visible"), Boolean)
            '
            'OKButton
            '
            Me.OKButton.AccessibleDescription = resources.GetString("OKButton.AccessibleDescription")
            Me.OKButton.AccessibleName = resources.GetString("OKButton.AccessibleName")
            Me.OKButton.Anchor = CType(resources.GetObject("OKButton.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OKButton.BackgroundImage = CType(resources.GetObject("OKButton.BackgroundImage"), System.Drawing.Image)
            Me.FooterPanelFlowLayout.SetConstraints(Me.OKButton, CType(resources.GetObject("OKButton.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
            Me.OKButton.Dock = CType(resources.GetObject("OKButton.Dock"), System.Windows.Forms.DockStyle)
            Me.OKButton.Enabled = CType(resources.GetObject("OKButton.Enabled"), Boolean)
            Me.OKButton.FlatStyle = CType(resources.GetObject("OKButton.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.OKButton.Font = CType(resources.GetObject("OKButton.Font"), System.Drawing.Font)
            Me.OKButton.Image = CType(resources.GetObject("OKButton.Image"), System.Drawing.Image)
            Me.OKButton.ImageAlign = CType(resources.GetObject("OKButton.ImageAlign"), System.Drawing.ContentAlignment)
            Me.OKButton.ImageIndex = CType(resources.GetObject("OKButton.ImageIndex"), Integer)
            Me.OKButton.ImeMode = CType(resources.GetObject("OKButton.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OKButton.Location = CType(resources.GetObject("OKButton.Location"), System.Drawing.Point)
            Me.FooterPanelFlowLayout.SetMinimumSize(Me.OKButton, CType(resources.GetObject("OKButton.MinimumSize"), System.Drawing.Size))
            Me.OKButton.Name = "OKButton"
            Me.FooterPanelFlowLayout.SetPreferredSize(Me.OKButton, CType(resources.GetObject("OKButton.PreferredSize"), System.Drawing.Size))
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
            Me.FooterPanelFlowLayout.SetConstraints(Me.CancelationButton, CType(resources.GetObject("CancelationButton.Constraints"), Syncfusion.Windows.Forms.Tools.FlowLayoutConstraints))
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
            Me.FooterPanelFlowLayout.SetMinimumSize(Me.CancelationButton, CType(resources.GetObject("CancelationButton.MinimumSize"), System.Drawing.Size))
            Me.CancelationButton.Name = "CancelationButton"
            Me.FooterPanelFlowLayout.SetPreferredSize(Me.CancelationButton, CType(resources.GetObject("CancelationButton.PreferredSize"), System.Drawing.Size))
            Me.CancelationButton.RightToLeft = CType(resources.GetObject("CancelationButton.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.CancelationButton.Size = CType(resources.GetObject("CancelationButton.Size"), System.Drawing.Size)
            Me.CancelationButton.TabIndex = CType(resources.GetObject("CancelationButton.TabIndex"), Integer)
            Me.CancelationButton.Text = resources.GetString("CancelationButton.Text")
            Me.CancelationButton.TextAlign = CType(resources.GetObject("CancelationButton.TextAlign"), System.Drawing.ContentAlignment)
            Me.CancelationButton.Visible = CType(resources.GetObject("CancelationButton.Visible"), Boolean)
            '
            'EditorPanels
            '
            Me.mEditorPanels.AccessibleDescription = resources.GetString("EditorPanels.AccessibleDescription")
            Me.mEditorPanels.AccessibleName = resources.GetString("EditorPanels.AccessibleName")
            Me.mEditorPanels.Anchor = CType(resources.GetObject("EditorPanels.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.mEditorPanels.AutoScroll = CType(resources.GetObject("EditorPanels.AutoScroll"), Boolean)
            Me.mEditorPanels.AutoScrollMargin = CType(resources.GetObject("EditorPanels.AutoScrollMargin"), System.Drawing.Size)
            Me.mEditorPanels.AutoScrollMinSize = CType(resources.GetObject("EditorPanels.AutoScrollMinSize"), System.Drawing.Size)
            Me.mEditorPanels.BackgroundImage = CType(resources.GetObject("EditorPanels.BackgroundImage"), System.Drawing.Image)
            Me.mEditorPanels.BorderPadding = 4
            Me.mEditorPanels.Dock = CType(resources.GetObject("EditorPanels.Dock"), System.Windows.Forms.DockStyle)
            Me.mEditorPanels.Enabled = CType(resources.GetObject("EditorPanels.Enabled"), Boolean)
            Me.mEditorPanels.Font = CType(resources.GetObject("EditorPanels.Font"), System.Drawing.Font)
            Me.mEditorPanels.ImeMode = CType(resources.GetObject("EditorPanels.ImeMode"), System.Windows.Forms.ImeMode)
            Me.mEditorPanels.Location = CType(resources.GetObject("EditorPanels.Location"), System.Drawing.Point)
            Me.mEditorPanels.Name = "EditorPanels"
            Me.mEditorPanels.RightToLeft = CType(resources.GetObject("EditorPanels.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.mEditorPanels.Size = CType(resources.GetObject("EditorPanels.Size"), System.Drawing.Size)
            Me.mEditorPanels.StackBodyPartPanels = True
            Me.mEditorPanels.StackConditionPanels = True
            Me.mEditorPanels.TabIndex = CType(resources.GetObject("EditorPanels.TabIndex"), Integer)
            Me.mEditorPanels.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.mEditorPanels.Visible = CType(resources.GetObject("EditorPanels.Visible"), Boolean)
            Me.mEditorPanels.WithCancellationReasons = True
            Me.mEditorPanels.WithCapturedConditions = False
            Me.mEditorPanels.WithCapturedInaccessibleParts = False
            Me.mEditorPanels.WithCaptureResult = False
            Me.mEditorPanels.WithCurrentConditions = True
            Me.mEditorPanels.WithCurrentInaccessibleBodyParts = True
            '
            'FooterPanelFlowLayout
            '
            Me.FooterPanelFlowLayout.Alignment = CType(resources.GetObject("FooterPanelFlowLayout.Alignment"), Syncfusion.Windows.Forms.Tools.FlowAlignment)
            Me.FooterPanelFlowLayout.ContainerControl = Me.FooterPanel
            Me.FooterPanelFlowLayout.CustomLayoutBounds = CType(resources.GetObject("FooterPanelFlowLayout.CustomLayoutBounds"), System.Drawing.Rectangle)
            Me.FooterPanelFlowLayout.HGap = CType(resources.GetObject("FooterPanelFlowLayout.HGap"), Integer)
            Me.FooterPanelFlowLayout.LayoutMode = CType(resources.GetObject("FooterPanelFlowLayout.LayoutMode"), Syncfusion.Windows.Forms.Tools.FlowLayoutMode)
            Me.FooterPanelFlowLayout.ReverseRows = CType(resources.GetObject("FooterPanelFlowLayout.ReverseRows"), Boolean)
            Me.FooterPanelFlowLayout.VGap = CType(resources.GetObject("FooterPanelFlowLayout.VGap"), Integer)
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
            Me.HeaderGroup.DockPadding.All = 8
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
            'SkipTaskForm
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.Controls.Add(Me.mEditorPanels)
            Me.Controls.Add(Me.FooterPanel)
            Me.Controls.Add(Me.HeaderGroup)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "SkipTaskForm"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            Me.FooterPanel.ResumeLayout(False)
            CType(Me.FooterPanelFlowLayout, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private mCulture As CultureInfo = CultureInfo.CurrentUICulture
        Public Property UICulture() As CultureInfo Implements IHasUICulture.UICulture
            Get
                Return mCulture
            End Get
            Set(ByVal Value As CultureInfo)
                mCulture = Value
            End Set
        End Property

        Private mCurrentInaccessibleBodyPartsWire As BodyPartCollection
        Private mCurrentConditionsWire As ConditionCollection
        Private mOriginalConditions As ConditionCollection
        Private mOriginalBodyParts As BodyPartCollection

        Private mTaskToBeSkippedWire As SensorTask
        Private mTaskToSkipToWire As SensorTask

        Public Sub WireTasks(ByVal taskToBeSkipped As SensorTask, ByVal taskToSkipTo As SensorTask)
            mTaskToBeSkippedWire = taskToBeSkipped
            mTaskToSkipToWire = taskToSkipTo

            If taskToSkipTo Is Nothing Then
                ' No task to skip to implies that we're cancelling the session
                mEditorPanels.CancelReasonsControl.WireSessionToCancel(mTaskToBeSkippedWire.OriginatingFactory.ParentSensorTaskFactories)
            End If
        End Sub

        Public ReadOnly Property TaskToSkipTo() As SensorTask
            Get
                Return mTaskToSkipToWire
            End Get
        End Property

        Public Sub WireInaccessibleBodyParts(ByVal parts As BodyPartCollection)
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            mCurrentInaccessibleBodyPartsWire = parts
            mOriginalBodyParts = parts.DeepCopy
            mEditorPanels.WireCurrentInaccessibleBodyParts(parts)
        End Sub


        Public Sub WireCurrentConditions(ByVal conditions As ConditionCollection)
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            mCurrentConditionsWire = conditions
            mOriginalConditions = conditions.DeepCopy
            mEditorPanels.WireCurrentConditions(conditions)
        End Sub


        Private WithEvents mFromTaskTextBox As New AutosizableRichTextBox
        Private WithEvents mToTaskTextBox As New AutosizableRichTextBox

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)

            '---
            ' Enable / disable components (this might be better if moved into the editor panels themselves)
            '
            Dim category As Mbark.Sensors.SensorTaskCategory = mTaskToBeSkippedWire.TargetCategory
            With mEditorPanels

                If mTaskToSkipToWire Is Nothing Then
                    ' No destination task implies end of session
                    .WithCancellationReasons = True
                    .WithCapturedConditions = False
                    .WithCapturedInaccessibleParts = False
                    .WithCurrentConditions = False
                    .WithCurrentInaccessibleBodyParts = False
                    .CancelReasonsControl.WithRadioButton = False
                    Me.Width = CInt(Me.Width / 2) ' FIXME, a cheap hack to make the form smaller!
                    .CancelReasonsControl.RadioButtonSelected = True
                Else
                    .CancelReasonsControl.WithRadioButton = True
                    .WithCancellationReasons = True
                    .WithCapturedConditions = False
                    .WithCapturedInaccessibleParts = False
                    If category = SensorTaskCategory.Face Then .WithCurrentInaccessibleBodyParts = False
                End If

                With .CurrentInaccessibleBodyPartsControl
                    .ReflectTask(mTaskToBeSkippedWire)
                    .WithRadioButton = True
                    .HeaderText = Messages.CurrentInjuries
                    .WireBodyPartsList(mCurrentInaccessibleBodyPartsWire)
                End With

                With .CurrentConditionsControl
                    If mCurrentConditionsWire.Count = 0 Then mEditorPanels.WithCurrentConditions = False
                    .HeaderText = Messages.CurrentConditions
                    .WithRadioButton = True
                    .WireConditions(mCurrentConditionsWire)
                End With



            End With



            '---
            ' Layout controls
            '
            Dim fromWriter As New IO.StringWriter(CultureInfo.InvariantCulture)
            With fromWriter
                .Write(Rtf.BoldOn)
                .Write(Messages.From(UICulture))
                .Write(Rtf.BoldOff)
                .Write(Rtf.Newline)
                .Write(mTaskToBeSkippedWire.FriendlyToString(UICulture))
            End With
            mFromTaskTextBox.Text = Rtf.ToRtf(fromWriter.ToString)


            Dim toWriter As New IO.StringWriter(CultureInfo.InvariantCulture)
            With toWriter
                .Write(Rtf.BoldOn)
                .Write(Messages.To(UICulture))
                .Write(Rtf.BoldOff)
                .Write(Rtf.Newline)
                If mTaskToSkipToWire Is Nothing Then
                    .Write(Rtf.ToRtf("End of session")) 'i18n
                Else
                    .Write(Rtf.ToRtf(mTaskToSkipToWire.FriendlyToString(UICulture)))
                End If

            End With
            mToTaskTextBox.Text = Rtf.ToRtf(toWriter.ToString)


            Dim fromLayout As New AutosizableDropDownLayoutArgs(mFromTaskTextBox)
            With fromLayout
                .FillWeightX = 0.5!
                .FillWeightY = 1.0!
            End With
            HeaderGroup.LayoutControl(fromLayout)

            Dim toLayout As New AutosizableDropDownLayoutArgs(mToTaskTextBox)
            With toLayout
                .GridPosX = 1
                .FillWeightX = 0.5!
                .FillWeightY = 1.0!
            End With
            HeaderGroup.LayoutControl(toLayout)

            '--
            ' Handle group selection
            '
            With mEditorPanels
                AddHandler .CancelReasonsControl.RadioButtonChanged, AddressOf HandleEditorGroupSelection
                AddHandler .CurrentInaccessibleBodyPartsControl.RadioButtonChanged, AddressOf HandleEditorGroupSelection
                AddHandler .CurrentConditionsControl.RadioButtonChanged, AddressOf HandleEditorGroupSelection

                ' Refresh our own state when a different reason, body part, or condition is selected
                AddHandler .CancelReasonsControl.ReasonChanged, AddressOf HandleReasonChange
                AddHandler mCurrentConditionsWire.ConditionValueChanged, AddressOf HandleConditionChange
                AddHandler mCurrentInaccessibleBodyPartsWire.BodyPartsChanged, AddressOf HandleBodyPartChange

            End With

            Me.Text = Messages.SkipTask(UICulture)
            RefreshAutomaticLayout(Me.CreateGraphics)

        End Sub


        Private mHandlingEditorGroupSelection As Boolean
        Private Sub HandleEditorGroupSelection(ByVal sender As Object, ByVal e As EventArgs)
            If mHandlingEditorGroupSelection Then Return
            mHandlingEditorGroupSelection = True

            With mEditorPanels

                If sender Is .CancelReasonsControl AndAlso .CancelReasonsControl.RadioButtonSelected Then
                    .CurrentConditionsControl.RadioButtonSelected = False
                    .CurrentInaccessibleBodyPartsControl.RadioButtonSelected = False
                End If

                If sender Is .CurrentConditionsControl AndAlso .CurrentConditionsControl.RadioButtonSelected Then
                    .CancelReasonsControl.RadioButtonSelected = False
                    .CurrentInaccessibleBodyPartsControl.RadioButtonSelected = False
                End If
                If sender Is .CurrentInaccessibleBodyPartsControl AndAlso .CurrentInaccessibleBodyPartsControl.RadioButtonSelected Then
                    .CurrentConditionsControl.RadioButtonSelected = False
                    .CancelReasonsControl.RadioButtonSelected = False
                End If
            End With

            mHandlingEditorGroupSelection = False
            mEditorPanels.Refresh()
            RefreshButtons()
        End Sub

        Private Sub HandleReasonChange(ByVal sender As Object, ByVal e As EventArgs)
            RefreshButtons()
        End Sub

        Private Sub HandleConditionChange(ByVal sender As Object, ByVal e As ConditionValueChangedEventArgs)
            RefreshButtons()
        End Sub

        Private Sub HandleBodyPartChange(ByVal sender As Object, ByVal e As BodyPartsChangeEventArgs)
            RefreshButtons()
        End Sub

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            RefreshAutomaticLayout(CreateGraphics)
            RefreshButtons()
        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout

            If HeaderGroup Is Nothing Then Return

            HeaderGroup.RefreshAutomaticLayout(graphics)
            'EditorPanels.RefreshAutomaticLayout(graphics)

            ' Line up the margins with the editor panels (how lovely!)
            FooterPanelFlowLayout.HorzFarMargin = mEditorPanels.BorderPadding
            FooterPanelFlowLayout.HorzNearMargin = mEditorPanels.BorderPadding


            ' Resize the buttons
            Static buttons As Collection(Of Button)
            If buttons Is Nothing Then
                buttons = New Collection(Of Button)
                buttons.Add(CancelationButton)
                buttons.Add(OKButton)
            End If
            UI.AutoSize.Buttons(graphics, buttons)


            Dim panelWidth As Integer = FooterPanel.ClientRectangle.Width
            Dim buttonWidth As Integer = CancelationButton.Location.X + CancelationButton.Width - OKButton.Location.X
            Dim footerWidth As Integer = panelWidth - buttonWidth - UndocumentedPaddingConstants.PreventFlowLayoutWrap
            Dim footerHeight As Integer = OKButton.Height
            FooterLabel.Width = footerWidth
            FooterPanelFlowLayout.SetMinimumSize(FooterLabel, New Size(footerWidth, footerHeight))
            FooterPanelFlowLayout.SetPreferredSize(FooterLabel, New Size(footerWidth, footerHeight))

            'Dim minSize As SF.FlowLayoutConstraints = FooterPanelFlowLayout.getMinimumLayoutSize(FooterLabel)



        End Sub

        Private mReason As SkipTaskReason
        Public ReadOnly Property Reason() As SkipTaskReason
            Get
                Return mReason
            End Get
        End Property


        Public ReadOnly Property IsJustified() As SkipTaskReason
            Get
                With mEditorPanels
                    With .CancelReasonsControl
                        If .RadioButtonSelected Then
                            Select Case .Reason
                                Case CancellationReason.OtherReason
                                    If .OtherReasonText <> String.Empty Then Return SkipTaskReason.OtherReason
                                Case CancellationReason.Convenience
                                    Return SkipTaskReason.Convenience
                                Case CancellationReason.PerformingDemo
                                    Return SkipTaskReason.PerformingDemo
                                Case CancellationReason.SensorProblem
                                    Return SkipTaskReason.SensorProblem
                                Case CancellationReason.SubjectLeftSession
                                    Return SkipTaskReason.SubjectLeftSession
                                Case CancellationReason.SubjectRefuses
                                    Return SkipTaskReason.SubjectRefuses
                            End Select
                        End If
                    End With

                    With .CurrentConditionsControl
                        If .RadioButtonSelected AndAlso _
                        Not mCurrentConditionsWire.EqualsSubset(mOriginalConditions, _
                            ConditionsMatchStyle.AllWithoutEquivalenceClasses, Nothing, True) AndAlso _
                            Not mTaskToSkipToWire Is Nothing AndAlso _
                            mCurrentConditionsWire.EqualsSubset(mTaskToSkipToWire.Conditions) Then
                            Return SkipTaskReason.Condition
                        End If

                    End With

                    With .CurrentInaccessibleBodyPartsControl
                        Dim parts As BodyPartCollection = mCurrentInaccessibleBodyPartsWire
                        If .RadioButtonSelected AndAlso Not parts.Equals(mOriginalBodyParts) Then
                            If parts.ContainsSet(mTaskToBeSkippedWire.TargetParts) Then
                                Return SkipTaskReason.InaccessibleBodyPart
                            End If
                        End If

                    End With

                End With
                Return SkipTaskReason.NoReason
            End Get
        End Property

        Private Sub RefreshButtons()

            ' We may not be loaded yet
            If OKButton Is Nothing Then Return

            OKButton.Enabled = IsJustified <> SkipTaskReason.NoReason
            OKButton.Refresh()
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

        Private Sub HeaderGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HeaderGroup.Load

        End Sub

        Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
            mReason = IsJustified
            Close()
        End Sub

        Private Sub CancelationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelationButton.Click
            Close()
        End Sub

        Public ReadOnly Property EditorPanels() As TaskOrAttemptEditor
            Get
                Return mEditorPanels
            End Get
        End Property
        Public ReadOnly Property Okay() As Button
            Get
                Return OKButton
            End Get
        End Property

    End Class

    Public Enum SkipTaskReason
        NoReason
        Convenience
        SubjectLeftSession
        SubjectRefuses
        SensorProblem
        PerformingDemo
        OtherReason
        InaccessibleBodyPart
        Condition
    End Enum


End Namespace