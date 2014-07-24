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
Imports System.Globalization
Imports System.Xml.Serialization


Imports Mbark.SensorMessages

Namespace Mbark.Sensors

    Public Enum SensorTaskCategory
        None = 0
        Face

        LeftIris
        RightIris
        BothIrises

        LeftSlap
        RightSlap
        ThumbsSlap

        FlatLeftThumb
        FlatLeftIndex
        FlatLeftMiddle
        FlatLeftRing
        FlatLeftLittle
        FlatRightThumb
        FlatRightIndex
        FlatRightMiddle
        FlatRightRing
        FlatRightLittle

        RolledLeftThumb
        RolledLeftIndex
        RolledLeftMiddle
        RolledLeftRing
        RolledLeftLittle
        RolledRightThumb
        RolledRightIndex
        RolledRightMiddle
        RolledRightRing
        RolledRightLittle

        LeftPalm
        RightPalm

        Voice
    End Enum

    Public Module SensorTaskCategorySupport

        Public Function ToString(ByVal category As SensorTaskCategory) As String
            Return ToString(CultureInfo.CurrentUICulture, category)
        End Function

        Public Function ToString(ByVal culture As CultureInfo, ByVal category As SensorTaskCategory) As String
            Select Case category

                Case SensorTaskCategory.Face : Return Messages.Face(culture)

                Case SensorTaskCategory.LeftIris : Return Messages.LeftIris(culture)
                Case SensorTaskCategory.RightIris : Return Messages.RightIris(culture)
                Case SensorTaskCategory.BothIrises : Return Messages.BothIrises(culture)

                Case SensorTaskCategory.LeftSlap : Return Messages.LeftSlap(culture)
                Case SensorTaskCategory.RightSlap : Return Messages.RightSlap(culture)
                Case SensorTaskCategory.ThumbsSlap : Return Messages.ThumbsSlap(culture)

                Case SensorTaskCategory.FlatLeftThumb : Return Messages.FlatLeftThumb(culture)
                Case SensorTaskCategory.FlatLeftIndex : Return Messages.FlatLeftIndex(culture)
                Case SensorTaskCategory.FlatLeftMiddle : Return Messages.FlatLeftMiddle(culture)
                Case SensorTaskCategory.FlatLeftRing : Return Messages.FlatLeftRing(culture)
                Case SensorTaskCategory.FlatLeftLittle : Return Messages.FlatLeftLittle(culture)
                Case SensorTaskCategory.FlatRightThumb : Return Messages.FlatRightThumb(culture)
                Case SensorTaskCategory.FlatRightIndex : Return Messages.FlatRightIndex(culture)
                Case SensorTaskCategory.FlatRightMiddle : Return Messages.FlatRightMiddle(culture)
                Case SensorTaskCategory.FlatRightRing : Return Messages.FlatRightRing(culture)
                Case SensorTaskCategory.FlatRightLittle : Return Messages.FlatRightLittle(culture)

                Case SensorTaskCategory.RolledLeftThumb : Return Messages.RolledLeftThumb(culture)
                Case SensorTaskCategory.RolledLeftIndex : Return Messages.RolledLeftIndex(culture)
                Case SensorTaskCategory.RolledLeftMiddle : Return Messages.RolledLeftMiddle(culture)
                Case SensorTaskCategory.RolledLeftRing : Return Messages.RolledLeftRing(culture)
                Case SensorTaskCategory.RolledLeftLittle : Return Messages.RolledLeftLittle(culture)
                Case SensorTaskCategory.RolledRightThumb : Return Messages.RolledRightThumb(culture)
                Case SensorTaskCategory.RolledRightIndex : Return Messages.RolledRightIndex(culture)
                Case SensorTaskCategory.RolledRightMiddle : Return Messages.RolledRightMiddle(culture)
                Case SensorTaskCategory.RolledRightRing : Return Messages.RolledRightRing(culture)
                Case SensorTaskCategory.RolledRightLittle : Return Messages.RolledRightLittle(culture)

                Case SensorTaskCategory.LeftPalm : Return Messages.LeftPalm(culture)
                Case SensorTaskCategory.RightPalm : Return Messages.RightPalm(culture)

                Case SensorTaskCategory.Voice : Return Messages.Voice(culture)

                Case Else : Return InfrastructureMessages.Messages.Unknown(culture)

            End Select

        End Function

    End Module

    Public Class SensorTaskCategoryCollection
        Inherits Collection(Of SensorTaskCategory)

        Public Function CreateDefinition() As SensorTaskCategoryCollectionDefinition
            Dim newDef As New SensorTaskCategoryCollectionDefinition
            For i As Integer = 0 To MyBase.Count - 1
                newDef.TaskCategories.Add(Item(i))
            Next
            Return newDef
        End Function

        Public Sub New(ByVal categories As SensorTaskCategory())
            If categories Is Nothing Then Throw New ArgumentNullException("categories")
            For i As Integer = 0 To categories.Length - 1
                MyBase.Add(categories(i))
            Next
        End Sub

        Public Overloads Sub Add(ByVal categories As SensorTaskCategoryCollection)
            If categories Is Nothing Then Return
            For i As Integer = 0 To categories.Count - 1
                MyBase.Add(categories(i))
            Next
        End Sub

        Public Sub New()

        End Sub

    End Class

    <XmlType("SensorTaskCategories"), Serializable()> _
    Public Class SensorTaskCategoryCollectionDefinition
        Implements ICloneable

        Private mTaskCategories As New Collection(Of SensorTaskCategory)
        Public ReadOnly Property TaskCategories() As Collection(Of SensorTaskCategory)
            Get
                Return mTaskCategories
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New SensorTaskCategoryCollectionDefinition
            For i As Integer = 0 To mTaskCategories.Count - 1
                newDef.mTaskCategories.Add(mTaskCategories(i))
            Next
            Return newDef
        End Function

        Public Function DeepCopy() As SensorTaskCategoryCollectionDefinition
            Return DirectCast(Clone(), SensorTaskCategoryCollectionDefinition)
        End Function

        Public Function CreateTaskCategoryCollection() As SensorTaskCategoryCollection
            Dim newCollection As New SensorTaskCategoryCollection
            For i As Integer = 0 To TaskCategories.Count - 1
                newCollection.Add(TaskCategories(i))
            Next
            Return newCollection
        End Function

    End Class

End Namespace