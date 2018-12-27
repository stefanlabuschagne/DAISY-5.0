<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SearchCallers.aspx.vb" Inherits="WebApplication1.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <H2>Edit Caller</H2>
<H3>Please enter and select search criteria:</H3>
<Br>
<table border =0 >
<tr>
<td>
    First name:</td><td><asp:TextBox ID="Firstname" runat="server" TabIndex="1"></asp:TextBox>
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
            <asp:ListItem Value="Other Country">Other Country</asp:ListItem>
        </asp:DropDownList>
    </td>
</td>


<tr>

<td>
Surname:</td><td><asp:TextBox ID="Surname" runat="server" TabIndex="2"></asp:TextBox>
</td>

<td>
Telephone:</td><td><asp:TextBox ID="Telephone" runat="server" TabIndex="2"></asp:TextBox>
</td>


</tr>
</table>
<asp:Button ID="Submit" runat="server" Text="Search Caller" />

<hr>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    BorderStyle="Solid" Caption="Search Results: (Click on the column hearders to sort)" DataKeyNames="CALLERID" 
    DataSourceID="SqlDataSource1"
    EmptyDataText="There are no callers to display." AllowPaging="True" 
        AllowSorting="True"
    AlternatingRowStyle-Wrap="False"        
       onselectedindexchanged="CallersGridView_SelectedIndexChanged"    
    AutoGenerateSelectButton="True" CaptionAlign="Left" BorderWidth="2px"
        SelectedRowStyle-ForeColor="White" SelectedRowStyle-BackColor="#4B6C9E" 
        CellPadding="2"
        
        Width="100%"
        
        >

    <Columns>

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

        <asp:BoundField DataField="CallerID" HeaderText="CallerID" ReadOnly="True" 
            SortExpression="CallerID"  />

        <asp:BoundField DataField="CallID" HeaderText="CallID" ReadOnly="True" 
            SortExpression="CallID"  />

    </Columns>

 

</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="" FilterExpression=""></asp:SqlDataSource>
<br />
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    SelectCommand="SELECT * FROM [AgeGroups]"></asp:SqlDataSource>
<br />
    <asp:Button
        ID="btnEditCall" runat="server" Text="Edit Call" Enabled="False" />

    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
    </asp:Content>

