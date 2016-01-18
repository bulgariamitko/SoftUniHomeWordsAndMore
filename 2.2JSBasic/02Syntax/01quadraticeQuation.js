function quadraticEquation(input) {

	root = Math.pow(input[1],2) - 4 * input[0] * input[2];
	root1 = (-input[1] + Math.sqrt(root))/(2*input[0]);
	root2 = (-input[1] - Math.sqrt(root))/(2*input[0]);

	if (root1 === root2) {
		console.log("X = " + root2);
	} else if (root1 && root2) {
		console.log("X1 = " + root2);
		console.log("X2 = " + root1);
	} else {
		console.log("No real rots");
	}
	
}

quadraticEquation([2, 5, -3]);
console.log();
quadraticEquation([2, -4, 2]);
console.log();
quadraticEquation([4, 2, 1]);