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
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports Mbark.SensorMessages
Imports Mbark.UI

Namespace Mbark.Sensors

    Public Class ControllerButtonsPanel
        Inherits System.Windows.Forms.UserControl
        Implements IAutosizable
        Implements IHasUICulture
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
        Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents EndSessionButton As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControllerButtonsPanel))
            Me.EndSessionButton = New System.Windows.Forms.Button
            Me.LogoPictureBox = New System.Windows.Forms.PictureBox
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'EndSessionButton
            '
            resources.ApplyResources(Me.EndSessionButton, "EndSessionButton")
            Me.EndSessionButton.Name = "EndSessionButton"
            '
            'LogoPictureBox
            '
            resources.ApplyResources(Me.LogoPictureBox, "LogoPictureBox")
            Me.LogoPictureBox.Name = "LogoPictureBox"
            Me.LogoPictureBox.TabStop = False
            '
            'ControllerButtonsPanel
            '
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.Controls.Add(Me.LogoPictureBox)
            Me.Controls.Add(Me.EndSessionButton)
            Me.Name = "ControllerButtonsPanel"
            resources.ApplyResources(Me, "$this")
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
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

        Dim mButtons As New Collection(Of Button)
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            mButtons.Add(EndSessionButton)
        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As System.Drawing.Graphics) _
        Implements UI.IAutosizable.RefreshAutomaticLayout

            If LogoPictureBox.Image Is Nothing Then
                LogoPictureBox.Image = New Bitmap(Me.GetType, "NIST-Logo.png")
                LogoPictureBox.Width = LogoPictureBox.Image.Width
                LogoPictureBox.Height = LogoPictureBox.Image.Height
            End If
            LogoPictureBox.Location = New Point(0, 0)
            EndSessionButton.Text = Messages.EndSessionButtonText(UICulture)
            EndSessionButton.Font = GlobalUISettings.Defaults.Fonts.Button
            UI.AutoSize.Buttons(graphics, mButtons)

            Dim endSessionButtonXLocation As Integer = Me.Width - EndSessionButton.Width
            EndSessionButton.Location = New Point(endSessionButtonXLocation + DockPadding.Left - DockPadding.Right, DockPadding.Top)

            mMinimumWidth = EndSessionButton.Width + LogoPictureBox.Width + DockPadding.Left + DockPadding.Right
            mMinimumHeight = EndSessionButton.Height + LogoPictureBox.Height + DockPadding.Top + DockPadding.Bottom

        End Sub

        Private mMinimumHeight As Integer
        Public ReadOnly Property MinimumHeight() As Integer Implements UI.IAutosizable.MinimumHeight
            Get
                Return mMinimumHeight
            End Get
        End Property

        Private mMinimumWidth As Integer
        Public ReadOnly Property MinimumWidth() As Integer Implements UI.IAutosizable.MinimumWidth
            Get

                Return mMinimumWidth
            End Get
        End Property

        Public ReadOnly Property NearestForm() As System.Windows.Forms.Form Implements UI.IAutosizable.NearestForm
            Get
                Return FindNearestForm(Me)
            End Get
        End Property

        Private mTabList As New Collection(Of Control)
        Public ReadOnly Property TabList() As Collection(Of Control) Implements IHasTabList.TabList
            Get
                mTabList.Clear()
                mTabList.Add(EndSessionButton)
                Return mTabList
            End Get
        End Property

#Region "       Automate test       "
        Public Sub EndSessionButtonPerformClick()
            EndSessionButton.PerformClick()
        End Sub
#End Region

    End Class

End Namespace