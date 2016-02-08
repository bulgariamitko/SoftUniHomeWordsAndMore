function keepTheChange(input) {
	var bill = Number(input[0]);
	var mood = input[1];
	var tip = 0;
	var result = 0;
	if (mood === "happy") {
		tip = 0.1;
		result = bill * tip;
	} else if (mood === "married") {
		tip = 0.0005;
		result = bill * tip;
	} else if (mood === "drunk") {
		tip = 0.15;
		var cal = bill * tip;
		var firstDigit = cal.toString().match(/[^0.]/);
		var fDig = Number(firstDigit[0]);
		console.log(tip, cal, fDig, cal * fDig);

		result = cal * fDig;
	} else {
		tip = 0.05;
		result = bill * tip;
	}

	console.log(result.toFixed(2));
}

keepTheChange(["120.44", "happy"]);
keepTheChange(["1230.83", "drunk"]);
keepTheChange(["716.00", "bored"]);
keepTheChange(["19841999.99", "drunk"]);
