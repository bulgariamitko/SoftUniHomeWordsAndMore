var imdb = imdb || {};

(function (scope) {
	var id = 0;
	function Theatre(name, length, rating, country, isPuppet) {
		this._id = id++;
		// extand class
		scope._Movie.call(this, name, length, rating, country);
		this.isPuppet = isPuppet || false;
	}
	// extend class
	Theatre.extend(scope._Movie);

	scope.getTheatre = function(name, length, rating, country, isPuppet) {
		return new Theatre(name, length, rating, country, isPuppet);
	};

}(imdb));