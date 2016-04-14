var app = app || {};

app.tagViews = (function () {
    function showAllTags(selector, data) {
        // TODO change html temp
        $.get('templates/tags.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            // TODO event edit tag name
            $('#tags .edit').on('click', function() {
                var id = $(this).prevAll('input[type="text"]').attr('id');
                var name = $(this).prevAll('input[type="text"]').val();
                Sammy(function() {
                    this.trigger('edit-tag', {id: id, name: name});
                });
            });

            // TODO event delete tag
            $('#tags .delete').on('click', function() {
                var id = $(this).prevAll('input[type="text"]').attr('id');
                Sammy(function() {
                    this.trigger('delete-tag', id);
                });
            });
        });
    }

    function showTagsById(selector, data) {
        // TODO change html temp
        $.get('templates/tags.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            if (data.tags.length === 0) {
                $(selector).html('No tags added! Please add a new tag for this book and try again!');
            } else {
                $(selector).html(rendered);
            }
        });
    }

    return {
        load: function () {
            return {
                showAllTags: showAllTags,
                showTagsById: showTagsById
            };
        }
    };
}());