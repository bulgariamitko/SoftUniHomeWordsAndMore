function exam(input) {
	var numToCount = input[input.length - 1];
	var matrix = [];
	var match = false;
	var toRemove = [];
	var toOutout = 0;
	var result = [];
	var output = "";

	for (var iRow = 0; iRow < input.length - 1; iRow++) {
		var numbers = input[iRow].trim().split(" ");
		matrix[iRow] = [];
		// console.log(numbers);
		for (var iCol = 0; iCol < numbers.length; iCol++) {
			// console.log(numbers[iCol]);
			matrix[iRow][iCol] = numbers[iCol];
		}
	}


	for (var mRow = 0; mRow < matrix.length; mRow++) {
		toRemove[mRow] = [];
		for (var mCol = 0; mCol < matrix[mRow].length; mCol++) {
			var find = matrix[mRow][mCol];
			for (var n = 1; n < numToCount; n++) {
				if (find === matrix[mRow][mCol+n]) {
						// toRemove[mRow].slice(mCol, 1);
						// toRemove[mRow].slice(mCol+n, 1);
						toRemove[mRow][mCol] = "";
						toRemove[mRow][mCol+n] = "";
						toOutout++;
				} else {
					if (toRemove[mRow][mCol] !== "") {
						toRemove[mRow][mCol] = matrix[mRow][mCol];
					}
				}
			}
		}
		// console.log(toOutout);
		toOutout = 0;
	}

	for (var i = 0; i < toRemove.length; i++) {
		var mm = toRemove[i].toString().replace(/[,]+/g, " ");
		
		if (mm.trim() === "") {
			output += "(empty)" + "\n";
		} else {
			output += mm.trim() + "\n";
		}
	}

	console.log(output);

}

exam(["3 3 3 2 5 9 9 9 9 1 2", "1 1 1 1 1 2 5 8 1 1 7 7", "7 1 2 3 5 7 4 4 1 2", "2"]);
// exam(["1 2 3 3", "3 5 7 8", "3 2 2 1", "3"]);
// exam(["2 1 1 1", "1 1 1 ", "3 7 3 3 1", "2"]);
// exam(["1 2 3 3 2 1 ", "5 2 2 1 1 0", "3 3 1 3 3", "2"]);
