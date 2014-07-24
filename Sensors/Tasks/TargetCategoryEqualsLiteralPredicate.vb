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


Imports System.Collections.Specialized
Imports System.Runtime.Serialization
Imports System.Xml.Serialization

Imports Mbark

Namespace Mbark.Sensors

    Public Class TargetCategoryEqualsLiteralPredicate
        Inherits Predicate

        Private mConditions As ConditionCollection
        Private mDefinition As New TargetCategoryEqualsLiteralPredicateDefinition

        Public Overrides ReadOnly Property Evaluate() As Boolean
            Get
                ' Without a parent, the category is irrelevant. 
                If mConditions.ParentTask Is Nothing Then Return True
                Return mConditions.ParentTask.TargetCategory = mDefinition.SoughtCategory
            End Get
        End Property

        Public Sub New(ByVal conditions As ConditionCollection, ByVal soughtCategory As SensorTaskCategory)
            mConditions = conditions
            mDefinition.SoughtCategory = soughtCategory
        End Sub

        Friend Overrides Function CreateDefinition() As PredicateDefinition
            Dim newDef As PredicateDefinition = mDefinition.DeepCopy
            CreateDefinitionImplementation(newDef)
            Return newDef
        End Function
    End Class


    <XmlType("CategoryEqualsLiteralPredicate"), Serializable()> _
    Public Class TargetCategoryEqualsLiteralPredicateDefinition
        Inherits PredicateDefinition

        Private mSoughtCategory As SensorTaskCategory
        Public Property SoughtCategory() As SensorTaskCategory
            Get
                Return mSoughtCategory
            End Get
            Set(ByVal value As SensorTaskCategory)
                mSoughtCategory = value
            End Set
        End Property

        Public Overrides Function Clone() As Object
            Dim newDef As New TargetCategoryEqualsLiteralPredicateDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Protected Overloads Sub CloneImplementation(ByVal definition As TargetCategoryEqualsLiteralPredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            MyBase.CloneImplementation(definition)
            definition.SoughtCategory = SoughtCategory
        End Sub


        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            Dim predicate As New TargetCategoryEqualsLiteralPredicate(conditions, SoughtCategory)
            MyBase.CreatePredicateImplementation(predicate, strings)
            Return predicate
        End Function
    End Class



End Namespace
