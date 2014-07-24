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
Imports Mbark.UI.GlobalUISettings

Imports Mbark.Sensors
Imports Mbark.SensorMessages

Imports SF = Syncfusion.Windows.Forms

Namespace Mbark.Sensors

    Public Class TaskListControl
        Inherits System.Windows.Forms.UserControl
        Implements IAutosizable
        Implements IHasUICulture
        Implements ISensorControlModeChangeConsumer

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
            If InDesignMode(Me) Then Return
            AutoRefreshTimer.Stop()
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents OuterPanel As Syncfusion.Windows.Forms.Tools.GradientPanel
        Friend WithEvents HeaderLabel As Syncfusion.Windows.Forms.Tools.GradientLabel
        Private WithEvents AutoRefreshTimer As System.Windows.Forms.Timer
        Friend WithEvents TaskGrid As Syncfusion.Windows.Forms.Grid.GridControl
        Friend WithEvents TrimTooltip As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TaskListControl))
            Me.OuterPanel = New Syncfusion.Windows.Forms.Tools.GradientPanel
            Me.TaskGrid = New Syncfusion.Windows.Forms.Grid.GridControl
            Me.HeaderLabel = New Syncfusion.Windows.Forms.Tools.GradientLabel
            Me.AutoRefreshTimer = New System.Windows.Forms.Timer(Me.components)
            Me.TrimTooltip = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.OuterPanel.SuspendLayout()
            CType(Me.TaskGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'OuterPanel
            '
            Me.OuterPanel.AccessibleDescription = resources.GetString("OuterPanel.AccessibleDescription")
            Me.OuterPanel.AccessibleName = resources.GetString("OuterPanel.AccessibleName")
            Me.OuterPanel.Anchor = CType(resources.GetObject("OuterPanel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OuterPanel.AutoScroll = CType(resources.GetObject("OuterPanel.AutoScroll"), Boolean)
            Me.OuterPanel.AutoScrollMargin = CType(resources.GetObject("OuterPanel.AutoScrollMargin"), System.Drawing.Size)
            Me.OuterPanel.AutoScrollMinSize = CType(resources.GetObject("OuterPanel.AutoScrollMinSize"), System.Drawing.Size)
            Me.OuterPanel.BackgroundImage = CType(resources.GetObject("OuterPanel.BackgroundImage"), System.Drawing.Image)
            Me.OuterPanel.BorderColor = System.Drawing.SystemColors.Highlight
            Me.OuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.OuterPanel.Controls.Add(Me.TaskGrid)
            Me.OuterPanel.Controls.Add(Me.HeaderLabel)
            Me.OuterPanel.Dock = CType(resources.GetObject("OuterPanel.Dock"), System.Windows.Forms.DockStyle)
            Me.OuterPanel.Enabled = CType(resources.GetObject("OuterPanel.Enabled"), Boolean)
            Me.OuterPanel.Font = CType(resources.GetObject("OuterPanel.Font"), System.Drawing.Font)
            Me.OuterPanel.ImeMode = CType(resources.GetObject("OuterPanel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OuterPanel.Location = CType(resources.GetObject("OuterPanel.Location"), System.Drawing.Point)
            Me.OuterPanel.Name = "OuterPanel"
            Me.OuterPanel.RightToLeft = CType(resources.GetObject("OuterPanel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OuterPanel.Size = CType(resources.GetObject("OuterPanel.Size"), System.Drawing.Size)
            Me.OuterPanel.TabIndex = CType(resources.GetObject("OuterPanel.TabIndex"), Integer)
            Me.OuterPanel.Text = resources.GetString("OuterPanel.Text")
            Me.TrimTooltip.SetToolTip(Me.OuterPanel, resources.GetString("OuterPanel.ToolTip"))
            Me.OuterPanel.Visible = CType(resources.GetObject("OuterPanel.Visible"), Boolean)
            '
            'TaskGrid
            '
            Me.TaskGrid.AccessibleDescription = resources.GetString("TaskGrid.AccessibleDescription")
            Me.TaskGrid.AccessibleName = resources.GetString("TaskGrid.AccessibleName")
            Me.TaskGrid.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.None
            Me.TaskGrid.AllowSelection = CType((Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row Or Syncfusion.Windows.Forms.Grid.GridSelectionFlags.AlphaBlend), Syncfusion.Windows.Forms.Grid.GridSelectionFlags)
            Me.TaskGrid.AlphaBlendSelectionColor = System.Drawing.Color.Transparent
            Me.TaskGrid.Anchor = CType(resources.GetObject("TaskGrid.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.TaskGrid.BackgroundImage = CType(resources.GetObject("TaskGrid.BackgroundImage"), System.Drawing.Image)
            Me.TaskGrid.ColCount = 0
            Me.TaskGrid.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
            Me.TaskGrid.Dock = CType(resources.GetObject("TaskGrid.Dock"), System.Windows.Forms.DockStyle)
            Me.TaskGrid.Enabled = CType(resources.GetObject("TaskGrid.Enabled"), Boolean)
            Me.TaskGrid.Font = CType(resources.GetObject("TaskGrid.Font"), System.Drawing.Font)
            Me.TaskGrid.ImeMode = CType(resources.GetObject("TaskGrid.ImeMode"), System.Windows.Forms.ImeMode)
            Me.TaskGrid.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
            Me.TaskGrid.Location = CType(resources.GetObject("TaskGrid.Location"), System.Drawing.Point)
            Me.TaskGrid.Name = "TaskGrid"
            Me.TaskGrid.RightToLeft = CType(resources.GetObject("TaskGrid.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.TaskGrid.RowCount = 0
            Me.TaskGrid.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.HideAlways
            Me.TaskGrid.Size = CType(resources.GetObject("TaskGrid.Size"), System.Drawing.Size)
            Me.TaskGrid.SmartSizeBox = False
            Me.TaskGrid.TabIndex = CType(resources.GetObject("TaskGrid.TabIndex"), Integer)
            Me.TaskGrid.Text = resources.GetString("TaskGrid.Text")
            Me.TaskGrid.ThemesEnabled = True
            Me.TrimTooltip.SetToolTip(Me.TaskGrid, resources.GetString("TaskGrid.ToolTip"))
            Me.TaskGrid.Visible = CType(resources.GetObject("TaskGrid.Visible"), Boolean)
            '
            'HeaderLabel
            '
            Me.HeaderLabel.AccessibleDescription = resources.GetString("HeaderLabel.AccessibleDescription")
            Me.HeaderLabel.AccessibleName = resources.GetString("HeaderLabel.AccessibleName")
            Me.HeaderLabel.Anchor = CType(resources.GetObject("HeaderLabel.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.HeaderLabel.AutoSize = CType(resources.GetObject("HeaderLabel.AutoSize"), Boolean)
            Me.HeaderLabel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Horizontal, System.Drawing.SystemColors.ActiveCaption, System.Drawing.SystemColors.InactiveCaption)
            Me.HeaderLabel.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
                        Or System.Windows.Forms.Border3DSide.Right) _
                        Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
            Me.HeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
            Me.HeaderLabel.Dock = CType(resources.GetObject("HeaderLabel.Dock"), System.Windows.Forms.DockStyle)
            Me.HeaderLabel.Enabled = CType(resources.GetObject("HeaderLabel.Enabled"), Boolean)
            Me.HeaderLabel.Font = CType(resources.GetObject("HeaderLabel.Font"), System.Drawing.Font)
            Me.HeaderLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.HeaderLabel.Image = CType(resources.GetObject("HeaderLabel.Image"), System.Drawing.Image)
            Me.HeaderLabel.ImageAlign = CType(resources.GetObject("HeaderLabel.ImageAlign"), System.Drawing.ContentAlignment)
            Me.HeaderLabel.ImageIndex = CType(resources.GetObject("HeaderLabel.ImageIndex"), Integer)
            Me.HeaderLabel.ImeMode = CType(resources.GetObject("HeaderLabel.ImeMode"), System.Windows.Forms.ImeMode)
            Me.HeaderLabel.Location = CType(resources.GetObject("HeaderLabel.Location"), System.Drawing.Point)
            Me.HeaderLabel.Name = "HeaderLabel"
            Me.HeaderLabel.RightToLeft = CType(resources.GetObject("HeaderLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.HeaderLabel.Size = CType(resources.GetObject("HeaderLabel.Size"), System.Drawing.Size)
            Me.HeaderLabel.TabIndex = CType(resources.GetObject("HeaderLabel.TabIndex"), Integer)
            Me.HeaderLabel.Text = resources.GetString("HeaderLabel.Text")
            Me.HeaderLabel.TextAlign = CType(resources.GetObject("HeaderLabel.TextAlign"), System.Drawing.ContentAlignment)
            Me.TrimTooltip.SetToolTip(Me.HeaderLabel, resources.GetString("HeaderLabel.ToolTip"))
            Me.HeaderLabel.Visible = CType(resources.GetObject("HeaderLabel.Visible"), Boolean)
            '
            'AutoRefreshTimer
            '
            '
            'TaskListControl
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.Controls.Add(Me.OuterPanel)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.Name = "TaskListControl"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
            Me.TrimTooltip.SetToolTip(Me, resources.GetString("$this.ToolTip"))
            CType(Me.OuterPanel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.OuterPanel.ResumeLayout(False)
            CType(Me.TaskGrid, System.ComponentModel.ISupportInitialize).EndInit()
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

        Private mTaskList As SensorTaskCollection

        Private Const NumberOfGridColumns As Integer = 9

        Private Const TaskNumberColumnIndex As Integer = 1
        Private Const DescriptionColumnIndex As Integer = 2
        Private Const SensorColumnIndex As Integer = 3
        Private Const ConditionColumnIndex As Integer = 4
        Private Const AttemptColumnIndex As Integer = 5
        Private Const DownloadColumnIndex As Integer = 6
        Private Const StatusColumnIndex As Integer = 7
        Private Const ConflictColumnIndex As Integer = 8
        Private Const ViewButtonColumnIndex As Integer = 9

        Private Const NumberOfHeaderColumns As Integer = 1
        Private Const NumberOfHeaderRows As Integer = 1

        Private mColumnWidths(NumberOfGridColumns + 1) As Integer
        Private mTotalColumnWidth As Integer

        ' Column widths (measured in number of characters)
        Private Const TaskNumberColumnWidth As Integer = 3
        Private Const DescriptionColumnWidth As Integer = 12
        Private Const SensorcolumnWidth As Integer = 16

        ' Grid cell types
        Private Const TextBoxCellType As String = "TextBox"
        Private Const ProgressBarCellType As String = "ProgressBar"
        Private Const PushButtonCellType As String = "PushButton"


        Private mTaskProvidingAttemptDetail As SensorTask
        Public Property TaskProvidingAttemptDetail() As SensorTask
            Get
                Return mTaskProvidingAttemptDetail
            End Get
            Set(ByVal value As SensorTask)
                mTaskProvidingAttemptDetail = value
            End Set
        End Property

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return

            ' Find the nearest provider and handle any session mode changes it produces
            SubscribeToParentSensorControlModeChangeEvents(Me, True)

            HeaderLabel.Text = Messages.Tasks(UICulture)

            With TaskGrid

                .ColCount = NumberOfGridColumns
                .ResizeColsBehavior = SF.Grid.GridResizeCellsBehavior.None
                .ResizeRowsBehavior = SF.Grid.GridResizeCellsBehavior.None
                .HScrollBehavior = SF.Grid.GridScrollbarMode.Disabled
                .AllowDragSelectedCols = False
                .AllowDragSelectedRows = False
                .AllowScrollCurrentCellInView = SF.Grid.GridScrollCurrentCellReason.None

                Dim headerRow As Integer = 0

                With .RowStyles(headerRow)
                    .Font = New SF.Grid.GridFontInfo(GlobalUISettings.Defaults.Fonts.Bold)
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, TaskNumberColumnIndex)
                    .Text = InfrastructureMessages.Messages.Hashmark(UICulture)
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, DescriptionColumnIndex)
                    .Text = Messages.Description(UICulture)
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, SensorColumnIndex)
                    .Text = Messages.Sensor(UICulture)
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, ConditionColumnIndex)
                    .Text = Messages.Conditions(UICulture)
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, AttemptColumnIndex)
                    .Text = Messages.Tries(UICulture)
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, StatusColumnIndex)
                    .Text = Messages.Status(UICulture)
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, ConflictColumnIndex)
                    .Text = Messages.Conflicts(UICulture)
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With TaskGrid(headerRow, DownloadColumnIndex)
                    .Text = StringConstants.Space
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                    .CellTipText = "This column may show buttons used for cancelling downloads"
                End With

                With TaskGrid(headerRow, ViewButtonColumnIndex)
                    .Text = StringConstants.Space
                    .WrapText = False
                    .Trimming = StringTrimming.EllipsisCharacter
                    .CellTipText = "Use the buttons in this column to show the detail for a particular task"
                End With

                With .ColStyles(DescriptionColumnIndex)
                    .CellType = TextBoxCellType
                    .VerticalAlignment = SF.Grid.GridVerticalAlignment.Middle
                    .TextAlign = SF.Grid.GridTextAlign.Default
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With .ColStyles(TaskNumberColumnIndex)
                    .CellType = PushButtonCellType
                    .VerticalAlignment = SF.Grid.GridVerticalAlignment.Middle
                    .TextAlign = SF.Grid.GridTextAlign.Default
                End With

                With .ColStyles(ConditionColumnIndex)
                    .CellType = TextBoxCellType
                    .VerticalAlignment = SF.Grid.GridVerticalAlignment.Middle
                    .TextAlign = SF.Grid.GridTextAlign.Default
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With .ColStyles(AttemptColumnIndex)
                    .CellType = TextBoxCellType
                    .VerticalAlignment = SF.Grid.GridVerticalAlignment.Middle
                    .HorizontalAlignment = SF.Grid.GridHorizontalAlignment.Left
                    .TextAlign = SF.Grid.GridTextAlign.Default
                    .Font = New SF.Grid.GridFontInfo(New Font("Wingdings", Defaults.Fonts.Huge.SizeInPoints))
                End With

                With .ColStyles(SensorColumnIndex)
                    .CellType = TextBoxCellType
                    .VerticalAlignment = SF.Grid.GridVerticalAlignment.Middle
                    .TextAlign = SF.Grid.GridTextAlign.Default
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With .ColStyles(StatusColumnIndex)
                    .CellType = ProgressBarCellType
                    .ProgressBar.ProgressValue = 0
                    .VerticalAlignment = SF.Grid.GridVerticalAlignment.Middle
                    .TextAlign = SF.Grid.GridTextAlign.Default
                    .CellAppearance = SF.Grid.GridCellAppearance.Flat
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With .ColStyles(DownloadColumnIndex)
                    .Font = New SF.Grid.GridFontInfo(New Font("Wingdings", Defaults.Fonts.Large.Size))
                    .Trimming = StringTrimming.EllipsisCharacter
                End With

                With .ColStyles(ViewButtonColumnIndex)
                    .CellType = PushButtonCellType
                    .Font = New SF.Grid.GridFontInfo(New Font("Wingdings", Defaults.Fonts.Regular.SizeInPoints))
                    .VerticalAlignment = SF.Grid.GridVerticalAlignment.Middle
                    .TextAlign = SF.Grid.GridTextAlign.Right
                    .Trimming = StringTrimming.EllipsisCharacter

                End With

                .Properties.RowHeaders = False

            End With

            ' Set the column widths (in characters)


            mColumnWidths(TaskNumberColumnIndex) = TaskNumberColumnWidth
            mColumnWidths(DescriptionColumnIndex) = DescriptionColumnWidth
            mColumnWidths(SensorColumnIndex) = SensorcolumnWidth
            mColumnWidths(ConditionColumnIndex) = 12
            mColumnWidths(AttemptColumnIndex) = 5
            mColumnWidths(DownloadColumnIndex) = 2
            mColumnWidths(StatusColumnIndex) = 10
            mColumnWidths(ConflictColumnIndex) = 7
            mColumnWidths(ViewButtonColumnIndex) = 2
            For i As Integer = 1 To mColumnWidths.Length - 1
                mTotalColumnWidth += mColumnWidths(i)
            Next


            RefreshAutomaticLayout(Me.CreateGraphics)
            RefreshTaskList()

            AddHandler TaskGrid.PushButtonClick, AddressOf HandleView_ButtonClick
            AddHandler TaskGrid.PushButtonClick, AddressOf TaskGrid_PushButtonClick
            AddHandler TaskGrid.PushButtonClick, AddressOf HandleDownload_ButtonClick
        End Sub


        Public Event TaskProvidingAttemptDetailChanged As EventHandler(Of EventArgs)
        Public Event RevokeOrRequestDownloadCancellation As EventHandler(Of DownloadEventArgs)

        Private Sub HandleView_ButtonClick(ByVal sender As Object, ByVal e As SF.Grid.GridCellPushButtonClickEventArgs)
            If e.ColIndex <> ViewButtonColumnIndex Then Return
            Dim taskIndex As Integer = e.RowIndex - NumberOfHeaderRows
            TaskProvidingAttemptDetail = mTaskList(taskIndex)
            RaiseEvent TaskProvidingAttemptDetailChanged(Me, New EventArgs)
        End Sub

        Private Sub TaskGrid_PushButtonClick(ByVal sender As Object, ByVal e As SF.Grid.GridCellPushButtonClickEventArgs)
            If e.ColIndex <> TaskNumberColumnIndex Then Return
            Dim taskIndex As Integer = e.RowIndex - NumberOfHeaderRows
            Me.JumpToTask(mTaskList(taskIndex))
        End Sub

        Private Sub HandleDownload_ButtonClick(ByVal sender As Object, ByVal e As SF.Grid.GridCellPushButtonClickEventArgs)
            If e.ColIndex <> DownloadColumnIndex Then Return
            Dim taskIndex As Integer = e.RowIndex - NumberOfHeaderRows
            Dim task As SensorTask = mTaskList(taskIndex)

            If task.DownloadsPaused Then
                ' If the task is already suspended, then resume downloads
                Dim args As New DownloadEventArgs(task, False)
                RaiseEvent RevokeOrRequestDownloadCancellation(Me, args)
            Else
                ' If the task is not suspended, then suspend downloads
                Dim args As New DownloadEventArgs(task, True)
                RaiseEvent RevokeOrRequestDownloadCancellation(Me, args)
            End If

        End Sub


        Private mSelectedRow As Integer = -1


        Public Event StartingTaskSelected As EventHandler(Of TaskSelectedEventArgs)

        Private Function TaskSkipPermitted(ByVal fromTask As SensorTask, ByVal toTask As SensorTask) As Boolean

            If Not SensorControlModeSets.TaskSelectionPermitted.Contains(CurrentSensorControlMode) Then Return False

            ' If we're not skipping *from* anything, then we just care if the destination is activatable
            If fromTask Is Nothing Then Return toTask.IsActivatable

            ' Not allowed to skip to ourselves
            If fromTask Is toTask Then Return False

            ' Not allowed to skip to another task in the same factory (unless that task was skipped)
            If fromTask.OriginatingFactory Is toTask.OriginatingFactory And toTask.Status <> SensorTaskStatus.Skipped Then Return False

            ' Must skip from an active task
            If fromTask.Status <> SensorTaskStatus.Active Then Return False

            ' Must skip to an activatable or skipped task
            If Not toTask.IsActivatable AndAlso toTask.Status <> SensorTaskStatus.Skipped Then Return False

            Return True
        End Function

        Public Sub FinishJumpToTask(ByVal newTask As SensorTask, ByVal wasJustified As Boolean)
            mTaskToJumpTo = Nothing
            If wasJustified AndAlso Not newTask Is Nothing Then SelectTask(mTaskList.IndexOf(newTask))
        End Sub

        Private mTaskToJumpTo As SensorTask
        Public ReadOnly Property TaskToJumpTo() As SensorTask
            Get
                Return mTaskToJumpTo
            End Get
        End Property


        Private Sub JumpToTask(ByVal newTask As SensorTask)

            mTaskToJumpTo = newTask

            Dim jumpFromTask As SensorTask = Nothing
            If Not mNoTaskSelected Then jumpFromTask = TaskList(SelectedTaskIndex)

            If Not TaskSkipPermitted(jumpFromTask, newTask) Then Return
            RaiseEvent StartingTaskSelected(Me, New TaskSelectedEventArgs(jumpFromTask, newTask))

            Return

        End Sub


        Public Property AutoRefreshFrequency() As Integer
            Get
                Return AutoRefreshTimer.Interval
            End Get
            Set(ByVal value As Integer)
                If value = 0 Then
                    AutoRefreshTimer.Enabled = False
                Else
                    AutoRefreshTimer.Interval = value
                    AutoRefreshTimer.Enabled = True
                End If
            End Set
        End Property

        Public ReadOnly Property AutoRefreshTimerIsRunning() As Boolean
            Get
                Return AutoRefreshTimer.Enabled
            End Get
        End Property

#Region "Refresh"

        Public Overrides Sub Refresh()
            RefreshTaskList()
        End Sub


        Private Sub RefreshRow(ByVal taskIndex As Integer)
            RefreshRowImplementation(taskIndex)
        End Sub

        Private Sub RefreshRowColors(ByVal row As Integer, ByVal task As SensorTask)

            With TaskGrid.RowStyles(row)
                If task.Status = SensorTaskStatus.Active Then
                    .BackColor = task.Colors.Active
                    .TextColor = SystemColors.ControlText
                    mSelectedRow = row
                ElseIf task.Status = SensorTaskStatus.Skipped Then
                    .BackColor = task.Colors.Inactive
                    .TextColor = task.Colors.DownloadProgressBar
                Else
                    .BackColor = task.Colors.Inactive
                    .TextColor = SystemColors.ControlText
                End If
            End With
        End Sub
        Private Sub RefreshTaskDescription(ByVal graphics As Graphics, ByVal row As Integer, ByVal task As SensorTask)

            With TaskGrid(row, DescriptionColumnIndex)
                .Text = task.Name(UICulture)
                If .Text = String.Empty Then .Text = task.TargetCategory.ToString
                If task.IsExcess Then .Text = .Text & " (Extra)"
                .ReadOnly = False
                .Enabled = False
            End With
            UI.RefreshTooltip(graphics, TaskGrid, row, DescriptionColumnIndex)

        End Sub
        Private Sub RefreshTaskNumber(ByVal row As Integer, ByVal task As SensorTask)


            'Try

            Dim taskIndex As Integer = mTaskList.IndexOf(task)
            With TaskGrid(row, TaskNumberColumnIndex)

                .Description = (taskIndex + 1).ToString(UICulture)

                Dim fromTask As SensorTask = Nothing
                If SelectedTaskIndex < mTaskList.Count AndAlso Not mNoTaskSelected Then
                    ' We only have a valid 'from' task if the selected task index is valid (we could be refreshing in the middle
                    ' of a strange state) and there is some task that is currently active.
                    '
                    fromTask = mTaskList(SelectedTaskIndex)
                End If

                If TaskSkipPermitted(fromTask, task) Then
                    .TextColor = SystemColors.ControlText
                    .Enabled = True
                    .CellTipText = Messages.ClickToJumpToTaskN(UICulture, taskIndex + 1)
                Else
                    .TextColor = SystemColors.Control
                    .Enabled = False
                    .CellTipText = String.Empty
                End If

            End With
            'Catch ex As Exception
            'Debugger.Break()
            'End Try
        End Sub
        Private Sub RefreshAttemptInfo(ByVal row As Integer, ByVal task As SensorTask)

            ' Attempt
            With TaskGrid(row, AttemptColumnIndex)

                Dim cellWriter As New IO.StringWriter(UICulture)
                Dim tooltipWriter As New IO.StringWriter(UICulture)
                For i As Integer = 0 To task.Attempts.Count - 1

                    If task.Attempts(i).HadCaptureFailure Or task.Attempts(i).HadDownloadFailure Then

                        cellWriter.Write(StringConstants.WingdingsX)
                        tooltipWriter.Write(Messages.AttemptNFailed(UICulture, i + 1))

                    ElseIf task.Attempts(i).IsRejected Then

                        cellWriter.Write(StringConstants.WingdingsThumbsDown)
                        tooltipWriter.Write(Messages.AttemptNRejected(UICulture, i + 1))

                    Else

                        If task.Attempts(i).NeedsDownload Then
                            cellWriter.Write(StringConstants.WingdingsCheck)
                            tooltipWriter.Write(Messages.AttemptNSuccessfulButNotYetDownloaded(UICulture, i + 1))
                        Else
                            cellWriter.Write(StringConstants.WingdingsCheckWithBox)
                            tooltipWriter.Write(Messages.AttemptNSuccessfulAndDownloaded(UICulture, i + 1))
                        End If

                    End If
                    If i <> task.Attempts.Count - 1 Then tooltipWriter.Write(vbCrLf)
                Next

                .Text = cellWriter.ToString
                .CellTipText = tooltipWriter.ToString
            End With
        End Sub
        Private Sub RefreshStatus(ByVal graphics As Graphics, ByVal row As Integer, ByVal task As SensorTask)

            ' Status Column
            With TaskGrid(row, StatusColumnIndex)

                .Text = SensorTaskStatusSupport.ToString(UICulture, task.Status)

                .Enabled = False
                .ProgressBar.ProgressValue = 0
                If task.Status = SensorTaskStatus.Downloading AndAlso _
                   task.Sensor.PercentDownloadedIsMeaningful Then
                    If .CellType <> ProgressBarCellType Then .CellType = ProgressBarCellType
                    With .ProgressBar
                        .Maximum = 100
                        .Minimum = 0
                        .ForeSegments = False
                        .ForeColor = task.Colors.DownloadProgressBar
                        .ProgressOrientation = Orientation.Horizontal
                        .ProgressValue = CInt(task.Sensor.PercentDownloaded * 100)
                    End With
                Else
                    .CellType = TextBoxCellType
                    .CellAppearance = SF.Grid.GridCellAppearance.Flat
                    .Text = SensorTaskStatusSupport.ToString(UICulture, task.Status)
                    .ProgressBar.ProgressValue = 0
                End If

                If task.Status = SensorTaskStatus.Skipped Then
                    .Font.Bold = True
                Else
                    .Font.Bold = False
                End If

            End With
            UI.RefreshTooltip(graphics, TaskGrid, row, StatusColumnIndex)
        End Sub
        Private Sub RefreshConditions(ByVal graphics As Graphics, ByVal row As Integer, ByVal task As SensorTask)
            TaskGrid(row, ConditionColumnIndex).Text = task.Conditions.FriendlyToString(UICulture)
            UI.RefreshTooltip(graphics, TaskGrid, row, ConditionColumnIndex)
        End Sub
        Private Sub RefreshSensorName(ByVal graphics As Graphics, ByVal row As Integer, ByVal task As SensorTask)
            TaskGrid(row, SensorColumnIndex).Text = task.Sensor.FriendlyName()
            UI.RefreshTooltip(graphics, TaskGrid, row, SensorColumnIndex)
        End Sub
        Private Sub RefreshDownloadButton(ByVal row As Integer, ByVal task As SensorTask)
            ' Download button
            With TaskGrid(row, DownloadColumnIndex)

                If task.Status = SensorTaskStatus.Downloading AndAlso task.Sensor.DownloadIsCancelable Then
                    .CellType = PushButtonCellType
                    .Description = StringConstants.WingdingsX
                    .CellAppearance = SF.Grid.GridCellAppearance.Flat
                ElseIf task.Status = SensorTaskStatus.Pending AndAlso task.DownloadsPaused Then
                    .CellType = PushButtonCellType
                    .Description = StringConstants.WingdingsX
                    .CellAppearance = SF.Grid.GridCellAppearance.Sunken
                Else
                    .CellType = TextBoxCellType
                    .CellAppearance = SF.Grid.GridCellAppearance.Flat
                    .Text = StringConstants.Space
                End If

            End With
        End Sub
        Private Sub RefreshConflict(ByVal graphics As Graphics, ByVal row As Integer, ByVal task As SensorTask)
            With TaskGrid(row, ConflictColumnIndex)
                If task.HasUnresolvedConflicts(Me.mCurrentConditionsWire, Me.mCurrentlyInaccessiblePartsWire) Then
                    .Text = Messages.Conflict(UICulture)
                    .TextColor = task.Colors.ConflictTextColor
                    .Font.Bold = True
                ElseIf task.HasOnlyCorrectedConflicts(Me.mCurrentConditionsWire, Me.mCurrentlyInaccessiblePartsWire) Then
                    .Text = Messages.Corrected(UICulture)
                    .TextColor = TaskGrid.ForeColor
                    .Font.Bold = False
                Else
                    .Text = String.Empty
                End If
            End With
            UI.RefreshTooltip(graphics, TaskGrid, row, ConflictColumnIndex)
        End Sub
        Private Sub RefreshViewButton(ByVal taskIndex As Integer, ByVal row As Integer, ByVal task As SensorTask)
            ' View button
            With TaskGrid(row, ViewButtonColumnIndex)

                If TaskProvidingAttemptDetail Is task AndAlso task.Attempts.AttemptsWithThumbnails > 0 Then
                    .CellType = TextBoxCellType
                    .Enabled = True
                    .Text = StringConstants.WingdingsBoldRightArrow
                    .TextAlign = SF.Grid.GridTextAlign.Right
                    .CellTipText = Messages.YouAreCurrentlyViewingTheImagesForThisTask(UICulture)
                ElseIf task.Attempts.AttemptsWithThumbnails > 0 Then
                    .CellType = PushButtonCellType
                    .Description = StringConstants.WingdingsRightArrow
                    .Enabled = True
                    .CellTipText = Messages.ClickToViewCapturedImagesForTaskN(UICulture, taskIndex + 1)
                Else
                    .CellType = TextBoxCellType
                    .Text = String.Empty
                    .Enabled = False
                End If
            End With
        End Sub

        Protected Friend Sub RefreshRowImplementation(ByVal taskIndex As Integer)

            Dim graphics As Graphics = NearestForm.CreateGraphics

            TaskGrid.BeginUpdate()

            Dim row As Integer = taskIndex + NumberOfHeaderRows
            Dim task As SensorTask = mTaskList(taskIndex)

            RefreshRowColors(row, task)
            RefreshTaskDescription(graphics, row, task)
            RefreshTaskNumber(row, task)
            RefreshStatus(graphics, row, task)
            RefreshAttemptInfo(row, task)
            RefreshSensorName(graphics, row, task)
            RefreshConditions(graphics, row, task)
            RefreshDownloadButton(row, task)
            RefreshConflict(graphics, row, task)
            RefreshViewButton(taskIndex, row, task)
            TaskGrid.EndUpdate()

        End Sub

        Private Sub RefreshTaskList()
            SafeInvokeNoArgSub(Me, AddressOf RefreshTaskListImplementation)
        End Sub

        Private mRefreshingTaskList As Boolean
        Private Sub RefreshTaskListImplementation()

            If TaskList Is Nothing Then Return

            ' Don't bother refreshing while we're trying to figure out what to do next
            If SensorControlModeProvider.CurrentSensorControlMode = SensorControlMode.ActivatingTask Then Return

            ' Protected against reentry
            If mRefreshingTaskList Then Return
            mRefreshingTaskList = True

            SuspendLayout()
            TaskGrid.BeginUpdate()
            TaskGrid.RowCount = TaskList.Count
            For i As Integer = 0 To mTaskList.Count - 1
                RefreshRow(i)
            Next

            AdjustColumnWidths()
            TaskGrid.EndUpdate()
            ResumeLayout()
            TaskGrid.Refresh()
            mRefreshingTaskList = False
        End Sub
#End Region


        Private Sub AdjustColumnWidths()

            If NearestForm Is Nothing Then Return
            Dim widthPerChar As Single = TaskGrid.Width * 1.0! / mTotalColumnWidth

            TaskGrid.BeginUpdate()
            For i As Integer = 0 To mColumnWidths.Length - 1
                If mColumnWidths(i) > 0 Then TaskGrid.ColWidths(i) = CInt(widthPerChar * mColumnWidths(i))
            Next
            TaskGrid.EndUpdate()

        End Sub

        Public Sub HandleSensorControlModeChange(ByVal sender As Object, ByVal e As SensorControlModeChangeEventArgs) _
        Implements ISensorControlModeChangeConsumer.HandleSensorControlModeChange
            If e Is Nothing Then Throw New ArgumentNullException("e")
            If e.NewMode = SensorControlMode.StartingNewTaskSet Then mTaskProvidingAttemptDetail = Nothing

            RefreshTaskList()

        End Sub

        Private Sub SelectRow(ByVal rowIndex As Integer)
            ForbidInvokeRequired(Me)

            mSelectedRow = rowIndex
            TaskList(SelectedTaskIndex).Status = SensorTaskStatus.Active
            mNoTaskSelected = False
            RefreshTaskList()

        End Sub

        Private mNoTaskSelected As Boolean = True
        Public Property SelectNoTask() As Boolean
            Get
                Return mNoTaskSelected
            End Get
            Set(ByVal value As Boolean)
                mNoTaskSelected = value
            End Set
        End Property

        Public Sub SelectTask(ByVal task As SensorTask)
            mNoTaskSelected = False
            SelectRow(mTaskList.IndexOf(task) + NumberOfHeaderRows)
        End Sub

        Public Sub SelectTask(ByVal taskIndex As Integer)
            mNoTaskSelected = False
            SelectRow(taskIndex + NumberOfHeaderRows)
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

        Private ReadOnly Property CurrentSensorControlMode() As SensorControlMode
            Get
                Return SensorControlModeProvider.CurrentSensorControlMode
            End Get
        End Property

        Public ReadOnly Property SelectedTaskIndex() As Integer
            Get
                If mNoTaskSelected Then
                    Return -1
                End If
                Return mSelectedRow - NumberOfHeaderRows
            End Get
        End Property


        Public ReadOnly Property TaskList() As SensorTaskCollection
            Get
                Return mTaskList
            End Get
        End Property

        Public Sub WireTaskList(ByVal list As SensorTaskCollection)
            mTaskList = list
            Me.mTaskProvidingAttemptDetail = Nothing
            Me.mTaskToJumpTo = Nothing
        End Sub

        Private mCurrentlyInaccessiblePartsWire As BodyPartCollection
        Public Sub WireCurrentlyInaccessibleParts(ByVal parts As BodyPartCollection)
            mCurrentlyInaccessiblePartsWire = parts
        End Sub

        Private mCurrentConditionsWire As ConditionCollection
        Public Sub WireCurrentConditions(ByVal currentConditions As ConditionCollection)
            mCurrentConditionsWire = currentConditions
        End Sub

        Private Sub AutoRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoRefreshTimer.Tick
            If Not Me.Visible Then Return
            RefreshTaskList()
        End Sub



        Public Sub AutoFont()
            HeaderLabel.Font = GlobalUISettings.Defaults.Fonts.FancyLabel
            TaskGrid.Font = GlobalUISettings.Defaults.Fonts.Regular
        End Sub

        Private mHeightInNumberOfTasks As Integer = 10
        Public Property HeightInNumberOfTasks() As Integer
            Get
                Return mHeightInNumberOfTasks
            End Get
            Set(ByVal value As Integer)
                mHeightInNumberOfTasks = value
            End Set
        End Property

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Private mMinimumSize As New Size
        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout

            AutoFont()
            AdjustColumnWidths()
            For i As Integer = 0 To NumberOfGridColumns
                If i <> ViewButtonColumnIndex AndAlso i <> DownloadColumnIndex Then
                    UI.RefreshTooltip(NearestForm.CreateGraphics, TaskGrid, 0, i)
                End If
            Next

            TaskGrid.Height = TaskGrid.RowHeights(0) * mHeightInNumberOfTasks
            TaskGrid.Refresh()

            AutoHeight.FancyLabel(graphics, HeaderLabel)

            Dim buttonPos As New Point
            buttonPos.X = GlobalUISettings.Defaults.Padding.PanelHorizontal
            buttonPos.Y = HeaderLabel.Height + TaskGrid.Height + GlobalUISettings.Defaults.Padding.PanelVertical


            Dim verticalBorderOffset As Integer = OuterPanel.Height - OuterPanel.DisplayRectangle.Height

            mMinimumSize.Height = _
                            GlobalUISettings.Defaults.Padding.PanelVertical + _
                            verticalBorderOffset

            RefreshTaskList()

            'Me.Size = mMinimumSize

        End Sub

        Public ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get
                Return mMinimumSize.Height
            End Get
        End Property

        Public ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get
                Return mMinimumSize.Width
            End Get
        End Property

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property


#Region "       Automation test     "
        Public Sub SelectSkipTask(ByVal taskNum As Integer)
            'TaskGrid(taskNum, Me.TaskNumberColumnIndex)
            Dim e As New SF.Grid.GridCellPushButtonClickEventArgs(taskNum, TaskNumberColumnIndex)
            'Me.JumpToTask(mTaskList(taskIndex))
            TaskGrid_PushButtonClick(Me, e)

            Dim info As Syncfusion.Windows.Forms.Grid.GridStyleInfo = TaskGrid(taskNum, TaskNumberColumnIndex)

        End Sub
        Public Sub SelectSkipTask(ByVal newtask As SensorTask, ByVal oldtask As SensorTask)
            JumpToTask(newtask)
        End Sub
#End Region
    End Class


    Public Class TaskSelectedEventArgs
        Inherits EventArgs

        Private mNewTask As SensorTask
        Private mOldTask As SensorTask

        Public ReadOnly Property OldTask() As SensorTask
            Get
                Return mOldTask
            End Get
        End Property
        Public ReadOnly Property NewTask() As SensorTask
            Get
                Return mNewTask
            End Get
        End Property
        Public Sub New(ByVal oldTask As SensorTask, ByVal newTask As SensorTask)
            mOldTask = oldTask
            mNewTask = newtask
        End Sub

    End Class

    Public Class DownloadEventArgs
        Inherits EventArgs

        Private mTask As SensorTask
        Private mCancelDownloads As Boolean

        Public ReadOnly Property Task() As SensorTask
            Get
                Return mTask
            End Get
        End Property

        Public ReadOnly Property CancelDownloads() As Boolean
            Get
                Return mCancelDownloads
            End Get
        End Property

        Public Sub New(ByVal task As SensorTask, ByVal suspendDownloads As Boolean)
            mTask = task
            mCancelDownloads = suspendDownloads
        End Sub

    End Class

End Namespace