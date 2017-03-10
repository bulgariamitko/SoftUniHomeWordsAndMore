<?php

$name = trim(fgets(STDIN));
$age = trim(fgets(STDIN));

Class Person {
	protected $name;
	protected $age;

	public function __construct($name, $age)
	{
		$this->name = $name;
		$this->age = $age;
		echo $this->name . " " . $this->age;
	}
}


new Person($name, $age);