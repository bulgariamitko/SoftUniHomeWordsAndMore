<?php

interface IFerrarable
{
	public function useBrake();
	public function pushPedal();
}

Class Ferrari implements IFerrarable
{
	protected $driver;
	protected $model;

	public function __construct($driver, $model = "488-Spider")
	{
		$this->driver = $driver;
		$this->model = $model;
	}

    /**
     * Gets the value of driver.
     *
     * @return mixed
     */
    public function getDriver()
    {
        return $this->driver;
    }

    /**
     * Sets the value of driver.
     *
     * @param mixed $driver the driver
     *
     * @return self
     */
    protected function setDriver($driver)
    {
        $this->driver = $driver;

        return $this;
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

    public function useBrake()
    {
    	return "Brakes!";
    }

    public function pushPedal()
    {
    	return "Zadu6avam sA!";
    }

    public function __toString()
    {
    	return $this->getModel() . "/" . $this->useBrake() . "/" . $this->pushPedal() . "/" . $this->getDriver();
    }
}

$driver = trim(fgets(STDIN));
$ferrari = new Ferrari($driver);

echo $ferrari;