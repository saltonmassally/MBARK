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

Imports System.Xml.Serialization

Namespace Mbark.Sensors

    <XmlType("SensorType"), Serializable()> Public Class SensorTypeDefinition
        Inherits TypeDefinition

        Private mHasConfigurationClass As Boolean
        Public Property HasConfigurationClass() As Boolean
            Get
                Return mHasConfigurationClass
            End Get
            Set(ByVal value As Boolean)
                mHasConfigurationClass = value
            End Set
        End Property

        Private mConfigurationClassName As String
        Public Property ConfigurationClassName() As String
            Get
                Return mConfigurationClassName
            End Get
            Set(ByVal value As String)
                mConfigurationClassName = value
            End Set
        End Property

        Public Overloads Shared Function CreateDefinition(ByVal sensor As ISensor) As SensorTypeDefinition

            If sensor Is Nothing Then Throw New ArgumentNullException("sensor")

            Dim newDef As New SensorTypeDefinition

            Dim asBaseSensor As BaseSensor = DirectCast(sensor, BaseSensor)
            newDef.ClassName = asBaseSensor.GetType.FullName
            newDef.LibraryFileName = IO.Path.GetFileName(asBaseSensor.GetType.Assembly.Location)
            If sensor.HasConfigurationClass Then
                newDef.HasConfigurationClass = True
                newDef.ConfigurationClassName = sensor.ConfigurationClassName
            Else
                newDef.HasConfigurationClass = False
                newDef.ConfigurationClassName = Nothing
            End If
            Return newDef
        End Function

        Public Shared Function CreateSensor(ByVal definition As SensorTypeDefinition) As ISensor
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            Return DirectCast(definition.InstantiateObject(), ISensor)
        End Function

        Public Overrides Function InstantiateObject() As Object
            Dim newObject As Object
            Try
                Subdirectory = "Sensors"
                newObject = MyBase.InstantiateObject()
            Catch ex As IO.FileNotFoundException
                Subdirectory = String.Empty
                newObject = MyBase.InstantiateObject()
            Catch ex As IO.DirectoryNotFoundException
                Subdirectory = String.Empty
                newObject = MyBase.InstantiateObject()
            End Try
            Return newObject
        End Function


    End Class

End Namespace
