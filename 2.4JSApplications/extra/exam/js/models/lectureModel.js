var app = app || {};

app.lectureModel = (function () {
    function LectureModel(requester) {
        this._requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/lectures/';
    }

    LectureModel.prototype.getAllLectures = function () {
        return this._requester.get(this.serviceUrl, true);
    };

    LectureModel.prototype.getAllMyLectures = function(userId) {
        var requestUrl = this.serviceUrl + '?query={"_acl.creator":"' + userId + '"}';
        return this._requester.get(requestUrl, true);
    };

    LectureModel.prototype.addLecture = function(data) {
        return this._requester.post(this.serviceUrl, data, true);
    };

    LectureModel.prototype.editLecture = function(noteId, data) {
        var requestUrl = this.serviceUrl + noteId;
        return this._requester.put(requestUrl, data, true);
    };

    LectureModel.prototype.deleteLecture = function(noteId) {
        var requestUrl = this.serviceUrl + noteId;
        return this._requester.delete(requestUrl, true);
    };

    return {
        load: function (requester) {
            return new LectureModel(requester);
        }
    };
}());