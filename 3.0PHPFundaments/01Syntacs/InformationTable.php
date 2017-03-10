<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Information Table</title>
</head>
<style type="text/css">
	table, th, td {
	    border: 1px solid black;
	}
	th {
		background-color: orange;
		text-align: left;
	}
	td {
		text-align: right;
	}
</style>
<body>
<?php 
	$name = $_POST['name'] ?? 0;
	$tel = $_POST['phone'] ?? 0;
	$num = $_POST['age'] ?? 0;
	$text = $_POST['address'] ?? 0;

	if (!empty($_POST['submit'])) {
		echo "<h1>Output:</h1>";
		?>
		<table>
			<tr>
				<th>Name</th>
				<td><?= $name; ?></td>
			</tr>
			<tr>
				<th>Phone number</th>
				<td><?= $tel; ?></td>
			</tr>
			<tr>
				<th>Age</th>
				<td><?= $num; ?></td>
			</tr>
			<tr>
				<th>Address</th>
				<td><?= $text; ?></td>
			</tr>
		</table>
		<?php
	}
 ?>


<h1>Fill form first:</h1>
 <form method="post">
 	<input type="text" name="name" placeholder="Name" required> <br>
 	<input type="tel" name="phone" placeholder="Phone number" required> <br>
 	<input type="num" name="age" min="0" placeholder="Age" required> <br>
 	<input type="text" name="address" placeholder="Address" required> <br>
 	<input type="submit" name="submit">
 </form>
</body>
</html>