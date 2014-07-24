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


Namespace Mbark.Sensors

    Public Class CaptureResultPanel
        Inherits RadioGroupBox

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
        Friend WithEvents CorruptImageCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents SmoothPictureBox As Mbark.UI.SmoothPictureBox
        Friend WithEvents RejectCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents WrongTaskComboBoxAdv As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
        Public WithEvents WrongTaskCheckBox As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaptureResultPanel))
            Me.SmoothPictureBox = New Mbark.UI.SmoothPictureBox
            Me.RejectCheckBox = New System.Windows.Forms.CheckBox
            Me.CorruptImageCheckBox = New System.Windows.Forms.CheckBox
            Me.WrongTaskCheckBox = New System.Windows.Forms.CheckBox
            Me.WrongTaskComboBoxAdv = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv
            Me.InnerPanel.SuspendLayout()
            CType(Me.WrongTaskComboBoxAdv, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'InnerPanel
            '
            Me.InnerPanel.Controls.Add(Me.WrongTaskComboBoxAdv)
            Me.InnerPanel.Controls.Add(Me.WrongTaskCheckBox)
            Me.InnerPanel.Controls.Add(Me.CorruptImageCheckBox)
            Me.InnerPanel.Controls.Add(Me.RejectCheckBox)
            Me.InnerPanel.Controls.Add(Me.SmoothPictureBox)
            resources.ApplyResources(Me.InnerPanel, "InnerPanel")
            '
            'GroupRadioButton
            '
            resources.ApplyResources(Me.GroupRadioButton, "GroupRadioButton")
            '
            'SmoothPictureBox
            '
            Me.SmoothPictureBox.Alignment = Mbark.UI.SmoothPictureBoxAlignment.Center
            Me.SmoothPictureBox.Backwards = False
            Me.SmoothPictureBox.BorderColor = System.Drawing.Color.Black
            Me.SmoothPictureBox.BorderThickness = 1
            Me.SmoothPictureBox.DisabledImage = Nothing
            resources.ApplyResources(Me.SmoothPictureBox, "SmoothPictureBox")
            Me.SmoothPictureBox.EnabledImage = Nothing
            Me.SmoothPictureBox.Name = "SmoothPictureBox"
            Me.SmoothPictureBox.OverlayColor = System.Drawing.Color.Black
            Me.SmoothPictureBox.OverlayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SmoothPictureBox.OverlayText = Nothing
            Me.SmoothPictureBox.WithBorder = False
            '
            'RejectCheckBox
            '
            resources.ApplyResources(Me.RejectCheckBox, "RejectCheckBox")
            Me.RejectCheckBox.Name = "RejectCheckBox"
            '
            'CorruptImageCheckBox
            '
            resources.ApplyResources(Me.CorruptImageCheckBox, "CorruptImageCheckBox")
            Me.CorruptImageCheckBox.Name = "CorruptImageCheckBox"
            '
            'WrongTaskCheckBox
            '
            resources.ApplyResources(Me.WrongTaskCheckBox, "WrongTaskCheckBox")
            Me.WrongTaskCheckBox.Name = "WrongTaskCheckBox"
            '
            'WrongTaskComboBoxAdv
            '
            Me.WrongTaskComboBoxAdv.FlatStyle = Syncfusion.Windows.Forms.Tools.ComboFlatStyle.System
            Me.WrongTaskComboBoxAdv.IgnoreThemeBackground = True
            resources.ApplyResources(Me.WrongTaskComboBoxAdv, "WrongTaskComboBoxAdv")
            Me.WrongTaskComboBoxAdv.Name = "WrongTaskComboBoxAdv"
            Me.WrongTaskComboBoxAdv.SuppressDropDownEvent = False
            '
            'CaptureResultPanel
            '
            Me.Name = "CaptureResultPanel"
            resources.ApplyResources(Me, "$this")
            Me.InnerPanel.ResumeLayout(False)
            CType(Me.WrongTaskComboBoxAdv, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mAttemptWire As SensorTaskAttempt
        Private mOriginalTaskCategory As SensorTaskCategory

        Private mWrongTaskIndexToTask As New Hashtable
        Public Sub WireAttempt(ByVal attempt As SensorTaskAttempt)
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")
            mAttemptWire = attempt
            SmoothPictureBox.EnabledImage = New Bitmap(attempt.ThumbnailImage)
            mOriginalTaskCategory = mAttemptWire.CapturedCategory

            mWrongTaskIndexToTask.Clear()
            WrongTaskComboBoxAdv.Items.Clear()

            For i As Integer = 0 To mAttemptWire.ParentTask.OriginatingFactory.ReassignableSensorTaskCategories.Count - 1
                Dim category As SensorTaskCategory = mAttemptWire.ParentTask.OriginatingFactory.ReassignableSensorTaskCategories(i)
                WrongTaskComboBoxAdv.Items.Add(SensorTaskCategorySupport.ToString(category))
                mWrongTaskIndexToTask(i) = category
                If category = mAttemptWire.CapturedCategory Then WrongTaskComboBoxAdv.SelectedIndex = i
            Next


            If WrongTaskComboBoxAdv.Items.Count = 0 Then
                ' If there isn't any category to change to, then disable the control
                WrongTaskComboBoxAdv.Items.Add(SensorTaskCategorySupport.ToString(attempt.CapturedCategory))
                WrongTaskCheckBox.Enabled = False
                WrongTaskComboBoxAdv.SelectedIndex = 0
            End If


        End Sub



        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return

            RejectCheckBox.Text = Messages.RejectThisImage(UICulture)
            CorruptImageCheckBox.Text = Messages.ImageIsCorrupt(UICulture)
            WrongTaskCheckBox.Text = Messages.WrongTask(UICulture)

            WrongTaskComboBoxAdv.Enabled = False
            WrongTaskComboBoxAdv.DropDownStyle = ComboBoxStyle.DropDownList
            If Not mAttemptWire Is Nothing Then
                RejectImage = mAttemptWire.IsRejected
                CorruptImage = mAttemptWire.HasCorruptImage
            End If
        End Sub

        Private mImageJustMarkedAsCorrupt As Boolean
        Public ReadOnly Property ImageJustMarkedAsCorrupt() As Boolean
            Get
                Return mImageJustMarkedAsCorrupt
            End Get
        End Property


        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If NearestForm Is Nothing Then Return
            RefreshAutomaticLayout(NearestForm.CreateGraphics)
            MyBase.HeaderText = "Captured Image" 'i18n
        End Sub

        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
            MyBase.RefreshAutomaticLayout(graphics)
            Dim baseMinimumWidth As Integer = MyBase.MinimumWidth

            RejectCheckBox.Font = GlobalUISettings.Defaults.Fonts.Small
            CorruptImageCheckBox.Font = GlobalUISettings.Defaults.Fonts.Small
            WrongTaskCheckBox.Font = GlobalUISettings.Defaults.Fonts.Small
            WrongTaskComboBoxAdv.Font = GlobalUISettings.Defaults.Fonts.Small

            ' CheckBox heights
            Mbark.UI.AutoSize.CheckBox(UICulture, graphics, WrongTaskCheckBox)
            Mbark.UI.AutoSize.CheckBox(UICulture, graphics, RejectCheckBox)
            Mbark.UI.AutoSize.CheckBox(UICulture, graphics, CorruptImageCheckBox)
            UI.AutoSize.ComboBoxAdv(UICulture, graphics, WrongTaskComboBoxAdv)

            ' Checkboxes are at the bottom of the panel, so we place them from the bottom up
            RejectCheckBox.Location = LowerLeft(InnerPanel, -RejectCheckBox.Height - TotalTopPadding - TotalBottomPadding)
            CorruptImageCheckBox.Location = UpperLeft(RejectCheckBox, -CorruptImageCheckBox.Height)

            ' Nudge the combo box in from the left margin, the checkbox should have no indent. The double indent is because it looks better
            Dim loc As Point = UpperLeft(CorruptImageCheckBox, -WrongTaskComboBoxAdv.Height)
            WrongTaskComboBoxAdv.Location = New Point(loc.X + 2 * GlobalUISettings.UndocumentedPaddingConstants.CheckboxIndent, loc.Y)
            WrongTaskCheckBox.Location = New Point(loc.X, UpperLeft(WrongTaskComboBoxAdv, -WrongTaskCheckBox.Height).Y)

            ' Fill the rest with the image
            SmoothPictureBox.Height = WrongTaskCheckBox.Location.Y - 1

            mMinimumWidth = 0
            mMinimumWidth = Math.Max(mMinimumWidth, WrongTaskCheckBox.Width + WrongTaskComboBoxAdv.Width)
            mMinimumWidth = Math.Max(mMinimumWidth, CorruptImageCheckBox.Width)
            mMinimumWidth = Math.Max(mMinimumWidth, RejectCheckBox.Width)
            mMinimumWidth = Math.Max(mMinimumWidth, baseMinimumWidth)

            ' So that the image isn't tiny, we make the minimum height the same as the width
            mMinimumHeight = mMinimumWidth

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

        Public Property CorruptImage() As Boolean
            Get
                Return CorruptImageCheckBox.CheckState = CheckState.Checked
            End Get
            Set(ByVal value As Boolean)
                If InDesignMode(Me) Or mAttemptWire Is Nothing Then Return
                If value Then
                    CorruptImageCheckBox.CheckState = CheckState.Checked
                Else
                    CorruptImageCheckBox.CheckState = CheckState.Unchecked
                End If
                mAttemptWire.HasCorruptImage = value
            End Set
        End Property

        Public Property RejectImage() As Boolean
            Get
                Return RejectCheckBox.CheckState = CheckState.Checked
            End Get
            Set(ByVal value As Boolean)
                If InDesignMode(Me) Or mAttemptWire Is Nothing Then Return
                If value Then
                    RejectCheckBox.CheckState = CheckState.Checked
                Else
                    RejectCheckBox.CheckState = CheckState.Unchecked
                End If
                mAttemptWire.IsRejected = value
            End Set
        End Property


        Private mRejectCheckStateBeforeCorruptChecked As CheckState = CheckState.Unchecked
        Private Sub CorruptImageCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CorruptImageCheckBox.CheckedChanged

            If CorruptImageCheckBox.CheckState = CheckState.Checked Then
                mRejectCheckStateBeforeCorruptChecked = RejectCheckBox.CheckState
                RejectCheckBox.CheckState = CheckState.Checked
                RejectCheckBox.Enabled = False
                mImageJustMarkedAsCorrupt = True
            Else
                RejectCheckBox.CheckState = mRejectCheckStateBeforeCorruptChecked
                RejectCheckBox.Enabled = True
                RejectCheckBox.Refresh()
            End If

            mAttemptWire.HasCorruptImage = CorruptImageCheckBox.CheckState = CheckState.Checked
        End Sub

        Private Sub RejectCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RejectCheckBox.CheckedChanged
            mAttemptWire.IsRejected = RejectCheckBox.CheckState = CheckState.Checked
        End Sub


        Private Sub WrongTaskCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrongTaskCheckBox.CheckedChanged

            If WrongTaskCheckBox.CheckState = CheckState.Checked Then
                RejectCheckBox.Enabled = False
                CorruptImageCheckBox.Enabled = False
                WrongTaskComboBoxAdv.Enabled = True
            Else
                RejectCheckBox.Enabled = True
                CorruptImageCheckBox.Enabled = True
                WrongTaskComboBoxAdv.Enabled = False


                ' When the checkbox is unchecked, we should restore the category to its original
                mAttemptWire.CapturedCategory = Me.mOriginalTaskCategory
                For i As Integer = 0 To mAttemptWire.ParentTask.OriginatingFactory.ReassignableSensorTaskCategories.Count - 1
                    Dim category As SensorTaskCategory = mAttemptWire.ParentTask.OriginatingFactory.ReassignableSensorTaskCategories(i)
                    If category = mAttemptWire.CapturedCategory Then WrongTaskComboBoxAdv.SelectedIndex = i
                Next
            End If


            RaiseEvent WrongTaskCheckBoxCheckedChanged(Me, New EventArgs)
        End Sub

        Public Event WrongTaskCheckBoxCheckedChanged As EventHandler(Of EventArgs)
        Public Event WrongTaskComboBoxAdvSelectedIndexChanged As EventHandler(Of EventArgs)

        Private Sub WrongTaskComboBoxAdv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles WrongTaskComboBoxAdv.SelectedIndexChanged

            ' If the map from WrongTaskComboBox.SelectedIndex to task is empty, then don't bother responding to this event
            If mWrongTaskIndexToTask.Count = 0 Then Return

            Dim newCategory As SensorTaskCategory = _
                DirectCast(mWrongTaskIndexToTask(WrongTaskComboBoxAdv.SelectedIndex), SensorTaskCategory)

            If newCategory = mAttemptWire.CapturedCategory Then Return

            ' Bind the selected category to the task wire
            mAttemptWire.CapturedCategory = newCategory

            ' Clear the target parts of those just captured 
            mAttemptWire.TargetPartsOnCapture.RemoveRange(mAttemptWire.TargetPartsOnCapture, False)

            ' Get the appropriate parts for the task
            mAttemptWire.TargetPartsOnCapture.AddRange(BodyPartCollection.ForTask(mAttemptWire.CapturedCategory))

            RaiseEvent WrongTaskComboBoxAdvSelectedIndexChanged(Me, New EventArgs)

        End Sub
    End Class

End Namespace