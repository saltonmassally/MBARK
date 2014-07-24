Option Strict On

Imports System
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Security.Permissions

Imports Mbark.SensorMessages
Imports Mbark.Sensors

Namespace Mbark

    <Serializable()> Public Class SensorException
        Inherits MbarkException

        Public Sub New()
            MyBase.New(Messages.GeneralSensorException(CultureInfo.CurrentUICulture))
            mTimestamp = DateTime.UtcNow
        End Sub

        Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
            mTimestamp = DateTime.UtcNow
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            mTimestamp = DateTime.UtcNow
        End Sub


        Public Sub New(ByVal msg As String)
            MyBase.New(msg)
            mTimestamp = DateTime.UtcNow
        End Sub

        <SecurityPermission(SecurityAction.Demand, SerializationFormatter:=True)> _
        Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            If info Is Nothing Then Return

            MyBase.GetObjectData(info, context)
            info.AddValue("Timestamp", Timestamp)
            info.AddValue("MachineNotes", MachineNotes)
            info.AddValue("Sensor", Sensor)
        End Sub

        Private mMachineNotes As String
        Public Property MachineNotes() As String
            Get
                Return mMachineNotes
            End Get
            Set(ByVal value As String)
                mMachineNotes = value
            End Set
        End Property

        Private mMachineException As Exception
        Public Property MachineException() As Exception
            Get
                Return mMachineException
            End Get
            Set(ByVal value As Exception)
                mMachineException = value
            End Set
        End Property

        Private mTimestamp As DateTime
        Public ReadOnly Property Timestamp() As DateTime
            Get
                Return mTimestamp
            End Get
        End Property

        Private mSensor As ISensor
        Public Property Sensor() As ISensor
            Get
                Return mSensor
            End Get
            Set(ByVal value As ISensor)
                mSensor = value
            End Set
        End Property


    End Class

End Namespace