angular.module('issueTracker.projects.getProjects', []).factory('getProjects', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function allProjects() {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/').then(function(getProjects) {
			deferred.resolve(getProjects);
		});
		return deferred.promise;
	}

	function getProject(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/' + id + '/').then(function(getProjects) {
			deferred.resolve(getProjects);
		});
		return deferred.promise;
	}

	function getIssuesByProject(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/' + id + '/Issues/').then(function(getProjects) {
			deferred.resolve(getProjects);
		});
		return deferred.promise;
	}

	return {
		allProjects: allProjects,
		getProject: getProject,
		getIssuesByProject: getIssuesByProject
	};
}]);