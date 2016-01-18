function beerStock(input) {
	var reservedBeers = input[0];
	var allBeers = 0;

	for (var i = 1; i < input.length; i++) {
		var beer = input[i];
		if (beer == "Exam Over") {
			break;
		}

		var myRegexp = /([0-9]+) ([a-z]+)/g;
		var match = myRegexp.exec(input[i]);
		var numOfBeers = parseInt(match[1]);
	    var beerInWhat = match[2];

	    if (beerInWhat == "beers") {
	    	allBeers += numOfBeers;
	    } else if (beerInWhat == "cases") {
	    	allBeers += numOfBeers * 24;
	    } else if (beerInWhat == "sixpacks") {
	    	allBeers += numOfBeers * 6;
	    }

	    
	}

		// console.log(allBeers);
	    var brokenBeers = Math.floor(allBeers / 100);
	   // console.log(brokenBeers);

	   var howLeft = allBeers - reservedBeers;

	   var howLeftWorked = Math.abs(howLeft);
	   // console.log(howLeftWorked);

	   allBeers -= brokenBeers;


	if (howLeft >= 0) {
		allBeers -= reservedBeers;
		// console.log("ALL BEERS:" + allBeers);
		var cases = Math.floor(allBeers / 24);
	   var beersLeft = allBeers % 24;
		// console.log("BeersLeft1: " + beersLeft);
	   var sixpacks = Math.floor(beersLeft / 6);
	   // console.log("SIXPACKS: " + sixpacks);
	   var beersLeft2 = beersLeft % 6;
	   // console.log(sixpacks);
		console.log("Cheers! Beer left: " + cases.toString() + " cases, " +  sixpacks.toString() + " sixpacks and " + beersLeft2.toString() + " beers.");
	} else {
		var cases = Math.floor(howLeftWorked / 24);
	   var beersLeft = howLeftWorked % 24;
		// console.log("BeersLeft1: " + beersLeft);
	   var sixpacks = Math.floor(beersLeft / 6);
	   // console.log("SIXPACKS: " + sixpacks);
	   var beersLeft2 = sixpacks % 6;
		console.log("Not enough beer. Beer needed: " + cases.toString() +" cases, " + sixpacks.toString() + " sixpacks and " + beersLeft2.toString() + " beers.");
	}
	
}

beerStock([197, "1 beers", "2 cases", "7 sixpacks", "3 beers", "Exam Over"]);
beerStock([23, "11 beers", "3 beers", "8 cases", "Exam Over"]);