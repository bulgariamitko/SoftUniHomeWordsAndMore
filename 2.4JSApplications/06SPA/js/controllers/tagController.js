var app = app || {};

app.tagController = (function () {
    function TagController(model, viewBag) {
        this._model = model;
        this._viewBag = viewBag;
    }

    TagController.prototype.loadAllTags = function(selector) {
        var _this = this;
        this._model.getAllTags().then(function(successData) {
            var result = {
                tags: []
            };

            successData.forEach(function(tag) {
                // TODO: change the columns names
                result.tags.push({tagId: tag._id, name: tag.name});
            });

            _this._viewBag.showAllTags(selector, result);
        });
    };

    TagController.prototype.loadTagsByBookId = function(selector, id) {
        var _this = this;
        this._model.getTagsByBookId(id).then(function(successData) {
            var result = {
                tags: []
            };

            successData.forEach(function(tag) {
                // TODO: change the columns names
                result.tags.push({tagId: tag._id, name: tag.name});
            });

            _this._viewBag.showTagsById(selector, result);
        });
    };

    TagController.prototype.addNewTag = function(data) {
        var _this = this;
        this._model.addNewTag(data).then(function() {
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

    TagController.prototype.editTag = function(data) {
        var _this = this;
        this._model.editTag(data).then(function() {
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

    TagController.prototype.deleteTag = function(data) {
        var _this = this;
        noty({
            text: 'Do you really want to delete this tag?',
            type: 'confirm',
            layout: 'topCenter',
            buttons: [
                {text: "Yes",
                    onClick: function($noty) {
                        _this._model.deleteTag(data).then(function() {
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
            return new TagController(model, viewBag);
        }
    };
}());