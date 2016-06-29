<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyReview.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">


    <div class="container col-sm-push-4 col-lg-4">
        <div>
        <asp:Label ID="HelprequestLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
        <asp:Label ID="VrijwilligerLabel" runat="server" Text="Selecteer hier een vrijwilliger om te beoordelen"></asp:Label>
        </div>
        <asp:ListBox ID="VrijwilligerListBox" runat="server"></asp:ListBox>
        <asp:TextBox ID="inputReview" runat="server" class="form-control" TextMode="MultiLine" placeholder="Plaats hier uw beoordeling over de vrijwilliger"></asp:TextBox>
        <asp:Button ID="btnPlaats" runat="server" Text="Plaats recensie" OnClick="btnPlaats_Click" />
        <asp:Button ID="btnAfsluiten" runat="server" Text="Sluit hulpvraag af" OnClientClick="return confirm('Weet je het zeker?')" OnClick="btnAfsluiten_Click" />
    </div>
</asp:Content>
