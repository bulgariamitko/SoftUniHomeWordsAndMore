function calcCylinderVol(input) {
	var radius = input[0];
	var height = input[1];
	var volume = Math.PI * radius * radius * height;
	var result = Math.round(volume * 1000) / 1000;
	console.log(result);
}

calcCylinderVol([2, 4]);
console.log();
calcCylinderVol([5, 8]);
console.log();
calcCylinderVol([12, 3]);