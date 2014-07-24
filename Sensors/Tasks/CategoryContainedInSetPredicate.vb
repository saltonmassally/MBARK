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

Imports System.Xml.Serialization
Imports System.Collections.ObjectModel


Imports Mbark

Namespace Mbark.Sensors
		
    <XmlType("RuntimeCategoryContainedInSetPredicate")> _
    Public Class CategoryContainedInSetPredicate
        Inherits Predicate

        Private mDefinition As New CategoryContainedInSetPredicateDefinition
        Private mCategories As New Collection(Of SensorTaskCategory)
        Private mConditions As ConditionCollection

        Public Sub New()
            ' Required for serialization
        End Sub

        Public Overrides ReadOnly Property Evaluate() As Boolean
            Get
                If mConditions.ParentTask Is Nothing Then Return True
                Return mCategories.Contains(mConditions.ParentTask.TargetCategory)
            End Get
        End Property

        Public Sub New(ByVal conditions As ConditionCollection, ByVal categories As Collection(Of SensorTaskCategory))

            mConditions = conditions
            mCategories = categories
        End Sub

        Friend Overrides Function CreateDefinition() As PredicateDefinition

            ' Bind from the instance to the definition
            For i As Integer = 0 To mCategories.Count - 1
                mDefinition.Categories.Add(DirectCast(mCategories(i), SensorTaskCategory))
            Next


            Dim newDef As PredicateDefinition = mDefinition.DeepCopy
            MyBase.CreateDefinitionImplementation(newDef)
            Return newDef
        End Function

    End Class

    <XmlType("CategoryContainedInSetPredicate"), Serializable()> _
Public Class CategoryContainedInSetPredicateDefinition
        Inherits PredicateDefinition


        Private mCategories As Collection(Of SensorTaskCategory)
        Public ReadOnly Property Categories() As Collection(Of SensorTaskCategory)
            Get
                If mCategories Is Nothing Then mCategories = New Collection(Of SensorTaskCategory)
                Return mCategories
            End Get
        End Property

        Public Overrides Function Clone() As Object
            Dim newDef As New CategoryContainedInSetPredicateDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Protected Overloads Sub CloneImplementation(ByVal definition As CategoryContainedInSetPredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            MyBase.CloneImplementation(definition)
            For i As Integer = 0 To mCategories.Count - 1
                definition.mCategories.Add(mCategories(i))
            Next i
        End Sub

        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            Return New CategoryContainedInSetPredicate(conditions, Categories)
        End Function
    End Class

End Namespace
