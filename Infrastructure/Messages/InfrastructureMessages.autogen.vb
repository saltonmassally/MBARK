Imports System
Imports System.Resources
Imports System.Threading
Imports System.Globalization

Namespace Mbark.InfrastructureMessages
	
' ---------------------------------------------------------------------------------------
'
' If you're reading these comments in anything other than a .cst file, then this file has
' been automatically generated with CodeSmith (www.codesmith.com). 
'
' In this case, DO *NOT* EDIT OR CHECK INTO SOURCE CONTROL.
'
' ----------------------------------------------------------------------------------------

Public NotInheritable Class Messages 

	
	
	Public Shared ReadOnly Property No() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "No")
		End Get
	End Property
	
	Public Shared ReadOnly Property No(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "No")
		End Get
	End Property
	
	Public Shared ReadOnly Property Yes() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Yes")
		End Get
	End Property
	
	Public Shared ReadOnly Property Yes(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Yes")
		End Get
	End Property
	
	Public Shared ReadOnly Property NotApplicable() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "NotApplicable")
		End Get
	End Property
	
	Public Shared ReadOnly Property NotApplicable(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "NotApplicable")
		End Get
	End Property
	
	Public Shared ReadOnly Property UserName() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "UserName")
		End Get
	End Property
	
	Public Shared ReadOnly Property UserName(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "UserName")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMbarkException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralMbarkException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMbarkException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralMbarkException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralUnreachableCodeException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralUnreachableCodeException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralUnreachableCodeException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralUnreachableCodeException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralTrespassingException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralTrespassingException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralTrespassingException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralTrespassingException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralNoSuchFieldException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralNoSuchFieldException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralNoSuchFieldException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralNoSuchFieldException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificNoSuchFieldException(ByVal fieldName As String) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "SpecificNoSuchFieldException", fieldName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificNoSuchFieldException(ByVal culture As CultureInfo, ByVal fieldName As String) As String
		Get
				Return GetString(culture, "SpecificNoSuchFieldException", fieldName)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property EmptyMessagesGroupLabel() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "EmptyMessagesGroupLabel")
		End Get
	End Property
	
	Public Shared ReadOnly Property EmptyMessagesGroupLabel(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "EmptyMessagesGroupLabel")
		End Get
	End Property
	
	Public Shared ReadOnly Property NonemptyMessagesGroupLabel(ByVal count As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "NonemptyMessagesGroupLabel", count.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property NonemptyMessagesGroupLabel(ByVal culture As CultureInfo, ByVal count As Integer) As String
		Get
				Return GetString(culture, "NonemptyMessagesGroupLabel", count.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property EnumerationDelimiter() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "EnumerationDelimiter")
		End Get
	End Property
	
	Public Shared ReadOnly Property EnumerationDelimiter(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "EnumerationDelimiter")
		End Get
	End Property
	
	Public Shared ReadOnly Property BadDateRangeDescription(ByVal fieldName As String, ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal badDate As DateTime) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "BadDateRangeDescription", fieldName, startDate.ToString(CultureInfo.CurrentUICulture), endDate.ToString(CultureInfo.CurrentUICulture), badDate.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property BadDateRangeDescription(ByVal culture As CultureInfo, ByVal fieldName As String, ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal badDate As DateTime) As String
		Get
				Return GetString(culture, "BadDateRangeDescription", fieldName, startDate.ToString(culture), endDate.ToString(culture), badDate.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property GeneralMissingSpecializationException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralMissingSpecializationException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMissingSpecializationException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralMissingSpecializationException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMissingWiringException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralMissingWiringException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMissingWiringException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralMissingWiringException")
		End Get
	End Property
	
	Public Shared ReadOnly Property MissingRequiredField(ByVal fieldName As String) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "MissingRequiredField", fieldName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property MissingRequiredField(ByVal culture As CultureInfo, ByVal fieldName As String) As String
		Get
				Return GetString(culture, "MissingRequiredField", fieldName)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property CreateAndSelectRecord() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CreateAndSelectRecord")
		End Get
	End Property
	
	Public Shared ReadOnly Property CreateAndSelectRecord(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CreateAndSelectRecord")
		End Get
	End Property
	
	Public Shared ReadOnly Property Revert() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Revert")
		End Get
	End Property
	
	Public Shared ReadOnly Property Revert(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Revert")
		End Get
	End Property
	
	Public Shared ReadOnly Property LowercaseNothing() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LowercaseNothing")
		End Get
	End Property
	
	Public Shared ReadOnly Property LowercaseNothing(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LowercaseNothing")
		End Get
	End Property
	
	Public Shared ReadOnly Property SingleQuote() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "SingleQuote")
		End Get
	End Property
	
	Public Shared ReadOnly Property SingleQuote(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "SingleQuote")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificMissingWiringException(ByVal typeName As Type, ByVal methodName As String) As String
      Get
			Dim typeNameAsString As String = String.Empty
  If typeName Is Nothing Then 
  typeNameAsString = String.Empty
  Else
typeNameAsString.ToString()
End If
	Return GetString(CultureInfo.CurrentUICulture, "SpecificMissingWiringException", typeNameAsString.ToString(), methodName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificMissingWiringException(ByVal culture As CultureInfo, ByVal typeName As Type, ByVal methodName As String) As String
		Get
			Dim typeNameAsString As String = String.Empty
  If typeName Is Nothing Then 
  typeNameAsString = String.Empty
  Else
typeNameAsString.ToString()
End If
	Return GetString(culture, "SpecificMissingWiringException", typeNameAsString.ToString(), methodName)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property CouldNotPopulateFieldEntryList() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CouldNotPopulateFieldEntryList")
		End Get
	End Property
	
	Public Shared ReadOnly Property CouldNotPopulateFieldEntryList(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CouldNotPopulateFieldEntryList")
		End Get
	End Property
	
	Public Shared ReadOnly Property DatabaseError() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "DatabaseError")
		End Get
	End Property
	
	Public Shared ReadOnly Property DatabaseError(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "DatabaseError")
		End Get
	End Property
	
	Public Shared ReadOnly Property Space() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Space")
		End Get
	End Property
	
	Public Shared ReadOnly Property Space(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Space")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralBadSpecializationException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralBadSpecializationException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralBadSpecializationException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralBadSpecializationException")
		End Get
	End Property
	
	Public Shared ReadOnly Property Ok() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Ok")
		End Get
	End Property
	
	Public Shared ReadOnly Property Ok(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Ok")
		End Get
	End Property
	
	Public Shared ReadOnly Property Cancel() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Cancel")
		End Get
	End Property
	
	Public Shared ReadOnly Property Cancel(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Cancel")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificMissingSpecializationException(ByVal baseType As Type, ByVal methodName As String) As String
      Get
			Dim baseTypeAsString As String = String.Empty
  If baseType Is Nothing Then 
  baseTypeAsString = String.Empty
  Else
baseTypeAsString.ToString()
End If
	Return GetString(CultureInfo.CurrentUICulture, "SpecificMissingSpecializationException", baseTypeAsString.ToString(), methodName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificMissingSpecializationException(ByVal culture As CultureInfo, ByVal baseType As Type, ByVal methodName As String) As String
		Get
			Dim baseTypeAsString As String = String.Empty
  If baseType Is Nothing Then 
  baseTypeAsString = String.Empty
  Else
baseTypeAsString.ToString()
End If
	Return GetString(culture, "SpecificMissingSpecializationException", baseTypeAsString.ToString(), methodName)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property AutoHeightString() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AutoHeightString")
		End Get
	End Property
	
	Public Shared ReadOnly Property AutoHeightString(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AutoHeightString")
		End Get
	End Property
	
	Public Shared ReadOnly Property AutoWidthUpperChar() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AutoWidthUpperChar")
		End Get
	End Property
	
	Public Shared ReadOnly Property AutoWidthUpperChar(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AutoWidthUpperChar")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralEntityNotInCollectionException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralEntityNotInCollectionException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralEntityNotInCollectionException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralEntityNotInCollectionException")
		End Get
	End Property
	
	Public Shared ReadOnly Property Star() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Star")
		End Get
	End Property
	
	Public Shared ReadOnly Property Star(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Star")
		End Get
	End Property
	
	Public Shared ReadOnly Property Ellipsis() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Ellipsis")
		End Get
	End Property
	
	Public Shared ReadOnly Property Ellipsis(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Ellipsis")
		End Get
	End Property
	
	Public Shared ReadOnly Property NumberAbbreviated() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "NumberAbbreviated")
		End Get
	End Property
	
	Public Shared ReadOnly Property NumberAbbreviated(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "NumberAbbreviated")
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
	
	Public Shared ReadOnly Property Failures() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Failures")
		End Get
	End Property
	
	Public Shared ReadOnly Property Failures(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Failures")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralControlIsNotAutosizableException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralControlIsNotAutosizableException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralControlIsNotAutosizableException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralControlIsNotAutosizableException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificControlIsNotAutosizableException(ByVal controlName As String) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "SpecificControlIsNotAutosizableException", controlName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificControlIsNotAutosizableException(ByVal culture As CultureInfo, ByVal controlName As String) As String
		Get
				Return GetString(culture, "SpecificControlIsNotAutosizableException", controlName)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property GeneralControlHasNoSupportForSoughtInterfaceException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralControlHasNoSupportForSoughtInterfaceException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralControlHasNoSupportForSoughtInterfaceException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralControlHasNoSupportForSoughtInterfaceException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificControlHasNoSupportForSoughtInterfaceException(ByVal controlName As String, ByVal interfaceName As String) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "SpecificControlHasNoSupportForSoughtInterfaceException", controlName, interfaceName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificControlHasNoSupportForSoughtInterfaceException(ByVal culture As CultureInfo, ByVal controlName As String, ByVal interfaceName As String) As String
		Get
				Return GetString(culture, "SpecificControlHasNoSupportForSoughtInterfaceException", controlName, interfaceName)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property GeneralUnexpectedNumberOfInterfaceSupportersException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralUnexpectedNumberOfInterfaceSupportersException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralUnexpectedNumberOfInterfaceSupportersException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralUnexpectedNumberOfInterfaceSupportersException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificUnexpectedNumberOfInterfaceSupportersException(ByVal interfaceName As String, ByVal foundCount As Integer, ByVal expectedCount As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "SpecificUnexpectedNumberOfInterfaceSupportersException", interfaceName, foundCount.ToString(CultureInfo.CurrentUICulture), expectedCount.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificUnexpectedNumberOfInterfaceSupportersException(ByVal culture As CultureInfo, ByVal interfaceName As String, ByVal foundCount As Integer, ByVal expectedCount As Integer) As String
		Get
				Return GetString(culture, "SpecificUnexpectedNumberOfInterfaceSupportersException", interfaceName, foundCount.ToString(culture), expectedCount.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property None() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "None")
		End Get
	End Property
	
	Public Shared ReadOnly Property None(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "None")
		End Get
	End Property
	
	Public Shared ReadOnly Property LowercaseNone() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "LowercaseNone")
		End Get
	End Property
	
	Public Shared ReadOnly Property LowercaseNone(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "LowercaseNone")
		End Get
	End Property
	
	Public Shared ReadOnly Property AutoWidthLowerChar() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AutoWidthLowerChar")
		End Get
	End Property
	
	Public Shared ReadOnly Property AutoWidthLowerChar(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AutoWidthLowerChar")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralTooManyCallsException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralTooManyCallsException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralTooManyCallsException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralTooManyCallsException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificTooManyCallsException(ByVal methodName As String, ByVal limit As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "SpecificTooManyCallsException", methodName, limit.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificTooManyCallsException(ByVal culture As CultureInfo, ByVal methodName As String, ByVal limit As Integer) As String
		Get
				Return GetString(culture, "SpecificTooManyCallsException", methodName, limit.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property UppercaseAlphabet() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "UppercaseAlphabet")
		End Get
	End Property
	
	Public Shared ReadOnly Property UppercaseAlphabet(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "UppercaseAlphabet")
		End Get
	End Property
	
	Public Shared ReadOnly Property January() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "January")
		End Get
	End Property
	
	Public Shared ReadOnly Property January(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "January")
		End Get
	End Property
	
	Public Shared ReadOnly Property February() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "February")
		End Get
	End Property
	
	Public Shared ReadOnly Property February(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "February")
		End Get
	End Property
	
	Public Shared ReadOnly Property March() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "March")
		End Get
	End Property
	
	Public Shared ReadOnly Property March(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "March")
		End Get
	End Property
	
	Public Shared ReadOnly Property April() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "April")
		End Get
	End Property
	
	Public Shared ReadOnly Property April(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "April")
		End Get
	End Property
	
	Public Shared ReadOnly Property May() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "May")
		End Get
	End Property
	
	Public Shared ReadOnly Property May(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "May")
		End Get
	End Property
	
	Public Shared ReadOnly Property June() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "June")
		End Get
	End Property
	
	Public Shared ReadOnly Property June(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "June")
		End Get
	End Property
	
	Public Shared ReadOnly Property July() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "July")
		End Get
	End Property
	
	Public Shared ReadOnly Property July(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "July")
		End Get
	End Property
	
	Public Shared ReadOnly Property August() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "August")
		End Get
	End Property
	
	Public Shared ReadOnly Property August(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "August")
		End Get
	End Property
	
	Public Shared ReadOnly Property September() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "September")
		End Get
	End Property
	
	Public Shared ReadOnly Property September(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "September")
		End Get
	End Property
	
	Public Shared ReadOnly Property October() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "October")
		End Get
	End Property
	
	Public Shared ReadOnly Property October(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "October")
		End Get
	End Property
	
	Public Shared ReadOnly Property November() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "November")
		End Get
	End Property
	
	Public Shared ReadOnly Property November(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "November")
		End Get
	End Property
	
	Public Shared ReadOnly Property December() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "December")
		End Get
	End Property
	
	Public Shared ReadOnly Property December(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "December")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralNotFormInvokableException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralNotFormInvokableException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralNotFormInvokableException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralNotFormInvokableException")
		End Get
	End Property
	
	Public Shared ReadOnly Property DataTooShortNBytesExpected(ByVal expectedBytes As Integer) As String
      Get
				Return GetString(CultureInfo.CurrentUICulture, "DataTooShortNBytesExpected", expectedBytes.ToString(CultureInfo.CurrentUICulture)) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property DataTooShortNBytesExpected(ByVal culture As CultureInfo, ByVal expectedBytes As Integer) As String
		Get
				Return GetString(culture, "DataTooShortNBytesExpected", expectedBytes.ToString(culture))
		End Get
	End Property
	
	
	Public Shared ReadOnly Property AutosizableDropDownGroupCannotLayoutItself() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "AutosizableDropDownGroupCannotLayoutItself")
		End Get
	End Property
	
	Public Shared ReadOnly Property AutosizableDropDownGroupCannotLayoutItself(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "AutosizableDropDownGroupCannotLayoutItself")
		End Get
	End Property
	
	Public Shared ReadOnly Property RationalDelimiter() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "RationalDelimiter")
		End Get
	End Property
	
	Public Shared ReadOnly Property RationalDelimiter(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "RationalDelimiter")
		End Get
	End Property
	
	Public Shared ReadOnly Property OpenDoubleQuote() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "OpenDoubleQuote")
		End Get
	End Property
	
	Public Shared ReadOnly Property OpenDoubleQuote(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "OpenDoubleQuote")
		End Get
	End Property
	
	Public Shared ReadOnly Property CloseDoubleQuote() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CloseDoubleQuote")
		End Get
	End Property
	
	Public Shared ReadOnly Property CloseDoubleQuote(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CloseDoubleQuote")
		End Get
	End Property
	
	Public Shared ReadOnly Property OpenParenthesis() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "OpenParenthesis")
		End Get
	End Property
	
	Public Shared ReadOnly Property OpenParenthesis(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "OpenParenthesis")
		End Get
	End Property
	
	Public Shared ReadOnly Property CloseParenthesis() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CloseParenthesis")
		End Get
	End Property
	
	Public Shared ReadOnly Property CloseParenthesis(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CloseParenthesis")
		End Get
	End Property
	
	Public Shared ReadOnly Property Colon() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Colon")
		End Get
	End Property
	
	Public Shared ReadOnly Property Colon(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Colon")
		End Get
	End Property
	
	Public Shared ReadOnly Property ColonSpace() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ColonSpace")
		End Get
	End Property
	
	Public Shared ReadOnly Property ColonSpace(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ColonSpace")
		End Get
	End Property
	
	Public Shared ReadOnly Property Comma() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Comma")
		End Get
	End Property
	
	Public Shared ReadOnly Property Comma(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Comma")
		End Get
	End Property
	
	Public Shared ReadOnly Property CommaSpace() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "CommaSpace")
		End Get
	End Property
	
	Public Shared ReadOnly Property CommaSpace(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "CommaSpace")
		End Get
	End Property
	
	Public Shared ReadOnly Property Hashmark() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Hashmark")
		End Get
	End Property
	
	Public Shared ReadOnly Property Hashmark(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Hashmark")
		End Get
	End Property
	
	Public Shared ReadOnly Property Attention() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Attention")
		End Get
	End Property
	
	Public Shared ReadOnly Property Attention(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Attention")
		End Get
	End Property
	
	Public Shared ReadOnly Property HiddenGroupRadioButtonText() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "HiddenGroupRadioButtonText")
		End Get
	End Property
	
	Public Shared ReadOnly Property HiddenGroupRadioButtonText(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "HiddenGroupRadioButtonText")
		End Get
	End Property
	
	Public Shared ReadOnly Property Other() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Other")
		End Get
	End Property
	
	Public Shared ReadOnly Property Other(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Other")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConfigurationFile() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ConfigurationFile")
		End Get
	End Property
	
	Public Shared ReadOnly Property ConfigurationFile(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ConfigurationFile")
		End Get
	End Property
	
	Public Shared ReadOnly Property ApplicationError() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "ApplicationError")
		End Get
	End Property
	
	Public Shared ReadOnly Property ApplicationError(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "ApplicationError")
		End Get
	End Property
	
	Public Shared ReadOnly Property Unknown() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "Unknown")
		End Get
	End Property
	
	Public Shared ReadOnly Property Unknown(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "Unknown")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMissingThreadInterruptedHandlerException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralMissingThreadInterruptedHandlerException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralMissingThreadInterruptedHandlerException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralMissingThreadInterruptedHandlerException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralRedundantWiringException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralRedundantWiringException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralRedundantWiringException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralRedundantWiringException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificRedundantWiringException(ByVal thisType As Type, ByVal wireName As String) As String
      Get
			Dim thisTypeAsString As String = String.Empty
  If thisType Is Nothing Then 
  thisTypeAsString = String.Empty
  Else
thisTypeAsString.ToString()
End If
	Return GetString(CultureInfo.CurrentUICulture, "SpecificRedundantWiringException", thisTypeAsString.ToString(), wireName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificRedundantWiringException(ByVal culture As CultureInfo, ByVal thisType As Type, ByVal wireName As String) As String
		Get
			Dim thisTypeAsString As String = String.Empty
  If thisType Is Nothing Then 
  thisTypeAsString = String.Empty
  Else
thisTypeAsString.ToString()
End If
	Return GetString(culture, "SpecificRedundantWiringException", thisTypeAsString.ToString(), wireName)
		End Get
	End Property
	
	
	Public Shared ReadOnly Property GeneralBadProxyException() As String
		Get
		  Return GetString(CultureInfo.CurrentUICulture, "GeneralBadProxyException")
		End Get
	End Property
	
	Public Shared ReadOnly Property GeneralBadProxyException(ByVal culture As CultureInfo) As String
	   Get
	     Return GetString(culture, "GeneralBadProxyException")
		End Get
	End Property
	
	Public Shared ReadOnly Property SpecificBadProxyException(ByVal collectionType As Type, ByVal proxyName As String) As String
      Get
			Dim collectionTypeAsString As String = String.Empty
  If collectionType Is Nothing Then 
  collectionTypeAsString = String.Empty
  Else
collectionTypeAsString.ToString()
End If
	Return GetString(CultureInfo.CurrentUICulture, "SpecificBadProxyException", collectionTypeAsString.ToString(), proxyName) 
	  End Get
    End Property  
	
	Public Shared ReadOnly Property SpecificBadProxyException(ByVal culture As CultureInfo, ByVal collectionType As Type, ByVal proxyName As String) As String
		Get
			Dim collectionTypeAsString As String = String.Empty
  If collectionType Is Nothing Then 
  collectionTypeAsString = String.Empty
  Else
collectionTypeAsString.ToString()
End If
	Return GetString(culture, "SpecificBadProxyException", collectionTypeAsString.ToString(), proxyName)
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
