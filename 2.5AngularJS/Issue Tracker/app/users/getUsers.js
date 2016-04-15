angular.module('issueTracker.users.getUsers', []).factory('getUsers', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function getAllUsers() {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'users').then(function(response) {
			deferred.resolve(response.data);
			console.log(response);
		}, function(error) {

		});
		return deferred.promise;
	}

	return {
		getAllUsers: getAllUsers
	};
}]);