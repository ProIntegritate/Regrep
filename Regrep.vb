Module Module1

    Sub Main()

        Dim sString() As String = Environment.GetCommandLineArgs()

        If UBound(sString) < 2 Then
            Console.WriteLine("REGREP - Written in 2019 by Glenn Larsson, Freeware.")
            Console.WriteLine("Requires at least 2 paramters: <Infile> '<regexp>' (-'<regexp>' '<regexp>' -'<regexp>' '<regexp>' ...)".Replace("'", Chr(34)))
            Console.WriteLine(vbCrLf & "Examples:")
            Console.WriteLine("Find A but not B then filter result with C, but remove D (etc):")
            Console.WriteLine("    regrep <Infile> 'A' -'B' 'C' -'D'".Replace("'", Chr(34)))
            Console.WriteLine(vbCrLf & "Example: Find Swedish Phonenumbers from a mass of text:")
            Console.WriteLine("    regrep <Infile> '[0-9 ]{2,5}[-]{1}[0-9 ]{5,9}'".Replace("'", Chr(34)))
            Exit Sub
        End If

        Dim sStuff As String = ""

        Dim sFilename As String = sString(1)
        Dim sPattern As String = sString(2)

        Try
            Dim i As Integer = FreeFile() : FileOpen(i, sFilename, OpenMode.Input)
            While Not EOF(i)
                sStuff = LineInput(i).Replace(vbCr, "").Replace(vbLf, "") ' no crlf

                For n = 2 To UBound(sString)
                    If InStr(1, sString(n), "-") <> 1 Then
                        If Text.RegularExpressions.Regex.IsMatch(sStuff, sString(n)) = False Then
                            sStuff = ""
                            Exit For
                        End If
                    End If
                Next

                For n = 2 To UBound(sString)
                    'MsgBox(InStr(1, sString(n), "-"))
                    If InStr(1, sString(n), "-") = 1 Then
                        If Text.RegularExpressions.Regex.IsMatch(sStuff, Microsoft.VisualBasic.Right(sString(n), Len(sString(n)) - 1)) = True Then
                            sStuff = ""
                            Exit For
                        End If
                    End If
                Next

                If sStuff <> "" Then Console.WriteLine(sStuff)

            End While
            FileClose(i)

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            For n = 0 To UBound(sString)
                Console.WriteLine("Argument (" & n.ToString & ") = " & sString(n))
            Next
        End Try

    End Sub

End Module
