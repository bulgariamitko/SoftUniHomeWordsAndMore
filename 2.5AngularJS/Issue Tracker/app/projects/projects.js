angular.module('issueTracker.projects', ['issueTracker.projects.getProjects', 'issueTracker.users.getUsers'])
.config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/projects/add/', {
		templateUrl: 'app/projects/add.html',
		controller: 'AddProjectController',
		resolve: {
		    auth: ['$q', function($q) {
		    	var userExists = localStorage.username;
		    	var isNotAdmin = localStorage.isNotAdmin;
		    	var isAdmin = localStorage.isAdmin;
		    	console.log("userExists:", userExists, "isNotAdmin:", isNotAdmin, "isAdmin:", isAdmin);
			    if (isAdmin === 'true') {
			    	return $q.when(userExists);
			    } else if (userExists && isAdmin === 'true') {
			      return $q.when(userExists);
			    } else if (userExists || isNotAdmin) {
			      return $q.reject({isAdmin: false, isNotAdmin: true});
			    } else {
			      return $q.reject({isAuth: false});
			    }
		    }]
		}
	});

	$routeProvider.when('/projects/:id/edit/', {
		templateUrl: 'app/projects/edit.html',
		controller: 'EditProjectController',
		resolve: {
		    auth: ['$q', function($q) {
		    	var userExists = localStorage.username;
		    	var isNotAdmin = localStorage.isNotAdmin;
		    	var isAdmin = localStorage.isAdmin;
		    	console.log("userExists:", userExists, "isNotAdmin:", isNotAdmin, "isAdmin:", isAdmin);
			    if (isAdmin === 'true') {
			    	return $q.when(userExists);
			    } else if (userExists && isAdmin === 'true') {
			      return $q.when(userExists);
			    } else if (userExists || isNotAdmin) {
			      return $q.reject({isAdmin: false, isNotAdmin: true});
			    } else {
			      return $q.reject({isAuth: false});
			    }
		    }]
		}
	});

	$routeProvider.when('/projects/', {
		templateUrl: 'app/projects/projects.html',
		controller: 'ProjectsController',
		resolve: {
		    auth: ['$q', function($q) {
		    	var userExists = localStorage.username;
		    	var isNotAdmin = localStorage.isNotAdmin;
		    	var isAdmin = localStorage.isAdmin;
		    	console.log("userExists:", userExists, "isNotAdmin:", isNotAdmin, "isAdmin:", isAdmin);
			    if (isAdmin === 'true') {
			    	return $q.when(userExists);
			    } else if (userExists && isAdmin === 'true') {
			      return $q.when(userExists);
			    } else if (userExists || isNotAdmin) {
			      return $q.reject({isAdmin: false, isNotAdmin: true});
			    } else {
			      return $q.reject({isAuth: false});
			    }
		    }]
		}
	});

	$routeProvider.when('/projects/:id/', {
		templateUrl: 'app/projects/project.html',
		controller: 'ProjectController',
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
	var id = $routeParams.id;
	getProjects.getProject(id).then(function(getProjectById) {
		console.log(getProjectById);
		if (localStorage.username != getProjectById.data.Lead.Username) {
			noty({
		        text: 'Sorry you must be the project leader in order to access this page',
		        type: 'error',
		        layout: 'topCenter',
		        timeout: 5000
		    });
			$location.path('/');
		}
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

	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});


	$scope.project = function(project) {
		getProjects.editProject(project, id).then(function(editedProject) {
			console.log(editedProject);
			$location.path('/projects/' + id + '/');
		});
	};
}]);