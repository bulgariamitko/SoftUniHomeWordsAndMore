<?php

abstract class Cat
{
	protected $breed;
	protected $name;
	protected $property;

	public function __construct(string $breed, string $name, int $property)
	{
		$this->breed = $breed;
		$this->name = $name;
		$this->property = $property;
	}

    /**
     * Gets the value of breed.
     *
     * @return mixed
     */
    public function getBreed()
    {
        return $this->breed;
    }

    /**
     * Sets the value of breed.
     *
     * @param mixed $breed the breed
     *
     * @return self
     */
    protected function setBreed($breed)
    {
        $this->breed = $breed;

        return $this;
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
     * Gets the value of property.
     *
     * @return mixed
     */
    public function getProperty()
    {
        return $this->property;
    }

    /**
     * Sets the value of property.
     *
     * @param mixed $property the property
     *
     * @return self
     */
    protected function setProperty($property)
    {
        $this->property = $property;

        return $this;
    }

    public function __toString()
    {
    	return $this->getBreed() . " " . $this->getName() . " " . $this->getProperty();
    }
}

Class Siamese extends Cat
{
	
}

Class Cymric extends Cat
{
	
}

Class StreetExtraordinaire extends Cat
{
	
}

$cats = [];
$line = trim(fgets(STDIN));

while ($line != "End") {
	$data = explode(" ", $line);
	switch ($data[0]) {
		case 'Siamese':
			$cat = new Siamese(...$data);
			break;
		case 'Cymric':
			$cat = new Cymric(...$data);
			break;
		case 'StreetExtraordinaire':
			$cat = new StreetExtraordinaire(...$data);
			break;
		default:
			throw new Exception("No such breed");
			break;
	}
	$cats[$data[1]] = $cat;

	$line = trim(fgets(STDIN));
}

$catName = trim(fgets(STDIN));

echo $cats[$catName];