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


Imports System.Runtime.Serialization
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel
Imports System.Xml.Serialization

Imports LocalizableStringProxy = Mbark.NamedProxy(Of Mbark.LocalizableString)

Imports Mbark

Namespace Mbark.Sensors

    <XmlType("RuntimePredicateFactory")> _
    Partial Public Class PredicateFactory
        Implements IHasName


        Private mDefinition As New PredicateFactoryDefinition
        Private mUnmetPrequisiteMessage As LocalizableString
        Private mFactoryArgs As Object()

        Public Sub FactoryArgs(ByVal ParamArray args As Object())
            mFactoryArgs = args
        End Sub

        Friend ReadOnly Property GetFactoryArgs(ByVal index As Integer) As Object
            Get
                Return mFactoryArgs(index)
            End Get
        End Property

        Public Property PredicateType() As PredicateType
            Get
                Return mDefinition.PredicateType
            End Get
            Set(ByVal value As PredicateType)
                mDefinition.PredicateType = value
            End Set
        End Property

        Public Function CreatePredicate(ByVal conditions As ConditionCollection) As Predicate

            Dim createPredicateResult As Predicate = Nothing

            With mDefinition
                Select Case .PredicateType

                    Case PredicateType.LiteralPredicate
                        Dim value As Boolean = DirectCast(mFactoryArgs(0), Boolean)
                        createPredicateResult = New LiteralPredicate(value)

                    Case PredicateType.CompoundAndPredicate
                        Dim PF1 As PredicateFactory = DirectCast(mFactoryArgs(0), PredicateFactory)
                        Dim PF2 As PredicateFactory = DirectCast(mFactoryArgs(1), PredicateFactory)
                        createPredicateResult = New CompoundAndPredicate(conditions, PF1, PF2)

                    Case PredicateType.CompoundOrPredicate
                        Dim PF1 As PredicateFactory = DirectCast(mFactoryArgs(0), PredicateFactory)
                        Dim PF2 As PredicateFactory = DirectCast(mFactoryArgs(1), PredicateFactory)
                        createPredicateResult = New CompoundOrPredicate(conditions, PF1, PF2)

                    Case PredicateType.CategoryEqualsLiteralPredicate
                        Dim category As SensorTaskCategory = DirectCast(mFactoryArgs(0), SensorTaskCategory)
                        createPredicateResult = New TargetCategoryEqualsLiteralPredicate(conditions, category)

                    Case PredicateType.ConditionEqualsLiteralPredicate
                        Dim name As String = DirectCast(mFactoryArgs(0), String)
                        Dim value As Object = mFactoryArgs(1)
                        createPredicateResult = New ConditionEqualsLiteralPredicate(conditions, name, value)

                    Case PredicateType.CategoryContainedInSetPredicate
                        Dim categories As Collection(Of SensorTaskCategory) = DirectCast(mFactoryArgs(0), Collection(Of SensorTaskCategory))
                        createPredicateResult = New CategoryContainedInSetPredicate(conditions, categories)

                    Case PredicateType.SensorModalityEqualsLiteralPredicate
                        Dim soughtModality As SensorModality = DirectCast(mFactoryArgs(0), SensorModality)
                        createPredicateResult = New SensorModalityEqualsLiteralPredicate(conditions, soughtModality)

                    Case Sensors.PredicateType.NotPredicate
                        Dim predicateFactoryToNegate As PredicateFactory = DirectCast(mFactoryArgs(0), PredicateFactory)
                        createPredicateResult = New NotPredicate(conditions, predicateFactoryToNegate)

                End Select

                Dim names As StringCollection = ExtractParticipatingConditions(Me)
                For i As Integer = 0 To names.Count - 1
                    If Not createPredicateResult.ParticipatingConditionNames.Contains(names(i)) Then
                        createPredicateResult.ParticipatingConditionNames.Add(names(i))
                    End If
                Next
            End With

            createPredicateResult.UnmetPrerequisiteMessage = Me.UnmetPrerequisiteMessage

            Return createPredicateResult

        End Function

        Public Property UnmetPrerequisiteMessage() As LocalizableString
            Get
                Return mUnmetPrequisiteMessage
            End Get
            Set(ByVal value As LocalizableString)
                mUnmetPrequisiteMessage = value
            End Set
        End Property


        Public Function Definition() As PredicateFactoryDefinition

            Dim newDef As PredicateFactoryDefinition = mDefinition.DeepCopy

            If Not UnmetPrerequisiteMessage Is Nothing Then
                newDef.UnmetPrerequisiteMessage = New LocalizableStringProxy(UnmetPrerequisiteMessage)
            End If

            If mDefinition.FactoryArgDefinitions Is Nothing Then
                newDef.FactoryArgDefinitions = New Object() {}
            End If

            ReDim newDef.FactoryArgDefinitions(mFactoryArgs.Length - 1)
            For i As Integer = 0 To mFactoryArgs.Length - 1

                If TypeOf mFactoryArgs(i) Is PredicateFactory Then
                    newDef.FactoryArgDefinitions(i) = DirectCast(mFactoryArgs(i), PredicateFactory).Definition
                Else
                    newDef.FactoryArgDefinitions(i) = mFactoryArgs(i)
                End If
            Next

            Return newDef

        End Function

        Friend Sub BindFromDefinitionToSelf(ByVal definition As PredicateFactoryDefinition, ByVal strings As LocalizableStringCollection)

            mDefinition = definition.DeepCopy

            ' Reconstitute the unmet prereq message if there is one
            If definition.UnmetPrerequisiteMessage.Name <> String.Empty Then
                mUnmetPrequisiteMessage = definition.UnmetPrerequisiteMessage.Dereference(strings)
            End If

            ReDim mFactoryArgs(mDefinition.FactoryArgDefinitions.Length - 1)
            For i As Integer = 0 To mDefinition.FactoryArgDefinitions.Length - 1
                If TypeOf mDefinition.FactoryArgDefinitions(i) Is PredicateFactoryDefinition Then
                    mFactoryArgs(i) = DirectCast(mDefinition.FactoryArgDefinitions(i), PredicateFactoryDefinition).CreatePredicateFactory(strings)
                Else
                    mFactoryArgs(i) = mDefinition.FactoryArgDefinitions(i)
                End If
            Next
        End Sub

        Public ReadOnly Property Name() As String Implements IHasName.Name
            Get
                Return mDefinition.Name
            End Get
        End Property

        Public Sub New(ByVal name As String)
            mDefinition.Name = name
        End Sub



    End Class

    <XmlType("PredicateFactory"), Serializable()> _
    Public Class PredicateFactoryDefinition
        Implements ICloneable

        Private mPredicateType As PredicateType
        <XmlAttribute("PredicateType")> Public Property PredicateType() As PredicateType
            Get
                Return mPredicateType
            End Get
            Set(ByVal value As PredicateType)
                mPredicateType = value
            End Set
        End Property
        Private mUnmetPrerequisiteMessage As LocalizableStringProxy
        Public Property UnmetPrerequisiteMessage() As LocalizableStringProxy
            Get
                Return mUnmetPrerequisiteMessage
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mUnmetPrerequisiteMessage = value
            End Set
        End Property

        Private mName As String
        <XmlAttribute("Name")> Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value
            End Set
        End Property

        <XmlElement("FactoryArgument")> _
        Public FactoryArgDefinitions As Object()

        Public Function DeepCopy() As PredicateFactoryDefinition
            Return DirectCast(Clone(), PredicateFactoryDefinition)
        End Function

        Public Function Clone() As Object Implements System.ICloneable.Clone

            Dim newDef As New PredicateFactoryDefinition

            newDef.Name = Me.Name
            newDef.PredicateType = Me.PredicateType
            newDef.UnmetPrerequisiteMessage = Me.UnmetPrerequisiteMessage

            If FactoryArgDefinitions Is Nothing Then
                FactoryArgDefinitions = New Object() {}
            End If

            ReDim newDef.FactoryArgDefinitions(FactoryArgDefinitions.Length - 1)
            For i As Integer = 0 To FactoryArgDefinitions.Length - 1

                If FactoryArgDefinitions(i) Is Nothing Then Continue For

                If FactoryArgDefinitions(i).GetType.GetInterface("IClonable") Is Nothing Then
                    newDef.FactoryArgDefinitions(i) = FactoryArgDefinitions(i)
                Else
                    newDef.FactoryArgDefinitions(i) = DirectCast(FactoryArgDefinitions(i), ICloneable).Clone
                End If
            Next

            Return newDef

        End Function

        Public Function CreatePredicateFactory(ByVal strings As LocalizableStringCollection) As PredicateFactory
            Dim factory As New PredicateFactory(Name)
            factory.BindFromDefinitionToSelf(Me, strings)
            Return factory
        End Function

    End Class

    Public Class PredicateFactoryCollection
        Inherits Collection(Of PredicateFactory)
        Implements INameQueryable(Of PredicateFactory)

        Public Function ByName(ByVal nameOfSoughtElement As String) As PredicateFactory Implements INameQueryable(Of PredicateFactory).ByName
            Dim found As PredicateFactory = Nothing
            For i As Integer = 0 To MyBase.Count - 1
                If MyBase.Item(i).Name = nameOfSoughtElement Then
                    found = MyBase.Item(i)
                End If
            Next
            If found Is Nothing Then Throw New BadProxyException(GetType(PredicateFactoryCollection), nameOfSoughtElement)
            Return found

        End Function

    End Class


End Namespace
