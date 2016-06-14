<%@ Page Language="C#"  MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="VolunteerHome.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.VolunteerHome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
<form id="form1" runat="server">
    <div class="container col-lg-4 pull-left">
        <label class="active">Menu</label>
        <ul class="nav nav-pills nav-stacked">
            <li role="presentation"><a href="ProfileVolunteer.aspx">Profiel</a></li>
            <li role="presentation"><a href="VolunteerReviews.aspx">Mijn Beoordelingen</a></li>
            <li role="presentation"><a href="#">???</a></li>
            <li role="presentation"><a href="#">???</a></li>
            <li role="presentation"><a href="#">???</a></li>
        </ul>
    </div>
    <div class="container col-lg-4">
        <div class="list-group">
            <asp:ListView ID="lvList" runat="server">
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
    
</form>
    </asp:Content>