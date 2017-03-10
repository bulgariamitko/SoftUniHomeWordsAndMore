<?php

Class Car
{
	protected $model;
	protected $engine;
	protected $weight;
	protected $color;

	public function __construct(string $model, Engine $engine, $weight, $color)
	{
		$this->model = $model;
		$this->engine = $engine;
		$this->weight = $weight;
		$this->color = $color;
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
     * Gets the value of color.
     *
     * @return mixed
     */
    public function getColor()
    {
        return $this->color;
    }

    /**
     * Sets the value of color.
     *
     * @param mixed $color the color
     *
     * @return self
     */
    protected function setColor($color)
    {
        $this->color = $color;

        return $this;
    }

    public function __toString()
    {
    	$output = "";
    	$output .= $this->getModel() . ":" . PHP_EOL;
    	$output .= "  " . $this->getEngine()->getModel() . ":" . PHP_EOL;
    	$output .= "    Power: " . $this->getEngine()->getPower() . PHP_EOL;
    	$output .= "    Displacement: " . $this->getEngine()->getDisplacement() . PHP_EOL;
    	$output .= "    Efficiency: " . $this->getEngine()->getEfficiency() . PHP_EOL;
    	$output .= "  Weight: " . $this->getWeight() . PHP_EOL;
    	$output .= "  Color: " . $this->getColor() . PHP_EOL;
    	return $output;
    }
}

Class Engine
{
	protected $model;
	protected $power;
	protected $displacement;
	protected $efficiency;

	public function __construct(string $model, int $power, $displacement, $efficiency)
	{
		$this->model = $model;
		$this->power = $power;
		$this->displacement = $displacement;
		$this->efficiency = $efficiency;
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

    /**
     * Gets the value of displacement.
     *
     * @return mixed
     */
    public function getDisplacement()
    {
        return $this->displacement;
    }

    /**
     * Sets the value of displacement.
     *
     * @param mixed $displacement the displacement
     *
     * @return self
     */
    protected function setDisplacement($displacement)
    {
        $this->displacement = $displacement;

        return $this;
    }

    /**
     * Gets the value of efficiency.
     *
     * @return mixed
     */
    public function getEfficiency()
    {
        return $this->efficiency;
    }

    /**
     * Sets the value of efficiency.
     *
     * @param mixed $efficiency the efficiency
     *
     * @return self
     */
    protected function setEfficiency($efficiency)
    {
        $this->efficiency = $efficiency;

        return $this;
    }
}

$engines = [];
$cars = [];
$enginesLoop = trim(fgets(STDIN));
for ($i=0; $i < $enginesLoop; $i++) { 
	$engineVals = explode(" ", trim(fgets(STDIN)));
	$model = $engineVals[0];
	$power = (int)$engineVals[1];
	$displacement = "n/a";
	$efficiency = "n/a";
	if (count($engineVals) > 2) {
        if (is_numeric($engineVals[2])) {
            $displacement = intval($engineVals[2]);
        } else {
            $efficiency = $engineVals[2];
        }
    }
    if (count($engineVals) > 3) {
        $efficiency = $engineVals[3];
    }
	
	$engine = new Engine($model, $power, $displacement, $efficiency);
	$engines[$engine->getModel()] = $engine;
}

$carsLoop = trim(fgets(STDIN));
for ($i=0; $i < $carsLoop; $i++) { 
	$carVals = explode(" ", trim(fgets(STDIN)));
	$model = $carVals[0];
	$engine = $engines[$carVals[1]];
	$weight = "n/a";
	$color = "n/a";
	if (count($carVals) > 2) {
        if (is_numeric($carVals[2])) {
            $weight = intval($carVals[2]);
        } else {
            $color = $carVals[2];
        }
    }
    if (count($carVals) > 3) {
        $color = $carVals[3];
    }
	
	$car = new Car($model, $engine, $weight, $color);
	$cars[$car->getModel()] = $car;
}

foreach ($cars as $car) {
	echo $car->__toString();
}