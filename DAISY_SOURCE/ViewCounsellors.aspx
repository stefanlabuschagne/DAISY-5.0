<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewCounsellors.aspx.vb" Inherits="WebApplication1.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DAISYConnectionString1 %>" 
    ProviderName="<%$ ConnectionStrings:DAISYConnectionString1.ProviderName %>" 
    SelectCommand="SELECT [Counsellor] FROM [Counsellors] where [Active] = 1">
</asp:SqlDataSource>
<h2>Active Counsellors</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Counsellor" DataSourceID="SqlDataSource1"
        
       SelectedRowStyle-ForeColor="White" 
       SelectedRowStyle-BackColor="#4B6C9E" 

      GridLines="None"
      BorderWidth = "1"
       Width="100%"
        CellPadding="2"
        AllowPaging = "true"

    CaptionAlign="Left" 

    EmptyDataText="There are no Counsellors to display." 
    AllowSorting= "true"
    AlternatingRowStyle-Wrap="False"        


    PageSize="15"  >
       
     
        <Columns>

                    <asp:BoundField DataField="Counsellor" ReadOnly="True" 
                SortExpression="Counsellor" />

        </Columns>
    </asp:GridView>

</asp:Content>
