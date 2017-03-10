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
	<h1>Annual Expenses</h1>
	<form method="post">
		<label for="years">Enter number of years</label>
		<input type="text" name="years" id="years">
		<input type="submit" name="enter" value="Show costs">
	</form>
	<?php if (!empty($_POST['enter'])): ?>
		<?php
			$year = date('Y');
			$yearsUntill = $year - $_POST['years'];
		?>
		<table width="400">
			<tr>
				<th>Year</th>
				<th>January</th>
				<th>February</th>
				<th>March</th>
				<th>April</th>
				<th>May</th>
				<th>June</th>
				<th>July</th>
				<th>August</th>
				<th>September</th>
				<th>Octomber</th>
				<th>November</th>
				<th>December</th>
				<th>Total</th>
			</tr>
			<?php for ($i=$year; $i > $yearsUntill; $i--): ?>
				<?php
					$total = 0;
					$month1 = rand(0, 999);
					$month2 = rand(0, 999);
					$month3 = rand(0, 999);
					$month4 = rand(0, 999);
					$month5 = rand(0, 999);
					$month6 = rand(0, 999);
					$month7 = rand(0, 999);
					$month8 = rand(0, 999);
					$month9 = rand(0, 999);
					$month10 = rand(0, 999);
					$month11 = rand(0, 999);
					$month12 = rand(0, 999);
					$total = $month1 + $month2 + $month3 + $month4 + $month5 + $month6 + $month7 + $month8 + $month9 + $month10 + $month11 + $month12; 
				?>
				<tr>
					<td><?= $i; ?></td>
					<td><?= $month1 ?></td>
					<td><?= $month2 ?></td>
					<td><?= $month3 ?></td>
					<td><?= $month4 ?></td>
					<td><?= $month5 ?></td>
					<td><?= $month6 ?></td>
					<td><?= $month7 ?></td>
					<td><?= $month8 ?></td>
					<td><?= $month9 ?></td>
					<td><?= $month10 ?></td>
					<td><?= $month11 ?></td>
					<td><?= $month12 ?></td>
					<td><?= $total ?></td>
				</tr>
			<?php endfor ?>
		</table>
	<?php endif ?>
</body>
</html>