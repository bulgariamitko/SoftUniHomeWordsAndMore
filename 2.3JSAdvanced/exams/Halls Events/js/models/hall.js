var app = app || {};

(function (scope) {
	function Hall(name, capacity) {
        this.setName(name);
        this.setCapacity(capacity);
        this.parties = [];
        this.lectures = [];
	}

	Hall.prototype.getName = function() {
        return this._name;
    };

    Hall.prototype.setName = function(name) {
        if (!(/^[A-Za-z ]+$/.test(name))) {
            throw new Error("Name should contains only letters and whitespace.");
        }
        this._name = name;
    };

    Hall.prototype.getCapacity = function() {
        return this._capacity;
    };

    Hall.prototype.setCapacity = function(capacity) {
        if (!(/^[0-9]+$/.test(capacity))) {
            throw new Error("Capacity should contains only numbers.");
        }
        this._capacity = capacity;
    };

	Hall.prototype.addEvent = function(event) {
		if (event instanceof scope._Party) {
   			this.parties.push(event);
		}
		if (event instanceof scope._Lecture) {
			this.lectures.push(event);
		}
		
	};

	app.hall = Hall;

}(app));