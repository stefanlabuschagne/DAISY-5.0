<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewStats.aspx.vb" Inherits="WebApplication1.WebForm10" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<h1>Caller Frequency Reports: <% Response.Write(Today.Year)  %></h1>

<h2>Caller Frequency per Province</h2>
<br>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="
SELECT     iif([Measure] = 'zTotal:','Total:',[Measure]) as [Measure] ,[Jan],[Feb],[Mar],[Apr],[May],[Jun], [Jul], [Aug], [Sep],[Oct],[Nov],[Dec],[Total]
FROM         dbo.[Stats by Province]
-- ORDER BY Measure
    

"></asp:SqlDataSource>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        Width="600px" EnableViewState="False"  >
    </asp:GridView>

    <% Response.Flush() %>
    
   
  


<h2>Caller Frequency per Race</h2>
<br/>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"  SelectCommandType="Text"
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="
SELECT     iif([Measure] = 'zTotal:','Total:',[Measure]) as [Measure],[Jan],[Feb],[Mar],[Apr],[May],[Jun], [Jul], [Aug], [Sep],[Oct],[Nov],[Dec],[Total]
FROM         dbo.[Stats by Race]
-- ORDER BY Measure

"></asp:SqlDataSource>

    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" 
        Width="600px" EnableViewState="False">
    </asp:GridView>

        <% Response.Flush() %>

<h2>Caller Frequency per Gender</h2>
<br>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="
SELECT     *
FROM         dbo.[Stats by Sex]
ORDER BY Measure


"></asp:SqlDataSource>

    <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3" 
        Width="600px" EnableViewState="False">
    </asp:GridView>

        <% Response.Flush() %>


<h2>Caller Frequency per Call Reason</h2>
<br>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="
SELECT     *
FROM         dbo.[Stats by Disorder]
ORDER BY Measure

"></asp:SqlDataSource>

    <asp:GridView ID="GridView4" runat="server" DataSourceID="SqlDataSource4" 
        Width="600px" EnableViewState="False">
    </asp:GridView>

        <% Response.Flush() %>

    <br/>
    <asp:TextBox ID="CSVPassword" type="password" runat="server" ></asp:TextBox>
    <asp:Button ID="DownloadData" runat="server" Text="Download Raw Data as CSV" /><br/>

      <asp:CustomValidator ID="CustomValidator333" runat="server"
        ControlToValidate="CSVPassword"
        ErrorMessage="Please enter the valid password"
        ClientValidationFunction="ValidPasswordEntered" Display="None"
        ValidateEmptyText="False" SetFocusOnError="True"></asp:CustomValidator>

<%--          <asp:CustomValidator ID="CustomValidator1" runat="server"
        ControlToValidate="CSVPassword"
        ErrorMessage="Please enter the valid password"
        OnServerValidate= "Password_ServerValidate" Display="None"
        ValidateEmptyText="False" SetFocusOnError="True"></asp:CustomValidator>--%>


    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="CSVPassword" ErrorMessage="Please enter the password for download." SetFocusOnError="true"  ></asp:RequiredFieldValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="false" />



    <script lang="JavaScript" type="text/javascript">
<!--

        function ValidPasswordEntered(sender, args) {

            var v = ((args.Value == 'Daisy10') || (args.Value == 'Daisy100'));

            if (v) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }

            // alert(document.getElementById("ctl00$MainContent$CSVPassword").innerText);

            //document.getElementById("ctl00$MainContent$CSVPassword").innerText = '';


        }


        // -->
</script>

      </asp:Content>
