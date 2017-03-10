<?php

Class Person
{
	protected $name;
	protected $company;
	protected $car;
	protected $pokemons = [];
	protected $children = [];
	protected $parents = [];

	public function __construct(string $name)
	{
		$this->name = $name;
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
     * Gets the value of company.
     *
     * @return mixed
     */
    public function getCompany()
    {
        return $this->company;
    }

    /**
     * Sets the value of company.
     *
     * @param mixed $company the company
     *
     * @return self
     */
    public function setCompany($company)
    {
        $this->company = $company;

        return $this;
    }

    /**
     * Gets the value of car.
     *
     * @return mixed
     */
    public function getCar()
    {
        return $this->car;
    }

    /**
     * Sets the value of car.
     *
     * @param mixed $car the car
     *
     * @return self
     */
    public function setCar($car)
    {
        $this->car = $car;

        return $this;
    }

    /**
     * Gets the value of pokemons.
     *
     * @return mixed
     */
    public function getPokemons()
    {
        return $this->pokemons;
    }

    /**
     * Sets the value of pokemons.
     *
     * @param mixed $pokemons the pokemons
     *
     * @return self
     */
    public function addPokemons($pokemon)
    {
        $this->pokemons[] = $pokemon;

        return $this;
    }

    /**
     * Gets the value of children.
     *
     * @return mixed
     */
    public function getChildren()
    {
        return $this->children;
    }

    /**
     * adds the value of children.
     *
     * @param mixed $children the children
     *
     * @return self
     */
    public function addChildren($child)
    {
        $this->children[] = $child;

        return $this;
    }

    /**
     * Gets the value of parents.
     *
     * @return mixed
     */
    public function getParents()
    {
        return $this->parents;
    }

    /**
     * adds the value of parents.
     *
     * @param mixed $parents the parents
     *
     * @return self
     */
    public function addParents($parent)
    {
        $this->parents[] = $parent;

        return $this;
    }

    public function __toString()
    {
    	$output = $this->getName() . PHP_EOL;
    	$output .= "Company:" . PHP_EOL;
    	if (!empty($this->getCompany())) {
	    	$output .= $this->getCompany()->getCompany() . " " . $this->getCompany()->getDepartment() . " " . $this->getCompany()->getSalary() . PHP_EOL;
    	}
    	$output .= "Car:" . PHP_EOL;
    	if (!empty($this->getCar())) {
	    	$output .= $this->getCar()->getModel() . " " . $this->getCar()->getSpeed() . PHP_EOL;
    	}
    	$output .= "Pokemon:" . PHP_EOL;
    	if (!empty($this->getPokemons())) {
	    	foreach ($this->getPokemons() as $pokemon) {
	    		$output .= $pokemon->getName() . " " . $pokemon->getType() . PHP_EOL;
	    	}
    	}
    	$output .= "Parents:" . PHP_EOL;
    	if (!empty($this->getParents())) {
    		foreach ($this->getParents() as $parent) {
	    		$output .= $parent->getName() . " " . $parent->getBirth() . PHP_EOL;
	    	}
    	}
    	$output .= "Children:" . PHP_EOL;
    	if (!empty($this->getChildren())) {
	    	foreach ($this->getChildren() as $child) {
	    		$output .= $child->getName() . " " . $child->getBirth() . PHP_EOL;
	    	}
    	}

    	return $output;
    }
}

Class Company
{
	protected $company;
	protected $department;
	protected $salary;

	public function __construct(string $company, string $department, float $salary)
	{
		$this->company = $company;
		$this->department = $department;
		$this->salary = number_format((float)$salary, 2);
	}

   	/**
     * Gets the value of company.
     *
     * @return mixed
     */
    public function getCompany()
    {
        return $this->company;
    }

    /**
     * Sets the value of company.
     *
     * @param mixed $company the company
     *
     * @return self
     */
    protected function setCompany($company)
    {
        $this->company = $company;

        return $this;
    }

    /**
     * Gets the value of department.
     *
     * @return mixed
     */
    public function getDepartment()
    {
        return $this->department;
    }

    /**
     * Sets the value of department.
     *
     * @param mixed $department the department
     *
     * @return self
     */
    protected function setDepartment($department)
    {
        $this->department = $department;

        return $this;
    }

    /**
     * Gets the value of salary.
     *
     * @return mixed
     */
    public function getSalary()
    {
        return $this->salary;
    }

    /**
     * Sets the value of salary.
     *
     * @param mixed $salary the salary
     *
     * @return self
     */
    protected function setSalary($salary)
    {
        $this->salary = $salary;

        return $this;
    }
}

Class Car
{
	protected $model;
	protected $speed;

	public function __construct(string $model, int $speed)
	{
		$this->model = $model;
		$this->speed = $speed;
	}

    /**
     * Gets the value of model.
     *
     * @return mixed
     */
    public function getModel()
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
     * Gets the value of speed.
     *
     * @return mixed
     */
    public function getSpeed()
    {
        return $this->speed;
    }

    /**
     * Sets the value of speed.
     *
     * @param mixed $speed the speed
     *
     * @return self
     */
    protected function setSpeed($speed)
    {
        $this->speed = $speed;

        return $this;
    }
}

Class Pokemon
{
	protected $name;
	protected $type;

	public function __construct(string $name, string $type)
	{
		$this->name = $name;
		$this->type = $type;
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
     * Gets the value of type.
     *
     * @return mixed
     */
    public function getType()
    {
        return $this->type;
    }

    /**
     * Sets the value of type.
     *
     * @param mixed $type the type
     *
     * @return self
     */
    protected function setType($type)
    {
        $this->type = $type;

        return $this;
    }
}

Class Family
{
	protected $name;
	protected $birth;

	public function __construct(string $name, string $birth)
	{
		$this->name = $name;
		$this->birth = $birth;
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
     * Gets the value of birth.
     *
     * @return mixed
     */
    public function getBirth()
    {
        return $this->birth;
    }

    /**
     * Sets the value of birth.
     *
     * @param mixed $birth the birth
     *
     * @return self
     */
    protected function setBirth($birth)
    {
        $this->birth = $birth;

        return $this;
    }
}

Class Child
{
	protected $name;
	protected $birth;

	public function __construct(string $name, string $birth)
	{
		$this->name = $name;
		$this->birth = $birth;
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
     * Gets the value of birth.
     *
     * @return mixed
     */
    public function getBirth()
    {
        return $this->birth;
    }

    /**
     * Sets the value of birth.
     *
     * @param mixed $birth the birth
     *
     * @return self
     */
    protected function setBirth($birth)
    {
        $this->birth = $birth;

        return $this;
    }
}

$people = [];
$line = trim(fgets(STDIN));
while ($line != "End") {
	$values = explode(" ", $line);
	$name = $values[0];

	if (empty($people[$name])) {
		$person = new Person($name);
		$people[$person->getName()] = $person;
	}
	switch ($values[1]) {
		case 'company':
			$company = new Company($values[2], $values[3], $values[4]);
			$people[$name]->setCompany($company);
			break;
		case 'car':
			$car = new Car($values[2], (int)$values[3]);
			$people[$name]->setCar($car);
			break;
		case 'pokemon':
			$pokemon = new Pokemon($values[2], $values[3]);
			$people[$name]->addPokemons($pokemon);
			break;
		case 'parents':
			$parent = new Family($values[2], $values[3]);
			$people[$name]->addParents($parent);
			break;
		case 'children':
			$child = new Child($values[2], $values[3]);
			$people[$name]->addChildren($child);
			break;
		default:
			throw new Exception("Switch error, no such value");
			break;
	}

	$line = trim(fgets(STDIN));
}

$personToOutput = trim(fgets(STDIN));

foreach ($people as $person) {
	if ($person->getName() == $personToOutput) {
		echo $person;
	}
}

// echo "<pre>";
// print_r($people);
// echo "</pre>";