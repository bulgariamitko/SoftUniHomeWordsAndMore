<?php
$input = fgets(STDIN);
// $input = '1375, 50000';
// $input = '1000, 4000, 8100';

$line = explode(", ", trim($input));

// take end point
$endPoint = (int)$line[0];
// remove  nd start point
array_shift($line);

foreach ($line as $startPoint) {
	// actions
	$actionCut = 0;
	$actionLap = 0;
	$actionGrind = 0;
	$actionEtch = 0;
	$actionXray = 0;

	$currentPoint = $startPoint;

	echo "Processing chunk " . $startPoint . " microns\n";

	// Cut
	while ($currentPoint > $endPoint) {
		if ($currentPoint / 4 < $endPoint) {
			break;
		}
		$currentPoint = $currentPoint / 4;
		$actionCut++;
	}
	echo "Cut x" . $actionCut . "\n";
	$currentPoint = floor($currentPoint);
	echo "Transporting and washing\n";
	if ($currentPoint == $endPoint) {
		echo "Finished crystal " . $currentPoint . " microns\n";
		continue;
	}

	// Lap
	while ($currentPoint > $endPoint) {
		if ($currentPoint - ((20 / 100) * $currentPoint) < $endPoint) {
			break;
		}
		$currentPoint = $currentPoint - ((20 / 100) * $currentPoint);
		$actionLap++;
	}
	echo "Lap x" . $actionLap . "\n";
	$currentPoint = floor($currentPoint);
	echo "Transporting and washing\n";
	if ($currentPoint == $endPoint) {
		echo "Finished crystal " . $currentPoint . " microns\n";
		continue;
	}

	// Grind
	while ($currentPoint > $endPoint) {
		if ($currentPoint - 20 < $endPoint) {
			break;
		}
		$currentPoint = $currentPoint - 20;
		$actionGrind++;
	}
	echo "Grind x" . $actionGrind . "\n";
	echo "Transporting and washing\n";
	if ($currentPoint == $endPoint) {
		echo "Finished crystal " . $currentPoint . " microns\n";
		continue;
	}

	// Etch
	while ($currentPoint > $endPoint) {
		if ($currentPoint - 1 < $endPoint) {
			break;
		}
		$currentPoint = $currentPoint - 2;
		$actionEtch++;
	}

	echo "Etch x" . $actionEtch . "\n";
	echo "Transporting and washing\n";
	if ($currentPoint == $endPoint) {
		echo "Finished crystal " . $currentPoint . " microns\n";
		continue;
	}

	// X-Ray
	$currentPoint = $currentPoint + 1;

	echo "X-ray x1\n";
	$currentPoint = floor($currentPoint);

	if ($currentPoint != $endPoint) {
		throw new Exception("The result is not legit!", 1);
		
	}
	echo "Finished crystal " . $currentPoint . " microns\n";
}


// Cut – cuts the crystal in 4
// Lap – removes 20% of the crystal’s thickness
// Grind – removes 20 microns of thickness
// Etch – removes 2 microns of thickness
// X-ray – increases the thickness of the crystal by 1 micron; this operation can only be done once!
// Transporting and washing – removes any imperfections smaller than 1 micron (round down the
// number); do this after every batch of operations that remove material


// 1375, 50000 Processing chunk 50000 microns
// Cut x2
// Transporting and washing
// Lap x3
// Transporting and washing
// Grind x11
// Transporting and washing
// Etch x3
// Transporting and washing
// X-ray x1
// Finished crystal 1375 microns

// 1000, 4000, 8100 Processing chunk 4000 microns
// Cut x1
// Transporting and washing
// Finished crystal 1000 microns
// Processing chunk 8100 microns
// Cut x1
// Transporting and washing
// Lap x3
// Transporting and washing
// Grind x1
// Transporting and washing
// Etch x8
// Transporting and washing
// Finished crystal 1000 microns