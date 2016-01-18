function masterHerbalist(input) {
	var totalhours = input[0];
	var totalHerbs = 0;
	var totalDays = 0;
	var totalEarnings = 0;

	for (var i = 1; i < input.length; i++) {
		if (input == "Season Over") {
			break;
		}

		totalDays++;
		var myRegexp = /([0-9]+) ([A-Z]+) ([0-9]+)/g;
		var match = myRegexp.exec(input[i]);


		if (match != null) {
			var hours = parseInt(match[1]);
			var path = match[2];
			var price = parseInt(match[3]);

			var pathLen = path.length;
			var index = 0;

		for (var i2 = 0; i2 < hours; i2++) {
			
				if (index >= pathLen) {
					index = 0;
				}

				if (path[index] == "H") {
					totalHerbs += price;
				}

				
				// console.log(path[index]);
				index += 1;
		
		}

		totalEarnings = totalHerbs / totalDays;
		// console.log(totalEarnings);
		
		}
		
	}

	var result = totalEarnings - totalhours;

	if (result >= 0) {
		console.log("Times are good. Extra money per day: " + result.toFixed(2) + ".");
	} else {
		console.log("We are in the red. Money needed: " + result.toFixed(2) + ".");
	}
}

// masterHerbalist([250, "5 MMZHQQQQ 37", "11 ZZHHHQ 80", "Season Over"]);
// masterHerbalist([477, "9 QQQQQQQ 999", "2 HH 15", "6 HKKKKKKK 5", "Season Over"]);
// masterHerbalist([133, "12 QQHWWHEEH 50", "6 HAHA 33", "Season Over"]);
