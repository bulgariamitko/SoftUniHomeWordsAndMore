<?php
require_once $_SERVER['DOCUMENT_ROOT'] . '/DB/connection.php';

// controllers
require_once $_SERVER['DOCUMENT_ROOT'] . '/Controllers/SkiController.php';

$ski = new SkiController($connection);

if (!empty($_POST['submit'])) {

	$ski->editVacationById($_GET['id'],
	$_POST['firstName'], 
    $_POST['lastName'], 
    $_POST['phone'], 
    $_POST['email'], 
    $_POST['roomType'], 
    $_POST['children'], 
    $_POST['adults'], 
    $_POST['rooms'], 
    $_POST['checkin'], 
    $_POST['checkout'], 
    $_POST['liftPass'] ?? 0, 
    $_POST['skiInstructor'] ?? 0);
}

$vacation = $ski->getVacationById($_GET['id']);
?>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Edit Vacation</title>
	<link rel="stylesheet" type="text/css" href="https://bootswatch.com/paper/bootstrap.min.css">
</head>
<body>
	<h2>Edit Vacation</h2>
	<form method="post" class="form-inline">
		<h3>Personal details:</h3>
		<label for="firstName">First Name*</label>
		<input type="text" value="<?= $vacation['customer']['FirstName'] ?>" name="firstName" id="firstName" placeholder="First name" class="form-control" required>
		<label for="lastName">Last Name*</label>
		<input type="text" value="<?= $vacation['customer']['LastName'] ?>" name="lastName" id="lastName" placeholder="Last name" class="form-control" required>
		<label for="phone">Phone Number*</label>
		<input type="tel" value="<?= $vacation['customer']['Phone'] ?>" name="phone" id="phone" placeholder="Phone number" class="form-control" required>
		<label for="email">Email Address*</label>
		<input type="email" value="<?= $vacation['customer']['Email'] ?>" name="email" id="email" placeholder="Email address" class="form-control" required>
		<h3>Room details:</h3>
		<label for="roomType">Type of Accommodation*</label>
		<select name="roomType" id="roomType" class="form-control">
			<option value="Hotel">Hotel</option>
			<option value="Hostel">Hostel</option>
			<option value="Villa">Villa</option>
		</select>
		<label for="children">Number of Children*</label>
		<input type="number" value="<?= $vacation['reservation']['Children'] ?>" name="children" id="children" placeholder="Number of Children" class="form-control" required>
		<label for="adults">Number of Adults*</label>
		<input type="number" value="<?= $vacation['reservation']['Adults'] ?>" name="adults" id="adults" placeholder="Number of Adults" class="form-control" required>
		<label for="rooms">Rooms*</label>
		<input type="number" value="<?= $vacation['reservation']['Rooms'] ?>" name="rooms" id="rooms" placeholder="Number of rooms needed" class="form-control" required>
		<h3>Check details</h3>
		<label for="checkin">Check-In Date*</label>
		<input type="date" value="<?= $vacation['vacation']['CheckIn'] ?>" name="checkin" id="checkin" class="form-control" required>
		<label for="checkout">Check-Out Date*</label>
		<input type="date" value="<?= $vacation['vacation']['CheckOut'] ?>" name="checkout" id="checkout" class="form-control" required>
		<label for="liftPass">Lift Pass</label>
		<input type="checkbox" value="<?= $vacation['vacation']['LiftPass'] ?>" name="liftPass" id="liftPass" class="form-control">
		<label for="skiInstructor">Ski Instructor</label>
		<input type="checkbox" value="<?= $vacation['vacation']['SkiInstructor'] ?>" name="skiInstructor" id="skiInstructor" class="form-control"><br>
		<input type="submit" name="submit" value="Reserve" class="btn btn-primary col-md-12">
	</form>
</body>
</html>