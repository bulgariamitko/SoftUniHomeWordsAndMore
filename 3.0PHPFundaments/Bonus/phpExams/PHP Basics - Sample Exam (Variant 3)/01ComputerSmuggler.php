<?php 

$_GET['list'] = 'CPU, CPU, CPU, CPU';

$list = explode(",", $_GET['list']);

$cpu = 0;
$ram = 0;
$via = 0;
$rom = 0;

foreach ($list as $v) {
	switch (trim($v)) {
		case 'CPU':
			$cpu++;
			break;
		case 'RAM':
			$ram++;
			break;
		case 'VIA':
			$via++;
			break;
		case 'ROM':
			$rom++;
			break;
		default:
			break;
	}
}


$comAssambled = min($cpu, $ram, $via, $rom);

$remainsCpu += $cpu - $comAssambled;
$remainsRam += $ram - $comAssambled;
$remainsVia += $via - $comAssambled;
$remainsRom += $rom - $comAssambled;

// parts price
$cpuPrice = 85;
$ramPrice = 35;
$viaPrice = 45;
$romPrice = 45;

//dicount if more then 5 parts
if ($cpu >= 5) {
	$cpuPricePaid = $cpuPrice / 2;
}
if ($ram >= 5) {
	$ramPricePaid = $ramPrice / 2;
}
if ($via >= 5) {
	$viaPricePaid = $viaPrice / 2;
}
if ($rom >= 5) {
	$romPricePaid = $romPrice / 2;
}

// total paid for parts
$totalcpuPrice = $cpu * ($cpuPricePaid ?? $cpuPrice);
$totalramPrice = $ram * ($ramPricePaid ?? $ramPrice);
$totalviaPrice = $via * ($viaPricePaid ?? $viaPrice);
$totalromPrice = $rom * ($romPricePaid ?? $romPrice);

// total selled price
$totalremainsCpu = $remainsCpu * ($cpuPrice / 2);
$totalremainsRam = $remainsRam * ($ramPrice / 2);
$totalremainsVia = $remainsVia * ($viaPrice / 2);
$totalremainsRom = $remainsRom * ($romPrice / 2);

$parts = $remainsCpu + $remainsRam + $remainsVia + $remainsRom;

$computerCost = 420;

$profit = $comAssambled * $computerCost;
$profit += $totalremainsCpu + $totalremainsRam + $totalremainsVia + $totalremainsRom;

$paid = $totalcpuPrice + $totalramPrice + $totalviaPrice + $totalromPrice;

// echo "<pre>";
// print_r($profit);
// echo "</pre>";
// echo "<pre>";
// print_r($paid);
// echo "</pre>";

$balance = $profit - $paid;
echo "<ul><li>" . $comAssambled . " computers assembled</li><li>" . $parts . " parts left</li></ul>";
if ($balance > 0) {
    echo "<p>Nakov gained " . $balance . " leva</p>";
} else {
    echo "<p>Nakov lost " . $balance . " leva</p>";
}