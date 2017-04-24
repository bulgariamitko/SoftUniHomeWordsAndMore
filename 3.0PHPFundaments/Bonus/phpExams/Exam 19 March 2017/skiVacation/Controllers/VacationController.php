<?php
require_once $_SERVER['DOCUMENT_ROOT'] . '/DB/connection.php';

require_once $_SERVER['DOCUMENT_ROOT'] . '/Models/Vacation.php';
require_once $_SERVER['DOCUMENT_ROOT'] . '/Interfaces/IVacationController.php';

Class VacationController implements IVacationController
{
	protected $connection;

	public function __construct($connection)
	{
		$this->connection = $connection;
	}

	public function insertVacationToDb($checkin, $checkout, $liftPass, $skiInstructor)
	{
		$this->connection->MInsert("Vacation", "(CheckIn, CheckOut, LiftPass, SkiInstructor, Deleted) VALUES ('" . $checkin . "', '" . $checkout . "', '" . $liftPass . "', '" . $skiInstructor . "', 0)");

		$vacation = $this->connection->MSelectOnly('Vacation', '*', 'ORDER BY ID DESC');
		return $vacation;
	}
	
}