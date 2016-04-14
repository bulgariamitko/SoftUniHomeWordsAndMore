var app = app || {};

app.homeController = (function() {
    function HomeController(viewBag, model) {
        this._viewBag = viewBag;
        this._model = model;
    }

    HomeController.prototype.loadWelcomePage = function(selector) {
        this._viewBag.showWelcomePage(selector);
    };

    HomeController.prototype.loadRegisterMenu = function(selector) {
        this._viewBag.showRegisterMenu(selector);
    };

    HomeController.prototype.loadHomePage = function(selector) {
        var data = {
            username: sessionStorage.username
        };
        this._viewBag.showHomePage(selector, data);
    };

    HomeController.prototype.loadHomeMenu = function(selector) {
        this._viewBag.showHomeMenu(selector);
    };

    return {
        load: function (viewBag, model) {
            return new HomeController(viewBag, model);
        }
    };
}());