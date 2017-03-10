<?php

// $text = '<p>Come and visit <a href="http://softuni.bg">the Software University</a> to master the art of programming. You can always check our <a href="www.softuni.bg/forum">forum</a> if you have any questions.</p>';

$text = trim(fgets(STDIN));

$re = [];
$re[] = '/<a href="/';
$re[] = '/">/';
$re[] = '/<\/a>/';
// $re = '/(<a href=")[\w:\/\.]+(">)[\w\s]+(<\/a>)/';
$replacements = [];
$replacements[] = '[URL=';
$replacements[] = ']';
$replacements[] = '[/URL]';

$text = preg_replace($re, $replacements, $text);

echo $text;
