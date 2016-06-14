<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master"  AutoEventWireup="true" CodeBehind="ProfileVolunteer.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.ProfileVolunteer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form id="form1" runat="server">
        <div class="container col-sm-push-4 col-lg-4">
        <p>Gebruikersnaam: </p>
        <asp:Label ID="UserNameLabel" runat="server" Text="Label"></asp:Label>
        <p>Email: </p>
        <asp:Label ID="EmailLabel" runat="server" Text="Label"></asp:Label>
        <p>Naam: </p>
        <asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label>
        <label for="inputAdres" class="sr-only">Adres</label>
        <asp:TextBox ID="inputAdres" class="form-control" placeholder="Adres"  runat="server"></asp:TextBox>
        <label for="inputCity" class="sr-only">Woonplaats</label>
        <asp:TextBox ID="inputCity" class="form-control" placeholder="City" runat="server"></asp:TextBox>
        <label for="inputPhonenumber" class="sr-only">Telefoon nummer</label>
        <asp:TextBox ID="inputPhonenumber" class="form-control" placeholder="Phonenumber" runat="server"></asp:TextBox>
        <asp:Label ID="labelDrviningLincense" runat="server" Text="Rijbewijs in bezit"></asp:Label><br>
        <asp:CheckBox ID="inputDrivingLincense"  runat="server" /><br>
        <asp:Label ID="labelCar" runat="server" Text="Auto in bezit"></asp:Label><br>
        <asp:CheckBox ID="inputCar"  runat="server" /><br>
        <label for="labelBirthDate" class="sr-only">Birthdate: </label>
        <asp:Label ID="labelBirthDate" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="labelPhoto" runat="server" Text="Foto"></asp:Label>
        <asp:FileUpload ID="inputPhoto" runat="server" />
        <asp:Label ID="labelVOG" runat="server" Text="Verklaring omtrent gedrag"></asp:Label>
        <asp:FileUpload ID="inputVog" runat="server" />
        <label for="inputPassword" class="sr-only">Please enter your password for conformation</label>
        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
        <div class="checkbox">
        </div>
        <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-lg btn-primary btn-block" Text="Update profiel gegevens"></asp:Button>

    </div>
    </form>
</asp:Content>

