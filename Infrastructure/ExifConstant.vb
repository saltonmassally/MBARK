'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
'       Kayee Kwong (kayee@nist.gov)
'       Ross J. Micheals (rossm@nist.gov)
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

Namespace Mbark

    <Serializable()> Public Enum ExifFlashState
        No = 0
        Yes = 1
        Unknown = 2
        Unspecified
    End Enum
    <Serializable()> Public Enum ExifFlashMode
        [On] = 0
        Automatic = 1
        Off = 2
        Unspecified
    End Enum
    <Serializable()> Public Enum ExifFlashRedeyeMode
        [On] = 0
        Off = 1
        Unspecified
    End Enum
    <Serializable()> Public Enum ExifContrast
        Normal = 0

        Soft = 1
        Hard = 2
        Unspecified
    End Enum
    <Serializable()> Public Enum ExifGainControl
        None = 0
        LowGainUp = 1
        HighGainUp = 2
        LowGainDown = 3
        HighGainDown = 4
        Unspecified
    End Enum
    <Serializable()> Public Enum ExifSaturation
        Normal = 0
        Low = 1
        High = 2
        Unspecified
    End Enum
    <Serializable()> Public Enum ExifSharpness
        Normal = 0
        Soft = 1
        Hard = 2
        Unspecified
    End Enum
    <Serializable()> Public Enum ExifWhiteBalance
        Automatic = 0
        ManualWhiteBalance = 1
        Unspecified
    End Enum

    <Serializable()> Public Class ExifProperties
        Implements ICloneable


        Private mAperture As Double                                           'Exif ID 9205
        Private mContrastProcessing As ExifContrast = ExifContrast.Unspecified        'Exif ID A408
        Private mDigitalZoomRatio As Double                                   'Exif ID A404
        Private mExposureBias As Double                                       'Exif ID 9204
        Private mExposureProgram As Short                                     'Exif ID 8822
        Private mExposureTime As Double                                       'Exif ID 829A
        Private mFlashState As ExifFlashState = ExifFlashState.Unspecified            'Exif ID 9209
        Private mFlashMode As ExifFlashMode = ExifFlashMode.Unspecified               'Exif ID 9209
        Private mFlashRedeye As ExifFlashRedeyeMode = ExifFlashRedeyeMode.Unspecified 'Exif ID 9209
        Private mFocalLength As Double                                        'Exif ID 920A
        Private mGainControl As ExifGainControl = ExifGainControl.Unspecified         'Exif ID A407
        Private mIlluminationType As Integer                                  'Exif ID 9208
        Private mMeteringMode As Short                                        'Exif ID 9207 
        Private mSaturationProcessing As ExifSaturation = ExifSaturation.Unspecified  'Exif ID A409
        Private mSharpnessProcessing As ExifSharpness = ExifSharpness.Unspecified     'Exif ID A40A
        Private mIso As Short                                                 'Exif ID 8827
        Private mWhiteBalance As ExifWhiteBalance = ExifWhiteBalance.Unspecified      'Exif ID A403



        Public Property Aperture() As Double
            Get
                Return mAperture
            End Get
            Set(ByVal value As Double)
                mAperture = value
            End Set
        End Property
        Public Property ContrastProcessing() As ExifContrast
            Get
                Return mContrastProcessing
            End Get
            Set(ByVal value As ExifContrast)
                mContrastProcessing = value
            End Set
        End Property
        Public Property DigitalZoomRatio() As Double
            Get
                Return mDigitalZoomRatio
            End Get
            Set(ByVal value As Double)
                mDigitalZoomRatio = value
            End Set
        End Property
        Public Property ExposureBias() As Double
            Get
                Return mExposureBias
            End Get
            Set(ByVal value As Double)
                mExposureBias = value
            End Set
        End Property
        Public Property ExposureProgram() As Short
            Get
                Return mExposureProgram
            End Get
            Set(ByVal value As Short)
                mExposureProgram = value
            End Set
        End Property
        Public Property ExposureTime() As Double
            Get
                Return mExposureTime
            End Get
            Set(ByVal value As Double)
                mExposureTime = value
            End Set
        End Property
        Public Property FlashState() As ExifFlashState
            Get
                Return mFlashState
            End Get
            Set(ByVal value As ExifFlashState)
                mFlashState = value
            End Set
        End Property
        Public Property FlashMode() As ExifFlashMode
            Get
                Return mFlashMode
            End Get
            Set(ByVal value As ExifFlashMode)
                mFlashMode = value
            End Set
        End Property
        Public Property FlashRedeye() As ExifFlashRedeyeMode
            Get
                Return mFlashRedeye
            End Get
            Set(ByVal value As ExifFlashRedeyeMode)
                mFlashRedeye = value
            End Set
        End Property
        Public Property FocalLength() As Double
            Get
                Return mFocalLength
            End Get
            Set(ByVal value As Double)
                mFocalLength = value
            End Set
        End Property
        Public Property GainControl() As ExifGainControl
            Get
                Return mGainControl
            End Get
            Set(ByVal value As ExifGainControl)
                mGainControl = value
            End Set
        End Property
        Public Property IlluminationType() As Integer
            Get
                Return mIlluminationType
            End Get
            Set(ByVal value As Integer)
                mIlluminationType = value
            End Set
        End Property
        Public Property MeteringMode() As Short
            Get
                Return mMeteringMode
            End Get
            Set(ByVal value As Short)
                mMeteringMode = value
            End Set
        End Property
        Public Property SaturationProcessing() As ExifSaturation
            Get
                Return mSaturationProcessing
            End Get
            Set(ByVal value As ExifSaturation)
                mSaturationProcessing = value
            End Set
        End Property
        Public Property SharpnessProcessing() As ExifSharpness
            Get
                Return mSharpnessProcessing
            End Get
            Set(ByVal value As ExifSharpness)
                mSharpnessProcessing = value
            End Set
        End Property
        Public Property Iso() As Short
            Get
                Return mIso
            End Get
            Set(ByVal value As Short)
                mIso = value
            End Set
        End Property
        Public Property WhiteBalance() As ExifWhiteBalance
            Get
                Return mWhiteBalance
            End Get
            Set(ByVal value As ExifWhiteBalance)
                mWhiteBalance = value
            End Set
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New ExifProperties

            With newDef
                .Aperture = Aperture
                .ContrastProcessing = ContrastProcessing
                .DigitalZoomRatio = DigitalZoomRatio
                .ExposureBias = ExposureBias
                .ExposureProgram = ExposureProgram
                .ExposureTime = ExposureTime
                .FlashState = FlashState
                .FlashMode = FlashMode
                .FlashRedeye = FlashRedeye
                .FocalLength = FocalLength
                .GainControl = GainControl
                .IlluminationType = IlluminationType
                .MeteringMode = MeteringMode
                .SaturationProcessing = SaturationProcessing
                .SharpnessProcessing = SharpnessProcessing
                .Iso = Iso
                .WhiteBalance = WhiteBalance
            End With

            Return newDef
        End Function

        Public Function DeepCopy() As ExifProperties
            Return DirectCast(Clone(), ExifProperties)
        End Function
    End Class


End Namespace
