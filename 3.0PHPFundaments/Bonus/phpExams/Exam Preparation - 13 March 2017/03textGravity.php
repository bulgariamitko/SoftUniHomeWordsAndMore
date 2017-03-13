<?php

// $_GET['text'] = 'The Milky Way is the galaxy that contains our star system';
// $_GET['lineLength'] = '10';

$text = $_GET['text'];
$cols = (int)$_GET['lineLength'];
$rows = ceil(strlen($_GET['text']) / $cols);

$matrix = [];
$num = 0;
$line = [];

for ($i=0; $i < $rows; $i++) { 
	if (empty($matrix[$i])) {
		$matrix[$i] = [];
	}
	for ($y=0; $y < $cols; $y++) {
		$matrix[$i][$y] = $text[$num] ?? '';
		$num++;
	}
}

$newMatrix = $matrix;
$demoNum = 0;
	
for ($i=$rows-1; $i > 0; $i--) { 
	for ($y=0; $y < $cols; $y++) {
		if ((empty($newMatrix[$i][$y]) || $newMatrix[$i][$y] == ' ') && $rows - 1) {
				$newMatrix[$i][$y] = $newMatrix[$i-1][$y];
				$newMatrix[$i-1][$y] = ' ';
		}
	}
}

echo "<table>";
for ($i=0; $i < $rows; $i++) { 
	echo "<tr>";
	for ($y=0; $y < $cols; $y++) {
		echo "<td>" . $newMatrix[$i][$y] . "</td>";
	}
	echo "</tr>";
}
echo "<table>";