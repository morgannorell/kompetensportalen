<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="examination.aspx.cs" Inherits="kompetensportalen.examination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="examination">
        <div id="countdownTimer"></div>
        <div class="exam-question" runat="server">
            <h1 id="qnbr" runat="server"><center>Frågeställning</center></h1>
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

            

            <script type="text/javascript">
                var countdown = 30*60*1000;
                var timerId = setInterval(function () {
                    countdown -= 1000;
                    var min = Math.floor(countdown / (60 * 1000));
                    var sec = Math.floor((countdown - (min * 60 * 1000)) / 1000);
                    var result = min + " : " + sec;
                    document.getElementById('countdownTimer').innerHTML = result;

                    if (countdown <= 0) {
                        alert("30 min!");
                        clearInterval(timerId);
                        //doSomething();
                    } else {
                        $("#countTime").html(min + " : " + sec);
                    }
                }, 1000);
            </script>
        </div>
    </div>
    </form>
</asp:Content>
