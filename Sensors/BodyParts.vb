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

Imports System.Globalization
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Xml.Serialization

Imports Mbark.SensorMessages
Imports System.Drawing

Namespace Mbark.Sensors

    <Serializable()> Public Enum BodyPart
        Unknown
        Face
        LeftIris
        RightIris
        LeftPalm
        RightPalm
        Voice
        LeftThumb = 12
        LeftIndex = 19
        LeftMiddle = 20
        LeftRing = 21
        LeftLittle = 22
        RightThumb = 11
        RightIndex = 15
        RightMiddle = 16
        RightRing = 17
        RightLittle = 18
    End Enum

    <Serializable()> Public Class BodyPartCollection
        Inherits List(Of BodyPart)

        Private mReadOnly As Boolean
        <NonSerialized()> Private mInsideUpdate As Boolean
        <NonSerialized()> Private mPartsAddedDuringUpdate As New Collection(Of BodyPart)
        <NonSerialized()> Private mPartsRemovedDuringUpdate As New Collection(Of BodyPart)
        Private mDescription As String

        Public Property Description() As String
            Get
                Return mDescription
            End Get
            Set(ByVal value As String)
                mDescription = value
            End Set
        End Property

        Public Sub BeginUpdate()
            If mInsideUpdate = True Then Throw New UnfinishedBodyPartsUpdateException
            mInsideUpdate = True
            mPartsAddedDuringUpdate = New Collection(Of BodyPart)
            mPartsRemovedDuringUpdate = New Collection(Of BodyPart)
        End Sub

        Public Sub EndUpdate()
            mInsideUpdate = False
            If mPartsAddedDuringUpdate.Count > 0 Or mPartsRemovedDuringUpdate.Count > 0 Then
                SyncLock Me
                    RaiseEvent BodyPartsChanged(Me, New BodyPartsChangeEventArgs(mPartsAddedDuringUpdate, mPartsRemovedDuringUpdate))
                End SyncLock
            End If
        End Sub

        Private Shared smLeftSlap As BodyPartCollection
        Private Shared smLeftHand As BodyPartCollection
        Private Shared smThumbsSlap As BodyPartCollection

        Private Shared smRightHand As BodyPartCollection
        Private Shared smRightSlap As BodyPartCollection

        Private Shared smFace As BodyPartCollection

        Private Shared smLeftIris As BodyPartCollection
        Private Shared smRightIris As BodyPartCollection
        Private Shared smBothIrises As BodyPartCollection

        Private Shared smLeftThumb As BodyPartCollection
        Private Shared smLeftIndex As BodyPartCollection
        Private Shared smLeftMiddle As BodyPartCollection
        Private Shared smLeftRing As BodyPartCollection
        Private Shared smLeftLittle As BodyPartCollection

        Private Shared smRightThumb As BodyPartCollection
        Private Shared smRightIndex As BodyPartCollection
        Private Shared smRightMiddle As BodyPartCollection
        Private Shared smRightRing As BodyPartCollection
        Private Shared smRightLittle As BodyPartCollection

        Private Shared smLeftPalm As BodyPartCollection
        Private Shared smRightPalm As BodyPartCollection

        Private Shared smVoice As BodyPartCollection

        Private Shared smEmpty As BodyPartCollection

        Public Shared ReadOnly Property ForLeftSlapTask() As BodyPartCollection
            Get
                If smLeftSlap Is Nothing Then
                    smLeftSlap = New BodyPartCollection
                    With smLeftSlap
                        .UncheckedAdd(BodyPart.LeftIndex)
                        .UncheckedAdd(BodyPart.LeftMiddle)
                        .UncheckedAdd(BodyPart.LeftRing)
                        .UncheckedAdd(BodyPart.LeftLittle)
                        .mReadOnly = True
                    End With

                End If
                Return smLeftSlap
            End Get
        End Property
        Public Shared ReadOnly Property ForLeftHand() As BodyPartCollection
            Get
                If smLeftHand Is Nothing Then
                    smLeftHand = New BodyPartCollection
                    With smLeftHand
                        .UncheckedAdd(BodyPart.LeftIndex)
                        .UncheckedAdd(BodyPart.LeftMiddle)
                        .UncheckedAdd(BodyPart.LeftRing)
                        .UncheckedAdd(BodyPart.LeftLittle)
                        .UncheckedAdd(BodyPart.LeftThumb)
                        .UncheckedAdd(BodyPart.LeftPalm)
                        .mReadOnly = True
                    End With

                End If
                Return smLeftHand
            End Get
        End Property
        Public Shared ReadOnly Property ForRightHand() As BodyPartCollection
            Get
                If smRightHand Is Nothing Then
                    smRightHand = New BodyPartCollection
                    With smRightHand
                        .UncheckedAdd(BodyPart.RightIndex)
                        .UncheckedAdd(BodyPart.RightMiddle)
                        .UncheckedAdd(BodyPart.RightRing)
                        .UncheckedAdd(BodyPart.RightLittle)
                        .UncheckedAdd(BodyPart.RightThumb)
                        .UncheckedAdd(BodyPart.RightPalm)
                        .mReadOnly = True
                    End With

                End If
                Return smRightHand
            End Get
        End Property

        Public Shared ReadOnly Property ForTask(ByVal category As SensorTaskCategory) As BodyPartCollection
            Get
                Select Case category
                    Case SensorTaskCategory.LeftSlap : Return ForLeftSlapTask
                    Case SensorTaskCategory.RightSlap : Return ForRightSlapTask
                    Case SensorTaskCategory.ThumbsSlap : Return ForThumbsSlapTask
                    Case SensorTaskCategory.LeftIris : Return ForLeftIrisTask
                    Case SensorTaskCategory.RightIris : Return ForRightIrisTask
                    Case SensorTaskCategory.Face : Return ForFaceTask

                    Case SensorTaskCategory.FlatLeftThumb : Return ForFlatLeftThumb
                    Case SensorTaskCategory.FlatLeftIndex : Return ForFlatLeftIndex
                    Case SensorTaskCategory.FlatLeftMiddle : Return ForFlatLeftMiddle
                    Case SensorTaskCategory.FlatLeftRing : Return ForFlatLeftRing
                    Case SensorTaskCategory.FlatLeftLittle : Return ForFlatLeftLittle
                    Case SensorTaskCategory.FlatRightThumb : Return ForFlatRightThumb
                    Case SensorTaskCategory.FlatRightIndex : Return ForFlatRightIndex
                    Case SensorTaskCategory.FlatRightMiddle : Return ForFlatRightMiddle
                    Case SensorTaskCategory.FlatRightRing : Return ForFlatRightRing
                    Case SensorTaskCategory.FlatRightLittle : Return ForFlatRightLittle

                    Case SensorTaskCategory.RolledLeftThumb : Return ForRolledLeftThumb
                    Case SensorTaskCategory.RolledLeftIndex : Return ForRolledLeftIndex
                    Case SensorTaskCategory.RolledLeftMiddle : Return ForRolledLeftMiddle
                    Case SensorTaskCategory.RolledLeftRing : Return ForRolledLeftRing
                    Case SensorTaskCategory.RolledLeftLittle : Return ForRolledLeftLittle
                    Case SensorTaskCategory.RolledRightThumb : Return ForRolledRightThumb
                    Case SensorTaskCategory.RolledRightIndex : Return ForRolledRightIndex
                    Case SensorTaskCategory.RolledRightMiddle : Return ForRolledRightMiddle
                    Case SensorTaskCategory.RolledRightRing : Return ForRolledRightRing
                    Case SensorTaskCategory.RolledRightLittle : Return ForRolledRightLittle

                    Case SensorTaskCategory.LeftPalm : Return ForLeftPalmTask
                    Case SensorTaskCategory.RightPalm : Return ForRightPalmTask

                    Case Else
                        Throw New NotImplementedException
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property ForRightSlapTask() As BodyPartCollection
            Get
                If smRightSlap Is Nothing Then
                    smRightSlap = New BodyPartCollection
                    With smRightSlap
                        .UncheckedAdd(BodyPart.RightIndex)
                        .UncheckedAdd(BodyPart.RightMiddle)
                        .UncheckedAdd(BodyPart.RightRing)
                        .UncheckedAdd(BodyPart.RightLittle)
                        .mReadOnly = True
                    End With
                End If
                Return smRightSlap
            End Get
        End Property
        Public Shared ReadOnly Property ForThumbsSlapTask() As BodyPartCollection
            Get
                If smThumbsSlap Is Nothing Then
                    smThumbsSlap = New BodyPartCollection
                    With smThumbsSlap
                        .UncheckedAdd(BodyPart.LeftThumb)
                        .UncheckedAdd(BodyPart.RightThumb)
                        .mReadOnly = True
                    End With
                End If
                Return smThumbsSlap
            End Get
        End Property
        Public Shared ReadOnly Property ForLeftPalmTask() As BodyPartCollection
            Get
                If smLeftPalm Is Nothing Then
                    smLeftPalm = New BodyPartCollection
                    With smLeftPalm
                        .UncheckedAdd(BodyPart.LeftPalm)
                    End With
                End If
                Return smLeftPalm
            End Get
        End Property
        Public Shared ReadOnly Property ForRightPalmTask() As BodyPartCollection
            Get
                If smRightPalm Is Nothing Then
                    smRightPalm = New BodyPartCollection
                    With smRightPalm
                        .UncheckedAdd(BodyPart.RightPalm)
                    End With
                End If
                Return smRightPalm
            End Get
        End Property
        Public Shared ReadOnly Property ForFaceTask() As BodyPartCollection
            Get
                If smFace Is Nothing Then
                    smFace = New BodyPartCollection
                    With smFace
                        .UncheckedAdd(BodyPart.Face)
                        .mReadOnly = True
                    End With
                End If
                Return smFace
            End Get
        End Property
        Public Shared ReadOnly Property ForLeftIrisTask() As BodyPartCollection
            Get
                If smLeftIris Is Nothing Then
                    smLeftIris = New BodyPartCollection
                    With smLeftIris
                        .UncheckedAdd(BodyPart.LeftIris)
                        .mReadOnly = True
                    End With
                End If
                Return smLeftIris
            End Get
        End Property
        Public Shared ReadOnly Property ForRightIrisTask() As BodyPartCollection
            Get
                If smRightIris Is Nothing Then
                    smRightIris = New BodyPartCollection
                    With smRightIris
                        .UncheckedAdd(BodyPart.RightIris)
                        .mReadOnly = True
                    End With
                End If
                Return smRightIris
            End Get
        End Property
        Public Shared ReadOnly Property ForBothIrises() As BodyPartCollection
            Get
                If smBothIrises Is Nothing Then
                    smBothIrises = New BodyPartCollection
                    With smBothIrises
                        .UncheckedAdd(BodyPart.RightIris)
                        .UncheckedAdd(BodyPart.LeftIris)
                        .mReadOnly = True
                    End With
                End If
                Return smBothIrises
            End Get
        End Property

        Public Shared ReadOnly Property ForFlatLeftThumb() As BodyPartCollection
            Get
                If smLeftThumb Is Nothing Then
                    smLeftThumb = New BodyPartCollection
                    With smLeftThumb
                        .UncheckedAdd(BodyPart.LeftThumb)
                        .mReadOnly = True
                    End With
                End If
                Return smLeftThumb
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledLeftThumb() As BodyPartCollection
            Get
                Return ForFlatLeftThumb
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatLeftIndex() As BodyPartCollection
            Get
                If smLeftIndex Is Nothing Then
                    smLeftIndex = New BodyPartCollection
                    With smLeftIndex
                        .UncheckedAdd(BodyPart.LeftIndex)
                        .mReadOnly = True
                    End With
                End If
                Return smLeftIndex
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledLeftIndex() As BodyPartCollection
            Get
                Return ForFlatLeftIndex
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatLeftMiddle() As BodyPartCollection
            Get
                If smLeftMiddle Is Nothing Then
                    smLeftMiddle = New BodyPartCollection
                    With smLeftMiddle
                        .UncheckedAdd(BodyPart.LeftMiddle)
                        .mReadOnly = True
                    End With
                End If
                Return smLeftMiddle
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledLeftMiddle() As BodyPartCollection
            Get
                Return ForFlatLeftMiddle
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatLeftRing() As BodyPartCollection
            Get
                If smLeftRing Is Nothing Then
                    smLeftRing = New BodyPartCollection
                    With smLeftRing
                        .UncheckedAdd(BodyPart.LeftRing)
                        .mReadOnly = True
                    End With
                End If
                Return smLeftRing
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledLeftRing() As BodyPartCollection
            Get
                Return ForFlatLeftRing
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatLeftLittle() As BodyPartCollection
            Get
                If smLeftLittle Is Nothing Then
                    smLeftLittle = New BodyPartCollection
                    With smLeftLittle
                        .UncheckedAdd(BodyPart.LeftLittle)
                        .mReadOnly = True
                    End With
                End If
                Return smLeftLittle
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledLeftLittle() As BodyPartCollection
            Get
                Return ForFlatLeftLittle
            End Get
        End Property

        Public Shared ReadOnly Property ForFlatRightThumb() As BodyPartCollection
            Get
                If smRightThumb Is Nothing Then
                    smRightThumb = New BodyPartCollection
                    With smRightThumb
                        .UncheckedAdd(BodyPart.RightThumb)
                        .mReadOnly = True
                    End With
                End If
                Return smRightThumb
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledRightThumb() As BodyPartCollection
            Get
                Return ForFlatRightThumb
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatRightIndex() As BodyPartCollection
            Get
                If smRightIndex Is Nothing Then
                    smRightIndex = New BodyPartCollection
                    With smRightIndex
                        .UncheckedAdd(BodyPart.RightIndex)
                        .mReadOnly = True
                    End With
                End If
                Return smRightIndex
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledRightIndex() As BodyPartCollection
            Get
                Return ForFlatRightIndex
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatRightMiddle() As BodyPartCollection
            Get
                If smRightMiddle Is Nothing Then
                    smRightMiddle = New BodyPartCollection
                    With smRightMiddle
                        .UncheckedAdd(BodyPart.RightMiddle)
                        .mReadOnly = True
                    End With
                End If
                Return smRightMiddle
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledRightMiddle() As BodyPartCollection
            Get
                Return ForFlatRightMiddle
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatRightRing() As BodyPartCollection
            Get
                If smRightRing Is Nothing Then
                    smRightRing = New BodyPartCollection
                    With smRightRing
                        .UncheckedAdd(BodyPart.RightRing)
                        .mReadOnly = True
                    End With
                End If
                Return smRightRing
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledRightRing() As BodyPartCollection
            Get
                Return ForFlatRightRing
            End Get
        End Property
        Public Shared ReadOnly Property ForFlatRightLittle() As BodyPartCollection
            Get
                If smRightLittle Is Nothing Then
                    smRightLittle = New BodyPartCollection
                    With smRightLittle
                        .UncheckedAdd(BodyPart.RightLittle)
                        .mReadOnly = True
                    End With
                End If
                Return smRightLittle
            End Get
        End Property
        Public Shared ReadOnly Property ForRolledRightLittle() As BodyPartCollection
            Get
                Return ForFlatRightLittle
            End Get
        End Property

        Public Shared ReadOnly Property Empty() As BodyPartCollection
            Get
                If smEmpty Is Nothing Then
                    smEmpty = New BodyPartCollection
                    smEmpty.mReadOnly = True
                End If
                Return smEmpty
            End Get
        End Property
        Public Shared ReadOnly Property ForVoiceTask() As BodyPartCollection
            Get
                If smVoice Is Nothing Then
                    smVoice = New BodyPartCollection
                    smVoice.UncheckedAdd(BodyPart.Voice)
                    smVoice.mReadOnly = True
                End If
                Return smVoice
            End Get
        End Property


        Public Sub Assign(ByVal parts As BodyPartCollection)
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            MyBase.Clear()
            mDescription = parts.mDescription
            MyBase.AddRange(parts)
        End Sub

        Private Sub UncheckedAdd(ByVal part As BodyPart)
            MyBase.Add(part)
        End Sub

        Public Overloads Sub Add(ByVal part As BodyPart)

            If mReadOnly Then Throw New ReadOnlyException
            If Not Contains(part) Then
                MyBase.Add(part)
                MyBase.Sort()
                If Me.mInsideUpdate Then
                    mPartsAddedDuringUpdate.Add(part)
                Else
                    Dim partsAdded As New Collection(Of BodyPart)
                    partsAdded.Add(part)
                    SyncLock Me
                        RaiseEvent BodyPartsChanged(Me, New BodyPartsChangeEventArgs(partsAdded, New Collection(Of BodyPart)))
                    End SyncLock
                End If
            End If
        End Sub

        Friend Sub AddIfContainedInOtherSet(ByVal otherSet As BodyPartCollection, ByVal part As BodyPart)
            If otherSet Is Nothing Then Throw New ArgumentNullException("otherSet")
            If otherSet.Contains(part) Then Add(part)
        End Sub

        Friend Sub AddEachPartIfContainedInOtherSet(ByVal otherSet As BodyPartCollection, ByVal parts As BodyPartCollection)

            If otherSet Is Nothing Then Throw New ArgumentNullException("otherSet")
            If parts Is Nothing Then Throw New ArgumentNullException("parts")

            For i As Integer = 0 To parts.Count - 1
                AddIfContainedInOtherSet(otherSet, parts(i))
            Next
        End Sub

        Friend Sub RemoveIfNotContainedInOtherSet(ByVal otherSet As BodyPartCollection, ByVal part As BodyPart)
            If otherSet Is Nothing Then Throw New ArgumentNullException("otherSet")
            If Not otherSet.Contains(part) Then Remove(part)
        End Sub

        Friend Sub RemoveEachPartIfNotContainedInOtherSet(ByVal otherSet As BodyPartCollection, ByVal parts As BodyPartCollection)

            If otherSet Is Nothing Then Throw New ArgumentNullException("otherSet")
            If parts Is Nothing Then Throw New ArgumentNullException("parts")

            For i As Integer = 0 To parts.Count - 1
                RemoveIfNotContainedInOtherSet(otherSet, parts(i))
            Next
        End Sub

        Public Overloads Sub Remove(ByVal part As BodyPart)
            If mReadOnly Then Throw New ReadOnlyException
            If Me.Contains(part) Then
                MyBase.Remove(part)
                MyBase.Sort()
                If Me.mInsideUpdate Then
                    mPartsRemovedDuringUpdate.Add(part)
                Else
                    Dim partsRemoved As New Collection(Of BodyPart)
                    partsRemoved.Add(part)
                    SyncLock Me
                        RaiseEvent BodyPartsChanged(Me, New BodyPartsChangeEventArgs(New Collection(Of BodyPart), partsRemoved))
                    End SyncLock
                End If

            End If
        End Sub


        'Friend Overloads Sub AddRange(ByVal parts As IEnumerable(Of BodyPart), ByVal raiseEvents As Boolean)
        '    If parts Is Nothing Then Throw New ArgumentNullException("parts")
        '    Dim en As IEnumerator(Of BodyPart) = parts.GetEnumerator
        '    If mReadOnly Then Throw New ReadOnlyException
        '    If raiseEvents Then BeginUpdate()
        '    While en.MoveNext
        '        MyBase.Add(en.Current)
        '    End While
        '    If raiseEvents Then EndUpdate()
        'End Sub

        Friend Overloads Sub RemoveRange(ByVal parts As IEnumerable(Of BodyPart), ByVal raiseEvents As Boolean)

            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            If parts Is Me Then parts = Me.DeepCopy

            Dim en As IEnumerator(Of BodyPart) = parts.GetEnumerator
            If mReadOnly Then Throw New ReadOnlyException
            If raiseEvents Then BeginUpdate()
            While en.MoveNext
                MyBase.Remove(en.Current)
            End While
            If raiseEvents Then EndUpdate()
        End Sub


        Public Shared Function OnLeftHand(ByVal part As BodyPart) As Boolean
            Return _
                part = BodyPart.LeftThumb OrElse _
                part = BodyPart.LeftIndex OrElse _
                part = BodyPart.LeftMiddle OrElse _
                part = BodyPart.LeftRing OrElse _
                part = BodyPart.LeftLittle
        End Function

        Public Shared Function OnRightHand(ByVal part As BodyPart) As Boolean
            Return _
                           part = BodyPart.RightThumb OrElse _
                           part = BodyPart.RightIndex OrElse _
                           part = BodyPart.RightMiddle OrElse _
                           part = BodyPart.RightRing OrElse _
                           part = BodyPart.RightLittle
        End Function

        Public Function ContainsSet(ByVal parts As BodyPartCollection) As Boolean
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            ContainsSet = True
            For i As Integer = 0 To parts.Count - 1
                If Not Contains(parts(i)) Then Return False
            Next
        End Function

        Public Function ContainsAny(ByVal parts As BodyPartCollection) As Boolean
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            ContainsAny = False
            For i As Integer = 0 To parts.Count - 1
                If Contains(parts(i)) Then Return True
            Next
        End Function

        Public Function ContainsNone(ByVal parts As BodyPartCollection) As Boolean
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            ContainsNone = True
            For i As Integer = 0 To parts.Count - 1
                If Contains(parts(i)) Then Return False
            Next
        End Function

        Public Overloads Function Equals(ByVal parts As BodyPartCollection) As Boolean
            If parts Is Nothing Then Throw New ArgumentNullException("parts")
            Return Me.ContainsSet(parts) AndAlso parts.ContainsSet(Me)
        End Function



        Public Event BodyPartsChanged As EventHandler(Of BodyPartsChangeEventArgs)


        Public Overloads Function ToString() As String
            Return ToString(CultureInfo.CurrentUICulture)
        End Function

        Public Overloads Function ToString(ByVal culture As CultureInfo) As String

            If Me.Count = 0 Then Return InfrastructureMessages.Messages.None(culture)

            Dim builder As New System.Text.StringBuilder
            Dim workingCopy As BodyPartCollection = Me.DeepCopy

            If workingCopy.ContainsSet(BodyPartCollection.ForLeftHand) Then
                builder.Append(Messages.LeftHand(culture))
                workingCopy.RemoveRange(BodyPartCollection.ForLeftHand, False)
            End If

            If workingCopy.ContainsSet(BodyPartCollection.ForRightHand) Then
                builder.Append(Messages.RightHand(culture))
                workingCopy.RemoveRange(BodyPartCollection.ForRightHand, False)
            End If


            For i As Integer = 0 To workingCopy.Count - 1
                Dim part As BodyPart = workingCopy(i)
                builder.Append(ToString(culture, part))
                If i <> Me.Count - 1 Then
                    builder.Append(InfrastructureMessages.Messages.CommaSpace(culture))
                End If
            Next
            Return builder.ToString
        End Function

        Public Overloads Shared Function ToString(ByVal culture As CultureInfo, ByVal part As BodyPart) As String
            Select Case part
                Case BodyPart.Face
                    Return Messages.Face(culture)

                Case BodyPart.LeftIndex
                    Return Messages.LeftIndexFinger(culture)
                Case BodyPart.LeftIris
                    Return Messages.LeftIris(culture)

                Case BodyPart.LeftLittle
                    Return Messages.LeftLittleFinger(culture)

                Case BodyPart.LeftMiddle
                    Return Messages.LeftMiddleFinger(culture)

                Case BodyPart.LeftRing
                    Return Messages.LeftRingFinger(culture)

                Case BodyPart.LeftThumb
                    Return Messages.LeftThumb(culture)

                Case BodyPart.LeftPalm
                    Return Messages.LeftPalm(culture)

                Case BodyPart.RightIndex
                    Return Messages.RightIndexFinger(culture)

                Case BodyPart.RightIris
                    Return Messages.RightIris(culture)

                Case BodyPart.RightLittle
                    Return Messages.RightLittleFinger(culture)

                Case BodyPart.RightMiddle
                    Return Messages.RightMiddleFinger(culture)

                Case BodyPart.RightRing
                    Return Messages.RightRingFinger(culture)

                Case BodyPart.RightThumb
                    Return Messages.RightThumb(culture)

                Case BodyPart.RightPalm
                    Return Messages.RightPalm(culture)

                Case BodyPart.voice
                    Return Messages.Voice(culture)

                Case Else
                    Return part.ToString
            End Select

        End Function

        Public Function BodyCategory(ByVal culture As CultureInfo) As String
            If ContainsSet(ForLeftSlapTask) Then
                Return Messages.LeftSlap(culture)
            ElseIf ContainsSet(ForRightSlapTask) Then
                Return Messages.RightSlap(culture)
            ElseIf ContainsSet(ForThumbsSlapTask) Then
                Return Messages.ThumbsSlap(culture)
            ElseIf ContainsSet(ForLeftIrisTask) Then
                Return Messages.LeftIris(culture)
            ElseIf ContainsSet(ForRightIrisTask) Then
                Return Messages.RightIris(culture)
            ElseIf ContainsSet(ForFaceTask) Then
                Return Messages.Face(culture)
            Else
                Return InfrastructureMessages.Messages.Other(culture)
            End If
        End Function

        Public Sub New()

        End Sub

        Public Function DeepCopy() As BodyPartCollection
            Dim bp As New BodyPartCollection
            bp.AddRange(Me)
            bp.Description = Description
            Return bp
        End Function

        Public Sub New(ByVal part As BodyPart)
            MyClass.New()
            Add(part)
        End Sub


    End Class

    Public Class BodyPartsChangeEventArgs
        Inherits EventArgs
        Private mIsAddition As Boolean
        Private mPartsAdded As New Collection(Of BodyPart)
        Private mPartsRemoved As New Collection(Of BodyPart)

        Public ReadOnly Property ChangeWasAnAddition() As Boolean
            Get
                Return mIsAddition
            End Get
        End Property


        Public ReadOnly Property PartsAdded() As Collection(Of BodyPart)
            Get
                Return mPartsAdded
            End Get
        End Property

        Public ReadOnly Property PartsRemoved() As Collection(Of BodyPart)
            Get
                Return mPartsRemoved
            End Get
        End Property


        Public Sub New(ByVal partsAdded As Collection(Of BodyPart), ByVal partsRemoved As Collection(Of BodyPart))
            For i As Integer = 0 To partsAdded.Count - 1
                mPartsAdded.Add(partsAdded(i))
            Next i

            For i As Integer = 0 To partsRemoved.Count - 1
                mPartsRemoved.Add(partsRemoved(i))
            Next i
        End Sub


    End Class

End Namespace

