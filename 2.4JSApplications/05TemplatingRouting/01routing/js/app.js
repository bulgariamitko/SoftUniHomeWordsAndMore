var app = app || {};

(function() {
	var router = Sammy(function() {
		// selectiors
		var mainSelector = 'main';
		var user = '#user';

		this.get('#/', function(){
			$(user).html('');
		});

		this.get('#/sam', function(){
			$(user).html(', Sam');
		});

		this.get('#/bob', function(){
			$(user).html(', Bob');
		});

		this.get('#/pesho', function(){
			$(user).html(', Pesho');
		});
	});

	router.run('#/');
}());