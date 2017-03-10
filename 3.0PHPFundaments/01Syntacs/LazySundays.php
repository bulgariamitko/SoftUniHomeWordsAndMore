<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Lazy Sundays</title>
</head>
<body>
<?php 
	function getSundays($y, $m) {
	    return new DatePeriod(
	        new DateTime("first sunday of $y-$m"),
	        DateInterval::createFromDateString('next sunday'),
	        new DateTime("last day of $y-$m")
	    );
	}

	$year = date('Y');
	$month = date('n');
?>
<h1>All Sundays for <?= $month; ?>-<?= $year; ?></h1>
<?php
	foreach (getSundays($year, $month) as $sunday) {
	    echo $sunday->format("l, d-F-Y") . "<br>";
	}
 ?>
</body>
</html>