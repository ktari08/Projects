(function(){
    var sec = $('#countdown span').text() || 0;
    var timer = setInterval(function()
    {
        $('#countdown span').text(--sec);
        if (sec == 0){
            $('#countdown').fadeout('fast');
                clearInterval(timer);
        }
    }, 1000);
})()

