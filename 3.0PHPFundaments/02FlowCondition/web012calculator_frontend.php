<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Calculate Two Numbers</title>
</head>
<body>
	<form method="get">
		<div>
		Operation:
			<select name="operation">
				<option value="sum">Sum</option>
				<option value="subtract">Subtract</option>
			</select>
		</div>
		<div>
			Number 1:
			<input type="text" name="number_one">
		</div>
		<div>
			Number 2:
			<input type="text" name="number_two">
		</div>
		<?php
			if (isset($output)): ?>
				<div>
					Result
					<input type="text" value="<?= $output ?>" disabled readonly>
				</div>
			<?php endif; ?>
		<div>
			<input type="submit" name="calculate" value="Calculate!">
		</div>
	</form>
</body>
</html>