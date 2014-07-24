

Option Strict On

Namespace Mbark.Sensors
		
		    Public Class CaptureResult

		        Friend mImageProperties As New ImageProperties
		        Friend mDefinition As New CaptureResultDefinition

		        Public Property SensorProperties() As SensorProperties
		            Get
		                Return mDefinition.SensorProperties
		            End Get
		            Set(ByVal value As SensorProperties)
		                mDefinition.SensorProperties = value
		            End Set
		        End Property

		        Public Property ImageProperties() As ImageProperties
		            Get
		                Return mImageProperties
		            End Get
		            Set(ByVal value As ImageProperties)
		                mImageProperties = value
		            End Set
		        End Property

		        Public Function CreateDefinition() As CaptureResultDefinition
		            Dim newDef As New CaptureResultDefinition

		            newDef.SensorProperties = mDefinition.SensorProperties.DeepCopy
		            newDef.ImagePropertiesDefinition = mImageProperties.Definition

		            Return newDef
		        End Function

		    End Class

End Namespace
