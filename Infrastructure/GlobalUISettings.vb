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
Imports System.IO

Namespace Mbark.UI.GlobalUISettings

    Namespace Defaults

        Public NotInheritable Class Fonts

            Private Sub New()

            End Sub

            ' Runtime adjustable properties
            Private Shared smFontSize As Single = 8
            Private Shared smFontName As String = "Verdana"

            Private Shared smTinyFontMultiplier As Single = 0.5!
            Private Shared smTinyFont As Font

            Private Shared smSmallFontMultiplier As Single = 0.9
            Private Shared smSmallFont As Font
            Private Shared smSmallBoldFont As Font

            Private Shared smRegularFont As Font
            Private Shared smBoldFont As Font

            Private Shared smLargeFontMultiplier As Single = 1.3!
            Private Shared smLargeFont As Font
            Private Shared smLargeBoldFont As Font

            Private Shared smHugeFontMultiplier As Single = 1.5!
            Private Shared smHugeFont As Font
            Private Shared smHugeBoldFont As Font

            Private Shared smTabletSmallMultiplier As Single = 1.8!
            Private Shared smSmallTablet As Font

            Private Shared smTabletFontMultiplier As Single = 2.0!
            Private Shared smTabletRegular As Font
            Private Shared smTabletBold As Font


            Private Shared Sub ClearDynamicFonts()
                smRegularFont = Nothing
                smSmallFont = Nothing
                smSmallBoldFont = Nothing
                smLargeFont = Nothing
                smBoldFont = Nothing
                smLargeBoldFont = Nothing
                smHugeFont = Nothing
                smHugeBoldFont = Nothing
                smTabletRegular = Nothing
                smTabletBold = Nothing
            End Sub

            Public Shared Property Size() As Single
                Get
                    Return smFontSize
                End Get
                Set(ByVal value As Single)
                    smFontSize = value
                    ClearDynamicFonts()
                End Set
            End Property

            Public Shared Property FontName() As String
                Get
                    Return smFontName
                End Get
                Set(ByVal value As String)
                    smFontName = value
                    ClearDynamicFonts()
                End Set
            End Property


            Public Shared ReadOnly Property TinySize() As Single
                Get
                    Return smFontSize * smTinyFontMultiplier
                End Get
            End Property
            Public Shared ReadOnly Property Tiny() As Font
                Get
                    If smTinyFont Is Nothing Then
                        smTinyFont = New Font(smFontName, smFontSize * TinySize, FontStyle.Regular)
                    End If
                    Return smtinyfont
                End Get
            End Property

            Public Shared ReadOnly Property SmallSize() As Single
                Get
                    Return smFontSize * smSmallFontMultiplier
                End Get
            End Property
            Public Shared ReadOnly Property Small() As Font
                Get
                    If smSmallFont Is Nothing Then
                        smSmallFont = New Font(smFontName, smFontSize * smSmallFontMultiplier, FontStyle.Regular)
                    End If
                    Return smSmallFont
                End Get
            End Property
            Public Shared ReadOnly Property SmallBold() As Font
                Get
                    If smSmallBoldFont Is Nothing Then
                        smSmallBoldFont = New Font(smFontName, smFontSize * smSmallFontMultiplier, FontStyle.Bold)
                    End If
                    Return smSmallBoldFont
                End Get
            End Property

            Public Shared ReadOnly Property Bold() As Font
                Get
                    If smBoldFont Is Nothing Then
                        smBoldFont = New Drawing.Font(smFontName, smFontSize, FontStyle.Bold)
                    End If
                    Return smBoldFont
                End Get
            End Property
            Public Shared ReadOnly Property Regular() As System.Drawing.Font
                Get
                    If smRegularFont Is Nothing Then
                        smRegularFont = New Drawing.Font(smFontName, smFontSize, Drawing.FontStyle.Regular)
                    End If
                    Return smRegularFont
                End Get
            End Property

            Public Shared ReadOnly Property Large() As Font
                Get
                    If smLargeFont Is Nothing Then
                        smLargeFont = New Font(smFontName, smFontSize * smLargeFontMultiplier)
                    End If
                    Return smLargeFont
                End Get
            End Property
            Public Shared ReadOnly Property LargeBold() As Font
                Get
                    If smLargeBoldFont Is Nothing Then
                        smLargeBoldFont = New Font(smFontName, CInt(smFontSize * smLargeFontMultiplier), FontStyle.Bold)
                    End If
                    Return smLargeBoldFont
                End Get

            End Property

            Public Shared ReadOnly Property Huge() As Font
                Get
                    If smHugeFont Is Nothing Then
                        smHugeFont = New Font(smFontName, CInt(smFontSize * smHugeFontMultiplier), FontStyle.Regular)
                    End If
                    Return smHugeFont
                End Get
            End Property
            Public Shared ReadOnly Property HugeBold() As Font
                Get
                    If smHugeBoldFont Is Nothing Then
                        smHugeBoldFont = New Font(smFontName, CInt(smFontSize * smHugeFontMultiplier), FontStyle.Bold)
                    End If
                    Return smHugeBoldFont
                End Get
            End Property

            Public Shared ReadOnly Property TabletRegular() As Font
                Get
                    If smTabletRegular Is Nothing Then
                        smTabletRegular = New Font(smFontName, CInt(smFontSize * smTabletFontMultiplier), FontStyle.Regular)
                    End If
                    Return smTabletRegular
                End Get
            End Property
            Public Shared ReadOnly Property TabletBold() As Font
                Get
                    If smTabletBold Is Nothing Then
                        smTabletBold = New Font(smFontName, CInt(smFontSize * smTabletFontMultiplier), FontStyle.Regular)
                    End If
                    Return smTabletBold
                End Get
            End Property
            Public Shared ReadOnly Property SmallTablet() As Font
                Get
                    If smSmallTablet Is Nothing Then
                        smSmallTablet = New Font(smFontName, CInt(smFontSize * smTabletSmallMultiplier), FontStyle.Regular)
                    End If
                    Return smSmallTablet
                End Get
            End Property

            Public Shared ReadOnly Property GroupBox() As System.Drawing.Font
                Get
                    Return Bold
                End Get
            End Property
            Public Shared ReadOnly Property Button() As Font
                Get
                    Return Regular
                End Get
            End Property
            Public Shared ReadOnly Property ButtonBold() As Font
                Get
                    Return Bold
                End Get
            End Property
            Public Shared ReadOnly Property TextBox() As Font
                Get
                    Return Regular
                End Get
            End Property
            Public Shared ReadOnly Property FieldCaption() As Font
                Get
                    Return Small
                End Get
            End Property
            Public Shared ReadOnly Property FieldGroupHeader() As Font
                Get
                    Return Bold
                End Get
            End Property
            Public Shared ReadOnly Property FancyLabel() As Font
                Get
                    Return Bold
                End Get
            End Property
            Public Shared ReadOnly Property InstructionLabel() As Font
                Get
                    Return Small
                End Get
            End Property

            Public Shared ReadOnly Property TabletHeader() As Font
                Get
                    Return SmallTablet
                End Get
            End Property


        End Class ' Fonts

        Public NotInheritable Class Padding

            Private Sub New()

            End Sub


            Private Shared mFancyLabelHorizontal As Integer = 2
            Private Shared mButtonVertical As Integer = 6
            Private Shared mButtonHorizontal As Integer = 24
            Private Shared mTabletButtonVertical As Integer = 12
            Private Shared mTabletButtonHorizontal As Integer = 30
            Private Shared mTextBoxVertical As Integer = 2
            Private Shared mComboBoxAdvVertical As Integer = 2
            Private Shared mCaptionLabelVertical As Integer = 2
            Private Shared mPanelVertical As Integer = 1
            Private Shared mMPanelHorizontal As Integer = 1
            Private Shared mFlowLayoutTop As Integer = 1
            Private Shared mFlowLayoutBottom As Integer = 2
            Private Shared mCheckBoxHorizontal As Integer = 2
            Private Shared mCheckBoxVertical As Integer = 2
            Private Shared mTabletComponent As Integer = 8


            Public Shared Property CheckBoxVertical() As Integer
                Get
                    Return mCheckBoxVertical
                End Get
                Set(ByVal value As Integer)
                    mCheckBoxVertical = value
                End Set
            End Property
            Public Shared Property CheckBoxHorizontal() As Integer
                Get
                    Return mCheckBoxHorizontal
                End Get
                Set(ByVal value As Integer)
                    mCheckBoxHorizontal = value
                End Set
            End Property
            Public Shared Property PanelHorizontal() As Integer
                Get
                    Return mMPanelHorizontal
                End Get
                Set(ByVal value As Integer)
                    mMPanelHorizontal = value
                End Set
            End Property
            Public Shared Property ButtonHorizontal() As Integer
                Get
                    Return mButtonHorizontal
                End Get
                Set(ByVal value As Integer)
                    mButtonHorizontal = value
                End Set
            End Property
            Public Shared Property TabletButtonVertical() As Integer
                Get
                    Return mTabletButtonVertical
                End Get
                Set(ByVal value As Integer)
                    mTabletButtonVertical = value
                End Set
            End Property
            Public Shared Property TabletButtonHorizontal() As Integer
                Get
                    Return mTabletButtonHorizontal
                End Get
                Set(ByVal value As Integer)
                    mTabletButtonHorizontal = value
                End Set
            End Property
            Public Shared Property FlowLayoutBottom() As Integer
                Get
                    Return mFlowLayoutBottom
                End Get
                Set(ByVal value As Integer)
                    mFlowLayoutBottom = value
                End Set
            End Property
            Public Shared Property FlowLayoutTop() As Integer
                Get
                    Return mFlowLayoutTop
                End Get
                Set(ByVal value As Integer)
                    mFlowLayoutTop = value
                End Set
            End Property
            Public Shared Property ButtonVertical() As Integer
                Get
                    Return mButtonVertical
                End Get
                Set(ByVal value As Integer)
                    mButtonVertical = value
                End Set
            End Property
            Public Shared Property CaptionLabelVertical() As Integer
                Get
                    Return mCaptionLabelVertical
                End Get
                Set(ByVal value As Integer)
                    mCaptionLabelVertical = value
                End Set
            End Property
            Public Shared Property ComboBoxAdvVertical() As Integer
                Get
                    Return mComboBoxAdvVertical
                End Get
                Set(ByVal value As Integer)
                    mComboBoxAdvVertical = value
                End Set
            End Property
            Public Shared Property TextBoxVertical() As Integer
                Get
                    Return mTextBoxVertical
                End Get
                Set(ByVal value As Integer)
                    mTextBoxVertical = value
                End Set
            End Property
            Public Shared Property FancyLabelHorizontal() As Integer
                Get
                    Return mFancyLabelHorizontal
                End Get
                Set(ByVal value As Integer)
                    mFancyLabelHorizontal = value
                End Set
            End Property
            Public Shared Property PanelVertical() As Integer
                Get
                    Return mPanelVertical
                End Get
                Set(ByVal value As Integer)
                    mPanelVertical = value
                End Set
            End Property
            Public Shared Property TabletComponent() As Integer
                Get
                    Return mTabletComponent
                End Get
                Set(ByVal value As Integer)
                    mTabletComponent = value
                End Set
            End Property


        End Class ' Padding

        Public NotInheritable Class DataEntryComponentPadding

            Private Sub New()

            End Sub

            Private Shared mTop As Integer = 2
            Private Shared mBottom As Integer = 2
            Private Shared mLeft As Integer = 2
            Private Shared mRight As Integer = 2
            Private Shared mErrorHandlerWidth As Integer = 20

            Public Shared Property Top() As Integer
                Get
                    Return mTop
                End Get
                Set(ByVal value As Integer)
                    mTop = value
                End Set
            End Property
            Public Shared Property Bottom() As Integer
                Get
                    Return mBottom
                End Get
                Set(ByVal value As Integer)
                    mBottom = value
                End Set
            End Property
            Public Shared Property Left() As Integer
                Get
                    Return mLeft
                End Get
                Set(ByVal value As Integer)
                    mLeft = value
                End Set
            End Property
            Public Shared Property Right() As Integer
                Get
                    Return mRight
                End Get
                Set(ByVal value As Integer)
                    mRight = value
                End Set
            End Property
            Public Shared Property ErrorHandlerWidth() As Integer
                Get
                    Return mErrorHandlerWidth
                End Get
                Set(ByVal value As Integer)
                    mErrorHandlerWidth = value
                End Set
            End Property



        End Class ' Data Entry Component

        Public NotInheritable Class Colors

            Public Shared ReadOnly Property TransparentBrush() As Syncfusion.Drawing.BrushInfo
                Get
                    Return mTransparentBrush
                End Get
            End Property

            Public Shared Property FancyLabelBackground() As Syncfusion.Drawing.BrushInfo
                Get
                    Return mFancyLabelBackground
                End Get
                Set(ByVal value As Syncfusion.Drawing.BrushInfo)
                    mFancyLabelBackground = value
                End Set
            End Property

            Private Shared mTransparentBrush As Syncfusion.Drawing.BrushInfo = _
               New Syncfusion.Drawing.BrushInfo(Color.Transparent)
            Private Shared mFancyLabelBackground As Syncfusion.Drawing.BrushInfo = _
                New Syncfusion.Drawing.BrushInfo( _
                    Syncfusion.Drawing.GradientStyle.BackwardDiagonal, _
                    System.Drawing.SystemColors.InactiveCaption, _
                    System.Drawing.SystemColors.ActiveCaption)
            Private Sub New()

            End Sub
        End Class ' Colors

    End Namespace ' Defaults

    Public NotInheritable Class ControlSizes
        Public Shared Property CheckBox() As Size
            Get
                Return mCheckBoxSize
            End Get
            Set(ByVal value As Size)
                mCheckBoxSize = value
            End Set
        End Property
        Private Shared mCheckBoxSize As New Size(13, 13)

        Public Shared Property ScrollBar() As Integer
            Get
                Return mScrollBar
            End Get
            Set(ByVal value As Integer)
                mScrollBar = value
            End Set
        End Property
        Private Shared mScrollBar As Integer = 18

        Private Shared mRadioButtonSize As New Size(13, 13)
        Public Shared Property RadioButtonSize() As Size
            Get
                Return mRadioButtonSize
            End Get
            Set(ByVal value As Size)
                mRadioButtonSize = value
            End Set
        End Property

        Private Sub New()
        End Sub

    End Class ' ControlSizes


    Public NotInheritable Class UndocumentedPaddingConstants

        Private Sub New()
            ' Forbid construction
        End Sub

        Private Shared smPreventFlowLayoutWrap As Integer = 16
        Public Shared ReadOnly Property PreventFlowLayoutWrap() As Integer
            Get
                Return smPreventFlowLayoutWrap
            End Get
        End Property

        Private Shared mPreventLabelWordWrap As Integer = 28
        Public Shared ReadOnly Property PreventLabelWordWrap() As Integer
            Get
                Return mPreventLabelWordWrap
            End Get
        End Property

        Private Shared mPreventCheckBoxWordWrap As Integer = 26
        Public Shared ReadOnly Property PreventCheckBoxWordWrap() As Integer
            Get
                Return mPreventCheckBoxWordWrap
            End Get
        End Property

        Private Shared smComboBoxButtonWidth As Integer = 32
        Public Shared ReadOnly Property ComboBoxButtonWidth() As Integer
            Get
                Return smComboBoxButtonWidth
            End Get
        End Property

        Private Shared smComboBoxAdvButtonWidth As Integer = 18
        Public Shared ReadOnly Property ComboBoxAdvButtonWidth() As Integer
            Get
                Return smComboBoxAdvButtonWidth
            End Get
        End Property

        Private Shared smPreventComboBoxTextTruncation As Integer = 8 + ComboBoxAdvButtonWidth
        Public Shared ReadOnly Property PreventComboBoxTextTruncation() As Integer
            Get
                Return smPreventComboBoxTextTruncation
            End Get
        End Property

        Private Shared smBetweenRadioButtonAndText As Integer = 8
        Public Shared ReadOnly Property BetweenRadioButtonAndText() As Integer
            Get
                Return smBetweenRadioButtonAndText
            End Get
        End Property

        Private Shared smCheckboxIndent As Integer = ControlSizes.CheckBox.Width + smBetweenCheckBoxAndText
        Public Shared ReadOnly Property CheckboxIndent() As Integer
            Get
                Return smCheckboxIndent
            End Get
        End Property


        Private Shared smBetweenCheckBoxAndText As Integer = 10
        Public Shared ReadOnly Property BetweenCheckBoxAndText() As Integer
            Get
                Return smBetweenCheckBoxAndText
            End Get
        End Property

        Private Shared smPreventSFGridHorizontalScrolling As Integer = 6
        Public Shared ReadOnly Property PreventSFGridHorizontalScrolling() As Integer
            Get
                Return smPreventSFGridHorizontalScrolling
            End Get
        End Property

        Private Shared smComboBoxVerticalPadding As Integer = 2
        Public Shared ReadOnly Property ComboBoxVerticalPadding() As Integer
            Get
                Return smComboBoxVerticalPadding
            End Get
        End Property

        Private Shared smGroupBoxIndent As Integer = 12
        Public Shared ReadOnly Property GroupBoxIndent() As Integer
            Get
                Return smGroupBoxIndent
            End Get
        End Property


    End Class


    Public NotInheritable Class StringConstants

        Private Sub New()
        End Sub

        Private Shared smWingdingsFontName As String = "Wingdings"
        Public Shared ReadOnly Property WingdingsFontName() As String
            Get
                Return smWingdingsFontName
            End Get
        End Property

        Private Shared smWingdingsCheck As String = ChrW(252)
        Public Shared ReadOnly Property WingdingsCheck() As String
            Get
                Return smWingdingsCheck
            End Get
        End Property

        Private Shared smWingdingsCheckWithBox As String = ChrW(254)
        Public Shared ReadOnly Property WingdingsCheckWithBox() As String
            Get
                Return smWingdingsCheckWithBox
            End Get
        End Property


        Private Shared smWingdingsX As String = ChrW(251)
        Public Shared ReadOnly Property WingdingsX() As String
            Get
                Return smWingdingsX
            End Get
        End Property

        Private Shared smSpace As String = " "
        Public Shared ReadOnly Property Space() As String
            Get
                Return smSpace
            End Get
        End Property

        Private Shared smColonSpace As String = ": "
        Public Shared ReadOnly Property ColonSpace() As String
            Get
                Return smColonSpace
            End Get
        End Property

        Private Shared smCommaSpace As String = ", "
        Public Shared ReadOnly Property CommaSpace() As String
            Get
                Return smCommaSpace
            End Get
        End Property


        Private Shared smComma As String = ","
        Public Shared ReadOnly Property Comma() As String
            Get
                Return smComma
            End Get
        End Property

        Private Shared smEquals As String = "="
        Public Shared ReadOnly Property EqualsSign() As String
            Get
                Return smEquals
            End Get
        End Property

        Private Shared smWingDingsClock As String = ChrW(194)
        Public Shared ReadOnly Property WingdingsClock() As String
            Get
                Return smWingDingsClock
            End Get
        End Property

        Private Shared smWingDingsThumbsDown As String = ChrW(68)
        Public Shared ReadOnly Property WingdingsThumbsDown() As String
            Get
                Return smWingDingsThumbsDown
            End Get
        End Property

        Private Shared smWingdingsRightArrow As String = ChrW(224)
        Public Shared ReadOnly Property WingdingsRightArrow() As String
            Get
                Return smWingdingsRightArrow
            End Get
        End Property


        Private Shared smWingdingsBoldRightArrow As String = ChrW(232)
        Public Shared ReadOnly Property WingdingsBoldRightArrow() As String
            Get
                Return smWingdingsBoldRightArrow
            End Get
        End Property

        Private Shared smWingdings2NoSymbol As String = ChrW(88)
        Public Shared ReadOnly Property Wingdings2NoSymbol() As String
            Get
                Return smWingdings2NoSymbol
            End Get
        End Property

    End Class


End Namespace
