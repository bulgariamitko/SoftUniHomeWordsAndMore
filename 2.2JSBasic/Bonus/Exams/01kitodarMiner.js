function kitodarMiner(input) {
	var totalSilver = 0;
	var totalGold= 0;
	var totalDiamonds = 0;

	for (var i = 0; i < input.length; i++) {
		var myRegexp = /-\s*(gold|diamonds|silver)\s*:\s*(\d+)$/i;
		var match = myRegexp.exec(input[i]);
		if (match) {
			var sortOf = match[1].toLowerCase();
			var qtty = Number(match[2]);
			// console.log(sortOf, qtty);
			if (sortOf == "silver") {
				totalSilver += qtty;
			} else if (sortOf == "gold") {
				totalGold += qtty;
			} else if (sortOf == "diamonds") {
				totalDiamonds += qtty;
			}
		}
	}

	// console.log(totalSilver, totalGold, totalDiamonds);

	console.log("*Silver: " + totalSilver);
	console.log("*Gold: " + totalGold);
	console.log("*Diamonds: " + totalDiamonds);

}

kitodarMiner(["mine bobovDol - gold: 10", "mine medenRudnik - silver: 22", "mine chernoMore - shrimps : 24", "gold: 50"]);
kitodarMiner(["mine bobovdol - gold: 10", "mine - diamonds: 5", "mine colas - wood: 10", "mine myMine - silver:  14", "mine silver:14 - silver: 14"]);
