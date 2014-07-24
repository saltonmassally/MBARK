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

Imports System.Drawing
Imports System.Globalization

Namespace Mbark.Sensors

    <Serializable()> Public Class SensorTaskColorsDefinition
        Implements ICloneable

        Private mInactive As String
        Public Property Inactive() As String
            Get
                Return mInactive
            End Get
            Set(ByVal value As String)
                mInactive = value
            End Set
        End Property
        Private mConflictTextColor As String
        Public Property ConflictTextColor() As String
            Get
                Return mConflictTextColor
            End Get
            Set(ByVal value As String)
                mConflictTextColor = value
            End Set
        End Property
        Private mActive As String
        Public Property Active() As String
            Get
                Return mActive
            End Get
            Set(ByVal value As String)
                mActive = value
            End Set
        End Property
        Private mDownloadProgressBar As String
        Public Property DownloadProgressBar() As String
            Get
                Return mDownloadProgressBar
            End Get
            Set(ByVal value As String)
                mDownloadProgressBar = value
            End Set
        End Property

        Public Function CreateSensorTaskColors() As SensorTaskColors
            Dim newColors As New SensorTaskColors
            newColors.Active = Color.FromArgb(Convert.ToInt32(Active, 16))
            newColors.Inactive = Color.FromArgb(Convert.ToInt32(Inactive, 16))
            newColors.DownloadProgressBar = Color.FromArgb(Convert.ToInt32(DownloadProgressBar, 16))
            newColors.ConflictTextColor = Color.FromArgb(Convert.ToInt32(ConflictTextColor, 16))
            Return newColors
        End Function

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newDef As New SensorTaskColorsDefinition
            newDef.Inactive = Inactive
            newDef.Active = Active
            newDef.ConflictTextColor = ConflictTextColor
            newDef.DownloadProgressBar = DownloadProgressBar
            Return newDef
        End Function

        Public Function DeepCopy() As SensorTaskColorsDefinition
            Return DirectCast(Clone(), SensorTaskColorsDefinition)
        End Function
    End Class

    Public Class SensorTaskColors

        Public Function Definition() As SensorTaskColorsDefinition
            Dim newDef As New SensorTaskColorsDefinition
            With newDef
                .Active = String.Format(cultureinfo.invariantculture, "{0:x8}", mActive.ToArgb)
                .Inactive = String.Format(CultureInfo.InvariantCulture, "{0:x8}", mInactive.ToArgb)
                .ConflictTextColor = String.Format(CultureInfo.InvariantCulture, "{0:x8}", mConflictTextColor.ToArgb)
                .DownloadProgressBar = String.Format(CultureInfo.InvariantCulture, "{0:x8}", mDownloadProgressBar.ToArgb)
            End With
            Return newDef
        End Function

        Private mInactive As Color
        Private mConflictTextColor As Color
        Private mActive As Color
        Private mDownloadProgressBar As Color

        Public Property Inactive() As Color
            Get
                Return mInactive
            End Get
            Set(ByVal value As Color)
                mInactive = value
            End Set
        End Property

        Public Property DownloadProgressBar() As Color
            Get
                Return mDownloadProgressBar
            End Get
            Set(ByVal value As Color)
                mDownloadProgressBar = value
            End Set
        End Property


        Public Property ConflictTextColor() As Color
            Get
                Return mConflictTextColor
            End Get
            Set(ByVal value As Color)
                mConflictTextColor = value
            End Set
        End Property

        Public Property Active() As Color
            Get
                Return mActive
            End Get
            Set(ByVal value As Color)
                mActive = value
            End Set
        End Property
    End Class


End Namespace
