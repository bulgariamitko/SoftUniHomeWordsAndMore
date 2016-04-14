var app = app || {};

app.lectureController = (function () {
    function LectureController(viewBag, model) {
        this._viewBag = viewBag;
        this._model = model;
    }

    LectureController.prototype.loadAllLectures = function(selector) {
        var _this = this;
        
        this._model.getAllLectures().then(function(successData) {
            var result = {
                lectures: []
            };

            successData.forEach(function(lecture) {
                result.lectures.push({
                    _id: lecture._id,
                    title: lecture.title,
                    start: lecture.start,
                    end: lecture.end,
                    lecturer: lecture.lecturer
                });
            });

            _this._viewBag.showLectures(selector, result);
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

    LectureController.prototype.loadMyLectures = function(selector) {
        var _this = this;
        var userId = sessionStorage.userId;
        
        this._model.getAllMyLectures(userId).then(function(successData) {
            var result = {
                lectures: []
            };

            successData.forEach(function(lecture) {
                result.lectures.push({
                    _id: lecture._id,
                    title: lecture.title,
                    start: lecture.start,
                    end: lecture.end,
                    lecturer: lecture.lecturer
                });
            });

            _this._viewBag.showLectures(selector, result);
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

    LectureController.prototype.loadAddLecture = function(selector) {
        this._viewBag.showAddLecture(selector);
    };

    LectureController.prototype.addLecture = function(data) {
        this._model.addLecture(data).then(function() {
            noty({
                text: data.title + ' was added successful.',
                type: 'success',
                layout: 'topCenter',
                timeout: 5000
            });
            Sammy(function () {
                this.trigger('redirectUrl', {url: '#/calendar/list/'});
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

    LectureController.prototype.loadEditLecture = function(selector, data) {
        this._viewBag.showEditLecture(selector, data);
    };

    LectureController.prototype.editLecture = function(data) {
        this._model.editLecture(data._id, data).then(function() {
            noty({
                text: data.title + ' was edited successful.',
                type: 'success',
                layout: 'topCenter',
                timeout: 5000
            });
            Sammy(function () {
                this.trigger('redirectUrl', {url: '#/calendar/list/'});
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

    LectureController.prototype.loadDeleteLecture = function(selector, data) {
        this._viewBag.showDeleteLecture(selector, data);
    };

    LectureController.prototype.deleteLecture = function(data) {
        var _this = this;
        noty({
            text: 'Do you really want to delete this lecture?',
            type: 'confirm',
            layout: 'topCenter',
            buttons: [
                {text: "Yes",
                    onClick: function($noty) {
                        _this._model.deleteLecture(data).then(function() {
                            noty({
                                text: 'The lecture was deleted successful.',
                                type: 'success',
                                layout: 'topCenter',
                                timeout: 5000
                            });
                            Sammy(function () {
                                this.trigger('redirectUrl', {url: '#/calendar/list/'});
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
        load: function (viewBag, model) {
            return new LectureController(viewBag, model);
        }
    };
}());