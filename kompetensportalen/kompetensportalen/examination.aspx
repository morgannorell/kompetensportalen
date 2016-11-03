<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="examination.aspx.cs" Inherits="kompetensportalen.examination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="examination">
        <div class="countdownTimer" id="countdownTimer"></div>
        <div class="exam-question" runat="server">
            <h1 class="qnbr" id="qnbr" runat="server"><center>Frågeställning</center></h1>
            
            <div class="category" id="category" runat="server"></div>
            <p id="question" class="questions" runat="server"></p>
        </div>
        <div class="hr" id="hr" runat="server"></div>
        <div class="exam-answers" runat="server">
            <asp:CheckBoxList ID="CheckBoxListAnswers" runat="server" CssClass="cbxList">
            <asp:ListItem id="answer1" runat="server"></asp:ListItem>
            <asp:ListItem id="answer2" runat="server"></asp:ListItem>
            <asp:ListItem id="answer3" runat="server"></asp:ListItem>
            <asp:ListItem id="answer4" runat="server"></asp:ListItem>
            </asp:CheckBoxList>
            <h1 class="qnbr" id="H1" runat="server"><center>Välkommen!</center></h1>
            <div id="text" runat="server">
                <p><center>När du trycker på starta test har du 30 minuter på dig att slutföra testet. Hinner du inte klart i tid blir du automatiskt underkänd.</center></p>
                    <p><i><center>Lycka till!!</center></i></p>
            </div>
            
            <asp:Button ID="btnNext" runat="server" Text="Nästa fråga" OnClick="btnNext_Click" CssClass="exam-button"/>
            <asp:Button ID="btnStart" runat="server" Text="Starta testet" OnClick="btnStart_Click"  CssClass="exam-button"/> 
        </div>
    </div>
    </form>
</asp:Content>
