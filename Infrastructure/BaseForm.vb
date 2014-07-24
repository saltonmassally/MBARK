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
Imports System.Security.Permissions
Imports System.Windows.Forms

Namespace Mbark.UI

    Public Class BaseForm
        Inherits System.Windows.Forms.Form

        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            If ResizeTimer Is Nothing Then ResizeTimer = New System.Windows.Forms.Timer
            ResizeTimer.Enabled = True
            ResizeTimer.Stop()
            ResizeTimer.Start()
        End Sub


        Private Sub ResizeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResizeTimer.Tick
            ResizeTimer.Enabled = False
            MyBase.OnResize(New EventArgs)
        End Sub


    End Class

End Namespace