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

Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports SF = Syncfusion.Windows.Forms.Tools

Imports Mbark.UI
Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Class FingerpickerControl
        Inherits BasePickerControl


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
        Friend WithEvents PalmToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents MiddleToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents LittleToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents IndexToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents RingToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents WholeHandToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents ThumbToolTip As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.PalmToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.MiddleToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.LittleToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.IndexToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.RingToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.ThumbToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.WholeHandToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.SuspendLayout()
            '
            'FingerpickerControl
            '
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.CausesValidation = False
            Me.Name = "FingerpickerControl"
            Me.Size = New System.Drawing.Size(231, 285)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public WithEvents IndexCheckBox As New XBox
        Public WithEvents MiddleCheckBox As New XBox
        Public WithEvents RingCheckBox As New XBox
        Public WithEvents LittleCheckBox As New XBox
        Public WithEvents ThumbCheckBox As New XBox
        Public WithEvents PalmCheckBox As New XBox
        Public WithEvents WholeHandCheckBox As New XBox

        Private mAllXBoxes As XBox() = {ThumbCheckBox, IndexCheckBox, MiddleCheckBox, RingCheckBox, LittleCheckBox, PalmCheckBox, WholeHandCheckBox}
        Private mSingleXBoxes As XBox() = {IndexCheckBox, MiddleCheckBox, RingCheckBox, LittleCheckBox, ThumbCheckBox, PalmCheckBox}

        Private mAllToolTips As ToolTip()

        Private mThumbState As CheckState
        Private mIndexState As CheckState
        Private mMiddleState As CheckState
        Private mRingState As CheckState
        Private mLittleState As CheckState
        Private mPalmState As CheckState
        Private mWholeHandState As CheckState

        Private mDisableThumb As Boolean
        Private mDisableIndex As Boolean
        Private mDisableMiddle As Boolean
        Private mDisableRing As Boolean
        Private mDisableLittle As Boolean
        Private mDisablePalm As Boolean


        Private Sub UserNew()

            ' This gets set before Load(), which initializes the image
            PopulatePartImages(New Bitmap(Me.GetType(), "hand.png"), New Bitmap(Me.GetType(), "hand-disabled.png"))

            ThumbCheckBox.Name = "ThumbCheckBox"
            IndexCheckBox.Name = "IndexCheckBox"
            MiddleCheckBox.Name = "MiddleCheckBox"
            RingCheckBox.Name = "RingCheckBox"
            LittleCheckBox.Name = "LittleCheckBox"
            PalmCheckBox.Name = "PalmCheckBox"
            WholeHandCheckBox.Name = "WholeHandCheckBox"

            For i As Integer = 0 To mAllXBoxes.Length - 1
                Controls.Add(mAllXBoxes(i))
            Next

        End Sub

        Private mIsLeft As Boolean = True
        Public Property IsLeft() As Boolean
            Get
                Return mIsLeft
            End Get
            Set(ByVal value As Boolean)
                mIsLeft = value
                UpdateTabIndexes()
            End Set
        End Property

        Private Sub UpdateTabIndexes()
            If Me.IsLeft Then
                WholeHandCheckBox.TabIndex = 0
                PalmCheckBox.TabIndex = 1
                LittleCheckBox.TabIndex = 2
                RingCheckBox.TabIndex = 3
                MiddleCheckBox.TabIndex = 4
                IndexCheckBox.TabIndex = 5
                ThumbCheckBox.TabIndex = 6
            Else
                WholeHandCheckBox.TabIndex = 6 - 0
                PalmCheckBox.TabIndex = 6 - 1
                LittleCheckBox.TabIndex = 6 - 2
                RingCheckBox.TabIndex = 6 - 3
                MiddleCheckBox.TabIndex = 6 - 4
                IndexCheckBox.TabIndex = 6 - 5
                ThumbCheckBox.TabIndex = 6 - 6
            End If

        End Sub


        Private mBindingFromWireToControl As Boolean
        Private Sub BindFromPartToControl(ByVal part As BodyPart, ByVal checkbox As CheckBox)
            If BodyPartsWire.Contains(part) Then CheckBox.CheckState = CheckState.Checked Else CheckBox.CheckState = CheckState.Unchecked
        End Sub


        Private ReadOnly Property AllSingleXBoxesWereManuallyChecked() As Boolean
            Get
                ' We can't loop through an array of these, since these are value types.
                Return _
                mIndexState = CheckState.Checked AndAlso _
                mMiddleState = CheckState.Checked AndAlso _
                mRingState = CheckState.Checked AndAlso _
                mLittleState = CheckState.Checked AndAlso _
                mThumbState = CheckState.Checked AndAlso _
                mPalmState = CheckState.Checked
            End Get
        End Property

        Protected Friend Overrides Sub BindFromWireToControl()

            If BodyPartsWire Is Nothing Then Return

            mBindingFromWireToControl = True

            With BodyPartsWire

                If IsLeft Then
                    BindFromPartToControl(BodyPart.LeftThumb, ThumbCheckBox)
                    BindFromPartToControl(BodyPart.LeftIndex, IndexCheckBox)
                    BindFromPartToControl(BodyPart.LeftMiddle, MiddleCheckBox)
                    BindFromPartToControl(BodyPart.LeftRing, RingCheckBox)
                    BindFromPartToControl(BodyPart.LeftLittle, LittleCheckBox)
                    BindFromPartToControl(BodyPart.LeftPalm, PalmCheckBox)
                Else
                    BindFromPartToControl(BodyPart.RightThumb, ThumbCheckBox)
                    BindFromPartToControl(BodyPart.RightIndex, IndexCheckBox)
                    BindFromPartToControl(BodyPart.RightMiddle, MiddleCheckBox)
                    BindFromPartToControl(BodyPart.RightRing, RingCheckBox)
                    BindFromPartToControl(BodyPart.RightLittle, LittleCheckBox)
                    BindFromPartToControl(BodyPart.RightPalm, PalmCheckBox)
                End If

            End With

            mThumbState = ThumbCheckBox.CheckState
            mIndexState = IndexCheckBox.CheckState
            mMiddleState = MiddleCheckBox.CheckState
            mRingState = RingCheckBox.CheckState
            mLittleState = LittleCheckBox.CheckState
            mPalmState = PalmCheckBox.CheckState


            RefreshCheckBoxes()
            mBindingFromWireToControl = False


        End Sub


        Private Sub AddOrRemoveBodyPart(ByVal checkBox As CheckBox, ByVal part As BodyPart)
            If checkBox.CheckState = CheckState.Checked Then
                BodyPartsWire.Add(part)
            Else
                BodyPartsWire.Remove(part)
            End If
        End Sub

        Private Sub BindFromControlToWire()

            If BodyPartsWire Is Nothing Then Return

            With BodyPartsWire
                If IsLeft Then
                    AddOrRemoveBodyPart(ThumbCheckBox, BodyPart.LeftThumb)
                    AddOrRemoveBodyPart(IndexCheckBox, BodyPart.LeftIndex)
                    AddOrRemoveBodyPart(MiddleCheckBox, BodyPart.LeftMiddle)
                    AddOrRemoveBodyPart(RingCheckBox, BodyPart.LeftRing)
                    AddOrRemoveBodyPart(LittleCheckBox, BodyPart.LeftLittle)
                    AddOrRemoveBodyPart(PalmCheckBox, BodyPart.LeftPalm)
                Else
                    AddOrRemoveBodyPart(ThumbCheckBox, BodyPart.RightThumb)
                    AddOrRemoveBodyPart(IndexCheckBox, BodyPart.RightIndex)
                    AddOrRemoveBodyPart(MiddleCheckBox, BodyPart.RightMiddle)
                    AddOrRemoveBodyPart(RingCheckBox, BodyPart.RightRing)
                    AddOrRemoveBodyPart(LittleCheckBox, BodyPart.RightLittle)
                    AddOrRemoveBodyPart(PalmCheckBox, BodyPart.RightPalm)
                End If
            End With


        End Sub

        Private Sub PopulateTabStops()

            ' Disable all TabStops by default
            For i As Integer = 0 To Controls.Count - 1
                Controls(i).TabStop = False
            Next

            ' Checkboxes are tabstops
            For i As Integer = 0 To mAllXBoxes.Length - 1
                mAllXBoxes(i).TabStop = True
            Next

            If IsLeft Then
                WholeHandCheckBox.TabIndex = 0
                PalmCheckBox.TabIndex = 1
                LittleCheckBox.TabIndex = 2
                RingCheckBox.TabIndex = 3
                MiddleCheckBox.TabIndex = 4
                IndexCheckBox.TabIndex = 5
                ThumbCheckBox.TabIndex = 6
            Else
                WholeHandCheckBox.TabIndex = 6
                PalmCheckBox.TabIndex = 5
                LittleCheckBox.TabIndex = 4
                RingCheckBox.TabIndex = 3
                MiddleCheckBox.TabIndex = 2
                IndexCheckBox.TabIndex = 1
                ThumbCheckBox.TabIndex = 0
            End If
        End Sub
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return


            mAllToolTips = New ToolTip() {IndexToolTip, MiddleToolTip, RingToolTip, LittleToolTip, ThumbToolTip, PalmToolTip, WholeHandToolTip}

            ' Set all of the boxes to a common global size.
            For i As Integer = 0 To mAllXBoxes.Length - 1
                mAllXBoxes(i).Size = GlobalUISettings.ControlSizes.CheckBox
            Next

            ' Always show all of the tooltips
            For i As Integer = 0 To mAllToolTips.Length - 1
                mAllToolTips(i).UseAnimation = True
                mAllToolTips(i).UseFading = False
            Next

            OnLayout(New LayoutEventArgs(Me, String.Empty))

            PopulateTabStops()

            RefreshCheckBoxes()
        End Sub

        Private Shared LittleTip As New Point(136 - 4, 57 - 10)
        Private Shared RingTip As New Point(190 - 4, 33 - 10)
        Private Shared MiddleTip As New Point(242 - 4, 12 - 10)
        Private Shared IndexTip As New Point(290 - 4, 38 - 10)
        Private Shared ThumbTip As New Point(282, 168 - 10)
        Private Shared PalmCenter As New Point(150 - 4, 190 - 10)
        Private Shared WholeHandLocation As New Point(80 - 4, 285 - 10)

        Private Shared SmallestXDelta As Integer = IndexTip.X - MiddleTip.X

        Private Sub PlaceCheckBox(ByVal checkBox As CheckBox, ByVal loc As Point)

            Dim newPoint As Point = MainPictureBox.RemapImagePoint(loc)

            checkBox.Size = GlobalUISettings.ControlSizes.CheckBox

            newPoint.Y += DockPadding.Top - checkBox.Height
            newPoint.X -= CInt(checkBox.Width / 2.0!)
            newPoint.X += DockPadding.Left

            ' Nudge the x-coordinate past the left side
            newPoint.X = Math.Max(DockPadding.Left + 1, newPoint.X)

            ' Nudge the x-coordinate in from the right side
            newPoint.X = Math.Min(newPoint.X, Width - DockPadding.Right - checkBox.Width)


            checkBox.Location = newPoint
            checkBox.BringToFront()

        End Sub

        Protected Overrides Sub LayoutCheckBoxes()

            ' See if we need to add a little padding at the top
            Dim newMiddle As Point = MainPictureBox.RemapImagePoint(MiddleTip)
            If newMiddle.Y < IndexCheckBox.Height Then
                DockPadding.Top = IndexCheckBox.Height - newMiddle.Y
            Else
                DockPadding.Top = 0
            End If

            Dim newIndex As Point = MainPictureBox.RemapImagePoint(IndexTip)
            DockPadding.Left = 0
            DockPadding.Right = 0

            PlaceCheckBox(ThumbCheckBox, ThumbTip)
            PlaceCheckBox(IndexCheckBox, IndexTip)
            PlaceCheckBox(MiddleCheckBox, MiddleTip)
            PlaceCheckBox(RingCheckBox, RingTip)
            PlaceCheckBox(LittleCheckBox, LittleTip)
            PlaceCheckBox(PalmCheckBox, PalmCenter)
            PlaceCheckBox(WholeHandCheckBox, WholeHandLocation)


        End Sub

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)

            If IsLeft Then
                FooterLabel.Text = Messages.LeftHand(UICulture)
                MainPictureBox.Backwards = False
            Else
                FooterLabel.Text = Messages.RightHand(UICulture)
                MainPictureBox.Backwards = True
            End If
            MainPictureBox.Refresh()
            LayoutCheckBoxes()

        End Sub

        Protected Overrides Function ComputeMinimumWidth() As Integer
            Dim baseMinimumWidth As Integer = MyBase.ComputeMinimumWidth
            Dim minimumScale As Single = UI.GlobalUISettings.ControlSizes.CheckBox.Width * 1.0! / SmallestXDelta
            Dim checkboxPreservativeMinimumWidth As Integer = mAllXBoxes.Length * UI.GlobalUISettings.ControlSizes.CheckBox.Width

            Return Math.Max(baseMinimumWidth, checkboxPreservativeMinimumWidth)
        End Function



#Region "CheckChanged Event Handlers"
        Private Sub ThumbCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThumbCheckBox.CheckedChanged
            HandleCheckChanged(mThumbState, ThumbCheckBox)
        End Sub

        Private Sub IndexCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles IndexCheckBox.CheckedChanged
            HandleCheckChanged(mIndexState, IndexCheckBox)
        End Sub

        Private Sub MiddleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MiddleCheckBox.CheckedChanged
            HandleCheckChanged(mMiddleState, MiddleCheckBox)
        End Sub

        Private Sub RingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RingCheckBox.CheckedChanged
            HandleCheckChanged(mRingState, RingCheckBox)
        End Sub

        Private Sub LittleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LittleCheckBox.CheckedChanged
            HandleCheckChanged(mLittleState, LittleCheckBox)
        End Sub

        Private Sub PalmCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PalmCheckBox.CheckedChanged
            HandleCheckChanged(mPalmState, PalmCheckBox)
        End Sub

        Private mHandlingWholeHandCheckBox As Boolean
        Private Sub WholeHandCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WholeHandCheckBox.CheckedChanged

            mWholeHandState = WholeHandCheckBox.CheckState
            mHandlingWholeHandCheckBox = True
            RefreshCheckBoxes()
            mHandlingWholeHandCheckBox = False
            BindFromControlToWire()

        End Sub

        Private Sub HandleCheckChanged(ByRef saveCheckBoxStateHere As CheckState, ByVal checkbox As CheckBox)
            If mBindingFromWireToControl Then Return
            If Not mHandlingWholeHandCheckBox Then saveCheckBoxStateHere = checkbox.CheckState
            RefreshCheckBoxes()
            BindFromControlToWire()
        End Sub

#End Region


#Region "ToolTip Bug Workarounds"

        Private Sub WorkaroundThumbCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles ThumbCheckBox.MouseEnter

            ThumbToolTip.RemoveAll()
            If IsLeft Then
                ThumbToolTip.SetToolTip(ThumbCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.LeftThumb))
            Else
                ThumbToolTip.SetToolTip(ThumbCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.RightThumb))
            End If
        End Sub

        Private Sub WorkaroundIndexCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles IndexCheckBox.MouseEnter

            IndexToolTip.RemoveAll()
            If IsLeft Then
                IndexToolTip.SetToolTip(IndexCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.LeftIndex))
            Else
                IndexToolTip.SetToolTip(IndexCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.RightIndex))
            End If
        End Sub

        Private Sub WorkaroundMiddleCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles MiddleCheckBox.MouseEnter

            MiddleToolTip.RemoveAll()
            If IsLeft Then
                MiddleToolTip.SetToolTip(MiddleCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.LeftMiddle))
            Else
                MiddleToolTip.SetToolTip(MiddleCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.RightMiddle))
            End If
        End Sub

        Private Sub WorkaroundRingCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles RingCheckBox.MouseEnter
            RingToolTip.RemoveAll()
            If IsLeft Then
                RingToolTip.SetToolTip(RingCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.LeftRing))
            Else
                RingToolTip.SetToolTip(RingCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.RightRing))
            End If
        End Sub

        Private Sub WorkaroundLittleCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles LittleCheckBox.MouseEnter
            LittleToolTip.RemoveAll()
            If IsLeft Then
                LittleToolTip.SetToolTip(LittleCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.LeftLittle))
            Else
                LittleToolTip.SetToolTip(LittleCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.RightLittle))
            End If
        End Sub

        Private Sub WorkaroundPalmCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles PalmCheckBox.MouseEnter
            PalmToolTip.RemoveAll()
            If IsLeft Then
                PalmToolTip.SetToolTip(PalmCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.LeftPalm))
            Else
                PalmToolTip.SetToolTip(PalmCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.RightPalm))
            End If
        End Sub

        Private Sub WorkaroundWholeHandCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles WholeHandCheckBox.MouseEnter
            WholeHandToolTip.RemoveAll()
            If IsLeft Then
                WholeHandToolTip.SetToolTip(WholeHandCheckBox, Messages.LeftHand)
            Else
                WholeHandToolTip.SetToolTip(WholeHandCheckBox, Messages.RightHand)
            End If

        End Sub

#End Region



        Private mInsideRefreshCheckBoxes As Boolean
        Protected Overrides Sub RefreshCheckBoxes()

            If mInsideRefreshCheckBoxes Then Return
            mInsideRefreshCheckBoxes = True

            If mHandlingWholeHandCheckBox Then
                ' 
                ' Respond to a change in the palm check box
                ' 
                If mWholeHandState = CheckState.Checked Then

                    ' ---
                    ' WholeHand Unchecked -> WholeHand Checked
                    ' ---

                    ' Using .BeginUpdate caches the updates so they don't all happen at once
                    BodyPartsWire.BeginUpdate()
                    For i As Integer = 0 To mSingleXBoxes.Length - 1
                        mSingleXBoxes(i).CheckState = CheckState.Checked
                        mSingleXBoxes(i).Enabled = False
                    Next
                    BodyPartsWire.EndUpdate()

                    WholeHandCheckBox.Enabled = MyBase.Enabled

                Else

                    ' ---
                    ' WholeHand Checked -> WholeHand Unchecked
                    ' ---

                    ' When unchecking the whole hand, we set each checkbox to the
                    ' state it was in before the whole hand was checked.
                    '
                    If Not BodyPartsWire Is Nothing Then BodyPartsWire.BeginUpdate()
                    ThumbCheckBox.CheckState = mThumbState
                    IndexCheckBox.CheckState = mIndexState
                    MiddleCheckBox.CheckState = mMiddleState
                    RingCheckBox.CheckState = mRingState
                    LittleCheckBox.CheckState = mLittleState
                    PalmCheckBox.CheckState = mPalmState

                    ThumbCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableThumb
                    IndexCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableIndex
                    MiddleCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableMiddle
                    RingCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableRing
                    LittleCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableLittle
                    PalmCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisablePalm
                    If Not BodyPartsWire Is Nothing Then BodyPartsWire.EndUpdate()



                End If

            Else

                If AllSingleXBoxesWereManuallyChecked Then
                    WholeHandCheckBox.CheckState = CheckState.Checked
                    WholeHandCheckBox.Enabled = False
                Else
                    WholeHandCheckBox.CheckState = CheckState.Unchecked
                    WholeHandCheckBox.Enabled = MyBase.Enabled
                End If

                ThumbCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableThumb
                IndexCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableIndex
                MiddleCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableMiddle
                RingCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableRing
                LittleCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisableLittle
                PalmCheckBox.Enabled = MyBase.Enabled AndAlso Not mDisablePalm
                'For i As Integer = 0 To Me.mSingleXBoxes.Length - 1
                '    mSingleXBoxes(i).Enabled = MyBase.Enabled
                'Next

            End If

            mInsideRefreshCheckBoxes = False


            ' Finally, refresh all of the XBoxes
            For i As Integer = 0 To mAllXBoxes.Length - 1
                mAllXBoxes(i).Refresh()
            Next

            Return


        End Sub


        Public Sub ResetFingerpickerControl()

            For i As Integer = 0 To mAllXBoxes.Length - 1
                mAllXBoxes(i).Checked = False
            Next

        End Sub

        Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
            MyBase.OnEnabledChanged(e)
            RefreshCheckBoxes()
        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            Me.RefreshCheckBoxes()
        End Sub

        Public Sub PopulateTabList(ByVal tabList As Collection(Of Control))

            If Me.IsLeft Then
                tabList.Add(WholeHandCheckBox)
                tabList.Add(PalmCheckBox)
                tabList.Add(LittleCheckBox)
                tabList.Add(RingCheckBox)
                tabList.Add(MiddleCheckBox)
                tabList.Add(IndexCheckBox)
                tabList.Add(ThumbCheckBox)
            Else
                tabList.Add(ThumbCheckBox)
                tabList.Add(IndexCheckBox)
                tabList.Add(MiddleCheckBox)
                tabList.Add(RingCheckBox)
                tabList.Add(LittleCheckBox)
                tabList.Add(PalmCheckBox)
                tabList.Add(WholeHandCheckBox)
            End If

        End Sub

        Public Sub ReflectTask(ByVal category As SensorTaskCategory)
            Dim parts As BodyPartCollection = BodyPartCollection.ForTask(category)

            If IsLeft Then
                mDisableThumb = Not parts.Contains(BodyPart.LeftThumb)
                mDisableIndex = Not parts.Contains(BodyPart.LeftIndex)
                mDisableMiddle = Not parts.Contains(BodyPart.LeftMiddle)
                mDisableRing = Not parts.Contains(BodyPart.LeftRing)
                mDisableLittle = Not parts.Contains(BodyPart.LeftLittle)
                mDisablePalm = Not parts.Contains(BodyPart.LeftPalm)
            Else
                mDisableThumb = Not parts.Contains(BodyPart.RightThumb)
                mDisableIndex = Not parts.Contains(BodyPart.RightIndex)
                mDisableMiddle = Not parts.Contains(BodyPart.RightMiddle)
                mDisableRing = Not parts.Contains(BodyPart.RightRing)
                mDisableLittle = Not parts.Contains(BodyPart.RightLittle)
                mDisablePalm = Not parts.Contains(BodyPart.RightPalm)
            End If

        End Sub


    End Class

End Namespace