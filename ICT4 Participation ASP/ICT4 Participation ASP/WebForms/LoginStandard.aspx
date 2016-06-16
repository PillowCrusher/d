<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master"  AutoEventWireup="true" CodeBehind="LoginStandard.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.LoginStandard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">


    <form runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <h2 class="form-signin-heading">Log alsjeblieft in</h2>
        <label for="inputUsername" class="sr-only">Email address</label>
        <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputUsername" ErrorMessage="Je moet een gebruikersnaam invullen" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:TextBox id="inputUsername" class="form-control" placeholder="Gebruikersnaam" required autofocus runat="server"></asp:TextBox>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPassword" ErrorMessage="Je moet een wachtwoord invullen" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:TextBox type="password" id="inputPassword" class="form-control" placeholder="Wachtwoord" required runat="server"></asp:TextBox>
        <label for="inputBarcode" class="sr-only">Password</label>
        <asp:TextBox id="inputBarcode" class="form-control" placeholder="Barcode" required runat="server"></asp:TextBox>
        <div class="checkbox">
          
        </div>
        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block" Text="Log in" OnClick="btnLogin_OnClick"></asp:Button>

    </div>
    </form>
</asp:Content>

