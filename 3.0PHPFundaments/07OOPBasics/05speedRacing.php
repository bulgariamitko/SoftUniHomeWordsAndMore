<?php 

class Car
{
    const INIT_DISTANCE = 0.;

    protected $model;
    protected $amount;
    protected $cost;
    protected $distance;

    public function __construct($model, $amount, $cost)
    {
        $this->model = $model;
        $this->amount = $amount;
        $this->cost = $cost;
        $this->distance = self::INIT_DISTANCE;
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
     * Gets the value of amount.
     *
     * @return mixed
     */
    public function getAmount()
    {
        return $this->amount;
    }

    /**
     * Sets the value of amount.
     *
     * @param mixed $amount the amount
     *
     * @return self
     */
    protected function setAmount($amount)
    {
        $this->amount = $amount;

        return $this;
    }

    /**
     * Gets the value of cost.
     *
     * @return mixed
     */
    public function getCost()
    {
        return $this->cost;
    }

    /**
     * Sets the value of cost.
     *
     * @param mixed $cost the cost
     *
     * @return self
     */
    protected function setCost($cost)
    {
        $this->cost = $cost;

        return $this;
    }

    /**
     * Gets the value of distance.
     *
     * @return mixed
     */
    public function getDistance()
    {
        return $this->distance;
    }

    /**
     * Sets the value of distance.
     *
     * @param mixed $distance the distance
     *
     * @return self
     */
    protected function setDistance($distance)
    {
        $this->distance = $distance;

        return $this;
    }

    public function travel(float $distance)
    {
        $fuelNeeded = $distance * $this->cost;
        if (round($fuelNeeded, 14) > round($this->amount, 14)) {
            throw new Exception("Insufficient fuel for the drive");
        }
        $this->amount -= $fuelNeeded;
        $this->amount = abs($this->amount);
        $this->distance += $distance;
    }

    public function __toString()
    {
        return $this->getModel() . " " . number_format($this->getAmount(), 2) . " " . $this->getDistance();
    }
}

class App
{
    const END_COMMAND = "End";

    protected $cars = [];

    public function start()
    {
        $this->processInput();
    }

    public function processInput()
    {
    	$loop = trim(fgets(STDIN));

		for ($i=0; $i < $loop; $i++) {
		    $carDetails = explode(" ", trim(fgets(STDIN)));
		    $car = new Car(...$carDetails);
		    $this->addCar($car);
		}

		$line = trim(fgets(STDIN));
		while ($line != self::END_COMMAND) {
		    $line = explode(" ", $line);
		    $car = $this->cars[$line[1]];
		    try {
			    $car->travel(floatval($line[2]));
		    } catch (Exception $e) {
		    	echo $e->getMessage() . PHP_EOL;
		    }

		    $line = trim(fgets(STDIN));
		}

		$this->renderAllCars();
    }

    public function addCar(Car $car)
    {
    	$this->cars[$car->getModel()] = $car;
    }

    public function renderAllCars()
    {
    	foreach ($this->cars as $car) {
    		echo $car . PHP_EOL;
    	}
    }
}

$app = new App();
$app->start();