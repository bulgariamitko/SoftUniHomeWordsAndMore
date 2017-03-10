<?php 

// $input1 = 'hi php java csharp sql html css js';
// $input2 = 'hi php java js softuni nakov java learn';

// $input1 = 'hi php java xml csharp sql html css js';
// $input2 = 'nakov java sql html css js';

// $input1 = 'I love programming';
// $input2 = 'Learn Java or C#';

$input1 = fgets(STDIN);
$input2 = fgets(STDIN);


$words1 = explode(' ', trim($input1));
$words2 = explode(' ', trim($input2));

$loopUntil = min(count($words1), count($words2));

$leftLargest = [];
$rightLArgest = [];

for ($i=0; $i < $loopUntil; $i++) { 
	if ($words1[$i] == $words2[$i]) {
		$leftLargest[] = $words1[$i];
	} else break;
}

// reverse array to check for right to left
$words1Reverse = array_reverse($words1);
$words2Reverse = array_reverse($words2);
for ($i=0; $i < $loopUntil; $i++) { 
	if ($words1Reverse[$i] == $words2Reverse[$i]) {
		$rightLArgest[] = $words1Reverse[$i];
	} else break;
}

$rightLArgest = array_reverse($rightLArgest);

// echo "<pre>";
// print_r($leftLargest);
// echo "</pre>";

// echo "<pre>";
// print_r($rightLArgest);
// echo "</pre>";

if (!empty($leftLargest)) {
	// echo "The largest common end is at the left: " . implode(' ', $leftLargest);
} elseif (!empty($rightLArgest)) {
	// echo "The largest common end is at the right: " . implode(' ', $rightLArgest);
} else {
	// echo "No common words at the left and right";
}

echo max(count($leftLargest), count($rightLArgest));