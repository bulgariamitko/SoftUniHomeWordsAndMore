<?php
require_once $_SERVER['DOCUMENT_ROOT'] . '/DB/connection.php';

require_once $_SERVER['DOCUMENT_ROOT'] . '/Models/Reservation.php';
require_once $_SERVER['DOCUMENT_ROOT'] . '/Interfaces/IReservationController.php';

Class ReservationController implements IReservationController
{
	protected $connection;

	public function __construct($connection)
	{
		$this->connection = $connection;
	}

	public function insertReservationToDb($roomType, $children, $adults, $rooms)
	{
		$this->connection->MInsert("Reservation", "(RoomType, Children, Adults, Rooms, Deleted) VALUES ('" . $roomType . "', '" . $children . "', '" . $adults . "', '" . $rooms . "', 0)");

		$reservation = $this->connection->MSelectOnly('Reservation', '*', 'ORDER BY ID DESC');
		return $reservation;
	}

}