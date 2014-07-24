Imports System.IO
Imports Mbark.Sensors
Imports NIST.BiCCL


Public Class BiCCLLoader : Inherits BaseLoader

    Public Overrides Function LoadFromFile(ByVal fileName As String) As Stream
        If fileName = String.Empty Then Return Nothing
        If Path.GetExtension(fileName).Equals(".xml") Then
            Return LoadFromXmlFile(fileName)
        ElseIf Path.GetExtension(fileName).Equals(".biccl") Then
            Return LoadFromBiCCLFile(fileName)

        ElseIf Path.GetExtension(fileName).Equals(".txt") Then
            'For now, treat .txt files as BiCCL files.
            Return LoadFromBiCCLFile(fileName)
        End If
        Return Nothing 'if the file isn't one we know
    End Function

    Public Function LoadFromBiCCLFile(ByVal fileName As String) As Stream

        If fileName = String.Empty Then Return Nothing

        Dim theStream As New MemoryStream
        Try
            Dim mController As New BiCCLController()
            theStream = mController.convertBiCCLToMemoryStream(fileName)
        Catch ex As Exception
            'For now, do nothing.
            Debug.WriteLine("Couldn't load initial settings file " + fileName)
            Debug.WriteLine(ex.ToString)
            theStream = Nothing
        End Try

        Return theStream

    End Function

End Class
