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


    <XmlType("SensorTasks"), Serializable()> _
    Public Class SensorTaskCollectionDefinition
        Implements ICloneable

        ' •—————————————————————————————————————————————————————————————————————————————————•
        ' | This class describes the auto-serializable components of SensorTaskCollection   |
        ' •—————————————————————————————————————————————————————————————————————————————————•

        <XmlElement("Tasks")> _
        Public SensorTaskDefinitions() As SensorTaskDefinition

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New SensorTaskCollectionDefinition
            If Not SensorTaskDefinitions Is Nothing Then
                ReDim newDef.SensorTaskDefinitions(Me.SensorTaskDefinitions.Length - 1)
                For i As Integer = 0 To Me.SensorTaskDefinitions.Length - 1
                    newDef.SensorTaskDefinitions(i) = Me.SensorTaskDefinitions(i).DeepCopy
                Next
            End If
            Return newDef
        End Function

        Public Function DeepCopy() As SensorTaskCollectionDefinition
            Return DirectCast(Clone(), SensorTaskCollectionDefinition)
        End Function

        Public Function CreateSensorTaskCollection( _
            ByVal originatingFactory As SensorTaskFactory, _
            ByVal strings As LocalizableStringCollection, _
            ByVal conditionFactories As ConditionFactoryCollection) As SensorTaskCollection

            Dim tasks As New SensorTaskCollection
            If Not SensorTaskDefinitions Is Nothing Then
                For i As Integer = 0 To SensorTaskDefinitions.Length - 1
                    tasks.Add(SensorTaskDefinitions(i).CreateSensorTask(originatingFactory, strings, conditionFactories))
                Next
            End If
            Return tasks
        End Function

    End Class

End Namespace
