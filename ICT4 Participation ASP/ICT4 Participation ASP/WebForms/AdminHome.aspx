<%@ Page Title="ay" Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <div class="container col-lg-4">
        <asp:Label ID="Label4" runat="server" Text="Gebruikers" Font-Size="21px"></asp:Label>
    </div>
    <div class="container col-lg-4">
        <asp:Label ID="Label5" runat="server" Text="Niet geaccepteerde vrijwilligers" Font-Size="21px"></asp:Label>
    </div>
    <div class="container col-lg-2">
        <asp:Label ID="Label6" runat="server" Text="Hulprequests" Font-Size="21px"></asp:Label>
    </div>
    <div class="container col-lg-2">
        <asp:Label ID="Label7" runat="server" Text="Reviews" Font-Size="21px"></asp:Label>
    </div>
    <br />
    <br />
    <div class="row" style="margin: 0px;">
        <div class="col-sm-4">
            <asp:ListBox ID="Actors" Width="100%" runat="server" Rows="25" OnSelectedIndexChanged="Actors_OnSelectedIndexChanged" AutoPostBack="True" Font-Size="18"></asp:ListBox>
        </div>
        <div class="col-sm-4">
            <asp:ListBox ID="VOG" Width="100%" runat="server" Rows="23" OnSelectedIndexChanged="VOG_OnSelectedIndexChanged" AutoPostBack="True" Font-Size="18"></asp:ListBox>
         <asp:Button ID="VOGBtn" runat="server" Text="VOG bekijken" Font-Size="21" Width="40%" />
        </div>
        <div class="col-sm-2">
            
            <asp:ListBox ID="Hulprequest" Width="100%" runat="server" Rows="10" Font-Size="18" OnSelectedIndexChanged="Hulprequest_OnSelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
        </div>
        <div class="col-sm-2">
            <asp:ListBox ID="Review" Width="100%" runat="server" Rows="10" Font-Size="12" OnSelectedIndexChanged="Review_OnSelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Width="33%" Height="40%" Rows="13" TextMode="MultiLine" Font-Size="18"></asp:TextBox>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Block" Font-Size="21" Width="12%" OnClientClick="return confirm('Weet je het zeker?')"  OnClick="Button1_OnClick" />
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False">........</asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Waarschuwing" Font-Size="21" Width="20%" OnClientClick="return confirm('Weet je het zeker?')" OnClick="Button2_OnClick" AutoPostBack="True" />
            <asp:Label ID="Label2" runat="server" Text="Label" Visible="True">........</asp:Label>
            <asp:Button ID="Button4" runat="server" Text="Vrijwilliger activeren" Font-Size="21" Width="31%" OnClick="Button4_OnClick"  AutoPostBack="True"/>
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="True">......</asp:Label>
            <asp:Button ID="Button3" runat="server" Text="Verwijderen" Font-Size="21" Width="31%" OnClientClick="return confirm('Weet je het zeker?')" OnClick="Button3_OnClick" AutoPostBack="True"/>
        </div>
    </div>
</asp:Content>