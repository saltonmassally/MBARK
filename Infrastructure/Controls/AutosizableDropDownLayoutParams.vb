Option Strict On

Imports System.Windows.Forms
Imports System.Drawing
Imports SF = Syncfusion.Windows.Forms.Tools

Namespace Mbark.UI

    <Serializable()> _
    Public Class AutosizableDropDownLayoutArgs

        Public Sub New(ByVal control As Control)
            mControl = control
        End Sub

        Public Sub RefreshAutomaticLayout(ByVal graphics As Graphics)
            Dim isSizable As Type = mControl.GetType.GetInterface(GetType(IAutosizable).ToString)
            Dim sizable As IAutosizable
            If Not isSizable Is Nothing Then
                sizable = DirectCast(mControl, IAutosizable)
                sizable.RefreshAutomaticLayout(graphics)
                mMinimumWidth = sizable.MinimumWidth
                mMinimumHeight = sizable.MinimumHeight
            Else
                Throw New ControlIsNotAutosizableException(mControl.Name)
            End If
        End Sub

        Public Property Control() As Control
            Get
                Return mControl
            End Get
            Set(ByVal value As Control)
                mControl = value
            End Set
        End Property
        Public Property Anchor() As SF.AnchorTypes
            Get
                Return mAnchor
            End Get
            Set(ByVal value As SF.AnchorTypes)
                mAnchor = value
            End Set
        End Property
        Public Property MinimumHeight() As Integer
            Get
                Return mMinimumHeight
            End Get
            Set(ByVal value As Integer)
                mMinimumHeight = value
            End Set
        End Property
        Public Property MinimumWidth() As Integer
            Get
                Return mMinimumWidth
            End Get
            Set(ByVal value As Integer)
                mMinimumWidth = value
            End Set
        End Property
        Public Property FillWeightY() As Single
            Get
                Return mFillWeightY
            End Get
            Set(ByVal value As Single)
                mFillWeightY = value
            End Set
        End Property
        Public Property FillWeightX() As Single
            Get
                Return mFillWeightX
            End Get
            Set(ByVal value As Single)
                mFillWeightX = value
            End Set
        End Property
        Public Property CellSpanY() As Integer
            Get
                Return mCellSpanY
            End Get
            Set(ByVal value As Integer)
                mCellSpanY = value
            End Set
        End Property
        Public Property CellSpanX() As Integer
            Get
                Return mCellSpanX
            End Get
            Set(ByVal value As Integer)
                mCellSpanX = value
            End Set
        End Property
        Public Property GridPosY() As Integer
            Get
                Return mGridPosY
            End Get
            Set(ByVal value As Integer)
                mGridPosY = value
            End Set
        End Property
        Public Property GridPosX() As Integer
            Get
                Return mGridPosX
            End Get
            Set(ByVal value As Integer)
                mGridPosX = value
            End Set
        End Property

        Public Sub New( _
            ByVal control As Control, _
            ByVal gridPosX As Integer, ByVal gridPosY As Integer, _
            ByVal cellSpanX As Integer, ByVal cellSpanY As Integer, _
            ByVal fillWeightX As Single, ByVal fillWeightY As Single)

            mControl = control
            mGridPosX = gridPosX
            mGridPosY = gridPosY
            mCellSpanX = cellSpanX
            mCellSpanY = cellSpanY
            mFillWeightX = fillWeightX
            mFillWeightY = fillWeightY

        End Sub

        Private mGridPosX As Integer
        Private mGridPosY As Integer
        Private mCellSpanX As Integer = 1
        Private mCellSpanY As Integer = 1
        Private mFillWeightX As Single
        Private mFillWeightY As Single
        Private mMinimumWidth As Integer
        Private mMinimumHeight As Integer
        Private mAnchor As SF.AnchorTypes = SF.AnchorTypes.Center
        <NonSerialized()> Private mControl As Control

    End Class

End Namespace