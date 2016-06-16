<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/NavbarMasterPage.master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="ICT4_Participation_ASP.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Master" runat="server">
<form runat="server" style="height: 100%" >
    <div style="width: 100%; height: 100%;overflow: hidden"  >
        <div style="float: right; width: 20%; height: 100%; display: inline;"  >
    <asp:ListBox ID="ListBox1" runat="server" Rows="28" Width="100%" Font-Size="21px" Height="100%">
    </asp:ListBox>
        </div>
        <div style="float: left; width: 20%;height: 100%" >
         <asp:ListBox ID="ListBox2" runat="server" Rows="28" Font-Size="21px" Width="100%" Height="100%">       
    </asp:ListBox>     
            <div>
            <asp:ListBox ID="ListBox3" runat="server" Rows="28" Font-Size="21px" Width="100%" Height="100%">       
    </asp:ListBox>
                </div>                      
            <asp:Button ID="Button1" runat="server" Text="Button" Font-Size="21px" Width="50%" />
            <div style="position: relative; left: 50%; margin-top: -10%">
                  <asp:Button ID="Button2" runat="server" Text="Button" Font-Size="21px" Width="50%"/>
 </div>
        </div>
        </div>
    </form>
</asp:Content>
    