var app = app || {};

app.bookModel = (function () {
    function BookModel(requester) {
        this._requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/Books';
    }

    BookModel.prototype.getAllBooks = function () {
        return this._requester.get(this.serviceUrl, true);
    };

    BookModel.prototype.addNewBook = function(data) {
        return this._requester.post(this.serviceUrl, data, true);
    };

    BookModel.prototype.editBook = function(data) {
        var requestUrl = this.serviceUrl + '/' + data.id;
        return this._requester.put(requestUrl, {name: data.name}, true);
    };

    BookModel.prototype.deleteBook = function(idToDelete) {
        var requestUrl = this.serviceUrl + '/' + idToDelete;
        return this._requester.delete(requestUrl, null, true);
    };

    return {
        load: function (requester) {
            return new BookModel(requester);
        }
    };
}());