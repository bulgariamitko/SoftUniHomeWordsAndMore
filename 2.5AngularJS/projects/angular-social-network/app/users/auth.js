angular.module('socialNetwork.users.auth', []).factory('auth', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function registerUser(user) {
		var deferred = $q.defer();
		$http.post(BASE_URL + 'Users/Register', user).then(function(response) {
			deferred.resolve(response.data);
		}, function(error) {

		});
		return deferred.promise;
	}

	function loginUser(user) {
		var deferred = $q.defer();
		$http.post(BASE_URL + 'Users/Login', user).then(function(response) {
			deferred.resolve(response.data);
			console.log(response.data);
		}, function(error) {
			console.log(error);
		});
		return deferred.promise;
	}

	function logout() {

	}

	return {
		registerUser: registerUser,
		loginUser: loginUser,
		logout: logout
	};
}]);