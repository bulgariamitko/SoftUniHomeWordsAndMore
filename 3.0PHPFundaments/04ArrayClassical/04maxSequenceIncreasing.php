<?php

// $line = '3 2 3 4 2 2 4';
// $line = '4 5 1 2 3 4 5';
// $line = '3 4 5 6';
// $line = '0 1 1 2 2 3 3';

$line = trim(fgets(STDIN));
$nums = explode(' ', $line);

$result = [];
$compare = $nums[0];
$length = 1;
$maxLength = 1;

for ($i=1; $i < count($nums); $i++) { 
	if ($nums[$i] - $compare >= 1) {
		$length++;
	} else {
		$length = 1;
	}
	$compare = $nums[$i];

	if ($maxLength < $length) {
		$maxLength = $length;

		for ($y=0; $y < $maxLength; $y++) { 
			if (empty($result[$y])) {
				$result[$y] = [];
			}
			$result[$y] = $nums[$i + 1 - $maxLength + $y];
		}
	}
}

echo implode(' ', $result);