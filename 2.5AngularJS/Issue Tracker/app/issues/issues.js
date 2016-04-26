angular.module('issueTracker.issues', ['issueTracker.issues.getIssues', 'issueTracker.projects.getProjects', 'issueTracker.comments.getComments', 'issueTracker.users.getUsers']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/issues/:id/', {
		templateUrl: 'app/issues/issue.html',
		controller: 'IssueController',
		resolve: {
		    auth: ['$q', function($q) {
		    	var userExists = localStorage.username;
			    if (userExists) {
			    	return $q.when(userExists);
			    } else {
			      return $q.reject({isAuth: false});
			    }
		    }]
		}
	});

	$routeProvider.when('/projects/:id/add-issue', {
		templateUrl: 'app/issues/add.html',
		controller: 'AddIssueController',
		resolve: {
		    auth: ['$q', function($q) {
		    	var userExists = localStorage.username;
			    if (userExists) {
			    	return $q.when(userExists);
			    } else {
			      return $q.reject({isAuth: false});
			    }
		    }]
		}
	});

	$routeProvider.when('/issues/:id/edit', {
		templateUrl: 'app/issues/edit.html',
		controller: 'EditIssueController',
		resolve: {
		    auth: ['$q', function($q) {
		    	var userExists = localStorage.username;
			    if (userExists) {
			    	return $q.when(userExists);
			    } else {
			      return $q.reject({isAuth: false});
			    }
		    }]
		}
	});
}]).controller('IssueController', ['$scope', '$route', '$routeParams', 'getIssues', 'getProjects', 'getComments', function($scope, $route, $routeParams, getIssues, getProjects, getComments) {
	var id = $routeParams.id;
	getIssues.getIssue(id).then(function(getIssueById) {
		$scope.issue = getIssueById.data;
		getProjects.getProject(getIssueById.data.Project.Id).then(function(getProjectById) {
			$scope.project = getProjectById.data;
			console.log(getProjectById.data);
		});
	});

	getComments.getComments(id).then(function(getallCommentsById) {
		console.log(getallCommentsById);
		$scope.comments = getallCommentsById.data;
	});

	$scope.changeStatus = function(status) {
		console.log(status);
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
	var id = $routeParams.id;
	getIssues.getIssue(id).then(function(getIssueById) {
		getProjects.getProject(getIssueById.data.Project.Id).then(function(getProjectById) {
			$scope.project = getProjectById.data;
			var projectLeader = getProjectById.data.Lead.Username;
			console.log(projectLeader);
			console.log(localStorage.username);
			console.log(getIssueById.data.Assignee.Username);
			console.log(localStorage.username != projectLeader && localStorage.username != getIssueById.data.Assignee.Username);
			if (localStorage.username != projectLeader && localStorage.username != getIssueById.data.Assignee.Username) {
				noty({
			        text: 'Sorry you must be the project leader or the issue assignee in order to edit this issue',
			        type: 'error',
			        layout: 'topCenter',
			        timeout: 5000
			    });
				$location.path('/');
			}
		});
		$scope.editIssue = {
			title: getIssueById.data.Title,
			description: getIssueById.data.Description,
			assigneeId: getIssueById.data.Author.Id,
			// TODO: fill in the priorities. how to take which project it is from?
			priorityId: getIssueById.data.Priority.Id,
			duedate: getIssueById.data.DueDate
		};

		$scope.getIssueById = getIssueById.data;
		
		getProjects.getProject(getIssueById.data.Project.Id).then(function(getCurrentProject) {
			$scope.Priorities = getCurrentProject.data.Priorities;
		});
	});

	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});


	$scope.issue = function(issue) {
		getIssues.editIssue(issue, id).then(function(editedIssue) {
			console.log(editedIssue);
			$location.path('/issues/' + id + '/');
		});
	};
}]);