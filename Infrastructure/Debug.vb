Option Strict On

Imports System.IO

Namespace Mbark

    Public Module Debugging
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId:="ex")> Public Sub Break(ByVal ex As Exception)
#If DEBUG Then
            Debugger.Break()
#Else
            Throw ex
#End If
        End Sub

        Public Sub Break()
#If DEBUG Then
            Debugger.Break()
#End If
        End Sub



        Public Sub WriteLine(ByVal message As String)
#If DEBUG Then
            Console.WriteLine(message)
#End If
        End Sub

        Public Sub Write(ByVal message As String)
#If DEBUG Then
            Console.Write(message)
#End If
        End Sub

        Public Sub WriteLine(ByVal ex As Exception)
#If DEBUG Then
            Console.WriteLine(Mbark.UnwindAllMessages(ex))
#End If
        End Sub

    End Module
End Namespace

