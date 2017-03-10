<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Modify String</title>
</head>
<style type="text/css">
	table, th, td {
	    border: 1px solid black;
	}
</style>
<body>
	<h1>Modify String</h1>
	<form method="post">
		<label for="string">Input string:</label>
		<input type="text" name="string" id="string" placeholder="Enter text here..." required>
		<label for="pali">Check Palindrome</label>
		<input type="radio" name="type" id="pali" value="pali">
		<label for="reverse">Reverse String</label>
		<input type="radio" name="type" id="reverse" value="reverse">
		<label for="split">Split</label>
		<input type="radio" name="type" id="split" value="split">
		<label for="hash">Hash String</label>
		<input type="radio" name="type" id="hash" value="hash">
		<label for="shuffle">Shuffle String</label>
		<input type="radio" name="type" id="shuffle" value="shuffle">
		<input type="submit" name="enter" value="Submit">
	</form>
	<br><br><br>
	<?php 
		if (!empty($_POST['enter'])) {
			$word = $_POST['string'];
			switch ($_POST['type']) {
				case 'pali':
					$reverse = strrev($word);
					if ($word == $reverse) {
						echo $word . ' This string is a palindrome';
					} else {
						echo $word . ' This is not a palindrome';
					}
					break;
				case 'reverse':
					$reverse = strrev($word);
					echo $reverse;
					break;
				case 'split':
					echo chunk_split($word, 1, ' ');
					break;
				case 'hash':
					echo hash('ripemd160', $word);
					break;
				case 'shuffle':
					echo str_shuffle($word);
					break;
				default:
					throw new Exception("Error Processing Request", 1);
					break;
			}
		}
	 ?>
</body>
</html>