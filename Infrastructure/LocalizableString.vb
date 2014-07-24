Option Strict On

Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Xml.Serialization

Namespace Mbark

    <XmlType("RegionMessagePair"), Serializable()> Public Class RegionMessagePair
        Private mRegion As String = String.Empty
        Private mMessage As String = String.Empty

        <XmlAttribute("Region")> Public Property Region() As String
            Get
                Return mRegion
            End Get
            Set(ByVal value As String)
                mRegion = value
            End Set
        End Property

        <XmlAttribute("Message")> Public Property Message() As String
            Get
                Return mMessage
            End Get
            Set(ByVal Value As String)
                mMessage = Value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal region As String, ByVal message As String)
            mRegion = region
            mMessage = message
        End Sub


    End Class

    <XmlType("RuntimeLocalizableString")> _
    Public Class LocalizableString
        Implements IHasName

        Private mMessageTable As New Dictionary(Of String, String)
        Private mName As String ' We forgo the traditional use of a private instance of a definition since this is just one string


        Default Public Overridable Property Message(ByVal region As String) As String
            Get
                If mMessageTable.ContainsKey(region) Then
                    Return mMessageTable(region)
                Else
                    Return String.Empty
                End If
            End Get
            Set(ByVal value As String)
                mMessageTable(region) = value
            End Set
        End Property

        Public ReadOnly Property Name() As String Implements IHasName.Name
            Get
                Return mName
            End Get
        End Property

        Public Overridable Property ByCulture(ByVal culture As CultureInfo) As String
            Get
                If culture Is Nothing Then
                    Return mMessageTable(CultureInfo.CurrentUICulture.Name)
                Else
                    Return mMessageTable(culture.Name)
                End If
            End Get
            Set(ByVal Value As String)
                If culture Is Nothing Then Throw New ArgumentNullException("culture")
                mMessageTable(culture.Name) = Value
            End Set
        End Property

        Public Overridable Function CreateDefinition() As LocalizableStringDefinition
            Dim newDef As New LocalizableStringDefinition(mName)

            Dim en As IEnumerator(Of String) = mMessageTable.Keys.GetEnumerator
            While en.MoveNext
                Dim region As String = en.Current
                Dim message As String = Me(region)
                Dim pair As New RegionMessagePair(region, message)
                newDef.RegionMessagePairs.Add(pair)
            End While
            Return newDef
        End Function

        'Public Sub New()
        '    ' Permits serialization, but rjm asks WHY is this necessary???
        'End Sub

        Public Sub New(ByVal name As String)
            mName = name
        End Sub

    End Class

    <XmlType("LocalizableString"), Serializable()> Public Class LocalizableStringDefinition
        Implements ICloneable

        Private mName As String = String.Empty
        Private mRegionMessagePairs As New Collection(Of RegionMessagePair)

        <XmlAttribute("name")> Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value
            End Set
        End Property

        Public ReadOnly Property RegionMessagePairs() As Collection(Of RegionMessagePair)
            Get
                Return mRegionMessagePairs
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New LocalizableStringDefinition(mName)
            For i As Integer = 0 To mRegionMessagePairs.Count - 1
                With mRegionMessagePairs(i)
                    newDef.RegionMessagePairs.Add(New RegionMessagePair(.Region, .Message))
                End With
            Next
            Return newDef
        End Function

        Public Function DeepCopy() As LocalizableStringDefinition
            Return DirectCast(Clone(), LocalizableStringDefinition)
        End Function

        Public Function CreateLocalizableString() As LocalizableString
            Dim newLocalizableString As New LocalizableString(mName)
            For i As Integer = 0 To RegionMessagePairs.Count - 1
                newLocalizableString(RegionMessagePairs(i).Region) = RegionMessagePairs(i).Message
            Next
            Return newLocalizableString
        End Function

        Public Sub New(ByVal name As String)
            mName = name
        End Sub

        Public Sub New()
            ' Permits serialization
        End Sub

        

    End Class

    
    <XmlType("RuntimeLocalizableStrings")> _
    Public Class LocalizableStringCollection
        Implements INameQueryable(Of LocalizableString)

        Private mStringTable As New Dictionary(Of String, LocalizableString)

        Default Public Property LocalizableString(ByVal name As String) As LocalizableString
            Get
                Return mStringTable(name)
            End Get
            Set(ByVal value As LocalizableString)
                mStringTable(name) = value
            End Set
        End Property

        Public Function CreateDefinition() As LocalizableStringCollectionDefinition
            Dim newdef As New LocalizableStringCollectionDefinition
            Dim en As IEnumerator(Of LocalizableString) = mStringTable.Values.GetEnumerator
            While en.MoveNext
                newdef.LocalizableStringDefinitions.Add(en.Current.CreateDefinition)
            End While
            Return newdef
        End Function

        Public Sub AddRange(ByVal strings As LocalizableStringCollection)
            Dim en As IEnumerator(Of LocalizableString) = strings.mStringTable.Values.GetEnumerator
            While en.MoveNext
                mStringTable(en.Current.Name) = en.Current
            End While
        End Sub

        Public Sub Add(ByVal localizable As LocalizableString)
            mStringTable(localizable.Name) = localizable
        End Sub

        Public ReadOnly Property LocalizableStrings() As IEnumerator(Of LocalizableString)
            Get
                Return mStringTable.Values.GetEnumerator
            End Get
        End Property


        Public Function ByName(ByVal nameOfSoughtElement As String) As LocalizableString Implements INameQueryable(Of Mbark.LocalizableString).ByName
            Return mStringTable(nameOfSoughtElement)
        End Function

    End Class

    <XmlType("LocalizableStrings"), Serializable()> Public Class LocalizableStringCollectionDefinition
        Implements ICloneable

        Private mLocalizableStringDefinitions As New Collection(Of LocalizableStringDefinition)
        Public ReadOnly Property LocalizableStringDefinitions() As Collection(Of LocalizableStringDefinition)
            Get
                Return mLocalizableStringDefinitions
            End Get
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New LocalizableStringCollectionDefinition
            For i As Integer = 0 To mLocalizableStringDefinitions.Count - 1
                newDef.LocalizableStringDefinitions.Add(mLocalizableStringDefinitions(i))
            Next
            Return newDef
        End Function

        Public Function DeepCopy() As LocalizableStringCollectionDefinition
            Return DirectCast(Clone(), LocalizableStringCollectionDefinition)
        End Function

        Public Function CreateLocalizableStringCollection() As LocalizableStringCollection
            Dim newCollection As New LocalizableStringCollection
            For i As Integer = 0 To mLocalizableStringDefinitions.Count - 1
                Dim name As String = mLocalizableStringDefinitions(i).Name
                Dim stringDef As LocalizableStringDefinition = mLocalizableStringDefinitions(i)
                newCollection(name) = stringDef.CreateLocalizableString
            Next
            Return newCollection
        End Function

        Public Sub Add(ByVal definition As LocalizableStringDefinition)
            mLocalizableStringDefinitions.Add(definition)
        End Sub


        Public Sub New()
            ' Permits serialization
        End Sub

    End Class


End Namespace
