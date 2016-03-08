var app = app || {};

(function (scope) {
	function Lecture(options) {
		// extand class
		scope._Event.call(this, options);

        this.setTrainer(options.trainer);
        this.setCourse(options.course);
	}

	// extend class
	Lecture.extends(scope._Event);

	Lecture.prototype.getTrainer = function() {
        return this._trainer;
    };

	Lecture.prototype.setTrainer = function(trainer) {
		if (!(trainer instanceof scope._Trainer)) {
   			throw new Error(trainer + " should be instance of the class Trainer.");
		}
		this._trainer = trainer;
	};

	Lecture.prototype.getCourse = function() {
        return this._course;
    };

	Lecture.prototype.setCourse = function(course) {
		if (!(course instanceof scope._Course)) {
   			throw new Error(course + " should be instance of the class Course.");
		}
		this._course = course;
	};

	// class to be able to be extanded: 
    scope._Lecture = Lecture;

	scope.lecture = function(options) {
		return new Lecture(options);
	};

}(app));