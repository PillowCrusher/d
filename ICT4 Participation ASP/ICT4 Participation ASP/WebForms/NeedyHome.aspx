<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NeedyHome.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.NeedyHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Needy Home</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container col-lg-4">
        
        <asp:TextBox id="inputTitle" CssClass="form-control" placeholder="Titel" required autofocus runat="server"></asp:TextBox>

        <asp:TextBox runat="server" ID="inputText" TextMode="MultiLine" placeholder="Beschrijving" CssClass="form-control"></asp:TextBox>
        <div>
            <label for="inputRijbewijs" class="sr-only">Rijbewijs</label>
            <asp:CheckBox runat="server" ID="cbDrivingLicence" CssClass="form-control" Text="Rijbewijs"/>
            <label for="inputUrgent" class="sr-only">Urgent</label>
            <asp:CheckBox runat="server" ID="cbUrgent" CssClass="form-control" Text="Urgent"/>
            <label for="inputKennisMaken" class="sr-only">Kennis maken</label>
            <asp:CheckBox runat="server" ID="cbMeeting" CssClass="form-control" Text="Kennis maken"/>
        </div>
    </div>
    </form>
</body>
</html>
