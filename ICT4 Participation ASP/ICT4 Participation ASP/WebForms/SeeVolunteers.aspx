<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="SeeVolunteers.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.SeeVolunteers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form ID="form1" runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <asp:Label ID="vrijwilligersLabel" runat="server" Text="Vrijwilligers"></asp:Label>
        <asp:ListBox ID="vrijwilligersListBox" runat="server"></asp:ListBox>
        <asp:Label ID="RecensiesLabel" runat="server" Text="Recensies"></asp:Label>
        <asp:ListBox ID="RecensiesListBox" runat="server"></asp:ListBox>
        <asp:Button ID="AcceptButton" runat="server" Text="Accepteer vrijwilliger " CssClass="btn btn-lg btn-primary btn-block"  />
        <asp:Button ID="DenyButton" runat="server" Text="Wijs vrijwilliger af" CssClass="btn btn-lg btn-primary btn-block"  />
    </div>
    </form>
</asp:Content>
