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

Namespace Mbark.Sensors.Builtins

    Public NotInheritable Class SensorTaskColorSchemes

        Private Sub New()
            ' Forbid construction
        End Sub

        ' http://wellstyled.com/tools/colorscheme2/index-en.html

        Private Shared smRed As SensorTaskColors
        Public Shared ReadOnly Property Red() As SensorTaskColors
            Get
                If smRed Is Nothing Then
                    smRed = New SensorTaskColors
                    With smRed
                        .Active = Color.FromArgb(&HFFFF8080)
                        .DownloadProgressBar = Color.FromArgb(&HFFB30000)
                        .ConflictTextColor = Color.FromArgb(&HFFFF0000)
                        .Inactive = Color.FromArgb(&HFFFFBFBF)
                    End With
                End If
                Return smRed
            End Get
        End Property

        Private Shared smOrange As SensorTaskColors
        Public Shared ReadOnly Property Orange() As SensorTaskColors
            Get
                If smOrange Is Nothing Then
                    smOrange = New SensorTaskColors
                    With smOrange
                        .Active = Color.FromArgb(&HFFFFCC80)
                        .DownloadProgressBar = Color.FromArgb(&HFFB36B00)
                        .ConflictTextColor = Color.FromArgb(&HFFFF9900)
                        .Inactive = Color.FromArgb(&HFFFFE6BF)
                    End With
                End If
                Return smOrange
            End Get
        End Property

        Private Shared smYellow As SensorTaskColors
        Public Shared ReadOnly Property Yellow() As SensorTaskColors
            Get
                If smYellow Is Nothing Then
                    smYellow = New SensorTaskColors
                    With smYellow
                        .Inactive = Color.FromArgb(&HFFFFFFBF)
                        .Active = Color.FromArgb(&HFFFFFF00)
                        .ConflictTextColor = Color.FromArgb(&HFFB3B300)
                        .DownloadProgressBar = Color.FromArgb(&HFFB3B300)
                    End With
                End If
                Return smYellow
            End Get
        End Property


        Private Shared smBlueGreen As SensorTaskColors
        Public Shared ReadOnly Property BlueGreen() As SensorTaskColors
            Get
                If smBlueGreen Is Nothing Then
                    smBlueGreen = New SensorTaskColors
                    With smBlueGreen
                        .Inactive = Color.FromArgb(&HFFBFFFFF)
                        .Active = Color.FromArgb(&HFF80FFFF)
                        .ConflictTextColor = Color.FromArgb(&HFF006B6B)
                        .DownloadProgressBar = Color.FromArgb(&HFF009999)
                    End With
                End If
                Return smBlueGreen
            End Get
        End Property


        Private Shared smGreen As SensorTaskColors
        Public Shared ReadOnly Property Green() As SensorTaskColors
            Get
                If smGreen Is Nothing Then
                    smGreen = New SensorTaskColors
                    With smGreen
                        .Inactive = Color.FromArgb(&HFFBFFFBF)
                        .Active = Color.FromArgb(&HFF80FF80)
                        .ConflictTextColor = Color.FromArgb(&HFF008F00)
                        .DownloadProgressBar = Color.FromArgb(&HFF00CC00)
                    End With
                End If
                Return smGreen
            End Get
        End Property

        Private Shared smBlue As SensorTaskColors
        Public Shared ReadOnly Property Blue() As SensorTaskColors
            Get
                If smBlue Is Nothing Then
                    smBlue = New SensorTaskColors
                    With smBlue
                        .Inactive = Color.FromArgb(&HFFBFCFFF)
                        .Active = Color.FromArgb(&HFF809FFF)
                        .ConflictTextColor = Color.FromArgb(&HFF00248F)
                        .DownloadProgressBar = Color.FromArgb(&HFF0033CC)
                    End With
                End If
                Return smBlue
            End Get
        End Property

        Private Shared smPurple As SensorTaskColors
        Public Shared ReadOnly Property Purple() As SensorTaskColors
            Get
                If smPurple Is Nothing Then
                    smPurple = New SensorTaskColors
                    With smPurple
                        .Inactive = Color.FromArgb(&HFFEABFFF)
                        .Active = Color.FromArgb(&HFFD580FF)
                        .ConflictTextColor = Color.FromArgb(&HFF00248F)
                        .DownloadProgressBar = Color.FromArgb(&HFF660099)
                    End With
                End If
                Return smPurple
            End Get
        End Property





    End Class

End Namespace