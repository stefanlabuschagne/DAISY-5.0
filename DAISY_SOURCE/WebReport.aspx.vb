Imports System.Data.SqlClient

Public Class WebForm7


    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If False Then '' IsPostBack() Then

            '' We Pressed one of the buttons on the Report

            Dim a = 10

            a = a + 100


        Else
            '' GET THE VALUES FROM THE PREVIOUS PAGE AND DO A QUERY AND SHOW THE RESULTS !!! ''

            '''''''''''''''''''''''''''''''''''''''
            ' Query The callers on the datasource '
            '''''''''''''''''''''''''''''''''''''''
            Dim DaQuery As String = ""
            Dim DaWhere As String = ""

            '' This connectionstring is also on the datasource!!
            DaQuery = "SELECT dbo.Callers.*, dbo.Calls.* FROM dbo.Callers INNER JOIN dbo.Calls ON dbo.Callers.CALLERID = dbo.Calls.CALLERID"
            DaWhere = ""


            '' Check for stuff and add it on for the query.
            If Request("ctl00$MainContent$Firstname").ToString().Length > 0 Then
                DaWhere = DaWhere & " And Name = '" & Request("ctl00$MainContent$Firstname").ToString() & "'"
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
                DaWhere = DaWhere & " and City = '" & Request("ctl00$MainContent$City").ToString() & "'"
            End If

            If Request("ctl00$MainContent$Telephone").ToString().Length > 0 Then
                DaWhere = DaWhere & " and Telephone1 like '%" & Request("ctl00$MainContent$Telephone").ToString() & "%'"
            End If


            '' Reasons
            Select Case Request("ctl00$MainContent$ReasonForCall").ToString()

                Case "ReasonADHD"

                    DaWhere = DaWhere & " and ReasonADHD  = 'True' "

                Case "ReasonAlzheimersDementia"

                    DaWhere = DaWhere & " and ReasonAlzheimersDementia = 'True' "

                Case "ReasonAnxiety"

                    DaWhere = DaWhere & " and ReasonAnxiety = 'True' "

                Case "ReasonBipolar"

                    DaWhere = DaWhere & " and ReasonBipolar = 'True' "

                Case "ReasonBorderlinePersonalityDisorder"

                    DaWhere = DaWhere & " and ReasonBorderlinePersonalityDisorder = 'True' "

                Case "ReasonBullying"

                    DaWhere = DaWhere & " and ReasonBullying = 'True' "

                Case "ReasonDebtPovertyUnemployment"

                    DaWhere = DaWhere & " and ReasonDebtPovertyUnemployment = 'True' "

                Case "ReasonDepression"

                    DaWhere = DaWhere & " and ReasonDepression = 'True' "

                Case "ReasonEatingDisorder"

                    DaWhere = DaWhere & " and ReasonEatingDisorder  = 'True' "

                Case "ReasonHIVAIDS"

                    DaWhere = DaWhere & " and ReasonHIVAIDS = 'True' "

                Case "ReasonInformation"

                    DaWhere = DaWhere & " and ReasonInformation = 'True' "

                Case "ReasonLossGriefLoneliness"

                    DaWhere = DaWhere & " and ReasonLossGriefLoneliness = 'True' "

                Case "ReasonNone"

                    DaWhere = DaWhere & " and ReasonNone  = 'True' "

                Case "ReasonOCD"

                    DaWhere = DaWhere & " and ReasonOCD = 'True' "

                Case "ReasonOtherIllness"

                    DaWhere = DaWhere & " and ReasonOtherIllness = 'True' "

                Case "ReasonPhysicalEmotionalAbuse"

                    DaWhere = DaWhere & " and ReasonPhysicalEmotionalAbuse = 'True' "

                Case "ReasonRelationshipRomanticIssues"

                    DaWhere = DaWhere & " and ReasonRelationshipRomanticIssues = 'True' "

                Case "ReasonRelationshipFamilyIssues"

                    DaWhere = DaWhere & " and ReasonRelationshipFamilyIssues = 'True' "

                Case "ReasonPostNatalDepression"

                    DaWhere = DaWhere & " and ReasonPostNatalDepression = 'True' "

                Case "ReasonPregnancy"

                    DaWhere = DaWhere & " and ReasonPregnancy = 'True' "

                Case "ReasonPTSDTrauma"

                    DaWhere = DaWhere & " and ReasonPTSDTrauma = 'True' "

                Case "ReasonRelationshipDomesticAbuse"

                    '' YES, THE FIELD IN THE DATABASE IS SPELT INCORRECTLY - JUST DEAL WITH IT!
                    DaWhere = DaWhere & " and ReasonReationshipDomesticAbuse = 'True' "

                Case "ReasonSchizophrenia"

                    DaWhere = DaWhere & " and ReasonSchizophrenia  = 'True' "

                Case "ReasonSelfMutilation"

                    DaWhere = DaWhere & " and ReasonSelfMutilation = 'True' "

                Case "ReasonSexualAbuseRape"

                    DaWhere = DaWhere & " and ReasonSexualAbuseRape = 'True' "

                Case "ReasonSexuality"

                    DaWhere = DaWhere & " and ReasonSexuality = 'True' "

                Case "ReasonSleepingDisorder"

                    DaWhere = DaWhere & " and ReasonSleepingDisorder = 'True' "

                Case "ReasonSocialPhobia"

                    DaWhere = DaWhere & " and ReasonSocialPhobia = 'True' "

                Case "ReasonStress"

                    DaWhere = DaWhere & " and ReasonStress  = 'True' "

                Case "ReasonSubstanceAbuse"

                    DaWhere = DaWhere & " and ReasonSubstanceAbuse = 'True' "

                Case "ReasonSuicide"  '' Bug Fixed SL 2018-08-24 - Removed Trailing Space!!

                    DaWhere = DaWhere & " and ReasonSuicide = 'True' "

                Case "ReasonFrequentCaller"

                    DaWhere = DaWhere & " and ReasonFrequentCaller = 'True' "

            End Select

            '' Query on Counsellors
            If Request("ctl00$MainContent$Counsellor").ToString().Length > 0 Then
                DaWhere = DaWhere & " and Counsellor = '" & Request("ctl00$MainContent$Counsellor").ToString() & "'"
            End If

            '' Query on StartDate
            If Request("ctl00$MainContent$StartDate").ToString().Length > 0 Then
                DaWhere = DaWhere & " and Calldate >= '" & Request("ctl00$MainContent$StartDate").ToString() & "'"
            End If

            '' Query on EndDate
            If Request("ctl00$MainContent$EndDate").ToString().Length > 0 Then
                DaWhere = DaWhere & " and Calldate <= '" & Request("ctl00$MainContent$EndDate").ToString() & "'"
            End If

            '' SL 2015-05-10 Query on the Occupation
            If Request("ctl00$MainContent$DropDownListOccupation").ToString().Length > 0 Then
                DaWhere = DaWhere & " and Occupation = '" & Request("ctl00$MainContent$DropDownListOccupation").ToString() & "'"
            End If

            '' SL 2015-05-10 Query on the Call Summary
            If Request("ctl00$MainContent$CallSummarySearch").ToString().Length > 0 Then
                DaWhere = DaWhere & " and CallSummary like '%" & Request("ctl00$MainContent$CallSummarySearch").ToString() & "%'"
            End If

            '' SL 2017-10-11 Query on the Helpline Selected 
            If Request("ctl00$MainContent$Helpline").ToString().Length > 0 Then
                DaWhere = DaWhere & " and HelpLine = '" & Request("ctl00$MainContent$HelpLine").ToString() & "'"
            End If

            If DaWhere.Length > 0 Then
                DaQuery = DaQuery & " Where " & DaWhere.Substring(5)


                ''Response.Write(DaQuery)
                ''Response.Flush()


                Dim connection As New SqlConnection(SqlDataSource1.ConnectionString)

                Using SqlDataSource1

                    Dim command As SqlCommand = New SqlCommand(DaQuery, connection)
                    connection.Open()

                    Dim reader As SqlDataReader = command.ExecuteReader()

                    If reader.HasRows Then

                        Dim daRowCount As Integer = 0

                        Do While reader.Read()

                            Dim TRow0 = New TableRow()

                            TRow0.Cells.Add(New TableCell)
                            TRow0.Cells(0).Text = "<hr>"
                            TRow0.Cells(0).ColumnSpan = 12

                            Table1.Rows.Add(TRow0)

                            Dim TRow = New TableRow()

                            TRow.Cells.Add(New TableCell)
                            TRow.Cells(0).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Calldate")).ToString().Substring(0, 10)

                            '' TRow.Cells(0).Text = "<nobr><a href='createcase.aspx?Action=EDIT&Callid=" & reader.GetValue(reader.GetOrdinal("CALLID")).ToString() & "' >" & reader.GetValue(reader.GetOrdinal("Calldate")).ToString() & "</a>"
                            '' https://forums.asp.net/t/1465385.aspx?Creating+a+dynamically+generated+table+with+controls

                            '' TRY A hYPERLINK INSTEAD
                            '' ONLY DEDICATED LINES HAS A DLLocation FIELD POPULATED WITH A VALUE

                            Dim hl As New HyperLink
                            hl.Text = reader.GetValue(reader.GetOrdinal("Calldate")).ToString().Substring(0, 10)
                            hl.ToolTip = "Click to edit call details"

                            If reader.GetValue(reader.GetOrdinal("DLLocation")).ToString() = "" Then
                                hl.NavigateUrl = "Createcase.aspx?ACTION=EDIT&CALLID=" + reader.GetValue(reader.GetOrdinal("CALLID")).ToString() & "&CALLERID=" + reader.GetValue(reader.GetOrdinal("CALLERID")).ToString()
                            Else
                                hl.NavigateUrl = "CreatecaseDedicatedLines.aspx?ACTION=EDIT&CALLID=" + reader.GetValue(reader.GetOrdinal("CALLID")).ToString() & "&CALLERID=" + reader.GetValue(reader.GetOrdinal("CALLERID")).ToString()
                            End If

                            TRow.Cells(0).Controls.Add(hl)

                            TRow.Cells.Add(New TableCell)
                            TRow.Cells(1).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Surname")).ToString() & ", " & reader.GetValue(reader.GetOrdinal("Name")).ToString()

                            TRow.Cells.Add(New TableCell)
                            TRow.Cells(2).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Sex")).ToString()

                            TRow.Cells.Add(New TableCell)
                            TRow.Cells(3).Text = "<nobr>" & reader.GetValue(reader.GetOrdinal("Race")).ToString()

                            TRow.Cells.Add(New TableCell)
                            TRow.Cells(4).Text = "" & reader.GetValue(reader.GetOrdinal("City")).ToString()

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

                            '' SL 24 March 2012
                            '' Check whether the short report format was checked
                            If Request("ctl00$MainContent$ChkShortReport") = Nothing Then


                                Dim TRow10 = New TableRow()

                                TRow10.Cells.Add(New TableCell)
                                TRow10.Cells(0).Text = "<hr>"
                                TRow10.Cells(0).ColumnSpan = 12

                                Table1.Rows.Add(TRow10)

                                Dim TRow2 = New TableRow()

                                TRow2.Cells.Add(New TableCell)
                                TRow2.Cells(0).Text = "<b>Call Reasons: </b> "


                                '' Make a List of Call Reasons!!
                                '' They want to see them ALL LISTED
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
                                        Reasons = Reasons & ", Anxiety / Panic"
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
                                    If reader.GetValue(reader.GetOrdinal("ReasonBorderlinePersonalityDisorder")) = True Then
                                        Reasons = Reasons & ", Borderline Personality Disorder"
                                    End If
                                Catch ex As Exception

                                End Try

                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonBullying")) = True Then
                                        Reasons = Reasons & ", Bullying"
                                    End If
                                Catch ex As Exception

                                End Try


                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonDebtPovertyUnemployment")) = True Then
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

                                '' #1
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonHIVAIDS")) = True Then
                                        Reasons = Reasons & ", HIV AIDS"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #2
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonInformation")) = True Then
                                        Reasons = Reasons & ", Information"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #3
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonLossGriefLoneliness")) = True Then
                                        Reasons = Reasons & ", Loss Grief Loneliness"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #4
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonNone")) = True Then
                                        Reasons = Reasons & ", None"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #5
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonOCD")) = True Then
                                        Reasons = Reasons & ", OCD"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #6
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonOtherIllness")) = True Then
                                        Reasons = Reasons & ", Other Illness"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #6.5
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonFrequentCaller")) = True Then
                                        Reasons = Reasons & ", Frequent Caller"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #7
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonPhysicalEmotionalAbuse")) = True Then
                                        Reasons = Reasons & ", Physical Emitional Abuse"
                                    End If
                                Catch ex As Exception

                                End Try






                                '' #8
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonPostNatalDepression")) = True Then
                                        Reasons = Reasons & ", Post Natal Depression"
                                    End If
                                Catch ex As Exception

                                End Try

                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonPregnancy")) = True Then
                                        Reasons = Reasons & ", Pregnancy"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #9
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonPTSDTrauma")) = True Then
                                        Reasons = Reasons & ", PTSD Trauma"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #10
                                Try
                                    '' YES THE DATABASE FIELD IS SPELT WRONG, BUT IT CANT BE CHAGED RIGHT NOW. JUST LIVE WITH THIS!!
                                    If reader.GetValue(reader.GetOrdinal("ReasonReationshipDomesticAbuse")) = True Then
                                        Reasons = Reasons & ", Relationship Domestic Abuse"
                                    End If
                                Catch ex As Exception

                                End Try


                                '' #10.1
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonRelationshipRomanticIssues")) = True Then
                                        Reasons = Reasons & ", Relationship - Romantic Issues"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #10.2
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonRelationshipFamilyIssues")) = True Then
                                        Reasons = Reasons & ", Relationship - Family Issues"
                                    End If
                                Catch ex As Exception

                                End Try




                                '' #11
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonSchizophrenia")) = True Then
                                        Reasons = Reasons & ", Schizophrenia"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #12
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonSelfMutilation")) = True Then
                                        Reasons = Reasons & ", Self Mutilation"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #13
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonSexualAbuseRape")) = True Then
                                        Reasons = Reasons & ", Sexual Abuse / Rape"
                                    End If
                                Catch ex As Exception

                                End Try


                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonSexuality")) = True Then
                                        Reasons = Reasons & ", Sexuality"
                                    End If
                                Catch ex As Exception

                                End Try


                                '' #14
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonSleepingDisorder")) = True Then
                                        Reasons = Reasons & ", Sleeping Disorder"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #15
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonSocialPhobia")) = True Then
                                        Reasons = Reasons & ", Social Phobia"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #16
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonStress")) = True Then
                                        Reasons = Reasons & ", Stress"
                                    End If
                                Catch ex As Exception

                                End Try

                                '' #17
                                Try
                                    If reader.GetValue(reader.GetOrdinal("ReasonSubstanceAbuse")) = True Then
                                        Reasons = Reasons & ", Substance Abuse"
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

                            End If '' Check for shortened format!

                            daRowCount = daRowCount + 1

                            Response.Flush()

                        Loop


                        ''
                        ' Show some Totals :) '
                        ''''''''''''

                        Label1.Text = "Total number of calls returned: <b>" + daRowCount.ToString() + "<b>"

                        Response.Flush()


                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        '' Now see if we need to Export to an CSV file as well ''
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If Request("ctl00$MainContent$ChckExportToCSV") = Nothing Then

                            Response.Clear()
                            'Response.AddHeader("")
                            'Response.AddHeader("")
                            Response.Flush()

                        End If






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

        End If





    End Sub




End Class