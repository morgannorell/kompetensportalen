<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="oldexam.aspx.cs" Inherits="kompetensportalen.oldexam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
        <div class="textfield-left">
            <div class="leaf-login"><img src="images/leaf.png" /></div>
            <div class="center"><h2>Administration</h2></div>
            <p><b>Ditt test</b></p>
            <div id="question">Fråga: <div id="xmlq" runat="server"></div></div>                   
        </div>
        <div class="vr"></div>
        <div class="login textfield-responsive">
            <form runat="server">
                <div class="correct">Rätt svar: <div id="xmlc" runat="server"></div></div>
                <p></p>
                <div class="answer">Ditt svar: </div>
                <hr class="line" />
                <div class="a1">Svar ett: </div>
                <p></p>
                <div class="a2">Svar två: </div>
                <p></p>
                <div class="a3">svar tre: </div>
                <p></p>
                <div class="a4">svar fyra: </div>
                <p></p>
                <asp:button runat="server" text="Tillbaka" />
                <asp:button runat="server" text="Nästa" />                    
            </form>
        </div> 
    </div>               
</asp:Content>
