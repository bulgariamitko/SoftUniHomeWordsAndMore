angular.module('issueTracker.issues', ['issueTracker.issues.getIssues']).config(['$routeProvider', function($routeProvider) {
	// $routeProvider.when('/issues', {
	// 	templateUrl: 'app/issues/issues.html',
	// 	controller: 'ProjectsController'
	// });

	$routeProvider.when('/issues/:id/', {
		templateUrl: 'app/issues/issue.html',
		controller: 'IssueController'
	});
}]).controller('IssueController', ['$scope', 'getIssues', '$routeParams', function($scope, getIssues, $routeParams) {
	var id = $routeParams.id;
	getIssues.getIssue(id).then(function(getIssueById) {
		$scope.issue = getIssueById.data;
	});
}]);