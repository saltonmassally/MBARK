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
Imports System

Imports LocalizableStringProxy = Mbark.NamedProxy(Of Mbark.LocalizableString)

Namespace Mbark.Sensors

    <XmlType("RuntimeConditionFactory")> _
    Public Class ConditionFactory
        Implements IHasName

        Friend mPrerequisiteFactory As PredicateFactory
        Friend mDefinition As New ConditionFactoryDefinition
        Friend mConditionDescription As LocalizableString

        Public Property FactoryName() As String
            Get
                Return mDefinition.FactoryName
            End Get
            Set(ByVal value As String)
                mDefinition.FactoryName = value
            End Set
        End Property


        Public Property ConditionIsStatic() As Boolean
            Get
                Return mDefinition.ConditionIsStatic
            End Get
            Set(ByVal value As Boolean)
                mDefinition.ConditionIsStatic = value
            End Set
        End Property


        Public Sub InitializationArgs(ByVal ParamArray args As Object())
            mDefinition.InitializationArgs.AddRange(args)
        End Sub

        Public Property ConditionDescription() As LocalizableString
            Get
                Return mConditionDescription
            End Get
            Set(ByVal value As LocalizableString)
                mConditionDescription = value
            End Set
        End Property

        Public Property ConditionDescription(ByVal region As String) As String
            Get
                Return mConditionDescription(region)
            End Get
            Set(ByVal value As String)
                mConditionDescription(region) = value
            End Set
        End Property

        Public Property PrerequisiteFactory() As PredicateFactory
            Get
                If mPrerequisiteFactory Is Nothing Then Return Builtins.PredicateFactories.TrueLiteral
                Return mPrerequisiteFactory
            End Get
            Set(ByVal value As PredicateFactory)
                mPrerequisiteFactory = value
            End Set
        End Property

        Public Property ConditionType() As ConditionType
            Get
                Return mDefinition.ConditionType
            End Get
            Set(ByVal value As ConditionType)
                mDefinition.ConditionType = value
            End Set
        End Property

        Public Property ConditionInitialValue() As Object
            Get
                Return mDefinition.ConditionInitialValue
            End Get
            Set(ByVal value As Object)
                mDefinition.ConditionInitialValue = value
            End Set
        End Property

        Public Property ConditionName() As String
            Get
                Return mDefinition.ConditionName
            End Get
            Set(ByVal value As String)
                mDefinition.ConditionName = value
            End Set
        End Property


        Public Function Create(ByVal conditions As ConditionCollection) As Condition
            Dim createResult As Condition = Nothing

            Select Case mDefinition.ConditionType
                Case ConditionType.BooleanCondition
                    Dim val As Boolean = DirectCast(mDefinition.ConditionInitialValue, Boolean)

                    ' Transform each LocalizableStringDefinition to a LocalizableString
                    For i As Integer = 0 To 5
                        Dim arg As Object = mDefinition.InitializationArgs(i)
                        If arg.GetType().Equals(GetType(LocalizableStringDefinition)) Then
                            mDefinition.InitializationArgs(i) = DirectCast(arg, LocalizableStringDefinition).CreateLocalizableString
                        End If


                    Next

                    createResult = New BooleanCondition( _
                        val, _
                        DirectCast(mDefinition.InitializationArgs(0), LocalizableString), _
                        DirectCast(mDefinition.InitializationArgs(1), LocalizableString), _
                        DirectCast(mDefinition.InitializationArgs(2), LocalizableString), _
                        DirectCast(mDefinition.InitializationArgs(3), LocalizableString), _
                        DirectCast(mDefinition.InitializationArgs(4), LocalizableString), _
                        DirectCast(mDefinition.InitializationArgs(5), LocalizableString))
            End Select

            If mPrerequisiteFactory IsNot Nothing AndAlso createResult IsNot Nothing Then
                createResult.Prerequisite = mPrerequisiteFactory.CreatePredicate(conditions)
            End If

            createResult.WireOriginatingFactory(Me)
            Return createResult
        End Function

        Public Function CreateDefinition() As ConditionFactoryDefinition

            Dim newDef As ConditionFactoryDefinition = mDefinition.DeepCopy
            newDef.PrerequisiteFactoryDefinition = PrerequisiteFactory.Definition

            Select Case mDefinition.ConditionType
                Case ConditionType.BooleanCondition
                    For i As Integer = 0 To 5

                        ' Transform objects that are LocalizableStringProxys 
                        Dim arg As Object = mDefinition.InitializationArgs(i)
                        If arg.GetType().Equals(GetType(LocalizableString)) Then
                            newDef.InitializationArgs(i) = New LocalizableStringProxy(DirectCast(arg, LocalizableString))
                        End If
                    Next
            End Select
            newDef.ConditionDescriptionString = New LocalizableStringProxy(mConditionDescription)

            Return newDef
        End Function



        Public ReadOnly Property Name() As String Implements IHasName.Name
            Get
                Return FactoryName
            End Get
        End Property
    End Class


    <XmlType("ConditionFactory"), Serializable()> Public Class ConditionFactoryDefinition
        Implements ICloneable


#Region "Private"

        Private mFactoryName As String = String.Empty
        Private mConditionName As String
        Private mConditionType As ConditionType
        Private mConditionIsStatic As Boolean
        Private mConditionDescriptionString As LocalizableStringProxy
        Private mConditionInitialValue As Object

        Friend mInitializationArgs As New ArrayList
        Private mPrerequisiteFactoryDefinition As PredicateFactoryDefinition
#End Region
        <XmlAttribute("Name")> Public Property FactoryName() As String
            Get
                If mFactoryName = String.Empty Then
                    mFactoryName = Guid.NewGuid.ToString
                End If
                Return mFactoryName
            End Get
            Set(ByVal value As String)
                mFactoryName = value
            End Set
        End Property


        <XmlAttribute("Type")> Public Property ConditionType() As ConditionType
            Get
                Return mConditionType
            End Get
            Set(ByVal Value As ConditionType)
                mConditionType = Value
            End Set
        End Property
        Public Property ConditionInitialValue() As Object
            Get
                Return mConditionInitialValue
            End Get
            Set(ByVal Value As Object)
                mConditionInitialValue = Value
            End Set
        End Property
        Public Property ConditionName() As String
            Get
                Return mConditionName
            End Get
            Set(ByVal Value As String)
                mConditionName = Value
            End Set
        End Property
        <XmlElement("ConditionDescription")> Public Property ConditionDescriptionString() As LocalizableStringProxy
            Get
                Return mConditionDescriptionString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mConditionDescriptionString = value
            End Set
        End Property
        Public Property ConditionIsStatic() As Boolean
            Get
                Return mConditionIsStatic
            End Get
            Set(ByVal Value As Boolean)
                mConditionIsStatic = Value
            End Set
        End Property
        <XmlElement("PrerequisiteFactory")> Public Property PrerequisiteFactoryDefinition() As PredicateFactoryDefinition
            Get
                Return mPrerequisiteFactoryDefinition
            End Get
            Set(ByVal Value As PredicateFactoryDefinition)
                mPrerequisiteFactoryDefinition = Value
            End Set
        End Property
        Public ReadOnly Property InitializationArgs() As ArrayList
            Get
                Return mInitializationArgs
            End Get
        End Property

        Public Function Clone() As Object Implements ICloneable.Clone
            Dim newDef As New ConditionFactoryDefinition
            newDef.FactoryName = FactoryName
            newDef.ConditionType = ConditionType
            newDef.ConditionInitialValue = ConditionInitialValue
            newDef.ConditionName = ConditionName
            newDef.ConditionDescriptionString = ConditionDescriptionString
            newDef.ConditionIsStatic = ConditionIsStatic
            If PrerequisiteFactoryDefinition IsNot Nothing Then
                newDef.PrerequisiteFactoryDefinition = PrerequisiteFactoryDefinition.DeepCopy
            End If
            newDef.InitializationArgs.AddRange(InitializationArgs)

            For i As Integer = 0 To mInitializationArgs.Count - 1
                If TypeOf mInitializationArgs(i) Is LocalizableString Then
                    newDef.InitializationArgs(i) = DirectCast(mInitializationArgs(i), LocalizableString)
                End If
            Next
            Return newDef
        End Function

        Public Function DeepCopy() As ConditionFactoryDefinition
            Return DirectCast(Clone(), ConditionFactoryDefinition)
        End Function

        Public Function CreateConditionFactory(ByVal strings As LocalizableStringCollection) As ConditionFactory
            Dim factory As New ConditionFactory

            ' If we've just been reconstituted, then we change our LocalizableStringProxies to LocalizableStrings
            For i As Integer = 0 To mInitializationArgs.Count - 1
                If TypeOf mInitializationArgs(i) Is LocalizableStringProxy Then
                    mInitializationArgs(i) = DirectCast(mInitializationArgs(i), LocalizableStringProxy).Dereference(strings)
                End If
            Next

            factory.mDefinition = DeepCopy()
            If PrerequisiteFactoryDefinition IsNot Nothing Then
                factory.mPrerequisiteFactory = PrerequisiteFactoryDefinition.CreatePredicateFactory(strings)
            End If
            factory.mConditionDescription = mConditionDescriptionString.Dereference(strings)

            Return factory
        End Function

    End Class



    'End Structure



End Namespace
