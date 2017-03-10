<?php
function getLimit($zone) {
	switch ($zone) {
		case 'motorway':
			$speedLimit = 130;
			break;
		case 'interstate':
			$speedLimit = 90;
			break;
		case 'city':
			$speedLimit = 50;
			break;
		case 'residential':
			$speedLimit = 20;
			break;
		default:
			echo "Not a Valid Input";
			$speedLimit = 1000;
	}
	return $speedLimit;
}

function getInfraction($speed, $limit) {
	$overSpeed = (int)$speed - $limit;
	if ($overSpeed < 0) {
		$result = false;
	} elseif ($overSpeed <= 20) {
		$result = 'speeding';
	} elseif ($overSpeed <= 40) {
		$result = 'excessive speeding';
	} else {
		$result = 'reckless driving';
	}
	return $result;
}

// $speed = "40";
// $zone = "city";
// $speed = "20";
// $zone = "residential";
// $speed = "120";
// $zone = "interstate";
// $speed = "200";
// $zone = "motorway";

$speed = trim(fgets(STDIN));
$zone = trim(fgets(STDIN));

$limit = getLimit($zone);
$infraction = getInfraction($speed, $limit);
$overSpeed = $speed - $limit;

// echo "<pre>";
// print_r($limit);
// echo "</pre>";
// echo "<pre>";
// print_r($infraction);
// echo "</pre>";
// echo "<pre>";
// print_r($overSpeed);
// echo "</pre>";

if ($infraction) {
	echo $infraction;
}


<?xml version="1.0" encoding="UTF-8"?>
<quiz>
  <question>
    Who was the forty-second president of the U.S.A.?
  </question>
  <answer>
    William Jefferson Clinton
  </answer>
</quiz>