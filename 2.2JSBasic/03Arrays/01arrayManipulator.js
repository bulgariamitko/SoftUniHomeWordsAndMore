function arrayManipulator(input) {
	var array = [];
	input.forEach(function(i) {
		if (!isNaN(i)) {
			array.push(parseInt(i));
		}
	});

	var minNum = Math.min.apply(null, array);
	var maxNum = Math.max.apply(null, array);
	console.log("Min number: " + minNum);
	console.log("Max number: " + maxNum);

	var mostFq = array.reduce(function(o, s) {
    o.freq[s] = (o.freq[s] || 0) + 1;
    if(!o.freq[o.most] || o.freq[s] > o.freq[o.most])
        o.most = s;
    return o;
}, { freq: { }, most: '' });

	console.log("Most frequent number: " + mostFq.most);
	array.sort(function(a, b){return b-a});

	// result
	var result = array.join(", ");
	console.log("[" + result + "]");
}

arrayManipulator(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount : 10}, [10, 20, 30, 40]]);