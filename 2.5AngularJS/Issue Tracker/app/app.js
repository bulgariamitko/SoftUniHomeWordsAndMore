angular.module('issueTracker',
	['ngRoute',
	'angular-loading-bar',
	'issueTracker.common', 
	'issueTracker.home', 
	'issueTracker.projects',
	'issueTracker.issues',
	'issueTracker.users.Password',
	'issueTracker.users.identity'])
.run(['$rootScope', '$location', function($rootScope, $location) {
	$rootScope.$on('$routeChangeError', function(event, next, previous, error) {
		if (error.isAuth === undefined && !error.isAdmin) {
			noty({
		        text: 'Sorry you must be an admin in order to access this page',
		        type: 'error',
		        layout: 'topCenter',
		        timeout: 5000
		    });
		    $location.path('/');
		} else {
			noty({
		        text: 'Sorry you must first login/register to the website in order to view this page',
		        type: 'error',
		        layout: 'topCenter',
		        timeout: 5000
		    });
		    $location.path('/');
		}
	});
}])
.config(['$routeProvider', function($routeProvider) {
		$routeProvider.otherwise({redirectTo: '/'});
}]).constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/');