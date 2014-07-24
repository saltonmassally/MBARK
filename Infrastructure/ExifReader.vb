'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
'       Ross J. Micheals (rossm@nist.gov)
'       Kayee Kwong (kayee@nist.gov)
'
' •—————————————————————————————————————————————————————————————————————————————————————————————————————•
' | LICENSE & DISCLAIMER                                                                                |
' |                                                                                                     |
' | This software was developed at the National Institute of Standards and Technology (NIST) by         |
' | employees of the Federal Government in the course of their official duties. Pursuant to title 17    |
' | Section 105 of the United States Code. This software is not subject to copyright protection and     |
' | is in the public domain. NIST assumes no responsibility whatsoever for use by other parties of      |
' | its source code or open source server, and makes no guarantees, expressed or implied, about its     |
' | quality, reliability, or any other characteristic.                                                  |
' |                                                                                                     |
' | Specific hardware and software products identified in this open source project were used in order   |
' | to perform technology transfer and collaboration. In no case does such identification imply         |
' | recommendation or endorsement by the National Institute of Standards and Technology, nor            |
' | does it imply that the products and equipment identified are necessarily the best available for the |
' | purpose.                                                                                            |
' •—————————————————————————————————————————————————————————————————————————————————————————————————————•

Option Strict On

Imports System.IO
Imports System.Drawing
Imports System.Globalization

Imports Mbark.InfrastructureMessages

Namespace Mbark

    Public Module ExifReader

        Public Function ExtractExifHeader(ByVal imageAsBytes() As Byte) As ExifProperties
            Try
                If imageAsBytes Is Nothing Then Throw New ArgumentNullException("imageAsBytes")
                Dim imgconv As New ImageConverter
                Dim myimage As Bitmap = DirectCast(imgconv.ConvertFrom(imageAsBytes), Bitmap)
                Return ExtractExifProperties(myimage)
            Catch ex As System.ArgumentException
                Throw
            End Try
        End Function
        Public Function ExtractExifHeader(ByVal img As Image) As ExifProperties
            If img Is Nothing Then Throw New ArgumentNullException("Image is Null")
            Return ExtractExifProperties(img)
        End Function

        Private Function ExtractExifProperties(ByVal image As Image) As ExifProperties
            Dim ExifProp As New ExifProperties

            ExifProp.Aperture = CDbl(GetItemValue(image, ExifTag.FNumber))
            ExifProp.ContrastProcessing = CType(GetItemValue(image, ExifTag.ContrastProcessing), ExifContrast)
            ExifProp.DigitalZoomRatio = CDbl(GetItemValue(image, ExifTag.DigitalZRatio))
            ExifProp.ExposureBias = CDbl(GetItemValue(image, ExifTag.ExposureBias))
            ExifProp.ExposureProgram = CShort(GetItemValue(image, ExifTag.ExposureProg))
            PopulateFlashMode(image, ExifProp)
            PopulateFlashState(image, ExifProp)
            PopulateFlashRedeye(image, ExifProp)
            ExifProp.FocalLength = CDbl(GetItemValue(image, ExifTag.FocalLength))
            ExifProp.GainControl = CType(GetItemValue(image, ExifTag.GainControl), ExifGainControl)
            ExifProp.Iso = CShort(GetItemValue(image, ExifTag.IsoSpeed))
            ExifProp.IlluminationType = CInt(GetItemValue(image, ExifTag.LightSource))
            ExifProp.MeteringMode = CShort(GetItemValue(image, ExifTag.MeteringMode))
            ExifProp.SaturationProcessing = CType(GetItemValue(image, ExifTag.SaturationProcessing), ExifSaturation)
            ExifProp.SharpnessProcessing = CType(GetItemValue(image, ExifTag.SharpnessProcessing), ExifSharpness)
            ExifProp.WhiteBalance = CType(GetItemValue(image, ExifTag.WhiteBalance), ExifWhiteBalance)

            Return ExifProp

        End Function

        Private Sub PopulateFlashState(ByVal image As Image, ByRef ExifProp As ExifProperties)
            Dim P As System.Drawing.Imaging.PropertyItem = image.GetPropertyItem(ExifTag.Flash)
            Dim value As Integer = FromBytesToInt16(P.Value)
            'determine Flash State
            Select Case value
                Case 0, 16, 24
                    ExifProp.FlashState = ExifFlashState.No
                Case 32
                    ExifProp.FlashState = ExifFlashState.Unknown
                Case Else
                    ExifProp.FlashState = ExifFlashState.Yes
            End Select
        End Sub
        Private Sub PopulateFlashMode(ByVal image As Image, ByRef ExifProp As ExifProperties)
            Dim P As System.Drawing.Imaging.PropertyItem = image.GetPropertyItem(ExifTag.Flash)
            Dim value As Integer = FromBytesToInt16(P.Value)
            Select Case value
                Case 9, 13, 15, 16, 73, 77, 79
                    ExifProp.FlashMode = ExifFlashMode.On
                Case 32
                    ExifProp.FlashMode = ExifFlashMode.Off
                Case Else
                    ExifProp.FlashMode = ExifFlashMode.Automatic
            End Select
        End Sub


        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> Private Sub PopulateFlashRedeye(ByVal image As Image, ByRef ExifProp As ExifProperties)

            '0000.H = Flash did not fire.
            '0001.H = Flash fired.
            '0005.H = Strobe return light not detected.
            '0007.H = Strobe return light detected.
            '0009.H = Flash fired, compulsory flash mode
            '000D.H = Flash fired, compulsory flash mode, return light not detected
            '000F.H = Flash fired, compulsory flash mode, return light detected
            '0010.H = Flash did not fire, compulsory flash mode
            '0018.H = Flash did not fire, auto mode
            '0019.H = Flash fired, auto mode
            '001D.H = Flash fired, auto mode, return light not detected
            '001F.H = Flash fired, auto mode, return light detected
            '0020.H = No flash function
            '0041.H = Flash fired, red-eye reduction mode
            '0045.H = Flash fired, red-eye reduction mode, return light not detected
            '0047.H = Flash fired, red-eye reduction mode, return light detected
            '0049.H = Flash fired, compulsory flash mode, red-eye reduction mode
            '004D.H = Flash fired, compulsory flash mode, red-eye reduction mode, return light not detected
            '004F.H = Flash fired, compulsory flash mode, red-eye reduction mode, return light detected
            '0059.H = Flash fired, auto mode, red-eye reduction mode
            '005D.H = Flash fired, auto mode, return light not detected, red-eye reduction mode
            '005F.H = Flash fired, auto mode, return light detected, red-eye reduction mode

            Dim pi As System.Drawing.Imaging.PropertyItem = image.GetPropertyItem(ExifTag.Flash)
            Dim value As Integer = FromBytesToInt16(pi.Value)

            Select Case value
                Case &H41, &H45, &H46, &H47, &H49, &H4D, &H4F, &H59, &H5D, &H5F
                    ExifProp.FlashRedeye = ExifFlashRedeyeMode.On
                Case Else
                    ExifProp.FlashRedeye = ExifFlashRedeyeMode.Off
            End Select
        End Sub
        Private Function GetItemValue(ByVal image As Image, ByVal id As Integer) As Object
            Dim P As System.Drawing.Imaging.PropertyItem = image.GetPropertyItem(id)
            Select Case P.Type
                Case 2 'ASCII
                    Return FromBytesToString(P.Value)
                Case 3 'Short
                    Return FromBytesToInt16(P.Value)
                Case 4, 9 'Long
                    Return FromBytesToInt16(P.Value)
                Case 5, 10 'Rational
                    Return FromBytesToRational(P.Value).ToDouble()
                Case Else
                    Return Nothing
            End Select
        End Function

        Private Function IsPropertyDefined(ByVal image As Image, ByVal propertyId As Int32) As Boolean
            Return CBool([Array].IndexOf(image.PropertyIdList, propertyId) > -1)
        End Function

        Public Function GetPropertyRational(ByVal image As Image, ByVal propertyId As Int32) As Rational
            If IsPropertyDefined(image, propertyId) Then
                Return FromBytesToRational(image.GetPropertyItem(propertyId).Value)
            Else
                Dim rational As New Rational
                rational.Numerator = 0
                rational.Denominator = 1
                Return rational
            End If
        End Function

        Public Function FromBytesToString(ByVal data As Byte()) As String
            If data Is Nothing Then Throw New ArgumentNullException("data")
            Dim asString As String = System.Text.Encoding.ASCII.GetString(data)
            If asString.EndsWith(vbNullChar) Then asString = asString.Substring(0, asString.Length - 1)
            Return asString
        End Function

        Public Function FromBytesToInt16(ByVal data As Byte()) As Int16
            If data Is Nothing Then Throw New ArgumentNullException("data")
            If data.Length < 2 Then Throw New ArgumentException(Messages.DataTooShortNBytesExpected(2), "data")
            Return data(1) << 8 Or data(0)
        End Function

        Public Function FromBytesToInt32(ByVal data As Byte()) As Int32
            If data Is Nothing Then Throw New ArgumentNullException("data")
            If data.Length < 4 Then Throw New ArgumentException(Messages.DataTooShortNBytesExpected(4), "data")
            Return data(3) << 24 Or data(2) << 16 Or data(1) << 8 Or data(0)
        End Function

        Public Function FromBytesToRational(ByVal data As Byte()) As Rational
            If data Is Nothing Then Throw New ArgumentNullException("data")
            If data.Length < 8 Then Throw New ArgumentException(Messages.DataTooShortNBytesExpected(8), "data")

            Dim R As New Rational, N(3), D(3) As Byte
            Array.Copy(data, 0, N, 0, 4)
            Array.Copy(data, 4, D, 0, 4)
            R.Denominator = FromBytesToInt16(D)
            R.Numerator = FromBytesToInt16(N)
            Return R
        End Function


    End Module

    <Serializable()> Public Class Rational

        Public Property Numerator() As Int32
            Get
                Return mNumerator
            End Get
            Set(ByVal value As Int32)
                mNumerator = value
            End Set
        End Property
        Public Property Denominator() As Int32
            Get
                Return mDenominator
            End Get
            Set(ByVal value As Int32)
                mDenominator = value
            End Set
        End Property

        Private mNumerator As Int32
        Private mDenominator As Int32

        Public Overloads Function ToString(ByVal culture As CultureInfo, ByVal delimiter As String) As String
            Return String.Format(culture, "{0}{1}{2}", Numerator, delimiter, Denominator)
        End Function

        Public Function ToDouble() As Double
            Dim result As Double = Numerator * 1.0 / Denominator
            Return result
        End Function

        Public Overloads Function Equals(ByVal value As Rational) As Boolean
            If value Is Nothing Then Throw New ArgumentNullException("value")
            Return Numerator = value.Numerator AndAlso Denominator = value.Denominator
        End Function

    End Class

#Region "       Enumeration     "
    Public Enum ExifTag
        Invalid = 0
        Aperture = &H9202
        ContrastProcessing = &HA408
        DigitalZRatio = &HA404
        ExposureBias = &H9204
        ExposureProg = &H8822
        ExposureTime = &H829A
        FileSource = &HA300
        Flash = &H9209
        FNumber = &H829D
        FocalLength = &H920A
        FocalXRes = &HA20E
        FocalYRes = &HA20F
        FocalResUnit = &HA210
        GainControl = &HA407
        IsoSpeed = &H8827
        LightSource = &H9208
        MakerNote = &H927C
        MaxAperture = &H9205
        MeteringMode = &H9207
        SaturationProcessing = &HA409
        SceneType = &HA301
        SensingMethod = &HA217
        SharpnessProcessing = &HA40A
        ShutterSpeed = &H9201
        SubjectDistance = &H9206
        SubjectLocation = &HA214
        UserComment = &H9286
        WhiteBalance = &HA403
    End Enum
#End Region


End Namespace