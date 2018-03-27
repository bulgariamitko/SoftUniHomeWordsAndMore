angular.module('issueTracker.dashboard.getDashboard', []).factory('getDashboard', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function allMyProjects(username) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/?pageSize=10000&pageNumber=1&filter=Lead.Username=="' + username + '"').then(function(getMyProjects) {
			console.log(getMyProjects);
			deferred.resolve(getMyProjects);
		}, function(error) {
			deferred.reject(error);
			noty({
                text: error.data.Message,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	function myProjects(username, pNum) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/?pageSize=13&pageNumber=' + pNum + '&filter=Lead.Username=="' + username + '"').then(function(getMyProjects) {
			console.log(getMyProjects);
			deferred.resolve(getMyProjects);
		}, function(error) {
			deferred.reject(error);
			noty({
                text: error.data.Message,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	function myTotalIssues() {
		var deferred = $q.defer();
		// toFIX: this is not right and need to be done better
		$http.get(BASE_URL + 'Issues/me?orderBy=DueDate desc&pageSize=10000&pageNumber=1').then(function(getMyIssues) {
			console.log(getMyIssues.data);
			deferred.resolve(getMyIssues);
		}, function(error) {
			deferred.reject(error);
			noty({
                text: error.data.Message,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	function myIssues(pNum) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Issues/me?orderBy=DueDate desc&pageSize=10&pageNumber=' + pNum).then(function(getMyIssues) {
			console.log(getMyIssues.data);
			deferred.resolve(getMyIssues);
		}, function(error) {
			deferred.reject(error);
			noty({
                text: error.data.Message,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	return {
		allMyProjects: allMyProjects,
		myProjects: myProjects,
		myTotalIssues: myTotalIssues,
		myIssues: myIssues
	};
}]);