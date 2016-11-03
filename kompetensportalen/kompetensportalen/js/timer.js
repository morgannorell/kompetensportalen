function test() {
    var countdown = 5 * 60 * 1000;
    var timerId = setInterval(function () {
        countdown -= 1000;
        var min = Math.floor(countdown / (60 * 1000));
        var sec = Math.floor((countdown - (min * 60 * 1000)) / 1000);
        var result = ('0' + min).slice(-2) + " : " + ('0' + sec).slice(-2);
        document.getElementById('countdownTimer').innerHTML = result;

        if (countdown <= 0) {
            clearInterval(timerId);
            window.location.replace("examFail.aspx");
        } else {
            $("#countTime").html(min + " : " + sec);
        }
    }, 1000);
};

