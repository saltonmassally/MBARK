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

Namespace Mbark.Sensors


    <Serializable()> Public Class CaptureResultDefinition
        Implements ICloneable

#Region "Private"
        Private mImagePropertiesDefinition As New ImagePropertiesDefinition
        Private mSensorProperties As New SensorProperties
#End Region

#Region "Properties"

        Public Property ImagePropertiesDefinition() As ImagePropertiesDefinition
            Get
                Return mImagePropertiesDefinition
            End Get
            Set(ByVal value As ImagePropertiesDefinition)
                mImagePropertiesDefinition = value
            End Set
        End Property

        Public Property SensorProperties() As SensorProperties
            Get
                Return mSensorProperties
            End Get
            Set(ByVal value As SensorProperties)
                mSensorProperties = value
            End Set
        End Property

#End Region

        Public Function CreateCaptureResult() As CaptureResult
            Dim result As New CaptureResult
            result.mDefinition = Me.DeepCopy()
            result.mImageProperties = ImagePropertiesDefinition.CreateImageProperties
            Return result
        End Function

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New CaptureResultDefinition
            newDef.ImagePropertiesDefinition = Me.ImagePropertiesDefinition.DeepCopy
            newDef.SensorProperties = Me.SensorProperties.DeepCopy
            Return newDef
        End Function

        Public Function DeepCopy() As CaptureResultDefinition
            Return DirectCast(Clone(), CaptureResultDefinition)
        End Function

    End Class

End Namespace
