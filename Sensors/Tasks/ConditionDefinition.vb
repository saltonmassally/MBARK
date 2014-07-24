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

Namespace Mbark.Sensors

    < _
    XmlType("Condition"), _
    XmlInclude(GetType(BooleanConditionDefinition)), _
    Serializable()> _
    Public Class ConditionDefinition
        Implements ICloneable

        ' •—————————————————————————————————————————————————————————————————————————————————•
        ' | This class describes the auto-serializable components of Condition              |
        ' •—————————————————————————————————————————————————————————————————————————————————•

        Private mPrerequisiteDefinition As PredicateDefinition
        Private mValue As Object
        Private mOriginatingFactory As String = String.Empty

        <XmlElement("Prerequisite")> Public Property PrerequisiteDefinition() As PredicateDefinition
            Get
                Return mPrerequisiteDefinition
            End Get
            Set(ByVal Value As PredicateDefinition)
                mPrerequisiteDefinition = Value
            End Set
        End Property


        Public Property Value() As Object
            Get
                Return mValue
            End Get
            Set(ByVal Value As Object)
                mValue = Value
            End Set
        End Property

        <XmlAttribute()> Public Property OriginatingFactory() As String
            Get
                Return mOriginatingFactory
            End Get
            Set(ByVal value As String)
                mOriginatingFactory = value
            End Set
        End Property

        Public Overridable Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New ConditionDefinition
            CloneImplementation(newDef)
            Return newDef
        End Function

        Public Overridable Function DeepCopy() As ConditionDefinition
            Return DirectCast(Clone(), ConditionDefinition)
        End Function

        Protected Sub CloneImplementation(ByVal definition As ConditionDefinition)
            If definition Is Nothing Then Throw New ArgumentNullException("definition")
            If Not PrerequisiteDefinition Is Nothing Then
                definition.PrerequisiteDefinition = PrerequisiteDefinition.DeepCopy
            End If
            definition.Value = Value
            definition.OriginatingFactory = OriginatingFactory
        End Sub

        Public Overridable Function CreateCondition( _
            ByVal conditions As ConditionCollection, _
            ByVal factory As ConditionFactory, _
            ByVal stringLibrary As LocalizableStringCollection) As Condition
            Throw New MissingSpecializationException("CreateCondition")
        End Function


    End Class

End Namespace
