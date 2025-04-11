document.addEventListener("DOMContentLoaded", function () {
    renderView("/User/UserTable", "#users")
});

function createUser() {
    $.ajax({
        dataType: 'json',
        type: "POST",
        url: "User/Create",
        data: {
            "firstName": $("#firstName").val(),
            "lastName": $("#lastName").val(),
            "email": $("#email").val(),
            "password": $("#password").val()
        },
        cache: false,
        success: function (data) {
            clearValidationErrors()
            renderView("/User/UserTable", "#users")
            alert(data.message);
        },
        error: function ($xhr, textStatus, errorThrown) {
            $("#userAction").html($xhr.responseText);
        }
    });
}

function editUser(id) {
    $.ajax({
        dataType: 'json',
        type: "POST",
        url: "User/Edit?id=" + id,
        data: {
            "firstName": $("#firstName").val(),
            "lastName": $("#lastName").val(),
            "email": $("#email").val(),
            "password": $("#password").val()
        },
        cache: false,
        success: function (data) {
            clearValidationErrors()
            renderView("/User/UserTable", "#users")
            alert(data.message);
        },
        error: function ($xhr, textStatus, errorThrown) {
            $("#userAction").html($xhr.responseText);
        }
    });
}

function deleteUser(id) {
    $.ajax({
        dataType: 'json',
        type: "DELETE",
        url: "User/Delete?id=" + id,
        cache: false,
        success: function (data) {
            renderView("/User/UserTable", "#users")
            clearView("#userAction")
            alert(data.message);
        }
    });
}
