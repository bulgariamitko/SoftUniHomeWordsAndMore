angular.module('issueTracker.users.auth', []).factory('auth', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function registerUser(user) {
		var deferred = $q.defer();
		$http.post(BASE_URL + 'api/Account/Register', user).then(function(response) {
			deferred.resolve(response.data);
			console.log(response);
		}, function(error) {

		});
		return deferred.promise;
	}

	function loginUser(user) {
		var deferred = $q.defer();
		$http({
		    method: 'POST',
		    url: BASE_URL + 'api/Token',
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for(var p in obj)
		        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
		        return str.join("&");
		    },
		    data: user
		}).then(function(response) {
			deferred.resolve(response.data);
			var cookie = ['token', '=', response.data.access_token, '; token_type=.', response.data.token_type, '; expires=', response.data.expires_in, '; username=', response.data.userName, ';'].join('');
  			document.cookie = cookie;
			console.log(response.data);
		}, function(error) {
			console.log(error);
		});
		return deferred.promise;
	}

	function logout(user) {
		var deferred = $q.defer();
		$http.post(BASE_URL + 'api/Account/Logout', user).then(function(response) {
			deferred.resolve(response.data);
		});
		return deferred.promise;
	}

	return {
		registerUser: registerUser,
		loginUser: loginUser,
		logout: logout
	};
}]);