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

Imports Mbark.UI
Imports Mbark.SensorMessages


' Note:
' ----
' This control does not encapsulate much UI logic, because it is used in more than one place. Specifically, 
' see AttemptEditor and SkipTaskForm for detailed behavior

Namespace Mbark.Sensors

    Public Class TaskOrAttemptEditor
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
        Public WithEvents CancelReasonsControl As Mbark.Sensors.CancelReasonsControl
        Public WithEvents CaptureResultControl As Mbark.Sensors.CaptureResultPanel
        Public WithEvents CurrentConditionsControl As Mbark.Sensors.ConditionsControl
        Public WithEvents CapturedConditionsControl As Mbark.Sensors.ConditionsControl
        Public WithEvents CurrentInaccessibleBodyPartsControl As Mbark.Sensors.InaccessibleBodyPartsControl
        Public WithEvents CapturedInaccessibleBodyPartsControl As Mbark.Sensors.InaccessibleBodyPartsControl

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskOrAttemptEditor))
            Me.CurrentInaccessibleBodyPartsControl = New Mbark.Sensors.InaccessibleBodyPartsControl
            Me.CapturedConditionsControl = New Mbark.Sensors.ConditionsControl
            Me.CaptureResultControl = New Mbark.Sensors.CaptureResultPanel
            Me.CapturedInaccessibleBodyPartsControl = New Mbark.Sensors.InaccessibleBodyPartsControl
            Me.CancelReasonsControl = New Mbark.Sensors.CancelReasonsControl
            Me.CurrentConditionsControl = New Mbark.Sensors.ConditionsControl
            Me.SuspendLayout()
            '
            'CurrentInaccessibleBodyPartsControl
            '
            Me.CurrentInaccessibleBodyPartsControl.BackColor = System.Drawing.SystemColors.Control
            Me.CurrentInaccessibleBodyPartsControl.DisabledLabelColor = System.Drawing.Color.Black
            Me.CurrentInaccessibleBodyPartsControl.DisabledLabelText = ""
            Me.CurrentInaccessibleBodyPartsControl.FingerPickerEnable = True
            Me.CurrentInaccessibleBodyPartsControl.HeaderText = Nothing
            Me.CurrentInaccessibleBodyPartsControl.HeaderTextColor = System.Drawing.Color.Empty
            Me.CurrentInaccessibleBodyPartsControl.IrisPickerEnable = True
            resources.ApplyResources(Me.CurrentInaccessibleBodyPartsControl, "CurrentInaccessibleBodyPartsControl")
            Me.CurrentInaccessibleBodyPartsControl.Name = "CurrentInaccessibleBodyPartsControl"
            Me.CurrentInaccessibleBodyPartsControl.RadioButtonIndentation = 8
            Me.CurrentInaccessibleBodyPartsControl.RadioButtonSelected = False
            Me.CurrentInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
            Me.CurrentInaccessibleBodyPartsControl.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.CurrentInaccessibleBodyPartsControl.WithFancyHeader = False
            Me.CurrentInaccessibleBodyPartsControl.WithIrises = False
            Me.CurrentInaccessibleBodyPartsControl.WithLeftHand = False
            Me.CurrentInaccessibleBodyPartsControl.WithRadioButton = False
            Me.CurrentInaccessibleBodyPartsControl.WithRightHand = False
            '
            'CapturedConditionsControl
            '
            Me.CapturedConditionsControl.DisabledLabelColor = System.Drawing.Color.Black
            Me.CapturedConditionsControl.DisabledLabelText = ""
            Me.CapturedConditionsControl.HeaderText = "Special Conditions"
            Me.CapturedConditionsControl.HeaderTextColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.CapturedConditionsControl, "CapturedConditionsControl")
            Me.CapturedConditionsControl.Name = "CapturedConditionsControl"
            Me.CapturedConditionsControl.RadioButtonIndentation = 8
            Me.CapturedConditionsControl.RadioButtonSelected = False
            Me.CapturedConditionsControl.RadioGroupBoxChecked = False
            Me.CapturedConditionsControl.ShowStaticsOnly = False
            Me.CapturedConditionsControl.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.CapturedConditionsControl.WithFancyHeader = False
            Me.CapturedConditionsControl.WithRadioButton = False
            '
            'CaptureResultControl
            '
            Me.CaptureResultControl.CorruptImage = False
            Me.CaptureResultControl.HeaderText = Nothing
            Me.CaptureResultControl.HeaderTextColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.CaptureResultControl, "CaptureResultControl")
            Me.CaptureResultControl.Name = "CaptureResultControl"
            Me.CaptureResultControl.RadioButtonIndentation = 8
            Me.CaptureResultControl.RadioButtonSelected = False
            Me.CaptureResultControl.RadioGroupBoxChecked = False
            Me.CaptureResultControl.RejectImage = False
            Me.CaptureResultControl.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.CaptureResultControl.WithFancyHeader = False
            Me.CaptureResultControl.WithRadioButton = False
            '
            'CapturedInaccessibleBodyPartsControl
            '
            Me.CapturedInaccessibleBodyPartsControl.BackColor = System.Drawing.SystemColors.Control
            Me.CapturedInaccessibleBodyPartsControl.DisabledLabelColor = System.Drawing.Color.Black
            Me.CapturedInaccessibleBodyPartsControl.DisabledLabelText = ""
            Me.CapturedInaccessibleBodyPartsControl.FingerPickerEnable = True
            Me.CapturedInaccessibleBodyPartsControl.HeaderText = Nothing
            Me.CapturedInaccessibleBodyPartsControl.HeaderTextColor = System.Drawing.Color.Empty
            Me.CapturedInaccessibleBodyPartsControl.IrisPickerEnable = True
            resources.ApplyResources(Me.CapturedInaccessibleBodyPartsControl, "CapturedInaccessibleBodyPartsControl")
            Me.CapturedInaccessibleBodyPartsControl.Name = "CapturedInaccessibleBodyPartsControl"
            Me.CapturedInaccessibleBodyPartsControl.RadioButtonIndentation = 8
            Me.CapturedInaccessibleBodyPartsControl.RadioButtonSelected = False
            Me.CapturedInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
            Me.CapturedInaccessibleBodyPartsControl.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.CapturedInaccessibleBodyPartsControl.WithFancyHeader = False
            Me.CapturedInaccessibleBodyPartsControl.WithIrises = False
            Me.CapturedInaccessibleBodyPartsControl.WithLeftHand = False
            Me.CapturedInaccessibleBodyPartsControl.WithRadioButton = False
            Me.CapturedInaccessibleBodyPartsControl.WithRightHand = False
            '
            'CancelReasonsControl
            '
            Me.CancelReasonsControl.HeaderText = "Other"
            Me.CancelReasonsControl.HeaderTextColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.CancelReasonsControl, "CancelReasonsControl")
            Me.CancelReasonsControl.Name = "CancelReasonsControl"
            Me.CancelReasonsControl.RadioButtonIndent = 16
            Me.CancelReasonsControl.RadioButtonIndentation = 8
            Me.CancelReasonsControl.RadioButtonSelected = False
            Me.CancelReasonsControl.RadioGroupBoxChecked = False
            Me.CancelReasonsControl.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.CancelReasonsControl.WithFancyHeader = False
            Me.CancelReasonsControl.WithRadioButton = False
            '
            'CurrentConditionsControl
            '
            Me.CurrentConditionsControl.DisabledLabelColor = System.Drawing.Color.Black
            Me.CurrentConditionsControl.DisabledLabelText = ""
            Me.CurrentConditionsControl.HeaderText = "Special Conditions"
            Me.CurrentConditionsControl.HeaderTextColor = System.Drawing.Color.Empty
            resources.ApplyResources(Me.CurrentConditionsControl, "CurrentConditionsControl")
            Me.CurrentConditionsControl.Name = "CurrentConditionsControl"
            Me.CurrentConditionsControl.RadioButtonIndentation = 8
            Me.CurrentConditionsControl.RadioButtonSelected = False
            Me.CurrentConditionsControl.RadioGroupBoxChecked = False
            Me.CurrentConditionsControl.ShowStaticsOnly = False
            Me.CurrentConditionsControl.UICulture = New System.Globalization.CultureInfo("en-US")
            Me.CurrentConditionsControl.WithFancyHeader = False
            Me.CurrentConditionsControl.WithRadioButton = False
            '
            'TaskOrAttemptEditor
            '
            Me.Controls.Add(Me.CurrentInaccessibleBodyPartsControl)
            Me.Controls.Add(Me.CapturedConditionsControl)
            Me.Controls.Add(Me.CaptureResultControl)
            Me.Controls.Add(Me.CapturedInaccessibleBodyPartsControl)
            Me.Controls.Add(Me.CancelReasonsControl)
            Me.Controls.Add(Me.CurrentConditionsControl)
            Me.Name = "TaskOrAttemptEditor"
            resources.ApplyResources(Me, "$this")
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

        Private mWithCapturedInaccessibleBodyParts As Boolean
        Public Property WithCapturedInaccessibleParts() As Boolean
            Get
                Return mWithCapturedInaccessibleBodyParts
            End Get
            Set(ByVal value As Boolean)
                mWithCapturedInaccessibleBodyParts = value
            End Set
        End Property

        Private mWithCurrentInaccessibleBodyParts As Boolean
        Public Property WithCurrentInaccessibleBodyParts() As Boolean
            Get
                Return mWithCurrentInaccessibleBodyParts
            End Get
            Set(ByVal value As Boolean)
                mWithCurrentInaccessibleBodyParts = value
            End Set
        End Property

        Private mWithCapturedConditions As Boolean
        Public Property WithCapturedConditions() As Boolean
            Get
                Return mWithCapturedConditions
            End Get
            Set(ByVal value As Boolean)
                mWithCapturedConditions = value
            End Set
        End Property

        Private mWithCurrentConditions As Boolean
        Public Property WithCurrentConditions() As Boolean
            Get
                Return mWithCurrentConditions
            End Get
            Set(ByVal value As Boolean)
                mWithCurrentConditions = value
            End Set
        End Property

        Private mWithCancelReasons As Boolean
        Public Property WithCancellationReasons() As Boolean
            Get
                Return mWithCancelReasons
            End Get
            Set(ByVal value As Boolean)
                mWithCancelReasons = value
            End Set
        End Property

        Private mWithCaptureResult As Boolean
        Public Property WithCaptureResult() As Boolean
            Get
                Return mWithCaptureResult
            End Get
            Set(ByVal value As Boolean)
                mWithCaptureResult = value
            End Set
        End Property

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Private mBorderPadding As Integer = 4
        Private mHalfBorderPadding As Integer = 2
        Public Property BorderPadding() As Integer
            Get
                Return mBorderPadding
            End Get
            Set(ByVal value As Integer)
                If value Mod 2 = 1 Then value += 1
                mBorderPadding = value
                mHalfBorderPadding = CInt(mBorderPadding / 2)
            End Set
        End Property


        Private mAutosizePanelsNotYetDrawn As Integer
        Private mAutosizePanelsDrawn As Integer
        Private mAutosizePanelsToDraw As Integer
        Private mAutosizeWidthUsed As Integer


        Public Sub AttemptToEdit(ByVal attempt As SensorTaskAttempt)
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")

            WithCapturedConditions = True
            WithCancellationReasons = False
            WithCaptureResult = True

            If attempt.ParentTask.TargetCategory = SensorTaskCategory.Face Then
                WithCapturedInaccessibleParts = False
                WithCurrentInaccessibleBodyParts = False
            Else
                WithCapturedInaccessibleParts = True
                WithCurrentInaccessibleBodyParts = True
            End If

            CapturedConditionsControl.WireConditions(attempt.CapturedConditions)
            CapturedInaccessibleBodyPartsControl.WireBodyPartsList(attempt.InaccessiblePartsOnCapture)
            CapturedInaccessibleBodyPartsControl.ReflectTask(attempt.ParentTask)
            CurrentInaccessibleBodyPartsControl.ReflectTask(attempt.ParentTask)
            CaptureResultControl.WireAttempt(attempt)

        End Sub

        Private mCurrentConditionsWire As ConditionCollection
        Public Sub WireCurrentConditions(ByVal conditions As ConditionCollection)
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            mCurrentConditionsWire = conditions
            WithCurrentConditions = True
            CurrentConditionsControl.WireConditions(mCurrentConditionsWire)
        End Sub


        Private mCurrentInaccessibleBodyPartsWire As BodyPartCollection
        Public Sub WireCurrentInaccessibleBodyParts(ByVal parts As BodyPartCollection)
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            mCurrentInaccessibleBodyPartsWire = parts
            WithCurrentInaccessibleBodyParts = True
            CurrentInaccessibleBodyPartsControl.WireBodyPartsList(mCurrentInaccessibleBodyPartsWire)
        End Sub

        Private Sub AutosizeAndStackPanel(ByVal graphics As Graphics, ByVal topPanel As Control, ByVal bottomPanel As Control)

            AutosizePanel(graphics, topPanel)
            mAutosizePanelsNotYetDrawn += 1
            mAutosizePanelsDrawn -= 1
            Dim widthUsedAfterOnePanel As Integer = mAutosizeWidthUsed

            topPanel.Height = CInt(topPanel.Height / 2)

            AutosizePanel(graphics, bottomPanel)
            bottomPanel.Location = LowerLeft(topPanel)
            bottomPanel.Width = topPanel.Width
            bottomPanel.Height = topPanel.Height

            ' Restore the amount of width used
            mAutosizeWidthUsed = widthUsedAfterOnePanel

        End Sub


        Private Sub AutosizePanel(ByVal graphics As Graphics, ByVal autoSizablePanel As Control)

            Dim a As IAutosizable = DirectCast(autoSizablePanel, IAutosizable)
            With autoSizablePanel
                a.RefreshAutomaticLayout(graphics)
                If Not .Visible Then Return


                If mAutosizePanelsNotYetDrawn = 0 Then Debugging.Break()
                Dim panelWidth As Integer = CInt((Me.ClientRectangle.Width - mAutosizeWidthUsed) / mAutosizePanelsNotYetDrawn)

                mAutosizePanelsNotYetDrawn -= 1
                mAutosizePanelsDrawn += 1

                Dim bpLeft As Integer, bpRight As Integer, bp As Integer
                If mAutosizePanelsNotYetDrawn = 0 Then bpRight = mBorderPadding Else bpRight = mHalfBorderPadding
                If mAutosizePanelsDrawn >= 1 Then bpLeft = mBorderPadding Else bpLeft = mHalfBorderPadding
                bp = bpLeft + bpRight

                .Location = New Point(mAutosizeWidthUsed + bpLeft, mBorderPadding)
                .Height = ClientRectangle.Height - mBorderPadding * 2
                .Width = Math.Max(panelWidth - bp, a.MinimumWidth - bp)

                mMinimumWidth += a.MinimumWidth + bp
                mMinimumHeight = Math.Max(mMinimumHeight, a.MinimumHeight + mBorderPadding * 2)

                mAutosizeWidthUsed += .Width + bp

            End With

        End Sub

        Private mStackConditionPanels As Boolean = True
        Public Property StackConditionPanels() As Boolean
            Get
                Return mStackConditionPanels
            End Get
            Set(ByVal value As Boolean)
                mStackConditionPanels = value
            End Set
        End Property

        Private mStackBodyPartPanels As Boolean = True
        Public Property StackBodyPartPanels() As Boolean
            Get
                Return mStackBodyPartPanels
            End Get
            Set(ByVal value As Boolean)
                mStackBodyPartPanels = value
            End Set
        End Property


        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout

            SuspendLayout()

            mAutosizePanelsToDraw = 0


            If mWithCancelReasons Then mAutosizePanelsToDraw += 1
            If mWithCaptureResult Then mAutosizePanelsToDraw += 1


            If Not CapturedConditionsControl.Conditions Is Nothing Then
                If WithCapturedConditions AndAlso Not CapturedConditionsControl.Conditions.HasValidConditions Then

                    ' Don't show any captured or current conditions if there are no valid ones
                    mWithCapturedConditions = False
                    mWithCurrentConditions = False

                    ' Don't bother stacking the body part panels if there are no conditions
                    StackBodyPartPanels = False
                End If
            End If

            Dim bothConditions As Boolean = WithCapturedConditions AndAlso WithCurrentConditions
            If bothConditions Then
                If StackConditionPanels Then
                    mAutosizePanelsToDraw += 1
                Else
                    mAutosizePanelsToDraw += 2
                End If
            Else
                If WithCapturedConditions Then mAutosizePanelsToDraw += 1
                If WithCurrentConditions Then mAutosizePanelsToDraw += 1
            End If

            Dim bothParts As Boolean = WithCapturedInaccessibleParts AndAlso WithCurrentInaccessibleBodyParts
            If bothParts Then
                If StackBodyPartPanels Then
                    mAutosizePanelsToDraw += 1
                Else
                    mAutosizePanelsToDraw += 2
                End If
            Else
                If WithCapturedInaccessibleParts Then mAutosizePanelsToDraw += 1
                If WithCurrentInaccessibleBodyParts Then mAutosizePanelsToDraw += 1
            End If

            CapturedInaccessibleBodyPartsControl.Visible = mWithCapturedInaccessibleBodyParts
            CurrentInaccessibleBodyPartsControl.Visible = mWithCurrentInaccessibleBodyParts
            CapturedConditionsControl.Visible = mWithCapturedConditions
            CurrentConditionsControl.Visible = mWithCurrentConditions
            CancelReasonsControl.Visible = mWithCancelReasons
            CaptureResultControl.Visible = mWithCaptureResult


            ' If there are no panels to draw, then leave
            If mAutosizePanelsToDraw = 0 Then Return

            mAutosizePanelsDrawn = 0
            mAutosizeWidthUsed = 0
            mAutosizePanelsNotYetDrawn = mAutosizePanelsToDraw

            mMinimumWidth = 0
            mMinimumHeight = 0

            If WithCancellationReasons Then AutosizePanel(graphics, CancelReasonsControl)
            If WithCaptureResult Then AutosizePanel(graphics, CaptureResultControl)

            If bothConditions AndAlso StackConditionPanels Then
                AutosizeAndStackPanel(graphics, CapturedConditionsControl, CurrentConditionsControl)
            Else
                If WithCapturedConditions Then AutosizePanel(graphics, CapturedConditionsControl)
                If WithCurrentConditions Then AutosizePanel(graphics, CurrentConditionsControl)
            End If

            If bothParts AndAlso StackBodyPartPanels Then
                AutosizeAndStackPanel(graphics, CapturedInaccessibleBodyPartsControl, CurrentInaccessibleBodyPartsControl)
            Else
                If WithCapturedInaccessibleParts Then AutosizePanel(graphics, CapturedInaccessibleBodyPartsControl)
                If WithCurrentInaccessibleBodyParts Then AutosizePanel(graphics, CurrentInaccessibleBodyPartsControl)
            End If

            ResumeLayout()


        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            'If InDesignMode(Me) Then Return

            ' Propogate the culture information
            CapturedConditionsControl.UICulture = UICulture
            CurrentConditionsControl.UICulture = UICulture
            CapturedInaccessibleBodyPartsControl.UICulture = UICulture
            CurrentInaccessibleBodyPartsControl.UICulture = UICulture
            CancelReasonsControl.UICulture = UICulture
            CaptureResultControl.UICulture = UICulture

            CurrentConditionsControl.ShowStaticsOnly = True
            CapturedConditionsControl.WithRadioButton = True
            CurrentConditionsControl.WithRadioButton = True
            CapturedInaccessibleBodyPartsControl.WithRadioButton = True
            CurrentInaccessibleBodyPartsControl.WithRadioButton = True
            CancelReasonsControl.WithRadioButton = True
            CaptureResultControl.WithRadioButton = True

            PopulateMessages()


        End Sub

        Private Sub PopulateMessages()
            CapturedConditionsControl.HeaderText = Messages.CapturedConditions(UICulture)
            CurrentConditionsControl.HeaderText = Messages.CurrentConditions(UICulture)
            CapturedInaccessibleBodyPartsControl.HeaderText = Messages.CapturedInjuries(UICulture)
            CurrentInaccessibleBodyPartsControl.HeaderText = Messages.CurrentInjuries(UICulture)
        End Sub

        Private Sub CancelReasonsControl_RadioButtonChange(ByVal obj As Object, ByVal e As EventArgs) Handles CancelReasonsControl.RadioButtonChanged
            If CancelReasonsControl.RadioButtonSelected Then
                CapturedConditionsControl.RadioGroupBoxChecked = False
                CapturedInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
                CaptureResultControl.RadioGroupBoxChecked = False
                CurrentConditionsControl.RadioGroupBoxChecked = False
                CurrentInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
            End If

        End Sub
        Private Sub CapturedConditionsControl_RadioButtonChange(ByVal obj As Object, ByVal e As EventArgs) Handles CapturedConditionsControl.RadioButtonChanged
            If CapturedConditionsControl.RadioButtonSelected Then
                CancelReasonsControl.RadioGroupBoxChecked = False
                CapturedInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
                CaptureResultControl.RadioGroupBoxChecked = False
                CurrentConditionsControl.RadioGroupBoxChecked = False
                CurrentInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
            End If
        End Sub
        Private Sub CapturedInaccessibleBodyPartsControl_RadioButtonChange(ByVal obj As Object, ByVal e As EventArgs) Handles CapturedInaccessibleBodyPartsControl.RadioButtonChanged
            If CapturedInaccessibleBodyPartsControl.RadioButtonSelected Then
                CancelReasonsControl.RadioGroupBoxChecked = False
                CapturedConditionsControl.RadioGroupBoxChecked = False
                CaptureResultControl.RadioGroupBoxChecked = False
                CurrentConditionsControl.RadioGroupBoxChecked = False
                CurrentInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
            End If
        End Sub
        Private Sub CaptureResultControl_RadioButtonChange(ByVal obj As Object, ByVal e As EventArgs) Handles CaptureResultControl.RadioButtonChanged
            If CaptureResultControl.RadioButtonSelected Then
                CancelReasonsControl.RadioGroupBoxChecked = False
                CapturedConditionsControl.RadioGroupBoxChecked = False
                CapturedInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
                CurrentConditionsControl.RadioGroupBoxChecked = False
                CurrentInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
            End If
        End Sub
        Private Sub CurrentConditionsControl_RadioButtonChange(ByVal obj As Object, ByVal e As EventArgs) Handles CurrentConditionsControl.RadioButtonChanged
            If CurrentConditionsControl.RadioButtonSelected Then
                CancelReasonsControl.RadioGroupBoxChecked = False
                CapturedConditionsControl.RadioGroupBoxChecked = False
                CapturedInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
                CaptureResultControl.RadioGroupBoxChecked = False
                CurrentInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
            End If
        End Sub
        Private Sub CurrentInaccessibleBodyPartsControl_RadioButtonChange(ByVal obj As Object, ByVal e As EventArgs) Handles CurrentInaccessibleBodyPartsControl.RadioButtonChanged
            If CurrentInaccessibleBodyPartsControl.RadioButtonSelected Then
                CancelReasonsControl.RadioGroupBoxChecked = False
                CapturedConditionsControl.RadioGroupBoxChecked = False
                CapturedInaccessibleBodyPartsControl.RadioGroupBoxChecked = False
                CaptureResultControl.RadioGroupBoxChecked = False
                CurrentConditionsControl.RadioGroupBoxChecked = False
            End If
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

    End Class

End Namespace