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

    public function __toString()
    {
        $output = (new ReflectionClass($this))->getName()
            . " {$this->getName()} {$this->getAge()} {$this->getGender()}" . PHP_EOL
            . $this->produceSound();
        return $output;
    }
}

class Dog extends Animal
{
	const SOUND = "BauBau";

	public function produceSound()
	{
		return self::SOUND;
	}
}

class Cat extends Animal
{
	const SOUND = "MiauMiau";

	public function produceSound()
	{
		return self::SOUND;
	}
}

class Frog extends Animal
{
	const SOUND = "Frogggg";

	public function produceSound()
	{
		return self::SOUND;
	}
}

class Kittens extends Cat
{
	const SOUND = "Miau";

	public function produceSound()
	{
		return self::SOUND;
	}
}

class Tomcat extends Cat
{
	const SOUND = "Give me one million b***h";

	public function produceSound()
	{
		return self::SOUND;
	}
}

$line = trim(fgets(STDIN));
$animals = [];

while ($line != "Beast!") {
	$data = explode(" ", trim(fgets(STDIN)));
	if (count($data) != 3) {
		throw new Exception("Invalid input!");
	}
	try {
		switch ($line) {
			case 'Dog':
				$dog = new Dog(...$data);
				$animals[] = $dog;
				break;
			case 'Cat':
				$cat = new Cat(...$data);
				$animals[] = $cat;
				break;
			case 'Frog':
				$frog = new Frog(...$data);
				$animals[] = $frog;
				break;
			case 'Kittens':
				$kittens = new Kittens(...$data);
				$animals[] = $kittens;
				break;
			case 'Tomcat':
				$tomcat = new Tomcat(...$data);
				$animals[] = $tomcat;
				break;
			default:
				throw new Exception("Not implemented!");
				break;
		}
	} catch (Exception $e) {
		echo $e->getMessage();
	}

	$line = trim(fgets(STDIN));
}

foreach ($animals as $animal) {
	echo $animal . PHP_EOL;
}