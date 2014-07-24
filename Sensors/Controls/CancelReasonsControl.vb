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
Imports System.Drawing
Imports System.Globalization

Imports System.Windows.Forms

Imports Mbark.UI
Imports Mbark.UI.GlobalUISettings
Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Class CancelReasonsControl
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
        Friend WithEvents OtherReasonRadio As System.Windows.Forms.RadioButton
        Friend WithEvents SensorProblemRadio As System.Windows.Forms.RadioButton
        Friend WithEvents SubjectRefusesRadio As System.Windows.Forms.RadioButton
        Friend WithEvents SubjectLeftRadio As System.Windows.Forms.RadioButton
        Friend WithEvents OtherReasonTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DemoRadio As System.Windows.Forms.RadioButton
        Friend WithEvents mConvenienceRadio As System.Windows.Forms.RadioButton
        Friend WithEvents SubjectRefusesTaskTooltip As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CancelReasonsControl))
            Me.OtherReasonRadio = New System.Windows.Forms.RadioButton
            Me.SensorProblemRadio = New System.Windows.Forms.RadioButton
            Me.SubjectRefusesRadio = New System.Windows.Forms.RadioButton
            Me.SubjectLeftRadio = New System.Windows.Forms.RadioButton
            Me.OtherReasonTextBox = New System.Windows.Forms.TextBox
            Me.DemoRadio = New System.Windows.Forms.RadioButton
            Me.mConvenienceRadio = New System.Windows.Forms.RadioButton
            Me.SubjectRefusesTaskTooltip = New System.Windows.Forms.ToolTip(Me.components)
            Me.InnerPanel.SuspendLayout()
            '
            'InnerPanel
            '
            Me.InnerPanel.Controls.Add(Me.mConvenienceRadio)
            Me.InnerPanel.Controls.Add(Me.DemoRadio)
            Me.InnerPanel.Controls.Add(Me.OtherReasonTextBox)
            Me.InnerPanel.Controls.Add(Me.SubjectLeftRadio)
            Me.InnerPanel.Controls.Add(Me.SubjectRefusesRadio)
            Me.InnerPanel.Controls.Add(Me.SensorProblemRadio)
            Me.InnerPanel.Controls.Add(Me.OtherReasonRadio)
            Me.InnerPanel.Name = "InnerPanel"
            Me.InnerPanel.Size = CType(resources.GetObject("InnerPanel.Size"), System.Drawing.Size)
            Me.InnerPanel.TabIndex = CType(resources.GetObject("InnerPanel.TabIndex"), Integer)
            '
            'GroupRadioButton
            '
            Me.GroupRadioButton.Name = "GroupRadioButton"
            Me.GroupRadioButton.TabIndex = CType(resources.GetObject("GroupRadioButton.TabIndex"), Integer)
            '
            'OtherReasonRadio
            '
            Me.OtherReasonRadio.AccessibleDescription = resources.GetString("OtherReasonRadio.AccessibleDescription")
            Me.OtherReasonRadio.AccessibleName = resources.GetString("OtherReasonRadio.AccessibleName")
            Me.OtherReasonRadio.Anchor = CType(resources.GetObject("OtherReasonRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OtherReasonRadio.Appearance = CType(resources.GetObject("OtherReasonRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.OtherReasonRadio.BackgroundImage = CType(resources.GetObject("OtherReasonRadio.BackgroundImage"), System.Drawing.Image)
            Me.OtherReasonRadio.CheckAlign = CType(resources.GetObject("OtherReasonRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.OtherReasonRadio.Dock = CType(resources.GetObject("OtherReasonRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.OtherReasonRadio.Enabled = CType(resources.GetObject("OtherReasonRadio.Enabled"), Boolean)
            Me.OtherReasonRadio.FlatStyle = CType(resources.GetObject("OtherReasonRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.OtherReasonRadio.Font = CType(resources.GetObject("OtherReasonRadio.Font"), System.Drawing.Font)
            Me.OtherReasonRadio.Image = CType(resources.GetObject("OtherReasonRadio.Image"), System.Drawing.Image)
            Me.OtherReasonRadio.ImageAlign = CType(resources.GetObject("OtherReasonRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.OtherReasonRadio.ImageIndex = CType(resources.GetObject("OtherReasonRadio.ImageIndex"), Integer)
            Me.OtherReasonRadio.ImeMode = CType(resources.GetObject("OtherReasonRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OtherReasonRadio.Location = CType(resources.GetObject("OtherReasonRadio.Location"), System.Drawing.Point)
            Me.OtherReasonRadio.Name = "OtherReasonRadio"
            Me.OtherReasonRadio.RightToLeft = CType(resources.GetObject("OtherReasonRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OtherReasonRadio.Size = CType(resources.GetObject("OtherReasonRadio.Size"), System.Drawing.Size)
            Me.OtherReasonRadio.TabIndex = CType(resources.GetObject("OtherReasonRadio.TabIndex"), Integer)
            Me.OtherReasonRadio.Text = resources.GetString("OtherReasonRadio.Text")
            Me.OtherReasonRadio.TextAlign = CType(resources.GetObject("OtherReasonRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me.OtherReasonRadio, resources.GetString("OtherReasonRadio.ToolTip"))
            Me.OtherReasonRadio.Visible = CType(resources.GetObject("OtherReasonRadio.Visible"), Boolean)
            '
            'SensorProblemRadio
            '
            Me.SensorProblemRadio.AccessibleDescription = resources.GetString("SensorProblemRadio.AccessibleDescription")
            Me.SensorProblemRadio.AccessibleName = resources.GetString("SensorProblemRadio.AccessibleName")
            Me.SensorProblemRadio.Anchor = CType(resources.GetObject("SensorProblemRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.SensorProblemRadio.Appearance = CType(resources.GetObject("SensorProblemRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.SensorProblemRadio.BackgroundImage = CType(resources.GetObject("SensorProblemRadio.BackgroundImage"), System.Drawing.Image)
            Me.SensorProblemRadio.CheckAlign = CType(resources.GetObject("SensorProblemRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.SensorProblemRadio.Dock = CType(resources.GetObject("SensorProblemRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.SensorProblemRadio.Enabled = CType(resources.GetObject("SensorProblemRadio.Enabled"), Boolean)
            Me.SensorProblemRadio.FlatStyle = CType(resources.GetObject("SensorProblemRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.SensorProblemRadio.Font = CType(resources.GetObject("SensorProblemRadio.Font"), System.Drawing.Font)
            Me.SensorProblemRadio.Image = CType(resources.GetObject("SensorProblemRadio.Image"), System.Drawing.Image)
            Me.SensorProblemRadio.ImageAlign = CType(resources.GetObject("SensorProblemRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.SensorProblemRadio.ImageIndex = CType(resources.GetObject("SensorProblemRadio.ImageIndex"), Integer)
            Me.SensorProblemRadio.ImeMode = CType(resources.GetObject("SensorProblemRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.SensorProblemRadio.Location = CType(resources.GetObject("SensorProblemRadio.Location"), System.Drawing.Point)
            Me.SensorProblemRadio.Name = "SensorProblemRadio"
            Me.SensorProblemRadio.RightToLeft = CType(resources.GetObject("SensorProblemRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.SensorProblemRadio.Size = CType(resources.GetObject("SensorProblemRadio.Size"), System.Drawing.Size)
            Me.SensorProblemRadio.TabIndex = CType(resources.GetObject("SensorProblemRadio.TabIndex"), Integer)
            Me.SensorProblemRadio.Text = resources.GetString("SensorProblemRadio.Text")
            Me.SensorProblemRadio.TextAlign = CType(resources.GetObject("SensorProblemRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me.SensorProblemRadio, resources.GetString("SensorProblemRadio.ToolTip"))
            Me.SensorProblemRadio.Visible = CType(resources.GetObject("SensorProblemRadio.Visible"), Boolean)
            '
            'SubjectRefusesRadio
            '
            Me.SubjectRefusesRadio.AccessibleDescription = resources.GetString("SubjectRefusesRadio.AccessibleDescription")
            Me.SubjectRefusesRadio.AccessibleName = resources.GetString("SubjectRefusesRadio.AccessibleName")
            Me.SubjectRefusesRadio.Anchor = CType(resources.GetObject("SubjectRefusesRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.SubjectRefusesRadio.Appearance = CType(resources.GetObject("SubjectRefusesRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.SubjectRefusesRadio.BackgroundImage = CType(resources.GetObject("SubjectRefusesRadio.BackgroundImage"), System.Drawing.Image)
            Me.SubjectRefusesRadio.CheckAlign = CType(resources.GetObject("SubjectRefusesRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesRadio.Dock = CType(resources.GetObject("SubjectRefusesRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.SubjectRefusesRadio.Enabled = CType(resources.GetObject("SubjectRefusesRadio.Enabled"), Boolean)
            Me.SubjectRefusesRadio.FlatStyle = CType(resources.GetObject("SubjectRefusesRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.SubjectRefusesRadio.Font = CType(resources.GetObject("SubjectRefusesRadio.Font"), System.Drawing.Font)
            Me.SubjectRefusesRadio.Image = CType(resources.GetObject("SubjectRefusesRadio.Image"), System.Drawing.Image)
            Me.SubjectRefusesRadio.ImageAlign = CType(resources.GetObject("SubjectRefusesRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesRadio.ImageIndex = CType(resources.GetObject("SubjectRefusesRadio.ImageIndex"), Integer)
            Me.SubjectRefusesRadio.ImeMode = CType(resources.GetObject("SubjectRefusesRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.SubjectRefusesRadio.Location = CType(resources.GetObject("SubjectRefusesRadio.Location"), System.Drawing.Point)
            Me.SubjectRefusesRadio.Name = "SubjectRefusesRadio"
            Me.SubjectRefusesRadio.RightToLeft = CType(resources.GetObject("SubjectRefusesRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.SubjectRefusesRadio.Size = CType(resources.GetObject("SubjectRefusesRadio.Size"), System.Drawing.Size)
            Me.SubjectRefusesRadio.TabIndex = CType(resources.GetObject("SubjectRefusesRadio.TabIndex"), Integer)
            Me.SubjectRefusesRadio.Text = resources.GetString("SubjectRefusesRadio.Text")
            Me.SubjectRefusesRadio.TextAlign = CType(resources.GetObject("SubjectRefusesRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me.SubjectRefusesRadio, resources.GetString("SubjectRefusesRadio.ToolTip"))
            Me.SubjectRefusesRadio.Visible = CType(resources.GetObject("SubjectRefusesRadio.Visible"), Boolean)
            '
            'SubjectLeftRadio
            '
            Me.SubjectLeftRadio.AccessibleDescription = resources.GetString("SubjectLeftRadio.AccessibleDescription")
            Me.SubjectLeftRadio.AccessibleName = resources.GetString("SubjectLeftRadio.AccessibleName")
            Me.SubjectLeftRadio.Anchor = CType(resources.GetObject("SubjectLeftRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.SubjectLeftRadio.Appearance = CType(resources.GetObject("SubjectLeftRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.SubjectLeftRadio.BackgroundImage = CType(resources.GetObject("SubjectLeftRadio.BackgroundImage"), System.Drawing.Image)
            Me.SubjectLeftRadio.CheckAlign = CType(resources.GetObject("SubjectLeftRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.SubjectLeftRadio.Dock = CType(resources.GetObject("SubjectLeftRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.SubjectLeftRadio.Enabled = CType(resources.GetObject("SubjectLeftRadio.Enabled"), Boolean)
            Me.SubjectLeftRadio.FlatStyle = CType(resources.GetObject("SubjectLeftRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.SubjectLeftRadio.Font = CType(resources.GetObject("SubjectLeftRadio.Font"), System.Drawing.Font)
            Me.SubjectLeftRadio.Image = CType(resources.GetObject("SubjectLeftRadio.Image"), System.Drawing.Image)
            Me.SubjectLeftRadio.ImageAlign = CType(resources.GetObject("SubjectLeftRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.SubjectLeftRadio.ImageIndex = CType(resources.GetObject("SubjectLeftRadio.ImageIndex"), Integer)
            Me.SubjectLeftRadio.ImeMode = CType(resources.GetObject("SubjectLeftRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.SubjectLeftRadio.Location = CType(resources.GetObject("SubjectLeftRadio.Location"), System.Drawing.Point)
            Me.SubjectLeftRadio.Name = "SubjectLeftRadio"
            Me.SubjectLeftRadio.RightToLeft = CType(resources.GetObject("SubjectLeftRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.SubjectLeftRadio.Size = CType(resources.GetObject("SubjectLeftRadio.Size"), System.Drawing.Size)
            Me.SubjectLeftRadio.TabIndex = CType(resources.GetObject("SubjectLeftRadio.TabIndex"), Integer)
            Me.SubjectLeftRadio.Text = resources.GetString("SubjectLeftRadio.Text")
            Me.SubjectLeftRadio.TextAlign = CType(resources.GetObject("SubjectLeftRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me.SubjectLeftRadio, resources.GetString("SubjectLeftRadio.ToolTip"))
            Me.SubjectLeftRadio.Visible = CType(resources.GetObject("SubjectLeftRadio.Visible"), Boolean)
            '
            'OtherReasonTextBox
            '
            Me.OtherReasonTextBox.AccessibleDescription = resources.GetString("OtherReasonTextBox.AccessibleDescription")
            Me.OtherReasonTextBox.AccessibleName = resources.GetString("OtherReasonTextBox.AccessibleName")
            Me.OtherReasonTextBox.Anchor = CType(resources.GetObject("OtherReasonTextBox.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OtherReasonTextBox.AutoSize = CType(resources.GetObject("OtherReasonTextBox.AutoSize"), Boolean)
            Me.OtherReasonTextBox.BackgroundImage = CType(resources.GetObject("OtherReasonTextBox.BackgroundImage"), System.Drawing.Image)
            Me.OtherReasonTextBox.Dock = CType(resources.GetObject("OtherReasonTextBox.Dock"), System.Windows.Forms.DockStyle)
            Me.OtherReasonTextBox.Enabled = CType(resources.GetObject("OtherReasonTextBox.Enabled"), Boolean)
            Me.OtherReasonTextBox.Font = CType(resources.GetObject("OtherReasonTextBox.Font"), System.Drawing.Font)
            Me.OtherReasonTextBox.ImeMode = CType(resources.GetObject("OtherReasonTextBox.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OtherReasonTextBox.Location = CType(resources.GetObject("OtherReasonTextBox.Location"), System.Drawing.Point)
            Me.OtherReasonTextBox.MaxLength = CType(resources.GetObject("OtherReasonTextBox.MaxLength"), Integer)
            Me.OtherReasonTextBox.Multiline = CType(resources.GetObject("OtherReasonTextBox.Multiline"), Boolean)
            Me.OtherReasonTextBox.Name = "OtherReasonTextBox"
            Me.OtherReasonTextBox.PasswordChar = CType(resources.GetObject("OtherReasonTextBox.PasswordChar"), Char)
            Me.OtherReasonTextBox.RightToLeft = CType(resources.GetObject("OtherReasonTextBox.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OtherReasonTextBox.ScrollBars = CType(resources.GetObject("OtherReasonTextBox.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.OtherReasonTextBox.Size = CType(resources.GetObject("OtherReasonTextBox.Size"), System.Drawing.Size)
            Me.OtherReasonTextBox.TabIndex = CType(resources.GetObject("OtherReasonTextBox.TabIndex"), Integer)
            Me.OtherReasonTextBox.Text = resources.GetString("OtherReasonTextBox.Text")
            Me.OtherReasonTextBox.TextAlign = CType(resources.GetObject("OtherReasonTextBox.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me.OtherReasonTextBox, resources.GetString("OtherReasonTextBox.ToolTip"))
            Me.OtherReasonTextBox.Visible = CType(resources.GetObject("OtherReasonTextBox.Visible"), Boolean)
            Me.OtherReasonTextBox.WordWrap = CType(resources.GetObject("OtherReasonTextBox.WordWrap"), Boolean)
            '
            'DemoRadio
            '
            Me.DemoRadio.AccessibleDescription = resources.GetString("DemoRadio.AccessibleDescription")
            Me.DemoRadio.AccessibleName = resources.GetString("DemoRadio.AccessibleName")
            Me.DemoRadio.Anchor = CType(resources.GetObject("DemoRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.DemoRadio.Appearance = CType(resources.GetObject("DemoRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.DemoRadio.BackgroundImage = CType(resources.GetObject("DemoRadio.BackgroundImage"), System.Drawing.Image)
            Me.DemoRadio.CheckAlign = CType(resources.GetObject("DemoRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.DemoRadio.Dock = CType(resources.GetObject("DemoRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.DemoRadio.Enabled = CType(resources.GetObject("DemoRadio.Enabled"), Boolean)
            Me.DemoRadio.FlatStyle = CType(resources.GetObject("DemoRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.DemoRadio.Font = CType(resources.GetObject("DemoRadio.Font"), System.Drawing.Font)
            Me.DemoRadio.Image = CType(resources.GetObject("DemoRadio.Image"), System.Drawing.Image)
            Me.DemoRadio.ImageAlign = CType(resources.GetObject("DemoRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.DemoRadio.ImageIndex = CType(resources.GetObject("DemoRadio.ImageIndex"), Integer)
            Me.DemoRadio.ImeMode = CType(resources.GetObject("DemoRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.DemoRadio.Location = CType(resources.GetObject("DemoRadio.Location"), System.Drawing.Point)
            Me.DemoRadio.Name = "DemoRadio"
            Me.DemoRadio.RightToLeft = CType(resources.GetObject("DemoRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.DemoRadio.Size = CType(resources.GetObject("DemoRadio.Size"), System.Drawing.Size)
            Me.DemoRadio.TabIndex = CType(resources.GetObject("DemoRadio.TabIndex"), Integer)
            Me.DemoRadio.Text = resources.GetString("DemoRadio.Text")
            Me.DemoRadio.TextAlign = CType(resources.GetObject("DemoRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me.DemoRadio, resources.GetString("DemoRadio.ToolTip"))
            Me.DemoRadio.Visible = CType(resources.GetObject("DemoRadio.Visible"), Boolean)
            '
            'ConvenienceRadio
            '
            Me.mConvenienceRadio.AccessibleDescription = resources.GetString("ConvenienceRadio.AccessibleDescription")
            Me.mConvenienceRadio.AccessibleName = resources.GetString("ConvenienceRadio.AccessibleName")
            Me.mConvenienceRadio.Anchor = CType(resources.GetObject("ConvenienceRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.mConvenienceRadio.Appearance = CType(resources.GetObject("ConvenienceRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.mConvenienceRadio.BackgroundImage = CType(resources.GetObject("ConvenienceRadio.BackgroundImage"), System.Drawing.Image)
            Me.mConvenienceRadio.CheckAlign = CType(resources.GetObject("ConvenienceRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.mConvenienceRadio.Dock = CType(resources.GetObject("ConvenienceRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.mConvenienceRadio.Enabled = CType(resources.GetObject("ConvenienceRadio.Enabled"), Boolean)
            Me.mConvenienceRadio.FlatStyle = CType(resources.GetObject("ConvenienceRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.mConvenienceRadio.Font = CType(resources.GetObject("ConvenienceRadio.Font"), System.Drawing.Font)
            Me.mConvenienceRadio.Image = CType(resources.GetObject("ConvenienceRadio.Image"), System.Drawing.Image)
            Me.mConvenienceRadio.ImageAlign = CType(resources.GetObject("ConvenienceRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.mConvenienceRadio.ImageIndex = CType(resources.GetObject("ConvenienceRadio.ImageIndex"), Integer)
            Me.mConvenienceRadio.ImeMode = CType(resources.GetObject("ConvenienceRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.mConvenienceRadio.Location = CType(resources.GetObject("ConvenienceRadio.Location"), System.Drawing.Point)
            Me.mConvenienceRadio.Name = "ConvenienceRadio"
            Me.mConvenienceRadio.RightToLeft = CType(resources.GetObject("ConvenienceRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.mConvenienceRadio.Size = CType(resources.GetObject("ConvenienceRadio.Size"), System.Drawing.Size)
            Me.mConvenienceRadio.TabIndex = CType(resources.GetObject("ConvenienceRadio.TabIndex"), Integer)
            Me.mConvenienceRadio.Text = resources.GetString("ConvenienceRadio.Text")
            Me.mConvenienceRadio.TextAlign = CType(resources.GetObject("ConvenienceRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me.mConvenienceRadio, resources.GetString("ConvenienceRadio.ToolTip"))
            Me.mConvenienceRadio.Visible = CType(resources.GetObject("ConvenienceRadio.Visible"), Boolean)
            '
            'CancelReasonsControl
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.Name = "CancelReasonsControl"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
            Me.SubjectRefusesTaskTooltip.SetToolTip(Me, resources.GetString("$this.ToolTip"))
            Me.InnerPanel.ResumeLayout(False)

        End Sub

#End Region

        Private mSessionToCancelWire As SensorTaskFactoryCollection
        Public Sub WireSessionToCancel(ByVal factoriesForSession As SensorTaskFactoryCollection)
            mSessionToCancelWire = factoriesForSession
        End Sub

        Private mReason As CancellationReason
        Public ReadOnly Property Reason() As CancellationReason
            Get
                Return mReason
            End Get
        End Property


        Private mRadios As New List(Of RadioButton)
        Private mSubjectRefusesTaskEnabled As Boolean = True
        Private mSensorProblemEnabled As Boolean = True
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)


            ' If more than one activatable task remains, then don't allow 'Subject Refuses Task' as an excuse
            Dim numberOfActivatableTasks As Integer
            If Not mSessionToCancelWire Is Nothing Then
                With mSessionToCancelWire
                    For i As Integer = 0 To .AllTasks.Count - 1
                        If .AllTasks(i).IsActivatable Then numberOfActivatableTasks += 1
                    Next
                End With
                mSubjectRefusesTaskEnabled = numberOfActivatableTasks = 1
                mSensorProblemEnabled = mSessionToCancelWire.Sensors.Count = 1
            End If


            mRadios.Add(mConvenienceRadio)
            mRadios.Add(SubjectLeftRadio)
            mRadios.Add(SubjectRefusesRadio)
            mRadios.Add(SensorProblemRadio)
            mRadios.Add(DemoRadio)
            mRadios.Add(OtherReasonRadio)


            PopulateMessages(UICulture)
            HeaderText = "Other"
            Me.RefreshRadiosEnabled()

        End Sub

        Private Sub PopulateMessages(ByVal culture As CultureInfo)

            mConvenienceRadio.Text = Messages.Convenience(culture)
            SubjectLeftRadio.Text = Messages.SubjectLeftSession(culture)
            SubjectRefusesRadio.Text = Messages.SubjectDeclines(culture)
            SensorProblemRadio.Text = Messages.SensorMalfunction(culture)
            DemoRadio.Text = Messages.PerformingDemoOrTesting(culture)
            OtherReasonRadio.Text = Messages.OtherReasonWithSpecifyAndColon(culture)
            HeaderText = InfrastructureMessages.Messages.Other(culture)

        End Sub

        Private mRadioButtonIndent As Integer = 16
        Public Property RadioButtonIndent() As Integer
            Get
                Return mRadioButtonIndent
            End Get
            Set(ByVal value As Integer)
                mRadioButtonIndent = value
            End Set
        End Property

        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
            MyBase.RefreshAutomaticLayout(graphics)

            AutoHeight.RadioButton(graphics, mConvenienceRadio)
            AutoHeight.RadioButton(graphics, SubjectLeftRadio)
            AutoHeight.RadioButton(graphics, SubjectRefusesRadio)
            AutoHeight.RadioButton(graphics, SensorProblemRadio)
            AutoHeight.RadioButton(graphics, DemoRadio)
            AutoHeight.RadioButton(graphics, OtherReasonRadio)

            mMinimumHeight = 0
            mMinimumWidth = 0

            For i As Integer = 0 To mRadios.Count - 1

                ' Font
                mRadios(i).Font = Defaults.Fonts.Small

                ' Place the radio button
                If i = 0 Then
                    mRadios(i).Location = New Point(RadioButtonIndent, 0)
                Else
                    Dim above As RadioButton = DirectCast(mRadios(i - 1), RadioButton)
                    mRadios(i).Location = LowerLeft(above)
                End If

                mRadios(i).Width = InnerPanel.Width - RadioButtonIndent

                Dim width As Integer = _
                    StringWidthInPixels(graphics, mRadios(i)) + _
                    ControlSizes.RadioButtonSize.Width + _
                    RadioButtonIndent + _
                    TotalLeftPadding + _
                    TotalRightPadding + _
                    UndocumentedPaddingConstants.PreventLabelWordWrap

                mMinimumWidth = Math.Max(mMinimumWidth, width)
                mMinimumHeight += mRadios(i).Height
            Next

            ' Place and size the 'other' reason text box
            Dim otherLoc As Point = LowerLeft(OtherReasonRadio)
            otherLoc.X += ControlSizes.RadioButtonSize.Width
            OtherReasonTextBox.Location = otherLoc
            OtherReasonTextBox.Width = InnerPanel.Width - OtherReasonTextBox.Location.X - 16
            OtherReasonTextBox.Font = Defaults.Fonts.Small
            OtherReasonTextBox.Height = CInt(3 * AutoHeight.FontHeightInPixels(UICulture, graphics, OtherReasonTextBox.Font))

            mMinimumHeight = LowerLeft(OtherReasonTextBox).Y + Defaults.Padding.PanelVertical + TotalTopPadding + TotalBottomPadding

            RefreshRadiosEnabled()

        End Sub

        Private Sub RefreshOtherReasonTextBoxEnabled()
            OtherReasonTextBox.Enabled = MyBase.RadioGroupBoxChecked AndAlso OtherReasonRadio.Checked
        End Sub

        Private Sub RefreshRadiosEnabled()

            For i As Integer = 0 To mRadios.Count - 1
                Dim c As Control = DirectCast(mRadios(i), Control)
                c.Enabled = MyBase.RadioGroupBoxChecked OrElse Not MyBase.WithRadioButton
            Next
            SubjectRefusesRadio.Enabled = RadioGroupBoxChecked AndAlso mSubjectRefusesTaskEnabled
            SensorProblemRadio.Enabled = RadioGroupBoxChecked AndAlso mSensorProblemEnabled
            RefreshOtherReasonTextBoxEnabled()
        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            RefreshRadiosEnabled()
        End Sub

        Private mMinimumHeight As Integer
        Public Overrides ReadOnly Property MinimumHeight() As Integer
            Get
                Return mMinimumHeight
            End Get
        End Property

        Private mMinimumWidth As Integer
        Public Overrides ReadOnly Property MinimumWidth() As Integer
            Get
                Return mMinimumWidth
            End Get
        End Property

        Public ReadOnly Property OtherReasonText() As String
            Get
                Return OtherReasonTextBox.Text
            End Get
        End Property

        Public Event ReasonChanged As EventHandler(Of EventArgs)

        Private Sub RadioCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            mConvenienceRadio.CheckedChanged, _
            SubjectLeftRadio.CheckedChanged, _
            SubjectRefusesRadio.CheckedChanged, _
            SensorProblemRadio.CheckedChanged, _
            DemoRadio.CheckedChanged, _
            OtherReasonRadio.CheckedChanged, _
            mConvenienceRadio.CheckedChanged

            If mConvenienceRadio.Checked Then mReason = CancellationReason.Convenience
            If SubjectLeftRadio.Checked Then mReason = CancellationReason.SubjectLeftSession
            If SubjectRefusesRadio.Checked Then mReason = CancellationReason.SubjectRefuses
            If SensorProblemRadio.Checked Then mReason = CancellationReason.SensorProblem
            If DemoRadio.Checked Then mReason = CancellationReason.PerformingDemo
            If OtherReasonRadio.Checked Then mReason = CancellationReason.OtherReason


            RaiseEvent ReasonChanged(Me, e)

            RefreshOtherReasonTextBoxEnabled()
        End Sub

        Private Sub GroupBoxRadioCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.RadioButtonChanged
            RefreshRadiosEnabled()
            RefreshOtherReasonTextBoxEnabled()
        End Sub

        Private Sub OtherReasonTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles OtherReasonTextBox.TextChanged
            RaiseEvent ReasonChanged(Me, e)
        End Sub


#Region "       Automate test       "
        Public ReadOnly Property ConvenienceRadio() As RadioButton
            Get
                Return mConvenienceRadio
            End Get
        End Property
#End Region

    End Class

    Public Enum CancellationReason
        NoReason
        Convenience
        SubjectLeftSession
        SubjectRefuses
        SensorProblem
        PerformingDemo
        OtherReason
    End Enum


End Namespace
