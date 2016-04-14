angular.module('issueTracker.dashboard', ['issueTracker.dashboard.projects']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/dashboard', {
		templateUrl: 'app/dashboard/dashboard.html',
		controller: 'DashboardController'
	});
}]).controller('DashboardController', ['$scope', 'projects', function($scope, projects) {
	projects.allProjects().then(function(allProjectsResult) {
		console.log(allProjectsResult.data);
		$scope.allProjectsResult = allProjectsResult.data;
	});
}]);