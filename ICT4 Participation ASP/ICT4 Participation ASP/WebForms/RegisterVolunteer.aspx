<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="RegisterVolunteer.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.RegisterVolunteer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <h2 class="form-signin-heading">Vul je gegevens in</h2>
        <label for="inputUserName" class="sr-only">Gebruikersnaam</label>
        <asp:TextBox ID="inputUserName" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
        <label for="inputEmail" class="sr-only">Email</label>
        <asp:TextBox type="email" ID="inputEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
        <label for="inputName" class="sr-only">Naam</label>
        <asp:TextBox ID="inputName" class="form-control" placeholder="Name"  runat="server"></asp:TextBox>
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
        <asp:Label ID="labelBirthDate" runat="server" Text="Geboortedatum"></asp:Label><br>
        <asp:TextBox ID="inputBirthDate" runat="server" TextMode="Date"></asp:TextBox><br>
        <asp:Label ID="labelPhoto" runat="server" Text="Foto"></asp:Label>
        <asp:FileUpload ID="inputPhoto" runat="server" />
        <asp:Label ID="labelVOG" runat="server" Text="Verklaring omtrent gedrag"></asp:Label>
        <asp:FileUpload ID="inputVog" runat="server" />
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
        <div class="checkbox">
        </div>
        <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-lg btn-primary btn-block" Text="Sign In"></asp:Button>

    </div>
        </form>
</asp:Content>

