<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="examination.aspx.cs" Inherits="kompetensportalen.examination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="examination">
        <div class="exam-question">
            <h1 id="qnbr" runat="server"><center>Fråga 1</center></h1>
            <p id="question" class="questions" runat="server"></p>
        </div>
        <div class="hr"></div>
        <div class="exam-answers">
            <asp:CheckBoxList ID="CheckBoxListAnswers" runat="server">
            <asp:ListItem id="answer1" runat="server"></asp:ListItem>
            <asp:ListItem id="answer2" runat="server"></asp:ListItem>
            <asp:ListItem id="answer3" runat="server"></asp:ListItem>
            <asp:ListItem id="answer4" runat="server"></asp:ListItem>
            </asp:CheckBoxList>
        </div>
    </div>
    </form>
</asp:Content>
