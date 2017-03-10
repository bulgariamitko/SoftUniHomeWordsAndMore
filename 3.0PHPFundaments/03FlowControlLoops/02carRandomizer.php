<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Car Randomizer</title>
</head>
<style type="text/css">
	table, th, td {
	    border: 1px solid black;
	}
</style>
<body>
	<h1>Car Randomizer</h1>
	<?php if (!empty($_POST['enter'])): ?>
		<?php
			$cars = explode(', ', $_POST['cars']);
			$colors = ['red', 'green', 'blue', 'white', 'black', 'purple'];
			$counts = [4, 5, 3, 2, 1, 6, 7];
		?>
		<table width="400">
			<tr>
				<th>Cars</th>
				<th>Colors</th>
				<th>Counters</th>
			</tr>
			<?php foreach ($cars as $car): ?>
				<?php
					$color = array_rand($colors);
					$count =  array_rand($counts);
				?>
				<tr>
					<td><?= $car; ?></td>
					<td><?= $colors[$color]; ?></td>
					<td><?= $counts[$count]; ?></td>
				</tr>
			<?php endforeach ?>
		</table>
	<?php endif ?>
	<form method="post">
		<label for="cars">Enter cars</label>
		<input type="text" name="cars" id="cars">
		<input type="submit" name="enter" value="Show result">
	</form>
</body>
</html>