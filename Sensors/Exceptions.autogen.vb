Imports System
Imports System.Globalization
Imports System.Runtime.Serialization
Imports Mbark.SensorMessages
Imports Mbark.Sensors

Namespace Mbark


<Serializable()> Public Class BadSensorStatusException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralBadSensorStatusException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal operation As String, ByVal state As SensorStatus)
			MyBase.New(Messages.SpecificBadSensorStatusException(CultureInfo.CurrentUICulture, operation, state))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class UnexpectedMissingBodyPartException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralUnexpectedMissingBodyPartException(CultureInfo.CurrentUICulture))
        End Sub        

		Public Sub New(ByVal msg As String, ByVal ex As Exception)
            MyBase.New(msg, ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
		
	
		Public Sub New(ByVal missingBodyParts As BodyPartCollection, ByVal expectedBodyParts As BodyPartCollection)
			MyBase.New(Messages.SpecificUnexpectedMissingBodyPartException(CultureInfo.CurrentUICulture, missingBodyParts, expectedBodyParts))
		End Sub
	
		Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
	
 
 End Class



<Serializable()> Public Class PollingCanceledException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralPollingCanceledException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class CaptureTimeoutException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralCaptureTimeoutException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class CaptureFailureException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralCaptureFailureException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class ConfigurationFailureException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralConfigurationFailureException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class ConfigurationTimeoutException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralConfigurationTimeoutException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class DownloadFailureException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralDownloadFailureException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class DownloadTimeoutException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralDownloadTimeoutException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class InitializationFailureException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralInitializationFailureException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class InitializationTimeoutException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralInitializationTimeoutException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class BadDefinitionException
        Inherits SensorException
		
		Public Sub New()
            MyBase.New(Messages.GeneralBadDefinitionException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class UnfinishedBodyPartsUpdateException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralUnfinishedBodyPartsUpdateException(CultureInfo.CurrentUICulture))
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



<Serializable()> Public Class MissingConditionFactoryException
        Inherits MbarkException
		
		Public Sub New()
            MyBase.New(Messages.GeneralMissingConditionFactoryException(CultureInfo.CurrentUICulture))
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

End Namespace
