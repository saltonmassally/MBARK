Option Strict On

Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Namespace Mbark.UI

    Public Class AutosizableRichTextBox
        Inherits System.Windows.Forms.UserControl
        Implements IAutosizable
        Implements IHasUICulture

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
        Friend WithEvents RichTextBox As System.Windows.Forms.RichTextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AutosizableRichTextBox))
            Me.RichTextBox = New System.Windows.Forms.RichTextBox
            Me.SuspendLayout()
            '
            'RichTextBox
            '
            Me.RichTextBox.AccessibleDescription = resources.GetString("RichTextBox.AccessibleDescription")
            Me.RichTextBox.AccessibleName = resources.GetString("RichTextBox.AccessibleName")
            Me.RichTextBox.Anchor = CType(resources.GetObject("RichTextBox.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.RichTextBox.AutoSize = CType(resources.GetObject("RichTextBox.AutoSize"), Boolean)
            Me.RichTextBox.BackColor = System.Drawing.SystemColors.Control
            Me.RichTextBox.BackgroundImage = CType(resources.GetObject("RichTextBox.BackgroundImage"), System.Drawing.Image)
            Me.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.RichTextBox.BulletIndent = CType(resources.GetObject("RichTextBox.BulletIndent"), Integer)
            Me.RichTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.RichTextBox.Dock = CType(resources.GetObject("RichTextBox.Dock"), System.Windows.Forms.DockStyle)
            Me.RichTextBox.Enabled = CType(resources.GetObject("RichTextBox.Enabled"), Boolean)
            Me.RichTextBox.Font = CType(resources.GetObject("RichTextBox.Font"), System.Drawing.Font)
            Me.RichTextBox.ImeMode = CType(resources.GetObject("RichTextBox.ImeMode"), System.Windows.Forms.ImeMode)
            Me.RichTextBox.Location = CType(resources.GetObject("RichTextBox.Location"), System.Drawing.Point)
            Me.RichTextBox.MaxLength = CType(resources.GetObject("RichTextBox.MaxLength"), Integer)
            Me.RichTextBox.Multiline = CType(resources.GetObject("RichTextBox.Multiline"), Boolean)
            Me.RichTextBox.Name = "RichTextBox"
            Me.RichTextBox.RightMargin = CType(resources.GetObject("RichTextBox.RightMargin"), Integer)
            Me.RichTextBox.RightToLeft = CType(resources.GetObject("RichTextBox.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.RichTextBox.ScrollBars = CType(resources.GetObject("RichTextBox.ScrollBars"), System.Windows.Forms.RichTextBoxScrollBars)
            Me.RichTextBox.Size = CType(resources.GetObject("RichTextBox.Size"), System.Drawing.Size)
            Me.RichTextBox.TabIndex = CType(resources.GetObject("RichTextBox.TabIndex"), Integer)
            Me.RichTextBox.Text = resources.GetString("RichTextBox.Text")
            Me.RichTextBox.Visible = CType(resources.GetObject("RichTextBox.Visible"), Boolean)
            Me.RichTextBox.WordWrap = CType(resources.GetObject("RichTextBox.WordWrap"), Boolean)
            Me.RichTextBox.ZoomFactor = CType(resources.GetObject("RichTextBox.ZoomFactor"), Single)
            '
            'AutosizableRichTextBox
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.Controls.Add(Me.RichTextBox)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.Name = "AutosizableRichTextBox"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
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

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If InDesignMode(Me) Then Return
            RichTextBox.SelectionColor = Me.BackColor
            RichTextBox.Font = Me.Font
            If NearestForm IsNot Nothing Then
                Dim graphics As Graphics = NearestForm.CreateGraphics
                RefreshAutomaticLayout(graphics)
                graphics.Dispose()
            End If
        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) Implements IAutosizable.RefreshAutomaticLayout
            mMinimumWidth = AutoWidth.CharWidthInPixels(UICulture, graphics, Me.Font) * mMinimumWidthInChars
            mMinimumHeight = AutoWidth.CharWidthInPixels(UICulture, graphics, Me.Font) * mMinimumHeightInChars
        End Sub

        Private mMinimumWidthInChars As Integer
        Public Property MinimumWidthInChars() As Integer
            Get
                Return mMinimumWidthInChars
            End Get
            Set(ByVal value As Integer)
                mMinimumWidthInChars = value
            End Set
        End Property

        Private mMinimumHeightInChars As Integer = 1
        Public Property MinimumHeightInChars() As Integer
            Get
                Return mMinimumHeightInChars
            End Get
            Set(ByVal value As Integer)
                mMinimumHeightInChars = value
            End Set
        End Property

        Public Overrides Property Text() As String
            Get
                Return RichTextBox.Rtf
            End Get
            Set(ByVal value As String)
                RichTextBox.ReadOnly = False
                RichTextBox.Rtf = value
                RichTextBox.ReadOnly = True
                RichTextBox.Refresh()
            End Set
        End Property

        Dim mMinimumHeight As Integer
        Dim mMinimumWidth As Integer

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
        End Sub


        Public ReadOnly Property MinimumHeight() As Integer Implements IAutosizable.MinimumHeight
            Get
                Return mMinimumHeight
            End Get
        End Property

        Public ReadOnly Property MinimumWidth() As Integer Implements IAutosizable.MinimumWidth
            Get
                Return mMinimumWidth
            End Get
        End Property

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property
    End Class

End Namespace