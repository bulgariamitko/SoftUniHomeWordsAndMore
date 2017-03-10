<?php

Class Food
{
	protected $name;
	protected $happiness;

	public function __construct(string $name, int $happiness)
	{
		$this->name = $name;
		$this->happiness = $happiness;
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
     * Gets the value of happiness.
     *
     * @return mixed
     */
    public function getHappiness()
    {
        return $this->happiness;
    }

    /**
     * Sets the value of happiness.
     *
     * @param mixed $happiness the happiness
     *
     * @return self
     */
    protected function setHappiness($happiness)
    {
        $this->happiness = $happiness;

        return $this;
    }
}

Class FoodFactory
{
    public static function create(string $name, int $happiness)
    {
        return new Food($name, $happiness);
    }
}

Class Wizard
{
	protected $name;
	protected $mood;

	public function __construct(string $name, int $mood = 0)
	{
		$this->name = $name;
		$this->mood = $mood;
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
     * Gets the value of mood.
     *
     * @return mixed
     */
    public function getMood()
    {
        return $this->mood;
    }

    /**
     * Sets the value of mood.
     *
     * @param mixed $mood the mood
     *
     * @return self
     */
    public function setMood($mood)
    {
        $this->mood = $mood;

        return $this;
    }

    public function getCurrentMood()
    {
    	if ($this->mood < -5) {
    		return "Angry";
    	} elseif ($this->mood >= -5 && $this->mood < 0) {
    		return "Sad";
    	} elseif ($this->mood >= 0 && $this->mood <= 15) {
    		return "Happy";
    	} else {
    		return "PHP";
    	}
    }
}

$cram = FoodFactory::create("Cram", 2);
$lembas = FoodFactory::create("lembas", 3);
$apple = FoodFactory::create("apple", 1);
$melon = FoodFactory::create("melon", 1);
$honeycake = FoodFactory::create("honeycake", 5);
$mushrooms = FoodFactory::create("mushrooms", 10);

$gandalf = new Wizard("Gandalf");
$line = trim(fgets(STDIN));
$data = explode(",", $line);

foreach ($data as $eaten) {
	switch (strtolower($eaten)) {
		case 'cram':
			$setNewMood = $gandalf->getMood() + $cram->getHappiness();
			$gandalf->setMood($setNewMood);
			break;
		case 'lembas':
			$setNewMood = $gandalf->getMood() + $lembas->getHappiness();
			$gandalf->setMood($setNewMood);
			break;
		case 'apple':
			$setNewMood = $gandalf->getMood() + $apple->getHappiness();
			$gandalf->setMood($setNewMood);
			break;
		case 'melon':
			$setNewMood = $gandalf->getMood() + $melon->getHappiness();
			$gandalf->setMood($setNewMood);
			break;
		case 'honeycake':
			$setNewMood = $gandalf->getMood() + $honeycake->getHappiness();
			$gandalf->setMood($setNewMood);
			break;
		case 'mushrooms':
			$setNewMood = $gandalf->getMood() - $mushrooms->getHappiness();
			$gandalf->setMood($setNewMood);
			break;
		default:
			$setNewMood = $gandalf->getMood() - 1;
			$gandalf->setMood($setNewMood);
			break;
	}
}

echo $gandalf->getMood() . PHP_EOL;
echo $gandalf->getCurrentMood();