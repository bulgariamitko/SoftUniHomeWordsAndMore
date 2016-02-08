function ewoksFans(input) {
	var result = 0;
	var fan = 0;
	var hater = 0;

	var startDate = new Date("1900-01-01");
	var endDate = new Date("2015-01-01");

	var biggestFan = new Date("1900-01-01");
	var biggestHater = new Date("2015-01-01");

	for (var i = 0; i < input.length; i++) {
		var myRegexp = /(\d+).(\d+).(\d+)/;
		var match = myRegexp.exec(input[i]);

		if (match) {
			var date = match[1];
			var month = match[2];
			var year = match[3];

			var d = new Date(year + "-" + month + "-" + date);
			var bornDate = new Date("1973-05-25");
			
			// console.log(d, bornDate, startDate, endDate);

			if (d > startDate && d < endDate) {
				if (d > bornDate) {
					if (d > biggestFan) {
						biggestFan = d;
						fan++;
					}
				} else {
					if (d < biggestHater) {
						biggestHater = d;
						hater++;
					}
				}
				result++;
			}
		}

	}

	if (result === 0) {
		console.log("No result");
	} 

	if (biggestFan != startDate && fan != 0) {
		console.log("The biggest fan of ewoks was born on", biggestFan.toDateString());
	}

	if (biggestHater != endDate && hater != 0) {
		console.log("The biggest hater of ewoks was born on", biggestHater.toDateString());
	}

}

ewoksFans(["22.03.2014", "17.05.1933", "10.10.1954"]);
ewoksFans(["22.03.2000"]);
ewoksFans(["22.03.1700", "01.07.2020"]);
