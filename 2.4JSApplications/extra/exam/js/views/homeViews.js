var app = app || {};

app.homeViews = (function () {
    function showWelcomePage(selector) {
        $.get('templates/welcome-guest.html', function(templ) {
            $(selector).html(templ);
        });
    }

    function showRegisterMenu(selector) {
        $.get('templates/menu-login.html', function(templ) {
            $(selector).html(templ);
        });
    }

    function showHomePage(selector, data) {
        $.get('templates/welcome-user.html', function(templ) {
            var renderedData = Mustache.render(templ, data);
            $(selector).html(renderedData);
        });
    }

    function showHomeMenu(selector) {
        $.get('templates/menu-home.html', function(templ) {
            $(selector).html(templ);
        });
    }

    return {
        load: function() {
            return {
                showWelcomePage: showWelcomePage,
                showRegisterMenu: showRegisterMenu,
                showHomePage: showHomePage,
                showHomeMenu: showHomeMenu
            };
        }
    };
}());