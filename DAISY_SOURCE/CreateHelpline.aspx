<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateHelpline.aspx.vb" Inherits="WebApplication1.CreateHelpline" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<H2>Create Helpline</H2>

    <table>
<tr>
<td>
Add new Helpline:
</td>
<td>
<asp:TextBox ID="NewHelpline" runat="server" MaxLength=100 ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Helpline description required" ControlToValidate="NewHelpline" ToolTip="Helpline description is required" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
</td>
</tr>

<%--        <tr><td></td>
            <td><asp:CheckBox ID="CheckBoxConfirm" runat="server" Text="I am autherized to add a helpline to Daisy" /></td>
        </tr>--%>
<tr>
<td>
<asp:Button ID="Button1" runat="server" Text="Add Helpline" Width="119px" />
</td>
</tr>
</table>
<asp:Label ID="LblFeedback" runat="server" Text=""></asp:Label>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="false" ShowSummary="true" />


<%--    <asp:CustomValidator ID="CustomValidator2" runat="server"   EnableClientScript="true"
        ControlToValidate="CheckBoxConfirm" 
        ErrorMessage="Check to confirm that you are authorized to add a HelpLine" 
        ClientValidationFunction="ConfirmNewHelplineYN" Display="Static" 
        SetFocusOnError="True"
        >You must select this box to proceed.</asp:CustomValidator>--%>

    <asp:CustomValidator ID="CustomValidator1" runat="server"   
        ControlToValidate="NewHelpline" 
        ErrorMessage="Helpline must be at least 10 characters in length." 
        ClientValidationFunction="ConfirmNewHelplinelength" Display="None" 
        ValidateEmptyText="false" SetFocusOnError="True"
        ></asp:CustomValidator>



    <script lang="JavaScript" type="text/javascript">
    <!--
        function ConfirmNewHelplinelength(sender, args) {

            args.IsValid = args.Value.length >= 10;

        }
  
        function ConfirmNewHelplineYN(sender, args) {

            args.IsValid = true;

        }

    // -->
    </script>


</asp:Content>
