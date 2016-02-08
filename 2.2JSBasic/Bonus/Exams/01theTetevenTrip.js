function theTetevenTrip(input) {
	var totalFuelConsum = 0;

	for (var i = 0; i < input.length; i++) {
		var arrayOfIt = input[i].split(" ");
		var model = arrayOfIt[0].trim();
		var engine = arrayOfIt[1].trim();
		var routeNum = Number(arrayOfIt[2].trim());
		var lugges = Number(arrayOfIt[3].trim());

		var littersPer100km = 10;
		var correctionGas = 1.2;
		var correctionPetrol = 1;
		var correctionDiesel = 0.8;

		var fuelConsum = 0;
		if (engine === "gas") {
			fuelConsum = correctionGas * littersPer100km;
		} else if (engine == "petrol") {
			fuelConsum = correctionPetrol * littersPer100km;
		} else if (engine == "diesel") {
			fuelConsum = correctionDiesel * littersPer100km;
		}

		var forEverykgOfLugges = 0.01;
		var	fuelConsumOfLugges = lugges * forEverykgOfLugges;

		totalFuelConsum = fuelConsum + fuelConsumOfLugges;
		var extraSnowConsum = 0.3 * totalFuelConsum;
		var routeKm = 0;
		var ttConsum = 0;
		var snowRounte = 0;
		var ttSnow = 0;
		if (routeNum === 1) {
			routeKm = 110;
			snowRounte = 10;
			ttSnow = snowRounte*(extraSnowConsum/100);
			ttConsum = routeKm*(totalFuelConsum/100);
		} else if (routeNum === 2) {
			routeKm = 95;
			snowRounte = 30;
			ttSnow = snowRounte*(extraSnowConsum/100);
			ttConsum = routeKm*(totalFuelConsum/100);
		}

		var output = Math.round(ttConsum + ttSnow);
		

		console.log(model, engine, routeNum, output);
	}
}

theTetevenTrip(['BMW petrol 1 320.5','Golf petrol 2 150.75','Lada gas 1 202','Mercedes diesel 2 312.54']);
