angular.module('issueTracker.users.Password', ['issueTracker.users.getUsers']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/profile/password/', {
		templateUrl: 'app/users/password.html',
		controller: 'ChangePasswordController'
	});
}]).controller('ChangePasswordController', ['$scope', '$location', 'getUsers', function($scope, $location, getUsers) {
	$scope.changePassword = function(newPassword) {
		getUsers.changePassword(newPassword).then(function(changedPassword) {
			$location.path('/');
		});
	};
}]);