<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="kompetensportalen.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
                <div class="textfield-left">
                    <div class="leaf-login"><img src="images/leaf.png" /></div>
                    <div class="center"><h2>Administration</h2></div>
                    <p><b>Logga in</b></p>
                    <p>Den här sidan är till för dig som administrerar
                        genomförda prov och följer upp resultat. För att
                        logga in så använder du ditt tilldelad adnimistrationskonto.
                        Detta konto är inte samma som du använder för att genomföra
                        dina test.</p>
                    <p>Om du saknar uppgifter så kan du klicka på supportknappen. 
                        Du kommer då till sidan där vi kan hjälpa dig.</p>
                    <p>När du sedan har loggat in så kan du jobba
                        med genomförda prov och se statestik på
                        resultaten.</p>                    
                </div>
                <div class="vr"></div>
                <div class="login textfield-responsive">
                    <form runat="server">
                        <asp:Label ID="lblAdminUsername" CssClass="login-label" runat="server" Text="Användarnamnn:"></asp:Label><br />
                        <asp:TextBox ID="tbxAdminUsername" CssClass="login-textbox" runat="server"></asp:TextBox><br /><br />
                        <asp:Label ID="lblAdminPassword" CssClass="login-label" runat="server" Text="Lösenord:"></asp:Label><br />                        
                        <asp:TextBox ID="tbxAdminPassword" CssClass="login-textbox" TextMode="Password" runat="server"></asp:TextBox><br /><br />
                        <asp:Button ID="btnSendAdmCred" CssClass="login-button" runat="server" Text="Logga in" OnClick="btnSendAdmCred_Click"></asp:Button>
                        <div id="error_login" class="errorlogin" runat="server"></div>                        
                        <a href="support.aspx">Glömt lösenord</a><p></p>                     
                    </form>
                </div>
			</div>
</asp:Content>

            

