<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateCounsellor.aspx.vb" Inherits="WebApplication1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<H2>Create Counsellor</H2>

    <table>
<tr>
<td>
Add new Counsellor:
</td>
<td>
<asp:TextBox ID="NewCounsellor" runat="server" MaxLength=100 >
</asp:TextBox><asp:RequiredFieldValidator
    ID="RequiredFieldValidator1" runat="server" ErrorMessage="Counsellor Name and Surname is required" ControlToValidate="NewCounsellor" ToolTip="Counsellor Name and Surname is required" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Button ID="Button1" runat="server" Text="Add Counsellor" Width="119px" />
</td>
</tr>
</table>
<asp:Label ID="LblFeedback" runat="server" Text=""></asp:Label>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>
