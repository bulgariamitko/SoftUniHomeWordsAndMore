function pricesTrends(input) {
	console.log("<table>");
	console.log("<tr><th>Price</th><th>Trend</th></tr>");
	var initNum = parseFloat(input[0]).toFixed(2);
	var initSecondNum = parseFloat(input[1]).toFixed(2);
	console.log('<tr><td>' + initNum + '</td><td><img src="fixed.png"/></td></td>');

	if (!isNaN(initSecondNum)) {
		if (initNum > initSecondNum) {
			console.log('<tr><td>' + initSecondNum + '</td><td><img src="down.png"/></td></td>');
		} else if (initNum < initSecondNum) {
			console.log('<tr><td>' + initSecondNum + '</td><td><img src="up.png"/></td></td>');
		} else {
			console.log('<tr><td>' + initSecondNum + '</td><td><img src="fixed.png"/></td></td>');
		}
	}
	

	for (var i = 1; i < input.length; i++) {

		var firstNum = parseFloat(input[i]).toFixed(2);
		var secondNum = parseFloat(input[i+1]).toFixed(2);

		// console.log(firstNum, secondNum);
		if (!isNaN(secondNum)) {
			if (parseFloat(firstNum) > parseFloat(secondNum)) {
				console.log('<tr><td>' + secondNum + '</td><td><img src="down.png"/></td></td>');
			} else if (parseFloat(firstNum) < parseFloat(secondNum)) {
				console.log('<tr><td>' + secondNum + '</td><td><img src="up.png"/></td></td>');
			} else {
				console.log('<tr><td>' + secondNum + '</td><td><img src="fixed.png"/></td></td>');
			}
		}

		
	}

	console.log("</table>");
}

pricesTrends([50, 60]);
pricesTrends([36.333, 36.5, 37.019, 35.4, 35, 35.001, 36.225]);
pricesTrends([1.33, 1.35, 2.25, 13.00, 0.5, 0.51, 0.5, 0.5, 0.33, 1.05, 1.346, 20, 900, 1500.1, 1500.10, 2000]);
pricesTrends([1]);