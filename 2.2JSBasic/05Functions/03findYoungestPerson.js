function findYoungestPerson(input) {
	var output = { firstname : 'none', lastname : 'none', age: 1111};
	for (var i = 0; i < input.length; i++) {
		if (input[i]['hasSmartphone']) {
			if (input[i]['age'] < output['age']) {
				output = { firstname : input[i]['firstname'], lastname : input[i]['lastname'], age: input[i]['age']};
			}
		}
	}

	console.log("The youngest person is " + output['firstname'] + " " + output['lastname']);
}

var people = [
  { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false }, 
  { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
  { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
  { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }
];

findYoungestPerson(people);