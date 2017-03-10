<?php
function isVolume($x, $y, $z) {
	$x1 = 10; $x2 = 50;
	$y1 = 20; $y2 = 80;
	$z1 = 15; $z2 = 50;

	if ($x >= $x1 && $x <= $x2) {
		if ($y >= $y1 && $y <= $y2) {
			if ($z >= $z1 && $z <= $z2) {
				return true;
			}
		}
	}

	return false;
}

// $line = explode(", ", "8, 20, 22");
// $line = explode(", ", "13.1, 50, 31.5, 50, 80, 50, -5, 18, 43");

$line = explode(" ", trim(fgets(STDIN)));

for ($i=0; $i < count($line); $i += 3) {
	$x = $line[$i];
	$y = $line[$i+1];
	$z = $line[$i+2];

	if (isVolume($x, $y, $z)) {
		echo "inside\n";
	} else {
		echo "outside\n";
	}
}

// echo "<pre>";
// print_r($line);
// echo "</pre>";