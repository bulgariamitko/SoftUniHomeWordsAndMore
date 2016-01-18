function fiveSpecialLetters(input) {
	function calcWeight(word) {
		var used = {};
		var weight = 0;
		var index = 1;
		for (var i = 0; i < word.length; i++) {
			var letter = word[i];
			// used[letter] = true;
			if (!(used[letter])) {
				// console.log('yes');
				weight += index * calcLetterWeight(letter);
				index++;
				used[letter] = true;
			}
		}
		return weight;
	}

	function calcLetterWeight(letter) {
		switch(letter) {
			case 'a': return 5;
			case 'b': return -12;
			case 'c': return 47;
			case 'd': return 7;
			case 'e': return -32;
			default: return 0;
		}
		

	}

	minWeight = input[0];
	maxWeight = input[1];
	// console.log(minWeight);
	// console.log(maxWeight);

	resultCount = 0;
	var a = 'a'.charCodeAt(0);
	var b = 'b'.charCodeAt(0);
	var c = 'c'.charCodeAt(0);
	var d = 'd'.charCodeAt(0);
	var e = 'e'.charCodeAt(0);

	console.log(calcWeight('eeead'));

	for (var i = a; i < e; i++) {
		for (var i2 = a; i2 < e; i2++) {
			for (var i3 = a; i3 < e; i3++) {
				for (var i4 = a; i4 < e; i4++) {
					for (var i5 = a; i5 < e; i5++) {
						var convertA = String.fromCharCode(i);
						var convertB = String.fromCharCode(i2);
						var convertC = String.fromCharCode(i3);
						var convertD = String.fromCharCode(i4);
						var convertE = String.fromCharCode(i5);
						var word = convertA + convertB + convertC + convertD + convertE;
						// console.log(word);
						var weight = calcWeight(word);
						if (word == 'bcead') {
							console.log("YESSS");
						}
						// console.log(weight);
						if (weight >= minWeight && weight <= maxWeight) {
							if (resultCount > 0) {
								console.log(" ");
							}
							console.log(word);
							resultCount++;
						}
					}
				}
			}
		}
	}

	if (resultCount == 0) {
		console.log("No");
	}
}

fiveSpecialLetters([40, 42]);
