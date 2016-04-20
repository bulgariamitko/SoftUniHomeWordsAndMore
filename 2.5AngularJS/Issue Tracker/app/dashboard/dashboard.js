angular.module('issueTracker.dashboard', ['issueTracker.dashboard.getDashboard', 'issueTracker.users.auth']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/dashboard/', {
		templateUrl: 'app/dashboard/dashboard.html',
		controller: 'DashboardController'
	});
}]).controller('DashboardController', ['$scope', 'getDashboard', 'auth', function($scope, getDashboard, auth) {
	//console.log(currentUser); //hmmm. how can i get the current users? :D no one knows :D 

	auth.me().then(function(getMe) {
		getDashboard.myProjects(getMe.Username).then(function(getMyProjects) {
			console.log(getMyProjects.data.Projects);
			$scope.myProjects = getMyProjects.data.Projects;
		});
	});

	getDashboard.myIssues().then(function(getMyIssues) {
		$scope.myIssues = getMyIssues.data.Issues;
	});

	// getIssues.getIssue(id).then(function(getIssueById) {
	// 	$scope.issue = getIssueById.data;
	// });

	// getComments.getComments(id).then(function(getallCommentsById) {
	// 	console.log(getallCommentsById);
	// 	$scope.comments = getallCommentsById.data;
	// });
}]);