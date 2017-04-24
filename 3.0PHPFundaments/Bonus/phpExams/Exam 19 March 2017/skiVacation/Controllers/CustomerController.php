<?php
require_once $_SERVER['DOCUMENT_ROOT'] . '/DB/connection.php';

require_once $_SERVER['DOCUMENT_ROOT'] . '/Models/Customer.php';
require_once $_SERVER['DOCUMENT_ROOT'] . '/Interfaces/ICustomerController.php';

Class CustomerController implements ICustomerController
{
	protected $connection;

	public function __construct($connection)
	{
		$this->connection = $connection;
	}

	public function insertCustomerToDb($firstName, $lastName, $phone, $email)
	{
		$this->connection->MInsert("Users", "(FirstName, LastName, Phone, Email, Deleted) VALUES ('" . $firstName . "', '" . $lastName . "', '" . $phone . "', '" . $email . "', 0)");

		$customer = $this->connection->MSelectOnly('Users', '*', 'ORDER BY ID DESC');
		return $customer;
	}
	
}