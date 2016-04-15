angular.module('issueTracker.users.identity', []).factory('identity', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	var deferred = $q.defer();
	var currentUser = undefined;
	if (document.cookie) {
		var accessToken = document.cookie.substring(6);
		$http.defaults.headers.common.Authorization = 'Bearer ' + accessToken;
		$http.get(BASE_URL + 'api/Account/UserInfo').then(function(response) {
			currentUser = response.data;
			deferred.resolve(currentUser);
			console.log(currentUser);
		});
	}
	
	return {
		getCurrentUser: function() {
			if (currentUser) {
				return $q.when(currentUser);
			} else {
				return deferred.promise;
			}
		},
		isAuth: function() {
			if (document.cookie) {
				return true;
			}
		}
	};
}]);