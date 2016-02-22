var app = app || {};

(function (scope) {

	var Types = {
        Boolean: typeof true,
        Number: typeof 0,
        String: typeof "",
        Object: typeof {},
        Undefined: typeof undefined,
        Function: typeof function() { }
    };

    Object.prototype.isString = function() {
        return typeof(this) === Types.String;
    };

	function Trainer(name, workHours) {
		// extand class
		scope._Employee.call(this, name, workHours);

        this.courses = [];
        this.feedbacks = [];
	}

	// extend class
	Trainer.extends(scope._Employee);

	Trainer.prototype.addFeedback = function(feedback) {
		if (!feedback || feedback.isString()) {
            throw new Error("Feedback is not a string or its empty");
        }
		
		this.feedbacks.push(feedback);
	};

	Trainer.prototype.addCourse = function(course) {
		if (course instanceof scope._Course) {
			this.courses.push(course);
		}
	};

	// class to be able to be extanded: 
    scope._Trainer = Trainer;

	scope.trainer = function(name, workHours) {
		return new Trainer(name, workHours);
	};

}(app));