<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ICT4_Participation_ASP.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
    <div style="overflow: hidden;width: 100%">
    <asp:ListBox ID="ListBox1" runat="server" Width="20%" Rows="40"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" Width="20%" Rows="40"></asp:ListBox>
        <div style="float: right;margin-right: 20%">
        <asp:ListBox ID="ListBox3" runat="server" Width="935%" Rows="40"></asp:ListBox>
            </div>
        </div>
</asp:Content>
    