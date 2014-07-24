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

Imports System.Windows.Forms
Imports System.Collections.Generic

Imports Mbark.UI.GlobalUISettings

Imports LocalizableStringProxy = Mbark.NamedProxy(Of Mbark.LocalizableString)

Namespace Mbark.Sensors

    Public Class BooleanCondition
        Inherits Condition

        Public Overloads Function Equals(ByVal arg As Boolean) As Boolean
            Return DirectCast(Value, Boolean) = arg
        End Function
        Public Overrides Property Value() As Object
            Get
                If MyBase.Value Is Nothing Then Return False Else Return MyBase.Value
            End Get
            Set(ByVal value As Object)
                If Prerequisite Is Nothing OrElse Prerequisite.Evaluate Then
                    MyBase.Value = value
                Else
                    MyBase.Value = Nothing
                End If
            End Set
        End Property

        Private mDefinition As New BooleanConditionDefinition

        Private mStandaloneTrueString As LocalizableString
        Private mStandaloneFalseString As LocalizableString
        Private mStandaloneInvalidString As LocalizableString
        Private mCompoundTrueString As LocalizableString
        Private mCompoundFalseString As LocalizableString
        Private mCompoundInvalidString As LocalizableString

        Friend Sub New( _
            ByVal initialValue As Boolean, _
            ByVal standaloneTrueString As LocalizableString, _
            ByVal standaloneFalseString As LocalizableString, _
            ByVal standaloneInvalidString As LocalizableString, _
            ByVal compoundTrueString As LocalizableString, _
            ByVal compoundFalseString As LocalizableString, _
            ByVal compoundInvalidString As LocalizableString)

            ' Only factories should be able to create contidions

            MyBase.New()
            MyBase.InitialValue(initialValue)


            mStandaloneTrueString = standaloneTrueString
            mStandaloneFalseString = standaloneFalseString
            mStandaloneInvalidString = standaloneInvalidString

            mCompoundTrueString = compoundTrueString
            mCompoundFalseString = compoundFalseString
            mCompoundInvalidString = compoundInvalidString

        End Sub


        Public Overrides Function StandaloneToString() As String
            If Not IsValid Then Return mStandaloneInvalidString(Application.CurrentCulture.Name)
            If DirectCast(Value, Boolean) Then Return mStandaloneTrueString(Application.CurrentCulture.Name)
            Return mStandaloneFalseString(Application.CurrentCulture.Name)
        End Function

        Public Overrides Function CompoundToString() As String
            If Not IsValid Then Return mCompoundInvalidString(Application.CurrentCulture.Name)
            If DirectCast(Value, Boolean) Then Return mCompoundTrueString(Application.CurrentCulture.Name)
            Return mCompoundFalseString(Application.CurrentCulture.Name)
        End Function


        Friend Overrides Function DeepCopyValue() As Object
            Dim val As Boolean = DirectCast(Value, Boolean)
            If val Then Return CObj(True) Else Return CObj(False)
        End Function


        Friend Overrides Function Definition(ByVal factories As List(Of ConditionFactory)) _
        As ConditionDefinition

            Dim newDef As BooleanConditionDefinition = DirectCast(mDefinition.DeepCopy(), BooleanConditionDefinition)

            With newDef
                .StandaloneTrueString = New LocalizableStringProxy(mStandaloneTrueString)
                .StandaloneFalseString = New LocalizableStringProxy(mStandaloneFalseString)
                .StandaloneInvalidString = New LocalizableStringProxy(mStandaloneInvalidString)

                .CompoundTrueString = New LocalizableStringProxy(mCompoundTrueString)
                .CompoundFalseString = New LocalizableStringProxy(mCompoundFalseString)
                .CompoundInvalidString = New LocalizableStringProxy(mCompoundInvalidString)

                .OriginatingFactory = OriginatingFactory.FactoryName
                .BooleanValue = CType(Value, Boolean)
                .PrerequisiteDefinition = Prerequisite.CreateDefinition
            End With

            Return newDef.DeepCopy
        End Function


    End Class

    <Serializable()> Public Class BooleanConditionDefinition
        Inherits ConditionDefinition

#Region "Private"


        Private mBooleanValue As Boolean
        Private mCompoundFalseString As LocalizableStringProxy
        Private mCompoundInvalidString As LocalizableStringProxy
        Private mCompoundTrueString As LocalizableStringProxy
        Private mStandaloneFalseString As LocalizableStringProxy
        Private mStandaloneInvalidString As LocalizableStringProxy
        Private mStandaloneTrueString As LocalizableStringProxy
#End Region

#Region "Properties"
        Public Property StandaloneFalseString() As LocalizableStringProxy
            Get
                Return mStandaloneFalseString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mStandaloneFalseString = value
            End Set
        End Property
        Public Property CompoundTrueString() As LocalizableStringProxy
            Get
                Return mCompoundTrueString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mCompoundTrueString = value
            End Set
        End Property

        Public Property StandaloneTrueString() As LocalizableStringProxy
            Get
                Return mStandaloneTrueString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mStandaloneTrueString = value
            End Set
        End Property

        Public Property StandaloneInvalidString() As LocalizableStringProxy
            Get
                Return mStandaloneInvalidString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mStandaloneInvalidString = value
            End Set
        End Property
        Public Property CompoundFalseString() As LocalizableStringProxy
            Get
                Return mCompoundFalseString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mCompoundFalseString = value
            End Set
        End Property
        Public Property CompoundInvalidString() As LocalizableStringProxy
            Get
                Return mCompoundInvalidString
            End Get
            Set(ByVal value As LocalizableStringProxy)
                mCompoundInvalidString = value
            End Set
        End Property
        Public Property BooleanValue() As Boolean
            Get
                Return mBooleanValue
            End Get
            Set(ByVal Value As Boolean)
                mBooleanValue = Value
            End Set
        End Property
#End Region

#Region "Clone"
        Public Overrides Function Clone() As Object
            Dim newDef As New BooleanConditionDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Protected Overloads Sub CloneImplementation(ByVal definition As BooleanConditionDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            MyBase.CloneImplementation(definition)

            ' LocalizableStringProxys are structures, so we get a deep copy for free.
            definition.StandaloneTrueString = StandaloneTrueString
            definition.StandaloneFalseString = StandaloneFalseString
            definition.StandaloneInvalidString = StandaloneInvalidString
            definition.CompoundTrueString = CompoundTrueString
            definition.CompoundFalseString = CompoundFalseString
            definition.CompoundInvalidString = CompoundInvalidString
            definition.BooleanValue = BooleanValue
        End Sub
#End Region

        Public Overrides Function CreateCondition( _
            ByVal conditions As ConditionCollection, _
            ByVal factory As ConditionFactory, _
            ByVal stringLibrary As LocalizableStringCollection) As Condition

            If factory Is Nothing Then Throw New ArgumentNullException("factory")
            If stringLibrary Is Nothing Then Throw New ArgumentNullException("stringLibrary")

            Dim condition As New BooleanCondition( _
                CType(BooleanValue, Boolean), _
                stringLibrary(StandaloneTrueString.Name), _
                stringLibrary(StandaloneFalseString.Name), _
                stringLibrary(StandaloneInvalidString.Name), _
                stringLibrary(CompoundTrueString.Name), _
                stringLibrary(CompoundFalseString.Name), _
                stringLibrary(CompoundInvalidString.Name))


            If Not PrerequisiteDefinition Is Nothing Then
                condition.Prerequisite = PrerequisiteDefinition.CreatePredicate(conditions, stringLibrary)
            End If


            condition.WireOriginatingFactory(factory)
            Return condition
        End Function


    End Class



End Namespace
