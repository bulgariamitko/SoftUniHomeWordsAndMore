<?php 
function Cooking($number, $commands) {
	switch ($commands) {
		case 'chop':
			$number /= 2;
			break;
		case 'dice':
			$number = sqrt($number);
			break;
		case 'spice':
			$number += 1;
			break;
		case 'bake':
			$number *= 3;
			break;
		case 'fillet':
			$number *= ((100-20) / 100);
			break;
		default:
			throw new Exception("Error Processing Request", 1);
			break;
	}
	return $number;
}

// $number = '32';
// $commands = explode(", ", 'chop, chop, chop, chop, chop');

// $number = '9';
// $commands = explode(", ", 'dice, spice, chop, bake, fillet');

$number = (int)trim(fgets(STDIN));
$commands = explode(", ", trim(fgets(STDIN)));

foreach ($commands as $command) {
	$number = Cooking($number, $command);
	echo $number . "\n";
}
