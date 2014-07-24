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
Imports System.ComponentModel

Namespace Mbark.Sensors

    Public Class SensorTaskFactory

        Friend mDefinition As New SensorTaskFactoryDefinition
        Friend mReassignableCategories As New SensorTaskCategoryCollection
        Friend mParentSensorTaskFactories As SensorTaskFactoryCollection

        Friend mPrerequisite As Predicate
        Friend mPrerequisiteFactory As PredicateFactory
        Friend mPrerequisiteConditionsCollection As ConditionCollection

        Friend mConditionFactories As New ConditionFactoryCollection
        Friend mGeneratedTasks As New SensorTaskCollection

        Friend mSensor As ISensor
        Friend mColors As SensorTaskColors


        Friend Function CreateDefinition(ByVal strings As LocalizableStringCollection, ByVal prerequisiteScope As ConditionFactoryCollection) As SensorTaskFactoryDefinition


            Dim newdef As SensorTaskFactoryDefinition = mDefinition.DeepCopy

            If mPrerequisiteFactory IsNot Nothing Then newdef.PrerequisiteDefinition = mPrerequisiteFactory.Definition
            With newdef
                .TargetConditionFactoryProxies = mConditionFactories.CreateProxyDefinition
                .GeneratedTasksDefinition = mGeneratedTasks.CreateDefinition(strings)
                .ReassignableCategoriesDefinition = ReassignableSensorTaskCategories.CreateDefinition
                .SensorTypeDefinitionString = SensorTypeDefinition.CreateDefinition(mSensor).ToString
                .ColorDefinitions = mColors.Definition
            End With

            Return newdef
        End Function


        Friend Sub WireParentSensorTaskFactories(ByVal factories As SensorTaskFactoryCollection)
            mParentSensorTaskFactories = factories
        End Sub

        Friend ReadOnly Property ParentSensorTaskFactories() As SensorTaskFactoryCollection
            Get
                Return mParentSensorTaskFactories
            End Get
        End Property

        Public ReadOnly Property ReassignableSensorTaskCategories() As SensorTaskCategoryCollection
            Get
                Return mReassignableCategories
            End Get
        End Property

        Public Property Colors() As SensorTaskColors
            Get
                Return mColors
            End Get
            Set(ByVal value As SensorTaskColors)
                mColors = value
            End Set
        End Property

        Public Property Sensor() As ISensor
            Get
                Return mSensor
            End Get
            Set(ByVal value As ISensor)
                mSensor = value
            End Set
        End Property

        Public Property PrerequisiteFactory() As PredicateFactory
            Get
                Return mPrerequisiteFactory
            End Get
            Set(ByVal value As PredicateFactory)
                mPrerequisiteFactory = value
            End Set

        End Property
        Public ReadOnly Property Prerequisite() As Predicate
            Get
                If mPrerequisiteFactory Is Nothing Then Return Builtins.Predicates.TrueLiteral

                If mPrerequisite Is Nothing Then
                    mPrerequisite = mPrerequisiteFactory.CreatePredicate(mPrerequisiteConditionsCollection)
                End If
                Return mPrerequisite
            End Get
        End Property

        Public Property TaskCount() As Integer
            Get
                Return mDefinition.TaskCount
            End Get
            Set(ByVal value As Integer)
                mDefinition.TaskCount = value
            End Set
        End Property

        Public ReadOnly Property GeneratedTasks() As SensorTaskCollection
            Get
                Return mGeneratedTasks
            End Get
        End Property

        Public ReadOnly Property ConditionFactories() As ConditionFactoryCollection
            Get
                Return mConditionFactories
            End Get
        End Property

        Public Property Category() As SensorTaskCategory
            Get
                Return mDefinition.Category
            End Get
            Set(ByVal value As SensorTaskCategory)
                mDefinition.Category = value
            End Set
        End Property

        Public Property SensorConfiguration() As SensorConfiguration
            Get
                Return mDefinition.SensorConfiguration
            End Get
            Set(ByVal value As SensorConfiguration)
                mDefinition.SensorConfiguration = value
            End Set
        End Property

        Public ReadOnly Property SatisfactoryTaskCount() As Integer
            Get
                Dim count As Integer

                ' Build a set of conditions to test with
                Dim testConditions As ConditionCollection = ConditionFactories.CreateConditionCollection()

                For i As Integer = 0 To mGeneratedTasks.Count - 1
                    Dim task As SensorTask = mGeneratedTasks(i)
                    If task.TargetCategory = Category AndAlso task.Conditions.EqualsSubset(testConditions) Then
                        count += 1
                    End If

                Next
                Return count
            End Get
        End Property


        Public Sub AddExtraTask(ByVal currentConditions As ConditionCollection, ByVal currentInaccessibleParts As BodyPartCollection)
            Dim oldTaskCount As Integer = TaskCount
            TaskCount = GeneratedTasks.Count + 1
            PopulateTargets(currentConditions, currentInaccessibleParts)
            TaskCount = oldTaskCount
        End Sub

        Public Sub TrimExcessTasks()

            Dim toRemove As Integer = Math.Max(0, GeneratedTasks.Count - TaskCount)
            If toRemove = 0 Then Return

            Dim excessTasks As New Collection(Of SensorTask)

            ' Mark those tasks that can be removed
            For i As Integer = 0 To GeneratedTasks.Count - 1
                If GeneratedTasks(i).IsExcess AndAlso GeneratedTasks(i).Attempts.Count = 0 Then
                    excessTasks.Add(GeneratedTasks(i))
                End If
            Next

            ' Remove those tasks
            For i As Integer = 0 To excessTasks.Count - 1
                GeneratedTasks.Remove(excessTasks(i))
            Next


        End Sub

        Public Sub PopulateTargets(ByVal currentConditions As ConditionCollection, ByVal currentInaccessibleParts As BodyPartCollection)

            If currentConditions Is Nothing Then Throw New ArgumentNullException("currentConditions")
            If currentInaccessibleParts Is Nothing Then Throw New ArgumentNullException("currentInaccessibleParts")

            Dim satisfactoryCount As Integer = SatisfactoryTaskCount
            Dim toCreate As Integer = TaskCount - satisfactoryCount - 1


            For i As Integer = 0 To toCreate
                Dim task As New SensorTask

                task.TargetCategory = Category
                task.Sensor = Sensor
                task.Colors = Colors
                task.TargetInaccessibleParts.Assign(currentInaccessibleParts) ' CHECK: Deep copy required here?
                task.WireOriginatingFactory(Me)
                task.PopulateConditions()
                task.Conditions.WireParentTask(task)
                If Not SensorConfiguration Is Nothing Then task.SensorConfiguration = SensorConfiguration.DeepCopy
                GeneratedTasks.Add(task)
            Next

            For i As Integer = 0 To GeneratedTasks.Count - 1

                Dim task As SensorTask = GeneratedTasks(i)
                task.TargetInaccessibleParts.AddEachPartIfContainedInOtherSet( _
                    task.TargetParts, currentInaccessibleParts)
                task.TargetInaccessibleParts.RemoveEachPartIfNotContainedInOtherSet( _
                        currentInaccessibleParts, task.TargetParts)
            Next

            Return

        End Sub

        Public Sub Clear()
            GeneratedTasks.Clear()
        End Sub

        'Mainly use for changing status for skipping or not skipping
        Public Sub ChangeAllTaskStatus(ByVal newStatus As SensorTaskStatus)
            With mGeneratedTasks
                For i As Integer = 0 To .Count - 1
                    If newStatus = SensorTaskStatus.Skipped Then
                        If .Item(i).IsSkippable() Then mGeneratedTasks.Item(i).Status = newStatus
                    ElseIf newStatus = SensorTaskStatus.Unstarted Then
                        If .Item(i).Status = SensorTaskStatus.Skipped Then mGeneratedTasks.Item(i).Status = newStatus
                    End If
                Next
            End With
        End Sub

        
    End Class

End Namespace
