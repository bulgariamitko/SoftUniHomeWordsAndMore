<?php 
$line = explode(" ", trim(fgets(STDIN)));

$numbers = [];
foreach ($line as $n) {
	if (empty($numbers[$n])) {
		$numbers[$n] = 0;
	}
	$numbers[$n]++;
}

ksort($numbers);

foreach ($numbers as $number => $times) {
	echo $number . " -> " . $times . " times\n";
}