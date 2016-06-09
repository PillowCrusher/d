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
        <label for="inputDrivingLincense" class="sr-only">Rijbewijs in bezit</label>
        <asp:CheckBox ID="inputDrivingLincense"  runat="server" />
        <label for="inputCar" class="sr-only">Auto in bezit</label>
        <asp:CheckBox ID="inputCar"  runat="server" />
        <label for="inputBirthDate" class="sr-only">Geboortedatum</label>
        <asp:Calendar ID="inputBirthDate" runat="server"></asp:Calendar>
        <label for="inputPhoto" class="sr-only">Photo</label>
        <asp:FileUpload ID="inputPhoto" runat="server" />
        <label for="inputVog" class="sr-only">Verklaring omtrent gedrag</label>
        <asp:FileUpload ID="inputVog" runat="server" />
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
        <div class="checkbox">
        </div>
        <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-lg btn-primary btn-block" Text="Sign In"></asp:Button>
  
    </div>
        </form>
</asp:Content>

