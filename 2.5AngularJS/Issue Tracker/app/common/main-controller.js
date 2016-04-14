angular.module('issueTracker.common', []).controller('MainController', ['$scope', 'identity', function($scope, identity) {
	identity.getCurrentUser().then(function(user) {
		$scope.currentUser = user;
	});

	$scope.isAuth = identity.isAuth();
}]);