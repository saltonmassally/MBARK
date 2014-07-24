Option Strict On

Imports System.Drawing
Imports System.Windows.Forms

Namespace Mbark.UI

    Public Class XBox
        Inherits System.Windows.Forms.CheckBox

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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
        End Sub

#End Region

        Private Const FocusThickness As Integer = 2
        Private Const InsetThickness As Integer = 2
        Private Const XThickness As Single = 2

        Private mHotColor As Color
        Private mXColor As Color
        Private mBorderColor As Color


        Private Sub UserNew()
            SetStyle(ControlStyles.UserPaint, True)

            mHotColor = UI.ThemeInterop.CheckBoxHotColor
            mXColor = UI.ThemeInterop.CheckBoxCheckColor
            mBorderColor = UI.ThemeInterop.CheckBoxBorderColor

        End Sub

        Private mMouseInside As Boolean


        Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
            MyBase.OnMouseEnter(e)
            mMouseInside = True
            Refresh()
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MyBase.OnMouseLeave(e)
            mMouseInside = False
            Refresh()
        End Sub


        Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
            Refresh()
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

            Static enabledBoxPen As New Pen(mBorderColor)
            Static disabledBoxPen As New Pen(SystemColors.ControlDark)

            Static enabledBackgroundBrush As New Drawing2D.LinearGradientBrush( _
                    New PointF(0, 0), New PointF(Width, Height), SystemColors.ControlLight, SystemColors.ControlLightLight)
            Static disabledBackgroundBrush As New SolidBrush(SystemColors.Control)

            Static enabledHotPen As New Pen(mHotColor, FocusThickness)
            Static disabledHotPen As New Pen(SystemColors.Control, FocusThickness)

            Static enabledXPen As New Pen(mXColor, XThickness)
            Static disabledXPen As New Pen(SystemColors.ControlDark, XThickness)

            Static enabledFocusPen As New Pen(mBorderColor)
            enabledFocusPen.DashStyle = Drawing2D.DashStyle.Dot

            Static disabledFocusPen As New Pen(SystemColors.ControlDarkDark)
            enabledFocusPen.DashStyle = Drawing2D.DashStyle.Dot


            Dim focusPen As Pen
            Dim hotPen As Pen
            Dim boxPen As Pen
            Dim backgroundBrush As Brush
            Dim xPen As Pen

            If Enabled Then
                backgroundBrush = enabledBackgroundBrush
                hotpen = enabledHotPen
                xPen = enabledXPen
                boxPen = enabledBoxPen
                focusPen = enabledFocusPen
            Else
                backgroundBrush = disabledBackgroundBrush
                hotpen = disabledHotPen
                xPen = disabledXPen
                boxPen = disabledBoxPen
                focusPen = disabledFocusPen
            End If

            With e.Graphics



                ' Background
                .FillRectangle(backgroundBrush, 0, 0, Width, Height)

                ' Outline
                .DrawRectangle(boxPen, 0, 0, Width - 1, Height - 1)

                If mMouseInside Then
                    .DrawRectangle( _
                        hotPen, _
                        CInt(Math.Floor(FocusThickness / 2.0!) + 1), _
                        CInt(Math.Floor(FocusThickness / 2.0!) + 1), _
                        Width - FocusThickness - 2, _
                        Height - FocusThickness - 2)
                End If

                If Focused Then
                    .DrawRectangle(focusPen, 1, 1, Width - 3, Height - 3)
                End If


                If CheckState = Windows.Forms.CheckState.Checked Then

                    Dim x0 As Single = InsetThickness + 1
                    Dim x1 As Single = Width - InsetThickness - 2
                    Dim y0 As Single = x0
                    Dim y1 As Single = Height - InsetThickness - 2

                    Dim p0 As New PointF(x0, y0)
                    Dim p1 As New PointF(x1, y1)

                    Dim p2 As New PointF(x0, y1)
                    Dim p3 As New PointF(x1, y0)

                    .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    .DrawLine(xPen, p0, p1)
                    .DrawLine(xPen, p2, p3)

                End If


            End With

        End Sub


    End Class

End Namespace