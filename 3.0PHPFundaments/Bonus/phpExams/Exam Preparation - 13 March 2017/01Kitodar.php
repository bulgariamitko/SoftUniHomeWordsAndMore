<?php

// $_GET['data'] = "mine bobovdol gold 10, mine tomn diamonds 5, mine colas Gold 10, mine myMine silver 14, mine silver14 siLver 14";

$totalGold = 0;
$totalSilver = 0;
$totalDiamons = 0;

$data = explode(",", trim($_GET['data']));

foreach ($data as $dataOne) {
	$allData = explode(" ", trim($dataOne));
	$mine = strtolower($allData[0]);
	$typeOfOre = strtolower($allData[2]);
	$value = (int)$allData[3];
	if ($mine == 'mine') {
		if ($typeOfOre == 'gold') {
			$totalGold += $value;
		} elseif ($typeOfOre == 'silver') {
			$totalSilver += $value;
		} elseif ($typeOfOre == 'diamonds') {
			$totalDiamons += $value;
		}
	}
}

echo "<p>*Gold: " . $totalGold . "</p>";
echo "<p>*Silver: " . $totalSilver . "</p>";
echo "<p>*Diamonds: " . $totalDiamons . "</p>";