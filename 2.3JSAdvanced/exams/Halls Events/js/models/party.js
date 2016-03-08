var app = app || {};

(function (scope) {
	function Party(options) {
		// extand class
		scope._Event.call(this, options);

        this.checkIsCatered(options.isCatered);
        this.checkIsBirthday(options.isBirthday);
        this.setOrganiser(options.organiser);
	}

	// extend class
	Party.extends(scope._Event);

	Party.prototype.checkIsCatered = function() {
        return this._isCatered;
    };

	Party.prototype.checkIsCatered = function(catered) {
		if (catered == true) {
			this._isCatered = true;
		}
		if (catered == false) {
			this._isCatered = false;
		}
    };

    Party.prototype.checkIsBirthday = function() {
        return this._isBirthday;
    };

    Party.prototype.setIsBirthday = function(birthday) {
		var bool = Boolean(birthday);
		this._isBirthday = birthday;

    };

    Party.prototype.getOrganiser = function() {
        return this._organiser;
    };

    Party.prototype.setOrganiser = function(organiser) {
		if (!(organiser instanceof scope._Employee)) {
   			throw new Error(organiser + " should be instance of the class Employee.");
		}
		this._organiser = organiser;
	};

	// class to be able to be extanded: 
    scope._Party = Party;
	
	scope.party = function(options) {
		return new Party(options);
	};

}(app));