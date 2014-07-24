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


Namespace Mbark.Sensors


    <Serializable()> Public Class SensorProperties
        Implements ICloneable

#Region "Private"
        Private mManufacturer As String
        Private mModelName As String
        Private mSerialNumber As String
        Private mElectronicLabel As String
        Private mVendorLibraryName As String
        Private mVendorLibraryVersion As String
        Private mExifProperties As ExifProperties
        Private mModality As SensorModality
        Private mFirmwareVersion As String
#End Region

#Region "Properties"
        Public Property Manufacturer() As String
            Get
                Return mManufacturer
            End Get
            Set(ByVal value As String)
                mManufacturer = value
            End Set
        End Property
        Public Property ModelName() As String
            Get
                Return mModelName
            End Get
            Set(ByVal value As String)
                mModelName = value
            End Set
        End Property
        Public Property FirmwareVersion() As String
            Get
                Return mFirmwareVersion
            End Get
            Set(ByVal value As String)
                mFirmwareVersion = value
            End Set
        End Property
        Public Property SerialNumber() As String
            Get
                Return mSerialNumber
            End Get
            Set(ByVal value As String)
                mSerialNumber = value
            End Set
        End Property
        Public Property ElectronicLabel() As String
            Get
                Return mElectronicLabel
            End Get
            Set(ByVal value As String)
                mElectronicLabel = value
            End Set
        End Property
        Public Property VendorLibraryName() As String
            Get
                Return mVendorLibraryName
            End Get
            Set(ByVal value As String)
                mVendorLibraryName = value
            End Set
        End Property
        Public Property VendorLibraryVersion() As String
            Get
                Return mVendorLibraryVersion
            End Get
            Set(ByVal value As String)
                mVendorLibraryVersion = value
            End Set
        End Property
        Public Property ExifProperties() As ExifProperties
            Get
                Return mExifProperties
            End Get
            Set(ByVal value As ExifProperties)
                mExifProperties = value
            End Set
        End Property
        Public Property Modality() As SensorModality
            Get
                Return mModality
            End Get
            Set(ByVal value As SensorModality)
                mModality = value
            End Set
        End Property
#End Region

#Region "Clone and Deep Copy"

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New SensorProperties
            newDef.Manufacturer = Me.Manufacturer
            newDef.ModelName = Me.ModelName
            newDef.FirmwareVersion = Me.FirmwareVersion
            newDef.SerialNumber = Me.SerialNumber
            newDef.ElectronicLabel = Me.ElectronicLabel
            newDef.VendorLibraryVersion = Me.VendorLibraryName
            newDef.VendorLibraryVersion = Me.VendorLibraryVersion
            newDef.Modality = Me.Modality
            If Not ExifProperties Is Nothing Then
                newDef.ExifProperties = Me.ExifProperties.DeepCopy()
            End If
            Return newDef
        End Function

        Public Function DeepCopy() As SensorProperties
            Return DirectCast(Clone(), SensorProperties)
        End Function
#End Region

    End Class

End Namespace
