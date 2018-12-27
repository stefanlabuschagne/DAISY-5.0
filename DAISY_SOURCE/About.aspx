<%@ Page Title="About Us" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="About.aspx.vb" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        About Daisy 5.0
    </h1>
    <h2 >
        Latest Updates to Ver 5.0 (4 Nov 2018)
    </h2>
    <p>
        <h3>Call Capturing</h3>
         <ul>
            <li>Added 2 Call Reasons for "Family and Romanitc Relationship Issues" separately.
            <li>Discontinued "Relationship - Domestic Abuse" Call reason.
            <li>Added "Company EAP" and "University Support Services" as Referals.
            <li>Added "Distress Rating" Section.
         </ul>

        <h3>The Call-Report</h3>

        <ul>
        <li>Now has buttons to pick dates from a dropdown. 
        <li>The report shows a total at the bottom, to indicate how many calls were returned from the query.
        <li>The date displayed at the left of each call on the report, is clickable. Click on the link to open the call for viewing / editing on the spot. 
        </ul>
            
        <h3>The Frequency Report</h3>

        <ul>
        <li>Now has totals for all the months and items.</li>
        <li>You can download the raw DAISY data, to create awesome reports in MS Excel Powerpivot.</li>
        <li>Improved layout and headings.</li>
        <li>On the downside. The report takes about 10 seconds+ to open. Just be patient.</li>
        </ul>
    </p>
</asp:Content>
