<?php

Class Human
{
	protected $firstName;
	protected $secondName;

	public function __construct(string $firstName, string $secondName)
	{
		$this->setFirstName($firstName);
		$this->setSecondName($secondName);
	}

    /**
     * Gets the value of firstName.
     *
     * @return mixed
     */
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
    	if (ctype_lower($firstName[0])) {
    		throw new Exception("Expected upper case letter!Argument: firstName");
    	}
    	if (strlen($firstName) < 4) {
    		throw new Exception("Expected length at least 4 symbols!Argument: firstName");
    	}
        $this->firstName = $firstName;

        return $this;
    }

    /**
     * Gets the value of secondName.
     *
     * @return mixed
     */
    public function getSecondName()
    {
        return $this->secondName;
    }

    /**
     * Sets the value of secondName.
     *
     * @param mixed $secondName the second name
     *
     * @return self
     */
    protected function setSecondName($secondName)
    {
    	if (ctype_lower($secondName[0])) {
    		throw new Exception("Expected upper case letter!Argument: lastName");
    	}
    	if (strlen($secondName) < 3) {
    		throw new Exception("Expected length at least 3 symbols!Argument: lastName");
    	}
        $this->secondName = $secondName;

        return $this;
    }

    public function __toString()
    {
    	$output = "First Name: " . $this->getFirstName() . PHP_EOL;
    	$output .= "Last Name: " . $this->getSecondName() . PHP_EOL;
    	return $output;
    }
}

class Student extends Human
{
	protected $facultyNumber;

	function __construct(string $firstName, string $secondName, $facultyNumber)
	{
		parent::__construct($firstName, $secondName);

		$this->setFacultyNumber($facultyNumber);
	}

    /**
     * Gets the value of facultyNumber.
     *
     * @return mixed
     */
    public function getFacultyNumber()
    {
        return $this->facultyNumber;
    }

    /**
     * Sets the value of facultyNumber.
     *
     * @param mixed $facultyNumber the faculty number
     *
     * @return self
     */
    protected function setFacultyNumber($facultyNumber)
    {
    	if (strlen($facultyNumber) < 5 || strlen($facultyNumber) > 11) {
    		throw new Exception("Invalid faculty number!");
    	}
        $this->facultyNumber = $facultyNumber;
        return $this;
    }

    public function __toString()
    {
    	$output = parent::__toString();
    	$output .= "Faculty number: " . $this->getFacultyNumber() . PHP_EOL;
    	return $output;
    }
}

class Worker extends Human
{
	protected $weekSalary;
	protected $workHoursPerWeek;

	function __construct(string $firstName, string $secondName, float $weekSalary, float $workHoursPerWeek)
	{
		parent::__construct($firstName, $secondName);

		$this->setWeekSalary($weekSalary);
		$this->setWorkHoursPerWeek($workHoursPerWeek);
	}

	/**
     * Sets the value of secondName.
     *
     * @param mixed $secondName the second name
     *
     * @return self
     */
    protected function setSecondName($secondName)
    {
    	if (strlen($secondName) < 3) {
    		throw new Exception("Expected length more than 3 symbols!Argument: lastName");
    	}
        parent::setSecondName($secondName);
    }

    /**
     * Gets the value of weekSalary.
     *
     * @return mixed
     */
    public function getWeekSalary()
    {
        return $this->weekSalary;
    }

    /**
     * Sets the value of weekSalary.
     *
     * @param mixed $weekSalary the week salary
     *
     * @return self
     */
    protected function setWeekSalary($weekSalary)
    {
    	if ($weekSalary < 10) {
    		throw new Exception("Expected value mismatch!Argument: weekSalary");
    		
    	}
        $this->weekSalary = $weekSalary;

        return $this;
    }

    /**
     * Gets the value of workHoursPerWeek.
     *
     * @return mixed
     */
    public function getWorkHoursPerWeek()
    {
        return $this->workHoursPerWeek;
    }

    /**
     * Sets the value of workHoursPerWeek.
     *
     * @param mixed $workHoursPerWeek the work hours per week
     *
     * @return self
     */
    protected function setWorkHoursPerWeek($workHoursPerWeek)
    {
    	if ($workHoursPerWeek < 1 || $workHoursPerWeek > 13) {
    		throw new Exception("Expected value mismatch!Argument: workHoursPerDay");
    		
    	}
        $this->workHoursPerWeek = $workHoursPerWeek;

        return $this;
    }

    protected function calculateSalaryPerHour()
    {
    	return $this->getWeekSalary() / 7 / $this->getWorkHoursPerWeek();
    }

    public function __toString()
    {
    	$output = parent::__toString();
    	$output .= "Week Salary: " . number_format($this->getWeekSalary(), 2, ".", "") . PHP_EOL;
    	$output .= "Hours per day: " . number_format($this->getWorkHoursPerWeek(), 2, ".", "") . PHP_EOL;
    	$output .= "Salary per hour: " . number_format($this->calculateSalaryPerHour(), 2, ".", "") . PHP_EOL;
    	return $output;
    }
}

$studentData = explode(" ", trim(fgets(STDIN)));
$workerData = explode(" ", trim(fgets(STDIN)));

try {
	$student = new Student(...$studentData);
	$worker = new Worker($workerData[0], $workerData[1], $workerData[2], $workerData[3]);

	echo $student . PHP_EOL;
	echo $worker . PHP_EOL;
} catch (Exception $e) {
	echo $e->getMessage();
}
