// script by Lloyd http://agyuku.net/2009/05/back-to-top-link-using-jquery/
// changed on 2011-03-12 by jen http://jenweb.info/page/go-to-top-jquery
$(function() {
    $('#toTop').hide();
    $(window).scroll(function() {
        if($(this).scrollTop() >= 60) { // could and should! be changed
            $('#toTop').fadeIn();
            $('#toTop').click(function() {
                $(this).addClass('toTop-click');
            });
        } else {
            if($(window).scrollTop() == 0) {
                $('#toTop').removeClass('toTop-click');
            }
            $('#toTop').fadeOut();
        }
    });
    // Opera fix: DynamicDrive script ::jQuery Scroll to Top Control v1.1
    // http://www.dynamicdrive.com/dynamicindex3/scrolltop.htm
    var mode = (window.opera) ? ((document.compatMode == "CSS1Compat") ? $('html') : $('body')) : $('html,body');
    $('#toTop').click(function() {
        mode.animate({scrollTop:0},800);
        return false;
    });
});