Imports Mbark
Imports System.Runtime.Serialization
Imports System.Collections.Specialized
Imports System.Xml.Serialization

Namespace Mbark.Sensors

    <XmlType("RuntimeCompoundAndPredicate")> _
    Public Class CompoundOrPredicate
        Inherits CompoundPredicate

        Public Overrides ReadOnly Property Evaluate() As Boolean
            Get
                If PredicateFactory1 Is Nothing Or PredicateFactory2 Is Nothing Then Return False
                Return PredicateFactory1.CreatePredicate(Conditions).Evaluate OrElse PredicateFactory2.CreatePredicate(Conditions).Evaluate
            End Get
        End Property

        Public Sub New(ByVal conditions As ConditionCollection, ByVal firstFactory As PredicateFactory, ByVal secondFactory As PredicateFactory)
            MyBase.New(conditions, firstFactory, secondFactory)
        End Sub

        Friend Overrides Function CreateDefinition() As PredicateDefinition
            Dim newDef As New CompoundOrPredicateDefinition
            newDef.Definition1 = PredicateFactory1.Definition
            newDef.Definition2 = PredicateFactory2.Definition
            MyBase.CreateDefinitionImplementation(newDef)
            Return newDef
        End Function
    End Class

    <XmlType("CompoundOrPredicate"), Serializable()> _
    Public Class CompoundOrPredicateDefinition
        Inherits CompoundPredicateDefinition

        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            Dim predicate As New CompoundOrPredicate( _
                conditions, Definition1.CreatePredicateFactory(strings), Definition2.CreatePredicateFactory(strings))
            MyBase.CreatePredicateImplementation(predicate, strings)
            Return predicate
        End Function

    End Class


End Namespace
