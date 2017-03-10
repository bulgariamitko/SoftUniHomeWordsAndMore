<?php
	session_start();
	if (!empty($_POST['clear'])) {
		session_unset();
		$_GET = NULL;
		$_POST = NULL;
	}

	if (empty($_SESSION['names']) && empty($_SESSION['ages'])) {
		$_SESSION['names'] = explode($_GET['delimiter'], $_GET['names']);
		$_SESSION['ages'] = explode($_GET['delimiter'], $_GET['ages']);
		$_SESSION['i'] = 0;
	}
	if (!empty($_SESSION['names'])) {
		$pages = ceil(count($_SESSION['names']) / 5);
	}
	if (!empty($_POST['next'])) {
		$_SESSION['i'] += 5;
	}
	if (!empty($_POST['pre'])) {
		$_SESSION['i'] -= 5;
		if ($_SESSION['i'] < 0) {
			$_SESSION['i'] = 0;
		}
	}
	if (!empty($_SESSION['i'])) {
		$y = ($_SESSION['i'] / 5) + 1;
	}
	if (!empty($_POST['page'])) {
		$y = $_POST['page'];
		$_SESSION['i'] = ($y - 1) * 5;
	}
	// echo "<pre>";
	// print_r($_SESSION['i']);
	// echo "</pre>";
?>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Render Students Info</title>
</head>
<style type="text/css">
	pre {
		background-color: black;
		color: white;
	}
	input[type='submit'] {
		cursor: pointer;
	}
</style>
<body>
	<form method="get">
		<div>
			Delimiter:
			<select name="delimiter">
				<option value=",">,</option>
				<option value="|">|</option>
				<option value="&">&</option>
			</select>
		</div>
		<div>
			Names:
			<input type="text" name="names" placeholder="Enter names using the right delimiter!" required>
		</div>
		<div>
			Ages:
			<input type="text" name="ages" placeholder="Enter ages using the right delimiter!" required>
		</div>
		<div>
			<input type="submit" name="filter" value="Filter">
		</div>
	</form>
	<?php 
		if (!empty($_SESSION['names']) && !empty($_SESSION['ages'])): ?>
		<?php

		?>
			<table border="1" cellpadding="0">
				<thead>
					<tr>
						<th>Name</th>
						<th>Age</th>
					</tr>
				</thead>
				<tbody>
					<?php for ($i = 0; $i < 5; $i++): ?>
						<?php if ($_SESSION['i'] + $i > count($_SESSION['names']) - 1) {
							break;
						} ?>
						<tr>
							<td><?= $_SESSION['names'][$_SESSION['i'] + $i]; ?></td>
							<td><?= $_SESSION['ages'][$_SESSION['i'] + $i]; ?></td>
						</tr>
					<?php endfor ?>
				</tbody>
			</table>
			<form method="post">
			<?php if ((count($_SESSION['names']) - $_SESSION['i']) / 5 < 4): ?>
				<input type="submit" name="pre" value="<<<Previous">
			<?php endif ?>
			<?php $i = 0; ?>
			<?php for ($y; $y <= ($_SESSION['i'] / 5) + 3; $y++): ?>
				<?php
					// the page before the last page
					if ($y == $pages - 1 && $i == 0) {
						echo "<input type='submit' name='page' value='" . ($y - 1) . "'>";
					}
					// the last page
					if ($y == $pages && $i == 0) {
						echo "<input type='submit' name='page' value='" . ($y - 2) . "'> ";
						echo "<input type='submit' name='page' value='" . ($y - 1) . "'>";
					}
					if ((count($_SESSION['names']) / 5) + 1 < $y) {
						break;
					}
					$i++;
				?>
				<?php if (!empty($y)): ?>
					<input type="submit" name="page" <?= (($_SESSION['i'] / 5) + 1 == $y) ? "style='color: red; font-weight: 600;'" : "" ?> value="<?= $y; ?>">
				<?php endif ?>
			<?php endfor ?>
			<?php if ((count($_SESSION['names']) - $_SESSION['i']) / 5 > 1): ?>
				<input type="submit" name="next" value="Next>>>">
			<?php endif ?>
				<br><br><br>
				<input type="submit" name="clear" value="Clear Session">
			</form>
		<?php endif; ?>
</body>
</html>
<?php 
// echo "<pre>";
// print_r("y: " . $y);
// echo "</pre>";
// echo "<pre>";
// print_r($_SESSION['i']);
// echo "</pre>";
// echo count($_SESSION['names']);
 ?>