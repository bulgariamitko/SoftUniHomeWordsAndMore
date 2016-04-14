var app = app || {};

app.lectureViews = (function () {
    function showLectures(selector, data) {
        $.get('templates/calendar.html', function(templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: '2016-01-12',
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data.lectures,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            Sammy(function () {
                                this.trigger('redirectUrl', {url: '#/calendar/add/'});
                            });
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);
                        $('#editLecture').on('click', function() {
                            $('body').removeClass();
                            $('.modal-backdrop.fade.in').remove();
                            Sammy(function () {
                                this.trigger('show-edit-lecture', {_id: calEvent._id, title: calEvent.title, start: calEvent.start._i, end: calEvent.end._i});
                            });
                        });
                        $('#deleteLecture').on('click', function() {
                            $('body').removeClass();
                            $('.modal-backdrop.fade.in').remove();
                            Sammy(function() {
                                this.trigger('show-delete-lecture', {_id: calEvent._id, title: calEvent.title, start: calEvent.start._i, end: calEvent.end._i});
                            });
                        });
                    });
                    $('#events-modal').modal();
                }
            });
        });
    }

    function showAddLecture(selector) {
        $.get('templates/add-lecture.html', function (templ) {
            var rendered = Mustache.render(templ);
            $(selector).html(rendered);

            // event add new lecture
            $('#addLecture').on('click', function() {
                var title = $('#title').val();
                var startDate = $('#start').val();
                var endDate = $('#end').val();
                var lecturer = sessionStorage.username;
                Sammy(function() {
                    this.trigger('add-new-lecture', {title: title, start: startDate, end: endDate, lecturer: lecturer});
                });
            });
        });
    }

    function showEditLecture(selector, data) {
        $.get('templates/edit-lecture.html', function(templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            // event edit lecture
            $('#editLecture').on('click', function() {
                var id = $(this).parent().prev().attr('data-id');
                var title = $('#title').val();
                var startDate = $('#start').val();
                var endDate = $('#end').val();
                Sammy(function() {
                    this.trigger('edit-lecture', {_id: id, title: title, start: startDate, end: endDate, lecturer: sessionStorage.username});
                });
            });
        });
    }

    function showDeleteLecture(selector, data) {
        $.get('templates/delete-lecture.html', function(templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            // event delete lecture
            $('#deleteLecture').on('click', function() {
                var id = $(this).parent().prev().attr('data-id');
                Sammy(function() {
                    this.trigger('delete-lecture', id);
                });
            });
        });
    }

    return {
        load: function () {
            return {
                showLectures: showLectures,
                showAddLecture: showAddLecture,
                showEditLecture: showEditLecture,
                showDeleteLecture: showDeleteLecture
            };
        }
    };
}());