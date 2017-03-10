<?php

function findAvgOfDigits($number) {
	$count = strlen($number);
	$total = 0;
	for ($i=0; $i < strlen($number); $i++) { 
		$total += (int)$number[$i];
	}
	while ($total / $count < 5) {
		$number .= '9';

		$count = strlen($number);
		$total = 0;
		for ($i=0; $i < strlen($number); $i++) { 
			$total += (int)$number[$i];
		}
	}

	return $number;
}

// $number = '101';
// $number = '5835';

$number = trim(fgets(STDIN));

echo findAvgOfDigits($number);