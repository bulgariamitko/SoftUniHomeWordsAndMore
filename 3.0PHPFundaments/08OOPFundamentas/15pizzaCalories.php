<?php

Class Dough
{
    protected $flour;
    protected $baking;
    protected $weight;

    const WHITE = 1.5;
    const WHOLEGRAIN = 1.0;
    const CRISPY = 0.9;
    const CHEWY = 1.1;
    const HOMEMADE = 1.0;
    const BASE = 2;

    public function __construct(string $flour, string $baking, int $weight)
    {
        $this->setFlour($flour);
        $this->setBaking($baking);
        $this->setWeight($weight);
    }

    /**
     * Gets the value of flour.
     *
     * @return mixed
     */
    public function getFlour()
    {
        return $this->flour;
    }

    /**
     * Sets the value of flour.
     *
     * @param mixed $flour the flour
     *
     * @return self
     */
    protected function setFlour($flour)
    {
        $flour = strtolower($flour);
        if ($flour != "white" && $flour != "wholegrain") {
            throw new Exception("Invalid type of dough.");
        }
        if ($flour == "white") {
            $this->flour = $this::WHITE;
        } else {
            $this->flour = $this::WHOLEGRAIN;
        }

        return $this;
    }

    /**
     * Gets the value of baking.
     *
     * @return mixed
     */
    public function getBaking()
    {
        return $this->baking;
    }

    /**
     * Sets the value of baking.
     *
     * @param mixed $baking the baking
     *
     * @return self
     */
    protected function setBaking($baking)
    {
        $baking = strtolower($baking);
        if ($baking != "crispy" && $baking != "chewy") {
            throw new Exception("Invalid type of dough.");
        }
        if ($baking == "crispy") {
            $this->baking = $this::CRISPY;
        } else {
            $this->baking = $this::CHEWY;
        }

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
        if ($weight > 1 && $weight > 200) {
            throw new Exception("Dough weight should be in the range [1..200].");
        }
        $this->weight = $weight;

        return $this;
    }

    public function calculateWeight()
    {
        return number_format(($this::BASE * $this->getWeight()) * $this->getFlour() * $this->getBaking(), 2);
    }
}

Class Topping
{
    protected $type;
    protected $weight;
    protected $typeAsItIs;

    const MEAT = 1.2;
    const VEGGIES = 0.8;
    const CHEESE = 1.1;
    const SAUCE = 0.9;
    const BASE = 2;

    public function __construct(string $type, int $weight)
    {
        $this->setType($type);
        $this->setWeight($weight);
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
        $this->typeAsItIs = $type;
        $type = strtolower($type);
        if ($type != "meat" && $type != "veggies" && $type != "cheese" && $type != "sauce") {
            throw new Exception("Cannot place {$this->typeAsItIs} on top of your pizza.");
        }
        if ($type == "meat") {
            $this->type = $this::MEAT;
        } elseif ($type == "veggies") {
            $this->type = $this::VEGGIES;
        } elseif ($type == "cheese") {
            $this->type = $this::CHEESE;
        } else {
            $this->type = $this::SAUCE;
        }

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
        if ($weight < 1 && $weight > 50) {
            throw new Exception("{$this->typeAsItIs} weight should be in the range [1..50].");
        }
        $this->weight = $weight;

        return $this;
    }

    public function calculateWeight()
    {
        return number_format(($this::BASE * $this->getWeight()) * $this->getType(), 2);
    }
}

Class Pizza
{
    protected $name;
    protected $numOfToppings;
    protected $toppings = [];
    protected $calories;

    public function __construct(string $name, int $numOfToppings)
    {
        $this->setName($name);
        $this->setNumOfToppings($numOfToppings);
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
        if (empty($name) || strlen($name) > 15) {
            throw new Exception("Pizza name should be between 1 and 15 symbols.");
        }
        $this->name = $name;

        return $this;
    }

    /**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getNumOfToppins()
    {
        return $this->numOfToppings;
    }

    /**
     * Sets the value of name.
     *
     * @param mixed $name the name
     *
     * @return self
     */
    protected function setNumOfToppings($numOfToppings)
    {
        $numOfToppings = (int)$numOfToppings;
        if ($numOfToppings <= 0 || $numOfToppings >= 11) {
            throw new Exception("Number of toppings should be in range [0..10].");
        }
        $this->numOfToppings = $numOfToppings;

        return $this;
    }

    public function addTopping(Topping $topping)
    {
        $this->toppings[] = $topping;
        return $this;
    }

    public function getCalories()
    {
        return $this->calories;
    }

    public function addCalories(float $caloriesToAdd)
    {
        $this->calories += $caloriesToAdd;
    }
}

$pizzaData = explode(" ", trim(fgets(STDIN)));
$doughData = explode(" ", trim(fgets(STDIN)));

try {
    $pizza = new Pizza($pizzaData[1], $pizzaData[2]);
    $dough = new Dough($doughData[1], $doughData[2], (int)$doughData[3]);
    $pizza->addCalories($dough->calculateWeight());
    for ($i=0; $i < $pizza->getNumOfToppins(); $i++) { 
        $toppingData = explode(" ", trim(fgets(STDIN)));
        $topping = new Topping($toppingData[1], $toppingData[2]);
        $pizza->addCalories($topping->calculateWeight());
    }

} catch (Exception $e) {
    echo $e->getMessage();
    exit;
}

$end = trim(fgets(STDIN));

echo $pizza->getName() . " - " . number_format($pizza->getCalories(), 2, ".", "") . " Calories.";