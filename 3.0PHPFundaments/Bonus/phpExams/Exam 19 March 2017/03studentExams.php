<?php

$_GET['string'] = 'Georgi Petrov - Java : 360, Marina - JavaScript : 200, Marina     -    JavaScript :     300, Vasil Dimitrov - PHP : 120, Vasil Dimitrov-PHP: 550, Vasil Dimitrov - PHP : 250';

// $_GET['string'] = 'Johnny Bravo - PHP : 300, Johnny Bravo-PHP: 600, Nikola Ivanov - PHP: 350, Johnny Bravo - PHP : 400';

$string = $_GET['string'];

$exams = [];
$data = preg_split( "/(,|-|:)/", $string );
// $data = explode(', ', trim($_GET['string']));

for ($i=0; $i < count($data); $i += 3) { 
	$person = trim($data[$i]);
	$examName = trim($data[$i+1]);
	$examScore = (int)trim($data[$i+2]);

	if (empty($exams[$person])) {
		// person
		$exams[$person] = [];
	}
	if (empty($exams[$person][$examName])) {
		// exam name
		$exams[$person][$examName] = [];
	}
	
	if (empty($exams[$person][$examName])) {
		// exam name
		$exams[$person][$examName] = [];
	}
	$exams[$person][$examName] = $examScore;
	
	// if ($exams[$person][$examName] == $examName
	// 	&& $examScore > $exams[$person][$examName]) {
	// 	$exams[$person][$examName][$examScore] = $examScore;
	// }
}

echo "<pre>";
print_r($exams);
echo "</pre>";


// A valid result value is between 0 and 400 points.
// makeup = count and take only the hiest result
// [1]Students score in descending order.
// [2]how many makeup exams did they take in ascending order.
// [3]students by name alphabetically.