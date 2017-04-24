<?php
interface SoundProducible
{
    public function produceSound();
}

abstract class Animal implements SoundProducible
{
	const INVALID = "Invalid input!";

	protected $name;
	protected $age;
	protected $gender;

	public function __construct($name, $age, $gender)
	{
		$this->setName($name);
		$this->setAge($age);
		$this->setGender($gender);
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
    	if (empty(trim($name))) {
    		throw new Exception(self::INVALID);
    		
    	}
        $this->name = $name;

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
    	if ($age < 0) {
    		throw new Exception(self::INVALID);
    	}
        $this->age = $age;

        return $this;
    }

    /**
     * Gets the value of gender.
     *
     * @return mixed
     */
    public function getGender()
    {
        return $this->gender;
    }

    /**
     * Sets the value of gender.
     *
     * @param mixed $gender the gender
     *
     * @return self
     */
    protected function setGender($gender)
    {
    	if (empty(trim($gender))) {
    		throw new Exception(self::INVALID);
    		
    	}
        $this->gender = $gender;

        return $this;
    }

    public function produceSound()
    {
        return "Not implemented";
    }

    public function __toString()
    {
        $output = get_class($this)
            . " {$this->getName()} {$this->getAge()} {$this->getGender()}" . PHP_EOL
            . $this->produceSound();
        return $output;
    }
}

class Dog extends Animal
{
	public function produceSound()
	{
		return "BauBau";
	}
}

class Cat extends Animal
{
	public function produceSound()
	{
		return "MiauMiau";
	}
}

class Frog extends Animal
{
	public function produceSound()
	{
		return "Frogggg";
	}
}

class Kitten extends Cat
{
    const DEFAULT_GENDER = "Female";

    public function __construct($name, $age)
    {
        parent::__construct($name, $age, self::DEFAULT_GENDER);
    }

	public function produceSound()
	{
		return "Miau";
	}
}

class Tomcat extends Cat
{
    const DEFAULT_GENDER = "Male";

    public function __construct($name, $age)
    {
        parent::__construct($name, $age, self::DEFAULT_GENDER);
    }

	public function produceSound()
	{
		return "Give me one million b***h";
	}
}

$animal = trim(fgets(STDIN));

while ($animal != "Beast!") {
	$data = explode(" ", trim(fgets(STDIN)));
	if (count($data) != 3) {
		throw new Exception("Invalid input!");
	}
	try {
		switch ($animal) {
			case 'Dog':
				$animal = new Dog(...$data);
				break;
			case 'Cat':
				$animal = new Cat(...$data);
				break;
			case 'Frog':
				$animal = new Frog(...$data);
				break;
			case 'Kitten':
				$animal = new Kitten(...$data);
				break;
			case 'Tomcat':
				$animal = new Tomcat(...$data);
				break;
			default:
                throw new Exception("Invalid input!");
				break 2;
		}
	} catch (Exception $e) {
		echo $e->getMessage() . PHP_EOL;
        break;
	}

    echo $animal . PHP_EOL;

	$animal = trim(fgets(STDIN));
}