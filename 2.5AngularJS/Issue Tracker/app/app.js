angular.module('issueTracker',
	['ngRoute', 
	'issueTracker.common', 
	'issueTracker.home', 
	'issueTracker.dashboard', 
	'issueTracker.users.identity']).config(['$routeProvider', function($routeProvider) {
		$routeProvider.otherwise({redirectTo: '/'});
}]).constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/');