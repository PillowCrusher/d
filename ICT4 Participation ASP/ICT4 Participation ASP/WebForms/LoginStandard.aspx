<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master"  AutoEventWireup="true" CodeBehind="LoginStandard.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.LoginStandard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">


    
    <div class="container col-sm-push-4 col-lg-4">
        <h2 class="form-signin-heading">Log alsjeblieft in</h2>
        <label for="inputUsername" class="sr-only">Email address</label>
        <asp:TextBox id="inputUsername" class="form-control" placeholder="Gebruikersnaam" autofocus runat="server"></asp:TextBox>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox type="password" id="inputPassword" class="form-control" placeholder="Wachtwoord" runat="server"></asp:TextBox>
        <label for="inputBarcode" class="sr-only">Password</label>
        <asp:TextBox id="inputBarcode" class="form-control" placeholder="Barcode" runat="server"></asp:TextBox>
        <div class="checkbox">
          
        </div>
        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block" Text="Log in" OnClick="btnLogin_OnClick"></asp:Button>

    </div>
</asp:Content>

