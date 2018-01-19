Imports IrrlichtNETCP
Module Render
    Public Device As IrrlichtDevice
    Public VideoDriver As VideoDriver
    Dim ScnMgr As SceneManager

    Dim Width = 800, Height = 600
    Dim DvType As DriverType = DriverType.Direct3D9
    Dim bits = 32
    Dim FullScreen As Boolean = False
    Dim Vsync As Boolean = True
    Dim Stencil As Boolean = True
    Dim AntiAlias As Boolean = True
    Sub Init()
        'ok, what about init?
        Device = New IrrlichtDevice(DvType, New Dimension2D(Width, Height), bits, FullScreen, Stencil, Vsync, antiAlias)
        VideoDriver = Device.VideoDriver
        ScnMgr = Device.SceneManager
        Device.WindowCaption = "nVolt"

    End Sub

    Sub Go()
        'For Start rendering, should be the last thing
        Do Until Device.Run = False
            Device.WindowCaption = "nVolt ~ fps:" & VideoDriver.FPS
            VideoDriver.BeginScene(True, True, New Color(159, 35, 138, 255)) 'clear buffer
            ScnMgr.DrawAll()
            VideoDriver.EndScene()
        Loop

        Device.Dispose()
    End Sub

    Sub RenderOnePlane()

    End Sub

End Module
