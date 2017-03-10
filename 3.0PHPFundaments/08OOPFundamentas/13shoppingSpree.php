<?php

Class Person
{
	protected $name;
	protected $money;
	protected $bag = [];

	public function __construct($name, $money)
	{
		$this->setName($name);
		$this->setMoney($money);
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
    	if (empty($name)) {
    		throw new Exception("Name cannot be empty");
    	}
        $this->name = $name;

        return $this;
    }

    /**
     * Gets the value of money.
     *
     * @return mixed
     */
    public function getMoney()
    {
        return $this->money;
    }

    /**
     * Sets the value of money.
     *
     * @param mixed $money the money
     *
     * @return self
     */
    protected function setMoney($money)
    {
    	if ($money < 0) {
    		throw new Exception("Money cannot be negative");
    	}
        $this->money = $money;

        return $this;
    }

    /**
     * Gets the value of bag.
     *
     * @return mixed
     */
    public function getBag()
    {
        return $this->bag;
    }

    /**
     * Sets the value of bag.
     *
     * @param mixed $bag the bag
     *
     * @return self
     */
    protected function addBag(Product $product)
    {
        $this->bag[] = $product->getName();

        return $this;
    }

    public function buyProduct(Product $product)
    {
    	if ($this->getMoney() < $product->getCost()) {
    		throw new Exception($this->getName() . " can't afford " . $product->getName());
    	} 
    	$moneyLeft = $this->getMoney() - $product->getCost();
    	$this->setMoney($moneyLeft);
    	$this->addBag($product);
    	return $this->getName() . " bought " . $product->getName();
    }

    public function __toString()
    {
    	if (count($this->getBag()) == 0) {
    		return $this->getName() . " - Nothing bought";
    	} else {
	    	return $this->getName() . " - " . implode(",", $this->getBag());
    	}
    }
}

Class Product
{
	protected $name;
	protected $cost;

	public function __construct($name, $cost)
	{
		$this->setName($name);
		$this->setCost($cost);
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
    	if (empty($name)) {
    		throw new Exception("Name cannot be empty");
    	}
        $this->name = $name;

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
    	if (empty($cost)) {
    		throw new Exception("Must have a cost");
    	}
        $this->cost = $cost;

        return $this;
    }
}

// people
$people = [];
$line = trim(fgets(STDIN));
$data = explode(";", $line);
foreach ($data as $moreData) {
	if (empty($moreData)) {
		continue;
	}
	$values = explode("=", $moreData);
	try {
		$person = new Person($values[0], $values[1]);
		$people[$person->getName()] = $person;
	} catch (Exception $e) {
		echo $e->getMessage() . PHP_EOL;
	}
}

// products
$products = [];
$line = trim(fgets(STDIN));
$data = explode(";", $line);
foreach ($data as $moreData) {
	if (empty($moreData)) {
		continue;
	}
	$values = explode("=", $moreData);
	try {
		$product = new Product($values[0], $values[1]);
		$products[$product->getName()] = $product;
	} catch (Exception $e) {
		echo $e->getMessage() . PHP_EOL;
	}
}


$line = trim(fgets(STDIN));

while ($line != "END") {
	$data = explode(" ", $line);
	if (empty($people[$data[0]]) || empty($products[$data[1]])) {
		continue;
	}
	try {
		echo $people[$data[0]]->buyProduct($products[$data[1]]) . PHP_EOL;
	} catch (Exception $e) {
		echo $e->getMessage() . PHP_EOL;
	}

	$line = trim(fgets(STDIN));
}

foreach ($people as $person) {
	echo $person . PHP_EOL;
}