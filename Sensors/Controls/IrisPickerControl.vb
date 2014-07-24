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
Imports System.Windows.Forms

Imports SF = Syncfusion.Windows.Forms.Tools

Imports Mbark.UI
Imports Mbark.SensorMessages

Namespace Mbark.Sensors


    Public Class IrisPickerControl
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
        Friend WithEvents RightEyeToolTip As System.Windows.Forms.ToolTip
        Friend WithEvents LeftEyeToolTip As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.RightEyeToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.LeftEyeToolTip = New System.Windows.Forms.ToolTip(Me.components)
            '
            'IrisPickerControl
            '
            Me.Name = "IrisPickerControl"
            Me.Size = New System.Drawing.Size(304, 432)

        End Sub

#End Region

        Public WithEvents LeftEyeCheckBox As New XBox
        Public WithEvents RightEyeCheckBox As New XBox

        Private Sub UserNew()

            LeftEyeCheckBox.Name = "LeftEyeCheckBox"
            Controls.Add(LeftEyeCheckBox)

            RightEyeCheckBox.Name = "RightEyeCheckBox"
            Controls.Add(RightEyeCheckBox)

            RightEyeCheckBox.TabIndex = 0
            LeftEyeCheckBox.TabIndex = 1

            PopulatePartImages(New Bitmap(Me.GetType(), "head.png"), New Bitmap(Me.GetType(), "head-disabled.png"))

        End Sub

        Private mBindingFromWireToControl As Boolean
        Protected Friend Overrides Sub BindFromWireToControl()

            If BodyPartsWire Is Nothing Then Return

            mBindingFromWireToControl = True
            With BodyPartsWire
                If .Contains(BodyPart.LeftIris) Then LeftEyeCheckBox.CheckState = CheckState.Checked Else LeftEyeCheckBox.CheckState = CheckState.Unchecked
                If .Contains(BodyPart.RightIris) Then RightEyeCheckBox.CheckState = CheckState.Checked Else RightEyeCheckBox.CheckState = CheckState.Unchecked
            End With
            mBindingFromWireToControl = False

        End Sub

        Private Sub BindFromControlToWire()

            If BodyPartsWire Is Nothing Then Return
            With BodyPartsWire
                If LeftEyeCheckBox.CheckState = CheckState.Checked Then .Add(BodyPart.LeftIris) Else .Remove(BodyPart.LeftIris)
                If RightEyeCheckBox.CheckState = CheckState.Checked Then .Add(BodyPart.RightIris) Else .Remove(BodyPart.RightIris)
            End With
            Refresh()

        End Sub


        Private Shared RightEyeCenter As New Point(152, 248)
        Private Shared LeftEyeCenter As New Point(279, 248)

        Private mLeftEyeOnly As Boolean
        Public Property LeftEyeOnly() As Boolean
            Get
                Return mLeftEyeOnly
            End Get
            Set(ByVal value As Boolean)
                mLeftEyeOnly = value
            End Set
        End Property

        Private mRightEyeOnly As Boolean
        Public Property RightEyeOnly() As Boolean
            Get
                Return mRightEyeOnly
            End Get
            Set(ByVal value As Boolean)
                mRightEyeOnly = value
            End Set
        End Property


        Private Sub PlaceCheckBox(ByVal checkBox As CheckBox, ByVal loc As Point)

            checkBox.Height = 13
            checkBox.Width = 13

            Dim newPoint As Point = MainPictureBox.RemapImagePoint(loc)

            newPoint.Y -= CInt(checkBox.Height / 2)
            newPoint.X -= CInt(checkBox.Width / 2)

            checkBox.Location = newPoint
            checkBox.Size = GlobalUISettings.ControlSizes.CheckBox
            checkBox.BringToFront()

        End Sub

        Protected Overrides Sub LayoutCheckBoxes()
            PlaceCheckBox(RightEyeCheckBox, RightEyeCenter)
            PlaceCheckBox(LeftEyeCheckBox, LeftEyeCenter)
        End Sub

        Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
            MyBase.OnEnabledChanged(e)
            RefreshCheckBoxes()
        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            Me.RefreshCheckBoxes()
        End Sub

        Protected Overrides Sub RefreshCheckBoxes()
            LeftEyeCheckBox.Enabled = MyBase.Enabled
            RightEyeCheckBox.Enabled = MyBase.Enabled
            If RightEyeOnly Then LeftEyeCheckBox.Enabled = False
            If LeftEyeOnly Then RightEyeCheckBox.Enabled = False
        End Sub


        Private Sub CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RightEyeCheckBox.CheckedChanged, LeftEyeCheckBox.CheckedChanged

            ' If we are currently binding from the wire to the control, then don't process this request as normal
            If mBindingFromWireToControl Then Return

            BindFromControlToWire()
            RefreshCheckBoxes()
        End Sub



        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
            MyBase.RefreshAutomaticLayout(graphics)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            PopulateMessages()
        End Sub

        Private Sub PopulateMessages()
            FooterLabel.Text = Messages.Irises(UICulture)
            RightEyeToolTip.SetToolTip(RightEyeCheckBox, Messages.RightIris(UICulture))
            LeftEyeToolTip.SetToolTip(LeftEyeCheckBox, Messages.LeftIris(UICulture))
        End Sub


        Public Sub DeselectAllIrises()
            LeftEyeCheckBox.Checked = False
            RightEyeCheckBox.Checked = False
        End Sub

        Public Sub PopulateTabList(ByVal tabList As Collection(Of Control))
            tabList.Add(RightEyeCheckBox)
            tabList.Add(LeftEyeCheckBox)
            
        End Sub



        Private Sub WorkaroundLeftEyeCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles LeftEyeCheckBox.MouseEnter
            LeftEyeToolTip.RemoveAll()
            LeftEyeToolTip.SetToolTip(LeftEyeCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.LeftIris))
        End Sub

        Private Sub WorkaroundRightEyeCheckBoxToolTipBug(ByVal sender As Object, ByVal e As EventArgs) Handles RightEyeCheckBox.MouseEnter
            RightEyeToolTip.RemoveAll()
            RightEyeToolTip.SetToolTip(RightEyeCheckBox, BodyPartCollection.ToString(UICulture, BodyPart.RightIris))
        End Sub


    End Class

End Namespace