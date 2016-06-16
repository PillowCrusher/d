<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="SeeVolunteers.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.SeeVolunteers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <div>
        <asp:Label ID="vrijwilligersLabel" runat="server" Text="Vrijwilligers"></asp:Label>
        </div>
        <asp:ListBox ID="vrijwilligersListBox" runat="server" OnSelectedIndexChanged="vrijwilligersListBox_SelectedIndexChanged"></asp:ListBox>
        <div>
        <asp:Label ID="RecensiesLabel" runat="server" Text="Recensies"></asp:Label>
        </div>
        <asp:ListBox ID="RecensiesListBox" runat="server" OnSelectedIndexChanged="RecensiesListBox_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="AcceptButton" runat="server" Text="Accepteer vrijwilliger " CssClass="btn btn-lg btn-primary btn-block" OnClick="AcceptButton_Click"  />
        <asp:Button ID="DenyButton" runat="server" Text="Wijs vrijwilliger af" CssClass="btn btn-lg btn-primary btn-block" OnClick="DenyButton_Click"  />
    </div>
</asp:Content>
