function exam(input) {
	var output = [];

	for (var i = 0; i < input.length - 1; i++) {
		input[i] = input[i].trim();
		var splitting = input[i].split(/\s+/);
		var student = splitting[0];
		var course = splitting[1].trim();
		var examPoints = Number(splitting[2]);
		var courseBonus = Number(splitting[3]);

		var coursePoints = examPoints - (examPoints * 0.8);
		coursePoints += courseBonus;

		if (output[course] === undefined) {
			output[course] = 0;
			output[course + "counter"] = 0;
		}

		output[course] += examPoints;
		output[course + "counter"]++;

		// console.log(output[course + "counter"], course);
		var score = ((coursePoints / 80) * 4) + 2;
		if (score > 6) {
			score = 6;
		}

		if (examPoints < 100) {
			console.log(student + ' failed at "' + course + '"');
		} else {
			coursePoints = Math.round(coursePoints * 100) / 100;
			console.log(student + ': Exam - "' + course + '"; Points - ' + coursePoints + '; Grade - ' + score.toFixed(2));	
		}	
	}

// console.log(input[input.length - 1]);

	var examToCal = input[input.length - 1];
	examToCal = examToCal.trim();
	var avg = (output[examToCal] / output[examToCal + "counter"]);
	// console.log(output[examToCal], output[examToCal + "counter"]);
	avg = Math.round(avg * 100) / 100;
	// console.log(output[examToCal], output[examToCal + "counter"]);
	console.log('"' + examToCal + '" average points -> ' + avg);

}

// exam(["Pesho Java-Basics 100 3", "Gosho    Java-Basics    157   3", "Tosho HTML&CSS 317 12", "Minka C#-Advanced 57 15", "Stanka C#-Advanced 157 15", "Kircho C#-Advanced 300 0", "Niki C#-Advanced 400 10", "Java-Basics"]);
// exam(["Student1 JS-Basics 0 0", "Student2 JS-Basics 4 1000", "Student3 JS-Basics 8 15", "Student4 JS-Basics 12 2", "Student5 JS-Basics 16 2", "Student6 JS-Basics 20 2", "Student7 JS-Basics 24 2", "Student1 JS-Basics 28 0", "Student2 JS-Basics 32 1000", "Student3 JS-Basics 36 15", "Student4 JS-Basics 40 2", "Student5 JS-Basics 44 2", "Student6 JS-Basics 48 2", "Student7 JS-Basics 52 2", "Student1 JS-Basics 56 0", "Student2 JS-Basics 60 1000", "Student3 JS-Basics 64 15", "Student4 JS-Basics 68 2", "Student5 JS-Basics 72 2", "Student6 JS-Basics 76 2", "Student7 JS-Basics 80 2", "Student1 JS-Basics 84 0", "Student2 JS-Basics 88 1000", "Student3 JS-Basics 92 15", "Student4 JS-Basics 96 2", "Student5 JS-Basics 100 2", "Student6 JS-Basics 104 2", "Student7 JS-Basics 108 2", "Student1 JS-Basics 112 0", "Student2 JS-Basics 116 1000", "Student3 JS-Basics 120 15", "Student4 JS-Basics 124 2", "Student5 JS-Basics 128 2", "Student6 JS-Basics 132 2", "Student7 JS-Basics 136 2", "Student1 JS-Basics 140 0", "Student2 JS-Basics 144 1000", "Student3 JS-Basics 148 15", "Student4 JS-Basics 152 2", "Student5 JS-Basics 156 2", "Student6 JS-Basics 160 2", "Student7 JS-Basics 164 2", "Student1 JS-Basics 168 0", "Student2 JS-Basics 172 1000", "Student3 JS-Basics 176 15", "Student4 JS-Basics 180 2", "Student5 JS-Basics 184 2", "Student6 JS-Basics 192 2", "Student7 JS-Basics 196 2", "Student1 JS-Basics 200 0", "Student2 JS-Basics 204 1000", "Student3 JS-Basics 208 15", "Student4 JS-Basics 212 2", "Student5 JS-Basics 216 2", "Student6 JS-Basics 220 2", "Student7 JS-Basics 224 2", "Student1 JS-Basics 228 0", "Student2 JS-Basics 232 1000", "Student3 JS-Basics 236 15", "Student4 JS-Basics 240 2", "Student5 JS-Basics 244 2", "Student6 JS-Basics 248 2", "Student7 JS-Basics 252 2", "Student1 JS-Basics 256 0", "Student2 JS-Basics 260 1000", "Student3 JS-Basics 264 15", "Student4 JS-Basics 268 2", "Student5 JS-Basics 272 2", "Student6 JS-Basics 276 2", "Student7 JS-Basics 280 2", "Student4 JS-Basics 284 2", "Student5 JS-Basics 292 2", "Student6 JS-Basics 296 2", "Student7 JS-Basics 300 2", "Student1 JS-Basics 304 0", "Student2 JS-Basics 308 1000", "Student3 JS-Basics 312 15", "Student4 JS-Basics 316 2", "Student5 JS-Basics 320 2", "Student6 JS-Basics 324 2", "Student7 JS-Basics 328 2", "Student1 JS-Basics 332 0", "Student2 JS-Basics 336 1000", "Student3 JS-Basics 340 15", "Student4 JS-Basics 344 2", "Student5 JS-Basics 348 2", "Student6 JS-Basics 352 2", "Student7 JS-Basics 356 2", "Student1 JS-Basics 360 0", "Student2 JS-Basics 364 1000", "Student3 JS-Basics 368 15", "Student4 JS-Basics 372 2", "Student5 JS-Basics 376 2", "Student6 JS-Basics 380 2", "Student7 JS-Basics 384 2", "Student3 JS-Basics 392 15", "Student4 JS-Basics 396 2", "Student5 JS-Basics 400 2", "Student6 JS-Basics 123 2", "Student7 JS-Basics 123 2", "JS-Basics"]);
exam(["   Bankin    HTML&CSS                0          0         ", "           RoYaL        HTML5&CSS        340         10        ", "       Bi0GaMe      Java   10    10     ", "Stamat HQC   190 10", "MINKA OOP   230 10", "   Java    "]);
