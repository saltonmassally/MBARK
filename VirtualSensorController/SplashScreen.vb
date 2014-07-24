Public NotInheritable Class SplashScreen

    Private WithEvents mTimer As New Windows.Forms.Timer


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mTimer.Interval = 5000
        mTimer.Start()
    End Sub

    Private Sub mTimer_Elapsed(ByVal sender As Object, ByVal e As EventArgs) Handles mTimer.Tick
        Me.Close()
    End Sub





End Class
