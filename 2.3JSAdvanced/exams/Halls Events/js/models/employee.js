var app = app || {};

(function (scope) {
	function Employee(name, workHours) {
        this.setName = name;
        this.setWorkHours = workHours;
	}

	Employee.prototype.getName = function() {
        return this._name;
    };

    Employee.prototype.setName = function(name) {
        if (!(/^[A-Za-z ]+$/.test(name))) {
            throw new Error("Name should contains only letters and whitespace.");
        }
        this._name = name;
    };

    Employee.prototype.getWorkHours = function() {
        return this._workHours;
    };

    Employee.prototype.setWorkHours = function(workHours) {
        if (!(/^[0-9]+$/.test(workHours))) {
            throw new Error("Work hours should contains only numbers.");
        }
        this._workHours = workHours;
    };

	// class to be able to be extanded: 
	scope._Employee = Employee;

	scope.employee = function(name, workHours) {
		return new Employee(name, workHours);
	};

}(app));