Option Strict On

Namespace Mbark.Sensors
    Public Class TimeoutDetailForm
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
        Friend WithEvents ReasonGroup As System.Windows.Forms.GroupBox
        Friend WithEvents NotReadyRadio As System.Windows.Forms.RadioButton
        Friend WithEvents DidNotTryRadio As System.Windows.Forms.RadioButton
        Friend WithEvents CriticalTimeRadio As System.Windows.Forms.RadioButton
        Friend WithEvents OperateControlRadio As System.Windows.Forms.RadioButton
        Friend WithEvents OtherReasonText As System.Windows.Forms.TextBox
        Friend WithEvents OtherRadio As System.Windows.Forms.RadioButton
        Friend WithEvents NoResponseRadio As System.Windows.Forms.RadioButton
        Friend WithEvents OKButton As System.Windows.Forms.Button
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TimeoutDetailForm))
            Me.ReasonGroup = New System.Windows.Forms.GroupBox
            Me.OtherReasonText = New System.Windows.Forms.TextBox
            Me.OtherRadio = New System.Windows.Forms.RadioButton
            Me.NoResponseRadio = New System.Windows.Forms.RadioButton
            Me.CriticalTimeRadio = New System.Windows.Forms.RadioButton
            Me.DidNotTryRadio = New System.Windows.Forms.RadioButton
            Me.NotReadyRadio = New System.Windows.Forms.RadioButton
            Me.OperateControlRadio = New System.Windows.Forms.RadioButton
            Me.OKButton = New System.Windows.Forms.Button
            Me.ReasonGroup.SuspendLayout()
            Me.SuspendLayout()
            '
            'ReasonGroup
            '
            Me.ReasonGroup.AccessibleDescription = resources.GetString("ReasonGroup.AccessibleDescription")
            Me.ReasonGroup.AccessibleName = resources.GetString("ReasonGroup.AccessibleName")
            Me.ReasonGroup.Anchor = CType(resources.GetObject("ReasonGroup.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.ReasonGroup.BackgroundImage = CType(resources.GetObject("ReasonGroup.BackgroundImage"), System.Drawing.Image)
            Me.ReasonGroup.Controls.Add(Me.OtherReasonText)
            Me.ReasonGroup.Controls.Add(Me.OtherRadio)
            Me.ReasonGroup.Controls.Add(Me.NoResponseRadio)
            Me.ReasonGroup.Controls.Add(Me.CriticalTimeRadio)
            Me.ReasonGroup.Controls.Add(Me.DidNotTryRadio)
            Me.ReasonGroup.Controls.Add(Me.NotReadyRadio)
            Me.ReasonGroup.Controls.Add(Me.OperateControlRadio)
            Me.ReasonGroup.Dock = CType(resources.GetObject("ReasonGroup.Dock"), System.Windows.Forms.DockStyle)
            Me.ReasonGroup.Enabled = CType(resources.GetObject("ReasonGroup.Enabled"), Boolean)
            Me.ReasonGroup.Font = CType(resources.GetObject("ReasonGroup.Font"), System.Drawing.Font)
            Me.ReasonGroup.ImeMode = CType(resources.GetObject("ReasonGroup.ImeMode"), System.Windows.Forms.ImeMode)
            Me.ReasonGroup.Location = CType(resources.GetObject("ReasonGroup.Location"), System.Drawing.Point)
            Me.ReasonGroup.Name = "ReasonGroup"
            Me.ReasonGroup.RightToLeft = CType(resources.GetObject("ReasonGroup.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.ReasonGroup.Size = CType(resources.GetObject("ReasonGroup.Size"), System.Drawing.Size)
            Me.ReasonGroup.TabIndex = CType(resources.GetObject("ReasonGroup.TabIndex"), Integer)
            Me.ReasonGroup.TabStop = False
            Me.ReasonGroup.Text = resources.GetString("ReasonGroup.Text")
            Me.ReasonGroup.Visible = CType(resources.GetObject("ReasonGroup.Visible"), Boolean)
            '
            'OtherReasonText
            '
            Me.OtherReasonText.AccessibleDescription = resources.GetString("OtherReasonText.AccessibleDescription")
            Me.OtherReasonText.AccessibleName = resources.GetString("OtherReasonText.AccessibleName")
            Me.OtherReasonText.Anchor = CType(resources.GetObject("OtherReasonText.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OtherReasonText.AutoSize = CType(resources.GetObject("OtherReasonText.AutoSize"), Boolean)
            Me.OtherReasonText.BackgroundImage = CType(resources.GetObject("OtherReasonText.BackgroundImage"), System.Drawing.Image)
            Me.OtherReasonText.Dock = CType(resources.GetObject("OtherReasonText.Dock"), System.Windows.Forms.DockStyle)
            Me.OtherReasonText.Enabled = CType(resources.GetObject("OtherReasonText.Enabled"), Boolean)
            Me.OtherReasonText.Font = CType(resources.GetObject("OtherReasonText.Font"), System.Drawing.Font)
            Me.OtherReasonText.ImeMode = CType(resources.GetObject("OtherReasonText.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OtherReasonText.Location = CType(resources.GetObject("OtherReasonText.Location"), System.Drawing.Point)
            Me.OtherReasonText.MaxLength = CType(resources.GetObject("OtherReasonText.MaxLength"), Integer)
            Me.OtherReasonText.Multiline = CType(resources.GetObject("OtherReasonText.Multiline"), Boolean)
            Me.OtherReasonText.Name = "OtherReasonText"
            Me.OtherReasonText.PasswordChar = CType(resources.GetObject("OtherReasonText.PasswordChar"), Char)
            Me.OtherReasonText.RightToLeft = CType(resources.GetObject("OtherReasonText.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OtherReasonText.ScrollBars = CType(resources.GetObject("OtherReasonText.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.OtherReasonText.Size = CType(resources.GetObject("OtherReasonText.Size"), System.Drawing.Size)
            Me.OtherReasonText.TabIndex = CType(resources.GetObject("OtherReasonText.TabIndex"), Integer)
            Me.OtherReasonText.Text = resources.GetString("OtherReasonText.Text")
            Me.OtherReasonText.TextAlign = CType(resources.GetObject("OtherReasonText.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.OtherReasonText.Visible = CType(resources.GetObject("OtherReasonText.Visible"), Boolean)
            Me.OtherReasonText.WordWrap = CType(resources.GetObject("OtherReasonText.WordWrap"), Boolean)
            '
            'OtherRadio
            '
            Me.OtherRadio.AccessibleDescription = resources.GetString("OtherRadio.AccessibleDescription")
            Me.OtherRadio.AccessibleName = resources.GetString("OtherRadio.AccessibleName")
            Me.OtherRadio.Anchor = CType(resources.GetObject("OtherRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OtherRadio.Appearance = CType(resources.GetObject("OtherRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.OtherRadio.BackgroundImage = CType(resources.GetObject("OtherRadio.BackgroundImage"), System.Drawing.Image)
            Me.OtherRadio.CheckAlign = CType(resources.GetObject("OtherRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.OtherRadio.Dock = CType(resources.GetObject("OtherRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.OtherRadio.Enabled = CType(resources.GetObject("OtherRadio.Enabled"), Boolean)
            Me.OtherRadio.FlatStyle = CType(resources.GetObject("OtherRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.OtherRadio.Font = CType(resources.GetObject("OtherRadio.Font"), System.Drawing.Font)
            Me.OtherRadio.Image = CType(resources.GetObject("OtherRadio.Image"), System.Drawing.Image)
            Me.OtherRadio.ImageAlign = CType(resources.GetObject("OtherRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.OtherRadio.ImageIndex = CType(resources.GetObject("OtherRadio.ImageIndex"), Integer)
            Me.OtherRadio.ImeMode = CType(resources.GetObject("OtherRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OtherRadio.Location = CType(resources.GetObject("OtherRadio.Location"), System.Drawing.Point)
            Me.OtherRadio.Name = "OtherRadio"
            Me.OtherRadio.RightToLeft = CType(resources.GetObject("OtherRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OtherRadio.Size = CType(resources.GetObject("OtherRadio.Size"), System.Drawing.Size)
            Me.OtherRadio.TabIndex = CType(resources.GetObject("OtherRadio.TabIndex"), Integer)
            Me.OtherRadio.Text = resources.GetString("OtherRadio.Text")
            Me.OtherRadio.TextAlign = CType(resources.GetObject("OtherRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.OtherRadio.Visible = CType(resources.GetObject("OtherRadio.Visible"), Boolean)
            '
            'NoResponseRadio
            '
            Me.NoResponseRadio.AccessibleDescription = resources.GetString("NoResponseRadio.AccessibleDescription")
            Me.NoResponseRadio.AccessibleName = resources.GetString("NoResponseRadio.AccessibleName")
            Me.NoResponseRadio.Anchor = CType(resources.GetObject("NoResponseRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.NoResponseRadio.Appearance = CType(resources.GetObject("NoResponseRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.NoResponseRadio.BackgroundImage = CType(resources.GetObject("NoResponseRadio.BackgroundImage"), System.Drawing.Image)
            Me.NoResponseRadio.CheckAlign = CType(resources.GetObject("NoResponseRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.NoResponseRadio.Dock = CType(resources.GetObject("NoResponseRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.NoResponseRadio.Enabled = CType(resources.GetObject("NoResponseRadio.Enabled"), Boolean)
            Me.NoResponseRadio.FlatStyle = CType(resources.GetObject("NoResponseRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.NoResponseRadio.Font = CType(resources.GetObject("NoResponseRadio.Font"), System.Drawing.Font)
            Me.NoResponseRadio.Image = CType(resources.GetObject("NoResponseRadio.Image"), System.Drawing.Image)
            Me.NoResponseRadio.ImageAlign = CType(resources.GetObject("NoResponseRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.NoResponseRadio.ImageIndex = CType(resources.GetObject("NoResponseRadio.ImageIndex"), Integer)
            Me.NoResponseRadio.ImeMode = CType(resources.GetObject("NoResponseRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.NoResponseRadio.Location = CType(resources.GetObject("NoResponseRadio.Location"), System.Drawing.Point)
            Me.NoResponseRadio.Name = "NoResponseRadio"
            Me.NoResponseRadio.RightToLeft = CType(resources.GetObject("NoResponseRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.NoResponseRadio.Size = CType(resources.GetObject("NoResponseRadio.Size"), System.Drawing.Size)
            Me.NoResponseRadio.TabIndex = CType(resources.GetObject("NoResponseRadio.TabIndex"), Integer)
            Me.NoResponseRadio.Text = resources.GetString("NoResponseRadio.Text")
            Me.NoResponseRadio.TextAlign = CType(resources.GetObject("NoResponseRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.NoResponseRadio.Visible = CType(resources.GetObject("NoResponseRadio.Visible"), Boolean)
            '
            'CriticalTimeRadio
            '
            Me.CriticalTimeRadio.AccessibleDescription = resources.GetString("CriticalTimeRadio.AccessibleDescription")
            Me.CriticalTimeRadio.AccessibleName = resources.GetString("CriticalTimeRadio.AccessibleName")
            Me.CriticalTimeRadio.Anchor = CType(resources.GetObject("CriticalTimeRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.CriticalTimeRadio.Appearance = CType(resources.GetObject("CriticalTimeRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.CriticalTimeRadio.BackgroundImage = CType(resources.GetObject("CriticalTimeRadio.BackgroundImage"), System.Drawing.Image)
            Me.CriticalTimeRadio.CheckAlign = CType(resources.GetObject("CriticalTimeRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.CriticalTimeRadio.Dock = CType(resources.GetObject("CriticalTimeRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.CriticalTimeRadio.Enabled = CType(resources.GetObject("CriticalTimeRadio.Enabled"), Boolean)
            Me.CriticalTimeRadio.FlatStyle = CType(resources.GetObject("CriticalTimeRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.CriticalTimeRadio.Font = CType(resources.GetObject("CriticalTimeRadio.Font"), System.Drawing.Font)
            Me.CriticalTimeRadio.Image = CType(resources.GetObject("CriticalTimeRadio.Image"), System.Drawing.Image)
            Me.CriticalTimeRadio.ImageAlign = CType(resources.GetObject("CriticalTimeRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.CriticalTimeRadio.ImageIndex = CType(resources.GetObject("CriticalTimeRadio.ImageIndex"), Integer)
            Me.CriticalTimeRadio.ImeMode = CType(resources.GetObject("CriticalTimeRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.CriticalTimeRadio.Location = CType(resources.GetObject("CriticalTimeRadio.Location"), System.Drawing.Point)
            Me.CriticalTimeRadio.Name = "CriticalTimeRadio"
            Me.CriticalTimeRadio.RightToLeft = CType(resources.GetObject("CriticalTimeRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.CriticalTimeRadio.Size = CType(resources.GetObject("CriticalTimeRadio.Size"), System.Drawing.Size)
            Me.CriticalTimeRadio.TabIndex = CType(resources.GetObject("CriticalTimeRadio.TabIndex"), Integer)
            Me.CriticalTimeRadio.Text = resources.GetString("CriticalTimeRadio.Text")
            Me.CriticalTimeRadio.TextAlign = CType(resources.GetObject("CriticalTimeRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.CriticalTimeRadio.Visible = CType(resources.GetObject("CriticalTimeRadio.Visible"), Boolean)
            '
            'DidNotTryRadio
            '
            Me.DidNotTryRadio.AccessibleDescription = resources.GetString("DidNotTryRadio.AccessibleDescription")
            Me.DidNotTryRadio.AccessibleName = resources.GetString("DidNotTryRadio.AccessibleName")
            Me.DidNotTryRadio.Anchor = CType(resources.GetObject("DidNotTryRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.DidNotTryRadio.Appearance = CType(resources.GetObject("DidNotTryRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.DidNotTryRadio.BackgroundImage = CType(resources.GetObject("DidNotTryRadio.BackgroundImage"), System.Drawing.Image)
            Me.DidNotTryRadio.CheckAlign = CType(resources.GetObject("DidNotTryRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.DidNotTryRadio.Dock = CType(resources.GetObject("DidNotTryRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.DidNotTryRadio.Enabled = CType(resources.GetObject("DidNotTryRadio.Enabled"), Boolean)
            Me.DidNotTryRadio.FlatStyle = CType(resources.GetObject("DidNotTryRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.DidNotTryRadio.Font = CType(resources.GetObject("DidNotTryRadio.Font"), System.Drawing.Font)
            Me.DidNotTryRadio.Image = CType(resources.GetObject("DidNotTryRadio.Image"), System.Drawing.Image)
            Me.DidNotTryRadio.ImageAlign = CType(resources.GetObject("DidNotTryRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.DidNotTryRadio.ImageIndex = CType(resources.GetObject("DidNotTryRadio.ImageIndex"), Integer)
            Me.DidNotTryRadio.ImeMode = CType(resources.GetObject("DidNotTryRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.DidNotTryRadio.Location = CType(resources.GetObject("DidNotTryRadio.Location"), System.Drawing.Point)
            Me.DidNotTryRadio.Name = "DidNotTryRadio"
            Me.DidNotTryRadio.RightToLeft = CType(resources.GetObject("DidNotTryRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.DidNotTryRadio.Size = CType(resources.GetObject("DidNotTryRadio.Size"), System.Drawing.Size)
            Me.DidNotTryRadio.TabIndex = CType(resources.GetObject("DidNotTryRadio.TabIndex"), Integer)
            Me.DidNotTryRadio.Text = resources.GetString("DidNotTryRadio.Text")
            Me.DidNotTryRadio.TextAlign = CType(resources.GetObject("DidNotTryRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.DidNotTryRadio.Visible = CType(resources.GetObject("DidNotTryRadio.Visible"), Boolean)
            '
            'NotReadyRadio
            '
            Me.NotReadyRadio.AccessibleDescription = resources.GetString("NotReadyRadio.AccessibleDescription")
            Me.NotReadyRadio.AccessibleName = resources.GetString("NotReadyRadio.AccessibleName")
            Me.NotReadyRadio.Anchor = CType(resources.GetObject("NotReadyRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.NotReadyRadio.Appearance = CType(resources.GetObject("NotReadyRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.NotReadyRadio.BackgroundImage = CType(resources.GetObject("NotReadyRadio.BackgroundImage"), System.Drawing.Image)
            Me.NotReadyRadio.CheckAlign = CType(resources.GetObject("NotReadyRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.NotReadyRadio.Dock = CType(resources.GetObject("NotReadyRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.NotReadyRadio.Enabled = CType(resources.GetObject("NotReadyRadio.Enabled"), Boolean)
            Me.NotReadyRadio.FlatStyle = CType(resources.GetObject("NotReadyRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.NotReadyRadio.Font = CType(resources.GetObject("NotReadyRadio.Font"), System.Drawing.Font)
            Me.NotReadyRadio.Image = CType(resources.GetObject("NotReadyRadio.Image"), System.Drawing.Image)
            Me.NotReadyRadio.ImageAlign = CType(resources.GetObject("NotReadyRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.NotReadyRadio.ImageIndex = CType(resources.GetObject("NotReadyRadio.ImageIndex"), Integer)
            Me.NotReadyRadio.ImeMode = CType(resources.GetObject("NotReadyRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.NotReadyRadio.Location = CType(resources.GetObject("NotReadyRadio.Location"), System.Drawing.Point)
            Me.NotReadyRadio.Name = "NotReadyRadio"
            Me.NotReadyRadio.RightToLeft = CType(resources.GetObject("NotReadyRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.NotReadyRadio.Size = CType(resources.GetObject("NotReadyRadio.Size"), System.Drawing.Size)
            Me.NotReadyRadio.TabIndex = CType(resources.GetObject("NotReadyRadio.TabIndex"), Integer)
            Me.NotReadyRadio.Text = resources.GetString("NotReadyRadio.Text")
            Me.NotReadyRadio.TextAlign = CType(resources.GetObject("NotReadyRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.NotReadyRadio.Visible = CType(resources.GetObject("NotReadyRadio.Visible"), Boolean)
            '
            'OperateControlRadio
            '
            Me.OperateControlRadio.AccessibleDescription = resources.GetString("OperateControlRadio.AccessibleDescription")
            Me.OperateControlRadio.AccessibleName = resources.GetString("OperateControlRadio.AccessibleName")
            Me.OperateControlRadio.Anchor = CType(resources.GetObject("OperateControlRadio.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OperateControlRadio.Appearance = CType(resources.GetObject("OperateControlRadio.Appearance"), System.Windows.Forms.Appearance)
            Me.OperateControlRadio.BackgroundImage = CType(resources.GetObject("OperateControlRadio.BackgroundImage"), System.Drawing.Image)
            Me.OperateControlRadio.CheckAlign = CType(resources.GetObject("OperateControlRadio.CheckAlign"), System.Drawing.ContentAlignment)
            Me.OperateControlRadio.Dock = CType(resources.GetObject("OperateControlRadio.Dock"), System.Windows.Forms.DockStyle)
            Me.OperateControlRadio.Enabled = CType(resources.GetObject("OperateControlRadio.Enabled"), Boolean)
            Me.OperateControlRadio.FlatStyle = CType(resources.GetObject("OperateControlRadio.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.OperateControlRadio.Font = CType(resources.GetObject("OperateControlRadio.Font"), System.Drawing.Font)
            Me.OperateControlRadio.Image = CType(resources.GetObject("OperateControlRadio.Image"), System.Drawing.Image)
            Me.OperateControlRadio.ImageAlign = CType(resources.GetObject("OperateControlRadio.ImageAlign"), System.Drawing.ContentAlignment)
            Me.OperateControlRadio.ImageIndex = CType(resources.GetObject("OperateControlRadio.ImageIndex"), Integer)
            Me.OperateControlRadio.ImeMode = CType(resources.GetObject("OperateControlRadio.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OperateControlRadio.Location = CType(resources.GetObject("OperateControlRadio.Location"), System.Drawing.Point)
            Me.OperateControlRadio.Name = "OperateControlRadio"
            Me.OperateControlRadio.RightToLeft = CType(resources.GetObject("OperateControlRadio.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OperateControlRadio.Size = CType(resources.GetObject("OperateControlRadio.Size"), System.Drawing.Size)
            Me.OperateControlRadio.TabIndex = CType(resources.GetObject("OperateControlRadio.TabIndex"), Integer)
            Me.OperateControlRadio.Text = resources.GetString("OperateControlRadio.Text")
            Me.OperateControlRadio.TextAlign = CType(resources.GetObject("OperateControlRadio.TextAlign"), System.Drawing.ContentAlignment)
            Me.OperateControlRadio.Visible = CType(resources.GetObject("OperateControlRadio.Visible"), Boolean)
            '
            'OKButton
            '
            Me.OKButton.AccessibleDescription = resources.GetString("OKButton.AccessibleDescription")
            Me.OKButton.AccessibleName = resources.GetString("OKButton.AccessibleName")
            Me.OKButton.Anchor = CType(resources.GetObject("OKButton.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.OKButton.BackgroundImage = CType(resources.GetObject("OKButton.BackgroundImage"), System.Drawing.Image)
            Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.OKButton.Dock = CType(resources.GetObject("OKButton.Dock"), System.Windows.Forms.DockStyle)
            Me.OKButton.Enabled = CType(resources.GetObject("OKButton.Enabled"), Boolean)
            Me.OKButton.FlatStyle = CType(resources.GetObject("OKButton.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.OKButton.Font = CType(resources.GetObject("OKButton.Font"), System.Drawing.Font)
            Me.OKButton.Image = CType(resources.GetObject("OKButton.Image"), System.Drawing.Image)
            Me.OKButton.ImageAlign = CType(resources.GetObject("OKButton.ImageAlign"), System.Drawing.ContentAlignment)
            Me.OKButton.ImageIndex = CType(resources.GetObject("OKButton.ImageIndex"), Integer)
            Me.OKButton.ImeMode = CType(resources.GetObject("OKButton.ImeMode"), System.Windows.Forms.ImeMode)
            Me.OKButton.Location = CType(resources.GetObject("OKButton.Location"), System.Drawing.Point)
            Me.OKButton.Name = "OKButton"
            Me.OKButton.RightToLeft = CType(resources.GetObject("OKButton.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.OKButton.Size = CType(resources.GetObject("OKButton.Size"), System.Drawing.Size)
            Me.OKButton.TabIndex = CType(resources.GetObject("OKButton.TabIndex"), Integer)
            Me.OKButton.Text = resources.GetString("OKButton.Text")
            Me.OKButton.TextAlign = CType(resources.GetObject("OKButton.TextAlign"), System.Drawing.ContentAlignment)
            Me.OKButton.Visible = CType(resources.GetObject("OKButton.Visible"), Boolean)
            '
            'TimeoutDetailForm
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.ControlBox = False
            Me.Controls.Add(Me.OKButton)
            Me.Controls.Add(Me.ReasonGroup)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximizeBox = False
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "TimeoutDetailForm"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            Me.ReasonGroup.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Enum TimeoutReason
            NotApplicable
            SubjectNotReady
            SubjectDidNotTryAttempt
            SubjectStartedAttemptDuringCriticalTime
            SubjectDidNotKnowHowToOperateTheControl
            ControlHasNoResponse
            OtherReason
        End Enum

        Private mOtherReason As String
        Public ReadOnly Property OtherReason() As String
            Get
                Return mOtherReason
            End Get
        End Property
        Private mReason As TimeoutReason
        Public ReadOnly Property Reason() As TimeoutReason
            Get
                Return mReason
            End Get
        End Property

        Private Sub RadioCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                                                                                    NotReadyRadio.Click, _
                                                                                                    DidNotTryRadio.Click, _
                                                                                                    CriticalTimeRadio.Click, _
                                                                                                    NoResponseRadio.Click, _
                                                                                                    OperateControlRadio.Click, _
                                                                                                    OtherRadio.Click
            If NotReadyRadio.Checked Then mReason = TimeoutReason.SubjectNotReady
            If DidNotTryRadio.Checked Then mReason = TimeoutReason.SubjectDidNotTryAttempt
            If CriticalTimeRadio.Checked Then mReason = TimeoutReason.SubjectStartedAttemptDuringCriticalTime
            If NoResponseRadio.Checked Then mReason = TimeoutReason.ControlHasNoResponse
            If OperateControlRadio.Checked Then mReason = TimeoutReason.SubjectDidNotKnowHowToOperateTheControl
            If OtherRadio.Checked Then mReason = TimeoutReason.OtherReason



            OtherReasonText.Enabled = OtherRadio.Checked
        End Sub

        Private Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OKButton.Click
            Me.Close()
        End Sub

        Private Sub OtherReasonText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OtherReasonText.TextChanged
            mOtherReason = OtherReasonText.Text
        End Sub
    End Class

End Namespace
