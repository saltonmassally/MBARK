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
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms


Imports Mbark.UI.GlobalUISettings

Namespace Mbark.UI

    Public Class Refonter
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents FontSizeTrackBar As System.Windows.Forms.TrackBar
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents FontListComboBox As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Refonter))
            Me.FontSizeTrackBar = New System.Windows.Forms.TrackBar
            Me.Label1 = New System.Windows.Forms.Label
            Me.FontListComboBox = New System.Windows.Forms.ComboBox
            CType(Me.FontSizeTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'FontSizeTrackBar
            '
            Me.FontSizeTrackBar.AccessibleDescription = resources.GetString("FontSizeTrackBar.AccessibleDescription")
            Me.FontSizeTrackBar.AccessibleName = resources.GetString("FontSizeTrackBar.AccessibleName")
            Me.FontSizeTrackBar.Anchor = CType(resources.GetObject("FontSizeTrackBar.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.FontSizeTrackBar.BackgroundImage = CType(resources.GetObject("FontSizeTrackBar.BackgroundImage"), System.Drawing.Image)
            Me.FontSizeTrackBar.Dock = CType(resources.GetObject("FontSizeTrackBar.Dock"), System.Windows.Forms.DockStyle)
            Me.FontSizeTrackBar.Enabled = CType(resources.GetObject("FontSizeTrackBar.Enabled"), Boolean)
            Me.FontSizeTrackBar.Font = CType(resources.GetObject("FontSizeTrackBar.Font"), System.Drawing.Font)
            Me.FontSizeTrackBar.ImeMode = CType(resources.GetObject("FontSizeTrackBar.ImeMode"), System.Windows.Forms.ImeMode)
            Me.FontSizeTrackBar.Location = CType(resources.GetObject("FontSizeTrackBar.Location"), System.Drawing.Point)
            Me.FontSizeTrackBar.Maximum = 20
            Me.FontSizeTrackBar.Minimum = 2
            Me.FontSizeTrackBar.Name = "FontSizeTrackBar"
            Me.FontSizeTrackBar.Orientation = CType(resources.GetObject("FontSizeTrackBar.Orientation"), System.Windows.Forms.Orientation)
            Me.FontSizeTrackBar.RightToLeft = CType(resources.GetObject("FontSizeTrackBar.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.FontSizeTrackBar.Size = CType(resources.GetObject("FontSizeTrackBar.Size"), System.Drawing.Size)
            Me.FontSizeTrackBar.TabIndex = CType(resources.GetObject("FontSizeTrackBar.TabIndex"), Integer)
            Me.FontSizeTrackBar.Text = resources.GetString("FontSizeTrackBar.Text")
            Me.FontSizeTrackBar.Value = 8
            Me.FontSizeTrackBar.Visible = CType(resources.GetObject("FontSizeTrackBar.Visible"), Boolean)
            '
            'Label1
            '
            Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
            Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
            Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
            Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
            Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
            Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
            Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
            Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
            Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
            Me.Label1.Name = "Label1"
            Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
            Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
            Me.Label1.Text = resources.GetString("Label1.Text")
            Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
            Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
            '
            'FontListComboBox
            '
            Me.FontListComboBox.AccessibleDescription = resources.GetString("FontListComboBox.AccessibleDescription")
            Me.FontListComboBox.AccessibleName = resources.GetString("FontListComboBox.AccessibleName")
            Me.FontListComboBox.Anchor = CType(resources.GetObject("FontListComboBox.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.FontListComboBox.BackgroundImage = CType(resources.GetObject("FontListComboBox.BackgroundImage"), System.Drawing.Image)
            Me.FontListComboBox.Dock = CType(resources.GetObject("FontListComboBox.Dock"), System.Windows.Forms.DockStyle)
            Me.FontListComboBox.Enabled = CType(resources.GetObject("FontListComboBox.Enabled"), Boolean)
            Me.FontListComboBox.Font = CType(resources.GetObject("FontListComboBox.Font"), System.Drawing.Font)
            Me.FontListComboBox.ImeMode = CType(resources.GetObject("FontListComboBox.ImeMode"), System.Windows.Forms.ImeMode)
            Me.FontListComboBox.IntegralHeight = CType(resources.GetObject("FontListComboBox.IntegralHeight"), Boolean)
            Me.FontListComboBox.ItemHeight = CType(resources.GetObject("FontListComboBox.ItemHeight"), Integer)
            Me.FontListComboBox.Location = CType(resources.GetObject("FontListComboBox.Location"), System.Drawing.Point)
            Me.FontListComboBox.MaxDropDownItems = CType(resources.GetObject("FontListComboBox.MaxDropDownItems"), Integer)
            Me.FontListComboBox.MaxLength = CType(resources.GetObject("FontListComboBox.MaxLength"), Integer)
            Me.FontListComboBox.Name = "FontListComboBox"
            Me.FontListComboBox.RightToLeft = CType(resources.GetObject("FontListComboBox.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.FontListComboBox.Size = CType(resources.GetObject("FontListComboBox.Size"), System.Drawing.Size)
            Me.FontListComboBox.TabIndex = CType(resources.GetObject("FontListComboBox.TabIndex"), Integer)
            Me.FontListComboBox.Text = resources.GetString("FontListComboBox.Text")
            Me.FontListComboBox.Visible = CType(resources.GetObject("FontListComboBox.Visible"), Boolean)
            '
            'Refonter
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.Controls.Add(Me.FontListComboBox)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.FontSizeTrackBar)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "Refonter"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            CType(Me.FontSizeTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mTargetControl As Control
        <Browsable(False)> _
        Property TargetControl() As Control
            Get
                Return mTargetControl
            End Get
            Set(ByVal value As Control)
                mTargetControl = value
            End Set
        End Property


        Private Sub HandleFontSizeChange(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FontSizeTrackBar.ValueChanged
            Defaults.Fonts.Size = FontSizeTrackBar.Value
            If mTargetControl Is Nothing Then Return
            RefreshControls()
        End Sub

        Private Sub Refonter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            FontListComboBox.Items.Clear()
            Dim ifc As New InstalledFontCollection
            For Each ff As FontFamily In ifc.Families
                If ff.IsStyleAvailable(FontStyle.Bold) AndAlso ff.IsStyleAvailable(FontStyle.Regular) Then
                    FontListComboBox.Items.Add(ff.Name)
                End If
            Next
            FontListComboBox.SelectedItem = 0
        End Sub

        Private Sub FontListComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles FontListComboBox.SelectedIndexChanged
            If FindNearestForm(TargetControl) Is Nothing Then Return
            Defaults.Fonts.FontName = FontListComboBox.SelectedItem.ToString
            RefreshControls()
        End Sub
        Private Sub RefreshControls()
            TargetControl.SuspendLayout()
            Dim autosizableTarget As IAutosizable = CType(mTargetControl, IAutosizable)
            autosizableTarget.RefreshAutomaticLayout(autosizableTarget.NearestForm.CreateGraphics)
            TargetControl.ResumeLayout()
            Return
        End Sub

    End Class

End Namespace