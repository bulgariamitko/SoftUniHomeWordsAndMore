var app = app || {};

app.homeViews = (function () {
    function showHomePage(selector) {
        $.get('templates/home.html', function(templ) {
            $(selector).html(templ);

            $('#loginBtn').on('click', function(e) {
                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/login'});
                });
            });

            $('#registerBtn').on('click', function(e) {
                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/register'});
                });
            });
        });
    }

    return {
        load: function() {
            return {
                showHomePage: showHomePage
            };
        }
    };
}());