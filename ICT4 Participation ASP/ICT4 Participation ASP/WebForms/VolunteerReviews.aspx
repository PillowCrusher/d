<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerReviews.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.VolunteerReviews1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>        
        <asp:Label ID="ReviewLabel" runat="server" Text="Reviews"></asp:Label>
        <asp:ListBox ID="ReviewsListBox" runat="server"></asp:ListBox>
        <asp:TextBox ID="ReviewTextBox" runat="server" class="form-control" TextMode="MultiLine" Enabled="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"display="Dynamic" ControlToValidate="inputComment" ErrorMessage="Je moet iets invullen als reactie" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:TextBox ID="inputComment" runat="server" class="form-control" TextMode="MultiLine" placeholder="Plaats hier je reactie"></asp:TextBox>
        <asp:Button ID="postComment" runat="server" Text="Plaats reactie"/>
    </div>
    </form>
</body>
</html>
