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
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Xml.Serialization
Imports System.Windows.Forms

Imports SF = Syncfusion.Windows.Forms

Imports Mbark
Imports Mbark.UI
Imports Mbark.Threading
Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Class BaseSensorController
        Inherits Mbark.UI.BaseForm
        Implements ISensorControlModeProvider
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

        Friend WithEvents MainFrameBarManager As Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager
        Friend WithEvents StateStatusBar As Syncfusion.Windows.Forms.Tools.StatusBarAdvPanel
        Friend WithEvents TimeStatusBar As Syncfusion.Windows.Forms.Tools.StatusBarAdvPanel
        Friend WithEvents StatusBar As Syncfusion.Windows.Forms.Tools.StatusBarAdv
        Friend WithEvents MainBar As Syncfusion.Windows.Forms.Tools.XPMenus.Bar
        Protected Friend WithEvents ExitBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents SessionParentBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem
        Friend WithEvents AdvancedParentBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem
        Friend WithEvents AboutBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents SelectAssistantBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.ListBarItem
        Friend WithEvents CancellationIsAttemptBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents ShortCircuitConflictAnalysisBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents TimeoutsAreAttemptsBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents ResetCorruptSensorsBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents StartupTimer As System.Windows.Forms.Timer
        Friend WithEvents FontsBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents AttemptEditorCascadesChangesBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents PercentCompleteBar As Syncfusion.Windows.Forms.Tools.ProgressBarAdv
        Friend WithEvents PercentCompleteToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents SkippingDeactivatesMultipleTasksBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents AlwaysCheckOutstandingConflictBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents TimeoutAlwaysPromptForDetailBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents ErrorCountToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents LoadSessionBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents DemoModeBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents SaveSessionBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents OpenSessionFileDialog As System.Windows.Forms.OpenFileDialog
        Friend WithEvents SaveSessionFileDialog As System.Windows.Forms.SaveFileDialog
        Friend WithEvents TaskDefinitionFileBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents TaskDefinitionFileDialog As System.Windows.Forms.OpenFileDialog
        Friend WithEvents DeleteImagesOnTaskSetCompletionItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents SensorSettingBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents ErrorCountStatusBar As Syncfusion.Windows.Forms.Tools.StatusBarAdvPanel
        Friend WithEvents MainPanel As Mbark.UI.AutosizableDropDownGroup
        Friend WithEvents CrashNowBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        Friend WithEvents PassiveSensorsAutoStartBarItem As Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseSensorController))
            Me.StatusBar = New Syncfusion.Windows.Forms.Tools.StatusBarAdv
            Me.PercentCompleteBar = New Syncfusion.Windows.Forms.Tools.ProgressBarAdv
            Me.TimeStatusBar = New Syncfusion.Windows.Forms.Tools.StatusBarAdvPanel
            Me.ErrorCountStatusBar = New Syncfusion.Windows.Forms.Tools.StatusBarAdvPanel
            Me.StateStatusBar = New Syncfusion.Windows.Forms.Tools.StatusBarAdvPanel
            Me.MainFrameBarManager = New Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(Me)
            Me.MainBar = New Syncfusion.Windows.Forms.Tools.XPMenus.Bar(Me.MainFrameBarManager, "MainToolbar")
            Me.SessionParentBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem
            Me.SelectAssistantBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.ListBarItem
            Me.ExitBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.AdvancedParentBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem
            Me.TaskDefinitionFileBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.LoadSessionBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.SaveSessionBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.AlwaysCheckOutstandingConflictBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.CancellationIsAttemptBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.ResetCorruptSensorsBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.DemoModeBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.PassiveSensorsAutoStartBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.SkippingDeactivatesMultipleTasksBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.TimeoutsAreAttemptsBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.TimeoutAlwaysPromptForDetailBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.CrashNowBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.AboutBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.AttemptEditorCascadesChangesBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.ShortCircuitConflictAnalysisBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.FontsBarItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.DeleteImagesOnTaskSetCompletionItem = New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem
            Me.StartupTimer = New System.Windows.Forms.Timer(Me.components)
            Me.PercentCompleteToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.ErrorCountToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.OpenSessionFileDialog = New System.Windows.Forms.OpenFileDialog
            Me.SaveSessionFileDialog = New System.Windows.Forms.SaveFileDialog
            Me.TaskDefinitionFileDialog = New System.Windows.Forms.OpenFileDialog
            Me.MainPanel = New Mbark.UI.AutosizableDropDownGroup
            CType(Me.StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.StatusBar.SuspendLayout()
            CType(Me.PercentCompleteBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TimeStatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorCountStatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.StateStatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MainFrameBarManager, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'StatusBar
            '
            Me.StatusBar.BackColor = System.Drawing.SystemColors.Control
            Me.StatusBar.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.StatusBar.BorderColor = System.Drawing.SystemColors.ControlDark
            Me.StatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.StatusBar.Controls.Add(Me.PercentCompleteBar)
            Me.StatusBar.Controls.Add(Me.TimeStatusBar)
            Me.StatusBar.Controls.Add(Me.ErrorCountStatusBar)
            Me.StatusBar.Controls.Add(Me.StateStatusBar)
            Me.StatusBar.CustomLayoutBounds = New System.Drawing.Rectangle(0, 0, 0, 0)
            Me.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.StatusBar.Location = New System.Drawing.Point(0, 542)
            Me.StatusBar.Name = "StatusBar"
            Me.StatusBar.Padding = New System.Windows.Forms.Padding(3)
            Me.StatusBar.Size = New System.Drawing.Size(792, 24)
            Me.StatusBar.SizingGrip = False
            Me.StatusBar.Spacing = New System.Drawing.Size(2, 2)
            Me.StatusBar.TabIndex = 1
            Me.StatusBar.ThemesEnabled = True
            '
            'PercentCompleteBar
            '
            Me.PercentCompleteBar.BackGradientEndColor = System.Drawing.Color.White
            Me.PercentCompleteBar.BackGradientStartColor = System.Drawing.Color.LightGray
            Me.PercentCompleteBar.BackMultipleColors = New System.Drawing.Color() {System.Drawing.Color.Empty}
            Me.PercentCompleteBar.BackSegments = False
            Me.PercentCompleteBar.BackTubeEndColor = System.Drawing.Color.White
            Me.PercentCompleteBar.BackTubeStartColor = System.Drawing.Color.LightGray
            Me.PercentCompleteBar.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
            Me.PercentCompleteBar.BorderColor = System.Drawing.SystemColors.ControlDark
            Me.PercentCompleteBar.CustomWaitingRender = False
            Me.PercentCompleteBar.FontColor = System.Drawing.Color.White
            Me.PercentCompleteBar.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.PercentCompleteBar.ForegroundImage = Nothing
            Me.PercentCompleteBar.ForeSegments = False
            Me.PercentCompleteBar.GradientEndColor = System.Drawing.SystemColors.ActiveCaption
            Me.PercentCompleteBar.GradientStartColor = System.Drawing.SystemColors.InactiveCaption
            Me.PercentCompleteBar.Location = New System.Drawing.Point(0, 2)
            Me.PercentCompleteBar.Maximum = 1
            Me.PercentCompleteBar.MultipleColors = New System.Drawing.Color() {System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.InactiveCaption, System.Drawing.SystemColors.InactiveCaptionText}
            Me.PercentCompleteBar.Name = "PercentCompleteBar"
            Me.PercentCompleteBar.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Tube
            Me.PercentCompleteBar.SegmentWidth = 1
            Me.PercentCompleteBar.Size = New System.Drawing.Size(80, 18)
            Me.PercentCompleteBar.TabIndex = 0
            Me.PercentCompleteBar.ThemesEnabled = False
            Me.PercentCompleteBar.TubeEndColor = System.Drawing.SystemColors.InactiveCaption
            Me.PercentCompleteBar.TubeStartColor = System.Drawing.SystemColors.ActiveCaption
            Me.PercentCompleteBar.Value = 0
            Me.PercentCompleteBar.WaitingGradientWidth = 400
            '
            'TimeStatusBar
            '
            Me.TimeStatusBar.BackColor = System.Drawing.SystemColors.Control
            Me.TimeStatusBar.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.TimeStatusBar.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
            Me.TimeStatusBar.BorderColor = System.Drawing.SystemColors.ControlDark
            Me.TimeStatusBar.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None
            Me.TimeStatusBar.Location = New System.Drawing.Point(82, 2)
            Me.TimeStatusBar.Margin = New System.Windows.Forms.Padding(0)
            Me.TimeStatusBar.Name = "TimeStatusBar"
            Me.TimeStatusBar.PanelType = Syncfusion.Windows.Forms.Tools.StatusBarAdvPanelType.LongTime
            Me.TimeStatusBar.Size = New System.Drawing.Size(94, 18)
            Me.TimeStatusBar.TabIndex = 1
            Me.TimeStatusBar.Text = Nothing
            Me.TimeStatusBar.ThemesEnabled = True
            Me.TimeStatusBar.ToolTip = "This is the current time. Right now."
            '
            'ErrorCountStatusBar
            '
            Me.ErrorCountStatusBar.BackColor = System.Drawing.SystemColors.Control
            Me.ErrorCountStatusBar.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.ErrorCountStatusBar.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
            Me.ErrorCountStatusBar.BorderColor = System.Drawing.SystemColors.ControlDark
            Me.ErrorCountStatusBar.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None
            Me.ErrorCountStatusBar.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.ErrorCountStatusBar.Location = New System.Drawing.Point(178, 2)
            Me.ErrorCountStatusBar.Margin = New System.Windows.Forms.Padding(0)
            Me.ErrorCountStatusBar.Name = "ErrorCountStatusBar"
            Me.ErrorCountStatusBar.Size = New System.Drawing.Size(86, 18)
            Me.ErrorCountStatusBar.TabIndex = 2
            Me.ErrorCountStatusBar.Text = Nothing
            Me.ErrorCountStatusBar.ThemesEnabled = True
            '
            'StateStatusBar
            '
            Me.StateStatusBar.Alignment = System.Windows.Forms.HorizontalAlignment.Left
            Me.StateStatusBar.BackColor = System.Drawing.SystemColors.Control
            Me.StateStatusBar.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control)
            Me.StateStatusBar.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
            Me.StateStatusBar.BorderColor = System.Drawing.SystemColors.ControlDark
            Me.StateStatusBar.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None
            Me.StateStatusBar.HAlign = Syncfusion.Windows.Forms.Tools.HorzFlowAlign.Justify
            Me.StateStatusBar.Location = New System.Drawing.Point(266, 2)
            Me.StateStatusBar.Margin = New System.Windows.Forms.Padding(0)
            Me.StateStatusBar.Name = "StateStatusBar"
            Me.StateStatusBar.PreferredSize = New System.Drawing.Size(147, 20)
            Me.StateStatusBar.Size = New System.Drawing.Size(517, 18)
            Me.StateStatusBar.TabIndex = 3
            Me.StateStatusBar.Text = Nothing
            Me.StateStatusBar.ThemesEnabled = True
            '
            'MainFrameBarManager
            '
            Me.MainFrameBarManager.BarPositionInfo = CType(resources.GetObject("MainFrameBarManager.BarPositionInfo"), System.IO.MemoryStream)
            Me.MainFrameBarManager.Bars.Add(Me.MainBar)
            Me.MainFrameBarManager.Categories.Add("Session")
            Me.MainFrameBarManager.CategoriesToIgnoreInCustDialog.AddRange(New Integer() {1})
            Me.MainFrameBarManager.CurrentBaseFormType = ""
            Me.MainFrameBarManager.EnableCustomizing = False
            Me.MainFrameBarManager.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MainFrameBarManager.Form = Me
            Me.MainFrameBarManager.Items.AddRange(New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem() {Me.AboutBarItem, Me.AdvancedParentBarItem, Me.AlwaysCheckOutstandingConflictBarItem, Me.AttemptEditorCascadesChangesBarItem, Me.CancellationIsAttemptBarItem, Me.ShortCircuitConflictAnalysisBarItem, Me.ResetCorruptSensorsBarItem, Me.ExitBarItem, Me.FontsBarItem, Me.LoadSessionBarItem, Me.SaveSessionBarItem, Me.DemoModeBarItem, Me.SelectAssistantBarItem, Me.DeleteImagesOnTaskSetCompletionItem, Me.SkippingDeactivatesMultipleTasksBarItem, Me.SessionParentBarItem, Me.TaskDefinitionFileBarItem, Me.TimeoutAlwaysPromptForDetailBarItem, Me.TimeoutsAreAttemptsBarItem, Me.PassiveSensorsAutoStartBarItem, Me.CrashNowBarItem})
            Me.MainFrameBarManager.ResetCustomization = False
            '
            'MainBar
            '
            Me.MainBar.BarName = "MainToolbar"
            Me.MainBar.BarStyle = CType((((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.IsMainMenu Or Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.RotateWhenVertical) _
                        Or Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.Visible) _
                        Or Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.UseWholeRow), Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle)
            Me.MainBar.Caption = "MainToolbar"
            Me.MainBar.Items.AddRange(New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem() {Me.SessionParentBarItem, Me.AdvancedParentBarItem})
            Me.MainBar.Manager = Me.MainFrameBarManager
            '
            'SessionParentBarItem
            '
            Me.SessionParentBarItem.CategoryIndex = 0
            Me.SessionParentBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SessionParentBarItem.ID = "Session"
            Me.SessionParentBarItem.Items.AddRange(New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem() {Me.SelectAssistantBarItem, Me.ExitBarItem})
            Me.SessionParentBarItem.SeparatorIndices.AddRange(New Integer() {1})
            Me.SessionParentBarItem.ShortcutText = ""
            Me.SessionParentBarItem.Text = "Sess&ion"
            '
            'SelectAssistantBarItem
            '
            Me.SelectAssistantBarItem.CategoryIndex = 0
            Me.SelectAssistantBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SelectAssistantBarItem.ID = "Select assistant..."
            Me.SelectAssistantBarItem.ShortcutText = ""
            Me.SelectAssistantBarItem.Text = "S&elect assistant..."
            '
            'ExitBarItem
            '
            Me.ExitBarItem.CategoryIndex = 0
            Me.ExitBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ExitBarItem.ID = "Exit"
            Me.ExitBarItem.ImageIndex = 2
            Me.ExitBarItem.PaintStyle = Syncfusion.Windows.Forms.Tools.XPMenus.PaintStyle.ImageAndText
            Me.ExitBarItem.ShortcutText = ""
            Me.ExitBarItem.Text = "E&xit"
            '
            'AdvancedParentBarItem
            '
            Me.AdvancedParentBarItem.CategoryIndex = 0
            Me.AdvancedParentBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AdvancedParentBarItem.ID = "Advanced"
            Me.AdvancedParentBarItem.Items.AddRange(New Syncfusion.Windows.Forms.Tools.XPMenus.BarItem() {Me.TaskDefinitionFileBarItem, Me.LoadSessionBarItem, Me.SaveSessionBarItem, Me.AlwaysCheckOutstandingConflictBarItem, Me.CancellationIsAttemptBarItem, Me.ResetCorruptSensorsBarItem, Me.DemoModeBarItem, Me.PassiveSensorsAutoStartBarItem, Me.SkippingDeactivatesMultipleTasksBarItem, Me.TimeoutsAreAttemptsBarItem, Me.TimeoutAlwaysPromptForDetailBarItem, Me.CrashNowBarItem})
            Me.AdvancedParentBarItem.SeparatorIndices.AddRange(New Integer() {0, 1, 3, 11})
            Me.AdvancedParentBarItem.ShortcutText = ""
            Me.AdvancedParentBarItem.Text = "&Advanced"
            Me.AdvancedParentBarItem.Visible = False
            '
            'TaskDefinitionFileBarItem
            '
            Me.TaskDefinitionFileBarItem.CategoryIndex = 0
            Me.TaskDefinitionFileBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TaskDefinitionFileBarItem.ID = "TaskDefitionFileBaritem"
            Me.TaskDefinitionFileBarItem.ShortcutText = ""
            Me.TaskDefinitionFileBarItem.Text = "Startup &tasks..."
            '
            'LoadSessionBarItem
            '
            Me.LoadSessionBarItem.CategoryIndex = 0
            Me.LoadSessionBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LoadSessionBarItem.ID = "Load session (now)..."
            Me.LoadSessionBarItem.ImageIndex = 1
            Me.LoadSessionBarItem.ShortcutText = ""
            Me.LoadSessionBarItem.Text = "&Load session (now)..."
            '
            'SaveSessionBarItem
            '
            Me.SaveSessionBarItem.CategoryIndex = 0
            Me.SaveSessionBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SaveSessionBarItem.ID = "Save session..."
            Me.SaveSessionBarItem.ImageIndex = 0
            Me.SaveSessionBarItem.PaintStyle = Syncfusion.Windows.Forms.Tools.XPMenus.PaintStyle.ImageAndText
            Me.SaveSessionBarItem.ShortcutText = ""
            Me.SaveSessionBarItem.Text = "&Save session..."
            '
            'AlwaysCheckOutstandingConflictBarItem
            '
            Me.AlwaysCheckOutstandingConflictBarItem.CategoryIndex = 0
            Me.AlwaysCheckOutstandingConflictBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AlwaysCheckOutstandingConflictBarItem.ID = "Always check outstanding conflicts on completion"
            Me.AlwaysCheckOutstandingConflictBarItem.ShortcutText = ""
            Me.AlwaysCheckOutstandingConflictBarItem.Text = "Always check outstanding conflicts on completion"
            '
            'CancellationIsAttemptBarItem
            '
            Me.CancellationIsAttemptBarItem.CategoryIndex = 0
            Me.CancellationIsAttemptBarItem.Checked = True
            Me.CancellationIsAttemptBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CancellationIsAttemptBarItem.ID = "CancellationCountsAsAttempt"
            Me.CancellationIsAttemptBarItem.ShortcutText = ""
            Me.CancellationIsAttemptBarItem.Text = "Cancellation counts as an attempt"
            '
            'ResetCorruptSensorsBarItem
            '
            Me.ResetCorruptSensorsBarItem.CategoryIndex = 0
            Me.ResetCorruptSensorsBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ResetCorruptSensorsBarItem.ID = "Corrupt images trigger sensor resets"
            Me.ResetCorruptSensorsBarItem.ShortcutText = ""
            Me.ResetCorruptSensorsBarItem.Text = "Corrupt images trigger sensor resets"
            '
            'DemoModeBarItem
            '
            Me.DemoModeBarItem.CategoryIndex = 0
            Me.DemoModeBarItem.Checked = True
            Me.DemoModeBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DemoModeBarItem.ID = "Save result images to disk"
            Me.DemoModeBarItem.ShortcutText = ""
            Me.DemoModeBarItem.Text = "Save result images to disk (demo)"
            '
            'PassiveSensorsAutoStartBarItem
            '
            Me.PassiveSensorsAutoStartBarItem.CategoryIndex = 0
            Me.PassiveSensorsAutoStartBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.PassiveSensorsAutoStartBarItem.ID = "Sensors start polling automatically"
            Me.PassiveSensorsAutoStartBarItem.ShortcutText = ""
            Me.PassiveSensorsAutoStartBarItem.Text = "Sensors start polling automatically"
            '
            'SkippingDeactivatesMultipleTasksBarItem
            '
            Me.SkippingDeactivatesMultipleTasksBarItem.CategoryIndex = 0
            Me.SkippingDeactivatesMultipleTasksBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SkippingDeactivatesMultipleTasksBarItem.ID = "SkippingDeactivatesMultipleTasksBarItem"
            Me.SkippingDeactivatesMultipleTasksBarItem.ShortcutText = ""
            Me.SkippingDeactivatesMultipleTasksBarItem.Text = "Skipping can deactivate multiple tasks"
            '
            'TimeoutsAreAttemptsBarItem
            '
            Me.TimeoutsAreAttemptsBarItem.CategoryIndex = 0
            Me.TimeoutsAreAttemptsBarItem.Checked = True
            Me.TimeoutsAreAttemptsBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TimeoutsAreAttemptsBarItem.ID = "Timeouts always count as an attempt"
            Me.TimeoutsAreAttemptsBarItem.ShortcutText = ""
            Me.TimeoutsAreAttemptsBarItem.Text = "Timeouts always count as an attempt"
            '
            'TimeoutAlwaysPromptForDetailBarItem
            '
            Me.TimeoutAlwaysPromptForDetailBarItem.CategoryIndex = 0
            Me.TimeoutAlwaysPromptForDetailBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TimeoutAlwaysPromptForDetailBarItem.ID = "Always prompt for detail on timeout"
            Me.TimeoutAlwaysPromptForDetailBarItem.ShortcutText = ""
            Me.TimeoutAlwaysPromptForDetailBarItem.Text = "Timeout always prompt for detail"
            '
            'CrashNowBarItem
            '
            Me.CrashNowBarItem.CategoryIndex = 0
            Me.CrashNowBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CrashNowBarItem.ID = "Crash now"
            Me.CrashNowBarItem.Text = "Crash now"
            '
            'AboutBarItem
            '
            Me.AboutBarItem.CategoryIndex = 0
            Me.AboutBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AboutBarItem.Enabled = False
            Me.AboutBarItem.ID = "About..."
            Me.AboutBarItem.ShortcutText = ""
            Me.AboutBarItem.Text = "About..."
            '
            'AttemptEditorCascadesChangesBarItem
            '
            Me.AttemptEditorCascadesChangesBarItem.CategoryIndex = 0
            Me.AttemptEditorCascadesChangesBarItem.Checked = True
            Me.AttemptEditorCascadesChangesBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AttemptEditorCascadesChangesBarItem.Enabled = False
            Me.AttemptEditorCascadesChangesBarItem.ID = "AttemptEditorCascadesChanges"
            Me.AttemptEditorCascadesChangesBarItem.ShortcutText = ""
            Me.AttemptEditorCascadesChangesBarItem.Text = "Attempt editor cascades changes in 'current' conditions and parts"
            '
            'ShortCircuitConflictAnalysisBarItem
            '
            Me.ShortCircuitConflictAnalysisBarItem.CategoryIndex = 0
            Me.ShortCircuitConflictAnalysisBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ShortCircuitConflictAnalysisBarItem.Enabled = False
            Me.ShortCircuitConflictAnalysisBarItem.ID = "ShortCircuitConflictAnalysis"
            Me.ShortCircuitConflictAnalysisBarItem.ShortcutText = ""
            Me.ShortCircuitConflictAnalysisBarItem.Tag = "ShortCircuitConflictAnalysis"
            Me.ShortCircuitConflictAnalysisBarItem.Text = "Conflict analysis should be short-circuiting"
            '
            'FontsBarItem
            '
            Me.FontsBarItem.CategoryIndex = 0
            Me.FontsBarItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FontsBarItem.ID = "Fonts..."
            Me.FontsBarItem.ShortcutText = ""
            Me.FontsBarItem.Text = "&Fonts..."
            '
            'DeleteImagesOnTaskSetCompletionItem
            '
            Me.DeleteImagesOnTaskSetCompletionItem.CategoryIndex = 0
            Me.DeleteImagesOnTaskSetCompletionItem.Checked = True
            Me.DeleteImagesOnTaskSetCompletionItem.CustomTextFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DeleteImagesOnTaskSetCompletionItem.ID = "Sensors should delete internal images on exit"
            Me.DeleteImagesOnTaskSetCompletionItem.ShortcutText = ""
            Me.DeleteImagesOnTaskSetCompletionItem.Text = "Sensors should delete internal images on task set completion"
            '
            'StartupTimer
            '
            Me.StartupTimer.Interval = 1000
            '
            'MainPanel
            '
            Me.MainPanel.BackColor = System.Drawing.SystemColors.Control
            Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MainPanel.HeaderEnabled = False
            Me.MainPanel.HeaderText = Nothing
            Me.MainPanel.Location = New System.Drawing.Point(0, 26)
            Me.MainPanel.LowerPanelVisible = True
            Me.MainPanel.Name = "MainPanel"
            Me.MainPanel.Size = New System.Drawing.Size(792, 516)
            Me.MainPanel.TabIndex = 0
            Me.MainPanel.UICulture = New System.Globalization.CultureInfo("en-US")
            '
            'BaseSensorController
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(4, 11)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Controls.Add(Me.MainPanel)
            Me.Controls.Add(Me.StatusBar)
            Me.Enabled = True
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BaseSensorController"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
            Me.Text = "BaseSensorController"
            CType(Me.StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.StatusBar.ResumeLayout(False)
            CType(Me.PercentCompleteBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TimeStatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorCountStatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.StateStatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MainFrameBarManager, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "  Constants  "
        Private Const DefaultControlPadding As Integer = 4

        Private Const EndSessionButtonClickedReason As String = "EndSessionButton+Click"
        Private Const TaskListControlSelectedTaskReason As String = "TaskListControl+TaskSelected"

#End Region

#Region "  UserNew / OnLoad  "
        Private Sub UserNew()

            KeyPreview = True

            SetStyle(Mbark.UI.DoubleBufferStyle, True)
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)

            With TaskListControl
                AddHandler .TaskProvidingAttemptDetailChanged, AddressOf TaskProvidingAttemptDetailChangeListener
                AddHandler .StartingTaskSelected, AddressOf TaskSelectedListener
                AddHandler .RevokeOrRequestDownloadCancellation, AddressOf CancelOrResumeDownloadsListener
            End With

            With SensorStatusControl
                AddHandler .SensorDisabledChange, AddressOf SensorDisabledListener
            End With

            AddHandler AttemptPicker.EditRequested, AddressOf EditAttemptListener


            'Moved settings parse code to HandleStartupTimer_Tick

            FillBarItemIcons()


        End Sub


        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)

            Me.Text = Messages.Session(UICulture)

            If InDesignMode(Me) Then Return

            SensorStatusControl.WireSensorSet(Sensors)

            ' TaskListControl wiring
            With TaskListControl
                .WireTaskList(mTaskFactories.AllTasks)
                .WireCurrentlyInaccessibleParts(InaccessibleBodyParts)
                .WireCurrentConditions(CurrentConditions)
            End With

            With InaccessibleBodyPartsControl
                .WithRightHand = True
                .WithLeftHand = True
                .WithIrises = True
                .WireBodyPartsList(InaccessibleBodyParts)
            End With

            With ConditionsControl
                .WireConditions(CurrentConditions)
                .HeaderText = Messages.SpecialConditions(UICulture)
            End With

            AttemptPicker.WireConditions(CurrentConditions)
            AttemptPicker.WireInaccessibleBodyParts(InaccessibleBodyParts)

            PercentCompleteToolTip.SetToolTip(PercentCompleteBar, Messages.PercentageOfAllTasksThatAreFullyCompleted(UICulture))
            RefreshPercentCompleteBar()


            AddHandler InaccessibleBodyParts.BodyPartsChanged, AddressOf MissingPartChangeListener

            Me.SuspendLayout()
            LayoutControls()

            ' Persist the location & size
            Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
            Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

            With mSettings.WindowSize
                Me.Size = New Size(Math.Min(.Width, screenWidth), Math.Min(.Height, screenHeight))
            End With

            Dim x As Integer = mSettings.WindowLocation.X
            Dim y As Integer = mSettings.WindowLocation.Y
            x = Math.Max(0, x)
            y = Math.Max(0, y)
            x = Math.Min(x, screenWidth - Width)
            y = Math.Min(y, screenHeight - Height)
            mSettings.WindowLocation = New Point(x, y)

            Me.Location = mSettings.WindowLocation


            Me.ResumeLayout()


            Me.StartupTimer.Start()
        End Sub

        'Loads from a file into the given factories object, then refreshes the necessary controls.
        Protected Sub PopulateFromFile(ByVal fname As String, ByVal factories As SensorTaskFactoryCollection)
            RemoveHandler InaccessibleBodyParts.BodyPartsChanged, AddressOf MissingPartChangeListener

            UnwireTaskFactories()

            Try
                factories = SensorTaskFactoryCollection.PopulateFromStream(Loader.LoadFromFile(fname))
                
            Catch ex As UnauthorizedAccessException
                MessageBox.Show("You have no access to this file.")
                Return
            Catch ex As Exception
                MessageBox.Show("There was a problem loading the file " & fname & "(" & ex.ToString & ")")
                Return
            End Try
            WireTaskFactories(factories)

            ' Fix the control wiring
            SensorStatusControl.WireSensorSet(Sensors)
            TaskListControl.WireTaskList(mTaskFactories.AllTasks)
            TaskListControl.WireCurrentlyInaccessibleParts(InaccessibleBodyParts)
            TaskListControl.WireCurrentConditions(CurrentConditions)

            InaccessibleBodyPartsControl.WireBodyPartsList(InaccessibleBodyParts)
            InaccessibleBodyPartsControl.BindFromWireToControls()

            ConditionsControl.WireConditions(CurrentConditions)
            AttemptPicker.WireConditions(CurrentConditions)
            AttemptPicker.WireInaccessibleBodyParts(InaccessibleBodyParts)
            PercentCompleteToolTip.SetToolTip(PercentCompleteBar, Messages.PercentageOfAllTasksThatAreFullyCompleted(UICulture))

            RefreshPercentCompleteBar()

            AddHandler InaccessibleBodyParts.BodyPartsChanged, AddressOf MissingPartChangeListener

            ' Go ahead and start up a new task set. Note that we *don't* populate the targets (which should not be done, 
            ' since the sensors aren't even initialized yet).
            If AutomaticallyStartNewTaskSet Then
                ChangeMode(SensorControlMode.StartingNewTaskSet)
            Else
                ChangeMode(SensorControlMode.AwaitingStartOfNewTaskSet)
            End If
        End Sub
#End Region

#Region "  Static Controls  "

        Private WithEvents LeftPanel As New AutosizableDropDownGroup
        Private WithEvents RightPanel As New AutosizableDropDownGroup

        Protected WithEvents TaskListControl As New TaskListControl
        Protected WithEvents ConditionsControl As New ConditionsControl
        Protected WithEvents AttemptPicker As New AttemptPicker
        Protected WithEvents SensorStatusControl As New SensorStatusControl
        Protected WithEvents InaccessibleBodyPartsControl As New InaccessibleBodyPartsControl
        Protected WithEvents SensorPanel As New SF.Tools.GradientPanel
        Protected WithEvents ButtonsPanel As New ControllerButtonsPanel

        ' The sensor layout is a instance variable so that the sensor panel can be removed and re-added
        Private mSensorLayout As AutosizableDropDownLayoutArgs
        Private Sub LayoutControls()

            Dim padding As Integer = DefaultControlPadding

            MainPanel.DockPadding.All = padding

            LeftPanel.Name = "LeftPanel"
            Dim leftPanelLayout As New AutosizableDropDownLayoutArgs(LeftPanel)
            With leftPanelLayout
                .GridPosX = 0
                .GridPosY = 0
                .FillWeightX = 0.75
                .FillWeightY = 1
            End With
            MainPanel.LayoutControl(leftPanelLayout)

            Dim rightPanelLayout As New AutosizableDropDownLayoutArgs(RightPanel)
            With rightPanelLayout
                .GridPosX = 1
                .GridPosY = 0
                .FillWeightX = 0.25
                .FillWeightY = 1
            End With
            MainPanel.LayoutControl(rightPanelLayout)

            ' -----------
            ' Left panels
            Dim taskListLayout As New AutosizableDropDownLayoutArgs(TaskListControl)
            TaskListControl.DockPadding.All = padding
            With taskListLayout
                .GridPosX = 0
                .GridPosY = 0
                .FillWeightX = 1
                .FillWeightY = 0.5
                .CellSpanX = 2
            End With
            LeftPanel.LayoutControl(taskListLayout)


            mSensorLayout = New AutosizableDropDownLayoutArgs(SensorPanel)
            SensorPanel.BorderStyle = BorderStyle.None
            SensorPanel.BackgroundColor = New Syncfusion.Drawing.BrushInfo(SystemColors.Control)
            SensorPanel.DockPadding.All = padding
            With mSensorLayout
                .GridPosX = 0
                .GridPosY = 1
                .FillWeightX = 0.7
                .FillWeightY = 0.5
            End With
            LeftPanel.LayoutControl(mSensorLayout)

            Dim statusLayout As New AutosizableDropDownLayoutArgs(SensorStatusControl)
            SensorStatusControl.DockPadding.All = padding
            With statusLayout
                .GridPosX = 1
                .GridPosY = 1
                .FillWeightX = 0.3
                .FillWeightY = 1.0 / 3.0
            End With
            LeftPanel.LayoutControl(statusLayout)


            ' ------------
            ' Right panels
            Dim attemptLayout As New AutosizableDropDownLayoutArgs(AttemptPicker)
            AttemptPicker.WithFancyHeader = True
            AttemptPicker.DockPadding.All = padding
            With attemptLayout
                .GridPosX = 0
                .GridPosY = 0
                .FillWeightX = 1
                .FillWeightY = 1
            End With
            RightPanel.LayoutControl(attemptLayout)


            Dim bodyPartsLayout As New AutosizableDropDownLayoutArgs(InaccessibleBodyPartsControl)
            InaccessibleBodyPartsControl.WithFancyHeader = True
            InaccessibleBodyPartsControl.DockPadding.All = padding
            With bodyPartsLayout
                .GridPosX = 0
                .GridPosY = 1
                .FillWeightX = 1
                .FillWeightY = 1.0 / 3.0
            End With
            RightPanel.LayoutControl(bodyPartsLayout)

            Dim conditionsLayout As New AutosizableDropDownLayoutArgs(ConditionsControl)
            ConditionsControl.WithFancyHeader = True
            ConditionsControl.DockPadding.All = padding
            With conditionsLayout
                .GridPosX = 0
                .GridPosY = 2
                .FillWeightX = 1
                .FillWeightY = 1.0 / 3.0
            End With
            RightPanel.LayoutControl(conditionsLayout)

            Dim buttonPanelLayout As New AutosizableDropDownLayoutArgs(ButtonsPanel)
            ButtonsPanel.DockPadding.Right = padding
            With buttonPanelLayout
                .GridPosX = 0
                .GridPosY = 3
            End With
            RightPanel.LayoutControl(buttonPanelLayout)
            AddHandler ButtonsPanel.EndSessionButton.Click, AddressOf EndSessionButton_Click



        End Sub

#End Region

#Region "  CommandComplete Listeners  "

        ' CommandComplete listeners get bound to a particular sensor's command template within the startup sections
        ' of the child classes of BaseSensorContoller

        Private Sub CaptureCommandCompleteListener(ByVal sender As Object, ByVal e As CommandCompleteEventArgs)

            OnCaptureCommandComplete(e)

            Console.WriteLine(e.Command.CommandId.ToString & " - " & Me.CurrentSensorControlMode.ToString)
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.HandlingCaptureResult)
            With args
                .Trigger = SensorModeChangeTrigger.CommandCompleted
                .Command = e.Command
                mLatestCaptureCompleteResult = e
            End With

            ChangeSensorControlMode(args)

        End Sub

        Protected Overridable Sub OnCaptureCommandComplete(ByVal e As CommandCompleteEventArgs)
            ' Intended for override
        End Sub


        Private Sub InitializationCommandCompleteListener(ByVal sender As Object, ByVal e As CommandCompleteEventArgs)

            OnInitializationCommandComplete(e)

            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.HandlingSensorInitializationCompletion)
            With args
                .Trigger = SensorModeChangeTrigger.CommandCompleted
                .Reason = "InitializationComplete"
                .Command = e.Command
            End With
            ChangeSensorControlMode(args)
        End Sub

        Protected Overridable Sub OnInitializationCommandComplete(ByVal e As CommandCompleteEventArgs)
            ' Intended for override
        End Sub

        Private Sub DownloadCommandCompleteListener(ByVal sender As Object, ByVal e As CommandCompleteEventArgs)

            OnDownloadCommandComplete(e)

            ' We don't make a separate state for this b/c it can happen at any time. With a delegate, 
            ' we can pick up exactly where we left off without worrying about keeping state
            Dim args() As Object = {e.Command}
            Invoke(New HandleDownloadResultDelegate(AddressOf HandleDownloadResult), args)
            If Me.CurrentSensorControlMode = SensorControlMode.AwaitingTaskSetCompletion Then
                ChangeMode(SensorControlMode.AwaitingTaskSetCompletion)
            End If

            TaskListControl.Refresh()
            AttemptPicker.RefreshPicker()
            RefreshButtons()

        End Sub

        Protected Overridable Sub OnDownloadCommandComplete(ByVal e As CommandCompleteEventArgs)
            ' Intended for override
        End Sub

        Private Sub ConfigurationCommandCompleteListener(ByVal sender As Object, ByVal e As CommandCompleteEventArgs)

            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.HandlingConfigurationResult)
            With args
                .Trigger = SensorModeChangeTrigger.CommandCompleted
                .Reason = "ConfigurationComplete"
                .Command = e.Command
            End With
            ChangeSensorControlMode(args)

        End Sub


#End Region

#Region "  Event Listeners  "

        ' The purpose of a listener is to wait for an event, and then pass it along to the master ChangeSensorControlMode
        ' method. This helps centralize the state transition logic.

        Private Sub EditAttemptListener(ByVal sender As Object, ByVal e As EditRequestedEventArgs)
            If e Is Nothing Then Throw New ArgumentNullException("e")
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.EditingAttempt)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "TaskListControl+EditRequested"
                mAttemptToEdit = e.Attempt
            End With
            ChangeSensorControlMode(args)
        End Sub

        Private Sub SkipJustificationResultListener(ByVal sender As Object, ByVal e As EventArgs)
            If e Is Nothing Then Throw New ArgumentNullException("e")
            Me.Enabled = True
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.HandlingTaskSkipResponse)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "CancelTaskForm.Closed"
            End With
            ChangeSensorControlMode(args)
        End Sub

        Private Sub CancelOrResumeDownloadsListener(ByVal sender As Object, ByVal e As DownloadEventArgs)
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.CancellingOrResumingDownload)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                If e.CancelDownloads Then
                    .CancelDownloadTask = e.Task
                    .Reason = "TaskListControl.CancelDownload"
                Else
                    .ResumeDownloadTask = e.Task
                    .Reason = "TaskListControl.ResumeDownload"
                End If
            End With
            ChangeSensorControlMode(args)
        End Sub

        Private Sub MissingPartChangeListener(ByVal sender As Object, ByVal e As BodyPartsChangeEventArgs)

            ' Don't react to changes in the current missing parts if we're changing them because of:
            ' (a) an attempt edit
            ' (b) a task skip response
            ' (c) activation of a new task
            ' (d) completing a task set (which reset the missing parts control)
            If CurrentSensorControlMode = SensorControlMode.HandlingAttemptEdit Then Return
            If CurrentSensorControlMode = SensorControlMode.HandlingTaskSkipResponse Then Return
            If CurrentSensorControlMode = SensorControlMode.ActivatingTask Then Return
            If CurrentSensorControlMode = SensorControlMode.CompletingTaskSet Then Return

            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.ActivatingTask)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "MissingPartChangeListener"
            End With
            ChangeSensorControlMode(args)
        End Sub

        Private Sub ConditionChangeListener(ByVal sender As Object, ByVal e As ConditionValueChangedEventArgs)

            OnConditionChange(e)


            ' Don't react to changes in the current conditions if we're changing them because of:
            ' (a) an attempt edit
            ' (b) a task skip response
            ' (c) activation of a new task
            ' (d) completing a task set (since this resets the missing parts control)
            ' (e) completing a task set (since this also resets the missing parts control)
            If CurrentSensorControlMode = SensorControlMode.HandlingAttemptEdit Then Return
            If CurrentSensorControlMode = SensorControlMode.HandlingTaskSkipResponse Then Return
            If CurrentSensorControlMode = SensorControlMode.ActivatingTask Then Return
            If CurrentSensorControlMode = SensorControlMode.CompletingTaskSet Then Return

            ' Stop respecting the active task as a skip destination when we change conditions
            If Not ActiveTask Is Nothing Then ActiveTask.SkipDestination = False

            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.ActivatingTask)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "ConditionsChange"
            End With

            ChangeSensorControlMode(args)
        End Sub

        Protected Overridable Sub OnConditionChange(ByVal e As ConditionValueChangedEventArgs)
            ' Intended for override
        End Sub

        Private Sub TaskProvidingAttemptDetailChangeListener(ByVal sender As Object, ByVal e As EventArgs)

            ' Wrapping the changes in a visible false/true reduces some annoying half-drawn artifacts
            AttemptPicker.InnerPanel.Visible = False
            AttemptPicker.WireTask(TaskListControl.TaskProvidingAttemptDetail)
            AttemptPicker.RefreshPicker()
            AttemptPicker.InnerPanel.Visible = True
            TaskListControl.Refresh()
            Return
        End Sub

        Private mEndSessionWithoutFinishDownload As Boolean
        Private Sub EndSessionButton_Click(ByVal sender As Object, ByVal arg As EventArgs)

            'reset
            mSubjectLeftSession = False

            mEndSessionWithoutFinishDownload = False
            mEndSessionRequested = True
            Dim rv As DialogResult
            If TaskList.IsDownloadStillNeeded Then
                Dim message As String = _
                    Messages.ThisSessionHasDataNotYetDownloaded(UICulture) & vbNewLine & _
                    Messages.DoYouWishToExit(UICulture)
                rv = MessageBox.Show( _
                    text:=message, _
                    caption:=Messages.SorryBang(UICulture), _
                    buttons:=MessageBoxButtons.YesNo, _
                    icon:=MessageBoxIcon.Question, _
                    defaultButton:=MessageBoxDefaultButton.Button2, _
                    options:=MessageBoxOptions.DefaultDesktopOnly)
            End If

            If Not TaskList.IsDownloadStillNeeded OrElse rv = Windows.Forms.DialogResult.Yes Then
                mEndSessionWithoutFinishDownload = True
                If CurrentSensorControlMode = SensorControlMode.AwaitingTaskSetCompletion Then
                    ChangeMode(SensorControlMode.AwaitingTaskSetCompletion, EndSessionButtonClickedReason)
                    Return
                End If

                If SensorControlModeSets.TaskSelectionPermitted.Contains(CurrentSensorControlMode) Then

                    ' Hide the current sensor
                    CurrentSensor.AsControl.Visible = False

                    ' Start the justification dialog and wait for it to finish
                    Dim args As New ChangeSensorControlModeArgs(SensorControlMode.JustifyingTaskSkip)
                    With args
                        .Trigger = SensorModeChangeTrigger.EventActivated
                        .Reason = EndSessionButtonClickedReason
                    End With
                    ChangeSensorControlMode(args)
                End If
            End If


        End Sub

        Private Sub TaskSelectedListener(ByVal sender As Object, ByVal e As TaskSelectedEventArgs)
            If e Is Nothing Then Throw New ArgumentNullException("e")
            If Not SensorControlModeSets.TaskSelectionPermitted.Contains(CurrentSensorControlMode) Then Return

            ' Hide the old control
            If Not e.OldTask Is Nothing Then e.OldTask.Sensor.AsControl.Visible = False

            ' Start the justification dialog and wait for it to finish
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.JustifyingTaskSkip)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = TaskListControlSelectedTaskReason
            End With
            ChangeSensorControlMode(args)



        End Sub

        Private Sub SensorRecoveryResultListener(ByVal sender As Object, ByVal e As EventArgs) _
            Handles mSensorRecoveryForm.Closed

            Me.Enabled = True

            ' Mark the sensor as no longer needing recovery
            mSensorRecoveryForm.FailingSensor.RequiresRecovery = False

            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.HandlingRecoveryResult)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "SensorRecoveryForm.Closed"
            End With
            ChangeSensorControlMode(args)
        End Sub

        Private Sub CaptureActivatedListener(ByVal sender As Object, ByVal captureActivatedArgs As CaptureActivatedEventArgs)

            OnCaptureActivated(captureActivatedArgs)
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.AwaitingCaptureResult)

            If ActiveTask Is Nothing Then
                MsgBox("There appears to be no active task.")
            End If

            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "BaseSensor.CaptureActivated"
                .CaptureActivatedTask = ActiveTask

                mLatestCapturingTask = ActiveTask
                Debug.Assert(captureActivatedArgs.OriginatingSensor Is CurrentSensor)
                Debug.Assert(ActiveTask IsNot Nothing)
            End With
            ChangeSensorControlMode(args)
        End Sub
        Protected Overridable Sub OnCaptureActivated(ByVal args As CaptureActivatedEventArgs)
            ' Intended for override
        End Sub

        Private Sub ReviewCompleteListener(ByVal sender As Object, ByVal reviewCompleteArgs As EventArgs)
            Me.Enabled = True
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.HandlingCaptureReviewResponse)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "CaptureReviewForm.Closed"
            End With
            ChangeSensorControlMode(args)
        End Sub

        Private Sub AttemptEditCompleteListener(ByVal sender As Object, ByVal e As EventArgs)
            Me.Enabled = True
            Dim args As New ChangeSensorControlModeArgs(SensorControlMode.HandlingAttemptEdit)
            With args
                .Trigger = SensorModeChangeTrigger.EventActivated
                .Reason = "AttemptEditor.Closed"
            End With
            ChangeSensorControlMode(args)
        End Sub

        Private Sub SensorDisabledListener(ByVal sender As Object, ByVal e As EventArgs)
            ActivateTaskAfterSensorCheck()
        End Sub

        Private Sub BadStatusListener(ByVal sender As Object, ByVal e As BadStatusEventArgs)

            ' Only act on this if we're waiting for capture to happen
            If CurrentSensorControlMode <> SensorControlMode.AwaitingCaptureSignal Then Return
            ActivateTaskAfterSensorCheck()
        End Sub

#End Region

#Region "  Major Fields & Convenience Wrappers  "

        Private mBaseLoader As BaseLoader

        Private mTaskFactories As New SensorTaskFactoryCollection
        Private mLatestCapturingTask As SensorTask
        Private mLatestCaptureCompleteResult As CommandCompleteEventArgs
        Private mAttemptToEdit As SensorTaskAttempt

        Private mTaskSetFailures As New List(Of SensorTaskFailure)
        Private mAllFailures As New List(Of SensorTaskFailure)

        Protected Property Loader() As BaseLoader
            Get
                Return mBaseLoader
            End Get
            Set(ByVal value As BaseLoader)
                mBaseLoader = value
            End Set
        End Property

        Protected ReadOnly Property Sensors() As SensorCollection
            Get
                Return mTaskFactories.Sensors
            End Get
        End Property

        Protected Sub RegisterSensor(ByVal sensor As ISensor)
            If sensor Is Nothing Then Throw New ArgumentNullException("sensor")
            Sensors.Add(sensor)
            SensorPanel.Controls.Add(sensor.AsControl)
            sensor.AsControl.Visible = False
            sensor.AsControl.Dock = DockStyle.Fill
        End Sub

        Protected Sub UnregisterSensor(ByVal sensor As ISensor)
            If sensor Is Nothing Then Throw New ArgumentNullException("sensor")
            sensor.AsControl.Visible = False
            sensor.AsControl.Enabled = False
            Sensors.Remove(sensor)
        End Sub

        Protected ReadOnly Property AllFailures() As List(Of SensorTaskFailure)
            Get
                Return mAllFailures
            End Get
        End Property



        Protected ReadOnly Property TaskFactories() As SensorTaskFactoryCollection
            Get
                Return mTaskFactories
            End Get
        End Property

        Public ReadOnly Property Sensor(ByVal index As Integer) As ISensor
            Get
                Return DirectCast(Sensors(index), ISensor)
            End Get
        End Property

        Public ReadOnly Property TaskList() As SensorTaskCollection
            Get
                Return mTaskFactories.AllTasks
            End Get
        End Property

        Public ReadOnly Property ActiveTask() As SensorTask
            Get
                Return mTaskFactories.ActiveTask
            End Get
        End Property

        Public ReadOnly Property CurrentSensor() As ISensor
            Get
                If ActiveTask Is Nothing Then Return Nothing Else Return ActiveTask.Sensor
            End Get
        End Property

        Public ReadOnly Property InaccessibleBodyParts() As BodyPartCollection
            Get
                Return mTaskFactories.CurrentInaccessibleBodyParts
            End Get
        End Property

        Protected ReadOnly Property CurrentConditions() As ConditionCollection
            Get
                Return mTaskFactories.CurrentConditions
            End Get
        End Property

#End Region

#Region "  Initialization & Status "

        Private mModeToEnterAfterSensorCheck As SensorControlMode
        Private mOutstandingInitializations As New Dictionary(Of Guid, ISensor) ' CommandId -> Sensor

        Private Sub StartSensorInitialization()

            ' Uninitialize sensors that need it
            For i As Integer = 0 To Sensors.Count - 1
                If Not Sensors(i).Disabled AndAlso Sensors(i).LatestStatus = SensorStatus.Offline Then
                    Sensors(i).Uninitialize()
                End If
            Next

            For i As Integer = 0 To Sensors.Count - 1
                Dim sensor As ISensor = Me.Sensor(i)
                Dim id As Guid

                Dim deferred As Boolean = sensor.DeferInitialization
                Dim nowCurrent As Boolean = sensor Is CurrentSensor
                Dim notDeferred As Boolean = Not sensor.DeferInitialization
                Dim notDisabled As Boolean = Not sensor.Disabled
                Dim uninitialized As Boolean = sensor.LatestStatus = SensorStatus.Uninitialized

                If deferred And nowCurrent OrElse notDeferred AndAlso notDisabled AndAlso uninitialized Then
                    id = sensor.StartInitialize()

                    If Not id.Equals(Guid.Empty) Then
                        ' Don't keep track of initializations that don't really occur
                        mOutstandingInitializations(id) = sensor
                    End If

                    SensorStatusControl.RefreshSensorStatus()

                End If

            Next

        End Sub

        Private Delegate Sub HandleDownloadResultDelegate(ByVal command As AsyncCommand)
        Private Sub HandleDownloadResult(ByVal command As AsyncCommand)

            ' The DownloadCompleteListener is responsible for marshalling this call to the form thread
            ForbidInvokeRequired(Me)

            TaskListControl.AutoRefreshFrequency = 0

            ' Get the sensor & task back from the hashtable
            Dim attempt As SensorTaskAttempt = mOutstandingDownloads(command.CommandId)
            Dim sensor As ISensor = attempt.ParentTask.Sensor

            If sensor.LatestDownloadWasSuccessful Then

                attempt.MarkAsDownloadedSuccessfully(DirectCast(command.TargetReturnValue, CaptureResultCollection))
                attempt.ParentTask.Status = SensorTaskStatus.Done

            ElseIf sensor.LatestDownloadWasCanceled Then

                ' rjm asks why this was 'suspended' 
                attempt.ParentTask.Status = SensorTaskStatus.Pending

            Else

                Dim failure As New SensorTaskFailure(command.TargetException)
                attempt.MarkAsHavingDownloadFailure(failure)
                'OutputLog("HandleDownloadResult - Failed, Change to Suspended")
                attempt.ParentTask.Status = SensorTaskStatus.Suspended
                'LogToFile.WriteLine(LogToFile.LogLevel.Fatal, failure.ExceptionMessages)
                mAllFailures.Add(failure)

            End If

            attempt.ParentTask.RefreshStatus()


            ' Unblock those tasks not already done (we don't have to make sure they are blocked first, Unblock() 
            ' takes care of this for us.)
            '
            For i As Integer = 0 To mTaskFactories.TasksOfSensor(sensor).Count - 1
                Dim tasks As SensorTaskCollection = mTaskFactories.TasksOfSensor(sensor)
                For j As Integer = 0 To tasks.Count - 1
                    tasks(j).Unblock()
                Next
            Next
            mOutstandingDownloads.Remove(command.CommandId)

            ' See if there are any others to download
            TryToStartDownloads()

            AttemptPicker.RefreshPicker()
            SensorStatusControl.RefreshSensorStatus()
            TaskListControl.Refresh()
            RefreshPercentCompleteBar()

        End Sub

        Private Enum HandleSensorInitializationCompletionResult
            OutstandingInitializationsRemain
            NoMoreInitializationsRemain
        End Enum

        Private Function HandleSensorInitializationCompletion(ByVal command As AsyncCommand) _
            As HandleSensorInitializationCompletionResult

            ' Log failures
            If command.IsTimeExpired Then
                Dim failure As New SensorTaskFailure(command.TargetException)
                AddTaskSetFailure(failure)

            ElseIf Not command.TargetException Is Nothing Then

                Dim failure As New SensorTaskFailure(command.TargetException)
                AddTaskSetFailure(failure)

            End If
            RefreshFailureCountToolTip()

            ' Remove the oustanding initialization 
            mOutstandingInitializations.Remove(command.CommandId)
            If mOutstandingInitializations.Count = 0 Then
                Return HandleSensorInitializationCompletionResult.NoMoreInitializationsRemain
            Else
                Return HandleSensorInitializationCompletionResult.OutstandingInitializationsRemain
            End If


        End Function


        Private Sub TryToUninitializeSensorsWithDeferredInitialization()

            ' This should be pretty-much self-explanitory. If there are no tasks left for a particular sensor, 
            ' and that sensor has deferred initialization, then go ahead an deactivate the sensor.

            For i As Integer = 0 To Sensors.Count - 1
                Dim tasks As SensorTaskCollection = mTaskFactories.TasksOfSensor(Sensors(i))
                If Not tasks Is Nothing AndAlso Sensors(i).DeferInitialization AndAlso tasks.FirstActivatableTask = -1 Then
                    Sensors(i).Uninitialize()
                End If
            Next

        End Sub


#End Region

#Region "  Configuration  "

        Private Sub StartSensorConfiguration()
            CurrentSensor.StartConfiguration(ActiveTask.SensorConfiguration)
            SensorStatusControl.RefreshSensorStatus()
        End Sub

        Private Enum HandleSensorConfigurationCompletionResult
            ConfigurationPassed
            ConfigurationFailed
        End Enum

        Private Function HandleSensorConfigurationCompletion(ByVal command As AsyncCommand) _
            As HandleSensorConfigurationCompletionResult

            Dim expired As Boolean = command.IsTimeExpired
            Dim exceptionThrown As Boolean = Not command.TargetException Is Nothing
            Dim sensorNotOnline As Boolean = CurrentSensor.LatestStatus <> SensorStatus.Online

            If expired OrElse exceptionThrown OrElse sensorNotOnline Then

                Dim failure As New SensorTaskFailure(command.TargetException)
                mTaskSetFailures.Add(failure)
                mAllFailures.Add(failure)

                Return HandleSensorConfigurationCompletionResult.ConfigurationFailed
            Else
                TryToActivateLivePreview()
                Return HandleSensorConfigurationCompletionResult.ConfigurationPassed
            End If




        End Function

        Private Sub TryToActivateLivePreview()
            If CurrentSensor.LatestStatus = SensorStatus.Online AndAlso Not CurrentSensor.RequiresConfiguration AndAlso CurrentSensor.HasLivePreview Then
                CurrentSensor.StartLivePreview()
            End If
        End Sub

        Public ReadOnly Property StartupSettingsFileName() As String
            Get
                ' By default, use the initial settings file
                Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
                Dim finalFilename As String = IO.Path.Combine(baseDir, scmInitialSettingsFileName)

                ' However, if a local settings file exists, use that one instead.
                Dim localSettingsPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
                Dim localSettingsFileName As String = IO.Path.Combine(localSettingsPath, scmUserSettingsFileName)
                If IO.File.Exists(localSettingsFileName) Then
                    finalFilename = localSettingsFileName
                End If
                Return finalFilename
            End Get
        End Property

#End Region

#Region "  Closing  "

        Private mCloseRequested As Boolean
        Private mIsClosing As Boolean
        Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)


            ' Disable the control boxes so that the user knows we're shutting down
            Me.ControlBox = False
            Me.Refresh()

            If Not SensorControlModeSets.ExitPermitted.Contains(mCurrentSensorControlMode) Then
                mCloseRequested = True

                If Not CurrentSensor Is Nothing AndAlso CurrentSensor.LatestStatus = SensorStatus.Capturing AndAlso CurrentSensor.CaptureIsCancelable() Then
                    CurrentSensor.CancelCapture()
                End If

            End If


            mIsClosing = True

            ' Save our current settings
            Dim settings As IO.FileStream = Nothing
            Try
                Dim localSettingsPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
                If Not IO.Directory.Exists(localSettingsPath) Then
                    ' attempt to create the settings directory
                    IO.Directory.CreateDirectory(localSettingsPath)
                End If
                Dim localSettingsFileName As String = IO.Path.Combine(localSettingsPath, scmUserSettingsFileName)
                settings = New IO.FileStream(localSettingsFileName, IO.FileMode.OpenOrCreate)
                settings.SetLength(0)

                If Me.WindowState <> FormWindowState.Minimized Then
                    ' Only save the location and size if we're not minimized
                    mSettings.WindowLocation = Me.Location
                    mSettings.WindowSize = Me.Size
                End If

                smSettingsSerializer.Serialize(settings, mSettings)
                Debug.WriteLine("Wrote current settings to " + localSettingsFileName)
            Catch ex As Exception
                Debug.WriteLine("Couldn't save settings file..." + ex.ToString)
            Finally
                settings.Flush()
                settings.Close()
            End Try


            For i As Integer = 0 To Sensors.Count - 1
                Dim sensor As ISensor = DirectCast(Sensors(i), ISensor)
                If mSettings.DeleteInternalImagesOnSetCompletion Then sensor.DeleteInternalImages()
                StateStatusBar.Text = Messages.ShuttingDownDotDotDot(UICulture)
                StateStatusBar.Refresh()
                sensor.Uninitialize()
            Next
            Visible = False

            If Not mSensorRecoveryForm Is Nothing Then mSensorRecoveryForm.Close()
            If Not mTimeoutDetailForm Is Nothing Then mTimeoutDetailForm.Close()
            If Not mSkipTaskForm Is Nothing Then mSkipTaskForm.Close()

        End Sub

        Private Sub ExitBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitBarItem.Click
            Me.Close()
        End Sub

#End Region

#Region "  Handle Capture Result  "


        Private Enum HandleCaptureResultOutcomes
            UnexpectedMissingBodyPart
            CaptureTimedOut
            CaptureResultSucessful
            CaptureFailure
            ReviewRequired
            CaptureCancelled
        End Enum

        Private Function HandleCaptureResult(ByVal command As AsyncCommand) As HandleCaptureResultOutcomes

            ' Re-mark the task as active (i.e., current)
            Try
                ' Slice the arguments that were passed into the command back out again
                mLatestCapturingTask.Status = SensorTaskStatus.Active
            Catch ex As NullReferenceException
                'mLatestCapturingTask can be NULL, what to do?
                Return HandleCaptureResultOutcomes.CaptureFailure
            Catch ex As Exception
                Return HandleCaptureResultOutcomes.CaptureFailure
                'Debugger.Break()
            End Try


            If command.IsTimeExpired Then Return HandleCaptureResultOutcomes.CaptureTimedOut

            If Not command.TargetException Is Nothing Then


                ' See if the sensor detected a 'bad' body part
                If TypeOf command.TargetException Is UnexpectedMissingBodyPartException Then
                    Return HandleCaptureResultOutcomes.UnexpectedMissingBodyPart
                End If

                If TypeOf command.TargetException Is CaptureTimeoutException OrElse _
                   TypeOf command.TargetException Is ThreadInterruptedException Then

                    Return HandleCaptureResultOutcomes.CaptureTimedOut

                ElseIf TypeOf command.TargetException Is PollingCanceledException Then
                    Return HandleCaptureResultOutcomes.CaptureCancelled

                ElseIf Not TypeOf command.TargetException Is PollingCanceledException Then

                    ' rjm asks - should we do something here?
                End If

                Return HandleCaptureResultOutcomes.CaptureFailure
            End If



            If CurrentSensor.RequiresReview Then Return HandleCaptureResultOutcomes.ReviewRequired

            ' Set the attempt detail to the current task
            SetTaskProvidingAttemptDetail(ActiveTask)


            ' Force this task to unpause the download (it may have been paused in order to reject a previous attempt)
            ActiveTask.DownloadsPaused = False


            Return HandleCaptureResultOutcomes.CaptureResultSucessful

        End Function

#End Region

#Region "  Capture Review  "

        Private WithEvents mOperatorReviewForm As OperatorReviewForm
        Protected ReadOnly Property OperatorReviewForm() As OperatorReviewForm
            Get
                Return mOperatorReviewForm
            End Get
        End Property
        Public Sub HandleCaptureReviewResponse()
            Dim lTallyMethod As TallyMethod = TallyMethod.Review
            RemoveHandler mOperatorReviewForm.Closed, AddressOf ReviewCompleteListener

            CurrentSensor.LatestReviewImageConsideredAcceptable = Not mOperatorReviewForm.Rejected


            If mOperatorReviewForm.Rejected Then
                ActiveTask.Status = SensorTaskStatus.Active
            Else
                If CurrentSensor.RequiresDownload Then
                    ' New successful attempts should not have their downloads paused (this could 
                    ' have happened if there was a successful attempt that was rejected when
                    ' the downloads were paused.

                    ActiveTask.DownloadsPaused = False
                    ActiveTask.Status = SensorTaskStatus.Pending
                Else
                    lTallyMethod = TallyMethod.StandaloneSuccess
                    ActiveTask.Status = SensorTaskStatus.Done
                End If
            End If

            ' Set the attempt detail to the current task
            SetTaskProvidingAttemptDetail(ActiveTask)

            TaskListControl.Refresh()
            TallyAttempt(lTallyMethod, Nothing)
            ActivateTaskAfterSensorCheck()
            AttemptPicker.RefreshPicker()


        End Sub

#End Region

#Region "  Downloads  "

        Private mOutstandingDownloads As New Dictionary(Of Guid, SensorTaskAttempt)

        Public Shared Sub CancelDownload(ByVal task As SensorTask)
            With task
                .DownloadsPaused = True
                .Sensor.CancelDownload()
                ' rjm - originally was 'Suspended'
                .Status = SensorTaskStatus.Pending
            End With
        End Sub

        Public Shared Sub ResumeDownload(ByVal task As SensorTask)
            With task
                .DownloadsPaused = False
                If .Status = SensorTaskStatus.Suspended Then .Status = SensorTaskStatus.Pending
            End With
        End Sub

        Private Sub TryToStartDownloads()
            If InvokeRequired Then
                Dim d As New TryToStartDownloadsDelegate(AddressOf TryToStartDownloadsImplementation)
                Try
                    Me.Invoke(d, Nothing)
                Catch ex As ThreadInterruptedException
                    ' Swallow this exception
                End Try
            Else
                TryToStartDownloadsImplementation()
            End If
        End Sub


        Private Delegate Sub TryToStartDownloadsDelegate()
        Private Sub TryToStartDownloadsImplementation()
            Dim notYetDownloaded As Integer = 0
            For i As Integer = 0 To Sensors.Count - 1
                Dim sensor As ISensor = Sensors(i)

                If sensor.LatestStatus = SensorStatus.Online Then

                    Dim attempt As SensorTaskAttempt = mTaskFactories.FirstAttemptHavingOutstandingDownload(sensor)

                    If Not attempt Is Nothing Then

                        ' Mark the task as downloading
                        attempt.ParentTask.Status = SensorTaskStatus.Downloading
                        ' Current Sensor can be empty if there is only task in the list.
                        If CurrentSensor IsNot Nothing AndAlso _
                           CurrentSensor.HasLivePreview Then
                            CurrentSensor.StopLivePreview()
                        End If
                        Dim downloadCommandId As Guid = sensor.StartDownload(attempt.DownloadCommandId)
                        TaskListControl.AutoRefreshFrequency = 1500
                        mOutstandingDownloads(downloadCommandId) = attempt

                        ' Block all tasks associated with this sensor
                        For j As Integer = 0 To mTaskFactories.TasksOfSensor(sensor).Count - 1
                            Dim task As SensorTask = DirectCast(mTaskFactories.TasksOfSensor(sensor)(j), SensorTask)
                            If Not task Is attempt.ParentTask Then task.Block()
                        Next



                        TaskListControl.Refresh()

                    End If

                End If

                notYetDownloaded += mTaskFactories.TasksNotDownloaded(sensor)
            Next

            ' We need to disable the inaccessibly body parts and conditions during a download, so we refresh them
            RefreshInaccessibleBodyPartsControl(CurrentSensorControlMode)
            RefreshConditionsControl(CurrentSensorControlMode)

        End Sub

#End Region

#Region "  Change Sensor Control Mode  "

        Private mChangingSensorControlMode As Boolean

        Private Delegate Sub ChangeSensorControlModeDelegate(ByVal args As ChangeSensorControlModeArgs)

        Protected Overridable Sub ChangeSensorControlMode(ByVal args As ChangeSensorControlModeArgs)

            ' Respect a deferred exit here
            If mCloseRequested AndAlso SensorControlModeSets.ExitPermitted.Contains(args.NewMode) Then
                Me.Close()
                Return
            End If


            If InvokeRequired Then
                While mChangingSensorControlMode : WaitWithDoEvents(150, 10) : End While
                mChangingSensorControlMode = True
                Dim dArgs As Object() = {args}
                Dim d As New ChangeSensorControlModeDelegate(AddressOf ChangeSensorControlModeImplementation)
                Try
                    If Not mCloseRequested Then Me.Invoke(d, dArgs)
                Catch ex As ObjectDisposedException
                    ' Also swallow this exception which we typically only see when we close
                    ' in an unhealty way.
                Catch ex As ThreadInterruptedException
                    ' Swallow this exception
                Finally
                    mChangingSensorControlMode = False
                End Try

            Else
                ChangeSensorControlModeImplementation(args)
            End If
        End Sub


        Private Sub ChangeSensorControlModeImplementation(ByVal args As ChangeSensorControlModeArgs)

            ForbidInvokeRequired(Me)

            Try
                Dim newMode As SensorControlMode = args.NewMode
                Dim trigger As SensorModeChangeTrigger = args.Trigger
                Dim reason As String = args.Reason
                Dim command As AsyncCommand = args.Command

                Dim oldMode As SensorControlMode = mCurrentSensorControlMode

                mPreviousSensorControlMode = oldMode
                mCurrentSensorControlMode = newMode

                RefreshStateStatusBar(newMode)
                RefreshCursor(newMode)
                RefreshPercentCompleteBar()
                RefreshConditionsControl(newMode)
                RefreshFailureCountToolTip()
                RefreshBarItems()
                RefreshButtons()
                RefreshAttemptPicker()

                If mIsClosing Then Return

                If Not CurrentSensor Is Nothing Then
                    With DirectCast(CurrentSensor, BaseSensor).ActivateSensorButton
                        .Enabled = newMode = SensorControlMode.AwaitingCaptureSignal
                        .Refresh()
                    End With
                End If


                ' Tell the other components that we've changed the control mode
                Dim modeChangeArgs As New SensorControlModeChangeEventArgs( _
                    mPreviousSensorControlMode, mCurrentSensorControlMode, command, trigger, reason)
                RaiseEvent SensorControlModeChange(Me, modeChangeArgs)


                Select Case newMode
                    Case SensorControlMode.AwaitingStartOfNewTaskSet
                        ' --------------------------------------------------------------------------------
                        ' Awaiting Start Of New Task Set
                        ' --------------------------------------------------------------------------------
                        '
                        OnAwaitingStartOfNewTaskSet()

                    Case SensorControlMode.StartingSensorCheck

                        ' --------------------------------------------------------------------------------
                        ' StartingSensorCheck
                        ' --------------------------------------------------------------------------------
                        '
                        ' StartSensorCheck determines if further action needs to be taken with respect to sensor
                        ' initialization.
                        '
                        Dim result As StartSensorCheckResult = StartSensorCheck()
                        Select Case result

                            Case StartSensorCheckResult.InitializationRequired

                                ' If any sensor requires initialization, then go ahead and start that right away ...
                                ChangeMode(SensorControlMode.StartingSensorInitialization, result.ToString)

                            Case StartSensorCheckResult.InitializationsPending

                                ' ... or, if there are initializaitons pending, then we just wait for a bit
                                Mbark.UI.WaitWithDoEvents(500, 100)

                            Case StartSensorCheckResult.RecoveryRequired
                                ChangeMode(SensorControlMode.RecoveringFromSensorFailures)

                            Case StartSensorCheckResult.NoActionRequired

                                ' ... otherwise, we enter whatever mode the user requested of us
                                ChangeMode(mModeToEnterAfterSensorCheck, result.ToString)

                        End Select

                    Case SensorControlMode.StartingSensorInitialization

                        ' --------------------------------------------------------------------------------
                        ' StartingSensorInitialization
                        '   [Next state triggered by the InitializationResultListener]
                        ' --------------------------------------------------------------------------------
                        StartSensorInitialization()

                    Case SensorControlMode.HandlingSensorInitializationCompletion

                        ' --------------------------------------------------------------------------------
                        ' HandlingSensorInitializationCompletion
                        ' --------------------------------------------------------------------------------



                        If command Is Nothing Then Throw New ArgumentNullException("command")
                        Dim result As HandleSensorInitializationCompletionResult = _
                                          HandleSensorInitializationCompletion(command)
                        Select Case result

                            Case HandleSensorInitializationCompletionResult.OutstandingInitializationsRemain
                                ' Stay in this state
                            Case HandleSensorInitializationCompletionResult.NoMoreInitializationsRemain
                                ChangeMode(SensorControlMode.StartingSensorCheck)
                                TurnOffTabStop(Me)
                        End Select


                    Case SensorControlMode.HandlingRecoveryResult

                        ' --------------------------------------------------------------------------------
                        ' HandlingRecoveryResult
                        ' --------------------------------------------------------------------------------

                        If HandleSensorRecoveryResult() = HandleSensorRecoveryOutcomes.GiveUp Then
                            mSensorRecoveryForm.FailingSensor.Disabled = True
                        End If
                        ChangeMode(SensorControlMode.StartingSensorCheck, String.Empty)

                    Case SensorControlMode.HandlingCaptureResult

                        ' --------------------------------------------------------------------------------
                        ' HandlingCaptureResult
                        ' --------------------------------------------------------------------------------

                        RefreshConditionsControl(CurrentSensorControlMode)

                        Dim result As HandleCaptureResultOutcomes = HandleCaptureResult(command)
                        Dim failure As SensorTaskFailure = Nothing


                        Dim captureResults As CaptureResultCollection = _
                         DirectCast(mLatestCaptureCompleteResult.Command.TargetReturnValue, CaptureResultCollection)

                        Dim trueTimeout As Boolean = command.IsTimeExpired AndAlso Not captureResults Is Nothing


                        If trueTimeout OrElse Not command.TargetException Is Nothing Then

                            If trueTimeout Then
                                failure = New SensorTaskFailure
                                failure.Category = SensorTaskFailureCategory.CaptureError
                                failure.MachineNotes = CurrentSensor.FriendlyName() & " / Capture Timeout"
                            End If

                            If Not command.TargetException Is Nothing Then
                                failure = New SensorTaskFailure(command.TargetException)
                            End If

                            If failure IsNot Nothing Then AddToAllFailures(failure)

                        End If

                        Select Case result

                            Case HandleCaptureResultOutcomes.CaptureTimedOut

                                If SensorTimeoutsAreAlwaysFailures Then
                                    TallyAttempt(TallyMethod.StandaloneTimeoutFailure, failure)
                                    If SensorPromptForDetailOnTimeout Then TimeoutDetail()
                                End If

                                TaskListControl.Refresh()
                                ActivateTaskAfterSensorCheck()

                            Case HandleCaptureResultOutcomes.CaptureCancelled
                                If SensorCancellationAreAlwaysFailures Then _
                                    TallyAttempt(TallyMethod.StandaloneFailure, failure)

                                TaskListControl.Refresh()
                                ChangeMode(SensorControlMode.ActivatingTask, result.ToString)

                            Case HandleCaptureResultOutcomes.CaptureResultSucessful

                                TallyAttempt(TallyMethod.StandaloneSuccess, Nothing)
                                TaskListControl.Refresh()
                                ChangeMode(SensorControlMode.ActivatingTask, result.ToString)

                            Case HandleCaptureResultOutcomes.CaptureFailure

                                TallyAttempt(TallyMethod.StandaloneFailure, failure)
                                TaskListControl.Refresh()
                                ActivateTaskAfterSensorCheck()

                            Case HandleCaptureResultOutcomes.ReviewRequired

                                mOperatorReviewForm = New OperatorReviewForm
                                mOperatorReviewForm.Name = "OperatorReviewForm"
                                AddHandler mOperatorReviewForm.Closed, AddressOf ReviewCompleteListener
                                With mOperatorReviewForm
                                    .StartPosition = FormStartPosition.Manual
                                    .MainPictureBox.EnabledImage = CurrentSensor.LatestThumbnail
                                    .TopMost = True
                                    .UninitializeSensorsOfCorruptImages = UninitializeSensorsOfCorruptImages
                                    .CurrentTask = Me.mLatestCapturingTask
                                    Me.Enabled = False
                                    .Location = UI.LocationForCenteringChildForm(Me, mOperatorReviewForm)
                                    .Show()
                                    .BringToFront()
                                End With

                                TaskListControl.Refresh()
                                ChangeMode(SensorControlMode.ReviewingCaptureResult, result.ToString)

                        End Select


                        AttemptPicker.RefreshPicker()


                    Case SensorControlMode.ReviewingCaptureResult

                        ' --------------------------------------------------------------------------------
                        ' ReviewingCaptureResult
                        '   [Next state triggered by a ReviewForm.Closed event]
                        ' --------------------------------------------------------------------------------

                    Case SensorControlMode.HandlingCaptureReviewResponse

                        ' --------------------------------------------------------------------------------
                        ' HandlingCaptureReviewResponse
                        ' --------------------------------------------------------------------------------

                        HandleCaptureReviewResponse()


                    Case SensorControlMode.RecoveringFromSensorFailures

                        ' --------------------------------------------------------------------------------
                        ' RecoveringFromSensorFailures
                        ' --------------------------------------------------------------------------------

                        RecoverFromSensorFailures()
                        ChangeMode(SensorControlMode.AwaitingRecoveryResult, String.Empty)

                    Case SensorControlMode.JustifyingTaskSkip

                        ' --------------------------------------------------------------------------------
                        ' JustifyingTaskSkip
                        ' --------------------------------------------------------------------------------

                        Dim outcome As JustifyTaskSkipOutcomes
                        If reason = EndSessionButtonClickedReason Then
                            outcome = JustifyTaskSkip(Nothing)
                        Else
                            outcome = JustifyTaskSkip(TaskListControl.TaskToJumpTo)
                        End If

                        ' If the active task is excess, then we won't have started the justificaiton dialog, and 
                        ' therefore won't need to wait for it to be done.
                        '
                        If outcome = JustifyTaskSkipOutcomes.ActiveTaskIsExcess Then
                            ChangeMode(SensorControlMode.HandlingTaskSkipResponse, outcome.ToString)
                        End If

                        ' Likewise, if we've already skipped from the task, and we're returning to it, 
                        ' then a justification isn't needed.
                        '
                        If outcome = JustifyTaskSkipOutcomes.TaskAlreadySkipped Then
                            ChangeMode(SensorControlMode.HandlingTaskSkipResponse, String.Empty)
                        End If


                        If outcome = JustifyTaskSkipOutcomes.SubjectAlreadyLeftSession Then
                            mSubjectLeftSession = False

                            Dim destination As SensorTask = TaskListControl.TaskToJumpTo
                            mTaskFactories.MigrateActiveTask(destination)
                            TaskListControl.FinishJumpToTask(destination, True)
                            destination.SkipDestination = True
                            mEndSessionRequested = False
                            mSubjectLeftSession = False

                            ActivateTaskAfterSensorCheck()
                        End If



                    Case SensorControlMode.HandlingTaskSkipResponse

                        ' --------------------------------------------------------------------------------
                        ' HandlingTaskSkipResponse
                        ' --------------------------------------------------------------------------------

                        ' Refresh the task factories in case we've dropped some tasks - rjm - May 5 2008
                        mTaskFactories.PopulateTargets()

                        Dim newtask As SensorTask = mSkipTaskForm.TaskToSkipTo
                        'If  AndAlso (ActiveTask.IsExcess OrElse mSkipTaskForm.Reason <> SkipTaskReason.NoReason) Then



                        If (ActiveTask IsNot Nothing AndAlso ActiveTask.IsExcess _
                            OrElse mSkipTaskForm.Reason <> SkipTaskReason.NoReason _
                            OrElse (newtask IsNot Nothing AndAlso newtask.Status = SensorTaskStatus.Skipped)) Then

                            If mSkipTaskForm.Reason = SkipTaskReason.Condition Then
                                ' Copy back any changed conditions
                                CurrentConditions.AssignSubset(mSkipTaskConditions)
                                ConditionsControl.Refresh()
                            End If

                            If mSkipTaskForm.Reason = SkipTaskReason.InaccessibleBodyPart Then
                                InaccessibleBodyParts.AddRange(mSkipTaskParts)
                                InaccessibleBodyPartsControl.BindFromWireToControls()
                            End If

                            If mSkipTaskForm.Reason = SkipTaskReason.SubjectLeftSession Then

                                ' If the subject left, then we should skip all tasks 
                                mSubjectLeftSession = True
                                For i As Integer = 0 To TaskList.Count - 1
                                    TaskListControl.SelectNoTask = True
                                    TaskList(i).Status = SensorTaskStatus.Skipped
                                Next


                            Else
                                If (Not newtask Is Nothing) Then
                                    If CurrentSensor IsNot newtask.Sensor AndAlso CurrentSensor.HasLivePreview Then
                                        CurrentSensor.StopLivePreview()
                                    End If
                                    ' Otherwise, we skip just this task 
                                    ActiveTask.Status = SensorTaskStatus.Skipped

                                    ' See if we should skip all the tasks in a factory
                                    If SkippingEffectsMultipleTasks Then
                                        For i As Integer = 0 To ActiveTask.OriginatingFactory.GeneratedTasks.Count - 1
                                            ActiveTask.OriginatingFactory.GeneratedTasks(i).Status = SensorTaskStatus.Skipped
                                        Next
                                    End If


                                    TaskListControl.FinishJumpToTask(newtask, True)
                                    newtask.OriginatingFactory.ChangeAllTaskStatus(SensorTaskStatus.Unstarted)

                                    ' Mark the task as a destination for a skip event
                                    newtask.SkipDestination = True
                                    mTaskFactories.MigrateActiveTask(newtask)
                                End If
                            End If

                        End If


                        If mSkipTaskForm.Reason = SkipTaskReason.NoReason Then
                            mEndSessionRequested = False
                            mSubjectLeftSession = False
                        End If

                        If mSubjectLeftSession OrElse newtask Is Nothing Then
                            If CurrentSensor.HasLivePreview Then CurrentSensor.StopLivePreview()
                            ChangeMode(SensorControlMode.AwaitingTaskSetCompletion)
                        Else
                            ActivateTaskAfterSensorCheck()
                        End If

                        mSkipTaskForm = Nothing


                    Case SensorControlMode.StartingNewTaskSet

                        ' --------------------------------------------------------------------------------
                        ' StartingNewTaskSet
                        ' --------------------------------------------------------------------------------

                        ResetSessionFlags()
                        ActivateTaskAfterSensorCheck()

                    Case SensorControlMode.AwaitingCaptureSignal
                        ' --------------------------------------------------------------------------------
                        ' Awaiting Capture Signal
                        ' --------------------------------------------------------------------------------

                        TaskListControl.Refresh()
                        InaccessibleBodyPartsControl.Refresh()



                        Dim autoStart As Boolean = mSettings.PassiveSensorsStartAutomatically
                        Dim sensorIsPassive As Boolean = Not ActiveTask.Sensor.CapturesImmediately
                        Dim pollingNotJustCancelled As Boolean = Not ActiveTask.Sensor.PollingWasCanceled
                        Dim oneTaskStarted As Boolean
                        For i As Integer = 0 To TaskFactories.TasksOfSensor(ActiveTask.Sensor).Count - 1
                            If Not TaskFactories.TasksOfSensor(ActiveTask.Sensor)(i).IsEffectivelyUnstarted Then
                                oneTaskStarted = True
                                Exit For
                            End If
                        Next

                        If autoStart AndAlso sensorIsPassive AndAlso pollingNotJustCancelled AndAlso oneTaskStarted Then
                            ActiveTask.Sensor.ActivateSensorNow()
                        End If


                    Case SensorControlMode.ActivatingTask

                        ' --------------------------------------------------------------------------------
                        ' Activating Task
                        ' --------------------------------------------------------------------------------


                        ' Here is where we scour all of the tasks for one that we can select
                        Dim result As ActivateTaskResult = ActivateTask(args)
                        AttemptPicker.RefreshPicker()
                        TaskListControl.Refresh()


                        If mTaskFactories.AllTasks.Count = 0 Then

                            ' If there are no tasks to perform, and we didn't get here because we disabled / enabled a sensor, 
                            ' then go and hide in some lonely state.
                            '
                            ChangeMode(SensorControlMode.NoTasksToPerform)

                        Else

                            TryToUninitializeSensorsWithDeferredInitialization()

                            Select Case result
                                Case ActivateTaskResult.TaskActivated
                                    'OutputLog("BaseSensorController - ActivateTaskResult.TaskActivated ****************************")
                                    If CurrentSensor.RequiresConfiguration(ActiveTask.SensorConfiguration) Then

                                        ' If the current task is activatable and requires configuraiton, then go ahead 
                                        ' and configure it
                                        ChangeMode(SensorControlMode.ConfiguringSensor)
                                    Else
                                        ' Otherwise, we just wait for the capture signal
                                        ChangeMode(SensorControlMode.AwaitingCaptureSignal, result.ToString)
                                    End If
                                    ' Force a sensor initialization if it was deferred
                                    If CurrentSensor.DeferInitialization AndAlso CurrentSensor.IsOfflineOrUninitialized Then
                                        ActivateTaskAfterSensorCheck()
                                    End If
                                    'OutputLog("[END] BaseSensorController - ActivateTaskResult.TaskActivated ****************************")
                                Case ActivateTaskResult.NoTaskActivated
                                    'OutputLog("BaseSensorController - ActivateTaskResult.NoTaskActivated ****************************")
                                    TaskListControl.SelectNoTask = True

                                    If Not mSubjectLeftSession AndAlso SelectFirstActivatableTask() Then

                                        ' If the current task is not activatable, then select the first activatable one and try again
                                        ChangeMode(SensorControlMode.ActivatingTask, result.ToString)
                                    Else

                                        ' If there is no activatable task, go on to the next set
                                        ChangeMode(SensorControlMode.AwaitingTaskSetCompletion, result.ToString)
                                    End If
                                    'OutputLog("[END] BaseSensorController - ActivateTaskResult.NoTaskActivated ****************************")
                            End Select
                        End If



                    Case SensorControlMode.ConfiguringSensor

                        ' --------------------------------------------------------------------------------
                        ' ConfiguringSensor
                        ' --------------------------------------------------------------------------------
                        StartSensorConfiguration()
                        SensorStatusControl.RefreshSensorStatus()
                        ChangeMode(SensorControlMode.AwaitingConfigurationResult)


                    Case SensorControlMode.HandlingConfigurationResult
                        ' --------------------------------------------------------------------------------
                        ' Handle Configuration Result
                        ' --------------------------------------------------------------------------------
                        Dim result As HandleSensorConfigurationCompletionResult = _
                            HandleSensorConfigurationCompletion(args.Command)

                        SensorStatusControl.RefreshSensorStatus()
                        CurrentSensor.RefreshControls()

                        Select Case result
                            Case HandleSensorConfigurationCompletionResult.ConfigurationPassed
                                ChangeMode(SensorControlMode.AwaitingCaptureSignal)

                            Case HandleSensorConfigurationCompletionResult.ConfigurationFailed
                                ActivateTaskAfterSensorCheck()

                        End Select

                    Case SensorControlMode.EditingAttempt

                        ' --------------------------------------------------------------------------------
                        ' Editing Attempt
                        ' --------------------------------------------------------------------------------                                            
                        EditAttempt(mAttemptToEdit)

                    Case SensorControlMode.CancellingOrResumingDownload

                        ' --------------------------------------------------------------------------------
                        ' Cancel or Resume Download
                        ' -------------------------------------------------------------------------------                                            

                        If Not args.CancelDownloadTask Is Nothing Then CancelDownload(args.CancelDownloadTask)
                        If Not args.ResumeDownloadTask Is Nothing Then ResumeDownload(args.ResumeDownloadTask)

                        ActivateTaskAfterSensorCheck()

                    Case SensorControlMode.HandlingAttemptEdit
                        ' --------------------------------------------------------------------------------
                        ' HandlingAttemptEdit
                        '       - Respond to the result of an attempt edit
                        ' --------------------------------------------------------------------------------                   

                        If mAttemptEditor.DialogResult = Windows.Forms.DialogResult.OK Then

                            ' Copy back changes to the current conditions. Note that this will trigger
                            ' a condition change event, which raises a ConditionChangeListener. Within
                            ' that listener, we ignore any changes that arrive when we are in this
                            ' state (HandlingAttemptEdit).
                            '
                            CurrentConditions.AssignSubset(mAttemptEditor.CurrentConditions)
                            ConditionsControl.Refresh()

                            ' We can use assignment here because a deep copy was wired in before we started
                            InaccessibleBodyParts.Assign(mAttemptEditor.CurrentInaccessibleBodyParts)

                            ' We have to tell the control to bind back from the wire, because it doesn't do so
                            ' automatically
                            InaccessibleBodyPartsControl.BindFromWireToControls()


                            ' Copy back the new attempt 
                            '
                            Dim idx As Integer = mAttemptToEdit.ParentTask.Attempts.IndexOf(mAttemptToEdit)
                            mAttemptToEdit.ParentTask.Attempts(idx) = mAttemptEditor.Attempt
                            mAttemptToEdit.ParentTask.RefreshStatus()

                            ' This handles the situation in which we edit a task we just did, and change it
                            ' from complete to incomplete by rejecting it manually ex post facto.
                            '
                            Dim activeTaskIsSomething As Boolean = Not ActiveTask Is Nothing
                            Dim differentParentTasks As Boolean = activeTaskIsSomething AndAlso Not ActiveTask Is mAttemptToEdit.ParentTask
                            Dim currentTaskUnstarted As Boolean = activeTaskIsSomething AndAlso ActiveTask.IsEffectivelyUnstarted
                            Dim editedTaskWasPending As Boolean = mStatusOfAttemptToEditBeforeEdit = SensorTaskStatus.Pending
                            Dim editedTaskWasDone As Boolean = mStatusOfAttemptToEditBeforeEdit = SensorTaskStatus.Done
                            Dim editedTaskIsNotPending As Boolean = mAttemptToEdit.ParentTask.Status <> SensorTaskStatus.Pending
                            Dim editedTaskNowSuspended As Boolean = _
                                mAttemptEditor.Attempt.ParentTask.Status = SensorTaskStatus.Suspended

                            If activeTaskIsSomething AndAlso currentTaskUnstarted AndAlso differentParentTasks AndAlso _
                               (editedTaskWasPending Or editedTaskWasDone) AndAlso editedTaskNowSuspended AndAlso editedTaskIsNotPending Then

                                ' Hide the old sensor
                                If CurrentSensor.HasLivePreview Then CurrentSensor.StopLivePreview()
                                CurrentSensor.AsControl.Visible = False

                                ' Go ahead and migrate to that task
                                mTaskFactories.MigrateActiveTask(mAttemptToEdit.ParentTask)

                                ' Change the current conditions to reflect the newly activated task
                                CurrentConditions.AssignSubset(mAttemptToEdit.ParentTask.Conditions)

                            End If




                        End If

                        AttemptPicker.RefreshPicker()
                        TryToStartDownloads()
                        ActivateTaskAfterSensorCheck()

                    Case SensorControlMode.AwaitingTaskSetCompletion

                        ' --------------------------------------------------------------------------------
                        ' AwaitingTaskSetCompletion
                        ' --------------------------------------------------------------------------------                   

                        TryToStartDownloads()

                        Dim result As AwaitTaskSetCompletionResults = AwaitTaskSetCompletion()

                        Dim checkForConflicts As Boolean = _
                        mSettings.CheckOutstandingConflictOnComplete

                        If result = AwaitTaskSetCompletionResults.ActivatableTaskRemains Then
                            ' If there are activating tasks remaining, then go ahead and activate them
                            ChangeMode(SensorControlMode.ActivatingTask, result.ToString)

                        ElseIf result = AwaitTaskSetCompletionResults.DownloadsStillNeeded Then
                            ' If we still have downloads, then wait for the downloads to complete

                        ElseIf result = AwaitTaskSetCompletionResults.SubjectAlreadyLeft AndAlso Not mEndSessionRequested Then
                            ' If the subject already left, then we keep waiting for the 'end session' click

                        ElseIf result = AwaitTaskSetCompletionResults.TaskSetComplete AndAlso mEndSessionRequested Then

                            If checkForConflicts Then
                                ChangeMode(SensorControlMode.CheckingOutstandingConflicts)
                            Else
                                ChangeMode(SensorControlMode.CompletingTaskSet)
                            End If

                        ElseIf result = AwaitTaskSetCompletionResults.SubjectAlreadyLeft AndAlso mEndSessionRequested Then

                            If checkForConflicts Then
                                ChangeMode(SensorControlMode.CheckingOutstandingConflicts)
                            Else
                                ChangeMode(SensorControlMode.CompletingTaskSet)
                            End If

                        ElseIf result = AwaitTaskSetCompletionResults.AwaitingEndSessionClick AndAlso mEndSessionRequested Then
                            If checkForConflicts Then
                                ChangeMode(SensorControlMode.CheckingOutstandingConflicts)
                            Else
                                ChangeMode(SensorControlMode.CompletingTaskSet)
                            End If
                        End If



                    Case SensorControlMode.CheckingOutstandingConflicts
                        ' --------------------------------------------------------------------------------
                        ' CheckingOutstandingConflicts
                        ' --------------------------------------------------------------------------------                   

                        If CheckOutstandingConflicts() Then
                            ChangeMode(SensorControlMode.EditingConflict)
                        Else
                            ChangeMode(SensorControlMode.CompletingTaskSet)
                        End If
                    Case SensorControlMode.EditingConflict
                        ' --------------------------------------------------------------------------------
                        ' EditingConflict
                        ' --------------------------------------------------------------------------------                   
                        EditOutstandingConflict()

                    Case SensorControlMode.CompletingTaskSet
                        ' --------------------------------------------------------------------------------
                        ' CompletingTaskSet
                        ' --------------------------------------------------------------------------------                   
                        OnCompletingTaskSet()

                        TaskListControl.Refresh()

                        ' Force garbage collection now
                        GC.Collect()
                        GC.WaitForPendingFinalizers()

                        TaskListControl.Refresh()

                        For i As Integer = 0 To Sensors.Count - 1
                            Sensors(i).DeleteInternalImages()
                        Next

                        RaiseEvent TaskSetComplete(Me, New EventArgs)

                        ' We clear on completion rather than startup in case we're reconsituting an unfinished session
                        mTaskFactories.Clear()
                        mAllFailures.Clear()
                        mTaskSetFailures.Clear()

                        ' Wire up the sensors and task list
                        SensorStatusControl.WireSensorSet(Sensors)
                        TaskListControl.WireTaskList(TaskList)
                        TaskListControl.Refresh()

                        AttemptPicker.Clear()

                        ConditionsControl.ResetConditionControl()
                        InaccessibleBodyPartsControl.ResetControl()

                        If AutomaticallyStartNewTaskSet Then
                            ChangeMode(SensorControlMode.StartingNewTaskSet)
                        Else
                            ChangeMode(SensorControlMode.AwaitingStartOfNewTaskSet)
                        End If

                    Case SensorControlMode.NoTasksToPerform
                        ' --------------------------------------------------------------------------------
                        ' NoTasksToPeform
                        ' --------------------------------------------------------------------------------

                        ' A special state that gets entered where there are zero tasks; (that is, the 
                        ' task list shows no tasks, or, specifically, Factories.AllTasks.Count is zero

                        For i As Integer = 0 To Sensors.Count - 1
                            Sensors(i).AsControl.Visible = False
                        Next
                        SensorStatusControl.RefreshSensorStatus()

                    Case Else

                End Select

                RefreshButtons()
                RefreshBarItems()
                TryToStartDownloads()
                RefreshTabList()
            Catch ex As BadSensorStatusException
                ' If a sensor suddently throws a bad exception; stop what we're doing and check all of the sensors
                ActivateTaskAfterSensorCheck()
            Catch ex As ObjectDisposedException When mIsClosing
                ' Swallow this exception
            Finally

            End Try
        End Sub

        Private Sub ChangeMode(ByVal newMode As SensorControlMode)
            ChangeMode(newMode, String.Empty)
        End Sub

        Private Sub ChangeMode(ByVal newMode As SensorControlMode, ByVal reason As String)
            Dim args As New ChangeSensorControlModeArgs(newMode)
            args.Reason = reason
            ChangeSensorControlMode(args)
        End Sub

#End Region

#Region "  Attempt Editing  "

        Private WithEvents mAttemptEditor As AttemptEditor
        Private mStatusOfAttemptToEditBeforeEdit As SensorTaskStatus

        Private Sub SetTaskProvidingAttemptDetail(ByVal task As SensorTask)
            TaskListControl.TaskProvidingAttemptDetail = task
            AttemptPicker.WireTask(task)
        End Sub

        Private Sub EditAttempt(ByVal attempt As SensorTaskAttempt)

            ' We have to keep track of the status of the attempt to edit separately, because the parent tasks are shallow copied
            mStatusOfAttemptToEditBeforeEdit = attempt.ParentTask.Status
            mAttemptEditor = New AttemptEditor

            With mAttemptEditor
                ' FRAGILE - We must wire up in this order because the attempt editor uses the current conditions &
                ' inaccessibly body parts information to track whether or not the attempt was already in conflict
                ' when starting up
                '
                .WireCurrentConditions(CurrentConditions)
                .WireDeepCopyOfCurrentInaccessibleBodyParts(InaccessibleBodyParts)
                .WireAttempt(attempt.DeepCopyEditables())
                .UninitializeSensorsOfCorruptImages = mSettings.UninitializeSensorsOfCorruptImages
                AddHandler .Closed, AddressOf AttemptEditCompleteListener
                Me.Enabled = False
                .Location = UI.LocationForCenteringChildForm(Me, mAttemptEditor)
                .Show()
            End With

        End Sub

#End Region

#Region "  Tally Attempt  "
        Private Enum TallyMethod
            None
            StandaloneSuccess
            StandaloneFailure
            StandaloneTimeoutFailure
            Review
        End Enum

        Private Sub TallyAttempt(ByVal tally As TallyMethod, ByVal captureFailure As SensorTaskFailure)

            Dim conditions As ConditionCollection = CurrentConditions.SubsetDeepCopy(ActiveTask.Conditions)
            conditions.MarkAsReadOnly()

            ' Notice that we sneak in a reference to the attempt's parent task, so that conditions and predicates
            ' that require category information work correctly.
            '
            conditions.WireParentTask(ActiveTask)

            Dim targetParts As BodyPartCollection = CurrentSensor.TargetParts.DeepCopy()
            Dim inaccessibleParts As BodyPartCollection = CurrentSensor.InaccessibleParts.DeepCopy()
            Dim downloadId As Guid = mLatestCaptureCompleteResult.Command.CommandId
            Dim thumbnail As Image = Nothing
            Dim rejectedByOperator As Boolean
            Dim corruptImage As Boolean
            Dim downloadStage As Boolean
            Dim results As CaptureResultCollection = Nothing

            Select Case tally

                Case TallyMethod.StandaloneFailure

                    thumbnail = Nothing
                    rejectedByOperator = False
                    downloadStage = False
                    corruptImage = False
                    ResultPopup.Show(Me, ResultPopupStyle.Failure)

                Case TallyMethod.StandaloneTimeoutFailure

                    thumbnail = Nothing
                    rejectedByOperator = False
                    downloadStage = False
                    corruptImage = False
                    ResultPopup.Show(Me, ResultPopupStyle.Timeout)

                Case TallyMethod.Review

                    thumbnail = CurrentSensor.LatestThumbnail
                    rejectedByOperator = mOperatorReviewForm.Rejected
                    corruptImage = mOperatorReviewForm.Corrupt
                    downloadStage = True

                    If rejectedByOperator Then
                        ResultPopup.Show(Me, ResultPopupStyle.Reject)
                    Else
                        ResultPopup.Show(Me, ResultPopupStyle.Accept)
                    End If

                Case TallyMethod.StandaloneSuccess

                    thumbnail = CurrentSensor.LatestThumbnail
                    rejectedByOperator = False
                    corruptImage = False
                    downloadStage = False
                    results = DirectCast(mLatestCaptureCompleteResult.Command.TargetReturnValue, CaptureResultCollection)
                    ResultPopup.Show(Me, ResultPopupStyle.Success)


            End Select

            mLatestCapturingTask.TallyAttempt( _
                     conditions:=conditions, _
                     targetParts:=targetParts, _
                     inaccessibleParts:=inaccessibleParts, _
                     thumbnail:=thumbnail, _
                     results:=results, _
                     captureFailure:=captureFailure, _
                     downloadId:=downloadId, _
                     withDownloadStage:=downloadStage, _
                     rejected:=rejectedByOperator, _
                     corrupt:=corruptImage)

            mLatestCapturingTask.RefreshStatus()

            Console.WriteLine("Tally attempt is done; resetting capturing task!")
            mLatestCapturingTask = Nothing
            mLatestCaptureCompleteResult = Nothing


        End Sub
#End Region

#Region "  Activate Task  "


        Private Enum ActivateTaskResult
            TaskActivated
            NoTaskActivated
        End Enum

        Private Function SelectFirstActivatableTask() As Boolean
            If TaskList.FirstActivatableTask = -1 Then Return False
            TaskListControl.SelectTask(TaskList.FirstActivatableTask)
            Return True
        End Function


        Private Function ActivateTask(ByVal args As ChangeSensorControlModeArgs) As ActivateTaskResult

            If Not CurrentSensor Is Nothing Then
                ' Regardless of what sensor is visible, stop the live preview and hide it
                If CurrentSensor.HasLivePreview Then CurrentSensor.StopLivePreview()
            End If


            ' Track what the active task is before recomputing it
            Dim activeTaskBeforeUpdate As SensorTask = mTaskFactories.ActiveTask

            ' Track what the detail provider was before computing the active task
            Dim detailProviderBeforeUpdate As SensorTask = TaskListControl.TaskProvidingAttemptDetail

            ' Track if the detail provider was the active task
            Dim detailProviderWasActiveTask As Boolean = ActiveTask Is detailProviderBeforeUpdate

            'KAYEE - Debug
            'OutputLog("BaseSensorController mTaskFactories.PopulateTargets()")
            ' Repopulate the task factories based on the new current conditions and missing parts
            mTaskFactories.PopulateTargets()

            If ActiveTask Is Nothing OrElse TaskListControl.SelectNoTask OrElse Me.mSubjectLeftSession Then
                ' If there is no active task, no task selected, or if the subject left then bail out now
                Return ActivateTaskResult.NoTaskActivated
            End If


            '
            If detailProviderWasActiveTask AndAlso _
                Not mTaskFactories.ActiveTask Is detailProviderBeforeUpdate AndAlso _
                mTaskFactories.ActiveTask.Attempts.Count > 0 Then
                '
                ' If the detail provider was the current task, and the current task has changed (and has attempts),
                ' then update the detail provider. By insisting that the current task has attempts in order
                ' for it to be the detail provider, we continually show the results of the last attempt.
                '
                TaskListControl.TaskProvidingAttemptDetail = mTaskFactories.ActiveTask
            End If


            If Not activeTaskBeforeUpdate Is mTaskFactories.ActiveTask Then
                '
                ' If the active task changed, then task list and conditions control should reflect that
                '
                CurrentConditions.AssignSubset(mTaskFactories.ActiveTask.Conditions)
                TaskListControl.SelectTask(mTaskFactories.ActiveTask)

            ElseIf Not CurrentConditions.EqualsSubset(mTaskFactories.ActiveTask.Conditions) Then
                '
                ' If the current conditions don't match the active task, then that task was
                ' selected (by the factories) as a last resort. Therefore, if this ActivateTask() was called
                ' due to a change in condition, then the changed condition isn't going to stick. 
                ' We need to warn the user that the conditions changed.
                '
                If args.Reason = "ConditionsChange" Then
                    MessageBox.Show( _
                        Messages.YouCantChangeThatConditionJustNow(UICulture), _
                        Messages.SorryBang(UICulture), _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Error, _
                        MessageBoxDefaultButton.Button1, _
                        MessageBoxOptions.DefaultDesktopOnly)
                End If

                CurrentConditions.AssignSubset(mTaskFactories.ActiveTask.Conditions)
            End If

            ' Make sure the attempt picker is showing details for the appropriate task
            AttemptPicker.WireTask(TaskListControl.TaskProvidingAttemptDetail)

            RefreshSensorControls()

            ' Remind the operator of conditions that warrant their attention
            Dim conditionsMessage As String = CurrentConditions.FriendlyToString(UICulture, ActiveTask)
            If conditionsMessage <> InfrastructureMessages.Messages.None(UICulture) Then
                CurrentSensor.ConditionsLabelText = conditionsMessage
            Else
                CurrentSensor.ConditionsLabelText = String.Empty
            End If

            ' Start live preview
            TryToActivateLivePreview()


            ' Make sure the sensor knows what parts are being imaged. 
            ' Since changing the inaccessible parts also calls ActivateTask, the CurrentSensorControlMode
            ' 
            CurrentSensor.TargetParts.Assign(ActiveTask.TargetParts)
            CurrentSensor.InaccessibleParts.Assign(ActiveTask.TargetInaccessibleParts)
            CurrentSensor.TargetCategory = ActiveTask.TargetCategory

            Return ActivateTaskResult.TaskActivated

        End Function

#End Region

#Region "  Sensor Failure & Recovery  "

        Private WithEvents mSensorRecoveryForm As SensorRecoveryForm
        Protected ReadOnly Property SensorRecoveryFrom() As SensorRecoveryForm
            Get
                Return mSensorRecoveryForm
            End Get
        End Property

        Private Sub ActivateTaskAfterSensorCheck()
            Static callcount As Integer = 0
            callcount += 1
            mModeToEnterAfterSensorCheck = SensorControlMode.ActivatingTask
            ChangeMode(SensorControlMode.StartingSensorCheck, String.Empty)
        End Sub

        Private Enum StartSensorCheckResult
            RecoveryRequired
            InitializationRequired
            InitializationsPending
            NoActionRequired
        End Enum

        Private Function StartSensorCheck() As StartSensorCheckResult

            ' Don't do anything if there are any initializations pending
            If Me.mOutstandingInitializations.Count > 0 Then
                ' MsgBox("Initializations pending!!!")
                Return StartSensorCheckResult.InitializationsPending
            End If

            ' See if any sensor requires recovery
            If Sensors.RequiresRecoveryCount > 0 Then
                Return StartSensorCheckResult.RecoveryRequired
            End If

            For i As Integer = 0 To Sensors.Count - 1
                Dim sensor As ISensor = Me.Sensor(i)

                Dim notDisabled As Boolean = Not sensor.Disabled
                Dim offlineOrUninit As Boolean = sensor.IsOfflineOrUninitialized
                Dim notDefered As Boolean = Not sensor.DeferInitialization OrElse sensor.DeferInitialization And sensor Is CurrentSensor

                If notDisabled AndAlso offlineOrUninit AndAlso notDefered Then
                    Return StartSensorCheckResult.InitializationRequired
                End If
            Next

            Return StartSensorCheckResult.NoActionRequired

        End Function

        Private Sub RecoverFromSensorFailures()

            For i As Integer = 0 To Sensors.Count - 1
                Dim sensor As ISensor = Me.Sensor(i)
                If sensor.RequiresRecovery Then 'Not sensor.Disabled AndAlso sensor.IsOfflineOrUninitialized Then

                    mSensorRecoveryForm = New SensorRecoveryForm
                    mSensorRecoveryForm.Text = sensor.FriendlyName()
                    mSensorRecoveryForm.FailingSensor = sensor

                    Me.Enabled = False
                    mSensorRecoveryForm.StartPosition = FormStartPosition.Manual
                    mSensorRecoveryForm.Location = UI.LocationForCenteringChildForm(Me, mSensorRecoveryForm)
                    mSensorRecoveryForm.Show()
                    Exit For
                End If
            Next

        End Sub

        Private Enum HandleSensorRecoveryOutcomes
            Retry
            GiveUp
        End Enum

        Private Function HandleSensorRecoveryResult() As HandleSensorRecoveryOutcomes
            With mSensorRecoveryForm
                If .DesiredRecoveryAction = SensorRecoveryForm.RecoveryAction.GiveUp Then
                    Return HandleSensorRecoveryOutcomes.GiveUp
                Else
                    Return HandleSensorRecoveryOutcomes.Retry
                End If
            End With
        End Function

        'Private Sub CheckForOutstandingSensorErrors()
        '    ForbidInvokeRequired(Me)
        '    For i As Integer = 0 To TaskList.Count - 1
        '        Dim task As SensorTask = TaskList(i)
        '        If task.Sensor.LatestStatus <> SensorStatus.Online Then task.Enabled = False
        '    Next
        'End Sub


#End Region

#Region "  Task Skipping  "

        Private mSkipTaskParts As BodyPartCollection
        Private mSkipTaskConditions As ConditionCollection
        Private mSubjectLeftSession As Boolean

        Private WithEvents mSkipTaskForm As SkipTaskForm
        Protected ReadOnly Property SkipTaskForm() As SkipTaskForm
            Get
                Return mSkipTaskForm
            End Get
        End Property
        Private Enum JustifyTaskSkipOutcomes
            ActiveTaskIsExcess
            ActiveTaskIsNotExcess
            SubjectAlreadyLeftSession
            TaskAlreadySkipped
        End Enum
        Private Function JustifyTaskSkip(ByVal taskToJumpTo As SensorTask) As JustifyTaskSkipOutcomes

            If mSubjectLeftSession Then Return JustifyTaskSkipOutcomes.SubjectAlreadyLeftSession

            mSkipTaskForm = New SkipTaskForm
            AddHandler mSkipTaskForm.Closed, AddressOf SkipJustificationResultListener

            mSkipTaskParts = InaccessibleBodyParts.DeepCopy
            mSkipTaskConditions = CurrentConditions.DeepCopy()

            With mSkipTaskForm
                .WireInaccessibleBodyParts(mSkipTaskParts)
                .WireCurrentConditions(mSkipTaskConditions)
                .WireTasks(ActiveTask, taskToJumpTo)

                If ActiveTask.IsExcess Then
                    Return JustifyTaskSkipOutcomes.ActiveTaskIsExcess
                ElseIf taskToJumpTo IsNot Nothing AndAlso _
                       taskToJumpTo.Status = SensorTaskStatus.Skipped Then
                    Return JustifyTaskSkipOutcomes.TaskAlreadySkipped
                Else
                    Me.Enabled = False
                    .StartPosition = FormStartPosition.Manual
                    .Location = UI.LocationForCenteringChildForm(Me, mSkipTaskForm)
                    .Show()
                    .BringToFront()
                    Return JustifyTaskSkipOutcomes.ActiveTaskIsNotExcess
                End If

            End With
        End Function


#End Region

#Region "  Timeouts  "

        Private mTimeoutDetailForm As TimeoutDetailForm
        Private Sub TimeoutDetail()
            mTimeoutDetailForm = New TimeoutDetailForm
            mTimeoutDetailForm.ShowDialog(Me)
            mTaskFactories.ActiveTask.LatestAttempt.TimeoutReason = mTimeoutDetailForm.Reason
            If mTimeoutDetailForm.Reason = TimeoutDetailForm.TimeoutReason.OtherReason Then
                mTaskFactories.ActiveTask.LatestAttempt.OtherTimeoutReason = mTimeoutDetailForm.OtherReason
            End If


        End Sub

#End Region

#Region "  Implements ISensorControlModeChangeProducer  "

        Private mPreviousSensorControlMode As SensorControlMode = SensorControlMode.StartingForm
        Private mCurrentSensorControlMode As SensorControlMode = SensorControlMode.StartingForm

        Public Event SensorControlModeChange As EventHandler(Of SensorControlModeChangeEventArgs) _
        Implements ISensorControlModeChangeProducer.SensorControlModeChange

        Public ReadOnly Property CurrentSensorControlMode() As SensorControlMode Implements ISensorControlModeProvider.CurrentSensorControlMode
            Get
                Return Me.mCurrentSensorControlMode
            End Get
        End Property

        Public ReadOnly Property PreviousSensorControlMode() As SensorControlMode Implements ISensorControlModeProvider.PreviousSensorControlMode
            Get
                Return Me.mPreviousSensorControlMode
            End Get
        End Property
#End Region

#Region "  Factory Wiring & Unwiring "


        Protected Sub WireTaskFactories(ByVal factories As SensorTaskFactoryCollection)
            mTaskFactories = factories

            For i As Integer = 0 To TaskFactories.Sensors.Count - 1
                RegisterSensor(Sensors(i))
                Sensors(i).AsControl.Visible = False
                AddCommandCompleteHandlers(Sensors(i))
            Next

            AddCaptureActivatedHandlers()
            AddConditionChangeHandlers()
            AddBadStatusHandlers()


        End Sub

        Private Sub UnwireTaskFactories()
            UninitializeAllSensors()

            RemoveBadStatusHandlers()
            RemoveConditionChangeHandlers()
            RemoveCaptureActivatedHandlers()


            For i As Integer = 0 To TaskFactories.Sensors.Count - 1
                RemoveCommandCompleteHandlers(Sensors(i))
            Next

            ' Reverse order since unregistering effectively deletes the sensor from the list
            For i As Integer = TaskFactories.Sensors.Count - 1 To 0 Step -1
                UnregisterSensor(Sensors(i))
                SensorPanel.Controls.RemoveAt(i)
            Next

            mTaskFactories = Nothing

            Return
        End Sub

        Private Sub LoadSessionBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles LoadSessionBarItem.Click

            Dim oldWorkingDirectory As String = System.IO.Directory.GetCurrentDirectory

            OpenSessionFileDialog.FileName = "session.xml"
            Dim result As DialogResult = OpenSessionFileDialog.ShowDialog()
            System.IO.Directory.SetCurrentDirectory(oldWorkingDirectory)


            If result = Windows.Forms.DialogResult.OK Then

                PopulateFromFile(OpenSessionFileDialog.FileName, New SensorTaskFactoryCollection)

            End If


        End Sub

        Protected Sub UninitializeAllSensors()

            For i As Integer = 0 To Sensors.Count - 1
                If Not Sensors(i).Disabled Then 'AndAlso Sensors(i).LatestStatus = SensorStatus.Offline Then
                    Sensors(i).Uninitialize()
                End If
            Next

            ' Try getting rid of the 'AndAlso Sensors(i).lateststatus = sensorstatus.offline and see if that helps
        End Sub

        Private Sub AddCommandCompleteHandlers(ByVal sensor As ISensor)
            With sensor
                .InitializationCommandTemplate.AddCommandCompleteHandler(AddressOf InitializationCommandCompleteListener)

                If Not .ConfigurationCommandTemplate Is Nothing Then
                    .ConfigurationCommandTemplate.AddCommandCompleteHandler(AddressOf ConfigurationCommandCompleteListener)
                End If

                .CaptureCommandTemplate.AddCommandCompleteHandler(AddressOf CaptureCommandCompleteListener)

                If Not .DownloadCommandTemplate Is Nothing Then
                    .DownloadCommandTemplate.AddCommandCompleteHandler(AddressOf DownloadCommandCompleteListener)
                End If

            End With
        End Sub

        Private Sub RemoveCommandCompleteHandlers(ByVal sensor As ISensor)

            With sensor
                .InitializationCommandTemplate.RemoveCommandCompleteHandler(AddressOf InitializationCommandCompleteListener)

                If Not .ConfigurationCommandTemplate Is Nothing Then
                    .ConfigurationCommandTemplate.RemoveCommandCompleteHandler(AddressOf ConfigurationCommandCompleteListener)
                End If

                .CaptureCommandTemplate.RemoveCommandCompleteHandler(AddressOf CaptureCommandCompleteListener)

                If Not .DownloadCommandTemplate Is Nothing Then
                    .DownloadCommandTemplate.RemoveCommandCompleteHandler(AddressOf DownloadCommandCompleteListener)
                End If


            End With
        End Sub

        Private Sub AddConditionChangeHandlers()

            ' Hook in the conditions
            Dim en As IEnumerator = TaskFactories.CurrentConditions.ConditionsEnumerator
            While en.MoveNext
                Dim c As Condition = DirectCast(en.Current, Condition)
                AddHandler c.ConditionValueChanged, AddressOf ConditionChangeListener
            End While
        End Sub

        Private Sub RemoveConditionChangeHandlers()
            Dim en As IEnumerator = TaskFactories.CurrentConditions.ConditionsEnumerator
            While en.MoveNext
                Dim c As Condition = DirectCast(en.Current, Condition)
                RemoveHandler c.ConditionValueChanged, AddressOf ConditionChangeListener
            End While
        End Sub

        Private Sub AddCaptureActivatedHandlers()
            For i As Integer = 0 To Sensors.Count - 1
                AddHandler Sensors(i).CaptureActivated, AddressOf CaptureActivatedListener
            Next
        End Sub


        Private Sub RemoveCaptureActivatedHandlers()
            For i As Integer = 0 To Sensors.Count - 1
                RemoveHandler Sensors(i).CaptureActivated, AddressOf CaptureActivatedListener
            Next
        End Sub

        Private Sub AddBadStatusHandlers()
            For i As Integer = 0 To Sensors.Count - 1
                AddHandler Sensors(i).BadStatus, AddressOf BadStatusListener
            Next
        End Sub

        Private Sub RemoveBadStatusHandlers()
            For i As Integer = 0 To Sensors.Count - 1
                RemoveHandler Sensors(i).BadStatus, AddressOf BadStatusListener
            Next
        End Sub


        Private Sub SaveSessionBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles SaveSessionBarItem.Click
            Cursor = Cursors.IBeam
            SaveSessionFileDialog.FileName = "session.xml"
            SaveSessionFileDialog.ShowDialog()
            mTaskFactories.SaveAsXmlFile(SaveSessionFileDialog.FileName)
            Cursor = Cursors.Default
        End Sub

#End Region

#Region "  Startup  "

        Private mAutomaticallyStartNewTaskSets As Boolean = True
        Public Property AutomaticallyStartNewTaskSet() As Boolean
            Get
                Return mAutomaticallyStartNewTaskSets
            End Get
            Set(ByVal value As Boolean)
                mAutomaticallyStartNewTaskSets = value
            End Set
        End Property



        Private Sub HandleStartupTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles StartupTimer.Tick
            ''The timer has fired.  Do startup file parsing here.
            'Dim taskFile As String
            'Dim factories As New SensorTaskFactoryCollection
            'Try
            '    Dim settingsfile As New IO.FileStream(StartupSettingsFileName, IO.FileMode.Open)
            '    mSettings = DirectCast(smSettingsSerializer.Deserialize(settingsfile), BaseSensorControllerSettings)
            '    settingsfile.Close()
            'Catch ex As IO.FileNotFoundException
            '    ' Swallow this exception
            'Catch ex As IO.IOException
            '    'OutputLog("BaseSensorController " & ex.Message)
            '    Console.WriteLine(DateTime.Now() & " BaseSensorController " & ex.Message)
            '    ' Swallow this exception
            'End Try

            'Try
            '    taskFile = mSettings.TaskDefinitionFileName
            '    If Not IO.Path.IsPathRooted(taskFile) Then
            '        taskFile = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, taskFile)
            '    End If
            '    PopulateFromFile(taskFile, factories)
            'Catch dex As IO.DirectoryNotFoundException
            '    MsgBox(dex.Message & vbNewLine & "Task list will be empty.")
            '    factories = New SensorTaskFactoryCollection
            'Catch ex As IO.FileNotFoundException
            '    MsgBox("Could not file file " & ex.FileName & ". Task list will be empty.")
            '    factories = New SensorTaskFactoryCollection
            '    WireTaskFactories(factories)
            'End Try

            'The timer has fired.  Do startup file parsing here.
            Dim taskFile As String
            Dim factories As New SensorTaskFactoryCollection
            Try
                Dim settingsfile As New IO.FileStream(StartupSettingsFileName, IO.FileMode.Open)
                mSettings = DirectCast(smSettingsSerializer.Deserialize(settingsfile), BaseSensorControllerSettings)
                settingsfile.Close()

                Try
                    taskFile = mSettings.TaskDefinitionFileName
                    If Not IO.Path.IsPathRooted(taskFile) Then
                        taskFile = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, taskFile)
                    End If
                    PopulateFromFile(taskFile, factories)
                Catch dex As IO.DirectoryNotFoundException
                    MsgBox(dex.Message & vbNewLine & "Task list will be empty.")
                    factories = New SensorTaskFactoryCollection
                Catch ex As IO.FileNotFoundException
                    MsgBox("Could not file file " & ex.FileName & ". Task list will be empty.")
                    factories = New SensorTaskFactoryCollection
                    WireTaskFactories(factories)
                Catch ane As System.ArgumentNullException
                    'MsgBox(ane.Message & vbNewLine & "Task list will be empty.")
                    'factories = New SensorTaskFactoryCollection
                End Try

            Catch ex As IO.FileNotFoundException
                ' Swallow this exception
            Catch ex As IO.IOException
                'OutputLog("BaseSensorController " & ex.Message)
                Console.WriteLine(DateTime.Now() & " BaseSensorController " & ex.Message)
                ' Swallow this exception
            End Try

           

            StartupTimer.Stop()
            StartupTimer.Dispose()
        End Sub

        Public Sub StartNewTaskSet()
            ResetSessionFlags()
            ChangeMode(SensorControlMode.StartingNewTaskSet, String.Empty)
        End Sub

        Private Sub ResetSessionFlags()
            mSubjectLeftSession = False
            mEndSessionRequested = False
        End Sub

        Protected Overridable Sub OnAwaitingStartOfNewTaskSet()
            ' Overridable
        End Sub

#End Region

#Region "  Advanced Options  "

        Private Sub BaseSensorController_KeyPress(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Back AndAlso e.Control = True Then
                AdvancedParentBarItem.Visible = Not AdvancedParentBarItem.Visible

            ElseIf e.Shift = True AndAlso e.KeyCode = Keys.Tab Then
                Debugging.WriteLine(Messages.ShiftPlusTab(UICulture))
                If mCurrentTabIndex = 0 Then
                    mCurrentTabIndex = mTabOrderList.Count - 1
                Else
                    mCurrentTabIndex -= 1
                End If
                SelectTabControl(mCurrentTabIndex)
            ElseIf e.KeyCode = Keys.Tab Then
                Debugging.WriteLine(Messages.Tab(UICulture))
                If mCurrentTabIndex < mTabOrderList.Count - 1 Then
                    mCurrentTabIndex += 1
                Else
                    mCurrentTabIndex = 0
                End If
                SelectTabControl(mCurrentTabIndex)
            End If


        End Sub

        Public Property CheckOutstandingConflictsOnComplete() As Boolean
            Get
                Return mSettings.CheckOutstandingConflictOnComplete
            End Get
            Set(ByVal value As Boolean)
                mSettings.CheckOutstandingConflictOnComplete = value
            End Set
        End Property
        Public Property IncludeSensorsOfDisabledTasks() As Boolean
            Get
                Return mSettings.IncludeSensorsOfDisabledTasks
            End Get
            Set(ByVal value As Boolean)
                mSettings.IncludeSensorsOfDisabledTasks = value
            End Set
        End Property
        Public Property SensorTimeoutsAreAlwaysFailures() As Boolean
            Get
                Return mSettings.SensorTimeoutsAreAlwaysFailures
            End Get
            Set(ByVal value As Boolean)
                mSettings.SensorTimeoutsAreAlwaysFailures = value
            End Set
        End Property
        Public Property SensorCancellationAreAlwaysFailures() As Boolean
            Get
                Return mSettings.SensorCancellationAreAlwaysFailures
            End Get
            Set(ByVal value As Boolean)
                mSettings.SensorCancellationAreAlwaysFailures = value
            End Set
        End Property
        Public Property SensorPromptForDetailOnTimeout() As Boolean
            Get
                Return mSettings.SensorPromptForDetailOnTimeout
            End Get
            Set(ByVal value As Boolean)
                mSettings.SensorPromptForDetailOnTimeout = value
            End Set
        End Property
        Public Property SkippingEffectsMultipleTasks() As Boolean
            Get
                Return mSettings.SkippingEffectsMultipleTasks
            End Get
            Set(ByVal value As Boolean)
                mSettings.SkippingEffectsMultipleTasks = value
            End Set
        End Property
        Public Property UninitializeSensorsOfCorruptImages() As Boolean
            Get
                Return mSettings.UninitializeSensorsOfCorruptImages
            End Get
            Set(ByVal value As Boolean)
                mSettings.UninitializeSensorsOfCorruptImages = value
            End Set
        End Property

        Public Property PassiveSensorsAutoStart() As Boolean
            Get
                Return mSettings.PassiveSensorsStartAutomatically
            End Get
            Set(ByVal value As Boolean)
                mSettings.PassiveSensorsStartAutomatically = value
            End Set
        End Property

        Public Property DeleteImagesOnTaskSetCompletion() As Boolean
            Get
                Return mSettings.DeleteInternalImagesOnSetCompletion
            End Get
            Set(ByVal value As Boolean)
                mSettings.DeleteInternalImagesOnSetCompletion = value
            End Set
        End Property

        Private Sub ResetCorruptSensorsBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ResetCorruptSensorsBarItem.Click
            ResetCorruptSensorsBarItem.Checked = Not ResetCorruptSensorsBarItem.Checked
            mSettings.UninitializeSensorsOfCorruptImages = ResetCorruptSensorsBarItem.Checked
        End Sub

        Private Sub TimeoutsAreAttemptsBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TimeoutsAreAttemptsBarItem.Click
            TimeoutsAreAttemptsBarItem.Checked = Not TimeoutsAreAttemptsBarItem.Checked
            SensorTimeoutsAreAlwaysFailures = TimeoutsAreAttemptsBarItem.Checked
        End Sub

        Private Sub CancellationIsAttemptBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles CancellationIsAttemptBarItem.Click
            CancellationIsAttemptBarItem.Checked = Not CancellationIsAttemptBarItem.Checked
            SensorCancellationAreAlwaysFailures = CancellationIsAttemptBarItem.Checked
        End Sub

        Private Sub AlwaysPromptForDetailOnTimeoutBarItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TimeoutAlwaysPromptForDetailBarItem.Click
            TimeoutAlwaysPromptForDetailBarItem.Checked = Not TimeoutAlwaysPromptForDetailBarItem.Checked
            SensorPromptForDetailOnTimeout = TimeoutAlwaysPromptForDetailBarItem.Checked
        End Sub

        Private Sub AlwaysCheckOutstandingConflictBarItem_Click(ByVal Sender As Object, ByVal e As EventArgs) _
        Handles AlwaysCheckOutstandingConflictBarItem.Click
            AlwaysCheckOutstandingConflictBarItem.Checked = Not AlwaysCheckOutstandingConflictBarItem.Checked
            CheckOutstandingConflictsOnComplete = AlwaysCheckOutstandingConflictBarItem.Checked
        End Sub

        Private Sub DeleteImagesOnTaskSetCompletionItem_click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles DeleteImagesOnTaskSetCompletionItem.Click
            DeleteImagesOnTaskSetCompletionItem.Checked = Not DeleteImagesOnTaskSetCompletionItem.Checked
            DeleteImagesOnTaskSetCompletion = DeleteImagesOnTaskSetCompletionItem.Checked
        End Sub

        Private Sub TaskDefinitionsfile_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TaskDefinitionFileBarItem.Click
            Dim result As DialogResult = TaskDefinitionFileDialog.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                mSettings.TaskDefinitionFileName = TaskDefinitionFileDialog.FileName
            End If
            RefreshBarItems()
        End Sub

        Private Sub DemoModeBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles DemoModeBarItem.Click
            DemoModeBarItem.Checked = Not DemoModeBarItem.Checked
            ' FIXME
        End Sub

        Private Sub PassiveSensorsAutoStartbaritem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PassiveSensorsAutoStartBarItem.Click
            PassiveSensorsAutoStartBarItem.Checked = Not PassiveSensorsAutoStartBarItem.Checked
            PassiveSensorsAutoStart = PassiveSensorsAutoStartBarItem.Checked
        End Sub

        Private Sub FontsBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FontsBarItem.Click
            Dim fonter As New Refonter
            fonter.TargetControl = Me
            fonter.ShowDialog()
        End Sub

        Private Sub RefreshBarItems()

            Dim sessionFile As String = IO.Path.GetFileName(mSettings.TaskDefinitionFileName)
            If sessionFile <> String.Empty Then
                TaskDefinitionFileBarItem.Text = Messages.DefaultSessionMenuText(UICulture) & StringUtilities.Parenthesize(UICulture, sessionFile)
            Else
                TaskDefinitionFileBarItem.Text = Messages.DefaultSessionMenuText(UICulture)
            End If

            With mSettings
                AlwaysCheckOutstandingConflictBarItem.Checked = .CheckOutstandingConflictOnComplete
                CancellationIsAttemptBarItem.Checked = .SensorCancellationAreAlwaysFailures
                DemoModeBarItem.Checked = .DemoMode
                DeleteImagesOnTaskSetCompletionItem.Checked = .DeleteInternalImagesOnSetCompletion
                PassiveSensorsAutoStartBarItem.Checked = .PassiveSensorsStartAutomatically
                SkippingDeactivatesMultipleTasksBarItem.Checked = .SkippingEffectsMultipleTasks
                ResetCorruptSensorsBarItem.Checked = .UninitializeSensorsOfCorruptImages
                TimeoutsAreAttemptsBarItem.Checked = .SensorTimeoutsAreAlwaysFailures
            End With

            ' Session loading is permitted whenever task selection is permitted
            LoadSessionBarItem.Enabled = SensorControlModeSets.LoadSessionPermitted.Contains(CurrentSensorControlMode)
            SaveSessionBarItem.Enabled = SensorControlModeSets.SaveSessionPermitted.Contains(CurrentSensorControlMode)
            ExitBarItem.Enabled = SensorControlModeSets.ExitPermitted.Contains(CurrentSensorControlMode)



        End Sub


        Private Sub CrashNowBarItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CrashNowBarItem.Click
            Throw New ApplicationException("Intentional system crash.")
        End Sub

#End Region

#Region "  AutoSize  & UI "

        Private mUICulture As CultureInfo = CultureInfo.CurrentUICulture
        Public Property UICulture() As CultureInfo Implements IHasUICulture.UICulture
            Get
                Return mUICulture
            End Get
            Set(ByVal Value As CultureInfo)
                mUICulture = Value
            End Set
        End Property


        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements UI.IAutosizable.RefreshAutomaticLayout
            If MainPanel Is Nothing Or StatusBar Is Nothing Then Return
            MainPanel.RefreshAutomaticLayout(graphics)
            StatusBar.Font = GlobalUISettings.Defaults.Fonts.Regular
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

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If NearestForm Is Nothing Then Return
            RecursiveSuspendLayout(Me)
            Dim g As Graphics = CreateGraphics()
            RefreshAutomaticLayout(g)
            RecursiveResumeLayout(Me)
            g.Dispose()
        End Sub

        Protected Overrides Sub OnMaximizedBoundsChanged(ByVal e As EventArgs)
            If NearestForm Is Nothing Then Return
            RefreshAutomaticLayout(CreateGraphics)
        End Sub


        Private Sub RefreshCursor(ByVal mode As SensorControlMode)
            Select Case mode

                Case SensorControlMode.AwaitingCaptureSignal
                    Cursor = Cursors.Arrow
                Case SensorControlMode.AwaitingTaskSetCompletion
                    Cursor = Cursors.Arrow
                Case SensorControlMode.NoTasksToPerform
                    Cursor = Cursors.Arrow
                Case Else
                    Cursor = Cursors.WaitCursor
            End Select

        End Sub

        Private Sub RefreshConditionsControl(ByVal mode As SensorControlMode)
            If SensorControlModeSets.ConditionChangePermitted.Contains(mode) AndAlso Me.mOutstandingDownloads.Count = 0 Then
                ConditionsControl.Enabled = True
            Else
                ConditionsControl.Enabled = False
            End If
            ConditionsControl.Refresh()
        End Sub

        Private Sub RefreshInaccessibleBodyPartsControl(ByVal mode As SensorControlMode)

            If SensorControlModeSets.InaccessibleBodyPartsChangeable.Contains(mode) AndAlso Me.mOutstandingDownloads.Count = 0 Then

                ' Check all current sensor and disabled the injury picker for those modality not on the list. We do this first to avoid flicker.
                InaccessibleBodyPartsControl.FingerPickerEnable = CheckIfCategoryExistInCurrentSensors(SensorModality.Fingerprint)
                InaccessibleBodyPartsControl.IrisPickerEnable = CheckIfCategoryExistInCurrentSensors(SensorModality.Iris)
                InaccessibleBodyPartsControl.Enabled = True
            Else
                InaccessibleBodyPartsControl.Enabled = False
            End If
            InaccessibleBodyPartsControl.Refresh()
        End Sub

        Private Sub RefreshControlBoxes()
            ' Only show the control box on nice occasions
            ControlBox = SensorControlModeSets.ExitPermitted.Contains(mCurrentSensorControlMode)
        End Sub

        Private Sub RefreshSensorControls()
            ' Make only the active sensor visible
            For i As Integer = 0 To Sensors.Count - 1
                Sensors(i).AsControl.Visible = CurrentSensor Is Sensors(i) AndAlso Not CurrentSensor.Disabled
                If Sensors(i).AsControl.Visible Then Sensors(i).AsControl.BringToFront()
                Sensors(i).AsControl.Refresh()
            Next
        End Sub

        Private Sub RefreshAttemptPicker()
            AttemptPicker.AttemptPickerBoxesEnabled = SensorControlModeSets.AttemptEditPermitted.Contains(CurrentSensorControlMode)
        End Sub

        Private Sub FillBarItemIcons()

            Dim resourceType As Type = GetType(UI.Icons)

            Dim regularMenuIcons As New ImageList
            With regularMenuIcons
                .ColorDepth = ColorDepth.Depth32Bit
                .ImageSize = New Size(16, 16)
                .Images.Add(New Bitmap(resourceType, "close.16.png"))
                .Images.Add(New Bitmap(resourceType, "diskette.16.png"))
                .Images.Add(New Bitmap(resourceType, "open_save.16.png"))

            End With



            Dim disabledMenuIcons As New ImageList
            With disabledMenuIcons
                .ColorDepth = ColorDepth.Depth32Bit
                .ImageSize = New Size(16, 16)
                .Images.Add(New Bitmap(resourceType, "close.16.disabled.png"))
                .Images.Add(New Bitmap(resourceType, "diskette.16.disabled.png"))
                .Images.Add(New Bitmap(resourceType, "open_save.16.disabled.png"))
            End With

            Dim hotMenuIcons As New ImageList
            With hotMenuIcons
                .ColorDepth = ColorDepth.Depth32Bit
                .ImageSize = New Size(16, 16)
                .Images.Add(New Bitmap(resourceType, "close.16.hot.png"))
                .Images.Add(New Bitmap(resourceType, "diskette.16.hot.png"))
                .Images.Add(New Bitmap(resourceType, "open_save.16.hot.png"))
            End With



            Dim barItems As SF.Tools.XPMenus.BarItem() = {ExitBarItem, SaveSessionBarItem, LoadSessionBarItem}
            For i As Integer = 0 To barItems.Length - 1
                With barItems(i)
                    .ImageList = regularMenuIcons
                    .DisabledImageList = disabledMenuIcons
                    .HighlightImageList = hotMenuIcons
                End With
            Next

            With ExitBarItem
                .ImageIndex = 0
                .DisabledImageIndex = 0
                .HighlightedImageIndex = 0
            End With

            With SaveSessionBarItem
                .ImageIndex = 1
                .DisabledImageIndex = 1
                .HighlightedImageIndex = 1
            End With

            With LoadSessionBarItem
                .ImageIndex = 2
                .DisabledImageIndex = 2
                .HighlightedImageIndex = 2
            End With

        End Sub


        Protected Overrides Sub OnActivated(ByVal e As EventArgs)
            MyBase.OnActivated(e)

            If Not mSensorRecoveryForm Is Nothing Then mSensorRecoveryForm.BringToFront()
            If Not mTimeoutDetailForm Is Nothing Then mTimeoutDetailForm.BringToFront()
            If Not mSkipTaskForm Is Nothing Then mSkipTaskForm.BringToFront()
            If Not mAttemptEditor Is Nothing Then mAttemptEditor.BringToFront()
            If Not mOperatorReviewForm Is Nothing Then mOperatorReviewForm.BringToFront()

        End Sub


#End Region

#Region "  Task Set Completion  "

        Protected Overridable Sub OnCompletingTaskSet()

        End Sub

        Private Function CheckOutstandingConflicts() As Boolean
            Dim taskCollection As SensorTaskCollection = TaskFactories.AllTasks
            For i As Integer = 0 To taskCollection.Count - 1
                If taskCollection(i).HasAttemptsInConflict(CurrentConditions, InaccessibleBodyParts) Then Return True
            Next
            Return False
        End Function


        Private Function EditOutstandingConflict() As Boolean

            ' Returns true if editing is --- return false if no more conflict editing is required
            Dim taskCollection As SensorTaskCollection = TaskFactories.AllTasks
            For i As Integer = 0 To taskCollection.Count - 1
                If taskCollection(i).HasAttemptsInConflict(CurrentConditions, InaccessibleBodyParts) Then
                    For j As Integer = 0 To taskCollection(i).Attempts.Count - 1
                        If taskCollection(i).Attempts(j).IsSuccessful AndAlso _
                           taskCollection(i).Attempts(j).InConflict(CurrentConditions, InaccessibleBodyParts) Then
                            mAttemptToEdit = taskCollection(i).Attempts(j)
                            EditAttempt(mAttemptToEdit)
                            Return True
                        End If
                    Next
                End If
            Next
            Return False
        End Function

        Private Enum AwaitTaskSetCompletionResults
            TaskSetComplete
            AwaitingEndSessionClick
            ActivatableTaskRemains
            DownloadsStillNeeded
            SubjectAlreadyLeft
        End Enum
        Private Function AwaitTaskSetCompletion() As AwaitTaskSetCompletionResults

            If mSubjectLeftSession Then Return AwaitTaskSetCompletionResults.SubjectAlreadyLeft
            'KAYEE - Debug begin
            'Dim activatableTask As Boolean = TaskList.HasActivatableTask
            'Dim isEndsesion As Boolean = Not mEndSessionRequested
            'OutputLog("[BaseSensorController.AwaitTaskSetCompletion() - " & activatableTask.ToString & " Andalso " & isEndsesion.ToString & "]")
            'If activatableTask AndAlso isEndsesion Then
            '    Return AwaitTaskSetCompletionResults.ActivatableTaskRemains
            'End If
            'Kayee - Debug end
            'below is the original code
            If TaskList.HasActivatableTask AndAlso Not mEndSessionRequested Then
                Return AwaitTaskSetCompletionResults.ActivatableTaskRemains
            End If


            If TaskList.IsDownloadStillNeeded AndAlso Not mEndSessionWithoutFinishDownload Then
                'If TaskList.IsDownloadStillNeeded Then
                Return AwaitTaskSetCompletionResults.DownloadsStillNeeded
            End If

            If mEndSessionRequested Then Return AwaitTaskSetCompletionResults.AwaitingEndSessionClick

            Return AwaitTaskSetCompletionResults.TaskSetComplete

        End Function

        Private Enum ReasonsTaskSetIsNotComplete
            None
            DownloadStillNeeded
            MoreTasksToBeDone
        End Enum

        Public Event TaskSetComplete As EventHandler(Of EventArgs)

#End Region

#Region "  Status Bars  "

        Private Sub RefreshPercentCompleteBar()

            Dim doneCount As Integer = 0
            For i As Integer = 0 To mTaskFactories.AllTasks.Count - 1
                Dim task As SensorTask = mTaskFactories.AllTasks(i)
                If task.Status = SensorTaskStatus.Done Then doneCount += 1
            Next

            PercentCompleteBar.Maximum = Math.Max(1, mTaskFactories.AllTasks.Count)
            PercentCompleteBar.Value = doneCount
            PercentCompleteBar.Refresh()

        End Sub

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> _
        Private Sub RefreshStateStatusBar(ByVal mode As SensorControlMode)

            ErrorCountStatusBar.Text = Messages.NErrors(UICulture, mAllFailures.Count)
            ErrorCountStatusBar.Refresh()


            Dim text As String = mode.ToString

            Select Case mode
                Case SensorControlMode.StartingForm
                    text = Messages.LoadingApplicationDotDotDot(UICulture)
                Case SensorControlMode.StartingSensorCheck
                    text = Messages.CheckingStatusOfSensorsDotDotDot(UICulture)
                Case SensorControlMode.StartingSensorInitialization
                    text = Messages.StartingSensorInitializationDotDotDot(UICulture)
                Case SensorControlMode.AwaitingSensorInitializationCompletion
                    text = Messages.WaitingForSensorsToInitializeDotDotDot(UICulture)
                Case SensorControlMode.HandlingSensorInitializationCompletion
                    text = Messages.FinishingSensorInitializationDotDotDot(UICulture)
                Case SensorControlMode.RecoveringFromSensorFailures
                    text = Messages.RecoveringFromSensorFailuresDotDotDot(UICulture)
                Case SensorControlMode.AwaitingRecoveryResult
                    text = Messages.AwaitingRecoveryResultDotDotDot(UICulture)
                Case SensorControlMode.HandlingRecoveryResult
                    text = Messages.AwaitingRecoveryResultDotDotDot(UICulture)
                Case SensorControlMode.AwaitingStartOfNewTaskSet
                    text = Messages.AwaitingStartOfNewTaskSetDotDotDot(UICulture)
                Case SensorControlMode.StartingNewTaskSet
                    text = Messages.StartingNewTaskSetDotDotDot(UICulture)
                Case SensorControlMode.ActivatingTask
                    text = Messages.DeterminingNextTaskDotDotDot(UICulture)
                Case SensorControlMode.JustifyingTaskSkip
                    text = Messages.WaitingForAValidReasonToSkipThisTaskDotDotDot(UICulture)
                Case SensorControlMode.HandlingTaskSkipResponse
                    text = Messages.HandlingTaskSkipJustificationDotDotDot(UICulture)
                Case SensorControlMode.AwaitingCaptureSignal
                    text = Messages.WaitingForCaptureToBeginDotDotDot(UICulture)
                Case SensorControlMode.AwaitingCaptureResult
                    text = Messages.CapturingBiometricDataDotDotDot(UICulture)
                Case SensorControlMode.HandlingCaptureResult
                    text = Messages.HandlingCaptureResultDotDotDot(UICulture)
                Case SensorControlMode.EditingAttempt
                    text = Messages.EditingAttemptDotDotDot(UICulture)
                Case SensorControlMode.HandlingAttemptEdit
                    text = Messages.HandlingAttemptEditDotDotDot(UICulture)
                Case SensorControlMode.ReviewingCaptureResult
                    text = Messages.ReviewingCaptureResultDotDotDot(UICulture)
                Case SensorControlMode.HandlingCaptureReviewResponse
                    text = Messages.HandlingReviewCaptureResultDotDotDot(UICulture)
                Case SensorControlMode.CancellingOrResumingDownload
                    text = Messages.CancellingOrResumingDownloadDotDotDot(UICulture)
                Case SensorControlMode.FinalizingSensorResult
                    text = Messages.FinalizingSensorResultDotDotDot(UICulture)
                Case SensorControlMode.GeneratingTemplate
                    text = Messages.GeneratingTemplateDotDotDot(UICulture)
                Case SensorControlMode.OperatorExplainingTimeout
                    text = Messages.OperatorExplainingTimeoutDotDotDot(UICulture)
                Case SensorControlMode.TallyingFailedAttempt
                    text = Messages.TallyingFailedAttemptDotDotDot(UICulture)
                Case SensorControlMode.NoTasksToPerform
                    text = Messages.NothingToDoSinceThereAreNoTasksToPerform(UICulture)
                Case SensorControlMode.AwaitingTaskSetCompletion
                    If TaskList.IsDownloadStillNeeded Then
                        text = Messages.WaitingForDownloadsToFinishDotDotDot(UICulture)
                    Else
                        text = Messages.AwaitingTaskSetCompletionDotDotDot(UICulture)
                    End If
                Case SensorControlMode.ConfiguringSensor
                    text = Messages.ConfiguringSensorDotDotDot(UICulture)
                Case SensorControlMode.AwaitingConfigurationResult
                    text = Messages.AwaitingConfigurationResultDotDotDot(UICulture)
                Case SensorControlMode.HandlingConfigurationResult
                    text = Messages.HandlingConfigurationResultDotDotDot(UICulture)
                Case SensorControlMode.CheckingOutstandingConflicts
                    text = Messages.CheckingOutstandingConflictsDotDotDot(UICulture)
                Case SensorControlMode.CompletingTaskSet
                    text = Messages.CompletingTaskSetDotDotDot(UICulture)
            End Select
            StateStatusBar.Text = text
            StateStatusBar.Refresh()

        End Sub

        Private Function GetFailuresAsLongString() As String
            Dim builder As New System.Text.StringBuilder

            ' Only show the last ten errors
            Dim start As Integer = Math.Max(0, mAllFailures.Count - 10)
            If start <> 0 Then builder.Append(InfrastructureMessages.Messages.Ellipsis(UICulture))

            For i As Integer = start To mAllFailures.Count - 1
                Dim failure As SensorTaskFailure = DirectCast(mAllFailures(i), SensorTaskFailure)
                builder.Append(failure.Timestamp.ToLocalTime.ToShortTimeString())
                builder.Append(InfrastructureMessages.Messages.ColonSpace(UICulture))
                builder.Append(failure.MachineNotes)
                If i <> mAllFailures.Count - 1 Then builder.Append(vbNewLine)
            Next
            Return builder.ToString
        End Function


        Private Sub RefreshFailureCountToolTip()
            ErrorCountToolTip.RemoveAll()
            ErrorCountToolTip.SetToolTip(ErrorCountStatusBar, GetFailuresAsLongString)
        End Sub

        Private Sub AddTaskSetFailure(ByVal failure As SensorTaskFailure)
            mTaskSetFailures.Add(failure)
            mAllFailures.Add(failure)
            RefreshFailureCountToolTip()
        End Sub

        Private Sub AddToAllFailures(ByVal failure As SensorTaskFailure)
            mAllFailures.Add(failure)
            RefreshFailureCountToolTip()
        End Sub

        Private Sub ErrorCountStatusBar_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles ErrorCountStatusBar.MouseEnter
            RefreshFailureCountToolTip()
        End Sub



#End Region

#Region " Buttons Panel "

        Private mEndSessionRequested As Boolean


        Private Sub RefreshButtons()
            SafeInvokeNoArgSub(Me, AddressOf RefreshButtonsImplementation)
        End Sub


        Private Sub RefreshButtonsImplementation()

            If SensorControlModeSets.TaskSelectionPermitted.Contains(CurrentSensorControlMode) _
                AndAlso mOutstandingDownloads.Count = 0 Then
                ButtonsPanel.EndSessionButton.Enabled = True
            Else
                ButtonsPanel.EndSessionButton.Enabled = False
            End If
            ButtonsPanel.Refresh()
        End Sub
#End Region

#Region "  Demo Only  "

        Public Property IsDemo() As Boolean
            Get
                Return mSettings.DemoMode
            End Get
            Set(ByVal value As Boolean)
                mSettings.DemoMode = value
            End Set
        End Property

#End Region

#Region "  Tabstops  "

        Private Sub TurnOffTabStop(ByVal ControlObj As Control)
            For Each c As Control In ControlObj.Controls
                c.TabStop = False
                TurnOffTabStop(c)
            Next
        End Sub

        Private Sub RefreshTabList()

            mTabOrderList.Clear()


            If mTaskFactories.ActiveTask IsNot Nothing Then
                AddToTabList(CurrentSensor.TabList)
            End If

            If SensorStatusControl.Enabled Then AddToTabList(SensorStatusControl.TabList)
            If AttemptPicker.Enabled Then AddToTabList(AttemptPicker.TabList)
            If InaccessibleBodyPartsControl.Enabled Then AddToTabList(InaccessibleBodyPartsControl.TabList)
            If ConditionsControl.Enabled Then AddToTabList(ConditionsControl.TabList)
            If ButtonsPanel.Enabled Then AddToTabList(ButtonsPanel.TabList)

            SelectTabControl(0)
        End Sub

        Private Sub AddToTabList(ByVal controls As Collection(Of Control))
            If controls Is Nothing Then Return
            For i As Integer = 0 To controls.Count - 1
                mTabOrderList.Add(controls(i))
            Next
        End Sub

        Private mCurrentTabIndex As Integer
        Private mTabOrderList As New Collection(Of Control)

        Private Sub SelectTabControl(ByVal index As Integer)
            If mTabOrderList.Count > 0 Then mTabOrderList(index).Focus()
        End Sub

#End Region

#Region "  Settings Persistence "
        Private mSettings As New BaseSensorControllerSettings
        Private Shared smSettingsSerializer As New XmlSerializer(GetType(BaseSensorControllerSettings))
        Private Const scmInitialSettingsFileName As String = "initial-settings.xml"
        Private Const scmUserSettingsFileName As String = "current-settings.xml"
#End Region

#Region " Check Current Task "
        Private Function CheckIfCategoryExistInCurrentSensors(ByVal modality As SensorModality) As Boolean
            For i As Integer = 0 To Sensors.Count - 1
                If Sensors(i).Modality = modality AndAlso Not Sensors(i).Disabled Then
                    Return True
                End If
            Next
            Return False
        End Function
#End Region

        '#Region "Debug"
        '        Private Sub OutputtoLog(ByVal msg As String)
        '            Dim sw As New System.IO.StreamWriter("c:\TestingLog2.txt", True)
        '            sw.WriteLine(DateTime.Now & " - " & msg)
        '            sw.Flush()
        '            sw.Close()
        '        End Sub
        '#End Region
    End Class

    <Serializable()> Public Class BaseSensorControllerSettings

        Private Shared DefaultWindowPosition As New Point(10, 10)
        Private Shared DefaultWindowSize As New Size(800, 600)

        Private mTaskDefinitionFileName As String '= "Configurations\Empty.xml"
        Public Property TaskDefinitionFileName() As String
            Get
                Return mTaskDefinitionFileName
            End Get
            Set(ByVal value As String)
                mTaskDefinitionFileName = value
            End Set
        End Property

        Private mCheckOutstandingConflictOnComplete As Boolean
        Public Property CheckOutstandingConflictOnComplete() As Boolean
            Get
                Return mCheckOutstandingConflictOnComplete
            End Get
            Set(ByVal value As Boolean)
                mCheckOutstandingConflictOnComplete = value
            End Set
        End Property
        Private mPassiveSensorsStartAutomatically As Boolean
        Public Property PassiveSensorsStartAutomatically() As Boolean
            Get
                Return mPassiveSensorsStartAutomatically
            End Get
            Set(ByVal value As Boolean)
                mPassiveSensorsStartAutomatically = value
            End Set
        End Property
        Private mDemoMode As Boolean = True
        Public Property DemoMode() As Boolean
            Get
                Return mDemoMode
            End Get
            Set(ByVal value As Boolean)
                mDemoMode = value
            End Set
        End Property
        Private mIncludeSensorsOfDisabledTasks As Boolean
        Public Property IncludeSensorsOfDisabledTasks() As Boolean
            Get
                Return mIncludeSensorsOfDisabledTasks
            End Get
            Set(ByVal value As Boolean)
                mIncludeSensorsOfDisabledTasks = value
            End Set
        End Property
        Private mSkippingEffectsMultipleTasks As Boolean
        Public Property SkippingEffectsMultipleTasks() As Boolean
            Get
                Return mSkippingEffectsMultipleTasks
            End Get
            Set(ByVal value As Boolean)
                mSkippingEffectsMultipleTasks = value
            End Set
        End Property
        Private mDeleteInternalImagesOnSetCompletion As Boolean = True
        Public Property DeleteInternalImagesOnSetCompletion() As Boolean
            Get
                Return mDeleteInternalImagesOnSetCompletion
            End Get
            Set(ByVal value As Boolean)
                mDeleteInternalImagesOnSetCompletion = value
            End Set
        End Property
        Private mSensorPromptForDetailOnTimeout As Boolean
        Public Property SensorPromptForDetailOnTimeout() As Boolean
            Get
                Return mSensorPromptForDetailOnTimeout
            End Get
            Set(ByVal value As Boolean)
                mSensorPromptForDetailOnTimeout = value
            End Set
        End Property
        Private mSensorTimeoutsAreAlwaysFailures As Boolean = True
        Public Property SensorTimeoutsAreAlwaysFailures() As Boolean
            Get
                Return mSensorTimeoutsAreAlwaysFailures
            End Get
            Set(ByVal value As Boolean)
                mSensorTimeoutsAreAlwaysFailures = value
            End Set
        End Property
        Private mSensorCancellationAreAlwaysFailures As Boolean
        Public Property SensorCancellationAreAlwaysFailures() As Boolean
            Get
                Return mSensorCancellationAreAlwaysFailures
            End Get
            Set(ByVal value As Boolean)
                mSensorCancellationAreAlwaysFailures = value
            End Set
        End Property
        Private mUninitializeSensorsOfCorruptImages As Boolean
        Public Property UninitializeSensorsOfCorruptImages() As Boolean
            Get
                Return mUninitializeSensorsOfCorruptImages
            End Get
            Set(ByVal value As Boolean)
                mUninitializeSensorsOfCorruptImages = value
            End Set
        End Property
        Private mWindowLocation As Point = DefaultWindowPosition
        Public Property WindowLocation() As Point
            Get
                Return mWindowLocation
            End Get
            Set(ByVal value As Point)
                mWindowLocation = value
            End Set
        End Property
        Private mWindowSize As Size = DefaultWindowSize
        Public Property WindowSize() As Size
            Get
                Return mWindowSize
            End Get
            Set(ByVal value As Size)
                mWindowSize = value
            End Set
        End Property

    End Class

    Public Class ChangeSensorControlModeArgs

        Private mNewMode As SensorControlMode
        Private mCommand As AsyncCommand
        Private mTrigger As SensorModeChangeTrigger
        Private mReason As String

        Private mCancelDownloadTask As SensorTask
        Private mResumeDownloadTask As SensorTask
        Private mCaptureActivatedTask As SensorTask
        Private mTaskProvidingAttemptDetail As SensorTask


        Public Property NewMode() As SensorControlMode
            Get
                Return mNewMode
            End Get
            Set(ByVal value As SensorControlMode)
                mNewMode = value
            End Set
        End Property
        Public Property Command() As AsyncCommand
            Get
                Return mCommand
            End Get
            Set(ByVal Value As AsyncCommand)
                mCommand = Value
            End Set
        End Property
        Public Property Trigger() As SensorModeChangeTrigger
            Get
                Return mTrigger
            End Get
            Set(ByVal Value As SensorModeChangeTrigger)
                mTrigger = Value
            End Set
        End Property
        Public Property Reason() As String
            Get
                Return mReason
            End Get
            Set(ByVal Value As String)
                mReason = Value
            End Set
        End Property

        Public Property CancelDownloadTask() As SensorTask
            Get
                Return mCancelDownloadTask
            End Get
            Set(ByVal Value As SensorTask)
                mCancelDownloadTask = Value
            End Set
        End Property
        Public Property ResumeDownloadTask() As SensorTask
            Get
                Return mResumeDownloadTask
            End Get
            Set(ByVal Value As SensorTask)
                mResumeDownloadTask = Value
            End Set
        End Property
        Public Property CaptureActivatedTask() As SensorTask
            Get
                Return mCaptureActivatedTask
            End Get
            Set(ByVal Value As SensorTask)
                mCaptureActivatedTask = Value
            End Set
        End Property
        Public Property TaskProvidingAttemptDetail() As SensorTask
            Get
                Return mTaskProvidingAttemptDetail
            End Get
            Set(ByVal Value As SensorTask)
                mTaskProvidingAttemptDetail = Value
            End Set
        End Property


        Public Sub New(ByVal newMode As SensorControlMode)
            mNewMode = newMode
            mTrigger = SensorModeChangeTrigger.ExplicitTransition
            mReason = String.Empty
        End Sub

    End Class


End Namespace
