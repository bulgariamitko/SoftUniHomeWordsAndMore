<?php
require_once $_SERVER['DOCUMENT_ROOT'] . '/DB/connection.php';

// controllers
require_once $_SERVER['DOCUMENT_ROOT'] . '/Controllers/CustomerController.php';
require_once $_SERVER['DOCUMENT_ROOT'] . '/Controllers/ReservationController.php';
require_once $_SERVER['DOCUMENT_ROOT'] . '/Controllers/VacationController.php';
require_once $_SERVER['DOCUMENT_ROOT'] . '/Controllers/SkiController.php';

$ski = new SkiController($connection);

if (!empty($_POST['submit'])) {
	if ($_POST['email'] != $_POST['confirmEmail']) {
		$error = 'Sorry, your emails are not equil! Please fill the form again.';
	}

	if (empty($error)) {
		// add customer
		$customerController = new CustomerController($connection);
		$customer = $customerController->insertCustomerToDb($_POST['firstName'], $_POST['lastName'], $_POST['phone'], $_POST['email']);
		// add reservation
		$reservationController = new ReservationController($connection);
		$reservation = $reservationController->insertReservationToDb($_POST['roomType'], $_POST['children'], $_POST['adults'], $_POST['rooms']);
		// add vacation
		$liftPass = ($_POST['liftPass'] == 'on' ? 1 : 0);
		$skiInstructor = ($_POST['skiInstructor'] == 'on' ? 1 : 0);
		$vacationController = new VacationController($connection);
		$vacation = $vacationController->insertVacationToDb($_POST['checkin'], $_POST['checkout'], $liftPass, $skiInstructor);
	}
}

if ($_POST['edit']) {
	$ski->redirectForEdit($_POST['id']);
}

if ($_POST['delete']) {
	$ski->deleteReservationById($_POST['id']);
}

$allData = $ski->getAllReservations();
?>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Reserve ski</title>
	<link rel="stylesheet" type="text/css" href="https://bootswatch.com/paper/bootstrap.min.css">
</head>
<body>
	<?php if (!empty($error)): ?>
		<span class="col-md-12 bg-danger"><?= $error; ?></span>
	<?php endif ?>
<div class="container">
	<h2>Make reservation:</h2>
	<form method="post" class="form-inline">
		<h3>Personal details:</h3>
		<label for="firstName">First Name*</label>
		<input type="text" name="firstName" id="firstName" placeholder="First name" class="form-control" required>
		<label for="lastName">Last Name*</label>
		<input type="text" name="lastName" id="lastName" placeholder="Last name" class="form-control" required>
		<label for="phone">Phone Number*</label>
		<input type="tel" name="phone" id="phone" placeholder="Phone number" class="form-control" required>
		<label for="email">Email Address*</label>
		<input type="email" name="email" id="email" placeholder="Email address" class="form-control" required>
		<label for="confirmEmail">Confirm Email Address*</label>
		<input type="email" name="confirmEmail" id="confirmEmail" placeholder="Confirm email address" class="form-control" required>
		<h3>Room details:</h3>
		<label for="roomType">Type of Accommodation*</label>
		<select name="roomType" id="roomType" class="form-control">
			<option value="Hotel">Hotel</option>
			<option value="Hostel">Hostel</option>
			<option value="Villa">Villa</option>
		</select>
		<label for="children">Number of Children*</label>
		<input type="number" name="children" id="children" placeholder="Number of Children" class="form-control" required>
		<label for="adults">Number of Adults*</label>
		<input type="number" name="adults" id="adults" placeholder="Number of Adults" class="form-control" required>
		<label for="rooms">Rooms*</label>
		<input type="number" name="rooms" id="rooms" placeholder="Number of rooms needed" class="form-control" required>
		<h3>Check details</h3>
		<label for="checkin">Check-In Date*</label>
		<input type="date" name="checkin" id="checkin" class="form-control" required>
		<label for="checkout">Check-Out Date*</label>
		<input type="date" name="checkout" id="checkout" class="form-control" required>
		<label for="liftPass">Lift Pass</label>
		<input type="checkbox" name="liftPass" id="liftPass" class="form-control">
		<label for="skiInstructor">Ski Instructor</label>
		<input type="checkbox" name="skiInstructor" id="skiInstructor" class="form-control"><br>
		<input type="submit" name="submit" value="Reserve" class="btn btn-primary col-md-12">
	</form>
	<hr>
	<h2>Reservations Table</h2>
	<?php
		if (empty($allData['customer'])) {
			echo "<h5>There no data yet! Add the form to add some data!</h5>";
		} else {
	 ?>
	<table class="table table-bordered">
		<tr>
			<th>Name</th>
			<th>Phone</th> 
			<th>Email</th>
			<th>Accommodation Details</th>
			<th>Vacation Details</th>
			<th>Edit</th>
			<th>Delete</th>
		</tr>
		<?php
			for ($i=0; $i < count($allData['customer']); $i++) { 
				echo "<tr>";
					echo "<td>" . $allData['customer'][$i][1] . " " . $allData['customer'][$i][2] . "</td>";
					echo "<td>" . $allData['customer'][$i][3] . "</td>";
					echo "<td>" . $allData['customer'][$i][4] . "</td>";
					echo "<td>" . $allData['reservation'][$i][1] . ", " . $allData['reservation'][$i][2] . " Rooms, " . $allData['reservation'][$i][3] . " Adults and " . $allData['reservation'][$i][4] . " Children</td>";
					$checkin = new DateTime($allData['vacation'][$i][1]);
					$checkout = new DateTime($allData['vacation'][$i][2]);
					echo "<td>" . date_format($checkin, 'd/m/Y') . " - " . date_format($checkout, 'd/m/Y') . " Rooms, " . (empty($allData['vacation'][$i][3]) ? 'No Lift Pass' : 'Lift Pass') . " and " . (empty($allData['vacation'][$i][4]) ? 'No Ski Instructor' : 'Ski Instructor') . "</td>";
					echo "<form method='post'>";
					echo "<input type='hidden' name='id' value='" . $allData['customer'][$i][0] . "'>";
					echo "<td><input type='submit' name='edit' value='Edit' class='btn btn-warning'></td>";
					echo "<td><input type='submit' name='delete' value='Delete' class='btn btn-danger'></td>";
					echo "</form>";
				echo "</tr>";
			}
		}
		 ?>
	</table>
</div>
</body>
</html>
<?php

// echo "<pre>";
// print_r($allData);
// echo "</pre>";