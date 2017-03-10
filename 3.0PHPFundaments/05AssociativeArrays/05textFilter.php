<?php 

// $text = 'It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux! Sincerely, a Windows client';
// $banlist = 'Linux, Windows';

$text = trim(fgets(STDIN));
$banlist = trim(fgets(STDIN));
$banlist = explode(', ', $banlist);

foreach ($banlist as $word) {
	$text = str_replace($word, str_repeat("*", strlen($word)), $text);
}

echo $text;