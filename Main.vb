Module Main
    'will be left blank for awhile...
    Sub Main()
        'Init graphics
        Render.Init()

        'OK, graphics now?
        Render.Go()
    End Sub


#Region "Debug"
    'For debug...
    Sub doWrite(ByVal str As String)
        Debug.Print(str)
    End Sub
#End Region
End Module
