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

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Xml.Serialization


Imports ConditionFactoryProxy = Mbark.NamedProxy(Of Mbark.sensors.ConditionFactory)
Imports PredicateFactoryProxy = Mbark.NamedProxy(Of Mbark.Sensors.PredicateFactory)

Namespace Mbark.Sensors


    <XmlType("RuntimeConditionFactoryCollection")> _
    Public Class ConditionFactoryCollection
        Inherits Collection(Of ConditionFactory)
        Implements INameQueryable(Of ConditionFactory)
        Implements INameQueryable(Of PredicateFactory)

        Private mEquivalenceClassFactories As New PredicateFactoryCollection

        Public Function CreateDefinition() As ConditionFactoryCollectionDefinition
            Dim def As New ConditionFactoryCollectionDefinition

            ReDim def.EquivalenceClassFactoryDefinitions(mEquivalenceClassFactories.Count - 1)
            For i As Integer = 0 To mEquivalenceClassFactories.Count - 1
                def.EquivalenceClassFactoryDefinitions(i) = mEquivalenceClassFactories(i).Definition
            Next

            ReDim def.FactoryDefinitions(MyBase.Count - 1)
            For i As Integer = 0 To MyBase.Count - 1
                def.FactoryDefinitions(i) = MyBase.Item(i).CreateDefinition()
            Next
            Return def
        End Function

        Public Function CreateProxyDefinition() As ConditionFactoryProxyCollectionDefinition

            Dim def As New ConditionFactoryProxyCollectionDefinition
            ReDim def.EquivalenceClassProxies(mEquivalenceClassFactories.Count - 1)
            For i As Integer = 0 To mEquivalenceClassFactories.Count - 1
                def.EquivalenceClassProxies(i) = New PredicateFactoryProxy(mEquivalenceClassFactories(i))
            Next

            ReDim def.ConditionFactoryProxies(MyBase.Count - 1)
            For i As Integer = 0 To MyBase.Count - 1
                def.ConditionFactoryProxies(i) = New ConditionFactoryProxy(MyBase.Item(i))
            Next

            Return def
        End Function

        Public Function CreateConditionCollection() As ConditionCollection
            Dim conditions As New ConditionCollection
            For i As Integer = 0 To MyBase.Count - 1
                Dim factory As ConditionFactory = Item(i)
                conditions(factory.ConditionName) = factory.Create(conditions)
            Next
            For i As Integer = 0 To mEquivalenceClassFactories.Count - 1
                Dim factory As PredicateFactory = mEquivalenceClassFactories(i)
                conditions.AddEquivalenceClass(factory)
            Next
            Return conditions
        End Function

        Public Shared Function Create(ByVal definition As ConditionFactoryCollectionDefinition, ByVal strings As LocalizableStringCollection) As ConditionFactoryCollection
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            Dim newFactories As New ConditionFactoryCollection

            For i As Integer = 0 To definition.FactoryDefinitions.Length - 1
                newFactories.Add(definition.FactoryDefinitions(i).CreateConditionFactory(strings))
            Next

            For i As Integer = 0 To definition.EquivalenceClassFactoryDefinitions.Length - 1
                newFactories.AddEquivalenceClassFactory(definition.EquivalenceClassFactoryDefinitions(i).CreatePredicateFactory(strings))
            Next


            Return newFactories

        End Function

        Public Sub AddEquivalenceClassFactory(ByVal factory As PredicateFactory)
            mEquivalenceClassFactories.Add(factory)
        End Sub

        Public Function ContainsEquivalenceClass(ByVal item As PredicateFactory) As Boolean
            Return mEquivalenceClassFactories.Contains(item)
        End Function

        Public Function ConditionByName(ByVal name As String) As ConditionFactory Implements INameQueryable(Of ConditionFactory).ByName
            Dim found As ConditionFactory = Nothing
            For i As Integer = 0 To MyBase.Count - 1
                If MyBase.Item(i).FactoryName = name Then
                    found = Item(i)
                End If
            Next
            If found Is Nothing Then
                Throw New BadProxyException(Me.GetType, name)
            End If

            Return found
        End Function

        Public Function EquivalenceClassByName(ByVal name As String) As PredicateFactory Implements INameQueryable(Of PredicateFactory).ByName
            Dim found As PredicateFactory = Nothing
            For i As Integer = 0 To mEquivalenceClassFactories.Count - 1
                If mEquivalenceClassFactories.Item(i).Name = name Then
                    found = mEquivalenceClassFactories.Item(i)
                End If
            Next
            If found Is Nothing Then Throw New BadProxyException(Me.GetType, name)
            Return found
        End Function

        Public ReadOnly Property EquivalenceClasses() As PredicateFactoryCollection
            Get
                Return mEquivalenceClassFactories
            End Get
        End Property




    End Class


End Namespace