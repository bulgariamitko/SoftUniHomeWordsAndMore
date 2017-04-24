<?php

interface IReservationController
{
	public function insertReservationToDb($roomType, $children, $adults, $rooms);
}