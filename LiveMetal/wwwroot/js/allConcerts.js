document.addEventListener("DOMContentLoaded", function () {
    var buttons = document.querySelectorAll('.toggle-reviews');
    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            var targetId = this.getAttribute('data-target');
            var targetElement = document.querySelector(targetId);
            var isVisible = targetElement.style.display === 'block';
            targetElement.style.display = isVisible ? 'none' : 'block';
            this.textContent = isVisible ? 'Show Reviews' : 'Hide Reviews';
        });
    });
});
