angular.module('issueTracker.issues.getIssues', []).factory('getIssues', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function getIssue(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Issues/' + id + '/').then(function(getIssues) {
			deferred.resolve(getIssues);
		});
		return deferred.promise;
	}

	function addIssue(issue) {
		var deferred = $q.defer();
		console.log(issue);
		$http({
		    method: 'POST',
		    url: BASE_URL + 'Issues/',
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for (var p in obj) {
		        	if (p === 'labels') {
	        			var labels = obj[p].split(',');
	        			for (var i = 0; i < labels.length; i++) {
		        			str.push('labels[' + i + '].name=' + encodeURIComponent(labels[i]));
	        			}
		        	} else if (p === 'duedate') {
		        		var isoDate = new Date(obj[p]).toISOString();
		        		str.push('duedate=' + isoDate);
		        	} else {
		        		str.push(encodeURIComponent(p) + '=' + encodeURIComponent(obj[p]));
		        	}
		        }
		    	console.log(str.join("&"));
		        return str.join("&");
		    },
		    data: issue
		}).then(function(response) {
			deferred.resolve(response.data);
			console.log(response.data);
		}, function(error) {
			console.log(error);
		});
		return deferred.promise;
	}

	return {
		getIssue: getIssue,
		addIssue: addIssue
	};
}]);