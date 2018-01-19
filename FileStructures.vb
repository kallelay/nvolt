Imports System.IO
' ///////////////////////////////////
' //        File structure         //
' ///////////////////////////////////
' // Last modification August'8th
' // By theKDL


Module FileStructures
    Class PRM
        Public Structure MODEL_VERTEX_LOAD
            Dim x, y, z As Single
            Dim nx, ny, nz As Single
        End Structure
        Public Structure MODEL_POLY_LOAD
            Dim type, Tpage As Int16
            Dim vi0, vi1, vi2, vi3 As Int16
            Dim c0, c1, c2, c3 As Long
            Dim u0, v0, u1, v1, u2, v2, u3, v3 As Single
        End Structure

        Public Structure MODEL_VERTEX_MORPH
            Dim x, y, z As Single
            Dim nx, ny, nz As Single
        End Structure
        Public Class MODEL
            Public polynum, vertnum As Short
            Public polyl() As MODEL_POLY_LOAD
            Public vexl() As MODEL_VERTEX_LOAD
        End Class

        Dim MyModel As New MODEL
        Sub New(ByVal filepath As String)
            Dim old&
            Dim J As New BinaryReader(New FileStream(filepath, FileMode.Open))


            'Vert/Poly count
            MyModel.polynum = J.ReadInt16()
            MyModel.vertnum = J.ReadInt16()

            Console.Clear()
            DoWrite("Poly count:" & Chr(9) & MyModel.polynum)
            DoWrite("Vert count:" & Chr(9) & MyModel.vertnum)

            ReDim MyModel.polyl(MyModel.polynum)
            For i = 1 To MyModel.polynum

                If old <> Int(100 * i / (MyModel.polynum)) Then
                    'Console.Clear()
                    DoWrite("Poly count:" & Chr(9) & MyModel.polynum)
                    DoWrite("Vert count:" & Chr(9) & MyModel.vertnum)
                    DoWrite("-------------------------------------")
                    'Try
                    'DoWrite("Reading Percentage: " & Int(100 * i / (MyModel.polynum + MyModel.vertnum)) & "%")

                    ' Catch
                    DoWrite("Reading Percentage: [POLYS] " & Int(100 * i / (MyModel.polynum)) & "%")
                End If

                old = Int(100 * i / (MyModel.polynum))
                'End Try
                '

                MyModel.polyl(i).type = J.ReadInt16
                MyModel.polyl(i).Tpage = J.ReadInt16
     
                MyModel.polyl(i).vi0 = J.ReadInt16
                MyModel.polyl(i).vi1 = J.ReadInt16
                MyModel.polyl(i).vi2 = J.ReadInt16
                MyModel.polyl(i).vi3 = J.ReadInt16



                MyModel.polyl(i).c0 = J.ReadInt32
                MyModel.polyl(i).c1 = J.ReadInt32
                MyModel.polyl(i).c2 = J.ReadInt32
                MyModel.polyl(i).c3 = J.ReadInt32

                MyModel.polyl(i).u0 = J.ReadSingle
                MyModel.polyl(i).v0 = J.ReadSingle
                MyModel.polyl(i).u1 = J.ReadSingle
                MyModel.polyl(i).v1 = J.ReadSingle
                MyModel.polyl(i).u2 = J.ReadSingle
                MyModel.polyl(i).v2 = J.ReadSingle
                MyModel.polyl(i).u3 = J.ReadSingle
                MyModel.polyl(i).v3 = J.ReadSingle
            Next

            ReDim MyModel.vexl(MyModel.vertnum)

            For a = 0 To MyModel.vertnum - 1
                If old <> Int(a * 100 / (MyModel.vertnum)) Then
                    ' Console.Clear()
                    ' DoWrite("Poly count:" & Chr(9) & MyModel.polynum)
                    ' DoWrite("Vert count:" & Chr(9) & MyModel.vertnum)
                    'DoWrite("-------------------------------------")
                    DoWrite("Reading Percentage: [POLYS] 100%")
                    DoWrite("Reading Percentage: [VERTICES] " & Int(a * 100 / (MyModel.vertnum)) & "%")
                End If

                old = Int(a * 100 / (MyModel.vertnum))

                MyModel.vexl(a).x = J.ReadSingle
                MyModel.vexl(a).y = -J.ReadSingle
                MyModel.vexl(a).z = J.ReadSingle

                MyModel.vexl(a).nx = J.ReadSingle
                MyModel.vexl(a).ny = -J.ReadSingle
                MyModel.vexl(a).nz = J.ReadSingle
            Next


        End Sub

    End Class
End Module
