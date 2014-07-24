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

Imports System.Collections.Specialized
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.Windows.Forms

Imports Mbark.UI.GlobalUISettings

Namespace Mbark.Sensors

    <XmlType("RuntimeCompoundAndPredicate")> _
    Public Class CompoundAndPredicate
        Inherits CompoundPredicate

        Public Sub New()
            ' Required for deserialization
        End Sub


        Public Overrides ReadOnly Property Evaluate() As Boolean
            Get
                If PredicateFactory1 Is Nothing Or PredicateFactory2 Is Nothing Then Return False
                Return PredicateFactory1.CreatePredicate(Conditions).Evaluate AndAlso PredicateFactory2.CreatePredicate(Conditions).Evaluate
            End Get
        End Property

        Public Sub New(ByVal conditions As ConditionCollection, ByVal firstFactory As PredicateFactory, ByVal secondFactory As PredicateFactory)
            MyBase.New(conditions, firstFactory, secondFactory)
        End Sub

        Friend Overrides Function CreateDefinition() As PredicateDefinition
            Dim newDef As New CompoundAndPredicateDefinition
            newDef.Definition1 = PredicateFactory1.Definition
            newDef.Definition2 = PredicateFactory2.Definition
            MyBase.CreateDefinitionImplementation(newDef)
            Return newDef
        End Function

     
    End Class

 


    <XmlType("CompoundAndPredicate"), Serializable()> _
    Public Class CompoundAndPredicateDefinition
        Inherits CompoundPredicateDefinition

        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            Dim predicate As New CompoundAndPredicate( _
                conditions, Definition1.CreatePredicateFactory(strings), Definition2.CreatePredicateFactory(strings))
            MyBase.CreatePredicateImplementation(predicate, strings)
            Return predicate

        End Function

        

    End Class

End Namespace
