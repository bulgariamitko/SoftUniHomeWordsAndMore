<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Dump Varialbes</title>
</head>
<body>
<?php 
	$val1 = 'hello';
	$val2 = 15;
	$val3 = 1.234;
	$val4 = array(1,2,3);
 	$val5 = (object)[2,34];

 	$array = [$val1, $val2, $val3, $val4, $val5];

 	foreach ($array as $v) {
 		echo gettype($v) . "(";
 		print_r($v);
 		echo ")<br>";
 	}
 ?>
</body>
</html>