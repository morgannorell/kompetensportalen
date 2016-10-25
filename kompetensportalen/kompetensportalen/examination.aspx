<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="examination.aspx.cs" Inherits="kompetensportalen.examination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="article">
        <h1 id="qnbr" runat="server">Fråga 1</h1>
        <p id="question" class="questions" runat="server"></p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
            <asp:ListItem id="ans1" runat="server"></asp:ListItem>
            <asp:ListItem id="ans2" runat="server"></asp:ListItem>
            <asp:ListItem id="ans3" runat="server"></asp:ListItem>
            <asp:ListItem id="ans4" runat="server"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    </form>
</asp:Content>
