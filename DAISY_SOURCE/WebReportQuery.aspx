 <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="WebReportQuery.aspx.vb" Inherits="WebApplication1.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Call Report</h2>
    <h3>Please enter and select filter criteria:</h3>
    <br/>

    <table border='0' width='100%'> 
    <tr><td>

        <table border="0"  >
        <tr><td>
        First name: 
        </td>
        <td>
        <asp:TextBox ID="Firstname" runat="server"
            TabIndex="1" MaxLength="100" ></asp:TextBox>


        </td>

       <td>   
        Surname: 
            </td>
        <td>
            <asp:TextBox ID="Surname" runat="server" TabIndex="2" MaxLength="100"></asp:TextBox>

        </td>


        </tr>


<tr>
<td>
Reason for Call:</td><td><asp:DropDownList ID="ReasonForCall" runat="server" TabIndex="3" Width="75%"  >
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="ReasonADHD">ADHD</asp:ListItem>
            <asp:ListItem Value="ReasonAlzheimersDementia">Alzheimers / Dementia</asp:ListItem>
            <asp:ListItem Value="ReasonAnxiety">Anxiety / Panic </asp:ListItem>
            <asp:ListItem Value="ReasonBipolar">Bipolar</asp:ListItem>
            <asp:ListItem Value="ReasonBorderlinePersonalityDisorder">Borderline Personality Disorder</asp:ListItem>
            <asp:ListItem Value="ReasonBullying">Bullying</asp:ListItem>
            <asp:ListItem Value="ReasonDebtPovertyUnemployment">Debt / Poverty / Unemployment</asp:ListItem>
            <asp:ListItem Value="ReasonDepression">Depression</asp:ListItem>
            <asp:ListItem Value="ReasonEatingDisoirder">Eating Disorder</asp:ListItem>
            <asp:ListItem Value="ReasonHIVAIDS">HIV / AIDS</asp:ListItem>
            <asp:ListItem Value="ReasonInformation">Information</asp:ListItem>
            <asp:ListItem Value="ReasonLossGriefLoneliness">Loss / Grief / Loneliness</asp:ListItem>
            <asp:ListItem Value="ReasonNone">None</asp:ListItem>
            <asp:ListItem Value="ReasonOCD">Obsessive Compulsive Disorder </asp:ListItem>
            <asp:ListItem Value="ReasonOtherIllness">Other Illness</asp:ListItem>
            <asp:ListItem Value="ReasonPhysicalEmotionalAbuse">Physical / Emotional Abuse</asp:ListItem>
            <asp:ListItem Value="ReasonPostNatalDepression">Post Natal Depression</asp:ListItem>
            <asp:ListItem Value="ReasonPregnancy">Pregnancy</asp:ListItem>
            <asp:ListItem Value="ReasonPTSDTrauma">PTSD / Trauma</asp:ListItem>
            <asp:ListItem Value="ReasonRelationshipDomesticAbuse">Relationship - Domestic Abuse (Legacy)</asp:ListItem>
            <asp:ListItem Value="ReasonRelationshipFamilyIssues">Relationship - Family Issues</asp:ListItem>
            <asp:ListItem Value="ReasonRelationshipRomanticIssues">Relationship - Romantic Issues</asp:ListItem>
            <asp:ListItem Value="ReasonSchizophrenia">Schizophrenia</asp:ListItem>
            <asp:ListItem Value="ReasonSelfMutilation">Self Mutilation</asp:ListItem>
            <asp:ListItem Value="ReasonSexualAbuseRape">Sexual Abuse / Rape </asp:ListItem>
            <asp:ListItem Value="ReasonSexuality">Sexuality</asp:ListItem>
            <asp:ListItem Value="ReasonSleepingDisorder">Sleeping Disorder</asp:ListItem>
            <asp:ListItem Value="ReasonSocialPhobia">Social Phobia</asp:ListItem>
            <asp:ListItem Value="ReasonStress">Stress</asp:ListItem>
            <asp:ListItem Value="ReasonSubstanceAbuse">Substance Abuse</asp:ListItem>
            <asp:ListItem Value="ReasonSuicide">Suicide</asp:ListItem>
            <asp:ListItem Value="ReasonFrequentCaller">Frequent Caller</asp:ListItem>
</asp:DropDownList></td>

        <td>   
        Age Group:
        </td>
        <td>
            <asp:DropDownList ID="AgeGroup" runat="server" DataSourceID="SqlDataSource2" 
                DataTextField="Group" DataValueField="Group" TabIndex="4">

            </asp:DropDownList>

            </td>
</tr>

<tr>

        <td>
        City: 
        </td>
        <td>
        <asp:TextBox ID="City" runat="server" TabIndex="5" ></asp:TextBox>
        </td>


        <td>
        Province: 
        </td>
        <td>
        <asp:DropDownList ID="ddlProvince" runat="server" TabIndex="6">
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
        
        </tr>

                </tr>

        <tr><td>    
        Gender:
        </td>
        <td>
        <asp:DropDownList ID="Gender" runat="server" TabIndex="7">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="M">Male</asp:ListItem>
            <asp:ListItem Value="F">Female</asp:ListItem>
        </asp:DropDownList>
            </td>

            <td>    
            Race:
            </td>
            <td>
                <asp:DropDownList ID="Race" runat="server" TabIndex="8">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="Black">Black</asp:ListItem>
                    <asp:ListItem Value="White">White</asp:ListItem>
                    <asp:ListItem Value="Coloured">Coloured</asp:ListItem>
                    <asp:ListItem Value="Indian">Indian</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>

         <tr><td>    
        Counsellor:
        </td>
        <td>
        <asp:DropDownList ID="Counsellor" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="Counsellor" DataValueField="Counsellor" TabIndex="9" Width="75%" >
                </asp:DropDownList>
        </td>

        <td>    
        Telephone:
        </td>
        <td>
        <asp:TextBox ID="Telephone" runat="server" TabIndex="10" MaxLength="10">
                </asp:TextBox>

        </td>

            
        </tr>

        <tr>
        <td><nobr>From: (yyyy-mm-dd)
            </td>
            <td>

                <asp:TextBox ID="StartDate" runat="server" MaxLength="10" TabIndex="11"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="..." CausesValidation="False" />
                <br><span style="height:0;width:0;position:absolute" >
                                <asp:Calendar ID="CalendarStartDate" runat="server" visible="false"  Height="45px" Width="200px" 
                BackColor="White" BorderColor="#999999" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="Black">
                <%--<DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle ForeColor="Black" />
                <WeekendDayStyle BackColor="#CCCCFF" />--%>
            </asp:Calendar>
                </span>
            </td>

                   <td><nobr>To: (yyyy-mm-dd)
            </td>
            <td>
                <asp:TextBox ID="EndDate" runat="server" MaxLength="10" TabIndex="12"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="..." CausesValidation="False" />
                <br><span style="height:0;width:0;position:absolute" >
                                <asp:Calendar ID="CalendarEndDate" runat="server" visible="false"  Height="45px" Width="200px" 
                BackColor="White" BorderColor="#999999" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="Black">
               <%-- <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle ForeColor="Black" />
                <WeekendDayStyle BackColor="#CCCCFF" />--%>
            </asp:Calendar>
                </span>
            </td>

        </tr>

        <tr>

            <td ><nobr>Enter a Search Phrase:</td>          
            <td ><asp:TextBox ID="CallSummarySearch" runat="server" MaxLength="100" Width="75%" TabIndex="13"></asp:TextBox></td>

            <td>   
            Occupation:
            </td>
        
            <td>
            <asp:DropDownList ID="DropDownListOccupation" runat="server" DataSourceID="SqlDataSource3"  Width="75%"
                DataTextField="Occupation" DataValueField="Occupation" TabIndex="14" >

            </asp:DropDownList>

            </td>
          

        </tr>

        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>

             <td>
                Helpline:
            </td>
            <td>
                <asp:DropDownList ID="HelpLine" runat="server" TabIndex="17"  DataSourceID="SqlDataSource4"  DataTextField="Helpline" DataValueField="Helpline" >
                </asp:DropDownList>
            </td>

        </tr>



        <tr>            
            <td>&nbsp;</td>
        </tr>

        <tr>            
            <td colspan="2" ><asp:CheckBox ID="ChkShortReport" runat="server" Checked="false" TabIndex="18" />List Summary details only</td>
        </tr>

<%--                <tr>            
            <td colspan="2" ><asp:CheckBox ID="ChckExportToCSV" runat="server" Checked="false" TabIndex="18" />Export to CSV for Excel Analytics</td>
        </tr>--%>
      
        </table>

    </td></tr>

</table>

    <asp:Label ID="lblFeedback" runat="server" BorderColor="Black"></asp:Label>

    <br />

    <asp:Button ID="SubmitQuery" runat="server" Text="Submit Query" />


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        ProviderName="<%$ ConnectionStrings:DAISYConnectionString1.ProviderName %>" SelectCommand="Select * from [counsellors] " >
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        SelectCommand="SELECT * FROM [AgeGroups]"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="SELECT * FROM [HelpLines]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        SelectCommand="SELECT Distinct Occupation from [Callers] order by Occupation"></asp:SqlDataSource>

    <asp:CustomValidator ID="CustomValidator1" runat="server" 
        ErrorMessage="Valid Start Date must be specified. YYYY-MM-DD" 
        ClientValidationFunction="CheckDate" Display="None" 
        ValidateEmptyText="True" SetFocusOnError="True"
        ControlToValidate="StartDate"></asp:CustomValidator>

    <asp:CustomValidator ID="CustomValidator2" runat="server" 
        ErrorMessage="Valid End Date must be specified. YYYY-MM-DD" 
        ClientValidationFunction="CheckDate" Display="None" 
        ValidateEmptyText="True" SetFocusOnError="True"
        ControlToValidate="EndDate"></asp:CustomValidator>

    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Start date must be less than or equal to End date." ControlToValidate="StartDate" ControlToCompare="EndDate" SetFocusOnError="True" Operator="LessThanEqual" Text="Start date must be less than or equal to End date." Display="None">
    </asp:CompareValidator>

    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="End date must be greater than or equal to Start date." ControlToValidate="EndDate" ControlToCompare="StartDate" SetFocusOnError="True" Operator="GreaterThanEqual" Text="End date must be geater than or equal to Start date." Display="None">
    </asp:CompareValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid phrase to search for (No Special Characters)." ControlToValidate="CallSummarySearch" ValidationExpression ="[A-z ]{0,100}"  SetFocusOnError="True" Display="None" />

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />


    <script language="JavaScript" type="text/javascript">
    <!--
        function CheckDate(sender, args) {

            // There must be a length of 10 or 0
            if ((args.Value.length == 0)) {
                args.IsValid = true;

            }
            else if (args.Value.length < 10) {
                args.IsValid = false;
            }
            else 
            {
                // Its the right length but now we need to validate the numbers
                args.IsValid = false;

                var a = new String(args.Value.toString());

                if (a.indexOf('-') == 4) {

                    if (a.lastIndexOf('-') == 7) { 

                        if (!isNaN(a.substring(0,4).toString()))
                        {

                            if (!isNaN(a.substring(5, 7).toString())) {


                                if (!isNaN(a.substring(8, 10).toString())) {

                                    args.IsValid = true;

                                }  

                            }                    
                        }
                
                    }

                }
 


            }

        }
    // -->
    </script>


 </asp:Content>
