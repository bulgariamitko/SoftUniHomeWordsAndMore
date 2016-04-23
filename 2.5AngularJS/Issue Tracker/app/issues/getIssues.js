angular.module('issueTracker.issues.getIssues', []).factory('getIssues', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function getIssue(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Issues/' + id + '/').then(function(getIssue) {
			console.log(getIssue);
			deferred.resolve(getIssue);
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
			noty({
                text: response.data.Title + ' was added successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
		}, function(error) {
			deferred.reject(error);
			noty({
                text: 'There was error adding this issue.',
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	function editIssue(issue, id) {
		var deferred = $q.defer();
		console.log(issue);
		$http({
		    method: 'PUT',
		    url: BASE_URL + 'Issues/' + id,
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for (var p in obj) {
		        	if (p === 'PriorityId') {
	        			var PriorityId = obj[p].split(',');
	        			for (var i = 0; i < PriorityId.length; i++) {
		        			str.push('PriorityId[' + i + '].name=' + encodeURIComponent(PriorityId[i]));
	        			}
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
			noty({
                text: response.data.Title + ' was edited successful.',
                type: 'info',
                layout: 'topCenter',
                timeout: 5000
            });
		}, function(error) {
			deferred.reject(error);
			noty({
                text: 'There was error editing this issue.',
                type: 'error',
                layout: 'topCenter',
                timeout: 5000
            });
		});
		return deferred.promise;
	}

	function changeStatus(status, id) {
		var deferred = $q.defer();
		console.log(status);
		$http({
		    method: 'PUT',
		    url: BASE_URL + 'Issues/' + id + '/changestatus?statusid={statusId}',
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for (var p in obj) {
		        	str.push(encodeURIComponent(p) + '=' + encodeURIComponent(obj[p]));
		        }
		    	console.log(str.join("&"));
		        return str.join("&");
		    },
		    data: status
		}).then(function(response) {
			deferred.resolve(response.data);
			console.log(response.data);
		}, function(error) {
			deferred.reject(error);
			console.log(error);
		});
		return deferred.promise;
	}

	return {
		getIssue: getIssue,
		addIssue: addIssue,
		editIssue: editIssue,
		changeStatus: changeStatus
	};
}]);