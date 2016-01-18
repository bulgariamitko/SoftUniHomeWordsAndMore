function lifetimeSupplyCalc(input) {
	var age = input[0];
	var maxAge = input[1];
	var food = input[2];
	var foodPerDay = input[3];
	var numOfDays = 365;

	var yearsLeft = maxAge - age;
	var allDays = yearsLeft * numOfDays;
	var foodAllDays = allDays * foodPerDay;

	console.log(foodAllDays + "kg of " + food + " would be enough until I am " + maxAge + " years old.");
}

lifetimeSupplyCalc([38, 118, "chocolate", 0.5]);
console.log();
lifetimeSupplyCalc([20, 87, "fruits", 2]);
console.log();
lifetimeSupplyCalc([16, 102, "nuts", 1.1]);