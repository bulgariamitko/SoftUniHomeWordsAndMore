<?php 

$word = trim(fgets(STDIN));
$letters = str_split($word);

$count = [];

foreach ($letters as $letter) {
	if (!array_key_exists($letter, $count)) {
		$count[$letter] = 0;
	}
	$count[$letter]++;
}

arsort($count);

echo "<pre>";
print_r($count);
echo "</pre>";