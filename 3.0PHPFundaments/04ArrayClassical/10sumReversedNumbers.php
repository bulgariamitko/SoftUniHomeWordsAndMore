<?php 

// $line = '123 234 12';
// $line = '12 12 34 84 66 12';
// $line = '120 1200 12000';

$line = trim(fgets(STDIN));
$nums = explode(' ', $line);
$total = 0;

foreach ($nums as $number) {
	$num = strrev($number);
	$total += (int)$num;
}

echo $total;