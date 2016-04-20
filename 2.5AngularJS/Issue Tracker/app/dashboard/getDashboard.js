angular.module('issueTracker.dashboard.getDashboard', []).factory('getDashboard', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function myProjects(username) {
		var deferred = $q.defer();
		// TODO: fix the url...
		$http.get(BASE_URL + 'Projects/?pageSize=2&pageNumber=1&filter=Lead.Username=="' + username + '"').then(function(getMyProjects) {
			deferred.resolve(getMyProjects);
		});
		return deferred.promise;
	}

	function myIssues() {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Issues/me?orderBy=Project.Name desc, IssueKey&pageSize=2&pageNumber=1').then(function(getMyIssues) {
			deferred.resolve(getMyIssues);
		});
		return deferred.promise;
	}

	return {
		myProjects: myProjects,
		myIssues: myIssues
	};
}]);