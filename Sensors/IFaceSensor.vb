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

Namespace Mbark.Sensors

    Public Enum PhysicalCameraLayout
        [Single]
        [ThreeByThree]
    End Enum

   
    Public Interface IFaceSensor

        Property IsDownloadCanceled() As Boolean

        ' Returns true if connection was opened successfully, or if the connection had already been opened.
        Function OpenConnection(ByVal requestor As String) As Boolean

        ' Returns true if the connection was closed sucessfully, or if the connection had already been closed.
        Function CloseConnection() As Boolean

        Function Initialize(ByVal configuration As PhysicalCameraLayout) As Boolean
        ReadOnly Property InitializationException() As Exception


        'Function GetPreviewImages() As Byte()()
        Function GetPreviewImages() As Object
        Sub StopPreviewImages()
        Function Capture() As Boolean
        ReadOnly Property CaptureException() As Exception
        ReadOnly Property PictureIndexes() As Integer()

        Sub DeleteAll()
        Sub DeleteLast()


        Function Configure(ByVal config As SensorConfiguration) As Boolean
        ReadOnly Property ConfigurationException() As Exception

        ReadOnly Property PictureCount(ByVal cameraNumber As Integer) As Integer

        Function DownloadPicture(ByVal cameraNumber As Integer, ByVal pictureNumber As Integer) As Byte()
        Function DownloadThumbnail(ByVal PictureIndexList() As Integer) As Boolean
        ReadOnly Property DownloadThumbnailException() As Exception
        ReadOnly Property Thumbnails() As Byte()()

        ReadOnly Property CameraCount() As Integer
        ReadOnly Property ConfigurationType() As Type

        Sub SetCameraIds(ByVal cameraId() As String)
        ReadOnly Property CameraIds() As String()
        ReadOnly Property IsFull() As Boolean
        Sub Uninitialize()
    End Interface


    Public Module FaceSensorUtilities

        Public Function ExpectedCameraCount(ByVal physicalConfiguration As PhysicalCameraLayout) As Integer
            Dim count As Integer = 0
            Select Case physicalConfiguration
                Case PhysicalCameraLayout.Single
                    count = 1
                Case PhysicalCameraLayout.ThreeByThree
                    count = 9
            End Select
            Return count
        End Function

    End Module
    

End Namespace

