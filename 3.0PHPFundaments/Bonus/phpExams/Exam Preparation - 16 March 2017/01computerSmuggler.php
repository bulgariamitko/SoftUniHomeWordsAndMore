<?php

$_GET['list'] = 'CPU, RAM, VIA, ROM, RAM, RAM, CPU, CPU, CPU, VIA, ROM, ROM, CPU';

$data = explode(", ", $_GET['list']);

$cpus = 0;
$rams = 0;
$vias = 0;
$roms = 0;

$cpuPrice = 85;
$ramPrice = 35;
$viaPrice = 45;
$romPrice = 45;

$computerPrice = 420;

$totalParts = 0;
$totalPaid = 0;
$totalSold = 0;

foreach ($data as $part) {
	switch ($part) {
		case 'CPU':
			$cpus++;
			$totalParts++;
			break;
		case 'RAM':
			$rams++;
			$totalParts++;
			break;
		case 'VIA':
			$vias++;
			$totalParts++;
			break;
		case 'ROM':
			$roms++;
			$totalParts++;
			break;
	}
}

// discount
if ($cpus >= 5) {
	$cpuPrice = $cpuPrice / 2;
}
if ($rams >= 5) {
	 $ramPrice = $ramPrice / 2;
}
if ($vias >= 5) {
	 $viaPrice = $viaPrice / 2;
}
if ($roms >= 5) {
	 $romPrice = $romPrice / 2;
}

$totalPaid += ($cpus * $cpuPrice) + ($rams * $ramPrice) + ($vias * $viaPrice) + ($roms * $romPrice);

$cpuPrice = 85;
$ramPrice = 35;
$viaPrice = 45;
$romPrice = 45;

// echo $cpus . " " . $rams . " " .  $vias . " " . $roms;

$comSold = min($cpus, $rams, $vias, $roms);

$totalSold += $comSold * $computerPrice;

$cpusLeft = $cpus - $comSold;
$ramsLeft = $rams - $comSold;
$viasLeft = $vias - $comSold;
$romsLeft = $roms - $comSold;

$totalSold += ($cpusLeft * ($cpuPrice / 2)) + ($ramsLeft * ($ramPrice / 2)) + ($viasLeft * ($viaPrice / 2)) + ($romsLeft * ($romPrice / 2));

$total = $totalSold - $totalPaid;

$totalPartsLeft = $cpusLeft + $ramsLeft + $viasLeft + $romsLeft;

// echo "<pre>";
// print_r($total);
// echo "</pre>";
// echo "<pre>";
// print_r($totalPartsLeft);
// echo "</pre>";


echo "<ul><li>" . $comSold .  " computers assembled</li><li>" . $totalPartsLeft . " parts left</li></ul><p>Nakov " . ($total <= 0 ? "lost {$total} leva" : "gained {$total} leva") . "</p>";
