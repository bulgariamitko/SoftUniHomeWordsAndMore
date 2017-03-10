<?php

interface ISoldier
{
	// public function getId();
	// public function getFirstName();
	// public function getLastName();
}

interface IPrivate
{
	public function getSalary();
}

interface ILeutenantGeneral
{
	public function getPrivates();
	public function addPrivate(PrivateSoldier $private);
}

interface ISpecialisedSoldier {
	public function getCop();
	public function setCop($cop);
}

interface IRepair
{
	public function getRepairs();
	public function addRepair(Repair $repair);
}

abstract class Soldier implements ISoldier
{
	protected $id;
	protected $firstName;
	protected $lastName;

	public function __construct(int $id, $firstName, $lastName)
	{
		$this->id = $id;
		$this->firstName = $firstName;
		$this->lastName = $lastName;
	}	

    /**
     * Gets the value of id.
     *
     * @return mixed
     */
    public function getId()
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

    public function getFirstName()
    {
    	return $this->firstName;
    }

    /**
     * Sets the value of firstName.
     *
     * @param mixed $firstName the first name
     *
     * @return self
     */
    protected function setFirstName($firstName)
    {
        $this->firstName = $firstName;

        return $this;
    }

    public function getLastName()
    {
    	return $this->lastName;
    }

    /**
     * Sets the value of lastName.
     *
     * @param mixed $lastName the last name
     *
     * @return self
     */
    protected function setLastName($lastName)
    {
        $this->lastName = $lastName;

        return $this;
    }
}

class PrivateSoldier extends Soldier implements IPrivate
{
	protected $salary;

	public function __construct(int $id, string $firstName, string $lastName, float $salary)
	{
		parent::__construct($id, $firstName, $lastName);
		$this->salary = $salary;
	}

	public function getSalary()
	{
		return $this->salary;
	}

	/**
     * Sets the value of salary.
     *
     * @param mixed $salary the salary
     *
     * @return self
     */
    protected function setSalary($salary)
    {
        $this->salary = $salary;

        return $this;
    }

    public function __toString()
    {
    	$output = "Name: " . parent::getFirstName() . " " . parent::getLastName() . " Id: " . parent::getId() . " Salary: " . number_format($this->getSalary(), 2);
    	return $output;
    }
}

Class LeutenantGeneral extends PrivateSoldier implements ILeutenantGeneral
{
	protected $privates = [];

	public function getPrivates()
	{
		return $this->privates;
	}

	public function addPrivate(PrivateSoldier $private)
	{
		$this->privates[] = $private;
		return $this;
	}

	public function __toString()
    {
    	$output = "Name: " . parent::getFirstName() . " " . parent::getLastName() . " Id: " . parent::getId() . " Salary: " . number_format(parent::getSalary(), 2) . PHP_EOL;
    		$output .= "Privates:";
	    	foreach ($this->getPrivates() as $private) {
	    		$output .= PHP_EOL . "  Name: " . $private->getFirstName() . " " . $private->getLastName() . " Id: " . $private->getId() . " Salary: " . number_format($private->getSalary(), 2);
    	}
    	return $output;
    }
}

abstract class SpecialisedSoldier extends PrivateSoldier implements ISpecialisedSoldier
{
	protected $cop;

	public function __construct(int $id, string $firstName, string $lastName, float $salary, string $cop)
	{
		parent::__construct($id, $firstName, $lastName, $salary);
		$this->setCop($cop);
	}

	public function getCop()
	{
		return $this->cop;
	}

	public function setCop($cop)
	{
		if ($cop != "Airforces" && $cop != "Marines") {
			throw new Exception("invalid corps");
		}
		$this->cop = $cop;
		return $this;
	}
}

Class Engineer extends SpecialisedSoldier
{
	protected $repairs = [];

	public function getRepairs()
	{
		return $this->repairs;
	}

	public function addRepair(Repair $repair)
	{
		$this->repairs[] = $repair;
		return $this;
	}

	public function __toString()
    {
    	$output = "Name: " . Soldier::getFirstName() . " " . Soldier::getLastName() . " Id: " . Soldier::getId() . " Salary: " . number_format(PrivateSoldier::getSalary(), 2) . PHP_EOL;
    	$output .= "Corps: " . parent::getCop() . PHP_EOL;
		$output .= "Repairs:" . PHP_EOL;
    	if (!empty($this->getRepairs())) {
	    	foreach ($this->getRepairs() as $repair) {
	    		$output .= "  Part Name: " . $repair->getName() . " Hours Worked: " . $repair->getHoursWorked() . PHP_EOL;
	    	}
    	}
    	return $output;
    }
}

Class Repair
{
	protected $name;
	protected $hoursWorked;

	public function __construct(string $name, int $hoursWorked)
	{
		$this->name = $name;
		$this->hoursWorked = $hoursWorked;
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
     * Gets the value of hoursWorked.
     *
     * @return mixed
     */
    public function getHoursWorked()
    {
        return $this->hoursWorked;
    }

    /**
     * Sets the value of hoursWorked.
     *
     * @param mixed $hoursWorked the hours worked
     *
     * @return self
     */
    protected function setHoursWorked($hoursWorked)
    {
        $this->hoursWorked = $hoursWorked;

        return $this;
    }
}

Class Commando extends SpecialisedSoldier
{
	protected $missions = [];

	public function getMissions()
	{
		return $this->missions;
	}

	public function addMission(Mission $mission)
	{
		$this->missions[] = $mission;
		return $this;
	}

	public function __toString()
    {
    	$output = "Name: " . Soldier::getFirstName() . " " . Soldier::getLastName() . " Id: " . Soldier::getId() . " Salary: " . number_format(PrivateSoldier::getSalary(), 2) . PHP_EOL;
    	$output .= "Corps: " . parent::getCop() . PHP_EOL;
		$output .= "Missions:";
	    	foreach ($this->getMissions() as $mission) {
	    		$output .= PHP_EOL . "  Code Name: " . $mission->getCodeName() . " State: " . $mission->getState();
	    	}
    	return $output;
    }
}

Class Mission
{
	protected $codeName;
	protected $state;

	public function __construct(string $codeName, string $state)
	{
		$this->setCodeName($codeName);
		$this->setState($state);
	}

    /**
     * Gets the value of codeName.
     *
     * @return mixed
     */
    public function getCodeName()
    {
        return $this->codeName;
    }

    /**
     * Sets the value of codeName.
     *
     * @param mixed $codeName the code name
     *
     * @return self
     */
    protected function setCodeName($codeName)
    {
        $this->codeName = $codeName;

        return $this;
    }

    /**
     * Gets the value of state.
     *
     * @return mixed
     */
    public function getState()
    {
        return $this->state;
    }

    /**
     * Sets the value of state.
     *
     * @param mixed $state the state
     *
     * @return self
     */
    protected function setState($state)
    {

    	if ($state != "inProgress" && $state != "finished") {
    		throw new Exception("invalid mission state");
    	}
        $this->state = $state;

        return $this;
    }

    public function completeMission()
    {
    	$this->setState("finished");
    	return $this;
    }
}

Class Sky extends Soldier
{
	protected $codeNumber;

	public function __construct($codeNumber)
	{
		$this->codeNumber = $codeNumber;
	}

    /**
     * Gets the value of codeNumber.
     *
     * @return mixed
     */
    public function getCodeNumber()
    {
        return $this->codeNumber;
    }

    /**
     * Sets the value of codeNumber.
     *
     * @param mixed $codeNumber the code number
     *
     * @return self
     */
    protected function setCodeNumber($codeNumber)
    {
        $this->codeNumber = $codeNumber;

        return $this;
    }

    public function __toString()
    {
    	$output = "Name: " . Soldier::getFirstName() . " " . Soldier::getLastName() . " Id: " . Soldier::getId() . PHP_EOL;
    	$output .= "Code Number: " . $this->getCodeNumber();
    	return $output;
    }
}

$army = [];
$line = trim(fgets(STDIN));

while ($line != "End") {
	$data = explode(" ", $line);
	try {
		switch ($data[0]) {
			case "Private":
			    $private = new PrivateSoldier((int)$data[1], $data[2], $data[3], (float)$data[4]);
			    $army[$private->getId()] = $private;
			    break;
			case "LeutenantGeneral":
				$general = new LeutenantGeneral((int)$data[1], $data[2], $data[3], (float)$data[4]);
			    $privateIds = array_map("intval", array_splice($data, 5));
			    foreach ($privateIds as $privateId) {
			    	$general->addPrivate($army[$privateId]);
			    }
			    $army[$general->getId()] = $general;
			    break;
			case "Engineer":
				$engineer = new Engineer((int)$data[1], $data[2], $data[3], (float)$data[4], $data[5]);
			    $repairData = array_splice($data, 6);
			    for ($i = 0; $i < count($repairData); $i += 2) {
			        $repair = new Repair($repairData[$i], (int)$repairData[$i+1]);
			        $engineer->addRepair($repair);
			    }
			    $army[$engineer->getId()] = $engineer;
			    break;
			case "Commando":
			    $commando = new Commando((int)$data[1], $data[2], $data[3], (float)$data[4], $data[5]);
			    $missionsData = array_splice($data, 6);
			    for ($i = 0; $i < count($missionsData); $i += 2) {
		        	$mission = new Mission($missionsData[$i], $missionsData[$i+1]);
		        	$commando->addMission($mission);
			    }
			    $army[$commando->getId()] = $commando;
			    break;
			case "Spy":
				$spy = new Spy((int)$data[1], $data[2], $data[3]);
				$army[$spy->getId()] = $spy;
			    break;
		}
	} catch (Exception $e) {
		$e->getMessage() . PHP_EOL;
	}
	
	$line = trim(fgets(STDIN));
}

$result = "";
foreach ($army as $soldier){
   $result.= $soldier."\n";
}
echo trim($result);