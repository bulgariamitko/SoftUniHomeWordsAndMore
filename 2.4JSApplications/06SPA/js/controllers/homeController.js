var app = app || {};

app.homeController = (function() {
    function HomeController(viewBag) {
        this._viewBag = viewBag;
    }

    HomeController.prototype.showHomePage = function(selector) {
        this._viewBag.showHomePage(selector);
    };

    return {
        load: function (viewBag) {
            return new HomeController(viewBag);
        }
    };
}());