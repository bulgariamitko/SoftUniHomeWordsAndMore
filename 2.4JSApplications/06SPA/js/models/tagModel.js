var app = app || {};

app.tagModel = (function () {
    function TagModel(requester) {
        this._requester = requester;
        // TODO change collection
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/Tags';
    }

    TagModel.prototype.getTagsByBookId = function(bookId) {
        // TOGO change collection id
        var endpointUrl = this.serviceUrl + '?query={"book._id":"' + bookId + '"}';
        return this._requester.get(endpointUrl, true);
    };

    TagModel.prototype.getAllTags = function () {
        return this._requester.get(this.serviceUrl, true);
    };

    TagModel.prototype.addNewTag = function(data) {
        return this._requester.post(this.serviceUrl, data, true);
    };

    TagModel.prototype.editTag = function(data) {
        var requestUrl = this.serviceUrl + '/' + data.id;
        return this._requester.put(requestUrl, {name: data.name}, true);
    };

    TagModel.prototype.deleteTag = function(idToDelete) {
        var requestUrl = this.serviceUrl + '/' + idToDelete;
        return this._requester.delete(requestUrl, null, true);
    };

    return {
        load: function (requester) {
            return new TagModel(requester);
        }
    };
}());