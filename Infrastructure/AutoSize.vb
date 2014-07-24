'
'  Multimodal Biometric Application Resource Kit (MBARK)
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
Imports System.Diagnostics.CodeAnalysis
Imports System.Collections.ObjectModel

Imports SF = Syncfusion.Windows.Forms

Imports Mbark.UI
Imports Mbark.UI.GlobalUISettings

Imports Mbark.InfrastructureMessages


Namespace Mbark.UI

    Public NotInheritable Class AutoSize

        Public Shared Sub Buttons(ByVal graphics As Graphics, ByVal buttonsToResize As Collection(Of Button))
            If buttonsToResize Is Nothing Then Throw New ArgumentNullException("buttonsToResize")

            Dim maxWidth As Integer = Integer.MinValue
            For i As Integer = 0 To buttonsToResize.Count - 1
                Dim width As Integer = UI.StringWidthInPixels(graphics, buttonsToResize(i).Font, buttonsToResize(i).Text)
                maxWidth = Math.Max(width, maxWidth)
            Next

            For i As Integer = 0 To buttonsToResize.Count - 1
                AutoHeight.Button(graphics, buttonsToResize(i))
                buttonsToResize(i).Width = maxWidth + Defaults.Padding.ButtonHorizontal
            Next

        End Sub

        Private Const LabelWidthMultiplier As Single = 1.0!
        Private Const LabelHeightMultiplier As Single = 1.0!

        Public Shared Sub Label(ByVal graphics As Graphics, ByVal control As Control)
            ToText(graphics, control, LabelWidthMultiplier, LabelHeightMultiplier)
        End Sub

        Public Shared Sub Label(ByVal graphics As Graphics, ByVal control As Control, ByVal font As Font, ByVal message As String)
            ToText(graphics, control, font, message, LabelWidthMultiplier, LabelHeightMultiplier)
        End Sub

        Public Shared Sub ToText( _
            ByVal graphics As Graphics, ByVal targetControl As Control, _
            ByVal font As Font, ByVal message As String, _
            ByVal widthMultiplier As Single, ByVal heightMultiplier As Single)

            If targetControl Is Nothing Then Throw New ArgumentNullException("targetControl")
            Dim sz As New Size
            sz.Width = CInt(widthMultiplier * UI.StringWidthInPixels(graphics, font, message)) + UndocumentedPaddingConstants.PreventLabelWordWrap
            sz.Height = CInt(heightMultiplier * UI.StringHeightInPixels(graphics, font, message))
            targetControl.Size = sz
            targetControl.Refresh()
        End Sub


        Public Shared Sub ToText( _
            ByVal graphics As Graphics, ByVal control As Control, _
            ByVal widthMultiplier As Single, ByVal heightMultiplier As Single)
            ToText(graphics, control, control.Font, control.Text, widthMultiplier, heightMultiplier)
        End Sub

        Public Shared Sub ComboBox(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal box As ComboBox)
            If box Is Nothing Then Throw New ArgumentNullException("box")
            Dim maxItemWidth As Integer = 0
            For i As Integer = 0 To box.Items.Count - 1
                maxItemWidth = Math.Max(maxItemWidth, UI.StringWidthInPixels(graphics, box.Font, box.Items(i).ToString))
            Next
            box.Width = maxItemWidth + UndocumentedPaddingConstants.ComboBoxButtonWidth
            box.Height = AutoHeight.FontHeightInPixels(culture, graphics, box.Font)

        End Sub


        <CLSCompliant(False)> Public Shared Sub ComboBoxAdv(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal box As SF.Tools.ComboBoxAdv)
            If box Is Nothing Then Throw New ArgumentNullException("box")
            Dim maxItemWidth As Integer = 0
            For i As Integer = 0 To box.Items.Count - 1
                maxItemWidth = Math.Max(maxItemWidth, UI.StringWidthInPixels(graphics, box.Font, box.Items(i).ToString))
            Next
            box.Width = maxItemWidth + UndocumentedPaddingConstants.PreventComboBoxTextTruncation
            box.Height = AutoHeight.FontHeightInPixels(culture, graphics, box.Font) + Defaults.Padding.TextBoxVertical

        End Sub

        <SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification:="Method performs type-specific operation")> _
        Public Shared Sub RadioButton(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal radio As RadioButton)
            If radio Is Nothing Then Throw New ArgumentNullException("radio")
            radio.Height = Math.Max(ControlSizes.RadioButtonSize.Height, AutoHeight.FontHeightInPixels(culture, graphics, radio.Font))
            radio.Width = _
                ControlSizes.RadioButtonSize.Width + _
                UndocumentedPaddingConstants.BetweenRadioButtonAndText + _
                StringWidthInPixels(graphics, radio.Font, radio.Text)

        End Sub

        <SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification:="Method performs type-specific operation")> _
        Public Shared Sub CheckBox(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal box As CheckBox)
            If box Is Nothing Then Throw New ArgumentNullException("box")
            box.Height = Math.Max(ControlSizes.CheckBox.Height, AutoHeight.FontHeightInPixels(culture, graphics, box.Font))
            box.Width = _
                ControlSizes.CheckBox.Width + _
                UndocumentedPaddingConstants.BetweenCheckBoxAndText + _
                UndocumentedPaddingConstants.PreventCheckBoxWordWrap + _
                StringWidthInPixels(graphics, box.Font, box.Text)
        End Sub




        Private Sub New()
        End Sub

    End Class


    Public NotInheritable Class AutoHeight

        Public Shared ReadOnly Property AutoHeightString(ByVal culture As CultureInfo) As String
            Get
                Return Messages.AutoHeightString(culture)
            End Get
        End Property


        Public Shared Function FontHeightInPixels(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal font As Font) As Integer
            Return StringHeightInPixels(graphics, font, AutoHeightString(culture))
        End Function

        Public Shared Function MaxPointSizeForHeight(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal font As Font, ByVal height As Single) As Single
            If font Is Nothing Then Throw New ArgumentNullException("font")
            Dim p1 As Single = 10.0!
            Dim p2 As Single = 100.0!

            Dim p1Font As New Font(font.FontFamily, p1)
            Dim p2Font As New Font(font.FontFamily, p2)

            Dim s1 As Single = CType(FontHeightInPixels(culture, graphics, p1Font), Single)
            Dim s2 As Single = CType(FontHeightInPixels(culture, graphics, p2Font), Single)

            p1Font.Dispose()
            p2Font.Dispose()

            Dim m As Single = (s2 - s1) / (p2 - p1)
            Dim s As Single = (height - s1) / m + p1

            Return s

        End Function


        Public Shared Sub ToText( _
               ByVal graphics As Graphics, ByVal control As Control, ByVal heightMultiplier As Single)
            If control Is Nothing Then Throw New ArgumentNullException("control")

            Dim pSize As New Size
            pSize.Width = control.Width
            pSize.Height = CInt(heightMultiplier * UI.StringHeightInPixels(graphics, control.Font, control.Text))
            control.Size = pSize

        End Sub


        Public Shared Sub Control(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, AutoHeightString(culture))
        End Sub

        Public Shared Sub Button(ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, target.Text) + Defaults.Padding.ButtonVertical
        End Sub

        Public Shared Sub TabletButton(ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, target.Text) + Defaults.Padding.TabletButtonVertical
        End Sub

        Public Shared Sub Label(ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, target.Text)
        End Sub

        Public Shared Sub RadioButton(ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, target.Text)
        End Sub

        Public Shared Sub CheckBox(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, AutoHeightString(culture)) + _
                Defaults.Padding.CheckBoxVertical
        End Sub

        Public Shared Sub MaskedEditBox(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, AutoHeightString(culture)) + _
                Defaults.Padding.TextBoxVertical
        End Sub

        Public Shared Sub TextBox(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, AutoHeightString(culture)) + Defaults.Padding.TextBoxVertical
        End Sub

        Public Shared Sub ComboBoxAdv(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Height = StringHeightInPixels(graphics, target.Font, AutoHeightString(culture)) + _
                Defaults.Padding.TextBoxVertical
        End Sub




        Public Shared Sub FancyLabel(ByVal graphics As Graphics, ByVal target As Control)
            Label(graphics, target)
        End Sub

        Private Sub New()
        End Sub

    End Class

    Public NotInheritable Class AutoWidth



        Public Shared ReadOnly Property AutoWidthUpperChar(ByVal culture As CultureInfo) As Char
            Get
                Return CChar(Messages.AutoWidthUpperChar(culture))
            End Get
        End Property

        Public Shared ReadOnly Property AutoWidthLowerChar(ByVal culture As CultureInfo) As Char
            Get
                Return CChar(Messages.AutoWidthLowerChar(culture))
            End Get
        End Property

        Public Shared Function CharWidthInPixels(ByVal culture As CultureInfo, ByVal graphics As Graphics, ByVal font As Font) As Integer
            Dim uw As Integer = StringWidthInPixels(graphics, font, AutoWidth.AutoWidthUpperChar(culture))
            Dim lw As Integer = StringWidthInPixels(graphics, font, AutoWidth.AutoWidthLowerChar(culture))
            Return CInt((uw + lw) / 2.0!)
        End Function

        Private Sub New()
        End Sub
    End Class


End Namespace
