<%@ Page Language="C#"  MasterPageFile="~/WebForms/NavbarMasterPage.master"  AutoEventWireup="true" CodeBehind="VolunteerReviews.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.VolunteerReviews1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">

    <div class="container col-sm-push-4 col-lg-4">
        <div>
        <asp:Label ID="ReviewLabel" runat="server" Text="Reviews"></asp:Label>
        </div>
        <div>
         <p>Review:   <asp:DropDownList ID="DdlReview" runat="server" ></asp:DropDownList></p>
        </div>
         <asp:TextBox ID="inputComment" runat="server" class="form-control" TextMode="MultiLine" placeholder="Plaats hier je reactie"></asp:TextBox>
        <asp:Button ID="postComment" runat="server" Text="Plaats reactie" OnClick="postComment_Click"/>
    </div>
    </asp:Content>
