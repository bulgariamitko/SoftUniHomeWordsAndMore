<?php

Class Person
{
	protected $name;

	public function __construct($name)
	{
		$this->name = $name;
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

    public function sayHello()
    {
    	return $this->getName() . ' says "Hello"!';
    }
}


$name = trim(fgets(STDIN));
$person = new Person($name);
// $fields = count(get_object_vars($person));
// $methods = count(get_class_methods($person));
// if ($fields != 1 || $methods != 1) {
// 	throw new Exception("Too many fields or methods");
// }

echo $person->sayHello();