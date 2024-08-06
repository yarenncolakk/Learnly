document.addEventListener("DOMContentLoaded", function () {
    var switchBtns = document.querySelectorAll('.switch-btn');

    switchBtns.forEach(function (btn) {
        btn.addEventListener('click', function (event) {
            event.preventDefault();
            var target = event.target.getAttribute('href');
            window.location.href = target;
        });
    });
});