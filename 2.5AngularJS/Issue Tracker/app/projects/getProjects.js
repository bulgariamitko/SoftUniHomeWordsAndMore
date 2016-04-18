angular.module('issueTracker.projects.getProjects', []).factory('getProjects', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	function allProjects() {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/').then(function(getProjects) {
			deferred.resolve(getProjects);
		});
		return deferred.promise;
	}

	function getProject(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/' + id + '/').then(function(getProjects) {
			deferred.resolve(getProjects);
		});
		return deferred.promise;
	}

	function getIssuesByProject(id) {
		var deferred = $q.defer();
		$http.get(BASE_URL + 'Projects/' + id + '/Issues/').then(function(getProjects) {
			deferred.resolve(getProjects);
		});
		return deferred.promise;
	}

	function addProject(project) {
		var deferred = $q.defer();
		console.log(project);
		$http({
		    method: 'POST',
		    url: BASE_URL + 'Projects/',
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for (var p in obj) {
		        	if (p === 'priorities') {
	        			var priorities = obj[p].name.split(',');
	        			for (var i = 0; i < priorities.length; i++) {
		        			str.push('priorities[' + i + '].name=' + encodeURIComponent(priorities[i]));
	        			}
		        	} else if (p === 'labels') {
	        			var labels = obj[p].name.split(',');
	        			for (var i = 0; i < labels.length; i++) {
		        			str.push('labels[' + i + '].name=' + encodeURIComponent(labels[i]));
	        			}
		        	} else {
		        		str.push(encodeURIComponent(p) + '=' + encodeURIComponent(obj[p]));
		        	}
		        }
		    	console.log(str.join("&"));
		        return str.join("&");
		    },
		    data: project
		}).then(function(response) {
			deferred.resolve(response.data);
			console.log(response.data);
		}, function(error) {
			console.log(error);
		});
		return deferred.promise;
	}

	function editProject(project, projectId) {
		var deferred = $q.defer();
		console.log(project);
		$http({
		    method: 'PUT',
		    url: BASE_URL + 'Projects/' + projectId,
		    headers: {'Content-Type': 'application/x-www-form-urlencoded'},
		    transformRequest: function(obj) {
		        var str = [];
		        for (var p in obj) {
		        	console.log(p);
		        	if (p === 'priorities') {
	        			var priorities = obj[p].split(',');
	        			for (var i = 0; i < priorities.length; i++) {
		        			str.push('priorities[' + i + '].name=' + encodeURIComponent(priorities[i]));
	        			}
		        	} else if (p === 'labels') {
	        			var labels = obj[p].split(',');
	        			for (var i = 0; i < labels.length; i++) {
		        			str.push('labels[' + i + '].name=' + encodeURIComponent(labels[i]));
	        			}
		        	} else {
		        		str.push(encodeURIComponent(p) + '=' + encodeURIComponent(obj[p]));
		        	}
		        }
		    	console.log(str.join("&"));
		        return str.join("&");
		    },
		    data: project
		}).then(function(response) {
			deferred.resolve(response.data);
			console.log(response.data);
		}, function(error) {
			console.log(error);
		});
		return deferred.promise;
	}

	return {
		allProjects: allProjects,
		getProject: getProject,
		getIssuesByProject: getIssuesByProject,
		addProject: addProject,
		editProject: editProject
	};
}]);