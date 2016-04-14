angular.module('issueTracker.home', ['issueTracker.users.auth']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/', {
		templateUrl: 'app/home/home.html',
		controller: 'HomeController'
	});
}]).controller('HomeController', ['$scope', '$location', 'auth', function($scope, $location, auth) {
	$scope.login = function(user) {
		auth.loginUser(user).then(function(loggedInUser) {
			console.log(loggedInUser);
			$location.path('/dashboard');
		});
	};

	$scope.register = function(user) {
		auth.registerUser(user).then(function(registeredUser) {
			console.log(registeredUser);
		});
	};

	$scope.logout = function(user) {
		auth.logout(user).then(function() {
			// $location.path('/');
		});
	};
}]);