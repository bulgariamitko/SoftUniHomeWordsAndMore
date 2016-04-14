var app = app || {};

app.bookViews = (function () {
    function showAllBooks(selector, data) {
        $.get('templates/books.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            // TODO event add new book name
            $('#addBook').on('click', function() {
                var name = $('#book').val();
                Sammy(function() {
                    this.trigger('add-new-book', {name: name});
                });
            });

            // TODO event edit book name
            $('#books .edit').on('click', function() {
                var id = $(this).prevAll('input[type="text"]').attr('id');
                var name = $(this).prevAll('input[type="text"]').val();
                Sammy(function() {
                    this.trigger('edit-book', {id: id, name: name});
                });
            });

            // TODO event delete book
            $('#books .delete').on('click', function() {
                var id = $(this).prevAll('input[type="text"]').attr('id');
                Sammy(function() {
                    this.trigger('delete-book', id);
                });
            });

            // TODO event get all tags book
            $('#books .get').on('click', function() {
                var id = $(this).prevAll('input[type="text"]').attr('id');
                Sammy(function() {
                    this.trigger('display-tags', id);
                });
            });
        });
    }

    function showAllBooksChoose(selector, data) {
        $.get('templates/addtag.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            // TODO event add new tag name
            $('#addTag').on('click', function() {
                var tagName = $('#tag').val();
                var bookId = $(this).prev().val();
                // TODO change the collection name
                var book = {"_type":"KinveyRef","_id": bookId,"_collection":"Books"};
                Sammy(function() {
                    this.trigger('add-new-tag', {name: tagName, book: book});
                });
            });
        });
    }

    return {
        load: function () {
            return {
                showAllBooks: showAllBooks,
                showAllBooksChoose: showAllBooksChoose
            };
        }
    };
}());