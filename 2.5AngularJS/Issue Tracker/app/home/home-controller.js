angular.module('issueTracker.home', ['issueTracker.dashboard.getDashboard', 'issueTracker.users.getUsers']).config(['$routeProvider', function($routeProvider) {
	if (document.cookie) {
		$routeProvider.when('/', {
			templateUrl: 'app/dashboard/dashboard.html',
			controller: 'DashboardController'
		});
	} else {
		$routeProvider.when('/', {
			templateUrl: 'app/home/home.html',
			controller: 'HomeController'
		});
	}
}]).controller('HomeController', ['$scope', '$rootScope', '$route', '$location', 'getUsers', function($scope, $rootScope, $route, $location, getUsers) {
	$scope.login = function(user) {
		getUsers.loginUser(user).then(function(loggedInUser) {
			$rootScope.loginedInUser = loggedInUser.userName;
			$route.reload();
		});
	};

	$scope.register = function(user) {
		getUsers.registerUser(user).then(function(registeredUser) {
			var loggingUser = {
				username: user.username,
				password: user.password
			};
			console.log(loggingUser, registeredUser);
			getUsers.loginUser(loggingUser).then(function(loggedInUser) {
				$rootScope.loginedInUser = loggedInUser;
				$route.reload();
			});
		});
	};
}]).controller('DashboardController', ['$scope', 'getDashboard', 'getUsers', function($scope, getDashboard, getUsers) {
	// getUsers.me().then(function(getMe) {
	// 	console.log(getMe);
	// });

	getDashboard.myProjects(document.cookie.split('=')[0]).then(function(getMyProjects) {
		console.log(getMyProjects.data.Projects);
		$scope.myProjects = getMyProjects.data.Projects;
	});

	getDashboard.myIssues().then(function(getMyIssues) {
		$scope.myIssues = getMyIssues.data.Issues;
	});
}]);