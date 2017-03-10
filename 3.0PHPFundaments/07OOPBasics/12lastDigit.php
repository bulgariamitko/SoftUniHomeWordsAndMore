<?php

Class Number
{
	protected $number;

	public function __construct(int $number)
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

    public function toWord()
    {
	    $num = (int)$this->getNumber();
	    $words = array();
	    $list1 = array('zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine', 'ten', 'eleven',
	        'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'
	    );
	    $num_levels = str_split($num, 3);
	        $singles = '';
	            $singles = (int) ($num % 10);
	            $singles = ' ' . $list1[$singles] . ' ';
	        $words[] = $singles;
	    return implode(' ', $words);
    }
}

$num = trim(fgets(STDIN));

$number = new Number($num);

echo trim($number->toWord());