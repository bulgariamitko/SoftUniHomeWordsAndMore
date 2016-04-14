var app = app || {};

app.userController = (function() {
    function UserController(viewBag, model) {
        this._viewBag = viewBag;
        this._model = model;
    }

    UserController.prototype.loadLoginPage = function(selector) {
        this._viewBag.showLoginPage(selector);
    };

    UserController.prototype.login = function(data) {
        this._model.login(data).then(function(successData) {
            sessionStorage.sessionId = successData._kmd.authtoken;
            sessionStorage.username = successData.username;
            sessionStorage.userId = successData._id;

            noty({
                text: 'Welcome back, bro! Nice to see you again, ' + sessionStorage.username,
                type: 'success',
                layout: 'topCenter',
                timeout: 5000
            });

            Sammy(function() {
                this.trigger('redirectUrl', {url: '#/home/'});
            });
        },
        function(error) {
            var errorMsg = error.responseJSON.description;
            noty({
                text: errorMsg,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
        }).done();
    };
    
    UserController.prototype.loadRegisterPage = function(selector) {
        this._viewBag.showRegisterPage(selector);
    };

    UserController.prototype.register = function(data) {
        this._model.register(data).then(function(successData) {
            sessionStorage.sessionId = successData._kmd.authtoken;
            sessionStorage.username = successData.username;
            sessionStorage.userId = successData._id;

            noty({
                text: 'Welcome ' + sessionStorage.username + '! You have register successfuly.',
                type: 'success',
                layout: 'topCenter',
                timeout: 5000
            });

            Sammy(function() {
                this.trigger('redirectUrl', {url: '#/home/'});
            });
        },
        function(error) {
            var errorMsg = error.responseJSON.description;
            noty({
                text: errorMsg,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
        }).done();
    };

    UserController.prototype.logout = function() {
        this._model.logout().then(function() {
            sessionStorage.clear();

            noty({
                text: 'Logout successfuly! See you soon again maybe?',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });

            Sammy(function() {
                this.trigger('redirectUrl', {url: '#/'});
            });
        },
        function(error) {
            var errorMsg = error.responseJSON.description;
            noty({
                text: errorMsg,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
        }).done();
    };

    return {
        load: function (viewBag, model) {
            return new UserController(viewBag, model);
        }
    };
}());