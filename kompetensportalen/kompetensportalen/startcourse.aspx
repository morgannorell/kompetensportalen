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
                    <form action="course_one.aspx" runat="server">
                        <p>Användarnamn:<br /><input type="text" name="username" size="21" value="test" /></p>
                        <p>Lösenord:<br /><input type="password" name="password" size="22" value="test" /></p>
                        <p><input type="submit" name="Login" value="Logga in" /></p>
                        <p><a href="support.aspx">Glömt lösenord</a></p>
                    </form>
                </div>
			</div>
</asp:Content>  
			