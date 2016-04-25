angular.module('issueTracker.users.identity', []).factory('identity', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	var deferred = $q.defer();
	if (document.cookie) {
		var accessToken = document.cookie.split('=')[1];
		$http.defaults.headers.common.Authorization = 'Bearer ' + accessToken;
		$http.get(BASE_URL + 'api/Account/UserInfo').then(function(response) {
			deferred.resolve(response.data);
			console.log(response.data);
		});
	}
	return deferred.promise;
}]);