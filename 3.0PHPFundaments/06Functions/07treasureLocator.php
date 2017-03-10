<?php

function treasure(float $x, float $y) {
	if ($x >= 1 && $x <= 3 && $y >= 1 && $y <= 3) {
		echo "Tuvalu\n";
	} elseif ($x >= 0 && $x <= 1 && $y >= 8 && $y <= 9) {
		echo "Tokelau\n";
	} elseif ($x >= 3 && $x <= 6 && $y >= 5 && $y <= 7) {
		echo "Samoa\n";
	} elseif ($x >= 6 && $x <= 8 && $y >= 0 && $y <= 2) {
		echo "Tonga\n";
	} elseif ($x >= 7 && $x <= 8 && $y >= 4 && $y <= 9) {
		echo "Cook\n";
	} else {
		echo "On the bottom of the ocean\n";
	}
}

// $nums = array_map("floatval", explode(", ", "4, 2, 1.5, 6.5, 1, 3"));
// $nums = array_map("floatval", explode(", ", "6, 4"));

$nums = explode(", ", trim(fgets(STDIN)));

for ($i=0; $i < count($nums); $i += 2) {
	treasure((float)$nums[$i+1], (float)$nums[$i]);
}