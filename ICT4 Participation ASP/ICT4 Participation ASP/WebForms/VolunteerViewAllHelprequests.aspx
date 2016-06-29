<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="VolunteerViewAllHelprequests.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.VolunteerViewAllHelprequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <div class="container">
        <div class="container col-sm-2 pull-left">
            <label class="active">Menu</label>
            <ul class="nav nav-pills nav-stacked">
                <li role="presentation">
                    <a href="ProfileVolunteer.aspx">Profiel</a>
                </li>
                <li role="presentation">
                    <a href="VolunteerReviews.aspx">Mijn Beoordelingen</a>
                </li>
                <li role="presentation">
                    <a href="VolunteerViewAllHelprequests.aspx">Alle hulpvragen</a>
                </li>
                <li role="presentation">
                    <a href="#">???</a>
                </li>
                <li role="presentation">
                    <a href="#">???</a>
                </li>
            </ul>
        </div>
        <div class="container col-sm-6">
            <div class="list-group">
                <asp:ListView ID="lvList" runat="server" OnItemCommand="HelpRequestsListView_OnItemCommand">
                    <LayoutTemplate>
                        <h1 class="h3">Helprequests</h1>
                        <ul class="list-group">
                            <asp:PlaceHolder id="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </ul>
                        <!-- </div> -->
                    </LayoutTemplate>

                    <ItemTemplate>
                        <li class="list-group-item">
                            <div>
                            <p>Titel: <span ID="HelpRequestTitle" runat="server" ><%#DataBinder.Eval(Container.DataItem, "Titel") %> </p></div>
                            <div>
                            <p>Beschrijving: <span ID ="HelpRequestDescription" runat="server"><%#DataBinder.Eval(Container.DataItem, "Description") %> </span></p></div>
                            <div>
                            <p>Locatie: <span ID ="HelpRequestLocation" runat="server"><%#DataBinder.Eval(Container.DataItem, "Location") %> </span></p></div>
                            <div>
                            <p>Benodigde reistijd: <span ID ="HelpRequestTravelTime" runat="server"><%#DataBinder.Eval(Container.DataItem, "TravelTime") %> </span></p></div>
                            <div>
                            <p>Dringed: <span ID ="HelpRequestUrgent" runat="server"><%#DataBinder.Eval(Container.DataItem, "Urgent") %> </span></p></div>
                            <div>
                            <p>Vervoerstype: <span ID ="HelpRequestTransportation" runat="server"><%#DataBinder.Eval(Container.DataItem, "TransportationType") %> </span></p></div>
                            <div>
                            <p>Begin datum: <span ID ="HelpRequestStart" runat="server"><%#DataBinder.Eval(Container.DataItem, "StartDate") %> </span></p></div>
                            <div>
                            <p>Eind datum: <span ID ="HelpRequestEnd" runat="server"><%#DataBinder.Eval(Container.DataItem, "EndDate") %> </span></p></div>
                            <div>
                             <p>Benodigde vrijwilligers: <span ID ="Span1" runat="server"><%#DataBinder.Eval(Container.DataItem, "VolunteersNumber") %> </span></p></div>
                            <div>                       
                             <p>Kennismakings gesprek nodig: <span ID ="HelpRequestInterview" runat="server"><%#DataBinder.Eval(Container.DataItem, "Interview") %> </span></p></div>  

                                <asp:LinkButton runat="server" ID="AcceptHelpRequest" Text="Inschrijven" CommandName="Accept" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' /></span>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <h3>Hulpvragen</h3>
                        <p>
                            Helprequests kunnen niet worden gevonden.
                        </p>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>

    </div>
</asp:Content>