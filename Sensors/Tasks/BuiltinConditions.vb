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

Imports System.Drawing
Imports System.Globalization

Imports Mbark.SensorMessages

Namespace Mbark.Sensors.Builtins

    Public NotInheritable Class ConditionNames

        Public Const CarryingGlasses As String = "CarryingGlasses"
        Public Const WearingGlasses As String = "WearingGlasses"

        Private Sub New()
            ' Forbid construction
        End Sub

    End Class

    Public NotInheritable Class ConditionStrings

        Public Shared ReadOnly Property CarryingGlasses() As LocalizableString
            Get
                Return smCarryingGlasses
            End Get
        End Property
        Public Shared ReadOnly Property GlassesOff() As LocalizableString
            Get
                Return smGlassesOff
            End Get
        End Property
        Public Shared ReadOnly Property GlassesOn() As LocalizableString
            Get
                Return smGlassesOn
            End Get
        End Property
        Public Shared ReadOnly Property Empty() As LocalizableString
            Get
                Return smEmpty
            End Get
        End Property
        Public Shared ReadOnly Property NotCarryingGlasses() As LocalizableString
            Get
                Return smNotCarryingGlasses
            End Get
        End Property
        Public Shared ReadOnly Property SubjectCurrentlyWearingGlasses() As LocalizableString
            Get
                Return smSubjectCurrentlyWearingGlasses
            End Get
        End Property
        Public Shared ReadOnly Property SubjectHasGlassesOnPerson() As LocalizableString
            Get
                Return smSubjectHasGlassesOnPerson
            End Get
        End Property

        Private Shared smEnUS As CultureInfo = New CultureInfo("en-US")

        ' We use functions for initialization at the recommendation of FxCop
        Private Shared smCarryingGlasses As LocalizableString = InitializeCarryingGlasses()
        Private Shared smNotCarryingGlasses As LocalizableString = InitializeNotCarryingGlasses()
        Private Shared smGlassesOn As LocalizableString = InitializeGlassesOn()
        Private Shared smGlassesOff As LocalizableString = InitializeGlassesOff()
        Private Shared smEmpty As LocalizableString = InitializeEmpty()
        Private Shared smSubjectHasGlassesOnPerson As LocalizableString = InitializeSubjectHasGlassesOnPerson()
        Private Shared smSubjectCurrentlyWearingGlasses As LocalizableString = InitializeSubjectCurrentlyWearingGlasses()

        Private Shared Function InitializeGlassesOff() As LocalizableString
            Dim value As New LocalizableString("GlassesOff")
            value(smEnUS.Name) = Messages.GlassesOff(smEnUS)
            Return value
        End Function
        Private Shared Function InitializeCarryingGlasses() As LocalizableString
            Dim value As New LocalizableString("CarryingGlasses")
            value(smEnUS.Name) = Messages.CarryingGlasses(smEnUS)
            Return value
        End Function
        Private Shared Function InitializeNotCarryingGlasses() As LocalizableString
            Dim value As New LocalizableString("NotCarryingGlasses")
            value(smEnUS.Name) = Messages.NotCarryingGlasses(smEnUS)
            Return value
        End Function
        Private Shared Function InitializeGlassesOn() As LocalizableString
            Dim value As New LocalizableString("GlassesOn")
            value(smEnUS.Name) = Messages.GlassesOn(smEnUS)
            Return value
        End Function
        Private Shared Function InitializeEmpty() As LocalizableString
            Dim value As New LocalizableString("Empty")
            value(smEnUS.Name) = String.Empty
            Return value
        End Function
        Private Shared Function InitializeSubjectHasGlassesOnPerson() As LocalizableString
            Dim value As New LocalizableString("HasGlassesOnPerson")
            value(smEnUS.Name) = Messages.SubjectIsCarryingGlasses(smEnUS)
            Return value
        End Function
        Private Shared Function InitializeSubjectCurrentlyWearingGlasses() As LocalizableString
            Dim value As New LocalizableString("CurrentlyWearingGlasses")
            value(smEnUS.Name) = Messages.SubjectCurrentlyWearingGlasses(smEnUS)
            Return value
        End Function

        Private Sub New()
            ' Forbid construction
        End Sub

    End Class

    Public NotInheritable Class UnmetPrerequisiteStrings

        Private Shared smEnUS As CultureInfo = New CultureInfo("en-US")
        Private Shared smSubjectMustBeCarryingGlasses As LocalizableString = InitializeSubjectMustBeCarryingGlasses()

        Public Shared ReadOnly Property SubjectMustBeCarryingGlasses() As LocalizableString
            Get
                Return smSubjectMustBeCarryingGlasses
            End Get
        End Property
        Private Shared Function InitializeSubjectMustBeCarryingGlasses() As LocalizableString
            Dim value As New LocalizableString("SubjectMustBeCarryingGlasses")
            value(smEnUS.Name) = Messages.SubjectMustBeCarryingGlasses(smEnUS)
            Return value
        End Function


        Private Sub New()
            ' Forbid construction
        End Sub


    End Class

    Public NotInheritable Class ConditionFactories

        Private Shared smNotCarryingGlasses As ConditionFactory
        Private Shared smCarryingGlasses As ConditionFactory
        Private Shared smNotWearingGlasses As ConditionFactory
        Private Shared smWearingGlasses As ConditionFactory

        Public Shared ReadOnly Property CarryingGlasses() As ConditionFactory
            Get
                If smCarryingGlasses Is Nothing Then
                    smCarryingGlasses = New ConditionFactory
                    smCarryingGlasses.FactoryName = "CarryingGlasses"
                    With smCarryingGlasses
                        .InitializationArgs( _
                                ConditionStrings.CarryingGlasses, ConditionStrings.NotCarryingGlasses, _
                                ConditionStrings.Empty, ConditionStrings.Empty, _
                                ConditionStrings.Empty, ConditionStrings.Empty)
                        .PrerequisiteFactory = PredicateFactories.IsFaceOrIrisTask
                        .ConditionType = ConditionType.BooleanCondition
                        .ConditionName = ConditionNames.CarryingGlasses
                        .ConditionDescription = ConditionStrings.SubjectHasGlassesOnPerson
                        .ConditionInitialValue = True
                        .ConditionIsStatic = True

                    End With
                End If
                Return smCarryingGlasses
            End Get
        End Property
        Public Shared ReadOnly Property NotCarryingGlasses() As ConditionFactory
            Get
                If smNotCarryingGlasses Is Nothing Then
                    smNotCarryingGlasses = New ConditionFactory
                    With smNotCarryingGlasses
                        .FactoryName = "NotCarryingGlasses"
                        .InitializationArgs( _
                             ConditionStrings.CarryingGlasses, ConditionStrings.NotCarryingGlasses, _
                             ConditionStrings.Empty, ConditionStrings.Empty, _
                             ConditionStrings.Empty, ConditionStrings.Empty)
                        .PrerequisiteFactory = PredicateFactories.IsFaceOrIrisTask
                        .ConditionType = ConditionType.BooleanCondition
                        .ConditionName = ConditionNames.CarryingGlasses
                        .ConditionDescription = ConditionStrings.SubjectHasGlassesOnPerson
                        .ConditionInitialValue = False
                        .ConditionIsStatic = True
                    End With
                End If
                Return smNotCarryingGlasses
            End Get
        End Property
        Public Shared ReadOnly Property WearingGlasses() As ConditionFactory
            Get
                If smWearingGlasses Is Nothing Then
                    smWearingGlasses = New ConditionFactory
                    With smWearingGlasses
                        .FactoryName = "WearingGlasses"
                        .InitializationArgs( _
                            ConditionStrings.GlassesOn, ConditionStrings.GlassesOff, ConditionStrings.Empty, _
                            ConditionStrings.GlassesOn, ConditionStrings.GlassesOff, ConditionStrings.Empty)
                        .PrerequisiteFactory = PredicateFactories.FaceOrIrisTaskAndIsCarryingGlasses
                        .ConditionType = ConditionType.BooleanCondition
                        .ConditionName = ConditionNames.WearingGlasses
                        .ConditionDescription = ConditionStrings.SubjectCurrentlyWearingGlasses
                        .ConditionInitialValue = True
                        .ConditionIsStatic = False
                        .PrerequisiteFactory = PredicateFactories.IsCarryingGlasses
                    End With
                End If
                Return smWearingGlasses
            End Get
        End Property
        Public Shared ReadOnly Property NotWearingGlasses() As ConditionFactory
            Get
                If smNotWearingGlasses Is Nothing Then
                    smNotWearingGlasses = New ConditionFactory
                    With smNotWearingGlasses
                        .FactoryName = "NotWearingGlasses"
                        .InitializationArgs( _
                         ConditionStrings.GlassesOn, ConditionStrings.GlassesOff, ConditionStrings.Empty, _
                         ConditionStrings.GlassesOn, ConditionStrings.GlassesOff, ConditionStrings.Empty)
                        .PrerequisiteFactory = PredicateFactories.FaceOrIrisTaskAndIsCarryingGlasses
                        .ConditionType = ConditionType.BooleanCondition
                        .ConditionName = ConditionNames.WearingGlasses
                        .ConditionDescription = ConditionStrings.SubjectCurrentlyWearingGlasses
                        .ConditionInitialValue = False
                        .ConditionIsStatic = False
                        .PrerequisiteFactory = PredicateFactories.IsCarryingGlasses
                    End With
                End If
                Return smNotWearingGlasses
            End Get
        End Property

        Private Sub New()
            ' Forbid construction
        End Sub

    End Class

    Public NotInheritable Class PredicateFactories

        Private Sub New()
            ' Forbid construction
        End Sub

        Private Shared smIsFaceTask As PredicateFactory
        Public Shared ReadOnly Property IsFaceTask() As PredicateFactory
            Get
                If smIsFaceTask Is Nothing Then
                    smIsFaceTask = New PredicateFactory("IsFaceTask")
                    smIsFaceTask.PredicateType = PredicateType.CategoryEqualsLiteralPredicate
                    smIsFaceTask.FactoryArgs(SensorTaskCategory.Face)
                End If
                Return smIsFaceTask
            End Get
        End Property

        Private Shared smIsIrisTask As PredicateFactory
        Public Shared ReadOnly Property IsIrisTask() As PredicateFactory
            Get
                If smIsIrisTask Is Nothing Then
                    smIsIrisTask = New PredicateFactory("IsIrisTask")
                    smIsIrisTask.PredicateType = PredicateType.SensorModalityEqualsLiteralPredicate
                    smIsIrisTask.FactoryArgs(SensorModality.Iris)
                End If
                Return smIsIrisTask
            End Get
        End Property

        Private Shared smIsFaceOrIrisTask As PredicateFactory
        Public Shared ReadOnly Property IsFaceOrIrisTask() As PredicateFactory
            Get
                If smIsFaceOrIrisTask Is Nothing Then
                    smIsFaceOrIrisTask = New PredicateFactory("IsFaceOrIrisTask")
                    smIsFaceOrIrisTask.PredicateType = PredicateType.CompoundOrPredicate
                    smIsFaceOrIrisTask.FactoryArgs(IsIrisTask, IsFaceTask)
                End If
                Return smIsFaceOrIrisTask
            End Get
        End Property

        Private Shared smFaceOrIrisTaskAndIsCarryingGlasses As PredicateFactory
        Private Shared smIsCarryingGlasses As PredicateFactory

        Public Shared ReadOnly Property IsCarryingGlasses() As PredicateFactory
            Get
                If smIsCarryingGlasses Is Nothing Then
                    smIsCarryingGlasses = New PredicateFactory("IsCarryingGlasses")
                    With smIsCarryingGlasses
                        .PredicateType = PredicateType.ConditionEqualsLiteralPredicate
                        .FactoryArgs(ConditionNames.CarryingGlasses, True)
                        .UnmetPrerequisiteMessage = UnmetPrerequisiteStrings.SubjectMustBeCarryingGlasses
                    End With
                End If

                Return smIsCarryingGlasses
            End Get
        End Property

        Private Shared smIsNotCarryingGlasses As PredicateFactory
        Public Shared ReadOnly Property IsNotCarryingGlasses() As PredicateFactory
            Get
                If smIsNotCarryingGlasses Is Nothing Then
                    smIsNotCarryingGlasses = New PredicateFactory("IsNotCarryingGlasses")
                    smIsNotCarryingGlasses.PredicateType = PredicateType.ConditionEqualsLiteralPredicate
                    smIsNotCarryingGlasses.FactoryArgs(ConditionNames.CarryingGlasses, False)
                End If
                Return smIsNotCarryingGlasses
            End Get
        End Property

        Private Shared smIsWearingGlasses As PredicateFactory
        Public Shared ReadOnly Property IsWearingGlasses() As PredicateFactory
            Get
                If smIsWearingGlasses Is Nothing Then
                    smIsWearingGlasses = New PredicateFactory("IsWearingGlasses")
                    smIsWearingGlasses.PredicateType = PredicateType.ConditionEqualsLiteralPredicate
                    smIsWearingGlasses.FactoryArgs(ConditionNames.WearingGlasses, True)
                End If
                Return smIsWearingGlasses
            End Get
        End Property

        Private Shared smIsNotWearingGlasses As PredicateFactory
        Public Shared ReadOnly Property IsNotWearingGlasses() As PredicateFactory
            Get
                If smIsNotWearingGlasses Is Nothing Then
                    smIsNotWearingGlasses = New PredicateFactory("IsNotWearingGlasses")
                    smIsNotWearingGlasses.PredicateType = PredicateType.ConditionEqualsLiteralPredicate
                    smIsNotWearingGlasses.FactoryArgs(ConditionNames.WearingGlasses, False)
                End If
                Return smIsNotWearingGlasses
            End Get
        End Property

        Public Shared ReadOnly Property FaceOrIrisTaskAndIsCarryingGlasses() As PredicateFactory
            Get
                If smFaceOrIrisTaskAndIsCarryingGlasses Is Nothing Then
                    smFaceOrIrisTaskAndIsCarryingGlasses = New PredicateFactory("FaceOrIrisTaskAndIsCarryingGlasses")
                    With smFaceOrIrisTaskAndIsCarryingGlasses
                        .PredicateType = PredicateType.CompoundAndPredicate
                        .FactoryArgs(IsFaceTask, IsCarryingGlasses)
                        .UnmetPrerequisiteMessage = UnmetPrerequisiteStrings.SubjectMustBeCarryingGlasses
                    End With
                End If
                Return smFaceOrIrisTaskAndIsCarryingGlasses
            End Get
        End Property

        Private Shared smCarryingGlassesAndNotWearingGlasses As PredicateFactory
        Public Shared ReadOnly Property CarryingGlassesAndNotWearingGlasses() As PredicateFactory
            Get
                If smCarryingGlassesAndNotWearingGlasses Is Nothing Then
                    smCarryingGlassesAndNotWearingGlasses = New PredicateFactory("CarryingGlassesAndNotWearingGlasses")
                    smCarryingGlassesAndNotWearingGlasses.PredicateType = PredicateType.CompoundAndPredicate
                    smCarryingGlassesAndNotWearingGlasses.FactoryArgs(IsCarryingGlasses, IsNotWearingGlasses)
                End If
                Return smCarryingGlassesAndNotWearingGlasses
            End Get
        End Property

        Private Shared smNotCarryingGlassesAndNotWearingGlasses As PredicateFactory
        Public Shared ReadOnly Property NotCarryingGlassesAndNotWearingGlasses() As PredicateFactory
            Get
                If smNotCarryingGlassesAndNotWearingGlasses Is Nothing Then
                    smNotCarryingGlassesAndNotWearingGlasses = New PredicateFactory("NotCarryingGlassesAndNotWearingGlasses")
                    smNotCarryingGlassesAndNotWearingGlasses.PredicateType = PredicateType.CompoundAndPredicate
                    smNotCarryingGlassesAndNotWearingGlasses.FactoryArgs(IsNotCarryingGlasses, IsNotWearingGlasses)
                End If
                Return smNotCarryingGlassesAndNotWearingGlasses
            End Get
        End Property

        Private Shared smNotWearingGlassesEquivalence As PredicateFactory
        Public Shared ReadOnly Property NotWearingGlassesEquivalence() As PredicateFactory
            Get
                If smNotWearingGlassesEquivalence Is Nothing Then
                    smNotWearingGlassesEquivalence = New PredicateFactory("NotWearingGlassesEquivalence")
                    smNotWearingGlassesEquivalence.PredicateType = PredicateType.CompoundOrPredicate
                    smNotWearingGlassesEquivalence.FactoryArgs( _
                        CarryingGlassesAndNotWearingGlasses, _
                        NotCarryingGlassesAndNotWearingGlasses)
                End If
                Return smNotWearingGlassesEquivalence
            End Get
        End Property

        Private Shared smTrueLiteral As PredicateFactory
        Public Shared ReadOnly Property TrueLiteral() As PredicateFactory
            Get
                If smTrueLiteral Is Nothing Then
                    smTrueLiteral = New PredicateFactory("TrueLiteral")
                    smTrueLiteral.PredicateType = PredicateType.LiteralPredicate
                    smTrueLiteral.FactoryArgs(True)
                End If
                Return smTrueLiteral
            End Get
        End Property

        Private Shared smFalseLiteral As PredicateFactory
        Public Shared ReadOnly Property FalseLiteral() As PredicateFactory
            Get
                If smFalseLiteral Is Nothing Then
                    smFalseLiteral = New PredicateFactory("FalseLiteral")
                    smFalseLiteral.PredicateType = PredicateType.LiteralPredicate
                    smFalseLiteral.FactoryArgs(True)
                End If
                Return smFalseLiteral
            End Get
        End Property

    End Class

    Public NotInheritable Class Predicates

        Private Sub New()
            ' Forbid construction
        End Sub

        Private Shared smTrueLiteral As LiteralPredicate
        Private Shared smFalseLiteral As LiteralPredicate

        Public Shared ReadOnly Property TrueLiteral() As LiteralPredicate
            Get
                If smTrueLiteral Is Nothing Then
                    smTrueLiteral = New LiteralPredicate(True)
                End If
                Return smTrueLiteral
            End Get
        End Property

        Public Shared ReadOnly Property FalseLiteral() As LiteralPredicate
            Get
                If smFalseLiteral Is Nothing Then
                    smFalseLiteral = New LiteralPredicate(False)
                End If
                Return smFalseLiteral
            End Get
        End Property

    End Class

    Public NotInheritable Class FactoryCreators

        Private Sub New()
            ' Forbid construction
        End Sub

        Public Shared Function FaceForNonCarryingGlasses( _
            ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
            As SensorTaskFactory

            Dim NonCarryingGlassesFactory As New SensorTaskFactory
            With NonCarryingGlassesFactory
                '.FriendlyName = "Face"
                .PrerequisiteFactory = PredicateFactories.IsNotCarryingGlasses '.CreatePredicate(currentConditions)
                .TaskCount = count
                .Sensor = sensor
                .Colors = colors
                .Category = SensorTaskCategory.Face
                .ConditionFactories.Add(ConditionFactories.NotCarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.NotWearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With

            Return NonCarryingGlassesFactory

        End Function

        Public Shared Function FaceWithGlassesOff( _
            ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
            As SensorTaskFactory

            If sensor Is Nothing Then Throw New ArgumentNullException("sensor")

            Dim carryingGlassesWithoutWearing As New SensorTaskFactory
            With carryingGlassesWithoutWearing
                '.FriendlyName = "Face (Glasses off)"
                .PrerequisiteFactory = Builtins.PredicateFactories.IsCarryingGlasses '.CreatePredicate(currentConditions)
                .Sensor = sensor
                .TaskCount = count
                .Category = SensorTaskCategory.Face
                .Colors = colors
                .ConditionFactories.Add(ConditionFactories.CarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.NotWearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return carryingGlassesWithoutWearing
        End Function

        Public Shared Function FaceWithGlassesOn( _
            ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
            As SensorTaskFactory

            Dim f As New SensorTaskFactory
            With f
                '.FriendlyName = "Face (Glasses on)"
                .PrerequisiteFactory = Builtins.PredicateFactories.IsCarryingGlasses '.CreatePredicate(currentConditions)
                .Sensor = sensor
                .TaskCount = count
                .Category = SensorTaskCategory.Face
                .Colors = colors
                .ConditionFactories.Add(ConditionFactories.CarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.WearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function
        Public Shared Function SingleFingerFlat( _
        ByVal sensor As ISensor, _
        ByVal name As String, _
        ByVal count As Integer, _
        ByVal colors As SensorTaskColors, _
        ByVal category As SensorTaskCategory, _
        ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory

            Dim f As New SensorTaskFactory
            With f
                ' .FriendlyName = name
                .TaskCount = count
                .Sensor = sensor
                .Category = category
                .Colors = colors
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function LeftSlap( _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
            As SensorTaskFactory

            Dim f As New SensorTaskFactory
            With f
                '.FriendlyName = "Left Slap"
                .TaskCount = count
                .Sensor = sensor
                .Category = SensorTaskCategory.LeftSlap
                .Colors = colors
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function RightSlap( _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
       As SensorTaskFactory

            Dim f As New SensorTaskFactory
            With f
                ' .FriendlyName = "Right Slap"
                .TaskCount = count
                .Sensor = sensor
                .Category = SensorTaskCategory.RightSlap
                .Colors = colors
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function


        Public Shared Function ThumbsSlap( _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory

            Dim f As New SensorTaskFactory
            With f
                ' .FriendlyName = "Thumbs Slap"
                .TaskCount = count
                .Sensor = sensor
                .Category = SensorTaskCategory.ThumbsSlap
                .Colors = colors
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function LeftIrisForNonCarryingGlasses( _
                 ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory
            Dim f As New SensorTaskFactory
            With f
                '.FriendlyName = "Left Iris"
                .PrerequisiteFactory = PredicateFactories.IsNotCarryingGlasses '.CreatePredicate(currentConditions)
                .TaskCount = count
                .Sensor = sensor
                .Colors = colors
                .Category = SensorTaskCategory.LeftIris
                .ConditionFactories.Add(ConditionFactories.NotCarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.NotWearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function LeftIrisWithGlassesOn( _
                    ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory
            Dim f As New SensorTaskFactory
            With f
                '.FriendlyName = "Left Iris (glasses on)"
                .PrerequisiteFactory = PredicateFactories.IsCarryingGlasses '.CreatePredicate(currentConditions)
                .TaskCount = count
                .Sensor = sensor
                .Colors = colors
                .Category = SensorTaskCategory.LeftIris
                .ConditionFactories.Add(ConditionFactories.CarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.WearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function LeftIrisWithGlassesOff( _
                    ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory
            Dim f As New SensorTaskFactory
            With f
                '.FriendlyName = "Left Iris (glasses off)"
                .PrerequisiteFactory = PredicateFactories.IsCarryingGlasses '.CreatePredicate(currentConditions)
                .TaskCount = count
                .Sensor = sensor
                .Colors = colors
                .Category = SensorTaskCategory.LeftIris
                .ConditionFactories.Add(ConditionFactories.CarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.NotWearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function


        Public Shared Function RightIrisForNonCarryingGlasses( _
            ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory
            Dim f As New SensorTaskFactory
            With f
                ' .FriendlyName = "Right Iris"
                .PrerequisiteFactory = PredicateFactories.IsNotCarryingGlasses '.CreatePredicate(currentConditions)
                .TaskCount = count
                .Sensor = sensor
                .Colors = colors
                .Category = SensorTaskCategory.RightIris
                .ConditionFactories.Add(ConditionFactories.NotCarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.NotWearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function RightIrisWithGlassesOn( _
            ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory
            Dim f As New SensorTaskFactory
            With f
                '.FriendlyName = "Right Iris (glasses on)"
                .PrerequisiteFactory = PredicateFactories.IsCarryingGlasses '.CreatePredicate(currentConditions)
                .TaskCount = count
                .Sensor = sensor
                .Colors = colors
                .Category = SensorTaskCategory.RightIris
                .ConditionFactories.Add(ConditionFactories.CarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.WearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function RightIrisWithGlassesOff( _
                        ByVal currentConditions As ConditionCollection, _
            ByVal sensor As ISensor, _
            ByVal count As Integer, _
            ByVal colors As SensorTaskColors, _
            ByVal reassignableCategories As SensorTaskCategoryCollection) _
        As SensorTaskFactory
            Dim f As New SensorTaskFactory
            With f
                ' .FriendlyName = "Right Iris (glasses off)"
                .PrerequisiteFactory = PredicateFactories.IsCarryingGlasses '.CreatePredicate(currentConditions)
                .TaskCount = count
                .Sensor = sensor
                .Colors = colors
                .Category = SensorTaskCategory.RightIris
                .ConditionFactories.Add(ConditionFactories.CarryingGlasses)
                .ConditionFactories.Add(ConditionFactories.NotWearingGlasses)
                .ConditionFactories.AddEquivalenceClassFactory(PredicateFactories.NotWearingGlassesEquivalence)
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function

        Public Shared Function Voice( _
                    ByVal sensor As ISensor, _
                    ByVal count As Integer, _
                    ByVal colors As SensorTaskColors, _
                    ByVal reassignableCategories As SensorTaskCategoryCollection) _
                As SensorTaskFactory

            Dim f As New SensorTaskFactory
            With f
                '.FriendlyName = "Voice"
                .TaskCount = count
                .Sensor = sensor
                .Category = SensorTaskCategory.Voice
                .Colors = colors
                .ReassignableSensorTaskCategories.Add(reassignableCategories)
            End With
            Return f
        End Function
    End Class


End Namespace
