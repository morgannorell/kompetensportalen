<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminstart.aspx.cs" Inherits="kompetensportalen.adminstart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
        <div class="examDone">
            <div class="leaf-login"><img src="images/leaf.png" /></div>
            <div class="center-left"><h2>Administration</h2></div>
            <p><b>Såhär gör du!</b></p>
            <p>På den här sidan kan du som administratör se
                vilka som har gjort prov. Du kan även markera
                en användare och sedan klicka på visa test för
                att se användarens senast genomförda prov.
            </p>          
            <form runat="server">
                <div class="userlistTitle">Användare som genomfört test.<br />
                    Klicka på den användare som du vill se testresultat för.
                </div><p></p><hr class="line" />
                <div id="userlist" runat="server">                    
                </div>
            </form>          
        </div>             
	</div>
</asp:Content>
