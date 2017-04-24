<?php

// $_GET['rocks'] = 'zhcdde,hzccd,eezhg';

// $_GET['rocks'] = 'zcgdef,hzgfcd,eedfhg';

$data = explode(',', trim($_GET['rocks']));

$diamonds = [];

foreach ($data as $smallData) {
	$name_array = str_split($smallData);
	$diamonds[] = array_unique($name_array);
}

// echo "<pre>";
// print_r($diamonds);
// echo "</pre>";

$letters =[];

foreach ($diamonds as $word) {
	$word = array_values($word);
	// echo "<pre>";
	// print_r($word);
	// echo "</pre>";
	for ($i=0; $i < count($word); $i++) {
		if (empty($letters[$word[$i]])) {
			$letters[$word[$i]] = 0;
		}
		$letters[$word[$i]]++;
	}
}

$final = 0;

foreach ($letters as $letter => $num) {
	if ($num / count($data) == 1) {
		$final++;
	}
}

// echo "<pre>";
// print_r($letters);
// echo "</pre>";

echo $final;