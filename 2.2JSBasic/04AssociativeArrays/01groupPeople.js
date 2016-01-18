function groupPeople(input) {
	var array = {};
	function Person(firstname, lastname, age) {
		array = ({"firstName": firstname, "lastName": lastname, "age": age});
		return array;
	}

	var people = [
	    new Person("Scott", "Guthrie", 38),
	    new Person("Scott", "Johns", 36),
	    new Person("Scott", "Hanselman", 39),
	    new Person("Jesse", "Liberty", 57),
	    new Person("Jon", "Skeet", 38)
	];

	function group(people, key) {
	    var associativeArray = {};
	    for (var i in people) {
	        var assoProperty = people[i][key];
	        associativeArray[assoProperty] = [];
	        for (var k in people) {
	            if (assoProperty === people[k][key]) {
	                associativeArray[assoProperty].push(people[k]);
	            }
	        }
	    }
	    return associativeArray;
	}

	var myRegexp = /groupBy\('([A-Za-z]+)'\);/g;
	var match = myRegexp.exec(input);
    var groupped = group(people, match[1]);

    console.log(groupped);

}

groupPeople("groupBy('firstName');");
// groupPeople("groupBy('age');");
// groupPeople("groupBy('lastName');");