'
'  Multimodal Biometric Application Resource Kit (MBARK)
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

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Globalization
Imports System.ComponentModel

Imports Mbark.UI.GlobalUISettings

Namespace Mbark.UI

    Public Class RadioGroupBox
        Inherits System.Windows.Forms.UserControl
        Implements IAutosizable
        Implements IHasUICulture

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
        Private WithEvents OuterPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Friend WithEvents MainGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents FancyHeaderLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        Public WithEvents InnerPanel As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxLabel As System.Windows.Forms.Label
        Protected Friend WithEvents GroupRadioButton As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.OuterPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.MainGroupBox = New System.Windows.Forms.GroupBox
            Me.GroupBoxLabel = New System.Windows.Forms.Label
            Me.GroupRadioButton = New System.Windows.Forms.RadioButton
            Me.InnerPanel = New System.Windows.Forms.Panel
            Me.FancyHeaderLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.OuterPanel.SuspendLayout()
            Me.MainGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'OuterPanel
            '
            Me.OuterPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.OuterPanel.BorderColor = System.Drawing.SystemColors.Highlight
            Me.OuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.OuterPanel.Controls.Add(Me.MainGroupBox)
            Me.OuterPanel.Controls.Add(Me.FancyHeaderLabel)
            Me.OuterPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.OuterPanel.Location = New System.Drawing.Point(0, 0)
            Me.OuterPanel.Name = "OuterPanel"
            Me.OuterPanel.Size = New System.Drawing.Size(239, 155)
            Me.OuterPanel.TabIndex = 0
            '
            'MainGroupBox
            '
            Me.MainGroupBox.AutoSize = True
            Me.MainGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MainGroupBox.Controls.Add(Me.GroupBoxLabel)
            Me.MainGroupBox.Controls.Add(Me.GroupRadioButton)
            Me.MainGroupBox.Controls.Add(Me.InnerPanel)
            Me.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MainGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.MainGroupBox.ForeColor = System.Drawing.SystemColors.ControlText
            Me.MainGroupBox.Location = New System.Drawing.Point(0, 16)
            Me.MainGroupBox.Name = "MainGroupBox"
            Me.MainGroupBox.Size = New System.Drawing.Size(239, 139)
            Me.MainGroupBox.TabIndex = 2
            Me.MainGroupBox.TabStop = False
            Me.MainGroupBox.Text = "XXX"
            '
            'GroupBoxLabel
            '
            Me.GroupBoxLabel.BackColor = System.Drawing.SystemColors.Control
            Me.GroupBoxLabel.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.GroupBoxLabel.Location = New System.Drawing.Point(33, 0)
            Me.GroupBoxLabel.Name = "GroupBoxLabel"
            Me.GroupBoxLabel.Size = New System.Drawing.Size(81, 17)
            Me.GroupBoxLabel.TabIndex = 15
            Me.GroupBoxLabel.Text = "GroupBoxLabel"
            Me.GroupBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'GroupRadioButton
            '
            Me.GroupRadioButton.BackColor = System.Drawing.SystemColors.Control
            Me.GroupRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.GroupRadioButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupRadioButton.ForeColor = System.Drawing.SystemColors.ControlText
            Me.GroupRadioButton.Location = New System.Drawing.Point(164, -4)
            Me.GroupRadioButton.Name = "GroupRadioButton"
            Me.GroupRadioButton.Size = New System.Drawing.Size(17, 22)
            Me.GroupRadioButton.TabIndex = 12
            Me.GroupRadioButton.Text = "GroupRadioButton"
            Me.GroupRadioButton.UseVisualStyleBackColor = False
            '
            'InnerPanel
            '
            Me.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.InnerPanel.Location = New System.Drawing.Point(3, 16)
            Me.InnerPanel.Name = "InnerPanel"
            Me.InnerPanel.Size = New System.Drawing.Size(233, 120)
            Me.InnerPanel.TabIndex = 4
            '
            'FancyHeaderLabel
            '
            Me.FancyHeaderLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, System.Drawing.SystemColors.ActiveCaption, System.Drawing.SystemColors.InactiveCaption)
            Me.FancyHeaderLabel.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.FancyHeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
            Me.FancyHeaderLabel.Dock = System.Windows.Forms.DockStyle.Top
            Me.FancyHeaderLabel.ForeColor = System.Drawing.SystemColors.HighlightText
            Me.FancyHeaderLabel.Location = New System.Drawing.Point(0, 0)
            Me.FancyHeaderLabel.Name = "FancyHeaderLabel"
            Me.FancyHeaderLabel.Size = New System.Drawing.Size(239, 16)
            Me.FancyHeaderLabel.TabIndex = 0
            Me.FancyHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.FancyHeaderLabel.Visible = False
            '
            'RadioGroupBox
            '
            Me.Controls.Add(Me.OuterPanel)
            Me.Name = "RadioGroupBox"
            Me.Size = New System.Drawing.Size(239, 155)
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.OuterPanel.ResumeLayout(False)
            Me.OuterPanel.PerformLayout()
            Me.MainGroupBox.ResumeLayout(False)
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
            SetStyle(Windows.Forms.ControlStyles.SupportsTransparentBackColor, True)
            FancyHeaderLabel.DrawActiveWhenDisabled = True
            AddHandler GroupRadioButton.CheckedChanged, AddressOf RelayCheckBoxChanged
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If Not NearestForm Is Nothing Then
                Dim g As Graphics = NearestForm.CreateGraphics()
                RefreshAutomaticLayout(g)
                g.Dispose()
            End If
            MainGroupBox.Font = Defaults.Fonts.GroupBox


        End Sub


        Public ReadOnly Property OuterPanelDockPadding() As DockPaddingEdges
            Get
                Return OuterPanel.DockPadding
            End Get
        End Property

        Private mWithRadioButton As Boolean
        Public Overridable Property WithRadioButton() As Boolean
            Get
                Return mWithRadioButton
            End Get
            Set(ByVal value As Boolean)
                mWithRadioButton = value
                If value Then
                    InnerPanel.Enabled = GroupRadioButton.Checked
                End If
                If NearestForm IsNot Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
            End Set
        End Property

        <Browsable(False)> Public Property RadioButtonSelected() As Boolean
            Get
                Return GroupRadioButton.Checked
            End Get
            Set(ByVal value As Boolean)
                GroupRadioButton.Checked = value
            End Set
        End Property

        Private mHeaderText As String
        Public Property HeaderText() As String
            Get
                Return mHeaderText
            End Get
            Set(ByVal value As String)
                mHeaderText = value
                If NearestForm IsNot Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
            End Set
        End Property

        Private mHeaderTextColor As Color = Mbark.UI.ThemeInterop.GroupBoxForeColor()
        Public Property HeaderTextColor() As Color
            Get
                Return mHeaderTextColor
            End Get
            Set(ByVal value As Color)
                mHeaderTextColor = value
                If WithFancyHeader Then
                    FancyHeaderLabel.ForeColor = value
                Else
                    MainGroupBox.ForeColor = value
                End If
                If NearestForm IsNot Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
            End Set
        End Property


        Protected Overrides Sub OnVisibleChanged(ByVal e As System.EventArgs)
            MyBase.OnVisibleChanged(e)
            GroupRadioButton.Visible = mWithRadioButton
        End Sub


        Private mRadioButtonIndentation As Integer = 8
        <Browsable(False)> Public Property RadioButtonIndentation() As Integer
            Get
                Return mRadioButtonIndentation
            End Get
            Set(ByVal value As Integer)
                mRadioButtonIndentation = value
            End Set
        End Property

        Private mBaseMinimumSize As Size
        Public Overridable Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout

            If graphics Is Nothing Then Return

            Dim minimumWidth, minimumHeight As Integer

            ' Uncomment the next line for testing control alignment 
            'InnerPanel.BackColor = SystemColors.ControlDark

            If mWithRadioButton Then

                ' Set the MainGroupBox font and text so that the size and margins invisibly adjust appropriately
                With MainGroupBox

                    .ForeColor = SystemColors.Control
                    .Font = Defaults.Fonts.GroupBox

                    ' This is sneaky. We set the autosize to grow only, so that when we make the string empty, it 
                    ' preserves the property margins.
                    '
                    .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
                    .Text = InfrastructureMessages.Messages.HiddenGroupRadioButtonText(UICulture)
                    .Text = String.Empty
                End With

                ' Fontify, color, size, and position the radio button
                With GroupRadioButton

                    .Font = Defaults.Fonts.Regular
                    .Size = GlobalUISettings.ControlSizes.RadioButtonSize

                    ' Align the midpoint of the radio buton with the midpoint of the upper margin
                    Dim x As Integer = RadioButtonIndentation
                    Dim y As Integer = CInt((InnerPanel.Location.Y) / 2.0! - (GlobalUISettings.ControlSizes.RadioButtonSize.Height / 2.0!))

                    .Location = New Point(x, y)
                End With

                ' Fontify, color, size, and position the (fake) group box label
                With GroupBoxLabel
                    .Visible = True
                    .Font = Defaults.Fonts.GroupBox
                    .Text = mHeaderText
                    '.ForeColor = mHeaderTextColor

                    ' We use the label autosize because it *doesn't* take descents into account (which would overlap with the inner panel)
                    GroupBoxLabel.AutoSize = True

                    ' Place the label to the right of the group radio button, at the top of the control
                    .Location = New Point(GroupRadioButton.Location.X + GroupRadioButton.Width, 0)
                End With


                ' Finally, compute the minimum width and height
                minimumHeight = InnerPanel.Location.Y + DockPadding.Top + DockPadding.Bottom
                minimumWidth = Math.Max(0, _
                    Width - InnerPanel.Width + GroupRadioButton.Width + GroupBoxLabel.Width + _
                    UI.GlobalUISettings.UndocumentedPaddingConstants.GroupBoxIndent)
                minimumWidth += DockPadding.Left + DockPadding.Right


            Else

                ' Hide the group radio button and the fake group box label
                Dim noSize As New Size(0, 0)
                GroupRadioButton.Size = noSize
                GroupRadioButton.Visible = False
                GroupBoxLabel.Size = noSize
                GroupBoxLabel.Visible = False
                GroupBoxLabel.Text = String.Empty
                MainGroupBox.Text = mHeaderText
                MainGroupBox.Font = Defaults.Fonts.GroupBox
                minimumHeight = DockPadding.Top + DockPadding.Bottom + UI.AutoHeight.FontHeightInPixels(UICulture, graphics, Defaults.Fonts.GroupBox)
                minimumWidth = Math.Max(0, _
                    UI.StringWidthInPixels(graphics, Defaults.Fonts.GroupBox, MainGroupBox.Text) _
                    + UI.GlobalUISettings.UndocumentedPaddingConstants.GroupBoxIndent)
                minimumWidth += DockPadding.Left + DockPadding.Right

            End If


            If WithFancyHeader Then

                ' Fontify, color, size, and position the 'fancy'  group box label
                With FancyHeaderLabel
                    .Text = mHeaderText
                    .Font = Defaults.Fonts.GroupBox
                    .ForeColor = SystemColors.ActiveCaptionText
                    UI.AutoHeight.FancyLabel(graphics, FancyHeaderLabel)
                End With
                minimumHeight += FancyHeaderLabel.Height

            End If

            ' Only set the minimum size if we are *not* in a child class. Setting it in the base and child class causes
            ' all sort of strange problems.
            '
            mBaseMinimumSize = New Size(minimumWidth, minimumHeight)
            If Me.GetType().Equals(GetType(RadioGroupBox)) Then MinimumSize = mBaseMinimumSize
            Return

        End Sub

        Protected Overridable ReadOnly Property BaseMinimumSize() As Size
            Get
                Return mBaseMinimumSize
            End Get
        End Property

        Public Overridable ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get
                Return MinimumSize.Height
            End Get
        End Property

        Public ReadOnly Property InnerPanelLocation() As Point
            Get
                Dim x As Integer = InnerPanel.Location.X + OuterPanel.Location.X
                Dim y As Integer = InnerPanel.Location.Y + OuterPanel.Location.Y
                Return New Point(x, y)
            End Get
        End Property

        Public Overridable ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get
                Return MinimumSize.Width
            End Get
        End Property

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then
                Dim g As Graphics = NearestForm.CreateGraphics
                RefreshAutomaticLayout(g)
                g.Dispose()
            End If
        End Sub

        Public Event RadioButtonChanged As EventHandler(Of EventArgs)

        Private mRelayCheckBoxLock As New Object
        Private Sub RelayCheckBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            ' Raising events is not thread-safe
            SyncLock mRelayCheckBoxLock
                RaiseEvent RadioButtonChanged(Me, e)
            End SyncLock
        End Sub


        Private Sub GroupRadioButton_Checked(ByVal sender As Object, ByVal e As EventArgs) Handles GroupRadioButton.CheckedChanged
            'If Not WithRadioButton Then Return
            InnerPanel.Enabled = GroupRadioButton.Checked
        End Sub

        Public ReadOnly Property TotalLeftPadding() As Integer
            Get
                Return _
                DockPadding.Left + _
                OuterPanel.DockPadding.Left + _
                InnerPanel.DockPadding.Left + _
                InnerPanel.Location.X
            End Get
        End Property


        Public ReadOnly Property TotalRightPadding() As Integer
            Get
                Return Width - InnerPanel.Width - TotalLeftPadding
            End Get
        End Property

        Public ReadOnly Property TotalTopPadding() As Integer
            Get
                Return _
                    DockPadding.Top + _
                    OuterPanel.DockPadding.Top + _
                    InnerPanel.DockPadding.Top + _
                    InnerPanel.Location.Y
            End Get
        End Property

        Public ReadOnly Property TotalBottomPadding() As Integer
            Get
                Return Height - InnerPanel.Height - TotalTopPadding
            End Get
        End Property

        Public Property RadioGroupBoxChecked() As Boolean
            Get
                Return GroupRadioButton.Checked
            End Get
            Set(ByVal value As Boolean)
                GroupRadioButton.Checked = value
            End Set
        End Property


        Private Sub GroupBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.GroupRadioButton.Checked = True
        End Sub

        Private mWithFancyHeader As Boolean
        Public Property WithFancyHeader() As Boolean
            Get
                Return mWithFancyHeader
            End Get
            Set(ByVal value As Boolean)

                mWithFancyHeader = value
                If mWithFancyHeader Then
                    FancyHeaderLabel.Visible = True
                    FancyHeaderLabel.Text = mHeaderText
                    MainGroupBox.Visible = False
                    If MainGroupBox.Controls.Contains(InnerPanel) Then

                        OuterPanel.Controls.Add(InnerPanel)
                        MainGroupBox.Controls.Remove(InnerPanel)
                        InnerPanel.BringToFront()
                        InnerPanel.Dock = DockStyle.Fill
                        OuterPanel.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                        ' rjm says that for some bizarre reason, the following line causes every inner panel control to stop working!!!
                        'OuterPanel.BorderColor = SystemColors.Highlight
                    End If
                Else
                    FancyHeaderLabel.Visible = False
                    MainGroupBox.Visible = True
                    If OuterPanel.Controls.Contains(InnerPanel) Then
                        OuterPanel.Controls.Remove(InnerPanel)
                        MainGroupBox.Controls.Add(InnerPanel)
                        OuterPanel.BorderStyle = Windows.Forms.BorderStyle.None
                    End If
                End If

                If Not NearestForm Is Nothing Then
                    Dim g As Graphics = NearestForm.CreateGraphics()
                    RefreshAutomaticLayout(g)
                    g.Dispose()
                End If
            End Set
        End Property

    End Class

End Namespace
