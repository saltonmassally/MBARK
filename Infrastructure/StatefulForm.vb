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

Imports System.Threading

Imports Mbark.Threading

Namespace Mbark.UI

    Public Class StatefulForm
        Inherits BaseForm

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            UserNew()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            UserDispose()
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StatefulForm))
            '
            'StatefulForm
            '
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "StatefulForm"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")

        End Sub

#End Region

#Region "  Startup & Shutdown  "

        Protected Overridable Sub UserNew()

        End Sub

        Protected Overridable Sub UserDispose()

        End Sub

        Private WithEvents mStartupTimer As New Timers.Timer
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If InDesignMode(Me) Then Return
            mStartupTimer.Start()
        End Sub

        Private mIsClosing As Boolean
        Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            MyBase.OnClosing(e)
            mIsClosing = True
        End Sub

        Protected ReadOnly Property IsClosing() As Boolean
            Get
                Return mIsClosing
            End Get
        End Property

        Private Sub mStartupTimer_Elapsed(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs) _
        Handles mStartupTimer.Elapsed
            mStartupTimer.Stop()
            ChangeState(StartupState, FormStateChangeTrigger.EventActivated, "mStartupTimer_Elapsed", Nothing)
        End Sub


        Private mStartupState As Integer
        Protected Property StartupState() As Integer
            Get
                Return mStartupState
            End Get
            Set(ByVal value As Integer)
                mStartupState = value
            End Set
        End Property

#End Region

        Private mPreviousState As Integer
        Private mCurrentState As Integer

        Public Sub ExplicitChangeState(ByVal newState As Integer)
            ChangeState(newState, FormStateChangeTrigger.Explicit, String.Empty, Nothing)
        End Sub

        Private mChangingState As Boolean
        Public Sub ChangeState( _
            ByVal newMode As Integer, _
            ByVal trigger As FormStateChangeTrigger, _
            ByVal reason As String, _
            ByVal command As AsyncCommand)

            If IsClosing Then Return

            If InvokeRequired Then
                While mChangingState
                    WaitWithDoEvents(150, 10)
                End While
                mChangingState = True
                Dim d As New StateChanger(AddressOf ChangeStateImplementationWrapper)
                Try
                    Me.Invoke(d, New Object() {newMode, trigger, reason, command})
                Catch ex As ThreadInterruptedException
                    ' Swallow this exception
                Finally
                    mChangingState = False
                End Try

            Else
                ChangeStateImplementationWrapper(newMode, trigger, reason, command)
            End If


        End Sub


        Protected Delegate Sub StateChanger( _
                ByVal newMode As Integer, _
                ByVal trigger As FormStateChangeTrigger, _
                ByVal reason As String, _
                ByVal command As AsyncCommand)


        Protected Overridable Sub ChangeStateImplementationWrapper( _
            ByVal newMode As Integer, _
            ByVal trigger As FormStateChangeTrigger, _
            ByVal reason As String, _
            ByVal command As AsyncCommand)

            mPreviousState = mCurrentState
            mCurrentState = newMode

            ChangeStateImplementation(command)

        End Sub


        Protected Overridable Sub ChangeStateImplementation(ByVal command As AsyncCommand)
            ' Intended for override
        End Sub


        Protected ReadOnly Property CurrentFormState() As Integer
            Get
                Return mCurrentState
            End Get
        End Property

        Protected ReadOnly Property PreviousFormState() As Integer
            Get
                Return mPreviousState
            End Get
        End Property




    End Class

End Namespace