<?php

interface IPerson
{
    public function getName();
    public function getAge();
}

interface Identifiable
{
	public function getId() : string;
}

interface Birthable
{
	public function getBirthDate(): string;
}

Class Citizen implements IPerson
{
	protected $name;
	protected $age;
	protected $id;
	protected $birthDate;


	public function __construct(string $name, int $age, string $id, string $birthDate)
	{
		$this->setName($name);
		$this->setAge($age);
		$this->id = $id;
		$this->birthDate = $birthDate;
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

    /**
     * Gets the value of id.
     *
     * @return mixed
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Sets the value of id.
     *
     * @param mixed $id the id
     *
     * @return self
     */
    protected function setId($id)
    {
        $this->id = $id;

        return $this;
    }

    /**
     * Gets the value of birthDate.
     *
     * @return mixed
     */
    public function getBirthDate()
    {
        return $this->birthDate;
    }

    /**
     * Sets the value of birthDate.
     *
     * @param mixed $birthDate the birth date
     *
     * @return self
     */
    protected function setBirthDate($birthDate)
    {
        $this->birthDate = $birthDate;

        return $this;
    }
}

$name = trim(fgets(STDIN));
$age = trim(fgets(STDIN));
$id = trim(fgets(STDIN));
$birthDate = trim(fgets(STDIN));

$person = new Citizen($name, $age, $id, $birthDate);

echo $person->getName() . PHP_EOL;
echo $person->getAge() . PHP_EOL;
echo $person->getId() . PHP_EOL;
echo $person->getBirthDate() . PHP_EOL;