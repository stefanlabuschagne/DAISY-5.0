Imports System.Data.SqlClient

Public Class WebForm7


    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '' GET THE VALUES FROM THE PREVIOUS PAGE AND DO A QUERY AND SHOW THE RESULTS !!! ''

        '''''''''''''''''''''''''''''''''''''''
        ' Query The callers on the datasource '
        '''''''''''''''''''''''''''''''''''''''
        Dim DaQuery As String
        Dim DaWhere As String

        '' This connectionstring is also on the datasource!!
        DaQuery = "SELECT dbo.Callers.*, dbo.Calls.* FROM dbo.Callers INNER JOIN dbo.Calls ON dbo.Callers.CALLERID = dbo.Calls.CALLERID"
        DaWhere = ""

        '' Check for stuff and add it on for the query.
        If Request("ctl00$MainContent$Firstname").ToString().Length > 0 Then
            DaWhere = DaWhere & " and Name = '" & Request("ctl00$MainContent$Firstname").ToString() & "'"
        End If

        If Request("ctl00$MainContent$Surname").ToString().Length > 0 Then
            DaWhere = DaWhere & " and Surname = '" & Request("ctl00$MainContent$Surname").ToString() & "'"
        End If

        If Request("ctl00$MainContent$Race").ToString().Length > 0 Then
            DaWhere = DaWhere & " and Race = '" & Request("ctl00$MainContent$Race").ToString() & "'"
        End If

        If Request("ctl00$MainContent$Gender").ToString().Length > 0 Then
            DaWhere = DaWhere & " and Sex = '" & Request("ctl00$MainContent$Gender").ToString() & "'"
        End If

        If Request("ctl00$MainContent$ddlProvince").ToString().Length > 0 Then
            DaWhere = DaWhere & " and Province = '" & Request("ctl00$MainContent$ddlProvince").ToString() & "'"
        End If

        If Request("ctl00$MainContent$AgeGroup").ToString().Length > 0 Then
            DaWhere = DaWhere & " and Age = '" & Request("ctl00$MainContent$AgeGroup").ToString() & "'"
        End If

        If Request("ctl00$MainContent$City").ToString().Length > 0 Then
            DaWhere = DaWhere & " and Age = '" & Request("ctl00$MainContent$City").ToString() & "'"
        End If


        '' Reasons
        Select Case Request("ctl00$MainContent$ReasonForCall").ToString()

            Case "ReasonDepression"

                DaWhere = DaWhere & " and ReasonDepression = 'True' "

            Case "ReasonBipolar"

                DaWhere = DaWhere & " and ReasonBipolar = 'True' "

            Case "ReasonLoss"

                DaWhere = DaWhere & " and ReasonLossGriefLoneliness = 'True' "

        End Select


        If DaWhere.Length > 0 Then
            DaQuery = DaQuery & " Where " & DaWhere.Substring(5)


            Dim connection As New SqlConnection(SqlDataSource1.ConnectionString)

            Using SqlDataSource1

                Dim command As SqlCommand = New SqlCommand(DaQuery, connection)
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader()

                If reader.HasRows Then
                    Do While reader.Read()

                        Dim TRow0 = New TableRow()

                        TRow0.Cells.Add(New TableCell)
                        TRow0.Cells(0).Text = "<hr>"
                        TRow0.Cells(0).ColumnSpan = 12

                        Table1.Rows.Add(TRow0)


                        Dim TRow = New TableRow()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(0).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Calldate")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(1).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Surname")).ToString() & ", " & reader.GetValue(reader.GetOrdinal("Name")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(2).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Sex")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(3).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Race")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(4).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("City")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(5).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Province")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(6).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Age")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(7).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Medication")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(8).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Telephone1")).ToString()

                        TRow.Cells.Add(New TableCell)
                        TRow.Cells(9).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Telephone2")).ToString()

                        Table1.Rows.Add(TRow)


                        Dim TRow10 = New TableRow()

                        TRow10.Cells.Add(New TableCell)
                        TRow10.Cells(0).Text = "<hr>"
                        TRow10.Cells(0).ColumnSpan = 12

                        Table1.Rows.Add(TRow10)

                        Dim TRow2 = New TableRow()

                        TRow2.Cells.Add(New TableCell)
                        TRow2.Cells(0).Text = "<b>Call Reasons: </b> "

                        '' Make a List of Call Reasons!!
                        Dim Reasons As String = ""

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonADHD")) = True Then
                                Reasons = Reasons & ", ADHD"
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonAlzheimersDementia")) = True Then
                                Reasons = Reasons & ", Alzheimers / Dementia"
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonAnxiety")) = True Then
                                Reasons = Reasons & ", Anxiety"
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonBipolar")) = True Then
                                Reasons = Reasons & ", Bipolar"
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonDebtPovertyUnempolyment")) = True Then
                                Reasons = Reasons & ", Debt / Poverty / Unempolyment"
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonDepression")) = True Then
                                Reasons = Reasons & ", Depression"
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonEatingDisorder")) = True Then
                                Reasons = Reasons & ", Eating Disorder"
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If reader.GetValue(reader.GetOrdinal("ReasonSuicide")) = True Then
                                Reasons = Reasons & ", Suicide"
                            End If
                        Catch ex As Exception

                        End Try

                        If Reasons.Length > 0 Then
                            TRow2.Cells(0).Text = TRow2.Cells(0).Text & Reasons.ToString().Substring(2)
                        End If

                        TRow2.Cells(0).ColumnSpan = 12

                        Table1.Rows.Add(TRow2)

                        Dim TRow3 = New TableRow()

                        TRow3.Cells.Add(New TableCell)
                        TRow3.Cells(0).Text = "<b>Call Information:</b> " & reader.GetValue(reader.GetOrdinal("CallSummary")).ToString()
                        TRow3.Cells(0).ColumnSpan = 12

                        Table1.Rows.Add(TRow3)


                    Loop
                Else
                    Dim TRow0 = New TableRow()

                    TRow0.Cells.Add(New TableCell)
                    TRow0.Cells(0).Text = "No records returned"
                    TRow0.Cells(0).ColumnSpan = 12

                    Table1.Rows.Add(TRow0)
                End If

                reader.Close()

            End Using

        Else

            '' NO CRITERIA WAS SPECIFIED SO - THE WHOLE DATABASE WILL BE RETURNED!!!

            Dim TRow0 = New TableRow()

            TRow0.Cells.Add(New TableCell)
            TRow0.Cells(0).Text = "No calls available for criteria."
            TRow0.Cells(0).ColumnSpan = 12

            Table1.Rows.Add(TRow0)

        End If


    End Sub

End Class