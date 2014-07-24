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

Imports ConditionFactoryProxy = Mbark.NamedProxy(Of Mbark.Sensors.ConditionFactory)
Imports PredicateFactoryProxy = Mbark.NamedProxy(Of Mbark.Sensors.PredicateFactory)

Namespace Mbark.Sensors

    <XmlType("ConditionFactoryCollection"), Serializable()> _
   Public Class ConditionFactoryCollectionDefinition
        Implements ICloneable

        <XmlElement("EquivalenceClasses")> _
        Public EquivalenceClassFactoryDefinitions() As PredicateFactoryDefinition
        <XmlElement("Factory")> _
        Public FactoryDefinitions() As ConditionFactoryDefinition

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New ConditionFactoryCollectionDefinition

            If EquivalenceClassFactoryDefinitions Is Nothing Then
                EquivalenceClassFactoryDefinitions = New PredicateFactoryDefinition() {}
            End If

            ReDim newDef.EquivalenceClassFactoryDefinitions(EquivalenceClassFactoryDefinitions.Length - 1)
            For i As Integer = 0 To EquivalenceClassFactoryDefinitions.Length - 1
                newDef.EquivalenceClassFactoryDefinitions(i) = EquivalenceClassFactoryDefinitions(i).DeepCopy
            Next

            If FactoryDefinitions Is Nothing Then
                FactoryDefinitions = New ConditionFactoryDefinition() {}
            End If

            ReDim newDef.FactoryDefinitions(FactoryDefinitions.Length - 1)
            For i As Integer = 0 To FactoryDefinitions.Length - 1
                newDef.FactoryDefinitions(i) = FactoryDefinitions(i).DeepCopy()
            Next
            Return newDef
        End Function

        Public Function DeepCopy() As ConditionFactoryCollectionDefinition
            Return DirectCast(Clone(), ConditionFactoryCollectionDefinition)
        End Function

        Public Function CreateConditionFactoryCollection(ByVal strings As LocalizableStringCollection) As ConditionFactoryCollection
            Dim factories As New ConditionFactoryCollection

            ' Empty arrays appear to deserialize to Nothing
            If FactoryDefinitions Is Nothing Then
                FactoryDefinitions = New ConditionFactoryDefinition() {}
            End If

            If EquivalenceClassFactoryDefinitions Is Nothing Then
                EquivalenceClassFactoryDefinitions = New PredicateFactoryDefinition() {}
            End If

            For i As Integer = 0 To FactoryDefinitions.Length - 1
                factories.Add(FactoryDefinitions(i).CreateConditionFactory(strings))
            Next

            For i As Integer = 0 To EquivalenceClassFactoryDefinitions.Length - 1
                factories.AddEquivalenceClassFactory(EquivalenceClassFactoryDefinitions(i).CreatePredicateFactory(strings))
            Next


            Return factories

        End Function

    End Class

    <XmlType("ConditionFactoryProxies"), Serializable()> _
    Public Class ConditionFactoryProxyCollectionDefinition
        Implements ICloneable

        <XmlElement("EquivalenceClasses")> _
        Public EquivalenceClassProxies() As PredicateFactoryProxy = {}
        <XmlElement("FactoryProxies")> _
        Public ConditionFactoryProxies() As ConditionFactoryProxy = {}

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New ConditionFactoryProxyCollectionDefinition

            If EquivalenceClassProxies Is Nothing Then
                EquivalenceClassProxies = New PredicateFactoryProxy() {}
            End If

            ReDim newDef.EquivalenceClassProxies(EquivalenceClassProxies.Length - 1)
            For i As Integer = 0 To EquivalenceClassProxies.Length - 1
                newDef.EquivalenceClassProxies(i) = EquivalenceClassProxies(i)
            Next

            If ConditionFactoryProxies Is Nothing Then
                ConditionFactoryProxies = New ConditionFactoryProxy() {}
            End If

            ReDim newDef.ConditionFactoryProxies(ConditionFactoryProxies.Length - 1)
            For i As Integer = 0 To ConditionFactoryProxies.Length - 1
                newDef.ConditionFactoryProxies(i) = ConditionFactoryProxies(i)
            Next
            Return newDef
        End Function

        Public Function DeepCopy() As ConditionFactoryProxyCollectionDefinition
            Return DirectCast(Clone(), ConditionFactoryProxyCollectionDefinition)
        End Function

        Public Function CreateConditionFactoryCollection(ByVal strings As LocalizableStringCollection, ByVal factoryLibrary As ConditionFactoryCollection) As ConditionFactoryCollection
            Dim factories As New ConditionFactoryCollection
            For i As Integer = 0 To ConditionFactoryProxies.Length - 1
                factories.Add(ConditionFactoryProxies(i).Dereference(factoryLibrary))
            Next

            If EquivalenceClassProxies IsNot Nothing Then
                For i As Integer = 0 To EquivalenceClassProxies.Length - 1
                    Dim equivalenceClass As PredicateFactory = EquivalenceClassProxies(i).Dereference(factoryLibrary.EquivalenceClasses)
                    factories.AddEquivalenceClassFactory(equivalenceClass)
                Next
            End If


            Return factories

        End Function

    End Class

End Namespace
