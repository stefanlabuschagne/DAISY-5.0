<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2.aspx.vb" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Surname" HeaderText="Surname" 
                SortExpression="Surname" />
            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
            <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
            <asp:BoundField DataField="Race" HeaderText="Race" SortExpression="Race" />
            <asp:BoundField DataField="MedicalAid" HeaderText="MedicalAid" 
                SortExpression="MedicalAid" />
            <asp:BoundField DataField="Medication" HeaderText="Medication" 
                SortExpression="Medication" />
            <asp:BoundField DataField="Address" HeaderText="Address" 
                SortExpression="Address" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="Province" HeaderText="Province" 
                SortExpression="Province" />
            <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" 
                SortExpression="PostalCode" />
            <asp:BoundField DataField="Telephone1" HeaderText="Telephone1" 
                SortExpression="Telephone1" />
            <asp:BoundField DataField="Telephone2" HeaderText="Telephone2" 
                SortExpression="Telephone2" />
            <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" 
                SortExpression="EmailAddress" />
            <asp:BoundField DataField="Counsellor" HeaderText="Counsellor" 
                SortExpression="Counsellor" />
            <asp:BoundField DataField="CallDate" HeaderText="CallDate" 
                SortExpression="CallDate" />
            <asp:BoundField DataField="Reasons" HeaderText="Reasons" 
                SortExpression="Reasons" />
            <asp:BoundField DataField="Referrals" HeaderText="Referrals" 
                SortExpression="Referrals" />
            <asp:BoundField DataField="CallSummary" HeaderText="CallSummary" 
                SortExpression="CallSummary" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
        ProviderName="<%$ ConnectionStrings:DAISYConnectionString1.ProviderName %>" 
        SelectCommand="SELECT [Name], [Surname], [Age], [Sex], [Race], [MedicalAid], [Medication], [Address], [City], [Province], [PostalCode], [Telephone1], [Telephone2], [EmailAddress], [Counsellor], [CallDate], [Reasons], [Referrals], [CallSummary] FROM [Calls]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
