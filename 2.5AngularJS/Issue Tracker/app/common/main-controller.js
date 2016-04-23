angular.module('issueTracker.common', ['issueTracker.users.getUsers'])
	.controller('MainController', ['$scope', '$rootScope', '$location', 'identity', 'getUsers', function($scope, $rootScope, $location, identity, getUsers) {
		$scope.isActive = function (viewLocation) { 
	        return viewLocation === $location.path();
	    };

		$scope.isAuth = identity.isAuth();

		$scope.logout = function() {
			document.cookie = document.cookie.split('=')[0] + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
			$location.path('/');
		};

		//TODO: navbar is not working/updating when a user logigged in
		if (document.cookie) {
			getUsers.me().then(function(getMe) {
				if (getMe) {
					document.currentUser = true;	
				}
				document.isAdmin = getMe.isAdmin;
				$rootScope.loginedInUser = getMe.Username;
				$rootScope.isAdmin = getMe.isAdmin;
				console.log(document.currentUser, document.isAdmin);
			});
		}
}]);