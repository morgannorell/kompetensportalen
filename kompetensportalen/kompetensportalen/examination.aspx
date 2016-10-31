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
            <h1>Countdown Clock</h1>
<div id="clockdiv">
  <div>
    <span class="minutes"></span>
    <div class="smalltext">Minutes</div>
  </div>
  <div>
    <span class="seconds"></span>
    <div class="smalltext">Seconds</div>
  </div>
</div>
            

            <script type="text/javascript">
                function getTimeRemaining(endtime) {
                    var t = Date.parse(endtime) - Date.parse(new Date());
                    var seconds = Math.floor((t / 1000) % 60);
                    var minutes = Math.floor((t / 1000 / 60) % 60);
                    return {
                        'total': t,
                        'minutes': minutes,
                        'seconds': seconds
                    };
                }

                function initializeClock(id, endtime) {
                    var clock = document.getElementById(id);
                    var minutesSpan = clock.querySelector('.minutes');
                    var secondsSpan = clock.querySelector('.seconds');

                    function updateClock() {
                        var t = getTimeRemaining(endtime);

                        minutesSpan.innerHTML = ('0' + t.minutes).slice(-2);
                        secondsSpan.innerHTML = ('0' + t.seconds).slice(-2);

                        if (t.total <= 0) {
                            clearInterval(timeinterval);
                        }
                    }

                    updateClock();
                    var timeinterval = setInterval(updateClock, 1000);
                }

                var timeInMinutes = 10;
                var currentTime = Date.parse(new Date());
                var deadline = new Date(currentTime + timeInMinutes * 60 * 1000);
                initializeClock('clockdiv', deadline);
            </script>
        </div>
    </div>
    </form>
</asp:Content>
