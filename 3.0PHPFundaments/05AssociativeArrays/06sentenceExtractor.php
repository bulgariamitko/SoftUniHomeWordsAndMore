<?php

// $text = 'This is my cat! And this is my dog. We happily live in Paris – the most beautiful city in the world! Isn’t it great? Well it is :)';
// $word = 'is';

$text = trim(fgets(STDIN));
$word = trim(fgets(STDIN));

// $re = '/[\w\s]+' . $word . '[\w\s]+(!|\?|\.)/';
$re = "/([^.?!]*\\b" . $word . "\\b[^.?!]*[.?!])/";

preg_match_all($re, $text, $matches);

foreach ($matches[0] as $sentence) {
	echo trim($sentence) . "\n";
}