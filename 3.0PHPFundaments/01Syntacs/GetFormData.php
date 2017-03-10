<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Get Form Data</title>
</head>
<body>

<h1>Fill form first:</h1>
 <form method="post">
 	<input type="text" name="name" placeholder="Name" required><br>
 	<input type="num" name="age" min="0" placeholder="Age" required><br>
 	<input type="radio" name="gender" value="male" id="male">
 	<label for="male">Male</label><br>
 	<input type="radio" name="gender" value="female" id="female">
 	<label for="female">Female</label><br>
 	<input type="submit" name="submit">
 </form>
<?php 

	if (!empty($_POST['submit'])) {
		$name = $_POST['name'];
		$age = $_POST['age'];
		$gender = $_POST['gender'];

		echo "<h1>Output:</h1>";
		echo "My name is {$name}. I am {$age} years old. I am {$gender}.";
	}
 ?>
</body>
</html>