<%@ Page  Title="Create Case"
Language="vb" 
MasterPageFile="~/Site.Master"
AutoEventWireup="false" CodeBehind="CreateCaseDedicatedLines.aspx.vb" 
Inherits="WebApplication1.WebForm11" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">


</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    
<b>Call - From a Dedicated Line 
    <asp:TextBox ID="CallID" runat="server" 
            TabIndex="1" MaxLength="10" Enabled="false" Visible="false" ></asp:TextBox></b>
   &nbsp;
   
    <table border='1' width='100%'> 
    <tr><td>

   <table width="100%" border="0">
   <tr>
   
       <td  >    
        Counsellor: 
        </td>
        <td>
        <asp:DropDownList ID="Counsellor" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="Counsellor" DataValueField="Counsellor" TabIndex="1">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="Counsellor is a required field" ControlToValidate="Counsellor" 
                ToolTip="Counsellor is a required field" Text="*" SetFocusOnError="True" ></asp:RequiredFieldValidator>
        </td>

              

        <td rowspan="3">
            Call Date:
        </td>
        <td rowspan="3">

            <asp:Calendar ID="CallCalendar1" runat="server" Height="45px" Width="200px" TabIndex="5" 
                BackColor="White" BorderColor="#999999" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="Black">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle ForeColor="Black" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>

        </td>
   

   </tr>

       <tr>

           <td  >    
        Time of day: 
        </td>
        <td>
        <asp:DropDownList ID="DLTime" runat="server" DataSourceID="SqlDataSource7" 
                DataTextField="Time" DataValueField="Time" TabIndex="2">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ErrorMessage="Time is a required field" ControlToValidate="DLTime" 
                ToolTip="Time is a required field" Text="*" SetFocusOnError="True" ></asp:RequiredFieldValidator>
        </td>

        </tr>
   <tr>
    
    <td>    
        Helpline: 
        </td>
        <td>
        <asp:DropDownList ID="HelpLine" runat="server" TabIndex="3" DataSourceID="SqlDataSource3" DataTextField="Helpline" DataValueField="Helpline">
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ErrorMessage="Helpline is a required field" ControlToValidate="HelpLine" 
                ToolTip="Helpline is a required field" Text="*" SetFocusOnError="True" ></asp:RequiredFieldValidator>

            </td>
   
   </tr>

   </table>

      </td>
   </tr>
   </table>

    <br/>

    <b>Caller Information <asp:TextBox ID="CallerID" runat="server" 
            TabIndex="1" MaxLength="10" Enabled="false" Visible="false" ></asp:TextBox></b>

    <table border='1' width='100%'> 
    <tr><td>

        <table border="0" width='100%' >
        <tr><td>
        First name: 
        </td>
        <td>
        <asp:TextBox ID="Firstname" runat="server" 
            TabIndex="6" MaxLength="100" ></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="First Name is a required field" ControlToValidate="Firstname" 
                SetFocusOnError="True" ToolTip="First Name is a required field">*</asp:RequiredFieldValidator>
        </td>

        <td>
        Street / Box: 
        </td>
        <td>
        <asp:TextBox ID="Address" runat="server" TabIndex="14" ></asp:TextBox>
        </td>


        <td>
        Location: 
        </td>
        <td>
            <asp:DropDownList ID="DLLocation" runat="server" DataSourceID="SqlDataSource4" 
                DataTextField="Location" DataValueField="Location" TabIndex="22">
            </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ErrorMessage="Location is a required field" ControlToValidate="DLLocation" 
                SetFocusOnError="True" ToolTip="Location is a required field" Text="*">*</asp:RequiredFieldValidator>
        </td>


        </tr>

        <tr><td>   
        Surname: 
            </td>
        <td>
            <asp:TextBox ID="Surname" runat="server" TabIndex="7" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Surname is a required field" ControlToValidate="Surname" 
                SetFocusOnError="True" ToolTip="Surname is a required field">*</asp:RequiredFieldValidator>
        </td>

         <td>
                    Suburb: 
                    </td>
                    <td>
                    <asp:TextBox ID="Suburb" runat="server" TabIndex="15" MaxLength="50" ></asp:TextBox>
                    </td>


                    <td>
        Type: 
        </td>
        <td>
            <asp:DropDownList ID="DLType" runat="server" DataSourceID="SqlDataSource5" 
                DataTextField="Type" DataValueField="Type" TabIndex="23">
            </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                ErrorMessage="Type is a required field" ControlToValidate="DLType" 
                SetFocusOnError="True" ToolTip="Type is a required field">*</asp:RequiredFieldValidator>
            
        </td>


        </tr>


        <tr><td>   
        Age Group:
        </td>
        <td>
            <asp:DropDownList ID="AgeGroup" runat="server" DataSourceID="SqlDataSource2" 
                DataTextField="Group" DataValueField="Group" TabIndex="8">
            </asp:DropDownList>

            </td>


                    <td>
                    City: 
                    </td>
                    <td>
                    <asp:TextBox ID="City" runat="server" TabIndex="16" ></asp:TextBox>
                    </td>

                            <td>
        Source: 
        </td>
        <td>
            <asp:DropDownList ID="DLSource" runat="server" DataSourceID="SqlDataSource6" 
                DataTextField="Source" DataValueField="Source" TabIndex="24"></asp:DropDownList>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                ErrorMessage="Source is a required field" ControlToValidate="DLSource" 
                SetFocusOnError="True" ToolTip="Source is a required field" Text="*">*</asp:RequiredFieldValidator>

        <tr><td>    
        Gender:
        </td>
        <td>
        <asp:DropDownList ID="Gender" runat="server" TabIndex="9">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="M">Male</asp:ListItem>
            <asp:ListItem Value="F">Female</asp:ListItem>
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ErrorMessage="Gender is a required field" ControlToValidate="Gender" 
                ToolTip="Gender is a required field" Text="*" SetFocusOnError="True" ></asp:RequiredFieldValidator>

            </td>

                        <td>
            Province: 
            </td>
            <td>
            <asp:DropDownList ID="ddlProvince" runat="server" TabIndex="17">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="Gauteng">Gauteng</asp:ListItem>
                <asp:ListItem Value="Free State">Free State</asp:ListItem>
                <asp:ListItem Value="Eastern Cape">Eastern Cape</asp:ListItem>
                <asp:ListItem Value="Western Cape">Western Cape</asp:ListItem>
                <asp:ListItem Value="Northern Cape">Northern Cape</asp:ListItem>
                <asp:ListItem Value="Limpopo">Limpopo</asp:ListItem>
                <asp:ListItem Value="North West">North West</asp:ListItem>
                <asp:ListItem Value="KwaZulu Natal">KwaZulu Natal</asp:ListItem>
                <asp:ListItem Value="Mpumalanga">Mpumalanga</asp:ListItem>
                <asp:ListItem Value="Other Country">Other Country</asp:ListItem>
                </asp:DropDownList>
            </td>

                            <td>
        Student Number: 
        </td>

        <td>
            <asp:TextBox ID="DLStudentNumber" runat="server" TabIndex="25">
            </asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
        ErrorMessage="Student Number is a required field" ControlToValidate="DLStudentNumber" 
        ToolTip="Student Number is a required field" Text="*" SetFocusOnError="True" ></asp:RequiredFieldValidator>


        </td>

        </tr>

        <tr><td>    
        Race:
        </td>
        <td>
        <asp:DropDownList ID="Race" runat="server" TabIndex="10">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="Black">Black</asp:ListItem>
            <asp:ListItem Value="White">White</asp:ListItem>
            <asp:ListItem Value="Coloured">Coloured</asp:ListItem>
            <asp:ListItem Value="Indian">Indian</asp:ListItem>
            <asp:ListItem Value="Other">Other</asp:ListItem>
        </asp:DropDownList>
            </td>

            <td>
                Postal Code:
            </td>
            <td>
                <asp:TextBox ID="PostalCode" runat="server" TabIndex="18" MaxLength="4"></asp:TextBox>        
            </td>


        </tr>
        <tr>

            <td>Occupation:</td> <td>
                <asp:TextBox ID="Occupation" runat="server" MaxLength="50" TabIndex="11" ></asp:TextBox></td>


            <td>
                Telephone 1:
            </td>
            <td>
                <asp:TextBox ID="Telephone1" runat="server" TabIndex="19" MaxLength="12"></asp:TextBox>        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Telephone is a required field" ControlToValidate="Telephone1" 
                    ToolTip="Telephone is a required field" Text="*" SetFocusOnError="True" ></asp:RequiredFieldValidator>
            </td> 


        </tr>

        <tr><td>    
        Medical Aid:
        </td>
        <td>
        <asp:DropDownList ID="MedicalAid" runat="server" TabIndex="12">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N">No</asp:ListItem>
            <asp:ListItem Value="U">Unknown</asp:ListItem>
        </asp:DropDownList>
            </td>


                   <td>
            Telephone 2:
        </td>
        <td>
            <asp:TextBox ID="Telephone2" runat="server" TabIndex="20" MaxLength="12"></asp:TextBox>        
        </td>




        </tr>

        <tr><td>    
        Medication: 
        </td>
        <td>
        <asp:DropDownList ID="Medication" runat="server" TabIndex="13">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N">No</asp:ListItem>
            <asp:ListItem Value="U">Unknown</asp:ListItem>
        </asp:DropDownList>
            </td>

                <td>
            EMail Address:
        </td>
        <td>
            <asp:TextBox ID="EMailAddress" runat="server" TabIndex="21" MaxLength="100"></asp:TextBox>        
        </td>

        </tr>

       </table>
   </td>
   </tr>
   </table>




   <br/>

<table width="100%" border="1" >
 <tr>
<td>

<b>Reasons for Call</b>

      <asp:TextBox ID="ValidationTB" runat="server" value="x" Enabled="true" Visible="true" BorderStyle="None" Width="0px" Height="0px" ></asp:TextBox>
 
  <asp:CustomValidator ID="CustomValidator333" runat="server"
        ControlToValidate="ValidationTB"
        ErrorMessage="At least 1 call reason must be selected."
        ClientValidationFunction="ValidCallReasonChecked" Display="None"
        ValidateEmptyText="True" SetFocusOnError="True"></asp:CustomValidator>

   <table border="0" width="100%" >


      <tr>
   
       <td>    
       <asp:CheckBox ID="ReasonADHD" runat="server" Text=" ADHD" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonPND" runat="server" Text=" Post Natal Depression" />
       </td>

    </tr>


       <tr>
   
       <td>    
       <asp:CheckBox ID="ReasonAlzheimersDementia" runat="server" Text=" Alzheimers / Dementia" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonPregnancy" runat="server" Text=" Pregnancy" />
       </td>

    </tr>

   <tr>
   
       <td>    
       <asp:CheckBox ID="ReasonAnxiety" runat="server" Text=" Anxiety / Panic" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonPSTDTrauma" runat="server" Text=" PTSD / Trauma" />
       </td>

    </tr>
    <tr>

       <td>    
       <asp:CheckBox ID="ReasonBipolar" runat="server" Text=" Bipolar" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonReationshipDomesticAbuse" runat="server" Text=" Relationship / Domestic Abuse" />
       </td>

    </tr>

    <tr>
   
        <td>    
        <asp:CheckBox ID="ReasonBorderlinePersonalityDisorder" runat="server" Text=" Borderline Personality Disorder" />
        </td>

        <td>
        </td>

    </tr>

        <tr>

       <td>    
       <asp:CheckBox ID="ReasonBullying" runat="server" Text=" Bullying" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSchizophrenia" runat="server" Text=" Schizophrenia" />
       </td>

    </tr>

    <tr>
   
       <td>    
       <asp:CheckBox ID="ReasonDebtPovertyUnemployment" runat="server" Text=" Debt / Poverty / Unemployment" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSelfMutilation" runat="server" Text=" Self-mutilation" />
       </td>

    </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReasonDepression" runat="server" Text=" Depression" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSexualAbuseRape" runat="server" Text=" Sexual Abuse / Rape" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReasonEatingDisorder" runat="server" Text=" Eating Disorder" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSexuality" runat="server" Text=" Sexuality" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReasonHIVAIDS" runat="server" Text=" HIV / AIDS" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSleepingDisorder" runat="server" Text=" Sleeping Disorder" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReasonInformation" runat="server" Text=" Information" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSocialPhobia" runat="server" Text=" Social Phobia" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReasonLoss" runat="server" Text=" Loss / Grief / Loneliness" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonStress" runat="server" Text=" Stress" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReasonNone" runat="server" Text=" None" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSubstanceAbuse" runat="server" Text=" Substance Abuse" />
       </td>

   </tr>

   <tr>

       <td>    
       <asp:CheckBox ID="ReasonOCD" runat="server" Text=" Obsessive Compulsive Disorder" />
       </td>

       <td>
       <asp:CheckBox ID="ReasonSuicide" runat="server" Text=" Suicide" />
       </td>

   </tr>

   <tr>

       <td>    
       <asp:CheckBox ID="ReasonOther" runat="server" Text=" Other Illness" />
       </td>

       <td>    
       <asp:CheckBox ID="ReasonFrequentCaller" runat="server" Text=" Frequent Caller" />
       </td>

   </tr>

      <tr>

       <td>    
       <asp:CheckBox ID="ReasonAbusePhysicalEmotional" runat="server" Text=" Physical / Emotional Abuse" />
       </td>

       <td>    
              <asp:CheckBox ID="ReasonOtherReason" runat="server" Text=" <b>Other</b>" />
       </td>

       <td>    
              <asp:CheckBox ID="ReasonFollowUp" runat="server" Text=" <b>Follow Up</b>" />
       </td>

   </tr>

   </table>

   </td>
   <td>

<b>Referals</b>
   <table border="0" width="100%">
   <tr>
   
       <td>    
       <asp:CheckBox ID="ReferDASGFaceToFace" runat="server"   Enabled="false" ToolTip="Option Discontinued" Text="SADAG Face to Face" />
       </td>

       <td>
       <asp:CheckBox ID="ReferRapeCrisis" runat="server"  Enabled="false" ToolTip="Option Discontinued" Text=" Rape Crisis" />
       </td>

    </tr>
    <tr>

       <td>    
       <asp:CheckBox ID="ReferGP" runat="server" Text=" General Practitioner" />
       </td>

       <td>
       <asp:CheckBox ID="ReferRehabilitationCentre" runat="server" Text=" Rehabilitation Centre" />
       </td>

    </tr>
    <tr>

       <td>    
       <asp:CheckBox ID="ReferGovHospital" runat="server" Text=" Government Hospital / Clinic" />
       </td>

       <td>
       <asp:CheckBox ID="ReferShelter" runat="server" Text=" Shelter" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReferLiteratureWebsite" runat="server" Text=" Literature / Website" />
       </td>

       <td>
       <asp:CheckBox ID="ReferSocialWorker" runat="server" Text=" Social Worker" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReferNone" runat="server" Text=" None" />
       </td>

       <td>
       <asp:CheckBox ID="ReferSupportGroup" runat="server" Text=" Support Group" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReferOther" runat="server" Text=" Other" />
       </td>

       <td>
            <asp:CheckBox ID="ReferTraumaCentre" runat="server" Text=" Trauma Centre" />
       </td>

   </tr>

    <tr>

       <td>    
       <asp:CheckBox ID="ReferOtherNGOHelpline" runat="server" Text=" Other NGO / Helpline" />
       </td>

       <td>
       <asp:CheckBox ID="ReferSADAGHelpLine" runat="server" Text=" <b>SADAG Helpline</b>" />
       </td>

   </tr>


      <tr>

       <td>    
       <asp:CheckBox ID="ReferPoliceStation" runat="server" Text=" Police Station" />
       </td>

       <td>
       <asp:CheckBox ID="ReferSelfHelp" runat="server" Text=" <b>Self Help</b>" />
       </td>

   </tr>

   <tr>

       <td>    
       <asp:CheckBox ID="ReferPrivateHospital" runat="server" Text=" Private Hospital / Clinic" />
       </td>

       <td>
       <asp:CheckBox ID="ReferUber" runat="server" Text=" <b>Uber</b>" />
       </td>

   </tr>

   <tr>

       <td>    
       <asp:CheckBox ID="ReferPsychiatrist" runat="server" Text=" Psychiatrist" />
       </td>

       <td>
       </td>

   </tr>

   <tr>

       <td>    
       <asp:CheckBox ID="ReferPsycologist" runat="server" Text=" Psychologist" />
       </td>

       <td>
       </td>
       
   </tr>

          <tr>

       <td>    
       <asp:CheckBox ID="ReferUniversityStudentWellness" runat="server" Text=" <b>University Student Wellness</b>" />
       </td>

       <td>
       </td>
       
   </tr>

      <tr>

       <td>    
              &nbsp;
       </td>

       <td>

       </td>

   </tr>

   <tr>

       <td>    
              &nbsp;
       </td>

       <td>

       </td>

   </tr>

   <tr>

       <td>    
       &nbsp;
       </td>

       <td>
       </td>

   </tr>


   </table>

   </td>
   </tr>
   </table>

   <b>Call Summary</b><br/>
   <asp:TextBox ID="CallSummary" runat="server" TextMode="MultiLine" MaxLength="10000" Rows="10" Width="100%" TabIndex="29"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="CallSummary" ErrorMessage="Call Summary is a required field." 
        SetFocusOnError="True" ToolTip="Call Summary is a required field"></asp:RequiredFieldValidator>
    <br />

    
       <b>Action Points</b><br/>
   <asp:TextBox ID="ActionPoints" runat="server" TextMode="MultiLine" MaxLength="10000" Rows="10" Width="100%" TabIndex="29">1.
2.
3.
4.
5.</asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
        ControlToValidate="ActionPoints" ErrorMessage="Action Points is a required field." 
        SetFocusOnError="True" ToolTip="Action Points is a required field"></asp:RequiredFieldValidator>
    <br />

    <b><asp:Label ID="LblFeedback" runat="server" Text=""></asp:Label></b>
    <br/>      

    <asp:Button ID="Button1" runat="server" Text="Submit Call" TabIndex="30" ToolTip="Click here to submit call" />

    <br />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        ProviderName="<%$ ConnectionStrings:DAISYConnectionString1.ProviderName %>" SelectCommand="" >
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        SelectCommand="SELECT * FROM [AgeGroups]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="SELECT * FROM [HelpLines]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        SelectCommand="SELECT * FROM [DLLocations] order by Location aSC"></asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        SelectCommand="SELECT * FROM [DLTypes] order by Type ASC"></asp:SqlDataSource>

                <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        SelectCommand="SELECT * FROM [DLSources] order by Source ASC"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        SelectCommand="SELECT * FROM [DLTimes] order by [Time] ASC "></asp:SqlDataSource>

    <asp:CustomValidator ID="CustomValidator1" runat="server"  
        ControlToValidate="CallSummary" 
        ErrorMessage="Call Summary must be at least 100 characters in length." 
        ClientValidationFunction="CheckLength" Display="None" 
        ValidateEmptyText="True" SetFocusOnError="True"
        ></asp:CustomValidator>

          <asp:CustomValidator ID="CustomValidator2" runat="server"  
        ControlToValidate="ActionPoints" 
        ErrorMessage="Action Points must be at least 50 characters in length." 
        ClientValidationFunction="CheckActionPointsLength" Display="None" 
        ValidateEmptyText="True" SetFocusOnError="True"
        ></asp:CustomValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />


<script lang="JavaScript" type="text/javascript">
<!--
    function CheckLength(sender, args) {
        args.IsValid = (args.Value.length >= 100);

    }

    function CheckActionPointsLength(sender, args) {
        args.IsValid = (args.Value.length >= 50);

    }

    function ValidCallReasonChecked(sender, args) {

        var v = document.getElementById("MainContent_ReasonADHD").checked
            || document.getElementById("MainContent_ReasonPND").checked
            || document.getElementById("MainContent_ReasonAlzheimersDementia").checked
             || document.getElementById("MainContent_ReasonPregnancy").checked
             || document.getElementById("MainContent_ReasonAnxiety").checked
             || document.getElementById("MainContent_ReasonPSTDTrauma").checked
             || document.getElementById("MainContent_ReasonBipolar").checked
             || document.getElementById("MainContent_ReasonReationshipDomesticAbuse").checked
             || document.getElementById("MainContent_ReasonBorderlinePersonalityDisorder").checked
             || document.getElementById("MainContent_ReasonBullying").checked
             || document.getElementById("MainContent_ReasonSchizophrenia").checked
             || document.getElementById("MainContent_ReasonDebtPovertyUnemployment").checked
             || document.getElementById("MainContent_ReasonSelfMutilation").checked
             || document.getElementById("MainContent_ReasonDepression").checked
             || document.getElementById("MainContent_ReasonSexualAbuseRape").checked
             || document.getElementById("MainContent_ReasonEatingDisorder").checked
             || document.getElementById("MainContent_ReasonSexuality").checked
             || document.getElementById("MainContent_ReasonHIVAIDS").checked
             || document.getElementById("MainContent_ReasonSleepingDisorder").checked
             || document.getElementById("MainContent_ReasonInformation").checked
             || document.getElementById("MainContent_ReasonSocialPhobia").checked
             || document.getElementById("MainContent_ReasonLoss").checked
             || document.getElementById("MainContent_ReasonStress").checked
             || document.getElementById("MainContent_ReasonNone").checked
             || document.getElementById("MainContent_ReasonSubstanceAbuse").checked
             || document.getElementById("MainContent_ReasonOCD").checked
             || document.getElementById("MainContent_ReasonSuicide").checked
             || document.getElementById("MainContent_ReasonOther").checked
             || document.getElementById("MainContent_ReasonFrequentCaller").checked
             || document.getElementById("MainContent_ReasonAbusePhysicalEmotional").checked

             || document.getElementById("MainContent_ReasonOtherReason").checked
             || document.getElementById("MainContent_ReasonFollowUp").checked
        ;


        if (v) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }


    }


// -->
</script>


</asp:Content>





 


