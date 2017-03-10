<?php

Class DecimalNumber
{
	protected $number;

	public function __construct($number)
	{
		$this->number = $number;
	}

    /**
     * Gets the value of number.
     *
     * @return mixed
     */
    public function getNumber()
    {
        return $this->number;
    }

    /**
     * Sets the value of number.
     *
     * @param mixed $number the number
     *
     * @return self
     */
    protected function setNumber($number)
    {
        $this->number = $number;

        return $this;
    }

    public function reverse()
    {
    	return strrev($this->number);
    }
}

$num = trim(fgets(STDIN));

$number = new DecimalNumber($num);

echo trim($number->reverse());