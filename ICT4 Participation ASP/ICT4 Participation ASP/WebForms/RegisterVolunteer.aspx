<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="RegisterVolunteer.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.RegisterVolunteer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <h2 class="form-signin-heading">Vul je gegevens in</h2>
        <label for="inputUserName" class="sr-only">Gebruikersnaam</label>
        <asp:TextBox ID="inputUserName" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UsernNameRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputUserName" ErrorMessage="Je moet een gebruikersnaam invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <label for="inputEmail" class="sr-only">Email</label>
        <asp:TextBox type="email" ID="inputEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputEmail" ErrorMessage="Je moet een email invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="Reg_Email_RegularExpressionValidator" runat="server" display="Dynamic" ControlToValidate="inputEmail" ErrorMessage="Enter a valit email adress" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
        <label for="inputName" class="sr-only">Naam</label>
        <asp:TextBox ID="inputName" class="form-control" placeholder="Name"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputName" ErrorMessage="Je moet je eigen naam invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <label for="inputAdres" class="sr-only">Adres</label>
        <asp:TextBox ID="inputAdres" class="form-control" placeholder="Adres"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="AdresRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputAdres" ErrorMessage="Je moet een adres invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <label for="inputCity" class="sr-only">Woonplaats</label>
        <asp:TextBox ID="inputCity" class="form-control" placeholder="City" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputCity" ErrorMessage="Je moet een woonplaats invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <label for="inputPhonenumber" class="sr-only">Telefoon nummer</label>
        <asp:TextBox ID="inputPhonenumber" class="form-control" placeholder="Phonenumber" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PhonenumberRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPhonenumber" ErrorMessage="Je moet een telefoonnummer invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" display="Dynamic" ErrorMessage="Vul een geldig format voor een telefoonnummer in" ControlToValidate="inputPhonenumber" ForeColor="Red" ValidationExpression="([0]{1}[6]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){7})|([0]{1}[1-9]{1}[0-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){5})|([0]{1}[1-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){6})"></asp:RegularExpressionValidator> 

        <asp:Label ID="labelDrviningLincense" runat="server" Text="Rijbewijs in bezit"></asp:Label><br/><br/>
        <asp:CheckBox ID="inputDrivingLincense"  runat="server" /><br/><br/>
        <asp:Label ID="labelCar" runat="server" Text="Auto in bezit"></asp:Label><br/><br/>
        <asp:CheckBox ID="inputCar"  runat="server" /><br/><br/>
        <asp:Label ID="labelBirthDate" runat="server" Text="Geboortedatum"></asp:Label><br/><br/>
        <asp:TextBox ID="inputBirthDate" runat="server" TextMode="Date"></asp:TextBox><br/><br/>
        <asp:RequiredFieldValidator ID="BirthDateRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputBirthDate" ErrorMessage="Je moet een geboortedatum invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:Label ID="labelPhoto" runat="server" Text="Foto"></asp:Label>
        <asp:FileUpload ID="inputPhoto" runat="server" />
        <asp:RequiredFieldValidator ID="FotoRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPhoto" ErrorMessage="Je moet een Foto toevoegen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:Label ID="labelVOG" runat="server" Text="Verklaring omtrent gedrag"></asp:Label>
        <asp:FileUpload ID="inputVog" runat="server" />
        <asp:RequiredFieldValidator ID="VOGRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputVog" ErrorMessage="Je moet een Verklaring omtrent gedrag toevoegen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPassword" ErrorMessage="Je moet een wachtwoord" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-lg btn-primary btn-block" Text="Registreer vrijwilliger" OnClick="btnRegister_OnClick"></asp:Button>

    </div>
        </form>
</asp:Content>

