var app = app || {};

(function() {
    var router = Sammy(function () {
        var loginSection = '#login';
        var wrapper = '#wrapper';
        var booksSelector = '#books';
        var tagSelector = '#tags';
        var chooseBook = '#chooseBook';
        var addTagSection = '#addTagSection';

        var requester = app.requester.config('kid_-1bf_DFMJb','aeec7da9b9bc46acb6b0dd48e0e6f59e');

        var homeViewBag = app.homeViews.load();
        var userViewBag = app.userViews.load();
        var bookViewBag = app.bookViews.load();
        var tagViewBag = app.tagViews.load();

        var userModel = app.userModel.load(requester);
        var bookModel = app.bookModel.load(requester);
        var tagModel = app.tagModel.load(requester);

        var homeController = app.homeController.load(homeViewBag);
        var userController = app.userController.load(userModel, userViewBag);
        var bookController = app.bookController.load(bookModel, bookViewBag);
        var tagController = app.tagController.load(tagModel, tagViewBag);

        this.before({except: {path: '#\/(register|login)?'}}, function() {
            var sessionId = sessionStorage.sessionAuth;
            if (!sessionId) {
                this.redirect('#/');
                return false;
            } else {
                this.redirect('#/books');
            }
        });

        this.get('#/', function() {
            $(loginSection).show();
            $(wrapper).hide();
            homeController.showHomePage(loginSection);
        });

        this.get('#/login', function() {
            userController.showLoginPage(loginSection);
        });

        this.get('#/logout', function() {
            userController.logout();
        });

        this.get('#/register', function() {
            userController.showRegisterPage(loginSection);
        });

        this.get('#/books', function() {
            $(loginSection).hide();
            $(wrapper).show();
            bookController.loadAllBooks(booksSelector);
            tagController.loadAllTags(tagSelector);
            bookController.loadAllBooksChoose(addTagSection);
        });

        this.bind('redirectUrl', function(e, data) {
            this.redirect(data.url);
        });

        this.bind('login', function(e, data) {
            userController.login(data);
        });

        this.bind('register', function(e, data) {
            userController.register(data);
        });

        // TODO event add new book name
        this.bind('add-new-book', function(e, data) {
            bookController.addNewBook(data);
        });

        // TODO event edit book name
        this.bind('edit-book', function(e, data) {
            bookController.editBook(data);
        });

        // TODO event delete book
        this.bind('delete-book', function(e, data) {
            bookController.deleteBook(data);
        });

        // TODO event display tags by book id
        this.bind('display-tags', function(e, data) {
            tagController.loadTagsByBookId(tagSelector, data);
            bookController.loadAllBooksChoose(addTagSection);
        });

        // TODO event add new tag name
        this.bind('add-new-tag', function(e, data) {
            tagController.addNewTag(data);
        });

        // TODO event edit tag name
        this.bind('edit-tag', function(e, data) {
            tagController.editTag(data);
        });

        // TODO event delete tag
        this.bind('delete-tag', function(e, data) {
            tagController.deleteTag(data);
        });
    });

    router.run('#/');
}());