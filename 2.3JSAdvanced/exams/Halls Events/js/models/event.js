var app = app || {};

(function (scope) {
	function Event(options) {
		if (this.constructor === Event) {
            throw new Error("Can't instantiate abstract class Event.");
        }
        this.setTitle = options.title;
        this.setType = options.type;
        this.setDuration = options.duration;
        this.setDate = options.date;
	}

	// class to be able to be extanded: 
	scope._Event = Event;

	Event.prototype.getTitle = function() {
        return this._title;
    };

    Event.prototype.setTitle = function(title) {
        if (!(/^[A-Za-z ]+$/.test(title))) {
            throw new Error("Title should contains only letters and whitespace.");
        }
        this._title = title;
    };

    Event.prototype.getType = function() {
        return this._type;
    };

    Event.prototype.setType = function(type) {
        if (!(/^[A-Za-z ]+$/.test(type))) {
            throw new Error("Type should contains only letters and whitespace.");
        }
        this._type = type;
    };

    Event.prototype.getDuration = function() {
        return this._duration;
    };

    Event.prototype.setDuration = function(duration) {
        if (!(/^[0-9]+$/.test(duration))) {
            throw new Error("Duration should contains only numbers.");
        }
        this._duration = duration;
    };

    Event.prototype.getDate = function() {
        return this._date;
    };

    Event.prototype.setDate = function(date) {
        if (!(date instanceof Date)) {
            throw new Error("Date should be a valid date.");
        }
        this._date = date;
    };

	scope.event = function(options) {
		return new Event(options);
	};

}(app));