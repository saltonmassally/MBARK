Option Strict On

Imports System.Windows.Forms
Imports System.Drawing

Namespace Mbark.UI

    Public Enum SmoothPictureBoxAlignment
        Top
        Bottom
        Left
        Right
        Center
    End Enum

    Public Class SmoothPictureBox
        Inherits UserControl

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
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
        Friend WithEvents PictureBox As PictureBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.PictureBox = New PictureBox
            Me.SuspendLayout()
            '
            'PictureBox
            '
            Me.PictureBox.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox.Cursor = Cursors.Default
            Me.PictureBox.Dock = DockStyle.Fill
            Me.PictureBox.Location = New System.Drawing.Point(0, 0)
            Me.PictureBox.Name = "PictureBox"
            Me.PictureBox.Size = New System.Drawing.Size(288, 336)
            Me.PictureBox.TabIndex = 0
            Me.PictureBox.TabStop = False
            '
            'SmoothPictureBox
            '
            Me.Controls.Add(Me.PictureBox)
            Me.Name = "SmoothPictureBox"
            Me.Size = New System.Drawing.Size(288, 336)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private mImageWidth As Integer
        Private mImageHeight As Integer
        Private mImageOriginY As Integer
        Private mImageOriginX As Integer

        Private mIsDirty As Boolean = True

        Private mIsLeftRightFilled As Boolean
        Private mIsTopBottomFilled As Boolean

        Public ReadOnly Property IsLeftRightFilled() As Boolean
            Get
                Return mIsLeftRightFilled
            End Get
        End Property

        Public ReadOnly Property IsTopBottomFilled() As Boolean
            Get
                Return mIsTopBottomFilled
            End Get
        End Property


        Private Sub FillPictureBox()

            If CurrentBitmap Is Nothing Then
                PictureBox.Image = Nothing
                Return
            End If

            If PictureBox.Width = 0 Or PictureBox.Height = 0 Then Return

            Dim ws As Integer = PictureBox.Width
            Dim hs As Integer = PictureBox.Height

            If Not mIsDirty Then Return

            Dim dest As New Bitmap(ws, hs)

            Dim g As Graphics = Graphics.FromImage(dest)

            g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear

            mImageWidth = ws - 1
            mImageHeight = hs - 1
            Dim a As Single = (ws * 1.0!) / hs
            Dim ai As Single = (CurrentBitmap.Width * 1.0!) / CurrentBitmap.Height

            If a < ai Then
                mImageHeight = CInt(ws * 1.0 / ai)

                mImageOriginX = 0
                If Alignment = SmoothPictureBoxAlignment.Top Then
                    mImageOriginY = 0
                ElseIf Alignment = SmoothPictureBoxAlignment.Bottom Then
                    mImageOriginY = hs - mImageHeight
                Else
                    mImageOriginY = CInt(0.5 * (hs - mImageHeight))
                End If

                mIsTopBottomFilled = True
                mIsLeftRightFilled = False
            Else
                mImageWidth = CInt(hs * ai)
                If Alignment = SmoothPictureBoxAlignment.Left Then
                    mImageOriginX = 0
                ElseIf Alignment = SmoothPictureBoxAlignment.Right Then
                    mImageOriginX = ws - mImageWidth
                Else
                    mImageOriginX = CInt(0.5 * (ws - mImageWidth))
                End If
                mImageOriginY = 0
                mIsTopBottomFilled = False
                mIsLeftRightFilled = True
            End If

            g.DrawImage(CurrentBitmap, mImageOriginX, mImageOriginY, mImageWidth, mImageHeight)

            If Backwards Then
                dest.RotateFlip(RotateFlipType.Rotate180FlipY)
            Else
                dest.RotateFlip(RotateFlipType.RotateNoneFlipNone)
            End If

            PictureBox.Image = dest

            If WithBorder Then
                g.DrawRectangle(New Pen(BorderColor, BorderThickness), mImageOriginX, mImageOriginY + 1, mImageWidth, mImageHeight - 1)
            End If


            Dim overlayWidth As Integer = UI.StringWidthInPixels(g, OverlayFont, OverlayText)
            Dim overlayHeight As Integer = UI.StringHeightInPixels(g, OverlayFont, OverlayText)

            Dim overlayX As Single = PictureBox.Width / 2.0! - overlayWidth / 2.0! + mImageOriginX
            Dim overlayY As Single = PictureBox.Height / 2.0! - overlayHeight / 2.0! + mImageOriginY

            g.DrawString(OverlayText, Me.Font, New SolidBrush(Color.Black), overlayX, overlayY)


            mIsDirty = False


        End Sub




        Public Property OverlayText() As String
            Get
                Return mOverlayText
            End Get
            Set(ByVal value As String)
                mOverlayText = value
            End Set
        End Property
        Private mOverlayText As String


        Private mOverlayFont As Font = Me.Font
        Public Property OverlayFont() As Font
            Get
                Return mOverlayFont
            End Get
            Set(ByVal value As Font)
                If Not mOverlayFont Is Nothing Then
                    mOverlayFont.Dispose()
                    mOverlayFont = Nothing
                End If
                mOverlayFont = value
            End Set
        End Property

        Private mOverlayBrush As SolidBrush = New SolidBrush(Color.Black)
        Public Property OverlayColor() As Color
            Get
                Return mOverlayBrush.Color
            End Get
            Set(ByVal value As Color)
                If Not mOverlayBrush Is Nothing Then
                    mOverlayBrush.Dispose()
                    mOverlayFont = Nothing
                End If
                mOverlayBrush = New SolidBrush(value)
            End Set
        End Property


        Private mAlignment As SmoothPictureBoxAlignment = SmoothPictureBoxAlignment.Center
        Public Property Alignment() As SmoothPictureBoxAlignment
            Get
                Return mAlignment
            End Get
            Set(ByVal value As SmoothPictureBoxAlignment)
                mAlignment = value
            End Set
        End Property

        Private mWithBorder As Boolean
        Public Property WithBorder() As Boolean
            Get
                Return mWithBorder
            End Get
            Set(ByVal value As Boolean)
                If value <> mWithBorder Then mIsDirty = True
                mWithBorder = value

            End Set
        End Property


        Public ReadOnly Property HorizontalScale() As Single
            Get
                Return CurrentBitmap.Width * 1.0! / mImageWidth
            End Get
        End Property

        Public Function RemapImagePoint(ByVal originalPoint As Point) As Point

            If CurrentBitmap Is Nothing Then Return originalPoint

            FillPictureBox()

            Dim newPoint As New Point

            Dim originalWidth As Single = CurrentBitmap.Width * 1.0!
            Dim originalHeight As Single = CurrentBitmap.Height * 1.0!

            Dim imageWidth As Single = mImageWidth * 1.0!
            Dim imageHeight As Single = mImageHeight * 1.0!

            Dim originalX As Single = originalPoint.X * 1.0!
            Dim originalY As Single = originalPoint.Y * 1.0!

            If Backwards Then
                newPoint.X = CInt(mImageOriginX + (imageWidth - (originalX * imageWidth / originalWidth)))
            Else
                newPoint.X = CInt(mImageOriginX + (originalX * imageWidth / originalWidth))
            End If

            newPoint.Y = CInt(mImageOriginY + (originalY * imageHeight / originalHeight))

            ' Don't forget the dockpadding
            newPoint.X += DockPadding.Left
            newPoint.Y += DockPadding.Top

            Return newPoint
        End Function


        Public ReadOnly Property ImageAspectRatio() As Double
            Get
                If CurrentBitmap Is Nothing Then Return 0
                Return CurrentBitmap.Width / CurrentBitmap.Height
            End Get
        End Property

        Public ReadOnly Property CurrentBitmap() As Image
            Get
                If mDisabledImage Is Nothing OrElse Enabled Then
                    Return mEnabledImage
                Else
                    Return mDisabledImage
                End If
            End Get
        End Property

        Private mBackwards As Boolean
        Public Property Backwards() As Boolean
            Get
                Return mBackwards
            End Get
            Set(ByVal value As Boolean)
                If value = mBackwards Then Return
                mBackwards = value
                mIsDirty = True
                FillPictureBox()
            End Set
        End Property

        Private mEnabledImage As Image
        Public Property EnabledImage() As Image
            Get
                Return mEnabledImage
            End Get
            Set(ByVal value As Image)
                If value Is mEnabledImage Then Return
                mEnabledImage = value
                mIsDirty = True
                FillPictureBox()
            End Set
        End Property

        Private mDisabledImage As Image
        Public Property DisabledImage() As Image
            Get
                Return mDisabledImage
            End Get
            Set(ByVal value As Image)
                If value Is mDisabledImage Then Return
                mDisabledImage = value
                mIsDirty = True
                FillPictureBox()
            End Set
        End Property

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            mIsDirty = True
            Refresh()
        End Sub

        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            mIsDirty = True
            Refresh()
        End Sub


        Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
            MyBase.OnEnabledChanged(e)
            mIsDirty = True
            Refresh()
        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            FillPictureBox()
            PictureBox.Refresh()
        End Sub

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            Refresh()
        End Sub

        Private mBorderColor As Color = Color.Black
        Public Property BorderColor() As Color
            Get
                Return mBorderColor
            End Get
            Set(ByVal value As Color)
                mBorderColor = value
                mIsDirty = True
            End Set
        End Property

        Private mBorderThickness As Integer = 1
        Public Property BorderThickness() As Integer
            Get
                Return mBorderThickness
            End Get
            Set(ByVal value As Integer)
                mBorderThickness = value
                mIsDirty = True
            End Set
        End Property

    End Class


End Namespace