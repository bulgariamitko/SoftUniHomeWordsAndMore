<?php
Class Person {
	protected $name;
	protected $age;

	public function __construct($name, $age)
	{
		$this->name = $name;
		$this->age = $age;
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

    public function IfOver30() {
    	if ($this->getAge() > 30) {
	    	return true;
    	}
    	return false;
    }
}

$loop = trim(fgets(STDIN));

$store = [];
for ($i=0; $i < $loop; $i++) { 
	// $line = explode(' ', 'Pesho 48');
	$line = explode(' ', trim(fgets(STDIN)));
	$name = $line[0];
	$age = $line[1];
	$person = new Person($name, $age);
	if ($person->IfOver30()) {
		$store[] = $person;
	}
}

usort($store, function (Person $person1, Person $person2) {
	return $person1->getName() <=> $person2->getName();
});

foreach ($store as $person) {
	// echo $person->getName();
	echo $person->getName() . " - " . $person->getAge() . "\n";
}