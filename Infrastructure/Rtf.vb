Option Strict On

Imports System.IO
Imports System.Globalization
Imports System.Collections.Specialized


Imports Mbark.UI.GlobalUISettings

Namespace Mbark

    Public NotInheritable Class Rtf

        Private Sub New()

        End Sub

        Private Shared ReadOnly Property RtfFontTable() As String
            Get
                Dim writer As New StringWriter(CultureInfo.InvariantCulture)
                writer.Write("{\fonttbl{\f0\fswiss\fcharset0 ")
                writer.Write(Defaults.Fonts.FontName)
                writer.Write(";}")
                RtfFontTable = writer.ToString
                writer.Dispose()
            End Get
        End Property

        Public Shared ReadOnly Property Footer() As String
            Get
                Return " }"
            End Get
        End Property

        Public Shared Function ToRtf(ByVal message As String) As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            writer.Write(Header())
            writer.Write(message)
            writer.WriteLine(Footer)
            ToRtf = writer.ToString
            writer.Dispose()
        End Function

        Public Shared Function ToRtfBold(ByVal message As String) As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            writer.Write(Header())
            writer.Write(Rtf.BoldOn)
            writer.Write(message)
            writer.Write(Rtf.BoldOff)
            writer.WriteLine(Footer)
            ToRtfBold = writer.ToString
            writer.Dispose()
        End Function



        Public Shared Function ToRtfBold(ByVal message As String, ByVal size As Single) As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            writer.Write(Header())
            writer.Write("\fs")
            writer.Write(CInt(size * 2))
            writer.Write(Rtf.BoldOn)
            writer.Write(message)
            writer.Write(Rtf.BoldOff)
            writer.WriteLine(Footer)
            ToRtfBold = writer.ToString
            writer.Dispose()
        End Function

        Public Shared Function ToRtf(ByVal message As String, ByVal size As Single) As String
            Dim writer As New StringWriter(CultureInfo.InvariantCulture)
            writer.Write(Header())
            writer.Write("\fs")
            writer.Write(CInt(size * 2))
            writer.Write(message)
            writer.WriteLine(Footer)
            ToRtf = writer.ToString
            writer.Dispose()
        End Function

        Public Shared ReadOnly Property Header() As String
            Get
                Dim writer As New StringWriter(CultureInfo.InvariantCulture)
                With writer
                    .Write("{\rtf1 ")
                    .Write(RtfFontTable())
                    .Write("}\f0 ")
                    .Write("\fs")
                    .Write(Defaults.Fonts.Size * 2)
                End With
                Header = writer.ToString
                writer.Dispose()
            End Get
        End Property

        Public Shared Function BoldOn() As String
            Return "\b1"
        End Function

        Public Shared Function BoldOff() As String
            Return "\b0"
        End Function

        Public Shared Function Newline() As String
            Return " \line "
        End Function


        Public Shared Function GenerateRow(ByVal strings As StringCollection, ByVal formatProvider As IFormatProvider) As String
            If strings Is Nothing Then Throw New ArgumentNullException("strings")

            Dim writer As New StringWriter(formatProvider)
            With writer
                writer.Write("\trowd\trautofit0\intbl")
                For i As Integer = 0 To strings.Count - 1
                    writer.Write("\cellx")
                    writer.Write((i + 1) * 10000)
                Next
                writer.Write("{")
                For i As Integer = 0 To strings.Count - 1
                    writer.Write(strings(i))
                    writer.Write("\cell ")
                Next
                writer.WriteLine(" }")
                writer.Write("{\trowd\trautofit0\intabl")
                For i As Integer = 0 To strings.Count - 1
                    writer.Write("\cellx")
                    writer.Write((i + 1) * 10000)
                Next
                writer.WriteLine("\row }")
            End With
            GenerateRow = writer.ToString
            writer.Dispose()
        End Function

    End Class

End Namespace
