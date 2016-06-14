<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="NavbarMasterPage.master" CodeBehind="Volunteer.aspx.cs" Inherits="ICT4_Participation_ASP.WebForms.Volunteer" %>

<asp:Content runat="server" ContentPlaceHolderID="Master">
    <form id="form1" runat="server">
    <div>
        <asp:Image CssClass="RightSide" ID="Image1" runat="server" ImageUrl="../Content/rr-passfoto.jpg" />
        
        <asp:ListBox class="LeftSide" ID="ListBox1" runat="server" Width="35%" Height="500px" OnSelectedIndexChanged="ListBox1_OnSelectedIndexChanged">
        </asp:ListBox>
        <br/>
        <asp:Button class="LeftSide" ID="Button1" runat="server" Text="Button" OnClick="Button1_OnClick" />
            
    </div>
    </form>
    </asp:Content>
