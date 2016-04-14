angular.module('issueTracker.dashboard.projects', []).factory('projects', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function allProjects() {
		var deferred = $q.defer();

		$http.get(BASE_URL + 'Projects/').then(function(projects) {
			deferred.resolve(projects);
		});

		return deferred.promise;
	}

	return {
		allProjects: allProjects
	};
}]);