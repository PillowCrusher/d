<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master"  AutoEventWireup="true" CodeBehind="ProfileVolunteer.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.ProfileVolunteer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <form id="form1" runat="server">
        <div class="container col-sm-push-4 col-lg-4">
        <p>Gebruikersnaam: </p>
        <asp:Label ID="UserNameLabel" runat="server" Text="Label"></asp:Label>
        <p>Email: </p>
        <asp:Label ID="EmailLabel" runat="server" Text="Label"></asp:Label>
        <p>Naam: </p>
        <label for="inputAdres" class="sr-only">Adres</label>
        <asp:RequiredFieldValidator ID="AdresRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputAdres" ErrorMessage="Je moet een adres invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputAdres" class="form-control" placeholder="Address"  runat="server"></asp:TextBox>
        <label for="inputCity" class="sr-only">Woonplaats</label>
        <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputCity" ErrorMessage="Je moet een woonplaats invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputCity" class="form-control" placeholder="Woonplaats" runat="server"></asp:TextBox>
        <label for="inputPhonenumber" class="sr-only">Telefoon nummer</label>
        <asp:RequiredFieldValidator ID="PhonenumberRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPhonenumber" ErrorMessage="Je moet een telefoonnummer invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" display="Dynamic" ErrorMessage="Vul een geldig format voor een telefoonnummer in" ControlToValidate="inputPhonenumber" ForeColor="Red" ValidationExpression="([0]{1}[6]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){7})|([0]{1}[1-9]{1}[0-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){5})|([0]{1}[1-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){6})"></asp:RegularExpressionValidator> 
        <asp:TextBox ID="inputPhonenumber" class="form-control" placeholder="Telefoonnummer" runat="server"></asp:TextBox>
        <asp:Label ID="labelDrviningLincense" runat="server" Text="Rijbewijs in bezit"></asp:Label><br/><br/>
        <asp:CheckBox ID="inputDrivingLincense"  runat="server" /><br/><br/>
        <asp:Label ID="labelCar" runat="server" Text="Auto in bezit"></asp:Label><br/><br/>
        <asp:CheckBox ID="inputCar"  runat="server" /><br/><br/>
        <asp:Label ID="labelBirthDate" runat="server" Text="Geboortedatum"></asp:Label><br/><br/>
        <asp:RequiredFieldValidator ID="BirthDateRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputBirthDate" ErrorMessage="Je moet een geboortedatum invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputBirthDate" runat="server" TextMode="Date"></asp:TextBox><br/><br/>
        <asp:Label ID="labelPhoto" runat="server" Text="Foto"></asp:Label>
        <asp:RequiredFieldValidator ID="FotoRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPhoto" ErrorMessage="Je moet een Foto toevoegen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:FileUpload ID="inputPhoto" runat="server" />
        <asp:Label ID="labelVOG" runat="server" Text="Verklaring omtrent gedrag"></asp:Label>
        <asp:RequiredFieldValidator ID="VOGRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputVog" ErrorMessage="Je moet een Verklaring omtrent gedrag toevoegen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:FileUpload ID="inputVog" runat="server" />
        <asp:Label ID="vaardighedenLabel" runat="server" Text="Vaardigheden"></asp:Label><br/>
        <asp:Panel ID="checkBoxPanel" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
        <asp:CheckBoxList ID="CheckBoxList1"  runat="server"></asp:CheckBoxList>
             </asp:Panel>
        <label for="inputPassword" class="sr-only">Vul uw wachtwoord in voor bevesteging</label>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPassword" ErrorMessage="Je moet een wachtwoord" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Wachtwoord" runat="server"></asp:TextBox>
        <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-lg btn-primary btn-block" Text="Update profiel gegevens"></asp:Button>
                    <style>
            .scrollingControlContainer
{
    overflow-x: hidden;
    overflow-y: scroll;
}

.scrollingCheckBoxList
{
    border: 1px #808080 solid;
    margin: 10px 10px 10px 10px;
    height: 100px;
}
        </style>

    </div>
    </form>
</asp:Content>

