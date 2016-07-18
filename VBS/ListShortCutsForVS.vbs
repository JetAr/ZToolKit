Imports System
Imports System.IO
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics

Public Module Module2

    Public Sub ListShortcutsInHTML()

        'Declare a StreamWriter
        Dim sw As System.IO.StreamWriter
        sw = New StreamWriter("c:\\demo\\Shortcuts.html")

        'Write the beginning HTML
        WriteHTMLStart(sw)

        ' Add a row for each keyboard shortcut
        For Each c As Command In DTE.Commands
            If c.Name <> "" Then
                Dim bindings As System.Array
                bindings = CType(c.Bindings, System.Array)
                For i As Integer = 0 To bindings.Length - 1
                    sw.WriteLine("<tr>")
                    sw.WriteLine("<td>" + c.Name + "</td>")
                    sw.WriteLine("<td>" + bindings(i) + "</td>")
                    sw.WriteLine("</tr>")
                Next

            End If
        Next

        'Write the end HTML
        WriteHTMLEnd(sw)

        'Flush and close the stream
        sw.Flush()
        sw.Close()
    End Sub
    Public Sub WriteHTMLStart(ByVal sw As System.IO.StreamWriter)
        sw.WriteLine("<html>")
        sw.WriteLine("<head>")
        sw.WriteLine("<title>")

        sw.WriteLine("Visual Studio Keyboard Shortcuts")
        sw.WriteLine("</title>")
        sw.WriteLine("</head>")

        sw.WriteLine("<body>")
        sw.WriteLine("<h1>Visual Studio 2005 Keyboard Shortcuts</h1>")
        sw.WriteLine("<font size=""2"" face=""Tahoma"">")
        sw.WriteLine("<table border=""1"">")
        sw.WriteLine("<tr BGCOLOR=""#018FFF""><td align=""center""><b>Command</b></td><td align=""center""><b>Shortcut</b></td></tr>")


    End Sub

    Public Sub WriteHTMLEnd(ByVal sw As System.IO.StreamWriter)
        sw.WriteLine("</table>")
        sw.WriteLine("</font>")
        sw.WriteLine("</body>")
        sw.WriteLine("</html>")
    End Sub

End Module
