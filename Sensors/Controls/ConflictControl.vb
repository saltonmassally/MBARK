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

Imports Mbark.UI.GlobalUISettings
Imports Mbark.UI
Imports Mbark.SensorMessages

Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Namespace Mbark.Sensors

    Public Class ConflictControl
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
        Friend WithEvents OverrideCheckBox As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
        Friend WithEvents DescriptionTextBox As Mbark.UI.AutosizableRichTextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.OverrideCheckBox = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv
            Me.DescriptionTextBox = New Mbark.UI.AutosizableRichTextBox
            Me.InnerPanel.SuspendLayout()
            CType(Me.OverrideCheckBox, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'GroupRadioButton
            '
            Me.GroupRadioButton.Name = "GroupRadioButton"
            '
            'InnerPanel
            '
            Me.InnerPanel.Controls.Add(Me.DescriptionTextBox)
            Me.InnerPanel.Controls.Add(Me.OverrideCheckBox)
            Me.InnerPanel.Name = "InnerPanel"
            Me.InnerPanel.Size = New System.Drawing.Size(506, 269)
            '
            'OverrideCheckBox
            '
            Me.OverrideCheckBox.BorderColor = System.Drawing.SystemColors.WindowFrame
            Me.OverrideCheckBox.CheckedInt = 1
            Me.OverrideCheckBox.CheckedString = "Checked"
            Me.OverrideCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
            Me.OverrideCheckBox.Dock = System.Windows.Forms.DockStyle.Top
            Me.OverrideCheckBox.GradientEnd = System.Drawing.SystemColors.ControlDark
            Me.OverrideCheckBox.GradientStart = System.Drawing.SystemColors.Control
            Me.OverrideCheckBox.HotBorderColor = System.Drawing.SystemColors.WindowFrame
            Me.OverrideCheckBox.ImageCheckBoxSize = New System.Drawing.Size(13, 13)
            Me.OverrideCheckBox.IndeterminateInt = -1
            Me.OverrideCheckBox.IndeterminateString = "Indeterminate"
            Me.OverrideCheckBox.Location = New System.Drawing.Point(0, 0)
            Me.OverrideCheckBox.Name = "OverrideCheckBox"
            Me.OverrideCheckBox.ShadowColor = System.Drawing.Color.Black
            Me.OverrideCheckBox.ShadowOffset = New System.Drawing.Point(2, 2)
            Me.OverrideCheckBox.Size = New System.Drawing.Size(506, 17)
            Me.OverrideCheckBox.StretchImage = False
            Me.OverrideCheckBox.TabIndex = 2
            Me.OverrideCheckBox.ThemesEnabled = True
            Me.OverrideCheckBox.UncheckedInt = 0
            Me.OverrideCheckBox.UncheckedString = "Unchecked"
            '
            'DescriptionTextBox
            '
            Me.DescriptionTextBox.BackColor = System.Drawing.SystemColors.Control
            Me.DescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DescriptionTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DescriptionTextBox.Location = New System.Drawing.Point(0, 17)
            Me.DescriptionTextBox.MinimumHeightInChars = 1
            Me.DescriptionTextBox.MinimumWidthInChars = 0
            Me.DescriptionTextBox.Name = "DescriptionTextBox"
            Me.DescriptionTextBox.Size = New System.Drawing.Size(506, 252)
            Me.DescriptionTextBox.TabIndex = 3
            '
            'ConflictControl
            '
            Me.Name = "ConflictControl"
            Me.Size = New System.Drawing.Size(512, 304)
            Me.InnerPanel.ResumeLayout(False)
            CType(Me.OverrideCheckBox, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

#End Region

        Private mIsLoading As Boolean
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            mIsLoading = True
            MyBase.OnLoad(e)
            WithRadioButton = False
            HeaderText = "Conflict"
            mIsLoading = False
            ' rjm asks - Why do we have to do this again, especially if the HeaderText setter does this?
            MyBase.RefreshAutomaticLayout(NearestForm().CreateGraphics)
        End Sub

        Private mConflict As SensorTaskAttemptConflict
        Private mAttemptWire As SensorTaskAttempt
        Friend Sub WireConflictAndAttempt(ByVal conflict As SensorTaskAttemptConflict, ByVal attempt As SensorTaskAttempt)
            mAttemptWire = attempt
            mConflict = conflict
            RefreshConflict()
        End Sub

        Private mInsideRefreshConflict As Boolean
        Public Sub RefreshConflict()
            ' Prevent this function from being called in an infinite loop
            If mInsideRefreshConflict OrElse mInsideCheckChanged Then Return

            mInsideRefreshConflict = True
            ForbidInvokeRequired(Me)
            MyBase.Refresh()

            OverrideCheckBox.Enabled = Not mConflict.IsEmpty

            Dim factories As SensorTaskFactoryCollection = mAttemptWire.ParentTask.OriginatingFactory.ParentSensorTaskFactories

            Dim hasNoConflict As Boolean = mConflict.IsEmpty
            Dim hasConflict As Boolean = Not mConflict.IsEmpty
            Dim hasFixableConflict As Boolean = hasConflict AndAlso factories.AttemptIsMigratable(mAttemptWire)
            Dim hasUnfixableConflict As Boolean = hasConflict AndAlso Not factories.AttemptIsMigratable(mAttemptWire)

            If hasNoConflict Then
                ' This is the case where there is no conflict
                OverrideCheckBox.ReadOnlyMode = True
                OverrideCheckBox.Text = Messages.ThisAttemptHasNoConflict(UICulture)
                OverrideCheckBox.Enabled = False
                OverrideCheckBox.CheckState = CheckState.Indeterminate
                DescriptionTextBox.Text = String.Empty
            Else
                DescriptionTextBox.Text = mConflict.ToRtf(True, CultureInfo.CurrentUICulture)
            End If

            If hasFixableConflict Then
                OverrideCheckBox.Text = Messages.ConflictWillBeAutomaticallyFixed(UICulture)
                OverrideCheckBox.CheckState = CheckState.Indeterminate
                OverrideCheckBox.ReadOnlyMode = True
            End If

            If hasUnfixableConflict Then
                OverrideCheckBox.Text = Messages.ConflictMustBeIgnored(UICulture)
                OverrideCheckBox.ReadOnlyMode = False
                If mAttemptWire.IsConflictIgnored Then
                    OverrideCheckBox.CheckState = CheckState.Checked
                Else
                    OverrideCheckBox.CheckState = CheckState.Unchecked
                End If
            End If

            'If Not mInsideCheckChanged Then
            '    ' Update the checkbox if we're not already changing it
            '    If mAttemptWire.IsConflictIgnored Then
            '        OverrideCheckBox.CheckState = CheckState.Checked
            '    Else
            '        OverrideCheckBox.CheckState = CheckState.Unchecked
            '    End If
            'End If


            'If Not mConflict.Category Is Nothing OrElse Not mConflict.ExistingSuccess Is Nothing Then
            '    ' If it's a conflict that causes a migration, then we force an automatic fix or ignore
            '    Dim factories As SensorTaskFactoryCollection = mAttemptWire.ParentTask.OriginatingFactory.ParentSensorTaskFactories
            '    If factories.AttemptIsMigratable(mAttemptWire) Then
            '        OverrideCheckBox.Text = Messages.ConflictWillBeAutomaticallyFixed(UICulture)
            '        OverrideCheckBox.ReadOnlyMode = True
            '        OverrideCheckBox.CheckState = CheckState.Indeterminate
            '    Else
            '        OverrideCheckBox.Text = Messages.ConflictMustBeIgnored(UICulture)
            '        OverrideCheckBox.ReadOnlyMode = True
            '        OverrideCheckBox.CheckState = CheckState.Checked
            '    End If
            '    DescriptionTextBox.Text = mConflict.ToRtf(True, CultureInfo.CurrentUICulture)

            'ElseIf Not mConflict.IsEmpty Then

            '    ' Conflict is some other category of conflict
            '    OverrideCheckBox.ReadOnlyMode = False
            '    OverrideCheckBox.Text = Messages.TheSystemShouldIgnoreThisConflict(UICulture)
            '    OverrideCheckBox.Enabled = True

            '    If Not mInsideCheckChanged Then
            '        ' Update the checkbox if we're not already changing it
            '        If mAttemptWire.IsConflictIgnored Then
            '            OverrideCheckBox.CheckState = CheckState.Checked
            '        Else
            '            OverrideCheckBox.CheckState = CheckState.Unchecked
            '        End If
            '    End If
            '    DescriptionTextBox.Text = mConflict.ToRtf(True, UICulture)

            'Else

            '    ' There is no conflict
            '    OverrideCheckBox.ReadOnlyMode = True
            '    OverrideCheckBox.Text = Messages.ThisAttemptHasNoConflict(UICulture)
            '    OverrideCheckBox.Enabled = False
            '    OverrideCheckBox.CheckState = CheckState.Indeterminate
            '    DescriptionTextBox.Text = String.Empty

            'End If

            OverrideCheckBox.Refresh()
            DescriptionTextBox.Refresh()

            mInsideRefreshConflict = False

        End Sub


        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
            OverrideCheckBox.Font = GlobalUISettings.Defaults.Fonts.Regular
            DescriptionTextBox.Font = GlobalUISettings.Defaults.Fonts.Regular
            UI.AutoHeight.CheckBox(UICulture, graphics, OverrideCheckBox)
        End Sub

        Private mInsideCheckChanged As Boolean
        Private Sub OverrideCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles OverrideCheckBox.CheckStateChanged
            If mInsideCheckChanged OrElse mConflict Is Nothing OrElse mInsideRefreshConflict OrElse mIsLoading Then Return
            mInsideCheckChanged = True

            ' We tread these two cases indpenedently to preserve the previous value if the checkstats is intereminante
            If OverrideCheckBox.CheckState = CheckState.Checked Then mAttemptWire.IsConflictIgnored = True
            If OverrideCheckBox.CheckState = CheckState.Unchecked Then mAttemptWire.IsConflictIgnored = False

            RefreshConflict()
            mInsideCheckChanged = False
        End Sub
    End Class

End Namespace
