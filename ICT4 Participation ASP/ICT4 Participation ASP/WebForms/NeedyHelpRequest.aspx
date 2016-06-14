<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyHelpRequest.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyHelpRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form id="form1" runat="server">
    <div class="container col-lg-4">
        
        <asp:TextBox id="inputTitle" CssClass="form-control" placeholder="Titel" required autofocus runat="server"></asp:TextBox>

        <asp:TextBox runat="server" ID="inputText" TextMode="MultiLine" placeholder="Beschrijving" CssClass="form-control"></asp:TextBox>
        <asp:TextBox runat="server" ID="inputLocation" placeholder="Lokatie" CssClass="form-control"></asp:TextBox>
        <p></p>
        
        <div class="form-group">
            <p>Start datum en tijd</p>
            <asp:TextBox runat="server" ID="inputStartDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:TextBox runat="server" ID="inputStartTime" TextMode="Time" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <p>Eind datum en tijd</p>
            <asp:TextBox runat="server" ID="inputEndDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:TextBox runat="server" ID="inputEndTime" TextMode="Time" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="inputRijbewijs" class="sr-only checkbox-inline">Rijbewijs</label>
            <asp:CheckBox runat="server" ID="cbDrivingLicence" CssClass="checkbox-inline" Text="Rijbewijs"/>
            <label for="inputUrgent" class="sr-only checkbox-inline">Urgent</label>
            <asp:CheckBox runat="server" ID="cbUrgent" CssClass="checkbox-inline" Text="Urgent"/>
            <label for="inputKennisMaken" class="sr-only checkbox-inline">Kennis maken</label>
            <asp:CheckBox runat="server" ID="cbMeeting" CssClass="checkbox-inline" Text="Kennis maken"/>
        </div>
        <asp:DropDownList runat="server" ID="skillsList" placeholder="Skills" CssClass="form-control" />

        <asp:Button runat="server" ID="btnSendHelpRequest" CssClass="btn btn-lg btn-primary btn-block" Text="Versturen" />
    </div>
    </form>
    </asp:Content>
