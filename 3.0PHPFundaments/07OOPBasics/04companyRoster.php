<?php 

Class Employee {
	protected $name;
	protected $salary;
	protected $position;
	protected $department;
	protected $email;
	protected $age;

	public function __construct($name, $salary, $position = null, $department, $email = null, $age = null)
	{
		$this->name = $name;
		$this->salary = $salary;
		$this->position = $position;
		$this->department = $department;
		$this->email = $email;
		$this->age = $age;
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
     * Gets the value of salary.
     *
     * @return mixed
     */
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

    /**
     * Gets the value of position.
     *
     * @return mixed
     */
    public function getPosition()
    {
        return $this->position;
    }

    /**
     * Sets the value of position.
     *
     * @param mixed $position the position
     *
     * @return self
     */
    protected function setPosition($position)
    {
        $this->position = $position;

        return $this;
    }

    /**
     * Gets the value of department.
     *
     * @return mixed
     */
    public function getDepartment()
    {
        return $this->department;
    }

    /**
     * Sets the value of department.
     *
     * @param mixed $department the department
     *
     * @return self
     */
    protected function setDepartment($department)
    {
        $this->department = $department;

        return $this;
    }

    /**
     * Gets the value of email.
     *
     * @return mixed
     */
    public function getEmail()
    {
        return $this->email;
    }

    /**
     * Sets the value of email.
     *
     * @param mixed $email the email
     *
     * @return self
     */
    protected function setEmail($email)
    {
        $this->email = $email;

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
        $this->age = $age;

        return $this;
    }

    public function __toString()
    {
    	return $this->getName() . " " . $this->getSalary() . " " . $this->getEmail() . " " . $this->getAge();
    }
}


Class Department {
	protected $name;
	protected $employees = [];

	function __construct($name)
	{
		$this->name = $name;
	}

	public function getName() {
		return $this->name;
	}

	protected function setName($name)
    {
        $this->name = $name;
        return $this;
    }

    public function hireEmployee(Employee $employee)
    {
    	$this->employees[] = $employee;
    }

    public function getAverageSalary()
    {
    	return array_sum(array_map(function(Employee $employee) {
    		return $employee->getSalary();
    	}, $this->employees)) / count($this->employees);
    }

    private function sortEmployeesBySalary(bool $desc = false)
    {
    	usort($this->employees, function(Employee $employee1, Employee $employee2) {
    		return $employee1->getSalary() <=> $employee2->getSalary();
    	});

    	if ($desc) {
    		$this->employees = array_reverse($this->employees);
    	}
    }

    public function __toString()
    {
    	$this->sortEmployeesBySalary(true);
    	$output = "";
    	foreach ($this->employees as $employee) {
    		$output .= $employee . PHP_EOL;
    	}

    	return $output;
    }
}

Class Company {
	protected $departments = [];

	public function addDepartment(Department $department)
	{
		$this->departments[$department->getName()] = $department;
	}

	public function hasDepartment(string $name)
	{
		return array_key_exists($name, $this->departments);
	}

	public function getDepartment(string $name)
	{
		if (!array_key_exists($name, $this->departments)) {
			throw new Exception("Department not found!");
		}
		return $this->departments[$name];
	}

	public function getBestPaidDepartment()
	{
		usort($this->departments, function(Department $department1, Department $department2) {
			return $department1->getAverageSalary() <=> $department2->getAverageSalary();
		});
		return $this->departments[count($this->departments) - 1];
	}
}

$company = new Company();
$loop = trim(fgets(STDIN));

for ($i=0; $i < $loop; $i++) { 
	// $line = explode(' ', 'Pesho 48');
	$line = explode(' ', trim(fgets(STDIN)));
	$name = $line[0];
	$salary = number_format(round((float)$line[1], 2), 2);
	$position = $line[2];
	$departmentName = $line[3];
	$email = $line[4] ?? 'n/a';
	$age = $line[5] ?? -1;
	
	if (!$company->hasDepartment($departmentName)) {
		$department = new Department($departmentName);
		$company->addDepartment($department);
	}

	$department = $company->getDepartment($departmentName);

	$employee = new Employee($name, $salary, $position, $department, $email, $age);
	$department->hireEmployee($employee);
}

$bestPaidDepartment = $company->getBestPaidDepartment();
echo "Highest Average Salary: " . $bestPaidDepartment->getName() . PHP_EOL;
echo $bestPaidDepartment;