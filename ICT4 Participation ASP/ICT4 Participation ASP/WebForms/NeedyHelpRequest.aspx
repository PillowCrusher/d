<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyHelpRequest.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyHelpRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form id="form1" runat="server">
    <div class="container col-lg-4">
        
        <asp:TextBox id="inputTitle" CssClass="form-control" placeholder="Titel" required autofocus runat="server"></asp:TextBox>

        <asp:TextBox runat="server" ID="inputText" TextMode="MultiLine" placeholder="Beschrijving" CssClass="form-control"></asp:TextBox>
        <div>
            <label for="inputRijbewijs" class="sr-only">Rijbewijs</label>
            <asp:CheckBox runat="server" ID="cbDrivingLicence" CssClass="form-control" Text="Rijbewijs"/>
            <label for="inputUrgent" class="sr-only">Urgent</label>
            <asp:CheckBox runat="server" ID="cbUrgent" CssClass="form-control" Text="Urgent"/>
            <label for="inputKennisMaken" class="sr-only">Kennis maken</label>
            <asp:CheckBox runat="server" ID="cbMeeting" CssClass="form-control" Text="Kennis maken"/>
            <asp:TextBox runat="server" ID="inputStartDate" TextMode="DateTime"></asp:TextBox>
            <asp:DropDownList runat="server" ID="skillsList" placeholder="Skills" />
            <asp:Button runat="server" ID="btnSendHelpRequest" CssClass="btn btn-block" Text="Versturen" />
        </div>
    </div>
    </form>
    </asp:Content>
