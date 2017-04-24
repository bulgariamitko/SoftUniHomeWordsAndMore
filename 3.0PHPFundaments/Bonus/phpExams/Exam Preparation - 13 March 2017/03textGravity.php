<?php

$_GET['text'] = 'The Milky Way is the galaxy that contains our star system';
$_GET['lineLength'] = '10';

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
		$matrix[$i][$y] = $text[$num] ?? ' ';
		$num++;
	}
}

// drop empty spots
for ($i=0; $i < $cols; $i++) {
	$spaces = 0;
	for ($y=$rows; $y >= 0; $y--) { 
		if ($matrix[$y][$i] == " ") {
            $spaces++;
        } else {
            $char = $matrix[$y][$i];
            $matrix[$y][$i] = " ";
            $matrix[$y+$spaces][$i] = $char;
        }
	}
}

echo "<table>";
for ($row=0; $row < count($matrix) - 1; $row++) { 
	echo "<tr>";
	for ($col=0; $col < count($matrix[$row]); $col++) { 
		echo "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
	}
	echo "</tr>";
}
echo "<table>";