'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
'       Ross J. Micheals (rossm@nist.gov)
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
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Mbark.SensorMessages
Imports Mbark.UI
Imports Mbark.UI.GlobalUISettings

Namespace Mbark.Sensors

    Public Class AttemptPicker
        Inherits RadioGroupBox
        Implements IHasTabList

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
        Friend WithEvents FlowLayout As Syncfusion.Windows.Forms.Tools.FlowLayout
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttemptPicker))
            Me.FlowLayout = New Syncfusion.Windows.Forms.Tools.FlowLayout(Me.components)
            CType(Me.FlowLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'InnerPanel
            '
            Me.InnerPanel.BackColor = System.Drawing.SystemColors.Control
            Me.InnerPanel.ForeColor = System.Drawing.SystemColors.ControlText
            resources.ApplyResources(Me.InnerPanel, "InnerPanel")
            '
            'FlowLayout
            '
            Me.FlowLayout.AutoLayout = False
            Me.FlowLayout.ContainerControl = Me.InnerPanel
            resources.ApplyResources(Me.FlowLayout, "FlowLayout")
            '
            'AttemptPicker
            '
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.Name = "AttemptPicker"
            resources.ApplyResources(Me, "$this")
            CType(Me.FlowLayout, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mAttemptBoxes As New List(Of AttemptPictureBox)
        Private mAttemptToBox As New Dictionary(Of SensorTaskAttempt, AttemptPictureBox)
        Private mTaskWire As SensorTask

        Private mConditionsWire As ConditionCollection
        Private mInaccessibleBodyPartsWire As BodyPartCollection


        Public Sub WireConditions(ByVal conditions As ConditionCollection)
            mConditionsWire = conditions
            PopulateControls()
        End Sub

        Public Sub WireInaccessibleBodyParts(ByVal parts As BodyPartCollection)
            mInaccessibleBodyPartsWire = parts
        End Sub

        Public Sub WireTask(ByVal task As SensorTask)
            mTaskWire = task
            PopulateControls()
        End Sub

        Public Sub RefreshPicker()
            SafeInvokeNoArgSub(Me, AddressOf RefreshPickerImplementation)
        End Sub

        Private mTabList As New Collection(Of Control)
        Private Sub PopulateControls()

            If mTaskWire Is Nothing Then
                mAttemptToBox.Clear()
                For i As Integer = 0 To mAttemptBoxes.Count - 1
                    mAttemptBoxes(i).ClearPicture()
                Next
                mAttemptBoxes.Clear()
                ClearInnerPanelControls()
                Return
            End If

            SuspendLayout()
            MyBase.InnerPanel.Visible = False
            Dim attempts As SensorTaskAttemptCollection = mTaskWire.Attempts

            While mAttemptBoxes.Count < attempts.Count
                Dim apb As New AttemptPictureBox
                apb.Visible = False
                AddHandler apb.EditRequested, AddressOf HandleEditRequested
                mAttemptBoxes.Add(apb)
            End While


            ' Remove stale attempts from the hashtable

            Dim en As IEnumerator(Of SensorTaskAttempt) = mAttemptToBox.Keys.GetEnumerator
            Dim toRemove As New List(Of SensorTaskAttempt)
            Dim toDispose As New List(Of AttemptPictureBox)
            While en.MoveNext

                If Not attempts.Contains(en.Current) Then
                    Dim apb As AttemptPictureBox = mAttemptToBox(en.Current)
                    apb.Visible = False
                    apb.CaptionLabel.Text = String.Empty
                    apb.ClearPicture()
                    toRemove.Add(en.Current)
                    toDispose.Add(apb)
                End If
            End While

            For i As Integer = 0 To toRemove.Count - 1
                mAttemptToBox.Remove(toRemove(i))
            Next

            ' Populate new attempts into the hashtable
            For i As Integer = 0 To attempts.Count - 1

                If Not mAttemptToBox.ContainsKey(attempts(i)) Then
                    If Not attempts(i).ThumbnailImage Is Nothing Then
                        Dim apbNotYetInMap As AttemptPictureBox = mAttemptBoxes(i)
                        apbNotYetInMap.Visible = False
                        apbNotYetInMap.WireAttempt(attempts(i))
                        InnerPanel.Controls.Add(apbNotYetInMap)
                        mAttemptToBox(attempts(i)) = apbNotYetInMap
                    End If
                End If

                ' Correctly order the picture boxes
                If mAttemptToBox.ContainsKey(attempts(i)) Then
                    Dim apb As AttemptPictureBox = mAttemptToBox(attempts(i))
                    If Not apb Is Nothing Then
                        apb.SendToBack()
                    End If
                End If
                

            Next

            mTabList.Clear()
            For i As Integer = 0 To attempts.Count - 1

                If mAttemptToBox.ContainsKey(attempts(i)) Then
                    Dim apb As AttemptPictureBox = mAttemptToBox(attempts(i))
                    If Not apb Is Nothing Then
                        apb.Visible = True
                        If Not mTabList.Contains(apb.EditButton) Then
                            mTabList.Add(apb.EditButton)
                        End If
                    End If
                End If

            Next

            MyBase.InnerPanel.Visible = True
            ResumeLayout()


        End Sub

        Public Sub Clear()

            ClearInnerPanelControls()

            mAttemptToBox.Clear()
            mAttemptBoxes.Clear()
            mTaskWire = Nothing
            RefreshPicker()
        End Sub

        Public Overrides Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
            MyBase.RefreshAutomaticLayout(graphics)

            InnerPanel.Visible = False
            'If mTaskWire Is Nothing Then Return

            'RecursiveSuspendLayout(Me)

            ' Determine the height and width of each AttemptPictureBox
            Dim abpHeight As Integer = InnerPanel.Height - FlowLayout.VGap
            Dim abpWidth As Integer

            'InnerPanel.Dock = DockStyle.Fill
            'Console.WriteLine(Me.Width - InnerPanel.Width)
            Dim innerPanelWidth As Integer = Me.Width - 6
            If mAttemptToBox.Count > 0 Then
                abpWidth = CInt(InnerPanel.Width / mAttemptToBox.Count) - UndocumentedPaddingConstants.PreventFlowLayoutWrap - FlowLayout.HGap
            End If


            ' For some reason, we need a second pass at the autosize
            Dim en As IEnumerator(Of SensorTaskAttempt) = mAttemptToBox.Keys.GetEnumerator
            Dim minimumWidth, minimumHeight As Integer
            Dim count As Integer
            While en.MoveNext
                Dim attempt As SensorTaskAttempt = en.Current
                If mAttemptToBox.ContainsKey(attempt) Then
                    Dim abp As AttemptPictureBox = mAttemptToBox(attempt)
                    abp.Height = abpHeight
                    abp.Width = abpWidth
                    abp.RefreshLabel(mConditionsWire, mInaccessibleBodyPartsWire)
                    abp.RefreshAutomaticLayout(graphics)
                    minimumWidth += abp.MinimumWidth
                    minimumHeight = Math.Max(minimumHeight, abp.MinimumHeight)
                    count += 1
                End If
            End While

            If count = 0 Then
                MyBase.RefreshAutomaticLayout(graphics)
            Else
                minimumWidth += UndocumentedPaddingConstants.PreventFlowLayoutWrap + (FlowLayout.HGap * count - 1)
                MinimumSize = New Size(minimumWidth, CInt(minimumWidth / count))
            End If





            InnerPanel.Visible = True

            FlowLayout.LayoutContainer()
            'RecursiveResumeLayout(Me)



        End Sub

        
        Public Overrides ReadOnly Property MinimumWidth() As Integer
            Get
                Return MinimumSize.Width
            End Get
        End Property

        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            If Not NearestForm Is Nothing Then
                Dim g As Graphics = NearestForm.CreateGraphics
                RefreshAutomaticLayout(g)
                g.Dispose()
            End If
        End Sub


        Public Sub RefreshPickerImplementation()
            If NearestForm Is Nothing Then Return
            PopulateControls()

            RefreshAutomaticLayout(NearestForm.CreateGraphics)
        End Sub

        Public ReadOnly Property TaskWire() As SensorTask
            Get
                Return mTaskWire
            End Get
        End Property

        Public Event EditRequested As EventHandler(Of EditRequestedEventArgs)

        Private Sub HandleEditRequested(ByVal sender As Object, ByVal e As EditRequestedEventArgs)
            RaiseEvent EditRequested(sender, e)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            HeaderTextColor = SystemColors.ActiveCaptionText
            HeaderText = Messages.CapturedImages(UICulture)
        End Sub

        Private mAttemptPickerBoxesEnabled As Boolean
        Public Property AttemptPickerBoxesEnabled() As Boolean
            Get
                Return mAttemptPickerBoxesEnabled
            End Get
            Set(ByVal value As Boolean)
                mAttemptPickerBoxesEnabled = value
                For i As Integer = 0 To mAttemptBoxes.Count - 1
                    With DirectCast(mAttemptBoxes(i), AttemptPictureBox)
                        .Enabled = mAttemptPickerBoxesEnabled
                        .Refresh()
                    End With
                Next
            End Set
        End Property

        Public ReadOnly Property TabList() As Collection(Of Control) Implements IHasTabList.TabList
            Get
                Return mTabList
            End Get
        End Property
        Private Sub ClearInnerPanelControls()
            For i As Integer = InnerPanel.Controls.Count - 1 To 0 Step -1
                InnerPanel.Controls(i).Dispose()
            Next
            InnerPanel.Controls.Clear()
        End Sub
    End Class


End Namespace
