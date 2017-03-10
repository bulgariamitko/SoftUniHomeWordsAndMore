<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Sum of Digits</title>
</head>
<style type="text/css">
	table, th, td {
	    border: 1px solid black;
	}
</style>
<body>
	<h1>Sum of Digits</h1>
	<form method="post">
		<label for="nums">Input string:</label>
		<input type="text" name="nums" id="nums" required>
		<input type="submit" name="enter" value="Submit">
	</form>
	<?php if (!empty($_POST['enter'])): ?>
		<?php
			$nums = explode(', ', $_POST['nums']);
		?>
		<table width="400">
			<tr>
				<th>Number</th>
				<th>Sum</th>
			</tr>
			<?php foreach ($nums as $num): ?>
				<?php 
					if (is_int((int)$num)) {
						$total = 0;
						for ($i=0; $i < $num; $i++) { 
							$total += $num[$i];
						}
					}
					if ($total == 0) {
						$total = "I cannot sum that";
					}
				 ?>
				<tr>
					<td><?= $num; ?></td>
					<td><?= $total; ?></td>
				</tr>
			<?php endforeach ?>
		</table>
	<?php endif ?>
</body>
</html>