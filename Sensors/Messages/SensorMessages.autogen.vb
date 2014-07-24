Imports System
Imports System.Globalization
Imports System.Resources
Imports System.Threading
Imports System.Xml
Imports Mbark.Sensors

Namespace Mbark.SensorMessages
	
' ---------------------------------------------------------------------------------------
'
' If you're reading these comments in anything other than a .cst file, then this file has
' been automatically generated with CodeSmith (www.codesmith.com). 
'
' In this case, DO *NOT* EDIT OR CHECK INTO SOURCE CONTROL.
'
' ----------------------------------------------------------------------------------------

Public NotInheritable Class Messages 

	
	
	Public Shared ReadOnly Property GeneralPollingCanceledException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralPollingCanceledException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralPollingCanceledException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralPollingCanceledException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralCaptureTimeoutException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralCaptureTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralCaptureTimeoutException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralCaptureTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralUnexpectedMissingBodyPartException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralUnexpectedMissingBodyPartException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralUnexpectedMissingBodyPartException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralUnexpectedMissingBodyPartException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificUnexpectedMissingBodyPartException(ByVal missingBodyParts As BodyPartCollection, ByVal expectedBodyParts As BodyPartCollection) As String
      Get
			Dim missingBodyPartsAsString As String = String.Empty
Dim expectedBodyPartsAsString As String = String.Empty
  If missingBodyParts Is Nothing Then 
  missingBodyPartsAsString = String.Empty
  Else
missingBodyPartsAsString.ToString(CultureInfo.CurrentUICulture)
End If
  If expectedBodyParts Is Nothing Then 
  expectedBodyPartsAsString = String.Empty
  Else
expectedBodyPartsAsString.ToString(CultureInfo.CurrentUICulture)
End If
	Return GetString(CultureInfo.CurrentUICulture, "SpecificUnexpectedMissingBodyPartException", missingBodyPartsAsString.ToString(CultureInfo.CurrentUICulture), expectedBodyPartsAsString.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificUnexpectedMissingBodyPartException(ByVal culture As CultureInfo, ByVal missingBodyParts As BodyPartCollection, ByVal expectedBodyParts As BodyPartCollection) As String
		Get
			Dim missingBodyPartsAsString As String = String.Empty
Dim expectedBodyPartsAsString As String = String.Empty
  If missingBodyParts Is Nothing Then 
  missingBodyPartsAsString = String.Empty
  Else
missingBodyPartsAsString.ToString(culture)
End If
  If expectedBodyParts Is Nothing Then 
  expectedBodyPartsAsString = String.Empty
  Else
expectedBodyPartsAsString.ToString(culture)
End If
	Return GetString(culture, "SpecificUnexpectedMissingBodyPartException", missingBodyPartsAsString.ToString(culture), expectedBodyPartsAsString.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property Task() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Task")
		End Get
	End Property
	
	Public Shared ReadOnly Property Task(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Task")
		End Get
	End Property
	
	Public Shared ReadOnly Property Tasks() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Tasks")
		End Get
	End Property
	
	Public Shared ReadOnly Property Tasks(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Tasks")
		End Get
	End Property
	
	Public Shared ReadOnly Property TaskNumber() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "TaskNumber")
		End Get
	End Property
	
	Public Shared ReadOnly Property TaskNumber(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "TaskNumber")
		End Get
	End Property
	
	Public Shared ReadOnly Property Description() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Description")
		End Get
	End Property
	
	Public Shared ReadOnly Property Description(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Description")
		End Get
	End Property
	
	Public Shared ReadOnly Property Sensor() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Sensor")
		End Get
	End Property
	
	Public Shared ReadOnly Property Sensor(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Sensor")
		End Get
	End Property
	
	Public Shared ReadOnly Property Conditions() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Conditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property Conditions(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Conditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property FailedAttempts() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FailedAttempts")
		End Get
	End Property
	
	Public Shared ReadOnly Property FailedAttempts(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FailedAttempts")
		End Get
	End Property
	
	Public Shared ReadOnly Property Status() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Status")
		End Get
	End Property
	
	Public Shared ReadOnly Property Status(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Status")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorTimeoutSensorTimeoutCaption() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SensorTimeoutSensorTimeoutCaption")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorTimeoutSensorTimeoutCaption(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SensorTimeoutSensorTimeoutCaption")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorTimeoutNotification() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SensorTimeoutNotification")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorTimeoutNotification(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SensorTimeoutNotification")
		End Get
	End Property
	
	Public Shared ReadOnly Property DoubleClickToSkipToTask(ByVal taskIndex As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "DoubleClickToSkipToTask", taskIndex.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property DoubleClickToSkipToTask(ByVal culture As CultureInfo, ByVal taskIndex As Integer) As String
		Get
				Return GetString(culture, "DoubleClickToSkipToTask", taskIndex.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property GeneralCaptureFailureException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralCaptureFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralCaptureFailureException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralCaptureFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property CancelTaskNotification() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CancelTaskNotification")
		End Get
	End Property
	
	Public Shared ReadOnly Property CancelTaskNotification(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CancelTaskNotification")
		End Get
	End Property
	
	Public Shared ReadOnly Property CancelTaskInstruction() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CancelTaskInstruction")
		End Get
	End Property
	
	Public Shared ReadOnly Property CancelTaskInstruction(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CancelTaskInstruction")
		End Get
	End Property
	
	Public Shared ReadOnly Property CurrentlyAssignedTask() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CurrentlyAssignedTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property CurrentlyAssignedTask(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CurrentlyAssignedTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property XsIndicateInjuries() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "XsIndicateInjuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property XsIndicateInjuries(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "XsIndicateInjuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property Irises() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Irises")
		End Get
	End Property
	
	Public Shared ReadOnly Property Irises(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Irises")
		End Get
	End Property
	
	Public Shared ReadOnly Property PartsIndicatedNotYetSufficientForSkipping() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PartsIndicatedNotYetSufficientForSkipping")
		End Get
	End Property
	
	Public Shared ReadOnly Property PartsIndicatedNotYetSufficientForSkipping(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PartsIndicatedNotYetSufficientForSkipping")
		End Get
	End Property
	
	Public Shared ReadOnly Property Injury() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Injury")
		End Get
	End Property
	
	Public Shared ReadOnly Property Injury(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Injury")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessibleBodyPart() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "InaccessibleBodyPart")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessibleBodyPart(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "InaccessibleBodyPart")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessibleBodyParts() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "InaccessibleBodyParts")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessibleBodyParts(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "InaccessibleBodyParts")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessibleBodyPartOrParts() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "InaccessibleBodyPartOrParts")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessibleBodyPartOrParts(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "InaccessibleBodyPartOrParts")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectLeftSession() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectLeftSession")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectLeftSession(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectLeftSession")
		End Get
	End Property
	
	Public Shared ReadOnly Property PerformingDemoOrTesting() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PerformingDemoOrTesting")
		End Get
	End Property
	
	Public Shared ReadOnly Property PerformingDemoOrTesting(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PerformingDemoOrTesting")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectDeclines() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectDeclines")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectDeclines(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectDeclines")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorMalfunction() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SensorMalfunction")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorMalfunction(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SensorMalfunction")
		End Get
	End Property
	
	Public Shared ReadOnly Property OtherReasonWithSpecifyAndColon() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "OtherReasonWithSpecifyAndColon")
		End Get
	End Property
	
	Public Shared ReadOnly Property OtherReasonWithSpecifyAndColon(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "OtherReasonWithSpecifyAndColon")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectIsCarryingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectIsCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectIsCarryingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectIsCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectHasGlassesOnPerson() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectHasGlassesOnPerson")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectHasGlassesOnPerson(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectHasGlassesOnPerson")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectCurrentlyWearingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectCurrentlyWearingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectCurrentlyWearingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectCurrentlyWearingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property GlassesOn() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GlassesOn")
		End Get
	End Property
	
	Public Shared ReadOnly Property GlassesOn(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GlassesOn")
		End Get
	End Property
	
	Public Shared ReadOnly Property GlassesOff() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GlassesOff")
		End Get
	End Property
	
	Public Shared ReadOnly Property GlassesOff(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GlassesOff")
		End Get
	End Property
	
	Public Shared ReadOnly Property Iris() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Iris")
		End Get
	End Property
	
	Public Shared ReadOnly Property Iris(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Iris")
		End Get
	End Property
	
	Public Shared ReadOnly Property CarryingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property CarryingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property NotCarryingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "NotCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property NotCarryingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "NotCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property RejectThisImage() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RejectThisImage")
		End Get
	End Property
	
	Public Shared ReadOnly Property RejectThisImage(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RejectThisImage")
		End Get
	End Property
	
	Public Shared ReadOnly Property ImageIsCorrupt() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ImageIsCorrupt")
		End Get
	End Property
	
	Public Shared ReadOnly Property ImageIsCorrupt(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ImageIsCorrupt")
		End Get
	End Property
	
	Public Shared ReadOnly Property Tries() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Tries")
		End Get
	End Property
	
	Public Shared ReadOnly Property Tries(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Tries")
		End Get
	End Property
	
	Public Shared ReadOnly Property TheSystemShouldIgnoreThisConflict() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "TheSystemShouldIgnoreThisConflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property TheSystemShouldIgnoreThisConflict(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "TheSystemShouldIgnoreThisConflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThisAttemptHasNoConflict() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ThisAttemptHasNoConflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThisAttemptHasNoConflict(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ThisAttemptHasNoConflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property CurrentConditions() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CurrentConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property CurrentConditions(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CurrentConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConditionsOnCapture() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ConditionsOnCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConditionsOnCapture(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ConditionsOnCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property AnticipatedConditions() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AnticipatedConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property AnticipatedConditions(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AnticipatedConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecialConditions() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SpecialConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecialConditions(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SpecialConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustNotBeCarryingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectMustNotBeCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustNotBeCarryingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectMustNotBeCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustBeCarryingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectMustBeCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustBeCarryingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectMustBeCarryingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustNotBeWearingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectMustNotBeWearingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustNotBeWearingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectMustNotBeWearingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustBeWearingGlasses() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SubjectMustBeWearingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SubjectMustBeWearingGlasses(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SubjectMustBeWearingGlasses")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecialConditionsCaptured() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SpecialConditionsCaptured")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecialConditionsCaptured(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SpecialConditionsCaptured")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecialConditionsNow() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SpecialConditionsNow")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecialConditionsNow(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SpecialConditionsNow")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessiblePartsCaptured() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "InaccessiblePartsCaptured")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessiblePartsCaptured(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "InaccessiblePartsCaptured")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessiblePartsNow() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "InaccessiblePartsNow")
		End Get
	End Property
	
	Public Shared ReadOnly Property InaccessiblePartsNow(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "InaccessiblePartsNow")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedPartsNowMissing() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CapturedPartsNowMissing")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedPartsNowMissing(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CapturedPartsNowMissing")
		End Get
	End Property
	
	Public Shared ReadOnly Property MissingPartsRecovered() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "MissingPartsRecovered")
		End Get
	End Property
	
	Public Shared ReadOnly Property MissingPartsRecovered(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "MissingPartsRecovered")
		End Get
	End Property
	
	Public Shared ReadOnly Property Session() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Session")
		End Get
	End Property
	
	Public Shared ReadOnly Property Session(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Session")
		End Get
	End Property
	
	Public Shared ReadOnly Property CheckingStatusOfSensorsDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CheckingStatusOfSensorsDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CheckingStatusOfSensorsDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CheckingStatusOfSensorsDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property StartingSensorInitializationDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "StartingSensorInitializationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property StartingSensorInitializationDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "StartingSensorInitializationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForSensorsToInitializeDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "WaitingForSensorsToInitializeDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForSensorsToInitializeDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "WaitingForSensorsToInitializeDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForCaptureToBeginDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "WaitingForCaptureToBeginDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForCaptureToBeginDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "WaitingForCaptureToBeginDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturingBiometricDataDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CapturingBiometricDataDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturingBiometricDataDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CapturingBiometricDataDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property TaskToSkip() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "TaskToSkip")
		End Get
	End Property
	
	Public Shared ReadOnly Property TaskToSkip(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "TaskToSkip")
		End Get
	End Property
	
	Public Shared ReadOnly Property From() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "From")
		End Get
	End Property
	
	Public Shared ReadOnly Property From(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "From")
		End Get
	End Property
	
	Public Shared ReadOnly Property [To]() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "[To]")
		End Get
	End Property
	
	Public Shared ReadOnly Property [To](ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "[To]")
		End Get
	End Property
	
	Public Shared ReadOnly Property DeterminingNextTaskDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DeterminingNextTaskDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property DeterminingNextTaskDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DeterminingNextTaskDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property LoadingApplicationDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LoadingApplicationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property LoadingApplicationDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LoadingApplicationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property FinishingSensorInitializationDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FinishingSensorInitializationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property FinishingSensorInitializationDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FinishingSensorInitializationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property Sensors() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Sensors")
		End Get
	End Property
	
	Public Shared ReadOnly Property Sensors(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Sensors")
		End Get
	End Property
	
	Public Shared ReadOnly Property Convenience() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Convenience")
		End Get
	End Property
	
	Public Shared ReadOnly Property Convenience(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Convenience")
		End Get
	End Property
	
	Public Shared ReadOnly Property Conflict() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Conflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property Conflict(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Conflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureFailure() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CaptureFailure")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureFailure(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CaptureFailure")
		End Get
	End Property
	
	Public Shared ReadOnly Property Corrupt() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Corrupt")
		End Get
	End Property
	
	Public Shared ReadOnly Property Corrupt(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Corrupt")
		End Get
	End Property
	
	Public Shared ReadOnly Property Success() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Success")
		End Get
	End Property
	
	Public Shared ReadOnly Property Success(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Success")
		End Get
	End Property
	
	Public Shared ReadOnly Property MoveBack() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "MoveBack")
		End Get
	End Property
	
	Public Shared ReadOnly Property MoveBack(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "MoveBack")
		End Get
	End Property
	
	Public Shared ReadOnly Property MoveForward() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "MoveForward")
		End Get
	End Property
	
	Public Shared ReadOnly Property MoveForward(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "MoveForward")
		End Get
	End Property
	
	Public Shared ReadOnly Property Ready() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Ready")
		End Get
	End Property
	
	Public Shared ReadOnly Property Ready(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Ready")
		End Get
	End Property
	
	Public Shared ReadOnly Property OutOfRange() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "OutOfRange")
		End Get
	End Property
	
	Public Shared ReadOnly Property OutOfRange(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "OutOfRange")
		End Get
	End Property
	
	Public Shared ReadOnly Property PollingDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PollingDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property PollingDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PollingDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadingThumbnailsDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DownloadingThumbnailsDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadingThumbnailsDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DownloadingThumbnailsDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property Accepted() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Accepted")
		End Get
	End Property
	
	Public Shared ReadOnly Property Accepted(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Accepted")
		End Get
	End Property
	
	Public Shared ReadOnly Property Rejected() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Rejected")
		End Get
	End Property
	
	Public Shared ReadOnly Property Rejected(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Rejected")
		End Get
	End Property
	
	Public Shared ReadOnly Property Timeout() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Timeout")
		End Get
	End Property
	
	Public Shared ReadOnly Property Timeout(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Timeout")
		End Get
	End Property
	
	Public Shared ReadOnly Property ClickToJumpToTaskN(ByVal taskIndex As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "ClickToJumpToTaskN", taskIndex.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property ClickToJumpToTaskN(ByVal culture As CultureInfo, ByVal taskIndex As Integer) As String
		Get
				Return GetString(culture, "ClickToJumpToTaskN", taskIndex.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property AttemptNFailed(ByVal attemptNumber As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "AttemptNFailed", attemptNumber.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property AttemptNFailed(ByVal culture As CultureInfo, ByVal attemptNumber As Integer) As String
		Get
				Return GetString(culture, "AttemptNFailed", attemptNumber.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property AttemptNRejected(ByVal attemptNumber As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "AttemptNRejected", attemptNumber.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property AttemptNRejected(ByVal culture As CultureInfo, ByVal attemptNumber As Integer) As String
		Get
				Return GetString(culture, "AttemptNRejected", attemptNumber.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property AttemptNSuccessfulButNotYetDownloaded(ByVal attemptNumber As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "AttemptNSuccessfulButNotYetDownloaded", attemptNumber.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property AttemptNSuccessfulButNotYetDownloaded(ByVal culture As CultureInfo, ByVal attemptNumber As Integer) As String
		Get
				Return GetString(culture, "AttemptNSuccessfulButNotYetDownloaded", attemptNumber.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property AttemptNSuccessfulAndDownloaded(ByVal attemptNumber As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "AttemptNSuccessfulAndDownloaded", attemptNumber.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property AttemptNSuccessfulAndDownloaded(ByVal culture As CultureInfo, ByVal attemptNumber As Integer) As String
		Get
				Return GetString(culture, "AttemptNSuccessfulAndDownloaded", attemptNumber.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property YouAreCurrentlyViewingTheImagesForThisTask() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "YouAreCurrentlyViewingTheImagesForThisTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property YouAreCurrentlyViewingTheImagesForThisTask(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "YouAreCurrentlyViewingTheImagesForThisTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property SessionEndWithConflict() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SessionEndWithConflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property SessionEndWithConflict(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SessionEndWithConflict")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralConfigurationFailureException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralConfigurationFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralConfigurationFailureException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralConfigurationFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralConfigurationTimeoutException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralConfigurationTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralConfigurationTimeoutException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralConfigurationTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralBadSensorStatusException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralBadSensorStatusException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralBadSensorStatusException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralBadSensorStatusException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificBadSensorStatusException(ByVal operation As String, ByVal state As SensorStatus) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "SpecificBadSensorStatusException", operation, state.ToString()) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificBadSensorStatusException(ByVal culture As CultureInfo, ByVal operation As String, ByVal state As SensorStatus) As String
		Get
				Return GetString(culture, "SpecificBadSensorStatusException", operation, state.ToString())
		End Get
	End Property
	
	
	Public Shared ReadOnly Property GeneralDownloadFailureException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralDownloadFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralDownloadFailureException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralDownloadFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralDownloadTimeoutException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralDownloadTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralDownloadTimeoutException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralDownloadTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralInitializationFailureException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralInitializationFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralInitializationFailureException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralInitializationFailureException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralInitializationTimeoutException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralInitializationTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralInitializationTimeoutException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralInitializationTimeoutException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralSensorException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralSensorException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralSensorException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralSensorException")
		End Get
	End Property
	
	Public Shared ReadOnly Property InitializationTimedOut() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "InitializationTimedOut")
		End Get
	End Property
	
	Public Shared ReadOnly Property InitializationTimedOut(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "InitializationTimedOut")
		End Get
	End Property
	
	Public Shared ReadOnly Property RecoveringFromSensorFailuresDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RecoveringFromSensorFailuresDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property RecoveringFromSensorFailuresDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RecoveringFromSensorFailuresDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property InitializationFailed() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "InitializationFailed")
		End Get
	End Property
	
	Public Shared ReadOnly Property InitializationFailed(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "InitializationFailed")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingRecoveryResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AwaitingRecoveryResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingRecoveryResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AwaitingRecoveryResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingRecoveryResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HandlingRecoveryResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingRecoveryResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HandlingRecoveryResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingStartOfNewTaskSetDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AwaitingStartOfNewTaskSetDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingStartOfNewTaskSetDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AwaitingStartOfNewTaskSetDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property StartingNewTaskSetDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "StartingNewTaskSetDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property StartingNewTaskSetDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "StartingNewTaskSetDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property NothingToDoSinceThereAreNoTasksToPerform() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "NothingToDoSinceThereAreNoTasksToPerform")
		End Get
	End Property
	
	Public Shared ReadOnly Property NothingToDoSinceThereAreNoTasksToPerform(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "NothingToDoSinceThereAreNoTasksToPerform")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftThumb() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftThumb(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftIndexFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftIndexFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftIndexFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftIndexFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftMiddleFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftMiddleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftMiddleFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftMiddleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftRingFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftRingFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftRingFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftRingFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftLittleFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftLittleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftLittleFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftLittleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightThumb() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightThumb(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightIndexFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightIndexFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightIndexFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightIndexFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightMiddleFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightMiddleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightMiddleFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightMiddleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightRingFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightRingFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightRingFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightRingFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightLittleFinger() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightLittleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightLittleFinger(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightLittleFinger")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftIris() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftIris")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftIris(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftIris")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForAValidReasonToSkipThisTaskDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "WaitingForAValidReasonToSkipThisTaskDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForAValidReasonToSkipThisTaskDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "WaitingForAValidReasonToSkipThisTaskDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingTaskSkipJustificationDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HandlingTaskSkipJustificationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingTaskSkipJustificationDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HandlingTaskSkipJustificationDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingCaptureResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HandlingCaptureResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingCaptureResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HandlingCaptureResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property EditingAttemptDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "EditingAttemptDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property EditingAttemptDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "EditingAttemptDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingAttemptEditDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HandlingAttemptEditDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingAttemptEditDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HandlingAttemptEditDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property ReviewingCaptureResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ReviewingCaptureResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property ReviewingCaptureResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ReviewingCaptureResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingReviewCaptureResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HandlingReviewCaptureResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingReviewCaptureResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HandlingReviewCaptureResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CancellingOrResumingDownloadDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CancellingOrResumingDownloadDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CancellingOrResumingDownloadDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CancellingOrResumingDownloadDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property FinalizingSensorResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FinalizingSensorResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property FinalizingSensorResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FinalizingSensorResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneratingTemplateDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneratingTemplateDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneratingTemplateDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneratingTemplateDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property OperatorExplainingTimeoutDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "OperatorExplainingTimeoutDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property OperatorExplainingTimeoutDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "OperatorExplainingTimeoutDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property TallyingFailedAttemptDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "TallyingFailedAttemptDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property TallyingFailedAttemptDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "TallyingFailedAttemptDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property NErrors(ByVal count As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "NErrors", count.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property NErrors(ByVal culture As CultureInfo, ByVal count As Integer) As String
		Get
				Return GetString(culture, "NErrors", count.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property ConfiguringSensorDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ConfiguringSensorDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConfiguringSensorDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ConfiguringSensorDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingConfigurationResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AwaitingConfigurationResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingConfigurationResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AwaitingConfigurationResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingConfigurationResultDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HandlingConfigurationResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandlingConfigurationResultDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HandlingConfigurationResultDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingTaskSetCompletionDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AwaitingTaskSetCompletionDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingTaskSetCompletionDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AwaitingTaskSetCompletionDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CheckingOutstandingConflictsDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CheckingOutstandingConflictsDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CheckingOutstandingConflictsDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CheckingOutstandingConflictsDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CompletingTaskSetDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CompletingTaskSetDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CompletingTaskSetDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CompletingTaskSetDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property Polling() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Polling")
		End Get
	End Property
	
	Public Shared ReadOnly Property Polling(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Polling")
		End Get
	End Property
	
	Public Shared ReadOnly Property TaskChangedFromT1ToT2(ByVal descriptionOfFromTask As String, ByVal descriptionOfToTask As String) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "TaskChangedFromT1ToT2", descriptionOfFromTask, descriptionOfToTask) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property TaskChangedFromT1ToT2(ByVal culture As CultureInfo, ByVal descriptionOfFromTask As String, ByVal descriptionOfToTask As String) As String
		Get
				Return GetString(culture, "TaskChangedFromT1ToT2", descriptionOfFromTask, descriptionOfToTask)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property RtfTaskChangedFromT1ToT2(ByVal descriptionOfFromTask As String, ByVal descriptionOfToTask As String) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "RtfTaskChangedFromT1ToT2", descriptionOfFromTask, descriptionOfToTask) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property RtfTaskChangedFromT1ToT2(ByVal culture As CultureInfo, ByVal descriptionOfFromTask As String, ByVal descriptionOfToTask As String) As String
		Get
				Return GetString(culture, "RtfTaskChangedFromT1ToT2", descriptionOfFromTask, descriptionOfToTask)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property PleaseRemoveHand() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PleaseRemoveHand")
		End Get
	End Property
	
	Public Shared ReadOnly Property PleaseRemoveHand(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PleaseRemoveHand")
		End Get
	End Property
	
	Public Shared ReadOnly Property NotStarted() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "NotStarted")
		End Get
	End Property
	
	Public Shared ReadOnly Property NotStarted(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "NotStarted")
		End Get
	End Property
	
	Public Shared ReadOnly Property Active() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Active")
		End Get
	End Property
	
	Public Shared ReadOnly Property Active(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Active")
		End Get
	End Property
	
	Public Shared ReadOnly Property Downloading() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Downloading")
		End Get
	End Property
	
	Public Shared ReadOnly Property Downloading(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Downloading")
		End Get
	End Property
	
	Public Shared ReadOnly Property Blocked() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Blocked")
		End Get
	End Property
	
	Public Shared ReadOnly Property Blocked(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Blocked")
		End Get
	End Property
	
	Public Shared ReadOnly Property Done() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Done")
		End Get
	End Property
	
	Public Shared ReadOnly Property Done(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Done")
		End Get
	End Property
	
	Public Shared ReadOnly Property Skipped() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Skipped")
		End Get
	End Property
	
	Public Shared ReadOnly Property Skipped(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Skipped")
		End Get
	End Property
	
	Public Shared ReadOnly Property Suspended() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Suspended")
		End Get
	End Property
	
	Public Shared ReadOnly Property Suspended(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Suspended")
		End Get
	End Property
	
	Public Shared ReadOnly Property Pending() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Pending")
		End Get
	End Property
	
	Public Shared ReadOnly Property Pending(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Pending")
		End Get
	End Property
	
	Public Shared ReadOnly Property AttemptEditor() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AttemptEditor")
		End Get
	End Property
	
	Public Shared ReadOnly Property AttemptEditor(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AttemptEditor")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureCanceled() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CaptureCanceled")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureCanceled(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CaptureCanceled")
		End Get
	End Property
	
	Public Shared ReadOnly Property PrematureLift() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PrematureLift")
		End Get
	End Property
	
	Public Shared ReadOnly Property PrematureLift(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PrematureLift")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralBadDefinitionException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralBadDefinitionException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralBadDefinitionException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralBadDefinitionException")
		End Get
	End Property
	
	Public Shared ReadOnly Property Face() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Face")
		End Get
	End Property
	
	Public Shared ReadOnly Property Face(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Face")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightIris() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightIris")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightIris(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightIris")
		End Get
	End Property
	
	Public Shared ReadOnly Property BothIrises() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "BothIrises")
		End Get
	End Property
	
	Public Shared ReadOnly Property BothIrises(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "BothIrises")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftSlap() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftSlap")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftSlap(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftSlap")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightSlap() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightSlap")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightSlap(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightSlap")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThumbsSlap() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ThumbsSlap")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThumbsSlap(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ThumbsSlap")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftThumb() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatLeftThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftThumb(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatLeftThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftIndex() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatLeftIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftIndex(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatLeftIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftMiddle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatLeftMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftMiddle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatLeftMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftRing() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatLeftRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftRing(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatLeftRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftLittle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatLeftLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatLeftLittle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatLeftLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightThumb() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatRightThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightThumb(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatRightThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightIndex() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatRightIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightIndex(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatRightIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightMiddle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatRightMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightMiddle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatRightMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightRing() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatRightRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightRing(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatRightRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightLittle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "FlatRightLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property FlatRightLittle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "FlatRightLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftThumb() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledLeftThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftThumb(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledLeftThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftIndex() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledLeftIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftIndex(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledLeftIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftMiddle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledLeftMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftMiddle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledLeftMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftRing() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledLeftRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftRing(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledLeftRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftLittle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledLeftLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledLeftLittle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledLeftLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightThumb() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledRightThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightThumb(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledRightThumb")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightIndex() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledRightIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightIndex(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledRightIndex")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightMiddle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledRightMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightMiddle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledRightMiddle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightRing() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledRightRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightRing(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledRightRing")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightLittle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RolledRightLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property RolledRightLittle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RolledRightLittle")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftPalm() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftPalm")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftPalm(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftPalm")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightPalm() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightPalm")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightPalm(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightPalm")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralUnfinishedBodyPartsUpdateException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralUnfinishedBodyPartsUpdateException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralUnfinishedBodyPartsUpdateException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralUnfinishedBodyPartsUpdateException")
		End Get
	End Property
	
	Public Shared ReadOnly Property Failure() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Failure")
		End Get
	End Property
	
	Public Shared ReadOnly Property Failure(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Failure")
		End Get
	End Property
	
	Public Shared ReadOnly Property Conflicts() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Conflicts")
		End Get
	End Property
	
	Public Shared ReadOnly Property Conflicts(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Conflicts")
		End Get
	End Property
	
	Public Shared ReadOnly Property PercentageOfAllTasksThatAreFullyCompleted() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PercentageOfAllTasksThatAreFullyCompleted")
		End Get
	End Property
	
	Public Shared ReadOnly Property PercentageOfAllTasksThatAreFullyCompleted(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PercentageOfAllTasksThatAreFullyCompleted")
		End Get
	End Property
	
	Public Shared ReadOnly Property DefaultSessionMenuText() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DefaultSessionMenuText")
		End Get
	End Property
	
	Public Shared ReadOnly Property DefaultSessionMenuText(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DefaultSessionMenuText")
		End Get
	End Property
	
	Public Shared ReadOnly Property ShuttingDownDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ShuttingDownDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property ShuttingDownDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ShuttingDownDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadFailure() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DownloadFailure")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadFailure(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DownloadFailure")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadFailed() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DownloadFailed")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadFailed(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DownloadFailed")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingDownload() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AwaitingDownload")
		End Get
	End Property
	
	Public Shared ReadOnly Property AwaitingDownload(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AwaitingDownload")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadComplete() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DownloadComplete")
		End Get
	End Property
	
	Public Shared ReadOnly Property DownloadComplete(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DownloadComplete")
		End Get
	End Property
	
	Public Shared ReadOnly Property EndOfSession() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "EndOfSession")
		End Get
	End Property
	
	Public Shared ReadOnly Property EndOfSession(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "EndOfSession")
		End Get
	End Property
	
	Public Shared ReadOnly Property Corrected() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Corrected")
		End Get
	End Property
	
	Public Shared ReadOnly Property Corrected(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Corrected")
		End Get
	End Property
	
	Public Shared ReadOnly Property ClickToViewCapturedImagesForTaskN(ByVal taskNumber As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "ClickToViewCapturedImagesForTaskN", taskNumber.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property ClickToViewCapturedImagesForTaskN(ByVal culture As CultureInfo, ByVal taskNumber As Integer) As String
		Get
				Return GetString(culture, "ClickToViewCapturedImagesForTaskN", taskNumber.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property WrongTask() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "WrongTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property WrongTask(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "WrongTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property Virtual() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Virtual")
		End Get
	End Property
	
	Public Shared ReadOnly Property Virtual(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Virtual")
		End Get
	End Property
	
	Public Shared ReadOnly Property Face3D() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Face3D")
		End Get
	End Property
	
	Public Shared ReadOnly Property Face3D(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Face3D")
		End Get
	End Property
	
	Public Shared ReadOnly Property Fingerprint() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Fingerprint")
		End Get
	End Property
	
	Public Shared ReadOnly Property Fingerprint(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Fingerprint")
		End Get
	End Property
	
	Public Shared ReadOnly Property Gait() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Gait")
		End Get
	End Property
	
	Public Shared ReadOnly Property Gait(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Gait")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandGeometry() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HandGeometry")
		End Get
	End Property
	
	Public Shared ReadOnly Property HandGeometry(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HandGeometry")
		End Get
	End Property
	
	Public Shared ReadOnly Property Voice() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Voice")
		End Get
	End Property
	
	Public Shared ReadOnly Property Voice(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Voice")
		End Get
	End Property
	
	Public Shared ReadOnly Property EditAttempt() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "EditAttempt")
		End Get
	End Property
	
	Public Shared ReadOnly Property EditAttempt(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "EditAttempt")
		End Get
	End Property
	
	Public Shared ReadOnly Property AnticipatedSpecialConditionsDuringCapture() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AnticipatedSpecialConditionsDuringCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property AnticipatedSpecialConditionsDuringCapture(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AnticipatedSpecialConditionsDuringCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property AnticipatedInjuriesDuringCapture() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AnticipatedInjuriesDuringCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property AnticipatedInjuriesDuringCapture(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AnticipatedInjuriesDuringCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property TaskAlreadyCompletedSuccessfully() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "TaskAlreadyCompletedSuccessfully")
		End Get
	End Property
	
	Public Shared ReadOnly Property TaskAlreadyCompletedSuccessfully(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "TaskAlreadyCompletedSuccessfully")
		End Get
	End Property
	
	Public Shared ReadOnly Property Injuries() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Injuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property Injuries(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Injuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property EndSessionButtonText() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "EndSessionButtonText")
		End Get
	End Property
	
	Public Shared ReadOnly Property EndSessionButtonText(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "EndSessionButtonText")
		End Get
	End Property
	
	Public Shared ReadOnly Property RestartSessionButtonText() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RestartSessionButtonText")
		End Get
	End Property
	
	Public Shared ReadOnly Property RestartSessionButtonText(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RestartSessionButtonText")
		End Get
	End Property
	
	Public Shared ReadOnly Property YouCantChangeThatConditionJustNow() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "YouCantChangeThatConditionJustNow")
		End Get
	End Property
	
	Public Shared ReadOnly Property YouCantChangeThatConditionJustNow(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "YouCantChangeThatConditionJustNow")
		End Get
	End Property
	
	Public Shared ReadOnly Property SorryBang() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SorryBang")
		End Get
	End Property
	
	Public Shared ReadOnly Property SorryBang(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SorryBang")
		End Get
	End Property
	
	Public Shared ReadOnly Property UnnecessaryExtraTask() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "UnnecessaryExtraTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property UnnecessaryExtraTask(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "UnnecessaryExtraTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property PleaseAcceptRejectThisDataRtf() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PleaseAcceptRejectThisDataRtf")
		End Get
	End Property
	
	Public Shared ReadOnly Property PleaseAcceptRejectThisDataRtf(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PleaseAcceptRejectThisDataRtf")
		End Get
	End Property
	
	Public Shared ReadOnly Property PleaseAcceptRejectThisData() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "PleaseAcceptRejectThisData")
		End Get
	End Property
	
	Public Shared ReadOnly Property PleaseAcceptRejectThisData(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "PleaseAcceptRejectThisData")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThisSessionHasDataNotYetDownloaded() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ThisSessionHasDataNotYetDownloaded")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThisSessionHasDataNotYetDownloaded(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ThisSessionHasDataNotYetDownloaded")
		End Get
	End Property
	
	Public Shared ReadOnly Property DoYouWishToExit() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DoYouWishToExit")
		End Get
	End Property
	
	Public Shared ReadOnly Property DoYouWishToExit(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DoYouWishToExit")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftHand() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LeftHand")
		End Get
	End Property
	
	Public Shared ReadOnly Property LeftHand(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LeftHand")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightHand() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RightHand")
		End Get
	End Property
	
	Public Shared ReadOnly Property RightHand(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RightHand")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConflictWillBeAutomaticallyFixed() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ConflictWillBeAutomaticallyFixed")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConflictWillBeAutomaticallyFixed(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ConflictWillBeAutomaticallyFixed")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConflictMustBeIgnored() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ConflictMustBeIgnored")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConflictMustBeIgnored(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ConflictMustBeIgnored")
		End Get
	End Property
	
	Public Shared ReadOnly Property SkipTask() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SkipTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property SkipTask(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SkipTask")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorRecoveryInstructions() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SensorRecoveryInstructions")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorRecoveryInstructions(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SensorRecoveryInstructions")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorRecoveryFormTitle() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SensorRecoveryFormTitle")
		End Get
	End Property
	
	Public Shared ReadOnly Property SensorRecoveryFormTitle(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SensorRecoveryFormTitle")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForDownloadsToFinishDotDotDot() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "WaitingForDownloadsToFinishDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property WaitingForDownloadsToFinishDotDotDot(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "WaitingForDownloadsToFinishDotDotDot")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedConditions() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CapturedConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedConditions(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CapturedConditions")
		End Get
	End Property
	
	Public Shared ReadOnly Property CurrentInjuries() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CurrentInjuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property CurrentInjuries(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CurrentInjuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedInjuries() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CapturedInjuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedInjuries(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CapturedInjuries")
		End Get
	End Property
	
	Public Shared ReadOnly Property Tab() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Tab")
		End Get
	End Property
	
	Public Shared ReadOnly Property Tab(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Tab")
		End Get
	End Property
	
	Public Shared ReadOnly Property ShiftPlusTab() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ShiftPlusTab")
		End Get
	End Property
	
	Public Shared ReadOnly Property ShiftPlusTab(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ShiftPlusTab")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedImages() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CapturedImages")
		End Get
	End Property
	
	Public Shared ReadOnly Property CapturedImages(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CapturedImages")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMissingConditionFactoryException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralMissingConditionFactoryException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMissingConditionFactoryException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralMissingConditionFactoryException")
		End Get
	End Property
	
	Public Shared ReadOnly Property CannotOpenSensorForRecording() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CannotOpenSensorForRecording")
		End Get
	End Property
	
	Public Shared ReadOnly Property CannotOpenSensorForRecording(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CannotOpenSensorForRecording")
		End Get
	End Property
	
	Public Shared ReadOnly Property ProblemWhileConfiguringSensorDuringCapture() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ProblemWhileConfiguringSensorDuringCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property ProblemWhileConfiguringSensorDuringCapture(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ProblemWhileConfiguringSensorDuringCapture")
		End Get
	End Property
	
	Public Shared ReadOnly Property TheScannerPlatenIsDirty() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "TheScannerPlatenIsDirty")
		End Get
	End Property
	
	Public Shared ReadOnly Property TheScannerPlatenIsDirty(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "TheScannerPlatenIsDirty")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThisSessionHasNotYetSaveInDatabase() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ThisSessionHasNotYetSaveInDatabase")
		End Get
	End Property
	
	Public Shared ReadOnly Property ThisSessionHasNotYetSaveInDatabase(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ThisSessionHasNotYetSaveInDatabase")
		End Get
	End Property
	
	Public Shared ReadOnly Property Olympus() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Olympus")
		End Get
	End Property
	
	Public Shared ReadOnly Property Olympus(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Olympus")
		End Get
	End Property
	
	Public Shared ReadOnly Property OlympusCamera() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "OlympusCamera")
		End Get
	End Property
	
	Public Shared ReadOnly Property OlympusCamera(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "OlympusCamera")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureFailureBadImageQuality() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CaptureFailureBadImageQuality")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureFailureBadImageQuality(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CaptureFailureBadImageQuality")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureTimedout() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CaptureTimedout")
		End Get
	End Property
	
	Public Shared ReadOnly Property CaptureTimedout(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CaptureTimedout")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConfigurationTimedOut() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ConfigurationTimedOut")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConfigurationTimedOut(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ConfigurationTimedOut")
		End Get
	End Property
	
	Public Shared ReadOnly Property ChangeCurrentAndCapturedDataTogether() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ChangeCurrentAndCapturedDataTogether")
		End Get
	End Property
	
	Public Shared ReadOnly Property ChangeCurrentAndCapturedDataTogether(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ChangeCurrentAndCapturedDataTogether")
		End Get
	End Property
	
	
	
	Private Shared ReadOnly Property ResourceTable(ByVal culture As CultureInfo) As Resources.ResourceManager
    Get
      If mResources Is Nothing or mCurrentCultureName <> culture.Name Then 
		
		mResources = New Resources.ResourceManager(culture.Name, System.Reflection.[Assembly].GetExecutingAssembly)
		mCurrentCultureName = culture.Name
		
		If mResources Is Nothing then
			mResources = New Resources.ResourceManager("en-US", System.Reflection.Assembly.GetExecutingAssembly)
		End If
		
	  End If
      Return mResources
    End Get	
  	End Property
    
  	Friend Shared Function GetString(ByVal culture As CultureInfo, ByVal key As String) As String
		Return ResourceTable(culture).GetString(key, culture)
  	End Function
  
  	Friend Shared Function GetString(ByVal culture As CultureInfo, ByVal key As String, ByVal ParamArray args() As String) As String
    	Return String.Format(culture, ResourceTable(culture).GetString(key,culture), args)
  	End Function

	Private Shared mResources As Resources.ResourceManager
  	Private Shared mCurrentCultureName As String
 
  	Private Sub New()
		' Forbid construction
  	End Sub

End Class

	End Namespace
