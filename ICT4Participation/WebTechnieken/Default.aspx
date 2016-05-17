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
    <form id="form1" runat="server" class="form-signin">
        
        
        <h2 class="form-signin-heading">Please sign in</h2>
        <label for="inputEmail" class="sr-only">Email address</label>
        <input id="inputEmail" class="form-control" placeholder="Email address" required="" autofocus="" type="email">
        <label for="inputPassword" class="sr-only">Password</label>
        <input id="inputPassword" class="form-control" placeholder="Password" required="" type="password">
        <div class="checkbox">
          <label>
            <input value="remember-me" type="checkbox"> Remember me
          </label>
        </div>
        <div class="container col-sm-4"></div>
        <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
        

    </form>
    </div> <!--
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script> -->
</body>
</html>
