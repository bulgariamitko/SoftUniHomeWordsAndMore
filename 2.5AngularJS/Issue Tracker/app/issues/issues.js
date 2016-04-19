angular.module('issueTracker.issues', ['issueTracker.issues.getIssues', 'issueTracker.projects.getProjects', 'issueTracker.users.getUsers']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/issues/:id/', {
		templateUrl: 'app/issues/issue.html',
		controller: 'IssueController'
	});

	$routeProvider.when('/projects/:id/add-issue', {
		templateUrl: 'app/issues/add.html',
		controller: 'AddIssueController'
	});
}]).controller('IssueController', ['$scope', '$routeParams', 'getIssues', function($scope, $routeParams, getIssues) {
	var id = $routeParams.id;
	getIssues.getIssue(id).then(function(getIssueById) {
		$scope.issue = getIssueById.data;
	});
}]).controller('AddIssueController', ['$scope', '$location', '$routeParams', 'getIssues', 'getProjects', 'getUsers', function($scope, $location, $routeParams, getIssues, getProjects, getUsers) {
	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});

	var id = $routeParams.id;
	getProjects.getProject(id).then(function(getProjectById) {
		console.log(getProjectById.data);
		console.log(getProjectById.data.Id);
		$scope.newIssue = {
			projectId: getProjectById.data.Id,
			assigneeId: getProjectById.data.Lead.Id
		};
		$scope.getProjectById = getProjectById.data;
	});

	getProjects.allProjects().then(function(getallProjects) {
		console.log(getallProjects);
		$scope.getallProjects = getallProjects.data;
	});

	$scope.issue = function(issue) {
		getIssues.addIssue(issue).then(function(addedIssue) {
			console.log(addedIssue);
			$location.path('/projects/' + id + '/');
		});
	};
}]);