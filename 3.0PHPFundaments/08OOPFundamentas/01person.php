<?php

Class Person
{
	protected $name;
	protected $age;

	public function __construct(string $name, int $age)
	{
		$this->setName($name);
		$this->setAge($age);
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
    	if (strlen($name) < 4) {
    		throw new Exception("Name’s length should not be less than 3 symbols!");
    	}
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
    	if ($age < 1) {
    		throw new Exception("Age must be positive!");
    	}
        $this->age = $age;

        return $this;
    }
}

Class Child extends Person
{
	protected $age;

	public function __construct(int $age)
	{
		$this->setAge();
	}

	protected function setAge($age)
	{
		if ($age > 16) {
			throw new Exception("Child’s age must be less than 16!");
		}

		parent::setAge($age);
	}
}

$name = trim(fgets(STDIN));
$age = trim(fgets(STDIN));

$person = new Person($name, $age);

echo $person->getName() . PHP_EOL;
echo $person->getAge() . PHP_EOL;