Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Namespace Mbark.Sensors

    Public Class BaseLoader

        Public Overridable Function LoadFromFile(ByVal fileName As String) As Stream
            If fileName = String.Empty Then Return Nothing
            Return LoadFromXmlFile(fileName)
        End Function


        Public Shared Function LoadFromXmlFile(ByVal fileName As String) As Stream

            If fileName = String.Empty Then Return Nothing
            Dim theStream As New IO.FileStream(fileName, IO.FileMode.Open)

            Return theStream
        End Function

    End Class
End Namespace

