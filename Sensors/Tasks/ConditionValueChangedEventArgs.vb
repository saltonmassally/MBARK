'
'  Multimodal Biometric Applicaiton Resource Kit (MBARK)
'
'  File author(s):
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

Imports System.Collections.Specialized
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.Windows.Forms

Imports Mbark.UI.GlobalUISettings

Namespace Mbark.Sensors

    Public Class ConditionValueChangedEventArgs
        Inherits EventArgs
        Private mOriginatingCondition As Condition
        Private mOldValue As Object
        Private mNewValue As Object

        Public Property NewValue() As Object
            Get
                Return mNewValue
            End Get
            Set(ByVal value As Object)
                mNewValue = value
            End Set
        End Property

        Public Property OldValue() As Object
            Get
                Return mOldValue
            End Get
            Set(ByVal value As Object)
                mOldValue = value
            End Set
        End Property

        Public Property OriginatingCondition() As Condition
            Get
                Return mOriginatingCondition
            End Get
            Set(ByVal value As Condition)
                mOriginatingCondition = value
            End Set
        End Property

        Public Sub New(ByVal condition As Condition, ByVal oldValue As Object, ByVal newValue As Object)
            mOriginatingCondition = condition
            mOldValue = oldValue
            mNewValue = newValue
        End Sub

    End Class

End Namespace
