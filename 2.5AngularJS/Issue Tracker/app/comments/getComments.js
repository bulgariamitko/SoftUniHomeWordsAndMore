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
		    	console.log(str.join("&"));
		        return str.join("&");
		    },
		    data: comment
		}, function(error) {
			console.log(error);
		});
		return deferred.promise;
	}

	return {
		getComments: getComments,
		addComment: addComment
	};
}]);