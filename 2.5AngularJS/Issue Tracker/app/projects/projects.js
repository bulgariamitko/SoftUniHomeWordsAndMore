angular.module('issueTracker.projects', ['issueTracker.projects.getProjects', 'issueTracker.users.getUsers']).config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/projects/add/', {
		templateUrl: 'app/projects/addNewProject.html',
		controller: 'AddProjectController'
	});

	$routeProvider.when('/projects', {
		templateUrl: 'app/projects/projects.html',
		controller: 'ProjectsController'
	});

	$routeProvider.when('/projects/:id/', {
		templateUrl: 'app/projects/project.html',
		controller: 'ProjectController'
	});

}]).controller('ProjectsController', ['$scope', 'getProjects', function($scope, getProjects) {
	getProjects.allProjects().then(function(allProjectsResult) {
		$scope.allProjectsResult = allProjectsResult.data;
	});
}]).controller('ProjectController', ['$scope', 'getProjects', '$routeParams', function($scope, getProjects, $routeParams) {
	var id = $routeParams.id;
	getProjects.getProject(id).then(function(getProjectById) {
		console.log(getProjectById);
		$scope.getProjectById = getProjectById.data;
	});
	getProjects.getIssuesByProject(id).then(function(getAllIssuesByProjectID) {
		$scope.issues = getAllIssuesByProjectID.data;
	});
}]).controller('AddProjectController', ['$scope', 'getUsers', function($scope, getUsers) {
	getUsers.getAllUsers().then(function(allUsers) {
		$scope.allUsers = allUsers;
	});
}]);