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
document.addEventListener('DOMContentLoaded', function () {
    const zoomableImages = document.querySelectorAll('.zoomable-image');

    zoomableImages.forEach(image => {
        image.addEventListener('click', function () {
            const imageUrl = image.getAttribute('src');
            const zoomedImage = document.createElement('img');
            zoomedImage.setAttribute('src', imageUrl);
            zoomedImage.classList.add('zoomed-image');

            const overlay = document.createElement('div');
            overlay.classList.add('overlay');
            overlay.appendChild(zoomedImage);

            document.body.appendChild(overlay);
        });
    });

    document.addEventListener('click', function (event) {
        if (event.target.classList.contains('overlay')) {
            event.target.remove();
        }
    });
});