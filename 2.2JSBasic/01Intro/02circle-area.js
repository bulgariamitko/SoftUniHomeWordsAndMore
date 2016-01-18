var input = document.getElementsByClassName("number");
var result = document.getElementsByClassName("results");

function circleArea(n) {
	return Math.PI * n * n;
}

for (var i = input.length - 1; i >= 0; i--) {
	var num = parseFloat(input[i].textContent);
	console.log(num);
	result[i].innerHTML = circleArea(num);
}