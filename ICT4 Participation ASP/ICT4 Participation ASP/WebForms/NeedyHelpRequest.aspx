<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyHelpRequest.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyHelpRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <asp:RequiredFieldValidator ID="TitelValidator" runat="server" display="Dynamic" ControlToValidate="inputTitle" ErrorMessage="Je moet een Titel invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox id="inputTitle" CssClass="form-control" placeholder="Titel" autofocus runat="server"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="TextValidator" runat="server" display="Dynamic" ControlToValidate="inputText" ErrorMessage="Je moet een beschrijving invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox runat="server" ID="inputText" TextMode="MultiLine" placeholder="Beschrijving" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="LocationFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputLocation" ErrorMessage="Je moet een locatie invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
        <asp:TextBox runat="server" ID="inputLocation" placeholder="Lokatie" CssClass="form-control"></asp:TextBox>
        <p></p>

        <div>
          <p>Benodigde reistijd:  <asp:TextBox ID="inputRijsTijd" runat="server" TextMode="Number"></asp:TextBox> min</p>
        </div>
        <div>
        <label for="inputUrgent" class="sr-only checkbox-inline">Urgent</label>
            <asp:CheckBox runat="server" ID="cbUrgent" CssClass="checkbox-inline" Text="Urgent"/>
        </div>
        <p>Nodig vervoertype: <asp:DropDownList ID="DdlTransport" runat="server"></asp:DropDownList></p>
        
        <div class="form-group">
            <p>Start datum en tijd</p>
            <asp:RequiredFieldValidator ID="inputStartDateValidator" runat="server" display="Dynamic" ControlToValidate="inputStartDate" ErrorMessage="Je moet een start datum invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="inputStartDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" display="Dynamic" ControlToValidate="inputStartTime" ErrorMessage="Je moet een start tijd invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="inputStartTime" TextMode="Time" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <p>Eind datum en tijd</p>
            <asp:RequiredFieldValidator ID="inputEndDateValidator" runat="server" display="Dynamic" ControlToValidate="inputEndDate" ErrorMessage="Je moet een eind datum invullen" ForeColor="Red" ></asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="inputEndDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="inputEndTimeValidator" runat="server" display="Dynamic" ControlToValidate="inputEndTime" ErrorMessage="Je moet een eind tijd invullen" ForeColor="Red" ></asp:RequiredFieldValidator>            
            <asp:TextBox runat="server" ID="inputEndTime" TextMode="Time" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <p>Aantal nodige vrijwiligers: <asp:TextBox ID="inputAantalVrijwilliger" TextMode="Number" runat="server"></asp:TextBox></p>

            <label for="inputKennisMaken" class="sr-only checkbox-inline">Kennis maken</label>
            <asp:CheckBox runat="server" ID="cbMeeting" CssClass="checkbox-inline" Text="Kennis maken"/>
        </div>
 <asp:Label ID="vaardighedenLabel" runat="server" Text="Vaardigheden"></asp:Label><br/>
        <asp:Panel ID="checkBoxPanel" runat="server" CssClass="scrollingControlContainer scrollingCheckBoxList">
        <asp:CheckBoxList ID="SkillCheckBoxList"  runat="server"></asp:CheckBoxList>
             </asp:Panel>
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
        <asp:Button runat="server" ID="btnSendHelpRequest" CssClass="btn btn-lg btn-primary btn-block" Text="Versturen" OnClick="btnSendHelpRequest_Click" />
    </div>
    </asp:Content>
