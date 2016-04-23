angular.module('issueTracker.issues', ['issueTracker.issues.getIssues', 'issueTracker.projects.getProjects', 'issueTracker.comments.getComments', 'issueTracker.users.getUsers']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/issues/:id/', {
		templateUrl: 'app/issues/issue.html',
		controller: 'IssueController'
	});

	$routeProvider.when('/projects/:id/add-issue', {
		templateUrl: 'app/issues/add.html',
		controller: 'AddIssueController'
	});

	$routeProvider.when('/issues/:id/edit', {
		templateUrl: 'app/issues/edit.html',
		controller: 'EditIssueController'
	});
}]).controller('IssueController', ['$scope', '$route', '$routeParams', 'getIssues', 'getComments', function($scope, $route, $routeParams, getIssues, getComments) {
	var id = $routeParams.id;
	getIssues.getIssue(id).then(function(getIssueById) {
		$scope.issue = getIssueById.data;
	});

	getComments.getComments(id).then(function(getallCommentsById) {
		console.log(getallCommentsById);
		$scope.comments = getallCommentsById.data;
	});

	$scope.status = function(status) {
		getIssues.changeStatus(status, id).then(function(statusChanged) {
			console.log(statusChanged);
			// TODO: refresh dosent work...
			$route.reload();
		});
	};

	$scope.comment = function(comment) {
		getComments.addComment(comment, id).then(function(addedComment) {
			console.log(addedComment);
			// TODO: refresh dosent work...
			$route.reload();
		});
	};
}]).controller('AddIssueController', ['$scope', '$location', '$routeParams', 'getIssues', 'getProjects', 'getUsers', function($scope, $location, $routeParams, getIssues, getProjects, getUsers) {
	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});

	getProjects.allProjects().then(function(getallProjects) {
		console.log(getallProjects);
		$scope.getallProjects = getallProjects.data;
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

	$scope.issue = function(issue) {
		getIssues.addIssue(issue).then(function(addedIssue) {
			console.log(addedIssue);
			$location.path('/projects/' + id + '/');
		});
	};
}]).controller('EditIssueController', ['$scope', '$location', '$routeParams', 'getIssues', 'getProjects', 'getUsers', function($scope, $location, $routeParams, getIssues, getProjects, getUsers) {
	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});

	var id = $routeParams.id;
	getIssues.getIssue(id).then(function(getIssueById) {
		$scope.editIssue = {
			title: getIssueById.data.Title,
			description: getIssueById.data.Description,
			assigneeId: getIssueById.data.Author.Id,
			// TODO: fill in the priorities. how to take which project it is from?
			//priorities: getIssueById.data.Priority.Id,
			duedate: getIssueById.data.DueDate
		};
		$scope.getIssueById = getIssueById.data;
	});

	$scope.issue = function(issue) {
		getIssues.editIssue(issue, id).then(function(editedIssue) {
			console.log(editedIssue);
			$location.path('/issues/' + id + '/');
		});
	};
}]);