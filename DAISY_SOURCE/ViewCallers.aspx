<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewCallers.aspx.vb" Inherits="WebApplication1.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <H2>View Callers</H2>
<H3>Please enter and select search criteria:</H3>
<br>
<table border =0 >
<tr>
<td>
    First name:</td><td><asp:TextBox ID="Firstname" runat="server" TabIndex="1"></asp:TextBox>
</td>

<td>
    Race:</td><td>    <asp:DropDownList ID="Race" runat="server" TabIndex="3">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="Black">Black</asp:ListItem>
            <asp:ListItem Value="White">White</asp:ListItem>
            <asp:ListItem Value="Coloured">Coloured</asp:ListItem>
            <asp:ListItem Value="Indian">Indian</asp:ListItem>
            <asp:ListItem Value="Other">Other</asp:ListItem>
    </asp:DropDownList>
</td>

<td>
    Province:</td><td>    <asp:DropDownList ID="Province" runat="server" TabIndex="5">
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
            <asp:ListItem Value="Northern Province">Northern Province</asp:ListItem>
            <asp:ListItem Value="Other Country">Other Country</asp:ListItem>
        </asp:DropDownList>
    </td>
</td>

<tr>

<td>
Surname:</td><td><asp:TextBox ID="Surname" runat="server" TabIndex="2"></asp:TextBox>
</td>

<td>
    Gender:</td><td>    
    <asp:DropDownList ID="Gender" runat="server" TabIndex="4">
        <asp:ListItem Value=""></asp:ListItem>
        <asp:ListItem Value="M">Male</asp:ListItem>
        <asp:ListItem Value="F">Female</asp:ListItem>
    </asp:DropDownList>
</td>

<td>
    Age:</td><td>
        <asp:DropDownList ID="Age" runat="server" 
            DataSourceID="SqlDataSource2" DataTextField="Group" DataValueField="Group">
        </asp:DropDownList>
</td>


</tr>
</table>
<asp:Button ID="Submit" runat="server" Text="Query Callers" />

<hr>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    BorderStyle="Solid" Caption="Caller Information" DataKeyNames="CallerId" 
    DataSourceID="SqlDataSource1"
    EmptyDataText="There are no callers to display." AllowPaging="True" 
        AllowSorting="True" EnableSortingAndPagingCallbacks="True" BorderWidth="4px"
    >
    <Columns>
        <asp:BoundField DataField="Callerid" HeaderText="Callerid" ReadOnly="True" 
            SortExpression="Callerid" visible="false"  />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Surname" HeaderText="Surname" 
            SortExpression="Surname" />
        <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
        <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
        <asp:BoundField DataField="Telephone1" HeaderText="Telephone1" 
            SortExpression="Telephone1" />
        <asp:BoundField DataField="Telephone2" HeaderText="Telephone2" 
            SortExpression="Telephone2" />
        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" 
            SortExpression="EmailAddress" />
        <asp:BoundField DataField="CallDate" HeaderText="CallDate" ReadOnly="True" 
            SortExpression="CallDate" />
        <asp:BoundField DataField="Reasons" HeaderText="Reasons" ReadOnly="True" 
            SortExpression="Reasons" />

    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="SELECT dbo.Callers.*, dbo.Calls.CallDate, '' as [Reasons]
                      FROM dbo.Callers INNER JOIN
                      dbo.Calls ON dbo.Callers.CALLERID = dbo.Calls.CALLERID                     
"></asp:SqlDataSource>
<br />
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="SELECT * FROM [AgeGroups]"></asp:SqlDataSource>
<br />

</asp:Content>
