Option Strict On

Imports System.Globalization

Module VirtualSensorControllerEntryPoint

    Public Sub Main()

        Dim culture As New CultureInfo("en-US")
        Try
            Static mutex As Threading.Mutex
            mutex = New Threading.Mutex(True, "StandaloneSensorControllerEntryPoint")

            If mutex.WaitOne(0, False) Then
                Application.EnableVisualStyles()
                Application.DoEvents()
                Dim splash As New SplashScreen
                splash.Show()
                Application.DoEvents()

                Dim controller As VirtualSensorController = New VirtualSensorController
                controller.UICulture = culture
                Application.Run(controller)
            Else
                MsgBox("Please close the application before starting another") 'i18n
            End If
        Catch ex As Exception
            Mbark.Debugging.Break()
            Mbark.UI.PrettyPrintException(culture, ex)
        End Try

    End Sub

End Module
