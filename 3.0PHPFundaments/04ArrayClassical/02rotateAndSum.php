<?php 

$line = trim(fgets(STDIN));
$rotate = trim(fgets(STDIN));

$nums = explode(' ', $line);

$tempArray = [];

for ($i=0; $i < $rotate; $i++) { 
	// store last value
	$last = end($nums);
	// remove last value
	unset($nums[count($nums) - 1]);
	// add element to begging of the array
	array_unshift($nums, $last);
	array_push($tempArray, $nums);
}

$sum = [];

foreach ($tempArray as $num) {
	for ($i=0; $i < count($num); $i++) {
		if (empty($sum[$i])) {
			$sum[$i] = 0;
		}
		$sum[$i] += $num[$i];
	}
}

echo implode(' ', $sum);