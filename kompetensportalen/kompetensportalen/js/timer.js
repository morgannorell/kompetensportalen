function startCountdown() {
    document.getElementById('countdownTimer').innerHTML = "30:00";
    var countdown = 30 * 60 * 1000;
    var timerId = setInterval(function () {
        countdown -= 1000;
        var min = Math.floor(countdown / (60 * 1000));
        var sec = Math.floor((countdown - (min * 60 * 1000)) / 1000);
        var result = ('0' + min).slice(-2) + " : " + ('0' + sec).slice(-2);


        document.cookie = countdown;
        document.getElementById('countdownTimer').innerHTML = result;

        if (countdown <= 0) {
            clearInterval(timerId);
            window.location.replace("examFail.aspx");
        } else {
            $("#countTime").html(min + " : " + sec);
        }
    }, 1000);
};

function resumeCountdown() {
    
    var countdown = document.cookie--;
    var premin = Math.floor(countdown / (60 * 1000));
    var presec = Math.floor((countdown - (premin * 60 * 1000)) / 1000);
    var preresult = ('0' + premin).slice(-2) + " : " + ('0' + presec).slice(-2);
    document.getElementById('countdownTimer').innerHTML = preresult;

    var timerId = setInterval(function () {
        countdown -= 1000;
        var min = Math.floor(countdown / (60 * 1000));
        var sec = Math.floor((countdown - (min * 60 * 1000)) / 1000);
        var result = ('0' + min).slice(-2) + " : " + ('0' + sec).slice(-2);

        document.cookie = countdown;
        document.getElementById('countdownTimer').innerHTML = result;

        if (countdown <= 0) {
            clearInterval(timerId);
            window.location.replace("examFail.aspx");
        } else {
            $("#countTime").html(min + " : " + sec);
        }
    }, 1000);
    
}

