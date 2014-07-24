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

Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Xml.Serialization

Imports ConditionFactoryProxy = Mbark.NamedProxy(Of Mbark.Sensors.ConditionFactory)
Imports PredicateFactoryProxy = Mbark.NamedProxy(Of Mbark.Sensors.PredicateFactory)

Imports Mbark.UI.GlobalUISettings

Namespace Mbark.Sensors

    <XmlType("RuntimeConditionCollection")> _
    Public Class ConditionCollection
        Implements ICollection(Of Condition)

        Private mIsReadOnly As Boolean
        Private mConditionsTable As New Dictionary(Of String, Condition)
        Private mParentTask As SensorTask
        Private mEquivalenceClasses As New List(Of PredicateFactory)

        Friend Function CreateDefinition() As ConditionCollectionDefinition

            Dim def As New ConditionCollectionDefinition
            Dim uniqueFactories As New List(Of ConditionFactory)

            ' Build the list of unique factories
            Dim en As IEnumerator(Of Condition) = mConditionsTable.Values.GetEnumerator
            While en.MoveNext
                Dim condition As Condition = en.Current
                If uniqueFactories.IndexOf(condition.OriginatingFactory) = -1 Then uniqueFactories.Add(condition.OriginatingFactory)
            End While


            ' Create the proxies to the condition factories
            ReDim def.FactoryProxies.ConditionFactoryProxies(uniqueFactories.Count - 1)
            For i As Integer = 0 To uniqueFactories.Count - 1
                def.FactoryProxies.ConditionFactoryProxies(i) = New ConditionFactoryProxy(uniqueFactories(i))
            Next


            ' Create the equivalence class proxies
            ReDim def.FactoryProxies.EquivalenceClassProxies(mEquivalenceClasses.Count - 1)
            For i As Integer = 0 To mEquivalenceClasses.Count - 1
                def.FactoryProxies.EquivalenceClassProxies(i) = New PredicateFactoryProxy(mEquivalenceClasses(i))
            Next

            ' Create definitons for the conditions themselves
            en = mConditionsTable.Values.GetEnumerator
            While en.MoveNext
                def.Conditions.Add(en.Current.Definition(uniqueFactories))
            End While

            



            Return def

        End Function

        Public ReadOnly Property HasValidConditions() As Boolean
            Get
                Dim en As IEnumerator(Of Condition) = mConditionsTable.Values.GetEnumerator
                While en.MoveNext
                    If en.Current.IsValid Then Return True
                End While
                Return False
            End Get
        End Property

        Public Sub DeepCopyPrerequisites(ByVal prerequisiteSource As Condition, ByVal conditions As ConditionCollection)

            If prerequisiteSource Is Nothing Then Throw New ArgumentNullException("prerequisiteSource")
            If conditions Is Nothing Then Throw New ArgumentNullException("conditions")

            If Not prerequisiteSource.Prerequisite Is Nothing Then
                For i As Integer = 0 To prerequisiteSource.Prerequisite.ParticipatingConditionNames.Count - 1
                    Dim prereqName As String = prerequisiteSource.Prerequisite.ParticipatingConditionNames(i)
                    If Not Me.ContainsCondition(prereqName) Then
                        Me(prereqName) = conditions(prereqName).DeepCopy(conditions)
                    End If
                Next
            End If
        End Sub


        Public Sub MarkAsReadOnly()
            mIsReadOnly = True
        End Sub


        Public Function FriendlyToString(ByVal culture As CultureInfo, ByVal suppressInvalidConditionsAccordingToTask As SensorTask) As String

            Dim friendlyString As String
            Dim writer As New System.IO.StringWriter(culture)

            ' We make a deep copy of the current conditions and wire it up to the task to be tested against since
            ' we don't want to assign a task to the current conditions
            '
            Dim conditions As ConditionCollection = DeepCopy()
            If Not suppressInvalidConditionsAccordingToTask Is Nothing Then
                conditions.WireParentTask(suppressInvalidConditionsAccordingToTask)
            End If

            Dim en As IEnumerator(Of Condition) = conditions.ConditionsEnumerator
            While en.MoveNext
                If suppressInvalidConditionsAccordingToTask IsNot Nothing OrElse en.Current.IsValid Then
                    writer.Write(en.Current.CompoundToString)
                    If en.Current.CompoundToString <> String.Empty Then
                        writer.Write(InfrastructureMessages.Messages.Space(culture))
                    End If

                End If
            End While
            If writer.ToString = String.Empty Then
                friendlyString = InfrastructureMessages.Messages.None(culture)
            Else
                friendlyString = writer.ToString
            End If
            writer.Dispose()
            Return friendlyString
        End Function

        Public Function FriendlyToString(ByVal culture As CultureInfo) As String
            Return FriendlyToString(culture, Nothing)
        End Function

        ReadOnly Property ContainsCondition(ByVal name As String) As Boolean
            Get
                Return mConditionsTable.ContainsKey(name)
            End Get
        End Property


        


        Default Property Item(ByVal name As String) As Condition
            Get
                If mConditionsTable.ContainsKey(name) Then
                    Return mConditionsTable(name)
                Else
                    Return Nothing
                End If
            End Get

            Set(ByVal value As Condition)

                If value Is Nothing Then Throw New ArgumentNullException("value")

                ' If the condition already exists, then remove the handler
                If mConditionsTable.ContainsKey(name) Then
                    RemoveHandler value.ConditionValueChanged, AddressOf HandleConditionValueChanged
                End If

                AddHandler value.ConditionValueChanged, AddressOf HandleConditionValueChanged
                mConditionsTable(name) = value
            End Set
        End Property



        Public ReadOnly Property ConditionsEnumerator() As IEnumerator(Of Condition)
            Get
                Return mConditionsTable.Values.GetEnumerator
            End Get
        End Property

        Friend ReadOnly Property ParentTask() As SensorTask
            Get
                Return mParentTask
            End Get
        End Property

        Friend Sub WireParentTask(ByVal parentTask As SensorTask)
            If parentTask Is Nothing Then
                Throw New ArgumentNullException("parentTask")
            End If
            mParentTask = parentTask
        End Sub

        Public Function EqualsSubset(ByVal subset As ConditionCollection) As Boolean
            If subset Is Nothing Then Throw New ArgumentNullException("subset")
            Return EqualsSubset(subset, ConditionsMatchStyle.All)
        End Function

        Public Sub AddEquivalenceClass(ByVal predicateFactory As PredicateFactory)
            If predicateFactory Is Nothing Then Throw New ArgumentNullException("predicateFactory")
            If mEquivalenceClasses.Contains(predicateFactory) Then Return
            mEquivalenceClasses.Add(predicateFactory)
        End Sub

        Protected Friend Function EqualsSubset( _
            ByVal subset As ConditionCollection, _
            ByVal style As ConditionsMatchStyle, _
            ByVal conflicts As ConditionsConflict, _
            ByVal shortCircuiting As Boolean) As Boolean

            If subset Is Nothing Then Throw New ArgumentNullException("subset")
            If conflicts Is Nothing Then
                shortCircuiting = True
            Else
                shortCircuiting = False
            End If

            ' Empty conditions are always satisfied
            If subset.mConditionsTable.Count = 0 Then Return True

            Dim namesOfFailableConditions As New StringCollection
            Dim namesOfNonParticipantConditions As New StringCollection

            ' Assume all conditions are equivalence class participants at first .
            Dim en As IEnumerator(Of String) = Me.mConditionsTable.Keys.GetEnumerator
            While en.MoveNext
                namesOfNonParticipantConditions.Add(en.Current)
            End While

            For i As Integer = 0 To subset.mEquivalenceClasses.Count - 1

                Dim pf As PredicateFactory = DirectCast(subset.mEquivalenceClasses(i), PredicateFactory)
                Dim supersetPredicate As Predicate = pf.CreatePredicate(Me)
                Dim subsetPredicate As Predicate = pf.CreatePredicate(subset)


                ' In this loop, we set up the list of conditions to check. The participating and non-participating
                ' conditions need to be treated slightly differently.
                '
                For j As Integer = 0 To subsetPredicate.ParticipatingConditionNames.Count - 1
                    Dim name As String = subsetPredicate.ParticipatingConditionNames(j)

                    ' Remove those participating conditions from the list of non-participating conditions 
                    ' (unless we're ignore equivalence classes)
                    '
                    If namesOfNonParticipantConditions.Contains(name) AndAlso style <> ConditionsMatchStyle.AllWithoutEquivalenceClasses Then
                        namesOfNonParticipantConditions.Remove(name)
                    End If

                    ' Put all of the participating conditions into the 'failed' list. Conditions are
                    ' assumed to be failed, and are removed from this list as they evaluate to be
                    ' passed. 
                    '
                    ' Notice we don't eliminate redudant names, because a condition might
                    ' participate in multiple equivalence clases, and must pass all of them in order to
                    ' not be checked later.
                    namesOfFailableConditions.Add(name)
                Next

                Dim supersetPasses As Boolean = supersetPredicate.Evaluate
                Dim subsetPasses As Boolean = subsetPredicate.Evaluate

                ' If the condition passes, remove it from the failed list
                If supersetPasses And subsetPasses Then
                    For j As Integer = 0 To subsetPredicate.ParticipatingConditionNames.Count - 1
                        Dim name As String = subsetPredicate.ParticipatingConditionNames(j)
                        namesOfFailableConditions.Remove(name)
                    Next
                End If

            Next

            ' Take all those valid conditions that really are non-participants, and add them to the rest of the 
            ' failed conditions list
            '
            For i As Integer = 0 To namesOfNonParticipantConditions.Count - 1
                Dim subsetCondition As Condition = subset(DirectCast(namesOfNonParticipantConditions(i), String))

                If subsetCondition IsNot Nothing AndAlso subsetCondition.IsValid Then
                    namesOfFailableConditions.Add(namesOfNonParticipantConditions(i))
                End If
            Next


            ' Perform the comparisons for non participants, and for those participants failing equivalence class
            ' membership
            '
            Dim conditionsEn As IEnumerator(Of Condition) = subset.ConditionsEnumerator
            While conditionsEn.MoveNext


                Dim subsetCondition As Condition = conditionsEn.Current
                Dim name As String = subsetCondition.Name

                If subsetCondition.IsValid Then
                    Dim supersetCondition As Condition = DirectCast(Me(name), Condition)

                    ' Make sure the subset condition exists in the superset
                    '
                    If supersetCondition Is Nothing Then
                        If Not conflicts Is Nothing Then conflicts.AddWithDeepCopy(Nothing, Me, subsetCondition, subset)
                        If shortCircuiting Then Return False
                    End If

                    ' Notice that we only do the comparison if the condition still has an entry in the
                    ' list of potentially failed conditions
                    '.
                    Dim doCompare As Boolean = _
                         namesOfFailableConditions.Contains(subsetCondition.Name) AndAlso ( _
                         style = ConditionsMatchStyle.AllWithoutEquivalenceClasses OrElse _
                         style = ConditionsMatchStyle.All OrElse _
                        (style = ConditionsMatchStyle.StaticsOnly AndAlso subsetCondition.IsStatic) OrElse _
                        (style = ConditionsMatchStyle.NonStaticsOnly AndAlso Not subsetCondition.IsStatic))

                    If doCompare Then

                        If Me(subsetCondition.Name) Is Nothing Then Debugging.Break()

                        Dim supersetValue As Object = Me(subsetCondition.Name).Value
                        Dim subsetValue As Object = subsetCondition.Value


                        If subsetCondition.IsValid AndAlso Not supersetValue.Equals(subsetValue) Then

                            If Not conflicts Is Nothing Then
                                conflicts.AddWithDeepCopy(supersetCondition, Me, subsetCondition, subset)
                            End If
                            If shortCircuiting Then Return False
                        End If

                    End If ' doCompare
                End If ' subsetCondition.IsValid

            End While


            If Not conflicts Is Nothing Then
                Return conflicts.IsEmpty
            Else
                Return True
            End If


        End Function

        ' Determines if all of the conditions in subset take on the same value as in the superset
        Protected Friend Function EqualsSubset(ByVal subset As ConditionCollection, ByVal style As ConditionsMatchStyle) As Boolean
            If subset Is Nothing Then Throw New ArgumentNullException("subset")
            Return EqualsSubset(subset, style, Nothing, True)
        End Function

        Public Overloads Function ToString() As String
            Return ToString(CultureInfo.CurrentUICulture)
        End Function

        Public Overloads Function ToString(ByVal culture As CultureInfo) As String
            Dim writer As New IO.StringWriter(culture)
            Dim en As IEnumerator = mConditionsTable.Values.GetEnumerator
            While en.MoveNext
                Dim cond As Condition = DirectCast(en.Current, Condition)
                If cond.IsValid Then
                    writer.Write(cond.Name)
                    writer.Write(StringConstants.EqualsSign)
                    writer.Write(cond.Value.ToString)
                    writer.Write(StringConstants.Space)
                End If
            End While
            If writer.ToString = String.Empty Then
                Return InfrastructureMessages.Messages.None(culture)
            Else
                Return writer.ToString
            End If
        End Function


        ' Only deep copy those conditions in the subset
        Public Function SubsetDeepCopy(ByVal subset As ConditionCollection) As ConditionCollection
            If subset Is Nothing Then Throw New ArgumentNullException("subset")
            Dim cs As New ConditionCollection
            Dim en As IEnumerator = mConditionsTable.Values.GetEnumerator
            While en.MoveNext
                Dim c As Condition = DirectCast(en.Current, Condition)
                If Not subset(c.Name) Is Nothing Then cs(c.Name) = c.DeepCopy(cs)
            End While

            For i As Integer = 0 To Me.mEquivalenceClasses.Count - 1
                Dim equivalenceClassShouldBeCopied As Boolean = True

                ' Only copy the equivalence class if they are meaningful. That is, if the conditions participating
                ' in the e.c. are part of the subset to be copied.
                '
                Dim participatingConditions As StringCollection = mEquivalenceClasses(i).CreatePredicate(Me).ParticipatingConditionNames
                For j As Integer = 0 To participatingConditions.Count - 1
                    If Not cs.ContainsCondition(participatingConditions(j)) Then
                        equivalenceClassShouldBeCopied = False
                        Exit For
                    End If
                Next

                If equivalenceClassShouldBeCopied Then
                    cs.AddEquivalenceClass(DirectCast(mEquivalenceClasses(i), PredicateFactory))
                End If

            Next
            Return cs
        End Function

        Public Function DeepCopy() As ConditionCollection
            Dim cs As New ConditionCollection
            Dim en As IEnumerator = mConditionsTable.Values.GetEnumerator
            While en.MoveNext
                Dim c As Condition = DirectCast(en.Current, Condition)
                cs(c.Name) = c.DeepCopy(cs)
            End While
            For i As Integer = 0 To Me.mEquivalenceClasses.Count - 1
                cs.AddEquivalenceClass(DirectCast(mEquivalenceClasses(i), PredicateFactory))
            Next
            Return cs
        End Function

        Public Sub AssignSubset(ByVal source As ConditionCollection)
            If source Is Nothing Then Throw New ArgumentNullException("source")
            Dim en As IEnumerator = mConditionsTable.Values.GetEnumerator
            While en.MoveNext
                Dim cond As Condition = DirectCast(en.Current, Condition)
                If source(cond.Name) IsNot Nothing AndAlso Not cond.Value.Equals(source(cond.Name).Value) Then
                    cond.Value = source(cond.Name).DeepCopyValue
                End If
            End While

        End Sub

        Public Event ConditionValueChanged As EventHandler(Of ConditionValueChangedEventArgs)

        Private Sub HandleConditionValueChanged(ByVal sender As Object, ByVal e As ConditionValueChangedEventArgs)
            RaiseEvent ConditionValueChanged(sender, e)
        End Sub

#Region "ICollection Implementation"

        Public Sub Add(ByVal item As Condition) Implements ICollection(Of Condition).Add
            If item Is Nothing Then Throw New ArgumentNullException("item")
            Me.Item(item.Name) = item
        End Sub

        Public Sub Clear() Implements ICollection(Of Condition).Clear
            mConditionsTable.Clear()
        End Sub

        Public Function Contains(ByVal item As Condition) As Boolean Implements ICollection(Of Condition).Contains
            mConditionsTable.ContainsValue(item)
        End Function

        Public Sub CopyTo(ByVal array() As Condition, ByVal arrayIndex As Integer) Implements ICollection(Of Condition).CopyTo
            Throw New NotImplementedException
        End Sub

        Public ReadOnly Property Count() As Integer Implements ICollection(Of Condition).Count
            Get
                Return mConditionsTable.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of Condition).IsReadOnly
            Get
                Return mIsReadOnly
            End Get
        End Property

        Public Function Remove(ByVal item As Condition) As Boolean Implements System.Collections.Generic.ICollection(Of Condition).Remove
            Throw New NotImplementedException
        End Function

        Public Function GetConditionEnumerator() As IEnumerator(Of Condition) Implements IEnumerable(Of Condition).GetEnumerator
            Return mConditionsTable.Values.GetEnumerator
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return mConditionsTable.Values.GetEnumerator()
        End Function

#End Region
    End Class

    <XmlType("ConditionCollection"), Serializable()> _
Public Class ConditionCollectionDefinition
        Implements ICloneable

        <XmlElement("ConditionFactory")> _
        Public FactoryProxies As New ConditionFactoryProxyCollectionDefinition
        Private mConditions As New Collection(Of ConditionDefinition)

        Public ReadOnly Property Conditions() As Collection(Of ConditionDefinition)
            Get
                If mConditions Is Nothing Then mConditions = New Collection(Of ConditionDefinition)
                Return mConditions
            End Get
        End Property

        Public Function Clone() As Object Implements ICloneable.Clone

            Dim newDef As New ConditionCollectionDefinition

            newDef.FactoryProxies = FactoryProxies.DeepCopy
            For i As Integer = 0 To Conditions.Count - 1
                newDef.Conditions.Add(Conditions(i))
            Next


            Return newDef
        End Function

        Public Function DeepCopy() As ConditionCollectionDefinition
            Return DirectCast(Clone(), ConditionCollectionDefinition)
        End Function

        Public Function CreateConditionCollection( _
            ByVal strings As LocalizableStringCollection, _
            ByVal conditionFactories As ConditionFactoryCollection) As ConditionCollection

            Dim newConditions As New ConditionCollection

            Dim factories As New Collection(Of ConditionFactory)



            With FactoryProxies


                ' Empty arrays deserialize to Nothing
                If .ConditionFactoryProxies Is Nothing Then
                    .ConditionFactoryProxies = New ConditionFactoryProxy() {}
                End If
                If .EquivalenceClassProxies Is Nothing Then
                    .EquivalenceClassProxies = New PredicateFactoryProxy() {}
                End If

                ' Reconstitute the list of factories
                For i As Integer = 0 To .ConditionFactoryProxies.Length - 1
                    factories.Add(.ConditionFactoryProxies(i).Dereference(conditionFactories))
                Next

                ' Reconstitute the equivalence classes
                For i As Integer = 0 To .EquivalenceClassProxies.Length - 1
                    newConditions.AddEquivalenceClass(.EquivalenceClassProxies(i).Dereference(conditionFactories.EquivalenceClasses))
                Next

            End With
           

            ' Reconstitute the conditions, linking them back to their originating factory
            For Each definition As ConditionDefinition In Conditions
                Dim soughtFactory As ConditionFactory = Nothing

                ' By brute force, find the factory that has this name 
                For i As Integer = 0 To factories.Count - 1
                    If factories(i).FactoryName = definition.OriginatingFactory Then
                        soughtFactory = factories(i)
                    End If
                Next

                If soughtFactory IsNot Nothing Then
                    newConditions.Add(definition.CreateCondition(newConditions, soughtFactory, strings))
                Else
                    ' FIXME: Make some exception that says that originating factory not found.
                    Throw New MbarkException
                End If
            Next

            Return newConditions

        End Function

    End Class

End Namespace
