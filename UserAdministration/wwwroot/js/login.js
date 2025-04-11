function loginUser() {
    $.ajax({
        dataType: 'json',
        type: "POST",
        url: "User/Login",
        data: { "email": $("#email").val(), "password": $("#password").val() },
        cache: false,
        success: function (data) {
            clearValidationErrors()
            renderView("/History/HistoryTable", "#history")
            alert(data.message);
        },
        error: function ($xhr, textStatus, errorThrown) {
            $("#login").html($xhr.responseText);
        }
    });
}
