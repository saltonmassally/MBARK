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

Option Strict On

Imports System.Collections.Specialized
Imports System.Globalization

Imports Mbark.UI.GlobalUISettings

Namespace Mbark.Sensors


    Public Class ConditionsConflict
        Inherits BaseSensorTaskAttemptConflict

        Private mSuperset As New ConditionCollection
        Private mSubset As New ConditionCollection
        Private mNames As New StringCollection
        Private mSupersetLabels As New StringCollection
        Private mSubsetLabels As New StringCollection

        Private mSupersetLabel As String
        Public Property SupersetLabel() As String
            Get
                Return mSupersetLabel
            End Get
            Set(ByVal value As String)
                mSupersetLabel = value
            End Set
        End Property

        Private mSubsetLabel As String
        Public Property SubsetLabel() As String
            Get
                Return mSubsetLabel
            End Get
            Set(ByVal value As String)
                mSubsetLabel = value
            End Set
        End Property

        Public Sub AddWithDeepCopy( _
            ByVal supersetCondition As Condition, _
            ByVal superset As ConditionCollection, _
            ByVal subsetCondition As Condition, _
            ByVal subset As ConditionCollection)
            Dim name As String

            If supersetCondition Is Nothing Then Throw New ArgumentNullException("supersetCondition")
            If superset Is Nothing Then Throw New ArgumentNullException("superset")
            If subsetCondition Is Nothing Then Throw New ArgumentNullException("subsetCondition")
            If subsetCondition Is Nothing Then Throw New ArgumentNullException("subsetCondition")

            If supersetCondition Is Nothing Then
                name = subsetCondition.Name
            Else
                name = supersetCondition.Name
            End If

            mNames.Add(name)
            mSupersetLabels.Add(SupersetLabel)
            mSubsetLabels.Add(SubsetLabel)

            If Not supersetCondition Is Nothing Then mSuperset(name) = supersetCondition.DeepCopy(mSuperset)
            If Not subsetCondition Is Nothing Then mSubset(name) = subsetCondition.DeepCopy(mSubset)

            ' Make sure to nab the prerequisites
            mSuperset.DeepCopyPrerequisites(supersetCondition, superset)
            mSubset.DeepCopyPrerequisites(subsetCondition, subset)

        End Sub


        Public ReadOnly Property Subset() As ConditionCollection
            Get
                Return mSubset
            End Get
        End Property
        Public ReadOnly Property Superset() As ConditionCollection
            Get
                Return mSuperset
            End Get
        End Property

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return mNames.Count = 0
            End Get
        End Property

        Public Overloads Function ToString(ByVal index As Integer, ByVal culture As CultureInfo) As String
            Dim writer As New System.IO.StringWriter(culture)

            If Not mSuperset(mNames(index)) Is Nothing Then
                With writer
                    .Write(mSupersetLabels(index))
                    .Write(InfrastructureMessages.Messages.ColonSpace(culture))
                    .Write(StringConstants.Space)
                    .WriteLine(mSuperset(mNames(index)).StandaloneToString)
                End With
            End If

            If Not mSubset(mNames(index)) Is Nothing Then
                With writer
                    .Write(mSubsetLabels(index))
                    .Write(InfrastructureMessages.Messages.ColonSpace(culture))
                    .WriteLine(mSubset(mNames(index)).StandaloneToString)
                End With
            End If

            Return writer.ToString
        End Function

        Public Overloads Function ToString(ByVal culture As CultureInfo) As String
            Using writer As New System.IO.StringWriter(culture)
                For i As Integer = 0 To mNames.Count - 1
                    writer.Write(ToString(i, culture))
                    If i <> mNames.Count - 1 Then writer.Write(StringConstants.Space)
                Next
                ToString = writer.ToString()
            End Using

        End Function

        Public Overrides Function ToRtf(ByVal culture As CultureInfo, ByVal standalone As Boolean) As String
            Dim toRtfResult As String
            Dim writer As New System.IO.StringWriter(CultureInfo.InvariantCulture)
            If standalone Then writer.Write(Rtf.Header())

            ' Put all of the conditions that share the same label together. We assume that
            ' subset and superset labels will be different. If not, they'll clobber each other here
            Dim labelToConditions As New Hashtable
            For i As Integer = 0 To mNames.Count - 1

                Dim conditions As StringCollection

                If labelToConditions(mSupersetLabels(i)) Is Nothing Then
                    labelToConditions(mSupersetLabels(i)) = New StringCollection
                End If

                If labelToConditions(mSubsetLabels(i)) Is Nothing Then
                    labelToConditions(mSubsetLabels(i)) = New StringCollection
                End If

                If Not mSuperset(mNames(i)) Is Nothing Then
                    conditions = DirectCast(labelToConditions(mSupersetLabels(i)), StringCollection)
                    Dim description As String = mSuperset(mNames(i)).StandaloneToString
                    If Not conditions.Contains(description) AndAlso mSuperset(mNames(i)).IsValid Then conditions.Add(description)
                End If

                If Not mSubset(mNames(i)) Is Nothing Then
                    conditions = DirectCast(labelToConditions(mSubsetLabels(i)), StringCollection)
                    Dim description As String = mSubset(mNames(i)).StandaloneToString
                    ' It only matter if the *superset* condition is valid here
                    If Not conditions.Contains(description) AndAlso mSuperset(mNames(i)).IsValid Then conditions.Add(description)

                End If
            Next

            Dim en As IEnumerator = labelToConditions.Keys.GetEnumerator
            While en.MoveNext
                Dim label As String = DirectCast(en.Current, String)
                writer.Write(Rtf.BoldOn)
                writer.Write(label)
                writer.Write(Rtf.BoldOff)
                writer.Write(InfrastructureMessages.Messages.ColonSpace(culture))
                Dim conds As StringCollection = DirectCast(labelToConditions(label), StringCollection)
                If conds.Count = 0 Then writer.Write(InfrastructureMessages.Messages.None(culture))
                For i As Integer = 0 To conds.Count - 1
                    writer.Write(conds(i))
                    If i <> conds.Count - 1 Then
                        writer.Write(InfrastructureMessages.Messages.Comma(culture))
                        writer.Write(StringConstants.Space)
                    End If
                Next
                writer.Write(Rtf.Newline)
            End While

            If standalone Then writer.Write(Rtf.Footer)
            toRtfResult = writer.ToString
            writer.Dispose()
            Return toRtfResult
        End Function

    End Class

End Namespace
