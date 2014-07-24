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

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Namespace Mbark.Sensors

    <XmlType("RuntimeSensorTaskFactoryCollection")> Public Class SensorTaskFactoryCollection
        Inherits Collection(Of SensorTaskFactory)

        Private mActiveTask As SensorTask
        Private mAllTasks As New SensorTaskCollection
        Private mTasksOfSensor As New Dictionary(Of ISensor, SensorTaskCollection)
        Private mSensors As New SensorCollection
        Private mLocalizableStrings As New LocalizableStringCollection

        Friend mCurrentConditions As New ConditionCollection
        Friend mCurrentInaccessibleBodyParts As New BodyPartCollection
        Friend mConditionFactories As New ConditionFactoryCollection


        Public Function SensorConfigurationTypes() As StringCollection
            Dim types As New StringCollection
            For i As Integer = 0 To MyBase.Count - 1
                Dim typeName As String = MyBase.Item(i).SensorConfiguration.GetType().FullName
                If types.IndexOf(typeName) = -1 Then types.Add(typeName)
            Next
            Return types
        End Function

        Friend Function CreateDefinition() As SensorTaskFactoryCollectionDefinition
            Dim newDef As New SensorTaskFactoryCollectionDefinition


            Dim en As IEnumerator(Of LocalizableString) = mLocalizableStrings.LocalizableStrings
            While en.MoveNext
                newDef.LocalizableStrings.Add(en.Current.CreateDefinition)
            End While

            newDef.ConditionFactories = mConditionFactories.CreateDefinition()

            ReDim newDef.SensorDefinitions(mSensors.Count - 1)
            For i As Integer = 0 To mSensors.Count - 1
                newDef.SensorDefinitions(i) = SensorTypeDefinition.CreateDefinition(mSensors(i))
            Next

            For i As Integer = 0 To MyBase.Count - 1
                newDef.FactoryDefinitions.Add(MyBase.Item(i).CreateDefinition(mLocalizableStrings, mConditionFactories))
            Next

            newDef.CurrentConditions = mCurrentConditions.CreateDefinition()
            newDef.CurrentInaccessibleBodyParts = mCurrentInaccessibleBodyParts.DeepCopy

            Return newDef
        End Function

        Public Shared Function PopulateFromStream(ByVal instream As Stream) As SensorTaskFactoryCollection

            Dim xml As New XmlDocument
            Try
                xml.Load(instream)
            Catch ex As Exception
                Debug.WriteLine("Couldn't load configuration data..." + ex.ToString)
                'Return Nothing
                Throw ex
            End Try

            Dim definitionNodes As XmlNodeList = xml.SelectNodes("//SensorDefinitions/SensorType")

            ' Get all the sensors with configuration classes, and manually create type definitions for them
            Dim configurationTypes As New Collection(Of TypeDefinition)
            Try
                For i As Integer = 0 To definitionNodes.Count - 1
                    Dim hasConfigurationClass As Boolean = CType(definitionNodes(i).SelectNodes("HasConfigurationClass")(0).InnerText, Boolean)
                    If hasConfigurationClass Then
                        Dim configurationClassname As String = definitionNodes(i).SelectNodes("ConfigurationClassName")(0).InnerText
                        Dim libraryFileName As String = definitionNodes(i).SelectNodes("LibraryFileName")(0).InnerText

                        If configurationClassname.Length = 0 Then Throw New BadDefinitionException
                        If libraryFileName.Length = 0 Then Throw New BadDefinitionException


                        Dim definition As New TypeDefinition
                        definition.LibraryFileName = libraryFileName
                        definition.ClassName = configurationClassname
                        configurationTypes.Add(definition)
                    End If
                Next


                ' Make an array of configuration class exemplars for the serializers to grok upon construction
                Dim additionalTypes(configurationTypes.Count - 1) As Type
                For i As Integer = 0 To configurationTypes.Count - 1
                    Dim def As TypeDefinition = configurationTypes(i)
                    Try
                        additionalTypes(i) = def.InstantiateObject().GetType()
                    Catch ex As IO.FileNotFoundException
                        ' If there is no such file, then try the 'Sensors' subdirectory
                        def.Subdirectory = "Sensors"
                        additionalTypes(i) = def.InstantiateObject().GetType()
                    End Try
                Next



                Dim factories As SensorTaskFactoryCollection
                'Dim definitionFile As New IO.FileStream(fileName, IO.FileMode.Open)
                Dim serializer As New XmlSerializer(GetType(SensorTaskFactoryCollectionDefinition), additionalTypes)
                'Console.WriteLine("Input stream is " + New StreamReader(instream).ReadToEnd)
                instream.Position = 0
                Dim factoriesDefinition As SensorTaskFactoryCollectionDefinition = _
                DirectCast(serializer.Deserialize(instream), SensorTaskFactoryCollectionDefinition)
                factories = factoriesDefinition.CreateSensorTaskFactories()

                ' Restore the active task (if there was one)
                For i As Integer = 0 To factories.Count - 1
                    For j As Integer = 0 To factories(i).GeneratedTasks.Count - 1
                        Dim task As SensorTask = factories(i).GeneratedTasks(j)
                        If task.Status = SensorTaskStatus.Active Then factories.mActiveTask = task
                    Next
                Next
                instream.Close()

                Return factories
            Catch ex As IO.FileNotFoundException
                Throw ex
            Catch ex As InvalidOperationException
                Throw ex
            End Try
        End Function

        'Public Shared Function LoadFromXmlFile(ByVal fileName As String) As SensorTaskFactoryCollection

        '    If fileName = String.Empty Then Return New SensorTaskFactoryCollection

        '    Dim xml As New XmlDocument
        '    Try
        '        xml.Load(fileName)
        '    Catch ex As Xml.XmlException
        '        Throw ex
        '    End Try

        '    Dim definitionNodes As XmlNodeList = xml.SelectNodes("//SensorDefinitions/SensorType")

        '    ' Get all the sensors with configuration classes, and manually create type definitions for them
        '    Dim configurationTypes As New Collection(Of TypeDefinition)
        '    Try
        '        For i As Integer = 0 To definitionNodes.Count - 1
        '            Dim hasConfigurationClass As Boolean = CType(definitionNodes(i).SelectNodes("HasConfigurationClass")(0).InnerText, Boolean)
        '            If hasConfigurationClass Then
        '                Dim configurationClassname As String = definitionNodes(i).SelectNodes("ConfigurationClassName")(0).InnerText
        '                Dim libraryFileName As String = definitionNodes(i).SelectNodes("LibraryFileName")(0).InnerText

        '                If configurationClassname.Length = 0 Then Throw New BadDefinitionException
        '                If libraryFileName.Length = 0 Then Throw New BadDefinitionException


        '                Dim definition As New TypeDefinition
        '                definition.LibraryFileName = libraryFileName
        '                definition.ClassName = configurationClassname
        '                configurationTypes.Add(definition)
        '            End If
        '        Next


        '        ' Make an array of configuration class exemplars for the serializers to grok upon construction
        '        Dim additionalTypes(configurationTypes.Count - 1) As Type
        '        For i As Integer = 0 To configurationTypes.Count - 1
        '            Dim def As TypeDefinition = configurationTypes(i)
        '            Try
        '                additionalTypes(i) = def.InstantiateObject().GetType()
        '            Catch ex As IO.FileNotFoundException
        '                ' If there is no such file, then try the 'Sensors' subdirectory 
        '                def.Subdirectory = "Sensors"
        '                additionalTypes(i) = def.InstantiateObject().GetType()
        '            End Try
        '        Next



        '        Dim factories As SensorTaskFactoryCollection
        '        Dim definitionFile As New IO.FileStream(fileName, IO.FileMode.Open)
        '        Dim serializer As New XmlSerializer(GetType(SensorTaskFactoryCollectionDefinition), additionalTypes)
        '        Dim factoriesDefinition As SensorTaskFactoryCollectionDefinition = _
        '            DirectCast(serializer.Deserialize(definitionFile), SensorTaskFactoryCollectionDefinition)
        '        factories = factoriesDefinition.CreateSensorTaskFactories()

        '        ' Restore the active task (if there was one)
        '        For i As Integer = 0 To factories.Count - 1
        '            For j As Integer = 0 To factories(i).GeneratedTasks.Count - 1
        '                Dim task As SensorTask = factories(i).GeneratedTasks(j)
        '                If task.Status = SensorTaskStatus.Active Then factories.mActiveTask = task
        '            Next
        '        Next
        '        definitionFile.Close()

        '        Return factories
        '    Catch ex As IO.FileNotFoundException
        '        Throw ex
        '    Catch ex As InvalidOperationException
        '        Throw ex
        '    End Try

        'End Function

        Public Sub SaveAsXmlFile(ByVal fileName As String)


            Dim uniqueConfigurationTypeNames As New StringCollection
            Dim exampleConfigurations As New Collection(Of SensorConfiguration)
            For i As Integer = 0 To Count - 1
                If Not MyBase.Item(i).SensorConfiguration Is Nothing Then
                    Dim typeName As String = MyBase.Item(i).SensorConfiguration.GetType().FullName
                    If uniqueConfigurationTypeNames.IndexOf(typeName) = -1 Then
                        uniqueConfigurationTypeNames.Add(typeName)
                        exampleConfigurations.Add(MyBase.Item(i).SensorConfiguration)
                    End If
                End If

            Next

            Dim typeDefs(uniqueConfigurationTypeNames.Count - 1) As TypeDefinition
            Dim types(uniqueConfigurationTypeNames.Count - 1) As Type

            For i As Integer = 0 To types.Length - 1
                typeDefs(i) = TypeDefinition.Create(exampleConfigurations(i))
                types(i) = exampleConfigurations(i).GetType
            Next


            Dim serializer As New XmlSerializer(GetType(SensorTaskFactoryCollectionDefinition), types)
            Dim factoryDefinitionFile As New IO.FileStream(fileName, IO.FileMode.OpenOrCreate)
            factoryDefinitionFile.SetLength(0)
            serializer.Serialize(factoryDefinitionFile, CreateDefinition())
            factoryDefinitionFile.Close()
            

        End Sub

        Public ReadOnly Property CurrentConditions() As ConditionCollection
            Get
                Return mCurrentConditions
            End Get
        End Property

        Public ReadOnly Property CurrentInaccessibleBodyParts() As BodyPartCollection
            Get
                Return mCurrentInaccessibleBodyParts
            End Get
        End Property

    
        Public ReadOnly Property Sensors() As SensorCollection
            Get
                Return mSensors
            End Get
        End Property



        Public ReadOnly Property LocalizableStringLibrary() As LocalizableStringCollection
            Get
                Return mLocalizableStrings
            End Get
        End Property

        Public ReadOnly Property ConditionFactoryLibrary() As ConditionFactoryCollection
            Get
                Return mConditionFactories
            End Get
        End Property

        Public ReadOnly Property ActiveTask() As SensorTask
            Get
                Return mActiveTask
            End Get
        End Property


        Public Sub PopulateTargets()
            For i As Integer = 0 To MyBase.Count - 1
                MyBase.Item(i).PopulateTargets(CurrentConditions, CurrentInaccessibleBodyParts)
            Next
            'KAYEE - Debug
            'OutputtoLog("SensorTaskFactoryCollection PopulateAllTasksList()")
            PopulateAllTasksList()
        End Sub

        Public Sub TrimExcessTasks()

            For i As Integer = 0 To MyBase.Count - 1
                MyBase.Item(i).TrimExcessTasks()
            Next
        End Sub


        Public ReadOnly Property AllTasks() As SensorTaskCollection
            Get
                Return mAllTasks
            End Get
        End Property

        Private Function SeekTaskBasedOnSensor(ByVal conditions As ConditionCollection, ByVal positiveMatch As Boolean) As SensorTask

            Dim foundTask As SensorTask = Nothing

            If ActiveTask IsNot Nothing Then

                ' There must be an active task to seek the next task for the current sensor
                For i As Integer = 0 To mTasksOfSensor(ActiveTask.Sensor).Count - 1

                    Dim task As SensorTask = mTasksOfSensor(ActiveTask.Sensor)(i)
                    Dim conditionsOK As Boolean = conditions.EqualsSubset(task.Conditions)
                    If Not positiveMatch Then conditionsOK = Not conditionsOK
                    If task.IsActivatable AndAlso conditionsOK Then
                        foundTask = task
                        Exit For
                    End If
                Next

                ' Make sure that if we found a task, that we don't cross a change in sensor
                ' should se select it
                '
                If foundTask IsNot Nothing Then

                    Dim currentTaskIndex As Integer = mAllTasks.IndexOf(ActiveTask)
                    Dim foundTaskIndex As Integer = mAllTasks.IndexOf(foundTask)
                    Dim start As Integer = Math.Min(currentTaskIndex, foundTaskIndex)
                    Dim [end] As Integer = Math.Max(currentTaskIndex, foundTaskIndex)
                    If Not TasksInRangeShareTheSameSensor(start, [end]) Then
                        foundTask = Nothing
                    End If

                End If

            End If

            Return foundTask
        End Function

        Private Function TasksInRangeShareTheSameSensor(ByVal startIndex As Integer, ByVal endIndex As Integer) As Boolean
            If startIndex = -1 OrElse endIndex = -1 Then Return False
            Dim startTask As SensorTask = mAllTasks(startIndex)
            For i As Integer = startIndex To endIndex
                If startTask.Sensor IsNot mAllTasks(i).Sensor Then Return False
            Next
            Return True

        End Function



        Private Function SeekTaskBasedOnNextIndex() As SensorTask

            Dim foundTask As SensorTask = Nothing

            If ActiveTask IsNot Nothing Then

                ' There must be an active task to check the task with the next index
                Dim currentTaskIndex As Integer = mAllTasks.IndexOf(ActiveTask)
                Dim notLastTask As Boolean = currentTaskIndex < (mAllTasks.Count - 1)
                Dim nextTaskOK As Boolean = notLastTask AndAlso mAllTasks(currentTaskIndex + 1).IsActivatable

                If notLastTask AndAlso nextTaskOK Then
                    foundTask = mAllTasks(currentTaskIndex + 1)
                End If



            End If

            Return foundTask
        End Function




        Private Function SeekFirstActivatableTask() As SensorTask
            Dim foundTask As SensorTask = Nothing
            For i As Integer = 0 To mAllTasks.Count - 1
                If mAllTasks(i).IsActivatable Then
                    foundTask = mAllTasks(i)
                End If
            Next
            Return foundTask
        End Function

        Private Sub AutoSelectActiveTask(ByVal currentConditions As ConditionCollection)

            If Not ActiveTask Is Nothing AndAlso ActiveTask.IsActivatable AndAlso _
               currentConditions.EqualsSubset(ActiveTask.Conditions) Then
                ' If the active task is activatable, and the first of all activatable tasks, then stay here
                Return
            End If

            ' If we've skipped to this task, then stay here
            If Not ActiveTask Is Nothing AndAlso ActiveTask.SkipDestination AndAlso ActiveTask.IsActivatable Then Return

            Dim newActiveTask As SensorTask = Nothing

            ' Seek the first activatable task for this sensor that also satisfies the current conditions
            If newActiveTask Is Nothing Then
                newActiveTask = SeekTaskBasedOnSensor(currentConditions, True)
            End If

            ' Seek the first activatable task for this sensor that does *not* satisfy the current conditions
            If newActiveTask Is Nothing Then
                newActiveTask = SeekTaskBasedOnSensor(currentConditions, False)
            End If


            If newActiveTask Is Nothing Then
                ' If we still have no active task, check the very next task. We don't do this earlier
                ' because the next task might be using a different sensor.
                newActiveTask = SeekTaskBasedOnNextIndex()
            End If

            If newActiveTask Is Nothing Then
                ' If we still have no active task, then just find the first one that *is* activatable
                newActiveTask = SeekFirstActivatableTask()
                For i As Integer = 0 To mAllTasks.Count - 1
                    If mAllTasks(i).IsActivatable Then
                        newActiveTask = mAllTasks(i)
                        Exit For
                    End If
                Next
            End If

            ' If the task has changed, the task can no longer be a skip destination
            If ActiveTask IsNot Nothing AndAlso newActiveTask IsNot ActiveTask Then
                mActiveTask.SkipDestination = False
            End If

            ' If we've picked a new active task, then activate it!
            If Not newActiveTask Is Nothing Then
                MigrateActiveTask(newActiveTask)
            Else
                mActiveTask = Nothing
            End If

        End Sub

        Public Sub MigrateActiveTask(ByVal newActiveTask As SensorTask)

            If newActiveTask Is Nothing Then Throw New ArgumentNullException("newActiveTask")

            ' Migrate the active task
            If Not ActiveTask Is Nothing AndAlso ActiveTask.Status = SensorTaskStatus.Active Then
                ActiveTask.Status = SensorTaskStatus.Suspended
            End If
            newActiveTask.Status = SensorTaskStatus.Active
            mActiveTask = newActiveTask
        End Sub

        Public Function AttemptIsMigratable(ByVal attempt As SensorTaskAttempt) As Boolean
            If attempt Is Nothing Then Throw New ArgumentNullException("attempt")
            For i As Integer = 0 To MyBase.Count - 1
                If attempt.Satisfies(MyBase.Item(i)) Then Return True
            Next
            Return False
        End Function

        'Private Function SeekCompatibleTask( _


        ' Returns the task migrated to
        Private Function AutoMigrateAttempt( _
            ByVal attempt As SensorTaskAttempt, _
            ByVal currentConditions As ConditionCollection, _
            ByVal currentInaccessibleParts As BodyPartCollection, _
            ByVal style As ConditionsMatchStyle) As SensorTask


            ' First, seek a compatible factory
            Dim targetFactory As SensorTaskFactory = Nothing
            For i As Integer = 0 To MyBase.Count - 1
                If attempt.Satisfies(MyBase.Item(i)) Then
                    targetFactory = MyBase.Item(i)
                    Exit For
                End If
            Next

            ' Without a satisfactory target factory, forget migrating the attempt
            If targetFactory Is Nothing Then Return Nothing

            ' Now, seek a target task to migrate the attempt onto
            Dim targetTask As SensorTask = Nothing
            For i As Integer = 0 To targetFactory.GeneratedTasks.Count - 1
                Dim task As SensorTask = targetFactory.GeneratedTasks(i)
                If attempt.Satisfies(task, style) Then
                    targetTask = task
                    Exit For
                End If
            Next

            ' If there is still no target task, then see if we can generate up a new one
            If targetTask Is Nothing Then
                'KAYEE - Debug
                'OutputtoLog("SensorTaskFactoryCollection AddExtraTask()")
                targetFactory.AddExtraTask(currentConditions, currentInaccessibleParts)
                If attempt.Satisfies(targetFactory.GeneratedTasks.Last, style) Then
                    targetTask = targetFactory.GeneratedTasks.Last
                Else
                    'DebuggingConsoleWriteLine(" Generated task doesn't satisfy!")
                End If
            End If

            ' If we still don't have a target task, then give up. We can't migrate this task
            If targetTask Is Nothing Then Return Nothing

            ' The migrated attempt should have the same conditions as the new task. We know that
            ' they are compatible, because the migrating tasks has either the same conditions as the 
            ' target task, or, it passed any equivalence class tests.

            attempt.CapturedConditions.AssignSubset(targetTask.Conditions)

            attempt.ParentTask.Attempts.Remove(attempt)
            attempt.ParentTask.RefreshStatus()

            targetTask.Attempts.Insert(0, attempt)
            targetTask.RefreshStatus()


            Return targetTask


        End Function


        Private Sub PopulateAllTasksList()

            ' Pass one of two
            RefreshAllTasksArray()

            ' Automigrate any attempt in conflict
            ' -----------------------------------
            '
            ' The purpose of this stage is to take any attempt that is in conflict, and try to figure 
            ' out where it should go. If there is no destination for an attempt, then the task will appear
            ' as in conflict to the user
            '
            '
            For i As Integer = 0 To mAllTasks.Count - 1
                Dim task As SensorTask = mAllTasks(i)

                ' Mark all of those tasks that need migration (deletion requires two passes). Migrating them
                ' in opposite order would also cause the tasks to appear done before the rejected attempts even
                ' had a chance to migrate
                '
                Dim toMigrate As New Collection(Of SensorTaskAttempt)
                For j As Integer = 0 To task.Attempts.Count - 1
                    Dim attempt As SensorTaskAttempt = task.Attempts(j)

                    If attempt.InConflict(CurrentConditions, CurrentInaccessibleBodyParts) Then
                        toMigrate.Add(attempt)
                    End If
                Next

                ' Migrate those attempts
                For j As Integer = 0 To toMigrate.Count - 1
                    'KAYEE - Debug
                    'OutputtoLog("SensorTaskFactoryCollection AutoMigrateAttempt()")
                    AutoMigrateAttempt(toMigrate(j), CurrentConditions, CurrentInaccessibleBodyParts, ConditionsMatchStyle.All)
                Next

            Next

            ' Pass two of two
            RefreshAllTasksArray()

            ' AutoSelectActiveTask makes use of the task map, so we should update it
            UpdateTaskMap()

            AutoSelectActiveTask(CurrentConditions)

        End Sub

        Private Sub RefreshAllTasksArray()

            ' Remove any excess tasks 
            TrimExcessTasks()

            ' Add/remove (well, mostly *remove*) from the task side. Okay, well, this comment should
            ' be 'remove stale tasks' but then it doesn't match the next comment
            '
            For i As Integer = mAllTasks.Count - 1 To 0 Step -1
                If mAllTasks(i).OriginatingFactory.GeneratedTasks.IndexOf(mAllTasks(i)) = -1 Then
                    mAllTasks.Remove(mAllTasks(i))
                End If
            Next


            ' Add/remove tasks from the factory side
            For i As Integer = 0 To MyBase.Count - 1
                For j As Integer = 0 To MyBase.Item(i).GeneratedTasks.Count - 1
                    Dim task As SensorTask = MyBase.Item(i).GeneratedTasks(j)

                    Dim hasIndex As Boolean = mAllTasks.IndexOf(task) <> -1
                    Dim noParent As Boolean = task.OriginatingFactory.GeneratedTasks.IndexOf(task) = -1
                    Dim prereqOK As Boolean = MyBase.Item(i).Prerequisite.Evaluate
                    Dim hasParts As Boolean = Not task.TargetParts.Equals(task.TargetInaccessibleParts)
                    Dim inConflict As Boolean = task.HasAttemptsInConflict(CurrentConditions, CurrentInaccessibleBodyParts)
                    Dim sensorDisabled As Boolean = task.Sensor.Disabled

                    Dim insertTask As Boolean = _
                        Not hasIndex AndAlso _
                        (inConflict OrElse prereqOK) AndAlso _
                        hasParts AndAlso _
                        Not sensorDisabled

                    Dim removeTask As Boolean = _
                        Not hasParts AndAlso Not inConflict OrElse _
                        Not inConflict AndAlso hasIndex AndAlso Not prereqOK OrElse _
                        sensorDisabled OrElse _
                        noParent

                    If insertTask Then
                        mAllTasks.Add(task)
                    ElseIf removeTask Then
                        If task.Status = SensorTaskStatus.Active Then task.Status = SensorTaskStatus.Suspended
                        mAllTasks.Remove(task)
                    ElseIf mAllTasks.IndexOf(task) > -1 Then
                        ' Leaving in
                    Else
                        ' Leaving out
                    End If

                Next
            Next

            mAllTasks.Sort()

            UpdateTaskMap()

        End Sub

        Friend Sub UpdateTaskMap()
            Dim en As IEnumerator(Of ISensor) = Me.mTasksOfSensor.Keys.GetEnumerator

            ' For each sensor, clear the tasks associated with that sensor
            While en.MoveNext
                mTasksOfSensor(en.Current).Clear()
            End While

            For i As Integer = 0 To mAllTasks.Count - 1
                Dim sensor As ISensor = mAllTasks(i).Sensor
                If Not mTasksOfSensor.ContainsKey(sensor) Then mTasksOfSensor(sensor) = New SensorTaskCollection
                Dim tasks As SensorTaskCollection = mTasksOfSensor(sensor)
                If tasks.IndexOf(mAllTasks(i)) = -1 Then tasks.Add(mAllTasks(i))
            Next


        End Sub

        Public ReadOnly Property TasksNotDownloadable(ByVal sensor As ISensor) As Integer
            Get
                If Not mTasksOfSensor.ContainsKey(sensor) Then Return 0
                For i As Integer = 0 To mTasksOfSensor(sensor).Count - 1
                    Dim task As SensorTask = mTasksOfSensor(sensor)(i)

                    Dim notPending As Boolean = task.Status <> SensorTaskStatus.Pending
                    Dim notDone As Boolean = task.Status <> SensorTaskStatus.Done
                    Dim notSkipped As Boolean = task.Status <> SensorTaskStatus.Skipped
                    Dim notDLSuspended As Boolean = Not (task.Status = SensorTaskStatus.Suspended AndAlso task.DownloadsPaused)

                    If notPending AndAlso notDone AndAlso notDLSuspended AndAlso notSkipped Then TasksNotDownloadable += 1
                Next
            End Get
        End Property

        Public ReadOnly Property TasksOfSensor(ByVal sensor As ISensor) As SensorTaskCollection
            Get
                If sensor Is Nothing Then Throw New ArgumentNullException("sensor")
                If mTasksOfSensor.ContainsKey(sensor) Then Return mTasksOfSensor(sensor) Else Return Nothing
            End Get
        End Property

        Public Function FirstAttemptHavingOutstandingDownload(ByVal sensor As ISensor) As SensorTaskAttempt

            If sensor Is Nothing Then Throw New ArgumentNullException("sensor")
            If Not mTasksOfSensor.ContainsKey(sensor) Then Return Nothing
            If TasksNotDownloadable(sensor) > 0 Then Return Nothing

            For i As Integer = 0 To mTasksOfSensor(sensor).Count - 1
                Dim task As SensorTask = mTasksOfSensor(sensor)(i)
                For j As Integer = 0 To task.Attempts.Count - 1
                    Dim attempt As SensorTaskAttempt = task.Attempts(j)
                    If attempt.NeedsDownload AndAlso Not attempt.ParentTask.DownloadsPaused Then Return task.Attempts(j)
                Next
            Next

            Return Nothing
        End Function

        Public ReadOnly Property TasksNotDownloaded(ByVal sensor As ISensor) As Integer
            Get
                If sensor Is Nothing Then Throw New ArgumentNullException("sensor")
                If Not mTasksOfSensor.ContainsKey(sensor) Then Return 0
                For i As Integer = 0 To mTasksOfSensor(sensor).Count - 1
                    Dim task As SensorTask = mTasksOfSensor(sensor)(i)
                    For j As Integer = 0 To task.Attempts.Count - 1
                        Dim attempt As SensorTaskAttempt = task.Attempts(j)
                        If attempt.NeedsDownload Then TasksNotDownloaded += 1
                    Next
                Next
            End Get
        End Property

        Public Overloads Sub Add(ByVal item As SensorTaskFactory)
            MyBase.Add(item)
            item.WireParentSensorTaskFactories(Me)
        End Sub

        Public Overloads Sub Clear()
            For i As Integer = 0 To MyBase.Count - 1
                Item(i).Clear()
            Next

            mActiveTask = Nothing
            mAllTasks.Clear()
            mTasksOfSensor.Clear()

            PopulateAllTasksList()

        End Sub

#Region "Debug"
        'Private Sub OutputtoLog(ByVal msg As String)
        '    Dim sw As New System.IO.StreamWriter("c:\TestingLog2.txt", True)
        '    sw.WriteLine(DateTime.Now & " - " & msg)
        '    sw.Flush()
        '    sw.Close()
        'End Sub
#End Region

    End Class

End Namespace
