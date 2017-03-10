<?php

// $_GET['input'] = 'What+a+wonderful+wordl%21';

$input = urldecode($_GET['input']);

$stringToArr = str_split($input);

for ($i=0; $i < count($stringToArr); $i++) {
	if ($input[$i] != ' ') {
		if (ord($input[$i]) % 2 == 0) {
			echo "<font color='red'>" . $input[$i] . " </font>";
		} else {
			echo "<font color='blue'>" . $input[$i] . " </font>";
		}
	}
}

