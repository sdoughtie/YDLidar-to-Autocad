Imports System.Math

Module Module1

    Sub Main()

        Dim polarAngle As Decimal
        Dim polarRadius As Decimal
        Dim cartesianX As Decimal
        Dim cartesianY As Decimal

        Dim commandlineFileName As String = Environment.CommandLine

        Using MyReader As New Microsoft.VisualBasic.
                      FileIO.TextFieldParser(commandlineFileName.Remove(0, 12))
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",", ":")
            'Dim currentRow As String()
            Dim currentField(3) As String
            While Not MyReader.EndOfData
                Try
                    currentField = MyReader.ReadFields()

                    polarAngle = Val(currentField(1))
                    polarRadius = Val(currentField(3))

                    cartesianX = polarRadius * Math.Cos(polarAngle * (Math.PI / 180))
                    cartesianY = polarRadius * Math.Sin(polarAngle * (Math.PI / 180))

                    If polarRadius > 0 Then
                        Console.WriteLine("point " & (cartesianX) & "," & (cartesianY) & ",0.000")
                    End If

                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    Console.WriteLine("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try

            End While
        End Using

    End Sub

End Module
