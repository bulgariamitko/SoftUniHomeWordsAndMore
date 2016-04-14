var app = app || {};

app.userViews = (function () {
    function showLoginPage(selector) {
        // TODO change temp if needed
        $.get('templates/login.html', function(templ) {
            $(selector).html(templ);

            // TODO login event
            $('#login-button').on('click', function(e) {
                var username = $('#username').val();
                var password = $('#password').val();

                Sammy(function() {
                    this.trigger('login', {username: username, password: password});
                });
            });
        });
    }

    function showRegisterPage(selector) {
        // TODO change temp if needed
        $.get('templates/register.html', function(templ) {
            $(selector).html(templ);

            // TODO register event
            $('#register-button').on('click', function(e) {
                var username = $('#username').val();
                var password = $('#password').val();
                var reapetPass = $('#confirm-password').val();

                if (password === reapetPass) {
                    Sammy(function() {
                        this.trigger('register', {username: username, password: password});
                    });
                } else {
                    noty({
                        text: 'Passwords do not match. Please, enter new password and try again.',
                        type: 'error',
                        layout: 'topCenter',
                        timeout: 5000
                    });
                }
            });
        });
    }
    return {
        load: function() {
            return {
                showLoginPage: showLoginPage,
                showRegisterPage: showRegisterPage
            };
        }
    };
}());