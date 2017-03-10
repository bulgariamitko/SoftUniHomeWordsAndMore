<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Sum Two Numbers</title>
</head>
<body>
<?php 
	$firstNumber = $_POST['first'] ?? 0;
	$secondNumber = $_POST['second'] ?? 0;
	$result = round($firstNumber + $secondNumber, 2);

	if (!empty($_POST['submit'])) {
		echo "<h1>Result:</h1>";
		echo "\$firstNumber + \$secondNumber = {$firstNumber} + {$secondNumber} = {$result}";
	}
 ?>

<h1>Fill form first:</h1>
 <form method="post">
 	<input type="num" name="first" step="any" placeholder="First number" required> <br>
 	<input type="num" name="second" step="any" placeholder="Second number" required> <br>
 	<input type="submit" name="submit">
 </form>
</body>
</html>