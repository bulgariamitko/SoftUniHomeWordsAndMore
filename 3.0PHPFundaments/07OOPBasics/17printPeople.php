<?php

Class Person
{
	protected $name;
	protected $age;
	protected $occupation;

	public function __construct($name, $age, $occupation)
	{
		$this->name = $name;
		$this->age = $age;
		$this->occupation = $occupation;
	}

    /**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * Sets the value of name.
     *
     * @param mixed $name the name
     *
     * @return self
     */
    protected function setName($name)
    {
        $this->name = $name;

        return $this;
    }

    /**
     * Gets the value of age.
     *
     * @return mixed
     */
    public function getAge()
    {
        return $this->age;
    }

    /**
     * Sets the value of age.
     *
     * @param mixed $age the age
     *
     * @return self
     */
    protected function setAge($age)
    {
        $this->age = $age;

        return $this;
    }

    /**
     * Gets the value of occupation.
     *
     * @return mixed
     */
    public function getOccupation()
    {
        return $this->occupation;
    }

    /**
     * Sets the value of occupation.
     *
     * @param mixed $occupation the occupation
     *
     * @return self
     */
    protected function setOccupation($occupation)
    {
        $this->occupation = $occupation;

        return $this;
    }

    public function __toString()
    {
    	$output = $this->getName() . " - age: " . $this->getAge() . ", occupation: " . $this->getOccupation();
    	return $output;
    }
}

$people = [];
$line = explode(" ", trim(fgets(STDIN)));

while ($line[0] != "END") {
	$name = $line[0];
	$age = $line[1];
	$occupation = $line[2];
	$person = new Person($name, $age, $occupation);
	$people[] = $person;

	$line = explode(" ", trim(fgets(STDIN)));
}

uasort($people, function(Person $person1, Person $person2) {
    return $person1->getAge() <=> $person2->getAge();
});

echo implode(PHP_EOL, $people);