<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="RegisterNeedy.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.RegisterNeedy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <h2 class="form-signin-heading">Vul je gegevens in</h2>
        <label for="inputUserName" class="sr-only">Gebruikersnaam</label>
        <asp:RequiredFieldValidator ID="UsernNameRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputUserName" ErrorMessage="Je moet een gebruikersnaam invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputUserName" class="form-control" placeholder="Gebruikersnaam" runat="server"></asp:TextBox>
        <label for="inputEmail" class="sr-only">Email</label>
        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputEmail" ErrorMessage="Je moet een email invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="Reg_Email_RegularExpressionValidator" runat="server" display="Dynamic" ControlToValidate="inputEmail" ErrorMessage="Enter a valit email adress" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
        <asp:TextBox type="email" ID="inputEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
        <label for="inputName" class="sr-only">Naam</label>
        <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputName" ErrorMessage="Je moet je eigen naam invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputName" class="form-control" placeholder="Naam"  runat="server"></asp:TextBox>
        <label for="inputAdres" class="sr-only">Adres</label>
        <asp:RequiredFieldValidator ID="AdresRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputAdres" ErrorMessage="Je moet een adres invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputAdres" class="form-control" placeholder="Address"  runat="server"></asp:TextBox>
        <label for="inputCity" class="sr-only">Woonplaats</label>
        <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputCity" ErrorMessage="Je moet een woonplaats invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputCity" class="form-control" placeholder="Woonplaats" runat="server"></asp:TextBox>
        <label for="inputPhonenumber" class="sr-only">Telefoon nummer</label>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" display="Dynamic" ErrorMessage="Vul een geldig format voor een telefoonnummer in" ControlToValidate="inputPhonenumber" ForeColor="Red" ValidationExpression="([0]{1}[6]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){7})|([0]{1}[1-9]{1}[0-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){5})|([0]{1}[1-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){6})"></asp:RegularExpressionValidator> 
        <asp:RequiredFieldValidator ID="PhonenumberRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPhonenumber" ErrorMessage="Je moet een telefoonnummer invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputPhonenumber" class="form-control" placeholder="Telefoonnummer" runat="server"></asp:TextBox>
        <asp:Label ID="LabelOpenbaarVervoer" runat="server" Text="Openbaar vervoer beschikbaar"></asp:Label><br>
        <asp:CheckBox ID="inputOpenbaarVervoer"  runat="server" /><br>
        <asp:Label ID="labelDrviningLincense" runat="server" Text="Rijbewijs in bezit"></asp:Label><br>
        <asp:CheckBox ID="inputDrivingLincense"  runat="server" /><br>
        <asp:Label ID="labelCar" runat="server" Text="Auto in bezit"></asp:Label><br>
        <asp:CheckBox ID="inputCar"  runat="server" /><br>
        <label for="inputBarcode" class="sr-only">Barcode</label>
        <asp:TextBox ID="inputBarcode" class="form-control" placeholder="barcode" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPassword" ErrorMessage="Je moet een wachtwoord" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Wachtwoord" runat="server"></asp:TextBox>
        <label for="inputPasswordConfirm" class="sr-only">Confirm Password</label>
        <asp:RequiredFieldValidator ID="ConfirmPasswordRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPasswordConfirm" ErrorMessage="Je moet je wachtwoord nog een keer invullen voor controle" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox type="password" ID="inputPasswordConfirm" class="form-control" placeholder="Bevestig wachtwoord" runat="server"></asp:TextBox>
        <asp:Button runat="server" ID="btnRegister" type="submit" CssClass="btn btn-lg btn-primary btn-block" Text="Registreer hulpbehoevende"></asp:Button>

    </div>
        
        </form>
</asp:Content>

