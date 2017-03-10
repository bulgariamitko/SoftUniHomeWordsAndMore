<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Square Root Sum</title>
</head>
<style type="text/css">
	table, th, td {
	    border: 1px solid black;
	}
</style>
<body>
	<h1>Refresh for a random number from 0 to 100</h1>
	<?php
		$num = range(0, 100, 2);
		$random = array_rand($num);
		$num = $num[$random];
	?>
	<table width="400">
		<tr>
			<th>Number</th>
			<th>Square</th>
			<th>Sum</th>
		</tr>
		<tr>
			<td><?= $num; ?></td>
			<td><?= round(sqrt($num), 2);  ?></td>
			<td><?= array_sum(str_split(round(sqrt($num), 2))); ?></td>
		</tr>
	</table>
</body>
</html>