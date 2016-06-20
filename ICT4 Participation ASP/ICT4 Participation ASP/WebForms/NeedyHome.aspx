<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyHome.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyHome" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
   
        <div class="container">
            <div class="container col-sm-2 pull-left">
        <label class="active">Menu</label>
        <ul class="nav nav-pills nav-stacked">
                    <li role="presentation">
                        <a href="NeedyHelpRequest.aspx">Hulpvraag maken</a>
                    </li>
                    <li role="presentation">
                        <asp:LinkButton ID="LinkReview" runat="server" OnClick="LinkReview_Click">Beoordelingen</asp:LinkButton>
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
            <div class="container col-sm-3">
        <div class="list-group">
            <asp:ListView ID="lvList" runat="server" EmptyData="No data found!" OnItemCommand="EmployeesListView_OnItemCommand">
                <LayoutTemplate>
                    <!-- <div id="containerDiv" runat="server" class="list-group"> -->
                            <h3>Helprequests</h3>
                    <ul class="list-group">
                        <asp:PlaceHolder id="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </ul>
                    <!-- </div> -->
                </LayoutTemplate>

                <ItemTemplate>
                    <li class="list-group-item">
                        <span ID="HelpRequestTitle" runat="server" ><%#DataBinder.Eval(Container.DataItem, "Titel") %> <asp:LinkButton runat="server" ID="SelectEmployeeButton" Text="Open Chat" CommandName="AddToChat" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID") %>' /></span>
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
            <div class="container col-sm-6">
                <h3>Chat</h3>
                <asp:TextBox runat="server" ID="inputChat" CssClass="form-control" TextMode="MultiLine" Height="200" ReadOnly="True"></asp:TextBox>
                <asp:TextBox runat="server" ID="inputMessage" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <asp:Button runat="server" ID="btnSendMessage" OnClick="btnSendMessage_OnClick" CssClass="btn btn-block" Text="Versturen" />
            </div>
        </div>
    </asp:Content>
