<?php 
function array_orderby() {
    $args = func_get_args();
    $data = array_shift($args);
    foreach ($args as $n => $field) {
        if (is_string($field)) {
            $tmp = array();
            foreach ($data as $key => $row)
                $tmp[$key] = $row[$field];
            $args[$n] = $tmp;
            }
    }
    $args[] = &$data;
    call_user_func_array('array_multisort', $args);
    return array_pop($args);
}

// avg score
$score = [];

// if form is entered
if (!empty($_POST['enter'])) {
	$person = [];
	for ($i=0; $i <= floor(count($_POST) / 4); $i++) {
		if (!empty($_POST['first-' . $i])) {
			array_push($score, $_POST['score-' . $i]);
			array_push($person, ['First' => $_POST['first-' . $i], 'Last' => $_POST['last-' . $i], 'Email' => $_POST['email-' . $i], 'Score' => $_POST['score-' . $i]]);
		}
	}

	switch ($_POST['sortby']) {
		case 1:
			$key = 'First';
			break;
		case 2:
			$key = 'Last';
			break;
		case 3:
			$key = 'Email';
			break;
		case 4:
			$key = 'Score';
			break;
		default:
			throw new Exception("Error Processing Request", 1);
			break;
	}

	switch ($_POST['order']) {
		case 'asc':
			$order = SORT_ASC;
			break;
		case 'desc':
			$order = SORT_DESC;
			break;
		default:
			throw new Exception("Error Processing Request", 1);
			break;
	}

	// soring array
	$sorted = array_orderby($person, $key, $order);
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Modify String</title>
	<script src="https://code.jquery.com/jquery-3.1.1.js" integrity="sha256-16cdPddA6VdVInumRGo6IbivbERE8p7CQR3HzTBuELA=" crossorigin="anonymous"></script>
</head>
<style type="text/css">
	table, th, td {
	    border: 1px solid black;
	}
	span {
	    padding: 5px;
	    background-color: blue;
	    margin: 10px 10px;
	    cursor: pointer;
	}
</style>
<body>
	<h1>Modify String</h1>
	<form method="post">
		<div class="default">
			<input type="text" name="first-0" placeholder="First name" required>
			<input type="text" name="last-0" placeholder="Second name" required>
			<input type="email" name="email-0" placeholder="Email address" required>
			<input type="number" name="score-0" placeholder="Exam score" required>
		</div>
		<div class="default-1">
			<input type="text" name="first-1" placeholder="First name" required>
			<input type="text" name="last-1" placeholder="Second name" required>
			<input type="email" name="email-1" placeholder="Email address" required>
			<input type="number" name="score-1" placeholder="Exam score" required>
		</div>
		<div class="default-2">
			<input type="text" name="first-2" placeholder="First name" required>
			<input type="text" name="last-2" placeholder="Second name" required>
			<input type="email" name="email-2" placeholder="Email address" required>
			<input type="number" name="score-2" placeholder="Exam score" required>
		</div>
		<span id="add">+</span>
		<label>Sort by:</label>
		<select name="sortby">
			<option value="1">First name</option>
			<option value="2">Last name</option>
			<option value="3">Email</option>
			<option value="4">Exam score</option>
		</select>
		<select name="order">
			<option value="asc">Ascending</option>
			<option value="desc">Descending</option>
		</select>
		<input type="submit" name="enter" value="Submit">
	</form>
	<?php if ($_POST['enter']): ?>
		<hr>
		<h3>Results:</h3>
		<table width="400">
			<tr>
				<th>First name</th>
				<th>Last name</th>
				<th>Email</th>
				<th>Exam score</th>
			</tr>
			<?php foreach ($sorted as $individual): ?>
				<tr>
				<?php foreach ($individual as $v): ?>
					<td><?= $v; ?></td>
				<?php endforeach ?>
				</tr>
			<?php endforeach ?>
			<?php 
				$count = count($score);
				$sum = array_sum($score);
				$median = $sum / $count;
				$average = ceil($median);
			 ?>
			<tr>
				<td colspan="3">Averange Score:</td>
				<td><?= $average; ?></td>
			</tr>
		</table>
	<?php endif ?>
</body>
</html>
<script type="text/javascript">
$(document).ready(function() {
	var num = 2;
	// add input
	$('#add').click(function() {
		num++;
		$('.default-2').after('<div class="default-' + num + '"><input type="text" name="first-' + num + '" placeholder="First name" required> <input type="text" name="last-' + num + '" placeholder="Second name" required> <input type="email" name="email-' + num + '" placeholder="Email address" required> <input type="number" name="score-' + num + '" placeholder="Exam score" required><span class="default-' + num + '">-</span</div>');
	});
	// delete input
	$('span[class^=default-]').click(function() {
		console.log('fsdfsd');
	});
});
</script>
