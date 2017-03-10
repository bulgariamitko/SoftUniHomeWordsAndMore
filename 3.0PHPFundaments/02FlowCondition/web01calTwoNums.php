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
			if (isset($_GET['calculate'])) {
				$operation = $_GET['operation'];
				$numberOne = $_GET['number_one'];
				$numberTwo = $_GET['number_two'];
				echo "<div>";
				echo "Result: ";
					if ($operation == "sum") {
						echo " <input type='text' value='" . ($numberOne + $numberTwo) . "' disabled>";
					} elseif ($operation == "subtract") {
						echo " <input type='text' value='" . ($numberOne - $numberTwo) . "' disabled>";
					} else {
						echo " <input type='text' value='Invalid operation supplied' disabled>";
					}
				echo "</div>";
			}
		?>
		<div>
			<input type="submit" name="calculate" value="Calculate!">
		</div>
	</form>
</body>
</html>