Option Strict On

Imports Mbark
Imports System.Collections.Specialized
Imports System.Xml.Serialization

Imports LocalizableStringProxy = Mbark.NamedProxy(Of Mbark.LocalizableString)

Namespace Mbark.Sensors



    Public Enum PredicateType
        LiteralPredicate
        ConditionEqualsLiteralPredicate
        CategoryEqualsLiteralPredicate
        CategoryContainedInSetPredicate
        SensorModalityEqualsLiteralPredicate
        CompoundAndPredicate
        CompoundOrPredicate
        NotPredicate
    End Enum

    <XmlType("RuntimePredicate")> Public MustInherit Class Predicate

        Protected Sub New()
            ' Forbid construction of abstract class
        End Sub

        Private mParticipatingConditionNames As New StringCollection
        Private mUnmetPrerequisiteMessage As LocalizableString

        Friend MustOverride Function CreateDefinition() As PredicateDefinition

        Protected Sub CreateDefinitionImplementation(ByVal definition As PredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            If UnmetPrerequisiteMessage IsNot Nothing Then
                definition.UnmetPrerequisiteMessageString = New LocalizableStringProxy(UnmetPrerequisiteMessage)
            End If
        End Sub

        ' Returns a list of names of conditions participating in the predicate
        Friend ReadOnly Property ParticipatingConditionNames() As StringCollection
            Get
                Return mParticipatingConditionNames
            End Get
        End Property

        Public MustOverride ReadOnly Property Evaluate() As Boolean

        'Public Overridable ReadOnly Property Evaluate() As Boolean
        '    Get
        '        Throw New TrespassingException("Evaluate")
        '    End Get
        'End Property

        Public Overrides Function ToString() As String
            Throw New TrespassingException("ToString")
        End Function

        Public Property UnmetPrerequisiteMessage() As LocalizableString
            Get
                Return mUnmetPrerequisiteMessage
            End Get
            Set(ByVal value As LocalizableString)
                mUnmetPrerequisiteMessage = value
            End Set
        End Property


    End Class


    Public Module Support

        Public Function ExtractParticipatingConditions(ByVal factory As PredicateFactory) As StringCollection
            Dim names As New StringCollection
            RecursivelyCollectNamesOfParticipatingConditions(names, factory)
            Return names
        End Function


        Private Sub RecursivelyCollectNamesOfParticipatingConditions( _
            ByRef names As StringCollection, ByVal factory As PredicateFactory)
            If factory.PredicateType = PredicateType.CompoundOrPredicate Or _
               factory.PredicateType = PredicateType.CompoundAndPredicate Then
                Dim pf0 As PredicateFactory = DirectCast(factory.GetFactoryArgs(0), PredicateFactory)
                Dim pf1 As PredicateFactory = DirectCast(factory.GetFactoryArgs(1), PredicateFactory)

                RecursivelyCollectNamesOfParticipatingConditions(names, pf0)
                RecursivelyCollectNamesOfParticipatingConditions(names, pf1)

            ElseIf factory.PredicateType = PredicateType.ConditionEqualsLiteralPredicate Then
                Dim name As String = DirectCast(factory.GetFactoryArgs(0), String)
                If Not names.Contains(name) Then names.Add(name)
            Else
                Return
            End If

        End Sub

    End Module

End Namespace
