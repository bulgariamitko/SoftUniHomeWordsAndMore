angular.module('socialNetwork.home', ['socialNetwork.users.auth']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/', {
		templateUrl: 'app/home/home.html',
		controller: 'HomeController'
	});
}]).controller('HomeController', ['$scope', '$location', 'auth', function($scope, $location, auth) {
	$scope.login = function(user) {
		auth.loginUser(user).then(function(loggedInUser) {
			console.log(loggedInUser);
			$location.path('/newsFeed');
		});
	};

	$scope.register = function(user) {
		auth.registerUser(user).then(function(registeredUser) {
			console.log(registeredUser);
		});
	};
}]);