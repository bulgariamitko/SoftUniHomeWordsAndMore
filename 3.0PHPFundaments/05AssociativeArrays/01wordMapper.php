<?php

// $_GET['input'] = 'The+quick+brows+fox.%21%21%21+jumped+over..%2F%2F+the+lazy+dog.%21';

$input = urldecode($_GET['input']);

$re = '/[a-zA-Z]+/';
$str = $input;

preg_match_all($re, $str, $matches);

$words = [];
foreach ($matches[0] as $word) {
	if (empty($words[strtolower($word)])) {
		$words[strtolower($word)] = 0;
	}
	$words[strtolower($word)]++;
}

echo "<table border='2'>";
foreach ($words as $word => $counter) {
	echo "<tr>";
		echo "<td>" . $word . "</td>";
		echo "<td>" . $counter . "</td>";
	echo "</tr>";
}
echo "</table>";