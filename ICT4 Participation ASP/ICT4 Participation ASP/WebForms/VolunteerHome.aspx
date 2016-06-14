<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerHome.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.VolunteerHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Volunteer Home</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">
    <div class="container  col-lg-4 pull-left">
        <div class="list-group">
            <asp:ListView ID="lvList" runat="server">
                <LayoutTemplate>
                    <!-- <div id="containerDiv" runat="server" class="list-group"> -->
                    <h1 class="h2">Helprequests</h1>
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
    <div class="container col-sm-push-4 col-lg-4">
        <label class="active">Menu</label>
        <ul class="nav nav-pills nav-stacked">
            <li role="presentation"><a href="ProfileVolunteer.aspx">Profiel</a></li>
            <li role="presentation"><a href="VolunteerReviews.aspx">Mijn Beoordelingen</a></li>
            <li role="presentation"><a href="#">???</a></li>
            <li role="presentation"><a href="#">???</a></li>
            <li role="presentation"><a href="#">???</a></li>
        </ul>
    </div>
</form>
</body>
</html>