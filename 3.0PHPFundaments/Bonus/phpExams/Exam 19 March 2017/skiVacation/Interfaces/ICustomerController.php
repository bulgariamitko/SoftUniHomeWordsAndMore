<?php

interface ICustomerController
{
	public function insertCustomerToDb($firstName, $lastName, $phone, $email);
}