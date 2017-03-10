<?php 

$numberOne = intval(fgets(STDIN));
$numberTwo = intval(fgets(STDIN));
$numberThree = intval(fgets(STDIN));

// METHOD 1
// $largestFromOneTwo = $numberOne;

// if ($numberTwo > $numberOne) {
// 	$largestFromOneTwo = $numberTwo;
// }

// if ($numberThree > $largestFromOneTwo) {
// 	echo "Max: " . $numberThree;
// } else {
// 	echo "Max: " . $largestFromOneTwo;
// }

// METHOD 2
$largest = max($numberOne, $numberTwo, $numberThree);
echo "Max: " . $largest;