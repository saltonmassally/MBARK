Imports System
Imports System.Globalization
Imports System.Runtime.Serialization
Imports Mbark.InfrastructureMessages

Namespace Mbark


<Serializable()> Public Class MbarkException
        Inherits Exception
		
		Public Sub New()
            MyBase.New(Messages.GeneralMbarkException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class UnreachableCodeException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralUnreachableCodeException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class TrespassingException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralTrespassingException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class NoSuchFieldException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralNoSuchFieldException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal fieldName As String)
			MyBase.New(Messages.SpecificNoSuchFieldException(CultureInfo.CurrentUICulture, fieldName))
		End Sub
	
 
 End Class



<Serializable()> Public Class MissingSpecializationException
        Inherits TrespassingException
		
		Public Sub New()
            MyBase.New(Messages.GeneralMissingSpecializationException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal baseType As Type, ByVal methodName As String)
			MyBase.New(Messages.SpecificMissingSpecializationException(CultureInfo.CurrentUICulture, baseType, methodName))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class MissingWiringException
        Inherits TrespassingException
		
		Public Sub New()
            MyBase.New(Messages.GeneralMissingWiringException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal typeName As Type, ByVal methodName As String)
			MyBase.New(Messages.SpecificMissingWiringException(CultureInfo.CurrentUICulture, typeName, methodName))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class RedundantWiringException
        Inherits TrespassingException
		
		Public Sub New()
            MyBase.New(Messages.GeneralRedundantWiringException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal thisType As Type, ByVal wireName As String)
			MyBase.New(Messages.SpecificRedundantWiringException(CultureInfo.CurrentUICulture, thisType, wireName))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class ControlIsNotAutosizableException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralControlIsNotAutosizableException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal controlName As String)
			MyBase.New(Messages.SpecificControlIsNotAutosizableException(CultureInfo.CurrentUICulture, controlName))
		End Sub
	
 
 End Class



<Serializable()> Public Class ControlHasNoSupportForSoughtInterfaceException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralControlHasNoSupportForSoughtInterfaceException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal controlName As String, ByVal interfaceName As String)
			MyBase.New(Messages.SpecificControlHasNoSupportForSoughtInterfaceException(CultureInfo.CurrentUICulture, controlName, interfaceName))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class UnexpectedNumberOfInterfaceSupportersException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralUnexpectedNumberOfInterfaceSupportersException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal interfaceName As String, ByVal foundCount As Integer, ByVal expectedCount As Integer)
			MyBase.New(Messages.SpecificUnexpectedNumberOfInterfaceSupportersException(CultureInfo.CurrentUICulture, interfaceName, foundCount, expectedCount))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class TooManyCallsException
        Inherits TrespassingException
		
		Public Sub New()
            MyBase.New(Messages.GeneralTooManyCallsException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal methodName As String, ByVal limit As Integer)
			MyBase.New(Messages.SpecificTooManyCallsException(CultureInfo.CurrentUICulture, methodName, limit))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class NotFormInvokableException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralNotFormInvokableException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class MissingThreadInterruptedHandlerException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralMissingThreadInterruptedHandlerException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class BadProxyException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralBadProxyException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal collectionType As Type, ByVal proxyName As String)
			MyBase.New(Messages.SpecificBadProxyException(CultureInfo.CurrentUICulture, collectionType, proxyName))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class

End Namespace
