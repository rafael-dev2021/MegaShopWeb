//Script do footer do layout
//Initiation
const toggleFooterBtn = document.getElementById('toggleFooterBtn');
const toggleIcon = document.getElementById('toggleIcon');
const mainFooter = document.getElementById('mainFooter');

let footerVisible = false;

toggleFooterBtn.addEventListener('click', () => {
    if (footerVisible) {
        mainFooter.style.display = 'none';
        toggleIcon.classList.remove('fa-chevron-down');
        toggleIcon.classList.add('fa-chevron-up');
        footerVisible = false;
    } else {
        mainFooter.style.display = 'block';
        toggleIcon.classList.remove('fa-chevron-up');
        toggleIcon.classList.add('fa-chevron-down');
        footerVisible = true;
    }
});
//End cod

//Script carousel layout
$(document).ready(function () {
    $('#myCarousel').carousel({
        interval: 3000,
        pause: 'hover',
        ride: 'carousel',
        wrap: true
    });
});
//End cod

//Zoomable image script
$(document).ready(function () {
    $('.zoomable-image').click(function () {
        var imageUrl = $(this).attr('src');
        var zoomedImage = $('<img>').attr('src', imageUrl).addClass('zoomed-image');
        var overlay = $('<div>').addClass('overlay').append(zoomedImage);
        $('body').append(overlay);
    });

    $(document).on('click', '.overlay', function () {
        $(this).remove();
    });
});