function spaceMustFlow(input) {
	let currentYield = Number(input[0]);
	let extractedSpice = 0;
	let days = 0;
	while(currentYield >= 100) {
		extractedSpice += currentYield - 26;
		currentYield -= 10;
		days++;
	}
	if (extractedSpice >= 26) {
		extractedSpice -= 26;
	}
	console.log(days);
	console.log(extractedSpice);
}

// spaceMustFlow(['111']);
// spaceMustFlow(['450']);
// spaceMustFlow(['200']);