/**
 * Created by doloscanliviu on 6/5/16.
 */

$(document).ready(function() {
    $('.gallery-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.slider-nav'
    });

    $('.slider-nav').slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        asNavFor: '.gallery-slider',
        dots: false,
        variableWidth: true,
        centerMode: true,
        focusOnSelect: true,
        prevArrow: '<div class="th-ctrls thumb-prev"></div>',
        nextArrow: '<div class="th-ctrls thumb-next"></div>'
    });

    $('.c-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        dots: true,
        arrows: false
    });
})
