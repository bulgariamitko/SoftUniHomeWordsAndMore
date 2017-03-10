<?php
function toNumber($letter) {
    if ($letter) {
    	return ord(strtolower($letter)) - 97;
    } else {
    	return 0;
    }
}

// $word = 'Abcz';
// $word = 'softuni';

$word = trim(fgets(STDIN));

$word = str_split(strtolower($word));

$output = [];

for ($i=0; $i < count($word); $i++) { 
	echo $word[$i] . ' -> ' . toNumber($word[$i]) . "\n";
}