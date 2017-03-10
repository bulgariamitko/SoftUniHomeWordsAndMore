<?php 

$nums = [];
while ($number = intval(fgets(STDIN))) {
	array_push($nums, $number);
	$largest = max($nums);
}

echo "Max: " . $largest;