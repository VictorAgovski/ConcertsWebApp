document.addEventListener("DOMContentLoaded", function () {
    var buttons = document.querySelectorAll('.toggle-reviews');
    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            var targetId = this.getAttribute('data-target');
            var targetElement = document.querySelector(targetId);
            $(targetElement).slideToggle();
            this.textContent = targetElement.style.display === 'none' ? 'Show Reviews' : 'Hide Reviews';
        });
    });
});