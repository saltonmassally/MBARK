'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
'       Ross J. Micheals (rossm@nist.gov)
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

Imports Mbark
Imports System.Runtime.Serialization
Imports System.Collections.Specialized
Imports System.Xml.Serialization

Namespace Mbark.Sensors

    <XmlType("RuntimeLiteralPredicate")> _
    Public Class LiteralPredicate
        Inherits Predicate

        Private mDefinition As New LiteralPredicateDefinition

        Friend Overrides Function CreateDefinition() As PredicateDefinition
            Dim newDef As PredicateDefinition = mDefinition.DeepCopy
            CreateDefinitionImplementation(newDef)
            Return newDef
        End Function

        Public Overrides ReadOnly Property Evaluate() As Boolean
            Get
                Return mDefinition.Value
            End Get
        End Property
        Public Sub New(ByVal value As Boolean)
            mDefinition.Value = value
        End Sub
        Public Overrides Function ToString() As String
            Return mDefinition.Value.ToString
        End Function

    End Class

    <XmlType("LiteralPredicate"), Serializable()> _
Public Class LiteralPredicateDefinition
        Inherits PredicateDefinition

        Private mValue As Boolean
        Public Property Value() As Boolean
            Get
                Return mValue
            End Get
            Set(ByVal value As Boolean)
                mValue = value
            End Set
        End Property

        Public Overrides Function Clone() As Object
            Dim newDef As New LiteralPredicateDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Protected Overloads Sub CloneImplementation(ByVal definition As LiteralPredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            MyBase.CloneImplementation(definition)
            definition.Value = Me.Value
        End Sub

        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            Dim predicate As New LiteralPredicate(Value)
            MyBase.CreatePredicateImplementation(predicate, strings)
            Return New LiteralPredicate(Value)
        End Function

    End Class

End Namespace
