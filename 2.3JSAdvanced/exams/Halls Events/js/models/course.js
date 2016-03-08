var app = app || {};

(function (scope) {
	function Course(name, numberOfLectures) {
        this.setName(name);
        this.setNumberOfLectures(numberOfLectures);
	}

	Course.prototype.getName = function() {
        return this._name;
    };

	Course.prototype.setName = function(name) {
        if (!(/^[A-Za-z ]+$/.test(name))) {
            throw new Error("name should contains only letters and whitespace.");
        }
        this._name = name;
    };

    Course.prototype.getNumberOfLectures = function() {
        return this._numberOfLectures;
    };

    Course.prototype.setNumberOfLectures = function(numberOfLectures) {
        if (!(/^[0-9]+$/.test(numberOfLectures))) {
            throw new Error("Number of lectures should contains only numbers.");
        }
        this._numberOfLectures = numberOfLectures;
    };

    // class to be able to be extanded: 
    scope._Course = Course;

	scope.course = function(name, numberOfLectures) {
		return new Course(name, numberOfLectures);
	};

}(app));