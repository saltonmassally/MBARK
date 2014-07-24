
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

Imports System.Collections.ObjectModel

Namespace Mbark.Sensors

#Region "  Capture Result Collection & (Serializable) Definition  "

    <Serializable()> Public Class CaptureResultCollectionDefinition
        Implements ICloneable

        Private mResultDefinitions As Collection(Of CaptureResultDefinition)
        Public ReadOnly Property ResultDefinitions() As Collection(Of CaptureResultDefinition)
            Get
                If mResultDefinitions Is Nothing Then mResultDefinitions = New Collection(Of CaptureResultDefinition)
                Return mResultDefinitions
            End Get
        End Property

        Public Sub New()
            ' Required for serialization
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New CaptureResultCollectionDefinition
            For i As Integer = 0 To mResultDefinitions.Count - 1
                newDef.ResultDefinitions.Add(mResultDefinitions(i))
            Next i
            Return newDef
        End Function

        Public Function DeepCopy() As CaptureResultCollectionDefinition
            Return DirectCast(Clone(), CaptureResultCollectionDefinition)
        End Function

        Public Function CreateCaptureResultCollection() As CaptureResultCollection
            Dim newResults As New CaptureResultCollection
            For i As Integer = 0 To ResultDefinitions.Count - 1
                newResults.Add(ResultDefinitions(i).CreateCaptureResult)
            Next
            Return newResults
        End Function

    End Class

#End Region

End Namespace
