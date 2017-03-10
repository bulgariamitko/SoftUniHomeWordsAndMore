<?php

interface Calleble
{
	public function call($number) : string;
}

interface Browseble
{
	public function browse($site) : string;
}

Class Smartphone implements Calleble, Browseble
{
	
	public function call($number) : string
	{
		if (!preg_match("/^[\\d]+$/", $number)) {
            throw new Exception("Invalid number!");
        }
		return "Calling... " . $number;
	}

	public function browse($site) : string
	{
		if (preg_match("/\\d/", $site)) {
			throw new Exception("Invalid URL!");
		}
		return "Browsing: " . $site . "!";
	}
}

$numsData = explode(" ", trim(fgets(STDIN)));
$urlData = explode(" ", trim(fgets(STDIN)));

$smartPhone = new Smartphone();

foreach ($numsData as $number) {
	try {
		echo $smartPhone->call($number) . PHP_EOL;
	} catch (Exception $e) {
		echo $e->getMessage() . PHP_EOL;
	}
}
foreach ($urlData as $url) {
	try {
		echo $smartPhone->browse($url) . PHP_EOL;
	} catch (Exception $e) {
		echo $e->getMessage() . PHP_EOL;
	}
}