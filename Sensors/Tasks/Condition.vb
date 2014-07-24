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

Imports System.Text
Imports System.Xml.Serialization
Imports System.Windows.Forms
Imports System.Collections.Generic

Namespace Mbark.Sensors

    <XmlType("RuntimeCondition")> _
    Public MustInherit Class Condition

        Private mPrerequisite As Predicate
        Private mOriginatingFactory As ConditionFactory
        Private mDefinition As New ConditionDefinition

        Public MustOverride Function StandaloneToString() As String
        Public MustOverride Function CompoundToString() As String

        Friend MustOverride Function Definition( _
            ByVal factories As List(Of ConditionFactory)) As ConditionDefinition

        Protected Sub New()
        End Sub

        Friend Function DeepCopy(ByVal conditions As ConditionCollection) As Condition
            Dim c As Condition = mOriginatingFactory.Create(conditions)
            c.mDefinition.Value = Me.DeepCopyValue()
            Return c
        End Function

        Friend MustOverride Function DeepCopyValue() As Object

        Public ReadOnly Property IsStatic() As Boolean
            Get
                Return mOriginatingFactory.ConditionIsStatic
            End Get
        End Property

        Public ReadOnly Property Description() As String
            Get
                Return mOriginatingFactory.ConditionDescription(Application.CurrentCulture.Name)
            End Get
        End Property

        Public ReadOnly Property Description(ByVal region As String) As String
            Get
                Return mOriginatingFactory.ConditionDescription(region)
            End Get
        End Property

        Public Property Prerequisite() As Predicate
            Get
                If mPrerequisite Is Nothing Then Return BuiltIns.Predicates.TrueLiteral
                Return mPrerequisite
            End Get
            Set(ByVal value As Predicate)
                mPrerequisite = value
            End Set
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return mOriginatingFactory.ConditionName
            End Get
        End Property

        Protected Sub InitialValue(ByVal value As Object)
            mDefinition.Value = value
        End Sub

        Public Overridable Property Value() As Object
            Get
                Return mDefinition.Value
            End Get
            Set(ByVal value As Object)

                ' If the condition is valid, and has indeed changed, then change it. Notice the subtle use
                ' of Me.Value instead of mValue, so that we get dynamic dispatch
                '
                If IsValid AndAlso Not Me.Value.Equals(value) Then
                    Dim eventArgs As New ConditionValueChangedEventArgs(Me, mDefinition.Value, value)
                    mDefinition.Value = value
                    RaiseEvent ConditionValueChanged(Me, eventArgs)
                End If
            End Set
        End Property

        Public Event ConditionValueChanged As EventHandler(Of ConditionValueChangedEventArgs)

        Public ReadOnly Property IsValid() As Boolean
            Get
                If mPrerequisite Is Nothing Then Return True
                Return mPrerequisite.Evaluate
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim builder As New StringBuilder
            If Not IsValid Then builder.Append("*")
            builder.Append(Name).Append("=").Append(Value.ToString)
            Return builder.ToString()
        End Function

        Friend Sub WireOriginatingFactory(ByVal factory As ConditionFactory)
            mOriginatingFactory = factory
        End Sub

        Friend ReadOnly Property OriginatingFactory() As ConditionFactory
            Get
                Return mOriginatingFactory
            End Get
        End Property

    End Class


End Namespace
