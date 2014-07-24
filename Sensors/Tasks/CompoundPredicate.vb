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

    <XmlType("RuntimeCompoundPredicate")> _
    Public MustInherit Class CompoundPredicate
        Inherits Predicate

        Protected Sub New()
            ' Forbid construction of abstract class
        End Sub

        Private mConditions As ConditionCollection
        Private mFactory1 As PredicateFactory
        Private mFactory2 As PredicateFactory

        Protected ReadOnly Property Conditions() As ConditionCollection
            Get
                Return mConditions
            End Get
        End Property

        Public ReadOnly Property PredicateFactory1() As PredicateFactory
            Get
                Return mFactory1
            End Get
        End Property

        Public ReadOnly Property PredicateFactory2() As PredicateFactory
            Get
                Return mFactory2
            End Get
        End Property

        Protected Sub New(ByVal conditions As ConditionCollection, ByVal factory1 As PredicateFactory, ByVal factory2 As PredicateFactory)

            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            If factory1 Is Nothing Then Throw New ArgumentNullException("factory1")
            If factory2 Is Nothing Then Throw New ArgumentNullException("factory2")

            mConditions = conditions
            mFactory1 = factory1
            mFactory2 = factory2
        End Sub

        Friend MustOverride Overrides Function CreateDefinition() As PredicateDefinition

    End Class


    Public MustInherit Class CompoundPredicateDefinition
        Inherits PredicateDefinition
        Private mDefinition1 As PredicateFactoryDefinition
        Private mDefinition2 As PredicateFactoryDefinition

        Protected Sub New()

        End Sub

        Public Property Definition1() As PredicateFactoryDefinition
            Get
                Return mDefinition1
            End Get
            Set(ByVal value As PredicateFactoryDefinition)
                mDefinition1 = value
            End Set
        End Property
        Public Property Definition2() As PredicateFactoryDefinition
            Get
                Return mDefinition2
            End Get
            Set(ByVal value As PredicateFactoryDefinition)
                mDefinition2 = value
            End Set
        End Property

        Public Overrides Function Clone() As Object
            Dim newDef As New CompoundOrPredicateDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Protected Overloads Sub CloneImplementation(ByVal definition As CompoundPredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            MyBase.CloneImplementation(definition)
            definition.Definition1 = Definition1
            definition.Definition2 = Definition2
        End Sub

        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            Throw New TrespassingException()
        End Function

    End Class


End Namespace
