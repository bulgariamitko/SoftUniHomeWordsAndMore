<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Time Until New Year</title>
</head>
<body>
<?php 

	$date = new DateTime();
	$endOfYear = new DateTime('2017-12-31 23:59:59');

	$interval = $endOfYear->diff($date);
?>
<h1>Days, hours, minutes, seconds until 01-01-2018</h1>
<?php echo $date->format('d-m-Y H:i:s') ?><br>
Hours until new year : <?php echo $interval->format("%h hours"); ?><br>
Minutes until new year : <?php echo $interval->format("%i minutes"); ?><br>
Seconds until new year : <?php echo $interval->format("%s seconds"); ?><br>
Days:Hours:Minutes:Seconds <?php echo $interval->format("%a:%h:%i:%s"); ?>
</body>
</html>