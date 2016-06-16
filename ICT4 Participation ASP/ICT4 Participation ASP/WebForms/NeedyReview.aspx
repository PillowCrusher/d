<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyReview.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">


    <form runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <div>
        <asp:Label ID="VrijwilligerLabel" runat="server" Text="Selecteer hier een vrijwilliger om te beoordelen"></asp:Label>
        </div>
        <asp:ListBox ID="VrijwilligerListBox" runat="server" OnSelectedIndexChanged="VrijwilligerListBox_SelectedIndexChanged"></asp:ListBox>
        <asp:TextBox ID="inputReview" runat="server" class="form-control" TextMode="MultiLine" placeholder="Plaats hier uw beoordeling over de vrijwilliger"></asp:TextBox>
        <asp:Button ID="btnPlaats" runat="server" Text="Plaats recensie" OnClick="btnPlaats_Click" />
        <asp:Button ID="btnAfsluiten" runat="server" Text="Sluit hulpvraag af" OnClick="btnAfsluiten_Click" />
    </div>
    </form>
</asp:Content>
