var app = app || {};

(function() {
    var router = Sammy(function () {
        var selector = '#container';
        var menu = '#menu';

        // TODO change app credentials
        var requester = app.requester.load('kid_ZyGnwINaJ-','8d4544bdb1b347c2aa0da11af6200487', 'https://baas.kinvey.com/');

        var homeViewBag = app.homeViews.load();
        var userViewBag = app.userViews.load();
        var lectureViewBag = app.lectureViews.load();

        var userModel = app.userModel.load(requester);
        var lectureModel = app.lectureModel.load(requester);

        var homeController = app.homeController.load(homeViewBag);
        var userController = app.userController.load(userViewBag, userModel);
        var lectureController = app.lectureController.load(lectureViewBag, lectureModel);

        // this.before({except: {path: '#\/(register|login)?'}}, function() {
        //     var sessionId = sessionStorage.sessionId;
        //     if (!sessionId) {
        //         this.redirect('#/');
        //         return false;
        //     } else {
        //         this.redirect('#/home');
        //     }
        // });

        this.get('#/', function() {
            homeController.loadRegisterMenu(menu);
            homeController.loadWelcomePage(selector);
        });

        this.get('#/home/', function() {
            homeController.loadHomeMenu(menu);
            homeController.loadHomePage(selector);
        });

        this.get('#/login/', function() {
            homeController.loadRegisterMenu(menu);
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function() {
            homeController.loadRegisterMenu(menu);
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.get('#/calendar/list/', function() {
            homeController.loadHomeMenu(menu);
            lectureController.loadAllLectures(selector);
        });

        this.get('#/calendar/my/', function() {
            homeController.loadHomeMenu(menu);
            lectureController.loadMyLectures(selector);
        });

        this.get('#/calendar/add/', function() {
            homeController.loadHomeMenu(menu);
            lectureController.loadAddLecture(selector);
        });

        this.get('#/calendar/edit/', function() {
            homeController.loadHomeMenu(menu);
            lectureController.loadEditLecture(selector);
        });


        // binding
        this.bind('redirectUrl', function(e, data) {
            this.redirect(data.url);
        });

        this.bind('login', function(e, data) {
            userController.login(data);
        });

        this.bind('register', function(e, data) {
            userController.register(data);
        });

        this.bind('add-new-lecture', function(e, data) {
            lectureController.addLecture(data);
        });

        this.bind('show-edit-lecture', function(e, data) {
            lectureController.loadEditLecture(selector, data);
        });

        this.bind('edit-lecture', function(e, data) {
            lectureController.editLecture(data);
        });

        this.bind('show-delete-lecture', function(e, data) {
            lectureController.loadDeleteLecture(selector, data);
        });

        this.bind('delete-lecture', function(e, data) {
            lectureController.deleteLecture(data);
        });
    });

    router.run('#/');
}());