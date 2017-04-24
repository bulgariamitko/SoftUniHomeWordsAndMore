<?php

interface IVacationController
{
	public function insertVacationToDb($checkin, $checkout, $liftPass, $skiInstructor);
}