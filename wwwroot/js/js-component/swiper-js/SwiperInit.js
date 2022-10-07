function swiperInit() {
    console.log('Entered initSwiper!');
    const swiper = new Swiper('.swiperTest', {
        scrollbar: {
            el: ".swiper-scrollbar",
            hide: true,
        },
    });
}

function cardSwiper() {
    console.log('Entered cardSwiper!');
    const swiper = new Swiper(".cardSwiper", {
        effect: "cards",
        grabCursor: true,
    });
}

function blogSlider() {
    console.log('Entered blogSlider!');
    var swiper = new Swiper('.blog-slider', {
        spaceBetween: 30,
        effect: 'fade',
        loop: true,
        mousewheel: {
            invert: false,
        },
        // autoHeight: true,
        pagination: {
            el: '.blog-slider__pagination',
            clickable: true,
        }
    });
}