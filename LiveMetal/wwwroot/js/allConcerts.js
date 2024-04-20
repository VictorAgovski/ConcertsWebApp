document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.toggle-reviews').forEach(button => {
        button.addEventListener('click', function () {
            var carouselId = this.getAttribute('data-target');
            var carousel = document.getElementById(carouselId.slice(1));
            var carouselInner = carousel.querySelector('.review-carousel');
            if (carousel.style.display === 'none' || !carousel.style.display) {
                carousel.style.display = 'block';
                carouselInner.style.transform = 'translateX(0)'; // Reset to the first slide
                this.textContent = "Hide Reviews";
            } else {
                carousel.style.display = 'none';
                this.textContent = "Show Reviews";
            }
        });
    });
});

function moveSlide(concertId, direction) {
    var container = document.getElementById('carousel-' + concertId);
    if (container) {
        var carousel = container.querySelector('.review-carousel');
        var slides = carousel.querySelectorAll('.carousel-slide');
        if (slides.length > 1) {
            var slideWidth = container.clientWidth; // Make sure this calculation is correct
            var currentTransform = getComputedStyle(carousel).transform;
            var currentIndex = currentTransform === 'none' ? 0 : parseInt(currentTransform.split(',')[4].trim());
            var newIndex = currentIndex - (slideWidth * direction);

            // Clamping the newIndex to ensure it doesn't go out of bounds
            newIndex = Math.max(newIndex, -(slides.length - 1) * slideWidth);
            newIndex = Math.min(newIndex, 0);

            carousel.style.transform = `translateX(${newIndex}px)`;
        }
    }
}
