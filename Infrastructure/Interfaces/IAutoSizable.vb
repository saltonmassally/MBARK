Option Strict On

Imports System.Drawing
Imports System.Windows.Forms

Namespace Mbark.UI

    Public Interface IAutosizable
        Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
        ReadOnly Property MinimumHeight() As Integer
        ReadOnly Property MinimumWidth() As Integer
        ReadOnly Property NearestForm() As Form
    End Interface

    Public Interface IAutosizableDropDown
        Inherits IAutosizable
        Event DropDownEvent As EventHandler(Of DropDownEventArgs)
        ReadOnly Property MinimumLowerPanelHeight() As Integer
        ReadOnly Property HeaderHeight() As Integer
        ReadOnly Property IsCollapsed() As Boolean
    End Interface

    Public Class DropDownEventArgs
        Inherits EventArgs
        Private mOrigin As IAutosizableDropDown
        Private mNewMinimumHeight As Integer
        Public ReadOnly Property EventOriginatorAsDropDown() As IAutosizableDropDown
            Get
                Return mOrigin
            End Get
        End Property
        Public ReadOnly Property EventOriginatorAsControl() As Control
            Get
                Return DirectCast(mOrigin, Control)
            End Get
        End Property
        Public ReadOnly Property NewMinimumHeight() As Integer
            Get
                Return mNewMinimumHeight
            End Get
        End Property
        Public Sub New(ByVal origin As IAutosizableDropDown, ByVal newMinimumHeight As Integer)
            mOrigin = origin
            mNewMinimumHeight = newMinimumHeight
        End Sub
    End Class

End Namespace

