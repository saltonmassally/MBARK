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

Option Strict On

Imports Mbark
Imports System.Xml.Serialization

Imports LocalizableStringProxy = Mbark.NamedProxy(Of Mbark.LocalizableString)

Namespace Mbark.Sensors

    < _
    XmlType("Predicate"), _
    XmlInclude(GetType(LiteralPredicateDefinition)), _
    XmlInclude(GetType(ConditionEqualsLiteralPredicateDefinition)), _
    XmlInclude(GetType(TargetCategoryEqualsLiteralPredicateDefinition)), _
    XmlInclude(GetType(CategoryContainedInSetPredicateDefinition)), _
    XmlInclude(GetType(SensorModalityEqualsLiteralPredicateDefinition)), _
    XmlInclude(GetType(CompoundAndPredicateDefinition)), _
    XmlInclude(GetType(CompoundOrPredicateDefinition)), _
    XmlInclude(GetType(NotPredicateDefinition)), _
    XmlInclude(GetType(LocalizableStringDefinition)), _
    Serializable() _
    > _
    Public MustInherit Class PredicateDefinition
        Implements ICloneable

        Protected Sub New()
            ' Required for deserialization
        End Sub

        Private mUnmetPrerequisiteMessageString As LocalizableStringProxy
        Public Property UnmetPrerequisiteMessageString() As LocalizableStringProxy
            Get
                Return mUnmetPrerequisiteMessageString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mUnmetPrerequisiteMessageString = value
            End Set
        End Property

        Protected Sub CloneImplementation(ByVal definition As PredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            definition.mUnmetPrerequisiteMessageString = Me.UnmetPrerequisiteMessageString
        End Sub

        Protected Sub CreatePredicateImplementation(ByVal predicate As Predicate, ByVal strings As LocalizableStringCollection)
            If predicate Is Nothing Then Throw New ArgumentNullException("predicate")
            If UnmetPrerequisiteMessageString.Name <> String.Empty Then
                predicate.UnmetPrerequisiteMessage = UnmetPrerequisiteMessageString.Dereference(strings)
            End If
        End Sub

        Public Overridable Function DeepCopy() As PredicateDefinition
            Return DirectCast(Clone(), PredicateDefinition)
        End Function

        Public MustOverride Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate

        Public MustOverride Function Clone() As Object Implements ICloneable.Clone


    End Class

End Namespace
