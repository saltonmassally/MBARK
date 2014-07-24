Option Strict On

Imports System.Globalization

Imports Mbark.InfrastructureMessages

Namespace Mbark



    Public Class StringPair

        Public Property First() As String
            Get
                Return mFirst
            End Get
            Set(ByVal value As String)
                mFirst = value
            End Set
        End Property
        Public Property Second() As String
            Get
                Return mSecond
            End Get
            Set(ByVal Value As String)
                mSecond = Value
            End Set
        End Property

        Private mFirst As String
        Private mSecond As String

        Public Overloads Function Equals(ByVal value As StringPair) As Boolean
            If value Is Nothing Then Throw New ArgumentNullException("value")
            Return First = value.First AndAlso Second = value.Second
        End Function

    End Class

    Public Module StringUtilities

        Public Const ForbiddenGetterMessage As String = "Use this property for writing values only."

        Public Function Quote(ByVal culture As CultureInfo, ByVal value As String) As String
            Return Messages.SingleQuote(culture) & value & Messages.SingleQuote(culture)
        End Function

        Public Function Parenthesize(ByVal culture As CultureInfo, ByVal value As String) As String
            Return Messages.OpenParenthesis(culture) & value & Messages.CloseParenthesis(culture)
        End Function


        Public Function UnwindAllMessages(ByVal ex As Exception) As String
            Dim builder As New Text.StringBuilder
            Dim count As Integer
            RecurseExceptionMessages(count, builder, ex)
            Return builder.ToString
        End Function


        Private Sub RecurseExceptionMessages(ByRef count As Integer, ByRef builder As Text.StringBuilder, ByRef ex As Exception)
            count += 1
            builder.Append(count & Messages.EnumerationDelimiter(CultureInfo.CurrentUICulture) & " " & ex.GetType.ToString & vbNewLine)
            builder.Append(ex.Message & vbNewLine)
            If Not ex.StackTrace Is Nothing Then builder.Append(ex.StackTrace.ToString & vbNewLine)
            If ex.InnerException Is Nothing Then
                Return
            Else
                RecurseExceptionMessages(count, builder, ex.InnerException)
            End If
        End Sub


        Public Function RemoveLinefeeds(ByVal value As String) As String
            If value Is Nothing Then Throw New ArgumentNullException(value)
            Return value.Replace(vbNewLine, " ")
        End Function

    End Module


End Namespace
