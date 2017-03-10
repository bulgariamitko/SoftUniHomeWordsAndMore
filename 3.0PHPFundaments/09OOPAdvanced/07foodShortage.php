<?php

Interface IPerson
{
	public function getName() : string;
	public function getAge() : string;
	public function getId() : string;
	public function getBirthdate() : string;
}

interface IRobot
{
	public function getModel() : string;
	public function getId() : string;
}

interface IPet
{
	public function getName() : string;
	public function getBirthdate() : string;
}

interface IRebel
{
	public function getName() : string;
	public function getAge() : string;
	public function getGroup() : string;
}

interface IBuy
{
	public function getFood() : int;

	public function buyFood() : int;
}

abstract class Citizen
{
	protected $birthdate;

	public function __construct($birthdate)
	{
		$this->birthdate = $birthdate;
	}

	/**
     * Gets the value of birthdate.
     *
     * @return mixed
     */
    public function getBirthdate() : string
    {
        return $this->birthdate;
    }

    /**
     * Sets the value of birthdate.
     *
     * @param mixed $birthdate the birthdate
     *
     * @return self
     */
    protected function setBirthdate($birthdate)
    {
        $this->birthdate = $birthdate;

        return $this;
    }

	public function findBirthYear($year) : string
	{
		$findYear = explode("/", $this->getBirthdate());
		$yearToBeFind = $findYear[2];
		if ($yearToBeFind == $year) {
			return $this->getBirthdate();
		} else {
			return false;
		}
	}

}

Class Person extends Citizen implements IPerson, IBuy
{
	protected $name;
	protected $age;
	protected $id;

	protected $food;

	public function __construct(string $name, int $age, string $id, string $birthdate)
	{
		parent::__construct($birthdate);
		$this->name = $name;
		$this->age = $age;
		$this->id = $id;
	}

	/**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getName() : string
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
    public function getAge() : string
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
     * Gets the value of id.
     *
     * @return mixed
     */
    public function getId() : string
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

    public function getFood() : int
    {
    	return $this->food;
    }

    public function buyFood() : int
    {
    	$this->food += 10;
    	return $this;
    }
}

Class Robot implements IRobot
{
	protected $model;
	protected $id;

	public function __construct(string $model, string $id)
	{
		$this->model = $model;
		$this->id = $id;
	}

	/**
     * Gets the value of model.
     *
     * @return mixed
     */
    public function getModel() : string
    {
        return $this->model;
    }

    /**
     * Sets the value of model.
     *
     * @param mixed $model the model
     *
     * @return self
     */
    protected function setModel($model)
    {
        $this->model = $model;

        return $this;
    }

	/**
     * Gets the value of id.
     *
     * @return mixed
     */
    public function getId() : string
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
}

Class Pet extends Citizen implements IPet
{
	protected $name;

	public function __construct(string $name, string $birthdate)
	{
		parent::__construct($birthdate);
		$this->name = $name;
	}

	/**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getName() : string
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
}

Class Rebel implements IRebel, IBuy
{

	protected $name;
	protected $age;
	protected $group;

	protected $food;

	public function __construct(string $name, int $age, string $group)
	{
		$this->name = $name;
		$this->age = $age;
		$this->group = $group;
	}

	/**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getName() : string
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
    public function getAge() : string
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
     * Gets the value of group.
     *
     * @return mixed
     */
    public function getGroup() : string
    {
        return $this->group;
    }

    /**
     * Sets the value of group.
     *
     * @param mixed $group the group
     *
     * @return self
     */
    protected function setGroup($group)
    {
        $this->group = $group;

        return $this;
    }
	
	public function getFood() : int
    {
    	return $this->food;
    }

    public function buyFood() : int
    {
    	$this->food += 5;
    	return $this;
    }
}

$citizens = [];
$lines = trim(fgets(STDIN));

for ($i=0; $i < $lines; $i++) {
	$line = trim(fgets(STDIN));
	$data = explode(" ", $line);
	if (count($data) == 4) {
		$citizen = new Person($data[0], (int)$data[1], $data[2], $data[3]);
	} else {
		$citizen = new Rebel($data[0], (int)$data[1], $data[2]);
	}
	$citizens[] = $citizen;
}

$totalBought = 0;

while ($line != "End") {
	foreach ($citizens as $citizen) {
		if ($line == $citizen->getName()) {
			if (get_class($citizen) == "Person") {
				$totalBought += 10;
			} else {
				$totalBought += 5;
			}
		}
	}

	$line = trim(fgets(STDIN));
}

echo $totalBought;