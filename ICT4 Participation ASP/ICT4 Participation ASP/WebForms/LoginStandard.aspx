<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginStandard.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.LoginStandard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="/Scripts/bootstrap.min.js" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h2 class="form-signin-heading">Please sign in</h2>
        <label for="inputEmail" class="sr-only">Email address</label>
        <asp:TextBox type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus runat="server"></asp:TextBox>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox type="password" id="inputPassword" class="form-control" placeholder="Password" required runat="server"></asp:TextBox>
        <div class="checkbox">
          <label>
            <input type="checkbox" value="remember-me"> Remember me
          </label>
        </div>
        <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>

    </div> <!-- /container -->
    </form>
</body>
</html>
