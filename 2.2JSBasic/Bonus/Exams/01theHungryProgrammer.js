function theHungryProgrammer(input, input2) {
	var meals = input;
	var commands = input2;
	var mealsEaten = 0;
	var end = false;
	for (var i = 0; i < input2.length; i++) {
		var commandsSplit = input2[i].split(" ");
		switch(commandsSplit[0]) {
			case 'Serve':
				if (input.length > 0) {
					var lastMeal = input.splice(-1,1)
					console.log(lastMeal + ' served!');
				}
				break;
			case 'Add':
				if (commandsSplit[1] != undefined) {
					input.unshift(commandsSplit[1]);
				}

				// console.log(input.toString());
				break;
			case 'Shift':
				var index1 = commandsSplit[1];
				var index2 = commandsSplit[2];
				var temp = input[index1];
				input[index1] = input[index2];
				input[index2] = temp;

				// console.log(input.toString());
				break;
			case 'Eat':
				var firstMeal = input.shift();
				mealsEaten++;
				console.log(firstMeal + ' eaten');
				break;
			case 'Consume':
				var index1 = commandsSplit[1];
				var index2 = commandsSplit[2];
				input.splice(index1, index2);

				for (var i = index1; i <= index2; i++) {
					mealsEaten++;
				}

				if (index1 == 0 && index2 >= input.length) {
					input = [];
				}

				// console.log("TEST: " + index1, 0, index2, input.length);

				console.log('Burp!');
				// console.log(input.toString());
				break;
			case 'End':
				end = true;
				break;
		}

		if (end) {
			break;
		}

		// commands
		// console.log(input2[i]);
	}

	if (input.length == 0) {
		console.log('The food is gone');
	} else {
		console.log('Meals left: ' + input.join(', '));
		
	}
	
	console.log('Meals eaten: ' + mealsEaten);
}

theHungryProgrammer(['chicken', 'steak', 'eggs'],
['Serve',
 'Eat',
 'End',
 'Consume 0 1']);

 theHungryProgrammer(['fries', 'fish', 'beer', 'chicken', 'beer', 'eggs'],
['Add spaghetti',
 'Shift 0 1',
 'Consume 1 4',
 'End']);

 theHungryProgrammer(['carrots', 'apple', 'beet'],
['Consume 0 2',
 'End',]);