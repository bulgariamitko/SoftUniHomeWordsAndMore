angular.module('issueTracker.common', ['issueTracker.users.getUsers'])
	.controller('MainController', ['$scope', '$rootScope', '$location', function($scope, $rootScope, $location) {
		$scope.isActive = function (viewLocation) { 
	        return viewLocation === $location.path();
	    };

	    // fix search when new page load, delete data
	    $scope.searchProjects = '';

		$scope.logout = function() {
			document.cookie = document.cookie.split('=')[0] + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
			document.currentUser = false;
			localStorage.clear();
			$rootScope.loginedInUser = '';
			$rootScope.isAdmin = '';
			$location.path('/');
		};
}]);