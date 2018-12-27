<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/Site.Master"  CodeBehind="WebReport.aspx_BAK.aspx.vb" Inherits="WebApplication1.WebForm7"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="0" 
        Width="100%">
    <asp:TableRow BorderWidth="1"><asp:TableCell><asp:Image ID="Image1" runat="server" ImageUrl="~/SADAG.bmp" /></asp:TableCell><asp:TableCell ColumnSpan=6 ><H2>Call Report<BR><%=Now%></H2></asp:TableCell></asp:TableRow>

    <asp:TableRow></asp:TableRow>
    <asp:TableRow><asp:TableCell><b>Date</asp:TableCell><asp:TableCell><b>Name</asp:TableCell><asp:TableCell><b>Sex</asp:TableCell><asp:TableCell><B>Race</asp:TableCell><asp:TableCell><nobr><b>City / Town</asp:TableCell><asp:TableCell><b>Province</asp:TableCell><asp:TableCell><b>Age</asp:TableCell><asp:TableCell><nobr><b>Medication</asp:TableCell><asp:TableCell><nobr><b>Phone Day</asp:TableCell><asp:TableCell><nobr><b>Phone Cell</asp:TableCell></asp:TableRow>
    <asp:TableRow></asp:TableRow>

    </asp:Table>
    

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="SELECT dbo.Callers.*, dbo.Calls.CallDate
                      FROM dbo.Callers INNER JOIN
                      dbo.Calls ON dbo.Callers.CALLERID = dbo.Calls.CALLERID
                      where dbo.Callers.callerid = 0
"></asp:SqlDataSource>


</asp:Content>
