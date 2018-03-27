angular.module('issueTracker.users.getUsers', []).factory('getUsers', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function getAllUsers() {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'users').then(function(response) {
			deferred.resolve(response.data);
			console.log(response);
		}, function(error) {
			deferred.reject(error);
		});
		return deferred.promise;
	}

	function registerUser(user) {
		var deferred = $q.defer();
		$http.post(BASE_URL + 'api/Account/Register', user).then(function(response) {
			deferred.resolve(response.data);
			console.log(response);
			noty({
                text: user.username + 'was registered successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
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

	function loginUser(user) {
		var deferred = $q.defer();
		$http({
		    method: 'POST',
		    url: BASE_URL + 'api/Token',
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for(var p in obj) {
		        	str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
		        }
		        str.push("grant_type=password");
		        return str.join("&");
		    },
		    data: user
		}).then(function(response) {
			deferred.resolve(response.data);
			var cookie = [response.data.userName, '=', response.data.access_token, '; token_type=.', response.data.token_type, '; expires=', response.data.expires_in, '; username=', response.data.userName, ';'].join('');
  			document.cookie = cookie;
  			noty({
                text: response.data.userName + ' was login successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
		}, function(error) {
			deferred.reject(error);
			noty({
                text: error.data.error_description,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	//TODO: fix this function...
	function identity(accessToken) {
		var deferred = $q.defer();
		$http.defaults.headers.common.Authorization = 'Bearer ' + accessToken;
		$http.get(BASE_URL + 'api/Account/UserInfo').then(function(response) {
			deferred.resolve(response.data);
		});
		return deferred.promise;
	}

	function me() {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'users/me').then(function(response) {
			deferred.resolve(response.data);
			if (!localStorage.isAdmin && !localStorage.isNotAdmin) {
				localStorage.username = response.data.Username;
				localStorage.isAdmin = response.data.isAdmin;
				localStorage.isNotAdmin = !response.data.isAdmin;
			}
			console.log(response);
		}, function (error) {
			deferred.reject(error);
			console.log(error);
		});
		return deferred.promise;
	}

	function changePassword(newPassword) {
		var deferred = $q.defer();
		$http({
		    method: 'POST',
		    url: BASE_URL + 'api/Account/ChangePassword',
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for(var p in obj) {
		        	str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
		        }
		        return str.join("&");
		    },
		    data: newPassword
		}).then(function(response) {
			deferred.resolve(response.data);
  			noty({
                text: 'The password was changed successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
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
		getAllUsers: getAllUsers,
		registerUser: registerUser,
		loginUser: loginUser,
		identity: identity,
		me: me,
		changePassword: changePassword
	};
}]);