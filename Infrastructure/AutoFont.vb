Option Strict On

Imports Mbark.UI.GlobalUISettings

Imports System.Windows.Forms

Namespace Mbark.UI


    Public NotInheritable Class AutoFont

#Region " AutoFont "

        Public Shared Sub Label(ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Font = Defaults.Fonts.Small
        End Sub

        Public Shared Sub BoldLabel(ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Font = Defaults.Fonts.SmallBold
        End Sub

        Public Shared Sub TextBox(ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Font = Defaults.Fonts.TextBox
        End Sub

        Public Shared Sub FancyLabel(ByVal target As Control)
            If target Is Nothing Then Throw New ArgumentNullException("target")
            target.Font = Defaults.Fonts.Bold
        End Sub

        Private Sub New()

        End Sub

#End Region

    End Class

End Namespace