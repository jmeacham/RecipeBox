﻿// Self executing anonymus function

(function () {
    
    $('#contact-form').submit(function () {
        $.post('', {
            name: $('#name').val(),
            email: $('#email').val(),
            subject: $('#subject').val(),
            message: $('#message').val()
        })
                .done(function (response) {
                    $('#form-section').html(response);
                });
        return false;
    });
}());