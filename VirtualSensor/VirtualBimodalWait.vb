Option Strict On

Imports Mbark.Threading
Imports Mbark.UI

Imports System.Drawing
Imports System.Delegate
Imports System.Threading

Namespace Mbark.Sensors

    <Serializable()> Public Class VirtualBimodalWait
        Private mShortTime As Integer = 250
        Private mLongTime As Integer = 1000
        Private mProcessTime As Integer = 3000
        Private mShortPlusOrMinus As Integer
        Private mLongPlusOrMinus As Integer
        Private mProbabilityOfLongWait As Double = 0

        Public Property ProbOfLongWait() As Double
            Get
                Return mProbabilityOfLongWait
            End Get
            Set(ByVal value As Double)
                mProbabilityOfLongWait = value
            End Set
        End Property
        Public Property ShortTime() As Integer
            Get
                Return mShortTime
            End Get
            Set(ByVal value As Integer)
                mShortTime = value
            End Set
        End Property
        Public Property LongTime() As Integer
            Get
                Return mLongTime
            End Get
            Set(ByVal value As Integer)
                mLongTime = value
            End Set
        End Property
        Public Property ProcessTime() As Integer
            Get
                Return mProcessTime
            End Get
            Set(ByVal Value As Integer)
                mProcessTime = Value
            End Set
        End Property
        Public Property ShortPlusOrMinus() As Integer
            Get
                Return mShortPlusOrMinus
            End Get
            Set(ByVal value As Integer)
                mShortPlusOrMinus = value
            End Set
        End Property
        Public Property LongPlusOrMinus() As Integer
            Get
                Return mLongPlusOrMinus
            End Get
            Set(ByVal value As Integer)
                mLongPlusOrMinus = value
            End Set
        End Property

        Private Shared mRandom As Random = New Random
        Shared Sub New()
            Randomize()
        End Sub

        Public Sub New(ByVal shortTime As Integer, ByVal shortPlusOrMinus As Integer, _
            ByVal longTime As Integer, ByVal longPlusOrMinus As Integer, _
            ByVal probabilityOfLongWait As Double)
            mShortTime = shortTime
            mShortPlusOrMinus = shortPlusOrMinus
            mLongTime = longTime
            mLongPlusOrMinus = longPlusOrMinus
            mProbabilityOfLongWait = probabilityOfLongWait
        End Sub

        Public Sub New()

        End Sub

        Public Function BetweenShortAndLongTime(ByVal fraction As Single) As Integer
            Dim offset As Single = (mLongTime - mShortTime) * fraction
            Return CInt(mShortTime + offset)
        End Function

        Public Function WaitTime() As Integer
            Dim base As Integer
            Dim offset As Integer
            If mRandom.NextDouble <= ProbOfLongWait Then
                base = mLongTime
                offset = mRandom.Next(-mLongPlusOrMinus, mLongPlusOrMinus)
            Else
                base = mShortTime
                offset = mRandom.Next(-mShortPlusOrMinus, mShortPlusOrMinus)
            End If
            Dim sleeptime As Integer = Math.Max(base + offset, 0)
            Return sleeptime
        End Function

        Private Shared smInsideWait As Boolean
        Public Function Wait(ByVal wakeupFrequency As Integer) As Integer

            Dim sleeptime As Integer = WaitTime()
            WaitWithDoEvents(sleeptime, wakeupFrequency)
            Return sleeptime

        End Function


    End Class

End Namespace