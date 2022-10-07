function navbar_sidebar() {
    var fullHeight = function () {

        $('.js-fullheight').css('height', $(window).height());
        $(window).resize(function () {
            $('.js-fullheight').css('height', $(window).height());
        });

    };
    fullHeight();

    $('.sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });

    //$('#sihome').on('click', function () {
    //    $('#sidebar').toggleClass('active');
    //});
}

