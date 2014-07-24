Option Strict On

Imports System.Collections.ObjectModel
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices


Namespace Mbark

    Public Module TypeUtilities

        Public Function FindNearestParentOfInterface(ByVal control As Control, ByVal soughtInterface As Type) As Control
            Dim providers As Collection(Of Control) = FindParentControlsOfInterface(control, soughtInterface)
            If providers.Count = 0 Then Return Nothing Else Return providers(0)
        End Function

        Public Function FindNearestParentOfType(ByVal start As Control, ByVal soughtType As Type) As Control
            Dim providers As Collection(Of Control) = FindParentControlsOfType(start, soughtType)
            If providers.Count = 0 Then Return Nothing Else Return providers(0)
        End Function

        ' TODO: Make sure this combination is correct, and/or optimal
        Private AllFieldsFlag As Reflection.BindingFlags = _
            Reflection.BindingFlags.NonPublic Or _
            Reflection.BindingFlags.Public Or _
            Reflection.BindingFlags.FlattenHierarchy Or _
            Reflection.BindingFlags.Static Or _
            Reflection.BindingFlags.Instance


        Private Sub FindParentControlsOfType( _
            ByVal foundObjects As Collection(Of Control), _
            ByVal startingControl As Control, _
            ByVal soughtType As Type, _
            ByVal recurseUp As Boolean)

            If startingControl.Parent Is Nothing Then Return

            If startingControl.Parent.GetType.Equals(soughtType) OrElse startingControl.Parent.GetType.IsSubclassOf(soughtType) Then
                foundObjects.Add(startingControl.Parent)
            End If

            If recurseUp Then
                FindParentControlsOfType(foundObjects, startingControl.Parent, soughtType, recurseUp)
            End If

        End Sub


        Private Sub FindParentControlsOfInterfaceImplementation( _
            ByVal foundObjects As Collection(Of Control), _
            ByVal control As Control, _
            ByVal soughtInterface As Type, _
            ByVal recurseUp As Boolean)

            If control Is Nothing OrElse control.Parent Is Nothing Then Return

            Dim foundInterface As Type = control.Parent.GetType.GetInterface(soughtInterface.Name)
            If Not foundInterface Is Nothing And foundObjects.IndexOf(control.Parent) = -1 Then
                foundObjects.Add(control.Parent)
            End If

            ' Recurse on the parent.
            If recurseUp Then
                FindParentControlsOfInterfaceImplementation(foundObjects, control.Parent, soughtInterface, recurseUp)
            End If

        End Sub

        Private Sub FindChildControlsOfInterface( _
            ByVal foundControls As Collection(Of Control), _
            ByVal target As Control, _
            ByVal soughtInterface As Type, _
            ByVal recursive As Boolean)

            If target Is Nothing Then Return

            For i As Integer = 0 To target.Controls.Count - 1
                Dim c As Control = target.Controls(i)
                Dim foundInterface As Type = c.GetType.GetInterface(soughtInterface.Name)
                If Not foundInterface Is Nothing Then
                    If foundControls.IndexOf(c) = -1 Then
                        foundControls.Add(c)
                    End If
                End If
                If recursive Then
                    FindChildControlsOfInterface(foundControls, c, soughtInterface, True)
                End If
            Next

        End Sub


        Public Function FindControlsOfInterface( _
            ByVal start As Windows.Forms.Control, _
            ByVal soughtInterface As Type, _
            ByVal recurseUp As Boolean, _
            ByVal recurseDown As Boolean) As Collection(Of Control)

            Dim controls As New Collection(Of Control)

            FindChildControlsOfInterface(controls, start, soughtInterface, recurseDown)
            FindParentControlsOfInterfaceImplementation(controls, start, soughtInterface, recurseUp)

            Return controls
        End Function

        Public Function FindParentControlsOfInterface(ByVal start As Control, ByVal soughtInterface As Type) As Collection(Of Control)
            Dim objects As New Collection(Of Control)
            FindParentControlsOfInterfaceImplementation(objects, start, soughtInterface, True)
            Return objects
        End Function


        Public Function FindParentControlsOfType(ByVal start As Control, ByVal soughtType As Type) As Collection(Of Control)
            Dim objects As New Collection(Of Control)
            FindParentControlsOfType(objects, start, soughtType, True)
            Return objects
        End Function



        ''' <summary><para>Gets a reference to the top control in a control 
        ''' hiearchy.</para></summary>
        ''' <param name="control"><para>The control from which to start the search.</para></param>
        Public Function ParentmostControl(ByVal control As Windows.Forms.Control) As Windows.forms.Control
            If control Is Nothing Then Throw New ArgumentNullException("control")
            If control.Parent Is Nothing Then Return control
            Return ParentmostControl(control.Parent)
        End Function

        ' Adapted from http://www.vbinfozine.com/t_bindevt.shtml
        Public Function DynamicEventBinding( _
            ByVal sender As Object, _
            ByVal receiver As Object, _
            ByVal bind As Boolean, _
            ByVal eventName As String, _
            ByVal handlerName As String) As Boolean

            If sender Is Nothing Then Throw New ArgumentNullException("sender")
            If receiver Is Nothing Then Throw New ArgumentNullException("receiver")

            ' Get the sender events
            Dim sendersEvents() As EventInfo = sender.GetType().GetEvents()
            Dim targetEvent As EventInfo = Nothing

            ' Find the event that maches the sought name
            For i As Integer = 0 To sendersEvents.Length - 1
                Dim candidateEvent As EventInfo = _
                    CType(sendersEvents(i), EventInfo)
                If candidateEvent.Name = eventName Then
                    targetEvent = candidateEvent
                End If
            Next
            If targetEvent Is Nothing Then Return False

            Dim targetHandler As MethodInfo = receiver.GetType.GetMethod(handlerName, AllFieldsFlag)
            If targetHandler Is Nothing Then Return False

            ' Create the delegate
            Dim d As System.Delegate = [Delegate].CreateDelegate( _
                targetEvent.EventHandlerType, receiver, targetHandler.Name)


            If bind Then
                targetEvent.AddEventHandler(sender, d)
            Else
                targetEvent.RemoveEventHandler(sender, d)
            End If



            Return True
        End Function

    End Module

    <Serializable()> Public Class TypeDefinition

        Public Property ClassName() As String
            Get
                Return mClassName
            End Get
            Set(ByVal value As String)
                mClassName = value
            End Set
        End Property
        Public Property Subdirectory() As String
            Get
                Return mSubdirectoryName
            End Get
            Set(ByVal value As String)
                mSubdirectoryName = value
            End Set
        End Property
        Public Property LibraryFileName() As String
            Get
                Return mLibraryFilename
            End Get
            Set(ByVal value As String)
                mLibraryFilename = value
            End Set
        End Property

        Private mClassName As String
        Private mLibraryFilename As String
        Private mSubdirectoryName As String

        Public Shared Function Create(ByVal obj As Object) As TypeDefinition
            If obj Is Nothing Then Throw New ArgumentNullException("obj")
            Dim newDef As New TypeDefinition
            newDef.ClassName = obj.GetType.FullName
            newDef.LibraryFileName = IO.Path.GetFileName(obj.GetType.Assembly.Location)
            Return newDef
        End Function

        Public Overridable Function InstantiateObject() As Object
            Dim filename As String
            Dim currentPath As String = AppDomain.CurrentDomain.BaseDirectory
            If Subdirectory <> String.Empty Then currentPath = IO.Path.Combine(currentPath, Subdirectory)
            filename = IO.Path.Combine(currentPath, LibraryFileName)

            Dim assem As [Assembly] = System.Reflection.Assembly.LoadFile(filename)
            Dim instance As Object = Nothing
            Try
                instance = assem.CreateInstance(ClassName)
            Catch ex As TargetInvocationException When Marshal.GetHRForException(ex.InnerException) = &H80040154
                MsgBox("Unregistered COM DLL")
                'Debugger.Break()
            End Try

            Return instance

        End Function

        Public Overrides Function ToString() As String
            Return LibraryFileName & "+" & ClassName
        End Function

        Public Delegate Function StringReturner() As String


    End Class

    Public Class Pair(Of T1, T2)

        Private mFirst As T1
        Private mSecond As T2

        Public Property First() As T1
            Get
                Return mFirst
            End Get
            Set(ByVal value As T1)
                mFirst = value
            End Set
        End Property

        Public Property Second() As T2
            Get
                Return mSecond
            End Get
            Set(ByVal value As T2)
                mSecond = value
            End Set
        End Property

        Public Sub New(ByVal first As T1, ByVal second As T2)
            Me.First = first
            Me.Second = second
        End Sub
    End Class

End Namespace
