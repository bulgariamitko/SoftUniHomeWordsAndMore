angular.module('issueTracker.projects', ['issueTracker.projects.getProjects', 'issueTracker.users.getUsers'])
.config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/projects/add/', {
		templateUrl: 'app/projects/add.html',
		controller: 'AddProjectController'
	});

	$routeProvider.when('/projects/:id/edit', {
		templateUrl: 'app/projects/edit.html',
		controller: 'EditProjectController'
	});

	$routeProvider.when('/projects/', {
		templateUrl: 'app/projects/projects.html',
		controller: 'ProjectsController',
		resolve: {
		    auth: ["$q", "getUsers", function($q, getUsers) {
		    	var userExists = document.currentUser;
		    	var isAdmin = document.isAdmin;
		    	console.log(userExists, isAdmin);
			    if (isAdmin) {
			    	return $q.when(userExists);
			    } else if (userExists && isAdmin) {
			      return $q.when(userExists);
			    } else if (userExists || isAdmin) {
			      return $q.reject({isAdmin: false});
			    } else {
			      return $q.reject({isAuth: false});
			    }
		    }]
		}
	});

	$routeProvider.when('/projects/:id/', {
		templateUrl: 'app/projects/project.html',
		controller: 'ProjectController'
	});

}]).controller('ProjectsController', ['$scope', 'getProjects', function($scope, getProjects) {
	getProjects.allProjects().then(function(allProjectsResult) {
		$scope.allProjectsResult = allProjectsResult.data;
	});
}]).controller('ProjectController', ['$scope', '$routeParams', 'getProjects', function($scope, $routeParams, getProjects) {
	var id = $routeParams.id;
	getProjects.getProject(id).then(function(getProjectById) {
		console.log(getProjectById);
		$scope.getProjectById = getProjectById.data;
	});
	getProjects.getIssuesByProject(id).then(function(getAllIssuesByProjectID) {
		$scope.issues = getAllIssuesByProjectID.data;
	});
}]).controller('AddProjectController', ['$scope', '$location', 'getUsers', 'getProjects', function($scope, $location, getUsers, getProjects) {
	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});

	$scope.project = function(project) {
		getProjects.addProject(project).then(function(newProject) {
			console.log(newProject);
			$location.path('/projects/');
		});
	};
}]).controller('EditProjectController', ['$scope', '$routeParams', '$location', 'getUsers', 'getProjects', function($scope, $routeParams, $location, getUsers, getProjects) {
	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});

	var id = $routeParams.id;
	getProjects.getProject(id).then(function(getProjectById) {
		console.log(getProjectById);
		var prioritiesData = getProjectById.data.Priorities;
		var prioritiesArr = [];
		for (var i = 0; i < prioritiesData.length; i++) {
			prioritiesArr.push(prioritiesData[i].Name);
		}
		var labelsData = getProjectById.data.Labels;
		var labelsArr = [];
		for (var i2 = 0; i2 < labelsData.length; i2++) {
			labelsArr.push(labelsData[i2].Name);
		}

		$scope.editProject = {
			name: getProjectById.data.Name,
			description: getProjectById.data.Description,
			projectKey: getProjectById.data.ProjectKey,
			leadId: getProjectById.data.Lead.Id,
			priorities: prioritiesArr.join(','),
			labels: labelsArr.join(',')
		};
	});

	$scope.project = function(project) {
		getProjects.editProject(project, id).then(function(editedProject) {
			console.log(editedProject);
			$location.path('/projects/' + id + '/');
		});
	};
}]);