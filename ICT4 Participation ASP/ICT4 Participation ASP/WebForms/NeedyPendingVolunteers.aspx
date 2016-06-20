<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyPendingVolunteers.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyPendingVolunteers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
   
        <div class="container">
            <div class="container col-sm-2 pull-left">
        <label class="active">Menu</label>
        <ul class="nav nav-pills nav-stacked">
                    <li role="presentation">
                        <a href="NeedyHelpRequest.aspx">Hulpvraag maken</a>
                    </li>
                    <li role="presentation">
                        <a href="NeedyReview.aspx">Beoordelingen</a>
                    </li>
                    <li role="presentation">
                        <a href="NeedyPendingVolunteers.aspx">Hulpverzoeken</a>
                    </li>
                    <li role="presentation">
                        <a href="#">???</a>
                    </li>
                    <li role="presentation">
                        <a href="#">???</a>
                    </li>
        </ul>
    </div>
            <div class="container col-sm-4">
        <div class="list-group">
            <asp:ListView ID="lvList" runat="server" EmptyData="No data found!" OnItemCommand="EmployeesListView_OnItemCommand">
                <LayoutTemplate>
                            <h3>Volunteers</h3>
                    <ul class="list-group">
                        <asp:PlaceHolder id="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </ul>
                </LayoutTemplate>

                <ItemTemplate>
                    <li class="list-group-item">
                        <span ID="VolunteerName" runat="server" >Naam: <%#DataBinder.Eval(Container.DataItem, "Name") %> <br /> Hulpvraag: <%#DataBinder.Eval(Container.DataItem, "Titel") %> <br />
                            <asp:LinkButton runat="server" ID="AcceptVolunteer" Text="Accept" CommandName="Accept" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserID") %>' /> /
                            <asp:LinkButton runat="server" ID="DeclineVolunteer" Text="Decline" CommandName="Decline" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserID") %>' />
                        </span>
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <h3>Volunteers</h3>
                    <p>
                        Volunteers kunnen niet worden gevonden.
                    </p>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
            
        </div>
    </asp:Content>

