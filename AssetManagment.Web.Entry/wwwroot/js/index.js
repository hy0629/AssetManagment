var pathname = window.location.pathname;
var pathlist = pathname.split('/');
var navlist = document.querySelectorAll('.nav-link');

pathlist.forEach(path => {
    var link = document.querySelector(`.nav-link[data-path="${path}"]`);
    if (link != undefined) {
        link.classList.add("active");
    }
});


