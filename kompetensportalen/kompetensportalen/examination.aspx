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

            <asp:Button ID="btnNext" runat="server" Text="Nästa fråga" OnClick="btnNext_Click" />
            <asp:Button ID="btnStart" runat="server" Text="Starta testet" OnClick="btnStart_Click" /> 
        </div>
    </div>
    </form>
</asp:Content>
