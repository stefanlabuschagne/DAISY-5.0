Public Class WebForm11

    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (Request.QueryString("Action") Is Nothing) Then

            '' See if we get a value back for the edit screen
            If Request.QueryString("Action").ToString().Length > 0 Then

                '' Response.Write(Request("Action").ToString() & "<Br>")

                '' Response.Write(Request.Querystring("Callerid").ToString() & "<Br>")

                '' Response.Write(Request("Callid").ToString() & "<Br>")

                '' LOAD THE DATA FROM THE DATABASES INTO THE SCREEN

                If (Request.QueryString("Action").ToString().ToUpper() = "EDIT") AndAlso (CallID.Text.Length = 0) Then


                    Dim DaConnection As New System.Data.SqlClient.SqlConnection

                    '' Get the string of the DAISYConnectionString1 '' 
                    DaConnection.ConnectionString = ConfigurationManager.ConnectionStrings("DAISYConnectionString1").ConnectionString.ToString()

                    Using DaConnection

                        Dim DaCommand As New System.Data.SqlClient.SqlCommand("Select * from Callers where callerid=" & Request.QueryString("Callerid").ToString(), DaConnection)
                        DaConnection.Open()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' GET and POPULATE THE CALLER DATA FROM THE DATABASE '
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DaReader As System.Data.SqlClient.SqlDataReader = DaCommand.ExecuteReader()
                        If DaReader.HasRows Then

                            DaReader.Read()

                            CallerID.Text = DaReader("CAllerid").ToString.Trim
                            Firstname.Text = DaReader("Name").ToString.Trim
                            Surname.Text = DaReader("Surname").ToString.Trim
                            AgeGroup.Text = DaReader("Age").ToString.Trim
                            Gender.Text = DaReader("Sex").ToString.Trim
                            Race.Text = DaReader("Race").ToString.Trim
                            Occupation.Text = DaReader("Occupation").ToString.Trim
                            MedicalAid.Text = DaReader("MedicalAid").ToString.Trim
                            Medication.Text = DaReader("Medication").ToString.Trim

                            Address.Text = DaReader("Address").ToString.Trim
                            Suburb.Text = ConvertDBNULLToString(DaReader("Suburb")).ToString.Trim
                            City.Text = DaReader("City").ToString.Trim
                            ddlProvince.Text = DaReader("Province").ToString.Trim

                            PostalCode.Text = DaReader("PostalCode").ToString.Trim
                            Telephone1.Text = DaReader("Telephone1").ToString.Trim
                            Telephone2.Text = DaReader("Telephone2").ToString.Trim

                            EMailAddress.Text = DaReader("EMailAddress").ToString.Trim

                            '' Added for dedicated Lines 15 December 2017
                            DLLocation.Text = DaReader("DLLocation").ToString.Trim
                            DLSource.Text = DaReader("DLSource").ToString.Trim
                            DLStudentNumber.Text = DaReader("DLStudentNumber").ToString.Trim
                            DLType.Text = DaReader("DLType").ToString.Trim


                        End If

                        DaReader.Close()

                        ''''''''''''''''''''''''''''''''''
                        ' GET AND POPULATE THE CALL DATA '
                        ''''''''''''''''''''''''''''''''''
                        DaCommand = New System.Data.SqlClient.SqlCommand("Select * from [Calls] where [callerid]=" & Request.QueryString("Callerid").ToString() & " and [callid] = " & Request("Callid").ToString() & "", DaConnection)
                        '' DaConnection.Open()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' GET and POPULATE THE CALLER DATA FROM THE DATABASE '
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DaReader = DaCommand.ExecuteReader()
                        If DaReader.HasRows Then

                            DaReader.Read()

                            '' hidden field
                            CallID.Text = DaReader("Callid")

                            Counsellor.Text = DaReader("Counsellor").Trim
                            '' CallDate.Text = DaReader("CallDate")

                            Try '' The dates dont always gets converted!
                                CallCalendar1.SelectedDate = DaReader("CallDate").ToString().Substring(0, 10)

                                CallCalendar1.VisibleDate = DaReader("CallDate")   '' Show this month as the visible month!
                            Catch ex As Exception


                            End Try

                            Counsellor.Text = DaReader("Counsellor").Trim
                            HelpLine.Text = ConvertDBNULLToString(DaReader("HelpLine")).Trim
                            '' CallDate.Text = DaReader("CallDate")

                            '' BECAUSE WE CANT TRUST THE DATA 
                            Try
                                CallCalendar1.SelectedDate = DaReader("CallDate").ToString().Substring(0, 10)
                            Catch ex As Exception

                            End Try

                            ReasonADHD.Checked = ConvertDBNULL(DaReader("ReasonADHD"))
                            ReasonAlzheimersDementia.Checked = ConvertDBNULL(DaReader("ReasonAlzheimersDementia"))
                            ReasonAnxiety.Checked = ConvertDBNULL(DaReader("ReasonAnxiety"))
                            ReasonBipolar.Checked = ConvertDBNULL(DaReader("ReasonBipolar"))
                            ReasonBorderlinePersonalityDisorder.Checked = ConvertDBNULL(DaReader("ReasonBorderlinePersonalityDisorder"))
                            ReasonBullying.Checked = ConvertDBNULL(DaReader("ReasonBullying"))
                            ReasonDebtPovertyUnemployment.Checked = ConvertDBNULL(DaReader("ReasonDebtPovertyUnemployment"))
                            ReasonDepression.Checked = ConvertDBNULL(DaReader("ReasonDepression"))

                            ReasonEatingDisorder.Checked = ConvertDBNULL(DaReader("ReasonEatingDisoirder")) '' = '" & ReasonEatingDisorder.Checked & "' " &
                            ReasonHIVAIDS.Checked = ConvertDBNULL(DaReader("ReasonHIVAIDS")) '' = '" & ReasonHIVAIDS.Checked & "' " &
                            ReasonInformation.Checked = ConvertDBNULL(DaReader("ReasonInformation")) ''= '" & ReasonInformation.Checked & "' " &
                            ReasonLoss.Checked = ConvertDBNULL(DaReader("ReasonLossGriefLoneliness")) ''= '" & ReasonLoss.Checked & "' " &
                            ReasonNone.Checked = ConvertDBNULL(DaReader("ReasonNone")) ''= '" & ReasonNone.Checked & "' " &
                            ReasonOCD.Checked = ConvertDBNULL(DaReader("ReasonOCD")) ''= '" & ReasonOCD.Checked & "' " &
                            ReasonOther.Checked = ConvertDBNULL(DaReader("ReasonOtherIllness")) ''= '" & ReasonOther.Checked & "' " &
                            ReasonFrequentCaller.Checked = ConvertDBNULL(DaReader("ReasonFrequentCaller"))
                            ReasonAbusePhysicalEmotional.Checked = ConvertDBNULL(DaReader("ReasonPhysicalEmotionalAbuse")) ''= '" & ReasonAbusePhysicalEmotional.Checked & "' " &
                            ReasonPND.Checked = ConvertDBNULL(DaReader("ReasonPostNatalDepression")) ''= '" & ReasonPND.Checked & "' " &
                            ReasonPregnancy.Checked = ConvertDBNULL(DaReader("ReasonPregnancy"))
                            ReasonPSTDTrauma.Checked = ConvertDBNULL(DaReader("ReasonPTSDTrauma")) ''= '" & ReasonPSTDTrauma.Checked & "' " &
                            ReasonReationshipDomesticAbuse.Checked = ConvertDBNULL(DaReader("ReasonReationshipDomesticAbuse")) ''= '" & ReasonReationshipDomesticAbuse.Checked & "' " &
                            ReasonSchizophrenia.Checked = ConvertDBNULL(DaReader("ReasonSchizophrenia")) ''= '" & ReasonSchizophrenia.Checked & "' " &
                            ReasonSelfMutilation.Checked = ConvertDBNULL(DaReader("ReasonSelfMutilation")) ''= '" & ReasonSelfMutilation.Checked & "' " &
                            ReasonSexualAbuseRape.Checked = ConvertDBNULL(DaReader("ReasonSexualAbuseRape")) ''= '" & ReasonSexualAbuseRape.Checked & "' " &
                            ReasonSexuality.Checked = ConvertDBNULL(DaReader("ReasonSexuality"))
                            ReasonSleepingDisorder.Checked = ConvertDBNULL(DaReader("ReasonSleepingDisorder")) ''= '" & ReasonSleepingDisorder.Checked & "' " &
                            ReasonSocialPhobia.Checked = ConvertDBNULL(DaReader("ReasonSocialPhobia")) ''= '" & ReasonSocialPhobia.Checked & "' " &
                            ReasonStress.Checked = ConvertDBNULL(DaReader("ReasonStress")) ''= '" & ReasonStress.Checked & "' " &
                            ReasonSubstanceAbuse.Checked = ConvertDBNULL(DaReader("ReasonSubstanceAbuse")) ''= '" & ReasonSubstanceAbuse.Checked & "' " &
                            ReasonSuicide.Checked = ConvertDBNULL(DaReader("ReasonSuicide")) ''= '" & ReasonSuicide.Checked & "' " &

                            ReferDASGFaceToFace.Checked = ConvertDBNULL(DaReader("ReferDASGFaceToFace")) ''= '" & ReferDASGFaceToFace.Checked & "' " &
                            ReferGP.Checked = ConvertDBNULL(DaReader("ReferGP")) ''= '" & [ReferGP.Checked = DaReader("").Checked & "' " &
                            ReferGovHospital.Checked = ConvertDBNULL(DaReader("ReferGovHospital")) ''= '" & ReferGovHospital.Checked & "' " &
                            ReferLiteratureWebsite.Checked = ConvertDBNULL(DaReader("ReferLiteratureWebsite")) ''= '" & ReferLiteratureWebsite.Checked & "' " &
                            ReferNone.Checked = ConvertDBNULL(DaReader("ReferNone")) ''= '" & ReferNone.Checked & "' " &
                            ReferOther.Checked = ConvertDBNULL(DaReader("ReferOther")) ''= '" & ReferOther.Checked & "' " &                                            
                            ReferOtherNGOHelpline.Checked = ConvertDBNULL(DaReader("ReferOtherNGOHelpline")) ''= '" & ReferOtherNGOHelpline.Checked & "' " &
                            ReferPoliceStation.Checked = ConvertDBNULL(DaReader("ReferPoliceStation")) ''= '" & ReferPoliceStation.Checked & "' " &
                            ReferPrivateHospital.Checked = ConvertDBNULL(DaReader("ReferPrivateHospital")) ''= '" & ReferPrivateHospital.Checked & "' " &
                            ReferPsychiatrist.Checked = ConvertDBNULL(DaReader("ReferPsychiatrist")) ''= '" & ReferPsychiatrist.Checked & "' " &
                            ReferPsycologist.Checked = ConvertDBNULL(DaReader("ReferPsychologist")) ''= '" & ReferPsycologist.Checked & "' " &
                            ReferRapeCrisis.Checked = ConvertDBNULL(DaReader("ReferRapeCrisis")) ''= '" & ReferRapeCrisis.Checked & "' " &

                            ReferRehabilitationCentre.Checked = ConvertDBNULL(DaReader("ReferRehabilitationCentre"))

                            ReferShelter.Checked = ConvertDBNULL(DaReader("ReferShelter")) ''= '" & ReferShelter.Checked & "' " &
                            ReferSocialWorker.Checked = ConvertDBNULL(DaReader("ReferSocialWorker")) ''= '" & ReferSocialWorker.Checked & "' " &
                            ReferSupportGroup.Checked = ConvertDBNULL(DaReader("ReferSupportGroup")) ''= '" & ReferSupportGroup.Checked & "' " &

                            ReferTraumaCentre.Checked = ConvertDBNULL(DaReader("ReferTraumaCentre"))
                            CallSummary.Text = ConvertDBNULLToString(DaReader("CallSummary")).Trim

                            '' Added for dedicated Lines 15 December 2017
                            ReasonOtherReason.Checked = ConvertDBNULL(DaReader("ReasonOtherReason"))
                            ReasonFollowUp.Checked = ConvertDBNULL(DaReader("ReasonFollowUp"))
                            ReferUniversityStudentWellness.Checked = ConvertDBNULL(DaReader("ReferUniversityStudentWellness"))
                            ReferSADAGHelpLine.Checked = ConvertDBNULL(DaReader("ReferSADAGHelpLine"))
                            ReferSelfHelp.Checked = ConvertDBNULL(DaReader("ReferSelfHelp"))
                            ReferUber.Checked = ConvertDBNULL(DaReader("ReferUber"))
                            DLTime.Text = ConvertDBNULLToString(DaReader("DLCallTimeOfDay")).Trim

                            '' Added SL 25 May 2018
                            ActionPoints.Text = ConvertDBNULLToString(DaReader("ActionPoints")).Trim

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ' Filter onthe Active Counsellors and the current one! '
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            '' Filter on the active and current Counsellor
                            SqlDataSource1.SelectCommand = "Select * from [counsellors] where active = 1 or [counsellor] = '" + DaReader("Counsellor").Trim + "' "



                        End If

                        DaReader.Close()

                    End Using

                End If


            End If

        Else

            '' Filter on All ACTIVE counsellors
            SqlDataSource1.SelectCommand = "Select * from [counsellors] where active = 1 "

        End If


        ' Hier skryf ons al die snot wat die gebeur as die postback gebeur. '
        If Not (IsPostBack) Then

            Counsellor.Focus()

            If CallCalendar1.SelectedDates.Count = 0 Then
                CallCalendar1.SelectedDate = Today()
            End If

            '           If CallDate.Text.Length = 0 Then
            ' CallDate.Text = Today()
            'End If


            ''''''''''''''''
            ' As dit 'n nuwe caller is dan is alles reg
            ' Andersins moet ons die caller-id opsoek 
            ' en die data vir die variables stel en display
            '
            ' En dan net die CALLER update en die NUWE CALL save '
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Else
            '' It a postback so save the data!!!

            '' Ek sou graag 'n redirect wou doen om 'n skoon skerm te wys. ''

            '' SL 24 October 2018
            '' Die Button1_Click event sal getrigger word omdat dit n postback is en dan sal n nuwe rekord by die databasis bygestit word!

        End If


    End Sub

    Protected Function ConvertDBNULL(ByVal SomeValue) As Boolean

        If TypeOf (SomeValue) Is DBNull Then
            Return False
        Else
            Return SomeValue
        End If

    End Function

    Protected Function ConvertDBNULLToString(ByVal SomeValue) As String

        If TypeOf (SomeValue) Is DBNull Then
            Return ""
        Else
            Return SomeValue
        End If

    End Function



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click


        '''''''''''''''''''''''''''''''''''''''''''''
        ' This happens after the Page=Load Event    '
        ' WHen we click on the "submit call" Button '
        '''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' As dit 'n nuwe caller is dan is alles reg          '
        ' SAVE DIE NUWE CALLER EN CALL                       '
        '                                                    '
        ' Andersins moet ons die caller-id opsoek            '
        ' En dan net die CALLER update en die NUWE CALL save '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''
        ' Insert the stuff into the datasource '
        ' Using ADO.NET                        '
        '''''''''''''''''''''''''''''''''''''''
        Dim NextCallerID As Integer
        '' Dim NextCallID As Integer

        Dim DaConnection As New System.Data.SqlClient.SqlConnection

        '' Get the string of the DAISYConnectionString1 '' 
        DaConnection.ConnectionString = ConfigurationManager.ConnectionStrings("DAISYConnectionString1").ConnectionString.ToString()

        If CallerID.Text = "" Then
            '' Add A New Caller And Call!!


            Using DaConnection



                ''''''''''''''''''''''''''''''''''''''
                ' Insert The Stuff into the Database '
                '                            
                ' Added some fields here for the DEDICATED LINES on  December 2017 '
                '
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim Retval
                Dim DaCommand As New System.Data.SqlClient.SqlCommand
                DaConnection.Open()
                DaCommand.Connection = DaConnection

                '' New Code from Here 
                DaCommand.CommandType = CommandType.StoredProcedure
                DaCommand.CommandText = "[CreateCaseWrite]"

                DaCommand.Parameters.AddWithValue("@Name", Firstname.Text)
                DaCommand.Parameters.AddWithValue("@Surname", Surname.Text)
                DaCommand.Parameters.AddWithValue("@Age", AgeGroup.Text)
                DaCommand.Parameters.AddWithValue("@Sex", Gender.Text)
                DaCommand.Parameters.AddWithValue("@Race", Race.Text)
                DaCommand.Parameters.AddWithValue("@Occupation", Occupation.Text)
                DaCommand.Parameters.AddWithValue("@MedicalAid", MedicalAid.Text)
                DaCommand.Parameters.AddWithValue("@Medication", Medication.Text)
                DaCommand.Parameters.AddWithValue("@Address", Address.Text)
                DaCommand.Parameters.AddWithValue("@City", City.Text)
                DaCommand.Parameters.AddWithValue("@Province", ddlProvince.Text)
                DaCommand.Parameters.AddWithValue("@PostalCode", PostalCode.Text)
                DaCommand.Parameters.AddWithValue("@Telephone1", Telephone1.Text)
                DaCommand.Parameters.AddWithValue("@Telephone2", Telephone2.Text)
                DaCommand.Parameters.AddWithValue("@EmailAddress", EMailAddress.Text)
                DaCommand.Parameters.AddWithValue("@Suburb", Suburb.Text)
                DaCommand.Parameters.AddWithValue("@DLLocation", DLLocation.Text)             '' For Dedicated Lines 
                DaCommand.Parameters.AddWithValue("@DLType", DLType.Text)                     '' For Dedicated Lines
                DaCommand.Parameters.AddWithValue("@DLSource", DLSource.Text)                 '' For Dedicated Lines
                DaCommand.Parameters.AddWithValue("@DLStudentNumber", DLStudentNumber.Text)   '' For Dedicated Lines
                DaCommand.Parameters.AddWithValue("@Counsellor", Counsellor.Text)
                DaCommand.Parameters.AddWithValue("@CallDate", CallCalendar1.SelectedDate.ToString().Substring(0, 10))

                DaCommand.Parameters.AddWithValue("@ReasonADHD ", Convert.ToBoolean(ReasonADHD.Checked.ToString()))

                DaCommand.Parameters.AddWithValue("@ReasonAlzheimersDementia", Convert.ToBoolean(ReasonAlzheimersDementia.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonAnxiety", Convert.ToBoolean(ReasonAnxiety.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonBipolar", Convert.ToBoolean(ReasonBipolar.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonDebtPovertyUnemployment", Convert.ToBoolean(ReasonDebtPovertyUnemployment.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonDepression", Convert.ToBoolean(ReasonDepression.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonEatingDisoirder", Convert.ToBoolean(ReasonEatingDisorder.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonHIVAIDS", Convert.ToBoolean(ReasonHIVAIDS.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonInformation", Convert.ToBoolean(ReasonInformation.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonLossGriefLoneliness", Convert.ToBoolean(ReasonLoss.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonNone", Convert.ToBoolean(ReasonNone.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonOCD", Convert.ToBoolean(ReasonOCD.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonOtherIllness", Convert.ToBoolean(ReasonOther.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPhysicalEmotionalAbuse", Convert.ToBoolean(ReasonAbusePhysicalEmotional.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPostNatalDepression", Convert.ToBoolean(ReasonPND.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPTSDTrauma", Convert.ToBoolean(ReasonPSTDTrauma.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonReationshipDomesticAbuse", Convert.ToBoolean(ReasonReationshipDomesticAbuse.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSchizophrenia", Convert.ToBoolean(ReasonSchizophrenia.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSelfMutilation", Convert.ToBoolean(ReasonSelfMutilation.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSexualAbuseRape", Convert.ToBoolean(ReasonSexualAbuseRape.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSleepingDisorder", Convert.ToBoolean(ReasonSleepingDisorder.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSocialPhobia", Convert.ToBoolean(ReasonSocialPhobia.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonStress", Convert.ToBoolean(ReasonStress.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSubstanceAbuse", Convert.ToBoolean(ReasonSubstanceAbuse.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSuicide", Convert.ToBoolean(ReasonSuicide.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferDASGFaceToFace", Convert.ToBoolean(ReferDASGFaceToFace.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferGP", Convert.ToBoolean(ReferGP.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferGovHospital", Convert.ToBoolean(ReferGovHospital.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferLiteratureWebsite", Convert.ToBoolean(ReferLiteratureWebsite.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferNone", Convert.ToBoolean(ReferNone.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferOther", Convert.ToBoolean(ReferOther.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferOtherNGOHelpline", Convert.ToBoolean(ReferOtherNGOHelpline.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPoliceStation", Convert.ToBoolean(ReferPoliceStation.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPrivateHospital", Convert.ToBoolean(ReferPrivateHospital.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPsychiatrist", Convert.ToBoolean(ReferPsychiatrist.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPsychologist", Convert.ToBoolean(ReferPsycologist.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferRapeCrisis", Convert.ToBoolean(ReferRapeCrisis.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferShelter", Convert.ToBoolean(ReferShelter.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferSocialWorker", Convert.ToBoolean(ReferSocialWorker.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferSupportGroup", Convert.ToBoolean(ReferSupportGroup.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferTraumaCentre", Convert.ToBoolean(ReferTraumaCentre.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@CallSummary", [CallSummary].Text.ToString.Replace("'", "`"))
                DaCommand.Parameters.AddWithValue("@ReasonFrequentCaller", Convert.ToBoolean(ReasonFrequentCaller.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonBullying", Convert.ToBoolean(ReasonBullying.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPregnancy", Convert.ToBoolean(ReasonPregnancy.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSexuality", Convert.ToBoolean(ReasonSexuality.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferRehabilitationCentre", Convert.ToBoolean(ReferRehabilitationCentre.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonBorderlinePersonalityDisorder", Convert.ToBoolean(ReasonBorderlinePersonalityDisorder.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@HelpLine", HelpLine.Text)
                DaCommand.Parameters.AddWithValue("@ReasonOtherReason", Convert.ToBoolean(ReasonOther.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonFollowUp", Convert.ToBoolean(ReasonFollowUp.Checked.ToString()))                                 '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferUniversityStudentWellness", Convert.ToBoolean(ReferUniversityStudentWellness.Checked.ToString())) '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferSadagHelpLine", Convert.ToBoolean(ReferSADAGHelpLine.Checked.ToString()))                         '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferSelfHelp", Convert.ToBoolean(ReferSelfHelp.Checked.ToString()))                                   '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferUber", Convert.ToBoolean(ReferUber.Checked.ToString()))                                           '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@DLCallTimeOfDay", DLTime.Text)
                DaCommand.Parameters.AddWithValue("@CalledOnBehalfOf", "")                   '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ActionPoints", ActionPoints.Text.ToString.Replace("'", "`"))
                DaCommand.Parameters.AddWithValue("@ReasonRelationshipRomanticIssues", 0)   '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ReasonRelationshipFamilyIssues", 0)     '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ReferCompanyEAP", 0)                    '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ReferUniversitySupportServices", 0)     '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@DistressRatingBegining", DBNull.Value)  '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@DistressRatingEnd", DBNull.Value)       '' Normal SADAG DAISY Lines Only

                DaCommand.ExecuteReader()


                '' Show clean Screen
                Response.Redirect("CreatecaseDedicatedLines.aspx")

                Response.End()


                ''''''''''''''''''''''''''''''''''''''''''''''''''
                '' OLD DEPRECATED CODE BELOW (18 November 2018) ''
                ''''''''''''''''''''''''''''''''''''''''''''''''''

                DaCommand.CommandText = "Insert into CALLERS (Name,Surname,Age,sex,Race,Occupation,MedicalAid,Medication,Address,City,Province,PostalCode,telephone1,Telephone2,EmailAddress,Suburb,DLLocation,DLType,DLSource,DLStudentNumber) values ('" & Firstname.Text & "', '" & Surname.Text & "', '" & AgeGroup.Text & "', '" & Gender.Text & "', '" & Race.Text & "','" & Occupation.Text & "', '" & MedicalAid.Text & "', '" & Medication.Text & "', '" & Address.Text & "', '" & City.Text & "', '" & ddlProvince.Text & "', '" & PostalCode.Text & "', '" & Telephone1.Text & "', '" & Telephone2.Text & "', '" & EMailAddress.Text & "','" & Suburb.Text & "','" & DLLocation.Text & "','" & DLType.Text & "','" & DLSource.Text & "','" & DLStudentNumber.Text & "')"
                Retval = DaCommand.ExecuteNonQuery()

                If Retval = 1 Then

                    LblFeedback.Text = "CALLER Data Submitted OK."

                    '' Get the CallerID from the database via the IDENTITY(1,1)
                    DaCommand.CommandText = "select ident_current('Callers')"
                    Dim DaReader As System.Data.SqlClient.SqlDataReader = DaCommand.ExecuteReader()
                    If DaReader.HasRows Then
                        DaReader.Read()
                        NextCallerID = DaReader.GetDecimal(0)
                    End If
                    DaReader.Close()

                    Dim Retval2

                    '' 26 May 2018 - Added IDENTITY(1,1) in the CALLS Database Tahble
                    DaCommand.CommandText = "Insert into CALLS (CALLERID,Counsellor,Calldate,ReasonADHD,ReasonAlzheimersDementia,ReasonAnxiety,[ReasonBipolar],[ReasonDebtPovertyUnemployment],[ReasonDepression],[ReasonEatingDisoirder],[ReasonHIVAIDS],[ReasonInformation],[ReasonLossGriefLoneliness],[ReasonNone],[ReasonOCD],[ReasonOtherIllness],[ReasonFrequentCaller],[ReasonPhysicalEmotionalAbuse],[ReasonPostNatalDepression],[ReasonPTSDTrauma],[ReasonReationshipDomesticAbuse],[ReasonSchizophrenia],[ReasonSelfMutilation],[ReasonSexualAbuseRape],[ReasonSleepingDisorder],[ReasonSocialPhobia],[ReasonStress],[ReasonSubstanceAbuse],[ReasonSuicide],[ReferDASGFaceToFace],[ReferGP],[ReferGovHospital],[ReferLiteratureWebsite],[ReferNone],[ReferOther],[ReferOtherNGOHelpline],[ReferPoliceStation],[ReferPrivateHospital],[ReferPsychiatrist],[ReferPsychologist],[ReferRapeCrisis],[ReferShelter],[ReferSocialWorker],[ReferSupportGroup],[ReferTraumaCentre],[CallSummary],[ReasonBullying],[ReasonPregnancy],[ReasonSexuality],[ReferRehabilitationCentre],[ReasonBorderlinePersonalityDisorder],[Helpline],[ReasonOtherReason],[ReasonFollowUp],[ReferUniversityStudentWellness],[ReferSadagHelpLine],[ReferSelfHelp],[ReferUber],[DLCallTimeOfDay],[ActionPoints]) values (" & NextCallerID & ",'" & Counsellor.Text & "','" & CallCalendar1.SelectedDate.ToString().Substring(0, 10) & "','" & ReasonADHD.Checked & "','" & ReasonAlzheimersDementia.Checked & "','" & ReasonAnxiety.Checked & "','" & ReasonBipolar.Checked & "','" & ReasonDebtPovertyUnemployment.Checked & "','" & ReasonDepression.Checked & "','" & ReasonEatingDisorder.Checked & "','" & ReasonHIVAIDS.Checked & "','" & ReasonInformation.Checked & "','" & ReasonLoss.Checked & "','" & ReasonNone.Checked & "','" & ReasonOCD.Checked & "','" & ReasonOther.Checked & "','" & ReasonFrequentCaller.Checked & "','" & ReasonAbusePhysicalEmotional.Checked & "','" & ReasonPND.Checked & "','" & ReasonPSTDTrauma.Checked & "','" & ReasonReationshipDomesticAbuse.Checked & "','" & ReasonSchizophrenia.Checked & "','" & ReasonSelfMutilation.Checked & "','" & ReasonSexualAbuseRape.Checked & "','" & ReasonSleepingDisorder.Checked & "','" & ReasonSocialPhobia.Checked & "','" & ReasonStress.Checked & "','" & ReasonSubstanceAbuse.Checked & "','" & ReasonSuicide.Checked & "','" & ReferDASGFaceToFace.Checked & "','" & ReferGP.Checked & "','" & ReferGovHospital.Checked & "','" & ReferLiteratureWebsite.Checked & "','" & ReferNone.Checked & "','" & ReferOther.Checked & "','" & ReferOtherNGOHelpline.Checked & "','" & ReferPoliceStation.Checked & "','" & ReferPrivateHospital.Checked & "','" & ReferPsychiatrist.Checked & "','" & ReferPsycologist.Checked & "','" & ReferRapeCrisis.Checked & "','" & ReferShelter.Checked & "','" & ReferSocialWorker.Checked & "','" & ReferSupportGroup.Checked & "','" & ReferTraumaCentre.Checked & "','" & [CallSummary].Text.ToString.Replace("'", "`") & "','" & ReasonBullying.Checked & "','" & ReasonPregnancy.Checked & "','" & ReasonSexuality.Checked & "','" & ReferRehabilitationCentre.Checked & "','" & ReasonBorderlinePersonalityDisorder.Checked & "','" & HelpLine.Text & "','" & ReasonOtherReason.Checked & "','" & ReasonFollowUp.Checked & "','" & ReferUniversityStudentWellness.Checked & "','" & ReferSADAGHelpLine.Checked & "','" & ReferSelfHelp.Checked & "','" & ReferUber.Checked & "','" & DLTime.Text & "','" & ActionPoints.Text.ToString.Replace("'", "`") & "')"


                    Retval2 = DaCommand.ExecuteNonQuery()

                    If Retval2 = 1 Then

                        LblFeedback.Text = LblFeedback.Text & vbCrLf & "CALL     Data Submitted OK."

                        '' Confirm that the call was added.
                        '' MsgBox("Caller and Call added.", MsgBoxStyle.Information, "Information")

                        '' Show clean Screen
                        Response.Redirect("Createcase.aspx")

                    End If

                End If


            End Using

        Else
            '' Just UPDATE the Current Caller In and Call Info!

            Using DaConnection

                DaConnection.Open()

                ''''''''''''''''''''''''''''''''''''''''''''''
                ' UPDATE The CALLER AND CALL in the Database '
                ''''''''''''''''''''''''''''''''''''''''''''''

                ' Added some fields here for the DEDICATED LINES on  December 2017 '


                Dim Retval
                Dim DaCommand As New System.Data.SqlClient.SqlCommand

                DaCommand.Connection = DaConnection

                '' New Code from Here 18 N0ovember 2018
                DaCommand.CommandType = CommandType.StoredProcedure
                DaCommand.CommandText = "[CreateCaseUpdate]"

                DaCommand.Parameters.AddWithValue("@CallerID", CallerID.Text)
                DaCommand.Parameters.AddWithValue("@Name", Firstname.Text)
                DaCommand.Parameters.AddWithValue("@Surname", Surname.Text)
                DaCommand.Parameters.AddWithValue("@Age", AgeGroup.Text)
                DaCommand.Parameters.AddWithValue("@Sex", Gender.Text)
                DaCommand.Parameters.AddWithValue("@Race", Race.Text)
                DaCommand.Parameters.AddWithValue("@Occupation", Occupation.Text)
                DaCommand.Parameters.AddWithValue("@MedicalAid", MedicalAid.Text)
                DaCommand.Parameters.AddWithValue("@Medication", Medication.Text)
                DaCommand.Parameters.AddWithValue("@Address", Address.Text)
                DaCommand.Parameters.AddWithValue("@City", City.Text)
                DaCommand.Parameters.AddWithValue("@Province", ddlProvince.Text)
                DaCommand.Parameters.AddWithValue("@PostalCode", PostalCode.Text)
                DaCommand.Parameters.AddWithValue("@Telephone1", Telephone1.Text)
                DaCommand.Parameters.AddWithValue("@Telephone2", Telephone2.Text)
                DaCommand.Parameters.AddWithValue("@EmailAddress", EMailAddress.Text)
                DaCommand.Parameters.AddWithValue("@Suburb", Suburb.Text)
                DaCommand.Parameters.AddWithValue("@DLLocation", DLLocation.Text)             '' For Dedicated Lines 
                DaCommand.Parameters.AddWithValue("@DLType", DLType.Text)                     '' For Dedicated Lines
                DaCommand.Parameters.AddWithValue("@DLSource", DLSource.Text)                 '' For Dedicated Lines
                DaCommand.Parameters.AddWithValue("@DLStudentNumber", DLStudentNumber.Text)   '' For Dedicated Lines
                DaCommand.Parameters.AddWithValue("@Counsellor", Counsellor.Text)
                DaCommand.Parameters.AddWithValue("@CallDate", CallCalendar1.SelectedDate.ToString().Substring(0, 10))

                DaCommand.Parameters.AddWithValue("@ReasonADHD ", Convert.ToBoolean(ReasonADHD.Checked.ToString()))

                DaCommand.Parameters.AddWithValue("@ReasonAlzheimersDementia", Convert.ToBoolean(ReasonAlzheimersDementia.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonAnxiety", Convert.ToBoolean(ReasonAnxiety.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonBipolar", Convert.ToBoolean(ReasonBipolar.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonDebtPovertyUnemployment", Convert.ToBoolean(ReasonDebtPovertyUnemployment.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonDepression", Convert.ToBoolean(ReasonDepression.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonEatingDisoirder", Convert.ToBoolean(ReasonEatingDisorder.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonHIVAIDS", Convert.ToBoolean(ReasonHIVAIDS.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonInformation", Convert.ToBoolean(ReasonInformation.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonLossGriefLoneliness", Convert.ToBoolean(ReasonLoss.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonNone", Convert.ToBoolean(ReasonNone.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonOCD", Convert.ToBoolean(ReasonOCD.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonOtherIllness", Convert.ToBoolean(ReasonOther.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPhysicalEmotionalAbuse", Convert.ToBoolean(ReasonAbusePhysicalEmotional.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPostNatalDepression", Convert.ToBoolean(ReasonPND.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPTSDTrauma", Convert.ToBoolean(ReasonPSTDTrauma.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonReationshipDomesticAbuse", Convert.ToBoolean(ReasonReationshipDomesticAbuse.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSchizophrenia", Convert.ToBoolean(ReasonSchizophrenia.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSelfMutilation", Convert.ToBoolean(ReasonSelfMutilation.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSexualAbuseRape", Convert.ToBoolean(ReasonSexualAbuseRape.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSleepingDisorder", Convert.ToBoolean(ReasonSleepingDisorder.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSocialPhobia", Convert.ToBoolean(ReasonSocialPhobia.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonStress", Convert.ToBoolean(ReasonStress.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSubstanceAbuse", Convert.ToBoolean(ReasonSubstanceAbuse.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSuicide", Convert.ToBoolean(ReasonSuicide.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferDASGFaceToFace", Convert.ToBoolean(ReferDASGFaceToFace.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferGP", Convert.ToBoolean(ReferGP.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferGovHospital", Convert.ToBoolean(ReferGovHospital.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferLiteratureWebsite", Convert.ToBoolean(ReferLiteratureWebsite.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferNone", Convert.ToBoolean(ReferNone.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferOther", Convert.ToBoolean(ReferOther.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferOtherNGOHelpline", Convert.ToBoolean(ReferOtherNGOHelpline.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPoliceStation", Convert.ToBoolean(ReferPoliceStation.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPrivateHospital", Convert.ToBoolean(ReferPrivateHospital.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPsychiatrist", Convert.ToBoolean(ReferPsychiatrist.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferPsychologist", Convert.ToBoolean(ReferPsycologist.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferRapeCrisis", Convert.ToBoolean(ReferRapeCrisis.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferShelter", Convert.ToBoolean(ReferShelter.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferSocialWorker", Convert.ToBoolean(ReferSocialWorker.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferSupportGroup", Convert.ToBoolean(ReferSupportGroup.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferTraumaCentre", Convert.ToBoolean(ReferTraumaCentre.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@CallSummary", [CallSummary].Text.ToString.Replace("'", "`"))
                DaCommand.Parameters.AddWithValue("@ReasonFrequentCaller", Convert.ToBoolean(ReasonFrequentCaller.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonBullying", Convert.ToBoolean(ReasonBullying.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonPregnancy", Convert.ToBoolean(ReasonPregnancy.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonSexuality", Convert.ToBoolean(ReasonSexuality.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReferRehabilitationCentre", Convert.ToBoolean(ReferRehabilitationCentre.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonBorderlinePersonalityDisorder", Convert.ToBoolean(ReasonBorderlinePersonalityDisorder.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@HelpLine", HelpLine.Text)
                DaCommand.Parameters.AddWithValue("@ReasonOtherReason", Convert.ToBoolean(ReasonOther.Checked.ToString()))
                DaCommand.Parameters.AddWithValue("@ReasonFollowUp", 0)  '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferUniversityStudentWellness", 0) '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferSadagHelpLine", 0) '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferSelfHelp", 0) '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@ReferUber", "") '' DEDICATED LINES
                DaCommand.Parameters.AddWithValue("@DLCallTimeOfDay", DLTime.Text)
                DaCommand.Parameters.AddWithValue("@CalledOnBehalfOf", "")                   '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ActionPoints", ActionPoints.Text.ToString.Replace("'", "`"))
                DaCommand.Parameters.AddWithValue("@ReasonRelationshipRomanticIssues", 0)   '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ReasonRelationshipFamilyIssues", 0)     '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ReferCompanyEAP", 0)                    '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@ReferUniversitySupportServices", 0)     '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@DistressRatingBegining", DBNull.Value)  '' Normal SADAG DAISY Lines Only
                DaCommand.Parameters.AddWithValue("@DistressRatingEnd", DBNull.Value)       '' Normal SADAG DAISY Lines Only

                DaCommand.ExecuteReader()


                '' Show clean Screen
                Response.Redirect("CreatecaseDedicatedLines.aspx")


                Response.End()






                ''''''''''''''''''''''''''''''''
                ' OLD DEPRECATED CODE BELOW  ''
                ''''''''''''''''''''''''''''''''
                DaCommand.CommandText = "UPDATE [CALLERS] SET " &
                    " [Name] = '" & Firstname.Text.ToString() & "', " &
                    " [SurName] = '" & Surname.Text.ToString() & "', " &
                    " [Age] = '" & AgeGroup.Text.ToString() & "', " &
                    " [Sex] = '" & Gender.Text.ToString() & "', " &
                    " [Race] = '" & Race.Text.ToString() & "', " &
                    " [Occupation] = '" & Occupation.Text.ToString() & "', " &
                    " [MedicalAid] = '" & MedicalAid.Text.ToString() & "', " &
                    " [Medication] = '" & Medication.Text.ToString() & "', " &
                    " [Address] = '" & Address.Text.ToString() & "', " &
                    " [Suburb] = '" & Suburb.Text.ToString() & "', " &
                    " [City] = '" & City.Text.ToString() & "', " &
                    " [Province] = '" & ddlProvince.Text.ToString() & "', " &
                    " [PostalCode] = '" & PostalCode.Text.ToString() & "', " &
                    " [Telephone1] = '" & Telephone1.Text.ToString() & "', " &
                    " [Telephone2] = '" & Telephone2.Text.ToString() & "', " &
                    " [EmailAddress] = '" & EMailAddress.Text.ToString() & "', " &
                    " [DLLocation] = '" & DLLocation.Text.ToString() & "', " &
                    " [DLType] = '" & DLType.Text.ToString() & "', " &
                    " [DLSource] = '" & DLSource.Text.ToString() & "', " &
                    " [DLStudentNumber] = '" & DLStudentNumber.Text.ToString() & "' " &
                    " WHERE [CALLERID] = " & CallerID.Text

                DaCommand.Connection = DaConnection

                Retval = DaCommand.ExecuteNonQuery()

                If Retval = 1 Then

                    LblFeedback.Text = "CALLER Data UPDATED OK."

                    Dim Retval2

                    ' Added some fields here for the DEDICATED LINES on  December 2017 '

                    DaCommand.CommandText = "UPDATE [CALLS] SET " &
                                            " [Counsellor] = '" & Counsellor.Text.ToString() & "', " &
                                            " [ReasonADHD] = '" & ReasonADHD.Checked & "', " &
                                            " [ReasonAlzheimersDementia] = '" & ReasonAlzheimersDementia.Checked.ToString() & "', " &
                                            " [ReasonAnxiety] = '" & ReasonAnxiety.Checked & "', " &
                                            " [ReasonBipolar] = '" & ReasonBipolar.Checked & "', " &
                                            " [ReasonBorderlinePersonalityDisorder] = '" & ReasonBorderlinePersonalityDisorder.Checked & "', " &
                                            " [ReasonBullying] = '" & ReasonBullying.Checked & "', " &
                                            " [ReasonDebtPovertyUnemployment] = '" & ReasonDebtPovertyUnemployment.Checked & "', " &
                                            " [ReasonDepression] = '" & ReasonDepression.Checked & "', " &
                                            " [ReasonEatingDisoirder] = '" & ReasonEatingDisorder.Checked & "', " &
                                            " [ReasonHIVAIDS] = '" & ReasonHIVAIDS.Checked & "', " &
                                            " [ReasonInformation] = '" & ReasonInformation.Checked & "', " &
                                            " [ReasonLossGriefLoneliness] = '" & ReasonLoss.Checked & "', " &
                                            " [ReasonNone] = '" & ReasonNone.Checked & "', " &
                                            " [ReasonOCD] = '" & ReasonOCD.Checked & "', " &
                                            " [ReasonOtherIllness] = '" & ReasonOther.Checked & "', " &
                                            " [ReasonFrequentCaller] = '" & ReasonFrequentCaller.Checked & "', " &
                                            " [ReasonPhysicalEmotionalAbuse] = '" & ReasonAbusePhysicalEmotional.Checked & "', " &
                                            " [ReasonPostNatalDepression] = '" & ReasonPND.Checked & "', " &
                                            " [ReasonPregnancy] = '" & ReasonPregnancy.Checked & "', " &
                                            " [ReasonPTSDTrauma] = '" & ReasonPSTDTrauma.Checked & "', " &
                                            " [ReasonReationshipDomesticAbuse] = '" & ReasonReationshipDomesticAbuse.Checked & "', " &
                                            " [ReasonSchizophrenia] = '" & ReasonSchizophrenia.Checked & "', " &
                                            " [ReasonSelfMutilation] = '" & ReasonSelfMutilation.Checked & "', " &
                                            " [ReasonSexualAbuseRape] = '" & ReasonSexualAbuseRape.Checked & "', " &
                                            " [ReasonSexuality] = '" & ReasonSexuality.Checked & "', " &
                                            " [ReasonSleepingDisorder] = '" & ReasonSleepingDisorder.Checked & "', " &
                                            " [ReasonSocialPhobia] = '" & ReasonSocialPhobia.Checked & "', " &
                                            " [ReasonStress] = '" & ReasonStress.Checked & "', " &
                                            " [ReasonSubstanceAbuse] = '" & ReasonSubstanceAbuse.Checked & "', " &
                                            " [ReasonSuicide] = '" & ReasonSuicide.Checked & "', " &
                                            " [ReferDASGFaceToFace] = '" & ReferDASGFaceToFace.Checked & "', " &
                                            " [ReferGP] = '" & [ReferGP].Checked & "', " &
                                            " [ReferGovHospital] = '" & ReferGovHospital.Checked & "', " &
                                            " [ReferLiteratureWebsite] = '" & ReferLiteratureWebsite.Checked & "', " &
                                            " [ReferNone] = '" & ReferNone.Checked & "', " &
                                            " [ReferOther] = '" & ReferOther.Checked & "', " &
                                            " [ReferOtherNGOHelpline] = '" & ReferOtherNGOHelpline.Checked & "', " &
                                            " [ReferPoliceStation] = '" & ReferPoliceStation.Checked & "', " &
                                            " [ReferPrivateHospital] = '" & ReferPrivateHospital.Checked & "', " &
                                            " [ReferPsychiatrist] = '" & ReferPsychiatrist.Checked & "', " &
                                            " [ReferPsychologist] = '" & ReferPsycologist.Checked & "', " &
                                            " [ReferRapeCrisis] = '" & ReferRapeCrisis.Checked & "', " &
                                            " [ReferRehabilitationCentre] = '" & ReferRehabilitationCentre.Checked & "', " &
                                            " [ReferShelter] = '" & ReferShelter.Checked & "', " &
                                            " [ReferSocialWorker] = '" & ReferSocialWorker.Checked & "', " &
                                            " [ReferSupportGroup] = '" & ReferSupportGroup.Checked & "', " &
                                            " [ReferTraumaCentre] = '" & ReferTraumaCentre.Checked & "', " &
                                            " [Calldate] = '" & CallCalendar1.SelectedDate.ToString().Substring(0, 10) & "', " &
                                            " [CallSummary] = '" & [CallSummary].Text.ToString.Replace("'", "`") & "', " &
                                            " [HelpLine] = '" & [HelpLine].Text.ToString.Replace("'", "`") & "', " &
                                            " [ReasonOtherReason] = '" & ReasonOtherReason.Checked & "', " &
                                            " [ReasonFollowUp] = '" & ReasonFollowUp.Checked & "', " &
                                            " [ReferUniversityStudentWellness] = '" & ReferUniversityStudentWellness.Checked & "', " &
                                            " [ReferSADAGHelpline] = '" & ReferSADAGHelpLine.Checked & "', " &
                                            " [ReferSelfHelp] = '" & ReferSelfHelp.Checked & "', " &
                                            " [ReferUber] = '" & ReferUber.Checked & "', " &
                                            " [ActionPoints] = '" & [ActionPoints].Text.ToString.Replace("'", "`") & "', " &
                                            " [DLCallTimeOfDay] = '" & DLTime.Text.ToString.Replace("'", "`") & "' " &
                                            " WHERE [CALLERID] = " & CallerID.Text

                    If CallID.Text.ToString().Length > 0 Then
                        DaCommand.CommandText = DaCommand.CommandText & " AND [CALLID] =" & CallID.Text & ""
                    End If

                    DaCommand.Connection = DaConnection

                    Retval2 = -1
                    Retval2 = DaCommand.ExecuteNonQuery()

                    If Retval2 > -1 Then

                        LblFeedback.Text = LblFeedback.Text & vbCrLf & "CALL Data UPDATED OK."

                        '' Show clean Screen
                        Response.Redirect("Createcase.aspx")

                    End If

                End If

            End Using

        End If




    End Sub

    Protected Sub MedicalAid_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MedicalAid.SelectedIndexChanged

    End Sub



    Protected Sub AgeGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AgeGroup.SelectedIndexChanged

    End Sub

    Protected Sub Race_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Race.SelectedIndexChanged

    End Sub

End Class