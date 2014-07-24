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
Imports System

Namespace Mbark.Sensors

    <XmlType("RuntimeNotPredicate")> _
    Public Class NotPredicate
        Inherits Predicate

        Protected Sub New()
            ' Forbid construction of abstract class
        End Sub

        Private mConditions As ConditionCollection
        Private mFactoryToNegate As PredicateFactory

        Protected ReadOnly Property Conditions() As ConditionCollection
            Get
                Return mConditions
            End Get
        End Property

        Public ReadOnly Property TargetFactoryToNegate() As PredicateFactory
            Get
                Return mFactoryToNegate
            End Get
        End Property

        Public Sub New(ByVal conditions As ConditionCollection, ByVal factoryToNegate As PredicateFactory)

            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            If factoryToNegate Is Nothing Then Throw New ArgumentNullException("factory")

            mConditions = conditions
            mFactoryToNegate = factoryToNegate

        End Sub

        Friend Overrides Function CreateDefinition() As PredicateDefinition
            Dim newDef As New NotPredicateDefinition
            newDef.DefinitionToNegate = TargetFactoryToNegate.Definition
            MyBase.CreateDefinitionImplementation(newDef)
            Return newDef

        End Function

        Public Overrides ReadOnly Property Evaluate() As Boolean
            Get
                Return Not mFactoryToNegate.CreatePredicate(Conditions).Evaluate
            End Get
        End Property
    End Class


    <XmlType("NotPredicate"), Serializable()> _
    Public Class NotPredicateDefinition
        Inherits PredicateDefinition

        Private mDefinitionToNegate As PredicateFactoryDefinition


        Public Property DefinitionToNegate() As PredicateFactoryDefinition
            Get
                Return mDefinitionToNegate
            End Get
            Set(ByVal value As PredicateFactoryDefinition)
                mDefinitionToNegate = value
            End Set
        End Property

        Public Overrides Function Clone() As Object
            Dim newDef As New NotPredicateDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Protected Overloads Sub CloneImplementation(ByVal definition As NotPredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            MyBase.CloneImplementation(definition)
            definition.DefinitionToNegate = Me.DefinitionToNegate
        End Sub


        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            Dim predicate As New NotPredicate(conditions, DefinitionToNegate.CreatePredicateFactory(strings))
            MyBase.CreatePredicateImplementation(predicate, strings)
            Return predicate
        End Function

    End Class


End Namespace
