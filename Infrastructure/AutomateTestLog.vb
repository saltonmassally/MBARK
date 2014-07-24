Imports System.IO

Public Module AutomateTestLog

    Public LogFileName As String
    Public Sub OutputLog(ByVal stepNum As Integer, ByVal command As String)
        Dim sw As New StreamWriter(LogFileName, True)
        sw.WriteLine("(step " & stepNum & ") - [" & DateTime.Now & " - " & command.ToUpper & "]")
        sw.Flush()
        sw.Close()
    End Sub
    Public Sub OutputLog(ByVal msg As String)
        Dim sw As New StreamWriter(LogFileName, True)
        sw.WriteLine(msg)
        sw.Flush()
        sw.close()
    End Sub
End Module
