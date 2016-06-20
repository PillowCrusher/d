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
                            <span ID="HelpRequestTitle" runat="server" ><%#DataBinder.Eval(Container.DataItem, "Titel") %> 
                                <asp:LinkButton runat="server" ID="AcceptHelpRequest" Text="Accept" CommandName="Accept" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' /> /
                                <asp:LinkButton runat="server" ID="DeclineHelpRequest" Text="Decline" CommandName="Decline" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' /></span>
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