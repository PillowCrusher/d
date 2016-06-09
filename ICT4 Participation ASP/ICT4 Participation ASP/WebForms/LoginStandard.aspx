<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginStandard.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.LoginStandard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    
    <link href="../Content/bootstrap.min.css" rel="stylesheet"/>

</head>
<body>

    <form id="form1" runat="server">
    <div class="container col-sm-push-4 col-lg-4">
        <h2 class="form-signin-heading">Please sign in</h2>
        <label for="inputUsername" class="sr-only">Email address</label>
        <asp:TextBox id="inputUsername" class="form-control" placeholder="Username" required autofocus runat="server"></asp:TextBox>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox type="password" id="inputPassword" class="form-control" placeholder="Password" required runat="server"></asp:TextBox>
        <div class="checkbox">
          
        </div>
        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block" Text="Sign In"></asp:Button>

    </div>
    </form>
</body>
</html>
