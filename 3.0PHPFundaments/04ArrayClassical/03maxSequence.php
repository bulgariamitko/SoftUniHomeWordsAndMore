<?php 

// $line = "2 1 1 2 3 3 2 2 2 1";

// $line = "1 1 1 2 3 1 3 3";

// $line = "4 4 4 4";

// $line = "0 1 1 5 2 2 6 3 3";

$line = trim(fgets(STDIN));

$nums = explode(' ', $line);

$longestNums = [];
$all = [];

for ($i=0; $i < count($nums); $i++) {
	if (empty($longestNums[$nums[$i]])) {
		$longestNums[$nums[$i]] = 0;
	}
	$longestNums[$nums[$i]]++;

	array_push($all, $longestNums);
	
	if ($i == count($nums) - 1) {
		break;
	}
	if (!key_exists($nums[$i+1], $longestNums)) {
		$longestNums = [];
	}
}

$repeat = 0;
$num = 0;

foreach ($all as $numsArr) {
	foreach ($numsArr as $key => $value) {
		if ($value > $repeat) {
			$repeat = $value;
			$num = $key;
		}
	}
}

$output = array_fill(0, $repeat, $num);

echo implode(' ', $output);