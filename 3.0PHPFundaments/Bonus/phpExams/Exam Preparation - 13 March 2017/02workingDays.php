<?php
function isWeekend($date) {
    $weekDay = date('w', strtotime($date));
    return ($weekDay == 0 || $weekDay == 6);
}

// $_GET['dateOne'] = "17-12-2014";
// $_GET['dateTwo'] = "31-12-2014";
// $_GET['holidays'] = "31-12-2014%0D%0A24-12-2014%0D%0A08-12-2014";

// $_GET['dateOne'] = "16-08-2014";
// $_GET['dateTwo'] = "17-08-2014";
// $_GET['holidays'] = "32-12-2014%0D%0A14-09-2014%0D%0A10-10-2014";

// $_GET['dateOne'] = "13-03-2017";
// $_GET['dateTwo'] = "18-03-2017";
// $_GET['holidays'] = "16-03-2017%0D%0A17-03-2017%0D%0A18-03-2017";

$begin = new DateTime($_GET['dateOne']);
$end = new DateTime($_GET['dateTwo']);
$holidays = explode(PHP_EOL, urldecode(trim($_GET['holidays'])));

$interval = DateInterval::createFromDateString('1 day');
$period = new DatePeriod($begin, $interval, $end);

$output = "<ol>";
$countDays = 0;
foreach ($period as $dt) {
	foreach ($holidays as $holiday) {
		if (trim($holiday) == trim($dt->format('d-m-Y'))) {
			continue 2;
		}
	}
	if (isWeekend($dt->format("d-m-Y"))) {
		continue;
	}
	$countDays++; 
  	$output .= "<li>" . $dt->format("d-m-Y") . "</li>";
}
$output .= "</ol>";

if (empty($countDays)) {
	echo "<h2>No workdays</h2>";
} else {
	echo $output;
}