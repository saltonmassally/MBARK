Option Strict On

Imports System.Xml.Serialization
Imports System.Collections.Generic

Namespace Mbark


    Public Interface IHasName
        ReadOnly Property Name() As String
    End Interface

    Public Interface INameQueryable(Of T)
        Function ByName(ByVal nameOfSoughtElement As String) As T
    End Interface

    <Serializable()> Public Structure NamedProxy(Of T As IHasName)

        Private mName As String


        Public Sub New(ByVal source As T)
            mName = source.Name
        End Sub

        <XmlAttribute("Name")> Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value
            End Set
        End Property

        Public Function Dereference(ByVal source As INameQueryable(Of T)) As T
            If source Is Nothing Then Throw New ArgumentNullException("source")
            Dim found As T = source.ByName(Me.Name)
            If found Is Nothing Then Throw New BadProxyException(GetType(T), Name)
            Return found
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Return Name = DirectCast(obj, NamedProxy(Of T)).Name
        End Function






    End Structure

End Namespace