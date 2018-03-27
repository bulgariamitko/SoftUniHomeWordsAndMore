angular.module('socialNetwork.users.identity', []).factory('identity', ['$http', '$q', 'BASE_URL', function($http, $q, BASE_URL) {
	var deferred = $q.defer();
	var currentUser = undefined;
	var accessToken = 'KFotgPC8mWLU5A8P6t67e7QWJVFQvPS324_gbcMVnkvs6quZCpoISzGIU7AnGOP4GaJ8qsDpMdsUdsu0JCvaCDsx6Dj0tbLFMPXT01vcdpowJRXn1zMm0BDY7FyW2KMgZQ-o7WKpUmqmLuGU5R5x0R9IzpkX6eklINZ6ieuhnoYD_k8W4owAQt0koCeGZaOyi-sRJB7tjHV6qrg35znn72QSMPliXGv-TiSMM8QAlGbW-RPkKx6gOxPqG18Xet_mScsBFebOdQszVuJahTQi9Xid1pM7w-q2mC1Ql3-G75Yg5ZFVecozURegFkAsyPUBhnP4ERJh1IPn-ChTcB3CzOxoUEQ5ZV0RlgFY2vWqbrzF3KBqvXbZ0_zzuJlZMYZgIY19qDZ46RBQmc9dYGat5Fdl5X_D-K7S2HWedeP9cYK6J4CetiQbjg7cW9MNRIRHPVjNQ2v4tqCbzC0FrxdQtwCyF5ugBuA1o5VhrlXXBzXbPM4KBsmCXzeWlk0ehD64';
	$http.defaults.headers.common.Authorization = 'Bearer ' + accessToken;
	$http.get(BASE_URL + 'me').then(function(response) {
		currentUser = response.data;
		deferred.resolve(currentUser);
	});
	
	return {
		getCurrentUser: function() {
			if (currentUser) {
				return $q.when(currentUser);
			} else {
				return deferred.promise;
			}
		},
		isAuth: function() {
			return true;
		}
	};
}]);