<?php

Class Family
{
	protected $people = [];
	private $oldestPerson;

	/**
     * Gets the value of person.
     *
     * @return mixed
     */
    public function getPeople()
    {
        return $this->people;
    }

    /**
     * Sets the value of person.
     *
     * @param mixed $person the person
     *
     * @return self
     */
    public function addPerson(Person $person)
    {
        $this->people[] = $person;
        if ($this->oldestPerson == null ||
        	$person->getAge() > $this->oldestPerson->getAge()) {
        		$this->oldestPerson = $person;
        }
        return $this;
    }

    public function getOldestMember()
    {
    	return $this->oldestPerson;
    }
}

Class Person
{
	protected $name;
	protected $age;

	public function __construct(string $name, int $age)
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
}

$loop = trim(fgets(STDIN));
$family = new Family();

for ($i=0; $i < $loop; $i++) { 
	$line = explode(" ", trim(fgets(STDIN)));
	
	$name = $line[0];
	$age = $line[1];

	$person = new Person($name, $age);
	$family->addPerson($person);
}


echo $family->getOldestMember()->getName() . " " . $family->getOldestMember()->getAge();

