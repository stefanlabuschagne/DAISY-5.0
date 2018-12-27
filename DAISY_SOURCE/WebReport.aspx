<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/Site.Master"  CodeBehind="WebReport.aspx.vb" Inherits="WebApplication1.WebForm7"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1" Width="100%">
    <asp:TableRow BorderWidth="1"><asp:TableCell><asp:Image ID="Image1" runat="server" ImageUrl="~/SADAG.bmp" /></asp:TableCell><asp:TableCell ColumnSpan="6" ><h2>Call Report<br/><%=Now%></h2></asp:TableCell></asp:TableRow>

        <asp:TableRow></asp:TableRow>
        <asp:TableRow><asp:TableCell><b>Date</b></asp:TableCell><asp:TableCell><b>Name</b></asp:TableCell><asp:TableCell><b>Sex</b></asp:TableCell><asp:TableCell><b>Race</b></asp:TableCell><asp:TableCell><nobr/><b>City / Town</asp:TableCell><asp:TableCell><b>Province</asp:TableCell><asp:TableCell><b>Age</asp:TableCell><asp:TableCell><nobr><b>Medication</asp:TableCell><asp:TableCell><nobr><b>Phone Day</asp:TableCell><asp:TableCell><nobr><b>Phone Cell</b></asp:TableCell></asp:TableRow>
        <asp:TableRow></asp:TableRow>

    </asp:Table>


    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="SELECT dbo.Callers.*, dbo.Calls.CallDate
                      FROM dbo.Callers INNER JOIN
                      dbo.Calls ON dbo.Callers.CALLERID = dbo.Calls.CALLERID
                      where dbo.Callers.callerid = 0
"></asp:SqlDataSource>


</asp:Content>
