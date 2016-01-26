function uncleScroogeBag(input) {
	var allCoins = 0;
	for (var i = 0; i < input.length; i++) {
		var coin = input[i].toLowerCase();
		var myRegexp = /coin\s*(\d+)[.]?[0]*$/;
		var match = myRegexp.exec(coin);
		if (match != null) {
			allCoins += parseInt(match[1].trim());
		}
	}

	var gold = Math.floor(allCoins / 100);
	var silver = Math.floor((allCoins % 100) / 10);
	var bronze = Math.floor(allCoins % 10);
	console.log("gold : " + gold);
	console.log("silver : " + silver);
	console.log("bronze : " + bronze);
}

uncleScroogeBag(['coin 1','coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100', 'coin 200', 'coin 500','cigars 1']);
uncleScroogeBag(['coin one', 'coin two', 'coin five', 'coin ten', 'coin twenty', 'coin fifty', 'coin hundred', 'cigars 1']);
uncleScroogeBag(['coin 1', 'coin two', 'coin 5', 'coin 10.50', 'coin 20', 'coin 50', 'coin hundred', 'cigars 1']);
uncleScroogeBag(["coin 10041", "coin 0.99", "coin -5", "coin 105.0", "coin 2002.01", "coin fifty", "coin -100", "cigars 1"]);
uncleScroogeBag(["cOin 1", "Coin 2", "coiN 45", "coin 100", "coIn 29", "coin 545", "coin hundred", "cigars 1"]);