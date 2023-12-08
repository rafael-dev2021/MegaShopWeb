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

// Carousel  script
window.addEventListener('DOMContentLoaded', function () {
    const carouselContainers = document.querySelectorAll('.carousel-container');
    const prevButtons = document.querySelectorAll('.fa-chevron-left');
    const nextButtons = document.querySelectorAll('.fa-chevron-right');
    const imageWidths = Array.from(carouselContainers).map(container => container.offsetWidth);
    const carouselsData = Array.from(carouselContainers).map((container, index) => ({
        container,
        currentPosition: 0,
        imageWidth: imageWidths[index],
        nextButton: nextButtons[index],
        prevButton: prevButtons[index],
    }));

    carouselsData.forEach(carousel => {
        const { container, nextButton, prevButton, imageWidth } = carousel;

        prevButton.style.display = 'none'; // Hide the "Previous" button initially

        prevButton.addEventListener('click', function () {
            if (carousel.currentPosition !== 0) {
                carousel.currentPosition += imageWidth;
                if (carousel.currentPosition > 0) {
                    carousel.currentPosition = 0;
                }
                carousel.container.style.transform = `translateX(${carousel.currentPosition}px)`;

                showPrevButton();
                showNextButton();
            }

            if (carousel.currentPosition === 0) {
                hidePrevButton();
            }
        });

        nextButton.addEventListener('click', function () {
            const maxPosition = -imageWidth * (carousel.container.childElementCount - 1);

            if (carousel.currentPosition > maxPosition) {
                carousel.currentPosition -= imageWidth;
                carousel.container.style.transform = `translateX(${carousel.currentPosition}px)`;

                showPrevButton();

                if (carousel.currentPosition <= maxPosition) {
                    hideNextButton();
                }
            }
        });

        function showPrevButton() {
            prevButton.style.display = 'block';
        }

        function hidePrevButton() {
            prevButton.style.display = 'none';
        }

        function showNextButton() {
            nextButton.style.display = 'block';
        }

        function hideNextButton() {
            nextButton.style.display = 'none';
        }
    });
});
