<?php

// $_GET['string'] = 'zibxle-SutFA';
// $_GET['key'] = '3';

// $_GET['string'] = 'HNbltpuk';
// $_GET['key'] = '4';

// $_GET['string'] = 'TilxlM-pFt';
// $_GET['key'] = '6';

// $_GET['string'] = 'mi-Ozv';
// $_GET['key'] = 5;

$string = trim($_GET['string']);
$key = (int)trim($_GET['key']);

$lastLetterz = ord('z');
$lastLetterZ = ord('Z');

$firstlettera = ord('a');
$firstletterA = ord('A');

for ($i=0; $i < strlen($string); $i++) { 
	// small letters
	if (preg_match('/[a-z]/', $string[$i])) {
		if (ord($string[$i]) + $key > $lastLetterz) {
			$value = (ord($string[$i]) + $key) - $lastLetterz;
			$letterord = $firstlettera + $value - 1;
			echo chr($letterord);
		} else {
			echo chr(ord($string[$i]) + $key);
		}
	} elseif (preg_match('/[A-Z]/', $string[$i])) {
		if (ord($string[$i]) + $key > $lastLetterZ) {
			$value = (ord($string[$i]) + $key) - $lastLetterZ;
			$letterord = $firstletterA + $value - 1;
			echo chr($letterord);
		} else {
			echo chr(ord($string[$i]) + $key);
		}
	} else {
		echo $string[$i];
	}
}

