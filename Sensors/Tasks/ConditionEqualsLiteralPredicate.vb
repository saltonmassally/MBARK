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

Namespace Mbark.Sensors

    <XmlType("RuntimeConditionEqualsLiteralPredicate")> _
    Public Class ConditionEqualsLiteralPredicate
        Inherits Predicate

        Private mConditions As ConditionCollection
        Private mDefinition As New ConditionEqualsLiteralPredicateDefinition

        Public Overrides ReadOnly Property Evaluate() As Boolean
            Get
                If mConditions(mDefinition.ConditionName) Is Nothing Then Return False

                ' If the condition is not valid, then we don't care what it is; i.e., it is equal to any value
                If Not mConditions(mDefinition.ConditionName).IsValid Then Return True

                Return mConditions(mDefinition.ConditionName).Value.Equals(mDefinition.SoughtValue)
            End Get
        End Property

        Public Sub New(ByVal conditions As ConditionCollection, ByVal conditionName As String, ByVal soughtValue As Object)
            mConditions = conditions
            mDefinition.ConditionName = conditionName
            mDefinition.SoughtValue = soughtValue
        End Sub

        Public Overrides Function ToString() As String
            Dim c As Condition = mConditions(mDefinition.ConditionName).DeepCopy(mConditions)
            c.Value = mDefinition.SoughtValue
            Return c.StandaloneToString
        End Function

        Friend Overrides Function CreateDefinition() As PredicateDefinition
            Dim newDef As PredicateDefinition = mDefinition.DeepCopy
            MyBase.CreateDefinitionImplementation(newDef)
            Return newDef
        End Function


    End Class


    <XmlType("ConditionEqualsLiteralPredicate"), Serializable()> _
    Public Class ConditionEqualsLiteralPredicateDefinition
        Inherits PredicateDefinition

        Private mConditionName As String
        Public Property ConditionName() As String
            Get
                Return mConditionName
            End Get
            Set(ByVal Value As String)
                mConditionName = Value
            End Set
        End Property

        Private mSoughtValue As Object
        Public Property SoughtValue() As Object
            Get
                Return mSoughtValue
            End Get
            Set(ByVal Value As Object)
                mSoughtValue = Value
            End Set
        End Property

        Public Overrides Function Clone() As Object
            Dim newDef As New ConditionEqualsLiteralPredicateDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Protected Overloads Sub CloneImplementation(ByVal definition As ConditionEqualsLiteralPredicateDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            MyBase.CloneImplementation(definition)
            definition.ConditionName = ConditionName
            definition.SoughtValue = SoughtValue
        End Sub

     
        Public Overrides Function CreatePredicate(ByVal conditions As ConditionCollection, ByVal strings As LocalizableStringCollection) As Predicate
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")
            Dim predicate As ConditionEqualsLiteralPredicate = New ConditionEqualsLiteralPredicate(conditions, ConditionName, SoughtValue)
            MyBase.CreatePredicateImplementation(predicate, strings)
            Return predicate
        End Function

    End Class


End Namespace
