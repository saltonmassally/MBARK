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
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace Mbark.Sensors


    <XmlType("TaskFactories"), Serializable()> _
    Public Class SensorTaskFactoryCollectionDefinition

        ' •————————————————————————————————————————————————————————————————————————————————————————•
        ' | This class describes the auto-serializable components of SensorTaskFactoryCollection   |
        ' •————————————————————————————————————————————————————————————————————————————————————————•

        Private mCurrentInaccessibleBodyParts As New BodyPartCollection
        Private mCurrentConditions As ConditionCollectionDefinition
        Private mSensorDefinitions As SensorTypeDefinition()
        Private mFactoryDefinitions As New Collection(Of SensorTaskFactoryDefinition)
        Private mLocalizableStringsDefinition As New LocalizableStringCollectionDefinition
        Private mConditionFactories As New ConditionFactoryCollectionDefinition



        <XmlArray()> Public Property SensorDefinitions() As SensorTypeDefinition()
            Get
                Return mSensorDefinitions
            End Get
            Set(ByVal value As SensorTypeDefinition())
                mSensorDefinitions = value
            End Set
        End Property

        Public ReadOnly Property FactoryDefinitions() As Collection(Of SensorTaskFactoryDefinition)
            Get
                Return mFactoryDefinitions
            End Get
        End Property

        <XmlElement("MessageLibrary")> Public Property LocalizableStrings() As LocalizableStringCollectionDefinition
            Get
                Return mLocalizableStringsDefinition
            End Get
            Set(ByVal value As LocalizableStringCollectionDefinition)
                mLocalizableStringsDefinition = value
            End Set
        End Property

        <XmlElement("ConditionLibrary")> Public Property ConditionFactories() As ConditionFactoryCollectionDefinition
            Get
                Return mConditionFactories
            End Get
            Set(ByVal value As ConditionFactoryCollectionDefinition)
                mConditionFactories = value
            End Set
        End Property

        Public Property CurrentConditions() As ConditionCollectionDefinition
            Get
                Return mCurrentConditions
            End Get
            Set(ByVal value As ConditionCollectionDefinition)
                mCurrentConditions = value
            End Set
        End Property

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")> _
        Public Property CurrentInaccessibleBodyParts() As BodyPartCollection
            Get
                Return mCurrentInaccessibleBodyParts
            End Get
            Set(ByVal value As BodyPartCollection)
                mCurrentInaccessibleBodyParts = value
            End Set
        End Property

        Public Function CreateSensorTaskFactories() As SensorTaskFactoryCollection

            Dim factories As New SensorTaskFactoryCollection

            ' Reconstitute the localizable string library
            Dim en As IEnumerator(Of LocalizableStringDefinition) = _
                mLocalizableStringsDefinition.LocalizableStringDefinitions.GetEnumerator
            While en.MoveNext
                factories.LocalizableStringLibrary(en.Current.Name) = en.Current.CreateLocalizableString
            End While


            ' Reconstitute the library of condition factories
            factories.mConditionFactories = _
                ConditionFactories.CreateConditionFactoryCollection(factories.LocalizableStringLibrary)

            ' Create a hashtable that maps condition names to the predicate factories they support
            Dim conditionNamePrereqMap As New Dictionary(Of String, PredicateFactory)
            For i As Integer = 0 To factories.mConditionFactories.Count - 1
                Dim conditionName As String = factories.mConditionFactories(i).ConditionName
                Dim prereq As PredicateFactory = factories.mConditionFactories(i).PrerequisiteFactory

                If conditionNamePrereqMap.ContainsKey(conditionName) Then
                    ' FIXME: THis code should complain if two conditions with the same name have different prereqs.
                Else
                    conditionNamePrereqMap.Add(conditionName, prereq)
                End If


            Next

            ' Reconstitute the sensors
            For i As Integer = 0 To SensorDefinitions.Length - 1
                factories.Sensors.Add(SensorTypeDefinition.CreateSensor(SensorDefinitions(i)))
            Next

            ' Reconstitute the current conditions
            factories.mCurrentConditions = CurrentConditions.CreateConditionCollection(factories.LocalizableStringLibrary, factories.mConditionFactories)
            factories.mCurrentInaccessibleBodyParts = CurrentInaccessibleBodyParts.DeepCopy

            ' If the current conditions are missing prerequisites, then grab them from the condition factory. This 
            ' occurs if we're using an external tool to generate the XML
            '
            Dim conditionEn As IEnumerator(Of Condition) = factories.mCurrentConditions.GetConditionEnumerator
            While conditionEn.MoveNext
                Dim conditionName As String = conditionEn.Current.Name
                If conditionNamePrereqMap.ContainsKey(conditionName) Then
                    conditionEn.Current.Prerequisite = conditionNamePrereqMap(conditionName).CreatePredicate(factories.mCurrentConditions)
                End If
            End While
            



            ' Reconstitute the task factories
            For i As Integer = 0 To FactoryDefinitions.Count - 1
                factories.Add(FactoryDefinitions(i).CreateFactory(factories))
            Next

            factories.UpdateTaskMap()


            Return factories
        End Function

    End Class

End Namespace
