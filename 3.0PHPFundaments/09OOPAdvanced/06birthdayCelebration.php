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

Class Person extends Citizen implements IPerson
{
	protected $name;
	protected $age;
	protected $id;

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

$citizens = [];
$line = trim(fgets(STDIN));

while ($line != "End") {
	$data = explode(" ", $line);
	if (count($data) == 3 && preg_match("/\//", $data[2])) {
		$citizen = new Pet($data[1], $data[2]);
		$citizens[] = $citizen;
	} elseif (count($data) == 5) {
		$citizen = new Person($data[1], (int)$data[2], $data[3], $data[4]);
		$citizens[] = $citizen;
	}


	$line = trim(fgets(STDIN));
}

$year = trim(fgets(STDIN));

foreach ($citizens as $citizen) {
	if (!empty($citizen->findBirthYear($year))) {
		echo $citizen->findBirthYear($year) . PHP_EOL;
		$output = true;
	}
}

if (!isset($output)) {
	echo "<no output>";
}