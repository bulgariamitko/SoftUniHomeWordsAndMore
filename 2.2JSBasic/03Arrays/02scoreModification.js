function scoreModification(input) {
	input.sort(function(a, b){return a-b});

	var array = [];
	var procent = 0.2;
	input.forEach(function(i) {
		if (i >= 0 && i <= 400) {
			array.push(i - (i * 0.2));
		}
	});

	console.log(array);
}

scoreModification([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);