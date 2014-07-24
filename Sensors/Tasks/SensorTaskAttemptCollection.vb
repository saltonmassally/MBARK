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
Imports System.Collections.ObjectModel

Namespace Mbark.Sensors

    <XmlType("RuntimeSensorTaskAttemptCollection")> _
    Public Class SensorTaskAttemptCollection
        Inherits Collection(Of SensorTaskAttempt)

        Friend Function CreateDefinition(ByVal parentTask As SensorTask, ByVal strings As LocalizableStringCollection) As SensorTaskAttemptCollectionDefinition

            mParentTask = parentTask

            Dim newDef As New SensorTaskAttemptCollectionDefinition
            ReDim newDef.AttemptDefinitions(MyBase.Count - 1)

            For i As Integer = 0 To MyBase.Count - 1
                newDef.AttemptDefinitions(i) = Item(i).CreateDefinition(parentTask, strings)
            Next

            Return newDef
        End Function

        Private mParentTask As SensorTask

        Public Overloads Function IndexOf(ByVal attempt As SensorTaskAttempt) As Integer
            If MyBase.IndexOf(attempt) = -1 Then
                For i As Integer = 0 To MyBase.Count - 1
                    ' We must use Item(i) instead of mAttempts(i) to trigger the overload
                    If Item(i).Equals(attempt) Then Return i
                Next
            Else
                Return MyBase.IndexOf(attempt)
            End If
            Return -1
        End Function

        Public ReadOnly Property AttemptsWithThumbnails() As Integer
            Get
                Dim count As Integer
                For i As Integer = 0 To MyBase.Count - 1
                    If Not Item(i).ThumbnailImage Is Nothing Then count += 1
                Next
                Return count
            End Get
        End Property

        Public Overloads Sub Insert(ByVal index As Integer, ByVal attempt As SensorTaskAttempt)
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")
            If attempt.ParentTask Is Nothing Then Debugging.Break()
            attempt.WireParentTask(mParentTask)

            ' If the task was unstarted, it's suspended now
            If mParentTask.Status = SensorTaskStatus.Unstarted Then mParentTask.Status = SensorTaskStatus.Suspended
            MyBase.Insert(index, attempt)
        End Sub

        Public Overloads Sub Add(ByVal attempt As SensorTaskAttempt)
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")
            Insert(MyBase.Count, attempt)
        End Sub


        Public Overloads Sub Remove(ByVal attempt As SensorTaskAttempt)
            MyBase.Remove(attempt)

            ' If the task was finished, it's now suspended
            If MyBase.Count = 0 AndAlso mParentTask.Status = SensorTaskStatus.Done Then mParentTask.Status = SensorTaskStatus.Suspended
        End Sub



        Public Sub New(ByVal parentTask As SensorTask)
            mParentTask = parentTask
        End Sub


    End Class

    <XmlType("Attempts"), Serializable()> _
    Public Class SensorTaskAttemptCollectionDefinition
        Implements ICloneable

        Private mAttemptDefinitions() As SensorTaskAttemptDefinition
        <XmlElement("Attempt")> Property AttemptDefinitions() As SensorTaskAttemptDefinition()
            Get
                If mAttemptDefinitions Is Nothing Then
                    mAttemptDefinitions = New SensorTaskAttemptDefinition() {}
                End If
                Return mAttemptDefinitions
            End Get
            Set(ByVal value As SensorTaskAttemptDefinition())
                mAttemptDefinitions = value
            End Set
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New SensorTaskAttemptCollectionDefinition
            ReDim newDef.AttemptDefinitions(AttemptDefinitions.Length - 1)
            For i As Integer = 0 To AttemptDefinitions.Length - 1
                newDef.AttemptDefinitions(i) = AttemptDefinitions(i).DeepCopy
            Next
            Return newDef
        End Function

        Public Function DeepCopy() As SensorTaskAttemptCollectionDefinition
            Return DirectCast(Clone(), SensorTaskAttemptCollectionDefinition)
        End Function

        Public Function CreateSensorTaskAttemptCollection( _
            ByVal parentTask As SensorTask, _
            ByVal strings As LocalizableStringCollection, _
            ByVal conditionFactories As ConditionFactoryCollection) _
            As SensorTaskAttemptCollection
            Dim attempts As New SensorTaskAttemptCollection(parentTask)
            For i As Integer = 0 To AttemptDefinitions.Length - 1
                attempts.Add(AttemptDefinitions(i).CreateTaskAttempt(parentTask, strings, conditionFactories))
            Next
            Return attempts
        End Function

    End Class

End Namespace
