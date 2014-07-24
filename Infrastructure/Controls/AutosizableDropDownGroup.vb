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

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports SF = Syncfusion.Windows.Forms.Tools

Imports Mbark.UI.GlobalUISettings
Imports Mbark.InfrastructureMessages

Namespace Mbark.UI

    Public Class AutosizableDropDownGroup
        Inherits System.Windows.Forms.UserControl
        Implements IAutosizableDropDown
        Implements IHasUICulture

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
        Friend WithEvents mGridBagLayout As Syncfusion.Windows.Forms.Tools.GridBagLayout
        Friend WithEvents MainPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Friend WithEvents HeaderLabel As System.Windows.Forms.Label
        Friend WithEvents LowerPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.mGridBagLayout = New Syncfusion.Windows.Forms.Tools.GridBagLayout(Me.components)
            Me.LowerPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.MainPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.HeaderLabel = New System.Windows.Forms.Label
            CType(Me.mGridBagLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LowerPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MainPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mGridBagLayout
            '
            Me.mGridBagLayout.AutoLayout = False
            Me.mGridBagLayout.ContainerControl = Me.LowerPanel
            '
            'LowerPanel
            '
            Me.LowerPanel.BackColor = System.Drawing.SystemColors.Control
            Me.LowerPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.LowerPanel.BorderColor = System.Drawing.Color.Blue
            Me.LowerPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.LowerPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LowerPanel.Location = New System.Drawing.Point(0, 0)
            Me.LowerPanel.Name = "LowerPanel"
            Me.LowerPanel.Size = New System.Drawing.Size(275, 219)
            Me.LowerPanel.TabIndex = 8
            '
            'MainPanel
            '
            Me.MainPanel.BackColor = System.Drawing.SystemColors.Control
            Me.MainPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo
            Me.MainPanel.Border3DStyle = System.Windows.Forms.Border3DStyle.Etched
            Me.MainPanel.BorderColor = System.Drawing.SystemColors.ControlDark
            Me.MainPanel.Controls.Add(Me.HeaderLabel)
            Me.MainPanel.Controls.Add(Me.LowerPanel)
            Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MainPanel.Location = New System.Drawing.Point(0, 0)
            Me.MainPanel.Name = "MainPanel"
            Me.MainPanel.Size = New System.Drawing.Size(279, 223)
            Me.MainPanel.TabIndex = 8
            '
            'HeaderLabel
            '
            Me.HeaderLabel.BackColor = System.Drawing.SystemColors.ActiveCaption
            Me.HeaderLabel.Dock = System.Windows.Forms.DockStyle.Top
            Me.HeaderLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.HeaderLabel.Location = New System.Drawing.Point(0, 0)
            Me.HeaderLabel.Name = "HeaderLabel"
            Me.HeaderLabel.Size = New System.Drawing.Size(275, 13)
            Me.HeaderLabel.TabIndex = 9
            Me.HeaderLabel.Text = "Label1"
            Me.HeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'AutosizableDropDownGroup
            '
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.Controls.Add(Me.MainPanel)
            Me.Name = "AutosizableDropDownGroup"
            Me.Size = New System.Drawing.Size(279, 223)
            CType(Me.mGridBagLayout, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LowerPanel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MainPanel.ResumeLayout(False)
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
            SetStyle(Mbark.UI.DoubleBufferStyle, True)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return
            AutoColor()
            Dim g As Graphics = NearestForm.CreateGraphics
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(g)
            g.Dispose()
        End Sub

        Private mDropDownEventLock As Object
        Private Sub OriginateDropDownRequest(ByVal sender As System.Object, ByVal e As System.EventArgs)
            mIsCollapsed = Not mIsCollapsed
            RecursivelyRefreshWidthsAndHeights(Me)

            ' Raising events is not thread-safe
            SyncLock mDropDownEventLock
                RaiseEvent DropDownEvent(Me, New DropDownEventArgs(Me, MinimumHeight))
            End SyncLock
        End Sub

        Private mIsCollapsed As Boolean
        Public ReadOnly Property IsCollapsed() As Boolean _
        Implements IAutosizableDropDown.IsCollapsed
            Get
                Return mIsCollapsed
            End Get
        End Property

        Private mHeaderEnabled As Boolean
        Public Property HeaderEnabled() As Boolean
            Get
                Return mHeaderEnabled
            End Get
            Set(ByVal value As Boolean)
                mHeaderEnabled = value
                If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
            End Set
        End Property

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If NearestForm Is Nothing Then Return
            Dim g As Graphics = NearestForm.CreateGraphics
            RefreshAutomaticLayout(g)
            g.Dispose()
        End Sub

        Private mLayoutData As New List(Of AutosizableDropDownLayoutArgs)
        Private mGridBagRowWidths As New List(Of Integer)
        Private mGridBagColHeights As New List(Of Integer)
        'Private mGridBagHeightsAndWidthsAreDirty As Boolean = True
        Private mMaximumRow As Integer = -1
        Private mMaximumColumn As Integer = -1
        Private mMinimumLowerPanelWidth As Integer
        Private mMinimumLowerPanelHeight As Integer
        Private mFillsHorizontally As Boolean
        Private mFillsVertically As Boolean

        Public ReadOnly Property FillsHorizontally() As Boolean
            Get
                RefreshMinimumWidthsAndHeights()
                Return mFillsHorizontally
            End Get
        End Property

        Public ReadOnly Property FillsVertically() As Boolean
            Get
                RefreshMinimumWidthsAndHeights()
                Return mFillsVertically
            End Get
        End Property

        Public ReadOnly Property MinimumRowWidth(ByVal row As Integer) As Integer
            Get
                RefreshMinimumWidthsAndHeights()
                Return mGridBagRowWidths(row)
            End Get
        End Property

        Public ReadOnly Property MinimumColumnHeight(ByVal col As Integer) As Integer
            Get
                RefreshMinimumWidthsAndHeights()
                Return mGridBagColHeights(col)
            End Get
        End Property

        Public ReadOnly Property MinimumLowerPanelWidth() As Integer
            Get
                RefreshMinimumWidthsAndHeights()
                Return mMinimumLowerPanelWidth
            End Get
        End Property

        Public ReadOnly Property MinimumLowerPanelHeight() As Integer _
       Implements IAutosizableDropDown.MinimumLowerPanelHeight
            Get
                RefreshMinimumWidthsAndHeights()
                If IsCollapsed Then Return 0 Else Return mMinimumLowerPanelHeight
            End Get
        End Property

        Public ReadOnly Property HeaderHeight() As Integer _
        Implements IAutosizableDropDown.HeaderHeight
            Get
                If HeaderEnabled Then Return HeaderLabel.Height Else Return 0
            End Get
        End Property

        Public ReadOnly Property LayoutParameters(ByVal index As Integer) As AutosizableDropDownLayoutArgs
            Get
                Return mLayoutData(index)
            End Get
        End Property

        Public ReadOnly Property LayoutParameters() As IList
            Get
                Return mLayoutData
            End Get
        End Property

        Public ReadOnly Property LayoutParameters(ByVal control As Control) As AutosizableDropDownLayoutArgs
            Get
                LayoutParameters = Nothing
                For i As Integer = 0 To mLayoutData.Count - 1
                    If LayoutParameters(i).Control.Equals(control) Then LayoutParameters = LayoutParameters(i)
                Next
            End Get
        End Property

        Public Sub RefreshMinimumWidthsAndHeights()

            If mGridBagRowWidths.Count = 0 Or mGridBagColHeights.Count = 0 Then Return

            ' Clear the existing data
            For r As Integer = 0 To mMaximumRow
                mGridBagRowWidths(r) = 0
            Next
            For c As Integer = 0 To mMaximumColumn
                mGridBagColHeights(c) = 0
            Next

            ' Accumulate the widths and heights
            For i As Integer = 0 To mLayoutData.Count - 1
                With Me.LayoutParameters(i)

                    For r As Integer = .GridPosY To .GridPosY + (.CellSpanY - 1)
                        mGridBagRowWidths(r) = CInt(mGridBagRowWidths(r)) + .MinimumWidth
                    Next r

                    For c As Integer = .GridPosX To .GridPosX + (.CellSpanX - 1)
                        mGridBagColHeights(c) = CInt(mGridBagColHeights(c)) + .MinimumHeight
                    Next

                End With
            Next

            ' Determine the largest minimum width and the largest minimum height
            mMinimumLowerPanelWidth = 0 'DockPadding.Left + DockPadding.Right
            mMinimumLowerPanelHeight = 0 'DockPadding.Top + DockPadding.Bottom
            For r As Integer = 0 To mMaximumRow
                mMinimumLowerPanelWidth = Math.Max(mMinimumLowerPanelWidth, CInt(mGridBagRowWidths(r)))
            Next

            For c As Integer = 0 To mMaximumColumn
                mMinimumLowerPanelHeight = Math.Max(mMinimumLowerPanelHeight, CInt(mGridBagColHeights(c)))
            Next


            'mGridBagHeightsAndWidthsAreDirty = False
        End Sub


        Public Sub RemoveLayout(ByVal layoutParameters As AutosizableDropDownLayoutArgs)
            mLayoutData.Remove(layoutParameters)
        End Sub

        Private mInsideLayout As Boolean
        Public Sub LayoutControl(ByVal layoutParameters As AutosizableDropDownLayoutArgs)

            If layoutParameters Is Nothing Then Throw New ArgumentNullException("layoutParameters")
            If layoutParameters.Control Is Me Then Throw New ArgumentException(Messages.AutosizableDropDownGroupCannotLayoutItself(UICulture))

            If mInsideLayout Then Return
            mInsideLayout = True
            RecursiveSuspendLayout(Me)

            If layoutParameters Is Nothing Then Throw New ArgumentNullException("layoutParameters")

            ' Only add the control and handle the drop down events if it is not
            ' yet part of the container.
            '
            If mLayoutData.IndexOf(layoutParameters) = -1 Then
                mLayoutData.Add(layoutParameters)

                If TypeOf layoutParameters.Control Is AutosizableDropDownGroup Then
                    Dim addg As AutosizableDropDownGroup = DirectCast(layoutParameters.Control, AutosizableDropDownGroup)
                    AddHandler addg.DropDownEvent, AddressOf HandleDropDownEvent
                End If

                ' Check if the control supports Begin/End Init
                Dim initInterface As Type = _
                layoutParameters.Control.GetType.GetInterface(GetType(ISupportInitialize).ToString)
                Dim supportsInit As Boolean = Not initInterface Is Nothing

                If supportsInit Then DirectCast(layoutParameters.Control, ISupportInitialize).BeginInit()
                LowerPanel.Controls.Add(layoutParameters.Control)
                If supportsInit Then DirectCast(layoutParameters.Control, ISupportInitialize).EndInit()

            End If

            With layoutParameters

                ' Update the minimum column and row index
                mMaximumColumn = Math.Max(mMaximumColumn, .GridPosX + (.CellSpanX - 1))
                mMaximumRow = Math.Max(mMaximumRow, .GridPosY + (.CellSpanY - 1))

                While mGridBagRowWidths.Count < mMaximumRow + 1
                    mGridBagRowWidths.Add(0)
                End While

                While mGridBagColHeights.Count < mMaximumColumn + 1
                    mGridBagColHeights.Add(0)
                End While


                mGridBagLayout.GetConstraints(.Control)

                Dim constraints As SF.GridBagConstraints = mGridBagLayout.GetConstraints(.Control)

                constraints.GridPosX = .GridPosX
                constraints.GridPosY = .GridPosY
                constraints.CellSpanX = .CellSpanX
                constraints.CellSpanY = .CellSpanY
                constraints.WeightX = .FillWeightX
                constraints.WeightY = .FillWeightY
                constraints.Anchor = SF.AnchorTypes.NorthEast

                If .FillWeightX > 0 And .FillWeightY > 0 Then
                    constraints.Fill = SF.FillType.Both
                    mFillsVertically = True
                    mFillsHorizontally = True
                ElseIf .FillWeightX > 0 And .FillWeightY = 0 Then
                    constraints.Fill = SF.FillType.Horizontal
                    mFillsHorizontally = True
                ElseIf .FillWeightX = 0 And .FillWeightY > 0 Then
                    constraints.Fill = SF.FillType.Vertical
                    mFillsVertically = True
                Else
                    constraints.Fill = SF.FillType.None
                End If

                mGridBagLayout.SetConstraints(.Control, constraints)

                Dim size As New Size(.MinimumWidth, .MinimumHeight)
                mGridBagLayout.SetMinimumSize(.Control, size)
                mGridBagLayout.SetPreferredSize(.Control, size)


            End With




            RecursiveResumeLayout(Me)

            mInsideLayout = False

        End Sub

        Private mHandleDropDownEventLock As Object
        Private Sub HandleDropDownEvent(ByVal sender As Object, ByVal e As DropDownEventArgs)

            OnDropDownEvent(e)

            If e Is Nothing Then Throw New ArgumentNullException("e")

            ' If there's a collapsed/expanded region, updating the minimum sizes will take this into account
            Dim g As Graphics = NearestForm.CreateGraphics
            UpdateMinimumSizeForChildren(g)
            RecursivelyRefreshWidthsAndHeights(Me)

            ' Raising events is not thread-safe
            SyncLock mHandleDropDownEventLock
                RaiseEvent DropDownEvent(Me, New DropDownEventArgs(e.EventOriginatorAsDropDown, MinimumHeight))
            End SyncLock

            If FindParentControlsOfType(Me, GetType(AutosizableDropDownGroup)).Count = 0 Then
                RefreshAutomaticLayout(g)
            End If
            g.Dispose()



        End Sub

        Protected Overridable Sub OnDropDownEvent(ByVal e As DropDownEventArgs)
            ' Intended for override
        End Sub

        Public Event DropDownEvent As EventHandler(Of DropDownEventArgs) Implements IAutosizableDropDown.DropDownEvent

        Public ReadOnly Property MinimumWidth() As Integer _
        Implements IAutosizable.MinimumWidth
            Get
                Return MinimumLowerPanelWidth + DockPadding.Right + DockPadding.Left
            End Get
        End Property

        Public ReadOnly Property MinimumHeight() As Integer _
        Implements IAutosizable.MinimumHeight
            Get
                Dim rootPadding As Integer = DockPadding.Top + DockPadding.Bottom
                Dim lowerPadding As Integer = LowerPanel.DockPadding.Top + LowerPanel.DockPadding.Bottom
                Dim mainPadding As Integer = MainPanel.DockPadding.Top + MainPanel.DockPadding.Bottom
                Dim clientPadding As Integer = Math.Abs(Height - ClientRectangle.Height)
                Dim decPadding As Integer = Defaults.DataEntryComponentPadding.Top + Defaults.DataEntryComponentPadding.Bottom
                MinimumHeight = MinimumLowerPanelHeight + HeaderLabel.Height + rootPadding + lowerPadding + mainPadding + clientPadding + decPadding
            End Get
        End Property

        Private mHeaderText As String
        Public Property HeaderText() As String
            Get
                Return mHeaderText
            End Get
            Set(ByVal value As String)
                mHeaderText = value
            End Set
        End Property

        ' Useful for debugging!
        'Public Overloads Sub OnPaint(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        '    For i As Integer = 0 To Me.LayoutParameters.Count - 1
        '        If TypeOf LayoutParameters(i).Control Is Label Then
        '            Dim l As Label = DirectCast(LayoutParameters(i).Control, Label)
        '            l.Text = l.Width & " " & l.Height
        '        End If
        '    Next
        '    HeaderLabel.Text = MinimumWidth & ", " & MinimumHeight
        'End Sub

        Friend Sub AutoColor()


            Static LightBackgroundColor As Color = SystemColors.ControlLight
            Static DarkBackgroundColor As Color = SystemColors.Control

            Static TopBackgroundBrush As Syncfusion.Drawing.BrushInfo = _
                New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, _
                LightBackgroundColor, DarkBackgroundColor)

            Static BottomBackgroundBrush As Syncfusion.Drawing.BrushInfo = _
                New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, _
                DarkBackgroundColor, LightBackgroundColor)

            Static BackgroundSolid As Syncfusion.Drawing.BrushInfo = _
                New Syncfusion.Drawing.BrushInfo(SystemColors.Control)

            If HeaderEnabled Then
                HeaderLabel.ForeColor = SystemColors.Highlight
                HeaderLabel.BackColor = SystemColors.ActiveCaption
                LowerPanel.BackgroundColor = BottomBackgroundBrush
            Else
                BackColor = SystemColors.Control
                LowerPanel.BackgroundColor = BackgroundSolid
            End If


        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As Graphics) Implements IAutosizable.RefreshAutomaticLayout
            ' We should refresh these no matter what
            RefreshHeaderAndLowerPanelHeights(graphics)

            LayoutContainerNow(graphics)
            RecursivelyRefreshWidthsAndHeights(Me)
            UpdateMinimumSizeForChildren(graphics)


            If FindParentControlsOfType(Me, GetType(AutosizableDropDownGroup)).Count = 0 Then
                RecursivelyLayoutContainer(Me, graphics)
            End If

        End Sub

        Private Sub UpdateMinimumSizeForChildren(ByVal graphics As Graphics)
            ' Update the minimum widths and heights for children that are also autosizeable
            For i As Integer = 0 To mLayoutData.Count - 1

                Dim layout As AutosizableDropDownLayoutArgs = LayoutParameters(i)

                Dim isAutosizable As Boolean = _
                    Not layout.Control.GetType.GetInterface(GetType(IAutosizable).ToString) Is Nothing

                If isAutosizable Then
                    Dim autosizable As IAutosizable = DirectCast(layout.Control, IAutosizable)
                    autosizable.RefreshAutomaticLayout(graphics)
                    LayoutParameters(i).MinimumHeight = autosizable.MinimumHeight
                    LayoutParameters(i).MinimumWidth = autosizable.MinimumWidth
                    LayoutControl(LayoutParameters(i))
                End If
            Next
        End Sub
        Public Sub LayoutContainerNow(ByVal graphics As Graphics)

            RefreshHeaderAndLowerPanelHeights(graphics)

            mGridBagLayout.LayoutContainer()

        End Sub

        Private Sub RefreshHeaderAndLowerPanelHeights(ByVal graphics As Graphics)
            If mHeaderEnabled Then

                HeaderLabel.Font = Defaults.Fonts.FieldGroupHeader
                HeaderLabel.Text = HeaderText

                If IsCollapsed Then
                    HeaderLabel.Text = mHeaderText & Messages.Ellipsis(UICulture)
                    LowerPanel.Height = 0
                Else
                    LowerPanel.Height = Height - HeaderLabel.Height - DockPadding.Top - DockPadding.Bottom
                    HeaderLabel.Text = mHeaderText
                End If
                Dim headerStringHeight As Integer = StringHeightInPixels(graphics, HeaderLabel.Font, HeaderText)
                HeaderLabel.Height = headerStringHeight
                HeaderLabel.Width = Width - DockPadding.Left - DockPadding.Right

            Else
                HeaderLabel.Height = 0
                MainPanel.BorderStyle = Windows.Forms.BorderStyle.None
                LowerPanel.BorderStyle = Windows.Forms.BorderStyle.None
            End If
        End Sub
        Private Sub RecursivelyRefreshWidthsAndHeights(ByVal start As AutosizableDropDownGroup)

            For i As Integer = 0 To start.mLayoutData.Count - 1
                Dim layout As AutosizableDropDownLayoutArgs = start.LayoutParameters(i)
                Dim control As Control = layout.Control
                Dim isAutosizableDropDown As Boolean = TypeOf control Is AutosizableDropDownGroup
                If isAutosizableDropDown Then
                    Dim autosizable As AutosizableDropDownGroup = DirectCast(layout.Control, AutosizableDropDownGroup)
                    RecursivelyRefreshWidthsAndHeights(autosizable)
                End If
            Next

            start.RefreshMinimumWidthsAndHeights()

        End Sub

        Private Sub RecursivelyLayoutContainer(ByVal start As AutosizableDropDownGroup, ByVal graphics As Graphics)

            'mbarkdebugger.ConsoleWriteLine("Laying out container " & start.Name)
            start.LayoutContainerNow(graphics)

            ' Update the minimum widths and heights for children that are also autosizeable
            For i As Integer = 0 To start.mLayoutData.Count - 1
                Dim layout As AutosizableDropDownLayoutArgs = start.LayoutParameters(i)
                Dim control As Control = layout.Control
                Dim isAutosizableDropDown As Boolean = TypeOf control Is AutosizableDropDownGroup
                If isAutosizableDropDown Then
                    Dim autosizable As AutosizableDropDownGroup = DirectCast(layout.Control, AutosizableDropDownGroup)
                    RecursivelyLayoutContainer(autosizable, graphics)
                End If
            Next

        End Sub


        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements IAutosizable.NearestForm
            Get
                If FindNearestForm(Me) Is Nothing Then Return Nothing Else Return FindNearestForm(Me)
            End Get
        End Property

        <Browsable(False)> Public Property LowerPanelVisible() As Boolean
            Get
                Return LowerPanel.Visible
            End Get
            Set(ByVal value As Boolean)
                LowerPanel.Visible = value
                LowerPanel.Refresh()
            End Set
        End Property


    End Class


    ' -------




End Namespace
