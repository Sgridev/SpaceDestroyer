Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "(*.vb)| *.vb"
        OpenFileDialog1.ShowDialog()
        Button2.Visible = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        mysub(OpenFileDialog1.FileName)
    End Sub

    Sub mysub(FileName As String)

        Dim lines() As String
        Dim outputlines As New List(Of String)
        Dim searchString As String = ""
        lines = IO.File.ReadAllLines(FileName)
        Dim last As String = ""
        For Each line As String In lines
            If line.Trim <> "" Then
                outputlines.Add(line)

            ElseIf last.Trim <> "" Then
                outputlines.Add(line)
            End If

            last = line.Trim
        Next

        System.IO.File.Delete(FileName)
        IO.File.WriteAllLines(FileName, outputlines)
        Me.Close()
    End Sub
End Class
