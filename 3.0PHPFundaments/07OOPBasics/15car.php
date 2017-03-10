<?php

Class Car
{
	protected $speed;
	protected $fuel;
	protected $fuelEconomy;
	protected $distance = 0.;
    protected $time = 0.;
    protected $minsPerKm = 0.;
    protected $fuelPerKm = 0.;

	public function __construct(int $speed, float $fuel, float $fuelEconomy)
	{
		$this->speed = $speed;
		$this->fuel = $fuel;
		$this->fuelEconomy = $fuelEconomy;

        $this->initialize();
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
     * Gets the value of fuel.
     *
     * @return mixed
     */
    public function getFuel()
    {
        return $this->fuel;
    }

    /**
     * Sets the value of fuel.
     *
     * @param mixed $fuel the fuel
     *
     * @return self
     */
    protected function setFuel($fuel)
    {
        $this->fuel = $fuel;

        return $this;
    }

    /**
     * Gets the value of fuelEconomy.
     *
     * @return mixed
     */
    public function getFuelEconomy()
    {
        return $this->fuelEconomy;
    }

    /**
     * Sets the value of fuelEconomy.
     *
     * @param mixed $fuelEconomy the fuel economy
     *
     * @return self
     */
    protected function setFuelEconomy($fuelEconomy)
    {
        $this->fuelEconomy = $fuelEconomy;

        return $this;
    }

    public function getDistance()
    {
    	return $this->distance;
    }

    public function getTimeTraveled()
    {
        return [
            "hours" => floor($this->time / 60),
            "minutes" => floor($this->time % 60)
        ];
    }

    public function travel(float $distance)
    {
        $requiredFuel = $this->fuelPerKm * $distance;
        if ($requiredFuel <= $this->fuel) {
            $this->fuel -= $requiredFuel;
            $this->distance += $distance;
            $this->time += $distance * $this->minsPerKm;
        } else {
            $possibleDistance = $this->fuel / $this->fuelPerKm;

            $this->distance += $possibleDistance;
            $this->fuel = 0;
            $this->time += $possibleDistance * $this->minsPerKm;
        }
    }

    public function reFuel(float $fuel)
    {
        $this->fuel += $fuel;
    }

    public function initialize()
    {
        $this->minsPerKm = 60 / $this->speed;
        $this->fuelPerKm = $this->fuelEconomy / 100;
    }
}

$line = explode(" ", trim(fgets(STDIN)));
$car = new Car(...$line);

$line = explode(" ", trim(fgets(STDIN)));
while ($line[0] != "END") {
    switch ($line[0]) {
        case 'Travel':
            $car->travel((float)$line[1]);
            break;
        case 'Refuel':
            $car->reFuel((float)$line[1]);
            break;
        case 'Distance':
            $distance = (float)$car->getDistance();
            echo "Total Distance: " . number_format($distance, 1)  . PHP_EOL;
            break;
        case 'Time':
            $time = $car->getTimeTraveled();
            echo "Total Time: " . $time['hours'] . " hours and " . $time['minutes'] . " minutes" . PHP_EOL;
            break;
        case 'Fuel':
            $fuel = (float)$car->getFuel();
            echo "Fuel left: " . number_format($fuel, 1) . " liters" . PHP_EOL;
            break;
        default:
            throw new Exception("Error Processing Request");
            break;
    }

    $line = explode(" ", trim(fgets(STDIN)));
}

