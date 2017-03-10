<?php 

// $line = '1 2 3 3';
// $line = '1 2';
// $line = '1';
// $line = '1 2 3';
// $line = '10 5 5 99 3 4 2 5 1 1 4';

$line = trim(fgets(STDIN));
$nums = explode(' ', $line);

$noResult = true;
for ($i=0; $i < count($nums); $i++) {
	if (count($nums) == 1) {
		$noResult = false;
		echo 0;
		break;
	}
	$tempArray = $nums;
	$array = array_splice($tempArray, 0, count($nums) - $i);
	$popOut = $tempArray[0] ?? 0;
	array_shift($tempArray);

	// echo "<pre>";
	// print_r($array);
	// echo "</pre>";
	// echo "<pre>";
	// print_r($tempArray);
	// echo "</pre>";

	if (array_sum($array) == array_sum($tempArray)) {
		$noResult = false;
		echo array_search($popOut, $nums);
		break;
	}
}

if ($noResult) {
	echo "no";
}