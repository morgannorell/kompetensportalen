<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="startcourse.aspx.cs" Inherits="kompetensportalen.startcourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
                <div class="textfield-left">
                    <div class="leaf-login"><img src="images/leaf.png" /></div>
                    <div class="center"><h2>Välkommen</h2></div>
                    <p><b>Såhär gör du!</b></p>
                    <p>För att kunna genomföra din utbildning så loggar
                        du in med det användarnamn och lösenord som du
                        har blivit tilldelad. Om du saknar uppgifter så kan
                        du klicka på förstoringsglaset så kommer du till supporten där
                        vi kan hjälpa dig.</p>
                    <p>När du sedan har loggat in så kan du starta 
                        din utbildning. Du kan också välja att se
                        resultatet av din senast genomförda utbildning
                        om du gjort den tidigare.</p>                    
                </div>
                <div class="vr"></div>
                <div class="login textfield-responsive">
                    <form runat="server">
                        <asp:Label ID="lblUsername" CssClass="login-label" runat="server" Text="Användarnamnn:"></asp:Label><br />
                        <asp:TextBox ID="tbxUsername" CssClass="login-textbox" runat="server"></asp:TextBox><br /><br />
                        <asp:Label ID="lblPassword" CssClass="login-label" runat="server" Text="Lösenord:"></asp:Label><br />                        
                        <asp:TextBox ID="tbxPassword" CssClass="login-textbox" TextMode="Password" runat="server"></asp:TextBox><br /><br />
                        <asp:Button ID="btnLogin" CssClass="login-button" runat="server" Text="Logga in" onclick="btnLogin_Click"></asp:Button><br />
                        <div id="error_login" class="errorlogin" runat="server"></div>                        
                        <a href="support.aspx">Glömt lösenord</a><p></p>                        
                    </form>
                </div>                
			</div>
</asp:Content>  
			