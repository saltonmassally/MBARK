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

Imports Mbark.UI
Imports Mbark.UI.GlobalUISettings
Imports Mbark.SensorMessages

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Mbark.Sensors

    Public Class ConditionsControl
        Inherits RadioGroupBox
        Implements IHasTabList

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
        Friend WithEvents FlowLayout As Syncfusion.Windows.Forms.Tools.FlowLayout
        Friend WithEvents DisabledLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.FlowLayout = New Syncfusion.Windows.Forms.Tools.FlowLayout(Me.components)
            Me.DisabledLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            CType(Me.FlowLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'InnerPanel
            '
            Me.InnerPanel.Name = "InnerPanel"
            Me.InnerPanel.Size = New System.Drawing.Size(346, 253)
            Me.InnerPanel.TabIndex = 2
            '
            'GroupRadioButton
            '
            Me.GroupRadioButton.Name = "GroupRadioButton"
            Me.GroupRadioButton.TabIndex = 1
            '
            'FlowLayout
            '
            Me.FlowLayout.ContainerControl = Me.InnerPanel
            '
            'DisabledLabel
            '
            Me.DisabledLabel.BackColor = System.Drawing.Color.Black
            Me.DisabledLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.BackwardDiagonal, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlLight)
            Me.DisabledLabel.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.DisabledLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
            Me.DisabledLabel.Location = New System.Drawing.Point(78, 92)
            Me.DisabledLabel.Name = "DisabledLabel"
            Me.DisabledLabel.Size = New System.Drawing.Size(196, 104)
            Me.DisabledLabel.TabIndex = 1
            Me.DisabledLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ConditionsControl
            '
            Me.Controls.Add(Me.DisabledLabel)
            Me.Name = "ConditionsControl"
            Me.Size = New System.Drawing.Size(352, 288)
            Me.Controls.SetChildIndex(Me.DisabledLabel, 0)
            CType(Me.FlowLayout, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mConditionLabels As New Dictionary(Of String, Label)
        Private mConditionControls As New Dictionary(Of String, Control)

        ' No wired task indicates all conditions should be shown
        Private mConditionsWire As ConditionCollection

        Public Sub WireConditions(ByVal conditions As ConditionCollection)
            mConditionsWire = conditions
            ClearControls()
            CreateControls()
            BindToControls(BindingDirection.FromWireToControls)
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Public ReadOnly Property Conditions() As ConditionCollection
            Get
                Return mConditionsWire
            End Get
        End Property

        Private mShowStaticsOnly As Boolean
        Public Property ShowStaticsOnly() As Boolean
            Get
                Return mShowStaticsOnly
            End Get
            Set(ByVal value As Boolean)
                mShowStaticsOnly = value
            End Set
        End Property

        Private Sub ClearControls()
            If Not mConditionLabels Is Nothing Then mConditionLabels.Clear()
            If Not mConditionControls Is Nothing Then mConditionControls.Clear()
            For i As Integer = InnerPanel.Controls.Count - 1 To 0 Step -1
                InnerPanel.Controls(i).Dispose()
            Next
            Me.InnerPanel.Controls.Clear()

        End Sub

        Private Sub CreateControls()

            mConditionLabels.Clear()
            mConditionControls.Clear()

            Dim en As IEnumerator(Of Condition) = mConditionsWire.ConditionsEnumerator
            While en.MoveNext

                Dim condition As Condition = en.Current

                ' Add the label
                Dim l As New Label
                l.Text = condition.Description
                l.Font = GlobalUISettings.Defaults.Fonts.Small
                l.BackColor = InnerPanel.BackColor
                l.ForeColor = SystemColors.ControlText
                Me.InnerPanel.Controls.Add(l)
                mConditionLabels(condition.Name) = l

                ' Add the appropriate control
                If TypeOf condition Is BooleanCondition Then
                    Dim cb As New ComboBox
                    cb.Items.Add(InfrastructureMessages.Messages.No(UICulture))
                    cb.Items.Add(InfrastructureMessages.Messages.Yes(UICulture))
                    cb.Name = condition.Name & "ComboBox"
                    cb.DropDownStyle = ComboBoxStyle.DropDownList
                    Me.InnerPanel.Controls.Add(cb)
                    mConditionControls(condition.Name) = cb
                    AddHandler cb.SelectedIndexChanged, AddressOf HandleValueChange
                End If


            End While

        End Sub

        Private Enum BindingDirection
            FromControlsToWire
            FromWireToControls
        End Enum

        Private mDoingBinding As Boolean

        Friend Sub BindFromWireToControls()
            BindToControls(BindingDirection.FromWireToControls)
        End Sub

        Private Sub BindToControls(ByVal direction As BindingDirection)

            UI.ForbidInvokeRequired(Me)
            mDoingBinding = True
            Dim en As IEnumerator(Of Condition) = mConditionsWire.ConditionsEnumerator
            While en.MoveNext
                If TypeOf en.Current Is BooleanCondition Then

                    Dim bc As BooleanCondition = DirectCast(en.Current, BooleanCondition)
                    Dim combo As ComboBox = DirectCast(mConditionControls(bc.Name), ComboBox)

                    If direction = BindingDirection.FromWireToControls Then
                        ' Bind from the wire to the control
                        If DirectCast(bc.Value, Boolean) = False Then
                            combo.SelectedIndex = 0
                        Else
                            combo.SelectedIndex = 1
                        End If
                        combo.Refresh()
                    Else
                        ' Bind from the control to the wire
                        If combo.SelectedIndex = 0 Then
                            bc.Value = False
                        Else
                            bc.Value = True
                        End If
                    End If

                End If
            End While
            mDoingBinding = False
            Refresh()



        End Sub

        Private Sub HandleValueChange(ByVal sender As Object, ByVal e As EventArgs)
            If Not mDoingBinding Then
                BindToControls(BindingDirection.FromControlsToWire)
            End If
        End Sub


        Private Delegate Sub RefreshDelegate()

        Public Overrides Sub Refresh()
            If InvokeRequired Then
                Me.Invoke(New RefreshDelegate(AddressOf RefreshImplementation))
            Else
                RefreshImplementation()
            End If
        End Sub

        Private Sub RefreshImplementation()

            MyBase.Refresh()

            If mConditionsWire Is Nothing Then Return
            Dim en As IEnumerator(Of Condition) = mConditionsWire.GetConditionEnumerator

            While en.MoveNext
                Dim condition As Condition = DirectCast(en.Current, Condition)
                Dim l As Label = ConditionLabel(condition.Name)
                Dim c As Control = ConditionControl(condition.Name)
                l.Enabled = condition.IsValid
                c.Enabled = condition.IsValid

                If WithRadioButton Then
                    l.Enabled = l.Enabled AndAlso RadioButtonSelected
                    c.Enabled = c.Enabled AndAlso RadioButtonSelected
                    l.Refresh()
                    c.Refresh()
                End If

                Dim bc As BooleanCondition = TryCast(condition, BooleanCondition)
                If bc IsNot Nothing Then
                    Dim cb As ComboBox = DirectCast(c, ComboBox)
                    If DirectCast(bc.Value, Boolean) = False Then cb.SelectedIndex = 0
                    If DirectCast(bc.Value, Boolean) = True Then cb.SelectedIndex = 1
                    'Create Controls Tab List
                    If cb.Enabled Then
                        If Not mTabList Is Nothing AndAlso Not mTabList.Contains(cb) Then
                            mTabList.Add(cb)
                        End If

                    End If
                End If
            End While

            

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
                    DisabledLabel.Text = value
                    If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
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


        Private ReadOnly Property ConditionLabel(ByVal name As String) As Label
            Get
                Return DirectCast(mConditionLabels(name), Label)
            End Get
        End Property


        Private ReadOnly Property ConditionControl(ByVal name As String) As Control
            Get
                Return DirectCast(mConditionControls(name), Control)
            End Get
        End Property

        Public Sub ResetConditionControl()
            Dim en As IEnumerator(Of Condition) = mConditionsWire.GetConditionEnumerator
            Dim names() As String = Nothing
            Dim cnt As Integer = 0
            While en.MoveNext
                ReDim Preserve names(cnt)
                names(cnt) = en.Current.Name
                cnt += 1
            End While

            If Not names Is Nothing Then
                For m As Integer = names.Length - 1 To 0 Step -1
                    Dim c As ComboBox = DirectCast(mConditionControls(names(m)), ComboBox)
                    c.SelectedIndex = 0
                Next
            End If
        End Sub

        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
            MyBase.RefreshAutomaticLayout(graphics)

            SuspendLayout()

            If mConditionLabels Is Nothing Or mConditionControls Is Nothing Then Return

            If mConditionsWire Is Nothing Then Return
            Dim en As IEnumerator(Of Condition) = mConditionsWire.ConditionsEnumerator

            Dim maxControlWidth As Integer = 0
            Dim maxLabelWidth As Integer = 0

            mMinimumHeight = 0
            mMinimumWidth = 0

            Dim totalControlHeight As Integer = 0

            While en.MoveNext
                Dim condition As condition = DirectCast(en.Current, condition)

                Dim l As Label = ConditionLabel(condition.Name)
                Dim c As Control = ConditionControl(condition.Name)

                If Not ShowStaticsOnly OrElse ShowStaticsOnly AndAlso condition.IsStatic Then

                    l.Font = Defaults.Fonts.Small
                    l.BackColor = SystemColors.Control
                    l.TextAlign = ContentAlignment.MiddleRight
                    c.Font = Defaults.Fonts.Small

                    UI.AutoSize.Label(graphics, l)

                    maxLabelWidth = Math.Max(maxLabelWidth, StringWidthInPixels(graphics, l.Font, l.Text) + UndocumentedPaddingConstants.PreventLabelWordWrap)

                    ' Autosize the controls
                    If TypeOf condition Is BooleanCondition Then
                        UI.AutoSize.ComboBox(UICulture, graphics, DirectCast(c, ComboBox))
                    End If
                    maxControlWidth = Math.Max(maxControlWidth, c.Width)

                    ' Bump up the control height in the unlikely event the label is taller
                    c.Height = Math.Max(l.Height, c.Height)

                    totalControlHeight = Math.Max(totalControlHeight, LowerLeft(c).Y)

                    l.Width = InnerPanel.Width - c.Width - UndocumentedPaddingConstants.PreventFlowLayoutWrap
                    l.Visible = True
                    c.Visible = True
                Else
                    l.Visible = False
                    c.Visible = False
                End If

            End While

            mMinimumHeight = totalControlHeight + TotalBottomPadding + TotalTopPadding
            mMinimumWidth = maxControlWidth + maxLabelWidth + TotalLeftPadding + TotalRightPadding

            UI.AutoSize.Label(graphics, DisabledLabel)
            DisabledLabel.Width = CInt(DisabledLabel.Width * 1.2!)
            DisabledLabel.Height = CInt(DisabledLabel.Height * 1.0!)

            Dim disabledLabelX As Integer = CInt(Me.Width / 2.0! - DisabledLabel.Width / 2.0!)
            Dim disabledlabely As Integer = CInt(Me.Height / 2.0! - DisabledLabel.Height / 2.0!)
            DisabledLabel.Location = New Point(disabledLabelX, disabledlabely)


            ResumeLayout()
            RefreshImplementation()

        End Sub

        Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
            MyBase.OnEnabledChanged(e)

            If DisabledLabel.Text = String.Empty Then
                DisabledLabel.Visible = False
            Else
                DisabledLabel.Visible = Not MyBase.Enabled
                DisabledLabel.Enabled = Not MyBase.Enabled
                DisabledLabel.Refresh()
            End If

        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            HeaderText = Messages.SpecialConditions(UICulture)
            DisabledLabel.Font = UI.GlobalUISettings.Defaults.Fonts.Small
            If InDesignMode(Me) Then Return
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Private mMinimumWidth As Integer
        Public Overrides ReadOnly Property MinimumWidth() As Integer
            Get
                Return mMinimumWidth
            End Get
        End Property

        Private mMinimumHeight As Integer
        Public Overrides ReadOnly Property MinimumHeight() As Integer
            Get
                Return mMinimumHeight
            End Get
        End Property


        Private Sub GroupRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupRadioButton.CheckedChanged
            Refresh()
        End Sub

        Private mTabList As New Collection(Of Control)
        Public ReadOnly Property TabList() As Collection(Of Control) Implements IHasTabList.TabList
            Get
                Return mTabList
            End Get
        End Property

#Region "       Automate Test       "
        Public Sub ChangeConditionToYes()
            Dim en As IEnumerator(Of Condition) = mConditionsWire.ConditionsEnumerator
            While en.MoveNext

                Dim condition As Condition = en.Current
                Dim cb As ComboBox = CType(Me.InnerPanel.Controls.Item(InnerPanel.Controls.IndexOfKey(condition.Name & "ComboBox")), ComboBox)

                cb.SelectedIndex = 1
            End While

        End Sub
#End Region
    End Class

End Namespace
