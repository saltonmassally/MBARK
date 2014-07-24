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
Imports System.Collections.ObjectModel

Namespace Mbark.Sensors

    <XmlType("TaskFactory"), Serializable()> _
  Public Class SensorTaskFactoryDefinition
        Implements ICloneable

#Region "Private"
        Private mFriendlyName As String = String.Empty
        Private mCategory As SensorTaskCategory
        Private mTaskCount As Integer = 1
        Private mSensorConfiguration As SensorConfiguration
        Private mReassignableCategoriesDefinition As New SensorTaskCategoryCollectionDefinition

        <XmlElement("TargetConditions")> Public TargetConditionFactoryProxies As New ConditionFactoryProxyCollectionDefinition
        <XmlElement("GeneratedTasks")> Public GeneratedTasksDefinition As New SensorTaskCollectionDefinition
        <XmlElement("DisplayColors")> Public ColorDefinitions As SensorTaskColorsDefinition
        <XmlElement("SensorType")> Public SensorTypeDefinitionString As String
        <XmlElement("TaskPrerequisite")> Public PrerequisiteDefinition As PredicateFactoryDefinition
#End Region

   
        Public Property Category() As SensorTaskCategory
            Get
                Return mCategory
            End Get
            Set(ByVal value As SensorTaskCategory)
                mCategory = value
            End Set
        End Property
        Public Property TaskCount() As Integer
            Get
                Return mTaskCount
            End Get
            Set(ByVal value As Integer)
                mTaskCount = value
            End Set
        End Property
        Public Property SensorConfiguration() As SensorConfiguration
            Get
                Return mSensorConfiguration
            End Get
            Set(ByVal value As SensorConfiguration)
                mSensorConfiguration = value
            End Set
        End Property
        <XmlElement("ReassignableCategories")> Public Property ReassignableCategoriesDefinition() As SensorTaskCategoryCollectionDefinition
            Get
                Return mReassignableCategoriesDefinition
            End Get
            Set(ByVal value As SensorTaskCategoryCollectionDefinition)
                mReassignableCategoriesDefinition = value
            End Set
        End Property
        '<XmlElement("ConditionFactories")> Public Property ConditionFactoryDefinitions() As ConditionFactoryCollectionDefinition
        '    Get
        '        Return mConditionFactoryDefinitions
        '    End Get
        '    Set(ByVal value As ConditionFactoryCollectionDefinition)
        '        mConditionFactoryDefinitions = value
        '    End Set
        'End Property

        Public Function Clone() As Object Implements ICloneable.Clone
            Dim newDef As New SensorTaskFactoryDefinition
            'newDef.FriendlyName = FriendlyName

            newDef.Category = Category
            newDef.ReassignableCategoriesDefinition = ReassignableCategoriesDefinition.DeepCopy

            newDef.TargetConditionFactoryProxies = TargetConditionFactoryProxies.DeepCopy

            newDef.GeneratedTasksDefinition = GeneratedTasksDefinition.DeepCopy
            newDef.TaskCount = TaskCount
            If ColorDefinitions IsNot Nothing Then 
                newDef.ColorDefinitions = ColorDefinitions.DeepCopy
            End If

            newDef.SensorTypeDefinitionString = SensorTypeDefinitionString

            If Not PrerequisiteDefinition Is Nothing Then
                newDef.PrerequisiteDefinition = PrerequisiteDefinition.DeepCopy
            End If

            If Not SensorConfiguration Is Nothing Then
                newDef.SensorConfiguration = SensorConfiguration.DeepCopy
            End If

            Return newDef
        End Function

        Public Function DeepCopy() As SensorTaskFactoryDefinition
            Return DirectCast(Clone(), SensorTaskFactoryDefinition)
        End Function

        Public Function CreateFactory(ByVal parentSensorTaskFactories As SensorTaskFactoryCollection) As SensorTaskFactory

            If parentSensorTaskFactories Is Nothing Then Throw New ArgumentNullException("parentSensorTaskFactories")

            Dim factory As New SensorTaskFactory
            With factory
                .mDefinition = Me.DeepCopy()
                .mParentSensorTaskFactories = parentSensorTaskFactories

                ' First, restore the string library, since reconsitutugint the prereq needs them
                Dim strings As LocalizableStringCollection = .mParentSensorTaskFactories.LocalizableStringLibrary

                ' Reconstitute the condition factories from the library of factories held by our parent collection
                factory.mConditionFactories = .mDefinition.TargetConditionFactoryProxies.CreateConditionFactoryCollection(strings, .mParentSensorTaskFactories.ConditionFactoryLibrary)

                If Not PrerequisiteDefinition Is Nothing Then
                    '.mPrerequisiteFactory = PrerequisiteDefinition.CreatePredicateFactory(strings).CreatePredicate(parentSensorTaskFactories.CurrentConditions)
                    .mPrerequisiteFactory = PrerequisiteDefinition.CreatePredicateFactory(strings)
                    .mPrerequisiteConditionsCollection = parentSensorTaskFactories.CurrentConditions
                End If


                ' We *must* restore the sensor before creating the task collection (which needs this data)
                .mSensor = parentSensorTaskFactories.Sensors.ByDefinitionString(SensorTypeDefinitionString)
                .mGeneratedTasks = GeneratedTasksDefinition.CreateSensorTaskCollection(factory, strings, .mParentSensorTaskFactories.ConditionFactoryLibrary)
                .mReassignableCategories = ReassignableCategoriesDefinition.CreateTaskCategoryCollection()

                If ColorDefinitions Is Nothing Then
                    .mColors = Builtins.SensorTaskColorSchemes.Blue
                Else
                    .mColors = ColorDefinitions.CreateSensorTaskColors
                End If

            End With

            Return factory
        End Function

    End Class


End Namespace
