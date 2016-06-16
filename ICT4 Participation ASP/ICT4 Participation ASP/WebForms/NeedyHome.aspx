<%@ Page Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="NeedyHome.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <div class="container col-lg-4 pull-left">
        <label class="active">Menu</label>
        <ul class="nav nav-pills nav-stacked">
            <li role="presentation"><a href="ProfileVolunteer.aspx">Hulpvraag maken</a></li>
            <li role="presentation"><a href="NeedyReviews.aspx">Beoordelingen</a></li>
            <li role="presentation"><a href="#">???</a></li>
            <li role="presentation"><a href="#">???</a></li>
            <li role="presentation"><a href="#">???</a></li>
        </ul>
    </div>
    <div class="container col-lg-4">
        <div class="list-group">
            <asp:ListView ID="lvList" runat="server" EmptyData="No data found!">
                <LayoutTemplate>
                    <!-- <div id="containerDiv" runat="server" class="list-group"> -->
                    <h1 class="h3">Helprequests</h1>
                    <ul class="list-group">
                        <asp:PlaceHolder id="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </ul>
                    <!-- </div> -->
                </LayoutTemplate>

                <ItemTemplate>
                    <li class="list-group-item">
                        <span ID="HelpRequestTitle" runat="server"><%#DataBinder.Eval(Container.DataItem, "Titel") %></span>
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="container">
                        Helprequests kunnen niet worden gevonden.
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
    
    </asp:Content>
