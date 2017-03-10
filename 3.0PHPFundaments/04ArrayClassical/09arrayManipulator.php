<?php

$line = trim(fgets(STDIN));
$nums = explode(' ', $line);

while ($line != 'print') {
	$command = explode(' ', $line);
	switch ($command[0]) {
		case 'add':
			$index = $command[1];
			$element = $command[2];
			array_splice($nums, $index, 0, $element);
			break;
		case 'addMany':
			$index = $command[1];
			$tempArray = [];
			for ($i=2; $i < count($command); $i++) {
				$tempArray[] = $command[$i];
			}
			array_reverse($tempArray);
			array_splice($nums, $index, 0, $tempArray);
			break;
		case 'contains':
			$element = $command[1];
			$key = array_search($element, $nums);
			if ($key === false) {
				echo -1 . "\n";
			} else {
				echo $key . "\n";
			}
			$key = null;
			break;
		case 'remove':
			$index = $command[1];
			unset($nums[$index]);
			$nums = array_values($nums);
			break;
		case 'shift':
			$positions = $command[1];
			$tempArray = [];
			$copyArray = $nums;
			for ($i=$positions; $i < count($nums); $i++) {
				$tempArray[] = $nums[$i];
				unset($copyArray[$i]);
			}
			$copyArray = array_values($copyArray);
			for ($i=count($tempArray) - 1; $i >= 0; $i--) { 
				array_unshift($copyArray, $tempArray[$i]);
			}
			$nums = $copyArray;
			break;
		case 'sumPairs':
			$tempArray = [];
			for ($i=0; $i < count($nums); $i += 2) {
				$tempArray[] = $nums[$i] + $nums[$i+1];
			}
			$nums = $tempArray;
			break;
		default:
			// echo "No such command";
			break;
	}

	// echo implode(', ', $nums) . "\n";

	$line = trim(fgets(STDIN));
}

echo "[" . implode(', ', $nums) . "]";