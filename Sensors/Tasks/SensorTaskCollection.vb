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

Imports System.Collections.Generic
Imports System.Xml.Serialization

Namespace Mbark.Sensors

    <XmlType("RuntimeSensorTaskCollection")> Public Class SensorTaskCollection
        Inherits List(Of SensorTask)


        Friend Function CreateDefinition(ByVal stringLibrary As LocalizableStringCollection) As SensorTaskCollectionDefinition
            Dim newDef As New SensorTaskCollectionDefinition
            ReDim newDef.SensorTaskDefinitions(MyBase.Count - 1)
            For i As Integer = 0 To MyBase.Count - 1
                newDef.SensorTaskDefinitions(i) = Item(i).CreateDefinition(stringLibrary)
            Next
            Return newDef
        End Function

        Public ReadOnly Property Last() As SensorTask
            Get
                If MyBase.Count = 0 Then Return Nothing Else Return MyBase.Item(MyBase.Count - 1)
            End Get
        End Property


      
        Public ReadOnly Property IsDownloadStillNeeded() As Boolean
            Get
                For i As Integer = 0 To MyBase.Count - 1
                    For j As Integer = 0 To MyBase.Item(i).Attempts.Count - 1
                        If MyBase.Item(i).Attempts(j).NeedsDownload Then Return True
                    Next
                Next
                Return False
            End Get
        End Property

        Public ReadOnly Property HasActivatableTask() As Boolean
            Get
                For i As Integer = 0 To MyBase.Count - 1
                    If MyBase.Item(i).IsActivatable Then Return True
                Next
                Return False
            End Get
        End Property


        Public Sub PopulateSensorSet(ByVal sensors As SensorCollection, ByVal includeSensorsOfDisabledTasks As Boolean)

            If sensors Is Nothing Then Throw New ArgumentNullException("sensors")

            For i As Integer = 0 To MyBase.Count - 1

                If Not sensors.Contains(MyBase.Item(i).Sensor) Then
                    ' If the sensor is not yet in the set...

                    If includeSensorsOfDisabledTasks Then
                        ' ... and we don't care if the task is disabled ...
                        sensors.Add(MyBase.Item(i).Sensor)

                    Else
                        ' ... or we do care if the task is enabled, we check to make sure it is.
                        sensors.Add(MyBase.Item(i).Sensor)
                    End If

                End If
            Next
        End Sub

        Public ReadOnly Property FirstActivatableTask(ByVal start As Integer) As Integer
            Get
                For i As Integer = start To MyBase.Count - 1
                    If MyBase.Item(i).IsActivatable Then Return i
                Next
                Return -1
            End Get
        End Property

        Public ReadOnly Property FirstActivatableTask() As Integer
            Get
                Return FirstActivatableTask(0)
            End Get
        End Property



    End Class


End Namespace