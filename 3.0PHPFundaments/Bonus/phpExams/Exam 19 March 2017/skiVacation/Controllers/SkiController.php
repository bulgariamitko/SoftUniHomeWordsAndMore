<?php

require_once $_SERVER['DOCUMENT_ROOT'] . '/DB/connection.php';
require_once $_SERVER['DOCUMENT_ROOT'] . '/Interfaces/ISkiController.php';

Class SkiController implements ISkiController
{
	public $ski = [];
	protected $connection;

	public function __construct($connection)
	{
		$this->connection = $connection;
	}

	public function getAllReservations()
	{
		$data = [];
		$data['customer'] = $this->connection->MSelectList('Users', '*', 'WHERE Deleted = 0');
		$data['reservation'] = $this->connection->MSelectList('Reservation', '*', 'WHERE Deleted = 0');
		$data['vacation'] = $this->connection->MSelectList('Vacation', '*', 'WHERE Deleted = 0');

		// $this->ski[] = $data;
		return $data;
	}

	public function deleteReservationById($id)
	{
		$this->connection->MUpdate('Users', 'Deleted = 1', 'WHERE ID = ' . $id);
		$this->connection->MUpdate('Reservation', 'Deleted = 1', 'WHERE ID = ' . $id);
		$this->connection->MUpdate('Vacation', 'Deleted = 1', 'WHERE ID = ' . $id);

		return $this;
	}

	public function redirectForEdit($id)
	{
		header('Location: Views/edit.php?id=' . $id);
	}

	public function getVacationById($id)
	{
		$vacation =[];
		$vacation['customer'] = $this->connection->MSelectOnly('Users', '*', 'WHERE ID = ' . $id);
		$vacation['reservation'] = $this->connection->MSelectOnly('Reservation', '*', 'WHERE ID = ' . $id);
		$vacation['vacation'] = $this->connection->MSelectOnly('Vacation', '*', 'WHERE ID = ' . $id);

		return $vacation;
	}

	public function editVacationById($id, $firstName, $lastName,  $phone,  $email,  $roomType,  $children,  $adults,  $rooms,  $checkin,  $checkout,  $liftPass,  $skiInstructor)
	{
		$this->connection->MUpdate('Users', 'FirstName = "' . $firstName . '", LastName = "' . $lastName . '", Phone = "' . $phone . '", Email = "' . $email . '"', 'WHERE ID = ' . $id);
		$this->connection->MUpdate('Reservation', 'RoomType = "' . $roomType . '", Children = "' . $children . '", Adults = "' . $adults . '", Rooms = "' . $rooms . '"', 'WHERE ID = ' . $id);
		$this->connection->MUpdate('Vacation', 'CheckIn = "' . $checkin . '", CheckOut = "' . $checkout . '", LiftPass = "' . $liftPass . '", SkiInstructor = "' . $skiInstructor . '"', 'WHERE ID = ' . $id);

		header('Location: ../index.php');
	}
}