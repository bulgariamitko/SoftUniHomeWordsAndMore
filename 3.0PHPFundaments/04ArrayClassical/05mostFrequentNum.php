<?php 

// $line = '4 1 1 4 2 3 4 4 1 2 4 9 3';
// $line = '2 2 2 2 1 2 2 2';
// $line = '7 7 7 0 2 2 2 0 10 10 10';

$line = trim(fgets(STDIN));
$nums = explode(' ', $line);

$output = [];

foreach ($nums as $key => $value) {
	if (empty($output[$value])) {
		$output[$value] = 0;
	}
	$output[$value]++;
}

$max = max($output);
$find = array_search($max, $output);

echo $find;