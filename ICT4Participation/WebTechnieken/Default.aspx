<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebTechnieken.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Webtechnieken Demo</title>
    <link rel="stylesheet" href="Styles/style.css"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="Scripts/voorbeeld.js"></script>
</head>
<body>
<div class="container col-sm-4"></div>
<div class="container col-sm-4">
    <form id="form1" runat="server" class="form-signin" onsubmit="return validateLoginForm()" method="post">
        
        
        <h2 class="form-signin-heading">Log in alsjeblieft</h2>
        <label  for="inputEmail" class="sr-only">Gebruikersnaam</label>
        <asp:TextBox ID="inputEmail" class="form-control" placeholder="Gebruikersnaam" required="" autofocus="" type="text" runat="server"></asp:TextBox>
        <label for="inputPassword" class="sr-only">Wachtwoord</label>
        <asp:TextBox id="inputPassword" class="form-control" placeholder="Wachtwoord" required="" type="password" runat="server"></asp:TextBox>
        <div class="container col-sm-4"></div>
        <asp:Button ID="LogIn" Text="Log in" class="btn btn-lg btn-primary btn-block" type="submit" runat="server" OnClick="LogIn_Button_Click"/>
        
    </form>
    </div> <!--
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script> -->
</body>
</html>
