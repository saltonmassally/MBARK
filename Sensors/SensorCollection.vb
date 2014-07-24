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

Namespace Mbark.Sensors

    Public Class SensorCollection
        Inherits List(Of ISensor)


        Public Overloads Sub Add(ByVal sensor As ISensor)
            If Not Contains(sensor) Then MyBase.Add(sensor)
        End Sub

        Public ReadOnly Property ByDefinitionString(ByVal definition As String) As ISensor
            Get
                Dim byDefinitionStringResult As ISensor = Nothing

                ' Note that this is a slow way to do this
                For i As Integer = 0 To Count - 1
                    If SensorTypeDefinition.CreateDefinition(Item(i)).ToString = definition Then
                        byDefinitionStringResult = Item(i)
                        Exit For
                    End If

                Next
                Return byDefinitionStringResult
            End Get
        End Property


        Public Function RequiresRecoveryCount() As Integer
            Dim requiresRecovery As Integer = 0
            For i As Integer = 0 To Count - 1
                If Not Item(i).Disabled AndAlso Item(i).RequiresRecovery Then requiresRecovery += 1
            Next
            Return requiresRecovery
        End Function

    End Class

End Namespace
