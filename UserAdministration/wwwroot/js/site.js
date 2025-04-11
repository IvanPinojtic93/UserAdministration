// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function renderView(url, target) {
    $.ajax({
        dataType: 'html',
        contentType: 'application/json; charset=utf-8',
        type: "GET",
        url: url,
        cache: false,
        success: function (data) {
            $(target).html(data);
        }
    });
}
function clearView(target) {
    $(target).html("");
}

function clearValidationErrors() {
    var validationErrors = document.getElementsByClassName('text-danger');

    for (var i = 0; i < validationErrors.length; i++) {
        validationErrors[i].innerHTML = "";
    }
}
