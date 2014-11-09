$(document).ready(function (ev)
{
    $mainPage = $('#header, #cookies, #give-cookie-button');
    $('#give-cookie-button').on('click', function (ev)
    {
        ev.preventDefault();
        $('#give-panel').fadeIn(200);
        $mainPage.animate({ 'opacity': 0 }, 200);
    });
    $('#gm-close-button').on('click', function (ev)
    {
        ev.preventDefault();
        $('#give-panel').fadeOut(200);
        $mainPage.animate({ 'opacity': 1 }, 200);
    });
});