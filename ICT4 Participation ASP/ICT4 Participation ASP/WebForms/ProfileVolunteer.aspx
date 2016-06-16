<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master"  AutoEventWireup="true" CodeBehind="ProfileVolunteer.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.ProfileVolunteer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
        <div class="container col-sm-push-4 col-lg-4">
        <p>Gebruikersnaam:
        <asp:Label ID="UserNameLabel" runat="server" Text="Label"></asp:Label> </p>
        <p>Email: <asp:Label ID="EmailLabel" runat="server" Text="Label"></asp:Label></p>        
        <p>Naam: <asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label></p>
        
        <asp:RequiredFieldValidator ID="AdresRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputAdres" ErrorMessage="Je moet een adres invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <p>Address: <asp:TextBox ID="inputAdres" class="form-control" placeholder="Address"  runat="server"></asp:TextBox></p>        
        <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputCity" ErrorMessage="Je moet een woonplaats invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <p>Woonplaats: <asp:TextBox ID="inputCity" class="form-control" placeholder="Woonplaats" runat="server"></asp:TextBox></p> 
        <asp:RequiredFieldValidator ID="PhonenumberRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPhonenumber" ErrorMessage="Je moet een telefoonnummer invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" display="Dynamic" ErrorMessage="Vul een geldig format voor een telefoonnummer in" ControlToValidate="inputPhonenumber" ForeColor="Red" ValidationExpression="([0]{1}[6]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){7})|([0]{1}[1-9]{1}[0-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){5})|([0]{1}[1-9]{1}[0-9]{1}[-\s]*[1-9]{1}[\s]*([0-9]{1}[\s]*){6})"></asp:RegularExpressionValidator> 
        <p>Telefoon nummer: <asp:TextBox ID="inputPhonenumber" class="form-control" placeholder="Telefoonnummer" runat="server"></asp:TextBox></p>
        <p>Rijbewijs in bezit: <asp:CheckBox ID="inputDrivingLincense"  runat="server" /></p>
        <p>Auto in bezit: <asp:CheckBox ID="inputCar"  runat="server" /></p>
        <p>Geboortedatum: <asp:Label ID="birthdDateLabel" runat="server" Text="Label"></asp:Label></p>
        <asp:Label ID="labelPhoto" runat="server" Text="Foto"></asp:Label>
        <asp:FileUpload ID="inputPhoto" runat="server" />
        <asp:Label ID="labelVOG" runat="server" Text="Verklaring omtrent gedrag"></asp:Label>
        <asp:FileUpload ID="inputVog" runat="server" />
        <asp:Label ID="vaardighedenLabel" runat="server" Text="Vaardigheden"></asp:Label><br/>
        <asp:Panel ID="checkBoxPanel" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
        <asp:CheckBoxList ID="SkillCheckBoxList"  runat="server"></asp:CheckBoxList>
             </asp:Panel>
        <label for="inputPassword" class="sr-only">Vul uw wachtwoord in voor bevesteging</label>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputPassword" ErrorMessage="Je moet een wachtwoord" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Wachtwoord" runat="server"></asp:TextBox>
        <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-lg btn-primary btn-block" Text="Update profiel gegevens" OnClick="btnUpdate_Click"></asp:Button>
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
</asp:Content>

