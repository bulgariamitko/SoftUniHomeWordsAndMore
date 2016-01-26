function arrayObjectExtractor(input) {
	var output = [];
	for (var i = 0; i < input.length; i++) {
		if (typeof(input[i]) == 'object' && input[i].constructor != Array ) {
			output.push(input[i]);
		}
	}

	console.log(output);
}

arrayObjectExtractor(["Pesho", 4, 4.21, { "name" : "Valyo", "age" : 16 }, { "type" : "fish", "model" : "zlatna ribka" }, [1,2,3], "Gosho", { "name" : "Penka", "height": 1.65}]);