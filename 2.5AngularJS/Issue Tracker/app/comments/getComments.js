angular.module('issueTracker.comments.getComments', []).factory('getComments', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function getComments(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Issues/' + id + '/comments/').then(function(getComments) {
			deferred.resolve(getComments);
		});
		return deferred.promise;
	}

	function addComment(comment, id) {
		var deferred = $q.defer();
		$http({
		    method: 'POST',
		    url: BASE_URL + 'Issues/' + id + '/comments/',
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for (var p in obj) {
		        	str.push(encodeURIComponent(p) + '=' + encodeURIComponent(obj[p]));
		        }
		        return str.join("&");
		    },
		    data: comment
		}).then(function(response) {
			deferred.resolve(response.data);
			console.log(response.data);
			noty({
                text: 'Comment was added successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
		}, function(error) {
			deferred.reject(error);
			console.log(error);
			noty({
                text:  error.data.Message,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	return {
		getComments: getComments,
		addComment: addComment
	};
}]);