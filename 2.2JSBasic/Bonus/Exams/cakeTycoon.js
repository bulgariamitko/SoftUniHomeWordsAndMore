function CakeTycoon(input) {
	var amountHeWants = input[0];
	var amountOneCakeMade = input[1];
	var kg = input[2];
	var amountTruffles = input[3];
	var priceTruffel = input[4];
	var increaseProcent = 1.25;

	var cakes = kg / amountOneCakeMade;

	if (cakes > amountHeWants) {
		var truffelCost = parseFloat(amountTruffles * priceTruffel);
		var output = parseFloat((truffelCost / amountHeWants) * increaseProcent);
		var cakePriceRounded = output.toFixed(2);
		console.log("All products available, price of a cake: " + cakePriceRounded);
	} else {
		var cakesRounded = Math.floor(cakes);
		var totalFlour = parseFloat(amountHeWants * amountOneCakeMade);
		var output = parseFloat(totalFlour - kg);
		var cakePriceRounded = output.toFixed(2);
		console.log("Can make only " + cakesRounded + " cakes, need " + cakePriceRounded + " kg more flour");
	}

	// var num = 1;
	// console.log(num.toFixed(2));
	
}

CakeTycoon([123, 1.2, 150, 15, 2000]);
CakeTycoon([20000, 0.54321, 1000, 2436, 57732]);
CakeTycoon([4455, 1.22344633589, 5654, 445999, 5778829]);