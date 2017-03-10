<?php

Class Person
{
	protected $name;
	protected $birth;

	protected $parents = [];
	protected $children = [];

	public function __construct(string $name, string $birth)
	{
		$this->name = $name;
		$this->birth = $birth;
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
     * Gets the value of birth.
     *
     * @return mixed
     */
    public function getBirth()
    {
        return $this->birth;
    }

    /**
     * Sets the value of birth.
     *
     * @param mixed $birth the birth
     *
     * @return self
     */
    protected function setBirth($birth)
    {
        $this->birth = $birth;

        return $this;
    }

    public function getPerents()
    {
    	return $this->parents;
    }

    public function addParent(Person $parent)
    {
    	$this->parents[] = $parent;

    	return $this;
    }

    public function getChildren()
    {
    	return $this->children;
    }

    public function addChild(Person $child)
    {
    	$this->children[] = $child;

    	return $this;
    }

    public function __toString()
    {
    	$output = $this->getName() . " " . $this->getBirth() . PHP_EOL;
    	$output .= "Parents:" . PHP_EOL;
    	foreach ($this->getPerents() as $parent) {
    		$output .= $parent->getName() . " " . $parent->getBirth() . PHP_EOL;
    	}
    	$output .= "Children:" . PHP_EOL;
    	foreach ($this->getChildren() as $child) {
    		$output .= $child->getName() . " " . $child->getBirth() . PHP_EOL;
    	}
    	return $output;
    }
}

$lines = [];
$line = trim(fgets(STDIN));

while ($line != "End") {
	$lines[] = $line;

	$line = trim(fgets(STDIN));
}

$people = [];
foreach ($lines as $line) {
	$data = explode(" ", $line);
	if (count($data) == 3 && ctype_alpha($data[0][0])) {
		$person = new Person($data[0] . " " . $data[1], $data[2]);
		$people[$person->getName()] = $person;
	}
}

foreach ($lines as $line) {
	$data = explode(" ", $line);
	// case - “FirstName LastName - FirstName LastName”
	if (count($data) == 5 && ctype_alpha($data[0][0]) && ctype_alpha($data[3][0]) && $data[2] == '-') {
		foreach ($people as $person) {
			if ($person->getName() == $data[0] . " " . $data[1]) {
				$currentPerson = $person;
			}
			if ($person->getName() == $data[3] . " " . $data[4]) {
				$childPerson = $person;
			}
		}
		$currentPerson->addChild($childPerson);
		$childPerson->addParent($currentPerson);
	}

	// case - “FirstName LastName - day/month/year”
	if (count($data) == 4 && ctype_alpha($data[0][0]) && is_numeric($data[3][0]) && $data[2] == '-') {
		foreach ($people as $person) {
			if ($person->getName() == $data[0] . " " . $data[1]) {
				$currentPerson = $person;
			}
			if ($person->getBirth() == $data[3]) {
				$childPerson = $person;
			}
		}
		$currentPerson->addChild($childPerson);
		$childPerson->addParent($currentPerson);
	}

	// case - “day/month/year - FirstName LastName”
	if (count($data) == 4 && is_numeric($data[0][0]) && ctype_alpha($data[2][0]) && $data[1] == '-') {
		foreach ($people as $person) {
			if ($person->getBirth() == $data[0]) {
				$currentPerson = $person;
			}
			if ($person->getName() == $data[2] . " " . $data[3]) {
				$childPerson = $person;
			}
		}
		$currentPerson->addChild($childPerson);
		$childPerson->addParent($currentPerson);
	}

	// case - “day/month/year - day/month/year”
	if (count($data) == 3 && is_numeric($data[0][0]) && is_numeric($data[2][0]) && $data[1] == '-') {
		foreach ($people as $person) {
			if ($person->getBirth() == $data[0]) {
				$currentPerson = $person;
			}
			if ($person->getBirth() == $data[2]) {
				$childPerson = $person;
			}
		}
		$currentPerson->addChild($childPerson);
		$childPerson->addParent($currentPerson);
	}
}

if (ctype_alpha($lines[0][0])) {
	echo $people[$lines[0]];
} else {
	foreach ($people as $person) {
		if ($person->getBirth() == $lines[0]) {
			$result = $person;
		}
	}
	echo $result;
}