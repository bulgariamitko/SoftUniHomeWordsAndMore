<?php
function isPrime($num) {
    if($num == 1)
        return false;

    if($num == 2)
        return true;

    if($num % 2 == 0) {
        return false;
    }

    $ceil = ceil(sqrt($num));
    for($i = 3; $i <= $ceil; $i = $i + 2) {
        if($num % $i == 0)
            return false;
    }

    return true;
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Primes In Range</title>
</head>
<body>
	<h1>Prime In Range</h1>
	<form method="post">
		<label for="index">Starting Index:</label>
		<input type="number" name="index" id="index" required>
		<label for="end">End:</label>
		<input type="number" name="end" id="end" required>
		<input type="submit" name="enter" value="Submit">
	</form>
	<?php if (!empty($_POST['enter'])): ?>
		<?php
			$index = $_POST['index'];
			$end = $_POST['end'];
		?>
			<?php for ($i=$index; $i <= $end; $i++): ?>
				<?= (isPrime($i) ? "<strong>" . $i . "</strong>" : $i) ?>, 
			<?php endfor ?>
	<?php endif ?>
</body>
</html>