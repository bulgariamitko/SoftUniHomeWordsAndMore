angular.module('issueTracker.issues.getIssues', []).factory('getIssues', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function getIssue(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Issues/' + id + '/').then(function(getIssues) {
			deferred.resolve(getIssues);
		});
		return deferred.promise;
	}

	return {
		getIssue: getIssue
	};
}]);