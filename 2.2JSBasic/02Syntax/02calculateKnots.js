function calculateKnots(input) {
	var knots = input / 1.852;
	var result = Math.round(knots * 100) / 100;

	console.log(result);
}

calculateKnots(20);
console.log();
calculateKnots(112);
console.log();
calculateKnots(400);