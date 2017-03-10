<?php 

$operation = $argv[1];

$numberOne = intval(fgets(STDIN));
$numberTwo = intval(fgets(STDIN));

if ($operation == "sum") {
	echo " == " . ($numberOne + $numberTwo);
} elseif ($operation == "subtract") {
	echo " == " . ($numberOne - $numberTwo);
} else {
	echo " == Wrong operation supplied.";
}
