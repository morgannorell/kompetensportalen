<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="support.aspx.cs" Inherits="kompetensportalen.support" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="article">
        <div class="textfield-left">
            <div class="leaf-login"><img src="images\glas.png"/></div>
            <div class="center"><h2>Support</h2></div>
            <p><b>Dina kontaktuppgifter:</b></p>
            <asp:Label ID="lblName" CssClass="support-label" runat="server" Text="Namn:"></asp:Label><br />
            <asp:TextBox ID="tbxName" CssClass="support-textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblPhone" CssClass="support-label" runat="server" Text="Telefon:"></asp:Label><br />
            <asp:TextBox ID="tbxPhone" CssClass="support-textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lblMail" CssClass="support-label" runat="server" Text="E-post:"></asp:Label><br />        
            <asp:TextBox ID="tbxMail" CssClass="support-textbox" runat="server"></asp:TextBox>
        </div>
        <div class="vr"></div>
        <div class="textfield-right-support">
            <asp:Label ID="lblMessage" CssClass="support-label-multiline" runat="server" Text="Meddelande:"></asp:Label>
            <asp:TextBox ID="tbxMessage" CssClass="support-multiline" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
            <asp:Button ID="btnSend" CssClass="support-button" runat="server" Text="Skicka" />

        </div>
    </div>
    </form>
</asp:Content>