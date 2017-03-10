<?php

Class Car
{
	protected $model;
	protected $engine;
	protected $cargo;
	
	protected $tires = [];

	public function __construct(string $model, Engine $engine, Cargo $cargo, Tire $tire1, Tire $tire2, Tire $tire3, Tire $tire4)
	{
		$this->model = $model;
		$this->engine = $engine;
		$this->cargo = $cargo;
		array_push($this->tires, $tire1, $tire2, $tire3, $tire4);
	}

	/**
     * Gets the value of engine.
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
     * Gets the value of engine.
     *
     * @return mixed
     */
    public function getEngine()
    {
        return $this->engine;
    }

    /**
     * Sets the value of engine.
     *
     * @param mixed $engine the engine
     *
     * @return self
     */
    protected function setEngine($engine)
    {
        $this->engine = $engine;

        return $this;
    }

    /**
     * Gets the value of cargo.
     *
     * @return mixed
     */
    public function getCargo()
    {
        return $this->cargo;
    }

    /**
     * Sets the value of cargo.
     *
     * @param mixed $cargo the cargo
     *
     * @return self
     */
    protected function setCargo($cargo)
    {
        $this->cargo = $cargo;

        return $this;
    }

    /**
     * Gets the value of tire1.
     *
     * @return mixed
     */
    public function getTires()
    {
        return $this->tires;
    }
}

Class Engine
{
	protected $speed;
	protected $power;

	public function __construct(int $speed, int $power)
	{
		$this->speed = $speed;
		$this->power = $power;
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

    /**
     * Gets the value of power.
     *
     * @return mixed
     */
    public function getPower()
    {
        return $this->power;
    }

    /**
     * Sets the value of power.
     *
     * @param mixed $power the power
     *
     * @return self
     */
    protected function setPower($power)
    {
        $this->power = $power;

        return $this;
    }
}

Class Cargo
{
	protected $weight;
	protected $type;

	public function __construct(int $weight, string $type)
	{
		$this->weight = $weight;
		$this->type = $type;
	}

	/**
     * Gets the value of weight.
     *
     * @return mixed
     */
    public function getWeight()
    {
        return $this->weight;
    }

    /**
     * Sets the value of weight.
     *
     * @param mixed $weight the weight
     *
     * @return self
     */
    protected function setWeight($weight)
    {
        $this->weight = $weight;

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

Class Tire
{
	protected $pressure;
	protected $age;

	public function __construct(float $pressure, int $age)
	{
		$this->pressure = $pressure;
		$this->age = $age;
	}

    /**
     * Gets the value of pressure.
     *
     * @return mixed
     */
    public function getPressure()
    {
        return $this->pressure;
    }

    /**
     * Sets the value of pressure.
     *
     * @param mixed $pressure the pressure
     *
     * @return self
     */
    protected function setPressure($pressure)
    {
        $this->pressure = $pressure;

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

function getFlammableCars($cars) {
	return array_filter($cars, function(Car $car) {
	    if ($car->getCargo()->getType() == "flamable" &&
	        $car->getEngine()->getPower() > 250) {
	        return true;
	    }
	});
}

function getFragileCars($cars) {
	return array_filter($cars, function(Car $car) {
		if ($car->getCargo()->getType() == "fragile") {
			foreach ($car->getTires() as $tire) {
				if ($tire->getPressure() < 1) {
					return true;
				}
			}
		}
	});
}

$cars = [];
$loop = trim(fgets(STDIN));

for ($i=0; $i < $loop; $i++) {
    $line = explode(" ", trim(fgets(STDIN)));
    $model = $line[0];
    
    $speed = (int)$line[1];
    $power = (int)$line[2];

    $engine = new Engine($speed, $power);

    $weight = (int)$line[3];
    $type = $line[4];

    $cargo = new Cargo($weight, $type);

    $tire1Pressure = (float)$line[5];
    $tire1Age = (int)$line[6];
    $tire2Pressure = (float)$line[7];
    $tire2Age = (int)$line[8];
    $tire3Pressure = (float)$line[9];
    $tire3Age = (int)$line[10];
    $tire4Pressure = (float)$line[11];
    $tire4Age = (int)$line[12];

    $tire1 = new Tire($tire1Pressure, $tire1Age);
    $tire2 = new Tire($tire2Pressure, $tire2Age);
    $tire3 = new Tire($tire3Pressure, $tire3Age);
    $tire4 = new Tire($tire4Pressure, $tire4Age);

    $car = new Car($model, $engine, $cargo, $tire1, $tire2, $tire3, $tire4);

    $cars[] = $car;
}

$cargoType = trim(fgets(STDIN));

if ($cargoType == "flamable") {
	$filteredCars = getFlammableCars($cars);
} else {
	$filteredCars = getFragileCars($cars);
}

foreach ($filteredCars as $car) {
	echo $car->getModel() . PHP_EOL;
}