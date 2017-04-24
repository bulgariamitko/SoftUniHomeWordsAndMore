<?php

interface ISkiController
{
	public function getAllReservations();

	public function deleteReservationById($id);

	public function redirectForEdit($id);

	public function getVacationById($id);

	public function editVacationById($id, $firstName, $lastName,  $phone,  $email,  $roomType,  $children,  $adults,  $rooms,  $checkin,  $checkout,  $liftPass,  $skiInstructor);
}