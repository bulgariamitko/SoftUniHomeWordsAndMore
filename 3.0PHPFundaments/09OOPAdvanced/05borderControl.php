<?php

Interface ICitizen
{
	public function getName() : string;
	public function getId() : string;
	public function findId($lastNums) : string;
}

abstract class Citizen implements ICitizen
{
	protected $name;
	protected $id;

	public function __construct(string $name, string $id)
	{
		$this->name = $name;
		$this->id = $id;
	}

    /**
     * Gets the value of name.
     *
     * @return mixed
     */
    public function getName() : string
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
     * Gets the value of id.
     *
     * @return mixed
     */
    public function getId() : string
    {
        return $this->id;
    }

    /**
     * Sets the value of id.
     *
     * @param mixed $id the id
     *
     * @return self
     */
    protected function setId($id)
    {
        $this->id = $id;

        return $this;
    }

    public function findId($lastNums) : string
    {
    	$length = strlen($lastNums);
    	$revertId = strrev($this->getId());
    	$cutId = substr($revertId, 0, $length);
    	$revertNum = strrev($lastNums);
    	if ($cutId == $revertNum) {
    		return $this->getId();
    	}
    	return false;
    }
}

Class Person extends Citizen
{
	protected $age;

	public function __construct(string $name, int $age, string $id)
	{
		parent::__construct($name, $id);
		$this->age = $age;
	}
}

Class Robot extends Citizen
{

}

$citizens = [];
$line = trim(fgets(STDIN));

while ($line != "End") {
	$data = explode(" ", $line);
	if (count($data) == 2) {
		$citizen = new Robot($data[0], $data[1]);
	} else {
		$citizen = new Person($data[0], (int)$data[1], $data[2]);
	}

	$citizens[] = $citizen;

	$line = trim(fgets(STDIN));
}

$num = trim(fgets(STDIN));

foreach ($citizens as $citizen) {
	if (!empty($citizen->findId($num))) {
		echo $citizen->findId($num) . PHP_EOL;
	}
}