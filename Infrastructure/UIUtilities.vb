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
Imports System.Diagnostics.CodeAnalysis
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms

Imports SF = Syncfusion.Windows.Forms

Imports Mbark
Imports Mbark.InfrastructureMessages

Namespace Mbark.UI


    Public NotInheritable Class Icons

        Private Shared mCloseIcon As Icon
        Private Shared mDisabledCloseIcon As Icon
        Private Shared mHotCloseIcon As Icon
        Private Shared mType As Type = (New Icons).GetType


        Private Sub New()
            ' Prevent construction
        End Sub

        Public Shared ReadOnly Property Close() As Icon
            Get
                If mCloseIcon Is Nothing Then
                    mCloseIcon = New Icon(mType, "close.ico")
                End If
                Return mCloseIcon
            End Get
        End Property

        Public Shared ReadOnly Property DisabledClose() As Icon
            Get
                If mDisabledCloseIcon Is Nothing Then
                    mDisabledCloseIcon = New Icon(mType, "close.disabled.ico")
                End If
                Return mDisabledCloseIcon
            End Get
        End Property

        Public Shared ReadOnly Property HotClose() As Icon
            Get
                If mHotCloseIcon Is Nothing Then
                    mHotCloseIcon = New Icon(mType, "close.hot.ico")
                End If
                Return mHotCloseIcon
            End Get
        End Property
    End Class

    Public NotInheritable Class ThemeInterop




        Friend NotInheritable Class NativeMethods


            <DllImport("UxTheme.dll", CallingConvention:=CallingConvention.Cdecl, ExactSpelling:=False)> _
            Friend Shared Function CloseThemeData(ByVal hWnd As IntPtr) As Int32
            End Function


            <DllImport("UxTheme.dll", CallingConvention:=CallingConvention.Cdecl, ExactSpelling:=True)> _
            Friend Shared Function GetThemeColor(ByVal hTheme As IntPtr, _
                                 ByVal iPartID As Integer, _
                                 ByVal iStateId As Integer, _
                                 ByVal iPropId As Integer, _
                                 ByRef pColor As ColorRef) As Integer
            End Function

            <DllImport("UxTheme.dll", CallingConvention:=CallingConvention.Cdecl, ExactSpelling:=True)> _
            Friend Shared Function IsAppThemed() As Integer
            End Function

            <DllImport("UxTheme.dll", CallingConvention:=CallingConvention.Cdecl, ExactSpelling:=True, CharSet:=CharSet.Unicode)> _
            Friend Shared Function OpenThemeData(ByVal hWnd As IntPtr, ByVal classList As String) As IntPtr
            End Function
            Private Sub New()
                ' Prevent construction
            End Sub

        End Class

        Friend Structure ColorRef
            Public R As Byte
            Public G As Byte
            Public B As Byte

            Public Overrides Function ToString() As String
                Return String.Format(CultureInfo.InvariantCulture, "#{0:x2}{1:x2}{2:x2}", R, G, B)
            End Function

        End Structure

        Private Sub New()
            ' Prevent construction
        End Sub

        Public Shared Function CheckBoxBorderColor() As Color
            Dim returnColor As Color = SystemColors.ActiveCaption
            If OSFeature.Feature.IsPresent(OSFeature.Themes) AndAlso NativeMethods.IsAppThemed() = 1 Then
                Dim cb As New CheckBox
                Dim theme As IntPtr = NativeMethods.OpenThemeData(cb.Handle, "BUTTON")
                If Not theme.Equals(IntPtr.Zero) Then
                    Dim outColor As ColorRef
                    NativeMethods.GetThemeColor(theme, 3, 1, 3822, outColor)
                    returnColor = Color.FromArgb(255, outColor.R, outColor.G, outColor.B)
                    NativeMethods.CloseThemeData(theme)
                End If
                cb.Dispose()
            End If
            Return returnColor
        End Function

        Public Shared Function CheckBoxCheckColor() As Color
            Dim returnColor As Color = SystemColors.ActiveCaption
            If OSFeature.Feature.IsPresent(OSFeature.Themes) AndAlso NativeMethods.IsAppThemed() = 1 Then
                Dim cb As New CheckBox
                Dim theme As IntPtr = NativeMethods.OpenThemeData(cb.Handle, "BUTTON")
                If Not theme.Equals(IntPtr.Zero) Then
                    Dim outColor As ColorRef
                    NativeMethods.GetThemeColor(theme, 3, 1, 3821, outColor)
                    returnColor = Color.FromArgb(255, outColor.R, outColor.G, outColor.B)
                    NativeMethods.CloseThemeData(theme)
                End If
                cb.Dispose()
            End If
            Return returnColor
        End Function

        Public Shared Function CheckBoxHotColor() As Color
            Dim returnColor As Color = SystemColors.ControlDark
            If OSFeature.Feature.IsPresent(OSFeature.Themes) AndAlso NativeMethods.IsAppThemed() = 1 Then
                Dim cb As New CheckBox
                Dim theme As IntPtr = NativeMethods.OpenThemeData(cb.Handle, "BUTTON")
                If Not theme.Equals(IntPtr.Zero) Then
                    Dim outColor As ColorRef
                    NativeMethods.GetThemeColor(theme, 3, 2, 3823, outColor)
                    returnColor = Color.FromArgb(255, outColor.R, outColor.G, outColor.B)
                    NativeMethods.CloseThemeData(theme)
                End If
                cb.Dispose()
            End If
            Return returnColor
        End Function

        Public Shared Function GroupBoxForeColor() As Color
            Dim foreColor As Color = SystemColors.HotTrack
            Static ButtonClassList As String = "BUTTON"
            If OSFeature.Feature.IsPresent(OSFeature.Themes) AndAlso NativeMethods.IsAppThemed() = 1 Then
                Dim gb As New GroupBox
                Dim td As IntPtr = NativeMethods.OpenThemeData(gb.Handle, ButtonClassList)
                If Not td.Equals(IntPtr.Zero) Then
                    Dim outColor As ColorRef
                    Dim okay As Boolean = NativeMethods.GetThemeColor(td, 4, 1, 3803, outColor) <> 0
                    If okay Then foreColor = Color.FromArgb(0, outColor.R, outColor.G, outColor.B)
                End If
                NativeMethods.CloseThemeData(gb.Handle)
            End If
            Return foreColor
        End Function

    End Class

    Public Module UIUtilities


        Public Const DoubleBufferStyle As System.Windows.Forms.ControlStyles = _
            Windows.Forms.ControlStyles.UserPaint Or _
            Windows.Forms.ControlStyles.AllPaintingInWmPaint Or _
            Windows.Forms.ControlStyles.DoubleBuffer

        Public Function FindNearestForm(ByVal control As Control) As Form
            Return DirectCast(FindNearestParentOfType(control, GetType(Form)), Form)
        End Function

        Public Function HorizontalPadding(ByVal form As Form) As Integer
            If form Is Nothing Then Throw New ArgumentNullException("form")
            Return form.Width - form.ClientSize.Width
        End Function

        ' A bit of a hack, we consider the state of the control's design mode 
        Public Function InDesignMode(ByVal control As Windows.Forms.Control) As Boolean

            If LicenseManagerInDesignMode() Then Return True

            Dim controls As New List(Of Control)
            GetParents(control, controls)

            For i As Integer = 0 To controls.Count - 1

                ' Windows.Forms.Control.DesignMode is proteced, so we've got to use reflection to get at it.
                Dim flags As Reflection.BindingFlags = _
                       Reflection.BindingFlags.NonPublic Or _
                       Reflection.BindingFlags.FlattenHierarchy Or _
                       Reflection.BindingFlags.Instance
                Dim designModeGetter As Reflection.PropertyInfo = control.GetType.GetProperty("DesignMode", flags)
                If CType(designModeGetter.GetValue(controls(i), Nothing), Boolean) Then Return True

            Next

            Return False
        End Function

        Public Function LicenseManagerInDesignMode() As Boolean
            Return System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime
        End Function

        <SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification:="Method performs type-specific operation")> _
        Public Function LocationForCenteringChildForm(ByVal parent As Form, ByVal child As Form) As Point
            If parent Is Nothing Then Throw New ArgumentNullException("parent")
            If child Is Nothing Then Throw New ArgumentNullException("child")
            Dim x As Integer = CInt(parent.Location.X + parent.Width / 2.0! - child.Width / 2.0!)
            Dim y As Integer = CInt(parent.Location.Y + parent.Height / 2.0! - child.Height / 2.0!)
            Return New Point(x, y)
        End Function

        Public Function LocationIsNear(ByVal control As Control, ByVal location As Point, ByVal tolerance As Integer) As Boolean
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim dx As Integer = Math.Abs(control.Location.X - location.X)
            Dim dy As Integer = Math.Abs(control.Location.Y - location.Y)
            If dx <= tolerance And dy <= tolerance Then Return True
        End Function

        Public Function LowerLeft(ByVal control As Control) As Point
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim x As Integer = control.Location.X
            Dim y As Integer = control.Location.Y + control.Height
            Return New Point(x, y)
        End Function

        Public Function LowerLeft(ByVal control As Control, ByVal verticalOffset As Integer) As Point
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim x As Integer = control.Location.X
            Dim y As Integer = control.Location.Y + control.Height + verticalOffset
            Return New Point(x, y)
        End Function

        Public Function LowerRight(ByVal control As Control, ByVal verticalOffset As Integer) As Point
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim x As Integer = control.Location.X
            Dim y As Integer = control.Location.Y + control.Height + verticalOffset
            Return New Point(x, y)
        End Function

        Public Function RawFormatGuidToNonGuid(ByVal format As Imaging.ImageFormat) As Imaging.ImageFormat
            If format Is Nothing Then Throw New ArgumentNullException("format")
            If format.Guid.Equals(Imaging.ImageFormat.Bmp.Guid) Then Return Imaging.ImageFormat.Bmp
            If format.Guid.Equals(Imaging.ImageFormat.Emf.Guid) Then Return Imaging.ImageFormat.Emf
            If format.Guid.Equals(Imaging.ImageFormat.Exif.Guid) Then Return Imaging.ImageFormat.Exif
            If format.Guid.Equals(Imaging.ImageFormat.Gif.Guid) Then Return Imaging.ImageFormat.Gif
            If format.Guid.Equals(Imaging.ImageFormat.Icon.Guid) Then Return Imaging.ImageFormat.Icon
            If format.Guid.Equals(Imaging.ImageFormat.Jpeg.Guid) Then Return Imaging.ImageFormat.Jpeg
            If format.Guid.Equals(Imaging.ImageFormat.MemoryBmp.Guid) Then Return Imaging.ImageFormat.MemoryBmp
            If format.Guid.Equals(Imaging.ImageFormat.Png.Guid) Then Return Imaging.ImageFormat.Png
            If format.Guid.Equals(Imaging.ImageFormat.Tiff.Guid) Then Return Imaging.ImageFormat.Tiff
            Return format
        End Function

        Public Function RefreshAutomaticLayoutOnLayoutEvent( _
            ByVal autosizable As IAutosizable, _
            ByVal fontOfCurrentLayout As Font, _
            ByVal targetFont As Font) As Font

            If autosizable Is Nothing Then Throw New ArgumentNullException("autosizable")

            Dim control As control = DirectCast(autosizable, control)
            If Mbark.UI.InDesignMode(control) Or autosizable.NearestForm Is Nothing Then Return Nothing
            If Not fontOfCurrentLayout Is Nothing AndAlso fontOfCurrentLayout.Equals(targetFont) Then
                Return targetFont
            Else
                Dim g As Graphics = autosizable.NearestForm.CreateGraphics()
                autosizable.RefreshAutomaticLayout(g)
                g.Dispose()
            End If
            Return targetFont
        End Function


        Public Function ResizeImage(ByVal original As Image, ByVal scale As Single) As Bitmap
            If original Is Nothing Then Throw New ArgumentNullException("original")
            If scale = 0.0! Then Throw New ArgumentOutOfRangeException("scale")

            Dim result As New Bitmap(CInt(original.Width * scale), CInt(original.Height * scale))
            Dim g As Graphics = Graphics.FromImage(result)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.DrawImage(original, 0, 0, result.Width + 1, result.Height + 1)
            Return result
        End Function


        Public Function StringHeightInPixels(ByVal graphics As Graphics, ByVal font As Font, ByVal message As String) As Integer
            If graphics Is Nothing Then Throw New ArgumentNullException("graphics")
            If font Is Nothing Then Throw New ArgumentNullException("font")

            Dim descent As Integer = CInt(font.FontFamily.GetCellDescent(font.Style) / graphics.DpiY)
            Return graphics.MeasureString(message, font).ToSize.Height + descent
        End Function


        Public Function StringWidthInPixels(ByVal graphics As Graphics, ByVal font As System.Drawing.Font, ByVal message As String) As Integer

            If font Is Nothing Then Throw New ArgumentNullException("font")
            Dim width As Integer
            If graphics Is Nothing Then
                width = 0
            Else
                width = graphics.MeasureString(message, font).ToSize.Width
            End If
            Return width
        End Function

        Public Function StringWidthInPixels(ByVal graphics As Graphics, ByVal control As Control) As Integer
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Return StringWidthInPixels(graphics, control.Font, control.Text)
        End Function

        Public Function UpperLeft(ByVal control As Control, ByVal verticalOffset As Integer) As Point
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim x As Integer = control.Location.X
            Dim y As Integer = control.Location.Y + verticalOffset
            Return New Point(x, y)
        End Function

        Public Function UpperLeft(ByVal control As Control) As Point
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim x As Integer = control.Location.X
            Dim y As Integer = control.Location.Y
            Return New Point(x, y)
        End Function

        Public Function UpperRight(ByVal control As Control) As Point
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim x As Integer = control.Location.X + control.Width
            Dim y As Integer = control.Location.Y
            Return New Point(x, y)
        End Function

        Public Function UpperRight(ByVal control As Control, ByVal horizontalOffset As Integer) As Point
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Dim x As Integer = control.Location.X + control.Width + horizontalOffset
            Dim y As Integer = control.Location.Y
            Return New Point(x, y)
        End Function

        Public Function VerticalDockPadding(ByVal control As ScrollableControl) As Integer
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Return control.DockPadding.Top + control.DockPadding.Bottom
        End Function

        Public Function VerticalPadding(ByVal form As Form) As Integer
            If form Is Nothing Then Throw New ArgumentNullException("form")
            Return form.Height - form.ClientSize.Height
        End Function

        Public Sub ForbidInvokeRequired(ByVal control As Control)
            If control Is Nothing Then Throw New ArgumentNullException("control")
            Debug.Assert(Not control.InvokeRequired)
        End Sub

        Private Sub GetParents(ByVal control As Control, ByVal controls As List(Of Control))
            If control Is Nothing Then
                Return
            Else
                controls.Add(control)
                GetParents(control.Parent, controls)
            End If

        End Sub


        Public Sub PrettyPrintException(ByVal culture As CultureInfo, ByVal ex As Exception)
            If ex Is Nothing Then Throw New ArgumentNullException("ex")
            Dim writer As New IO.StringWriter(culture)
            With writer
                .Write(UnwindAllMessages(ex))
            End With
            MessageBox.Show(writer.ToString(), Messages.ApplicationError(culture), MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            writer.Dispose()
        End Sub

        Public Sub RecursiveResumeLayout(ByVal start As Control)
            If start Is Nothing Then Throw New ArgumentNullException("start")
            If start.Controls.Count = 0 Then
                start.ResumeLayout()
                Return
            End If
            For i As Integer = 0 To start.Controls.Count - 1
                RecursiveResumeLayout(start.Controls(i))
            Next
        End Sub

        Public Sub RecursiveSuspendLayout(ByVal start As Control)
            If start Is Nothing Then Throw New ArgumentNullException("start")
            If start.Controls.Count = 0 Then
                start.SuspendLayout()
                Return
            End If
            For i As Integer = 0 To start.Controls.Count - 1
                RecursiveSuspendLayout(start.Controls(i))
            Next
        End Sub

        Public Sub RefreshTooltip(ByVal graphics As Graphics, ByVal grid As SF.Grid.GridControl, ByVal row As Integer, ByVal col As Integer)
            If graphics Is Nothing Then Throw New ArgumentNullException("graphics")
            If grid Is Nothing Then Throw New ArgumentNullException("grid")

            If grid.ColCount = 0 Or grid.RowCount = 0 Then Return

            Static UndocumentedHorizontalGridCellPadding As Integer = 3 ' FIXME: Move to namespace

            Dim style As SF.Grid.GridStyleInfo = grid(row, col)
            If grid.ColWidths(col) < graphics.MeasureString(style.Text, style.GdipFont).Width + UndocumentedHorizontalGridCellPadding Then
                grid(row, col).CellTipText = style.Text
            Else
                grid(row, col).CellTipText = String.Empty
            End If

        End Sub

        Public Sub SetPreferredAndMinimumSize(ByVal bag As SF.Tools.GridBagLayout, ByVal control As Control, ByVal size As Size)

            If bag Is Nothing Then Throw New ArgumentNullException("bag")
            If control Is Nothing Then Throw New ArgumentNullException("control")

            bag.SetPreferredSize(control, size)
            bag.SetMinimumSize(control, size)
        End Sub


        Public Sub SetPreferredSizeToStringSize( _
            ByVal bag As SF.Tools.GridBagLayout, _
            ByVal graphics As Graphics, _
            ByVal control As Control, _
            ByVal widthMultiplier As Single, ByVal heightMultiplier As Single)

            If bag Is Nothing Then Throw New ArgumentNullException("bag")
            If control Is Nothing Then Throw New ArgumentNullException("control")

            Dim pSize As New Size
            pSize.Width = CInt(widthMultiplier * UI.StringWidthInPixels(graphics, control.Font, control.Text))
            pSize.Height = CInt(heightMultiplier * UI.StringHeightInPixels(graphics, control.Font, control.Text))
            bag.SetPreferredSize(control, pSize)
            bag.SetMinimumSize(control, pSize)

        End Sub

        Public Sub WaitWithDoEvents(ByVal milliseconds As Integer, ByVal doEventsFrequency As Integer)
            Static doingEvents As Boolean
            Static doEventsLock As New Object

            Dim start As Long = MillisecondsNow()
            Dim elapsed As Double

            Try
                While elapsed <= milliseconds
                    If Monitor.TryEnter(doEventsLock) Then
                        doingEvents = True
                        Application.DoEvents()
                        doingEvents = False
                        Monitor.Exit(doEventsLock)
                    End If
                    Thread.Sleep(doEventsFrequency)
                    elapsed = MillisecondsNow() - start
                End While
            Finally
                doingEvents = False
            End Try

        End Sub

        Public Sub Watermark(ByVal pictureToFade As Bitmap, ByVal factor As Integer)

            If pictureToFade Is Nothing Then Throw New ArgumentNullException("pictureToFade")
            If factor = 0 Then Throw New ArgumentOutOfRangeException("factor")

            Dim clr As Color
            For py As Integer = 0 To pictureToFade.Height - 1
                For px As Integer = 0 To pictureToFade.Width - 1
                    clr = pictureToFade.GetPixel(px, py)
                    pictureToFade.SetPixel(px, py, Color.FromArgb(CInt(clr.A / factor), clr.R, clr.G, clr.B))
                Next px
            Next py
        End Sub
        Public Function MillisecondsNow() As Long
            Return CType(DateTime.Now.Ticks * 1.0 / TimeSpan.TicksPerMillisecond, Long)
        End Function
    End Module

End Namespace
 
