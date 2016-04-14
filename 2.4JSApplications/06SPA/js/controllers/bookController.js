var app = app || {};

app.bookController = (function () {
    function BookController(model, viewBag) {
        this._model = model;
        this._viewBag = viewBag;
    }

    BookController.prototype.loadAllBooks = function(selector) {
        var _this = this;

        this._model.getAllBooks().then(function(successData) {
            var result = {
                books: []
            };

            successData.forEach(function(book) {
                // TODO: change the columns names
                result.books.push({bookId: book._id, name: book.name});
            });

            _this._viewBag.showAllBooks(selector, result);
        });
    };

    BookController.prototype.loadAllBooksChoose = function(selector) {
        var _this = this;

        this._model.getAllBooks().then(function(successData) {
            var result = {
                books: []
            };

            successData.forEach(function(book) {
                // TODO: change the columns names
                result.books.push({bookId: book._id, name: book.name});
            });

            _this._viewBag.showAllBooksChoose(selector, result);
        });
    };

    BookController.prototype.addNewBook = function(data) {
        var _this = this;
        this._model.addNewBook(data).then(function() {
            noty({
                text: data.name + ' was added successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
            Sammy(function () {
                this.trigger('redirectUrl', {url: '#/books'});
            });
        });
    };

    BookController.prototype.editBook = function(data) {
        var _this = this;
        this._model.editBook(data).then(function() {
            noty({
                text: data.name + ' was edit successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
            Sammy(function () {
                this.trigger('redirectUrl', {url: '#/books'});
            });
        });
    };

    BookController.prototype.deleteBook = function(data) {
        var _this = this;
        noty({
            text: 'Do you really want to delete this book?',
            type: 'confirm',
            layout: 'topCenter',
            buttons: [
                {text: "Yes",
                    onClick: function($noty) {
                        _this._model.deleteBook(data).then(function() {
                            Sammy(function () {
                                this.trigger('redirectUrl', {url: '#/books'});
                            });
                        });
                        $noty.close();
                    }
                },
                {text: "No", 
                    onClick: function($noty) {
                        $noty.close();
                    }
                }
            ]
        });
    };

    return {
        load: function (model, viewBag) {
            return new BookController(model, viewBag);
        }
    };
}());