function courseGradeScaling(input) {
	// var array = [];
	input.forEach(function(i) {
		i['score'] += i['score'] * 0.1;
		if (i['score'] >= 100) {
			i['hasPassed'] = true;
			// array.push(i);
		} else {
			input.pop(i);
		}
	});

	function sortByKey(array, key) {
	    return array.sort(function(a, b) {
	        var x = a[key]; var y = b[key];
	        return ((x < y) ? -1 : ((x > y) ? 1 : 0));
	    });
	}

	result = sortByKey(input, 'name');
	
	var array = [];
	input.forEach(function(i) {
		array.push('{"name":"' + i['name'] + '","score":' + i['score'] + '","hasPassed":' + i['hasPassed'] + '}');
	});

	var result2 = array.join(", ");
	console.log("[" + result2 + "]");
}

courseGradeScaling(
	[
	    {
	        'name' : 'Пешо',
	        'score' : 91
	    },
	    {
	        'name' : 'Лилия',
	        'score' : 290
	    },
	    {
	        'name' : 'Алекс',
	        'score' : 343
	    },
	    {
	        'name' : 'Габриела',
	        'score' : 400
	    },
	    {
	        'name' : 'Жичка',
	        'score' : 70
	    }
	]
);